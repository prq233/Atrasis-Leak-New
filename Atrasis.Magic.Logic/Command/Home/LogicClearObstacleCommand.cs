using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200019E RID: 414
	public sealed class LogicClearObstacleCommand : LogicCommand
	{
		// Token: 0x0600170B RID: 5899 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicClearObstacleCommand()
		{
		}

		// Token: 0x0600170C RID: 5900 RVA: 0x0000F116 File Offset: 0x0000D316
		public LogicClearObstacleCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x0600170D RID: 5901 RVA: 0x0000F125 File Offset: 0x0000D325
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600170E RID: 5902 RVA: 0x0000F13A File Offset: 0x0000D33A
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600170F RID: 5903 RVA: 0x0000F14F File Offset: 0x0000D34F
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CLEAR_OBSTACLE;
		}

		// Token: 0x06001710 RID: 5904 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001711 RID: 5905 RVA: 0x000582C8 File Offset: 0x000564C8
		public override int Execute(LogicLevel level)
		{
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID == null || gameObjectByID.GetGameObjectType() != LogicGameObjectType.OBSTACLE)
			{
				return -1;
			}
			LogicObstacle logicObstacle = (LogicObstacle)gameObjectByID;
			if (logicObstacle.GetObstacleData().GetVillageType() == level.GetVillageType())
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				if (logicObstacle.CanStartClearing())
				{
					LogicObstacleData obstacleData = logicObstacle.GetObstacleData();
					if (logicObstacle.GetVillageType() == 1 && playerAvatar.GetVillage2TownHallLevel() < LogicDataTables.GetGlobals().GetMinVillage2TownHallLevelForDestructObstacle() && obstacleData.GetClearCost() > 0)
					{
						return 0;
					}
					LogicResourceData clearResourceData = obstacleData.GetClearResourceData();
					int clearCost = obstacleData.GetClearCost();
					if (playerAvatar.HasEnoughResources(clearResourceData, clearCost, true, this, false))
					{
						if (obstacleData.GetClearTime() == 0 || level.HasFreeWorkers(this, -1))
						{
							playerAvatar.CommodityCountChangeHelper(0, clearResourceData, -clearCost);
							logicObstacle.StartClearing();
							if (logicObstacle.IsTombstone())
							{
								int tombGroup = logicObstacle.GetTombGroup();
								if (tombGroup != 2)
								{
									LogicArrayList<LogicGameObject> gameObjects = level.GetGameObjectManager().GetGameObjects(LogicGameObjectType.OBSTACLE);
									for (int i = 0; i < gameObjects.Size(); i++)
									{
										LogicObstacle logicObstacle2 = (LogicObstacle)gameObjects[i];
										if (logicObstacle2.IsTombstone() && logicObstacle2.GetTombGroup() == tombGroup)
										{
											logicObstacle2.StartClearing();
										}
									}
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

		// Token: 0x04000CC9 RID: 3273
		private int int_1;
	}
}
