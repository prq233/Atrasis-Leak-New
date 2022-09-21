using System;
using Atrasis.Magic.Logic.Message;
using Atrasis.Magic.Logic.Message.Scoring;
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
		// Token: 0x0600000A RID: 10 RVA: 0x000020C1 File Offset: 0x000002C1
		public override void OnReceiveAccountMessage(ServerAccountMessage message)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000020C8 File Offset: 0x000002C8
		public override void OnReceiveRequestMessage(ServerRequestMessage message)
		{
			if (message.GetMessageType() == ServerMessageType.LEADERBOARD_REQUEST)
			{
				GClass1.smethod_0((LeaderboardRequestMessage)message);
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000022BC File Offset: 0x000004BC
		private static void smethod_0(LeaderboardRequestMessage leaderboardRequestMessage_0)
		{
			LogicArrayList<AvatarRankingEntry> logicArrayList = new LogicArrayList<AvatarRankingEntry>(leaderboardRequestMessage_0.Count);
			LogicArrayList<AvatarDuelRankingEntry> logicArrayList2 = new LogicArrayList<AvatarDuelRankingEntry>(leaderboardRequestMessage_0.Count);
			LogicArrayList<AvatarRankingEntry> logicArrayList3 = GClass2.smethod_13(null);
			LogicArrayList<AvatarDuelRankingEntry> logicArrayList4 = GClass2.smethod_15(null);
			int i = 0;
			int num = LogicMath.Min(logicArrayList3.Size(), leaderboardRequestMessage_0.Count);
			while (i < num)
			{
				logicArrayList.Add(logicArrayList3[i]);
				i++;
			}
			int j = 0;
			int num2 = LogicMath.Min(logicArrayList4.Size(), leaderboardRequestMessage_0.Count);
			while (j < num2)
			{
				logicArrayList2.Add(logicArrayList4[j]);
				j++;
			}
			ServerRequestManager.SendResponse(new LeaderboardResponseMessage
			{
				Success = true,
				MainLeaderboard = logicArrayList,
				SecondaryLeaderboard = logicArrayList2
			}, leaderboardRequestMessage_0);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000020E2 File Offset: 0x000002E2
		public override void OnReceiveSessionMessage(ServerSessionMessage message)
		{
			if (message.GetMessageType() == ServerMessageType.FORWARD_LOGIC_REQUEST_MESSAGE)
			{
				GClass1.smethod_1((ForwardLogicRequestMessage)message);
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002374 File Offset: 0x00000574
		private static void smethod_1(ForwardLogicRequestMessage forwardLogicRequestMessage_0)
		{
			PiranhaMessage piranhaMessage = LogicMagicMessageFactory.Instance.CreateMessageByType((int)forwardLogicRequestMessage_0.MessageType);
			if (piranhaMessage == null)
			{
				throw new Exception("logicMessage should not be NULL!");
			}
			piranhaMessage.GetByteStream().SetByteArray(forwardLogicRequestMessage_0.MessageBytes, forwardLogicRequestMessage_0.MessageLength);
			piranhaMessage.SetMessageVersion((int)forwardLogicRequestMessage_0.MessageVersion);
			piranhaMessage.Decode();
			if (!piranhaMessage.IsServerToClientMessage())
			{
				switch (piranhaMessage.GetMessageType())
				{
				case 14401:
					GClass1.smethod_2((AskForAllianceRankingListMessage)piranhaMessage, forwardLogicRequestMessage_0);
					return;
				case 14402:
				case 14405:
				case 14407:
					break;
				case 14403:
					GClass1.smethod_3((AskForAvatarRankingListMessage)piranhaMessage, forwardLogicRequestMessage_0);
					return;
				case 14404:
					GClass1.smethod_4((AskForAvatarLocalRankingListMessage)piranhaMessage, forwardLogicRequestMessage_0);
					return;
				case 14406:
					GClass1.smethod_5((AskForAvatarLastSeasonRankingListMessage)piranhaMessage, forwardLogicRequestMessage_0);
					return;
				case 14408:
					GClass1.smethod_6((AskForAvatarDuelLastSeasonRankingListMessage)piranhaMessage, forwardLogicRequestMessage_0);
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002448 File Offset: 0x00000648
		private static void smethod_2(AskForAllianceRankingListMessage askForAllianceRankingListMessage_0, ServerSessionMessage serverSessionMessage_0)
		{
			if (askForAllianceRankingListMessage_0.GetLocalRanking())
			{
				AllianceLocalRankingListMessage allianceLocalRankingListMessage = new AllianceLocalRankingListMessage();
				allianceLocalRankingListMessage.SetAllianceRankingList(new LogicArrayList<AllianceRankingEntry>(0));
				allianceLocalRankingListMessage.SetVillageType(askForAllianceRankingListMessage_0.GetVillageType());
				ServerMessageManager.SendMessage(GClass1.smethod_7(allianceLocalRankingListMessage, serverSessionMessage_0.SessionId), ServerManager.GetProxySocket(serverSessionMessage_0.SessionId));
				return;
			}
			AllianceRankingListMessage allianceRankingListMessage = new AllianceRankingListMessage();
			allianceRankingListMessage.SetAllianceRankingList(GClass2.smethod_11(askForAllianceRankingListMessage_0.GetVillageType(), askForAllianceRankingListMessage_0.RemoveAllianceId()));
			allianceRankingListMessage.SetDiamondPrizes(GClass2.smethod_5());
			allianceRankingListMessage.SetNextEndTimeSeconds(GClass2.smethod_6());
			allianceRankingListMessage.SetVillageType(askForAllianceRankingListMessage_0.GetVillageType());
			ServerMessageManager.SendMessage(GClass1.smethod_7(allianceRankingListMessage, serverSessionMessage_0.SessionId), ServerManager.GetProxySocket(serverSessionMessage_0.SessionId));
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000024F0 File Offset: 0x000006F0
		private static void smethod_3(AskForAvatarRankingListMessage askForAvatarRankingListMessage_0, ServerSessionMessage serverSessionMessage_0)
		{
			if (askForAvatarRankingListMessage_0.GetVillageType() == 1)
			{
				AvatarDuelRankingListMessage avatarDuelRankingListMessage = new AvatarDuelRankingListMessage();
				LogicLong logicLong_ = askForAvatarRankingListMessage_0.RemoveAvatarId();
				avatarDuelRankingListMessage.SetAvatarRankingList(GClass2.smethod_15(logicLong_));
				avatarDuelRankingListMessage.SetNextEndTimeSeconds(GClass2.smethod_6());
				avatarDuelRankingListMessage.SetSeasonMonth(GClass2.smethod_8());
				avatarDuelRankingListMessage.SetSeasonYear(GClass2.smethod_7());
				avatarDuelRankingListMessage.SetLastSeasonAvatarRankingList(GClass2.smethod_16(logicLong_));
				avatarDuelRankingListMessage.SetLastSeasonMonth(GClass2.smethod_10());
				avatarDuelRankingListMessage.SetLastSeasonYear(GClass2.smethod_9());
				ServerMessageManager.SendMessage(GClass1.smethod_7(avatarDuelRankingListMessage, serverSessionMessage_0.SessionId), ServerManager.GetProxySocket(serverSessionMessage_0.SessionId));
				return;
			}
			AvatarRankingListMessage avatarRankingListMessage = new AvatarRankingListMessage();
			LogicLong logicLong_2 = askForAvatarRankingListMessage_0.RemoveAvatarId();
			avatarRankingListMessage.SetAvatarRankingList(GClass2.smethod_13(logicLong_2));
			avatarRankingListMessage.SetNextEndTimeSeconds(GClass2.smethod_6());
			avatarRankingListMessage.SetSeasonMonth(GClass2.smethod_8());
			avatarRankingListMessage.SetSeasonYear(GClass2.smethod_7());
			avatarRankingListMessage.SetLastSeasonAvatarRankingList(GClass2.smethod_14(logicLong_2));
			avatarRankingListMessage.SetLastSeasonMonth(GClass2.smethod_10());
			avatarRankingListMessage.SetLastSeasonYear(GClass2.smethod_9());
			ServerMessageManager.SendMessage(GClass1.smethod_7(avatarRankingListMessage, serverSessionMessage_0.SessionId), ServerManager.GetProxySocket(serverSessionMessage_0.SessionId));
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000020FC File Offset: 0x000002FC
		private static void smethod_4(AskForAvatarLocalRankingListMessage askForAvatarLocalRankingListMessage_0, ServerSessionMessage serverSessionMessage_0)
		{
			AvatarLocalRankingListMessage avatarLocalRankingListMessage = new AvatarLocalRankingListMessage();
			avatarLocalRankingListMessage.SetAvatarRankingList(new LogicArrayList<AvatarRankingEntry>(0));
			ServerMessageManager.SendMessage(GClass1.smethod_7(avatarLocalRankingListMessage, serverSessionMessage_0.SessionId), ServerManager.GetProxySocket(serverSessionMessage_0.SessionId));
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000025F4 File Offset: 0x000007F4
		private static void smethod_5(AskForAvatarLastSeasonRankingListMessage askForAvatarLastSeasonRankingListMessage_0, ServerSessionMessage serverSessionMessage_0)
		{
			AvatarLastSeasonRankingListMessage avatarLastSeasonRankingListMessage = new AvatarLastSeasonRankingListMessage();
			avatarLastSeasonRankingListMessage.SetAvatarRankingList(GClass2.smethod_14(askForAvatarLastSeasonRankingListMessage_0.RemoveAvatarId()));
			avatarLastSeasonRankingListMessage.SetSeasonYear(GClass2.smethod_9());
			avatarLastSeasonRankingListMessage.SetSeasonMonth(GClass2.smethod_10());
			ServerMessageManager.SendMessage(GClass1.smethod_7(avatarLastSeasonRankingListMessage, serverSessionMessage_0.SessionId), ServerManager.GetProxySocket(serverSessionMessage_0.SessionId));
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002648 File Offset: 0x00000848
		private static void smethod_6(AskForAvatarDuelLastSeasonRankingListMessage askForAvatarDuelLastSeasonRankingListMessage_0, ServerSessionMessage serverSessionMessage_0)
		{
			AvatarDuelLastSeasonRankingListMessage avatarDuelLastSeasonRankingListMessage = new AvatarDuelLastSeasonRankingListMessage();
			avatarDuelLastSeasonRankingListMessage.SetAvatarRankingList(GClass2.smethod_16(askForAvatarDuelLastSeasonRankingListMessage_0.RemoveAvatarId()));
			avatarDuelLastSeasonRankingListMessage.SetSeasonYear(GClass2.smethod_9());
			avatarDuelLastSeasonRankingListMessage.SetSeasonMonth(GClass2.smethod_10());
			ServerMessageManager.SendMessage(GClass1.smethod_7(avatarDuelLastSeasonRankingListMessage, serverSessionMessage_0.SessionId), ServerManager.GetProxySocket(serverSessionMessage_0.SessionId));
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000269C File Offset: 0x0000089C
		private static ForwardLogicMessage smethod_7(PiranhaMessage piranhaMessage_0, long long_0)
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

		// Token: 0x06000015 RID: 21 RVA: 0x000026F4 File Offset: 0x000008F4
		public override void OnReceiveCoreMessage(ServerCoreMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType != ServerMessageType.SCORING_SYNC)
			{
				if (messageType == ServerMessageType.SERVER_PERFORMANCE)
				{
					ServerMessageManager.SendMessage(new ServerPerformanceDataMessage(), message.Sender);
					return;
				}
			}
			else
			{
				GClass2.smethod_4((ScoringSyncMessage)message);
			}
		}
	}
}
