using System;
using Atrasis.Magic.Logic.Offer;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000151 RID: 337
	public class LogicGemBundleData : LogicData
	{
		// Token: 0x060012DD RID: 4829 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicGemBundleData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060012DE RID: 4830 RVA: 0x0004E4D8 File Offset: 0x0004C6D8
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.bool_0 = !base.GetBooleanValue("Disabled", 0);
			this.bool_1 = base.GetBooleanValue("ExistsApple", 0);
			this.bool_2 = base.GetBooleanValue("ExistsAndroid", 0);
			this.bool_3 = base.GetBooleanValue("ExistsKunlun", 0);
			this.bool_4 = base.GetBooleanValue("ExistsBazaar", 0);
			this.bool_5 = base.GetBooleanValue("ExistsTencent", 0);
			this.string_0 = base.GetValue("ShopItemExportName", 0);
			this.string_1 = base.GetValue("ShopItemInfoExportName", 0);
			this.string_2 = base.GetValue("ShopItemBG", 0);
			this.bool_6 = base.GetBooleanValue("RED", 0);
			this.bool_7 = base.GetBooleanValue("OfferedByCalendar", 0);
			this.int_0 = base.GetIntegerValue("TownhallLimitMin", 0);
			this.int_1 = base.GetIntegerValue("TownhallLimitMax", 0);
			this.bool_8 = base.GetBooleanValue("ResourceAmountFromThCSV", 0);
			int arraySize = base.GetArraySize("Resources");
			this.logicArrayList_1 = new LogicArrayList<LogicResourceData>(arraySize);
			this.logicArrayList_3 = new LogicArrayList<int>(arraySize);
			for (int i = 0; i < arraySize; i++)
			{
				string value = base.GetValue("Resources", i);
				if (value.Length > 0)
				{
					LogicResourceData resourceByName = LogicDataTables.GetResourceByName(value, this);
					if (resourceByName != null)
					{
						if (resourceByName.GetWarResourceReferenceData() != null)
						{
							Debugger.Error("Can't give WarResource as Resource in GemBundleData");
						}
						if (resourceByName.IsPremiumCurrency())
						{
							Debugger.Error("Can't give PremiumCurrency as Resource in GemBundleData");
						}
						this.logicArrayList_3.Add(base.GetIntegerValue("ResourceAmounts", i));
					}
				}
			}
			arraySize = base.GetArraySize("Buildings");
			this.logicArrayList_2 = new LogicArrayList<LogicData>(arraySize);
			this.logicArrayList_4 = new LogicArrayList<int>(arraySize);
			this.logicArrayList_5 = new LogicArrayList<int>(arraySize);
			this.logicArrayList_6 = new LogicArrayList<int>(arraySize);
			for (int j = 0; j < arraySize; j++)
			{
				this.logicArrayList_4.Add(base.GetIntegerValue("BuildingNumber", j));
				this.logicArrayList_5.Add(base.GetIntegerValue("BuildingLevel", j));
				this.logicArrayList_6.Add(base.GetIntegerValue("GemCost", j));
				string value2 = base.GetValue("Buildings", j);
				if (value2.Length > 0)
				{
					LogicData logicData = null;
					string value3 = base.GetValue("BuildingType", j);
					if (value3 != null)
					{
						if (!(value3 == "building"))
						{
							if (value3 == "deco")
							{
								logicData = LogicDataTables.GetDecoByName(value2, this);
							}
						}
						else
						{
							logicData = LogicDataTables.GetBuildingByName(value2, this);
						}
					}
					if (logicData != null)
					{
						this.logicArrayList_2.Add(logicData);
					}
				}
			}
			arraySize = base.GetArraySize("UnlocksTroop");
			this.logicArrayList_0 = new LogicArrayList<LogicCombatItemData>(arraySize);
			for (int k = 0; k < arraySize; k++)
			{
				string value4 = base.GetValue("UnlocksTroop", k);
				if (value4.Length > 0)
				{
					LogicCombatItemData logicCombatItemData = null;
					string value3 = base.GetValue("TroopType", k);
					if (value3 != null)
					{
						if (!(value3 == "troop"))
						{
							if (value3 == "spell")
							{
								logicCombatItemData = LogicDataTables.GetSpellByName(value4, this);
							}
						}
						else
						{
							logicCombatItemData = LogicDataTables.GetCharacterByName(value4, this);
						}
					}
					if (logicCombatItemData != null)
					{
						this.logicArrayList_0.Add(logicCombatItemData);
					}
				}
			}
			this.logicBillingPackageData_0 = LogicDataTables.GetBillingPackageByName(base.GetValue("BillingPackage", 0), this);
			if (this.logicBillingPackageData_0 == null)
			{
				Debugger.Error("No billing package set!");
			}
			this.int_2 = base.GetIntegerValue("Priority", 0);
			this.bool_11 = base.GetBooleanValue("FrontPageItem", 0);
			this.bool_12 = base.GetBooleanValue("TreasureItem", 0);
			this.int_3 = base.GetIntegerValue("ValueForUI", 0);
			this.string_3 = base.GetValue("ValueTID", 0);
			this.int_4 = base.GetIntegerValue("TimesCanBePurchased", 0);
			this.int_5 = base.GetIntegerValue("AvailableTimeMinutes", 0);
			this.int_6 = base.GetIntegerValue("CooldownAfterPurchaseMinutes", 0);
			this.int_7 = base.GetIntegerValue("ShopFrontPageCooldownAfterPurchaseMin", 0);
			this.bool_10 = base.GetBooleanValue("HideTimer", 0);
			this.int_8 = base.GetIntegerValue("LinkedPackageID", 0);
			this.bool_9 = base.GetName().EndsWith("_ALT");
			this.int_9 = base.GetIntegerValue("GiftGems", 0);
			this.int_10 = base.GetIntegerValue("GiftUsers", 0);
			string value5 = base.GetValue("ReplacesBillingPackage", 0);
			if (value5.Length > 0)
			{
				this.logicBillingPackageData_1 = LogicDataTables.GetBillingPackageByName(value5, this);
			}
			if (this.int_9 > 0 != this.int_10 > 0)
			{
				Debugger.Error("Gift values should both be ZERO or both be NON-ZERO");
			}
			if (!this.bool_11 && this.int_7 > 0)
			{
				Debugger.Error("FrontPageItem = FALSE => ShopFrontPageCooldownAfterPurchaseMin must be set 0");
			}
			this.int_12 = base.GetIntegerValue("VillageType", 0);
			if (this.int_12 != -1 && this.int_12 > 1)
			{
				Debugger.Error("invalid VillageType");
			}
			if (this.bool_0 && this.int_5 > 0)
			{
				Debugger.Warning("We should no longer use timed offers. Use chronos instead.");
			}
			if (this.bool_7)
			{
				Debugger.Warning("We no longer support enabling/disabling gem bundles thru chronos. Use chronos offers instead.");
				this.bool_7 = false;
			}
			this.int_11 = base.GetIntegerValue("THResourceMultiplier", 0);
			if (this.int_11 <= 0)
			{
				this.int_11 = 100;
			}
			this.logicDeliverableBundle_0 = this.CreateBundle();
		}

		// Token: 0x060012DF RID: 4831 RVA: 0x0004EA38 File Offset: 0x0004CC38
		public LogicDeliverableBundle CreateBundle()
		{
			LogicDeliverableBundle logicDeliverableBundle = new LogicDeliverableBundle();
			if (this.logicArrayList_2 != null)
			{
				for (int i = 0; i < this.logicArrayList_2.Size(); i++)
				{
					LogicData logicData = this.logicArrayList_2[i];
					int buildingLevel = this.logicArrayList_5[i];
					int buildingCount = this.logicArrayList_4[i];
					LogicDataType dataType = logicData.GetDataType();
					if (dataType != LogicDataType.BUILDING)
					{
						if (dataType == LogicDataType.DECO)
						{
							LogicDeliverableDecoration logicDeliverableDecoration = new LogicDeliverableDecoration();
							logicDeliverableDecoration.SetDecorationData((LogicDecoData)logicData);
							logicDeliverableBundle.AddDeliverable(logicDeliverableDecoration);
						}
					}
					else
					{
						LogicDeliverableBuilding logicDeliverableBuilding = new LogicDeliverableBuilding();
						logicDeliverableBuilding.SetBuildingData((LogicBuildingData)logicData);
						logicDeliverableBuilding.SetBuildingLevel(buildingLevel);
						logicDeliverableBuilding.SetBuildingCount(buildingCount);
						logicDeliverableBundle.AddDeliverable(logicDeliverableBuilding);
					}
				}
			}
			for (int j = 0; j < this.logicArrayList_1.Size(); j++)
			{
				if (this.bool_8)
				{
					LogicDeliverableScaledMultiplier logicDeliverableScaledMultiplier = new LogicDeliverableScaledMultiplier();
					logicDeliverableScaledMultiplier.SetScaledResourceData(this.logicArrayList_1[j]);
					logicDeliverableScaledMultiplier.SetScaledResourceMultiplier(this.int_11);
					logicDeliverableBundle.AddDeliverable(logicDeliverableScaledMultiplier);
				}
				else
				{
					LogicDeliverableResource logicDeliverableResource = new LogicDeliverableResource();
					logicDeliverableResource.SetResourceData(this.logicArrayList_1[j]);
					logicDeliverableResource.SetResourceAmount(this.logicArrayList_3[j]);
					logicDeliverableBundle.AddDeliverable(logicDeliverableResource);
				}
			}
			if (this.bool_6)
			{
				LogicDeliverableSpecial logicDeliverableSpecial = new LogicDeliverableSpecial();
				logicDeliverableSpecial.SetId(0);
				logicDeliverableBundle.AddDeliverable(logicDeliverableSpecial);
			}
			if (this.int_9 > 0)
			{
				LogicDeliverableGift logicDeliverableGift = new LogicDeliverableGift();
				LogicDeliverableResource logicDeliverableResource2 = new LogicDeliverableResource();
				logicDeliverableGift.SetGiftLimit(this.int_10);
				logicDeliverableResource2.SetResourceData(LogicDataTables.GetDiamondsData());
				logicDeliverableResource2.SetResourceAmount(this.int_9);
				logicDeliverableBundle.AddDeliverable(logicDeliverableGift);
				logicDeliverableBundle.AddDeliverable(logicDeliverableResource2);
			}
			return logicDeliverableBundle;
		}

		// Token: 0x060012E0 RID: 4832 RVA: 0x0000CA16 File Offset: 0x0000AC16
		public LogicBillingPackageData GetBillingPackage()
		{
			return this.logicBillingPackageData_0;
		}

		// Token: 0x060012E1 RID: 4833 RVA: 0x0000CA1E File Offset: 0x0000AC1E
		public int GetLinkedPackageId()
		{
			return this.int_8;
		}

		// Token: 0x060012E2 RID: 4834 RVA: 0x0000CA26 File Offset: 0x0000AC26
		public int GetShopFrontPageCooldownAfterPurchaseSeconds()
		{
			return 60 * this.int_7;
		}

		// Token: 0x060012E3 RID: 4835 RVA: 0x0000CA31 File Offset: 0x0000AC31
		public int GetVillageType()
		{
			return this.int_12;
		}

		// Token: 0x040008FC RID: 2300
		private bool bool_0;

		// Token: 0x040008FD RID: 2301
		private bool bool_1;

		// Token: 0x040008FE RID: 2302
		private bool bool_2;

		// Token: 0x040008FF RID: 2303
		private bool bool_3;

		// Token: 0x04000900 RID: 2304
		private bool bool_4;

		// Token: 0x04000901 RID: 2305
		private bool bool_5;

		// Token: 0x04000902 RID: 2306
		private bool bool_6;

		// Token: 0x04000903 RID: 2307
		private bool bool_7;

		// Token: 0x04000904 RID: 2308
		private bool bool_8;

		// Token: 0x04000905 RID: 2309
		private bool bool_9;

		// Token: 0x04000906 RID: 2310
		private bool bool_10;

		// Token: 0x04000907 RID: 2311
		private bool bool_11;

		// Token: 0x04000908 RID: 2312
		private bool bool_12;

		// Token: 0x04000909 RID: 2313
		private string string_0;

		// Token: 0x0400090A RID: 2314
		private string string_1;

		// Token: 0x0400090B RID: 2315
		private string string_2;

		// Token: 0x0400090C RID: 2316
		private string string_3;

		// Token: 0x0400090D RID: 2317
		private int int_0;

		// Token: 0x0400090E RID: 2318
		private int int_1;

		// Token: 0x0400090F RID: 2319
		private int int_2;

		// Token: 0x04000910 RID: 2320
		private int int_3;

		// Token: 0x04000911 RID: 2321
		private int int_4;

		// Token: 0x04000912 RID: 2322
		private int int_5;

		// Token: 0x04000913 RID: 2323
		private int int_6;

		// Token: 0x04000914 RID: 2324
		private int int_7;

		// Token: 0x04000915 RID: 2325
		private int int_8;

		// Token: 0x04000916 RID: 2326
		private int int_9;

		// Token: 0x04000917 RID: 2327
		private int int_10;

		// Token: 0x04000918 RID: 2328
		private int int_11;

		// Token: 0x04000919 RID: 2329
		private int int_12;

		// Token: 0x0400091A RID: 2330
		private LogicDeliverableBundle logicDeliverableBundle_0;

		// Token: 0x0400091B RID: 2331
		private LogicBillingPackageData logicBillingPackageData_0;

		// Token: 0x0400091C RID: 2332
		private LogicBillingPackageData logicBillingPackageData_1;

		// Token: 0x0400091D RID: 2333
		private LogicArrayList<LogicCombatItemData> logicArrayList_0;

		// Token: 0x0400091E RID: 2334
		private LogicArrayList<LogicResourceData> logicArrayList_1;

		// Token: 0x0400091F RID: 2335
		private LogicArrayList<LogicData> logicArrayList_2;

		// Token: 0x04000920 RID: 2336
		private LogicArrayList<int> logicArrayList_3;

		// Token: 0x04000921 RID: 2337
		private LogicArrayList<int> logicArrayList_4;

		// Token: 0x04000922 RID: 2338
		private LogicArrayList<int> logicArrayList_5;

		// Token: 0x04000923 RID: 2339
		private LogicArrayList<int> logicArrayList_6;
	}
}
