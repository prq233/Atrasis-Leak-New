using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000033 RID: 51
	public class ForwardLogicMessage : ServerSessionMessage
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000120 RID: 288 RVA: 0x0000509B File Offset: 0x0000329B
		// (set) Token: 0x06000121 RID: 289 RVA: 0x000050A3 File Offset: 0x000032A3
		public short MessageType { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000122 RID: 290 RVA: 0x000050AC File Offset: 0x000032AC
		// (set) Token: 0x06000123 RID: 291 RVA: 0x000050B4 File Offset: 0x000032B4
		public short MessageVersion { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000124 RID: 292 RVA: 0x000050BD File Offset: 0x000032BD
		// (set) Token: 0x06000125 RID: 293 RVA: 0x000050C5 File Offset: 0x000032C5
		public int MessageLength { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000126 RID: 294 RVA: 0x000050CE File Offset: 0x000032CE
		// (set) Token: 0x06000127 RID: 295 RVA: 0x000050D6 File Offset: 0x000032D6
		public byte[] MessageBytes { get; set; }

		// Token: 0x06000128 RID: 296 RVA: 0x000050DF File Offset: 0x000032DF
		public override void Encode(ByteStream stream)
		{
			stream.WriteShort(this.MessageType);
			stream.WriteShort(this.MessageVersion);
			stream.WriteVInt(this.MessageLength);
			stream.WriteBytesWithoutLength(this.MessageBytes, this.MessageLength);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00005117 File Offset: 0x00003317
		public override void Decode(ByteStream stream)
		{
			this.MessageType = stream.ReadShort();
			this.MessageVersion = stream.ReadShort();
			this.MessageLength = stream.ReadVInt();
			this.MessageBytes = stream.ReadBytes(this.MessageLength, 16777215);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00005154 File Offset: 0x00003354
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.FORWARD_LOGIC_MESSAGE;
		}

		// Token: 0x040000DF RID: 223
		[CompilerGenerated]
		private short short_0;

		// Token: 0x040000E0 RID: 224
		[CompilerGenerated]
		private short short_1;

		// Token: 0x040000E1 RID: 225
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040000E2 RID: 226
		[CompilerGenerated]
		private byte[] byte_0;
	}
}
