using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Message.Avatar;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Logic.Message.Home;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Servers.Core.Network.Message.Request.Stream;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace ns0
{
	// Token: 0x02000007 RID: 7
	public class GClass3
	{
		// Token: 0x0600002A RID: 42 RVA: 0x0000225D File Offset: 0x0000045D
		public GClass3(GClass1 gclass1_1)
		{
			this.gclass1_0 = gclass1_1;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003268 File Offset: 0x00001468
		public void method_0(PiranhaMessage piranhaMessage_0)
		{
			short messageType = piranhaMessage_0.GetMessageType();
			if (messageType <= 14344)
			{
				if (messageType <= 14103)
				{
					if (messageType == 10212)
					{
						this.method_1((ChangeAvatarNameMessage)piranhaMessage_0);
						return;
					}
					if (messageType != 14103)
					{
						return;
					}
					this.method_3((CancelMatchmakingMessage)piranhaMessage_0);
					return;
				}
				else
				{
					if (messageType == 14114)
					{
						this.method_4((HomeBattleReplayMessage)piranhaMessage_0);
						return;
					}
					switch (messageType)
					{
					case 14341:
						this.method_6((AskForAllianceBookmarksFullDataMessage)piranhaMessage_0);
						return;
					case 14342:
						break;
					case 14343:
						this.method_7((AddAllianceBookmarkMessage)piranhaMessage_0);
						return;
					case 14344:
						this.method_8((RemoveAllianceBookmarkMessage)piranhaMessage_0);
						return;
					default:
						return;
					}
				}
			}
			else if (messageType <= 14418)
			{
				if (messageType == 14407)
				{
					this.method_9((ClaimDiamondsStreamEntryMessage)piranhaMessage_0);
					return;
				}
				if (messageType != 14418)
				{
					return;
				}
				this.method_10((RemoveAvatarStreamEntryMessage)piranhaMessage_0);
				return;
			}
			else
			{
				if (messageType == 14600)
				{
					this.method_2((AvatarNameCheckRequestMessage)piranhaMessage_0);
					return;
				}
				if (messageType != 15110)
				{
					return;
				}
				this.method_11((Village2AttackStartSpectateMessage)piranhaMessage_0);
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003370 File Offset: 0x00001570
		private void method_1(ChangeAvatarNameMessage changeAvatarNameMessage_0)
		{
			if (changeAvatarNameMessage_0.GetNameSetByUser())
			{
				string text = changeAvatarNameMessage_0.RemoveAvatarName();
				if (text == null)
				{
					return;
				}
				text = StringUtil.RemoveMultipleSpaces(text.Trim());
				if (text.Length < 2)
				{
					AvatarNameChangeFailedMessage avatarNameChangeFailedMessage = new AvatarNameChangeFailedMessage();
					avatarNameChangeFailedMessage.SetErrorCode(AvatarNameChangeFailedMessage.ErrorCode.TOO_SHORT);
					this.gclass1_0.SendPiranhaMessage(avatarNameChangeFailedMessage, 1);
					return;
				}
				if (text.Length > 16)
				{
					AvatarNameChangeFailedMessage avatarNameChangeFailedMessage2 = new AvatarNameChangeFailedMessage();
					avatarNameChangeFailedMessage2.SetErrorCode(AvatarNameChangeFailedMessage.ErrorCode.TOO_LONG);
					this.gclass1_0.SendPiranhaMessage(avatarNameChangeFailedMessage2, 1);
					return;
				}
				if (WordCensorUtil.IsValidMessage(text))
				{
					LogicClientAvatar logicClientAvatar = this.gclass1_0.method_1().LogicClientAvatar;
					if (logicClientAvatar.GetNameChangeState() >= 1)
					{
						AvatarNameChangeFailedMessage avatarNameChangeFailedMessage3 = new AvatarNameChangeFailedMessage();
						avatarNameChangeFailedMessage3.SetErrorCode(AvatarNameChangeFailedMessage.ErrorCode.ALREADY_CHANGED);
						this.gclass1_0.SendPiranhaMessage(avatarNameChangeFailedMessage3, 1);
						return;
					}
					if (logicClientAvatar.GetNameChangeState() == 0 && logicClientAvatar.GetTownHallLevel() < LogicDataTables.GetGlobals().GetEnableNameChangeTownHallLevel())
					{
						AvatarNameChangeFailedMessage avatarNameChangeFailedMessage4 = new AvatarNameChangeFailedMessage();
						avatarNameChangeFailedMessage4.SetErrorCode(AvatarNameChangeFailedMessage.ErrorCode.TH_LEVEL_TOO_LOW);
						this.gclass1_0.SendPiranhaMessage(avatarNameChangeFailedMessage4, 1);
						return;
					}
					LogicChangeAvatarNameCommand logicChangeAvatarNameCommand = new LogicChangeAvatarNameCommand();
					logicChangeAvatarNameCommand.SetAvatarName(text);
					logicChangeAvatarNameCommand.SetAvatarNameChangeState(logicClientAvatar.GetNameChangeState() + 1);
					this.gclass1_0.method_1().LogicClientAvatar.SetName(text);
					this.gclass1_0.method_1().LogicClientAvatar.SetNameChangeState(logicClientAvatar.GetNameChangeState() + 1);
					this.gclass1_0.method_1().method_13(logicChangeAvatarNameCommand);
					return;
				}
				else
				{
					AvatarNameChangeFailedMessage avatarNameChangeFailedMessage5 = new AvatarNameChangeFailedMessage();
					avatarNameChangeFailedMessage5.SetErrorCode(AvatarNameChangeFailedMessage.ErrorCode.BAD_WORD);
					this.gclass1_0.SendPiranhaMessage(avatarNameChangeFailedMessage5, 1);
				}
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000034E4 File Offset: 0x000016E4
		private void method_2(AvatarNameCheckRequestMessage avatarNameCheckRequestMessage_0)
		{
			string text = avatarNameCheckRequestMessage_0.GetName();
			if (text == null)
			{
				return;
			}
			text = StringUtil.RemoveMultipleSpaces(text.Trim());
			if (text.Length < 2)
			{
				AvatarNameCheckResponseMessage avatarNameCheckResponseMessage = new AvatarNameCheckResponseMessage();
				avatarNameCheckResponseMessage.SetName(avatarNameCheckRequestMessage_0.GetName());
				avatarNameCheckResponseMessage.SetInvalid(true);
				avatarNameCheckResponseMessage.SetErrorCode(AvatarNameCheckResponseMessage.ErrorCode.NAME_TOO_SHORT);
				this.gclass1_0.SendPiranhaMessage(avatarNameCheckResponseMessage, 1);
				return;
			}
			if (text.Length > 16)
			{
				AvatarNameCheckResponseMessage avatarNameCheckResponseMessage2 = new AvatarNameCheckResponseMessage();
				avatarNameCheckResponseMessage2.SetName(avatarNameCheckRequestMessage_0.GetName());
				avatarNameCheckResponseMessage2.SetInvalid(true);
				avatarNameCheckResponseMessage2.SetErrorCode(AvatarNameCheckResponseMessage.ErrorCode.NAME_TOO_LONG);
				this.gclass1_0.SendPiranhaMessage(avatarNameCheckResponseMessage2, 1);
				return;
			}
			if (!WordCensorUtil.IsValidMessage(text))
			{
				AvatarNameCheckResponseMessage avatarNameCheckResponseMessage3 = new AvatarNameCheckResponseMessage();
				avatarNameCheckResponseMessage3.SetName(avatarNameCheckRequestMessage_0.GetName());
				avatarNameCheckResponseMessage3.SetInvalid(true);
				avatarNameCheckResponseMessage3.SetErrorCode(AvatarNameCheckResponseMessage.ErrorCode.INVALID_NAME);
				this.gclass1_0.SendPiranhaMessage(avatarNameCheckResponseMessage3, 1);
				return;
			}
			LogicClientAvatar logicClientAvatar = this.gclass1_0.method_1().LogicClientAvatar;
			if (logicClientAvatar.GetNameChangeState() >= 1)
			{
				AvatarNameCheckResponseMessage avatarNameCheckResponseMessage4 = new AvatarNameCheckResponseMessage();
				avatarNameCheckResponseMessage4.SetName(avatarNameCheckRequestMessage_0.GetName());
				avatarNameCheckResponseMessage4.SetInvalid(true);
				avatarNameCheckResponseMessage4.SetErrorCode(AvatarNameCheckResponseMessage.ErrorCode.NAME_ALREADY_CHANGED);
				this.gclass1_0.SendPiranhaMessage(avatarNameCheckResponseMessage4, 1);
				return;
			}
			if (logicClientAvatar.GetNameChangeState() == 0 && logicClientAvatar.GetTownHallLevel() < LogicDataTables.GetGlobals().GetEnableNameChangeTownHallLevel())
			{
				AvatarNameCheckResponseMessage avatarNameCheckResponseMessage5 = new AvatarNameCheckResponseMessage();
				avatarNameCheckResponseMessage5.SetName(avatarNameCheckRequestMessage_0.GetName());
				avatarNameCheckResponseMessage5.SetInvalid(true);
				avatarNameCheckResponseMessage5.SetErrorCode(AvatarNameCheckResponseMessage.ErrorCode.NAME_TH_LEVEL_TOO_LOW);
				this.gclass1_0.SendPiranhaMessage(avatarNameCheckResponseMessage5, 1);
				return;
			}
			AvatarNameCheckResponseMessage avatarNameCheckResponseMessage6 = new AvatarNameCheckResponseMessage();
			avatarNameCheckResponseMessage6.SetName(avatarNameCheckRequestMessage_0.GetName());
			this.gclass1_0.SendPiranhaMessage(avatarNameCheckResponseMessage6, 1);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000226C File Offset: 0x0000046C
		private void method_3(CancelMatchmakingMessage cancelMatchmakingMessage_0)
		{
			if (this.gclass1_0.method_8())
			{
				GClass9.smethod_4(this.gclass1_0);
				if (!this.gclass1_0.method_8())
				{
					this.gclass1_0.method_23();
				}
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000229E File Offset: 0x0000049E
		private void method_4(HomeBattleReplayMessage homeBattleReplayMessage_0)
		{
			ServerRequestManager.Create(new LoadReplayStreamRequestMessage
			{
				Id = homeBattleReplayMessage_0.GetReplayId()
			}, ServerManager.GetDocumentSocket(11, this.gclass1_0.AccountId), 5).OnComplete = new ServerRequestArgs.CompleteHandler(this.method_5);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003674 File Offset: 0x00001874
		private void method_5(ServerRequestArgs serverRequestArgs_0)
		{
			if (serverRequestArgs_0.ErrorCode != ServerRequestError.Success || !serverRequestArgs_0.ResponseMessage.Success || this.gclass1_0.IsDestructed())
			{
				this.gclass1_0.SendPiranhaMessage(new HomeBattleReplayFailedMessage(), 1);
				return;
			}
			LoadReplayStreamResponseMessage loadReplayStreamResponseMessage = (LoadReplayStreamResponseMessage)serverRequestArgs_0.ResponseMessage;
			if (loadReplayStreamResponseMessage.MajorVersion == 9 && loadReplayStreamResponseMessage.BuildVersion == 256 && loadReplayStreamResponseMessage.ContentVersion == ResourceManager.GetContentVersion())
			{
				HomeBattleReplayDataMessage homeBattleReplayDataMessage = new HomeBattleReplayDataMessage();
				homeBattleReplayDataMessage.SetReplayData(loadReplayStreamResponseMessage.StreamData);
				this.gclass1_0.SendPiranhaMessage(homeBattleReplayDataMessage, 1);
				return;
			}
			this.gclass1_0.SendPiranhaMessage(new HomeBattleReplayFailedMessage(), 1);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000022DA File Offset: 0x000004DA
		private void method_6(AskForAllianceBookmarksFullDataMessage askForAllianceBookmarksFullDataMessage_0)
		{
			ServerMessageManager.SendMessage(new SendAllianceBookmarksFullDataToClientMessage
			{
				SessionId = this.gclass1_0.Id,
				AllianceIds = this.gclass1_0.method_1().AllianceBookmarksList
			}, ServerManager.GetNextSocket(29));
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002314 File Offset: 0x00000514
		private void method_7(AddAllianceBookmarkMessage addAllianceBookmarkMessage_0)
		{
			if (this.gclass1_0.method_1().AllianceBookmarksList.Size() < LogicDataTables.GetGlobals().GetBookmarksMaxAlliances())
			{
				this.gclass1_0.method_1().method_14(addAllianceBookmarkMessage_0.GetAllianceId());
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000234D File Offset: 0x0000054D
		private void method_8(RemoveAllianceBookmarkMessage removeAllianceBookmarkMessage_0)
		{
			this.gclass1_0.method_1().method_15(removeAllianceBookmarkMessage_0.GetAllianceId());
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003718 File Offset: 0x00001918
		private void method_9(ClaimDiamondsStreamEntryMessage claimDiamondsStreamEntryMessage_0)
		{
			GClass3.Class2 @class = new GClass3.Class2();
			@class.gclass3_0 = this;
			@class.logicLong_0 = claimDiamondsStreamEntryMessage_0.RemoveStreamEntryId();
			ServerRequestManager.Create(new LoadAvatarStreamRequestMessage
			{
				Id = @class.logicLong_0
			}, ServerManager.GetDocumentSocket(11, this.gclass1_0.AccountId), 30).OnComplete = new ServerRequestArgs.CompleteHandler(@class.method_0);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002365 File Offset: 0x00000565
		private void method_10(RemoveAvatarStreamEntryMessage removeAvatarStreamEntryMessage_0)
		{
			this.gclass1_0.method_1().method_17(removeAvatarStreamEntryMessage_0.GetStreamEntryId());
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000377C File Offset: 0x0000197C
		private void method_11(Village2AttackStartSpectateMessage village2AttackStartSpectateMessage_0)
		{
			if (this.gclass1_0.method_1().method_4() != null)
			{
				LogicLong logicLong = this.gclass1_0.method_1().method_4().method_14(this.gclass1_0.method_1());
				if (logicLong != null)
				{
					this.gclass1_0.method_11(logicLong);
					this.gclass1_0.method_13(1);
					ServerRequestManager.Create(new LiveReplayAddSpectatorRequestMessage
					{
						LiveReplayId = this.gclass1_0.method_10(),
						SlotId = this.gclass1_0.method_12(),
						SessionId = this.gclass1_0.Id
					}, ServerManager.GetDocumentSocket(9, this.gclass1_0.method_10()), 30).OnComplete = new ServerRequestArgs.CompleteHandler(this.method_12);
				}
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000237D File Offset: 0x0000057D
		[CompilerGenerated]
		private void method_12(ServerRequestArgs serverRequestArgs_0)
		{
			if (serverRequestArgs_0.ErrorCode != ServerRequestError.Success || !serverRequestArgs_0.ResponseMessage.Success)
			{
				this.gclass1_0.method_11(-1L);
				this.gclass1_0.method_13(0);
			}
		}

		// Token: 0x0400000E RID: 14
		private readonly GClass1 gclass1_0;

		// Token: 0x02000008 RID: 8
		[CompilerGenerated]
		private sealed class Class2
		{
			// Token: 0x06000039 RID: 57 RVA: 0x00003850 File Offset: 0x00001A50
			internal void method_0(ServerRequestArgs serverRequestArgs_0)
			{
				if (this.gclass3_0.gclass1_0.IsDestructed())
				{
					return;
				}
				if (this.gclass3_0.gclass1_0.method_1().AvatarStreamList.IndexOf(this.logicLong_0) == -1)
				{
					return;
				}
				if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
				{
					AdminMessageAvatarStreamEntry adminMessageAvatarStreamEntry = (AdminMessageAvatarStreamEntry)((LoadAvatarStreamResponseMessage)serverRequestArgs_0.ResponseMessage).Entry;
					if (!adminMessageAvatarStreamEntry.IsClaimed())
					{
						adminMessageAvatarStreamEntry.SetClaimed(true);
						ServerMessageManager.SendMessage(new UpdateAvatarStreamMessage
						{
							AccountId = this.logicLong_0,
							Entry = adminMessageAvatarStreamEntry
						}, ServerManager.GetDocumentSocket(11, this.gclass3_0.gclass1_0.AccountId));
						AvatarStreamEntryMessage avatarStreamEntryMessage = new AvatarStreamEntryMessage();
						avatarStreamEntryMessage.SetAvatarStreamEntry(adminMessageAvatarStreamEntry);
						this.gclass3_0.gclass1_0.SendPiranhaMessage(avatarStreamEntryMessage, 1);
						LogicDiamondsAddedCommand logicDiamondsAddedCommand = new LogicDiamondsAddedCommand();
						logicDiamondsAddedCommand.SetData(true, adminMessageAvatarStreamEntry.GetDiamondCount(), 0, false, 1, null);
						this.gclass3_0.gclass1_0.method_1().method_13(logicDiamondsAddedCommand);
					}
				}
			}

			// Token: 0x0400000F RID: 15
			public GClass3 gclass3_0;

			// Token: 0x04000010 RID: 16
			public LogicLong logicLong_0;
		}
	}
}
