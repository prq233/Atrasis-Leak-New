using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000042 RID: 66
	public class StartServerSessionFailedMessage : ServerSessionMessage
	{
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000192 RID: 402 RVA: 0x00005535 File Offset: 0x00003735
		// (set) Token: 0x06000193 RID: 403 RVA: 0x0000553D File Offset: 0x0000373D
		public new long SessionId
		{
			get
			{
				return base.SessionId;
			}
			set
			{
				base.SessionId = value;
			}
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00005546 File Offset: 0x00003746
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.START_SERVER_SESSION_FAILED;
		}
	}
}
