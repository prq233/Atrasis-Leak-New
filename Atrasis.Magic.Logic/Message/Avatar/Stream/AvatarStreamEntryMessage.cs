using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar.Stream
{
	// Token: 0x02000097 RID: 151
	public class AvatarStreamEntryMessage : PiranhaMessage
	{
		// Token: 0x06000672 RID: 1650 RVA: 0x00005BB5 File Offset: 0x00003DB5
		public AvatarStreamEntryMessage() : this(0)
		{
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0000328C File Offset: 0x0000148C
		public AvatarStreamEntryMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x00005BBE File Offset: 0x00003DBE
		public override void Decode()
		{
			base.Decode();
			this.avatarStreamEntry_0 = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)this.m_stream.ReadInt());
			this.avatarStreamEntry_0.Decode(this.m_stream);
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x00005BED File Offset: 0x00003DED
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.avatarStreamEntry_0.GetAvatarStreamEntryType());
			this.avatarStreamEntry_0.Encode(this.m_stream);
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x00005C1C File Offset: 0x00003E1C
		public override short GetMessageType()
		{
			return 24412;
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x00005C23 File Offset: 0x00003E23
		public override void Destruct()
		{
			base.Destruct();
			this.avatarStreamEntry_0 = null;
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x00005C32 File Offset: 0x00003E32
		public AvatarStreamEntry RemoveAvatarStreamEntry()
		{
			AvatarStreamEntry result = this.avatarStreamEntry_0;
			this.avatarStreamEntry_0 = null;
			return result;
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x00005C41 File Offset: 0x00003E41
		public void SetAvatarStreamEntry(AvatarStreamEntry entry)
		{
			this.avatarStreamEntry_0 = entry;
		}

		// Token: 0x0400026E RID: 622
		public const int MESSAGE_TYPE = 24412;

		// Token: 0x0400026F RID: 623
		private AvatarStreamEntry avatarStreamEntry_0;
	}
}
