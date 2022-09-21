using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Battle;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Home;
using Atrasis.Magic.Logic.Message;
using Atrasis.Magic.Logic.Message.Avatar;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Logic.Message.Home;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Request.Stream;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Message.Session.Change;
using Atrasis.Magic.Servers.Core.Network.Message.Session.State;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace ns0
{
	// Token: 0x02000009 RID: 9
	public class GClass4 : ServerMessageManager
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00003958 File Offset: 0x00001B58
		public override void OnReceiveAccountMessage(ServerAccountMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType <= ServerMessageType.GAME_ALLOW_SERVER_COMMAND)
			{
				if (messageType <= ServerMessageType.CLIENT_UPDATE_LIVE_REPLAY)
				{
					if (messageType == ServerMessageType.ALLIANCE_LEAVED)
					{
						GClass4.smethod_1((AllianceLeavedMessage)message);
						return;
					}
					if (messageType != ServerMessageType.CLIENT_UPDATE_LIVE_REPLAY)
					{
						return;
					}
				}
				else
				{
					if (messageType == ServerMessageType.CREATE_AVATAR_STREAM)
					{
						GClass4.smethod_2((CreateAvatarStreamMessage)message);
						return;
					}
					switch (messageType)
					{
					case ServerMessageType.DUEL_ATTACK_EVENT:
						GClass4.smethod_7((DuelAttackEventMessage)message);
						return;
					case ServerMessageType.DUEL_PROGRESS:
						GClass4.smethod_5((DuelProgressMessage)message);
						return;
					case ServerMessageType.DUEL_RESULT:
						GClass4.smethod_6((DuelResultMessage)message);
						return;
					case ServerMessageType.END_GAME_HOME_LOCK:
						GClass4.smethod_4((EndGameHomeLockMessage)message);
						return;
					case ServerMessageType.END_LIVE_REPLAY:
						break;
					case ServerMessageType.EVENT_LOG:
					case ServerMessageType.FORWARD_LOGIC_MESSAGE:
					case ServerMessageType.FORWARD_LOGIC_REQUEST_MESSAGE:
						return;
					case ServerMessageType.GAME_ALLIANCE_DONATION_COUNT:
						GClass4.smethod_8((GameAllianceDonationCountMessage)message);
						return;
					case ServerMessageType.GAME_ALLOW_SERVER_COMMAND:
						GClass4.smethod_0((GameAllowServerCommandMessage)message);
						return;
					default:
						return;
					}
				}
			}
			else if (messageType <= ServerMessageType.GAME_STATE_CALLBACK)
			{
				if (messageType == ServerMessageType.GAME_HOME_PROTECTION_UPDATE)
				{
					GClass4.smethod_3((GameHomeProtectionUpdateMessage)message);
					return;
				}
				if (messageType != ServerMessageType.GAME_STATE_CALLBACK)
				{
					return;
				}
				GClass4.smethod_14((GameStateCallbackMessage)message);
				return;
			}
			else if (messageType != ServerMessageType.INITIALIZE_LIVE_REPLAY && messageType != ServerMessageType.LIVE_REPLAY_REMOVE_SPECTATOR && messageType != ServerMessageType.SERVER_UPDATE_LIVE_REPLAY)
			{
				return;
			}
			GClass15.smethod_6(message);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003A80 File Offset: 0x00001C80
		private static void smethod_0(GameAllowServerCommandMessage gameAllowServerCommandMessage_0)
		{
			GClass5 gclass;
			if (GClass7.smethod_4(gameAllowServerCommandMessage_0.AccountId, out gclass))
			{
				if (gameAllowServerCommandMessage_0.ServerCommand == null)
				{
					Logging.Error("GameMessageManager.onGameAllowServerCommandMessageReceived: serverCommand is NULL. Sender: " + gameAllowServerCommandMessage_0.Sender);
					return;
				}
				gclass.method_13(gameAllowServerCommandMessage_0.ServerCommand);
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003AC8 File Offset: 0x00001CC8
		private static void smethod_1(AllianceLeavedMessage allianceLeavedMessage_0)
		{
			GClass5 gclass;
			if (GClass7.smethod_4(allianceLeavedMessage_0.AccountId, out gclass))
			{
				gclass.DonationCount = 0;
				gclass.ReceivedDonationCount = 0;
				if (gclass.LogicClientAvatar.IsInAlliance() && gclass.LogicClientAvatar.GetAllianceId().Equals(allianceLeavedMessage_0.AllianceId))
				{
					LogicLeaveAllianceCommand logicLeaveAllianceCommand = new LogicLeaveAllianceCommand();
					logicLeaveAllianceCommand.SetAllianceData(allianceLeavedMessage_0.AllianceId);
					gclass.method_13(logicLeaveAllianceCommand);
					gclass.LogicClientAvatar.SetAllianceId(null);
					gclass.LogicClientAvatar.SetAllianceName(null);
					gclass.LogicClientAvatar.SetAllianceBadgeId(-1);
					gclass.LogicClientAvatar.SetAllianceLevel(-1);
				}
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003B60 File Offset: 0x00001D60
		private static void smethod_2(CreateAvatarStreamMessage createAvatarStreamMessage_0)
		{
			GClass5 gclass;
			if (GClass7.smethod_4(createAvatarStreamMessage_0.AccountId, out gclass))
			{
				ServerRequestManager.Create(new CreateAvatarStreamRequestMessage
				{
					OwnerId = gclass.Id,
					Entry = createAvatarStreamMessage_0.Entry
				}, ServerManager.GetDocumentSocket(11, gclass.Id), 30).OnComplete = new ServerRequestArgs.CompleteHandler(gclass.method_20);
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003BC0 File Offset: 0x00001DC0
		private static void smethod_3(GameHomeProtectionUpdateMessage gameHomeProtectionUpdateMessage_0)
		{
			GClass5 gclass;
			if (GClass7.smethod_4(gameHomeProtectionUpdateMessage_0.AccountId, out gclass))
			{
				gclass.ProtectionTime = TimeUtil.GetTimestamp();
				if (gameHomeProtectionUpdateMessage_0.ShieldTimeSeconds != -1)
				{
					gclass.RemainingShieldTimeSeconds = gameHomeProtectionUpdateMessage_0.ShieldTimeSeconds;
				}
				if (gameHomeProtectionUpdateMessage_0.GuardTimeSeconds != -1)
				{
					gclass.RemainingGuardTimeSeconds = gameHomeProtectionUpdateMessage_0.GuardTimeSeconds;
				}
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003C14 File Offset: 0x00001E14
		private static void smethod_4(EndGameHomeLockMessage endGameHomeLockMessage_0)
		{
			GClass5 gclass;
			if (GClass7.smethod_4(endGameHomeLockMessage_0.AccountId, out gclass) && gclass.method_2() != null && gclass.method_2().method_0().Equals(endGameHomeLockMessage_0.AttackerId))
			{
				gclass.method_3(null);
				if (gclass.method_0() != null && gclass.method_0().method_2() == null)
				{
					gclass.method_0().method_23();
				}
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003C78 File Offset: 0x00001E78
		private static void smethod_5(DuelProgressMessage duelProgressMessage_0)
		{
			GClass17 gclass;
			if (GClass19.smethod_3(duelProgressMessage_0.AccountId, out gclass))
			{
				gclass.method_4(duelProgressMessage_0);
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003CA0 File Offset: 0x00001EA0
		private static void smethod_6(DuelResultMessage duelResultMessage_0)
		{
			GClass17 gclass;
			if (GClass19.smethod_3(duelResultMessage_0.AccountId, out gclass))
			{
				gclass.method_5(duelResultMessage_0);
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003CC8 File Offset: 0x00001EC8
		private static void smethod_7(DuelAttackEventMessage duelAttackEventMessage_0)
		{
			GClass17 gclass;
			if (GClass19.smethod_3(duelAttackEventMessage_0.AccountId, out gclass))
			{
				gclass.method_8(duelAttackEventMessage_0);
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003CF0 File Offset: 0x00001EF0
		private static void smethod_8(GameAllianceDonationCountMessage gameAllianceDonationCountMessage_0)
		{
			GClass5 gclass;
			if (GClass7.smethod_4(gameAllianceDonationCountMessage_0.AccountId, out gclass) && (gclass.DonationCount != gameAllianceDonationCountMessage_0.DonationCount || gclass.ReceivedDonationCount != gameAllianceDonationCountMessage_0.ReceivedDonationCount))
			{
				gclass.DonationCount = gameAllianceDonationCountMessage_0.DonationCount;
				gclass.ReceivedDonationCount = gameAllianceDonationCountMessage_0.ReceivedDonationCount;
				if (gclass.method_0() == null)
				{
					GClass7.smethod_7(gclass);
				}
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003D50 File Offset: 0x00001F50
		public override void OnReceiveRequestMessage(ServerRequestMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType <= ServerMessageType.GAME_AVATAR_REQUEST)
			{
				if (messageType == ServerMessageType.AVATAR_REQUEST)
				{
					GClass4.smethod_9((AvatarRequestMessage)message);
					return;
				}
				if (messageType != ServerMessageType.GAME_AVATAR_REQUEST)
				{
					return;
				}
				GClass4.smethod_10((GameAvatarRequestMessage)message);
				return;
			}
			else
			{
				if (messageType == ServerMessageType.GAME_CREATE_ALLIANCE_INVITATION_REQUEST)
				{
					GClass4.smethod_12((GameCreateAllianceInvitationRequestMessage)message);
					return;
				}
				if (messageType == ServerMessageType.GAME_JOIN_ALLIANCE_REQUEST)
				{
					GClass4.smethod_11((GameJoinAllianceRequestMessage)message);
					return;
				}
				if (messageType != ServerMessageType.LIVE_REPLAY_ADD_SPECTATOR_REQUEST)
				{
					return;
				}
				GClass15.smethod_6(message);
				return;
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003DCC File Offset: 0x00001FCC
		private static void smethod_9(AvatarRequestMessage avatarRequestMessage_0)
		{
			GClass5 gclass;
			if (GClass7.smethod_4(avatarRequestMessage_0.AccountId, out gclass))
			{
				ServerRequestManager.SendResponse(new AvatarResponseMessage
				{
					LogicClientAvatar = gclass.LogicClientAvatar,
					Success = true
				}, avatarRequestMessage_0);
				return;
			}
			ServerRequestManager.SendResponse(new AvatarResponseMessage(), avatarRequestMessage_0);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003E14 File Offset: 0x00002014
		private static void smethod_10(GameAvatarRequestMessage gameAvatarRequestMessage_0)
		{
			GClass5 document;
			if (GClass7.smethod_4(gameAvatarRequestMessage_0.AccountId, out document))
			{
				ServerRequestManager.SendResponse(new GameAvatarResponseMessage
				{
					Document = document,
					Success = true
				}, gameAvatarRequestMessage_0);
				return;
			}
			ServerRequestManager.SendResponse(new GameAvatarResponseMessage(), gameAvatarRequestMessage_0);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003E58 File Offset: 0x00002058
		private static void smethod_11(GameJoinAllianceRequestMessage gameJoinAllianceRequestMessage_0)
		{
			GClass4.Class3 @class = new GClass4.Class3();
			@class.gameJoinAllianceRequestMessage_0 = gameJoinAllianceRequestMessage_0;
			if (GClass7.smethod_4(@class.gameJoinAllianceRequestMessage_0.AccountId, out @class.gclass5_0))
			{
				if (@class.gclass5_0.LogicClientAvatar.IsInAlliance() || @class.gclass5_0.method_10(LogicCommandType.JOIN_ALLIANCE))
				{
					ServerRequestManager.SendResponse(new GameJoinAllianceResponseMessage
					{
						ErrorReason = GameJoinAllianceResponseMessage.Reason.ALREADY_IN_ALLIANCE
					}, @class.gameJoinAllianceRequestMessage_0);
					return;
				}
				if (!@class.gclass5_0.LogicClientAvatar.HasAllianceCastle())
				{
					ServerRequestManager.SendResponse(new GameJoinAllianceResponseMessage
					{
						ErrorReason = GameJoinAllianceResponseMessage.Reason.NO_CASTLE
					}, @class.gameJoinAllianceRequestMessage_0);
					return;
				}
				if (!@class.gclass5_0.method_8())
				{
					if (@class.gameJoinAllianceRequestMessage_0.AvatarStreamId == null || @class.gclass5_0.AvatarStreamList.IndexOf(@class.gameJoinAllianceRequestMessage_0.AvatarStreamId) != -1)
					{
						@class.gclass5_0.method_9(true);
						ServerRequestManager.Create(new AllianceJoinRequestMessage
						{
							AllianceId = @class.gameJoinAllianceRequestMessage_0.AllianceId,
							Avatar = @class.gclass5_0.LogicClientAvatar,
							Created = @class.gameJoinAllianceRequestMessage_0.Created,
							Invited = @class.gameJoinAllianceRequestMessage_0.Invited
						}, ServerManager.GetDocumentSocket(11, @class.gameJoinAllianceRequestMessage_0.AllianceId), 15).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
						return;
					}
				}
				ServerRequestManager.SendResponse(new GameJoinAllianceResponseMessage
				{
					ErrorReason = GameJoinAllianceResponseMessage.Reason.GENERIC
				}, @class.gameJoinAllianceRequestMessage_0);
				return;
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003FD0 File Offset: 0x000021D0
		private static void smethod_12(GameCreateAllianceInvitationRequestMessage gameCreateAllianceInvitationRequestMessage_0)
		{
			GClass4.Class4 @class = new GClass4.Class4();
			@class.gameCreateAllianceInvitationRequestMessage_0 = gameCreateAllianceInvitationRequestMessage_0;
			GClass5 gclass;
			if (!GClass7.smethod_4(@class.gameCreateAllianceInvitationRequestMessage_0.AccountId, out gclass))
			{
				ServerRequestManager.SendResponse(new GameCreateAllianceInvitationResponseMessage
				{
					ErrorReason = GameCreateAllianceInvitationResponseMessage.Reason.GENERIC
				}, @class.gameCreateAllianceInvitationRequestMessage_0);
				return;
			}
			if (gclass.LogicClientAvatar.IsInAlliance() || gclass.method_10(LogicCommandType.JOIN_ALLIANCE) || gclass.method_8())
			{
				ServerRequestManager.SendResponse(new GameCreateAllianceInvitationResponseMessage
				{
					ErrorReason = GameCreateAllianceInvitationResponseMessage.Reason.ALREADY_IN_ALLIANCE
				}, @class.gameCreateAllianceInvitationRequestMessage_0);
				return;
			}
			if (!gclass.LogicClientAvatar.HasAllianceCastle())
			{
				ServerRequestManager.SendResponse(new GameCreateAllianceInvitationResponseMessage
				{
					ErrorReason = GameCreateAllianceInvitationResponseMessage.Reason.NO_CASTLE
				}, @class.gameCreateAllianceInvitationRequestMessage_0);
				return;
			}
			ServerRequestManager.Create(new LoadAvatarStreamOfTypeRequestMessage
			{
				StreamIds = gclass.AvatarStreamList,
				SenderAvatarId = @class.gameCreateAllianceInvitationRequestMessage_0.Entry.GetSenderAvatarId(),
				Type = AvatarStreamEntryType.ALLIANCE_INVITATION
			}, ServerManager.GetDocumentSocket(11, gclass.Id), 5).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000040CC File Offset: 0x000022CC
		public override void OnReceiveSessionMessage(ServerSessionMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType <= ServerMessageType.FORWARD_LOGIC_REQUEST_MESSAGE)
			{
				if (messageType == ServerMessageType.CHANGE_GAME_STATE)
				{
					GClass4.smethod_18((ChangeGameStateMessage)message);
					return;
				}
				if (messageType == ServerMessageType.FORWARD_LOGIC_MESSAGE)
				{
					GClass4.smethod_15((ForwardLogicMessage)message);
					return;
				}
				if (messageType != ServerMessageType.FORWARD_LOGIC_REQUEST_MESSAGE)
				{
					return;
				}
				GClass4.smethod_16((ForwardLogicRequestMessage)message);
				return;
			}
			else
			{
				if (messageType <= ServerMessageType.START_SERVER_SESSION)
				{
					switch (messageType)
					{
					case ServerMessageType.GAME_DUEL_MATCHMAKING:
						GClass4.smethod_20((GameDuelMatchmakingMessage)message);
						return;
					case ServerMessageType.GAME_DUEL_MATCHMAKING_RESULT:
						GClass9.smethod_5((GameDuelMatchmakingResultMessage)message);
						return;
					case ServerMessageType.GAME_FRIENDLY_SCOUT:
						GClass4.smethod_22((GameFriendlyScoutMessage)message);
						return;
					case ServerMessageType.GAME_HOME_PROTECTION_UPDATE:
					case ServerMessageType.GAME_JOIN_ALLIANCE_REQUEST:
					case ServerMessageType.GAME_JOIN_ALLIANCE_RESPONSE:
					case ServerMessageType.GAME_LOG:
						break;
					case ServerMessageType.GAME_MATCHMAKING:
						GClass4.smethod_19((GameMatchmakingMessage)message);
						return;
					case ServerMessageType.GAME_MATCHMAKING_RESULT:
						GClass10.smethod_7((GameMatchmakingResultMessage)message);
						return;
					case ServerMessageType.GAME_SPECTATE_LIVE_REPLAY:
						GClass4.smethod_23((GameSpectateLiveReplayMessage)message);
						break;
					case ServerMessageType.GAME_START_FAKE_ATTACK:
						GClass4.smethod_21((GameStartFakeAttackMessage)message);
						return;
					default:
						if (messageType != ServerMessageType.START_SERVER_SESSION)
						{
							return;
						}
						GClass2.smethod_2((StartServerSessionMessage)message);
						return;
					}
					return;
				}
				if (messageType == ServerMessageType.STOP_SERVER_SESSION)
				{
					GClass2.smethod_3((StopServerSessionMessage)message);
					return;
				}
				if (messageType != ServerMessageType.UPDATE_SOCKET_SERVER_SESSION)
				{
					return;
				}
				GClass4.smethod_13((UpdateSocketServerSessionMessage)message);
				return;
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000041FC File Offset: 0x000023FC
		private static void smethod_13(UpdateSocketServerSessionMessage updateSocketServerSessionMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_4(updateSocketServerSessionMessage_0.SessionId, out gclass))
			{
				gclass.UpdateSocketServerSessionMessageReceived(updateSocketServerSessionMessage_0);
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00004220 File Offset: 0x00002420
		private static void smethod_14(GameStateCallbackMessage gameStateCallbackMessage_0)
		{
			GClass5 gclass;
			if (GClass7.smethod_4(gameStateCallbackMessage_0.AccountId, out gclass))
			{
				if (gameStateCallbackMessage_0.LogicClientAvatar != null)
				{
					gclass.LogicClientAvatar = gameStateCallbackMessage_0.LogicClientAvatar;
				}
				else
				{
					for (int i = 0; i < gameStateCallbackMessage_0.AvatarChanges.Size(); i++)
					{
						gameStateCallbackMessage_0.AvatarChanges[i].ApplyAvatarChange(gclass.LogicClientAvatar);
					}
				}
				if (gameStateCallbackMessage_0.HomeJSON != null)
				{
					if (gameStateCallbackMessage_0.ExecutedServerCommands != null)
					{
						int j = 0;
						IL_C4:
						while (j < gameStateCallbackMessage_0.ExecutedServerCommands.Size())
						{
							LogicServerCommand logicServerCommand = gameStateCallbackMessage_0.ExecutedServerCommands[j];
							for (int k = 0; k < gclass.ServerCommands.Size(); k++)
							{
								if (gclass.ServerCommands[k].GetId() == logicServerCommand.GetId())
								{
									gclass.ServerCommands.Remove(k);
									IL_C0:
									j++;
									goto IL_C4;
								}
							}
							goto IL_C0;
						}
					}
					gclass.HomeData = gameStateCallbackMessage_0.HomeJSON;
					gclass.SaveTime = gameStateCallbackMessage_0.SaveTime;
					gclass.MaintenanceTime = -1;
				}
				if (gclass.LogicClientAvatar.IsInAlliance() && gameStateCallbackMessage_0.AvatarChanges.Size() != 0)
				{
					ServerMessageManager.SendMessage(new AllianceAvatarChangesMessage
					{
						AccountId = gclass.LogicClientAvatar.GetAllianceId(),
						MemberId = gclass.LogicClientAvatar.GetId(),
						AvatarChanges = gameStateCallbackMessage_0.AvatarChanges
					}, 11);
				}
				GClass1 gclass2 = gclass.method_0();
				if (gclass2 != null)
				{
					DateTime utcNow = DateTime.UtcNow;
					if (utcNow.Subtract(gclass2.method_4()).TotalSeconds > 2.0)
					{
						GClass7.smethod_7(gclass);
						gclass2.method_5(utcNow);
					}
					if (gclass2.method_2() != null && gameStateCallbackMessage_0.SessionId != gclass2.Id)
					{
						gclass2.SendPiranhaMessage(new OutOfSyncMessage(), 1);
						gclass2.SendMessage(new StopSessionMessage
						{
							Reason = 1
						}, 1);
						return;
					}
					if (gameStateCallbackMessage_0.AvatarChanges.Size() != 0)
					{
						for (int l = 0; l < gameStateCallbackMessage_0.AvatarChanges.Size(); l++)
						{
							if (gameStateCallbackMessage_0.AvatarChanges[l].GetAvatarChangeType() == AvatarChangeType.ALLIANCE_JOINED)
							{
								gclass2.method_18();
							}
						}
						return;
					}
				}
				else
				{
					GClass7.smethod_7(gclass);
				}
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004434 File Offset: 0x00002634
		private static void smethod_15(ForwardLogicMessage forwardLogicMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_4(forwardLogicMessage_0.SessionId, out gclass))
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

		// Token: 0x0600004D RID: 77 RVA: 0x000044AC File Offset: 0x000026AC
		private static void smethod_16(ForwardLogicRequestMessage forwardLogicRequestMessage_0)
		{
			PiranhaMessage piranhaMessage = LogicMagicMessageFactory.Instance.CreateMessageByType((int)forwardLogicRequestMessage_0.MessageType);
			if (piranhaMessage == null)
			{
				throw new Exception("logicMessage should not be NULL!");
			}
			piranhaMessage.GetByteStream().SetByteArray(forwardLogicRequestMessage_0.MessageBytes, forwardLogicRequestMessage_0.MessageLength);
			piranhaMessage.SetMessageVersion((int)forwardLogicRequestMessage_0.MessageVersion);
			piranhaMessage.Decode();
			if (!piranhaMessage.IsServerToClientMessage() && piranhaMessage.GetMessageType() == 14325)
			{
				LogicLong logicLong = ((AskForAvatarProfileMessage)piranhaMessage).RemoveAvatarId();
				GClass5 gclass;
				if (GClass7.smethod_4(logicLong, out gclass))
				{
					AvatarProfileMessage avatarProfileMessage = new AvatarProfileMessage();
					AvatarProfileFullEntry avatarProfileFullEntry = new AvatarProfileFullEntry();
					avatarProfileFullEntry.SetDonations(gclass.DonationCount);
					avatarProfileFullEntry.SetDonationsReceived(gclass.ReceivedDonationCount);
					avatarProfileFullEntry.SetLogicClientAvatar(gclass.LogicClientAvatar);
					avatarProfileFullEntry.SetCompressedHomeJSON(gclass.HomeData);
					avatarProfileMessage.SetAvatarProfileFullEntry(avatarProfileFullEntry);
					ServerMessageManager.SendMessage(GClass4.smethod_17(avatarProfileMessage, forwardLogicRequestMessage_0.SessionId), ServerManager.GetProxySocket(forwardLogicRequestMessage_0.SessionId));
					return;
				}
				AvatarProfileFailedMessage avatarProfileFailedMessage = new AvatarProfileFailedMessage();
				avatarProfileFailedMessage.SetAvatarId(logicLong);
				avatarProfileFailedMessage.SetErrorType(AvatarProfileFailedMessage.ErrorType.NOT_FOUND);
				ServerMessageManager.SendMessage(GClass4.smethod_17(avatarProfileFailedMessage, forwardLogicRequestMessage_0.SessionId), ServerManager.GetProxySocket(forwardLogicRequestMessage_0.SessionId));
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000045C0 File Offset: 0x000027C0
		private static ForwardLogicMessage smethod_17(PiranhaMessage piranhaMessage_0, long long_0)
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

		// Token: 0x0600004F RID: 79 RVA: 0x00004618 File Offset: 0x00002818
		private static void smethod_18(ChangeGameStateMessage changeGameStateMessage_0)
		{
			GClass4.Class5 @class = new GClass4.Class5();
			if (GClass2.smethod_4(changeGameStateMessage_0.SessionId, out @class.gclass1_0))
			{
				GClass5 gclass = @class.gclass1_0.method_1();
				switch (changeGameStateMessage_0.StateType)
				{
				case GameStateType.HOME:
					@class.gclass1_0.method_22();
					if (@class.gclass1_0.method_1().method_2() != null)
					{
						if (!@class.gclass1_0.method_1().method_2().method_3())
						{
							@class.gclass1_0.method_17();
							return;
						}
						@class.gclass1_0.method_1().method_3(null);
					}
					@class.gclass1_0.method_23();
					return;
				case GameStateType.NPC_ATTACK:
					@class.gclass1_0.method_22();
					@class.gclass1_0.method_24(new GameNpcAttackState
					{
						HomeId = new LogicLong(-1, -1),
						PlayerAvatar = gclass.LogicClientAvatar,
						HomeData = GClass11.smethod_2()[changeGameStateMessage_0.NpcData.GetInstanceID()],
						NpcAvatar = LogicNpcAvatar.GetNpcAvatar(changeGameStateMessage_0.NpcData),
						SaveTime = -1
					});
					return;
				case GameStateType.NPC_DUEL:
					@class.gclass1_0.method_22();
					@class.gclass1_0.method_24(new GameNpcDuelState
					{
						HomeId = new LogicLong(-1, -1),
						PlayerAvatar = gclass.LogicClientAvatar,
						HomeData = GClass11.smethod_2()[changeGameStateMessage_0.NpcData.GetInstanceID()],
						NpcAvatar = LogicNpcAvatar.GetNpcAvatar(changeGameStateMessage_0.NpcData),
						SaveTime = -1
					});
					return;
				case GameStateType.MATCHED_ATTACK:
				case GameStateType.FAKE_ATTACK:
				case GameStateType.DUEL:
					break;
				case GameStateType.CHALLENGE_ATTACK:
				{
					LogicLong liveReplayId = GClass15.smethod_3(@class.gclass1_0, changeGameStateMessage_0.ChallengeAllianceId, changeGameStateMessage_0.ChallengeStreamId);
					@class.gclass1_0.method_22();
					@class.gclass1_0.method_24(new GameChallengeAttackState
					{
						HomeId = changeGameStateMessage_0.ChallengeHomeId,
						HomeData = changeGameStateMessage_0.ChallengeHomeJSON,
						PlayerAvatar = gclass.LogicClientAvatar,
						SaveTime = -1,
						LiveReplayId = liveReplayId,
						AllianceId = changeGameStateMessage_0.ChallengeAllianceId,
						StreamId = changeGameStateMessage_0.ChallengeStreamId,
						MapId = changeGameStateMessage_0.ChallengeMapId
					});
					ServerMessageManager.SendMessage(new AllianceChallengeLiveReplayIdMessage
					{
						AccountId = changeGameStateMessage_0.ChallengeStreamId,
						LiveReplayId = liveReplayId
					}, 11);
					break;
				}
				case GameStateType.VISIT:
					ServerRequestManager.Create(new GameAvatarRequestMessage
					{
						AccountId = changeGameStateMessage_0.HomeId
					}, ServerManager.GetDocumentSocket(9, changeGameStateMessage_0.HomeId), 5).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004880 File Offset: 0x00002A80
		private static void smethod_19(GameMatchmakingMessage gameMatchmakingMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_4(gameMatchmakingMessage_0.SessionId, out gclass))
			{
				gclass.method_22();
				if (gclass.method_14() != null)
				{
					gclass.method_24(gclass.method_14());
					gclass.method_15(null);
				}
				GClass10.smethod_5(gclass);
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000048C4 File Offset: 0x00002AC4
		private static void smethod_20(GameDuelMatchmakingMessage gameDuelMatchmakingMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_4(gameDuelMatchmakingMessage_0.SessionId, out gclass))
			{
				if (gclass.method_1().method_4() != null)
				{
					return;
				}
				if (gclass.method_14() != null)
				{
					gclass.method_15(null);
				}
				gclass.method_22();
				GClass9.smethod_3(gclass, gameDuelMatchmakingMessage_0.Snapshot);
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004910 File Offset: 0x00002B10
		private static void smethod_21(GameStartFakeAttackMessage gameStartFakeAttackMessage_0)
		{
			GClass4.Class6 @class = new GClass4.Class6();
			if (GClass2.smethod_4(gameStartFakeAttackMessage_0.SessionId, out @class.gclass1_0))
			{
				if (gameStartFakeAttackMessage_0.AccountId != null)
				{
					ServerRequestManager.Create(new GameAvatarRequestMessage
					{
						AccountId = gameStartFakeAttackMessage_0.AccountId
					}, ServerManager.GetDocumentSocket(9, gameStartFakeAttackMessage_0.AccountId), 30).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
					return;
				}
				GameState gameState = @class.gclass1_0.method_2();
				if (gameState != null && gameState.GetGameStateType() == GameStateType.HOME)
				{
					AvailableServerCommandMessage availableServerCommandMessage = new AvailableServerCommandMessage();
					availableServerCommandMessage.SetServerCommand(new LogicMatchmakingCommand());
					@class.gclass1_0.SendPiranhaMessage(availableServerCommandMessage, 1);
					@class.gclass1_0.method_15(new GameFakeAttackState
					{
						HomeId = new LogicLong(-1, -1),
						HomeData = GClass8.smethod_3((LogicGameObjectData)gameStartFakeAttackMessage_0.ArgData),
						HomeOwnerAvatar = GClass8.smethod_0(),
						PlayerAvatar = @class.gclass1_0.method_1().LogicClientAvatar,
						SaveTime = TimeUtil.GetTimestamp(),
						MaintenanceTime = -1
					});
				}
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004A1C File Offset: 0x00002C1C
		private static void smethod_22(GameFriendlyScoutMessage gameFriendlyScoutMessage_0)
		{
			GClass1 gclass;
			if (GClass2.smethod_4(gameFriendlyScoutMessage_0.SessionId, out gclass))
			{
				gclass.method_22();
				FriendlyScoutHomeDataMessage friendlyScoutHomeDataMessage = new FriendlyScoutHomeDataMessage();
				LogicClientHome logicClientHome = new LogicClientHome();
				logicClientHome.GetCompressibleHomeJSON().Set(gameFriendlyScoutMessage_0.HomeJSON);
				logicClientHome.GetCompressibleGlobalJSON().Set(ResourceManager.SERVER_SAVE_FILE_GLOBAL);
				logicClientHome.GetCompressibleCalendarJSON().Set(ResourceManager.SERVER_SAVE_FILE_CALENDAR);
				friendlyScoutHomeDataMessage.SetAccountId(gameFriendlyScoutMessage_0.AccountId);
				friendlyScoutHomeDataMessage.SetAvatarId(gameFriendlyScoutMessage_0.AccountId);
				friendlyScoutHomeDataMessage.SetCurrentTimestamp(TimeUtil.GetTimestamp());
				friendlyScoutHomeDataMessage.SetLogicClientHome(logicClientHome);
				friendlyScoutHomeDataMessage.SetLogicClientAvatar(gclass.method_1().LogicClientAvatar);
				friendlyScoutHomeDataMessage.SetMapId(gameFriendlyScoutMessage_0.MapId);
				friendlyScoutHomeDataMessage.SetStreamId(gameFriendlyScoutMessage_0.StreamId);
				gclass.SendPiranhaMessage(friendlyScoutHomeDataMessage, 1);
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00004ADC File Offset: 0x00002CDC
		private static void smethod_23(GameSpectateLiveReplayMessage gameSpectateLiveReplayMessage_0)
		{
			GClass4.Class7 @class = new GClass4.Class7();
			@class.gameSpectateLiveReplayMessage_0 = gameSpectateLiveReplayMessage_0;
			if (GClass2.smethod_4(@class.gameSpectateLiveReplayMessage_0.SessionId, out @class.gclass1_0))
			{
				ServerRequestManager.Create(new LiveReplayAddSpectatorRequestMessage
				{
					LiveReplayId = @class.gameSpectateLiveReplayMessage_0.LiveReplayId,
					SlotId = (@class.gameSpectateLiveReplayMessage_0.IsEnemy ? 1 : 0),
					SessionId = @class.gclass1_0.Id
				}, ServerManager.GetDocumentSocket(9, @class.gameSpectateLiveReplayMessage_0.LiveReplayId), 30).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000023B4 File Offset: 0x000005B4
		public override void OnReceiveCoreMessage(ServerCoreMessage message)
		{
			if (message.GetMessageType() == ServerMessageType.SERVER_PERFORMANCE)
			{
				ServerMessageManager.SendMessage(new ServerPerformanceDataMessage
				{
					SessionCount = GClass2.smethod_0()
				}, message.Sender);
			}
		}

		// Token: 0x0200000A RID: 10
		[CompilerGenerated]
		private sealed class Class3
		{
			// Token: 0x06000058 RID: 88 RVA: 0x00004B78 File Offset: 0x00002D78
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				this.gclass5_0.method_9(false);
				if (serverRequestArgs_0.ErrorCode != ServerRequestError.Success)
				{
					ServerRequestManager.SendResponse(new GameJoinAllianceResponseMessage
					{
						ErrorReason = GameJoinAllianceResponseMessage.Reason.GENERIC
					}, this.gameJoinAllianceRequestMessage_0);
					return;
				}
				AllianceJoinResponseMessage allianceJoinResponseMessage = (AllianceJoinResponseMessage)serverRequestArgs_0.ResponseMessage;
				if (allianceJoinResponseMessage.Success)
				{
					if (this.gameJoinAllianceRequestMessage_0.AvatarStreamId != null)
					{
						this.gclass5_0.method_17(this.gameJoinAllianceRequestMessage_0.AvatarStreamId);
					}
					LogicJoinAllianceCommand logicJoinAllianceCommand = new LogicJoinAllianceCommand();
					logicJoinAllianceCommand.SetAllianceData(allianceJoinResponseMessage.AllianceId, allianceJoinResponseMessage.AllianceName, allianceJoinResponseMessage.AllianceBadgeId, allianceJoinResponseMessage.AllianceLevel, allianceJoinResponseMessage.Created);
					this.gclass5_0.method_13(logicJoinAllianceCommand);
					ServerRequestManager.SendResponse(new GameJoinAllianceResponseMessage
					{
						Success = true
					}, this.gameJoinAllianceRequestMessage_0);
					return;
				}
				GameJoinAllianceResponseMessage gameJoinAllianceResponseMessage = new GameJoinAllianceResponseMessage();
				switch (allianceJoinResponseMessage.ErrorReason)
				{
				case AllianceJoinResponseMessage.Reason.GENERIC:
					gameJoinAllianceResponseMessage.ErrorReason = GameJoinAllianceResponseMessage.Reason.GENERIC;
					break;
				case AllianceJoinResponseMessage.Reason.FULL:
					gameJoinAllianceResponseMessage.ErrorReason = GameJoinAllianceResponseMessage.Reason.FULL;
					break;
				case AllianceJoinResponseMessage.Reason.CLOSED:
					gameJoinAllianceResponseMessage.ErrorReason = GameJoinAllianceResponseMessage.Reason.CLOSED;
					break;
				case AllianceJoinResponseMessage.Reason.SCORE:
					gameJoinAllianceResponseMessage.ErrorReason = GameJoinAllianceResponseMessage.Reason.SCORE;
					break;
				case AllianceJoinResponseMessage.Reason.BANNED:
					gameJoinAllianceResponseMessage.ErrorReason = GameJoinAllianceResponseMessage.Reason.BANNED;
					break;
				}
				ServerRequestManager.SendResponse(gameJoinAllianceResponseMessage, this.gameJoinAllianceRequestMessage_0);
			}

			// Token: 0x04000011 RID: 17
			public GClass5 gclass5_0;

			// Token: 0x04000012 RID: 18
			public GameJoinAllianceRequestMessage gameJoinAllianceRequestMessage_0;
		}

		// Token: 0x0200000B RID: 11
		[CompilerGenerated]
		private sealed class Class4
		{
			// Token: 0x0600005A RID: 90 RVA: 0x00004C9C File Offset: 0x00002E9C
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					LoadAvatarStreamOfTypeResponseMessage loadAvatarStreamOfTypeResponseMessage = (LoadAvatarStreamOfTypeResponseMessage)serverRequestArgs_0.ResponseMessage;
					for (int i = 0; i < loadAvatarStreamOfTypeResponseMessage.StreamList.Size(); i++)
					{
						if (((AllianceInvitationAvatarStreamEntry)loadAvatarStreamOfTypeResponseMessage.StreamList[i]).GetAllianceId().Equals(this.gameCreateAllianceInvitationRequestMessage_0.Entry.GetAllianceId()))
						{
							ServerRequestManager.SendResponse(new GameCreateAllianceInvitationResponseMessage
							{
								ErrorReason = GameCreateAllianceInvitationResponseMessage.Reason.ALREADY_HAS_AN_INVITE
							}, this.gameCreateAllianceInvitationRequestMessage_0);
							return;
						}
					}
					if (loadAvatarStreamOfTypeResponseMessage.StreamList.Size() >= 10)
					{
						ServerRequestManager.SendResponse(new GameCreateAllianceInvitationResponseMessage
						{
							ErrorReason = GameCreateAllianceInvitationResponseMessage.Reason.HAS_TOO_MANY_INVITES
						}, this.gameCreateAllianceInvitationRequestMessage_0);
					}
					ServerMessageManager.SendMessage(new CreateAvatarStreamMessage
					{
						AccountId = this.gameCreateAllianceInvitationRequestMessage_0.AccountId,
						Entry = this.gameCreateAllianceInvitationRequestMessage_0.Entry
					}, 9);
					ServerRequestManager.SendResponse(new GameCreateAllianceInvitationResponseMessage
					{
						Success = true
					}, this.gameCreateAllianceInvitationRequestMessage_0);
					return;
				}
				ServerRequestManager.SendResponse(new GameCreateAllianceInvitationResponseMessage
				{
					ErrorReason = GameCreateAllianceInvitationResponseMessage.Reason.GENERIC
				}, this.gameCreateAllianceInvitationRequestMessage_0);
			}

			// Token: 0x04000013 RID: 19
			public GameCreateAllianceInvitationRequestMessage gameCreateAllianceInvitationRequestMessage_0;
		}

		// Token: 0x0200000C RID: 12
		[CompilerGenerated]
		private sealed class Class5
		{
			// Token: 0x0600005C RID: 92 RVA: 0x00004DB0 File Offset: 0x00002FB0
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				if (!this.gclass1_0.IsDestructed())
				{
					if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
					{
						GameAvatarResponseMessage gameAvatarResponseMessage = (GameAvatarResponseMessage)serverRequestArgs_0.ResponseMessage;
						this.gclass1_0.method_22();
						this.gclass1_0.method_24(new GameVisitState
						{
							HomeId = gameAvatarResponseMessage.Document.Id,
							HomeData = gameAvatarResponseMessage.Document.HomeData,
							HomeOwnerAvatar = gameAvatarResponseMessage.Document.LogicClientAvatar,
							SaveTime = gameAvatarResponseMessage.Document.SaveTime,
							PlayerAvatar = this.gclass1_0.method_1().LogicClientAvatar
						});
						return;
					}
					this.gclass1_0.SendPiranhaMessage(new VisitFailedMessage(), 1);
				}
			}

			// Token: 0x04000014 RID: 20
			public GClass1 gclass1_0;
		}

		// Token: 0x0200000D RID: 13
		[CompilerGenerated]
		private sealed class Class6
		{
			// Token: 0x0600005E RID: 94 RVA: 0x00004E7C File Offset: 0x0000307C
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				if (this.gclass1_0.IsDestructed())
				{
					return;
				}
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					GameState gameState = this.gclass1_0.method_2();
					if (gameState != null && gameState.GetGameStateType() == GameStateType.HOME)
					{
						GameDocument document = ((GameAvatarResponseMessage)serverRequestArgs_0.ResponseMessage).Document;
						AvailableServerCommandMessage availableServerCommandMessage = new AvailableServerCommandMessage();
						availableServerCommandMessage.SetServerCommand(new LogicMatchmakingCommand());
						this.gclass1_0.SendPiranhaMessage(availableServerCommandMessage, 1);
						this.gclass1_0.method_15(new GameFakeAttackState
						{
							HomeId = document.Id,
							HomeData = document.HomeData,
							HomeOwnerAvatar = document.LogicClientAvatar,
							PlayerAvatar = this.gclass1_0.method_1().LogicClientAvatar,
							SaveTime = document.SaveTime,
							MaintenanceTime = document.MaintenanceTime
						});
						return;
					}
				}
				else
				{
					AttackHomeFailedMessage attackHomeFailedMessage = new AttackHomeFailedMessage();
					attackHomeFailedMessage.SetReason(AttackHomeFailedMessage.Reason.GENERIC);
					this.gclass1_0.SendPiranhaMessage(attackHomeFailedMessage, 1);
				}
			}

			// Token: 0x04000015 RID: 21
			public GClass1 gclass1_0;
		}

		// Token: 0x0200000E RID: 14
		[CompilerGenerated]
		private sealed class Class7
		{
			// Token: 0x06000060 RID: 96 RVA: 0x00004F7C File Offset: 0x0000317C
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				if (serverRequestArgs_0.ErrorCode != ServerRequestError.Success || !serverRequestArgs_0.ResponseMessage.Success)
				{
					if (!this.gclass1_0.IsDestructed())
					{
						LiveReplayFailedMessage liveReplayFailedMessage = new LiveReplayFailedMessage();
						if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success)
						{
							LiveReplayAddSpectatorResponseMessage.Reason errorCode = ((LiveReplayAddSpectatorResponseMessage)serverRequestArgs_0.ResponseMessage).ErrorCode;
							if (errorCode != LiveReplayAddSpectatorResponseMessage.Reason.NOT_EXISTS)
							{
								if (errorCode == LiveReplayAddSpectatorResponseMessage.Reason.FULL)
								{
									liveReplayFailedMessage.SetReason(LiveReplayFailedMessage.Reason.NO_FREE_SLOTS);
								}
							}
							else
							{
								liveReplayFailedMessage.SetReason(LiveReplayFailedMessage.Reason.GENERIC);
							}
						}
						else
						{
							liveReplayFailedMessage.SetReason(LiveReplayFailedMessage.Reason.GENERIC);
						}
						this.gclass1_0.SendPiranhaMessage(liveReplayFailedMessage, 1);
					}
					return;
				}
				if (this.gclass1_0.IsDestructed())
				{
					ServerMessageManager.SendMessage(new LiveReplayRemoveSpectatorMessage
					{
						AccountId = this.gameSpectateLiveReplayMessage_0.LiveReplayId,
						SessionId = this.gclass1_0.Id
					}, 9);
					return;
				}
				this.gclass1_0.method_22();
				this.gclass1_0.method_11(this.gameSpectateLiveReplayMessage_0.LiveReplayId);
				this.gclass1_0.method_13(this.gameSpectateLiveReplayMessage_0.IsEnemy ? 1 : 0);
			}

			// Token: 0x04000016 RID: 22
			public GClass1 gclass1_0;

			// Token: 0x04000017 RID: 23
			public GameSpectateLiveReplayMessage gameSpectateLiveReplayMessage_0;
		}
	}
}
