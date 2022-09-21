using System;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x02000070 RID: 112
	public class RemoveFriendMessage : FriendAvatarBaseMessage
	{
		// Token: 0x060004F5 RID: 1269 RVA: 0x00004EB7 File Offset: 0x000030B7
		public RemoveFriendMessage() : this(0)
		{
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00004B8F File Offset: 0x00002D8F
		public RemoveFriendMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00004B98 File Offset: 0x00002D98
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00004BA0 File Offset: 0x00002DA0
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00004EC0 File Offset: 0x000030C0
		public override short GetMessageType()
		{
			return 10506;
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00004BAF File Offset: 0x00002DAF
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x040001E2 RID: 482
		public const int MESSAGE_TYPE = 10506;
	}
}
