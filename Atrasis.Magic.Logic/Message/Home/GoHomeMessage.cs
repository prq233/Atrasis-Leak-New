using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x0200004D RID: 77
	public class GoHomeMessage : PiranhaMessage
	{
		// Token: 0x0600038D RID: 909 RVA: 0x00004243 File Offset: 0x00002443
		public GoHomeMessage() : this(0)
		{
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0000328C File Offset: 0x0000148C
		public GoHomeMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0001C36C File Offset: 0x0001A56C
		public override void Decode()
		{
			int num = this.m_stream.ReadInt();
			int num2 = this.m_stream.ReadInt();
			this.int_0 = ((int)((long)num & 4294901760L) | num2 >> 16);
			this.short_0 = (short)(num & 65535);
			this.short_1 = (short)(num2 & 65535);
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0001C3C8 File Offset: 0x0001A5C8
		public override void Encode()
		{
			int value = (int)((long)this.int_0 & 4294901760L) | ((int)this.short_0 & 65535);
			int value2 = (this.int_0 & 65535) << 16 | ((int)this.short_1 & 65535);
			this.m_stream.WriteInt(value);
			this.m_stream.WriteInt(value2);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0000424C File Offset: 0x0000244C
		public int GetMapId()
		{
			return (int)this.short_0;
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00004254 File Offset: 0x00002454
		public int GetLayoutId()
		{
			return (int)this.short_1;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0000425C File Offset: 0x0000245C
		public int GetState3()
		{
			return this.int_0;
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00004264 File Offset: 0x00002464
		public override short GetMessageType()
		{
			return 14101;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000396 RID: 918 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x04000162 RID: 354
		public const int MESSAGE_TYPE = 14101;

		// Token: 0x04000163 RID: 355
		private short short_0;

		// Token: 0x04000164 RID: 356
		private short short_1;

		// Token: 0x04000165 RID: 357
		private int int_0;

		// Token: 0x04000166 RID: 358
		private bool bool_0;
	}
}
