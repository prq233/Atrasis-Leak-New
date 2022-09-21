using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Scoring;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000FA RID: 250
	public class SeasonDocument : CouchbaseDocument
	{
		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000791 RID: 1937 RVA: 0x000092C4 File Offset: 0x000074C4
		// (set) Token: 0x06000792 RID: 1938 RVA: 0x000092CC File Offset: 0x000074CC
		public LogicArrayList<AllianceRankingEntry>[] AllianceRankingList { get; private set; }

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000793 RID: 1939 RVA: 0x000092D5 File Offset: 0x000074D5
		// (set) Token: 0x06000794 RID: 1940 RVA: 0x000092DD File Offset: 0x000074DD
		public LogicArrayList<AvatarRankingEntry> AvatarRankingList { get; private set; }

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000795 RID: 1941 RVA: 0x000092E6 File Offset: 0x000074E6
		// (set) Token: 0x06000796 RID: 1942 RVA: 0x000092EE File Offset: 0x000074EE
		public LogicArrayList<AvatarDuelRankingEntry> AvatarDuelRankingList { get; private set; }

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000797 RID: 1943 RVA: 0x000092F7 File Offset: 0x000074F7
		// (set) Token: 0x06000798 RID: 1944 RVA: 0x000092FF File Offset: 0x000074FF
		public DateTime NextCheckTime { get; set; }

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000799 RID: 1945 RVA: 0x00009308 File Offset: 0x00007508
		public int Year
		{
			get
			{
				return base.Id.GetHigherInt();
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x0600079A RID: 1946 RVA: 0x00009315 File Offset: 0x00007515
		public int Month
		{
			get
			{
				return base.Id.GetLowerInt();
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x00009322 File Offset: 0x00007522
		public DateTime EndTime
		{
			get
			{
				return new DateTime(this.Year, this.Month, 1, 0, 0, 0);
			}
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x00017F08 File Offset: 0x00016108
		public SeasonDocument()
		{
			this.AllianceRankingList = new LogicArrayList<AllianceRankingEntry>[2];
			this.AllianceRankingList[0] = new LogicArrayList<AllianceRankingEntry>(1000);
			this.AllianceRankingList[1] = new LogicArrayList<AllianceRankingEntry>(1000);
			this.AvatarRankingList = new LogicArrayList<AvatarRankingEntry>(1000);
			this.AvatarDuelRankingList = new LogicArrayList<AvatarDuelRankingEntry>(1000);
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x00017F6C File Offset: 0x0001616C
		public SeasonDocument(LogicLong id) : base(id)
		{
			this.AllianceRankingList = new LogicArrayList<AllianceRankingEntry>[2];
			this.AllianceRankingList[0] = new LogicArrayList<AllianceRankingEntry>(1000);
			this.AllianceRankingList[1] = new LogicArrayList<AllianceRankingEntry>(1000);
			this.AvatarRankingList = new LogicArrayList<AvatarRankingEntry>(1000);
			this.AvatarDuelRankingList = new LogicArrayList<AvatarDuelRankingEntry>(1000);
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x00017FD0 File Offset: 0x000161D0
		protected sealed override void Encode(ByteStream stream)
		{
			for (int i = 0; i < 2; i++)
			{
				LogicArrayList<AllianceRankingEntry> logicArrayList = this.AllianceRankingList[i];
				stream.WriteVInt(logicArrayList.Size());
				for (int j = 0; j < logicArrayList.Size(); j++)
				{
					logicArrayList[j].Encode(stream);
				}
			}
			stream.WriteVInt(this.AvatarRankingList.Size());
			for (int k = 0; k < this.AvatarRankingList.Size(); k++)
			{
				this.AvatarRankingList[k].Encode(stream);
			}
			stream.WriteVInt(this.AvatarDuelRankingList.Size());
			for (int l = 0; l < this.AvatarDuelRankingList.Size(); l++)
			{
				this.AvatarDuelRankingList[l].Encode(stream);
			}
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00018094 File Offset: 0x00016294
		protected sealed override void Decode(ByteStream stream)
		{
			for (int i = 0; i < 2; i++)
			{
				LogicArrayList<AllianceRankingEntry> logicArrayList = this.AllianceRankingList[i];
				for (int j = stream.ReadVInt(); j > 0; j--)
				{
					AllianceRankingEntry allianceRankingEntry = new AllianceRankingEntry();
					allianceRankingEntry.Decode(stream);
					logicArrayList.Add(allianceRankingEntry);
				}
			}
			for (int k = stream.ReadVInt(); k > 0; k--)
			{
				AvatarRankingEntry avatarRankingEntry = new AvatarRankingEntry();
				avatarRankingEntry.Decode(stream);
				this.AvatarRankingList.Add(avatarRankingEntry);
			}
			for (int l = stream.ReadVInt(); l > 0; l--)
			{
				AvatarDuelRankingEntry avatarDuelRankingEntry = new AvatarDuelRankingEntry();
				avatarDuelRankingEntry.Decode(stream);
				this.AvatarDuelRankingList.Add(avatarDuelRankingEntry);
			}
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00018140 File Offset: 0x00016340
		protected sealed override void Save(LogicJSONObject jsonObject)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray(2);
			LogicJSONArray logicJSONArray2 = new LogicJSONArray(1000);
			LogicJSONArray logicJSONArray3 = new LogicJSONArray(1000);
			for (int i = 0; i < 2; i++)
			{
				LogicJSONArray logicJSONArray4 = new LogicJSONArray(1000);
				LogicArrayList<AllianceRankingEntry> logicArrayList = this.AllianceRankingList[i];
				for (int j = 0; j < logicArrayList.Size(); j++)
				{
					logicJSONArray4.Add(logicArrayList[j].Save());
				}
				logicJSONArray.Add(logicJSONArray4);
			}
			for (int k = 0; k < this.AvatarRankingList.Size(); k++)
			{
				logicJSONArray2.Add(this.AvatarRankingList[k].Save());
			}
			for (int l = 0; l < this.AvatarDuelRankingList.Size(); l++)
			{
				logicJSONArray3.Add(this.AvatarDuelRankingList[l].Save());
			}
			jsonObject.Put("allianceRankings", logicJSONArray);
			jsonObject.Put("avatarRankings", logicJSONArray2);
			jsonObject.Put("avatarDuelRankings", logicJSONArray3);
			jsonObject.Put("nextCheckTime", new LogicJSONString(this.NextCheckTime.ToString("O")));
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0001826C File Offset: 0x0001646C
		protected sealed override void Load(LogicJSONObject jsonObject)
		{
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("allianceRankings");
			LogicJSONArray jsonarray2 = jsonObject.GetJSONArray("avatarRankings");
			LogicJSONArray jsonarray3 = jsonObject.GetJSONArray("avatarDuelRankings");
			for (int i = 0; i < 2; i++)
			{
				LogicJSONArray jsonarray4 = jsonarray.GetJSONArray(i);
				LogicArrayList<AllianceRankingEntry> logicArrayList = this.AllianceRankingList[i];
				for (int j = 0; j < jsonarray4.Size(); j++)
				{
					AllianceRankingEntry allianceRankingEntry = new AllianceRankingEntry();
					allianceRankingEntry.Load(jsonarray4.GetJSONObject(j));
					logicArrayList.Add(allianceRankingEntry);
				}
			}
			for (int k = 0; k < jsonarray2.Size(); k++)
			{
				AvatarRankingEntry avatarRankingEntry = new AvatarRankingEntry();
				avatarRankingEntry.Load(jsonarray2.GetJSONObject(k));
				this.AvatarRankingList.Add(avatarRankingEntry);
			}
			for (int l = 0; l < jsonarray3.Size(); l++)
			{
				AvatarDuelRankingEntry avatarDuelRankingEntry = new AvatarDuelRankingEntry();
				avatarDuelRankingEntry.Load(jsonarray3.GetJSONObject(l));
				this.AvatarDuelRankingList.Add(avatarDuelRankingEntry);
			}
			this.NextCheckTime = DateTime.Parse(jsonObject.GetJSONString("nextCheckTime").GetStringValue());
		}

		// Token: 0x04000440 RID: 1088
		private const string string_0 = "allianceRankings";

		// Token: 0x04000441 RID: 1089
		private const string string_1 = "avatarRankings";

		// Token: 0x04000442 RID: 1090
		private const string string_2 = "avatarDuelRankings";

		// Token: 0x04000443 RID: 1091
		private const string string_3 = "nextCheckTime";

		// Token: 0x04000444 RID: 1092
		protected const int RANKING_LIST_SIZE = 1000;

		// Token: 0x04000445 RID: 1093
		[CompilerGenerated]
		private LogicArrayList<AllianceRankingEntry>[] logicArrayList_0;

		// Token: 0x04000446 RID: 1094
		[CompilerGenerated]
		private LogicArrayList<AvatarRankingEntry> logicArrayList_1;

		// Token: 0x04000447 RID: 1095
		[CompilerGenerated]
		private LogicArrayList<AvatarDuelRankingEntry> logicArrayList_2;

		// Token: 0x04000448 RID: 1096
		[CompilerGenerated]
		private DateTime dateTime_0;
	}
}
