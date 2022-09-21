using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x02000004 RID: 4
	public class GClass1 : ServerMessageManager
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000020A3 File Offset: 0x000002A3
		public override void OnReceiveAccountMessage(ServerAccountMessage message)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020A3 File Offset: 0x000002A3
		public override void OnReceiveRequestMessage(ServerRequestMessage message)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002240 File Offset: 0x00000440
		public override void OnReceiveSessionMessage(ServerSessionMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType == ServerMessageType.FORWARD_LOGIC_REQUEST_MESSAGE)
			{
				GClass1.smethod_0((ForwardLogicRequestMessage)message);
				return;
			}
			if (messageType != ServerMessageType.SEND_ALLIANCE_BOOKMARKS_FULL_DATA_TO_CLIENT)
			{
				return;
			}
			GClass1.smethod_4((SendAllianceBookmarksFullDataToClientMessage)message);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000227C File Offset: 0x0000047C
		private static void smethod_0(ForwardLogicRequestMessage forwardLogicRequestMessage_0)
		{
			GClass1.Class1 @class = new GClass1.Class1();
			@class.forwardLogicRequestMessage_0 = forwardLogicRequestMessage_0;
			PiranhaMessage piranhaMessage = LogicMagicMessageFactory.Instance.CreateMessageByType((int)@class.forwardLogicRequestMessage_0.MessageType);
			if (piranhaMessage == null)
			{
				throw new Exception("logicMessage should not be NULL!");
			}
			piranhaMessage.GetByteStream().SetByteArray(@class.forwardLogicRequestMessage_0.MessageBytes, @class.forwardLogicRequestMessage_0.MessageLength);
			piranhaMessage.SetMessageVersion((int)@class.forwardLogicRequestMessage_0.MessageVersion);
			piranhaMessage.Decode();
			if (!piranhaMessage.IsServerToClientMessage())
			{
				short messageType = piranhaMessage.GetMessageType();
				if (messageType == 14303)
				{
					ServerRequestManager.Create(new AvatarRequestMessage
					{
						AccountId = @class.forwardLogicRequestMessage_0.AccountId
					}, ServerManager.GetDocumentSocket(9, @class.forwardLogicRequestMessage_0.AccountId), 5).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
					return;
				}
				if (messageType != 14324)
				{
					return;
				}
				GClass1.smethod_2((SearchAlliancesMessage)piranhaMessage, @class.forwardLogicRequestMessage_0);
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002368 File Offset: 0x00000568
		private static void smethod_1(ForwardLogicRequestMessage forwardLogicRequestMessage_0, ServerRequestArgs serverRequestArgs_0)
		{
			GClass1.Struct0 @struct;
			@struct.forwardLogicRequestMessage_0 = forwardLogicRequestMessage_0;
			@struct.serverRequestArgs_0 = serverRequestArgs_0;
			@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
			asyncVoidMethodBuilder_.Start<GClass1.Struct0>(ref @struct);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000023AC File Offset: 0x000005AC
		private static void smethod_2(SearchAlliancesMessage searchAlliancesMessage_0, ForwardLogicRequestMessage forwardLogicRequestMessage_0)
		{
			GClass1.Struct2 @struct;
			@struct.searchAlliancesMessage_0 = searchAlliancesMessage_0;
			@struct.forwardLogicRequestMessage_0 = forwardLogicRequestMessage_0;
			@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
			asyncVoidMethodBuilder_.Start<GClass1.Struct2>(ref @struct);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000023F0 File Offset: 0x000005F0
		private static ForwardLogicMessage smethod_3(PiranhaMessage piranhaMessage_0, long long_0)
		{
			if (piranhaMessage_0.GetEncodingLength() == 0)
			{
				piranhaMessage_0.Encode();
			}
			return new ForwardLogicMessage
			{
				SessionId = long_0,
				MessageType = piranhaMessage_0.GetMessageType(),
				MessageVersion = (short)piranhaMessage_0.GetMessageVersion(),
				MessageLength = piranhaMessage_0.GetEncodingLength(),
				MessageBytes = piranhaMessage_0.GetMessageBytes()
			};
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002448 File Offset: 0x00000648
		private static void smethod_4(SendAllianceBookmarksFullDataToClientMessage sendAllianceBookmarksFullDataToClientMessage_0)
		{
			GClass1.Struct3 @struct;
			@struct.sendAllianceBookmarksFullDataToClientMessage_0 = sendAllianceBookmarksFullDataToClientMessage_0;
			@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
			asyncVoidMethodBuilder_.Start<GClass1.Struct3>(ref @struct);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000020AA File Offset: 0x000002AA
		public override void OnReceiveCoreMessage(ServerCoreMessage message)
		{
			if (message.GetMessageType() == ServerMessageType.SERVER_PERFORMANCE)
			{
				ServerMessageManager.SendMessage(new ServerPerformanceDataMessage(), message.Sender);
			}
		}

		// Token: 0x02000005 RID: 5
		[CompilerGenerated]
		private sealed class Class1
		{
			// Token: 0x06000011 RID: 17 RVA: 0x000020D1 File Offset: 0x000002D1
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				GClass1.smethod_1(this.forwardLogicRequestMessage_0, serverRequestArgs_0);
			}

			// Token: 0x04000002 RID: 2
			public ForwardLogicRequestMessage forwardLogicRequestMessage_0;
		}

		// Token: 0x02000007 RID: 7
		[CompilerGenerated]
		private sealed class Class2
		{
			// Token: 0x06000015 RID: 21 RVA: 0x000025E8 File Offset: 0x000007E8
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				GClass1.Class2.Struct1 @struct;
				@struct.class2_0 = this;
				@struct.serverRequestArgs_0 = serverRequestArgs_0;
				@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
				@struct.int_0 = -1;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
				asyncVoidMethodBuilder_.Start<GClass1.Class2.Struct1>(ref @struct);
			}

			// Token: 0x0400000A RID: 10
			public SearchAlliancesMessage searchAlliancesMessage_0;

			// Token: 0x0400000B RID: 11
			public ForwardLogicRequestMessage forwardLogicRequestMessage_0;

			// Token: 0x02000008 RID: 8
			[StructLayout(LayoutKind.Auto)]
			private struct Struct1 : IAsyncStateMachine
			{
				// Token: 0x06000016 RID: 22 RVA: 0x0000262C File Offset: 0x0000082C
				void IAsyncStateMachine.MoveNext()
				{
					int num = this.int_0;
					GClass1.Class2 @class = this.class2_0;
					try
					{
						TaskAwaiter<LogicArrayList<AllianceHeaderEntry>> awaiter;
						if (num != 0)
						{
							LogicClientAvatar logicClientAvatar_ = null;
							if (this.serverRequestArgs_0.ErrorCode == ServerRequestError.Success && this.serverRequestArgs_0.ResponseMessage.Success)
							{
								logicClientAvatar_ = ((AvatarResponseMessage)this.serverRequestArgs_0.ResponseMessage).LogicClientAvatar;
							}
							this.allianceListMessage_0 = new AllianceListMessage();
							this.allianceListMessage_1 = this.allianceListMessage_0;
							awaiter = GClass2.smethod_2(@class.searchAlliancesMessage_0, logicClientAvatar_).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								this.int_0 = 0;
								this.taskAwaiter_0 = awaiter;
								this.asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter<LogicArrayList<AllianceHeaderEntry>>, GClass1.Class2.Struct1>(ref awaiter, ref this);
								return;
							}
						}
						else
						{
							awaiter = this.taskAwaiter_0;
							this.taskAwaiter_0 = default(TaskAwaiter<LogicArrayList<AllianceHeaderEntry>>);
							this.int_0 = -1;
						}
						LogicArrayList<AllianceHeaderEntry> result = awaiter.GetResult();
						this.allianceListMessage_1.SetAlliances(result);
						this.allianceListMessage_1 = null;
						this.allianceListMessage_0.SetBookmarkList(new LogicArrayList<LogicLong>());
						this.allianceListMessage_0.SetSearchString(@class.searchAlliancesMessage_0.GetSearchString());
						ServerMessageManager.SendMessage(GClass1.smethod_3(this.allianceListMessage_0, @class.forwardLogicRequestMessage_0.SessionId), ServerManager.GetProxySocket(@class.forwardLogicRequestMessage_0.SessionId));
					}
					catch (Exception exception)
					{
						this.int_0 = -2;
						this.asyncVoidMethodBuilder_0.SetException(exception);
						return;
					}
					this.int_0 = -2;
					this.asyncVoidMethodBuilder_0.SetResult();
				}

				// Token: 0x06000017 RID: 23 RVA: 0x000020ED File Offset: 0x000002ED
				[DebuggerHidden]
				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine iasyncStateMachine_0)
				{
					this.asyncVoidMethodBuilder_0.SetStateMachine(iasyncStateMachine_0);
				}

				// Token: 0x0400000C RID: 12
				public int int_0;

				// Token: 0x0400000D RID: 13
				public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

				// Token: 0x0400000E RID: 14
				public ServerRequestArgs serverRequestArgs_0;

				// Token: 0x0400000F RID: 15
				public GClass1.Class2 class2_0;

				// Token: 0x04000010 RID: 16
				private AllianceListMessage allianceListMessage_0;

				// Token: 0x04000011 RID: 17
				private AllianceListMessage allianceListMessage_1;

				// Token: 0x04000012 RID: 18
				private TaskAwaiter<LogicArrayList<AllianceHeaderEntry>> taskAwaiter_0;
			}
		}
	}
}
