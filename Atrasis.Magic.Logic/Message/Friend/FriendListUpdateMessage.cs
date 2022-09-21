using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x0200006F RID: 111
	public class FriendListUpdateMessage : PiranhaMessage
	{
		// Token: 0x060004EC RID: 1260 RVA: 0x00004E43 File Offset: 0x00003043
		public FriendListUpdateMessage() : this(0)
		{
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0000328C File Offset: 0x0000148C
		public FriendListUpdateMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00004E4C File Offset: 0x0000304C
		public override void Decode()
		{
			base.Decode();
			this.friendEntry_0 = new FriendEntry();
			this.friendEntry_0.Decode(this.m_stream);
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x00004E70 File Offset: 0x00003070
		public override void Encode()
		{
			base.Encode();
			this.friendEntry_0.Encode(this.m_stream);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x00004E89 File Offset: 0x00003089
		public override short GetMessageType()
		{
			return 20106;
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x00002C4D File Offset: 0x00000E4D
		public override int GetServiceNodeType()
		{
			return 3;
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x00004E90 File Offset: 0x00003090
		public override void Destruct()
		{
			base.Destruct();
			this.friendEntry_0 = null;
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00004E9F File Offset: 0x0000309F
		public FriendEntry RemoveFriendEntry()
		{
			FriendEntry result = this.friendEntry_0;
			this.friendEntry_0 = null;
			return result;
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00004EAE File Offset: 0x000030AE
		public void SetFriendEntry(FriendEntry entry)
		{
			this.friendEntry_0 = entry;
		}

		// Token: 0x040001E0 RID: 480
		public const int MESSAGE_TYPE = 20106;

		// Token: 0x040001E1 RID: 481
		private FriendEntry friendEntry_0;
	}
}
