using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Logic.Message.Home;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Request.Stream;
using Atrasis.Magic.Servers.Core.Network.Message.Session.State;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace ns0
{
	// Token: 0x02000007 RID: 7
	public class GClass4
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00002193 File Offset: 0x00000393
		public GClass4(GClass2 gclass2_1)
		{
			this.gclass2_0 = gclass2_1;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000029D4 File Offset: 0x00000BD4
		public void method_0(PiranhaMessage piranhaMessage_0)
		{
			short messageType = piranhaMessage_0.GetMessageType();
			if (messageType <= 14134)
			{
				if (messageType <= 14102)
				{
					if (messageType == 14101)
					{
						this.method_1((GoHomeMessage)piranhaMessage_0);
						return;
					}
					if (messageType != 14102)
					{
						return;
					}
					this.method_2((EndClientTurnMessage)piranhaMessage_0);
					return;
				}
				else
				{
					if (messageType == 14113)
					{
						this.method_3((VisitHomeMessage)piranhaMessage_0);
						return;
					}
					if (messageType != 14134)
					{
						return;
					}
					this.method_4((AttackNpcMessage)piranhaMessage_0);
					return;
				}
			}
			else if (messageType <= 14301)
			{
				if (messageType == 14135)
				{
					this.method_5((DuelNpcMessage)piranhaMessage_0);
					return;
				}
				if (messageType != 14301)
				{
					return;
				}
				this.method_6((CreateAllianceMessage)piranhaMessage_0);
				return;
			}
			else
			{
				if (messageType == 14305)
				{
					this.method_8((JoinAllianceMessage)piranhaMessage_0);
					return;
				}
				if (messageType == 14317)
				{
					this.method_10((RequestJoinAllianceMessage)piranhaMessage_0);
					return;
				}
				if (messageType != 14323)
				{
					return;
				}
				this.method_11((JoinAllianceUsingInvitationMessage)piranhaMessage_0);
				return;
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002AC0 File Offset: 0x00000CC0
		private void method_1(GoHomeMessage goHomeMessage_0)
		{
			if (this.gclass2_0.method_3())
			{
				return;
			}
			this.gclass2_0.method_4(true);
			this.gclass2_0.method_6();
			this.gclass2_0.SendMessage(new ChangeGameStateMessage
			{
				StateType = GameStateType.HOME,
				LayoutId = goHomeMessage_0.GetLayoutId(),
				MapId = goHomeMessage_0.GetMapId()
			}, 9);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002B24 File Offset: 0x00000D24
		private void method_2(EndClientTurnMessage endClientTurnMessage_0)
		{
			GClass6 gclass = this.gclass2_0.method_1();
			if (gclass != null)
			{
				gclass.method_1(endClientTurnMessage_0.GetSubTick(), endClientTurnMessage_0.GetChecksum(), endClientTurnMessage_0.GetCommands());
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000021A2 File Offset: 0x000003A2
		private void method_3(VisitHomeMessage visitHomeMessage_0)
		{
			this.gclass2_0.SendMessage(new ChangeGameStateMessage
			{
				StateType = GameStateType.VISIT,
				HomeId = visitHomeMessage_0.RemoveHomeId(),
				VisitType = visitHomeMessage_0.GetVisitType()
			}, 9);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002B58 File Offset: 0x00000D58
		private void method_4(AttackNpcMessage attackNpcMessage_0)
		{
			LogicNpcData npcData = attackNpcMessage_0.GetNpcData();
			GClass6 gclass = this.gclass2_0.method_1();
			if (gclass == null)
			{
				return;
			}
			if (npcData == null || !npcData.IsUnlockedInMap(gclass.method_10()) || !npcData.IsSinglePlayer())
			{
				return;
			}
			if (this.gclass2_0.method_3())
			{
				return;
			}
			this.gclass2_0.method_4(true);
			this.gclass2_0.method_6();
			this.gclass2_0.SendMessage(new ChangeGameStateMessage
			{
				StateType = GameStateType.NPC_ATTACK,
				NpcData = npcData
			}, 9);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002BDC File Offset: 0x00000DDC
		private void method_5(DuelNpcMessage duelNpcMessage_0)
		{
			LogicNpcData npcData = duelNpcMessage_0.GetNpcData();
			GClass6 gclass = this.gclass2_0.method_1();
			if (gclass == null)
			{
				return;
			}
			if (npcData == null || !npcData.IsUnlockedInMap(gclass.method_10()) || npcData.IsSinglePlayer())
			{
				return;
			}
			if (this.gclass2_0.method_3())
			{
				return;
			}
			this.gclass2_0.method_4(true);
			this.gclass2_0.method_6();
			this.gclass2_0.SendMessage(new ChangeGameStateMessage
			{
				StateType = GameStateType.NPC_DUEL,
				NpcData = npcData
			}, 9);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002C60 File Offset: 0x00000E60
		private void method_6(CreateAllianceMessage createAllianceMessage_0)
		{
			if (!this.method_13())
			{
				AllianceCreateFailedMessage allianceCreateFailedMessage = new AllianceCreateFailedMessage();
				allianceCreateFailedMessage.SetReason(AllianceCreateFailedMessage.Reason.GENERIC);
				this.gclass2_0.SendPiranhaMessage(allianceCreateFailedMessage, 1);
				return;
			}
			if (this.gclass2_0.method_1().method_10().GetResourceCount(LogicDataTables.GetGlobals().GetAllianceCreateResourceData()) < LogicDataTables.GetGlobals().GetAllianceCreateCost())
			{
				AllianceCreateFailedMessage allianceCreateFailedMessage2 = new AllianceCreateFailedMessage();
				allianceCreateFailedMessage2.SetReason(AllianceCreateFailedMessage.Reason.GENERIC);
				this.gclass2_0.SendPiranhaMessage(allianceCreateFailedMessage2, 1);
				return;
			}
			ServerSocket nextSocket = ServerManager.GetNextSocket(11);
			if (nextSocket != null)
			{
				ServerRequestManager.Create(new CreateAllianceRequestMessage
				{
					AllianceName = createAllianceMessage_0.GetAllianceName(),
					AllianceDescription = createAllianceMessage_0.GetAllianceDescription(),
					AllianceType = (AllianceType)createAllianceMessage_0.GetAllianceType(),
					AllianceBadgeId = createAllianceMessage_0.GetAllianceBadgeId(),
					RequiredScore = createAllianceMessage_0.GetRequiredScore(),
					RequiredDuelScore = createAllianceMessage_0.GetRequiredDuelScore(),
					WarFrequency = createAllianceMessage_0.GetWarFrequency(),
					PublicWarLog = createAllianceMessage_0.GetPublicWarLog(),
					ArrangedWarEnabled = createAllianceMessage_0.GetArrangedWarEnabled()
				}, nextSocket, 30).OnComplete = new ServerRequestArgs.CompleteHandler(this.method_7);
				return;
			}
			AllianceCreateFailedMessage allianceCreateFailedMessage3 = new AllianceCreateFailedMessage();
			allianceCreateFailedMessage3.SetReason(AllianceCreateFailedMessage.Reason.GENERIC);
			this.gclass2_0.SendPiranhaMessage(allianceCreateFailedMessage3, 1);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002D8C File Offset: 0x00000F8C
		private void method_7(ServerRequestArgs serverRequestArgs_0)
		{
			if (serverRequestArgs_0.ErrorCode != ServerRequestError.Success)
			{
				AllianceCreateFailedMessage allianceCreateFailedMessage = new AllianceCreateFailedMessage();
				allianceCreateFailedMessage.SetReason(AllianceCreateFailedMessage.Reason.GENERIC);
				this.gclass2_0.SendPiranhaMessage(allianceCreateFailedMessage, 1);
				return;
			}
			CreateAllianceResponseMessage createAllianceResponseMessage = (CreateAllianceResponseMessage)serverRequestArgs_0.ResponseMessage;
			if (createAllianceResponseMessage.Success)
			{
				LogicLong id = this.gclass2_0.method_1().method_10().GetId();
				ServerRequestManager.Create(new GameJoinAllianceRequestMessage
				{
					AccountId = id,
					AllianceId = createAllianceResponseMessage.AllianceId,
					Created = true
				}, ServerManager.GetDocumentSocket(9, id), 30).OnComplete = new ServerRequestArgs.CompleteHandler(this.method_9);
				return;
			}
			AllianceCreateFailedMessage allianceCreateFailedMessage2 = new AllianceCreateFailedMessage();
			switch (createAllianceResponseMessage.ErrorReason)
			{
			case CreateAllianceResponseMessage.Reason.GENERIC:
				allianceCreateFailedMessage2.SetReason(AllianceCreateFailedMessage.Reason.GENERIC);
				break;
			case CreateAllianceResponseMessage.Reason.INVALID_NAME:
				allianceCreateFailedMessage2.SetReason(AllianceCreateFailedMessage.Reason.INVALID_NAME);
				break;
			case CreateAllianceResponseMessage.Reason.INVALID_DESCRIPTION:
				allianceCreateFailedMessage2.SetReason(AllianceCreateFailedMessage.Reason.INVALID_DESCRIPTION);
				break;
			case CreateAllianceResponseMessage.Reason.NAME_TOO_SHORT:
				allianceCreateFailedMessage2.SetReason(AllianceCreateFailedMessage.Reason.NAME_TOO_SHORT);
				break;
			case CreateAllianceResponseMessage.Reason.NAME_TOO_LONG:
				allianceCreateFailedMessage2.SetReason(AllianceCreateFailedMessage.Reason.NAME_TOO_LONG);
				break;
			}
			this.gclass2_0.SendPiranhaMessage(allianceCreateFailedMessage2, 1);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002E90 File Offset: 0x00001090
		private void method_8(JoinAllianceMessage joinAllianceMessage_0)
		{
			if (!this.method_13())
			{
				AllianceJoinFailedMessage allianceJoinFailedMessage = new AllianceJoinFailedMessage();
				allianceJoinFailedMessage.SetReason(AllianceJoinFailedMessage.Reason.ALREADY_IN_ALLIANCE);
				this.gclass2_0.SendPiranhaMessage(allianceJoinFailedMessage, 1);
				return;
			}
			LogicLong id = this.gclass2_0.method_1().method_10().GetId();
			ServerRequestManager.Create(new GameJoinAllianceRequestMessage
			{
				AccountId = id,
				AllianceId = joinAllianceMessage_0.RemoveAllianceId()
			}, ServerManager.GetDocumentSocket(9, id), 30).OnComplete = new ServerRequestArgs.CompleteHandler(this.method_9);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002F10 File Offset: 0x00001110
		private void method_9(ServerRequestArgs serverRequestArgs_0)
		{
			if (serverRequestArgs_0.ErrorCode == ServerRequestError.Aborted)
			{
				AllianceJoinFailedMessage allianceJoinFailedMessage = new AllianceJoinFailedMessage();
				allianceJoinFailedMessage.SetReason(AllianceJoinFailedMessage.Reason.GENERIC);
				this.gclass2_0.SendPiranhaMessage(allianceJoinFailedMessage, 1);
				return;
			}
			if (!serverRequestArgs_0.ResponseMessage.Success)
			{
				GameJoinAllianceResponseMessage gameJoinAllianceResponseMessage = (GameJoinAllianceResponseMessage)serverRequestArgs_0.ResponseMessage;
				AllianceJoinFailedMessage allianceJoinFailedMessage2 = new AllianceJoinFailedMessage();
				switch (gameJoinAllianceResponseMessage.ErrorReason)
				{
				case GameJoinAllianceResponseMessage.Reason.NO_CASTLE:
				case GameJoinAllianceResponseMessage.Reason.ALREADY_IN_ALLIANCE:
				case GameJoinAllianceResponseMessage.Reason.GENERIC:
					allianceJoinFailedMessage2.SetReason(AllianceJoinFailedMessage.Reason.GENERIC);
					break;
				case GameJoinAllianceResponseMessage.Reason.FULL:
					allianceJoinFailedMessage2.SetReason(AllianceJoinFailedMessage.Reason.FULL);
					break;
				case GameJoinAllianceResponseMessage.Reason.CLOSED:
					allianceJoinFailedMessage2.SetReason(AllianceJoinFailedMessage.Reason.CLOSED);
					break;
				case GameJoinAllianceResponseMessage.Reason.SCORE:
					allianceJoinFailedMessage2.SetReason(AllianceJoinFailedMessage.Reason.SCORE);
					break;
				case GameJoinAllianceResponseMessage.Reason.BANNED:
					allianceJoinFailedMessage2.SetReason(AllianceJoinFailedMessage.Reason.BANNED);
					break;
				}
				this.gclass2_0.SendPiranhaMessage(allianceJoinFailedMessage2, 1);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002FC4 File Offset: 0x000011C4
		private void method_10(RequestJoinAllianceMessage requestJoinAllianceMessage_0)
		{
			if (this.method_13())
			{
				LogicLong logicLong = requestJoinAllianceMessage_0.RemoveAllianceId();
				ServerRequestManager.Create(new RequestAllianceJoinRequestMessage
				{
					Avatar = this.gclass2_0.method_1().method_10(),
					AllianceId = logicLong,
					Message = requestJoinAllianceMessage_0.GetMessage()
				}, ServerManager.GetDocumentSocket(11, logicLong), 30).OnComplete = new ServerRequestArgs.CompleteHandler(this.method_12);
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003030 File Offset: 0x00001230
		private void method_11(JoinAllianceUsingInvitationMessage joinAllianceUsingInvitationMessage_0)
		{
			if (this.method_13())
			{
				ServerRequestManager.Create(new LoadAvatarStreamRequestMessage
				{
					Id = joinAllianceUsingInvitationMessage_0.GetAvatarStreamEntryId()
				}, ServerManager.GetDocumentSocket(11, this.gclass2_0.AccountId), 5).OnComplete = new ServerRequestArgs.CompleteHandler(this.method_14);
				return;
			}
			AllianceJoinFailedMessage allianceJoinFailedMessage = new AllianceJoinFailedMessage();
			allianceJoinFailedMessage.SetReason(AllianceJoinFailedMessage.Reason.ALREADY_IN_ALLIANCE);
			this.gclass2_0.SendPiranhaMessage(allianceJoinFailedMessage, 1);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000309C File Offset: 0x0000129C
		private void method_12(ServerRequestArgs serverRequestArgs_0)
		{
			if (this.gclass2_0.IsDestructed())
			{
				return;
			}
			if (serverRequestArgs_0.ErrorCode != ServerRequestError.Success)
			{
				AllianceJoinRequestFailedMessage allianceJoinRequestFailedMessage = new AllianceJoinRequestFailedMessage();
				allianceJoinRequestFailedMessage.SetReason(AllianceJoinRequestFailedMessage.Reason.GENERIC);
				this.gclass2_0.SendPiranhaMessage(allianceJoinRequestFailedMessage, 1);
				return;
			}
			RequestAllianceJoinResponseMessage requestAllianceJoinResponseMessage = (RequestAllianceJoinResponseMessage)serverRequestArgs_0.ResponseMessage;
			if (requestAllianceJoinResponseMessage.Success)
			{
				this.gclass2_0.SendPiranhaMessage(new AllianceJoinRequestOkMessage(), 1);
				return;
			}
			AllianceJoinRequestFailedMessage allianceJoinRequestFailedMessage2 = new AllianceJoinRequestFailedMessage();
			switch (requestAllianceJoinResponseMessage.ErrorReason)
			{
			case RequestAllianceJoinResponseMessage.Reason.GENERIC:
				allianceJoinRequestFailedMessage2.SetReason(AllianceJoinRequestFailedMessage.Reason.GENERIC);
				break;
			case RequestAllianceJoinResponseMessage.Reason.CLOSED:
				allianceJoinRequestFailedMessage2.SetReason(AllianceJoinRequestFailedMessage.Reason.CLOSED);
				break;
			case RequestAllianceJoinResponseMessage.Reason.ALREADY_SENT:
				allianceJoinRequestFailedMessage2.SetReason(AllianceJoinRequestFailedMessage.Reason.ALREADY_SENT);
				break;
			case RequestAllianceJoinResponseMessage.Reason.NO_SCORE:
				allianceJoinRequestFailedMessage2.SetReason(AllianceJoinRequestFailedMessage.Reason.NO_SCORE);
				break;
			case RequestAllianceJoinResponseMessage.Reason.BANNED:
				allianceJoinRequestFailedMessage2.SetReason(AllianceJoinRequestFailedMessage.Reason.BANNED);
				break;
			case RequestAllianceJoinResponseMessage.Reason.TOO_MANY_PENDING_REQUESTS:
				allianceJoinRequestFailedMessage2.SetReason(AllianceJoinRequestFailedMessage.Reason.TOO_MANY_PENDING_REQUESTS);
				break;
			case RequestAllianceJoinResponseMessage.Reason.NO_DUEL_SCORE:
				allianceJoinRequestFailedMessage2.SetReason(AllianceJoinRequestFailedMessage.Reason.NO_DUEL_SCORE);
				break;
			}
			this.gclass2_0.SendPiranhaMessage(allianceJoinRequestFailedMessage2, 1);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003180 File Offset: 0x00001380
		private bool method_13()
		{
			return !this.gclass2_0.method_1().method_10().IsInAlliance() && !this.gclass2_0.method_1().method_12(LogicCommandType.JOIN_ALLIANCE) && this.gclass2_0.method_1().method_10().HasAllianceCastle();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000031D0 File Offset: 0x000013D0
		[CompilerGenerated]
		private void method_14(ServerRequestArgs serverRequestArgs_0)
		{
			if (this.gclass2_0.IsDestructed())
			{
				return;
			}
			if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
			{
				AllianceInvitationAvatarStreamEntry allianceInvitationAvatarStreamEntry = (AllianceInvitationAvatarStreamEntry)((LoadAvatarStreamResponseMessage)serverRequestArgs_0.ResponseMessage).Entry;
				LogicLong allianceId = allianceInvitationAvatarStreamEntry.GetAllianceId();
				ServerRequestManager.Create(new GameJoinAllianceRequestMessage
				{
					AccountId = this.gclass2_0.AccountId,
					AllianceId = allianceId,
					AvatarStreamId = allianceInvitationAvatarStreamEntry.GetId(),
					Invited = true
				}, ServerManager.GetDocumentSocket(9, this.gclass2_0.AccountId), 30).OnComplete = new ServerRequestArgs.CompleteHandler(this.method_9);
				return;
			}
			AllianceJoinFailedMessage allianceJoinFailedMessage = new AllianceJoinFailedMessage();
			allianceJoinFailedMessage.SetReason(AllianceJoinFailedMessage.Reason.ALREADY_IN_ALLIANCE);
			this.gclass2_0.SendPiranhaMessage(allianceJoinFailedMessage, 1);
		}

		// Token: 0x04000005 RID: 5
		private readonly GClass2 gclass2_0;
	}
}
