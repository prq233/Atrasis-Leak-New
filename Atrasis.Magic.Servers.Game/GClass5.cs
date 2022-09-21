using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Network;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Request.Stream;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Servers.Core.Network.Message.Session.State;
using Atrasis.Magic.Servers.Core.Network.Request;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.Math;

namespace ns0
{
	// Token: 0x0200000F RID: 15
	public class GClass5 : GameDocument
	{
		// Token: 0x06000061 RID: 97 RVA: 0x000023E6 File Offset: 0x000005E6
		[CompilerGenerated]
		public GClass1 method_0()
		{
			return this.gclass1_0;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000023EE File Offset: 0x000005EE
		[CompilerGenerated]
		public void method_1(GClass1 gclass1_1)
		{
			this.gclass1_0 = gclass1_1;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000023F7 File Offset: 0x000005F7
		[CompilerGenerated]
		public GClass6 method_2()
		{
			return this.gclass6_0;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000023FF File Offset: 0x000005FF
		[CompilerGenerated]
		public void method_3(GClass6 gclass6_1)
		{
			this.gclass6_0 = gclass6_1;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002408 File Offset: 0x00000608
		[CompilerGenerated]
		public GClass17 method_4()
		{
			return this.gclass17_0;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00002410 File Offset: 0x00000610
		[CompilerGenerated]
		public void method_5(GClass17 gclass17_1)
		{
			this.gclass17_0 = gclass17_1;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002419 File Offset: 0x00000619
		[CompilerGenerated]
		public DateTime method_6()
		{
			return this.dateTime_0;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002421 File Offset: 0x00000621
		[CompilerGenerated]
		public void method_7(DateTime dateTime_1)
		{
			this.dateTime_0 = dateTime_1;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000242A File Offset: 0x0000062A
		[CompilerGenerated]
		public bool method_8()
		{
			return this.bool_0;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002432 File Offset: 0x00000632
		[CompilerGenerated]
		public void method_9(bool bool_1)
		{
			this.bool_0 = bool_1;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000243B File Offset: 0x0000063B
		public GClass5()
		{
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002443 File Offset: 0x00000643
		public GClass5(LogicLong logicLong_0) : base(logicLong_0)
		{
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000507C File Offset: 0x0000327C
		public bool method_10(LogicCommandType logicCommandType_0)
		{
			for (int i = 0; i < base.ServerCommands.Size(); i++)
			{
				if (base.ServerCommands[i].GetCommandType() == logicCommandType_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000244C File Offset: 0x0000064C
		public void method_11(LogicLong logicLong_0)
		{
			if (base.RecentlyMatchedEnemies.Size() > 50)
			{
				base.RecentlyMatchedEnemies.Remove(0);
			}
			base.RecentlyMatchedEnemies.Add(new GameDocument.RecentlyEnemy(logicLong_0, TimeUtil.GetTimestamp()));
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000050B8 File Offset: 0x000032B8
		public bool method_12(LogicLong logicLong_0)
		{
			int timestamp = TimeUtil.GetTimestamp();
			for (int i = 0; i < base.RecentlyMatchedEnemies.Size(); i++)
			{
				GameDocument.RecentlyEnemy recentlyEnemy = base.RecentlyMatchedEnemies[i];
				if (LogicLong.Equals(recentlyEnemy.AvatarId, logicLong_0) && timestamp - recentlyEnemy.Timestamp <= 900)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00005110 File Offset: 0x00003310
		public void method_13(LogicServerCommand logicServerCommand_0)
		{
			int num = -1;
			for (int i = 0; i < base.ServerCommands.Size(); i++)
			{
				if (base.ServerCommands[i].GetId() > num)
				{
					num = base.ServerCommands[i].GetId();
				}
			}
			logicServerCommand_0.SetId(num + 1);
			base.ServerCommands.Add(logicServerCommand_0);
			if (this.method_0() != null && this.method_0().method_2() != null && this.method_0().method_2().GetGameStateType() == GameStateType.HOME)
			{
				this.method_0().SendMessage(new HomeServerCommandAllowedMessage
				{
					ServerCommand = logicServerCommand_0
				}, 10);
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000247F File Offset: 0x0000067F
		public void method_14(LogicLong logicLong_0)
		{
			if (base.AllianceBookmarksList.IndexOf(logicLong_0) == -1)
			{
				base.AllianceBookmarksList.Add(logicLong_0);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000051B0 File Offset: 0x000033B0
		public void method_15(LogicLong logicLong_0)
		{
			int num = base.AllianceBookmarksList.IndexOf(logicLong_0);
			if (num != -1)
			{
				base.AllianceBookmarksList.Remove(num);
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000051DC File Offset: 0x000033DC
		private void method_16(AvatarStreamEntry avatarStreamEntry_0)
		{
			if (base.AvatarStreamList.Size() >= 50)
			{
				this.method_17(base.AvatarStreamList[0]);
			}
			base.AvatarStreamList.Add(avatarStreamEntry_0.GetId());
			if (this.method_0() != null)
			{
				AvatarStreamEntryMessage avatarStreamEntryMessage = new AvatarStreamEntryMessage();
				avatarStreamEntryMessage.SetAvatarStreamEntry(avatarStreamEntry_0);
				this.method_0().SendPiranhaMessage(avatarStreamEntryMessage, 1);
				if (avatarStreamEntry_0.IsNew())
				{
					ServerMessageManager.SendMessage(new AvatarStreamSeenMessage
					{
						AccountId = avatarStreamEntry_0.GetId()
					}, 11);
					return;
				}
			}
			else
			{
				GClass7.smethod_7(this);
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00005264 File Offset: 0x00003464
		public void method_17(LogicLong logicLong_0)
		{
			int num = base.AvatarStreamList.IndexOf(logicLong_0);
			if (num != -1)
			{
				base.AvatarStreamList.Remove(num);
				ServerMessageManager.SendMessage(new RemoveAvatarStreamMessage
				{
					AccountId = logicLong_0
				}, ServerManager.GetDocumentSocket(11, base.Id));
				if (this.method_0() != null)
				{
					AvatarStreamEntryRemovedMessage avatarStreamEntryRemovedMessage = new AvatarStreamEntryRemovedMessage();
					avatarStreamEntryRemovedMessage.SetStreamEntryId(logicLong_0);
					this.method_0().SendPiranhaMessage(avatarStreamEntryRemovedMessage, 1);
					return;
				}
				GClass7.smethod_7(this);
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000052D8 File Offset: 0x000034D8
		public void method_18(Village2AttackEntry village2AttackEntry_0)
		{
			if (base.Village2AttackList.Size() >= 50)
			{
				this.method_19(base.Village2AttackList[0]);
			}
			base.Village2AttackList.Add(village2AttackEntry_0.GetId());
			if (this.method_0() != null)
			{
				Village2AttackEntryAddedMessage village2AttackEntryAddedMessage = new Village2AttackEntryAddedMessage();
				village2AttackEntryAddedMessage.SetAttackEntry(village2AttackEntry_0);
				this.method_0().SendPiranhaMessage(village2AttackEntryAddedMessage, 1);
				return;
			}
			GClass7.smethod_7(this);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00005340 File Offset: 0x00003540
		public void method_19(LogicLong logicLong_0)
		{
			int num = base.Village2AttackList.IndexOf(logicLong_0);
			if (num != -1)
			{
				base.Village2AttackList.Remove(num);
				if (this.method_0() != null)
				{
					Village2AttackEntryRemovedMessage village2AttackEntryRemovedMessage = new Village2AttackEntryRemovedMessage();
					village2AttackEntryRemovedMessage.SetStreamId(logicLong_0);
					this.method_0().SendPiranhaMessage(village2AttackEntryRemovedMessage, 1);
					return;
				}
				GClass7.smethod_7(this);
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00005394 File Offset: 0x00003594
		public void method_20(ServerRequestArgs serverRequestArgs_0)
		{
			if (serverRequestArgs_0.ErrorCode == ServerRequestError.Success && serverRequestArgs_0.ResponseMessage.Success)
			{
				this.method_16(((CreateAvatarStreamResponseMessage)serverRequestArgs_0.ResponseMessage).Entry);
				return;
			}
			Logging.Warning("GameAvatar.onAvatarStreamCreated: The stream server " + serverRequestArgs_0.ResponseMessage.Sender + " could not create a stream.");
		}

		// Token: 0x04000018 RID: 24
		[CompilerGenerated]
		private GClass1 gclass1_0;

		// Token: 0x04000019 RID: 25
		[CompilerGenerated]
		private GClass6 gclass6_0;

		// Token: 0x0400001A RID: 26
		[CompilerGenerated]
		private GClass17 gclass17_0;

		// Token: 0x0400001B RID: 27
		[CompilerGenerated]
		private DateTime dateTime_0;

		// Token: 0x0400001C RID: 28
		[CompilerGenerated]
		private bool bool_0;
	}
}
