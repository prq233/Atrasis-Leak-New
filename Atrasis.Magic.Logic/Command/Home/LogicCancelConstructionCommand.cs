using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000198 RID: 408
	public sealed class LogicCancelConstructionCommand : LogicCommand
	{
		// Token: 0x060016E1 RID: 5857 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicCancelConstructionCommand()
		{
		}

		// Token: 0x060016E2 RID: 5858 RVA: 0x0000EF76 File Offset: 0x0000D176
		public LogicCancelConstructionCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x060016E3 RID: 5859 RVA: 0x0000EF85 File Offset: 0x0000D185
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060016E4 RID: 5860 RVA: 0x0000EF9A File Offset: 0x0000D19A
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060016E5 RID: 5861 RVA: 0x0000EFAF File Offset: 0x0000D1AF
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CANCEL_CONSTRUCTION;
		}

		// Token: 0x060016E6 RID: 5862 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060016E7 RID: 5863 RVA: 0x00057B04 File Offset: 0x00055D04
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null)
			{
				if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING)
				{
					LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
					if (!LogicDataTables.GetGlobals().AllowCancelBuildingConstruction() && logicBuilding.GetUpgradeLevel() == 0 && logicBuilding.IsConstructing() && !logicBuilding.IsUpgrading())
					{
						return -2;
					}
					if (logicBuilding.IsConstructing())
					{
						logicBuilding.GetListener().CancelNotification();
						logicBuilding.CancelConstruction();
						return 0;
					}
				}
				else if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.OBSTACLE)
				{
					LogicObstacle logicObstacle = (LogicObstacle)gameObjectByID;
					if (logicObstacle.IsClearingOnGoing())
					{
						LogicObstacleData obstacleData = logicObstacle.GetObstacleData();
						level.GetPlayerAvatar().CommodityCountChangeHelper(0, obstacleData.GetClearResourceData(), obstacleData.GetClearCost());
						logicObstacle.CancelClearing();
						return 0;
					}
				}
				else if (gameObjectByID.GetGameObjectType() == LogicGameObjectType.TRAP)
				{
					LogicTrap logicTrap = (LogicTrap)gameObjectByID;
					if (logicTrap.IsConstructing())
					{
						logicTrap.GetListener().CancelNotification();
						logicTrap.CancelConstruction();
						return 0;
					}
				}
			}
			return -1;
		}

		// Token: 0x04000CBA RID: 3258
		private int int_1;
	}
}
