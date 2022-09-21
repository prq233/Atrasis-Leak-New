using System;
using System.Diagnostics;
using Atrasis.Magic.Logic.Message;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Cluster;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Message.Session.State;
using Atrasis.Magic.Titan.Message;

namespace ns0
{
	// Token: 0x02000010 RID: 16
	public class GClass11 : ClusterInstance
	{
		// Token: 0x06000078 RID: 120 RVA: 0x00002818 File Offset: 0x00000A18
		public GClass11(int int_1, int int_2 = -1) : base(int_1, int_2)
		{
			this.gclass3_0 = new GClass3();
			this.stopwatch_0 = new Stopwatch();
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00004CAC File Offset: 0x00002EAC
		protected override void ReceiveMessage(ServerMessage message)
		{
			this.stopwatch_0.Restart();
			ServerMessageType messageType = message.GetMessageType();
			if (messageType <= ServerMessageType.HOME_SERVER_COMMAND_ALLOWED)
			{
				if (messageType != ServerMessageType.FORWARD_LOGIC_MESSAGE)
				{
					switch (messageType)
					{
					case ServerMessageType.GAME_STATE_DATA:
						this.method_6((GameStateDataMessage)message);
						break;
					case ServerMessageType.GAME_STATE_NULL_DATA:
						this.method_7((GameStateNullDataMessage)message);
						break;
					case ServerMessageType.HOME_SERVER_COMMAND_ALLOWED:
						this.method_5((HomeServerCommandAllowedMessage)message);
						break;
					}
				}
				else
				{
					this.method_4((ForwardLogicMessage)message);
				}
			}
			else if (messageType != ServerMessageType.START_SERVER_SESSION)
			{
				if (messageType != ServerMessageType.STOP_SERVER_SESSION)
				{
					if (messageType == ServerMessageType.UPDATE_SOCKET_SERVER_SESSION)
					{
						this.method_3((UpdateSocketServerSessionMessage)message);
					}
				}
				else
				{
					this.method_2((StopServerSessionMessage)message);
				}
			}
			else
			{
				this.method_1((StartServerSessionMessage)message);
			}
			this.stopwatch_0.Stop();
			this.long_0 += this.stopwatch_0.ElapsedMilliseconds;
			this.int_0++;
			if (this.long_0 > 1000L)
			{
				this.long_0 /= 1000L;
				this.int_0 = 1;
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00004DD0 File Offset: 0x00002FD0
		protected override void OnPingTestCompleted()
		{
			for (int i = 0; i < ServerManager.GetServerCount(0); i++)
			{
				ServerMessageManager.SendMessage(new ClusterPerformanceDataMessage
				{
					Id = this.m_id,
					SessionCount = this.gclass3_0.method_0(),
					Ping = this.m_ping
				}, 0, i);
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00002838 File Offset: 0x00000A38
		public long method_0()
		{
			if (this.int_0 != 0)
			{
				return this.long_0 / (long)this.int_0;
			}
			return 0L;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000285A File Offset: 0x00000A5A
		private void method_1(StartServerSessionMessage startServerSessionMessage_0)
		{
			this.gclass3_0.method_1(startServerSessionMessage_0);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002868 File Offset: 0x00000A68
		private void method_2(StopServerSessionMessage stopServerSessionMessage_0)
		{
			this.gclass3_0.method_2(stopServerSessionMessage_0);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00004E24 File Offset: 0x00003024
		private void method_3(UpdateSocketServerSessionMessage updateSocketServerSessionMessage_0)
		{
			GClass2 gclass;
			if (this.gclass3_0.method_3(updateSocketServerSessionMessage_0.SessionId, out gclass))
			{
				gclass.UpdateSocketServerSessionMessageReceived(updateSocketServerSessionMessage_0);
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00004E50 File Offset: 0x00003050
		private void method_4(ForwardLogicMessage forwardLogicMessage_0)
		{
			GClass2 gclass;
			if (this.gclass3_0.method_3(forwardLogicMessage_0.SessionId, out gclass))
			{
				PiranhaMessage piranhaMessage = LogicMagicMessageFactory.Instance.CreateMessageByType((int)forwardLogicMessage_0.MessageType);
				if (piranhaMessage == null)
				{
					throw new Exception("logicMessage should not be NULL!");
				}
				piranhaMessage.GetByteStream().SetByteArray(forwardLogicMessage_0.MessageBytes, forwardLogicMessage_0.MessageLength);
				piranhaMessage.SetMessageVersion((int)forwardLogicMessage_0.MessageVersion);
				piranhaMessage.Decode();
				if (!piranhaMessage.IsServerToClientMessage())
				{
					gclass.method_0().method_0(piranhaMessage);
				}
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00004ED0 File Offset: 0x000030D0
		private void method_5(HomeServerCommandAllowedMessage homeServerCommandAllowedMessage_0)
		{
			GClass2 gclass;
			if (this.gclass3_0.method_3(homeServerCommandAllowedMessage_0.SessionId, out gclass) && gclass.method_1() != null && gclass.method_1().method_9().GetState() == 1)
			{
				gclass.method_1().method_13(homeServerCommandAllowedMessage_0.ServerCommand);
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00004F20 File Offset: 0x00003120
		private void method_6(GameStateDataMessage gameStateDataMessage_0)
		{
			GClass2 gclass;
			if (this.gclass3_0.method_3(gameStateDataMessage_0.SessionId, out gclass))
			{
				gclass.method_4(false);
				switch (gameStateDataMessage_0.State.GetGameStateType())
				{
				case GameStateType.HOME:
					gclass.method_5(GClass6.smethod_0(gclass, (GameHomeState)gameStateDataMessage_0.State));
					return;
				case GameStateType.NPC_ATTACK:
					gclass.method_5(GClass6.smethod_1(gclass, (GameNpcAttackState)gameStateDataMessage_0.State));
					return;
				case GameStateType.NPC_DUEL:
					gclass.method_5(GClass6.smethod_2(gclass, (GameNpcDuelState)gameStateDataMessage_0.State));
					return;
				case GameStateType.MATCHED_ATTACK:
					gclass.method_5(GClass6.smethod_3(gclass, (GameMatchedAttackState)gameStateDataMessage_0.State));
					return;
				case GameStateType.VISIT:
					gclass.method_5(GClass6.smethod_4(gclass, (GameVisitState)gameStateDataMessage_0.State));
					return;
				}
				Logging.Error("GameModeCluster.onLoadGameStateDataMessageReceived: unknown game state: " + gameStateDataMessage_0.State.GetGameStateType());
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000501C File Offset: 0x0000321C
		private void method_7(GameStateNullDataMessage gameStateNullDataMessage_0)
		{
			GClass2 gclass;
			if (this.gclass3_0.method_3(gameStateNullDataMessage_0.SessionId, out gclass))
			{
				gclass.method_6();
			}
		}

		// Token: 0x04000029 RID: 41
		private readonly GClass3 gclass3_0;

		// Token: 0x0400002A RID: 42
		private readonly Stopwatch stopwatch_0;

		// Token: 0x0400002B RID: 43
		private long long_0;

		// Token: 0x0400002C RID: 44
		private int int_0;
	}
}
