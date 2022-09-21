using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000079 RID: 121
	public class CreateAllianceResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600037A RID: 890 RVA: 0x000068DC File Offset: 0x00004ADC
		// (set) Token: 0x0600037B RID: 891 RVA: 0x000068E4 File Offset: 0x00004AE4
		public LogicLong AllianceId { get; set; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600037C RID: 892 RVA: 0x000068ED File Offset: 0x00004AED
		// (set) Token: 0x0600037D RID: 893 RVA: 0x000068F5 File Offset: 0x00004AF5
		public CreateAllianceResponseMessage.Reason ErrorReason { get; set; }

		// Token: 0x0600037E RID: 894 RVA: 0x000068FE File Offset: 0x00004AFE
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteLong(this.AllianceId);
				return;
			}
			stream.WriteVInt((int)this.ErrorReason);
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00006921 File Offset: 0x00004B21
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.AllianceId = stream.ReadLong();
				return;
			}
			this.ErrorReason = (CreateAllianceResponseMessage.Reason)stream.ReadVInt();
		}

		// Token: 0x06000380 RID: 896 RVA: 0x00006944 File Offset: 0x00004B44
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_ALLIANCE_RESPONSE;
		}

		// Token: 0x04000199 RID: 409
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x0400019A RID: 410
		[CompilerGenerated]
		private CreateAllianceResponseMessage.Reason reason_0;

		// Token: 0x0200007A RID: 122
		public enum Reason
		{
			// Token: 0x0400019C RID: 412
			GENERIC,
			// Token: 0x0400019D RID: 413
			INVALID_NAME,
			// Token: 0x0400019E RID: 414
			INVALID_DESCRIPTION,
			// Token: 0x0400019F RID: 415
			NAME_TOO_SHORT,
			// Token: 0x040001A0 RID: 416
			NAME_TOO_LONG
		}
	}
}
