using System;

namespace Atrasis.Magic.Logic.Util
{
	// Token: 0x02000010 RID: 16
	public class LogicSavedPath
	{
		// Token: 0x06000091 RID: 145 RVA: 0x00002541 File Offset: 0x00000741
		public LogicSavedPath(int size)
		{
			this.int_0 = new int[size];
			this.int_1 = size;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000255C File Offset: 0x0000075C
		public void Destruct()
		{
			this.int_0 = null;
			this.int_1 = 0;
			this.int_2 = 0;
			this.int_3 = 0;
			this.int_4 = -1;
			this.int_5 = 0;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00002588 File Offset: 0x00000788
		public int GetLength()
		{
			return this.int_2;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000151C4 File Offset: 0x000133C4
		public void StorePath(int[] path, int length, int startTile, int endTile, int costStrategy)
		{
			if (this.int_1 >= length)
			{
				if (length > 0)
				{
					Array.Copy(path, this.int_0, length);
				}
				this.int_6 = 0;
				this.int_3 = startTile;
				this.int_4 = endTile;
				this.int_2 = length;
				this.int_5 = costStrategy;
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00002590 File Offset: 0x00000790
		public void ExtractPath(int[] path)
		{
			this.int_6++;
			Array.Copy(this.int_0, path, this.int_2);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000025B2 File Offset: 0x000007B2
		public bool IsEqual(int startTile, int endTile, int costStrategy)
		{
			return this.int_3 == startTile && this.int_4 == endTile && this.int_5 == costStrategy;
		}

		// Token: 0x04000053 RID: 83
		private int[] int_0;

		// Token: 0x04000054 RID: 84
		private int int_1;

		// Token: 0x04000055 RID: 85
		private int int_2;

		// Token: 0x04000056 RID: 86
		private int int_3;

		// Token: 0x04000057 RID: 87
		private int int_4;

		// Token: 0x04000058 RID: 88
		private int int_5;

		// Token: 0x04000059 RID: 89
		private int int_6;
	}
}
