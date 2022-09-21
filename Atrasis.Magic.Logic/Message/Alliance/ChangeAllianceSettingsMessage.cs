using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000BE RID: 190
	public class ChangeAllianceSettingsMessage : PiranhaMessage
	{
		// Token: 0x06000824 RID: 2084 RVA: 0x00006AC1 File Offset: 0x00004CC1
		public ChangeAllianceSettingsMessage() : this(0)
		{
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0000328C File Offset: 0x0000148C
		public ChangeAllianceSettingsMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x00020A30 File Offset: 0x0001EC30
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
			this.m_stream.ReadString(900000);
			this.int_1 = this.m_stream.ReadInt();
			this.int_0 = this.m_stream.ReadInt();
			this.int_2 = this.m_stream.ReadInt();
			this.int_3 = this.m_stream.ReadInt();
			this.int_4 = this.m_stream.ReadInt();
			this.logicData_0 = ByteStreamHelper.ReadDataReference(this.m_stream);
			this.bool_0 = this.m_stream.ReadBoolean();
			this.bool_1 = this.m_stream.ReadBoolean();
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x00020AF4 File Offset: 0x0001ECF4
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteString(null);
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_2);
			this.m_stream.WriteInt(this.int_3);
			this.m_stream.WriteInt(this.int_4);
			ByteStreamHelper.WriteDataReference(this.m_stream, this.logicData_0);
			this.m_stream.WriteBoolean(this.bool_0);
			this.m_stream.WriteBoolean(this.bool_1);
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x00006ACA File Offset: 0x00004CCA
		public override short GetMessageType()
		{
			return 14316;
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x00006AD1 File Offset: 0x00004CD1
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x00006AE0 File Offset: 0x00004CE0
		public string GetAllianceDescription()
		{
			return this.string_0;
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x00006AE8 File Offset: 0x00004CE8
		public void SetAllianceDescription(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x00006AF1 File Offset: 0x00004CF1
		public int GetAllianceBadgeId()
		{
			return this.int_1;
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x00006AF9 File Offset: 0x00004CF9
		public void SetAllianceBadgeId(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x00006B02 File Offset: 0x00004D02
		public int GetAllianceType()
		{
			return this.int_0;
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x00006B0A File Offset: 0x00004D0A
		public void SetAllianceType(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x00006B13 File Offset: 0x00004D13
		public int GetRequiredScore()
		{
			return this.int_2;
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x00006B1B File Offset: 0x00004D1B
		public void SetRequiredScore(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x00006B24 File Offset: 0x00004D24
		public int GetRequiredDuelScore()
		{
			return this.int_3;
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x00006B2C File Offset: 0x00004D2C
		public void SetRequiredDuelScore(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x00006B35 File Offset: 0x00004D35
		public LogicData GetOriginData()
		{
			return this.logicData_0;
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x00006B3D File Offset: 0x00004D3D
		public void SetOriginData(LogicData data)
		{
			this.logicData_0 = data;
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x00006B46 File Offset: 0x00004D46
		public int GetWarFrequency()
		{
			return this.int_4;
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x00006B4E File Offset: 0x00004D4E
		public bool IsAmicalWarEnabled()
		{
			return this.bool_1;
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x00006B56 File Offset: 0x00004D56
		public void SetAmicalWarEnabled(bool enabled)
		{
			this.bool_1 = enabled;
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x00006B5F File Offset: 0x00004D5F
		public bool IsPublicWarLog()
		{
			return this.bool_0;
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x00006B67 File Offset: 0x00004D67
		public void SetPublicWarLog(bool enabled)
		{
			this.bool_0 = enabled;
		}

		// Token: 0x04000322 RID: 802
		public const int MESSAGE_TYPE = 14316;

		// Token: 0x04000323 RID: 803
		private LogicData logicData_0;

		// Token: 0x04000324 RID: 804
		private string string_0;

		// Token: 0x04000325 RID: 805
		private int int_0;

		// Token: 0x04000326 RID: 806
		private int int_1;

		// Token: 0x04000327 RID: 807
		private int int_2;

		// Token: 0x04000328 RID: 808
		private int int_3;

		// Token: 0x04000329 RID: 809
		private int int_4;

		// Token: 0x0400032A RID: 810
		private bool bool_0;

		// Token: 0x0400032B RID: 811
		private bool bool_1;
	}
}
