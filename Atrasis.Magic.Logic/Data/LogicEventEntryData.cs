using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200014E RID: 334
	public class LogicEventEntryData : LogicData
	{
		// Token: 0x060012C6 RID: 4806 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicEventEntryData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060012C7 RID: 4807 RVA: 0x0004E388 File Offset: 0x0004C588
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("ItemSWF", 0);
			this.string_1 = base.GetValue("ItemExportName", 0);
			this.string_2 = base.GetValue("UpcomingItemExportName", 0);
			this.bool_0 = base.GetBooleanValue("LoadSWF", 0);
			this.string_3 = base.GetValue("TitleTID", 0);
			this.string_4 = base.GetValue("UpcomingTitleTID", 0);
			this.string_5 = base.GetValue("ButtonTID", 0);
			this.string_6 = base.GetValue("ButtonAction", 0);
			this.string_7 = base.GetValue("ButtonActionData", 0);
			this.string_8 = base.GetValue("Button2TID", 0);
			this.string_9 = base.GetValue("Button2Action", 0);
			this.string_10 = base.GetValue("Button2ActionData", 0);
			this.string_11 = base.GetValue("ButtonLanguage", 0);
		}

		// Token: 0x060012C8 RID: 4808 RVA: 0x0000C94F File Offset: 0x0000AB4F
		public string GetItemSWF()
		{
			return this.string_0;
		}

		// Token: 0x060012C9 RID: 4809 RVA: 0x0000C957 File Offset: 0x0000AB57
		public string GetItemExportName()
		{
			return this.string_1;
		}

		// Token: 0x060012CA RID: 4810 RVA: 0x0000C95F File Offset: 0x0000AB5F
		public string GetUpcomingItemExportName()
		{
			return this.string_2;
		}

		// Token: 0x060012CB RID: 4811 RVA: 0x0000C967 File Offset: 0x0000AB67
		public bool IsLoadSWF()
		{
			return this.bool_0;
		}

		// Token: 0x060012CC RID: 4812 RVA: 0x0000C96F File Offset: 0x0000AB6F
		public string GetTitleTID()
		{
			return this.string_3;
		}

		// Token: 0x060012CD RID: 4813 RVA: 0x0000C977 File Offset: 0x0000AB77
		public string GetUpcomingTitleTID()
		{
			return this.string_4;
		}

		// Token: 0x060012CE RID: 4814 RVA: 0x0000C97F File Offset: 0x0000AB7F
		public string GetButtonTID()
		{
			return this.string_5;
		}

		// Token: 0x060012CF RID: 4815 RVA: 0x0000C987 File Offset: 0x0000AB87
		public string GetButtonAction()
		{
			return this.string_6;
		}

		// Token: 0x060012D0 RID: 4816 RVA: 0x0000C98F File Offset: 0x0000AB8F
		public string GetButtonActionData()
		{
			return this.string_7;
		}

		// Token: 0x060012D1 RID: 4817 RVA: 0x0000C997 File Offset: 0x0000AB97
		public string GetButton2TID()
		{
			return this.string_8;
		}

		// Token: 0x060012D2 RID: 4818 RVA: 0x0000C99F File Offset: 0x0000AB9F
		public string GetButton2Action()
		{
			return this.string_9;
		}

		// Token: 0x060012D3 RID: 4819 RVA: 0x0000C9A7 File Offset: 0x0000ABA7
		public string GetButton2ActionData()
		{
			return this.string_10;
		}

		// Token: 0x060012D4 RID: 4820 RVA: 0x0000C9AF File Offset: 0x0000ABAF
		public string GetButtonLanguage()
		{
			return this.string_11;
		}

		// Token: 0x040008ED RID: 2285
		private string string_0;

		// Token: 0x040008EE RID: 2286
		private string string_1;

		// Token: 0x040008EF RID: 2287
		private string string_2;

		// Token: 0x040008F0 RID: 2288
		private string string_3;

		// Token: 0x040008F1 RID: 2289
		private string string_4;

		// Token: 0x040008F2 RID: 2290
		private string string_5;

		// Token: 0x040008F3 RID: 2291
		private string string_6;

		// Token: 0x040008F4 RID: 2292
		private string string_7;

		// Token: 0x040008F5 RID: 2293
		private string string_8;

		// Token: 0x040008F6 RID: 2294
		private string string_9;

		// Token: 0x040008F7 RID: 2295
		private string string_10;

		// Token: 0x040008F8 RID: 2296
		private string string_11;

		// Token: 0x040008F9 RID: 2297
		private bool bool_0;
	}
}
