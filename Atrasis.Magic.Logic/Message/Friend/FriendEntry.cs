using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x0200006D RID: 109
	public class FriendEntry
	{
		// Token: 0x060004BC RID: 1212 RVA: 0x00004CC4 File Offset: 0x00002EC4
		public FriendEntry()
		{
			this.int_5 = -1;
			this.int_6 = -1;
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0001CE64 File Offset: 0x0001B064
		public void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			if (stream.ReadBoolean())
			{
				this.logicLong_1 = stream.ReadLong();
			}
			this.string_0 = stream.ReadString(900000);
			this.string_2 = stream.ReadString(900000);
			this.string_3 = stream.ReadString(900000);
			stream.ReadString(900000);
			this.int_0 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.logicLong_2 = stream.ReadLong();
				this.int_6 = stream.ReadInt();
				this.string_1 = stream.ReadString(900000);
				this.int_7 = stream.ReadInt();
				this.int_8 = stream.ReadInt();
			}
			if (stream.ReadBoolean())
			{
				this.logicLong_3 = stream.ReadLong();
				stream.ReadInt();
			}
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0001CF84 File Offset: 0x0001B184
		public void Encode(ByteStream stream)
		{
			stream.WriteLong(this.logicLong_0);
			if (this.logicLong_1 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_1);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			stream.WriteString(this.string_0);
			stream.WriteString(this.string_2);
			stream.WriteString(this.string_3);
			stream.WriteString(null);
			stream.WriteInt(this.int_0);
			stream.WriteInt(this.int_1);
			stream.WriteInt(this.int_2);
			stream.WriteInt(this.int_3);
			stream.WriteInt(this.int_4);
			stream.WriteInt(this.int_5);
			stream.WriteInt(0);
			if (this.logicLong_2 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_2);
				stream.WriteInt(this.int_6);
				stream.WriteString(this.string_1);
				stream.WriteInt(this.int_7);
				stream.WriteInt(this.int_8);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			if (this.logicLong_3 != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.logicLong_3);
				stream.WriteInt(0);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00004CDA File Offset: 0x00002EDA
		public LogicLong GetAvatarId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00004CE2 File Offset: 0x00002EE2
		public void SetAvatarId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00004CEB File Offset: 0x00002EEB
		public LogicLong GetHomeId()
		{
			return this.logicLong_1;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00004CF3 File Offset: 0x00002EF3
		public void SetHomeId(LogicLong value)
		{
			this.logicLong_1 = value;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00004CFC File Offset: 0x00002EFC
		public LogicLong GetAllianceId()
		{
			return this.logicLong_2;
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00004D04 File Offset: 0x00002F04
		public void SetAllianceId(LogicLong value)
		{
			this.logicLong_2 = value;
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00004D0D File Offset: 0x00002F0D
		public LogicLong GetLiveReplayId()
		{
			return this.logicLong_3;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00004D15 File Offset: 0x00002F15
		public void SetLiveReplayId(LogicLong value)
		{
			this.logicLong_3 = value;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00004D1E File Offset: 0x00002F1E
		public string GetName()
		{
			return this.string_0;
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00004D26 File Offset: 0x00002F26
		public void SetName(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00004D2F File Offset: 0x00002F2F
		public string GetAllianceName()
		{
			return this.string_1;
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x00004D37 File Offset: 0x00002F37
		public void SetAllianceName(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x00004D40 File Offset: 0x00002F40
		public string GetFacebookId()
		{
			return this.string_2;
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00004D48 File Offset: 0x00002F48
		public void SetFacebookId(string value)
		{
			this.string_2 = value;
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00004D51 File Offset: 0x00002F51
		public string GetGamecenterId()
		{
			return this.string_3;
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00004D59 File Offset: 0x00002F59
		public void SetGamecenterId(string value)
		{
			this.string_3 = value;
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00004D62 File Offset: 0x00002F62
		public int GetProtectionDurationSeconds()
		{
			return this.int_0;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00004D6A File Offset: 0x00002F6A
		public void SetProtectionDurationSeconds(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00004D73 File Offset: 0x00002F73
		public int GetExpLevel()
		{
			return this.int_1;
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00004D7B File Offset: 0x00002F7B
		public void SetExpLevel(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00004D84 File Offset: 0x00002F84
		public int GetLeagueType()
		{
			return this.int_2;
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00004D8C File Offset: 0x00002F8C
		public void SetLeagueType(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00004D95 File Offset: 0x00002F95
		public int GetScore()
		{
			return this.int_3;
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x00004D9D File Offset: 0x00002F9D
		public void SetScore(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00004DA6 File Offset: 0x00002FA6
		public int GetDuelScore()
		{
			return this.int_4;
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00004DAE File Offset: 0x00002FAE
		public void SetDuelScore(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00004DB7 File Offset: 0x00002FB7
		public int GetFriendState()
		{
			return this.int_5;
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00004DBF File Offset: 0x00002FBF
		public void SetFriendState(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00004DC8 File Offset: 0x00002FC8
		public int GetAllianceBadgeId()
		{
			return this.int_6;
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00004DD0 File Offset: 0x00002FD0
		public void SetAllianceBadgeId(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00004DD9 File Offset: 0x00002FD9
		public int GetAllianceRole()
		{
			return this.int_7;
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00004DE1 File Offset: 0x00002FE1
		public void SetAllianceRole(int value)
		{
			this.int_7 = value;
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00004DEA File Offset: 0x00002FEA
		public int GetAllianceLevel()
		{
			return this.int_8;
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00004DF2 File Offset: 0x00002FF2
		public void SetAllianceLevel(int value)
		{
			this.int_8 = value;
		}

		// Token: 0x040001CC RID: 460
		private LogicLong logicLong_0;

		// Token: 0x040001CD RID: 461
		private LogicLong logicLong_1;

		// Token: 0x040001CE RID: 462
		private LogicLong logicLong_2;

		// Token: 0x040001CF RID: 463
		private LogicLong logicLong_3;

		// Token: 0x040001D0 RID: 464
		private string string_0;

		// Token: 0x040001D1 RID: 465
		private string string_1;

		// Token: 0x040001D2 RID: 466
		private string string_2;

		// Token: 0x040001D3 RID: 467
		private string string_3;

		// Token: 0x040001D4 RID: 468
		private int int_0;

		// Token: 0x040001D5 RID: 469
		private int int_1;

		// Token: 0x040001D6 RID: 470
		private int int_2;

		// Token: 0x040001D7 RID: 471
		private int int_3;

		// Token: 0x040001D8 RID: 472
		private int int_4;

		// Token: 0x040001D9 RID: 473
		private int int_5;

		// Token: 0x040001DA RID: 474
		private int int_6;

		// Token: 0x040001DB RID: 475
		private int int_7;

		// Token: 0x040001DC RID: 476
		private int int_8;
	}
}
