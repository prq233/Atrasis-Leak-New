using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001DF RID: 479
	public sealed class LogicUpgradeBuildingCommand : LogicCommand
	{
		// Token: 0x060018B5 RID: 6325 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicUpgradeBuildingCommand()
		{
		}

		// Token: 0x060018B6 RID: 6326 RVA: 0x000106E3 File Offset: 0x0000E8E3
		public LogicUpgradeBuildingCommand(int gameObjectId, bool useAltResource)
		{
			this.int_1 = gameObjectId;
			this.bool_0 = useAltResource;
		}

		// Token: 0x060018B7 RID: 6327 RVA: 0x000106F9 File Offset: 0x0000E8F9
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x060018B8 RID: 6328 RVA: 0x0001071A File Offset: 0x0000E91A
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteBoolean(this.bool_0);
			base.Encode(encoder);
		}

		// Token: 0x060018B9 RID: 6329 RVA: 0x0001073B File Offset: 0x0000E93B
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.UPGRADE_BUILDING;
		}

		// Token: 0x060018BA RID: 6330 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060018BB RID: 6331 RVA: 0x0005C858 File Offset: 0x0005AA58
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null)
			{
				if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
					LogicBuildingData buildingData = logicBuilding.GetBuildingData();
					if (buildingData.IsTownHallVillage2() && !LogicUpgradeBuildingCommand.smethod_0(level))
					{
						return -76;
					}
					if (buildingData.GetVillageType() != level.GetVillageType())
					{
						return -32;
					}
					if (level.GetGameObjectManager().GetAvailableBuildingUpgradeCount(logicBuilding) <= 0)
					{
						return -34;
					}
					if (logicBuilding.GetWallIndex() == 0)
					{
						if (logicBuilding.CanUpgrade(true))
						{
							int num = logicBuilding.GetUpgradeLevel() + 1;
							int buildCost = buildingData.GetBuildCost(num, level);
							LogicResourceData logicResourceData = this.bool_0 ? buildingData.GetAltBuildResource(num) : buildingData.GetBuildResource(num);
							if (logicResourceData != null)
							{
								LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
								if (playerAvatar.HasEnoughResources(logicResourceData, buildCost, true, this, false))
								{
									if ((buildingData.GetConstructionTime(num, level, 0) != 0 || LogicDataTables.GetGlobals().WorkerForZeroBuilTime()) && !level.HasFreeWorkers(this, -1))
									{
										return -1;
									}
									playerAvatar.CommodityCountChangeHelper(0, logicResourceData, -buildCost);
									logicBuilding.StartUpgrading(true, false);
									return 0;
								}
							}
						}
						return -1;
					}
					return -35;
				}
				else if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.TRAP)
				{
					LogicTrap logicTrap = (LogicTrap)gameObjectByID;
					if (logicTrap.CanUpgrade(true))
					{
						LogicTrapData trapData = logicTrap.GetTrapData();
						LogicResourceData buildResource = trapData.GetBuildResource();
						LogicClientAvatar playerAvatar2 = level.GetPlayerAvatar();
						int buildCost2 = trapData.GetBuildCost(logicTrap.GetUpgradeLevel() + 1);
						if (playerAvatar2.HasEnoughResources(buildResource, buildCost2, true, this, false))
						{
							if ((trapData.GetBuildTime(logicTrap.GetUpgradeLevel() + 1) != 0 || LogicDataTables.GetGlobals().WorkerForZeroBuilTime()) && !level.HasFreeWorkers(this, -1))
							{
								return -1;
							}
							playerAvatar2.CommodityCountChangeHelper(0, buildResource, -buildCost2);
							logicTrap.StartUpgrading();
							return 0;
						}
					}
				}
				else if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.VILLAGE_OBJECT)
				{
					if (!this.bool_0)
					{
						LogicVillageObject logicVillageObject = (LogicVillageObject)gameObjectByID;
						if (logicVillageObject.CanUpgrade(true))
						{
							LogicVillageObjectData villageObjectData = logicVillageObject.GetVillageObjectData();
							LogicResourceData buildResource2 = villageObjectData.GetBuildResource();
							int buildCost3 = villageObjectData.GetBuildCost(logicVillageObject.GetUpgradeLevel() + 1);
							if (buildResource2 != null)
							{
								LogicClientAvatar playerAvatar3 = level.GetPlayerAvatar();
								if (playerAvatar3.HasEnoughResources(buildResource2, buildCost3, true, this, false))
								{
									if ((villageObjectData.GetBuildTime(logicVillageObject.GetUpgradeLevel() + 1) != 0 || LogicDataTables.GetGlobals().WorkerForZeroBuilTime()) && !level.HasFreeWorkers(this, -1))
									{
										return -1;
									}
									playerAvatar3.CommodityCountChangeHelper(0, buildResource2, -buildCost3);
									logicVillageObject.StartUpgrading(true);
									return 0;
								}
							}
						}
						return -1;
					}
					return -31;
				}
			}
			return -1;
		}

		// Token: 0x060018BC RID: 6332 RVA: 0x0005CAC4 File Offset: 0x0005ACC4
		private static bool smethod_0(LogicLevel logicLevel_0)
		{
			if (logicLevel_0.GetVillageType() == 1)
			{
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.BUILDING);
				for (int i = 0; i < table.GetItemCount(); i++)
				{
					LogicBuildingData logicBuildingData = (LogicBuildingData)table.GetItemAt(i);
					if (logicBuildingData.GetVillageType() == 1 && !logicLevel_0.IsBuildingCapReached(logicBuildingData, false))
					{
						return false;
					}
				}
				LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.TRAP);
				for (int j = 0; j < table2.GetItemCount(); j++)
				{
					LogicTrapData logicTrapData = (LogicTrapData)table2.GetItemAt(j);
					if (logicTrapData.GetVillageType() == 1 && !logicLevel_0.IsTrapCapReached(logicTrapData, false))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x04000D41 RID: 3393
		private int int_1;

		// Token: 0x04000D42 RID: 3394
		private bool bool_0;
	}
}
