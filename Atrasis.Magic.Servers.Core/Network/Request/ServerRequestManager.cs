using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using ns0;

namespace Atrasis.Magic.Servers.Core.Network.Request
{
	// Token: 0x02000029 RID: 41
	public static class ServerRequestManager
	{
		// Token: 0x060000F2 RID: 242 RVA: 0x00004EE6 File Offset: 0x000030E6
		public static void Init()
		{
			ServerRequestManager.bool_0 = true;
			ServerRequestManager.concurrentDictionary_0 = new ConcurrentDictionary<long, ServerRequestArgs>();
			ServerRequestManager.thread_0 = new Thread(new ThreadStart(ServerRequestManager.smethod_0));
			ServerRequestManager.thread_0.Start();
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000B604 File Offset: 0x00009804
		private static void smethod_0()
		{
			while (ServerRequestManager.bool_0)
			{
				DateTime utcNow = DateTime.UtcNow;
				foreach (KeyValuePair<long, ServerRequestArgs> keyValuePair in ServerRequestManager.concurrentDictionary_0)
				{
					ServerRequestArgs serverRequestArgs;
					if (utcNow > keyValuePair.Value.ExpireTime && ServerRequestManager.concurrentDictionary_0.TryRemove(keyValuePair.Key, out serverRequestArgs))
					{
						keyValuePair.Value.method_0();
					}
				}
				Thread.Sleep(500);
			}
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000B69C File Offset: 0x0000989C
		public static ServerRequestArgs Create(ServerRequestMessage message, ServerSocket socket, int timeout = 30)
		{
			ServerRequestArgs serverRequestArgs = new ServerRequestArgs(timeout);
			long num = Interlocked.Increment(ref ServerRequestManager.long_0);
			message.RequestId = num;
			if (!ServerRequestManager.concurrentDictionary_0.TryAdd(num, serverRequestArgs))
			{
				throw new Exception("Unable to add new message");
			}
			Class2.smethod_5(message, socket);
			return serverRequestArgs;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00004F18 File Offset: 0x00003118
		public static void SendResponse(ServerResponseMessage response, ServerRequestMessage request)
		{
			response.RequestId = request.RequestId;
			Class2.smethod_5(response, ServerManager.GetSocket(request.SenderType, request.SenderId));
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000B6E4 File Offset: 0x000098E4
		internal static void smethod_1(ServerResponseMessage serverResponseMessage_0)
		{
			ServerRequestArgs serverRequestArgs;
			if (ServerRequestManager.concurrentDictionary_0.TryRemove(serverResponseMessage_0.RequestId, out serverRequestArgs))
			{
				serverRequestArgs.method_1(serverResponseMessage_0);
			}
		}

		// Token: 0x04000061 RID: 97
		private static ConcurrentDictionary<long, ServerRequestArgs> concurrentDictionary_0;

		// Token: 0x04000062 RID: 98
		private static Thread thread_0;

		// Token: 0x04000063 RID: 99
		private static bool bool_0;

		// Token: 0x04000064 RID: 100
		private static long long_0;
	}
}
