using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000045 RID: 69
	public class StopServerSessionMessage : ServerSessionMessage
	{
		// Token: 0x060001A7 RID: 423 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000055A9 File Offset: 0x000037A9
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.STOP_SERVER_SESSION;
		}
	}
}
