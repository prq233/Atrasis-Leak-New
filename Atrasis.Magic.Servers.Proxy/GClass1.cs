using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Account;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Session;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x02000004 RID: 4
	public class GClass1 : ServerSession
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00002120 File Offset: 0x00000320
		[CompilerGenerated]
		public GClass3 method_0()
		{
			return this.gclass3_0;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002128 File Offset: 0x00000328
		public GClass1(long long_0, GClass3 gclass3_1, AccountDocument accountDocument_0) : base(long_0, accountDocument_0.Id, gclass3_1.method_6())
		{
			this.gclass3_0 = gclass3_1;
			this.int_0 = -1;
			this.dateTime_0 = DateTime.UtcNow;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002680 File Offset: 0x00000880
		public override void Destruct()
		{
			for (int i = 0; i < 30; i++)
			{
				if (this.m_sockets[i] != null)
				{
					base.SendMessage(new StopServerSessionMessage(), i);
				}
			}
			GClass0.smethod_6().DeleteIfEquals(base.AccountId, base.Id.ToString());
			this.method_2();
			base.Destruct();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000026E0 File Offset: 0x000008E0
		public void method_1(int int_1)
		{
			if (this.int_0 != int_1)
			{
				this.int_0 = int_1;
				if (this.int_0 <= 0 || this.int_0 <= TimeUtil.GetTimestamp())
				{
					this.int_0 = -1;
				}
				ChatAccountBanStatusMessage chatAccountBanStatusMessage = new ChatAccountBanStatusMessage();
				chatAccountBanStatusMessage.SetBanSeconds(LogicMath.Max(this.int_0 - TimeUtil.GetTimestamp(), 0));
				base.SendPiranhaMessage(chatAccountBanStatusMessage, 1);
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002740 File Offset: 0x00000940
		private void method_2()
		{
			GClass1.Struct0 @struct;
			@struct.gclass1_0 = this;
			@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
			asyncVoidMethodBuilder_.Start<GClass1.Struct0>(ref @struct);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000277C File Offset: 0x0000097C
		public void method_3(ServerSocket serverSocket_0, BindServerSocketRequestMessage bindServerSocketRequestMessage_0 = null)
		{
			if (this.m_destructed)
			{
				return;
			}
			int serverType = serverSocket_0.ServerType;
			int serverId = serverSocket_0.ServerId;
			if (this.m_sockets[serverType] != null)
			{
				base.SendMessage(new StopServerSessionMessage(), serverType);
			}
			this.m_sockets[serverType] = serverSocket_0;
			if (serverType == 1)
			{
				return;
			}
			if (!this.bool_0 && serverSocket_0.ServerType != 9)
			{
				Logging.Warning("ProxySession.setSocket called but session did not start.");
			}
			LogicArrayList<int> logicArrayList = new LogicArrayList<int>();
			LogicArrayList<int> logicArrayList2 = new LogicArrayList<int>();
			for (int i = 0; i < 30; i++)
			{
				ServerSocket serverSocket = this.m_sockets[i];
				if (serverSocket != null)
				{
					logicArrayList.Add(serverSocket.ServerType);
					logicArrayList2.Add(serverSocket.ServerId);
				}
			}
			base.SendMessage(new StartServerSessionMessage
			{
				AccountId = base.AccountId,
				Country = base.Country,
				ServerSocketTypeList = logicArrayList,
				ServerSocketIdList = logicArrayList2,
				BindRequestMessage = bindServerSocketRequestMessage_0
			}, serverType);
			for (int j = 2; j < 30; j++)
			{
				if (j != serverType && this.m_sockets[serverType] != null)
				{
					base.SendMessage(new UpdateSocketServerSessionMessage
					{
						ServerType = serverType,
						ServerId = serverId
					}, j);
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000289C File Offset: 0x00000A9C
		public void method_4(int int_1, bool bool_1 = true)
		{
			if (this.m_sockets[int_1] != null)
			{
				if (bool_1)
				{
					base.SendMessage(new StopServerSessionMessage(), int_1);
				}
				this.m_sockets[int_1] = null;
				for (int i = 2; i < 30; i++)
				{
					if (i != int_1 && this.m_sockets[int_1] != null)
					{
						base.SendMessage(new UpdateSocketServerSessionMessage
						{
							ServerType = int_1,
							ServerId = -1
						}, i);
					}
				}
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002156 File Offset: 0x00000356
		public ServerSocket method_5(int int_1)
		{
			return this.m_sockets[int_1];
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002900 File Offset: 0x00000B00
		public void method_6()
		{
			if (this.bool_0 && this.m_sockets[6] == null && (this.int_0 == -1 || TimeUtil.GetTimestamp() > this.int_0))
			{
				ServerSocket nextSocket = ServerManager.GetNextSocket(6);
				if (nextSocket != null)
				{
					this.method_3(nextSocket, null);
				}
				this.int_0 = -1;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002160 File Offset: 0x00000360
		public void method_7()
		{
			this.bool_0 = true;
		}

		// Token: 0x04000005 RID: 5
		[CompilerGenerated]
		private readonly GClass3 gclass3_0;

		// Token: 0x04000006 RID: 6
		private int int_0;

		// Token: 0x04000007 RID: 7
		private bool bool_0;

		// Token: 0x04000008 RID: 8
		private readonly DateTime dateTime_0;
	}
}
