using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001DE RID: 478
	public sealed class LogicUnlockBuildingCommand : LogicCommand
	{
		// Token: 0x060018AE RID: 6318 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicUnlockBuildingCommand()
		{
		}

		// Token: 0x060018AF RID: 6319 RVA: 0x000106A3 File Offset: 0x0000E8A3
		public LogicUnlockBuildingCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x060018B0 RID: 6320 RVA: 0x000106B2 File Offset: 0x0000E8B2
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060018B1 RID: 6321 RVA: 0x000106C7 File Offset: 0x0000E8C7
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060018B2 RID: 6322 RVA: 0x000106DC File Offset: 0x0000E8DC
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.UNLOCK_BUILDING;
		}

		// Token: 0x060018B3 RID: 6323 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060018B4 RID: 6324 RVA: 0x0005C7A0 File Offset: 0x0005A9A0
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
			{
				LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
				if (logicBuilding.IsLocked() && logicBuilding.GetUpgradeLevel() == 0 && logicBuilding.CanUnlock(true))
				{
					LogicBuildingData buildingData = logicBuilding.GetBuildingData();
					if (buildingData.GetConstructionTime(0, level, 0) == 0 || level.HasFreeWorkers(this, -1))
					{
						LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
						LogicResourceData buildResource = buildingData.GetBuildResource(0);
						int buildCost = buildingData.GetBuildCost(0, level);
						if (playerAvatar.HasEnoughResources(buildResource, buildCost, true, this, false))
						{
							playerAvatar.CommodityCountChangeHelper(0, buildResource, -buildCost);
							logicBuilding.StartConstructing(true);
							logicBuilding.GetListener().RefreshState();
							return 0;
						}
					}
				}
			}
			return -1;
		}

		// Token: 0x04000D40 RID: 3392
		private int int_1;
	}
}
