using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar;
using Atrasis.Magic.Logic.Message.Home;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Message.Session.State;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Servers.Core.Session;

namespace ns0
{
	// Token: 0x02000004 RID: 4
	public class GClass1 : ServerSession
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000020A3 File Offset: 0x000002A3
		[CompilerGenerated]
		public GClass3 method_0()
		{
			return this.gclass3_0;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020AB File Offset: 0x000002AB
		[CompilerGenerated]
		public GClass5 method_1()
		{
			return this.gclass5_0;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020B3 File Offset: 0x000002B3
		[CompilerGenerated]
		public GameState method_2()
		{
			return this.gameState_0;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020BB File Offset: 0x000002BB
		[CompilerGenerated]
		private void method_3(GameState gameState_1)
		{
			this.gameState_0 = gameState_1;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020C4 File Offset: 0x000002C4
		[CompilerGenerated]
		public DateTime method_4()
		{
			return this.dateTime_0;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000020CC File Offset: 0x000002CC
		[CompilerGenerated]
		public void method_5(DateTime dateTime_1)
		{
			this.dateTime_0 = dateTime_1;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000020D5 File Offset: 0x000002D5
		[CompilerGenerated]
		public bool method_6()
		{
			return this.bool_0;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000020DD File Offset: 0x000002DD
		[CompilerGenerated]
		public void method_7(bool bool_2)
		{
			this.bool_0 = bool_2;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000020E6 File Offset: 0x000002E6
		[CompilerGenerated]
		public bool method_8()
		{
			return this.bool_1;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000020EE File Offset: 0x000002EE
		[CompilerGenerated]
		public void method_9(bool bool_2)
		{
			this.bool_1 = bool_2;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000020F7 File Offset: 0x000002F7
		[CompilerGenerated]
		public long method_10()
		{
			return this.long_0;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000020FF File Offset: 0x000002FF
		[CompilerGenerated]
		public void method_11(long long_1)
		{
			this.long_0 = long_1;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002108 File Offset: 0x00000308
		[CompilerGenerated]
		public int method_12()
		{
			return this.int_0;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002110 File Offset: 0x00000310
		[CompilerGenerated]
		public void method_13(int int_1)
		{
			this.int_0 = int_1;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002119 File Offset: 0x00000319
		[CompilerGenerated]
		public GameFakeAttackState method_14()
		{
			return this.gameFakeAttackState_0;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002121 File Offset: 0x00000321
		[CompilerGenerated]
		public void method_15(GameFakeAttackState gameFakeAttackState_1)
		{
			this.gameFakeAttackState_0 = gameFakeAttackState_1;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002C88 File Offset: 0x00000E88
		public GClass1(StartServerSessionMessage startServerSessionMessage_0) : base(startServerSessionMessage_0)
		{
			this.gclass3_0 = new GClass3(this);
			GClass5 gclass;
			this.gclass5_0 = (GClass7.smethod_4(base.AccountId, out gclass) ? gclass : GClass7.smethod_6(base.AccountId));
			if (this.method_1().method_0() != null)
			{
				GClass2.smethod_5(this.method_1().method_0().Id);
			}
			this.method_1().method_1(this);
			GClass7.smethod_9(this.method_1());
			ServerRequestManager.Create(new BindServerSocketRequestMessage
			{
				SessionId = base.Id,
				ServerType = 10,
				ServerId = -1
			}, this.m_sockets[1], 10).OnComplete = new ServerRequestArgs.CompleteHandler(this.method_16);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002D54 File Offset: 0x00000F54
		private void method_16(ServerRequestArgs serverRequestArgs_0)
		{
			if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
			{
				BindServerSocketResponseMessage bindServerSocketResponseMessage = (BindServerSocketResponseMessage)serverRequestArgs_0.ResponseMessage;
				this.m_sockets[bindServerSocketResponseMessage.ServerType] = ServerManager.GetSocket(bindServerSocketResponseMessage.ServerType, bindServerSocketResponseMessage.ServerId);
				if (this.method_1().LogicClientAvatar.IsInAlliance())
				{
					this.method_18();
				}
				this.method_19();
				this.method_20();
				this.method_21();
				if (this.method_1().method_2() != null)
				{
					if (!this.method_1().method_2().method_3())
					{
						this.method_17();
						return;
					}
					this.method_1().method_3(null);
				}
				if (this.method_1().method_4() != null && this.method_1().method_4().method_15())
				{
					this.method_1().method_4().method_6();
				}
				this.method_23();
				return;
			}
			base.SendMessage(new StopSessionMessage(), 1);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002E44 File Offset: 0x00001044
		public void method_17()
		{
			WaitingToGoHomeMessage waitingToGoHomeMessage = new WaitingToGoHomeMessage();
			waitingToGoHomeMessage.SetEstimatedTimeSeconds(300);
			base.SendPiranhaMessage(waitingToGoHomeMessage, 1);
			this.method_11(this.method_1().method_2().method_1());
			this.method_13(1);
			ServerRequestManager.Create(new LiveReplayAddSpectatorRequestMessage
			{
				LiveReplayId = this.method_10(),
				SlotId = this.method_12(),
				SessionId = base.Id
			}, ServerManager.GetDocumentSocket(9, this.method_10()), 30).OnComplete = new ServerRequestArgs.CompleteHandler(this.method_25);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000212A File Offset: 0x0000032A
		public override void Destruct()
		{
			GClass7.smethod_8(this.method_1());
			this.method_1().method_1(null);
			this.method_1().method_7(DateTime.UtcNow);
			this.method_22();
			base.Destruct();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002EE4 File Offset: 0x000010E4
		public void method_18()
		{
			ServerSocket documentSocket = ServerManager.GetDocumentSocket(11, this.method_1().LogicClientAvatar.GetAllianceId());
			if (documentSocket != null)
			{
				ServerRequestManager.Create(new BindServerSocketRequestMessage
				{
					ServerType = documentSocket.ServerType,
					ServerId = documentSocket.ServerId,
					SessionId = base.Id
				}, this.m_sockets[1], 30);
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002F48 File Offset: 0x00001148
		private void method_19()
		{
			BookmarksListMessage bookmarksListMessage = new BookmarksListMessage();
			bookmarksListMessage.SetAllianceIds(this.method_1().AllianceBookmarksList);
			base.SendPiranhaMessage(bookmarksListMessage, 1);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000215F File Offset: 0x0000035F
		private void method_20()
		{
			ServerMessageManager.SendMessage(new SendAvatarStreamsToClientMessage
			{
				StreamIds = this.method_1().AvatarStreamList,
				SessionId = base.Id
			}, ServerManager.GetDocumentSocket(11, this.method_1().Id));
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000219A File Offset: 0x0000039A
		private void method_21()
		{
			ServerMessageManager.SendMessage(new SendVillage2AttackEntryListToClientMessage
			{
				EntryIds = this.method_1().Village2AttackList,
				SessionId = base.Id
			}, ServerManager.GetDocumentSocket(11, this.method_1().Id));
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002F74 File Offset: 0x00001174
		public void method_22()
		{
			if (this.method_2() != null)
			{
				if (this.method_2().GetSimulationServiceNodeType() == SimulationServiceNodeType.BATTLE)
				{
					base.SendMessage(new StopSpecifiedServerSessionMessage
					{
						ServerType = 27,
						ServerId = this.m_sockets[27].ServerId
					}, 1);
				}
				else
				{
					base.SendMessage(new GameStateNullDataMessage(), 10);
				}
				this.method_3(null);
			}
			if (this.method_6())
			{
				GClass10.smethod_6(this);
			}
			if (this.method_8())
			{
				GClass9.smethod_4(this);
			}
			if (this.method_10() != -1L)
			{
				ServerMessageManager.SendMessage(new LiveReplayRemoveSpectatorMessage
				{
					AccountId = this.method_10(),
					SlotId = this.method_12(),
					SessionId = base.Id
				}, 9);
				this.method_11(-1L);
				this.method_13(0);
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003050 File Offset: 0x00001250
		public void method_23()
		{
			this.method_1().UpdateProtection();
			this.method_24(new GameHomeState
			{
				HomeId = this.method_1().Id,
				HomeData = this.method_1().HomeData,
				PlayerAvatar = this.method_1().LogicClientAvatar,
				SaveTime = this.method_1().SaveTime,
				RemainingShieldTimeSeconds = this.method_1().RemainingShieldTimeSeconds,
				RemainingGuardTimeSeconds = this.method_1().RemainingGuardTimeSeconds,
				MaintenanceTime = this.method_1().MaintenanceTime,
				ServerCommands = this.method_1().ServerCommands
			});
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000030FC File Offset: 0x000012FC
		public void method_24(GameState gameState_1)
		{
			GClass1.Class1 @class = new GClass1.Class1();
			@class.gameState_0 = gameState_1;
			@class.gclass1_0 = this;
			if (this.method_2() != null)
			{
				throw new Exception("GameSession.loadGameState: current game state should be NULL");
			}
			this.method_3(@class.gameState_0);
			if (@class.gameState_0.GetSimulationServiceNodeType() == SimulationServiceNodeType.BATTLE)
			{
				ServerRequestManager.Create(new BindServerSocketRequestMessage
				{
					SessionId = base.Id,
					ServerType = 27,
					ServerId = -1,
					InitSessionMessage = new GameStateDataMessage
					{
						State = @class.gameState_0
					}
				}, this.m_sockets[1], 10).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
				return;
			}
			base.SendMessage(new GameStateDataMessage
			{
				State = @class.gameState_0
			}, 10);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000021D5 File Offset: 0x000003D5
		[CompilerGenerated]
		private void method_25(ServerRequestArgs serverRequestArgs_0)
		{
			if (serverRequestArgs_0.ErrorCode != ServerRequestError.Success || !serverRequestArgs_0.ResponseMessage.Success)
			{
				this.method_11(-1L);
				this.method_13(0);
			}
		}

		// Token: 0x04000002 RID: 2
		[CompilerGenerated]
		private readonly GClass3 gclass3_0;

		// Token: 0x04000003 RID: 3
		[CompilerGenerated]
		private readonly GClass5 gclass5_0;

		// Token: 0x04000004 RID: 4
		[CompilerGenerated]
		private GameState gameState_0;

		// Token: 0x04000005 RID: 5
		[CompilerGenerated]
		private DateTime dateTime_0;

		// Token: 0x04000006 RID: 6
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000007 RID: 7
		[CompilerGenerated]
		private bool bool_1;

		// Token: 0x04000008 RID: 8
		[CompilerGenerated]
		private long long_0 = -1L;

		// Token: 0x04000009 RID: 9
		[CompilerGenerated]
		private int int_0;

		// Token: 0x0400000A RID: 10
		[CompilerGenerated]
		private GameFakeAttackState gameFakeAttackState_0;

		// Token: 0x02000005 RID: 5
		[CompilerGenerated]
		private sealed class Class1
		{
			// Token: 0x06000023 RID: 35 RVA: 0x000031BC File Offset: 0x000013BC
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				GClass17 gclass;
				if ((serverRequestArgs_0.ErrorCode != ServerRequestError.Success || !serverRequestArgs_0.ResponseMessage.Success) && this.gameState_0.GetGameStateType() == GameStateType.DUEL && GClass19.smethod_3(((GameDuelState)this.gameState_0).AvatarId, out gclass))
				{
					gclass.method_3(this.gclass1_0.method_1());
				}
			}

			// Token: 0x0400000B RID: 11
			public GameState gameState_0;

			// Token: 0x0400000C RID: 12
			public GClass1 gclass1_0;
		}
	}
}
