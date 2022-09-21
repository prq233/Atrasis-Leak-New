using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001F6 RID: 502
	public static class LogicCalendarEventFactory
	{
		// Token: 0x060019B0 RID: 6576 RVA: 0x00011129 File Offset: 0x0000F329
		public static LogicCalendarEvent CreateByType(int type)
		{
			switch (type)
			{
			case 0:
				return new LogicCalendarEvent();
			case 1:
				return new LogicOfferCalendarEvent();
			case 4:
				return new LogicDuelLootLimitCalendarEvent();
			}
			Debugger.Error("Unknown calendar event type!");
			return null;
		}

		// Token: 0x060019B1 RID: 6577 RVA: 0x000613F8 File Offset: 0x0005F5F8
		public static LogicCalendarEvent LoadFromJSON(LogicJSONObject jsonObject, LogicCalendarErrorHandler errorHandler)
		{
			LogicCalendarEvent logicCalendarEvent = LogicCalendarEventFactory.CreateByType(jsonObject.GetJSONNumber("type").GetIntValue());
			if (errorHandler != null)
			{
				logicCalendarEvent.SetErrorHandler(errorHandler);
			}
			logicCalendarEvent.Init(jsonObject);
			return logicCalendarEvent;
		}
	}
}
