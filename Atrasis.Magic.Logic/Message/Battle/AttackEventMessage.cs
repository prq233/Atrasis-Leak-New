using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Battle
{
	// Token: 0x0200007A RID: 122
	public class AttackEventMessage : PiranhaMessage
	{
		// Token: 0x0600054C RID: 1356 RVA: 0x0000519A File Offset: 0x0000339A
		public AttackEventMessage() : this(0)
		{
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0000328C File Offset: 0x0000148C
		public AttackEventMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x000051A3 File Offset: 0x000033A3
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x000051CD File Offset: 0x000033CD
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x000051F7 File Offset: 0x000033F7
		public override short GetMessageType()
		{
			return 25027;
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x000051FE File Offset: 0x000033FE
		public int GetEventType()
		{
			return this.int_0;
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x00005206 File Offset: 0x00003406
		public void SetEventType(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0000520F File Offset: 0x0000340F
		public int GetEventArg()
		{
			return this.int_1;
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x00005217 File Offset: 0x00003417
		public void SetEventArg(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x04000200 RID: 512
		public const int MESSAGE_TYPE = 25027;

		// Token: 0x04000201 RID: 513
		private int int_0;

		// Token: 0x04000202 RID: 514
		private int int_1;
	}
}
