using System;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Battle
{
	// Token: 0x020001FD RID: 509
	public class LogicReplay
	{
		// Token: 0x06001A0F RID: 6671 RVA: 0x00011480 File Offset: 0x0000F680
		public LogicReplay(LogicLevel level)
		{
			this.logicLevel_0 = level;
			this.logicJSONObject_0 = new LogicJSONObject();
			this.StartRecord();
		}

		// Token: 0x06001A10 RID: 6672 RVA: 0x000114A0 File Offset: 0x0000F6A0
		public void Destruct()
		{
			this.logicJSONObject_0 = null;
			this.logicJSONNumber_0 = null;
			this.logicJSONNumber_1 = null;
		}

		// Token: 0x06001A11 RID: 6673 RVA: 0x00062F08 File Offset: 0x00061108
		public void StartRecord()
		{
			this.logicJSONObject_0 = new LogicJSONObject();
			this.logicJSONNumber_0 = new LogicJSONNumber();
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			LogicJSONObject logicJSONObject2 = new LogicJSONObject();
			LogicJSONObject logicJSONObject3 = new LogicJSONObject();
			this.logicLevel_0.SaveToJSON(logicJSONObject);
			this.logicLevel_0.GetVisitorAvatar().SaveToReplay(logicJSONObject2);
			this.logicLevel_0.GetHomeOwnerAvatar().SaveToReplay(logicJSONObject3);
			this.logicJSONObject_0.Put("level", logicJSONObject);
			this.logicJSONObject_0.Put("attacker", logicJSONObject2);
			this.logicJSONObject_0.Put("defender", logicJSONObject3);
			this.logicJSONObject_0.Put("end_tick", this.logicJSONNumber_0);
			this.logicJSONObject_0.Put("timestamp", new LogicJSONNumber(this.logicLevel_0.GetGameMode().GetStartTime()));
			this.logicJSONObject_0.Put("cmd", new LogicJSONArray());
			this.logicJSONObject_0.Put("calendar", this.logicLevel_0.GetCalendar().Save());
			if (this.logicLevel_0.GetGameMode().GetConfiguration().GetJson() != null)
			{
				this.logicJSONObject_0.Put("globals", this.logicLevel_0.GetGameMode().GetConfiguration().GetJson());
			}
		}

		// Token: 0x06001A12 RID: 6674 RVA: 0x000114B7 File Offset: 0x0000F6B7
		public void SubTick()
		{
			this.logicJSONNumber_0.SetIntValue(this.logicLevel_0.GetLogicTime().GetTick() + 1);
		}

		// Token: 0x06001A13 RID: 6675 RVA: 0x0006304C File Offset: 0x0006124C
		public void RecordCommand(LogicCommand command)
		{
			LogicJSONArray jsonarray = this.logicJSONObject_0.GetJSONArray("cmd");
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			LogicCommandManager.SaveCommandToJSON(logicJSONObject, command);
			jsonarray.Add(logicJSONObject);
		}

		// Token: 0x06001A14 RID: 6676 RVA: 0x000114D6 File Offset: 0x0000F6D6
		public void RecordPreparationSkipTime(int secs)
		{
			if (secs > 0)
			{
				if (this.logicJSONNumber_1 == null)
				{
					this.logicJSONNumber_1 = new LogicJSONNumber();
					this.logicJSONObject_0.Put("prep_skip", this.logicJSONNumber_1);
				}
				this.logicJSONNumber_1.SetIntValue(secs);
			}
		}

		// Token: 0x06001A15 RID: 6677 RVA: 0x00011511 File Offset: 0x0000F711
		public LogicJSONObject GetJson()
		{
			return this.logicJSONObject_0;
		}

		// Token: 0x04000E13 RID: 3603
		private readonly LogicLevel logicLevel_0;

		// Token: 0x04000E14 RID: 3604
		private LogicJSONObject logicJSONObject_0;

		// Token: 0x04000E15 RID: 3605
		private LogicJSONNumber logicJSONNumber_0;

		// Token: 0x04000E16 RID: 3606
		private LogicJSONNumber logicJSONNumber_1;
	}
}
