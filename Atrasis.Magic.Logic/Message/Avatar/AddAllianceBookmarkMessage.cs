using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x0200007D RID: 125
	public class AddAllianceBookmarkMessage : PiranhaMessage
	{
		// Token: 0x06000573 RID: 1395 RVA: 0x000052CA File Offset: 0x000034CA
		public AddAllianceBookmarkMessage() : this(0)
		{
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0000328C File Offset: 0x0000148C
		public AddAllianceBookmarkMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x000052D3 File Offset: 0x000034D3
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x000052EC File Offset: 0x000034EC
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x00005305 File Offset: 0x00003505
		public override short GetMessageType()
		{
			return 14343;
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0000530C File Offset: 0x0000350C
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0000531B File Offset: 0x0000351B
		public LogicLong GetAllianceId()
		{
			return this.logicLong_0;
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x00005323 File Offset: 0x00003523
		public void SetAllianceId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x0400020C RID: 524
		public const int MESSAGE_TYPE = 14343;

		// Token: 0x0400020D RID: 525
		private LogicLong logicLong_0;
	}
}
