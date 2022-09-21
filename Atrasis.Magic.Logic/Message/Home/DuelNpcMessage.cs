using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000049 RID: 73
	public class DuelNpcMessage : PiranhaMessage
	{
		// Token: 0x06000349 RID: 841 RVA: 0x00003FFB File Offset: 0x000021FB
		public DuelNpcMessage() : this(0)
		{
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000328C File Offset: 0x0000148C
		public DuelNpcMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00004004 File Offset: 0x00002204
		public override void Decode()
		{
			base.Decode();
			this.logicNpcData_0 = (LogicNpcData)ByteStreamHelper.ReadDataReference(this.m_stream, LogicDataType.NPC);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00004024 File Offset: 0x00002224
		public override void Encode()
		{
			base.Encode();
			ByteStreamHelper.WriteDataReference(this.m_stream, this.logicNpcData_0);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000403D File Offset: 0x0000223D
		public override short GetMessageType()
		{
			return 14135;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00004044 File Offset: 0x00002244
		public override void Destruct()
		{
			base.Destruct();
			this.logicNpcData_0 = null;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00004053 File Offset: 0x00002253
		public LogicNpcData GetNpcData()
		{
			return this.logicNpcData_0;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000405B File Offset: 0x0000225B
		public void SetNpcData(LogicNpcData data)
		{
			this.logicNpcData_0 = data;
		}

		// Token: 0x0400014A RID: 330
		public const int MESSAGE_TYPE = 14135;

		// Token: 0x0400014B RID: 331
		private LogicNpcData logicNpcData_0;
	}
}
