using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000C0 RID: 192
	public class DonateAllianceUnitMessage : PiranhaMessage
	{
		// Token: 0x06000856 RID: 2134 RVA: 0x00006C21 File Offset: 0x00004E21
		public DonateAllianceUnitMessage() : this(0)
		{
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x0000328C File Offset: 0x0000148C
		public DonateAllianceUnitMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00020D34 File Offset: 0x0001EF34
		public override void Decode()
		{
			base.Decode();
			this.logicCombatItemData_0 = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(this.m_stream, (this.m_stream.ReadInt() != 0) ? LogicDataType.SPELL : LogicDataType.CHARACTER);
			this.logicLong_0 = this.m_stream.ReadLong();
			this.bool_0 = this.m_stream.ReadBoolean();
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x00006C2A File Offset: 0x00004E2A
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.logicCombatItemData_0.GetCombatItemType());
			ByteStreamHelper.WriteDataReference(this.m_stream, this.logicCombatItemData_0);
			this.m_stream.WriteBoolean(this.bool_0);
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x00006C6A File Offset: 0x00004E6A
		public override short GetMessageType()
		{
			return 14310;
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x00006C71 File Offset: 0x00004E71
		public override void Destruct()
		{
			base.Destruct();
			this.logicCombatItemData_0 = null;
			this.logicLong_0 = null;
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x00006C87 File Offset: 0x00004E87
		public LogicCombatItemData GetAllianceUnitData()
		{
			return this.logicCombatItemData_0;
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x00006C8F File Offset: 0x00004E8F
		public void SetAllianceUnitData(LogicCombatItemData data)
		{
			this.logicCombatItemData_0 = data;
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x00006C98 File Offset: 0x00004E98
		public LogicLong GetStreamId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x00006CA0 File Offset: 0x00004EA0
		public void SetStreamId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x00006CA9 File Offset: 0x00004EA9
		public bool UseQuickDonate()
		{
			return this.bool_0;
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x00006CB1 File Offset: 0x00004EB1
		public void SetQuickDonate(bool enabled)
		{
			this.bool_0 = enabled;
		}

		// Token: 0x04000337 RID: 823
		public const int MESSAGE_TYPE = 14310;

		// Token: 0x04000338 RID: 824
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000339 RID: 825
		private LogicLong logicLong_0;

		// Token: 0x0400033A RID: 826
		private bool bool_0;
	}
}
