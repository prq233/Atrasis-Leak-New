using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000D9 RID: 217
	public class AllianceStreamEntryRemovedMessage : PiranhaMessage
	{
		// Token: 0x0600094A RID: 2378 RVA: 0x00007504 File Offset: 0x00005704
		public AllianceStreamEntryRemovedMessage() : this(0)
		{
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceStreamEntryRemovedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x0000750D File Offset: 0x0000570D
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x00007526 File Offset: 0x00005726
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x0000753F File Offset: 0x0000573F
		public override short GetMessageType()
		{
			return 24318;
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x00007546 File Offset: 0x00005746
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x00007555 File Offset: 0x00005755
		public LogicLong GetStreamEntryId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0000755D File Offset: 0x0000575D
		public void SetStreamEntryId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x040003A8 RID: 936
		public const int MESSAGE_TYPE = 24318;

		// Token: 0x040003A9 RID: 937
		private LogicLong logicLong_0;
	}
}
