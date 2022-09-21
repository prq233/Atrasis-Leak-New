using System;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x02000071 RID: 113
	public class StartFriendLiveSpectateMessage : FriendAvatarBaseMessage
	{
		// Token: 0x060004FB RID: 1275 RVA: 0x00004EC7 File Offset: 0x000030C7
		public StartFriendLiveSpectateMessage() : this(0)
		{
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00004B8F File Offset: 0x00002D8F
		public StartFriendLiveSpectateMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00004B98 File Offset: 0x00002D98
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00004BA0 File Offset: 0x00002DA0
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00004ED0 File Offset: 0x000030D0
		public override short GetMessageType()
		{
			return 10507;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00004BAF File Offset: 0x00002DAF
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x040001E3 RID: 483
		public const int MESSAGE_TYPE = 10507;
	}
}
