using System;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001FA RID: 506
	public class LogicDuelLootLimitCalendarEvent : LogicCalendarEvent
	{
		// Token: 0x060019C6 RID: 6598 RVA: 0x00061C68 File Offset: 0x0005FE68
		public override void Load(LogicJSONObject jsonObject)
		{
			base.Load(jsonObject);
			this.int_14 = LogicJSONHelper.GetInt(jsonObject, "lootLimitCooldownInMinutes", 1320);
			this.int_15 = LogicJSONHelper.GetInt(jsonObject, "duelBonusPercentWin", 100);
			this.int_16 = LogicJSONHelper.GetInt(jsonObject, "duelBonusPercentLose", 0);
			this.int_17 = LogicJSONHelper.GetInt(jsonObject, "duelBonusPercentDraw", 0);
			this.int_18 = LogicJSONHelper.GetInt(jsonObject, "duelBonusMaxDiamondCostPercent", 100);
		}

		// Token: 0x060019C7 RID: 6599 RVA: 0x00061CDC File Offset: 0x0005FEDC
		public override LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = base.Save();
			logicJSONObject.Put("lootLimitCooldownInMinutes", new LogicJSONNumber(this.int_14));
			logicJSONObject.Put("duelBonusPercentWin", new LogicJSONNumber(this.int_15));
			logicJSONObject.Put("duelBonusPercentLose", new LogicJSONNumber(this.int_16));
			logicJSONObject.Put("duelBonusPercentDraw", new LogicJSONNumber(this.int_17));
			logicJSONObject.Put("duelBonusMaxDiamondCostPercent", new LogicJSONNumber(this.int_18));
			return logicJSONObject;
		}

		// Token: 0x060019C8 RID: 6600 RVA: 0x00002EAE File Offset: 0x000010AE
		public override int GetCalendarEventType()
		{
			return 4;
		}

		// Token: 0x060019C9 RID: 6601 RVA: 0x00011231 File Offset: 0x0000F431
		public int GetDuelLootLimitCooldownInMinutes()
		{
			return this.int_14;
		}

		// Token: 0x060019CA RID: 6602 RVA: 0x00011239 File Offset: 0x0000F439
		public void SetDuelLootLimitCooldownInMinutes(int value)
		{
			this.int_14 = value;
		}

		// Token: 0x060019CB RID: 6603 RVA: 0x00011242 File Offset: 0x0000F442
		public int GetDuelBonusPercentWin()
		{
			return this.int_15;
		}

		// Token: 0x060019CC RID: 6604 RVA: 0x0001124A File Offset: 0x0000F44A
		public void SetDuelBonusPercentWin(int value)
		{
			this.int_15 = value;
		}

		// Token: 0x060019CD RID: 6605 RVA: 0x00011253 File Offset: 0x0000F453
		public int GetDuelBonusPercentLose()
		{
			return this.int_16;
		}

		// Token: 0x060019CE RID: 6606 RVA: 0x0001125B File Offset: 0x0000F45B
		public void SetDuelBonusPercentLose(int value)
		{
			this.int_16 = value;
		}

		// Token: 0x060019CF RID: 6607 RVA: 0x00011264 File Offset: 0x0000F464
		public int GetDuelBonusPercentDraw()
		{
			return this.int_17;
		}

		// Token: 0x060019D0 RID: 6608 RVA: 0x0001126C File Offset: 0x0000F46C
		public void SetDuelBonusPercentDraw(int value)
		{
			this.int_17 = value;
		}

		// Token: 0x060019D1 RID: 6609 RVA: 0x00011275 File Offset: 0x0000F475
		public int GetDuelBonusMaxDiamondCostPercent()
		{
			return this.int_18;
		}

		// Token: 0x060019D2 RID: 6610 RVA: 0x0001127D File Offset: 0x0000F47D
		public void SetDuelBonusMaxDiamondCostPercent(int value)
		{
			this.int_18 = value;
		}

		// Token: 0x04000DDD RID: 3549
		private int int_14;

		// Token: 0x04000DDE RID: 3550
		private int int_15;

		// Token: 0x04000DDF RID: 3551
		private int int_16;

		// Token: 0x04000DE0 RID: 3552
		private int int_17;

		// Token: 0x04000DE1 RID: 3553
		private int int_18;
	}
}
