using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001BE RID: 446
	public sealed class LogicSellBuildingCommand : LogicCommand
	{
		// Token: 0x060017D8 RID: 6104 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSellBuildingCommand()
		{
		}

		// Token: 0x060017D9 RID: 6105 RVA: 0x0000FBFF File Offset: 0x0000DDFF
		public LogicSellBuildingCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x060017DA RID: 6106 RVA: 0x0000FC0E File Offset: 0x0000DE0E
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060017DB RID: 6107 RVA: 0x0000FC23 File Offset: 0x0000DE23
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060017DC RID: 6108 RVA: 0x0000FC38 File Offset: 0x0000DE38
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SELL_BUILDING;
		}

		// Token: 0x060017DD RID: 6109 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017DE RID: 6110 RVA: 0x0005AF84 File Offset: 0x00059184
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null)
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
					if (logicBuilding.CanSell())
					{
						playerAvatar.CommodityCountChangeHelper(0, logicBuilding.GetSellResource(), logicBuilding.GetSellPrice());
						logicBuilding.OnSell();
						level.GetGameObjectManager().RemoveGameObject(logicBuilding);
						return 0;
					}
				}
				else if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.DECO)
				{
					LogicDeco logicDeco = (LogicDeco)gameObjectByID;
					LogicDecoData decoData = logicDeco.GetDecoData();
					LogicResourceData buildResource = decoData.GetBuildResource();
					int sellPrice = decoData.GetSellPrice();
					if (buildResource.IsPremiumCurrency())
					{
						playerAvatar.SetDiamonds(playerAvatar.GetDiamonds() + sellPrice);
						playerAvatar.SetFreeDiamonds(playerAvatar.GetFreeDiamonds() + sellPrice);
						playerAvatar.GetChangeListener().FreeDiamondsAdded(sellPrice, 6);
					}
					else
					{
						playerAvatar.CommodityCountChangeHelper(0, buildResource, sellPrice);
					}
					level.GetGameObjectManager().RemoveGameObject(logicDeco);
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000D0A RID: 3338
		private int int_1;
	}
}
