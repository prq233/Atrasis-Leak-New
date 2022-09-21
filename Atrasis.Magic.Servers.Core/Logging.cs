using System;
using System.Diagnostics;
using System.IO;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Titan.Debug;
using ns0;

namespace Atrasis.Magic.Servers.Core
{
	// Token: 0x02000004 RID: 4
	public static class Logging
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00004625 File Offset: 0x00002825
		internal static void smethod_0()
		{
			Atrasis.Magic.Titan.Debug.Debugger.SetListener(new Class1());
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00004631 File Offset: 0x00002831
		[Conditional("DEBUG")]
		public static void Print(string message)
		{
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00004633 File Offset: 0x00002833
		public static void Warning(string message)
		{
			if (Logging.SEND_LOGS && Logging.SEND_WARNING_LOGS && ServerManager.IsInit() && ServerManager.GetServerCount(0) != 0)
			{
				Class2.smethod_5(new ServerLogMessage
				{
					LogType = 0,
					Message = message
				}, ServerManager.GetSocket(0, 0));
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000970C File Offset: 0x0000790C
		public static void Error(string message)
		{
			if (Logging.SEND_LOGS && ServerManager.IsInit() && ServerManager.GetServerCount(0) != 0)
			{
				Class2.smethod_5(new ServerLogMessage
				{
					LogType = 1,
					Message = message
				}, ServerManager.GetSocket(0, 0));
			}
			File.AppendAllText("logs.txt", message + "\n");
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00004671 File Offset: 0x00002871
		public static void Event(string type, string message)
		{
			Class2.smethod_5(new EventLogMessage
			{
				Type = type,
				Message = message
			}, ServerManager.GetSocket(0, 0));
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00004692 File Offset: 0x00002892
		public static void Assert(bool condition, string assertionFailed)
		{
			if (!condition)
			{
				Logging.Error(assertionFailed);
			}
		}

		// Token: 0x04000005 RID: 5
		public static bool SEND_LOGS;

		// Token: 0x04000006 RID: 6
		public static bool SEND_WARNING_LOGS;
	}
}
