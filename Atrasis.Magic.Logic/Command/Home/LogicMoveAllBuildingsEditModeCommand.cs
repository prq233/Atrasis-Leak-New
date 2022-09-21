using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001AB RID: 427
	public sealed class LogicMoveAllBuildingsEditModeCommand : LogicCommand
	{
		// Token: 0x0600175C RID: 5980 RVA: 0x0000F493 File Offset: 0x0000D693
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600175D RID: 5981 RVA: 0x0000F4C0 File Offset: 0x0000D6C0
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600175E RID: 5982 RVA: 0x0000F4ED File Offset: 0x0000D6ED
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.MOVE_ALL_BUILDINGS_EDIT_MODE;
		}

		// Token: 0x0600175F RID: 5983 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001760 RID: 5984 RVA: 0x00058D60 File Offset: 0x00056F60
		public override int Execute(LogicLevel level)
		{
			LogicRect playArea = level.GetPlayArea();
			LogicArrayList<LogicGameObject> logicArrayList = new LogicArrayList<LogicGameObject>();
			LogicArrayList<LogicGameObject> logicArrayList2 = new LogicArrayList<LogicGameObject>();
			LogicGameObjectFilter logicGameObjectFilter = new LogicGameObjectFilter();
			logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.BUILDING);
			logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.TRAP);
			logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.DECO);
			LogicArrayList<LogicGameObject> gameObjects = level.GetGameObjectManager().GetGameObjects(LogicGameObjectType.BUILDING);
			LogicArrayList<LogicGameObject> gameObjects2 = level.GetGameObjectManager().GetGameObjects(LogicGameObjectType.OBSTACLE);
			logicArrayList2.AddAll(gameObjects2);
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				LogicBuilding logicBuilding = (LogicBuilding)gameObjects[i];
				if (logicBuilding.IsLocked())
				{
					logicGameObjectFilter.AddIgnoreObject(logicBuilding);
					logicArrayList2.Add(logicBuilding);
				}
			}
			level.GetGameObjectManager().GetGameObjects(logicArrayList, logicGameObjectFilter);
			for (int j = 0; j < logicArrayList.Size(); j++)
			{
				LogicGameObject logicGameObject = logicArrayList[j];
				LogicVector2 positionLayout = logicGameObject.GetPositionLayout(this.int_1, true);
				if (positionLayout.m_x != -1 && positionLayout.m_y != -1)
				{
					int num = positionLayout.m_x + this.int_2;
					int num2 = positionLayout.m_y + this.int_3;
					int widthInTiles = logicGameObject.GetWidthInTiles();
					int heightInTiles = logicGameObject.GetHeightInTiles();
					if (num < playArea.GetStartX() || num2 < playArea.GetStartY() || num + widthInTiles > playArea.GetEndX() || num2 + heightInTiles > playArea.GetEndY())
					{
						return -1;
					}
					if (this.int_1 <= 3 && this.int_1 != 1)
					{
						for (int k = 0; k < logicArrayList2.Size(); k++)
						{
							LogicGameObject logicGameObject2 = logicArrayList2[k];
							if (logicGameObject2 != logicGameObject)
							{
								int tileX = logicGameObject2.GetTileX();
								int tileY = logicGameObject2.GetTileY();
								int widthInTiles2 = logicGameObject2.GetWidthInTiles();
								int heightInTiles2 = logicGameObject2.GetHeightInTiles();
								if (tileX != -1 && tileY != -1 && num + widthInTiles > tileX && num2 + heightInTiles > tileY && num < tileX + widthInTiles2 && num2 < tileY + heightInTiles2)
								{
									return -1;
								}
							}
						}
					}
				}
			}
			for (int l = 0; l < logicArrayList.Size(); l++)
			{
				LogicGameObject logicGameObject3 = logicArrayList[l];
				LogicVector2 positionLayout2 = logicGameObject3.GetPositionLayout(this.int_1, true);
				if (positionLayout2.m_x != -1 && positionLayout2.m_y != -1)
				{
					logicGameObject3.SetPositionLayoutXY(positionLayout2.m_x + this.int_2, positionLayout2.m_y + this.int_3, this.int_1, true);
				}
			}
			logicGameObjectFilter.Destruct();
			return 0;
		}

		// Token: 0x04000CD7 RID: 3287
		private int int_1;

		// Token: 0x04000CD8 RID: 3288
		private int int_2;

		// Token: 0x04000CD9 RID: 3289
		private int int_3;
	}
}
