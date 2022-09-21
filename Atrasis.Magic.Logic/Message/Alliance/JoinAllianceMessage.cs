using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000C2 RID: 194
	public class JoinAllianceMessage : PiranhaMessage
	{
		// Token: 0x0600086D RID: 2157 RVA: 0x00006D01 File Offset: 0x00004F01
		public JoinAllianceMessage() : this(0)
		{
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x0000328C File Offset: 0x0000148C
		public JoinAllianceMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00006D0A File Offset: 0x00004F0A
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x00006D23 File Offset: 0x00004F23
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x00006D3C File Offset: 0x00004F3C
		public override short GetMessageType()
		{
			return 14305;
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00006D43 File Offset: 0x00004F43
		public LogicLong RemoveAllianceId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00006D52 File Offset: 0x00004F52
		public void SetAllianceId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x0400033E RID: 830
		public const int MESSAGE_TYPE = 14305;

		// Token: 0x0400033F RID: 831
		private LogicLong logicLong_0;
	}
}
