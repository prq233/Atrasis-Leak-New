using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Servers.Core.Util;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Database.Document
{
	// Token: 0x020000F6 RID: 246
	public class AllianceDocument : CouchbaseDocument
	{
		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600074C RID: 1868 RVA: 0x0000907A File Offset: 0x0000727A
		// (set) Token: 0x0600074D RID: 1869 RVA: 0x00009082 File Offset: 0x00007282
		public string Description { get; set; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x0600074E RID: 1870 RVA: 0x0000908B File Offset: 0x0000728B
		public AllianceHeaderEntry Header { get; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x0600074F RID: 1871 RVA: 0x00009093 File Offset: 0x00007293
		public Dictionary<long, AllianceMemberEntry> Members { get; }

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000750 RID: 1872 RVA: 0x0000909B File Offset: 0x0000729B
		public Dictionary<long, DateTime> KickedMembersTimes { get; }

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000751 RID: 1873 RVA: 0x000090A3 File Offset: 0x000072A3
		public LogicArrayList<LogicLong> StreamEntryList { get; }

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000752 RID: 1874 RVA: 0x000090AB File Offset: 0x000072AB
		// (set) Token: 0x06000753 RID: 1875 RVA: 0x000090B3 File Offset: 0x000072B3
		public DateTime DonationTime { get; set; }

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000754 RID: 1876 RVA: 0x000090BC File Offset: 0x000072BC
		// (set) Token: 0x06000755 RID: 1877 RVA: 0x000090C4 File Offset: 0x000072C4
		public DateTime CheckRankingTime { get; set; }

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000756 RID: 1878 RVA: 0x000090CD File Offset: 0x000072CD
		// (set) Token: 0x06000757 RID: 1879 RVA: 0x000090D5 File Offset: 0x000072D5
		public DateTime LastUpdateTime { get; set; }

		// Token: 0x06000758 RID: 1880 RVA: 0x000090DE File Offset: 0x000072DE
		public AllianceDocument()
		{
			this.Description = string.Empty;
			this.Header = new AllianceHeaderEntry();
			this.Members = new Dictionary<long, AllianceMemberEntry>();
			this.KickedMembersTimes = new Dictionary<long, DateTime>();
			this.StreamEntryList = new LogicArrayList<LogicLong>();
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x00016F68 File Offset: 0x00015168
		public AllianceDocument(LogicLong id) : base(id)
		{
			this.Description = string.Empty;
			this.Header = new AllianceHeaderEntry();
			this.Header.SetAllianceId(id);
			this.Members = new Dictionary<long, AllianceMemberEntry>();
			this.KickedMembersTimes = new Dictionary<long, DateTime>();
			this.StreamEntryList = new LogicArrayList<LogicLong>();
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x0000911D File Offset: 0x0000731D
		public bool IsFull()
		{
			return this.Header.GetNumberOfMembers() >= 50;
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x0000815C File Offset: 0x0000635C
		protected sealed override void Encode(ByteStream stream)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x0000815C File Offset: 0x0000635C
		protected sealed override void Decode(ByteStream stream)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x00016FC0 File Offset: 0x000151C0
		protected sealed override void Save(LogicJSONObject jsonObject)
		{
			this.Header.Save(jsonObject);
			jsonObject.Put("description", new LogicJSONString(this.Description));
			LogicJSONArray logicJSONArray = new LogicJSONArray(this.Members.Count);
			foreach (AllianceMemberEntry allianceMemberEntry in this.Members.Values)
			{
				logicJSONArray.Add(allianceMemberEntry.Save());
			}
			jsonObject.Put("members", logicJSONArray);
			LogicJSONArray logicJSONArray2 = new LogicJSONArray(this.KickedMembersTimes.Count);
			foreach (KeyValuePair<long, DateTime> keyValuePair in this.KickedMembersTimes)
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				LogicJSONArray logicJSONArray3 = new LogicJSONArray(2);
				logicJSONArray3.Add(new LogicJSONNumber((int)(keyValuePair.Key >> 32)));
				logicJSONArray3.Add(new LogicJSONNumber((int)keyValuePair.Key));
				logicJSONObject.Put("id", logicJSONArray3);
				logicJSONObject.Put("t", new LogicJSONString(keyValuePair.Value.ToString("O")));
				logicJSONArray2.Add(logicJSONObject);
			}
			jsonObject.Put("kickedMembers", logicJSONArray2);
			LogicJSONArray logicJSONArray4 = new LogicJSONArray(this.StreamEntryList.Size());
			for (int i = 0; i < this.StreamEntryList.Size(); i++)
			{
				LogicLong logicLong = this.StreamEntryList[i];
				LogicJSONArray logicJSONArray5 = new LogicJSONArray(2);
				logicJSONArray5.Add(new LogicJSONNumber(logicLong.GetHigherInt()));
				logicJSONArray5.Add(new LogicJSONNumber(logicLong.GetLowerInt()));
				logicJSONArray4.Add(logicJSONArray5);
			}
			jsonObject.Put("streams", logicJSONArray4);
			jsonObject.Put("checkRankingT", new LogicJSONNumber(TimeUtil.GetTimestamp(this.CheckRankingTime)));
			jsonObject.Put("donationT", new LogicJSONNumber(TimeUtil.GetTimestamp(this.DonationTime)));
			jsonObject.Put("lastUpdateT", new LogicJSONNumber(TimeUtil.GetTimestamp(this.LastUpdateTime)));
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x00017200 File Offset: 0x00015400
		protected sealed override void Load(LogicJSONObject jsonObject)
		{
			this.Header.Load(jsonObject);
			this.Header.SetAllianceId(base.Id);
			this.Description = jsonObject.GetJSONString("description").GetStringValue();
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("members");
			for (int i = 0; i < jsonarray.Size(); i++)
			{
				AllianceMemberEntry allianceMemberEntry = new AllianceMemberEntry();
				allianceMemberEntry.Load(jsonarray.GetJSONObject(i));
				this.Members.Add(allianceMemberEntry.GetAvatarId(), allianceMemberEntry);
			}
			LogicJSONArray jsonarray2 = jsonObject.GetJSONArray("kickedMembers");
			for (int j = 0; j < jsonarray2.Size(); j++)
			{
				LogicJSONObject jsonobject = jsonarray2.GetJSONObject(j);
				LogicJSONArray jsonarray3 = jsonobject.GetJSONArray("id");
				LogicLong @long = new LogicLong(jsonarray3.GetJSONNumber(0).GetIntValue(), jsonarray3.GetJSONNumber(1).GetIntValue());
				DateTime value = DateTime.Parse(jsonobject.GetJSONString("t").GetStringValue());
				this.KickedMembersTimes.Add(@long, value);
			}
			LogicJSONArray jsonarray4 = jsonObject.GetJSONArray("streams");
			for (int k = 0; k < jsonarray4.Size(); k++)
			{
				LogicJSONArray jsonarray5 = jsonarray4.GetJSONArray(k);
				LogicLong item = new LogicLong(jsonarray5.GetJSONNumber(0).GetIntValue(), jsonarray5.GetJSONNumber(1).GetIntValue());
				this.StreamEntryList.Add(item);
			}
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("checkRankingT");
			if (jsonnumber != null)
			{
				this.CheckRankingTime = TimeUtil.GetDateTimeFromTimestamp(jsonnumber.GetIntValue());
				this.DonationTime = TimeUtil.GetDateTimeFromTimestamp(jsonObject.GetJSONNumber("donationT").GetIntValue());
				this.LastUpdateTime = TimeUtil.GetDateTimeFromTimestamp(jsonObject.GetJSONNumber("lastUpdateT").GetIntValue());
				return;
			}
			DateTime utcNow = DateTime.UtcNow;
			this.CheckRankingTime = utcNow.Date;
			this.DonationTime = new DateTime(utcNow.Year, utcNow.Month, 1);
			this.LastUpdateTime = utcNow;
		}

		// Token: 0x0400040F RID: 1039
		private const string string_0 = "description";

		// Token: 0x04000410 RID: 1040
		private const string string_1 = "members";

		// Token: 0x04000411 RID: 1041
		private const string string_2 = "kickedMembers";

		// Token: 0x04000412 RID: 1042
		private const string string_3 = "id";

		// Token: 0x04000413 RID: 1043
		private const string string_4 = "t";

		// Token: 0x04000414 RID: 1044
		private const string string_5 = "streams";

		// Token: 0x04000415 RID: 1045
		private const string string_6 = "donationT";

		// Token: 0x04000416 RID: 1046
		private const string string_7 = "checkRankingT";

		// Token: 0x04000417 RID: 1047
		private const string string_8 = "lastUpdateT";

		// Token: 0x04000418 RID: 1048
		[CompilerGenerated]
		private string string_9;

		// Token: 0x04000419 RID: 1049
		[CompilerGenerated]
		private readonly AllianceHeaderEntry allianceHeaderEntry_0;

		// Token: 0x0400041A RID: 1050
		[CompilerGenerated]
		private readonly Dictionary<long, AllianceMemberEntry> dictionary_0;

		// Token: 0x0400041B RID: 1051
		[CompilerGenerated]
		private readonly Dictionary<long, DateTime> dictionary_1;

		// Token: 0x0400041C RID: 1052
		[CompilerGenerated]
		private readonly LogicArrayList<LogicLong> logicArrayList_0;

		// Token: 0x0400041D RID: 1053
		[CompilerGenerated]
		private DateTime dateTime_0;

		// Token: 0x0400041E RID: 1054
		[CompilerGenerated]
		private DateTime dateTime_1;

		// Token: 0x0400041F RID: 1055
		[CompilerGenerated]
		private DateTime dateTime_2;
	}
}
