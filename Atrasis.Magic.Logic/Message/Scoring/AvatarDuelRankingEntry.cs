using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x02000035 RID: 53
	public class AvatarDuelRankingEntry : RankingEntry
	{
		// Token: 0x06000249 RID: 585 RVA: 0x0000371C File Offset: 0x0000191C
		public AvatarDuelRankingEntry()
		{
			this.int_7 = -1;
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0001AE34 File Offset: 0x00019034
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteInt(this.int_3);
			stream.WriteInt(this.int_4);
			stream.WriteInt(this.int_5);
			stream.WriteInt(this.int_6);
			stream.WriteString(this.string_14);
			stream.WriteLong(this.logicLong_1);
			stream.WriteInt(0);
			stream.WriteInt(0);
			if (this.logicLong_2 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_2);
				stream.WriteString(this.string_15);
				stream.WriteInt(this.int_7);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0001AEDC File Offset: 0x000190DC
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			this.int_6 = stream.ReadInt();
			this.string_14 = stream.ReadString(900000);
			this.logicLong_1 = stream.ReadLong();
			stream.ReadInt();
			stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.logicLong_2 = stream.ReadLong();
				this.string_15 = stream.ReadString(900000);
				this.int_7 = stream.ReadInt();
			}
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000372B File Offset: 0x0000192B
		public int GetExpLevel()
		{
			return this.int_3;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00003733 File Offset: 0x00001933
		public void SetExpLevel(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000373C File Offset: 0x0000193C
		public int GetDuelWinCount()
		{
			return this.int_4;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00003744 File Offset: 0x00001944
		public void SetDuelWinCount(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000374D File Offset: 0x0000194D
		public int GetDuelLoseCount()
		{
			return this.int_6;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00003755 File Offset: 0x00001955
		public void SetDuelLoseCount(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000375E File Offset: 0x0000195E
		public int GetDuelDrawCount()
		{
			return this.int_5;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00003766 File Offset: 0x00001966
		public void SetDuelDrawCount(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000376F File Offset: 0x0000196F
		public int GetAllianceBadgeId()
		{
			return this.int_7;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00003777 File Offset: 0x00001977
		public void SetAllianceBadgeId(int value)
		{
			this.int_7 = value;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00003780 File Offset: 0x00001980
		public string GetCountry()
		{
			return this.string_14;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00003788 File Offset: 0x00001988
		public void SetCountry(string value)
		{
			this.string_14 = value;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00003791 File Offset: 0x00001991
		public string GetAllianceName()
		{
			return this.string_15;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00003799 File Offset: 0x00001999
		public void SetAllianceName(string value)
		{
			this.string_15 = value;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x000037A2 File Offset: 0x000019A2
		public LogicLong GetHomeId()
		{
			return this.logicLong_1;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x000037AA File Offset: 0x000019AA
		public void SetHomeId(LogicLong value)
		{
			this.logicLong_1 = value;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x000037B3 File Offset: 0x000019B3
		public LogicLong GetAllianceId()
		{
			return this.logicLong_2;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x000037BB File Offset: 0x000019BB
		public void SetAllianceId(LogicLong value)
		{
			this.logicLong_2 = value;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0001AF7C File Offset: 0x0001917C
		public override LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = base.Save();
			logicJSONObject.Put("xpLvl", new LogicJSONNumber(this.int_3));
			logicJSONObject.Put("dWinCnt", new LogicJSONNumber(this.int_4));
			logicJSONObject.Put("dDrawCnt", new LogicJSONNumber(this.int_5));
			logicJSONObject.Put("dLoseCnt", new LogicJSONNumber(this.int_6));
			if (this.logicLong_2 != null)
			{
				LogicJSONObject logicJSONObject2 = new LogicJSONObject();
				LogicJSONArray logicJSONArray = new LogicJSONArray(2);
				logicJSONArray.Add(new LogicJSONNumber(this.logicLong_2.GetHigherInt()));
				logicJSONArray.Add(new LogicJSONNumber(this.logicLong_2.GetLowerInt()));
				logicJSONObject2.Put("id", logicJSONArray);
				logicJSONObject2.Put("name", new LogicJSONString(this.string_15));
				logicJSONObject2.Put("badgeId", new LogicJSONNumber(this.int_7));
				logicJSONObject.Put("alli", logicJSONObject2);
			}
			return logicJSONObject;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0001B070 File Offset: 0x00019270
		public override void Load(LogicJSONObject jsonObject)
		{
			base.Load(jsonObject);
			this.int_3 = jsonObject.GetJSONNumber("xpLvl").GetIntValue();
			this.int_4 = jsonObject.GetJSONNumber("dWinCnt").GetIntValue();
			this.int_5 = jsonObject.GetJSONNumber("dDrawCnt").GetIntValue();
			this.int_6 = jsonObject.GetJSONNumber("dLoseCnt").GetIntValue();
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("alli");
			if (jsonobject != null)
			{
				LogicJSONArray jsonarray = jsonobject.GetJSONArray("id");
				this.logicLong_2 = new LogicLong(jsonarray.GetJSONNumber(0).GetIntValue(), jsonarray.GetJSONNumber(1).GetIntValue());
				this.string_15 = jsonobject.GetJSONString("name").GetStringValue();
				this.int_7 = jsonobject.GetJSONNumber("badgeId").GetIntValue();
			}
			this.logicLong_1 = base.GetId().Clone();
		}

		// Token: 0x040000CD RID: 205
		private const string string_6 = "xpLvl";

		// Token: 0x040000CE RID: 206
		private const string string_7 = "dWinCnt";

		// Token: 0x040000CF RID: 207
		private const string string_8 = "dDrawCnt";

		// Token: 0x040000D0 RID: 208
		private const string string_9 = "dLoseCnt";

		// Token: 0x040000D1 RID: 209
		private const string string_10 = "alli";

		// Token: 0x040000D2 RID: 210
		private const string string_11 = "id";

		// Token: 0x040000D3 RID: 211
		private const string string_12 = "name";

		// Token: 0x040000D4 RID: 212
		private const string string_13 = "badgeId";

		// Token: 0x040000D5 RID: 213
		private int int_3;

		// Token: 0x040000D6 RID: 214
		private int int_4;

		// Token: 0x040000D7 RID: 215
		private int int_5;

		// Token: 0x040000D8 RID: 216
		private int int_6;

		// Token: 0x040000D9 RID: 217
		private int int_7;

		// Token: 0x040000DA RID: 218
		private string string_14;

		// Token: 0x040000DB RID: 219
		private string string_15;

		// Token: 0x040000DC RID: 220
		private LogicLong logicLong_1;

		// Token: 0x040000DD RID: 221
		private LogicLong logicLong_2;
	}
}
