using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200015D RID: 349
	public class LogicObstacleData : LogicGameObjectData
	{
		// Token: 0x06001481 RID: 5249 RVA: 0x0000B4F2 File Offset: 0x000096F2
		public LogicObstacleData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001482 RID: 5250 RVA: 0x00051974 File Offset: 0x0004FB74
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("ExportName", 0);
			this.string_1 = base.GetValue("ExportNameBase", 0);
			this.int_5 = base.GetIntegerValue("Width", 0);
			this.int_6 = base.GetIntegerValue("Height", 0);
			this.bool_0 = base.GetBooleanValue("Passable", 0);
			this.logicEffectData_0 = LogicDataTables.GetEffectByName(base.GetValue("ClearEffect", 0), this);
			this.logicEffectData_1 = LogicDataTables.GetEffectByName(base.GetValue("PickUpEffect", 0), this);
			this.bool_1 = base.GetBooleanValue("IsTombstone", 0);
			this.int_7 = base.GetIntegerValue("TombGroup", 0);
			this.int_8 = base.GetIntegerValue("AppearancePeriodHours", 0);
			this.int_9 = base.GetIntegerValue("MinRespawnTimeHours", 0);
			this.int_15 = base.GetIntegerValue("LootDefensePercentage", 0);
			this.int_16 = base.GetIntegerValue("RedMul", 0);
			this.int_17 = base.GetIntegerValue("GreenMul", 0);
			this.int_18 = base.GetIntegerValue("BlueMul", 0);
			this.int_19 = base.GetIntegerValue("RedAdd", 0);
			this.int_20 = base.GetIntegerValue("GreenAdd", 0);
			this.int_21 = base.GetIntegerValue("BlueAdd", 0);
			this.bool_2 = base.GetBooleanValue("LightsOn", 0);
			this.int_22 = base.GetIntegerValue("Village2RespawnCount", 0);
			this.int_23 = base.GetIntegerValue("VariationCount", 0);
			this.bool_3 = base.GetBooleanValue("TallGrass", 0);
			this.bool_4 = base.GetBooleanValue("TallGrassSpawnPoint", 0);
			this.int_24 = base.GetIntegerValue("LootHighlightPercentage", 0);
			this.string_2 = base.GetValue("HighlightExportName", 0);
			this.logicResourceData_0 = LogicDataTables.GetResourceByName(base.GetValue("ClearResource", 0), this);
			if (this.logicResourceData_0 == null)
			{
				Debugger.Error("Clear resource is not defined for obstacle: " + base.GetName());
			}
			this.int_1 = base.GetIntegerValue("ClearCost", 0);
			this.int_2 = base.GetIntegerValue("ClearTimeSeconds", 0);
			this.int_3 = base.GetIntegerValue("RespawnWeight", 0);
			string value = base.GetValue("LootResource", 0);
			if (value.Length <= 0)
			{
				this.int_3 = 0;
			}
			else
			{
				this.logicResourceData_1 = LogicDataTables.GetResourceByName(value, this);
				this.int_0 = base.GetIntegerValue("LootCount", 0);
			}
			this.int_4 = base.GetIntegerValue("LootMultiplierForVersion2", 0);
			if (this.int_4 == 0)
			{
				this.int_4 = 1;
			}
			string value2 = base.GetValue("SpawnObstacle", 0);
			if (value2.Length > 0)
			{
				this.logicObstacleData_0 = LogicDataTables.GetObstacleByName(value2, this);
				this.int_10 = base.GetIntegerValue("SpawnRadius", 0);
				this.int_11 = base.GetIntegerValue("SpawnIntervalSeconds", 0);
				this.int_12 = base.GetIntegerValue("SpawnCount", 0);
				this.int_13 = base.GetIntegerValue("MaxSpawned", 0);
				this.int_14 = base.GetIntegerValue("MaxLifetimeSpawns", 0);
			}
		}

		// Token: 0x06001483 RID: 5251 RVA: 0x00051C9C File Offset: 0x0004FE9C
		public override void CreateReferences2()
		{
			if (this.logicResourceData_1 != null && this.logicResourceData_1.GetVillageType() != base.GetVillageType() && !this.logicResourceData_1.IsPremiumCurrency())
			{
				Debugger.Error("invalid resource");
			}
			if (this.logicResourceData_0.GetVillageType() != base.GetVillageType() && !this.logicResourceData_0.IsPremiumCurrency())
			{
				Debugger.Error("invalid clear resource");
			}
		}

		// Token: 0x06001484 RID: 5252 RVA: 0x0000D77E File Offset: 0x0000B97E
		public int GetRespawnWeight()
		{
			return this.int_3;
		}

		// Token: 0x06001485 RID: 5253 RVA: 0x0000D786 File Offset: 0x0000B986
		public int GetClearTime()
		{
			return this.int_2;
		}

		// Token: 0x06001486 RID: 5254 RVA: 0x0000D78E File Offset: 0x0000B98E
		public LogicResourceData GetClearResourceData()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x06001487 RID: 5255 RVA: 0x0000D796 File Offset: 0x0000B996
		public LogicResourceData GetLootResourceData()
		{
			return this.logicResourceData_1;
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x0000D79E File Offset: 0x0000B99E
		public int GetLootCount()
		{
			return this.int_0;
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x0000D7A6 File Offset: 0x0000B9A6
		public int GetClearCost()
		{
			return this.int_1;
		}

		// Token: 0x0600148A RID: 5258 RVA: 0x0000D7AE File Offset: 0x0000B9AE
		public int GetLootMultiplierVersion2()
		{
			return this.int_4;
		}

		// Token: 0x0600148B RID: 5259 RVA: 0x0000D7B6 File Offset: 0x0000B9B6
		public bool IsLootCart()
		{
			return this.int_15 > 0;
		}

		// Token: 0x0600148C RID: 5260 RVA: 0x0000D7C1 File Offset: 0x0000B9C1
		public string GetExportName()
		{
			return this.string_0;
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x0000D7C9 File Offset: 0x0000B9C9
		public string GetExportNameBase()
		{
			return this.string_1;
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x0000D7D1 File Offset: 0x0000B9D1
		public int GetWidth()
		{
			return this.int_5;
		}

		// Token: 0x0600148F RID: 5263 RVA: 0x0000D7D9 File Offset: 0x0000B9D9
		public int GetHeight()
		{
			return this.int_6;
		}

		// Token: 0x06001490 RID: 5264 RVA: 0x0000D7E1 File Offset: 0x0000B9E1
		public bool IsPassable()
		{
			return this.bool_0;
		}

		// Token: 0x06001491 RID: 5265 RVA: 0x0000D7E9 File Offset: 0x0000B9E9
		public int GetTombGroup()
		{
			return this.int_7;
		}

		// Token: 0x06001492 RID: 5266 RVA: 0x0000D7F1 File Offset: 0x0000B9F1
		public LogicEffectData GetClearEffect()
		{
			return this.logicEffectData_0;
		}

		// Token: 0x06001493 RID: 5267 RVA: 0x0000D7F9 File Offset: 0x0000B9F9
		public LogicEffectData GetPickUpEffect()
		{
			return this.logicEffectData_1;
		}

		// Token: 0x06001494 RID: 5268 RVA: 0x0000D801 File Offset: 0x0000BA01
		public LogicObstacleData GetSpawnObstacle()
		{
			return this.logicObstacleData_0;
		}

		// Token: 0x06001495 RID: 5269 RVA: 0x0000D809 File Offset: 0x0000BA09
		public bool IsTombstone()
		{
			return this.bool_1;
		}

		// Token: 0x06001496 RID: 5270 RVA: 0x0000D811 File Offset: 0x0000BA11
		public int GetAppearancePeriodHours()
		{
			return this.int_8;
		}

		// Token: 0x06001497 RID: 5271 RVA: 0x0000D819 File Offset: 0x0000BA19
		public int GetMinRespawnTimeHours()
		{
			return this.int_9;
		}

		// Token: 0x06001498 RID: 5272 RVA: 0x0000D821 File Offset: 0x0000BA21
		public int GetSpawnRadius()
		{
			return this.int_10;
		}

		// Token: 0x06001499 RID: 5273 RVA: 0x0000D829 File Offset: 0x0000BA29
		public int GetSpawnIntervalSeconds()
		{
			return this.int_11;
		}

		// Token: 0x0600149A RID: 5274 RVA: 0x0000D831 File Offset: 0x0000BA31
		public int GetSpawnCount()
		{
			return this.int_12;
		}

		// Token: 0x0600149B RID: 5275 RVA: 0x0000D839 File Offset: 0x0000BA39
		public int GetMaxSpawned()
		{
			return this.int_13;
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x0000D841 File Offset: 0x0000BA41
		public int GetMaxLifetimeSpawns()
		{
			return this.int_14;
		}

		// Token: 0x0600149D RID: 5277 RVA: 0x0000D849 File Offset: 0x0000BA49
		public int GetLootDefensePercentage()
		{
			return this.int_15;
		}

		// Token: 0x0600149E RID: 5278 RVA: 0x0000D851 File Offset: 0x0000BA51
		public int GetRedMul()
		{
			return this.int_16;
		}

		// Token: 0x0600149F RID: 5279 RVA: 0x0000D859 File Offset: 0x0000BA59
		public int GetGreenMul()
		{
			return this.int_17;
		}

		// Token: 0x060014A0 RID: 5280 RVA: 0x0000D861 File Offset: 0x0000BA61
		public int GetBlueMul()
		{
			return this.int_18;
		}

		// Token: 0x060014A1 RID: 5281 RVA: 0x0000D869 File Offset: 0x0000BA69
		public int GetRedAdd()
		{
			return this.int_19;
		}

		// Token: 0x060014A2 RID: 5282 RVA: 0x0000D871 File Offset: 0x0000BA71
		public int GetGreenAdd()
		{
			return this.int_20;
		}

		// Token: 0x060014A3 RID: 5283 RVA: 0x0000D879 File Offset: 0x0000BA79
		public int GetBlueAdd()
		{
			return this.int_21;
		}

		// Token: 0x060014A4 RID: 5284 RVA: 0x0000D881 File Offset: 0x0000BA81
		public bool IsLightsOn()
		{
			return this.bool_2;
		}

		// Token: 0x060014A5 RID: 5285 RVA: 0x0000D889 File Offset: 0x0000BA89
		public int GetVillage2RespawnCount()
		{
			return this.int_22;
		}

		// Token: 0x060014A6 RID: 5286 RVA: 0x0000D891 File Offset: 0x0000BA91
		public int GetVariationCount()
		{
			return this.int_23;
		}

		// Token: 0x060014A7 RID: 5287 RVA: 0x0000D899 File Offset: 0x0000BA99
		public bool IsTallGrass()
		{
			return this.bool_3;
		}

		// Token: 0x060014A8 RID: 5288 RVA: 0x0000D8A1 File Offset: 0x0000BAA1
		public bool IsTallGrassSpawnPoint()
		{
			return this.bool_4;
		}

		// Token: 0x060014A9 RID: 5289 RVA: 0x0000D8A9 File Offset: 0x0000BAA9
		public int GetLootHighlightPercentage()
		{
			return this.int_24;
		}

		// Token: 0x060014AA RID: 5290 RVA: 0x0000D8B1 File Offset: 0x0000BAB1
		public string GetHighlightExportName()
		{
			return this.string_2;
		}

		// Token: 0x04000ACF RID: 2767
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000AD0 RID: 2768
		private LogicResourceData logicResourceData_1;

		// Token: 0x04000AD1 RID: 2769
		private LogicEffectData logicEffectData_0;

		// Token: 0x04000AD2 RID: 2770
		private LogicEffectData logicEffectData_1;

		// Token: 0x04000AD3 RID: 2771
		private LogicObstacleData logicObstacleData_0;

		// Token: 0x04000AD4 RID: 2772
		private string string_0;

		// Token: 0x04000AD5 RID: 2773
		private string string_1;

		// Token: 0x04000AD6 RID: 2774
		private string string_2;

		// Token: 0x04000AD7 RID: 2775
		private bool bool_0;

		// Token: 0x04000AD8 RID: 2776
		private bool bool_1;

		// Token: 0x04000AD9 RID: 2777
		private bool bool_2;

		// Token: 0x04000ADA RID: 2778
		private bool bool_3;

		// Token: 0x04000ADB RID: 2779
		private bool bool_4;

		// Token: 0x04000ADC RID: 2780
		private int int_0;

		// Token: 0x04000ADD RID: 2781
		private int int_1;

		// Token: 0x04000ADE RID: 2782
		private int int_2;

		// Token: 0x04000ADF RID: 2783
		private int int_3;

		// Token: 0x04000AE0 RID: 2784
		private int int_4;

		// Token: 0x04000AE1 RID: 2785
		private int int_5;

		// Token: 0x04000AE2 RID: 2786
		private int int_6;

		// Token: 0x04000AE3 RID: 2787
		private int int_7;

		// Token: 0x04000AE4 RID: 2788
		private int int_8;

		// Token: 0x04000AE5 RID: 2789
		private int int_9;

		// Token: 0x04000AE6 RID: 2790
		private int int_10;

		// Token: 0x04000AE7 RID: 2791
		private int int_11;

		// Token: 0x04000AE8 RID: 2792
		private int int_12;

		// Token: 0x04000AE9 RID: 2793
		private int int_13;

		// Token: 0x04000AEA RID: 2794
		private int int_14;

		// Token: 0x04000AEB RID: 2795
		private int int_15;

		// Token: 0x04000AEC RID: 2796
		private int int_16;

		// Token: 0x04000AED RID: 2797
		private int int_17;

		// Token: 0x04000AEE RID: 2798
		private int int_18;

		// Token: 0x04000AEF RID: 2799
		private int int_19;

		// Token: 0x04000AF0 RID: 2800
		private int int_20;

		// Token: 0x04000AF1 RID: 2801
		private int int_21;

		// Token: 0x04000AF2 RID: 2802
		private int int_22;

		// Token: 0x04000AF3 RID: 2803
		private int int_23;

		// Token: 0x04000AF4 RID: 2804
		private int int_24;
	}
}
