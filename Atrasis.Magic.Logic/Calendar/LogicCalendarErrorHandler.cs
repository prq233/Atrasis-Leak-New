using System;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Calendar
{
	// Token: 0x020001F4 RID: 500
	public class LogicCalendarErrorHandler
	{
		// Token: 0x06001966 RID: 6502 RVA: 0x00010E35 File Offset: 0x0000F035
		public void Error(LogicCalendarEvent eventName, string message)
		{
			Debugger.Error(string.Format("Error in calendar event {0}: {1}", eventName, message));
		}

		// Token: 0x06001967 RID: 6503 RVA: 0x00010E48 File Offset: 0x0000F048
		public void ErrorField(LogicCalendarEvent eventName, string field, string message)
		{
			Debugger.Error(string.Format("Error in calendar event {0}, field {1}: {2}", eventName, field, message));
		}

		// Token: 0x06001968 RID: 6504 RVA: 0x00010E48 File Offset: 0x0000F048
		public void ErrorFunction(LogicCalendarEvent eventName, LogicCalendarFunction function, string message)
		{
			Debugger.Error(string.Format("Error in calendar event {0}, field {1}: {2}", eventName, function, message));
		}

		// Token: 0x06001969 RID: 6505 RVA: 0x00010E5C File Offset: 0x0000F05C
		public void ErrorFunction(LogicCalendarEvent eventName, LogicCalendarFunction function, string parameter, string message)
		{
			Debugger.Error(string.Format("Error in calendar event {0}, function {1}, parameter {2}: {3}", new object[]
			{
				eventName,
				function,
				parameter,
				message
			}));
		}

		// Token: 0x0600196A RID: 6506 RVA: 0x00010E84 File Offset: 0x0000F084
		public void Warning(LogicCalendarEvent eventName, string message)
		{
			Debugger.Error(string.Format("Warning in calendar event {0}: {1}", eventName, message));
		}

		// Token: 0x0600196B RID: 6507 RVA: 0x00010E97 File Offset: 0x0000F097
		public void WarningField(LogicCalendarEvent eventName, string field, string message)
		{
			Debugger.Error(string.Format("Warning in calendar event {0}, field {1}: {2}", eventName, field, message));
		}

		// Token: 0x0600196C RID: 6508 RVA: 0x00010EAB File Offset: 0x0000F0AB
		public void WarningFunction(LogicCalendarEvent eventName, LogicCalendarFunction function, string message)
		{
			Debugger.Error(string.Format("Warning in calendar event {0}, function {1}: {2}", eventName, function, message));
		}

		// Token: 0x0600196D RID: 6509 RVA: 0x00010EBF File Offset: 0x0000F0BF
		public void WarningFunction(LogicCalendarEvent eventName, LogicCalendarFunction function, string parameter, string message)
		{
			Debugger.Error(string.Format("Warning in calendar event {0}, function {1}, parameter {2}: {3}", new object[]
			{
				eventName,
				function,
				parameter,
				message
			}));
		}
	}
}
