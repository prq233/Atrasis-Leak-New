using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Level
{
	// Token: 0x02000102 RID: 258
	public sealed class LogicTile
	{
		// Token: 0x06000C42 RID: 3138 RVA: 0x00008EA5 File Offset: 0x000070A5
		public LogicTile(byte tileX, byte tileY)
		{
			this.logicArrayList_0 = new LogicArrayList<LogicGameObject>(4);
			this.byte_1 = tileX;
			this.byte_2 = tileY;
			this.byte_0 = 16;
			this.short_0 = -1;
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x00008ED6 File Offset: 0x000070D6
		public void Destruct()
		{
			this.logicArrayList_0 = null;
			this.byte_0 = 16;
		}

		// Token: 0x06000C44 RID: 3140 RVA: 0x00008EE7 File Offset: 0x000070E7
		public void AddGameObject(LogicGameObject gameObject)
		{
			this.logicArrayList_0.Add(gameObject);
			if (!gameObject.IsPassable())
			{
				this.byte_0 &= 239;
			}
			this.RefreshSubTiles();
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x00008F16 File Offset: 0x00007116
		public bool IsPassablePathFinder(int x, int y)
		{
			return (x | y) <= 1 && (1 << x + 2 * y & (int)this.byte_0) == 0;
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x00008F34 File Offset: 0x00007134
		public bool IsPassablePathFinder(int pos)
		{
			return (1 << pos & (int)this.byte_0) == 0;
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x0002A4F4 File Offset: 0x000286F4
		public bool IsBuildable(LogicGameObject gameObject)
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicGameObject logicGameObject = this.logicArrayList_0[i];
				if (logicGameObject != gameObject && (!logicGameObject.IsPassable() || logicGameObject.IsUnbuildable()))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x0002A53C File Offset: 0x0002873C
		public bool IsBuildableWithIgnoreList(LogicGameObject[] gameObjects, int count)
		{
			int i = 0;
			int num = -1;
			IL_5B:
			while (i < this.logicArrayList_0.Size())
			{
				LogicGameObject logicGameObject = this.logicArrayList_0[i];
				int j = 0;
				while (j < count)
				{
					if (gameObjects[j] == logicGameObject)
					{
						num = j;
						IL_2B:
						if (num != -1 || (this.logicArrayList_0[i].IsPassable() && !this.logicArrayList_0[i].IsUnbuildable()))
						{
							i++;
							num = -1;
							goto IL_5B;
						}
						return false;
					}
					else
					{
						j++;
					}
				}
				goto IL_2B;
			}
			return true;
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x0002A5B8 File Offset: 0x000287B8
		public void RemoveGameObject(LogicGameObject gameObject)
		{
			int num = -1;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i] == gameObject)
				{
					num = i;
					IL_2D:
					if (num != -1)
					{
						this.logicArrayList_0.Remove(num);
						this.RefreshPassableFlag();
					}
					return;
				}
			}
			goto IL_2D;
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x0002A608 File Offset: 0x00028808
		public LogicObstacle GetTallGrass()
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetGameObjectType() == LogicGameObjectType.OBSTACLE)
				{
					LogicObstacle logicObstacle = (LogicObstacle)this.logicArrayList_0[i];
					if (logicObstacle.GetObstacleData().IsTallGrass())
					{
						return logicObstacle;
					}
				}
			}
			return null;
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x00008F46 File Offset: 0x00007146
		public LogicGameObject GetGameObject(int idx)
		{
			return this.logicArrayList_0[idx];
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x00008F54 File Offset: 0x00007154
		public int GetGameObjectCount()
		{
			return this.logicArrayList_0.Size();
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x00008F61 File Offset: 0x00007161
		public bool IsFullyNotPassable()
		{
			return (this.byte_0 & 15) == 15;
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x00008F70 File Offset: 0x00007170
		public short GetRoomIdx()
		{
			return this.short_0;
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x00008F78 File Offset: 0x00007178
		public void SetRoomIdx(short index)
		{
			this.short_0 = index;
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x00008F81 File Offset: 0x00007181
		public int GetPathFinderCost(int x, int y)
		{
			if (this.int_0 > 0)
			{
				return this.int_0;
			}
			if ((x | y) <= 1 && ((int)this.byte_0 & 1 << x + 2 * y) == 0)
			{
				return 0;
			}
			return int.MaxValue;
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x00008FB3 File Offset: 0x000071B3
		public int GetPathFinderCostIgnorePos(int x, int y)
		{
			if (this.int_0 > 0)
			{
				return this.int_0;
			}
			if (((int)this.byte_0 & 1 << x + 2 * y) == 0)
			{
				return 0;
			}
			return int.MaxValue;
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x00008FDF File Offset: 0x000071DF
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetPathFinderCost()
		{
			if (this.int_0 > 0)
			{
				return this.int_0;
			}
			if (!this.IsFullyNotPassable())
			{
				return 0;
			}
			return int.MaxValue;
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x0002A664 File Offset: 0x00028864
		public void RefreshSubTiles()
		{
			this.byte_0 &= 240;
			this.int_0 = 0;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicGameObject logicGameObject = this.logicArrayList_0[i];
				this.int_0 = LogicMath.Max(this.int_0, logicGameObject.PathFinderCost());
				if (!logicGameObject.IsPassable())
				{
					int widthInTiles = logicGameObject.GetWidthInTiles();
					int widthInTiles2 = logicGameObject.GetWidthInTiles();
					if (widthInTiles != 1)
					{
						if (widthInTiles2 != 1)
						{
							int num = logicGameObject.PassableSubtilesAtEdge();
							int num2 = 2 * ((int)this.byte_1 - logicGameObject.GetTileX());
							int num3 = 2 * ((int)this.byte_2 - logicGameObject.GetTileY());
							int num4 = 2 * widthInTiles - num;
							int num5 = 2 * widthInTiles2 - num;
							for (int j = 0; j < 2; j++)
							{
								int num6 = j;
								int num7 = num2 + j;
								for (int k = 0; k < 2; k++)
								{
									int num8 = num3 + k;
									if (num8 < num5 && num7 < num4 && num7 >= num && num8 >= num)
									{
										this.byte_0 |= (byte)(1 << num6);
									}
									num6 += 2;
								}
							}
							goto IL_120;
						}
					}
					this.byte_0 |= 15;
				}
				IL_120:;
			}
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x0002A7A8 File Offset: 0x000289A8
		public void RefreshPassableFlag()
		{
			bool flag = false;
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (!this.logicArrayList_0[i].IsPassable())
				{
					flag = true;
					IL_2F:
					this.byte_0 = (flag ? (this.byte_0 & 239) : (this.byte_0 | 16));
					this.RefreshSubTiles();
					return;
				}
			}
			goto IL_2F;
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x00009000 File Offset: 0x00007200
		public byte GetPassableFlag()
		{
			return (byte)(this.byte_0 >> 4 & 1);
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x0000900D File Offset: 0x0000720D
		public int GetX()
		{
			return (int)this.byte_1;
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x00009015 File Offset: 0x00007215
		public int GetY()
		{
			return (int)this.byte_2;
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x0002A80C File Offset: 0x00028A0C
		public bool HasWall()
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicGameObject logicGameObject = this.logicArrayList_0[i];
				if (logicGameObject.IsWall() && logicGameObject.IsAlive())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x040004ED RID: 1261
		private byte byte_0;

		// Token: 0x040004EE RID: 1262
		private readonly byte byte_1;

		// Token: 0x040004EF RID: 1263
		private readonly byte byte_2;

		// Token: 0x040004F0 RID: 1264
		private short short_0;

		// Token: 0x040004F1 RID: 1265
		private int int_0;

		// Token: 0x040004F2 RID: 1266
		private LogicArrayList<LogicGameObject> logicArrayList_0;
	}
}
