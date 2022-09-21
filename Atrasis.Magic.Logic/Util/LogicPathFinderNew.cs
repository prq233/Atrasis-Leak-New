using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Util
{
	// Token: 0x0200000E RID: 14
	public sealed class LogicPathFinderNew : LogicPathFinder
	{
		// Token: 0x06000067 RID: 103 RVA: 0x000135AC File Offset: 0x000117AC
		public LogicPathFinderNew(LogicTileMap tileMap) : base(tileMap)
		{
			this.int_4 = -1;
			this.int_5 = -1;
			if (tileMap != null)
			{
				this.int_0 = tileMap.GetSizeX();
				this.int_1 = tileMap.GetSizeY();
			}
			else
			{
				this.int_0 = 3;
				this.int_1 = 4;
			}
			this.logicSavedPath_0 = new LogicSavedPath[30];
			int i = 0;
			int size = this.int_0 * 4;
			while (i < 30)
			{
				this.logicSavedPath_0[i] = new LogicSavedPath(size);
				i++;
			}
			int num = 4 * this.int_0 * this.int_1;
			this.int_8 = new int[num];
			this.int_11 = new int[num];
			this.int_9 = new int[num];
			this.int_10 = new int[num];
			this.int_12 = new int[num];
			this.logicVector2_0 = new LogicVector2();
			this.ResetCostStrategyToDefault();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00013688 File Offset: 0x00011888
		public override void Destruct()
		{
			base.Destruct();
			for (int i = 0; i < 30; i++)
			{
				if (this.logicSavedPath_0[i] != null)
				{
					this.logicSavedPath_0[i].Destruct();
					this.logicSavedPath_0[i] = null;
				}
			}
			if (this.logicVector2_0 != null)
			{
				this.logicVector2_0.Destruct();
				this.logicVector2_0 = null;
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000136E4 File Offset: 0x000118E4
		public unsafe void AStar(int startTile, int endTile)
		{
			for (int i = 0; i < 30; i++)
			{
				LogicSavedPath logicSavedPath = this.logicSavedPath_0[i];
				if (logicSavedPath.IsEqual(startTile, endTile, this.int_2))
				{
					this.int_3 = logicSavedPath.GetLength();
					logicSavedPath.ExtractPath(this.int_10);
					return;
				}
			}
			this.int_4 = endTile % this.int_0;
			this.int_5 = endTile / this.int_0;
			this.int_6 = 0;
			int num = 4 * this.int_1 * this.int_0;
			int[] array;
			int* ptr;
			if ((array = this.int_8) != null && array.Length != 0)
			{
				ptr = &array[0];
			}
			else
			{
				ptr = null;
			}
			int[] array2;
			int* ptr2;
			if ((array2 = this.int_12) != null && array2.Length != 0)
			{
				ptr2 = &array2[0];
			}
			else
			{
				ptr2 = null;
			}
			int[] array3;
			int* ptr3;
			if ((array3 = this.int_11) != null && array3.Length != 0)
			{
				ptr3 = &array3[0];
			}
			else
			{
				ptr3 = null;
			}
			LogicCpp.MemSet(ptr, 0, num * 4);
			LogicCpp.MemSet(ptr2, 0, num * 4);
			LogicCpp.MemSet(ptr3, int.MaxValue, num * 4);
			array3 = null;
			array2 = null;
			array = null;
			this.int_3 = 0;
			int[] array4 = this.int_10;
			int num2 = this.int_3;
			this.int_3 = num2 + 1;
			array4[num2] = startTile;
			this.int_9[startTile] = -1;
			this.int_9[endTile] = -1;
			this.AStarAddTile(startTile);
			int[] array5 = this.int_10;
			int num3 = 0;
			int[] array6 = this.int_10;
			num2 = this.int_3;
			this.int_3 = num2 - 1;
			array5[num3] = array6[num2 - 1];
			this.int_8[startTile] = 2;
			if (this.int_6 != 0 && this.int_3 != 0)
			{
				do
				{
					int num4 = this.RemoveSmallest();
					this.int_8[num4] = 2;
					this.AStarAddTile(num4);
				}
				while (this.int_8[endTile] != 2 && this.int_6 > 0);
				this.int_3 = 0;
				if (endTile != -1)
				{
					int num5 = this.int_9[endTile];
					if (num5 != -1)
					{
						int[] array7 = this.int_10;
						num2 = this.int_3;
						this.int_3 = num2 + 1;
						array7[num2] = endTile;
						for (int num6 = this.int_9[num5]; num6 != -1; num6 = this.int_9[num6])
						{
							int[] array8 = this.int_10;
							num2 = this.int_3;
							this.int_3 = num2 + 1;
							array8[num2] = num5;
							num5 = num6;
						}
					}
				}
				this.int_7++;
				if (this.int_7 >= 30)
				{
					this.int_7 = 0;
				}
				this.logicSavedPath_0[this.int_7].StorePath(this.int_10, this.int_3, startTile, endTile, this.int_2);
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00013968 File Offset: 0x00011B68
		public void AStarAddTile(int tileIndex)
		{
			int num = tileIndex % this.int_0;
			int num2 = tileIndex / this.int_0;
			LogicTile tile = this.m_tileMap.GetTile(num, num2);
			if (tile != null)
			{
				int pathFinderCost = tile.GetPathFinderCost(0, 0);
				int pathFinderCost2 = tile.GetPathFinderCost(1, 0);
				int pathFinderCost3 = tile.GetPathFinderCost(0, 1);
				int pathFinderCost4 = tile.GetPathFinderCost(1, 1);
				if (pathFinderCost != 2147483647 || pathFinderCost2 != 2147483647)
				{
					this.AStarAddTile(tileIndex, num, num2 - 1, tileIndex - this.int_0, 100);
				}
				if (pathFinderCost3 != 2147483647 || pathFinderCost4 != 2147483647)
				{
					this.AStarAddTile(tileIndex, num, num2 + 1, tileIndex + this.int_0, 100);
				}
				if (pathFinderCost != 2147483647 || pathFinderCost3 != 2147483647)
				{
					this.AStarAddTile(tileIndex, num - 1, num2, tileIndex - 1, 100);
				}
				if (pathFinderCost2 != 2147483647 || pathFinderCost4 != 2147483647)
				{
					this.AStarAddTile(tileIndex, num + 1, num2, tileIndex + 1, 100);
				}
				if (pathFinderCost != 2147483647)
				{
					this.AStarAddTile(tileIndex, num - 1, num2 - 1, tileIndex - this.int_0 - 1, 141);
				}
				if (pathFinderCost3 != 2147483647)
				{
					this.AStarAddTile(tileIndex, num - 1, num2 + 1, tileIndex + this.int_0 - 1, 141);
				}
				if (pathFinderCost2 != 2147483647)
				{
					this.AStarAddTile(tileIndex, num + 1, num2 - 1, tileIndex - this.int_0 + 1, 141);
				}
				if (pathFinderCost4 != 2147483647)
				{
					this.AStarAddTile(tileIndex, num + 1, num2 + 1, tileIndex + this.int_0 + 1, 141);
				}
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00013AE0 File Offset: 0x00011CE0
		public void AStarAddTile(int tileIndex, int tileX, int tileY, int pathIdx, int cost)
		{
			if (tileX >= 0 && tileY >= 0 && this.int_0 > tileX && this.int_1 > tileY)
			{
				int num = this.int_8[pathIdx];
				if (num != 2)
				{
					int num2 = this.bool_0 ? int.MaxValue : 1;
					int tilePathFinderCost = this.m_tileMap.GetTilePathFinderCost(tileX, tileY);
					if (tilePathFinderCost < num2)
					{
						int num3 = this.int_12[tileIndex] + cost + (this.int_2 * tilePathFinderCost >> 8);
						int num4 = tileX - this.int_4;
						int num5 = tileY - this.int_5;
						if (num4 < 1)
						{
							num4 = this.int_4 - tileX;
						}
						if (num5 < 1)
						{
							num5 = this.int_5 - tileY;
						}
						int num6 = num3 + 10 * (num4 + num5);
						if (num == 1)
						{
							if (this.int_12[pathIdx] > num6)
							{
								this.int_12[pathIdx] = num6;
								this.int_9[pathIdx] = tileIndex;
								return;
							}
						}
						else if (num == 0)
						{
							this.int_8[pathIdx] = 1;
							int[] array = this.int_10;
							int num7 = this.int_3;
							this.int_3 = num7 + 1;
							array[num7] = pathIdx;
							this.int_9[pathIdx] = tileIndex;
							this.int_12[pathIdx] = num6;
							this.Add(pathIdx);
						}
					}
				}
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00013C08 File Offset: 0x00011E08
		public bool IsCollision(int x, int y)
		{
			if (this.m_tileMap == null)
			{
				return false;
			}
			LogicTile tile = this.m_tileMap.GetTile(x >> 1, y >> 1);
			return tile == null || !tile.IsPassablePathFinder((x & 1) + 2 * (y & 1));
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00013C48 File Offset: 0x00011E48
		public void Add(int tileIdx)
		{
			int[] array = this.int_11;
			int num = this.int_6;
			this.int_6 = num + 1;
			array[num] = tileIdx;
			if (this.int_6 > 1)
			{
				int num2 = this.int_6 - 1;
				do
				{
					int num3 = num2 - 1 >> 1;
					int num4 = this.int_11[num2];
					int num5 = this.int_11[num3];
					if (this.int_12[num4] >= this.int_12[num5])
					{
						break;
					}
					this.int_11[num2] = num5;
					this.int_11[num3] = num4;
					num2 = num3;
				}
				while (num2 > 0);
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00013CC8 File Offset: 0x00011EC8
		public int RemoveSmallest()
		{
			if (this.int_6 == 0)
			{
				return -1;
			}
			int result = this.int_11[0];
			int[] array = this.int_11;
			int num = this.int_6 - 1;
			this.int_6 = num;
			int num2 = array[num];
			this.int_11[0] = num2;
			int num3 = 0;
			int num4 = 0;
			for (;;)
			{
				int num5 = 2 * num3 + 1;
				int num6 = 2 * num3 + 2;
				if (num6 < this.int_6)
				{
					if (this.int_12[num2] <= this.int_12[this.int_11[num6]])
					{
						num6 = num3;
					}
					num4 = num6;
				}
				if (num5 < this.int_6 && this.int_12[this.int_11[num4]] > this.int_12[this.int_11[num5]])
				{
					num4 = num5;
				}
				if (num4 == num3)
				{
					break;
				}
				this.int_11[num3] = this.int_11[num4];
				this.int_11[num4] = num2;
				num3 = num4;
			}
			return result;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002470 File Offset: 0x00000670
		public override int GetParent(int index)
		{
			return this.int_9[index];
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000247A File Offset: 0x0000067A
		public override int GetPathLength()
		{
			return this.int_3;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00013DA4 File Offset: 0x00011FA4
		public override void GetPathPoint(LogicVector2 position, int idx)
		{
			if ((ulong)idx >= (ulong)((long)this.int_3))
			{
				Debugger.Error("illegal path index");
			}
			position.m_x = this.int_10[idx] % this.int_0;
			position.m_y = this.int_10[idx] / this.int_0;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00013DF0 File Offset: 0x00011FF0
		public override void GetPathPointSubTile(LogicVector2 position, int idx)
		{
			if ((ulong)idx >= (ulong)((long)this.int_3))
			{
				Debugger.Error("illegal path index");
			}
			LogicTile tile = this.m_tileMap.GetTile(position.m_x, position.m_y);
			position.m_x *= 2;
			position.m_y *= 2;
			if (tile.IsPassablePathFinder(3))
			{
				if (tile.IsPassablePathFinder(2) && tile.IsPassablePathFinder(1))
				{
					position.m_x++;
				}
				position.m_y++;
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00013E80 File Offset: 0x00012080
		public unsafe void CreatePathPoint(LogicVector2 startPosition)
		{
			int num = this.int_3;
			int num2 = this.int_0 * 2;
			int num3 = 4 * this.int_0 * this.int_1;
			int[] array;
			int* ptr;
			if ((array = this.int_9) != null && array.Length != 0)
			{
				ptr = &array[0];
			}
			else
			{
				ptr = null;
			}
			int[] array2;
			int* ptr2;
			if ((array2 = this.int_12) != null && array2.Length != 0)
			{
				ptr2 = &array2[0];
			}
			else
			{
				ptr2 = null;
			}
			LogicCpp.MemSet(ptr, -1, num3 * 4);
			LogicCpp.MemSet(ptr2, -1, num3 * 4);
			array2 = null;
			array = null;
			int num4 = 0;
			for (int i = 0; i < num; i++)
			{
				this.GetPathPoint(this.logicVector2_0, i);
				LogicTile tile = this.m_tileMap.GetTile(this.logicVector2_0.m_x, this.logicVector2_0.m_y);
				int num5 = 4 * this.int_0 * this.logicVector2_0.m_y + 2 * this.logicVector2_0.m_x;
				if (tile.GetPathFinderCostIgnorePos(0, 0) != 2147483647)
				{
					num4++;
					this.int_12[num5] = int.MaxValue;
				}
				if (tile.GetPathFinderCostIgnorePos(1, 0) != 2147483647)
				{
					num4++;
					this.int_12[num5 | 1] = int.MaxValue;
				}
				if (tile.GetPathFinderCostIgnorePos(0, 1) != 2147483647)
				{
					num4++;
					this.int_12[num5 + num2] = int.MaxValue;
				}
				if (tile.GetPathFinderCostIgnorePos(1, 1) != 2147483647)
				{
					num4++;
					this.int_12[num5 + num2 | 1] = int.MaxValue;
				}
			}
			int num6 = startPosition.m_x + num2 * startPosition.m_y;
			this.int_11[0] = num6;
			this.int_12[num6] = 1;
			int j = 0;
			int num7 = 1;
			while (j < num4)
			{
				int num8 = num7 - 1;
				int num9 = this.int_11[num7 - 1];
				int num10 = 0;
				int num11 = int.MaxValue;
				for (int k = 0; k < num7; k++)
				{
					int num12 = this.int_11[k];
					if (num11 > this.int_12[num12])
					{
						num9 = num12;
						num10 = k;
						num11 = this.int_12[num12];
					}
				}
				int num13 = this.int_12[num9];
				if (num10 < num8)
				{
					Array.Copy(this.int_11, num10 + 1, this.int_11, num10, num8 - num10);
				}
				this.int_11[num7] = -1;
				if (num7 > 4096)
				{
					Debugger.Warning("LPFNew stack grew too large!");
					return;
				}
				int num14 = num9 - num2;
				int num15 = num9 + num2;
				int num16 = num9 - 1;
				int num17 = num9 + 1;
				if (num14 >= 0 && num14 < num3 && this.int_12[num14] > num13 + 100)
				{
					this.int_12[num14] = num13 + 100;
					this.int_9[num14] = num9;
					this.int_11[num8++] = num14;
				}
				if (num15 >= 0 && num15 < num3 && this.int_12[num15] > num13 + 100)
				{
					this.int_12[num15] = num13 + 100;
					this.int_9[num15] = num9;
					this.int_11[num8++] = num15;
				}
				if (num16 >= 0 && num16 < num3 && this.int_12[num16] > num13 + 100)
				{
					this.int_12[num16] = num13 + 100;
					this.int_9[num16] = num9;
					this.int_11[num8++] = num16;
				}
				if (num17 >= 0 && num17 < num3 && this.int_12[num17] > num13 + 100)
				{
					this.int_12[num17] = num13 + 100;
					this.int_9[num17] = num9;
					this.int_11[num8++] = num17;
				}
				num14 = num9 - num2 - 1;
				num15 = num9 - num2 + 1;
				num16 = num9 + num2 - 1;
				num17 = num9 + num2 + 1;
				if (num14 >= 0 && num14 < num3 && this.int_12[num14] > num13 + 141)
				{
					this.int_12[num14] = num13 + 141;
					this.int_9[num14] = num9;
					this.int_11[num8++] = num14;
				}
				if (num15 >= 0 && num15 < num3 && this.int_12[num15] > num13 + 141)
				{
					this.int_12[num15] = num13 + 141;
					this.int_9[num15] = num9;
					this.int_11[num8++] = num15;
				}
				if (num16 >= 0 && num16 < num3 && this.int_12[num16] > num13 + 141)
				{
					this.int_12[num16] = num13 + 141;
					this.int_9[num16] = num9;
					this.int_11[num8++] = num16;
				}
				if (num17 >= 0 && num17 < num3 && this.int_12[num17] > num13 + 141)
				{
					this.int_12[num17] = num13 + 141;
					this.int_9[num17] = num9;
					this.int_11[num8++] = num17;
				}
				if (num8 <= 0)
				{
					return;
				}
				num7 = num8;
				j++;
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00014360 File Offset: 0x00012560
		public override void FindPath(LogicVector2 startPosition, LogicVector2 endPosition, bool clampPathFinderCost)
		{
			this.bool_1 = false;
			if (!this.m_tileMap.IsPassablePathFinder(startPosition.m_x, startPosition.m_y))
			{
				this.int_3 = 0;
				return;
			}
			if (!this.IsReachable(endPosition.m_x, endPosition.m_y) && clampPathFinderCost)
			{
				int num = LogicMath.Sqrt((endPosition.m_x - startPosition.m_x) * (endPosition.m_x - startPosition.m_x) + (endPosition.m_y - startPosition.m_y) * (endPosition.m_y - startPosition.m_y));
				int i = LogicMath.Clamp(endPosition.m_x - num, 0, 2 * this.int_0);
				int num2 = LogicMath.Clamp(endPosition.m_y - num, 0, 2 * this.int_1);
				int num3 = LogicMath.Clamp(endPosition.m_x + num, 0, 2 * this.int_0);
				int num4 = LogicMath.Clamp(endPosition.m_y + num, 0, 2 * this.int_1);
				int num5 = -1;
				int y = -1;
				int num6 = int.MaxValue;
				while (i < num3)
				{
					int num7 = i;
					for (int j = num2; j < num4; j++)
					{
						if (this.IsReachable(num7, j))
						{
							int num8 = (num7 - endPosition.m_x) * (num7 - endPosition.m_x) + (j - endPosition.m_y) * (j - endPosition.m_y);
							if (num8 < num6)
							{
								num5 = num7;
								y = j;
								num6 = num8;
							}
						}
					}
					i++;
				}
				if (num5 == -1)
				{
					this.int_3 = 0;
					return;
				}
				endPosition.m_x = num5;
				endPosition.m_y = y;
			}
			if (!this.IsReachable(endPosition.m_x, endPosition.m_y))
			{
				this.int_3 = 0;
				return;
			}
			int num9 = (startPosition.m_x >> 1) + (startPosition.m_y >> 1) * this.int_0;
			int num10 = (endPosition.m_x >> 1) + (endPosition.m_y >> 1) * this.int_0;
			if ((num9 == num10 && this.IsReachable(startPosition.m_x, startPosition.m_y) && this.IsReachable(endPosition.m_x, endPosition.m_y)) || this.IsLineOfSightClear(startPosition.m_x, startPosition.m_y, endPosition.m_x, endPosition.m_y))
			{
				this.int_3 = 0;
				int[] array = this.int_10;
				int num11 = this.int_3;
				this.int_3 = num11 + 1;
				array[num11] = num10;
				int[] array2 = this.int_10;
				num11 = this.int_3;
				this.int_3 = num11 + 1;
				array2[num11] = num9;
				this.bool_1 = true;
				return;
			}
			this.AStar(num9, num10);
			if (this.int_3 > 0)
			{
				int[] array3 = this.int_10;
				int num11 = this.int_3;
				this.int_3 = num11 + 1;
				array3[num11] = num9;
			}
			this.CreatePathPoint(startPosition);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00014600 File Offset: 0x00012800
		public bool IsLineOfSightClear(int xA, int yA, int xB, int yB)
		{
			if (this.IsLineOfSightClearImpl(xA, yA, xB, yB))
			{
				int num = this.Sign(xB - xA);
				int num2 = this.Sign(yB - yA);
				return this.IsLineOfSightClearImpl(xA + num, yA, xB, yB - num2) && this.IsLineOfSightClearImpl(xA, yA + num2, xB - num, yB);
			}
			return false;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00014654 File Offset: 0x00012854
		public bool IsLineOfSightClearImpl(int xA, int yA, int xB, int yB)
		{
			int num = (xB > xA) ? 1 : -1;
			int num2 = (yB > yA) ? 1 : -1;
			int num3 = LogicMath.Abs(xB - xA);
			int num4 = LogicMath.Abs(yB - yA);
			int num5 = num3 - num4;
			int num6 = num3 * 2;
			int num7 = num4 * 2;
			int i = num3 + num4;
			int num8 = xA;
			int num9 = yA;
			while (i >= 0)
			{
				if (this.IsCollision(num8, num9))
				{
					return false;
				}
				if (num5 > 0)
				{
					num5 -= num7;
					num8 += num;
				}
				else
				{
					num5 += num6;
					num9 += num2;
				}
				i--;
			}
			return true;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002482 File Offset: 0x00000682
		public override void SetCostStrategy(bool enabled, int quality)
		{
			this.bool_0 = enabled;
			this.int_2 = quality;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002492 File Offset: 0x00000692
		public override void ResetCostStrategyToDefault()
		{
			this.bool_0 = true;
			this.int_2 = 256;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000146D8 File Offset: 0x000128D8
		public override void InvalidateCache()
		{
			for (int i = 0; i < 30; i++)
			{
				this.logicSavedPath_0[i].StorePath(null, 0, -1, -1, 0);
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000024A6 File Offset: 0x000006A6
		public override bool IsLineOfSightClear()
		{
			return this.bool_1;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000024AE File Offset: 0x000006AE
		public bool IsReachable(int x, int y)
		{
			return this.m_tileMap.GetPathFinderCost(x, y) < (this.bool_0 ? int.MaxValue : 1);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000024CF File Offset: 0x000006CF
		public int Sign(int value)
		{
			if (value <= 0)
			{
				return value >> 31;
			}
			return 1;
		}

		// Token: 0x04000030 RID: 48
		public const int SAVED_PATHS = 30;

		// Token: 0x04000031 RID: 49
		private bool bool_0;

		// Token: 0x04000032 RID: 50
		private bool bool_1;

		// Token: 0x04000033 RID: 51
		private readonly int int_0;

		// Token: 0x04000034 RID: 52
		private readonly int int_1;

		// Token: 0x04000035 RID: 53
		private int int_2;

		// Token: 0x04000036 RID: 54
		private int int_3;

		// Token: 0x04000037 RID: 55
		private int int_4;

		// Token: 0x04000038 RID: 56
		private int int_5;

		// Token: 0x04000039 RID: 57
		private int int_6;

		// Token: 0x0400003A RID: 58
		private int int_7;

		// Token: 0x0400003B RID: 59
		private readonly int[] int_8;

		// Token: 0x0400003C RID: 60
		private readonly int[] int_9;

		// Token: 0x0400003D RID: 61
		private readonly int[] int_10;

		// Token: 0x0400003E RID: 62
		private readonly int[] int_11;

		// Token: 0x0400003F RID: 63
		private readonly int[] int_12;

		// Token: 0x04000040 RID: 64
		private LogicVector2 logicVector2_0;

		// Token: 0x04000041 RID: 65
		private readonly LogicSavedPath[] logicSavedPath_0;
	}
}
