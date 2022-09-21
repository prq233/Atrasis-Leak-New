using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Account;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Logic.Message.Avatar;
using Atrasis.Magic.Logic.Message.Facebook;
using Atrasis.Magic.Logic.Message.Google;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Servers.Core.Settings;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Message.Security;

namespace ns0
{
	// Token: 0x02000010 RID: 16
	public class GClass8
	{
		// Token: 0x06000061 RID: 97 RVA: 0x0000245A File Offset: 0x0000065A
		public GClass8(GClass3 gclass3_1)
		{
			this.gclass3_0 = gclass3_1;
			this.dateTime_0 = DateTime.UtcNow;
			this.dictionary_0 = new Dictionary<short, DateTime>();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000380C File Offset: 0x00001A0C
		public void method_0(PiranhaMessage piranhaMessage_0)
		{
			int messageType = (int)piranhaMessage_0.GetMessageType();
			int serviceNodeType = piranhaMessage_0.GetServiceNodeType();
			GEnum0 genum = this.gclass3_0.method_10();
			if (genum != GEnum0.const_2)
			{
				if (genum == GEnum0.const_4)
				{
					return;
				}
				if (messageType != 10100 && messageType != 10101 && messageType != 10108 && messageType != 10121)
				{
					return;
				}
			}
			if (serviceNodeType == 1)
			{
				if (messageType <= 10117)
				{
					if (messageType <= 10101)
					{
						if (messageType == 10100)
						{
							this.method_2((ClientHelloMessage)piranhaMessage_0);
							return;
						}
						if (messageType != 10101)
						{
							return;
						}
						this.method_3((LoginMessage)piranhaMessage_0);
						return;
					}
					else
					{
						if (messageType == 10108)
						{
							this.method_5((KeepAliveMessage)piranhaMessage_0);
							return;
						}
						if (messageType != 10117)
						{
							return;
						}
						this.method_7((ReportUserMessage)piranhaMessage_0);
						return;
					}
				}
				else if (messageType <= 14201)
				{
					if (messageType == 10121)
					{
						this.method_6((UnlockAccountMessage)piranhaMessage_0);
						return;
					}
					if (messageType != 14201)
					{
						return;
					}
					this.method_8((BindFacebookAccountMessage)piranhaMessage_0);
					return;
				}
				else
				{
					if (messageType == 14211)
					{
						this.method_9((UnbindFacebookAccountMessage)piranhaMessage_0);
						return;
					}
					if (messageType != 14262)
					{
						return;
					}
					this.method_10((BindGoogleServiceAccountMessage)piranhaMessage_0);
					return;
				}
			}
			else
			{
				if (genum != GEnum0.const_2)
				{
					return;
				}
				GClass1 gclass = this.gclass3_0.method_3();
				if (gclass == null)
				{
					return;
				}
				if (!this.method_1(piranhaMessage_0))
				{
					if (serviceNodeType != 28)
					{
						if (serviceNodeType != 29)
						{
							gclass.SendPiranhaMessage(piranhaMessage_0, serviceNodeType);
							return;
						}
					}
					this.method_11(piranhaMessage_0, ServerManager.GetNextSocket(serviceNodeType));
					return;
				}
				if (messageType == 14302)
				{
					this.method_11(piranhaMessage_0, ServerManager.GetDocumentSocket(11, ((AskForAllianceDataMessage)piranhaMessage_0).RemoveAllianceId()));
					return;
				}
				if (messageType == 14325)
				{
					this.method_11(piranhaMessage_0, ServerManager.GetDocumentSocket(9, ((AskForAvatarProfileMessage)piranhaMessage_0).RemoveAvatarId()) ?? ServerManager.GetNextSocket(9));
					return;
				}
				return;
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000039B8 File Offset: 0x00001BB8
		private bool method_1(PiranhaMessage piranhaMessage_0)
		{
			int messageType = (int)piranhaMessage_0.GetMessageType();
			return messageType == 14325 || messageType == 14302;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000039E0 File Offset: 0x00001BE0
		private void method_2(ClientHelloMessage clientHelloMessage_0)
		{
			if (this.gclass3_0.method_10() == GEnum0.const_0 && this.method_15(clientHelloMessage_0.GetMajorVersion(), clientHelloMessage_0.GetBuildVersion(), null, clientHelloMessage_0.GetContentHash(), clientHelloMessage_0.GetAppStore()) && this.method_16())
			{
				Logging.Warning("MessageManager.clientHelloMessageReceived: pepper encryption not supported");
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003A30 File Offset: 0x00001C30
		private void method_3(LoginMessage loginMessage_0)
		{
			GClass8.Struct2 @struct;
			@struct.gclass8_0 = this;
			@struct.loginMessage_0 = loginMessage_0;
			@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
			asyncVoidMethodBuilder_.Start<GClass8.Struct2>(ref @struct);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003A74 File Offset: 0x00001C74
		private void method_4(ServerRequestArgs serverRequestArgs_0)
		{
			if (!this.gclass3_0.method_7())
			{
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					if (this.gclass3_0.method_10() == GEnum0.const_2)
					{
						this.gclass3_0.method_3().method_7();
						return;
					}
				}
				else
				{
					GClass4.smethod_7(this.gclass3_0, 0);
				}
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000247F File Offset: 0x0000067F
		private void method_5(KeepAliveMessage keepAliveMessage_0)
		{
			this.dateTime_0 = DateTime.UtcNow;
			this.method_13(new KeepAliveServerMessage());
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003AD0 File Offset: 0x00001CD0
		private void method_6(UnlockAccountMessage unlockAccountMessage_0)
		{
			GClass8.Struct3 @struct;
			@struct.gclass8_0 = this;
			@struct.unlockAccountMessage_0 = unlockAccountMessage_0;
			@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
			asyncVoidMethodBuilder_.Start<GClass8.Struct3>(ref @struct);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003B14 File Offset: 0x00001D14
		private void method_7(ReportUserMessage reportUserMessage_0)
		{
			GClass8.Struct4 @struct;
			@struct.gclass8_0 = this;
			@struct.reportUserMessage_0 = reportUserMessage_0;
			@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
			asyncVoidMethodBuilder_.Start<GClass8.Struct4>(ref @struct);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002497 File Offset: 0x00000697
		private void method_8(BindFacebookAccountMessage bindFacebookAccountMessage_0)
		{
			this.method_13(new FacebookAccountBoundMessage());
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000024A4 File Offset: 0x000006A4
		private void method_9(UnbindFacebookAccountMessage unbindFacebookAccountMessage_0)
		{
			this.method_13(new UnbindFacebookAccountMessage());
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003B58 File Offset: 0x00001D58
		private void method_10(BindGoogleServiceAccountMessage bindGoogleServiceAccountMessage_0)
		{
			GClass8.Struct5 @struct;
			@struct.gclass8_0 = this;
			@struct.bindGoogleServiceAccountMessage_0 = bindGoogleServiceAccountMessage_0;
			@struct.asyncVoidMethodBuilder_0 = AsyncVoidMethodBuilder.Create();
			@struct.int_0 = -1;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder_ = @struct.asyncVoidMethodBuilder_0;
			asyncVoidMethodBuilder_.Start<GClass8.Struct5>(ref @struct);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003B9C File Offset: 0x00001D9C
		private void method_11(PiranhaMessage piranhaMessage_0, ServerSocket serverSocket_0)
		{
			if (serverSocket_0 != null)
			{
				if (this.method_1(piranhaMessage_0) && !this.method_12(piranhaMessage_0.GetMessageType()))
				{
					return;
				}
				ServerMessageManager.SendMessage(new ForwardLogicRequestMessage
				{
					SessionId = this.gclass3_0.method_3().Id,
					AccountId = this.gclass3_0.method_3().AccountId,
					MessageType = piranhaMessage_0.GetMessageType(),
					MessageVersion = (short)piranhaMessage_0.GetMessageVersion(),
					MessageLength = piranhaMessage_0.GetEncodingLength(),
					MessageBytes = piranhaMessage_0.GetMessageBytes()
				}, serverSocket_0);
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003C30 File Offset: 0x00001E30
		private bool method_12(short short_0)
		{
			DateTime utcNow = DateTime.UtcNow;
			DateTime value;
			if (this.dictionary_0.TryGetValue(short_0, out value))
			{
				if (utcNow.Subtract(value).TotalMilliseconds < 500.0)
				{
					return false;
				}
				this.dictionary_0[short_0] = utcNow;
			}
			else
			{
				this.dictionary_0.Add(short_0, utcNow);
			}
			return true;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003C90 File Offset: 0x00001E90
		public void method_13(PiranhaMessage piranhaMessage_0)
		{
			GEnum0 genum = this.gclass3_0.method_10();
			if (genum != GEnum0.const_2)
			{
				if (genum == GEnum0.const_4)
				{
					return;
				}
				int messageType = (int)piranhaMessage_0.GetMessageType();
				if (messageType != 20103 && messageType != 20104 && messageType != 20133 && messageType != 20132)
				{
					return;
				}
				if (messageType == 20103)
				{
					this.gclass3_0.method_14(GEnum0.const_3);
				}
			}
			this.gclass3_0.method_1().method_10(piranhaMessage_0);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003D00 File Offset: 0x00001F00
		public bool method_14()
		{
			return DateTime.UtcNow.Subtract(this.dateTime_0).TotalSeconds < 30.0;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003D34 File Offset: 0x00001F34
		private bool method_15(int int_0, int int_1, string string_0, string string_1, int int_2)
		{
			if (int_0 != 9 || int_1 != 256 || (string_0 != null && !ResourceSettings.IsSupportedAppVersion(string_0)))
			{
				LoginFailedMessage loginFailedMessage = new LoginFailedMessage();
				loginFailedMessage.SetErrorCode(LoginFailedMessage.ErrorCode.CLIENT_VERSION);
				loginFailedMessage.SetUpdateUrl(ResourceSettings.GetAppStoreUrl(int_2));
				this.method_13(loginFailedMessage);
				return false;
			}
			if (string_1 != ResourceManager.FINGERPRINT_SHA)
			{
				LoginFailedMessage loginFailedMessage2 = new LoginFailedMessage();
				loginFailedMessage2.SetErrorCode(LoginFailedMessage.ErrorCode.DATA_VERSION);
				loginFailedMessage2.SetContentUrl(ResourceSettings.GetContentUrl());
				loginFailedMessage2.SetContentUrlList(ResourceSettings.ContentUrlList);
				loginFailedMessage2.SetCompressedFingerprint(ResourceManager.COMPRESSED_FINGERPRINT_DATA);
				this.method_13(loginFailedMessage2);
				return false;
			}
			return true;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003DC4 File Offset: 0x00001FC4
		private bool method_16()
		{
			if ((ServerStatus.Status == ServerStatusType.SHUTDOWN_STARTED || ServerStatus.Status == ServerStatusType.MAINTENANCE) && !ResourceSettings.IsDeveloperIP(this.gclass3_0.method_5().ToString()))
			{
				LoginFailedMessage loginFailedMessage = new LoginFailedMessage();
				loginFailedMessage.SetErrorCode(LoginFailedMessage.ErrorCode.SERVER_MAINTENANCE);
				loginFailedMessage.SetEndMaintenanceTime(LogicMath.Max(ServerStatus.Time + ServerStatus.NextTime - TimeUtil.GetTimestamp(), 0));
				this.method_13(loginFailedMessage);
				return false;
			}
			if (GClass2.smethod_0() >= EnvironmentSettings.Settings.Proxy.SessionCapacity)
			{
				LoginFailedMessage loginFailedMessage2 = new LoginFailedMessage();
				loginFailedMessage2.SetErrorCode((LoginFailedMessage.ErrorCode)1000);
				loginFailedMessage2.SetReason("The servers are not able to connect you at this time. Try again in a few minutes.");
				this.method_13(loginFailedMessage2);
				return false;
			}
			return true;
		}

		// Token: 0x04000043 RID: 67
		private readonly GClass3 gclass3_0;

		// Token: 0x04000044 RID: 68
		private DateTime dateTime_0;

		// Token: 0x04000045 RID: 69
		private Dictionary<short, DateTime> dictionary_0;

		// Token: 0x02000014 RID: 20
		[CompilerGenerated]
		private sealed class Class2
		{
			// Token: 0x04000060 RID: 96
			public GClass8 gclass8_0;

			// Token: 0x04000061 RID: 97
			public string string_0;
		}

		// Token: 0x02000015 RID: 21
		[CompilerGenerated]
		private sealed class Class3
		{
			// Token: 0x0600007B RID: 123 RVA: 0x00004F9C File Offset: 0x0000319C
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				if (this.class2_0.gclass8_0.gclass3_0.method_10() != GEnum0.const_2)
				{
					return;
				}
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					AvatarResponseMessage avatarResponseMessage = (AvatarResponseMessage)serverRequestArgs_0.ResponseMessage;
					GoogleServiceAccountAlreadyBoundMessage googleServiceAccountAlreadyBoundMessage = new GoogleServiceAccountAlreadyBoundMessage();
					googleServiceAccountAlreadyBoundMessage.SetAccountId(this.accountDocument_0.Id);
					googleServiceAccountAlreadyBoundMessage.SetPassToken(this.accountDocument_0.PassToken);
					googleServiceAccountAlreadyBoundMessage.SetGoogleServiceId(this.class2_0.string_0);
					googleServiceAccountAlreadyBoundMessage.SetAvatar(avatarResponseMessage.LogicClientAvatar);
					this.class2_0.gclass8_0.method_13(googleServiceAccountAlreadyBoundMessage);
				}
			}

			// Token: 0x04000062 RID: 98
			public AccountDocument accountDocument_0;

			// Token: 0x04000063 RID: 99
			public GClass8.Class2 class2_0;
		}
	}
}
