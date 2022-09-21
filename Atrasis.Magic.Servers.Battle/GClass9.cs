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
	// Token: 0x0200000F RID: 15
	public class GClass9 : ClusterInstance
	{
		// Token: 0x06000052 RID: 82 RVA: 0x0000266C File Offset: 0x0000086C
		public GClass9(int int_1, int int_2 = -1) : base(int_1, int_2)
		{
			this.gclass3_0 = new GClass3();
			this.stopwatch_0 = new Stopwatch();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000038AC File Offset: 0x00001AAC
		protected override void ReceiveMessage(ServerMessage message)
		{
			this.stopwatch_0.Restart();
			ServerMessageType messageType = message.GetMessageType();
			if (messageType <= ServerMessageType.GAME_STATE_NULL_DATA)
			{
				if (messageType != ServerMessageType.FORWARD_LOGIC_MESSAGE)
				{
					if (messageType != ServerMessageType.GAME_STATE_DATA)
					{
						if (messageType == ServerMessageType.GAME_STATE_NULL_DATA)
						{
							this.method_6((GameStateNullDataMessage)message);
						}
					}
					else
					{
						this.method_5((GameStateDataMessage)message);
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

		// Token: 0x06000054 RID: 84 RVA: 0x000039B8 File Offset: 0x00001BB8
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

		// Token: 0x06000055 RID: 85 RVA: 0x0000268C File Offset: 0x0000088C
		public long method_0()
		{
			if (this.int_0 != 0)
			{
				return this.long_0 / (long)this.int_0;
			}
			return 0L;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000026AE File Offset: 0x000008AE
		private void method_1(StartServerSessionMessage startServerSessionMessage_0)
		{
			this.gclass3_0.method_1(startServerSessionMessage_0);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000026BC File Offset: 0x000008BC
		private void method_2(StopServerSessionMessage stopServerSessionMessage_0)
		{
			this.gclass3_0.method_2(stopServerSessionMessage_0);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003A0C File Offset: 0x00001C0C
		private void method_3(UpdateSocketServerSessionMessage updateSocketServerSessionMessage_0)
		{
			GClass2 gclass;
			if (this.gclass3_0.method_3(updateSocketServerSessionMessage_0.SessionId, out gclass))
			{
				gclass.UpdateSocketServerSessionMessageReceived(updateSocketServerSessionMessage_0);
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003A38 File Offset: 0x00001C38
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

		// Token: 0x0600005A RID: 90 RVA: 0x00003AB8 File Offset: 0x00001CB8
		private void method_5(GameStateDataMessage gameStateDataMessage_0)
		{
			GClass2 gclass;
			if (this.gclass3_0.method_3(gameStateDataMessage_0.SessionId, out gclass))
			{
				switch (gameStateDataMessage_0.State.GetGameStateType())
				{
				case GameStateType.CHALLENGE_ATTACK:
					gclass.method_3(GClass6.smethod_1(gclass, (GameChallengeAttackState)gameStateDataMessage_0.State));
					return;
				case GameStateType.FAKE_ATTACK:
					gclass.method_3(GClass6.smethod_0(gclass, (GameFakeAttackState)gameStateDataMessage_0.State));
					return;
				case GameStateType.DUEL:
					gclass.method_3(GClass6.smethod_2(gclass, (GameDuelState)gameStateDataMessage_0.State));
					return;
				default:
					Logging.Error("GameModeCluster.onLoadGameStateDataMessageReceived: unknown game state: " + gameStateDataMessage_0.State.GetGameStateType());
					break;
				}
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003B68 File Offset: 0x00001D68
		private void method_6(GameStateNullDataMessage gameStateNullDataMessage_0)
		{
			GClass2 gclass;
			if (this.gclass3_0.method_3(gameStateNullDataMessage_0.SessionId, out gclass))
			{
				gclass.method_4();
			}
		}

		// Token: 0x04000023 RID: 35
		private readonly GClass3 gclass3_0;

		// Token: 0x04000024 RID: 36
		private readonly Stopwatch stopwatch_0;

		// Token: 0x04000025 RID: 37
		private long long_0;

		// Token: 0x04000026 RID: 38
		private int int_0;
	}
}
