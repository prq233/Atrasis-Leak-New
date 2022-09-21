using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Message.League
{
	// Token: 0x0200003D RID: 61
	public class LeagueMemberEntry
	{
		// Token: 0x060002D3 RID: 723 RVA: 0x00003B9B File Offset: 0x00001D9B
		public LeagueMemberEntry()
		{
			this.int_7 = -1;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0001BC98 File Offset: 0x00019E98
		public void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteString(this.string_0);
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_0);
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(0);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_4);
			encoder.WriteInt(this.int_5);
			encoder.WriteInt(this.int_6);
			encoder.WriteLong(this.logicLong_1);
			encoder.WriteLong(this.logicLong_2);
			if (this.logicLong_3 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteLong(this.logicLong_3);
				encoder.WriteString(this.string_1);
				encoder.WriteInt(this.int_7);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			encoder.WriteLong(new LogicLong(0, 0));
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0001BD7C File Offset: 0x00019F7C
		public void Decode(ByteStream stream)
		{
			this.logicLong_0 = stream.ReadLong();
			this.string_0 = stream.ReadString(900000);
			this.int_1 = stream.ReadInt();
			this.int_0 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			stream.ReadInt();
			this.int_3 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			this.int_5 = stream.ReadInt();
			this.int_6 = stream.ReadInt();
			this.logicLong_1 = stream.ReadLong();
			this.logicLong_2 = stream.ReadLong();
			if (stream.ReadBoolean())
			{
				this.logicLong_3 = stream.ReadLong();
				this.string_1 = stream.ReadString(900000);
				this.int_7 = stream.ReadInt();
			}
			stream.ReadLong();
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00003BAA File Offset: 0x00001DAA
		public LogicLong GetAccountId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00003BB2 File Offset: 0x00001DB2
		public void SetAccountId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00003BBB File Offset: 0x00001DBB
		public LogicLong GetAvatarId()
		{
			return this.logicLong_1;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00003BC3 File Offset: 0x00001DC3
		public void SetAvatarId(LogicLong value)
		{
			this.logicLong_1 = value;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00003BCC File Offset: 0x00001DCC
		public LogicLong GetHomeId()
		{
			return this.logicLong_2;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00003BD4 File Offset: 0x00001DD4
		public void SetHomeId(LogicLong value)
		{
			this.logicLong_2 = value;
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00003BDD File Offset: 0x00001DDD
		public string GetName()
		{
			return this.string_0;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00003BE5 File Offset: 0x00001DE5
		public void SetName(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00003BEE File Offset: 0x00001DEE
		public string GetAllianceName()
		{
			return this.string_1;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00003BF6 File Offset: 0x00001DF6
		public void SetAllianceName(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00003BFF File Offset: 0x00001DFF
		public int GetScore()
		{
			return this.int_0;
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00003C07 File Offset: 0x00001E07
		public void SetScore(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00003C10 File Offset: 0x00001E10
		public int GetOrder()
		{
			return this.int_1;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00003C18 File Offset: 0x00001E18
		public void SetOrder(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00003C21 File Offset: 0x00001E21
		public int GetPreviousOrder()
		{
			return this.int_2;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00003C29 File Offset: 0x00001E29
		public void SetPreviousOrder(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00003C32 File Offset: 0x00001E32
		public int GetAttackWinCount()
		{
			return this.int_3;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00003C3A File Offset: 0x00001E3A
		public void SetAttackWinCount(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00003C43 File Offset: 0x00001E43
		public int GetAttackLoseCount()
		{
			return this.int_4;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00003C4B File Offset: 0x00001E4B
		public void SetAttackLoseCount(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00003C54 File Offset: 0x00001E54
		public int GetDefenseWinCount()
		{
			return this.int_5;
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00003C5C File Offset: 0x00001E5C
		public void SetDefenseWinCount(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00003C65 File Offset: 0x00001E65
		public int GetDefenseLoseCount()
		{
			return this.int_6;
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00003C6D File Offset: 0x00001E6D
		public void SetDefenseLoseCount(int value)
		{
			this.int_6 = value;
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00003C76 File Offset: 0x00001E76
		public int GetAllianceBadgeId()
		{
			return this.int_7;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00003C7E File Offset: 0x00001E7E
		public void SetAllianceBadgeId(int value)
		{
			this.int_7 = value;
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00003C87 File Offset: 0x00001E87
		public LogicLong GetAllianceId()
		{
			return this.logicLong_3;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00003C8F File Offset: 0x00001E8F
		public void SetAllianceId(LogicLong value)
		{
			this.logicLong_3 = value;
		}

		// Token: 0x04000115 RID: 277
		private LogicLong logicLong_0;

		// Token: 0x04000116 RID: 278
		private LogicLong logicLong_1;

		// Token: 0x04000117 RID: 279
		private LogicLong logicLong_2;

		// Token: 0x04000118 RID: 280
		private string string_0;

		// Token: 0x04000119 RID: 281
		private string string_1;

		// Token: 0x0400011A RID: 282
		private int int_0;

		// Token: 0x0400011B RID: 283
		private int int_1;

		// Token: 0x0400011C RID: 284
		private int int_2;

		// Token: 0x0400011D RID: 285
		private int int_3;

		// Token: 0x0400011E RID: 286
		private int int_4;

		// Token: 0x0400011F RID: 287
		private int int_5;

		// Token: 0x04000120 RID: 288
		private int int_6;

		// Token: 0x04000121 RID: 289
		private int int_7;

		// Token: 0x04000122 RID: 290
		private LogicLong logicLong_3;
	}
}
