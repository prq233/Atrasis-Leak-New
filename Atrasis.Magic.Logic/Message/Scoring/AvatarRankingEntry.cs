using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x02000039 RID: 57
	public class AvatarRankingEntry : RankingEntry
	{
		// Token: 0x0600028B RID: 651 RVA: 0x000038FF File Offset: 0x00001AFF
		public AvatarRankingEntry()
		{
			this.int_9 = -1;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0001B544 File Offset: 0x00019744
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteInt(this.int_3);
			stream.WriteInt(this.int_4);
			stream.WriteInt(this.int_5);
			stream.WriteInt(this.int_6);
			stream.WriteInt(this.int_7);
			stream.WriteInt(this.int_8);
			stream.WriteString(this.string_16);
			stream.WriteLong(this.logicLong_1);
			stream.WriteInt(0);
			stream.WriteInt(0);
			if (this.logicLong_2 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_2);
				stream.WriteString(this.string_17);
				stream.WriteInt(this.int_9);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0001B604 File Offset: 0x00019804
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			this.int_6 = stream.ReadInt();
			this.int_7 = stream.ReadInt();
			this.int_8 = stream.ReadInt();
			this.string_16 = stream.ReadString(900000);
			this.logicLong_1 = stream.ReadLong();
			stream.ReadInt();
			stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.logicLong_2 = stream.ReadLong();
				this.string_17 = stream.ReadString(900000);
				this.int_9 = stream.ReadInt();
			}
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000390E File Offset: 0x00001B0E
		public int GetExpLevel()
		{
			return this.int_3;
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00003916 File Offset: 0x00001B16
		public void SetExpLevel(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000391F File Offset: 0x00001B1F
		public int GetAttackWinCount()
		{
			return this.int_4;
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00003927 File Offset: 0x00001B27
		public void SetAttackWinCount(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00003930 File Offset: 0x00001B30
		public int GetAttackLoseCount()
		{
			return this.int_5;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00003938 File Offset: 0x00001B38
		public void SetAttackLoseCount(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00003941 File Offset: 0x00001B41
		public int GetDefenseWinCount()
		{
			return this.int_6;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00003949 File Offset: 0x00001B49
		public void SetDefenseWinCount(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00003952 File Offset: 0x00001B52
		public int GetDefenseLoseCount()
		{
			return this.int_7;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000395A File Offset: 0x00001B5A
		public void SetDefenseLoseCount(int value)
		{
			this.int_7 = value;
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00003963 File Offset: 0x00001B63
		public int GetLeagueType()
		{
			return this.int_8;
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000396B File Offset: 0x00001B6B
		public void SetLeagueType(int value)
		{
			this.int_8 = value;
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00003974 File Offset: 0x00001B74
		public int GetAllianceBadgeId()
		{
			return this.int_9;
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000397C File Offset: 0x00001B7C
		public void SetAllianceBadgeId(int value)
		{
			this.int_9 = value;
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00003985 File Offset: 0x00001B85
		public string GetCountry()
		{
			return this.string_16;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000398D File Offset: 0x00001B8D
		public void SetCountry(string value)
		{
			this.string_16 = value;
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00003996 File Offset: 0x00001B96
		public string GetAllianceName()
		{
			return this.string_17;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000399E File Offset: 0x00001B9E
		public void SetAllianceName(string value)
		{
			this.string_17 = value;
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x000039A7 File Offset: 0x00001BA7
		public LogicLong GetHomeId()
		{
			return this.logicLong_1;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x000039AF File Offset: 0x00001BAF
		public void SetHomeId(LogicLong value)
		{
			this.logicLong_1 = value;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x000039B8 File Offset: 0x00001BB8
		public LogicLong GetAllianceId()
		{
			return this.logicLong_2;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x000039C0 File Offset: 0x00001BC0
		public void SetAllianceId(LogicLong value)
		{
			this.logicLong_2 = value;
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0001B6BC File Offset: 0x000198BC
		public override LogicJSONObject Save()
		{
			LogicJSONObject logicJSONObject = base.Save();
			logicJSONObject.Put("xpLvl", new LogicJSONNumber(this.int_3));
			logicJSONObject.Put("attWinCnt", new LogicJSONNumber(this.int_4));
			logicJSONObject.Put("attLoseCnt", new LogicJSONNumber(this.int_5));
			logicJSONObject.Put("defWinCnt", new LogicJSONNumber(this.int_6));
			logicJSONObject.Put("defLoseCnt", new LogicJSONNumber(this.int_7));
			logicJSONObject.Put("leagueT", new LogicJSONNumber(this.int_8));
			if (this.logicLong_2 != null)
			{
				LogicJSONObject logicJSONObject2 = new LogicJSONObject();
				LogicJSONArray logicJSONArray = new LogicJSONArray(2);
				logicJSONArray.Add(new LogicJSONNumber(this.logicLong_2.GetHigherInt()));
				logicJSONArray.Add(new LogicJSONNumber(this.logicLong_2.GetLowerInt()));
				logicJSONObject2.Put("id", logicJSONArray);
				logicJSONObject2.Put("name", new LogicJSONString(this.string_17));
				logicJSONObject2.Put("badgeId", new LogicJSONNumber(this.int_9));
				logicJSONObject.Put("alli", logicJSONObject2);
			}
			return logicJSONObject;
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0001B7DC File Offset: 0x000199DC
		public override void Load(LogicJSONObject jsonObject)
		{
			base.Load(jsonObject);
			this.int_3 = jsonObject.GetJSONNumber("xpLvl").GetIntValue();
			this.int_4 = jsonObject.GetJSONNumber("attWinCnt").GetIntValue();
			this.int_5 = jsonObject.GetJSONNumber("attLoseCnt").GetIntValue();
			this.int_6 = jsonObject.GetJSONNumber("defWinCnt").GetIntValue();
			this.int_7 = jsonObject.GetJSONNumber("defLoseCnt").GetIntValue();
			this.int_8 = jsonObject.GetJSONNumber("leagueT").GetIntValue();
			LogicJSONObject jsonobject = jsonObject.GetJSONObject("alli");
			if (jsonobject != null)
			{
				LogicJSONArray jsonarray = jsonobject.GetJSONArray("id");
				this.logicLong_2 = new LogicLong(jsonarray.GetJSONNumber(0).GetIntValue(), jsonarray.GetJSONNumber(1).GetIntValue());
				this.string_17 = jsonobject.GetJSONString("name").GetStringValue();
				this.int_9 = jsonobject.GetJSONNumber("badgeId").GetIntValue();
			}
			this.logicLong_1 = base.GetId().Clone();
		}

		// Token: 0x040000EC RID: 236
		private const string string_6 = "xpLvl";

		// Token: 0x040000ED RID: 237
		private const string string_7 = "attWinCnt";

		// Token: 0x040000EE RID: 238
		private const string string_8 = "attLoseCnt";

		// Token: 0x040000EF RID: 239
		private const string string_9 = "defWinCnt";

		// Token: 0x040000F0 RID: 240
		private const string string_10 = "defLoseCnt";

		// Token: 0x040000F1 RID: 241
		private const string string_11 = "leagueT";

		// Token: 0x040000F2 RID: 242
		private const string string_12 = "alli";

		// Token: 0x040000F3 RID: 243
		private const string string_13 = "id";

		// Token: 0x040000F4 RID: 244
		private const string string_14 = "name";

		// Token: 0x040000F5 RID: 245
		private const string string_15 = "badgeId";

		// Token: 0x040000F6 RID: 246
		private int int_3;

		// Token: 0x040000F7 RID: 247
		private int int_4;

		// Token: 0x040000F8 RID: 248
		private int int_5;

		// Token: 0x040000F9 RID: 249
		private int int_6;

		// Token: 0x040000FA RID: 250
		private int int_7;

		// Token: 0x040000FB RID: 251
		private int int_8;

		// Token: 0x040000FC RID: 252
		private int int_9;

		// Token: 0x040000FD RID: 253
		private string string_16;

		// Token: 0x040000FE RID: 254
		private string string_17;

		// Token: 0x040000FF RID: 255
		private LogicLong logicLong_1;

		// Token: 0x04000100 RID: 256
		private LogicLong logicLong_2;
	}
}
