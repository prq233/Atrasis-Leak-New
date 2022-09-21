using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000075 RID: 117
	public class AvatarResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000348 RID: 840 RVA: 0x00006724 File Offset: 0x00004924
		// (set) Token: 0x06000349 RID: 841 RVA: 0x0000672C File Offset: 0x0000492C
		public LogicClientAvatar LogicClientAvatar { get; set; }

		// Token: 0x0600034A RID: 842 RVA: 0x00006735 File Offset: 0x00004935
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				this.LogicClientAvatar.Encode(stream);
			}
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000674B File Offset: 0x0000494B
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.LogicClientAvatar = new LogicClientAvatar();
				this.LogicClientAvatar.Decode(stream);
			}
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000676C File Offset: 0x0000496C
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.AVATAR_RESPONSE;
		}

		// Token: 0x04000188 RID: 392
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_0;
	}
}
