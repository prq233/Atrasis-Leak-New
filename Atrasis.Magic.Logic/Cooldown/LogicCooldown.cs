using System;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Cooldown
{
	// Token: 0x0200016A RID: 362
	public class LogicCooldown
	{
		// Token: 0x0600159F RID: 5535 RVA: 0x0000213B File Offset: 0x0000033B
		public LogicCooldown()
		{
		}

		// Token: 0x060015A0 RID: 5536 RVA: 0x0000E11B File Offset: 0x0000C31B
		public LogicCooldown(int targetGlobalId, int cooldownSecs)
		{
			this.int_0 = targetGlobalId;
			this.int_1 = LogicTime.GetCooldownSecondsInTicks(cooldownSecs);
		}

		// Token: 0x060015A1 RID: 5537 RVA: 0x0000E136 File Offset: 0x0000C336
		public void Tick()
		{
			if (this.int_1 > 0)
			{
				this.int_1--;
			}
		}

		// Token: 0x060015A2 RID: 5538 RVA: 0x0000E14F File Offset: 0x0000C34F
		public void FastForwardTime(int secs)
		{
			this.int_1 = LogicMath.Max(this.int_1 - LogicTime.GetCooldownSecondsInTicks(secs), 0);
		}

		// Token: 0x060015A3 RID: 5539 RVA: 0x00053A00 File Offset: 0x00051C00
		public void Load(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("cooldown");
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("target");
			if (jsonnumber == null)
			{
				Debugger.Error("LogicCooldown::load - Cooldown was not found!");
				return;
			}
			if (jsonnumber2 == null)
			{
				Debugger.Error("LogicCooldown::load - Target was not found!");
				return;
			}
			this.int_1 = jsonnumber.GetIntValue();
			this.int_0 = jsonnumber2.GetIntValue();
		}

		// Token: 0x060015A4 RID: 5540 RVA: 0x0000E16A File Offset: 0x0000C36A
		public void Save(LogicJSONObject jsonObject)
		{
			jsonObject.Put("cooldown", new LogicJSONNumber(this.int_1));
			jsonObject.Put("target", new LogicJSONNumber(this.int_0));
		}

		// Token: 0x060015A5 RID: 5541 RVA: 0x0000E198 File Offset: 0x0000C398
		public int GetCooldownSeconds()
		{
			return LogicTime.GetCooldownTicksInSeconds(this.int_1);
		}

		// Token: 0x060015A6 RID: 5542 RVA: 0x0000E1A5 File Offset: 0x0000C3A5
		public int GetTargetGlobalId()
		{
			return this.int_0;
		}

		// Token: 0x04000BD0 RID: 3024
		private int int_0;

		// Token: 0x04000BD1 RID: 3025
		private int int_1;
	}
}
