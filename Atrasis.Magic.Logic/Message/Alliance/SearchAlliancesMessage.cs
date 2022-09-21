using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000C7 RID: 199
	public class SearchAlliancesMessage : PiranhaMessage
	{
		// Token: 0x06000898 RID: 2200 RVA: 0x00006ED6 File Offset: 0x000050D6
		public SearchAlliancesMessage() : this(0)
		{
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x0000328C File Offset: 0x0000148C
		public SearchAlliancesMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x00020F04 File Offset: 0x0001F104
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
			this.int_0 = this.m_stream.ReadInt();
			this.logicData_0 = ByteStreamHelper.ReadDataReference(this.m_stream, LogicDataType.REGION);
			this.int_1 = this.m_stream.ReadInt();
			this.int_2 = this.m_stream.ReadInt();
			this.int_3 = this.m_stream.ReadInt();
			this.int_4 = this.m_stream.ReadInt();
			this.bool_0 = this.m_stream.ReadBoolean();
			this.m_stream.ReadInt();
			this.m_stream.ReadInt();
			this.int_5 = this.m_stream.ReadInt();
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x00020FD0 File Offset: 0x0001F1D0
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteInt(this.int_0);
			ByteStreamHelper.WriteDataReference(this.m_stream, this.logicData_0);
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(this.int_2);
			this.m_stream.WriteInt(this.int_3);
			this.m_stream.WriteInt(this.int_4);
			this.m_stream.WriteBoolean(this.bool_0);
			this.m_stream.WriteInt(0);
			this.m_stream.WriteInt(0);
			this.m_stream.WriteInt(this.int_5);
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x00006EDF File Offset: 0x000050DF
		public override short GetMessageType()
		{
			return 14324;
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x00006A22 File Offset: 0x00004C22
		public override int GetServiceNodeType()
		{
			return 29;
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x00006EE6 File Offset: 0x000050E6
		public string GetSearchString()
		{
			return this.string_0;
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x00006EEE File Offset: 0x000050EE
		public void SetSearchString(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x00006EF7 File Offset: 0x000050F7
		public int GetWarFrequency()
		{
			return this.int_0;
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x00006EFF File Offset: 0x000050FF
		public void SetWarFrequency(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x00006F08 File Offset: 0x00005108
		public LogicData GetOrigin()
		{
			return this.logicData_0;
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x00006F10 File Offset: 0x00005110
		public void SetOrigin(LogicData data)
		{
			this.logicData_0 = data;
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x00006F19 File Offset: 0x00005119
		public int GetMinimumMembers()
		{
			return this.int_1;
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x00006F21 File Offset: 0x00005121
		public void SetMinimumMembers(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x00006F2A File Offset: 0x0000512A
		public int GetMaximumMembers()
		{
			return this.int_2;
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x00006F32 File Offset: 0x00005132
		public void SetMaximumMembers(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x00006F3B File Offset: 0x0000513B
		public int GetRequiredScore()
		{
			return this.int_3;
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x00006F43 File Offset: 0x00005143
		public void SetRequiredScore(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x00006F4C File Offset: 0x0000514C
		public int GetRequiredDuelScore()
		{
			return this.int_4;
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x00006F54 File Offset: 0x00005154
		public void SetRequireDuelScore(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x00006F5D File Offset: 0x0000515D
		public int GetMinimumExpLevel()
		{
			return this.int_5;
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x00006F65 File Offset: 0x00005165
		public void SetMinimumExpLevel(int value)
		{
			this.int_5 = value;
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x00006F6E File Offset: 0x0000516E
		public bool GetJoinableOnly()
		{
			return this.bool_0;
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x00006F76 File Offset: 0x00005176
		public void SetJoinableOnly(bool enabled)
		{
			this.bool_0 = enabled;
		}

		// Token: 0x04000349 RID: 841
		public const int MESSAGE_TYPE = 14324;

		// Token: 0x0400034A RID: 842
		private string string_0;

		// Token: 0x0400034B RID: 843
		private bool bool_0;

		// Token: 0x0400034C RID: 844
		private int int_0;

		// Token: 0x0400034D RID: 845
		private int int_1;

		// Token: 0x0400034E RID: 846
		private int int_2;

		// Token: 0x0400034F RID: 847
		private int int_3;

		// Token: 0x04000350 RID: 848
		private int int_4;

		// Token: 0x04000351 RID: 849
		private int int_5;

		// Token: 0x04000352 RID: 850
		private LogicData logicData_0;
	}
}
