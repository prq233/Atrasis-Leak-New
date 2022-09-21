using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000F2 RID: 242
	public class AccountDocument : CouchbaseDocument
	{
		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000715 RID: 1813 RVA: 0x00008EA0 File Offset: 0x000070A0
		// (set) Token: 0x06000716 RID: 1814 RVA: 0x00008EA8 File Offset: 0x000070A8
		public string PassToken { get; private set; }

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x00008EB1 File Offset: 0x000070B1
		// (set) Token: 0x06000718 RID: 1816 RVA: 0x00008EB9 File Offset: 0x000070B9
		public string Country { get; set; }

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000719 RID: 1817 RVA: 0x00008EC2 File Offset: 0x000070C2
		// (set) Token: 0x0600071A RID: 1818 RVA: 0x00008ECA File Offset: 0x000070CA
		public string FacebookId { get; set; }

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x0600071B RID: 1819 RVA: 0x00008ED3 File Offset: 0x000070D3
		// (set) Token: 0x0600071C RID: 1820 RVA: 0x00008EDB File Offset: 0x000070DB
		public string GamecenterId { get; set; }

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x0600071D RID: 1821 RVA: 0x00008EE4 File Offset: 0x000070E4
		// (set) Token: 0x0600071E RID: 1822 RVA: 0x00008EEC File Offset: 0x000070EC
		public string GoogleServiceId { get; set; }

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x0600071F RID: 1823 RVA: 0x00008EF5 File Offset: 0x000070F5
		// (set) Token: 0x06000720 RID: 1824 RVA: 0x00008EFD File Offset: 0x000070FD
		public int CreateTime { get; private set; }

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000721 RID: 1825 RVA: 0x00008F06 File Offset: 0x00007106
		// (set) Token: 0x06000722 RID: 1826 RVA: 0x00008F0E File Offset: 0x0000710E
		public int LastSessionTime { get; set; }

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000723 RID: 1827 RVA: 0x00008F17 File Offset: 0x00007117
		// (set) Token: 0x06000724 RID: 1828 RVA: 0x00008F1F File Offset: 0x0000711F
		public int SessionCount { get; set; }

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000725 RID: 1829 RVA: 0x00008F28 File Offset: 0x00007128
		// (set) Token: 0x06000726 RID: 1830 RVA: 0x00008F30 File Offset: 0x00007130
		public int PlayTimeSeconds { get; set; }

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000727 RID: 1831 RVA: 0x00008F39 File Offset: 0x00007139
		// (set) Token: 0x06000728 RID: 1832 RVA: 0x00008F41 File Offset: 0x00007141
		public int StateArgValue { get; set; }

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000729 RID: 1833 RVA: 0x00008F4A File Offset: 0x0000714A
		// (set) Token: 0x0600072A RID: 1834 RVA: 0x00008F52 File Offset: 0x00007152
		public int BanCounter { get; set; }

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x0600072B RID: 1835 RVA: 0x00008F5B File Offset: 0x0000715B
		// (set) Token: 0x0600072C RID: 1836 RVA: 0x00008F63 File Offset: 0x00007163
		public int BanChatTime { get; set; } = -1;

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x0600072D RID: 1837 RVA: 0x00008F6C File Offset: 0x0000716C
		// (set) Token: 0x0600072E RID: 1838 RVA: 0x00008F74 File Offset: 0x00007174
		public int ReportCount { get; set; }

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x00008F7D File Offset: 0x0000717D
		// (set) Token: 0x06000730 RID: 1840 RVA: 0x00008F85 File Offset: 0x00007185
		public int ResetReportTime { get; set; }

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000731 RID: 1841 RVA: 0x00008F8E File Offset: 0x0000718E
		// (set) Token: 0x06000732 RID: 1842 RVA: 0x00008F96 File Offset: 0x00007196
		public AccountState State { get; set; }

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000733 RID: 1843 RVA: 0x00008F9F File Offset: 0x0000719F
		// (set) Token: 0x06000734 RID: 1844 RVA: 0x00008FA7 File Offset: 0x000071A7
		public AccountRankingType Rank { get; set; }

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000735 RID: 1845 RVA: 0x00008FB0 File Offset: 0x000071B0
		// (set) Token: 0x06000736 RID: 1846 RVA: 0x00008FB8 File Offset: 0x000071B8
		public string StateArg { get; set; }

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000737 RID: 1847 RVA: 0x00008FC1 File Offset: 0x000071C1
		// (set) Token: 0x06000738 RID: 1848 RVA: 0x00008FC9 File Offset: 0x000071C9
		public string CreateIPAddress { get; set; }

		// Token: 0x06000739 RID: 1849 RVA: 0x00008FD2 File Offset: 0x000071D2
		public AccountDocument()
		{
			this.logicArrayList_0 = new LogicArrayList<ReportEntry>();
			this.logicArrayList_1 = new LogicArrayList<ReportEntry>();
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x00008FF7 File Offset: 0x000071F7
		public AccountDocument(LogicLong id) : base(id)
		{
			this.logicArrayList_0 = new LogicArrayList<ReportEntry>();
			this.logicArrayList_1 = new LogicArrayList<ReportEntry>();
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00016498 File Offset: 0x00014698
		public void Init()
		{
			char[] array = new char[40];
			for (int i = 0; i < 40; i++)
			{
				array[i] = "abcdefghijklmnopqrstuvwxyz0123456789"[ServerCore.Random.Rand("abcdefghijklmnopqrstuvwxyz0123456789".Length)];
			}
			this.PassToken = new string(array);
			this.State = AccountState.NORMAL;
			this.Rank = AccountRankingType.NORMAL;
			this.CreateTime = TimeUtil.GetTimestamp();
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x0000901D File Offset: 0x0000721D
		public int GetNumberOfReports()
		{
			if (this.ResetReportTime >= TimeUtil.GetTimestamp())
			{
				return this.ReportCount;
			}
			return 0;
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00016500 File Offset: 0x00014700
		public int GetNumberOfReportedUsersToday(int source)
		{
			DateTime t = DateTime.UtcNow.AddDays(-1.0);
			int num = 0;
			if (source == 1)
			{
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					if (this.logicArrayList_0[i].Time >= t)
					{
						num++;
					}
				}
			}
			else
			{
				for (int j = 0; j < this.logicArrayList_1.Size(); j++)
				{
					if (this.logicArrayList_1[j].Time >= t)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x000165A0 File Offset: 0x000147A0
		public bool AddReportedUser(LogicLong accountId, int source)
		{
			DateTime t = DateTime.UtcNow.AddDays(-1.0);
			if (source == 1)
			{
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					ReportEntry reportEntry = this.logicArrayList_0[i];
					if (reportEntry.AccountId.Equals(accountId))
					{
						if (reportEntry.Time >= t)
						{
							return false;
						}
						this.logicArrayList_0.Remove(i--);
					}
				}
				this.logicArrayList_0.Add(new ReportEntry
				{
					AccountId = accountId,
					Time = DateTime.UtcNow
				});
			}
			else
			{
				for (int j = 0; j < this.logicArrayList_1.Size(); j++)
				{
					ReportEntry reportEntry2 = this.logicArrayList_1[j];
					if (reportEntry2.AccountId.Equals(accountId))
					{
						if (reportEntry2.Time >= t)
						{
							return false;
						}
						this.logicArrayList_1.Remove(j--);
					}
				}
				this.logicArrayList_1.Add(new ReportEntry
				{
					AccountId = accountId,
					Time = DateTime.UtcNow
				});
			}
			return true;
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x000166D4 File Offset: 0x000148D4
		public int IncreaseReportCount()
		{
			if (this.State != AccountState.NORMAL)
			{
				return 0;
			}
			int timestamp = TimeUtil.GetTimestamp();
			if (timestamp > this.ResetReportTime)
			{
				this.ReportCount = 0;
			}
			this.ResetReportTime = timestamp + 86400;
			return ++this.ReportCount;
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00016720 File Offset: 0x00014920
		protected override void Save(LogicJSONObject jsonObject)
		{
			jsonObject.Put("passToken", new LogicJSONString(this.PassToken));
			jsonObject.Put("state", new LogicJSONNumber((int)this.State));
			if (this.State != AccountState.NORMAL)
			{
				if (this.StateArg != null)
				{
					jsonObject.Put("stateArg", new LogicJSONString(this.StateArg));
				}
				if (this.StateArgValue != 0)
				{
					jsonObject.Put("stateArgValue", new LogicJSONNumber(this.StateArgValue));
				}
			}
			if (this.BanChatTime != -1)
			{
				jsonObject.Put("banChatT", new LogicJSONNumber(this.BanChatTime));
			}
			if (this.BanCounter != -1)
			{
				jsonObject.Put("banCounter", new LogicJSONNumber(this.BanCounter));
			}
			jsonObject.Put("rankingType", new LogicJSONNumber((int)this.Rank));
			jsonObject.Put("country", new LogicJSONString(this.Country));
			if (this.FacebookId != null)
			{
				jsonObject.Put("facebookId", new LogicJSONString(this.FacebookId));
			}
			if (this.GamecenterId != null)
			{
				jsonObject.Put("gamecenterId", new LogicJSONString(this.GamecenterId));
			}
			if (this.GoogleServiceId != null)
			{
				jsonObject.Put("googleServiceId", new LogicJSONString(this.GoogleServiceId));
			}
			jsonObject.Put("createTime", new LogicJSONNumber(this.CreateTime));
			jsonObject.Put("lastSessionTime", new LogicJSONNumber(this.LastSessionTime));
			jsonObject.Put("sessionCount", new LogicJSONNumber(this.SessionCount));
			jsonObject.Put("playTimeSecs", new LogicJSONNumber(this.PlayTimeSeconds));
			jsonObject.Put("createIpAddr", new LogicJSONString(this.CreateIPAddress));
			jsonObject.Put("reportCount", new LogicJSONNumber(this.ReportCount));
			jsonObject.Put("resetReportTime", new LogicJSONNumber(this.ResetReportTime));
			LogicJSONArray logicJSONArray = new LogicJSONArray(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				logicJSONArray.Add(this.logicArrayList_0[i].Save());
			}
			jsonObject.Put("reports", logicJSONArray);
			LogicJSONArray logicJSONArray2 = new LogicJSONArray(this.logicArrayList_1.Size());
			for (int j = 0; j < this.logicArrayList_1.Size(); j++)
			{
				logicJSONArray2.Add(this.logicArrayList_1[j].Save());
			}
			jsonObject.Put("allianceReports", logicJSONArray2);
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x0001699C File Offset: 0x00014B9C
		protected override void Load(LogicJSONObject jsonObject)
		{
			this.PassToken = jsonObject.GetJSONString("passToken").GetStringValue();
			this.State = (AccountState)jsonObject.GetJSONNumber("state").GetIntValue();
			if (this.State != AccountState.NORMAL)
			{
				LogicJSONString jsonstring = jsonObject.GetJSONString("stateArg");
				this.StateArg = ((jsonstring != null) ? jsonstring.GetStringValue() : null);
				LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("stateArgValue");
				this.StateArgValue = ((jsonnumber != null) ? jsonnumber.GetIntValue() : 0);
			}
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("banChatT");
			this.BanChatTime = ((jsonnumber2 != null) ? jsonnumber2.GetIntValue() : -1);
			LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("banCounter");
			this.BanCounter = ((jsonnumber3 != null) ? jsonnumber3.GetIntValue() : 0);
			this.Rank = (AccountRankingType)jsonObject.GetJSONNumber("rankingType").GetIntValue();
			this.Country = jsonObject.GetJSONString("country").GetStringValue();
			LogicJSONString jsonstring2 = jsonObject.GetJSONString("facebookId");
			this.FacebookId = ((jsonstring2 != null) ? jsonstring2.GetStringValue() : null);
			LogicJSONString jsonstring3 = jsonObject.GetJSONString("gamecenterId");
			this.GamecenterId = ((jsonstring3 != null) ? jsonstring3.GetStringValue() : null);
			LogicJSONString jsonstring4 = jsonObject.GetJSONString("googleServiceId");
			this.GoogleServiceId = ((jsonstring4 != null) ? jsonstring4.GetStringValue() : null);
			this.CreateTime = jsonObject.GetJSONNumber("createTime").GetIntValue();
			this.LastSessionTime = jsonObject.GetJSONNumber("lastSessionTime").GetIntValue();
			this.SessionCount = jsonObject.GetJSONNumber("sessionCount").GetIntValue();
			this.PlayTimeSeconds = jsonObject.GetJSONNumber("playTimeSecs").GetIntValue();
			LogicJSONString jsonstring5 = jsonObject.GetJSONString("createIpAddr");
			this.CreateIPAddress = ((jsonstring5 != null) ? jsonstring5.GetStringValue() : null);
			LogicJSONNumber jsonnumber4 = jsonObject.GetJSONNumber("reportCount");
			this.ReportCount = ((jsonnumber4 != null) ? jsonnumber4.GetIntValue() : 0);
			LogicJSONNumber jsonnumber5 = jsonObject.GetJSONNumber("resetReportTime");
			this.ResetReportTime = ((jsonnumber5 != null) ? jsonnumber5.GetIntValue() : 0);
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("reports");
			if (jsonarray != null)
			{
				this.logicArrayList_0.EnsureCapacity(jsonarray.Size());
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					ReportEntry item = default(ReportEntry);
					item.Load(jsonarray.Get(i));
					this.logicArrayList_0.Add(item);
				}
			}
			LogicJSONArray jsonarray2 = jsonObject.GetJSONArray("allianceReports");
			if (jsonarray2 != null)
			{
				this.logicArrayList_1.EnsureCapacity(jsonarray2.Size());
				for (int j = 0; j < jsonarray2.Size(); j++)
				{
					ReportEntry item2 = default(ReportEntry);
					item2.Load(jsonarray2.Get(j));
					this.logicArrayList_1.Add(item2);
				}
			}
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00016C30 File Offset: 0x00014E30
		protected override void Encode(ByteStream stream)
		{
			stream.WriteString(this.PassToken);
			stream.WriteVInt((int)this.State);
			stream.WriteVInt((int)this.Rank);
			stream.WriteVInt(this.BanChatTime);
			stream.WriteString(this.Country);
			stream.WriteString(this.FacebookId);
			stream.WriteString(this.GamecenterId);
			stream.WriteVInt(this.CreateTime);
			stream.WriteVInt(this.LastSessionTime);
			stream.WriteVInt(this.SessionCount);
			stream.WriteVInt(this.PlayTimeSeconds);
			stream.WriteString(this.CreateIPAddress);
			stream.WriteVInt(this.StateArgValue);
			stream.WriteVInt(this.logicArrayList_0.Size());
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				this.logicArrayList_0[i].Encode(stream);
			}
			stream.WriteVInt(this.logicArrayList_0.Size());
			for (int j = 0; j < this.logicArrayList_0.Size(); j++)
			{
				this.logicArrayList_1[j].Encode(stream);
			}
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x00016D54 File Offset: 0x00014F54
		protected override void Decode(ByteStream stream)
		{
			this.PassToken = stream.ReadString(900000);
			this.State = (AccountState)stream.ReadVInt();
			this.Rank = (AccountRankingType)stream.ReadVInt();
			this.BanChatTime = stream.ReadVInt();
			this.Country = stream.ReadString(900000);
			this.FacebookId = stream.ReadString(900000);
			this.GamecenterId = stream.ReadString(900000);
			this.CreateTime = stream.ReadVInt();
			this.LastSessionTime = stream.ReadVInt();
			this.SessionCount = stream.ReadVInt();
			this.PlayTimeSeconds = stream.ReadVInt();
			this.CreateIPAddress = stream.ReadString(900000);
			this.StateArgValue = stream.ReadVInt();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				ReportEntry item = default(ReportEntry);
				item.Decode(stream);
				this.logicArrayList_0.Add(item);
			}
			for (int j = stream.ReadVInt(); j > 0; j--)
			{
				ReportEntry item2 = default(ReportEntry);
				item2.Decode(stream);
				this.logicArrayList_1.Add(item2);
			}
		}

		// Token: 0x040003DB RID: 987
		private const string string_0 = "passToken";

		// Token: 0x040003DC RID: 988
		private const string string_1 = "state";

		// Token: 0x040003DD RID: 989
		private const string string_2 = "stateArg";

		// Token: 0x040003DE RID: 990
		private const string string_3 = "stateArgValue";

		// Token: 0x040003DF RID: 991
		private const string string_4 = "rankingType";

		// Token: 0x040003E0 RID: 992
		private const string string_5 = "country";

		// Token: 0x040003E1 RID: 993
		private const string string_6 = "facebookId";

		// Token: 0x040003E2 RID: 994
		private const string string_7 = "gamecenterId";

		// Token: 0x040003E3 RID: 995
		private const string string_8 = "googleServiceId";

		// Token: 0x040003E4 RID: 996
		private const string string_9 = "createTime";

		// Token: 0x040003E5 RID: 997
		private const string string_10 = "lastSessionTime";

		// Token: 0x040003E6 RID: 998
		private const string string_11 = "sessionCount";

		// Token: 0x040003E7 RID: 999
		private const string string_12 = "playTimeSecs";

		// Token: 0x040003E8 RID: 1000
		private const string string_13 = "createIpAddr";

		// Token: 0x040003E9 RID: 1001
		private const string string_14 = "banChatT";

		// Token: 0x040003EA RID: 1002
		private const string string_15 = "banCounter";

		// Token: 0x040003EB RID: 1003
		private const string string_16 = "reports";

		// Token: 0x040003EC RID: 1004
		private const string string_17 = "allianceReports";

		// Token: 0x040003ED RID: 1005
		private const string string_18 = "reportCount";

		// Token: 0x040003EE RID: 1006
		private const string string_19 = "resetReportTime";

		// Token: 0x040003EF RID: 1007
		public const string CHARS = "abcdefghijklmnopqrstuvwxyz0123456789";

		// Token: 0x040003F0 RID: 1008
		public const int PASS_TOKEN_LENGTH = 40;

		// Token: 0x040003F1 RID: 1009
		[CompilerGenerated]
		private string string_20;

		// Token: 0x040003F2 RID: 1010
		[CompilerGenerated]
		private string string_21;

		// Token: 0x040003F3 RID: 1011
		[CompilerGenerated]
		private string string_22;

		// Token: 0x040003F4 RID: 1012
		[CompilerGenerated]
		private string string_23;

		// Token: 0x040003F5 RID: 1013
		[CompilerGenerated]
		private string string_24;

		// Token: 0x040003F6 RID: 1014
		[CompilerGenerated]
		private int int_0;

		// Token: 0x040003F7 RID: 1015
		[CompilerGenerated]
		private int int_1;

		// Token: 0x040003F8 RID: 1016
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040003F9 RID: 1017
		[CompilerGenerated]
		private int int_3;

		// Token: 0x040003FA RID: 1018
		[CompilerGenerated]
		private int int_4;

		// Token: 0x040003FB RID: 1019
		[CompilerGenerated]
		private int int_5;

		// Token: 0x040003FC RID: 1020
		[CompilerGenerated]
		private int int_6;

		// Token: 0x040003FD RID: 1021
		[CompilerGenerated]
		private int int_7;

		// Token: 0x040003FE RID: 1022
		[CompilerGenerated]
		private int int_8;

		// Token: 0x040003FF RID: 1023
		[CompilerGenerated]
		private AccountState accountState_0;

		// Token: 0x04000400 RID: 1024
		[CompilerGenerated]
		private AccountRankingType accountRankingType_0;

		// Token: 0x04000401 RID: 1025
		[CompilerGenerated]
		private string string_25;

		// Token: 0x04000402 RID: 1026
		[CompilerGenerated]
		private string string_26;

		// Token: 0x04000403 RID: 1027
		private LogicArrayList<ReportEntry> logicArrayList_0;

		// Token: 0x04000404 RID: 1028
		private LogicArrayList<ReportEntry> logicArrayList_1;
	}
}
