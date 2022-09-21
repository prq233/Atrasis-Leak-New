using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000138 RID: 312
	public class LogicAllianceLevelData : LogicData
	{
		// Token: 0x060010B0 RID: 4272 RVA: 0x0000B3C0 File Offset: 0x000095C0
		public LogicAllianceLevelData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060010B1 RID: 4273 RVA: 0x0004AA74 File Offset: 0x00048C74
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.bool_0 = base.GetBooleanValue("IsVisible", 0);
			this.int_0 = base.GetIntegerValue("ExpPoints", 0);
			LogicAllianceLevelData logicAllianceLevelData = null;
			if (base.GetInstanceID() > 0)
			{
				logicAllianceLevelData = (LogicAllianceLevelData)this.m_table.GetItemAt(base.GetInstanceID() - 1);
			}
			this.int_1 = base.GetIntegerValue("TroopRequestCooldown", 0);
			if (logicAllianceLevelData != null && this.int_1 == 0)
			{
				this.int_1 = logicAllianceLevelData.int_1;
			}
			this.int_2 = base.GetIntegerValue("TroopDonationLimit", 0);
			if (logicAllianceLevelData != null && this.int_2 == 0)
			{
				this.int_2 = logicAllianceLevelData.int_2;
			}
			this.int_3 = base.GetIntegerValue("TroopDonationRefund", 0);
			if (logicAllianceLevelData != null && this.int_3 == 0)
			{
				this.int_3 = logicAllianceLevelData.int_3;
			}
			this.int_4 = base.GetIntegerValue("TroopDonationUpgrade", 0);
			if (logicAllianceLevelData != null && this.int_4 == 0)
			{
				this.int_4 = logicAllianceLevelData.int_4;
			}
			this.int_5 = base.GetIntegerValue("WarLootCapacityPercent", 0);
			if (logicAllianceLevelData != null && this.int_5 == 0)
			{
				this.int_5 = logicAllianceLevelData.int_5;
			}
			this.int_6 = base.GetIntegerValue("WarLootMultiplierPercent", 0);
			if (logicAllianceLevelData != null && this.int_6 == 0)
			{
				this.int_6 = logicAllianceLevelData.int_6;
			}
			this.int_7 = base.GetIntegerValue("BadgeLevel", 0);
			if (logicAllianceLevelData != null && this.int_7 == 0)
			{
				this.int_7 = logicAllianceLevelData.int_7;
			}
		}

		// Token: 0x060010B2 RID: 4274 RVA: 0x0000B4AA File Offset: 0x000096AA
		public bool IsVisible()
		{
			return this.bool_0;
		}

		// Token: 0x060010B3 RID: 4275 RVA: 0x0000B4B2 File Offset: 0x000096B2
		public int GetExpPoints()
		{
			return this.int_0;
		}

		// Token: 0x060010B4 RID: 4276 RVA: 0x0000B4BA File Offset: 0x000096BA
		public int GetTroopRequestCooldown()
		{
			return this.int_1;
		}

		// Token: 0x060010B5 RID: 4277 RVA: 0x0000B4C2 File Offset: 0x000096C2
		public int GetTroopDonationLimit()
		{
			return this.int_2;
		}

		// Token: 0x060010B6 RID: 4278 RVA: 0x0000B4CA File Offset: 0x000096CA
		public int GetTroopDonationRefund()
		{
			return this.int_3;
		}

		// Token: 0x060010B7 RID: 4279 RVA: 0x0000B4D2 File Offset: 0x000096D2
		public int GetTroopDonationUpgrade()
		{
			return this.int_4;
		}

		// Token: 0x060010B8 RID: 4280 RVA: 0x0000B4DA File Offset: 0x000096DA
		public int GetWarLootCapacityPercent()
		{
			return this.int_5;
		}

		// Token: 0x060010B9 RID: 4281 RVA: 0x0000B4E2 File Offset: 0x000096E2
		public int GetWarLootMultiplierPercent()
		{
			return this.int_6;
		}

		// Token: 0x060010BA RID: 4282 RVA: 0x0000B4EA File Offset: 0x000096EA
		public int GetBadgeLevel()
		{
			return this.int_7;
		}

		// Token: 0x040006FC RID: 1788
		private int int_0;

		// Token: 0x040006FD RID: 1789
		private bool bool_0;

		// Token: 0x040006FE RID: 1790
		private int int_1;

		// Token: 0x040006FF RID: 1791
		private int int_2;

		// Token: 0x04000700 RID: 1792
		private int int_3;

		// Token: 0x04000701 RID: 1793
		private int int_4;

		// Token: 0x04000702 RID: 1794
		private int int_5;

		// Token: 0x04000703 RID: 1795
		private int int_6;

		// Token: 0x04000704 RID: 1796
		private int int_7;
	}
}
