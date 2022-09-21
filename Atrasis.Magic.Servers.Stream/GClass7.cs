using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Message;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Logic.Message.Alliance.Stream;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Helper;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Core;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Request.Stream;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Message.Session.Change;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x0200000C RID: 12
	public class GClass7 : ServerMessageManager
	{
		// Token: 0x06000031 RID: 49 RVA: 0x0000382C File Offset: 0x00001A2C
		public override void OnReceiveAccountMessage(ServerAccountMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType <= ServerMessageType.REMOVE_AVATAR_STREAM)
			{
				switch (messageType)
				{
				case ServerMessageType.ALLIANCE_AVATAR_CHANGES:
					GClass7.smethod_5((AllianceAvatarChangesMessage)message);
					return;
				case ServerMessageType.ALLIANCE_CHALLENGE_LIVE_REPLAY_ID:
					GClass7.smethod_14((AllianceChallengeLiveReplayIdMessage)message);
					return;
				case ServerMessageType.ALLIANCE_CHALLENGE_REPORT:
					GClass7.smethod_13((AllianceChallengeReportMessage)message);
					return;
				case ServerMessageType.ALLIANCE_CHALLENGE_REQUEST:
					GClass7.smethod_12((AllianceChallengeRequestMessage)message);
					return;
				case ServerMessageType.ALLIANCE_CHALLENGE_SPECTATOR_COUNT:
					GClass7.smethod_15((AllianceChallengeSpectatorCountMessage)message);
					return;
				case ServerMessageType.ALLIANCE_CREATE_MAIL:
					GClass7.smethod_6((AllianceCreateMailMessage)message);
					return;
				case ServerMessageType.ALLIANCE_JOIN_REQUEST:
				case ServerMessageType.ALLIANCE_JOIN_RESPONSE:
				case ServerMessageType.ALLIANCE_LEAVED:
				case ServerMessageType.ASK_FOR_SERVER_STATUS:
				case ServerMessageType.AVATAR_REQUEST:
				case ServerMessageType.AVATAR_RESPONSE:
					break;
				case ServerMessageType.ALLIANCE_KICK_MEMBER:
					GClass7.smethod_16((AllianceKickMemberMessage)message);
					break;
				case ServerMessageType.ALLIANCE_REQUEST_ALLIANCE_UNITS:
					GClass7.smethod_10((AllianceRequestAllianceUnitsMessage)message);
					return;
				case ServerMessageType.ALLIANCE_SHARE_DUEL_REPLAY:
					GClass7.smethod_9((AllianceShareDuelReplayMessage)message);
					return;
				case ServerMessageType.ALLIANCE_SHARE_REPLAY:
					GClass7.smethod_8((AllianceShareReplayMessage)message);
					return;
				case ServerMessageType.ALLIANCE_UNIT_DONATE_RESPONSE:
					GClass7.smethod_11((AllianceUnitDonateResponseMessage)message);
					return;
				case ServerMessageType.AVATAR_STREAM_SEEN:
					GClass7.smethod_7((AvatarStreamSeenMessage)message);
					return;
				default:
					if (messageType == ServerMessageType.LEAVE_ALLIANCE_MEMBER)
					{
						GClass7.smethod_4((LeaveAllianceMemberMessage)message);
						return;
					}
					if (messageType != ServerMessageType.REMOVE_AVATAR_STREAM)
					{
						return;
					}
					GClass7.smethod_0((RemoveAvatarStreamMessage)message);
					return;
				}
				return;
			}
			if (messageType == ServerMessageType.REMOVE_VILLAGE2_ATTACK_ENTRY)
			{
				GClass7.smethod_1((RemoveVillage2AttackEntryMessage)message);
				return;
			}
			if (messageType == ServerMessageType.UPDATE_AVATAR_STREAM)
			{
				GClass7.smethod_2((UpdateAvatarStreamMessage)message);
				return;
			}
			if (messageType != ServerMessageType.UPDATE_VILLAGE2_ATTACK_ENTRY)
			{
				return;
			}
			GClass7.smethod_3((UpdateVillage2AttackEntryMessage)message);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000021AB File Offset: 0x000003AB
		private static void smethod_0(RemoveAvatarStreamMessage removeAvatarStreamMessage_0)
		{
			GClass10.smethod_16(removeAvatarStreamMessage_0.AccountId);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000021AB File Offset: 0x000003AB
		private static void smethod_1(RemoveVillage2AttackEntryMessage removeVillage2AttackEntryMessage_0)
		{
			GClass10.smethod_16(removeVillage2AttackEntryMessage_0.AccountId);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000021B8 File Offset: 0x000003B8
		private static void smethod_2(UpdateAvatarStreamMessage updateAvatarStreamMessage_0)
		{
			GClass10.smethod_13(updateAvatarStreamMessage_0.Entry);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000021C5 File Offset: 0x000003C5
		private static void smethod_3(UpdateVillage2AttackEntryMessage updateVillage2AttackEntryMessage_0)
		{
			GClass10.smethod_14(updateVillage2AttackEntryMessage_0.Entry);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003998 File Offset: 0x00001B98
		private static void smethod_4(LeaveAllianceMemberMessage leaveAllianceMemberMessage_0)
		{
			GClass8 gclass;
			AllianceMemberEntry allianceMemberEntry;
			if (GClass9.smethod_3(leaveAllianceMemberMessage_0.AccountId, out gclass) && gclass.Members.TryGetValue(leaveAllianceMemberMessage_0.MemberId, out allianceMemberEntry))
			{
				if (allianceMemberEntry.GetAllianceRole() == LogicAvatarAllianceRole.LEADER)
				{
					AllianceMemberEntry allianceMemberEntry2 = null;
					LogicAvatarAllianceRole role = (LogicAvatarAllianceRole)0;
					foreach (AllianceMemberEntry allianceMemberEntry3 in gclass.Members.Values)
					{
						if (allianceMemberEntry3 != allianceMemberEntry && (allianceMemberEntry2 == null || !allianceMemberEntry3.HasLowerRoleThan(role)))
						{
							allianceMemberEntry2 = allianceMemberEntry3;
							role = allianceMemberEntry3.GetAllianceRole();
						}
					}
					if (allianceMemberEntry2 != null)
					{
						gclass.method_7(allianceMemberEntry2, LogicAvatarAllianceRole.LEADER, allianceMemberEntry.GetAvatarId(), allianceMemberEntry.GetName());
					}
				}
				gclass.method_1(leaveAllianceMemberMessage_0.MemberId);
				GClass4 gclass2 = gclass.method_6(leaveAllianceMemberMessage_0.AccountId);
				if (gclass2 != null)
				{
					GClass5.smethod_5(gclass2.Id);
				}
				AllianceEventStreamEntry allianceEventStreamEntry = new AllianceEventStreamEntry();
				GClass3.smethod_0(allianceEventStreamEntry, allianceMemberEntry);
				allianceEventStreamEntry.SetEventType(AllianceEventStreamEntryType.LEFT);
				allianceEventStreamEntry.SetEventAvatarId(allianceMemberEntry.GetAvatarId());
				allianceEventStreamEntry.SetEventAvatarName(allianceMemberEntry.GetName());
				GClass10.smethod_7(gclass.Id, allianceEventStreamEntry);
				gclass.method_13(allianceEventStreamEntry);
				GClass9.smethod_5(gclass);
			}
			ServerMessageManager.SendMessage(new AllianceLeavedMessage
			{
				AccountId = leaveAllianceMemberMessage_0.MemberId,
				AllianceId = leaveAllianceMemberMessage_0.AccountId
			}, 9);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003AF8 File Offset: 0x00001CF8
		private static void smethod_5(AllianceAvatarChangesMessage allianceAvatarChangesMessage_0)
		{
			GClass8 gclass;
			AllianceMemberEntry memberEntry;
			if (GClass9.smethod_3(allianceAvatarChangesMessage_0.AccountId, out gclass) && gclass.Members.TryGetValue(allianceAvatarChangesMessage_0.MemberId, out memberEntry))
			{
				bool flag = false;
				for (int i = 0; i < allianceAvatarChangesMessage_0.AvatarChanges.Size(); i++)
				{
					AvatarChange avatarChange = allianceAvatarChangesMessage_0.AvatarChanges[i];
					avatarChange.ApplyAvatarChange(memberEntry);
					if (avatarChange.GetAvatarChangeType() == AvatarChangeType.SCORE || avatarChange.GetAvatarChangeType() == AvatarChangeType.DUEL_SCORE)
					{
						flag = true;
					}
				}
				GClass4 gclass2 = gclass.method_6(allianceAvatarChangesMessage_0.MemberId);
				if (gclass2 != null && gclass2.method_3() != null)
				{
					for (int j = 0; j < allianceAvatarChangesMessage_0.AvatarChanges.Size(); j++)
					{
						allianceAvatarChangesMessage_0.AvatarChanges[j].ApplyAvatarChange(gclass2.method_3());
					}
				}
				if (flag)
				{
					gclass.method_8();
				}
				GClass9.smethod_5(gclass);
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003BD8 File Offset: 0x00001DD8
		private static void smethod_6(AllianceCreateMailMessage allianceCreateMailMessage_0)
		{
			GClass8 gclass;
			AllianceMemberEntry allianceMemberEntry;
			if (GClass9.smethod_3(allianceCreateMailMessage_0.AccountId, out gclass) && gclass.Members.TryGetValue(allianceCreateMailMessage_0.MemberId, out allianceMemberEntry))
			{
				AllianceMailAvatarStreamEntry allianceMailAvatarStreamEntry = new AllianceMailAvatarStreamEntry();
				allianceMailAvatarStreamEntry.SetSenderAvatarId(allianceMemberEntry.GetAvatarId());
				allianceMailAvatarStreamEntry.SetSenderHomeId(allianceMemberEntry.GetHomeId());
				allianceMailAvatarStreamEntry.SetSenderName(allianceMemberEntry.GetName());
				allianceMailAvatarStreamEntry.SetSenderLevel(allianceMemberEntry.GetExpLevel());
				allianceMailAvatarStreamEntry.SetSenderLeagueType(allianceMemberEntry.GetLeagueType());
				allianceMailAvatarStreamEntry.SetMessage(allianceCreateMailMessage_0.Message);
				allianceMailAvatarStreamEntry.SetAllianceId(gclass.Id);
				allianceMailAvatarStreamEntry.SetAllianceName(gclass.Header.GetAllianceName());
				allianceMailAvatarStreamEntry.SetAllianceBadgeId(gclass.Header.GetAllianceBadgeId());
				foreach (AllianceMemberEntry allianceMemberEntry2 in gclass.Members.Values)
				{
					ServerMessageManager.SendMessage(new CreateAvatarStreamMessage
					{
						AccountId = allianceMemberEntry2.GetAvatarId(),
						Entry = allianceMailAvatarStreamEntry
					}, 9);
				}
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003CF8 File Offset: 0x00001EF8
		private static void smethod_7(AvatarStreamSeenMessage avatarStreamSeenMessage_0)
		{
			AvatarStreamEntry avatarStreamEntry = GClass10.smethod_4(avatarStreamSeenMessage_0.AccountId);
			if (avatarStreamEntry != null && avatarStreamEntry.IsNew())
			{
				avatarStreamEntry.SetNew(false);
				GClass10.smethod_13(avatarStreamEntry);
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003D2C File Offset: 0x00001F2C
		private static void smethod_8(AllianceShareReplayMessage allianceShareReplayMessage_0)
		{
			GClass7.Class3 @class = new GClass7.Class3();
			@class.allianceShareReplayMessage_0 = allianceShareReplayMessage_0;
			if (GClass9.smethod_3(@class.allianceShareReplayMessage_0.AccountId, out @class.gclass8_0) && @class.gclass8_0.Members.TryGetValue(@class.allianceShareReplayMessage_0.MemberId, out @class.allianceMemberEntry_0))
			{
				ServerRequestManager.Create(new LoadAvatarStreamRequestMessage
				{
					Id = @class.allianceShareReplayMessage_0.ReplayId
				}, ServerManager.GetDocumentSocket(11, @class.allianceShareReplayMessage_0.MemberId), 30).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003DC8 File Offset: 0x00001FC8
		private static void smethod_9(AllianceShareDuelReplayMessage allianceShareDuelReplayMessage_0)
		{
			GClass7.Class4 @class = new GClass7.Class4();
			if (GClass9.smethod_3(allianceShareDuelReplayMessage_0.AccountId, out @class.gclass8_0) && @class.gclass8_0.Members.TryGetValue(allianceShareDuelReplayMessage_0.MemberId, out @class.allianceMemberEntry_0))
			{
				ServerRequestManager.Create(new LoadVillage2AttackEntryRequestMessage
				{
					Id = allianceShareDuelReplayMessage_0.ReplayId
				}, ServerManager.GetDocumentSocket(11, allianceShareDuelReplayMessage_0.MemberId), 30).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003E48 File Offset: 0x00002048
		private static void smethod_10(AllianceRequestAllianceUnitsMessage allianceRequestAllianceUnitsMessage_0)
		{
			GClass8 gclass;
			AllianceMemberEntry allianceMemberEntry;
			if (GClass9.smethod_3(allianceRequestAllianceUnitsMessage_0.AccountId, out gclass) && gclass.Members.TryGetValue(allianceRequestAllianceUnitsMessage_0.MemberId, out allianceMemberEntry))
			{
				for (int i = 0; i < gclass.StreamEntryList.Size(); i++)
				{
					StreamEntry streamEntry = GClass10.smethod_3(gclass.StreamEntryList[i]);
					if (streamEntry != null && streamEntry.GetStreamEntryType() == StreamEntryType.DONATE && streamEntry.GetSenderAvatarId().Equals(allianceMemberEntry.GetAvatarId()))
					{
						gclass.method_15(streamEntry.GetId());
					}
				}
				DonateStreamEntry donateStreamEntry = new DonateStreamEntry();
				GClass3.smethod_0(donateStreamEntry, allianceMemberEntry);
				string text = allianceRequestAllianceUnitsMessage_0.Message;
				if (text.Length > 128)
				{
					text = text.Substring(0, 128);
				}
				donateStreamEntry.SetMessage(text);
				donateStreamEntry.SetCasteLevel(allianceRequestAllianceUnitsMessage_0.CastleUpgradeLevel, allianceRequestAllianceUnitsMessage_0.CastleUsedCapacity, allianceRequestAllianceUnitsMessage_0.CastleSpellUsedCapacity, allianceRequestAllianceUnitsMessage_0.CastleTotalCapacity, allianceRequestAllianceUnitsMessage_0.CastleSpellTotalCapacity);
				GClass10.smethod_7(gclass.Id, donateStreamEntry);
				gclass.method_13(donateStreamEntry);
				GClass9.smethod_5(gclass);
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003F54 File Offset: 0x00002154
		private static void smethod_11(AllianceUnitDonateResponseMessage allianceUnitDonateResponseMessage_0)
		{
			GClass8 gclass;
			if (GClass9.smethod_3(allianceUnitDonateResponseMessage_0.AccountId, out gclass))
			{
				StreamEntry streamEntry = GClass10.smethod_3(allianceUnitDonateResponseMessage_0.StreamId);
				if (streamEntry != null)
				{
					DonateStreamEntry donateStreamEntry = (DonateStreamEntry)streamEntry;
					if (allianceUnitDonateResponseMessage_0.Success)
					{
						LogicAllianceLevelData allianceLevel = LogicDataTables.GetAllianceLevel(gclass.Header.GetAllianceLevel());
						LogicAllianceUnitReceivedCommand logicAllianceUnitReceivedCommand = new LogicAllianceUnitReceivedCommand();
						logicAllianceUnitReceivedCommand.SetData(allianceUnitDonateResponseMessage_0.MemberName, allianceUnitDonateResponseMessage_0.Data, LogicMath.Clamp(allianceUnitDonateResponseMessage_0.UpgradeLevel + allianceLevel.GetTroopDonationUpgrade(), 0, allianceUnitDonateResponseMessage_0.Data.GetUpgradeLevelCount() - 1));
						ServerMessageManager.SendMessage(new GameAllowServerCommandMessage
						{
							AccountId = donateStreamEntry.GetSenderAvatarId(),
							ServerCommand = logicAllianceUnitReceivedCommand
						}, 9);
						AllianceMemberEntry allianceMemberEntry;
						if (gclass.Members.TryGetValue(allianceUnitDonateResponseMessage_0.MemberId, out allianceMemberEntry))
						{
							allianceMemberEntry.SetDonations(allianceMemberEntry.GetDonations() + allianceUnitDonateResponseMessage_0.Data.GetHousingSpace());
							ServerMessageManager.SendMessage(new GameAllianceDonationCountMessage
							{
								AccountId = allianceUnitDonateResponseMessage_0.MemberId,
								DonationCount = allianceMemberEntry.GetDonations(),
								ReceivedDonationCount = allianceMemberEntry.GetReceivedDonations()
							}, 9);
						}
						AllianceMemberEntry allianceMemberEntry2;
						if (gclass.Members.TryGetValue(donateStreamEntry.GetSenderAvatarId(), out allianceMemberEntry2))
						{
							allianceMemberEntry2.SetReceivedDonations(allianceMemberEntry2.GetReceivedDonations() + allianceUnitDonateResponseMessage_0.Data.GetHousingSpace());
							ServerMessageManager.SendMessage(new GameAllianceDonationCountMessage
							{
								AccountId = donateStreamEntry.GetSenderAvatarId(),
								DonationCount = allianceMemberEntry2.GetDonations(),
								ReceivedDonationCount = allianceMemberEntry2.GetReceivedDonations()
							}, 9);
						}
					}
					else
					{
						donateStreamEntry.RemoveDonation(allianceUnitDonateResponseMessage_0.MemberId, allianceUnitDonateResponseMessage_0.Data, allianceUnitDonateResponseMessage_0.UpgradeLevel);
						gclass.method_14(donateStreamEntry);
					}
					donateStreamEntry.SetDonationPendingRequestCount(donateStreamEntry.GetDonationPendingRequestCount() - 1);
					if (donateStreamEntry.IsCastleFull() && donateStreamEntry.GetDonationPendingRequestCount() <= 0)
					{
						gclass.method_15(donateStreamEntry.GetId());
						GClass9.smethod_5(gclass);
						return;
					}
					GClass10.smethod_12(donateStreamEntry);
				}
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004128 File Offset: 0x00002328
		private static void smethod_12(AllianceChallengeRequestMessage allianceChallengeRequestMessage_0)
		{
			GClass8 gclass;
			AllianceMemberEntry allianceMemberEntry;
			if (GClass9.smethod_3(allianceChallengeRequestMessage_0.AccountId, out gclass) && gclass.Members.TryGetValue(allianceChallengeRequestMessage_0.MemberId, out allianceMemberEntry))
			{
				for (int i = 0; i < gclass.StreamEntryList.Size(); i++)
				{
					StreamEntry streamEntry = GClass10.smethod_3(gclass.StreamEntryList[i]);
					if (streamEntry != null && streamEntry.GetStreamEntryType() == StreamEntryType.CHALLENGE && streamEntry.GetSenderAvatarId().Equals(allianceMemberEntry.GetAvatarId()))
					{
						if (((ChallengeStreamEntry)streamEntry).IsStarted())
						{
							return;
						}
						gclass.method_15(streamEntry.GetId());
					}
				}
				ChallengeStreamEntry challengeStreamEntry = new ChallengeStreamEntry();
				GClass3.smethod_0(challengeStreamEntry, allianceMemberEntry);
				string text = allianceChallengeRequestMessage_0.Message;
				if (text.Length > 128)
				{
					text = text.Substring(0, 128);
				}
				challengeStreamEntry.SetMessage(text);
				challengeStreamEntry.SetSnapshotHomeJSON(allianceChallengeRequestMessage_0.HomeJSON);
				challengeStreamEntry.SetWarLayout(allianceChallengeRequestMessage_0.WarLayout);
				GClass10.smethod_7(gclass.Id, challengeStreamEntry);
				gclass.method_13(challengeStreamEntry);
				GClass9.smethod_5(gclass);
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000423C File Offset: 0x0000243C
		private static void smethod_13(AllianceChallengeReportMessage allianceChallengeReportMessage_0)
		{
			GClass8 gclass;
			if (GClass9.smethod_3(allianceChallengeReportMessage_0.AccountId, out gclass))
			{
				ChallengeStreamEntry challengeStreamEntry = (ChallengeStreamEntry)GClass10.smethod_3(allianceChallengeReportMessage_0.StreamId);
				if (challengeStreamEntry != null)
				{
					ChallengeReplayStreamEntry challengeReplayStreamEntry = new ChallengeReplayStreamEntry();
					challengeReplayStreamEntry.SetSenderAvatarId(challengeReplayStreamEntry.GetSenderAvatarId());
					challengeReplayStreamEntry.SetSenderHomeId(challengeReplayStreamEntry.GetSenderHomeId());
					challengeReplayStreamEntry.SetSenderName(challengeReplayStreamEntry.GetSenderName());
					challengeReplayStreamEntry.SetSenderLevel(challengeReplayStreamEntry.GetSenderLevel());
					challengeReplayStreamEntry.SetSenderLeagueType(challengeReplayStreamEntry.GetSenderLeagueType());
					challengeReplayStreamEntry.SetSenderRole(challengeReplayStreamEntry.GetSenderRole());
					challengeReplayStreamEntry.SetBattleLogJSON(allianceChallengeReportMessage_0.BattleLog);
					challengeReplayStreamEntry.SetReplayMajorVersion(9);
					challengeReplayStreamEntry.SetReplayBuildVersion(256);
					challengeReplayStreamEntry.SetReplayContentVersion(ResourceManager.GetContentVersion());
					challengeReplayStreamEntry.SetReplayId(allianceChallengeReportMessage_0.ReplayId);
					GClass10.smethod_7(gclass.Id, challengeReplayStreamEntry);
					gclass.method_15(challengeStreamEntry.GetId());
					gclass.method_13(challengeReplayStreamEntry);
					return;
				}
				Logging.Warning("StreamMessageManager.onAllianceChallengeReportMessageReceived: pStreamEntry has been deleted. Replay ignored.");
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00004320 File Offset: 0x00002520
		private static void smethod_14(AllianceChallengeLiveReplayIdMessage allianceChallengeLiveReplayIdMessage_0)
		{
			ChallengeStreamEntry challengeStreamEntry = (ChallengeStreamEntry)GClass10.smethod_3(allianceChallengeLiveReplayIdMessage_0.AccountId);
			if (challengeStreamEntry != null)
			{
				challengeStreamEntry.SetLiveReplayId(allianceChallengeLiveReplayIdMessage_0.LiveReplayId);
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00004350 File Offset: 0x00002550
		private static void smethod_15(AllianceChallengeSpectatorCountMessage allianceChallengeSpectatorCountMessage_0)
		{
			GClass8 gclass;
			if (GClass9.smethod_3(allianceChallengeSpectatorCountMessage_0.AccountId, out gclass))
			{
				ChallengeStreamEntry challengeStreamEntry = (ChallengeStreamEntry)GClass10.smethod_3(allianceChallengeSpectatorCountMessage_0.StreamId);
				if (challengeStreamEntry != null && challengeStreamEntry.GetSpectatorCount() != allianceChallengeSpectatorCountMessage_0.Count)
				{
					challengeStreamEntry.SetSpectatorCount(allianceChallengeSpectatorCountMessage_0.Count);
					gclass.method_14(challengeStreamEntry);
				}
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000043A4 File Offset: 0x000025A4
		private static void smethod_16(AllianceKickMemberMessage allianceKickMemberMessage_0)
		{
			GClass8 gclass;
			AllianceMemberEntry allianceMemberEntry;
			AllianceMemberEntry allianceMemberEntry2;
			if (GClass9.smethod_3(allianceKickMemberMessage_0.AccountId, out gclass) && gclass.Members.TryGetValue(allianceKickMemberMessage_0.MemberId, out allianceMemberEntry) && gclass.Members.TryGetValue(allianceKickMemberMessage_0.KickMemberId, out allianceMemberEntry2))
			{
				if (allianceMemberEntry.GetAllianceRole() == allianceMemberEntry2.GetAllianceRole() || allianceMemberEntry.HasLowerRoleThan(allianceMemberEntry2.GetAllianceRole()))
				{
					return;
				}
				AllianceEventStreamEntry allianceEventStreamEntry = new AllianceEventStreamEntry();
				GClass3.smethod_0(allianceEventStreamEntry, allianceMemberEntry2);
				allianceEventStreamEntry.SetEventType(AllianceEventStreamEntryType.KICKED);
				allianceEventStreamEntry.SetEventAvatarId(allianceMemberEntry.GetAvatarId());
				allianceEventStreamEntry.SetEventAvatarName(allianceMemberEntry.GetName());
				GClass10.smethod_7(gclass.Id, allianceEventStreamEntry);
				gclass.method_1(allianceKickMemberMessage_0.KickMemberId);
				gclass.method_2(allianceKickMemberMessage_0.KickMemberId);
				gclass.method_13(allianceEventStreamEntry);
				ServerMessageManager.SendMessage(new AllianceLeavedMessage
				{
					AccountId = allianceKickMemberMessage_0.KickMemberId,
					AllianceId = gclass.Id
				}, 9);
				GClass9.smethod_5(gclass);
				AllianceKickOutStreamEntry allianceKickOutStreamEntry = new AllianceKickOutStreamEntry();
				allianceKickOutStreamEntry.SetSenderAvatarId(allianceMemberEntry.GetAvatarId());
				allianceKickOutStreamEntry.SetSenderHomeId(allianceMemberEntry.GetHomeId());
				allianceKickOutStreamEntry.SetSenderName(allianceMemberEntry.GetName());
				allianceKickOutStreamEntry.SetSenderLevel(allianceMemberEntry.GetExpLevel());
				allianceKickOutStreamEntry.SetSenderLeagueType(allianceMemberEntry.GetLeagueType());
				string text = allianceKickMemberMessage_0.Message;
				if (text.Length > 128)
				{
					text = text.Substring(0, 128);
				}
				allianceKickOutStreamEntry.SetMessage(text);
				allianceKickOutStreamEntry.SetAllianceId(gclass.Id);
				allianceKickOutStreamEntry.SetAllianceName(gclass.Header.GetAllianceName());
				allianceKickOutStreamEntry.SetAllianceBadgeId(gclass.Header.GetAllianceBadgeId());
				ServerMessageManager.SendMessage(new CreateAvatarStreamMessage
				{
					AccountId = allianceKickMemberMessage_0.KickMemberId,
					Entry = allianceKickOutStreamEntry
				}, 9);
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000456C File Offset: 0x0000276C
		public override void OnReceiveRequestMessage(ServerRequestMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType > ServerMessageType.CREATE_ALLIANCE_REQUEST)
			{
				switch (messageType)
				{
				case ServerMessageType.CREATE_AVATAR_STREAM_REQUEST:
					GClass7.smethod_19((CreateAvatarStreamRequestMessage)message);
					return;
				case ServerMessageType.CREATE_AVATAR_STREAM_RESPONSE:
				case ServerMessageType.CREATE_REPLAY_STREAM_RESPONSE:
					break;
				case ServerMessageType.CREATE_REPLAY_STREAM_REQUEST:
					GClass7.smethod_20((CreateReplayStreamRequestMessage)message);
					return;
				case ServerMessageType.CREATE_VILLAGE2_ATTACK_ENTRY_REQUEST:
					GClass7.smethod_21((CreateVillage2AttackEntryRequestMessage)message);
					return;
				default:
					switch (messageType)
					{
					case ServerMessageType.LOAD_AVATAR_STREAM_OF_TYPE_REQUEST:
						GClass7.smethod_25((LoadAvatarStreamOfTypeRequestMessage)message);
						return;
					case ServerMessageType.LOAD_AVATAR_STREAM_OF_TYPE_RESPONSE:
					case ServerMessageType.LOAD_AVATAR_STREAM_RESPONSE:
					case ServerMessageType.LOAD_REPLAY_STREAM_RESPONSE:
						break;
					case ServerMessageType.LOAD_AVATAR_STREAM_REQUEST:
						GClass7.smethod_23((LoadAvatarStreamRequestMessage)message);
						return;
					case ServerMessageType.LOAD_REPLAY_STREAM_REQUEST:
						GClass7.smethod_22((LoadReplayStreamRequestMessage)message);
						return;
					case ServerMessageType.LOAD_VILLAGE2_ATTACK_ENTRY_REQUEST:
						GClass7.smethod_24((LoadVillage2AttackEntryRequestMessage)message);
						return;
					default:
						if (messageType != ServerMessageType.REQUEST_ALLIANCE_JOIN_REQUEST)
						{
							return;
						}
						GClass7.smethod_26((RequestAllianceJoinRequestMessage)message);
						break;
					}
					break;
				}
				return;
			}
			if (messageType == ServerMessageType.ALLIANCE_JOIN_REQUEST)
			{
				GClass7.smethod_18((AllianceJoinRequestMessage)message);
				return;
			}
			if (messageType != ServerMessageType.CREATE_ALLIANCE_REQUEST)
			{
				return;
			}
			GClass7.smethod_17((CreateAllianceRequestMessage)message);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00004664 File Offset: 0x00002864
		private static void smethod_17(CreateAllianceRequestMessage createAllianceRequestMessage_0)
		{
			CreateAllianceResponseMessage createAllianceResponseMessage = new CreateAllianceResponseMessage();
			string allianceName = createAllianceRequestMessage_0.AllianceName;
			if (allianceName == null || allianceName.Length < 2)
			{
				createAllianceResponseMessage.ErrorReason = CreateAllianceResponseMessage.Reason.NAME_TOO_SHORT;
				ServerRequestManager.SendResponse(createAllianceResponseMessage, createAllianceRequestMessage_0);
				return;
			}
			if (allianceName.Length > 15)
			{
				createAllianceResponseMessage.ErrorReason = CreateAllianceResponseMessage.Reason.NAME_TOO_LONG;
				ServerRequestManager.SendResponse(createAllianceResponseMessage, createAllianceRequestMessage_0);
				return;
			}
			GClass8 gclass = GClass9.smethod_4();
			gclass.Header.SetAllianceName(allianceName);
			gclass.method_26(createAllianceRequestMessage_0.AllianceDescription, createAllianceRequestMessage_0.AllianceType, createAllianceRequestMessage_0.AllianceBadgeId, createAllianceRequestMessage_0.RequiredScore, createAllianceRequestMessage_0.RequiredDuelScore, createAllianceRequestMessage_0.WarFrequency, createAllianceRequestMessage_0.OriginData, createAllianceRequestMessage_0.PublicWarLog, createAllianceRequestMessage_0.ArrangedWarEnabled);
			createAllianceResponseMessage.Success = true;
			createAllianceResponseMessage.AllianceId = gclass.Id;
			GClass9.smethod_5(gclass);
			ServerRequestManager.SendResponse(createAllianceResponseMessage, createAllianceRequestMessage_0);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00004728 File Offset: 0x00002928
		private static void smethod_18(AllianceJoinRequestMessage allianceJoinRequestMessage_0)
		{
			AllianceJoinResponseMessage allianceJoinResponseMessage = new AllianceJoinResponseMessage();
			GClass8 gclass;
			if (!GClass9.smethod_3(allianceJoinRequestMessage_0.AllianceId, out gclass))
			{
				allianceJoinResponseMessage.ErrorReason = AllianceJoinResponseMessage.Reason.GENERIC;
				ServerRequestManager.SendResponse(allianceJoinResponseMessage, allianceJoinRequestMessage_0);
				return;
			}
			if (!allianceJoinRequestMessage_0.Created)
			{
				if (gclass.IsFull())
				{
					allianceJoinResponseMessage.ErrorReason = AllianceJoinResponseMessage.Reason.FULL;
					ServerRequestManager.SendResponse(allianceJoinResponseMessage, allianceJoinRequestMessage_0);
					return;
				}
				if (!allianceJoinRequestMessage_0.Invited)
				{
					if (gclass.Header.GetAllianceType() != AllianceType.OPEN || gclass.Header.GetNumberOfMembers() == 0)
					{
						allianceJoinResponseMessage.ErrorReason = ((gclass.Header.GetAllianceType() == AllianceType.CLOSED) ? AllianceJoinResponseMessage.Reason.CLOSED : AllianceJoinResponseMessage.Reason.GENERIC);
						ServerRequestManager.SendResponse(allianceJoinResponseMessage, allianceJoinRequestMessage_0);
						return;
					}
					if (gclass.method_3(allianceJoinRequestMessage_0.Avatar.GetId()))
					{
						allianceJoinResponseMessage.ErrorReason = AllianceJoinResponseMessage.Reason.BANNED;
						ServerRequestManager.SendResponse(allianceJoinResponseMessage, allianceJoinRequestMessage_0);
						return;
					}
					if (gclass.Header.GetRequiredScore() > allianceJoinRequestMessage_0.Avatar.GetScore() || gclass.Header.GetRequiredDuelScore() > allianceJoinRequestMessage_0.Avatar.GetDuelScore())
					{
						allianceJoinResponseMessage.ErrorReason = AllianceJoinResponseMessage.Reason.SCORE;
						ServerRequestManager.SendResponse(allianceJoinResponseMessage, allianceJoinRequestMessage_0);
						return;
					}
				}
			}
			else if (gclass.Header.GetNumberOfMembers() != 0)
			{
				throw new Exception("StreamMessageManager.joinAllianceRequestMessageReceived: A new alliance must be empty!");
			}
			AllianceMemberEntry allianceMemberEntry = GClass2.smethod_0(allianceJoinRequestMessage_0.Avatar);
			allianceMemberEntry.SetAllianceRole(allianceJoinRequestMessage_0.Created ? LogicAvatarAllianceRole.LEADER : LogicAvatarAllianceRole.MEMBER);
			gclass.method_0(allianceMemberEntry);
			if (!allianceJoinRequestMessage_0.Created)
			{
				AllianceEventStreamEntry allianceEventStreamEntry = new AllianceEventStreamEntry();
				GClass3.smethod_0(allianceEventStreamEntry, allianceMemberEntry);
				allianceEventStreamEntry.SetEventType(AllianceEventStreamEntryType.JOINED);
				allianceEventStreamEntry.SetEventAvatarId(allianceMemberEntry.GetAvatarId());
				allianceEventStreamEntry.SetEventAvatarName(allianceMemberEntry.GetName());
				GClass10.smethod_7(gclass.Id, allianceEventStreamEntry);
				gclass.method_13(allianceEventStreamEntry);
			}
			allianceJoinResponseMessage.Success = true;
			allianceJoinResponseMessage.AllianceId = gclass.Id;
			allianceJoinResponseMessage.AllianceName = gclass.Header.GetAllianceName();
			allianceJoinResponseMessage.AllianceBadgeId = gclass.Header.GetAllianceBadgeId();
			allianceJoinResponseMessage.AllianceLevel = gclass.Header.GetAllianceLevel();
			allianceJoinResponseMessage.Created = allianceJoinRequestMessage_0.Created;
			GClass9.smethod_5(gclass);
			ServerRequestManager.SendResponse(allianceJoinResponseMessage, allianceJoinRequestMessage_0);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000021D2 File Offset: 0x000003D2
		private static void smethod_19(CreateAvatarStreamRequestMessage createAvatarStreamRequestMessage_0)
		{
			GClass10.smethod_8(createAvatarStreamRequestMessage_0.OwnerId, createAvatarStreamRequestMessage_0.Entry);
			ServerRequestManager.SendResponse(new CreateAvatarStreamResponseMessage
			{
				Success = true,
				Entry = createAvatarStreamRequestMessage_0.Entry
			}, createAvatarStreamRequestMessage_0);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00004908 File Offset: 0x00002B08
		private static void smethod_20(CreateReplayStreamRequestMessage createReplayStreamRequestMessage_0)
		{
			byte[] byte_;
			ZLibHelper.CompressInZLibFormat(LogicStringUtil.GetBytes(createReplayStreamRequestMessage_0.JSON), out byte_);
			LogicLong id;
			GClass10.smethod_9(byte_, out id);
			ServerRequestManager.SendResponse(new CreateReplayStreamResponseMessage
			{
				Success = true,
				Id = id
			}, createReplayStreamRequestMessage_0);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002203 File Offset: 0x00000403
		private static void smethod_21(CreateVillage2AttackEntryRequestMessage createVillage2AttackEntryRequestMessage_0)
		{
			GClass10.smethod_10(createVillage2AttackEntryRequestMessage_0.OwnerId, createVillage2AttackEntryRequestMessage_0.Entry);
			ServerRequestManager.SendResponse(new CreateVillage2AttackEntryResponseMessage
			{
				Success = true,
				Entry = createVillage2AttackEntryRequestMessage_0.Entry
			}, createVillage2AttackEntryRequestMessage_0);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000494C File Offset: 0x00002B4C
		private static void smethod_22(LoadReplayStreamRequestMessage loadReplayStreamRequestMessage_0)
		{
			Atrasis.Magic.Servers.Core.Database.Document.ReplayStreamEntry replayStreamEntry = GClass10.smethod_5(loadReplayStreamRequestMessage_0.Id);
			if (replayStreamEntry != null)
			{
				ServerRequestManager.SendResponse(new LoadReplayStreamResponseMessage
				{
					StreamData = replayStreamEntry.GetStreamData(),
					MajorVersion = replayStreamEntry.GetMajorVersion(),
					BuildVersion = replayStreamEntry.GetBuildVersion(),
					ContentVersion = replayStreamEntry.GetContentVersion(),
					Success = true
				}, loadReplayStreamRequestMessage_0);
				return;
			}
			ServerRequestManager.SendResponse(new LoadReplayStreamResponseMessage(), loadReplayStreamRequestMessage_0);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000049B8 File Offset: 0x00002BB8
		private static void smethod_23(LoadAvatarStreamRequestMessage loadAvatarStreamRequestMessage_0)
		{
			AvatarStreamEntry avatarStreamEntry = GClass10.smethod_4(loadAvatarStreamRequestMessage_0.Id);
			if (avatarStreamEntry != null)
			{
				ServerRequestManager.SendResponse(new LoadAvatarStreamResponseMessage
				{
					Entry = avatarStreamEntry,
					Success = true
				}, loadAvatarStreamRequestMessage_0);
				return;
			}
			ServerRequestManager.SendResponse(new LoadAvatarStreamResponseMessage(), loadAvatarStreamRequestMessage_0);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000049FC File Offset: 0x00002BFC
		private static void smethod_24(LoadVillage2AttackEntryRequestMessage loadVillage2AttackEntryRequestMessage_0)
		{
			Village2AttackEntry village2AttackEntry = GClass10.smethod_6(loadVillage2AttackEntryRequestMessage_0.Id);
			if (village2AttackEntry != null)
			{
				ServerRequestManager.SendResponse(new LoadVillage2AttackEntryResponseMessage
				{
					Entry = village2AttackEntry,
					Success = true
				}, loadVillage2AttackEntryRequestMessage_0);
				return;
			}
			ServerRequestManager.SendResponse(new LoadVillage2AttackEntryResponseMessage(), loadVillage2AttackEntryRequestMessage_0);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004A40 File Offset: 0x00002C40
		private static void smethod_25(LoadAvatarStreamOfTypeRequestMessage loadAvatarStreamOfTypeRequestMessage_0)
		{
			LoadAvatarStreamOfTypeResponseMessage loadAvatarStreamOfTypeResponseMessage = new LoadAvatarStreamOfTypeResponseMessage();
			LogicArrayList<AvatarStreamEntry> logicArrayList = new LogicArrayList<AvatarStreamEntry>(loadAvatarStreamOfTypeRequestMessage_0.StreamIds.Size());
			for (int i = 0; i < loadAvatarStreamOfTypeRequestMessage_0.StreamIds.Size(); i++)
			{
				AvatarStreamEntry avatarStreamEntry = GClass10.smethod_4(loadAvatarStreamOfTypeRequestMessage_0.StreamIds[i]);
				if (avatarStreamEntry != null && avatarStreamEntry.GetAvatarStreamEntryType() == loadAvatarStreamOfTypeRequestMessage_0.Type && (loadAvatarStreamOfTypeRequestMessage_0.SenderAvatarId == null || avatarStreamEntry.GetSenderAvatarId().Equals(loadAvatarStreamOfTypeRequestMessage_0.SenderAvatarId)))
				{
					logicArrayList.Add(avatarStreamEntry);
				}
			}
			loadAvatarStreamOfTypeResponseMessage.Success = true;
			loadAvatarStreamOfTypeResponseMessage.StreamList = logicArrayList;
			ServerRequestManager.SendResponse(loadAvatarStreamOfTypeResponseMessage, loadAvatarStreamOfTypeRequestMessage_0);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00004AD4 File Offset: 0x00002CD4
		private static void smethod_26(RequestAllianceJoinRequestMessage requestAllianceJoinRequestMessage_0)
		{
			GClass8 gclass;
			if (GClass9.smethod_3(requestAllianceJoinRequestMessage_0.AllianceId, out gclass))
			{
				LogicLong id = requestAllianceJoinRequestMessage_0.Avatar.GetId();
				if (!gclass.Members.ContainsKey(id))
				{
					if (gclass.Header.GetAllianceType() != AllianceType.OPEN)
					{
						if (gclass.Header.GetAllianceType() == AllianceType.CLOSED)
						{
							ServerRequestManager.SendResponse(new RequestAllianceJoinResponseMessage
							{
								ErrorReason = RequestAllianceJoinResponseMessage.Reason.CLOSED
							}, requestAllianceJoinRequestMessage_0);
							return;
						}
						if (gclass.method_3(id))
						{
							ServerRequestManager.SendResponse(new RequestAllianceJoinResponseMessage
							{
								ErrorReason = RequestAllianceJoinResponseMessage.Reason.BANNED
							}, requestAllianceJoinRequestMessage_0);
							return;
						}
						int num = 0;
						for (int i = 0; i < gclass.StreamEntryList.Size(); i++)
						{
							StreamEntry streamEntry = GClass10.smethod_3(gclass.StreamEntryList[i]);
							if (streamEntry != null && streamEntry.GetStreamEntryType() == StreamEntryType.JOIN_REQUEST)
							{
								JoinRequestAllianceStreamEntry joinRequestAllianceStreamEntry = (JoinRequestAllianceStreamEntry)streamEntry;
								if (joinRequestAllianceStreamEntry.GetState() == 1)
								{
									num++;
									if (joinRequestAllianceStreamEntry.GetSenderAvatarId().Equals(id))
									{
										ServerRequestManager.SendResponse(new RequestAllianceJoinResponseMessage
										{
											ErrorReason = RequestAllianceJoinResponseMessage.Reason.ALREADY_SENT
										}, requestAllianceJoinRequestMessage_0);
										return;
									}
								}
								else if (joinRequestAllianceStreamEntry.GetState() == 0 && joinRequestAllianceStreamEntry.GetAgeSeconds() < 3600)
								{
									ServerRequestManager.SendResponse(new RequestAllianceJoinResponseMessage
									{
										ErrorReason = RequestAllianceJoinResponseMessage.Reason.ALREADY_SENT
									}, requestAllianceJoinRequestMessage_0);
									return;
								}
							}
						}
						if (num >= 10)
						{
							ServerRequestManager.SendResponse(new RequestAllianceJoinResponseMessage
							{
								ErrorReason = RequestAllianceJoinResponseMessage.Reason.TOO_MANY_PENDING_REQUESTS
							}, requestAllianceJoinRequestMessage_0);
							return;
						}
						if (requestAllianceJoinRequestMessage_0.Avatar.GetScore() < gclass.Header.GetRequiredScore())
						{
							ServerRequestManager.SendResponse(new RequestAllianceJoinResponseMessage
							{
								ErrorReason = RequestAllianceJoinResponseMessage.Reason.NO_SCORE
							}, requestAllianceJoinRequestMessage_0);
							return;
						}
						if (requestAllianceJoinRequestMessage_0.Avatar.GetDuelScore() < gclass.Header.GetRequiredDuelScore())
						{
							ServerRequestManager.SendResponse(new RequestAllianceJoinResponseMessage
							{
								ErrorReason = RequestAllianceJoinResponseMessage.Reason.NO_DUEL_SCORE
							}, requestAllianceJoinRequestMessage_0);
							return;
						}
						JoinRequestAllianceStreamEntry joinRequestAllianceStreamEntry2 = new JoinRequestAllianceStreamEntry();
						GClass3.smethod_1(joinRequestAllianceStreamEntry2, requestAllianceJoinRequestMessage_0.Avatar);
						string text = requestAllianceJoinRequestMessage_0.Message;
						if (text != null && text.Length >= 128)
						{
							text = text.Substring(0, 128);
						}
						joinRequestAllianceStreamEntry2.SetMessage(text);
						GClass10.smethod_7(gclass.Id, joinRequestAllianceStreamEntry2);
						gclass.method_13(joinRequestAllianceStreamEntry2);
						GClass9.smethod_5(gclass);
						ServerRequestManager.SendResponse(new RequestAllianceJoinResponseMessage
						{
							Success = true
						}, requestAllianceJoinRequestMessage_0);
						return;
					}
				}
				ServerRequestManager.SendResponse(new RequestAllianceJoinResponseMessage
				{
					ErrorReason = RequestAllianceJoinResponseMessage.Reason.GENERIC
				}, requestAllianceJoinRequestMessage_0);
				return;
			}
			ServerRequestManager.SendResponse(new RequestAllianceJoinResponseMessage
			{
				ErrorReason = RequestAllianceJoinResponseMessage.Reason.GENERIC
			}, requestAllianceJoinRequestMessage_0);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00004D10 File Offset: 0x00002F10
		public override void OnReceiveSessionMessage(ServerSessionMessage message)
		{
			ServerMessageType messageType = message.GetMessageType();
			if (messageType <= ServerMessageType.SEND_AVATAR_STREAMS_TO_CLIENT)
			{
				if (messageType == ServerMessageType.FORWARD_LOGIC_MESSAGE)
				{
					GClass7.smethod_28((ForwardLogicMessage)message);
					return;
				}
				if (messageType == ServerMessageType.FORWARD_LOGIC_REQUEST_MESSAGE)
				{
					GClass7.smethod_29((ForwardLogicRequestMessage)message);
					return;
				}
				if (messageType != ServerMessageType.SEND_AVATAR_STREAMS_TO_CLIENT)
				{
					return;
				}
				GClass7.smethod_31((SendAvatarStreamsToClientMessage)message);
				return;
			}
			else if (messageType <= ServerMessageType.START_SERVER_SESSION)
			{
				if (messageType == ServerMessageType.SEND_VILLAGE2_ATTACK_ENTRY_LIST_TO_CLIENT)
				{
					GClass7.smethod_32((SendVillage2AttackEntryListToClientMessage)message);
					return;
				}
				if (messageType != ServerMessageType.START_SERVER_SESSION)
				{
					return;
				}
				GClass5.smethod_2((StartServerSessionMessage)message);
				return;
			}
			else
			{
				if (messageType == ServerMessageType.STOP_SERVER_SESSION)
				{
					GClass5.smethod_3((StopServerSessionMessage)message);
					return;
				}
				if (messageType != ServerMessageType.UPDATE_SOCKET_SERVER_SESSION)
				{
					return;
				}
				GClass7.smethod_27((UpdateSocketServerSessionMessage)message);
				return;
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004DC4 File Offset: 0x00002FC4
		private static void smethod_27(UpdateSocketServerSessionMessage updateSocketServerSessionMessage_0)
		{
			GClass4 gclass;
			if (GClass5.smethod_4(updateSocketServerSessionMessage_0.SessionId, out gclass))
			{
				gclass.UpdateSocketServerSessionMessageReceived(updateSocketServerSessionMessage_0);
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004DE8 File Offset: 0x00002FE8
		private static void smethod_28(ForwardLogicMessage forwardLogicMessage_0)
		{
			GClass4 gclass;
			if (GClass5.smethod_4(forwardLogicMessage_0.SessionId, out gclass))
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

		// Token: 0x06000051 RID: 81 RVA: 0x00004E60 File Offset: 0x00003060
		private static void smethod_29(ForwardLogicRequestMessage forwardLogicRequestMessage_0)
		{
			PiranhaMessage piranhaMessage = LogicMagicMessageFactory.Instance.CreateMessageByType((int)forwardLogicRequestMessage_0.MessageType);
			if (piranhaMessage == null)
			{
				throw new Exception("logicMessage should not be NULL!");
			}
			piranhaMessage.GetByteStream().SetByteArray(forwardLogicRequestMessage_0.MessageBytes, forwardLogicRequestMessage_0.MessageLength);
			piranhaMessage.SetMessageVersion((int)forwardLogicRequestMessage_0.MessageVersion);
			piranhaMessage.Decode();
			GClass8 gclass;
			if (!piranhaMessage.IsServerToClientMessage() && piranhaMessage.GetMessageType() == 14302 && GClass9.smethod_3(((AskForAllianceDataMessage)piranhaMessage).RemoveAllianceId(), out gclass))
			{
				ServerMessageManager.SendMessage(GClass7.smethod_30(gclass.method_21(), forwardLogicRequestMessage_0.SessionId), ServerManager.GetProxySocket(forwardLogicRequestMessage_0.SessionId));
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004F00 File Offset: 0x00003100
		private static ForwardLogicMessage smethod_30(PiranhaMessage piranhaMessage_0, long long_0)
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

		// Token: 0x06000053 RID: 83 RVA: 0x00004F58 File Offset: 0x00003158
		private static void smethod_31(SendAvatarStreamsToClientMessage sendAvatarStreamsToClientMessage_0)
		{
			AvatarStreamMessage avatarStreamMessage = new AvatarStreamMessage();
			LogicArrayList<LogicLong> streamIds = sendAvatarStreamsToClientMessage_0.StreamIds;
			LogicArrayList<AvatarStreamEntry> logicArrayList = new LogicArrayList<AvatarStreamEntry>(streamIds.Size());
			for (int i = 0; i < streamIds.Size(); i++)
			{
				AvatarStreamEntry avatarStreamEntry = GClass10.smethod_4(streamIds[i]);
				if (avatarStreamEntry != null)
				{
					logicArrayList.Add(avatarStreamEntry);
				}
			}
			avatarStreamMessage.SetStreamEntries(logicArrayList);
			avatarStreamMessage.Encode();
			ServerMessageManager.SendMessage(GClass7.smethod_30(avatarStreamMessage, sendAvatarStreamsToClientMessage_0.SessionId), ServerManager.GetProxySocket(sendAvatarStreamsToClientMessage_0.SessionId));
			for (int j = 0; j < logicArrayList.Size(); j++)
			{
				AvatarStreamEntry avatarStreamEntry2 = logicArrayList[j];
				if (avatarStreamEntry2.IsNew())
				{
					avatarStreamEntry2.SetNew(false);
					GClass10.smethod_13(avatarStreamEntry2);
				}
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000500C File Offset: 0x0000320C
		private static void smethod_32(SendVillage2AttackEntryListToClientMessage sendVillage2AttackEntryListToClientMessage_0)
		{
			Village2AttackEntryListMessage village2AttackEntryListMessage = new Village2AttackEntryListMessage();
			LogicArrayList<LogicLong> entryIds = sendVillage2AttackEntryListToClientMessage_0.EntryIds;
			LogicArrayList<Village2AttackEntry> logicArrayList = new LogicArrayList<Village2AttackEntry>(entryIds.Size());
			for (int i = 0; i < entryIds.Size(); i++)
			{
				Village2AttackEntry village2AttackEntry = GClass10.smethod_6(entryIds[i]);
				if (village2AttackEntry != null)
				{
					logicArrayList.Add(village2AttackEntry);
				}
			}
			village2AttackEntryListMessage.SetStreamEntries(logicArrayList);
			village2AttackEntryListMessage.Encode();
			ServerMessageManager.SendMessage(GClass7.smethod_30(village2AttackEntryListMessage, sendVillage2AttackEntryListToClientMessage_0.SessionId), ServerManager.GetProxySocket(sendVillage2AttackEntryListToClientMessage_0.SessionId));
			for (int j = 0; j < logicArrayList.Size(); j++)
			{
				Village2AttackEntry village2AttackEntry2 = logicArrayList[j];
				if (village2AttackEntry2.IsNew())
				{
					village2AttackEntry2.SetNew(false);
					GClass10.smethod_14(village2AttackEntry2);
				}
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002234 File Offset: 0x00000434
		public override void OnReceiveCoreMessage(ServerCoreMessage message)
		{
			if (message.GetMessageType() == ServerMessageType.SERVER_PERFORMANCE)
			{
				ServerMessageManager.SendMessage(new ServerPerformanceDataMessage
				{
					SessionCount = GClass5.smethod_0()
				}, message.Sender);
			}
		}

		// Token: 0x0200000D RID: 13
		[CompilerGenerated]
		private sealed class Class3
		{
			// Token: 0x06000058 RID: 88 RVA: 0x000050C0 File Offset: 0x000032C0
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					LoadAvatarStreamResponseMessage loadAvatarStreamResponseMessage = (LoadAvatarStreamResponseMessage)serverRequestArgs_0.ResponseMessage;
					if (loadAvatarStreamResponseMessage.Entry.GetAvatarStreamEntryType() == AvatarStreamEntryType.ATTACKER_BATTLE_REPORT || loadAvatarStreamResponseMessage.Entry.GetAvatarStreamEntryType() == AvatarStreamEntryType.DEFENDER_BATTLE_REPORT)
					{
						BattleReportStreamEntry battleReportStreamEntry = (BattleReportStreamEntry)loadAvatarStreamResponseMessage.Entry;
						Atrasis.Magic.Logic.Message.Alliance.Stream.ReplayStreamEntry replayStreamEntry = new Atrasis.Magic.Logic.Message.Alliance.Stream.ReplayStreamEntry();
						GClass3.smethod_0(replayStreamEntry, this.allianceMemberEntry_0);
						replayStreamEntry.SetAttack(loadAvatarStreamResponseMessage.Entry.GetAvatarStreamEntryType() == AvatarStreamEntryType.ATTACKER_BATTLE_REPORT);
						replayStreamEntry.SetBattleLogJSON(battleReportStreamEntry.GetBattleLogJSON());
						replayStreamEntry.SetMajorVersion(battleReportStreamEntry.GetMajorVersion());
						replayStreamEntry.SetBuildVersion(battleReportStreamEntry.GetBuildVersion());
						replayStreamEntry.SetContentVersion(battleReportStreamEntry.GetContentVersion());
						replayStreamEntry.SetReplayId(battleReportStreamEntry.GetReplayId());
						replayStreamEntry.SetReplayShardId(battleReportStreamEntry.GetReplayShardId());
						replayStreamEntry.SetOpponentName(battleReportStreamEntry.GetSenderName());
						string text = this.allianceShareReplayMessage_0.Message;
						if (text != null && text.Length > 128)
						{
							text = text.Substring(0, 128);
						}
						replayStreamEntry.SetMessage(text);
						GClass10.smethod_7(this.gclass8_0.Id, replayStreamEntry);
						this.gclass8_0.method_13(replayStreamEntry);
						GClass9.smethod_5(this.gclass8_0);
					}
				}
			}

			// Token: 0x0400000E RID: 14
			public AllianceMemberEntry allianceMemberEntry_0;

			// Token: 0x0400000F RID: 15
			public AllianceShareReplayMessage allianceShareReplayMessage_0;

			// Token: 0x04000010 RID: 16
			public GClass8 gclass8_0;
		}

		// Token: 0x0200000E RID: 14
		[CompilerGenerated]
		private sealed class Class4
		{
			// Token: 0x0600005A RID: 90 RVA: 0x000051F4 File Offset: 0x000033F4
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					LoadVillage2AttackEntryResponseMessage loadVillage2AttackEntryResponseMessage = (LoadVillage2AttackEntryResponseMessage)serverRequestArgs_0.ResponseMessage;
					if (loadVillage2AttackEntryResponseMessage.Entry.GetAttackEntryType() == Village2AttackEntryType.BATTLE_RESULT)
					{
						Village2BattleResultAttackEntry village2BattleResultAttackEntry = (Village2BattleResultAttackEntry)loadVillage2AttackEntryResponseMessage.Entry;
						DuelReplayStreamEntry duelReplayStreamEntry = new DuelReplayStreamEntry();
						GClass3.smethod_0(duelReplayStreamEntry, this.allianceMemberEntry_0);
						duelReplayStreamEntry.SetAttackerStars(village2BattleResultAttackEntry.GetAttackerStars());
						duelReplayStreamEntry.SetAttackerDestructionPercentage(village2BattleResultAttackEntry.GetAttackerDestructionPercentage());
						duelReplayStreamEntry.SetOpponentStars(village2BattleResultAttackEntry.GetOpponentStars());
						duelReplayStreamEntry.SetOpponentDestructionPercentage(village2BattleResultAttackEntry.GetOpponentDestructionPercentage());
						duelReplayStreamEntry.SetOpponentName(village2BattleResultAttackEntry.GetName());
						duelReplayStreamEntry.SetAttackerAllianceName(this.gclass8_0.Header.GetAllianceName());
						duelReplayStreamEntry.SetAttackerAllianceLevel(this.gclass8_0.Header.GetAllianceLevel());
						duelReplayStreamEntry.SetAttackerAllianceBadgeId(this.gclass8_0.Header.GetAllianceBadgeId());
						if (village2BattleResultAttackEntry.GetAllianceId() != null)
						{
							duelReplayStreamEntry.SetOpponentAllianceId(village2BattleResultAttackEntry.GetAllianceId());
							duelReplayStreamEntry.SetOpponentAllianceName(village2BattleResultAttackEntry.GetAllianceName());
							duelReplayStreamEntry.SetOpponentAllianceLevel(village2BattleResultAttackEntry.GetAllianceExpLevel());
							duelReplayStreamEntry.SetOpponentAllianceBadgeId(village2BattleResultAttackEntry.GetAllianceBadgeId());
						}
						if (village2BattleResultAttackEntry.GetAttackerReplayId() != null)
						{
							duelReplayStreamEntry.SetAttackerReplayId(village2BattleResultAttackEntry.GetAttackerReplayId());
							duelReplayStreamEntry.SetAttackerReplayShardId(village2BattleResultAttackEntry.GetAttackerReplayShardId());
							duelReplayStreamEntry.SetAttackerReplayMajorVersion(village2BattleResultAttackEntry.GetAttackerReplayMajorVersion());
							duelReplayStreamEntry.SetAttackerReplayBuildVersion(village2BattleResultAttackEntry.GetAttackerReplayBuildVersion());
							duelReplayStreamEntry.SetAttackerReplayContentVersion(village2BattleResultAttackEntry.GetAttackerReplayContentVersion());
						}
						if (village2BattleResultAttackEntry.GetOpponentReplayId() != null)
						{
							duelReplayStreamEntry.SetOpponentReplayId(village2BattleResultAttackEntry.GetOpponentReplayId());
							duelReplayStreamEntry.SetOpponentReplayShardId(village2BattleResultAttackEntry.GetOpponentReplayShardId());
							duelReplayStreamEntry.SetOpponentReplayMajorVersion(village2BattleResultAttackEntry.GetOpponentReplayMajorVersion());
							duelReplayStreamEntry.SetOpponentReplayBuildVersion(village2BattleResultAttackEntry.GetOpponentReplayBuildVersion());
							duelReplayStreamEntry.SetOpponentReplayContentVersion(village2BattleResultAttackEntry.GetOpponentReplayContentVersion());
							duelReplayStreamEntry.SetOpponentAvatarId(village2BattleResultAttackEntry.GetAvatarId());
							duelReplayStreamEntry.SetOpponentHomeId(village2BattleResultAttackEntry.GetHomeId());
						}
						GClass10.smethod_7(this.gclass8_0.Id, duelReplayStreamEntry);
						this.gclass8_0.method_13(duelReplayStreamEntry);
						GClass9.smethod_5(this.gclass8_0);
					}
				}
			}

			// Token: 0x04000011 RID: 17
			public AllianceMemberEntry allianceMemberEntry_0;

			// Token: 0x04000012 RID: 18
			public GClass8 gclass8_0;
		}
	}
}
