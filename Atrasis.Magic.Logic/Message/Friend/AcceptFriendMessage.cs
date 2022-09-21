using System;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x02000067 RID: 103
	public class AcceptFriendMessage : FriendAvatarBaseMessage
	{
		// Token: 0x06000497 RID: 1175 RVA: 0x00004B86 File Offset: 0x00002D86
		public AcceptFriendMessage() : this(0)
		{
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x00004B8F File Offset: 0x00002D8F
		public AcceptFriendMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00004B98 File Offset: 0x00002D98
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x00004BA0 File Offset: 0x00002DA0
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00004BA8 File Offset: 0x00002DA8
		public override short GetMessageType()
		{
			return 10501;
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00004BAF File Offset: 0x00002DAF
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x040001BD RID: 445
		public const int MESSAGE_TYPE = 10501;
	}
}
