using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000159 RID: 345
	public class LogicLocaleData : LogicData
	{
		// Token: 0x06001421 RID: 5153 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicLocaleData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001422 RID: 5154 RVA: 0x00050D08 File Offset: 0x0004EF08
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("FileName", 0);
			this.string_1 = base.GetValue("LocalizedName", 0);
			this.bool_0 = base.GetBooleanValue("HasEvenSpaceCharacters", 0);
			this.bool_1 = base.GetBooleanValue("isRTL", 0);
			this.string_2 = base.GetValue("UsedSystemFont", 0);
			this.string_3 = base.GetValue("HelpshiftSDKLanguage", 0);
			this.string_4 = base.GetValue("HelpshiftSDKLanguageAndroid", 0);
			this.int_0 = base.GetIntegerValue("SortOrder", 0);
			this.bool_2 = base.GetBooleanValue("TestLanguage", 0);
			this.bool_3 = base.GetBooleanValue("BoomboxEnabled", 0);
			this.string_5 = base.GetValue("BoomboxUrl", 0);
			this.string_6 = base.GetValue("BoomboxStagingUrl", 0);
			this.string_7 = base.GetValue("HelpshiftLanguageTagOverride", 0);
		}

		// Token: 0x06001423 RID: 5155 RVA: 0x0000D49A File Offset: 0x0000B69A
		public string GetFileName()
		{
			return this.string_0;
		}

		// Token: 0x06001424 RID: 5156 RVA: 0x0000D4A2 File Offset: 0x0000B6A2
		public string GetLocalizedName()
		{
			return this.string_1;
		}

		// Token: 0x06001425 RID: 5157 RVA: 0x0000D4AA File Offset: 0x0000B6AA
		public bool IsHasEvenSpaceCharacters()
		{
			return this.bool_0;
		}

		// Token: 0x06001426 RID: 5158 RVA: 0x0000D4B2 File Offset: 0x0000B6B2
		public bool IsRTL()
		{
			return this.bool_1;
		}

		// Token: 0x06001427 RID: 5159 RVA: 0x0000D4BA File Offset: 0x0000B6BA
		public string GetUsedSystemFont()
		{
			return this.string_2;
		}

		// Token: 0x06001428 RID: 5160 RVA: 0x0000D4C2 File Offset: 0x0000B6C2
		public string GetHelpshiftSDKLanguage()
		{
			return this.string_3;
		}

		// Token: 0x06001429 RID: 5161 RVA: 0x0000D4CA File Offset: 0x0000B6CA
		public string GetHelpshiftSDKLanguageAndroid()
		{
			return this.string_4;
		}

		// Token: 0x0600142A RID: 5162 RVA: 0x0000D4D2 File Offset: 0x0000B6D2
		public int GetSortOrder()
		{
			return this.int_0;
		}

		// Token: 0x0600142B RID: 5163 RVA: 0x0000D4DA File Offset: 0x0000B6DA
		public bool IsTestLanguage()
		{
			return this.bool_2;
		}

		// Token: 0x0600142C RID: 5164 RVA: 0x0000D4E2 File Offset: 0x0000B6E2
		public bool IsBoomboxEnabled()
		{
			return this.bool_3;
		}

		// Token: 0x0600142D RID: 5165 RVA: 0x0000D4EA File Offset: 0x0000B6EA
		public string GetBoomboxUrl()
		{
			return this.string_5;
		}

		// Token: 0x0600142E RID: 5166 RVA: 0x0000D4F2 File Offset: 0x0000B6F2
		public string GetBoomboxStagingUrl()
		{
			return this.string_6;
		}

		// Token: 0x0600142F RID: 5167 RVA: 0x0000D4FA File Offset: 0x0000B6FA
		public string GetHelpshiftLanguageTagOverride()
		{
			return this.string_7;
		}

		// Token: 0x04000A66 RID: 2662
		private string string_0;

		// Token: 0x04000A67 RID: 2663
		private string string_1;

		// Token: 0x04000A68 RID: 2664
		private string string_2;

		// Token: 0x04000A69 RID: 2665
		private string string_3;

		// Token: 0x04000A6A RID: 2666
		private string string_4;

		// Token: 0x04000A6B RID: 2667
		private string string_5;

		// Token: 0x04000A6C RID: 2668
		private string string_6;

		// Token: 0x04000A6D RID: 2669
		private string string_7;

		// Token: 0x04000A6E RID: 2670
		private int int_0;

		// Token: 0x04000A6F RID: 2671
		private bool bool_0;

		// Token: 0x04000A70 RID: 2672
		private bool bool_1;

		// Token: 0x04000A71 RID: 2673
		private bool bool_2;

		// Token: 0x04000A72 RID: 2674
		private bool bool_3;
	}
}
