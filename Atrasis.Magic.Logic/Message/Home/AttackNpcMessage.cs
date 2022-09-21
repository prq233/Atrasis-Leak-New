using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000043 RID: 67
	public class AttackNpcMessage : PiranhaMessage
	{
		// Token: 0x0600031C RID: 796 RVA: 0x00003E3C File Offset: 0x0000203C
		public AttackNpcMessage() : this(0)
		{
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0000328C File Offset: 0x0000148C
		public AttackNpcMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00003E45 File Offset: 0x00002045
		public override void Decode()
		{
			base.Decode();
			this.logicNpcData_0 = (LogicNpcData)ByteStreamHelper.ReadDataReference(this.m_stream, LogicDataType.NPC);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00003E65 File Offset: 0x00002065
		public override void Encode()
		{
			base.Encode();
			ByteStreamHelper.WriteDataReference(this.m_stream, this.logicNpcData_0);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00003E7E File Offset: 0x0000207E
		public override short GetMessageType()
		{
			return 14134;
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00003E85 File Offset: 0x00002085
		public override void Destruct()
		{
			base.Destruct();
			this.logicNpcData_0 = null;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00003E94 File Offset: 0x00002094
		public LogicNpcData GetNpcData()
		{
			return this.logicNpcData_0;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00003E9C File Offset: 0x0000209C
		public void SetNpcData(LogicNpcData data)
		{
			this.logicNpcData_0 = data;
		}

		// Token: 0x0400013C RID: 316
		public const int MESSAGE_TYPE = 14134;

		// Token: 0x0400013D RID: 317
		private LogicNpcData logicNpcData_0;
	}
}
