using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000191 RID: 401
	public sealed class LogicBuyDecoCommand : LogicCommand
	{
		// Token: 0x060016B3 RID: 5811 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicBuyDecoCommand()
		{
		}

		// Token: 0x060016B4 RID: 5812 RVA: 0x0000ED20 File Offset: 0x0000CF20
		public LogicBuyDecoCommand(int x, int y, LogicDecoData decoData)
		{
			this.int_1 = x;
			this.int_2 = y;
			this.logicDecoData_0 = decoData;
		}

		// Token: 0x060016B5 RID: 5813 RVA: 0x0000ED3D File Offset: 0x0000CF3D
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.logicDecoData_0 = (LogicDecoData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.DECO);
			base.Decode(stream);
		}

		// Token: 0x060016B6 RID: 5814 RVA: 0x0000ED71 File Offset: 0x0000CF71
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			ByteStreamHelper.WriteDataReference(encoder, this.logicDecoData_0);
			base.Encode(encoder);
		}

		// Token: 0x060016B7 RID: 5815 RVA: 0x0000ED9E File Offset: 0x0000CF9E
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.BUY_DECO;
		}

		// Token: 0x060016B8 RID: 5816 RVA: 0x0000EDA5 File Offset: 0x0000CFA5
		public override void Destruct()
		{
			base.Destruct();
			this.int_1 = 0;
			this.int_2 = 0;
			this.logicDecoData_0 = null;
		}

		// Token: 0x060016B9 RID: 5817 RVA: 0x00056E8C File Offset: 0x0005508C
		public override int Execute(LogicLevel level)
		{
			if (this.logicDecoData_0 == null)
			{
				return -1;
			}
			if (this.logicDecoData_0.IsEnabledInVillageType(level.GetVillageType()))
			{
				if (level.IsValidPlaceForBuilding(this.int_1, this.int_2, this.logicDecoData_0.GetWidth(), this.logicDecoData_0.GetHeight(), null))
				{
					LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
					LogicResourceData buildResource = this.logicDecoData_0.GetBuildResource();
					int buildCost = this.logicDecoData_0.GetBuildCost();
					if (playerAvatar.HasEnoughResources(buildResource, buildCost, true, this, false) && !level.IsDecoCapReached(this.logicDecoData_0, true))
					{
						if (buildResource.IsPremiumCurrency())
						{
							playerAvatar.UseDiamonds(buildCost);
							playerAvatar.GetChangeListener().DiamondPurchaseMade(1, this.logicDecoData_0.GetGlobalID(), 0, buildCost, level.GetVillageType());
						}
						else
						{
							playerAvatar.CommodityCountChangeHelper(0, buildResource, -buildCost);
						}
						LogicDeco logicDeco = (LogicDeco)LogicGameObjectFactory.CreateGameObject(this.logicDecoData_0, level, level.GetVillageType());
						logicDeco.SetInitialPosition(this.int_1 << 9, this.int_2 << 9);
						level.GetGameObjectManager().AddGameObject(logicDeco, -1);
						int widthInTiles = logicDeco.GetWidthInTiles();
						int heightInTiles = logicDeco.GetHeightInTiles();
						for (int i = 0; i < widthInTiles; i++)
						{
							for (int j = 0; j < heightInTiles; j++)
							{
								LogicObstacle tallGrass = level.GetTileMap().GetTile(this.int_1 + i, this.int_2 + j).GetTallGrass();
								if (tallGrass != null)
								{
									level.GetGameObjectManager().RemoveGameObject(tallGrass);
								}
							}
						}
						return 0;
					}
				}
				return -1;
			}
			return -32;
		}

		// Token: 0x04000CAC RID: 3244
		private int int_1;

		// Token: 0x04000CAD RID: 3245
		private int int_2;

		// Token: 0x04000CAE RID: 3246
		private LogicDecoData logicDecoData_0;
	}
}
