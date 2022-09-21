using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200015B RID: 347
	public class LogicNewsData : LogicData
	{
		// Token: 0x06001444 RID: 5188 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicNewsData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001445 RID: 5189 RVA: 0x0005141C File Offset: 0x0004F61C
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_0 = base.GetIntegerValue("ID", 0);
			this.bool_0 = base.GetBooleanValue("Enabled", 0);
			this.bool_1 = base.GetBooleanValue("EnabledIOS", 0);
			this.bool_2 = base.GetBooleanValue("EnabledAndroid", 0);
			this.bool_3 = base.GetBooleanValue("EnabledKunlun", 0);
			this.bool_4 = base.GetBooleanValue("EnabledTencent", 0);
			this.bool_5 = base.GetBooleanValue("EnabledLowEnd", 0);
			this.bool_6 = base.GetBooleanValue("EnabledHighEnd", 0);
			this.string_0 = base.GetValue("Type", 0);
			this.bool_7 = base.GetBooleanValue("ShowAsNew", 0);
			this.string_1 = base.GetValue("ButtonTID", 0);
			this.string_2 = base.GetValue("ActionType", 0);
			this.string_3 = base.GetValue("ActionParameter1", 0);
			this.string_4 = base.GetValue("ActionParameter2", 0);
			this.string_5 = base.GetValue("NativeAndroidURL", 0);
			this.string_6 = base.GetValue("IncludedCountries", 0);
			this.string_7 = base.GetValue("ExcludedCountries", 0);
			this.string_8 = base.GetValue("ExcludedLoginCountries", 0);
			this.bool_8 = base.GetBooleanValue("CenterText", 0);
			this.bool_9 = base.GetBooleanValue("LoadResources", 0);
			this.bool_10 = base.GetBooleanValue("LoadInLowEnd", 0);
			this.string_9 = base.GetValue("ItemSWF", 0);
			this.string_10 = base.GetValue("ItemExportName", 0);
			this.string_11 = base.GetValue("IconSWF", 0);
			this.string_12 = base.GetValue("IconExportName", 0);
			this.int_1 = base.GetIntegerValue("IconFrame", 0);
			this.bool_11 = base.GetBooleanValue("AnimateIcon", 0);
			this.bool_12 = base.GetBooleanValue("CenterIcon", 0);
			this.int_2 = base.GetIntegerValue("MinTownHall", 0);
			this.int_3 = base.GetIntegerValue("MaxTownHall", 0);
			this.int_4 = base.GetIntegerValue("MinLevel", 0);
			this.int_5 = base.GetIntegerValue("MaxLevel", 0);
			this.int_6 = base.GetIntegerValue("MaxDiamonds", 0);
			this.bool_13 = base.GetBooleanValue("ClickToDismiss", 0);
			this.bool_14 = base.GetBooleanValue("NotifyAlways", 0);
			this.int_7 = base.GetIntegerValue("NotifyMinLevel", 0);
			this.int_8 = base.GetIntegerValue("AvatarIdModulo", 0);
			this.int_9 = base.GetIntegerValue("ModuloMin", 0);
			this.int_10 = base.GetIntegerValue("ModuloMax", 0);
			this.bool_15 = base.GetBooleanValue("Collapsed", 0);
			this.string_13 = base.GetValue("MinOS", 0);
			this.string_14 = base.GetValue("MaxOS", 0);
			this.string_15 = base.GetValue("ButtonTID2", 0);
			this.string_16 = base.GetValue("Action2Type", 0);
			this.string_17 = base.GetValue("Action2Parameter1", 0);
			this.string_18 = base.GetValue("Action2Parameter2", 0);
		}

		// Token: 0x06001446 RID: 5190 RVA: 0x0000D5A6 File Offset: 0x0000B7A6
		public int GetID()
		{
			return this.int_0;
		}

		// Token: 0x06001447 RID: 5191 RVA: 0x0000D5AE File Offset: 0x0000B7AE
		public bool IsEnabled()
		{
			return this.bool_0;
		}

		// Token: 0x06001448 RID: 5192 RVA: 0x0000D5B6 File Offset: 0x0000B7B6
		public bool IsEnabledIOS()
		{
			return this.bool_1;
		}

		// Token: 0x06001449 RID: 5193 RVA: 0x0000D5BE File Offset: 0x0000B7BE
		public bool IsEnabledAndroid()
		{
			return this.bool_2;
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x0000D5C6 File Offset: 0x0000B7C6
		public bool IsEnabledKunlun()
		{
			return this.bool_3;
		}

		// Token: 0x0600144B RID: 5195 RVA: 0x0000D5CE File Offset: 0x0000B7CE
		public bool IsEnabledTencent()
		{
			return this.bool_4;
		}

		// Token: 0x0600144C RID: 5196 RVA: 0x0000D5D6 File Offset: 0x0000B7D6
		public bool IsEnabledLowEnd()
		{
			return this.bool_5;
		}

		// Token: 0x0600144D RID: 5197 RVA: 0x0000D5DE File Offset: 0x0000B7DE
		public bool IsEnabledHighEnd()
		{
			return this.bool_6;
		}

		// Token: 0x0600144E RID: 5198 RVA: 0x0000D5E6 File Offset: 0x0000B7E6
		public new string GetType()
		{
			return this.string_0;
		}

		// Token: 0x0600144F RID: 5199 RVA: 0x0000D5EE File Offset: 0x0000B7EE
		public bool IsShowAsNew()
		{
			return this.bool_7;
		}

		// Token: 0x06001450 RID: 5200 RVA: 0x0000D5F6 File Offset: 0x0000B7F6
		public string GetButtonTID()
		{
			return this.string_1;
		}

		// Token: 0x06001451 RID: 5201 RVA: 0x0000D5FE File Offset: 0x0000B7FE
		public string GetActionType()
		{
			return this.string_2;
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x0000D606 File Offset: 0x0000B806
		public string GetActionParameter1()
		{
			return this.string_3;
		}

		// Token: 0x06001453 RID: 5203 RVA: 0x0000D60E File Offset: 0x0000B80E
		public string GetActionParameter2()
		{
			return this.string_4;
		}

		// Token: 0x06001454 RID: 5204 RVA: 0x0000D616 File Offset: 0x0000B816
		public string GetNativeAndroidURL()
		{
			return this.string_5;
		}

		// Token: 0x06001455 RID: 5205 RVA: 0x0000D61E File Offset: 0x0000B81E
		public string GetIncludedCountries()
		{
			return this.string_6;
		}

		// Token: 0x06001456 RID: 5206 RVA: 0x0000D626 File Offset: 0x0000B826
		public string GetExcludedCountries()
		{
			return this.string_7;
		}

		// Token: 0x06001457 RID: 5207 RVA: 0x0000D62E File Offset: 0x0000B82E
		public string GetExcludedLoginCountries()
		{
			return this.string_8;
		}

		// Token: 0x06001458 RID: 5208 RVA: 0x0000D636 File Offset: 0x0000B836
		public bool IsCenterText()
		{
			return this.bool_8;
		}

		// Token: 0x06001459 RID: 5209 RVA: 0x0000D63E File Offset: 0x0000B83E
		public bool IsLoadResources()
		{
			return this.bool_9;
		}

		// Token: 0x0600145A RID: 5210 RVA: 0x0000D646 File Offset: 0x0000B846
		public bool IsLoadInLowEnd()
		{
			return this.bool_10;
		}

		// Token: 0x0600145B RID: 5211 RVA: 0x0000D64E File Offset: 0x0000B84E
		public string GetItemSWF()
		{
			return this.string_9;
		}

		// Token: 0x0600145C RID: 5212 RVA: 0x0000D656 File Offset: 0x0000B856
		public string GetItemExportName()
		{
			return this.string_10;
		}

		// Token: 0x0600145D RID: 5213 RVA: 0x0000D65E File Offset: 0x0000B85E
		public string GetIconSWF()
		{
			return this.string_11;
		}

		// Token: 0x0600145E RID: 5214 RVA: 0x0000D666 File Offset: 0x0000B866
		public int GetIconFrame()
		{
			return this.int_1;
		}

		// Token: 0x0600145F RID: 5215 RVA: 0x0000D66E File Offset: 0x0000B86E
		public bool IsAnimateIcon()
		{
			return this.bool_11;
		}

		// Token: 0x06001460 RID: 5216 RVA: 0x0000D676 File Offset: 0x0000B876
		public bool IsCenterIcon()
		{
			return this.bool_12;
		}

		// Token: 0x06001461 RID: 5217 RVA: 0x0000D67E File Offset: 0x0000B87E
		public int GetMinTownHall()
		{
			return this.int_2;
		}

		// Token: 0x06001462 RID: 5218 RVA: 0x0000D686 File Offset: 0x0000B886
		public int GetMaxTownHall()
		{
			return this.int_3;
		}

		// Token: 0x06001463 RID: 5219 RVA: 0x0000D68E File Offset: 0x0000B88E
		public int GetMinLevel()
		{
			return this.int_4;
		}

		// Token: 0x06001464 RID: 5220 RVA: 0x0000D696 File Offset: 0x0000B896
		public int GetMaxLevel()
		{
			return this.int_5;
		}

		// Token: 0x06001465 RID: 5221 RVA: 0x0000D69E File Offset: 0x0000B89E
		public int GetMaxDiamonds()
		{
			return this.int_6;
		}

		// Token: 0x06001466 RID: 5222 RVA: 0x0000D6A6 File Offset: 0x0000B8A6
		public bool IsClickToDismiss()
		{
			return this.bool_13;
		}

		// Token: 0x06001467 RID: 5223 RVA: 0x0000D6AE File Offset: 0x0000B8AE
		public bool IsNotifyAlways()
		{
			return this.bool_14;
		}

		// Token: 0x06001468 RID: 5224 RVA: 0x0000D6B6 File Offset: 0x0000B8B6
		public int GetNotifyMinLevel()
		{
			return this.int_7;
		}

		// Token: 0x06001469 RID: 5225 RVA: 0x0000D6BE File Offset: 0x0000B8BE
		public int GetAvatarIdModulo()
		{
			return this.int_8;
		}

		// Token: 0x0600146A RID: 5226 RVA: 0x0000D6C6 File Offset: 0x0000B8C6
		public int GetModuloMin()
		{
			return this.int_9;
		}

		// Token: 0x0600146B RID: 5227 RVA: 0x0000D6CE File Offset: 0x0000B8CE
		public int GetModuloMax()
		{
			return this.int_10;
		}

		// Token: 0x0600146C RID: 5228 RVA: 0x0000D6D6 File Offset: 0x0000B8D6
		public bool IsCollapsed()
		{
			return this.bool_15;
		}

		// Token: 0x0600146D RID: 5229 RVA: 0x0000D6DE File Offset: 0x0000B8DE
		public string GetMinOS()
		{
			return this.string_13;
		}

		// Token: 0x0600146E RID: 5230 RVA: 0x0000D6E6 File Offset: 0x0000B8E6
		public string GetMaxOS()
		{
			return this.string_14;
		}

		// Token: 0x0600146F RID: 5231 RVA: 0x0000D6EE File Offset: 0x0000B8EE
		public string GetButtonTID2()
		{
			return this.string_15;
		}

		// Token: 0x06001470 RID: 5232 RVA: 0x0000D6F6 File Offset: 0x0000B8F6
		public string GetAction2Type()
		{
			return this.string_16;
		}

		// Token: 0x06001471 RID: 5233 RVA: 0x0000D6FE File Offset: 0x0000B8FE
		public string GetAction2Parameter1()
		{
			return this.string_17;
		}

		// Token: 0x06001472 RID: 5234 RVA: 0x0000D706 File Offset: 0x0000B906
		public string GetAction2Parameter2()
		{
			return this.string_18;
		}

		// Token: 0x04000A95 RID: 2709
		private string string_0;

		// Token: 0x04000A96 RID: 2710
		private string string_1;

		// Token: 0x04000A97 RID: 2711
		private string string_2;

		// Token: 0x04000A98 RID: 2712
		private string string_3;

		// Token: 0x04000A99 RID: 2713
		private string string_4;

		// Token: 0x04000A9A RID: 2714
		private string string_5;

		// Token: 0x04000A9B RID: 2715
		private string string_6;

		// Token: 0x04000A9C RID: 2716
		private string string_7;

		// Token: 0x04000A9D RID: 2717
		private string string_8;

		// Token: 0x04000A9E RID: 2718
		private string string_9;

		// Token: 0x04000A9F RID: 2719
		private string string_10;

		// Token: 0x04000AA0 RID: 2720
		private string string_11;

		// Token: 0x04000AA1 RID: 2721
		private string string_12;

		// Token: 0x04000AA2 RID: 2722
		private string string_13;

		// Token: 0x04000AA3 RID: 2723
		private string string_14;

		// Token: 0x04000AA4 RID: 2724
		private string string_15;

		// Token: 0x04000AA5 RID: 2725
		private string string_16;

		// Token: 0x04000AA6 RID: 2726
		private string string_17;

		// Token: 0x04000AA7 RID: 2727
		private string string_18;

		// Token: 0x04000AA8 RID: 2728
		private int int_0;

		// Token: 0x04000AA9 RID: 2729
		private int int_1;

		// Token: 0x04000AAA RID: 2730
		private int int_2;

		// Token: 0x04000AAB RID: 2731
		private int int_3;

		// Token: 0x04000AAC RID: 2732
		private int int_4;

		// Token: 0x04000AAD RID: 2733
		private int int_5;

		// Token: 0x04000AAE RID: 2734
		private int int_6;

		// Token: 0x04000AAF RID: 2735
		private int int_7;

		// Token: 0x04000AB0 RID: 2736
		private int int_8;

		// Token: 0x04000AB1 RID: 2737
		private int int_9;

		// Token: 0x04000AB2 RID: 2738
		private int int_10;

		// Token: 0x04000AB3 RID: 2739
		private bool bool_0;

		// Token: 0x04000AB4 RID: 2740
		private bool bool_1;

		// Token: 0x04000AB5 RID: 2741
		private bool bool_2;

		// Token: 0x04000AB6 RID: 2742
		private bool bool_3;

		// Token: 0x04000AB7 RID: 2743
		private bool bool_4;

		// Token: 0x04000AB8 RID: 2744
		private bool bool_5;

		// Token: 0x04000AB9 RID: 2745
		private bool bool_6;

		// Token: 0x04000ABA RID: 2746
		private bool bool_7;

		// Token: 0x04000ABB RID: 2747
		private bool bool_8;

		// Token: 0x04000ABC RID: 2748
		private bool bool_9;

		// Token: 0x04000ABD RID: 2749
		private bool bool_10;

		// Token: 0x04000ABE RID: 2750
		private bool bool_11;

		// Token: 0x04000ABF RID: 2751
		private bool bool_12;

		// Token: 0x04000AC0 RID: 2752
		private bool bool_13;

		// Token: 0x04000AC1 RID: 2753
		private bool bool_14;

		// Token: 0x04000AC2 RID: 2754
		private bool bool_15;
	}
}
