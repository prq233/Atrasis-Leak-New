using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Util
{
	// Token: 0x0200000F RID: 15
	public sealed class LogicPathFinderOld : LogicPathFinder
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00014704 File Offset: 0x00012904
		public LogicPathFinderOld(LogicTileMap tileMap) : base(tileMap)
		{
			if (tileMap != null)
			{
				this.int_0 = 2 * tileMap.GetSizeX();
				this.int_1 = 2 * tileMap.GetSizeY();
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
			int num = this.int_0 * this.int_1;
			this.int_9 = new int[num];
			this.int_12 = new int[num];
			this.int_10 = new int[num];
			this.int_11 = new int[num];
			this.int_13 = new int[num];
			this.ResetCostStrategyToDefault();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000147C8 File Offset: 0x000129C8
		public override void Destruct()
		{
			base.Destruct();
			this.int_9 = null;
			this.int_12 = null;
			this.int_10 = null;
			this.int_11 = null;
			this.int_13 = null;
			for (int i = 0; i < 30; i++)
			{
				if (this.logicSavedPath_0[i] != null)
				{
					this.logicSavedPath_0[i].Destruct();
					this.logicSavedPath_0[i] = null;
				}
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0001482C File Offset: 0x00012A2C
		public unsafe void AStar(int startTile, int endTile)
		{
			for (int i = 0; i < 30; i++)
			{
				LogicSavedPath logicSavedPath = this.logicSavedPath_0[i];
				if (logicSavedPath.IsEqual(startTile, endTile, this.int_2))
				{
					this.int_3 = logicSavedPath.GetLength();
					logicSavedPath.ExtractPath(this.int_11);
					return;
				}
			}
			this.int_4 = endTile % this.int_0;
			this.int_5 = endTile / this.int_0;
			this.int_6 = 0;
			int num = 4 * this.int_1 * this.int_0;
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
			if ((array2 = this.int_13) != null && array2.Length != 0)
			{
				ptr2 = &array2[0];
			}
			else
			{
				ptr2 = null;
			}
			int[] array3;
			int* ptr3;
			if ((array3 = this.int_12) != null && array3.Length != 0)
			{
				ptr3 = &array3[0];
			}
			else
			{
				ptr3 = null;
			}
			for (int j = 0; j < num; j++)
			{
				ptr[j] = 0;
				ptr2[j] = 0;
				ptr3[j] = int.MaxValue;
			}
			array3 = null;
			array2 = null;
			array = null;
			this.int_3 = 0;
			int[] array4 = this.int_11;
			int num2 = this.int_3;
			this.int_3 = num2 + 1;
			array4[num2] = startTile;
			this.int_10[startTile] = -1;
			this.int_10[endTile] = -1;
			this.AStarAddTile(startTile);
			int[] array5 = this.int_11;
			int num3 = 0;
			int[] array6 = this.int_11;
			num2 = this.int_3;
			this.int_3 = num2 - 1;
			array5[num3] = array6[num2 - 1];
			this.int_9[startTile] = 2;
			if (this.int_6 != 0 && this.int_3 != 0)
			{
				do
				{
					int num4 = this.RemoveSmallest();
					this.int_9[num4] = 2;
					this.AStarAddTile(num4);
				}
				while (this.int_9[endTile] != 2 && this.int_6 > 0);
				this.int_3 = 0;
				if (endTile != -1)
				{
					int num5 = this.int_10[endTile];
					if (num5 != -1)
					{
						int[] array7 = this.int_11;
						num2 = this.int_3;
						this.int_3 = num2 + 1;
						array7[num2] = endTile;
						for (int num6 = this.int_10[num5]; num6 != -1; num6 = this.int_10[num6])
						{
							int[] array8 = this.int_11;
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
				this.logicSavedPath_0[this.int_7].StorePath(this.int_11, this.int_3, startTile, endTile, this.int_2);
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00014AB8 File Offset: 0x00012CB8
		public void AStarAddTile(int tileIndex)
		{
			int num = tileIndex % this.int_0;
			int num2 = tileIndex / this.int_0;
			this.AStarAddTile(tileIndex, num, num2 - 1, tileIndex - this.int_0, 100);
			this.AStarAddTile(tileIndex, num, num2 + 1, tileIndex + this.int_0, 100);
			this.AStarAddTile(tileIndex, num - 1, num2, tileIndex - 1, 100);
			this.AStarAddTile(tileIndex, num + 1, num2, tileIndex + 1, 100);
			this.AStarAddTile(tileIndex, num - 1, num2 - 1, tileIndex - this.int_0 - 1, 141);
			this.AStarAddTile(tileIndex, num - 1, num2 + 1, tileIndex + this.int_0 - 1, 141);
			this.AStarAddTile(tileIndex, num + 1, num2 + 1, tileIndex + this.int_0 + 1, 141);
			this.AStarAddTile(tileIndex, num + 1, num2 - 1, tileIndex - this.int_0 + 1, 141);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00014B9C File Offset: 0x00012D9C
		public bool AStarAddTile(int tileIndex, int tileX, int tileY, int pathIdx, int cost)
		{
			if (tileX >= 0 && tileY >= 0 && this.int_0 > tileX && this.int_1 > tileY)
			{
				int num = this.int_9[pathIdx];
				if (num != 2)
				{
					if (num != 0)
					{
						return true;
					}
					this.int_9[pathIdx] = 1;
					int[] array = this.int_11;
					int num2 = this.int_3;
					this.int_3 = num2 + 1;
					array[num2] = pathIdx;
					int pathFinderCost = this.m_tileMap.GetPathFinderCost(tileX, tileY);
					if (pathFinderCost < (this.bool_0 ? 2147483647 : 1))
					{
						int num3 = this.int_13[tileIndex] + cost + (this.int_2 * pathFinderCost >> 8);
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
						this.int_13[tileIndex] = num3 + 10 * (num4 + num5);
						this.Add(pathIdx);
						this.int_8 = ((this.int_8 >= this.int_6) ? this.int_8 : this.int_6);
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00013C08 File Offset: 0x00011E08
		public bool IsCollision(int x, int y)
		{
			if (this.m_tileMap == null)
			{
				return false;
			}
			LogicTile tile = this.m_tileMap.GetTile(x >> 1, y >> 1);
			return tile == null || !tile.IsPassablePathFinder((x & 1) + 2 * (y & 1));
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00014CB8 File Offset: 0x00012EB8
		public void Add(int tileIdx)
		{
			int[] array = this.int_12;
			int num = this.int_6;
			this.int_6 = num + 1;
			array[num] = tileIdx;
			if (this.int_6 > 1)
			{
				int num2 = this.int_6 - 1;
				do
				{
					int num3 = num2 - 1 >> 1;
					int num4 = this.int_12[num2];
					int num5 = this.int_12[num3];
					if (this.int_13[num4] >= this.int_13[num5])
					{
						break;
					}
					this.int_12[num2] = num5;
					this.int_12[num3] = num4;
					num2 = num3;
				}
				while (num2 > 0);
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00014D38 File Offset: 0x00012F38
		public int RemoveSmallest()
		{
			if (this.int_6 == 0)
			{
				return -1;
			}
			int result = this.int_12[0];
			int[] array = this.int_12;
			int num = this.int_6 - 1;
			this.int_6 = num;
			int num2 = array[num];
			this.int_12[0] = num2;
			int num3 = 0;
			int num4 = 0;
			for (;;)
			{
				int num5 = 2 * num3 + 1;
				int num6 = 2 * num3 + 2;
				if (num6 < this.int_6)
				{
					if (this.int_13[num2] <= this.int_13[this.int_12[num6]])
					{
						num6 = num3;
					}
					num4 = num6;
				}
				if (num5 < this.int_6 && this.int_13[this.int_12[num4]] > this.int_13[this.int_12[num5]])
				{
					num4 = num5;
				}
				if (num4 == num3)
				{
					break;
				}
				this.int_12[num3] = this.int_12[num4];
				this.int_12[num4] = num2;
				num3 = num4;
			}
			return result;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000024DB File Offset: 0x000006DB
		public override int GetPathLength()
		{
			return this.int_3;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00014E14 File Offset: 0x00013014
		public override void GetPathPoint(LogicVector2 position, int idx)
		{
			if (idx < 0 || this.int_3 <= idx)
			{
				Debugger.Error("illegal path index");
			}
			position.m_x = this.int_11[idx] % this.int_0;
			position.m_y = this.int_11[idx] / this.int_0;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000024E3 File Offset: 0x000006E3
		public override void GetPathPointSubTile(LogicVector2 position, int idx)
		{
			Debugger.Warning("getPathPointSubTile() called. Should not be called ever for LogicPathFinderOld!");
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00014E64 File Offset: 0x00013064
		public override void FindPath(LogicVector2 startPosition, LogicVector2 endPosition, bool clampPathFinderCost)
		{
			this.int_8 = 0;
			if (this.m_tileMap.IsPassablePathFinder(startPosition.m_x, startPosition.m_y))
			{
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
				int num9 = startPosition.m_x + startPosition.m_y * this.int_0;
				int num10 = endPosition.m_x + endPosition.m_y * this.int_0;
				if (this.IsLineOfSightClear(startPosition.m_x, startPosition.m_y, endPosition.m_x, endPosition.m_y))
				{
					this.int_3 = 0;
					int[] array = this.int_11;
					int num11 = this.int_3;
					this.int_3 = num11 + 1;
					array[num11] = num10;
					int[] array2 = this.int_11;
					num11 = this.int_3;
					this.int_3 = num11 + 1;
					array2[num11] = num9;
					return;
				}
				this.AStar(num9, num10);
				if (this.int_3 > 0)
				{
					int[] array3 = this.int_11;
					int num11 = this.int_3;
					this.int_3 = num11 + 1;
					array3[num11] = num9;
					return;
				}
			}
			else
			{
				this.int_3 = 0;
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000150C0 File Offset: 0x000132C0
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

		// Token: 0x0600008A RID: 138 RVA: 0x00015114 File Offset: 0x00013314
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

		// Token: 0x0600008B RID: 139 RVA: 0x000024EF File Offset: 0x000006EF
		public override void SetCostStrategy(bool enabled, int quality)
		{
			this.bool_0 = enabled;
			this.int_2 = quality;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000024FF File Offset: 0x000006FF
		public override void ResetCostStrategyToDefault()
		{
			this.bool_0 = true;
			this.int_2 = 256;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00015198 File Offset: 0x00013398
		public override void InvalidateCache()
		{
			for (int i = 0; i < 30; i++)
			{
				this.logicSavedPath_0[i].StorePath(null, 0, -1, -1, 0);
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00002513 File Offset: 0x00000713
		public override int GetParent(int index)
		{
			Debugger.Warning("getParent(idx) should not be called for LogicPathFinderOld");
			return 0;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000024CF File Offset: 0x000006CF
		public int Sign(int value)
		{
			if (value <= 0)
			{
				return value >> 31;
			}
			return 1;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00002520 File Offset: 0x00000720
		public bool IsReachable(int x, int y)
		{
			return this.m_tileMap.GetPathFinderCost(x, y) < (this.bool_0 ? int.MaxValue : 1);
		}

		// Token: 0x04000042 RID: 66
		public const int SAVED_PATHS = 30;

		// Token: 0x04000043 RID: 67
		private bool bool_0;

		// Token: 0x04000044 RID: 68
		private readonly int int_0;

		// Token: 0x04000045 RID: 69
		private readonly int int_1;

		// Token: 0x04000046 RID: 70
		private int int_2;

		// Token: 0x04000047 RID: 71
		private int int_3;

		// Token: 0x04000048 RID: 72
		private int int_4;

		// Token: 0x04000049 RID: 73
		private int int_5;

		// Token: 0x0400004A RID: 74
		private int int_6;

		// Token: 0x0400004B RID: 75
		private int int_7;

		// Token: 0x0400004C RID: 76
		private int int_8;

		// Token: 0x0400004D RID: 77
		private int[] int_9;

		// Token: 0x0400004E RID: 78
		private int[] int_10;

		// Token: 0x0400004F RID: 79
		private int[] int_11;

		// Token: 0x04000050 RID: 80
		private int[] int_12;

		// Token: 0x04000051 RID: 81
		private int[] int_13;

		// Token: 0x04000052 RID: 82
		private readonly LogicSavedPath[] logicSavedPath_0;
	}
}
