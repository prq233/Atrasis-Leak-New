using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000BF RID: 191
	public class CreateAllianceMessage : PiranhaMessage
	{
		// Token: 0x0600083C RID: 2108 RVA: 0x00006B70 File Offset: 0x00004D70
		public CreateAllianceMessage() : this(0)
		{
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x0000328C File Offset: 0x0000148C
		public CreateAllianceMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x00020BAC File Offset: 0x0001EDAC
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
			this.string_1 = this.m_stream.ReadString(900000);
			this.int_1 = this.m_stream.ReadInt();
			this.int_0 = this.m_stream.ReadInt();
			this.int_2 = this.m_stream.ReadInt();
			this.int_3 = this.m_stream.ReadInt();
			this.int_4 = this.m_stream.ReadInt();
			this.logicData_0 = ByteStreamHelper.ReadDataReference(this.m_stream);
			this.bool_0 = this.m_stream.ReadBoolean();
			this.bool_1 = this.m_stream.ReadBoolean();
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x00020C74 File Offset: 0x0001EE74
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteString(this.string_1);
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_2);
			this.m_stream.WriteInt(this.int_3);
			this.m_stream.WriteInt(this.int_4);
			ByteStreamHelper.WriteDataReference(this.m_stream, this.logicData_0);
			this.m_stream.WriteBoolean(this.bool_0);
			this.m_stream.WriteBoolean(this.bool_1);
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x00006B79 File Offset: 0x00004D79
		public override short GetMessageType()
		{
			return 14301;
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x00006B80 File Offset: 0x00004D80
		public string GetAllianceName()
		{
			return this.string_0;
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x00006B88 File Offset: 0x00004D88
		public void SetAllianceName(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x00006B91 File Offset: 0x00004D91
		public string GetAllianceDescription()
		{
			return this.string_1;
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x00006B99 File Offset: 0x00004D99
		public void SetAllianceDescription(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00006BA2 File Offset: 0x00004DA2
		public int GetAllianceBadgeId()
		{
			return this.int_1;
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x00006BAA File Offset: 0x00004DAA
		public void SetAllianceBadgeId(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x00006BB3 File Offset: 0x00004DB3
		public int GetAllianceType()
		{
			return this.int_0;
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x00006BBB File Offset: 0x00004DBB
		public void SetAllianceType(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x00006BC4 File Offset: 0x00004DC4
		public int GetRequiredScore()
		{
			return this.int_2;
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x00006BCC File Offset: 0x00004DCC
		public void SetRequiredScore(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x00006BD5 File Offset: 0x00004DD5
		public int GetRequiredDuelScore()
		{
			return this.int_3;
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x00006BDD File Offset: 0x00004DDD
		public void SetRequiredDuelScore(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x00006BE6 File Offset: 0x00004DE6
		public LogicData GetOriginData()
		{
			return this.logicData_0;
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x00006BEE File Offset: 0x00004DEE
		public void SetOriginData(LogicData data)
		{
			this.logicData_0 = data;
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x00006BF7 File Offset: 0x00004DF7
		public int GetWarFrequency()
		{
			return this.int_4;
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x00006BFF File Offset: 0x00004DFF
		public bool GetArrangedWarEnabled()
		{
			return this.bool_1;
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x00006C07 File Offset: 0x00004E07
		public void SetAmicalWarEnabled(bool enabled)
		{
			this.bool_1 = enabled;
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00006C10 File Offset: 0x00004E10
		public bool GetPublicWarLog()
		{
			return this.bool_0;
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00006C18 File Offset: 0x00004E18
		public void SetPublicWarLog(bool enabled)
		{
			this.bool_0 = enabled;
		}

		// Token: 0x0400032C RID: 812
		public const int MESSAGE_TYPE = 14301;

		// Token: 0x0400032D RID: 813
		private LogicData logicData_0;

		// Token: 0x0400032E RID: 814
		private string string_0;

		// Token: 0x0400032F RID: 815
		private string string_1;

		// Token: 0x04000330 RID: 816
		private int int_0;

		// Token: 0x04000331 RID: 817
		private int int_1;

		// Token: 0x04000332 RID: 818
		private int int_2;

		// Token: 0x04000333 RID: 819
		private int int_3;

		// Token: 0x04000334 RID: 820
		private int int_4;

		// Token: 0x04000335 RID: 821
		private bool bool_0;

		// Token: 0x04000336 RID: 822
		private bool bool_1;
	}
}
