using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000161 RID: 353
	public class LogicResourceData : LogicData
	{
		// Token: 0x060014CF RID: 5327 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicResourceData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060014D0 RID: 5328 RVA: 0x00051F68 File Offset: 0x00050168
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.logicEffectData_1 = LogicDataTables.GetEffectByName(base.GetValue("StealEffect", 0), this);
			this.logicEffectData_0 = LogicDataTables.GetEffectByName(base.GetValue("CollectEffect", 0), this);
			this.string_0 = base.GetValue("ResourceIconExportName", 0);
			this.int_0 = base.GetIntegerValue("StealLimitMid", 0);
			this.string_1 = base.GetValue("StealEffectMid", 0);
			this.int_1 = base.GetIntegerValue("StealLimitBig", 0);
			this.string_2 = base.GetValue("StealEffectBig", 0);
			this.bool_0 = base.GetBooleanValue("PremiumCurrency", 0);
			this.string_3 = base.GetValue("HudInstanceName", 0);
			this.string_4 = base.GetValue("CapFullTID", 0);
			this.int_2 = base.GetIntegerValue("TextRed", 0);
			this.int_3 = base.GetIntegerValue("TextGreen", 0);
			this.int_4 = base.GetIntegerValue("TextBlue", 0);
			this.string_5 = base.GetValue("BundleIconExportName", 0);
			this.int_5 = base.GetIntegerValue("VillageType", 0);
			if (this.int_5 >= 2)
			{
				Debugger.Error("invalid VillageType");
			}
			string value = base.GetValue("WarRefResource", 0);
			if (value.Length > 0)
			{
				this.logicResourceData_0 = LogicDataTables.GetResourceByName(value, this);
			}
		}

		// Token: 0x060014D1 RID: 5329 RVA: 0x0000D9A9 File Offset: 0x0000BBA9
		public LogicResourceData GetWarResourceReferenceData()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x060014D2 RID: 5330 RVA: 0x0000D9B1 File Offset: 0x0000BBB1
		public LogicEffectData GetCollectEffect()
		{
			return this.logicEffectData_0;
		}

		// Token: 0x060014D3 RID: 5331 RVA: 0x0000D9B9 File Offset: 0x0000BBB9
		public string GetResourceIconExportName()
		{
			return this.string_0;
		}

		// Token: 0x060014D4 RID: 5332 RVA: 0x0000D9C1 File Offset: 0x0000BBC1
		public LogicEffectData GetStealEffect()
		{
			return this.logicEffectData_1;
		}

		// Token: 0x060014D5 RID: 5333 RVA: 0x0000D9C9 File Offset: 0x0000BBC9
		public int GetStealLimitMid()
		{
			return this.int_0;
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x0000D9D1 File Offset: 0x0000BBD1
		public string GetStealEffectMid()
		{
			return this.string_1;
		}

		// Token: 0x060014D7 RID: 5335 RVA: 0x0000D9D9 File Offset: 0x0000BBD9
		public int GetStealLimitBig()
		{
			return this.int_1;
		}

		// Token: 0x060014D8 RID: 5336 RVA: 0x0000D9E1 File Offset: 0x0000BBE1
		public string GetStealEffectBig()
		{
			return this.string_2;
		}

		// Token: 0x060014D9 RID: 5337 RVA: 0x0000D9E9 File Offset: 0x0000BBE9
		public bool IsPremiumCurrency()
		{
			return this.bool_0;
		}

		// Token: 0x060014DA RID: 5338 RVA: 0x0000D9F1 File Offset: 0x0000BBF1
		public string GetHudInstanceName()
		{
			return this.string_3;
		}

		// Token: 0x060014DB RID: 5339 RVA: 0x0000D9F9 File Offset: 0x0000BBF9
		public string GetCapFullTID()
		{
			return this.string_4;
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x0000DA01 File Offset: 0x0000BC01
		public int GetTextRed()
		{
			return this.int_2;
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x0000DA09 File Offset: 0x0000BC09
		public int GetTextGreen()
		{
			return this.int_3;
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x0000DA11 File Offset: 0x0000BC11
		public int GetTextBlue()
		{
			return this.int_4;
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x0000DA19 File Offset: 0x0000BC19
		public string GetBundleIconExportName()
		{
			return this.string_5;
		}

		// Token: 0x060014E0 RID: 5344 RVA: 0x0000DA21 File Offset: 0x0000BC21
		public int GetVillageType()
		{
			return this.int_5;
		}

		// Token: 0x04000B13 RID: 2835
		private string string_0;

		// Token: 0x04000B14 RID: 2836
		private string string_1;

		// Token: 0x04000B15 RID: 2837
		private string string_2;

		// Token: 0x04000B16 RID: 2838
		private string string_3;

		// Token: 0x04000B17 RID: 2839
		private string string_4;

		// Token: 0x04000B18 RID: 2840
		private string string_5;

		// Token: 0x04000B19 RID: 2841
		private int int_0;

		// Token: 0x04000B1A RID: 2842
		private int int_1;

		// Token: 0x04000B1B RID: 2843
		private int int_2;

		// Token: 0x04000B1C RID: 2844
		private int int_3;

		// Token: 0x04000B1D RID: 2845
		private int int_4;

		// Token: 0x04000B1E RID: 2846
		private int int_5;

		// Token: 0x04000B1F RID: 2847
		private bool bool_0;

		// Token: 0x04000B20 RID: 2848
		private LogicEffectData logicEffectData_0;

		// Token: 0x04000B21 RID: 2849
		private LogicEffectData logicEffectData_1;

		// Token: 0x04000B22 RID: 2850
		private LogicResourceData logicResourceData_0;
	}
}
