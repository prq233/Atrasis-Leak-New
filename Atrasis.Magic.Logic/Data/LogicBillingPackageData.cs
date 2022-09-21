using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200013D RID: 317
	public class LogicBillingPackageData : LogicData
	{
		// Token: 0x06001116 RID: 4374 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicBillingPackageData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x0004B5E8 File Offset: 0x000497E8
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.bool_0 = base.GetBooleanValue("Disabled", 0);
			this.bool_1 = base.GetBooleanValue("ExistsApple", 0);
			this.bool_2 = base.GetBooleanValue("ExistsAndroid", 0);
			this.int_0 = base.GetIntegerValue("Diamonds", 0);
			this.int_1 = base.GetIntegerValue("USD", 0);
			this.string_0 = base.GetValue("ShopItemExportName", 0);
			this.string_1 = base.GetValue("OfferItemExportName", 0);
			this.int_2 = base.GetIntegerValue("Order", 0);
			this.bool_3 = base.GetBooleanValue("RED", 0);
			this.int_3 = base.GetIntegerValue("RMB", 0);
			this.bool_4 = base.GetBooleanValue("KunlunOnly", 0);
			this.int_4 = base.GetIntegerValue("LenovoID", 0);
			this.string_2 = base.GetValue("TencentID", 0);
			this.bool_5 = base.GetBooleanValue("isOfferPackage", 0);
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x0000B833 File Offset: 0x00009A33
		public bool Disabled()
		{
			return this.bool_0;
		}

		// Token: 0x06001119 RID: 4377 RVA: 0x0000B83B File Offset: 0x00009A3B
		public bool ExistsApple()
		{
			return this.bool_1;
		}

		// Token: 0x0600111A RID: 4378 RVA: 0x0000B843 File Offset: 0x00009A43
		public bool ExistsAndroid()
		{
			return this.bool_2;
		}

		// Token: 0x0600111B RID: 4379 RVA: 0x0000B84B File Offset: 0x00009A4B
		public int GetDiamonds()
		{
			return this.int_0;
		}

		// Token: 0x0600111C RID: 4380 RVA: 0x0000B853 File Offset: 0x00009A53
		public int GetUSD()
		{
			return this.int_1;
		}

		// Token: 0x0600111D RID: 4381 RVA: 0x0000B85B File Offset: 0x00009A5B
		public string GetShopItemExportName()
		{
			return this.string_0;
		}

		// Token: 0x0600111E RID: 4382 RVA: 0x0000B863 File Offset: 0x00009A63
		public string GetOfferItemExportName()
		{
			return this.string_1;
		}

		// Token: 0x0600111F RID: 4383 RVA: 0x0000B86B File Offset: 0x00009A6B
		public int GetOrder()
		{
			return this.int_2;
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x0000B873 File Offset: 0x00009A73
		public bool IsRED()
		{
			return this.bool_3;
		}

		// Token: 0x06001121 RID: 4385 RVA: 0x0000B87B File Offset: 0x00009A7B
		public int GetRMB()
		{
			return this.int_3;
		}

		// Token: 0x06001122 RID: 4386 RVA: 0x0000B883 File Offset: 0x00009A83
		public bool IsKunlunOnly()
		{
			return this.bool_4;
		}

		// Token: 0x06001123 RID: 4387 RVA: 0x0000B88B File Offset: 0x00009A8B
		public int GetLenovoID()
		{
			return this.int_4;
		}

		// Token: 0x06001124 RID: 4388 RVA: 0x0000B893 File Offset: 0x00009A93
		public string GetTencentID()
		{
			return this.string_2;
		}

		// Token: 0x06001125 RID: 4389 RVA: 0x0000B89B File Offset: 0x00009A9B
		public bool IsOfferPackage()
		{
			return this.bool_5;
		}

		// Token: 0x04000762 RID: 1890
		private string string_0;

		// Token: 0x04000763 RID: 1891
		private string string_1;

		// Token: 0x04000764 RID: 1892
		private string string_2;

		// Token: 0x04000765 RID: 1893
		private int int_0;

		// Token: 0x04000766 RID: 1894
		private int int_1;

		// Token: 0x04000767 RID: 1895
		private int int_2;

		// Token: 0x04000768 RID: 1896
		private int int_3;

		// Token: 0x04000769 RID: 1897
		private int int_4;

		// Token: 0x0400076A RID: 1898
		private bool bool_0;

		// Token: 0x0400076B RID: 1899
		private bool bool_1;

		// Token: 0x0400076C RID: 1900
		private bool bool_2;

		// Token: 0x0400076D RID: 1901
		private bool bool_3;

		// Token: 0x0400076E RID: 1902
		private bool bool_4;

		// Token: 0x0400076F RID: 1903
		private bool bool_5;
	}
}
