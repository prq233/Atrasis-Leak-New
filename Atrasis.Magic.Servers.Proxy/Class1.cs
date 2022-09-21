using System;
using System.Collections.Concurrent;
using System.Threading;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Titan.Message;

namespace ns0
{
	// Token: 0x0200000E RID: 14
	internal static class Class1
	{
		// Token: 0x0600005B RID: 91 RVA: 0x000036B8 File Offset: 0x000018B8
		internal static void smethod_0()
		{
			Class1.bool_0 = true;
			Class1.autoResetEvent_0 = new AutoResetEvent(false);
			Class1.autoResetEvent_1 = new AutoResetEvent(false);
			Class1.concurrentQueue_0 = new ConcurrentQueue<Class1.Struct1>();
			Class1.concurrentQueue_1 = new ConcurrentQueue<Class1.Struct1>();
			Class1.thread_0 = new Thread(new ThreadStart(Class1.smethod_1));
			Class1.thread_0.Name = "Message Receive Handler";
			Class1.thread_0.Start();
			Class1.thread_1 = new Thread(new ThreadStart(Class1.smethod_2));
			Class1.thread_1.Name = "Message Send Handler";
			Class1.thread_1.Start();
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003754 File Offset: 0x00001954
		private static void smethod_1()
		{
			while (Class1.bool_0)
			{
				Class1.autoResetEvent_0.WaitOne();
				Class1.Struct1 @struct;
				while (Class1.concurrentQueue_0.TryDequeue(out @struct))
				{
					try
					{
						@struct.gclass3_0.method_2().method_0(@struct.piranhaMessage_0);
					}
					catch (Exception arg)
					{
						Logging.Error("MessageHandler.receive: unable to handle the piranha message: " + arg);
					}
				}
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000037C4 File Offset: 0x000019C4
		private static void smethod_2()
		{
			while (Class1.bool_0)
			{
				Class1.autoResetEvent_1.WaitOne();
				Class1.Struct1 @struct;
				while (Class1.concurrentQueue_1.TryDequeue(out @struct))
				{
					@struct.gclass3_0.method_1().method_11(@struct.piranhaMessage_0);
				}
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000240E File Offset: 0x0000060E
		internal static void smethod_3(PiranhaMessage piranhaMessage_0, GClass3 gclass3_0)
		{
			Class1.concurrentQueue_0.Enqueue(new Class1.Struct1(piranhaMessage_0, gclass3_0));
			Class1.autoResetEvent_0.Set();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000242C File Offset: 0x0000062C
		internal static void smethod_4(PiranhaMessage piranhaMessage_0, GClass3 gclass3_0)
		{
			Class1.concurrentQueue_1.Enqueue(new Class1.Struct1(piranhaMessage_0, gclass3_0));
			Class1.autoResetEvent_1.Set();
		}

		// Token: 0x0400003A RID: 58
		private static Thread thread_0;

		// Token: 0x0400003B RID: 59
		private static Thread thread_1;

		// Token: 0x0400003C RID: 60
		private static ConcurrentQueue<Class1.Struct1> concurrentQueue_0;

		// Token: 0x0400003D RID: 61
		private static ConcurrentQueue<Class1.Struct1> concurrentQueue_1;

		// Token: 0x0400003E RID: 62
		private static AutoResetEvent autoResetEvent_0;

		// Token: 0x0400003F RID: 63
		private static AutoResetEvent autoResetEvent_1;

		// Token: 0x04000040 RID: 64
		private static bool bool_0;

		// Token: 0x0200000F RID: 15
		private struct Struct1
		{
			// Token: 0x06000060 RID: 96 RVA: 0x0000244A File Offset: 0x0000064A
			internal Struct1(PiranhaMessage piranhaMessage_1, GClass3 gclass3_1)
			{
				this.piranhaMessage_0 = piranhaMessage_1;
				this.gclass3_0 = gclass3_1;
			}

			// Token: 0x04000041 RID: 65
			internal readonly PiranhaMessage piranhaMessage_0;

			// Token: 0x04000042 RID: 66
			internal readonly GClass3 gclass3_0;
		}
	}
}
