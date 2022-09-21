using System;
using System.Collections.Generic;
using System.Linq;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Logic.Message.Alliance.Stream;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Servers.Core.Network.Message;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace ns0
{
	// Token: 0x0200000F RID: 15
	public class GClass8 : AllianceDocument
	{
		// Token: 0x0600005B RID: 91 RVA: 0x00002266 File Offset: 0x00000466
		public GClass8()
		{
			this.dictionary_0 = new Dictionary<long, GClass4>();
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002279 File Offset: 0x00000479
		public GClass8(LogicLong logicLong_0) : base(logicLong_0)
		{
			this.dictionary_0 = new Dictionary<long, GClass4>();
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000053D8 File Offset: 0x000035D8
		public void method_0(AllianceMemberEntry allianceMemberEntry_0)
		{
			if (!base.Members.TryAdd(allianceMemberEntry_0.GetAvatarId(), allianceMemberEntry_0))
			{
				throw new Exception("Alliance.addMember: member already in this alliance!");
			}
			if (base.IsFull())
			{
				throw new Exception("Alliance.addMember: alliance is FULL!");
			}
			base.Header.SetNumberOfMembers(base.Members.Count);
			this.method_8();
			this.method_16(allianceMemberEntry_0);
			this.method_18();
			base.KickedMembersTimes.Remove(allianceMemberEntry_0.GetAvatarId());
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000545C File Offset: 0x0000365C
		public void method_1(LogicLong logicLong_0)
		{
			if (base.Members.Remove(logicLong_0))
			{
				GClass4 gclass;
				if (this.dictionary_0.Remove(logicLong_0, out gclass))
				{
					gclass.SendMessage(new StopServerSessionMessage(), 1);
					GClass5.smethod_5(gclass.Id);
				}
				base.Header.SetNumberOfMembers(base.Members.Count);
				this.method_17(logicLong_0);
				this.method_8();
				this.method_18();
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000054D4 File Offset: 0x000036D4
		public void method_2(LogicLong logicLong_0)
		{
			DateTime utcNow = DateTime.UtcNow;
			if (base.KickedMembersTimes.ContainsKey(logicLong_0))
			{
				base.KickedMembersTimes[logicLong_0] = DateTime.UtcNow;
			}
			else
			{
				base.KickedMembersTimes.Add(logicLong_0, DateTime.UtcNow);
			}
			foreach (KeyValuePair<long, DateTime> keyValuePair in base.KickedMembersTimes.ToArray<KeyValuePair<long, DateTime>>())
			{
				if (utcNow.Subtract(keyValuePair.Value).TotalDays >= 1.0)
				{
					base.KickedMembersTimes.Remove(keyValuePair.Key);
				}
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00005580 File Offset: 0x00003780
		public bool method_3(LogicLong logicLong_0)
		{
			DateTime value;
			if (base.KickedMembersTimes.TryGetValue(logicLong_0, out value))
			{
				if (DateTime.UtcNow.Subtract(value).TotalDays < 1.0)
				{
					return true;
				}
				base.KickedMembersTimes.Remove(logicLong_0);
			}
			return false;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000228D File Offset: 0x0000048D
		public void method_4(LogicLong logicLong_0, GClass4 gclass4_0)
		{
			if (!this.dictionary_0.TryAdd(logicLong_0, gclass4_0))
			{
				this.dictionary_0[logicLong_0] = gclass4_0;
			}
			this.method_18();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000055D8 File Offset: 0x000037D8
		public void method_5(LogicLong logicLong_0, GClass4 gclass4_0)
		{
			GClass4 gclass;
			if (this.dictionary_0.TryGetValue(logicLong_0, out gclass) && gclass.Id == gclass4_0.Id && this.dictionary_0.Remove(logicLong_0))
			{
				this.method_18();
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00005624 File Offset: 0x00003824
		public GClass4 method_6(LogicLong logicLong_0)
		{
			GClass4 result;
			if (this.dictionary_0.TryGetValue(logicLong_0, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000564C File Offset: 0x0000384C
		public void method_7(AllianceMemberEntry allianceMemberEntry_0, LogicAvatarAllianceRole logicAvatarAllianceRole_0, LogicLong logicLong_0, string string_0)
		{
			if (allianceMemberEntry_0.GetAllianceRole() != logicAvatarAllianceRole_0)
			{
				bool flag = allianceMemberEntry_0.HasLowerRoleThan(logicAvatarAllianceRole_0);
				allianceMemberEntry_0.SetAllianceRole(logicAvatarAllianceRole_0);
				LogicChangeAllianceRoleCommand logicChangeAllianceRoleCommand = new LogicChangeAllianceRoleCommand();
				logicChangeAllianceRoleCommand.SetData(base.Id, logicAvatarAllianceRole_0);
				ServerMessageManager.SendMessage(new GameAllowServerCommandMessage
				{
					AccountId = allianceMemberEntry_0.GetAvatarId(),
					ServerCommand = logicChangeAllianceRoleCommand
				}, 9);
				AllianceEventStreamEntry allianceEventStreamEntry = new AllianceEventStreamEntry();
				GClass3.smethod_0(allianceEventStreamEntry, allianceMemberEntry_0);
				allianceEventStreamEntry.SetEventAvatarId(logicLong_0);
				allianceEventStreamEntry.SetEventAvatarName(string_0);
				allianceEventStreamEntry.SetEventType(flag ? AllianceEventStreamEntryType.PROMOTED : AllianceEventStreamEntryType.DEMOTED);
				GClass10.smethod_7(base.Id, allianceEventStreamEntry);
				this.method_13(allianceEventStreamEntry);
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000022BB File Offset: 0x000004BB
		public void method_8()
		{
			this.method_10();
			this.method_11();
			this.method_12();
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000056E0 File Offset: 0x000038E0
		public void method_9(DateTime dateTime_0)
		{
			if (base.LastUpdateTime < dateTime_0)
			{
				int num = (int)base.LastUpdateTime.Subtract(dateTime_0).TotalSeconds;
				if (num < 30)
				{
					return;
				}
				foreach (AllianceMemberEntry allianceMemberEntry in base.Members.Values)
				{
					allianceMemberEntry.SetCreatedTime(allianceMemberEntry.GetCreatedTime() + num);
				}
				if (base.CheckRankingTime.Subtract(dateTime_0).TotalDays >= 1.0)
				{
					base.CheckRankingTime = dateTime_0.Date;
					foreach (AllianceMemberEntry allianceMemberEntry2 in base.Members.Values)
					{
						allianceMemberEntry2.SetPreviousOrder(allianceMemberEntry2.GetOrder());
						allianceMemberEntry2.SetPreviousOrderVillage2(allianceMemberEntry2.GetOrderVillage2());
					}
				}
				if (base.DonationTime.Subtract(dateTime_0).TotalDays >= 1.0)
				{
					base.DonationTime = new DateTime(dateTime_0.Year, dateTime_0.Month, 1);
					foreach (AllianceMemberEntry allianceMemberEntry3 in base.Members.Values)
					{
						if (allianceMemberEntry3.GetDonations() != 0 || allianceMemberEntry3.GetReceivedDonations() != 0)
						{
							allianceMemberEntry3.SetDonations(0);
							allianceMemberEntry3.SetReceivedDonations(0);
							ServerMessageManager.SendMessage(new GameAllianceDonationCountMessage
							{
								AccountId = allianceMemberEntry3.GetAvatarId(),
								DonationCount = 0,
								ReceivedDonationCount = 0
							}, 9);
						}
					}
				}
				base.LastUpdateTime = base.LastUpdateTime.AddSeconds((double)num);
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000058D4 File Offset: 0x00003AD4
		private void method_10()
		{
			LogicArrayList<AllianceMemberEntry> logicArrayList = new LogicArrayList<AllianceMemberEntry>(base.Members.Count);
			using (Dictionary<long, AllianceMemberEntry>.ValueCollection.Enumerator enumerator = base.Members.Values.GetEnumerator())
			{
				IL_72:
				while (enumerator.MoveNext())
				{
					AllianceMemberEntry allianceMemberEntry = enumerator.Current;
					int num = -1;
					for (int i = 0; i < logicArrayList.Size(); i++)
					{
						if (allianceMemberEntry.GetScore() > logicArrayList[i].GetScore())
						{
							num = i;
							IL_5E:
							logicArrayList.Add((num == -1) ? logicArrayList.Size() : num, allianceMemberEntry);
							goto IL_72;
						}
					}
					goto IL_5E;
				}
			}
			for (int j = 0; j < logicArrayList.Size(); j++)
			{
				logicArrayList[j].SetOrder(j + 1);
				if (logicArrayList[j].GetPreviousOrder() == 0)
				{
					logicArrayList[j].SetPreviousOrder(j + 1);
				}
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000059C4 File Offset: 0x00003BC4
		private void method_11()
		{
			LogicArrayList<AllianceMemberEntry> logicArrayList = new LogicArrayList<AllianceMemberEntry>(base.Members.Count);
			using (Dictionary<long, AllianceMemberEntry>.ValueCollection.Enumerator enumerator = base.Members.Values.GetEnumerator())
			{
				IL_72:
				while (enumerator.MoveNext())
				{
					AllianceMemberEntry allianceMemberEntry = enumerator.Current;
					int num = -1;
					for (int i = 0; i < logicArrayList.Size(); i++)
					{
						if (allianceMemberEntry.GetDuelScore() > logicArrayList[i].GetDuelScore())
						{
							num = i;
							IL_5E:
							logicArrayList.Add((num == -1) ? logicArrayList.Size() : num, allianceMemberEntry);
							goto IL_72;
						}
					}
					goto IL_5E;
				}
			}
			for (int j = 0; j < logicArrayList.Size(); j++)
			{
				logicArrayList[j].SetOrderVillage2(j + 1);
				if (logicArrayList[j].GetPreviousOrderVillage2() == 0)
				{
					logicArrayList[j].SetPreviousOrderVillage2(j + 1);
				}
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00005AB4 File Offset: 0x00003CB4
		private void method_12()
		{
			int num = 0;
			int num2 = 0;
			foreach (AllianceMemberEntry allianceMemberEntry in base.Members.Values)
			{
				num += allianceMemberEntry.GetScore();
				num2 += allianceMemberEntry.GetDuelScore();
			}
			base.Header.SetScore(num / 2 + ((num % 2 > 0) ? 1 : 0));
			base.Header.SetDuelScore(num2 / 2 + ((num2 % 2 > 0) ? 1 : 0));
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00005B50 File Offset: 0x00003D50
		public void method_13(StreamEntry streamEntry_0)
		{
			if (streamEntry_0.GetId().IsZero())
			{
				throw new Exception("Alliance.addStreamEntry: id should be set!");
			}
			while (base.StreamEntryList.Size() >= 100)
			{
				this.method_15(base.StreamEntryList[0]);
			}
			base.StreamEntryList.Add(streamEntry_0.GetId());
			this.method_19(streamEntry_0);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000022CF File Offset: 0x000004CF
		public void method_14(StreamEntry streamEntry_0)
		{
			this.method_19(streamEntry_0);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00005BB0 File Offset: 0x00003DB0
		public void method_15(LogicLong logicLong_0)
		{
			int num = base.StreamEntryList.IndexOf(logicLong_0);
			if (num != -1)
			{
				base.StreamEntryList.Remove(num);
				this.method_20(logicLong_0);
				GClass10.smethod_15(logicLong_0);
				return;
			}
			Logging.Warning("Alliance.removeStreamEntry: unknown stream entry id: " + logicLong_0);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00005C04 File Offset: 0x00003E04
		private void method_16(AllianceMemberEntry allianceMemberEntry_0)
		{
			AllianceMemberMessage allianceMemberMessage = new AllianceMemberMessage();
			allianceMemberMessage.SetAllianceMemberEntry(allianceMemberEntry_0);
			this.method_24(allianceMemberMessage, 1);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00005C28 File Offset: 0x00003E28
		private void method_17(LogicLong logicLong_0)
		{
			AllianceMemberRemovedMessage allianceMemberRemovedMessage = new AllianceMemberRemovedMessage();
			allianceMemberRemovedMessage.SetMemberAvatarId(logicLong_0);
			this.method_24(allianceMemberRemovedMessage, 1);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00005C4C File Offset: 0x00003E4C
		private void method_18()
		{
			AllianceOnlineStatusUpdatedMessage allianceOnlineStatusUpdatedMessage = new AllianceOnlineStatusUpdatedMessage();
			allianceOnlineStatusUpdatedMessage.SetMembersCount(base.Members.Count);
			allianceOnlineStatusUpdatedMessage.SetMembersOnline(this.dictionary_0.Count);
			this.method_24(allianceOnlineStatusUpdatedMessage, 1);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00005C8C File Offset: 0x00003E8C
		private void method_19(StreamEntry streamEntry_0)
		{
			AllianceStreamEntryMessage allianceStreamEntryMessage = new AllianceStreamEntryMessage();
			allianceStreamEntryMessage.SetStreamEntry(streamEntry_0);
			this.method_24(allianceStreamEntryMessage, 1);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00005CB0 File Offset: 0x00003EB0
		private void method_20(LogicLong logicLong_0)
		{
			AllianceStreamEntryRemovedMessage allianceStreamEntryRemovedMessage = new AllianceStreamEntryRemovedMessage();
			allianceStreamEntryRemovedMessage.SetStreamEntryId(logicLong_0);
			this.method_24(allianceStreamEntryRemovedMessage, 1);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00005CD4 File Offset: 0x00003ED4
		public AllianceDataMessage method_21()
		{
			this.method_9(DateTime.UtcNow);
			AllianceDataMessage allianceDataMessage = new AllianceDataMessage();
			AllianceFullEntry allianceFullEntry = new AllianceFullEntry();
			LogicArrayList<AllianceMemberEntry> logicArrayList = new LogicArrayList<AllianceMemberEntry>(base.Members.Count);
			allianceFullEntry.SetAllianceHeaderEntry(base.Header);
			allianceFullEntry.SetAllianceDescription(base.Description);
			allianceFullEntry.SetAllianceMembers(logicArrayList);
			foreach (AllianceMemberEntry item in base.Members.Values)
			{
				logicArrayList.Add(item);
			}
			allianceDataMessage.SetAllianceFullEntry(allianceFullEntry);
			return allianceDataMessage;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000022D8 File Offset: 0x000004D8
		public AllianceFullEntryUpdateMessage method_22()
		{
			AllianceFullEntryUpdateMessage allianceFullEntryUpdateMessage = new AllianceFullEntryUpdateMessage();
			allianceFullEntryUpdateMessage.SetAllianceHeaderEntry(base.Header);
			allianceFullEntryUpdateMessage.SetDescription(base.Description);
			return allianceFullEntryUpdateMessage;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00005D80 File Offset: 0x00003F80
		public AllianceStreamMessage method_23()
		{
			AllianceStreamMessage allianceStreamMessage = new AllianceStreamMessage();
			LogicArrayList<StreamEntry> logicArrayList = new LogicArrayList<StreamEntry>(base.StreamEntryList.Size());
			for (int i = 0; i < base.StreamEntryList.Size(); i++)
			{
				StreamEntry streamEntry = GClass10.smethod_3(base.StreamEntryList[i]);
				if (streamEntry != null)
				{
					logicArrayList.Add(streamEntry);
				}
			}
			allianceStreamMessage.SetStreamEntries(logicArrayList);
			return allianceStreamMessage;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00005DE0 File Offset: 0x00003FE0
		public void method_24(PiranhaMessage piranhaMessage_0, int int_1)
		{
			foreach (GClass4 gclass in this.dictionary_0.Values)
			{
				gclass.SendPiranhaMessage(piranhaMessage_0, int_1);
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00005E38 File Offset: 0x00004038
		public void method_25(LogicServerCommand logicServerCommand_0)
		{
			foreach (long @long in base.Members.Keys)
			{
				ServerMessageManager.SendMessage(new GameAllowServerCommandMessage
				{
					AccountId = @long,
					ServerCommand = logicServerCommand_0
				}, 9);
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00005EAC File Offset: 0x000040AC
		public void method_26(string string_0, AllianceType allianceType_0, int int_1, int int_2, int int_3, int int_4, LogicData logicData_0, bool bool_0, bool bool_1)
		{
			int allianceLevel = base.Header.GetAllianceLevel();
			if (string_0 == null)
			{
				string_0 = string.Empty;
			}
			if (string_0.Length > 128)
			{
				string_0 = string_0.Substring(0, 128);
			}
			allianceType_0 = (AllianceType)LogicMath.Clamp((int)allianceType_0, 1, 3);
			LogicAllianceBadgeLayerData logicAllianceBadgeLayerData;
			LogicAllianceBadgeLayerData logicAllianceBadgeLayerData2;
			LogicAllianceBadgeLayerData logicAllianceBadgeLayerData3;
			GClass1.smethod_0(int_1, out logicAllianceBadgeLayerData, out logicAllianceBadgeLayerData2, out logicAllianceBadgeLayerData3);
			if (logicAllianceBadgeLayerData != null && logicAllianceBadgeLayerData.GetRequiredClanLevel() > allianceLevel)
			{
				logicAllianceBadgeLayerData = GClass1.smethod_2(LogicAllianceBadgeLayerType.MIDDLE, allianceLevel);
			}
			if (logicAllianceBadgeLayerData2 != null && logicAllianceBadgeLayerData2.GetRequiredClanLevel() > allianceLevel)
			{
				logicAllianceBadgeLayerData2 = GClass1.smethod_2(LogicAllianceBadgeLayerType.BACKGROUND, allianceLevel);
			}
			if (logicAllianceBadgeLayerData3 != null && logicAllianceBadgeLayerData3.GetRequiredClanLevel() > allianceLevel)
			{
				logicAllianceBadgeLayerData3 = GClass1.smethod_2(LogicAllianceBadgeLayerType.FOREGROUND, allianceLevel);
			}
			int_1 = GClass1.smethod_1(logicAllianceBadgeLayerData, logicAllianceBadgeLayerData2, logicAllianceBadgeLayerData3);
			if (logicData_0 != null && logicData_0.GetDataType() != LogicDataType.REGION)
			{
				logicData_0 = null;
			}
			base.Description = string_0;
			base.Header.SetAllianceType(allianceType_0);
			base.Header.SetAllianceBadgeId(int_1);
			base.Header.SetRequiredScore(int_2);
			base.Header.SetRequiredDuelScore(int_3);
			base.Header.SetWarFrequency(int_4);
			base.Header.SetOriginData(logicData_0);
			base.Header.SetPublicWarLog(bool_0);
			base.Header.SetArrangedWarEnabled(bool_1);
			if (base.Members.Count != 0)
			{
				LogicAllianceSettingsChangedCommand logicAllianceSettingsChangedCommand = new LogicAllianceSettingsChangedCommand();
				logicAllianceSettingsChangedCommand.SetAllianceData(base.Id, int_1);
				this.method_25(logicAllianceSettingsChangedCommand);
				this.method_24(this.method_22(), 1);
			}
		}

		// Token: 0x04000013 RID: 19
		public const int int_0 = 100;

		// Token: 0x04000014 RID: 20
		private readonly Dictionary<long, GClass4> dictionary_0;
	}
}
