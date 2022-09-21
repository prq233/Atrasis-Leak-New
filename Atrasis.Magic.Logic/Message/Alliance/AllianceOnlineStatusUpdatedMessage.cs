using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000B9 RID: 185
	public class AllianceOnlineStatusUpdatedMessage : PiranhaMessage
	{
		// Token: 0x060007FA RID: 2042 RVA: 0x00006932 File Offset: 0x00004B32
		public AllianceOnlineStatusUpdatedMessage() : this(0)
		{
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceOnlineStatusUpdatedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0000693B File Offset: 0x00004B3B
		public override void Decode()
		{
			base.Decode();
			this.int_1 = this.m_stream.ReadVInt();
			this.int_0 = this.m_stream.ReadVInt();
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x00006965 File Offset: 0x00004B65
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteVInt(this.int_1);
			this.m_stream.WriteVInt(this.int_0);
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0000698F File Offset: 0x00004B8F
		public override short GetMessageType()
		{
			return 20207;
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x00003F09 File Offset: 0x00002109
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00006996 File Offset: 0x00004B96
		public int GetMembersOnline()
		{
			return this.int_1;
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x0000699E File Offset: 0x00004B9E
		public void SetMembersOnline(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x000069A7 File Offset: 0x00004BA7
		public int GetMembersCount()
		{
			return this.int_0;
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x000069AF File Offset: 0x00004BAF
		public void SetMembersCount(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000318 RID: 792
		public const int MESSAGE_TYPE = 20207;

		// Token: 0x04000319 RID: 793
		private int int_0;

		// Token: 0x0400031A RID: 794
		private int int_1;
	}
}
