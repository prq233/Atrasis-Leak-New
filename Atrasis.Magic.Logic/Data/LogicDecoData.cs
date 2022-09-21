using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200014B RID: 331
	public class LogicDecoData : LogicGameObjectData
	{
		// Token: 0x0600127D RID: 4733 RVA: 0x0000B4F2 File Offset: 0x000096F2
		public LogicDecoData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x0600127E RID: 4734 RVA: 0x0004E250 File Offset: 0x0004C450
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_0 = base.GetIntegerValue("Width", 0);
			this.int_1 = base.GetIntegerValue("Height", 0);
			this.int_3 = base.GetIntegerValue("MaxCount", 0);
			this.bool_0 = !base.GetBooleanValue("NotInShop", 0);
			this.int_2 = base.GetIntegerValue("BuildCost", 0);
			this.int_4 = base.GetIntegerValue("RequiredExpLevel", 0);
			this.bool_1 = base.GetBooleanValue("DecoPath", 0);
			this.logicResourceData_0 = LogicDataTables.GetResourceByName(base.GetValue("BuildResource", 0), this);
		}

		// Token: 0x0600127F RID: 4735 RVA: 0x0000C705 File Offset: 0x0000A905
		public bool IsInShop()
		{
			return this.bool_0;
		}

		// Token: 0x06001280 RID: 4736 RVA: 0x0000C70D File Offset: 0x0000A90D
		public int GetMaxCount()
		{
			return this.int_3;
		}

		// Token: 0x06001281 RID: 4737 RVA: 0x0000C715 File Offset: 0x0000A915
		public int GetRequiredExpLevel()
		{
			return this.int_4;
		}

		// Token: 0x06001282 RID: 4738 RVA: 0x0000C71D File Offset: 0x0000A91D
		public int GetSellPrice()
		{
			return this.int_2 / 10;
		}

		// Token: 0x06001283 RID: 4739 RVA: 0x0000C728 File Offset: 0x0000A928
		public int GetBuildCost()
		{
			return this.int_2;
		}

		// Token: 0x06001284 RID: 4740 RVA: 0x0000C730 File Offset: 0x0000A930
		public int GetWidth()
		{
			return this.int_0;
		}

		// Token: 0x06001285 RID: 4741 RVA: 0x0000C738 File Offset: 0x0000A938
		public int GetHeight()
		{
			return this.int_1;
		}

		// Token: 0x06001286 RID: 4742 RVA: 0x0000C740 File Offset: 0x0000A940
		public LogicResourceData GetBuildResource()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x06001287 RID: 4743 RVA: 0x0000C748 File Offset: 0x0000A948
		public bool IsPassable()
		{
			return this.bool_1;
		}

		// Token: 0x040008CB RID: 2251
		private int int_0;

		// Token: 0x040008CC RID: 2252
		private int int_1;

		// Token: 0x040008CD RID: 2253
		private int int_2;

		// Token: 0x040008CE RID: 2254
		private int int_3;

		// Token: 0x040008CF RID: 2255
		private int int_4;

		// Token: 0x040008D0 RID: 2256
		private bool bool_0;

		// Token: 0x040008D1 RID: 2257
		private bool bool_1;

		// Token: 0x040008D2 RID: 2258
		private LogicResourceData logicResourceData_0;
	}
}
