using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Facebook
{
	// Token: 0x02000073 RID: 115
	public class FacebookAccountBoundMessage : PiranhaMessage
	{
		// Token: 0x0600050C RID: 1292 RVA: 0x00004F68 File Offset: 0x00003168
		public FacebookAccountBoundMessage() : this(0)
		{
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0000328C File Offset: 0x0000148C
		public FacebookAccountBoundMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x00004F71 File Offset: 0x00003171
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00004F8A File Offset: 0x0000318A
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00004FA3 File Offset: 0x000031A3
		public override short GetMessageType()
		{
			return 24201;
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x00004FAA File Offset: 0x000031AA
		public int GetResultCode()
		{
			return this.int_0;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00004FB2 File Offset: 0x000031B2
		public void SetResultCode(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040001E8 RID: 488
		public const int MESSAGE_TYPE = 24201;

		// Token: 0x040001E9 RID: 489
		private int int_0;
	}
}
