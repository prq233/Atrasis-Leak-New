using System;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Request.Stream;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Message.Session.State;

namespace Atrasis.Magic.Servers.Core.Network.Message
{
	// Token: 0x0200002D RID: 45
	public static class ServerMessageFactory
	{
		// Token: 0x06000103 RID: 259 RVA: 0x0000B70C File Offset: 0x0000990C
		public static ServerMessage CreateMessageByType(ServerMessageType type)
		{
			switch (type)
			{
			case ServerMessageType.ALLIANCE_AVATAR_CHANGES:
				return new AllianceAvatarChangesMessage();
			case ServerMessageType.ALLIANCE_CHALLENGE_LIVE_REPLAY_ID:
				return new AllianceChallengeLiveReplayIdMessage();
			case ServerMessageType.ALLIANCE_CHALLENGE_REPORT:
				return new AllianceChallengeReportMessage();
			case ServerMessageType.ALLIANCE_CHALLENGE_REQUEST:
				return new AllianceChallengeRequestMessage();
			case ServerMessageType.ALLIANCE_CHALLENGE_SPECTATOR_COUNT:
				return new AllianceChallengeSpectatorCountMessage();
			case ServerMessageType.ALLIANCE_CREATE_MAIL:
				return new AllianceCreateMailMessage();
			case ServerMessageType.ALLIANCE_JOIN_REQUEST:
				return new AllianceJoinRequestMessage();
			case ServerMessageType.ALLIANCE_JOIN_RESPONSE:
				return new AllianceJoinResponseMessage();
			case ServerMessageType.ALLIANCE_KICK_MEMBER:
				return new AllianceKickMemberMessage();
			case ServerMessageType.ALLIANCE_LEAVED:
				return new AllianceLeavedMessage();
			case ServerMessageType.ALLIANCE_REQUEST_ALLIANCE_UNITS:
				return new AllianceRequestAllianceUnitsMessage();
			case ServerMessageType.ALLIANCE_SHARE_DUEL_REPLAY:
				return new AllianceShareDuelReplayMessage();
			case ServerMessageType.ALLIANCE_SHARE_REPLAY:
				return new AllianceShareReplayMessage();
			case ServerMessageType.ALLIANCE_UNIT_DONATE_RESPONSE:
				return new AllianceUnitDonateResponseMessage();
			case ServerMessageType.ASK_FOR_SERVER_STATUS:
				return new AskForServerStatusMessage();
			case ServerMessageType.AVATAR_REQUEST:
				return new AvatarRequestMessage();
			case ServerMessageType.AVATAR_RESPONSE:
				return new AvatarResponseMessage();
			case ServerMessageType.AVATAR_STREAM_SEEN:
				return new AvatarStreamSeenMessage();
			case ServerMessageType.BIND_SERVER_SOCKET_REQUEST:
				return new BindServerSocketRequestMessage();
			case ServerMessageType.BIND_SERVER_SOCKET_RESPONSE:
				return new BindServerSocketResponseMessage();
			case ServerMessageType.CHANGE_GAME_STATE:
				return new ChangeGameStateMessage();
			case ServerMessageType.CHAT_ACCOUNT_BAN_STATUS_UPDATED:
				return new ChatAccountBanStatusUpdatedMessage();
			case ServerMessageType.CLIENT_UPDATE_LIVE_REPLAY:
				return new ClientUpdateLiveReplayMessage();
			case ServerMessageType.CLUSTER_PERFORMANCE_DATA:
				return new ClusterPerformanceDataMessage();
			case ServerMessageType.CREATE_ALLIANCE_REQUEST:
				return new CreateAllianceRequestMessage();
			case ServerMessageType.CREATE_ALLIANCE_RESPONSE:
				return new CreateAllianceResponseMessage();
			case ServerMessageType.CREATE_AVATAR_STREAM:
				return new CreateAvatarStreamMessage();
			case ServerMessageType.CREATE_AVATAR_STREAM_REQUEST:
				return new CreateAvatarStreamRequestMessage();
			case ServerMessageType.CREATE_AVATAR_STREAM_RESPONSE:
				return new CreateAvatarStreamResponseMessage();
			case ServerMessageType.CREATE_REPLAY_STREAM_REQUEST:
				return new CreateReplayStreamRequestMessage();
			case ServerMessageType.CREATE_REPLAY_STREAM_RESPONSE:
				return new CreateReplayStreamResponseMessage();
			case ServerMessageType.CREATE_VILLAGE2_ATTACK_ENTRY_REQUEST:
				return new CreateVillage2AttackEntryRequestMessage();
			case ServerMessageType.CREATE_VILLAGE2_ATTACK_ENTRY_RESPONSE:
				return new CreateVillage2AttackEntryResponseMessage();
			case ServerMessageType.DUEL_ATTACK_EVENT:
				return new DuelAttackEventMessage();
			case ServerMessageType.DUEL_PROGRESS:
				return new DuelProgressMessage();
			case ServerMessageType.DUEL_RESULT:
				return new DuelResultMessage();
			case ServerMessageType.END_GAME_HOME_LOCK:
				return new EndGameHomeLockMessage();
			case ServerMessageType.END_LIVE_REPLAY:
				return new EndLiveReplayMessage();
			case ServerMessageType.EVENT_LOG:
				return new EventLogMessage();
			case ServerMessageType.FORWARD_LOGIC_MESSAGE:
				return new ForwardLogicMessage();
			case ServerMessageType.FORWARD_LOGIC_REQUEST_MESSAGE:
				return new ForwardLogicRequestMessage();
			case ServerMessageType.GAME_ALLIANCE_DONATION_COUNT:
				return new GameAllianceDonationCountMessage();
			case ServerMessageType.GAME_ALLOW_SERVER_COMMAND:
				return new GameAllowServerCommandMessage();
			case ServerMessageType.GAME_AVATAR_REQUEST:
				return new GameAvatarRequestMessage();
			case ServerMessageType.GAME_AVATAR_RESPONSE:
				return new GameAvatarResponseMessage();
			case ServerMessageType.GAME_CREATE_ALLIANCE_INVITATION_REQUEST:
				return new GameCreateAllianceInvitationRequestMessage();
			case ServerMessageType.GAME_CREATE_ALLIANCE_INVITATION_RESPONSE:
				return new GameCreateAllianceInvitationResponseMessage();
			case ServerMessageType.GAME_DUEL_MATCHMAKING:
				return new GameDuelMatchmakingMessage();
			case ServerMessageType.GAME_DUEL_MATCHMAKING_RESULT:
				return new GameDuelMatchmakingResultMessage();
			case ServerMessageType.GAME_FRIENDLY_SCOUT:
				return new GameFriendlyScoutMessage();
			case ServerMessageType.GAME_HOME_PROTECTION_UPDATE:
				return new GameHomeProtectionUpdateMessage();
			case ServerMessageType.GAME_JOIN_ALLIANCE_REQUEST:
				return new GameJoinAllianceRequestMessage();
			case ServerMessageType.GAME_JOIN_ALLIANCE_RESPONSE:
				return new GameJoinAllianceResponseMessage();
			case ServerMessageType.GAME_LOG:
				return new GameLogMessage();
			case ServerMessageType.GAME_MATCHMAKING:
				return new GameMatchmakingMessage();
			case ServerMessageType.GAME_MATCHMAKING_RESULT:
				return new GameMatchmakingResultMessage();
			case ServerMessageType.GAME_SPECTATE_LIVE_REPLAY:
				return new GameSpectateLiveReplayMessage();
			case ServerMessageType.GAME_START_FAKE_ATTACK:
				return new GameStartFakeAttackMessage();
			case ServerMessageType.GAME_STATE_CALLBACK:
				return new GameStateCallbackMessage();
			case ServerMessageType.GAME_STATE_DATA:
				return new GameStateDataMessage();
			case ServerMessageType.HOME_SERVER_COMMAND_ALLOWED:
				return new HomeServerCommandAllowedMessage();
			case ServerMessageType.INITIALIZE_LIVE_REPLAY:
				return new InitializeLiveReplayMessage();
			case ServerMessageType.LEAVE_ALLIANCE_MEMBER:
				return new LeaveAllianceMemberMessage();
			case ServerMessageType.LEADERBOARD_REQUEST:
				return new LeaderboardRequestMessage();
			case ServerMessageType.LEADERBOARD_RESPONSE:
				return new LeaderboardResponseMessage();
			case ServerMessageType.LIVE_REPLAY_ADD_SPECTATOR_REQUEST:
				return new LiveReplayAddSpectatorRequestMessage();
			case ServerMessageType.LIVE_REPLAY_ADD_SPECTATOR_RESPONSE:
				return new LiveReplayAddSpectatorResponseMessage();
			case ServerMessageType.LIVE_REPLAY_REMOVE_SPECTATOR:
				return new LiveReplayRemoveSpectatorMessage();
			case ServerMessageType.LOAD_AVATAR_STREAM_OF_TYPE_REQUEST:
				return new LoadAvatarStreamOfTypeRequestMessage();
			case ServerMessageType.LOAD_AVATAR_STREAM_OF_TYPE_RESPONSE:
				return new LoadAvatarStreamOfTypeResponseMessage();
			case ServerMessageType.LOAD_AVATAR_STREAM_REQUEST:
				return new LoadAvatarStreamRequestMessage();
			case ServerMessageType.LOAD_AVATAR_STREAM_RESPONSE:
				return new LoadAvatarStreamResponseMessage();
			case ServerMessageType.LOAD_REPLAY_STREAM_REQUEST:
				return new LoadReplayStreamRequestMessage();
			case ServerMessageType.LOAD_REPLAY_STREAM_RESPONSE:
				return new LoadReplayStreamResponseMessage();
			case ServerMessageType.LOAD_VILLAGE2_ATTACK_ENTRY_REQUEST:
				return new LoadVillage2AttackEntryRequestMessage();
			case ServerMessageType.LOAD_VILLAGE2_ATTACK_ENTRY_RESPONSE:
				return new LoadVillage2AttackEntryResponseMessage();
			case ServerMessageType.PING:
				return new PingMessage();
			case ServerMessageType.PONG:
				return new PongMessage();
			case ServerMessageType.REMOVE_AVATAR_STREAM:
				return new RemoveAvatarStreamMessage();
			case ServerMessageType.REMOVE_VILLAGE2_ATTACK_ENTRY:
				return new RemoveVillage2AttackEntryMessage();
			case ServerMessageType.REQUEST_ALLIANCE_JOIN_REQUEST:
				return new RequestAllianceJoinRequestMessage();
			case ServerMessageType.REQUEST_ALLIANCE_JOIN_RESPONSE:
				return new RequestAllianceJoinResponseMessage();
			case ServerMessageType.SCORING_SYNC:
				return new ScoringSyncMessage();
			case ServerMessageType.SEND_ALLIANCE_BOOKMARKS_FULL_DATA_TO_CLIENT:
				return new SendAllianceBookmarksFullDataToClientMessage();
			case ServerMessageType.SEND_AVATAR_STREAMS_TO_CLIENT:
				return new SendAvatarStreamsToClientMessage();
			case ServerMessageType.SEND_VILLAGE2_ATTACK_ENTRY_LIST_TO_CLIENT:
				return new SendVillage2AttackEntryListToClientMessage();
			case ServerMessageType.SERVER_LOG:
				return new ServerLogMessage();
			case ServerMessageType.SERVER_PERFORMANCE:
				return new ServerPerformanceMessage();
			case ServerMessageType.SERVER_PERFORMANCE_DATA:
				return new ServerPerformanceDataMessage();
			case ServerMessageType.SERVER_STATUS:
				return new ServerStatusMessage();
			case ServerMessageType.SERVER_UPDATE_LIVE_REPLAY:
				return new ServerUpdateLiveReplayMessage();
			case ServerMessageType.START_SERVER_SESSION:
				return new StartServerSessionMessage();
			case ServerMessageType.STOP_SERVER_SESSION:
				return new StopServerSessionMessage();
			case ServerMessageType.STOP_SESSION:
				return new StopSessionMessage();
			case ServerMessageType.STOP_SPECIFIED_SERVER_SESSION:
				return new StopSpecifiedServerSessionMessage();
			case ServerMessageType.UPDATE_AVATAR_STREAM:
				return new UpdateAvatarStreamMessage();
			case ServerMessageType.UPDATE_RESOURCE_SETTINGS:
				return new UpdateResourceSettingsMessage();
			case ServerMessageType.UPDATE_SOCKET_SERVER_SESSION:
				return new UpdateSocketServerSessionMessage();
			case ServerMessageType.UPDATE_VILLAGE2_ATTACK_ENTRY:
				return new UpdateVillage2AttackEntryMessage();
			}
			return null;
		}
	}
}
