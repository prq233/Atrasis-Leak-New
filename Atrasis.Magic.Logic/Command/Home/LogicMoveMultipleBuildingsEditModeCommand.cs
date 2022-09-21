using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001AF RID: 431
	public sealed class LogicMoveMultipleBuildingsEditModeCommand : LogicCommand
	{
		// Token: 0x06001776 RID: 6006 RVA: 0x0000F67F File Offset: 0x0000D87F
		public LogicMoveMultipleBuildingsEditModeCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<int>();
			this.logicArrayList_1 = new LogicArrayList<int>();
			this.logicArrayList_2 = new LogicArrayList<int>();
		}

		// Token: 0x06001777 RID: 6007 RVA: 0x00059824 File Offset: 0x00057A24
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			for (int i = LogicMath.Min(500, stream.ReadInt()); i > 0; i--)
			{
				this.logicArrayList_1.Add(stream.ReadInt());
				this.logicArrayList_2.Add(stream.ReadInt());
				this.logicArrayList_0.Add(stream.ReadInt());
			}
			base.Decode(stream);
		}

		// Token: 0x06001778 RID: 6008 RVA: 0x00059894 File Offset: 0x00057A94
		public override void Encode(ChecksumEncoder encoder)
		{
			int num = this.logicArrayList_0.Size();
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(num);
			for (int i = LogicMath.Min(500, num); i > 0; i--)
			{
				encoder.WriteInt(this.logicArrayList_1[i]);
				encoder.WriteInt(this.logicArrayList_2[i]);
				encoder.WriteInt(this.logicArrayList_0[i]);
			}
			base.Encode(encoder);
		}

		// Token: 0x06001779 RID: 6009 RVA: 0x0000F6A8 File Offset: 0x0000D8A8
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.MOVE_MULTIPLE_BUILDINGS_EDIT_MODE;
		}

		// Token: 0x0600177A RID: 6010 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600177B RID: 6011 RVA: 0x00059914 File Offset: 0x00057B14
		public override int Execute(LogicLevel level)
		{
			int num = this.logicArrayList_0.Size();
			if (num > 0)
			{
				bool flag = true;
				if (this.logicArrayList_1.Size() == num && this.logicArrayList_1.Size() == num && num <= 500)
				{
					LogicGameObject[] array = new LogicGameObject[num];
					for (int i = 0; i < num; i++)
					{
						LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.logicArrayList_0[i]);
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
					if (flag)
					{
						for (int j = 0; j < num; j++)
						{
							LogicGameObject logicGameObject = array[j];
							if (logicGameObject.GetGameObjectType() == LogicGameObjectType.BUILDING && flag)
							{
								LogicBuilding logicBuilding = (LogicBuilding)logicGameObject;
								if (logicBuilding.GetWallIndex() != 0)
								{
									int num2 = this.logicArrayList_1[j];
									int num3 = this.logicArrayList_2[j];
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
												int valueB = num2 - this.logicArrayList_1[k];
												int valueB2 = num3 - this.logicArrayList_2[k];
												if ((num2 & this.logicArrayList_1[k]) != -1)
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
					}
					if (flag)
					{
						for (int l = 0; l < num; l++)
						{
							int num17 = this.logicArrayList_1[l];
							int num18 = this.logicArrayList_2[l];
							LogicGameObject logicGameObject3 = array[l];
							int widthInTiles = logicGameObject3.GetWidthInTiles();
							int heightInTiles = logicGameObject3.GetHeightInTiles();
							int num19 = num17 + widthInTiles;
							int num20 = num18 + heightInTiles;
							for (int m = 0; m < num; m++)
							{
								LogicGameObject logicGameObject4 = array[m];
								if (logicGameObject4 != logicGameObject3)
								{
									int num21 = this.logicArrayList_1[m];
									int num22 = this.logicArrayList_2[m];
									if (num21 != -1 && num22 != -1)
									{
										int widthInTiles2 = logicGameObject4.GetWidthInTiles();
										int heightInTiles2 = logicGameObject4.GetHeightInTiles();
										int num23 = num21 + widthInTiles2;
										int num24 = num22 + heightInTiles2;
										if (num19 > num21 && num20 > num22 && num17 < num23 && num18 < num24)
										{
											return 0;
										}
									}
								}
							}
						}
						bool flag3 = false;
						for (int n = 0; n < num; n++)
						{
							int num25 = this.logicArrayList_1[n];
							int num26 = this.logicArrayList_2[n];
							LogicGameObject logicGameObject5 = array[n];
							LogicVector2 positionLayout = logicGameObject5.GetPositionLayout(this.int_1, true);
							if (positionLayout.m_x != -1 && positionLayout.m_y != -1 && num25 != positionLayout.m_x && num26 != positionLayout.m_y)
							{
								flag3 = true;
							}
							logicGameObject5.SetPositionLayoutXY(num25, num26, this.int_1, true);
							LogicGlobals globals = LogicDataTables.GetGlobals();
							if (!globals.NoCooldownFromMoveEditModeActive() && level.GetActiveLayout(level.GetVillageType()) == this.int_1 && level.GetHomeOwnerAvatar().GetExpLevel() >= globals.GetChallengeBaseCooldownEnabledTownHall())
							{
								level.SetLayoutCooldownSecs(this.int_1, globals.GetChallengeBaseSaveCooldown());
							}
						}
						if (flag3 && level.GetHomeOwnerAvatar().GetExpLevel() >= LogicDataTables.GetGlobals().GetChallengeBaseCooldownEnabledTownHall())
						{
							level.SetLayoutCooldownSecs(this.int_1, LogicDataTables.GetGlobals().GetChallengeBaseSaveCooldown());
						}
						return 0;
					}
				}
			}
			return -1;
		}

		// Token: 0x04000CE4 RID: 3300
		private readonly LogicArrayList<int> logicArrayList_0;

		// Token: 0x04000CE5 RID: 3301
		private readonly LogicArrayList<int> logicArrayList_1;

		// Token: 0x04000CE6 RID: 3302
		private readonly LogicArrayList<int> logicArrayList_2;

		// Token: 0x04000CE7 RID: 3303
		private int int_1;
	}
}
