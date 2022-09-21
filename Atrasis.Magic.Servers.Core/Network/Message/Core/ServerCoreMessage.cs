using System;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x020000A4 RID: 164
	public abstract class ServerCoreMessage : ServerMessage
	{
		// Token: 0x06000480 RID: 1152 RVA: 0x00005816 File Offset: 0x00003A16
		public sealed override ServerMessageCategory GetMessageCategory()
		{
			return ServerMessageCategory.CORE;
		}
	}
}
