using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001AE RID: 430
	public sealed class LogicMoveMultipleBuildingsCommand : LogicCommand
	{
		// Token: 0x0600176F RID: 5999 RVA: 0x0000F5EB File Offset: 0x0000D7EB
		public LogicMoveMultipleBuildingsCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<int>(500);
			this.logicArrayList_1 = new LogicArrayList<int>(500);
			this.logicArrayList_2 = new LogicArrayList<int>(500);
		}

		// Token: 0x06001770 RID: 6000 RVA: 0x00059270 File Offset: 0x00057470
		public override void Decode(ByteStream stream)
		{
			for (int i = LogicMath.Min(stream.ReadInt(), 500); i > 0; i--)
			{
				this.logicArrayList_0.Add(stream.ReadInt());
				this.logicArrayList_1.Add(stream.ReadInt());
				this.logicArrayList_2.Add(stream.ReadInt());
			}
			base.Decode(stream);
		}

		// Token: 0x06001771 RID: 6001 RVA: 0x000592D4 File Offset: 0x000574D4
		public override void Encode(ChecksumEncoder encoder)
		{
			int num = LogicMath.Min(this.logicArrayList_2.Size(), 500);
			encoder.WriteInt(num);
			for (int i = 0; i < num; i++)
			{
				encoder.WriteInt(this.logicArrayList_0[i]);
				encoder.WriteInt(this.logicArrayList_1[i]);
				encoder.WriteInt(this.logicArrayList_2[i]);
			}
			base.Encode(encoder);
		}

		// Token: 0x06001772 RID: 6002 RVA: 0x0000F623 File Offset: 0x0000D823
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.MOVE_MULTIPLE_BUILDING;
		}

		// Token: 0x06001773 RID: 6003 RVA: 0x0000F62A File Offset: 0x0000D82A
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
			this.logicArrayList_1 = null;
			this.logicArrayList_2 = null;
		}

		// Token: 0x06001774 RID: 6004 RVA: 0x00059348 File Offset: 0x00057548
		public override int Execute(LogicLevel level)
		{
			int num = this.logicArrayList_2.Size();
			if (num > 0)
			{
				bool flag = true;
				if (this.logicArrayList_0.Size() == num && this.logicArrayList_0.Size() == num && num <= 500)
				{
					LogicGameObject[] array = new LogicGameObject[num];
					for (int i = 0; i < num; i++)
					{
						LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.logicArrayList_2[i]);
						if (gameObjectByID != null)
						{
							LogicGameObjectType gameObjectType = gameObjectByID.GetGameObjectType();
							if (gameObjectType != LogicGameObjectType.BUILDING && gameObjectType != LogicGameObjectType.TRAP && gameObjectType != LogicGameObjectType.DECO)
							{
								flag = false;
							}
							array[i] = gameObjectByID;
						}
						else
						{
							flag = false;
						}
					}
					if (!flag)
					{
						Debugger.Warning("EditModeInvalidGameObjectType");
						return -1;
					}
					for (int j = 0; j < num; j++)
					{
						LogicGameObject logicGameObject = array[j];
						if (logicGameObject.GetGameObjectType() == LogicGameObjectType.BUILDING && flag)
						{
							LogicBuilding logicBuilding = (LogicBuilding)logicGameObject;
							if (logicBuilding.GetWallIndex() != 0)
							{
								int num2 = this.logicArrayList_0[j];
								int num3 = this.logicArrayList_1[j];
								int num4 = 0;
								int num5 = 0;
								int num6 = 0;
								int num7 = 0;
								int num8 = 0;
								int num9 = 0;
								int num10 = 0;
								int num11 = 0;
								int num12 = 0;
								bool flag2 = true;
								for (int k = 0; k < num; k++)
								{
									LogicGameObject logicGameObject2 = array[k];
									if (logicGameObject2.GetGameObjectType() == LogicGameObjectType.BUILDING)
									{
										LogicBuilding logicBuilding2 = (LogicBuilding)logicGameObject2;
										if (logicBuilding2.GetWallIndex() == logicBuilding.GetWallIndex())
										{
											int valueB = num2 - this.logicArrayList_0[k];
											int valueB2 = num3 - this.logicArrayList_1[k];
											if ((num2 & this.logicArrayList_0[k]) != -1)
											{
												flag2 = false;
											}
											num4 = LogicMath.Min(num4, valueB);
											num5 = LogicMath.Min(num5, valueB2);
											num6 = LogicMath.Max(num6, valueB);
											num7 = LogicMath.Max(num7, valueB2);
											int wallBlockX = logicBuilding2.GetBuildingData().GetWallBlockX(num12);
											int wallBlockY = logicBuilding2.GetBuildingData().GetWallBlockY(num12);
											num8 = LogicMath.Min(num8, wallBlockX);
											num9 = LogicMath.Min(num9, wallBlockY);
											num10 = LogicMath.Max(num10, wallBlockX);
											num11 = LogicMath.Max(num11, wallBlockY);
											num12++;
										}
									}
								}
								if (logicBuilding.GetBuildingData().GetWallBlockCount() == num12)
								{
									int num13 = num10 - num8;
									int num14 = num11 - num9;
									int num15 = num6 - num4;
									int num16 = num7 - num5;
									if ((num13 != num15 || num14 != num16) && !flag2 && num13 != num15 != (num14 != num16))
									{
										flag = false;
									}
								}
							}
						}
					}
					if (flag)
					{
						for (int l = 0; l < num; l++)
						{
							int num17 = this.logicArrayList_0[l];
							int num18 = this.logicArrayList_1[l];
							LogicGameObject logicGameObject3 = array[l];
							int num19 = num17 + logicGameObject3.GetWidthInTiles();
							int num20 = num18 + logicGameObject3.GetHeightInTiles();
							for (int m = 0; m < num; m++)
							{
								LogicGameObject logicGameObject4 = array[m];
								if (logicGameObject4 != logicGameObject3)
								{
									int num21 = this.logicArrayList_0[m];
									int num22 = this.logicArrayList_1[m];
									int num23 = num21 + logicGameObject4.GetWidthInTiles();
									int num24 = num22 + logicGameObject4.GetHeightInTiles();
									if (num19 > num21 && num20 > num22 && num17 < num23 && num18 < num24)
									{
										Debugger.Warning("EditModeObjectsOverlap");
										return -1;
									}
								}
							}
						}
					}
					if (flag)
					{
						for (int n = 0; n < num; n++)
						{
							int x = this.logicArrayList_0[n];
							int y = this.logicArrayList_1[n];
							LogicGameObject logicGameObject5 = array[n];
							int widthInTiles = logicGameObject5.GetWidthInTiles();
							int heightInTiles = logicGameObject5.GetHeightInTiles();
							if (!level.IsValidPlaceForBuildingWithIgnoreList(x, y, widthInTiles, heightInTiles, array, num))
							{
								Debugger.Warning("EditModeInvalidPosition");
								return -1;
							}
						}
					}
					if (flag)
					{
						for (int num25 = 0; num25 < num; num25++)
						{
							int num26 = this.logicArrayList_0[num25];
							int num27 = this.logicArrayList_1[num25];
							array[num25].SetPositionXY(num26 << 9, num27 << 9);
						}
						for (int num28 = 0; num28 < num; num28++)
						{
							int num29 = this.logicArrayList_0[num28];
							int num30 = this.logicArrayList_1[num28];
							LogicGameObject logicGameObject6 = array[num28];
							int widthInTiles2 = logicGameObject6.GetWidthInTiles();
							int heightInTiles2 = logicGameObject6.GetHeightInTiles();
							for (int num31 = 0; num31 < widthInTiles2; num31++)
							{
								for (int num32 = 0; num32 < heightInTiles2; num32++)
								{
									LogicObstacle tallGrass = level.GetTileMap().GetTile(num29 + num31, num30 + num32).GetTallGrass();
									if (tallGrass != null)
									{
										level.GetGameObjectManager().RemoveGameObject(tallGrass);
									}
								}
							}
						}
						if (level.GetHomeOwnerAvatar() != null && level.GetHomeOwnerAvatar().GetTownHallLevel() >= LogicDataTables.GetGlobals().GetChallengeBaseCooldownEnabledTownHall())
						{
							level.SetLayoutCooldownSecs(level.GetActiveLayout(level.GetVillageType()), LogicDataTables.GetGlobals().GetChallengeBaseSaveCooldown());
						}
						return 0;
					}
				}
				else
				{
					Debugger.Warning("EditModeSizeMismatch");
				}
				return -1;
			}
			return -92;
		}

		// Token: 0x06001775 RID: 6005 RVA: 0x0000F647 File Offset: 0x0000D847
		public void AddNewMove(int gameObjectId, int x, int y)
		{
			if (this.logicArrayList_2.Size() < 500)
			{
				this.logicArrayList_2.Add(gameObjectId);
				this.logicArrayList_0.Add(x);
				this.logicArrayList_1.Add(y);
			}
		}

		// Token: 0x04000CE1 RID: 3297
		private LogicArrayList<int> logicArrayList_0;

		// Token: 0x04000CE2 RID: 3298
		private LogicArrayList<int> logicArrayList_1;

		// Token: 0x04000CE3 RID: 3299
		private LogicArrayList<int> logicArrayList_2;
	}
}
