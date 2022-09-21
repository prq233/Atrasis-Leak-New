using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x0200008B RID: 139
	public class AvatarProfileMessage : PiranhaMessage
	{
		// Token: 0x060005E7 RID: 1511 RVA: 0x0000572A File Offset: 0x0000392A
		public AvatarProfileMessage() : this(0)
		{
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x0000328C File Offset: 0x0000148C
		public AvatarProfileMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x00005733 File Offset: 0x00003933
		public override void Decode()
		{
			base.Decode();
			this.avatarProfileFullEntry_0 = new AvatarProfileFullEntry();
			this.avatarProfileFullEntry_0.Decode(this.m_stream);
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x00005757 File Offset: 0x00003957
		public override void Encode()
		{
			base.Encode();
			this.avatarProfileFullEntry_0.Encode(this.m_stream);
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00005770 File Offset: 0x00003970
		public override short GetMessageType()
		{
			return 24334;
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x00005777 File Offset: 0x00003977
		public override void Destruct()
		{
			base.Destruct();
			if (this.avatarProfileFullEntry_0 != null)
			{
				this.avatarProfileFullEntry_0.Destruct();
				this.avatarProfileFullEntry_0 = null;
			}
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x00005799 File Offset: 0x00003999
		public AvatarProfileFullEntry RemoveAvatarProfileFullEntry()
		{
			AvatarProfileFullEntry result = this.avatarProfileFullEntry_0;
			this.avatarProfileFullEntry_0 = null;
			return result;
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x000057A8 File Offset: 0x000039A8
		public void SetAvatarProfileFullEntry(AvatarProfileFullEntry entry)
		{
			this.avatarProfileFullEntry_0 = entry;
		}

		// Token: 0x0400023B RID: 571
		public const int MESSAGE_TYPE = 24334;

		// Token: 0x0400023C RID: 572
		private AvatarProfileFullEntry avatarProfileFullEntry_0;
	}
}
