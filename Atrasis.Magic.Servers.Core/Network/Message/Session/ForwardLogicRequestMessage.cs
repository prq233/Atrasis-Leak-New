using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000034 RID: 52
	public class ForwardLogicRequestMessage : ServerSessionMessage
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600012C RID: 300 RVA: 0x0000515B File Offset: 0x0000335B
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00005163 File Offset: 0x00003363
		public LogicLong AccountId { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600012E RID: 302 RVA: 0x0000516C File Offset: 0x0000336C
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00005174 File Offset: 0x00003374
		public short MessageType { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000130 RID: 304 RVA: 0x0000517D File Offset: 0x0000337D
		// (set) Token: 0x06000131 RID: 305 RVA: 0x00005185 File Offset: 0x00003385
		public short MessageVersion { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000132 RID: 306 RVA: 0x0000518E File Offset: 0x0000338E
		// (set) Token: 0x06000133 RID: 307 RVA: 0x00005196 File Offset: 0x00003396
		public int MessageLength { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000134 RID: 308 RVA: 0x0000519F File Offset: 0x0000339F
		// (set) Token: 0x06000135 RID: 309 RVA: 0x000051A7 File Offset: 0x000033A7
		public byte[] MessageBytes { get; set; }

		// Token: 0x06000136 RID: 310 RVA: 0x0000BD98 File Offset: 0x00009F98
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
			stream.WriteShort(this.MessageType);
			stream.WriteShort(this.MessageVersion);
			stream.WriteVInt(this.MessageLength);
			stream.WriteBytesWithoutLength(this.MessageBytes, this.MessageLength);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000BDE8 File Offset: 0x00009FE8
		public override void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
			this.MessageType = stream.ReadShort();
			this.MessageVersion = stream.ReadShort();
			this.MessageLength = stream.ReadVInt();
			this.MessageBytes = stream.ReadBytes(this.MessageLength, 16777215);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000051B0 File Offset: 0x000033B0
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.FORWARD_LOGIC_REQUEST_MESSAGE;
		}

		// Token: 0x040000E3 RID: 227
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040000E4 RID: 228
		[CompilerGenerated]
		private short short_0;

		// Token: 0x040000E5 RID: 229
		[CompilerGenerated]
		private short short_1;

		// Token: 0x040000E6 RID: 230
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040000E7 RID: 231
		[CompilerGenerated]
		private byte[] byte_0;
	}
}
