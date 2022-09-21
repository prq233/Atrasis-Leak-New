using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000F8 RID: 248
	public class GameDocument : CouchbaseDocument
	{
		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x0000918A File Offset: 0x0000738A
		// (set) Token: 0x0600076C RID: 1900 RVA: 0x00009192 File Offset: 0x00007392
		public LogicClientAvatar LogicClientAvatar { get; set; }

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x0600076D RID: 1901 RVA: 0x0000919B File Offset: 0x0000739B
		// (set) Token: 0x0600076E RID: 1902 RVA: 0x000091A3 File Offset: 0x000073A3
		public LogicArrayList<LogicServerCommand> ServerCommands { get; set; }

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x0600076F RID: 1903 RVA: 0x000091AC File Offset: 0x000073AC
		// (set) Token: 0x06000770 RID: 1904 RVA: 0x000091B4 File Offset: 0x000073B4
		public LogicArrayList<GameDocument.RecentlyEnemy> RecentlyMatchedEnemies { get; set; }

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000771 RID: 1905 RVA: 0x000091BD File Offset: 0x000073BD
		// (set) Token: 0x06000772 RID: 1906 RVA: 0x000091C5 File Offset: 0x000073C5
		public LogicArrayList<LogicLong> AllianceBookmarksList { get; set; }

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000773 RID: 1907 RVA: 0x000091CE File Offset: 0x000073CE
		// (set) Token: 0x06000774 RID: 1908 RVA: 0x000091D6 File Offset: 0x000073D6
		public LogicArrayList<LogicLong> AvatarStreamList { get; set; }

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x000091DF File Offset: 0x000073DF
		// (set) Token: 0x06000776 RID: 1910 RVA: 0x000091E7 File Offset: 0x000073E7
		public LogicArrayList<LogicLong> Village2AttackList { get; set; }

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000777 RID: 1911 RVA: 0x000091F0 File Offset: 0x000073F0
		// (set) Token: 0x06000778 RID: 1912 RVA: 0x000091F8 File Offset: 0x000073F8
		public byte[] HomeData { get; set; }

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x00009201 File Offset: 0x00007401
		// (set) Token: 0x0600077A RID: 1914 RVA: 0x00009209 File Offset: 0x00007409
		public int RemainingShieldTimeSeconds { get; set; }

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x0600077B RID: 1915 RVA: 0x00009212 File Offset: 0x00007412
		// (set) Token: 0x0600077C RID: 1916 RVA: 0x0000921A File Offset: 0x0000741A
		public int RemainingGuardTimeSeconds { get; set; }

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x0600077D RID: 1917 RVA: 0x00009223 File Offset: 0x00007423
		// (set) Token: 0x0600077E RID: 1918 RVA: 0x0000922B File Offset: 0x0000742B
		public int DonationCount { get; set; }

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x00009234 File Offset: 0x00007434
		// (set) Token: 0x06000780 RID: 1920 RVA: 0x0000923C File Offset: 0x0000743C
		public int ReceivedDonationCount { get; set; }

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000781 RID: 1921 RVA: 0x00009245 File Offset: 0x00007445
		// (set) Token: 0x06000782 RID: 1922 RVA: 0x0000924D File Offset: 0x0000744D
		public int SaveTime { get; set; }

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000783 RID: 1923 RVA: 0x00009256 File Offset: 0x00007456
		// (set) Token: 0x06000784 RID: 1924 RVA: 0x0000925E File Offset: 0x0000745E
		public int MaintenanceTime { get; set; }

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000785 RID: 1925 RVA: 0x00009267 File Offset: 0x00007467
		// (set) Token: 0x06000786 RID: 1926 RVA: 0x0000926F File Offset: 0x0000746F
		public int ProtectionTime { get; set; }

		// Token: 0x06000787 RID: 1927 RVA: 0x000174B0 File Offset: 0x000156B0
		public GameDocument()
		{
			this.LogicClientAvatar = LogicClientAvatar.GetDefaultAvatar();
			this.ServerCommands = new LogicArrayList<LogicServerCommand>();
			this.RecentlyMatchedEnemies = new LogicArrayList<GameDocument.RecentlyEnemy>();
			this.AllianceBookmarksList = new LogicArrayList<LogicLong>();
			this.AvatarStreamList = new LogicArrayList<LogicLong>();
			this.Village2AttackList = new LogicArrayList<LogicLong>();
			this.SaveTime = -1;
			this.MaintenanceTime = -1;
			this.ProtectionTime = TimeUtil.GetTimestamp();
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x00017520 File Offset: 0x00015720
		public GameDocument(LogicLong id) : base(id)
		{
			this.LogicClientAvatar = LogicClientAvatar.GetDefaultAvatar();
			this.ServerCommands = new LogicArrayList<LogicServerCommand>();
			this.RecentlyMatchedEnemies = new LogicArrayList<GameDocument.RecentlyEnemy>();
			this.AllianceBookmarksList = new LogicArrayList<LogicLong>();
			this.AvatarStreamList = new LogicArrayList<LogicLong>();
			this.Village2AttackList = new LogicArrayList<LogicLong>();
			this.SaveTime = -1;
			this.MaintenanceTime = -1;
			this.ProtectionTime = TimeUtil.GetTimestamp();
			this.method_0(id);
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x00009278 File Offset: 0x00007478
		private void method_0(LogicLong logicLong_1)
		{
			this.LogicClientAvatar.SetId(logicLong_1);
			this.LogicClientAvatar.SetCurrentHomeId(logicLong_1);
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x00009292 File Offset: 0x00007492
		public int GetRemainingProtectionTimeSeconds()
		{
			return LogicMath.Max(this.RemainingShieldTimeSeconds + this.RemainingGuardTimeSeconds + this.ProtectionTime - TimeUtil.GetTimestamp(), 0);
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x00017598 File Offset: 0x00015798
		public void UpdateProtection()
		{
			int timestamp = TimeUtil.GetTimestamp();
			int num = this.RemainingShieldTimeSeconds - (timestamp - this.ProtectionTime);
			if (num < 0)
			{
				int num2 = this.RemainingGuardTimeSeconds + num;
				if (num2 < 0)
				{
					num2 = 0;
				}
				num = 0;
				this.RemainingGuardTimeSeconds = num2;
			}
			this.RemainingShieldTimeSeconds = num;
			this.ProtectionTime = timestamp;
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x000175E8 File Offset: 0x000157E8
		protected override void Encode(ByteStream stream)
		{
			this.LogicClientAvatar.Encode(stream);
			stream.WriteBytes(this.HomeData, this.HomeData.Length);
			stream.WriteVInt(this.RemainingShieldTimeSeconds);
			stream.WriteVInt(this.RemainingGuardTimeSeconds);
			stream.WriteVInt(this.ServerCommands.Size());
			for (int i = 0; i < this.ServerCommands.Size(); i++)
			{
				LogicCommandManager.EncodeCommand(stream, this.ServerCommands[i]);
			}
			stream.WriteVInt(this.RecentlyMatchedEnemies.Size());
			for (int j = 0; j < this.RecentlyMatchedEnemies.Size(); j++)
			{
				stream.WriteLong(this.RecentlyMatchedEnemies[j].AvatarId);
				stream.WriteVInt(this.RecentlyMatchedEnemies[j].Timestamp);
			}
			stream.WriteVInt(this.AllianceBookmarksList.Size());
			for (int k = 0; k < this.AllianceBookmarksList.Size(); k++)
			{
				stream.WriteLong(this.AllianceBookmarksList[k]);
			}
			stream.WriteVInt(this.AvatarStreamList.Size());
			for (int l = 0; l < this.AvatarStreamList.Size(); l++)
			{
				stream.WriteLong(this.AvatarStreamList[l]);
			}
			stream.WriteVInt(this.Village2AttackList.Size());
			for (int m = 0; m < this.Village2AttackList.Size(); m++)
			{
				stream.WriteLong(this.Village2AttackList[m]);
			}
			stream.WriteVInt(this.DonationCount);
			stream.WriteVInt(this.ReceivedDonationCount);
			stream.WriteVInt(this.SaveTime);
			stream.WriteVInt(this.MaintenanceTime);
			stream.WriteVInt(this.ProtectionTime);
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x000177A8 File Offset: 0x000159A8
		protected override void Decode(ByteStream stream)
		{
			this.LogicClientAvatar.Decode(stream);
			this.HomeData = stream.ReadBytes(stream.ReadBytesLength(), 900000);
			this.RemainingShieldTimeSeconds = stream.ReadVInt();
			this.RemainingGuardTimeSeconds = stream.ReadVInt();
			this.ServerCommands.Clear();
			this.RecentlyMatchedEnemies.Clear();
			this.AllianceBookmarksList.Clear();
			this.AvatarStreamList.Clear();
			this.Village2AttackList.Clear();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.ServerCommands.Add((LogicServerCommand)LogicCommandManager.DecodeCommand(stream));
			}
			for (int j = stream.ReadVInt(); j > 0; j--)
			{
				this.RecentlyMatchedEnemies.Add(new GameDocument.RecentlyEnemy(stream.ReadLong(), stream.ReadVInt()));
			}
			for (int k = stream.ReadVInt(); k > 0; k--)
			{
				this.AllianceBookmarksList.Add(stream.ReadLong());
			}
			for (int l = stream.ReadVInt(); l > 0; l--)
			{
				this.AvatarStreamList.Add(stream.ReadLong());
			}
			for (int m = stream.ReadVInt(); m > 0; m--)
			{
				this.Village2AttackList.Add(stream.ReadLong());
			}
			this.DonationCount = stream.ReadVInt();
			this.ReceivedDonationCount = stream.ReadVInt();
			this.SaveTime = stream.ReadVInt();
			this.MaintenanceTime = stream.ReadVInt();
			this.ProtectionTime = stream.ReadVInt();
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x00017924 File Offset: 0x00015B24
		protected override void Save(LogicJSONObject jsonObject)
		{
			this.LogicClientAvatar.Save(jsonObject);
			jsonObject.Put("homeData", new LogicJSONString(Convert.ToBase64String(this.HomeData)));
			jsonObject.Put("remShieldTimeSecs", new LogicJSONNumber(this.RemainingShieldTimeSeconds));
			jsonObject.Put("remGuardTimeSecs", new LogicJSONNumber(this.RemainingGuardTimeSeconds));
			jsonObject.Put("protectionTime", new LogicJSONNumber(this.ProtectionTime));
			jsonObject.Put("saveTime", new LogicJSONNumber(this.SaveTime));
			jsonObject.Put("maintenanceTime", new LogicJSONNumber(this.MaintenanceTime));
			jsonObject.Put("donationCount", new LogicJSONNumber(this.DonationCount));
			jsonObject.Put("receivedDonationCount", new LogicJSONNumber(this.ReceivedDonationCount));
			LogicJSONArray logicJSONArray = new LogicJSONArray(this.RecentlyMatchedEnemies.Size());
			for (int i = 0; i < this.RecentlyMatchedEnemies.Size(); i++)
			{
				GameDocument.RecentlyEnemy recentlyEnemy = this.RecentlyMatchedEnemies[i];
				LogicJSONArray logicJSONArray2 = new LogicJSONArray(3);
				logicJSONArray2.Add(new LogicJSONNumber(recentlyEnemy.AvatarId.GetHigherInt()));
				logicJSONArray2.Add(new LogicJSONNumber(recentlyEnemy.AvatarId.GetLowerInt()));
				logicJSONArray2.Add(new LogicJSONNumber(recentlyEnemy.Timestamp));
				logicJSONArray.Add(logicJSONArray2);
			}
			jsonObject.Put("recentlyEnemies", logicJSONArray);
			LogicJSONArray logicJSONArray3 = new LogicJSONArray(this.AllianceBookmarksList.Size());
			for (int j = 0; j < this.AllianceBookmarksList.Size(); j++)
			{
				LogicLong logicLong = this.AllianceBookmarksList[j];
				LogicJSONArray logicJSONArray4 = new LogicJSONArray(2);
				logicJSONArray4.Add(new LogicJSONNumber(logicLong.GetHigherInt()));
				logicJSONArray4.Add(new LogicJSONNumber(logicLong.GetLowerInt()));
				logicJSONArray3.Add(logicJSONArray4);
			}
			jsonObject.Put("allianceBookmarks", logicJSONArray3);
			LogicJSONArray logicJSONArray5 = new LogicJSONArray(this.AvatarStreamList.Size());
			for (int k = 0; k < this.AvatarStreamList.Size(); k++)
			{
				LogicLong logicLong2 = this.AvatarStreamList[k];
				LogicJSONArray logicJSONArray6 = new LogicJSONArray(2);
				logicJSONArray6.Add(new LogicJSONNumber(logicLong2.GetHigherInt()));
				logicJSONArray6.Add(new LogicJSONNumber(logicLong2.GetLowerInt()));
				logicJSONArray5.Add(logicJSONArray6);
			}
			jsonObject.Put("avatarStreams", logicJSONArray5);
			LogicJSONArray logicJSONArray7 = new LogicJSONArray(this.Village2AttackList.Size());
			for (int l = 0; l < this.Village2AttackList.Size(); l++)
			{
				LogicLong logicLong3 = this.Village2AttackList[l];
				LogicJSONArray logicJSONArray8 = new LogicJSONArray(2);
				logicJSONArray8.Add(new LogicJSONNumber(logicLong3.GetHigherInt()));
				logicJSONArray8.Add(new LogicJSONNumber(logicLong3.GetLowerInt()));
				logicJSONArray7.Add(logicJSONArray8);
			}
			jsonObject.Put("attackListV2", logicJSONArray7);
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00017C00 File Offset: 0x00015E00
		protected override void Load(LogicJSONObject jsonObject)
		{
			this.LogicClientAvatar.Load(jsonObject);
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("home");
			if (jsonobject != null)
			{
				LogicJSONObject jsonobject2 = jsonobject.GetJSONObject("homeJSON");
				if (jsonobject2 != null)
				{
					this.HomeData = Convert.FromBase64String(jsonobject2.GetJSONString("c").GetStringValue());
				}
				this.RemainingShieldTimeSeconds = jsonobject.GetJSONNumber("shield_t").GetIntValue();
				this.RemainingGuardTimeSeconds = jsonobject.GetJSONNumber("guard_t").GetIntValue();
			}
			else
			{
				this.HomeData = Convert.FromBase64String(jsonObject.GetJSONString("homeData").GetStringValue());
				this.RemainingShieldTimeSeconds = jsonObject.GetJSONNumber("remShieldTimeSecs").GetIntValue();
				this.RemainingGuardTimeSeconds = jsonObject.GetJSONNumber("remGuardTimeSecs").GetIntValue();
			}
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("protectionTime");
			this.ProtectionTime = ((jsonnumber != null) ? jsonnumber.GetIntValue() : this.SaveTime);
			this.SaveTime = jsonObject.GetJSONNumber("saveTime").GetIntValue();
			this.MaintenanceTime = jsonObject.GetJSONNumber("maintenanceTime").GetIntValue();
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("donationCount");
			this.DonationCount = ((jsonnumber2 != null) ? jsonnumber2.GetIntValue() : 0);
			LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber("receivedDonationCount");
			this.ReceivedDonationCount = ((jsonnumber3 != null) ? jsonnumber3.GetIntValue() : 0);
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("recentlyEnemies");
			if (jsonarray != null)
			{
				for (int i = 0; i < jsonarray.Size(); i++)
				{
					LogicJSONArray jsonarray2 = jsonarray.GetJSONArray(i);
					this.RecentlyMatchedEnemies.Add(new GameDocument.RecentlyEnemy(new LogicLong(jsonarray2.GetJSONNumber(0).GetIntValue(), jsonarray2.GetJSONNumber(1).GetIntValue()), jsonarray2.GetJSONNumber(2).GetIntValue()));
				}
			}
			LogicJSONArray jsonarray3 = jsonObject.GetJSONArray("allianceBookmarks");
			if (jsonarray3 != null)
			{
				this.AllianceBookmarksList.EnsureCapacity(jsonarray3.Size());
				for (int j = 0; j < jsonarray3.Size(); j++)
				{
					LogicJSONArray jsonarray4 = jsonarray3.GetJSONArray(j);
					this.AllianceBookmarksList.Add(new LogicLong(jsonarray4.GetJSONNumber(0).GetIntValue(), jsonarray4.GetJSONNumber(1).GetIntValue()));
				}
			}
			LogicJSONArray jsonarray5 = jsonObject.GetJSONArray("avatarStreams");
			if (jsonarray5 != null)
			{
				this.AvatarStreamList.EnsureCapacity(jsonarray5.Size());
				for (int k = 0; k < jsonarray5.Size(); k++)
				{
					LogicJSONArray jsonarray6 = jsonarray5.GetJSONArray(k);
					this.AvatarStreamList.Add(new LogicLong(jsonarray6.GetJSONNumber(0).GetIntValue(), jsonarray6.GetJSONNumber(1).GetIntValue()));
				}
			}
			LogicJSONArray jsonarray7 = jsonObject.GetJSONArray("attackListV2");
			if (jsonarray7 != null)
			{
				this.Village2AttackList.EnsureCapacity(jsonarray7.Size());
				for (int l = 0; l < jsonarray7.Size(); l++)
				{
					LogicJSONArray jsonarray8 = jsonarray7.GetJSONArray(l);
					this.Village2AttackList.Add(new LogicLong(jsonarray8.GetJSONNumber(0).GetIntValue(), jsonarray8.GetJSONNumber(1).GetIntValue()));
				}
			}
			this.method_0(base.Id);
		}

		// Token: 0x04000423 RID: 1059
		private const string string_0 = "home";

		// Token: 0x04000424 RID: 1060
		private const string string_1 = "homeData";

		// Token: 0x04000425 RID: 1061
		private const string string_2 = "remShieldTimeSecs";

		// Token: 0x04000426 RID: 1062
		private const string string_3 = "remGuardTimeSecs";

		// Token: 0x04000427 RID: 1063
		private const string string_4 = "saveTime";

		// Token: 0x04000428 RID: 1064
		private const string string_5 = "maintenanceTime";

		// Token: 0x04000429 RID: 1065
		private const string string_6 = "donationCount";

		// Token: 0x0400042A RID: 1066
		private const string string_7 = "receivedDonationCount";

		// Token: 0x0400042B RID: 1067
		private const string string_8 = "recentlyEnemies";

		// Token: 0x0400042C RID: 1068
		private const string string_9 = "allianceBookmarks";

		// Token: 0x0400042D RID: 1069
		private const string string_10 = "avatarStreams";

		// Token: 0x0400042E RID: 1070
		private const string string_11 = "attackListV2";

		// Token: 0x0400042F RID: 1071
		private const string string_12 = "protectionTime";

		// Token: 0x04000430 RID: 1072
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000431 RID: 1073
		[CompilerGenerated]
		private LogicArrayList<LogicServerCommand> logicArrayList_0;

		// Token: 0x04000432 RID: 1074
		[CompilerGenerated]
		private LogicArrayList<GameDocument.RecentlyEnemy> logicArrayList_1;

		// Token: 0x04000433 RID: 1075
		[CompilerGenerated]
		private LogicArrayList<LogicLong> logicArrayList_2;

		// Token: 0x04000434 RID: 1076
		[CompilerGenerated]
		private LogicArrayList<LogicLong> logicArrayList_3;

		// Token: 0x04000435 RID: 1077
		[CompilerGenerated]
		private LogicArrayList<LogicLong> logicArrayList_4;

		// Token: 0x04000436 RID: 1078
		[CompilerGenerated]
		private byte[] byte_0;

		// Token: 0x04000437 RID: 1079
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04000438 RID: 1080
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04000439 RID: 1081
		[CompilerGenerated]
		private int int_2;

		// Token: 0x0400043A RID: 1082
		[CompilerGenerated]
		private int int_3;

		// Token: 0x0400043B RID: 1083
		[CompilerGenerated]
		private int int_4;

		// Token: 0x0400043C RID: 1084
		[CompilerGenerated]
		private int int_5;

		// Token: 0x0400043D RID: 1085
		[CompilerGenerated]
		private int int_6;

		// Token: 0x020000F9 RID: 249
		public struct RecentlyEnemy
		{
			// Token: 0x06000790 RID: 1936 RVA: 0x000092B4 File Offset: 0x000074B4
			public RecentlyEnemy(LogicLong id, int timestamp)
			{
				this.AvatarId = id;
				this.Timestamp = timestamp;
			}

			// Token: 0x0400043E RID: 1086
			public readonly LogicLong AvatarId;

			// Token: 0x0400043F RID: 1087
			public readonly int Timestamp;
		}
	}
}
