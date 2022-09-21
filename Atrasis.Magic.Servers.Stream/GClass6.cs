using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Logic.Message.Alliance.Stream;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Logic.Message.Home;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Message.Session.State;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace ns0
{
	// Token: 0x02000009 RID: 9
	public class GClass6
	{
		// Token: 0x0600001F RID: 31 RVA: 0x0000219C File Offset: 0x0000039C
		public GClass6(GClass4 gclass4_1)
		{
			this.gclass4_0 = gclass4_1;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002808 File Offset: 0x00000A08
		public void method_0(PiranhaMessage piranhaMessage_0)
		{
			short messageType = piranhaMessage_0.GetMessageType();
			if (messageType > 14125)
			{
				if (messageType <= 14315)
				{
					switch (messageType)
					{
					case 14306:
						this.method_4((ChangeAllianceMemberRoleMessage)piranhaMessage_0);
						return;
					case 14307:
					case 14309:
						break;
					case 14308:
						this.method_1((LeaveAllianceMessage)piranhaMessage_0);
						return;
					case 14310:
						this.method_5((DonateAllianceUnitMessage)piranhaMessage_0);
						return;
					default:
						if (messageType != 14315)
						{
							return;
						}
						this.method_2((ChatToAllianceStreamMessage)piranhaMessage_0);
						return;
					}
				}
				else
				{
					if (messageType == 14316)
					{
						this.method_3((ChangeAllianceSettingsMessage)piranhaMessage_0);
						return;
					}
					if (messageType == 14321)
					{
						this.method_10((RespondToAllianceJoinRequestMessage)piranhaMessage_0);
						return;
					}
					if (messageType != 14322)
					{
						return;
					}
					this.method_11((SendAllianceInvitationMessage)piranhaMessage_0);
				}
				return;
			}
			if (messageType <= 14111)
			{
				if (messageType == 14110)
				{
					this.method_9((StartFriendlyChallengeSpectateMessage)piranhaMessage_0);
					return;
				}
				if (messageType != 14111)
				{
					return;
				}
				this.method_7((ScoutFriendlyBattleMessage)piranhaMessage_0);
				return;
			}
			else
			{
				if (messageType == 14120)
				{
					this.method_8((AcceptFriendlyBattleMessage)piranhaMessage_0);
					return;
				}
				if (messageType != 14125)
				{
					return;
				}
				this.method_6((CancelChallengeMessage)piranhaMessage_0);
				return;
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002928 File Offset: 0x00000B28
		private void method_1(LeaveAllianceMessage leaveAllianceMessage_0)
		{
			if (this.gclass4_0.method_1() != null)
			{
				GClass8 gclass = this.gclass4_0.method_1();
				AllianceMemberEntry allianceMemberEntry = gclass.Members[this.gclass4_0.AccountId];
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
				AllianceEventStreamEntry allianceEventStreamEntry = new AllianceEventStreamEntry();
				GClass3.smethod_0(allianceEventStreamEntry, allianceMemberEntry);
				allianceEventStreamEntry.SetEventType(AllianceEventStreamEntryType.LEFT);
				allianceEventStreamEntry.SetEventAvatarId(allianceMemberEntry.GetAvatarId());
				allianceEventStreamEntry.SetEventAvatarName(allianceMemberEntry.GetName());
				GClass10.smethod_7(gclass.Id, allianceEventStreamEntry);
				gclass.method_1(this.gclass4_0.AccountId);
				gclass.method_13(allianceEventStreamEntry);
				ServerMessageManager.SendMessage(new AllianceLeavedMessage
				{
					AccountId = this.gclass4_0.AccountId,
					AllianceId = gclass.Id
				}, 9);
				GClass9.smethod_5(gclass);
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002A78 File Offset: 0x00000C78
		public void method_2(ChatToAllianceStreamMessage chatToAllianceStreamMessage_0)
		{
			if (!this.method_12())
			{
				return;
			}
			if (this.gclass4_0.method_1() != null)
			{
				string text = chatToAllianceStreamMessage_0.RemoveMessage();
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				if (text.Length > 128)
				{
					text = text.Substring(0, 128);
				}
				AllianceMemberEntry allianceMemberEntry_ = this.gclass4_0.method_1().Members[this.gclass4_0.AccountId];
				ChatStreamEntry chatStreamEntry = new ChatStreamEntry();
				GClass3.smethod_0(chatStreamEntry, allianceMemberEntry_);
				chatStreamEntry.SetMessage(WordCensorUtil.FilterMessage(text));
				GClass10.smethod_7(this.gclass4_0.method_1().Id, chatStreamEntry);
				this.gclass4_0.method_1().method_13(chatStreamEntry);
				GClass9.smethod_5(this.gclass4_0.method_1());
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002B40 File Offset: 0x00000D40
		private void method_3(ChangeAllianceSettingsMessage changeAllianceSettingsMessage_0)
		{
			if (this.gclass4_0.method_1() != null)
			{
				this.gclass4_0.method_1().method_26(changeAllianceSettingsMessage_0.GetAllianceDescription(), (AllianceType)changeAllianceSettingsMessage_0.GetAllianceType(), changeAllianceSettingsMessage_0.GetAllianceBadgeId(), changeAllianceSettingsMessage_0.GetRequiredScore(), changeAllianceSettingsMessage_0.GetRequiredDuelScore(), changeAllianceSettingsMessage_0.GetWarFrequency(), changeAllianceSettingsMessage_0.GetOriginData(), changeAllianceSettingsMessage_0.IsPublicWarLog(), changeAllianceSettingsMessage_0.IsAmicalWarEnabled());
				AllianceMemberEntry allianceMemberEntry = this.gclass4_0.method_1().Members[this.gclass4_0.AccountId];
				AllianceEventStreamEntry allianceEventStreamEntry = new AllianceEventStreamEntry();
				GClass3.smethod_0(allianceEventStreamEntry, allianceMemberEntry);
				allianceEventStreamEntry.SetEventType(AllianceEventStreamEntryType.CHANGED_SETTINGS);
				allianceEventStreamEntry.SetEventAvatarId(allianceMemberEntry.GetAvatarId());
				allianceEventStreamEntry.SetEventAvatarName(allianceMemberEntry.GetName());
				GClass10.smethod_7(this.gclass4_0.method_1().Id, allianceEventStreamEntry);
				this.gclass4_0.method_1().method_13(allianceEventStreamEntry);
				GClass9.smethod_5(this.gclass4_0.method_1());
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002C30 File Offset: 0x00000E30
		private void method_4(ChangeAllianceMemberRoleMessage changeAllianceMemberRoleMessage_0)
		{
			if (this.gclass4_0.method_1() != null)
			{
				LogicLong @long = changeAllianceMemberRoleMessage_0.RemoveMemberId();
				AllianceMemberEntry allianceMemberEntry;
				if (!this.gclass4_0.method_1().Members.TryGetValue(@long, out allianceMemberEntry))
				{
					return;
				}
				AllianceMemberEntry allianceMemberEntry2 = this.gclass4_0.method_1().Members[this.gclass4_0.AccountId];
				if ((changeAllianceMemberRoleMessage_0.GetMemberRole() == LogicAvatarAllianceRole.MEMBER || changeAllianceMemberRoleMessage_0.GetMemberRole() == LogicAvatarAllianceRole.LEADER || changeAllianceMemberRoleMessage_0.GetMemberRole() == LogicAvatarAllianceRole.ELDER || changeAllianceMemberRoleMessage_0.GetMemberRole() == LogicAvatarAllianceRole.CO_LEADER) && allianceMemberEntry.HasLowerRoleThan(allianceMemberEntry2.GetAllianceRole()) && !allianceMemberEntry2.HasLowerRoleThan(changeAllianceMemberRoleMessage_0.GetMemberRole()))
				{
					if (changeAllianceMemberRoleMessage_0.GetMemberRole() == LogicAvatarAllianceRole.LEADER)
					{
						this.gclass4_0.method_1().method_7(allianceMemberEntry2, LogicAvatarAllianceRole.CO_LEADER, allianceMemberEntry2.GetAvatarId(), allianceMemberEntry2.GetName());
					}
					this.gclass4_0.method_1().method_7(allianceMemberEntry, changeAllianceMemberRoleMessage_0.GetMemberRole(), allianceMemberEntry2.GetAvatarId(), allianceMemberEntry2.GetName());
					GClass9.smethod_5(this.gclass4_0.method_1());
				}
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002D34 File Offset: 0x00000F34
		private void method_5(DonateAllianceUnitMessage donateAllianceUnitMessage_0)
		{
			if (this.gclass4_0.method_1() != null)
			{
				GClass8 gclass = this.gclass4_0.method_1();
				LogicCombatItemData allianceUnitData = donateAllianceUnitMessage_0.GetAllianceUnitData();
				if (!allianceUnitData.IsDonationDisabled())
				{
					if (donateAllianceUnitMessage_0.UseQuickDonate())
					{
						if (!LogicDataTables.GetGlobals().EnableQuickDonate() || this.gclass4_0.method_3().GetDiamonds() < allianceUnitData.GetDonateCost())
						{
							return;
						}
					}
					else if (this.gclass4_0.method_3().GetUnitCount(allianceUnitData) <= 0)
					{
						return;
					}
					if (gclass.StreamEntryList.IndexOf(donateAllianceUnitMessage_0.GetStreamId()) != -1)
					{
						StreamEntry streamEntry = GClass10.smethod_3(donateAllianceUnitMessage_0.GetStreamId());
						if (streamEntry.GetStreamEntryType() == StreamEntryType.DONATE)
						{
							DonateStreamEntry donateStreamEntry = (DonateStreamEntry)streamEntry;
							if (donateStreamEntry.CanAddDonation(this.gclass4_0.AccountId, donateAllianceUnitMessage_0.GetAllianceUnitData(), gclass.Header.GetAllianceLevel()))
							{
								donateStreamEntry.AddDonation(this.gclass4_0.AccountId, allianceUnitData, this.gclass4_0.method_3().GetUnitUpgradeLevel(allianceUnitData));
								donateStreamEntry.SetDonationPendingRequestCount(donateStreamEntry.GetDonationPendingRequestCount() + 1);
								gclass.method_14(donateStreamEntry);
								if (donateAllianceUnitMessage_0.UseQuickDonate())
								{
									this.gclass4_0.method_3().CommodityCountChangeHelper(0, allianceUnitData, -1);
								}
								LogicDonateAllianceUnitCommand logicDonateAllianceUnitCommand = new LogicDonateAllianceUnitCommand();
								logicDonateAllianceUnitCommand.SetData(allianceUnitData, streamEntry.GetId(), donateAllianceUnitMessage_0.UseQuickDonate());
								ServerMessageManager.SendMessage(new GameAllowServerCommandMessage
								{
									AccountId = this.gclass4_0.AccountId,
									ServerCommand = logicDonateAllianceUnitCommand
								}, 9);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002EA4 File Offset: 0x000010A4
		private void method_6(CancelChallengeMessage cancelChallengeMessage_0)
		{
			if (this.gclass4_0.method_1() != null)
			{
				GClass8 gclass = this.gclass4_0.method_1();
				AllianceMemberEntry allianceMemberEntry = gclass.Members[this.gclass4_0.AccountId];
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
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002F50 File Offset: 0x00001150
		private void method_7(ScoutFriendlyBattleMessage scoutFriendlyBattleMessage_0)
		{
			if (this.gclass4_0.method_1() != null)
			{
				AllianceDocument allianceDocument = this.gclass4_0.method_1();
				LogicLong streamId = scoutFriendlyBattleMessage_0.GetStreamId();
				if (allianceDocument.StreamEntryList.IndexOf(streamId) != -1)
				{
					StreamEntry streamEntry = GClass10.smethod_3(scoutFriendlyBattleMessage_0.GetStreamId());
					if (streamEntry.GetStreamEntryType() == StreamEntryType.CHALLENGE)
					{
						ChallengeStreamEntry challengeStreamEntry = (ChallengeStreamEntry)streamEntry;
						if (challengeStreamEntry.IsStarted())
						{
							ChallengeFailedMessage challengeFailedMessage = new ChallengeFailedMessage();
							challengeFailedMessage.SetReason(ChallengeFailedMessage.Reason.ALREADY_CLOSED);
							this.gclass4_0.SendPiranhaMessage(challengeFailedMessage, 1);
							return;
						}
						this.gclass4_0.SendMessage(new GameFriendlyScoutMessage
						{
							AccountId = challengeStreamEntry.GetSenderAvatarId(),
							HomeJSON = challengeStreamEntry.GetSnapshotHomeJSON(),
							MapId = (challengeStreamEntry.IsWarLayout() ? 1 : 0),
							StreamId = challengeStreamEntry.GetId()
						}, 9);
						return;
					}
				}
			}
			ChallengeFailedMessage challengeFailedMessage2 = new ChallengeFailedMessage();
			challengeFailedMessage2.SetReason(ChallengeFailedMessage.Reason.GENERIC);
			this.gclass4_0.SendPiranhaMessage(challengeFailedMessage2, 1);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003038 File Offset: 0x00001238
		private void method_8(AcceptFriendlyBattleMessage acceptFriendlyBattleMessage_0)
		{
			if (this.gclass4_0.method_1() != null)
			{
				GClass8 gclass = this.gclass4_0.method_1();
				LogicLong streamId = acceptFriendlyBattleMessage_0.GetStreamId();
				if (gclass.StreamEntryList.IndexOf(streamId) != -1)
				{
					StreamEntry streamEntry = GClass10.smethod_3(acceptFriendlyBattleMessage_0.GetStreamId());
					if (streamEntry.GetStreamEntryType() == StreamEntryType.CHALLENGE)
					{
						ChallengeStreamEntry challengeStreamEntry = (ChallengeStreamEntry)streamEntry;
						if (challengeStreamEntry.IsStarted())
						{
							ChallengeFailedMessage challengeFailedMessage = new ChallengeFailedMessage();
							challengeFailedMessage.SetReason(ChallengeFailedMessage.Reason.ALREADY_CLOSED);
							this.gclass4_0.SendPiranhaMessage(challengeFailedMessage, 1);
							return;
						}
						this.gclass4_0.SendMessage(new ChangeGameStateMessage
						{
							StateType = GameStateType.CHALLENGE_ATTACK,
							ChallengeAllianceId = gclass.Id,
							ChallengeHomeId = challengeStreamEntry.GetSenderAvatarId(),
							ChallengeStreamId = challengeStreamEntry.GetId(),
							ChallengeHomeJSON = challengeStreamEntry.GetSnapshotHomeJSON(),
							ChallengeMapId = (challengeStreamEntry.IsWarLayout() ? 1 : 0)
						}, 9);
						challengeStreamEntry.SetStarted(true);
						gclass.method_14(challengeStreamEntry);
						return;
					}
				}
			}
			ChallengeFailedMessage challengeFailedMessage2 = new ChallengeFailedMessage();
			challengeFailedMessage2.SetReason(ChallengeFailedMessage.Reason.GENERIC);
			this.gclass4_0.SendPiranhaMessage(challengeFailedMessage2, 1);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000314C File Offset: 0x0000134C
		private void method_9(StartFriendlyChallengeSpectateMessage startFriendlyChallengeSpectateMessage_0)
		{
			if (this.gclass4_0.method_1() != null)
			{
				AllianceDocument allianceDocument = this.gclass4_0.method_1();
				LogicLong streamId = startFriendlyChallengeSpectateMessage_0.GetStreamId();
				if (allianceDocument.StreamEntryList.IndexOf(streamId) != -1)
				{
					StreamEntry streamEntry = GClass10.smethod_3(startFriendlyChallengeSpectateMessage_0.GetStreamId());
					if (streamEntry.GetStreamEntryType() == StreamEntryType.CHALLENGE)
					{
						ChallengeStreamEntry challengeStreamEntry = (ChallengeStreamEntry)streamEntry;
						if (challengeStreamEntry.IsStarted() && challengeStreamEntry.GetLiveReplayId() != null)
						{
							this.gclass4_0.SendMessage(new GameSpectateLiveReplayMessage
							{
								LiveReplayId = challengeStreamEntry.GetLiveReplayId(),
								IsEnemy = false
							}, 9);
							return;
						}
					}
				}
			}
			LiveReplayFailedMessage liveReplayFailedMessage = new LiveReplayFailedMessage();
			liveReplayFailedMessage.SetReason(LiveReplayFailedMessage.Reason.GENERIC);
			this.gclass4_0.SendPiranhaMessage(liveReplayFailedMessage, 1);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000031F4 File Offset: 0x000013F4
		private void method_10(RespondToAllianceJoinRequestMessage respondToAllianceJoinRequestMessage_0)
		{
			if (this.gclass4_0.method_1() != null)
			{
				GClass6.Class1 @class = new GClass6.Class1();
				@class.gclass6_0 = this;
				@class.gclass8_0 = this.gclass4_0.method_1();
				@class.allianceMemberEntry_0 = @class.gclass8_0.Members[this.gclass4_0.AccountId];
				if (@class.allianceMemberEntry_0.GetAllianceRole() == LogicAvatarAllianceRole.MEMBER)
				{
					AllianceInvitationSendFailedMessage allianceInvitationSendFailedMessage = new AllianceInvitationSendFailedMessage();
					allianceInvitationSendFailedMessage.SetReason(AllianceInvitationSendFailedMessage.Reason.NO_RIGHTS);
					this.gclass4_0.SendPiranhaMessage(allianceInvitationSendFailedMessage, 1);
					return;
				}
				LogicLong streamEntryId = respondToAllianceJoinRequestMessage_0.GetStreamEntryId();
				if (@class.gclass8_0.StreamEntryList.IndexOf(streamEntryId) != -1)
				{
					StreamEntry streamEntry = GClass10.smethod_3(respondToAllianceJoinRequestMessage_0.GetStreamEntryId());
					if (streamEntry.GetStreamEntryType() == StreamEntryType.JOIN_REQUEST)
					{
						GClass6.Class2 class2 = new GClass6.Class2();
						class2.class1_0 = @class;
						class2.joinRequestAllianceStreamEntry_0 = (JoinRequestAllianceStreamEntry)streamEntry;
						if (class2.joinRequestAllianceStreamEntry_0.GetState() == 1)
						{
							if (respondToAllianceJoinRequestMessage_0.IsAccepted())
							{
								ServerRequestManager.Create(new GameJoinAllianceRequestMessage
								{
									AccountId = class2.joinRequestAllianceStreamEntry_0.GetSenderAvatarId(),
									AllianceId = class2.class1_0.gclass8_0.Id,
									Invited = true
								}, ServerManager.GetDocumentSocket(9, class2.joinRequestAllianceStreamEntry_0.GetSenderAvatarId()), 30).OnComplete = new ServerRequestArgs.CompleteHandler(class2.method_0);
								return;
							}
							class2.joinRequestAllianceStreamEntry_0.SetState(0);
							class2.joinRequestAllianceStreamEntry_0.SetResponderName(class2.class1_0.allianceMemberEntry_0.GetName());
							class2.class1_0.gclass8_0.method_14(class2.joinRequestAllianceStreamEntry_0);
							GClass10.smethod_12(class2.joinRequestAllianceStreamEntry_0);
							JoinAllianceResponseAvatarStreamEntry joinAllianceResponseAvatarStreamEntry = new JoinAllianceResponseAvatarStreamEntry();
							joinAllianceResponseAvatarStreamEntry.SetSenderAvatarId(class2.class1_0.allianceMemberEntry_0.GetAvatarId());
							joinAllianceResponseAvatarStreamEntry.SetSenderHomeId(class2.class1_0.allianceMemberEntry_0.GetHomeId());
							joinAllianceResponseAvatarStreamEntry.SetSenderName(class2.class1_0.allianceMemberEntry_0.GetName());
							joinAllianceResponseAvatarStreamEntry.SetSenderLevel(class2.class1_0.allianceMemberEntry_0.GetExpLevel());
							joinAllianceResponseAvatarStreamEntry.SetSenderLeagueType(class2.class1_0.allianceMemberEntry_0.GetLeagueType());
							joinAllianceResponseAvatarStreamEntry.SetAllianceId(class2.class1_0.gclass8_0.Id);
							joinAllianceResponseAvatarStreamEntry.SetAllianceName(class2.class1_0.gclass8_0.Header.GetAllianceName());
							joinAllianceResponseAvatarStreamEntry.SetAllianceBadgeId(class2.class1_0.gclass8_0.Header.GetAllianceBadgeId());
							ServerMessageManager.SendMessage(new CreateAvatarStreamMessage
							{
								AccountId = class2.joinRequestAllianceStreamEntry_0.GetSenderAvatarId(),
								Entry = joinAllianceResponseAvatarStreamEntry
							}, 9);
						}
					}
				}
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003494 File Offset: 0x00001694
		private void method_11(SendAllianceInvitationMessage sendAllianceInvitationMessage_0)
		{
			if (this.gclass4_0.method_1() != null)
			{
				GClass8 gclass = this.gclass4_0.method_1();
				AllianceMemberEntry allianceMemberEntry = gclass.Members[this.gclass4_0.AccountId];
				if (allianceMemberEntry.GetAllianceRole() == LogicAvatarAllianceRole.MEMBER)
				{
					AllianceInvitationSendFailedMessage allianceInvitationSendFailedMessage = new AllianceInvitationSendFailedMessage();
					allianceInvitationSendFailedMessage.SetReason(AllianceInvitationSendFailedMessage.Reason.NO_RIGHTS);
					this.gclass4_0.SendPiranhaMessage(allianceInvitationSendFailedMessage, 1);
					return;
				}
				AllianceInvitationAvatarStreamEntry allianceInvitationAvatarStreamEntry = new AllianceInvitationAvatarStreamEntry();
				allianceInvitationAvatarStreamEntry.SetSenderAvatarId(allianceMemberEntry.GetAvatarId());
				allianceInvitationAvatarStreamEntry.SetSenderHomeId(allianceMemberEntry.GetHomeId());
				allianceInvitationAvatarStreamEntry.SetSenderName(allianceMemberEntry.GetName());
				allianceInvitationAvatarStreamEntry.SetSenderLevel(allianceMemberEntry.GetExpLevel());
				allianceInvitationAvatarStreamEntry.SetSenderLeagueType(allianceMemberEntry.GetLeagueType());
				allianceInvitationAvatarStreamEntry.SetAllianceId(gclass.Id);
				allianceInvitationAvatarStreamEntry.SetAllianceName(gclass.Header.GetAllianceName());
				allianceInvitationAvatarStreamEntry.SetAllianceBadgeId(gclass.Header.GetAllianceBadgeId());
				allianceInvitationAvatarStreamEntry.SetAllianceLevel(gclass.Header.GetAllianceLevel());
				ServerRequestManager.Create(new GameCreateAllianceInvitationRequestMessage
				{
					AccountId = sendAllianceInvitationMessage_0.GetAvatarId(),
					Entry = allianceInvitationAvatarStreamEntry
				}, ServerManager.GetDocumentSocket(9, sendAllianceInvitationMessage_0.GetAvatarId()), 30).OnComplete = new ServerRequestArgs.CompleteHandler(this.method_13);
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000035BC File Offset: 0x000017BC
		private bool method_12()
		{
			return DateTime.UtcNow.Subtract(this.dateTime_0).TotalSeconds >= 1.0;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000035F4 File Offset: 0x000017F4
		[CompilerGenerated]
		private void method_13(ServerRequestArgs serverRequestArgs_0)
		{
			if (this.gclass4_0.IsDestructed())
			{
				return;
			}
			if (serverRequestArgs_0.ErrorCode != ServerRequestError.Success)
			{
				AllianceInvitationSendFailedMessage allianceInvitationSendFailedMessage = new AllianceInvitationSendFailedMessage();
				allianceInvitationSendFailedMessage.SetReason(AllianceInvitationSendFailedMessage.Reason.GENERIC);
				this.gclass4_0.SendPiranhaMessage(allianceInvitationSendFailedMessage, 1);
				return;
			}
			GameCreateAllianceInvitationResponseMessage gameCreateAllianceInvitationResponseMessage = (GameCreateAllianceInvitationResponseMessage)serverRequestArgs_0.ResponseMessage;
			if (gameCreateAllianceInvitationResponseMessage.Success)
			{
				this.gclass4_0.SendPiranhaMessage(new AllianceInvitationSentOkMessage(), 1);
				return;
			}
			AllianceInvitationSendFailedMessage allianceInvitationSendFailedMessage2 = new AllianceInvitationSendFailedMessage();
			switch (gameCreateAllianceInvitationResponseMessage.ErrorReason)
			{
			case GameCreateAllianceInvitationResponseMessage.Reason.GENERIC:
				allianceInvitationSendFailedMessage2.SetReason(AllianceInvitationSendFailedMessage.Reason.GENERIC);
				break;
			case GameCreateAllianceInvitationResponseMessage.Reason.NO_CASTLE:
				allianceInvitationSendFailedMessage2.SetReason(AllianceInvitationSendFailedMessage.Reason.NO_CASTLE);
				break;
			case GameCreateAllianceInvitationResponseMessage.Reason.ALREADY_IN_ALLIANCE:
				allianceInvitationSendFailedMessage2.SetReason(AllianceInvitationSendFailedMessage.Reason.ALREADY_IN_ALLIANCE);
				break;
			case GameCreateAllianceInvitationResponseMessage.Reason.ALREADY_HAS_AN_INVITE:
				allianceInvitationSendFailedMessage2.SetReason(AllianceInvitationSendFailedMessage.Reason.ALREADY_HAS_AN_INVITE);
				break;
			case GameCreateAllianceInvitationResponseMessage.Reason.HAS_TOO_MANY_INVITES:
				allianceInvitationSendFailedMessage2.SetReason(AllianceInvitationSendFailedMessage.Reason.HAS_TOO_MANY_INVITES);
				break;
			}
			this.gclass4_0.SendPiranhaMessage(allianceInvitationSendFailedMessage2, 1);
		}

		// Token: 0x04000007 RID: 7
		private readonly GClass4 gclass4_0;

		// Token: 0x04000008 RID: 8
		private DateTime dateTime_0;

		// Token: 0x0200000A RID: 10
		[CompilerGenerated]
		private sealed class Class1
		{
			// Token: 0x04000009 RID: 9
			public AllianceMemberEntry allianceMemberEntry_0;

			// Token: 0x0400000A RID: 10
			public GClass8 gclass8_0;

			// Token: 0x0400000B RID: 11
			public GClass6 gclass6_0;
		}

		// Token: 0x0200000B RID: 11
		[CompilerGenerated]
		private sealed class Class2
		{
			// Token: 0x06000030 RID: 48 RVA: 0x000036BC File Offset: 0x000018BC
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				if (this.class1_0.gclass6_0.gclass4_0.IsDestructed())
				{
					return;
				}
				if (serverRequestArgs_0.ErrorCode != ServerRequestError.Success)
				{
					AllianceInvitationSendFailedMessage allianceInvitationSendFailedMessage = new AllianceInvitationSendFailedMessage();
					allianceInvitationSendFailedMessage.SetReason(AllianceInvitationSendFailedMessage.Reason.GENERIC);
					this.class1_0.gclass6_0.gclass4_0.SendPiranhaMessage(allianceInvitationSendFailedMessage, 1);
					return;
				}
				if (serverRequestArgs_0.ResponseMessage.Success)
				{
					this.joinRequestAllianceStreamEntry_0.SetState(2);
					this.joinRequestAllianceStreamEntry_0.SetResponderName(this.class1_0.allianceMemberEntry_0.GetName());
					this.class1_0.gclass8_0.method_14(this.joinRequestAllianceStreamEntry_0);
					GClass10.smethod_12(this.joinRequestAllianceStreamEntry_0);
					return;
				}
				GameJoinAllianceResponseMessage gameJoinAllianceResponseMessage = (GameJoinAllianceResponseMessage)serverRequestArgs_0.ResponseMessage;
				AllianceInvitationSendFailedMessage allianceInvitationSendFailedMessage2 = new AllianceInvitationSendFailedMessage();
				GameJoinAllianceResponseMessage.Reason errorReason = gameJoinAllianceResponseMessage.ErrorReason;
				if (errorReason != GameJoinAllianceResponseMessage.Reason.NO_CASTLE)
				{
					if (errorReason != GameJoinAllianceResponseMessage.Reason.ALREADY_IN_ALLIANCE)
					{
						allianceInvitationSendFailedMessage2.SetReason(AllianceInvitationSendFailedMessage.Reason.GENERIC);
					}
					else
					{
						allianceInvitationSendFailedMessage2.SetReason(AllianceInvitationSendFailedMessage.Reason.ALREADY_IN_ALLIANCE);
						if (this.joinRequestAllianceStreamEntry_0.GetState() == 1)
						{
							this.class1_0.gclass8_0.method_15(this.joinRequestAllianceStreamEntry_0.GetId());
							GClass9.smethod_5(this.class1_0.gclass8_0);
						}
					}
				}
				else
				{
					allianceInvitationSendFailedMessage2.SetReason(AllianceInvitationSendFailedMessage.Reason.NO_CASTLE);
					if (this.joinRequestAllianceStreamEntry_0.GetState() == 1)
					{
						this.class1_0.gclass8_0.method_15(this.joinRequestAllianceStreamEntry_0.GetId());
						GClass9.smethod_5(this.class1_0.gclass8_0);
					}
				}
				this.class1_0.gclass6_0.gclass4_0.SendPiranhaMessage(allianceInvitationSendFailedMessage2, 1);
			}

			// Token: 0x0400000C RID: 12
			public JoinRequestAllianceStreamEntry joinRequestAllianceStreamEntry_0;

			// Token: 0x0400000D RID: 13
			public GClass6.Class1 class1_0;
		}
	}
}
