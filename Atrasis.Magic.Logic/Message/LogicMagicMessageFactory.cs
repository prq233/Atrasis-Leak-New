using System;
using Atrasis.Magic.Logic.Message.Account;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Logic.Message.Alliance.Stream;
using Atrasis.Magic.Logic.Message.Alliance.War;
using Atrasis.Magic.Logic.Message.Avatar;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Logic.Message.Battle;
using Atrasis.Magic.Logic.Message.Chat;
using Atrasis.Magic.Logic.Message.Facebook;
using Atrasis.Magic.Logic.Message.Friend;
using Atrasis.Magic.Logic.Message.Google;
using Atrasis.Magic.Logic.Message.Home;
using Atrasis.Magic.Logic.Message.League;
using Atrasis.Magic.Logic.Message.Scoring;
using Atrasis.Magic.Logic.Message.Security;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Message.Security;

namespace Atrasis.Magic.Logic.Message
{
	// Token: 0x02000028 RID: 40
	public class LogicMagicMessageFactory : LogicMessageFactory
	{
		// Token: 0x060001CD RID: 461 RVA: 0x00019B14 File Offset: 0x00017D14
		public override PiranhaMessage CreateMessageByType(int type)
		{
			PiranhaMessage result = null;
			if (type < 20000)
			{
				if (type <= 14134)
				{
					if (type <= 10507)
					{
						if (type <= 10121)
						{
							switch (type)
							{
							case 10099:
								result = new ClientCryptoErrorMessage();
								break;
							case 10100:
								result = new ClientHelloMessage();
								break;
							case 10101:
								result = new LoginMessage();
								break;
							default:
								if (type != 10108)
								{
									switch (type)
									{
									case 10113:
										result = new SetDeviceTokenMessage();
										break;
									case 10116:
										result = new ResetAccountMessage();
										break;
									case 10117:
										result = new ReportUserMessage();
										break;
									case 10118:
										result = new AccountSwitchedMessage();
										break;
									case 10121:
										result = new UnlockAccountMessage();
										break;
									}
								}
								else
								{
									result = new KeepAliveMessage();
								}
								break;
							}
						}
						else if (type != 10150)
						{
							if (type != 10212)
							{
								switch (type)
								{
								case 10501:
									result = new AcceptFriendMessage();
									break;
								case 10502:
									result = new AddFriendMessage();
									break;
								case 10504:
									result = new AskForFriendListMessage();
									break;
								case 10506:
									result = new RemoveFriendMessage();
									break;
								case 10507:
									result = new StartFriendLiveSpectateMessage();
									break;
								}
							}
							else
							{
								result = new ChangeAvatarNameMessage();
							}
						}
						else
						{
							result = new AppleBillingRequestMessage();
						}
					}
					else if (type <= 14120)
					{
						if (type != 10905)
						{
							switch (type)
							{
							case 14101:
								result = new GoHomeMessage();
								break;
							case 14102:
								result = new EndClientTurnMessage();
								break;
							case 14103:
								result = new CancelMatchmakingMessage();
								break;
							case 14104:
							case 14105:
							case 14107:
							case 14108:
							case 14109:
							case 14112:
								break;
							case 14106:
								result = new AttackHomeMessage();
								break;
							case 14110:
								result = new StartFriendlyChallengeSpectateMessage();
								break;
							case 14111:
								result = new ScoutFriendlyBattleMessage();
								break;
							case 14113:
								result = new VisitHomeMessage();
								break;
							case 14114:
								result = new HomeBattleReplayMessage();
								break;
							default:
								if (type == 14120)
								{
									result = new AcceptFriendlyBattleMessage();
								}
								break;
							}
						}
						else
						{
							result = new InboxOpenedMessage();
						}
					}
					else if (type != 14123)
					{
						if (type != 14125)
						{
							if (type == 14134)
							{
								result = new AttackNpcMessage();
							}
						}
						else
						{
							result = new CancelChallengeMessage();
						}
					}
					else
					{
						result = new AttackMatchedHomeMessage();
					}
				}
				else if (type <= 14344)
				{
					if (type <= 14211)
					{
						if (type != 14135)
						{
							if (type != 14201)
							{
								if (type == 14211)
								{
									result = new UnbindFacebookAccountMessage();
								}
							}
							else
							{
								result = new BindFacebookAccountMessage();
							}
						}
						else
						{
							result = new DuelNpcMessage();
						}
					}
					else if (type != 14262)
					{
						switch (type)
						{
						case 14301:
							result = new CreateAllianceMessage();
							break;
						case 14302:
							result = new AskForAllianceDataMessage();
							break;
						case 14303:
							result = new AskForJoinableAlliancesListMessage();
							break;
						case 14304:
						case 14307:
						case 14309:
						case 14311:
						case 14312:
						case 14313:
						case 14314:
						case 14318:
						case 14319:
						case 14320:
							break;
						case 14305:
							result = new JoinAllianceMessage();
							break;
						case 14306:
							result = new ChangeAllianceMemberRoleMessage();
							break;
						case 14308:
							result = new LeaveAllianceMessage();
							break;
						case 14310:
							result = new DonateAllianceUnitMessage();
							break;
						case 14315:
							result = new ChatToAllianceStreamMessage();
							break;
						case 14316:
							result = new ChangeAllianceSettingsMessage();
							break;
						case 14317:
							result = new RequestJoinAllianceMessage();
							break;
						case 14321:
							result = new RespondToAllianceJoinRequestMessage();
							break;
						case 14322:
							result = new SendAllianceInvitationMessage();
							break;
						case 14323:
							result = new JoinAllianceUsingInvitationMessage();
							break;
						case 14324:
							result = new SearchAlliancesMessage();
							break;
						case 14325:
							result = new AskForAvatarProfileMessage();
							break;
						default:
							switch (type)
							{
							case 14341:
								result = new AskForAllianceBookmarksFullDataMessage();
								break;
							case 14343:
								result = new AddAllianceBookmarkMessage();
								break;
							case 14344:
								result = new RemoveAllianceBookmarkMessage();
								break;
							}
							break;
						}
					}
					else
					{
						result = new BindGoogleServiceAccountMessage();
					}
				}
				else if (type <= 14503)
				{
					switch (type)
					{
					case 14401:
						result = new AskForAllianceRankingListMessage();
						break;
					case 14402:
					case 14405:
						break;
					case 14403:
						result = new AskForAvatarRankingListMessage();
						break;
					case 14404:
						result = new AskForAvatarLocalRankingListMessage();
						break;
					case 14406:
						result = new AskForAvatarLastSeasonRankingListMessage();
						break;
					case 14407:
						result = new ClaimDiamondsStreamEntryMessage();
						break;
					case 14408:
						result = new AskForAvatarDuelLastSeasonRankingListMessage();
						break;
					default:
						if (type != 14418)
						{
							if (type == 14503)
							{
								result = new AskForLeagueMemberListMessage();
							}
						}
						else
						{
							result = new RemoveAvatarStreamEntryMessage();
						}
						break;
					}
				}
				else if (type <= 14600)
				{
					if (type != 14510)
					{
						if (type == 14600)
						{
							result = new AvatarNameCheckRequestMessage();
						}
					}
					else
					{
						result = new BattleEndClientTurnMessage();
					}
				}
				else if (type != 14715)
				{
					if (type == 15110)
					{
						result = new Village2AttackStartSpectateMessage();
					}
				}
				else
				{
					result = new SendGlobalChatLineMessage();
				}
			}
			else if (type <= 24133)
			{
				if (type <= 20151)
				{
					if (type <= 20117)
					{
						if (type != 20000)
						{
							switch (type)
							{
							case 20100:
								result = new ServerHelloMessage();
								break;
							case 20101:
							case 20102:
							case 20107:
							case 20109:
							case 20110:
							case 20111:
								break;
							case 20103:
								result = new LoginFailedMessage();
								break;
							case 20104:
								result = new LoginOkMessage();
								break;
							case 20105:
								result = new FriendListMessage();
								break;
							case 20106:
								result = new FriendListUpdateMessage();
								break;
							case 20108:
								result = new KeepAliveServerMessage();
								break;
							case 20112:
								result = new AddFriendErrorMessage();
								break;
							default:
								if (type == 20117)
								{
									result = new ReportUserStatusMessage();
								}
								break;
							}
						}
						else
						{
							result = new ExtendedSetEncryptionMessage();
						}
					}
					else if (type <= 20132)
					{
						if (type != 20118)
						{
							if (type == 20132)
							{
								result = new UnlockAccountOkMessage();
							}
						}
						else
						{
							result = new ChatAccountBanStatusMessage();
						}
					}
					else if (type != 20133)
					{
						if (type == 20151)
						{
							result = new AppleBillingProcessedByServerMessage();
						}
					}
					else
					{
						result = new UnlockAccountFailedMessage();
					}
				}
				else if (type <= 20208)
				{
					if (type != 20161)
					{
						if (type != 20171)
						{
							switch (type)
							{
							case 20205:
								result = new AvatarNameChangeFailedMessage();
								break;
							case 20206:
								result = new AvatarOnlineStatusUpdated();
								break;
							case 20207:
								result = new AllianceOnlineStatusUpdatedMessage();
								break;
							case 20208:
								result = new AvatarOnlineStatusListMessage();
								break;
							}
						}
						else
						{
							result = new PersonalBreakStartedMessage();
						}
					}
					else
					{
						result = new ShutdownStartedMessage();
					}
				}
				else if (type <= 20300)
				{
					if (type != 20261)
					{
						if (type == 20300)
						{
							result = new AvatarNameCheckResponseMessage();
						}
					}
					else
					{
						result = new GoogleServiceAccountBoundMessage();
					}
				}
				else if (type != 20501)
				{
					switch (type)
					{
					case 24101:
						result = new OwnHomeDataMessage();
						break;
					case 24103:
						result = new AttackHomeFailedMessage();
						break;
					case 24104:
						result = new OutOfSyncMessage();
						break;
					case 24107:
						result = new EnemyHomeDataMessage();
						break;
					case 24111:
						result = new AvailableServerCommandMessage();
						break;
					case 24112:
						result = new WaitingToGoHomeMessage();
						break;
					case 24113:
						result = new VisitedHomeDataMessage();
						break;
					case 24114:
						result = new HomeBattleReplayDataMessage();
						break;
					case 24115:
						result = new ServerErrorMessage();
						break;
					case 24116:
						result = new HomeBattleReplayFailedMessage();
						break;
					case 24117:
						result = new LiveReplayFailedMessage();
						break;
					case 24118:
						result = new LiveReplayHeaderMessage();
						break;
					case 24119:
						result = new LiveReplayDataMessage();
						break;
					case 24121:
						result = new ChallengeFailedMessage();
						break;
					case 24122:
						result = new VisitFailedMessage();
						break;
					case 24125:
						result = new AttackSpectatorCountMessage();
						break;
					case 24126:
						result = new LiveReplayEndMessage();
						break;
					case 24133:
						result = new NpcDataMessage();
						break;
					}
				}
				else
				{
					result = new AcceptFriendErrorMessage();
				}
			}
			else if (type <= 24503)
			{
				if (type <= 24262)
				{
					if (type != 24201)
					{
						if (type != 24214)
						{
							if (type == 24262)
							{
								result = new GoogleServiceAccountAlreadyBoundMessage();
							}
						}
						else
						{
							result = new FacebookAccountUnboundMessage();
						}
					}
					else
					{
						result = new FacebookAccountBoundMessage();
					}
				}
				else if (type <= 24373)
				{
					switch (type)
					{
					case 24301:
						result = new AllianceDataMessage();
						break;
					case 24302:
						result = new AllianceJoinFailedMessage();
						break;
					case 24303:
					case 24305:
					case 24306:
					case 24307:
					case 24313:
					case 24314:
					case 24315:
					case 24316:
					case 24317:
					case 24323:
					case 24326:
					case 24327:
					case 24328:
					case 24330:
					case 24331:
					case 24333:
					case 24336:
						break;
					case 24304:
						result = new JoinableAllianceListMessage();
						break;
					case 24308:
						result = new AllianceMemberMessage();
						break;
					case 24309:
						result = new AllianceMemberRemovedMessage();
						break;
					case 24310:
						result = new AllianceListMessage();
						break;
					case 24311:
						result = new AllianceStreamMessage();
						break;
					case 24312:
						result = new AllianceStreamEntryMessage();
						break;
					case 24318:
						result = new AllianceStreamEntryRemovedMessage();
						break;
					case 24319:
						result = new AllianceJoinRequestOkMessage();
						break;
					case 24320:
						result = new AllianceJoinRequestFailedMessage();
						break;
					case 24321:
						result = new AllianceInvitationSendFailedMessage();
						break;
					case 24322:
						result = new AllianceInvitationSentOkMessage();
						break;
					case 24324:
						result = new AllianceFullEntryUpdateMessage();
						break;
					case 24325:
						result = new AllianceWarSearchDataMessage();
						break;
					case 24329:
						result = new AllianceWarDataMessage();
						break;
					case 24332:
						result = new AllianceCreateFailedMessage();
						break;
					case 24334:
						result = new AvatarProfileMessage();
						break;
					case 24335:
						result = new AllianceWarFullEntryMessage();
						break;
					case 24337:
						result = new AllianceWarDataFailedMessage();
						break;
					case 24338:
						result = new AllianceWarHistoryMessage();
						break;
					case 24339:
						result = new AvatarProfileFailedMessage();
						break;
					case 24340:
						result = new BookmarksListMessage();
						break;
					case 24341:
						result = new AllianceBookmarksFullDataMessage();
						break;
					default:
						switch (type)
						{
						case 24370:
							result = new Village2AttackEntryListMessage();
							break;
						case 24371:
							result = new Village2AttackEntryUpdateMessage();
							break;
						case 24372:
							result = new Village2AttackEntryAddedMessage();
							break;
						case 24373:
							result = new Village2AttackEntryRemovedMessage();
							break;
						}
						break;
					}
				}
				else
				{
					switch (type)
					{
					case 24401:
						result = new AllianceRankingListMessage();
						break;
					case 24402:
						result = new AllianceLocalRankingListMessage();
						break;
					case 24403:
						result = new AvatarRankingListMessage();
						break;
					case 24404:
						result = new AvatarLocalRankingListMessage();
						break;
					case 24405:
						result = new AvatarLastSeasonRankingListMessage();
						break;
					case 24406:
					case 24410:
					case 24413:
					case 24414:
					case 24415:
					case 24416:
					case 24417:
						break;
					case 24407:
						result = new AvatarDuelLocalRankingListMessage();
						break;
					case 24408:
						result = new AvatarDuelLastSeasonRankingListMessage();
						break;
					case 24409:
						result = new AvatarDuelRankingListMessage();
						break;
					case 24411:
						result = new AvatarStreamMessage();
						break;
					case 24412:
						result = new AvatarStreamEntryMessage();
						break;
					case 24418:
						result = new AvatarStreamEntryRemovedMessage();
						break;
					default:
						if (type == 24503)
						{
							result = new LeagueMemberListMessage();
						}
						break;
					}
				}
			}
			else if (type <= 25007)
			{
				if (type != 24715)
				{
					if (type != 25006)
					{
						if (type == 25007)
						{
							result = new FriendlyScoutHomeDataMessage();
						}
					}
					else
					{
						result = new AllianceWarEventMessage();
					}
				}
				else
				{
					result = new GlobalChatLineMessage();
				}
			}
			else if (type <= 25027)
			{
				if (type != 25023)
				{
					if (type == 25027)
					{
						result = new AttackEventMessage();
					}
				}
				else
				{
					result = new Village2AttackAvatarDataMessage();
				}
			}
			else if (type != 25892)
			{
				if (type == 29997)
				{
					result = new CryptoErrorMessage();
				}
			}
			else
			{
				result = new DisconnectedMessage();
			}
			return result;
		}

		// Token: 0x040000A3 RID: 163
		public static readonly LogicMessageFactory Instance = new LogicMagicMessageFactory();
	}
}
