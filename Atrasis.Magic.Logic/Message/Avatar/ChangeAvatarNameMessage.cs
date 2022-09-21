using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x0200008D RID: 141
	public class ChangeAvatarNameMessage : PiranhaMessage
	{
		// Token: 0x060005F9 RID: 1529 RVA: 0x000057E1 File Offset: 0x000039E1
		public ChangeAvatarNameMessage() : this(0)
		{
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0000328C File Offset: 0x0000148C
		public ChangeAvatarNameMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x000057EA File Offset: 0x000039EA
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
			this.bool_0 = this.m_stream.ReadBoolean();
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00005819 File Offset: 0x00003A19
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteBoolean(this.bool_0);
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00005843 File Offset: 0x00003A43
		public override short GetMessageType()
		{
			return 10212;
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0000584A File Offset: 0x00003A4A
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x00005859 File Offset: 0x00003A59
		public string RemoveAvatarName()
		{
			string result = this.string_0;
			this.string_0 = null;
			return result;
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x00005868 File Offset: 0x00003A68
		public void SetAvatarName(string name)
		{
			this.string_0 = name;
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00005871 File Offset: 0x00003A71
		public bool GetNameSetByUser()
		{
			return this.bool_0;
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x00005879 File Offset: 0x00003A79
		public void SetNameSetByUser(bool set)
		{
			this.bool_0 = set;
		}

		// Token: 0x0400023F RID: 575
		public const int MESSAGE_TYPE = 10212;

		// Token: 0x04000240 RID: 576
		private string string_0;

		// Token: 0x04000241 RID: 577
		private bool bool_0;
	}
}
