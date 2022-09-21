using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000190 RID: 400
	public sealed class LogicBuyBuildingCommand : LogicCommand
	{
		// Token: 0x060016AC RID: 5804 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicBuyBuildingCommand()
		{
		}

		// Token: 0x060016AD RID: 5805 RVA: 0x0000EC7F File Offset: 0x0000CE7F
		public LogicBuyBuildingCommand(int x, int y, LogicBuildingData buildingData)
		{
			this.int_1 = x;
			this.int_2 = y;
			this.logicBuildingData_0 = buildingData;
		}

		// Token: 0x060016AE RID: 5806 RVA: 0x0000EC9C File Offset: 0x0000CE9C
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.logicBuildingData_0 = (LogicBuildingData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.BUILDING);
			base.Decode(stream);
		}

		// Token: 0x060016AF RID: 5807 RVA: 0x0000ECCF File Offset: 0x0000CECF
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			ByteStreamHelper.WriteDataReference(encoder, this.logicBuildingData_0);
			base.Encode(encoder);
		}

		// Token: 0x060016B0 RID: 5808 RVA: 0x0000ECFC File Offset: 0x0000CEFC
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.BUY_BUILDING;
		}

		// Token: 0x060016B1 RID: 5809 RVA: 0x0000ED03 File Offset: 0x0000CF03
		public override void Destruct()
		{
			base.Destruct();
			this.int_1 = 0;
			this.int_2 = 0;
			this.logicBuildingData_0 = null;
		}

		// Token: 0x060016B2 RID: 5810 RVA: 0x00056C68 File Offset: 0x00054E68
		public override int Execute(LogicLevel level)
		{
			int villageType = level.GetVillageType();
			if (!this.logicBuildingData_0.IsEnabledInVillageType(level.GetVillageType()))
			{
				return -32;
			}
			if (this.logicBuildingData_0.GetWallBlockCount() <= 1 && this.logicBuildingData_0.GetBuildingClass().CanBuy() && level.IsValidPlaceForBuilding(this.int_1, this.int_2, this.logicBuildingData_0.GetWidth(), this.logicBuildingData_0.GetHeight(), null) && !level.IsBuildingCapReached(this.logicBuildingData_0, true) && level.GetCalendar().IsEnabled(this.logicBuildingData_0))
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				LogicResourceData buildResource = this.logicBuildingData_0.GetBuildResource(0);
				int buildCost = this.logicBuildingData_0.GetBuildCost(0, level);
				if (playerAvatar.HasEnoughResources(buildResource, buildCost, true, this, false) && (this.logicBuildingData_0.IsWorkerBuilding() || (this.logicBuildingData_0.GetConstructionTime(0, level, 0) <= 0 && !LogicDataTables.GetGlobals().WorkerForZeroBuilTime()) || level.HasFreeWorkers(this, -1)))
				{
					if (buildResource.IsPremiumCurrency())
					{
						playerAvatar.UseDiamonds(buildCost);
						playerAvatar.GetChangeListener().DiamondPurchaseMade(1, this.logicBuildingData_0.GetGlobalID(), 0, buildCost, villageType);
					}
					else
					{
						playerAvatar.CommodityCountChangeHelper(0, buildResource, -buildCost);
					}
					LogicBuilding logicBuilding = (LogicBuilding)LogicGameObjectFactory.CreateGameObject(this.logicBuildingData_0, level, villageType);
					logicBuilding.SetInitialPosition(this.int_1 << 9, this.int_2 << 9);
					level.GetGameObjectManager().AddGameObject(logicBuilding, -1);
					logicBuilding.StartConstructing(false);
					if (this.logicBuildingData_0.IsWall() && level.IsBuildingCapReached(this.logicBuildingData_0, false))
					{
						level.GetGameListener().BuildingCapReached(this.logicBuildingData_0);
					}
					int widthInTiles = logicBuilding.GetWidthInTiles();
					int heightInTiles = logicBuilding.GetHeightInTiles();
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
				}
				return 0;
			}
			return -33;
		}

		// Token: 0x04000CA9 RID: 3241
		private int int_1;

		// Token: 0x04000CAA RID: 3242
		private int int_2;

		// Token: 0x04000CAB RID: 3243
		private LogicBuildingData logicBuildingData_0;
	}
}
