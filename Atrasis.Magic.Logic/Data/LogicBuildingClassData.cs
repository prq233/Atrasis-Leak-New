using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200013F RID: 319
	public class LogicBuildingClassData : LogicData
	{
		// Token: 0x06001128 RID: 4392 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicBuildingClassData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001129 RID: 4393 RVA: 0x0004B88C File Offset: 0x00049A8C
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.bool_4 = base.GetBooleanValue("CanBuy", 0);
			this.bool_5 = base.GetBooleanValue("ShopCategoryResource", 0);
			this.bool_6 = base.GetBooleanValue("ShopCategoryArmy", 0);
			this.bool_3 = string.Equals("Worker", base.GetName());
			if (!this.bool_3)
			{
				this.bool_3 = string.Equals("Worker2", base.GetName());
			}
			this.bool_1 = string.Equals("Town Hall", base.GetName());
			this.bool_0 = string.Equals("Town Hall2", base.GetName());
			this.bool_2 = string.Equals("Wall", base.GetName());
		}

		// Token: 0x0600112A RID: 4394 RVA: 0x0000B8A3 File Offset: 0x00009AA3
		public bool IsWorker()
		{
			return this.bool_3;
		}

		// Token: 0x0600112B RID: 4395 RVA: 0x0000B8AB File Offset: 0x00009AAB
		public bool IsTownHall()
		{
			return this.bool_1;
		}

		// Token: 0x0600112C RID: 4396 RVA: 0x0000B8B3 File Offset: 0x00009AB3
		public bool IsTownHall2()
		{
			return this.bool_0;
		}

		// Token: 0x0600112D RID: 4397 RVA: 0x0000B8BB File Offset: 0x00009ABB
		public bool IsWall()
		{
			return this.bool_2;
		}

		// Token: 0x0600112E RID: 4398 RVA: 0x0000B8C3 File Offset: 0x00009AC3
		public bool CanBuy()
		{
			return this.bool_4;
		}

		// Token: 0x04000779 RID: 1913
		private bool bool_0;

		// Token: 0x0400077A RID: 1914
		private bool bool_1;

		// Token: 0x0400077B RID: 1915
		private bool bool_2;

		// Token: 0x0400077C RID: 1916
		private bool bool_3;

		// Token: 0x0400077D RID: 1917
		private bool bool_4;

		// Token: 0x0400077E RID: 1918
		private bool bool_5;

		// Token: 0x0400077F RID: 1919
		private bool bool_6;
	}
}
