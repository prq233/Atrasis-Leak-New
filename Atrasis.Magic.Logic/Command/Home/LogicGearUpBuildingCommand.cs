using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A6 RID: 422
	public sealed class LogicGearUpBuildingCommand : LogicCommand
	{
		// Token: 0x0600173C RID: 5948 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicGearUpBuildingCommand()
		{
		}

		// Token: 0x0600173D RID: 5949 RVA: 0x0000F367 File Offset: 0x0000D567
		public LogicGearUpBuildingCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x0600173E RID: 5950 RVA: 0x0000F376 File Offset: 0x0000D576
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600173F RID: 5951 RVA: 0x0000F38B File Offset: 0x0000D58B
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001740 RID: 5952 RVA: 0x0000F3A0 File Offset: 0x0000D5A0
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.GEAR_UP_BUILDING;
		}

		// Token: 0x06001741 RID: 5953 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001742 RID: 5954 RVA: 0x000589AC File Offset: 0x00056BAC
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID == null || gameObjectByID.GetGameObjectType() != LogicGameObjectType.BUILDING)
			{
				return -1;
			}
			LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
			LogicBuildingData buildingData = logicBuilding.GetBuildingData();
			if (buildingData.GetVillageType() != level.GetVillageType())
			{
				return -32;
			}
			if (level.IsBuildingGearUpCapReached(buildingData, true))
			{
				return -31;
			}
			if (logicBuilding.GetGearLevel() != 0)
			{
				return -35;
			}
			int upgradeLevel = logicBuilding.GetUpgradeLevel();
			int gearUpCost = buildingData.GetGearUpCost(upgradeLevel);
			if (gearUpCost <= 0)
			{
				return -36;
			}
			if (upgradeLevel < buildingData.GetMinUpgradeLevelForGearUp())
			{
				return -37;
			}
			if (level.GetGameObjectManagerAt(1).GetHighestBuildingLevel(buildingData.GetGearUpBuildingData()) < buildingData.GetGearUpLevelRequirement())
			{
				return -1;
			}
			LogicResourceData gearUpResource = buildingData.GetGearUpResource();
			if (gearUpResource != null)
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if (playerAvatar.HasEnoughResources(gearUpResource, gearUpCost, true, this, false) && level.HasFreeWorkers(this, 1))
				{
					playerAvatar.CommodityCountChangeHelper(0, gearUpResource, -gearUpCost);
					logicBuilding.StartUpgrading(true, true);
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x04000CD2 RID: 3282
		private int int_1;
	}
}
