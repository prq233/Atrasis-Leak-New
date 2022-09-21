using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;

namespace ns0
{
	// Token: 0x0200002E RID: 46
	internal class Class4
	{
		// Token: 0x06000104 RID: 260 RVA: 0x0000BB18 File Offset: 0x00009D18
		public Class4(ServerMessageManager serverMessageManager_1)
		{
			this.bool_0 = true;
			this.concurrentQueue_0 = new ConcurrentQueue<Class4.Struct0>();
			this.concurrentQueue_1 = new ConcurrentQueue<ServerMessage>();
			this.autoResetEvent_0 = new AutoResetEvent(false);
			this.autoResetEvent_1 = new AutoResetEvent(false);
			this.serverMessageManager_0 = serverMessageManager_1;
			this.thread_0 = new Thread(new ThreadStart(this.method_1));
			this.thread_0.Start();
			this.thread_1 = new Thread(new ThreadStart(this.method_0));
			this.thread_1.Start();
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000BBAC File Offset: 0x00009DAC
		private void method_0()
		{
			while (this.bool_0)
			{
				this.autoResetEvent_1.WaitOne();
				ServerMessage serverMessage;
				while (this.concurrentQueue_1.TryDequeue(out serverMessage))
				{
					try
					{
						switch (serverMessage.GetMessageCategory())
						{
						case ServerMessageCategory.ACCOUNT:
							this.serverMessageManager_0.OnReceiveAccountMessage((ServerAccountMessage)serverMessage);
							break;
						case ServerMessageCategory.REQUEST:
							this.serverMessageManager_0.OnReceiveRequestMessage((ServerRequestMessage)serverMessage);
							break;
						case ServerMessageCategory.RESPONSE:
							ServerRequestManager.smethod_1((ServerResponseMessage)serverMessage);
							break;
						case ServerMessageCategory.SESSION:
							this.serverMessageManager_0.OnReceiveSessionMessage((ServerSessionMessage)serverMessage);
							break;
						case ServerMessageCategory.CORE:
							if (!ServerMessageManager.smethod_0((ServerCoreMessage)serverMessage))
							{
								this.serverMessageManager_0.OnReceiveCoreMessage((ServerCoreMessage)serverMessage);
							}
							break;
						default:
							Logging.Error("ServerMessageHandler.receive: unknown message category: " + serverMessage.GetMessageCategory());
							break;
						}
					}
					catch (Exception ex)
					{
						Logging.Warning(string.Concat(new object[]
						{
							"ServerMessageHandler.receive: exception when the handle of message type ",
							serverMessage.GetMessageType(),
							", trace: ",
							ex
						}));
					}
				}
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000BCD8 File Offset: 0x00009ED8
		private void method_1()
		{
			while (this.bool_0)
			{
				this.autoResetEvent_0.WaitOne();
				Class4.Struct0 @struct;
				while (this.concurrentQueue_0.TryDequeue(out @struct))
				{
					byte[] byte_;
					int int_;
					Class2.smethod_4(@struct.Message, out byte_, out int_);
					@struct.Socket.method_0(byte_, int_);
				}
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00004FA6 File Offset: 0x000031A6
		public void method_2(ServerMessage serverMessage_0)
		{
			this.concurrentQueue_1.Enqueue(serverMessage_0);
			this.autoResetEvent_1.Set();
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00004FC0 File Offset: 0x000031C0
		public void method_3(ServerMessage serverMessage_0, ServerSocket serverSocket_0)
		{
			this.concurrentQueue_0.Enqueue(new Class4.Struct0(serverMessage_0, serverSocket_0));
			this.autoResetEvent_0.Set();
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00004FE0 File Offset: 0x000031E0
		public virtual void vmethod_0()
		{
			while (this.concurrentQueue_0.Count != 0 || this.concurrentQueue_1.Count != 0)
			{
				Thread.Sleep(50);
			}
			this.bool_0 = false;
		}

		// Token: 0x040000D4 RID: 212
		private readonly Thread thread_0;

		// Token: 0x040000D5 RID: 213
		private readonly Thread thread_1;

		// Token: 0x040000D6 RID: 214
		private readonly ConcurrentQueue<Class4.Struct0> concurrentQueue_0;

		// Token: 0x040000D7 RID: 215
		private readonly ConcurrentQueue<ServerMessage> concurrentQueue_1;

		// Token: 0x040000D8 RID: 216
		private readonly AutoResetEvent autoResetEvent_0;

		// Token: 0x040000D9 RID: 217
		private readonly AutoResetEvent autoResetEvent_1;

		// Token: 0x040000DA RID: 218
		private readonly ServerMessageManager serverMessageManager_0;

		// Token: 0x040000DB RID: 219
		private bool bool_0;

		// Token: 0x0200002F RID: 47
		private struct Struct0
		{
			// Token: 0x1700003F RID: 63
			// (get) Token: 0x0600010A RID: 266 RVA: 0x00005013 File Offset: 0x00003213
			internal ServerMessage Message { get; }

			// Token: 0x17000040 RID: 64
			// (get) Token: 0x0600010B RID: 267 RVA: 0x0000501B File Offset: 0x0000321B
			internal ServerSocket Socket { get; }

			// Token: 0x0600010C RID: 268 RVA: 0x00005023 File Offset: 0x00003223
			internal Struct0(ServerMessage serverMessage_1, ServerSocket serverSocket_1)
			{
				this.Message = serverMessage_1;
				this.Socket = serverSocket_1;
			}

			// Token: 0x040000DC RID: 220
			[CompilerGenerated]
			private readonly ServerMessage serverMessage_0;

			// Token: 0x040000DD RID: 221
			[CompilerGenerated]
			private readonly ServerSocket serverSocket_0;
		}
	}
}
