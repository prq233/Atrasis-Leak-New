using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message
{
	// Token: 0x0200002A RID: 42
	public abstract class ServerMessage
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x00004F3D File Offset: 0x0000313D
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x00004F45 File Offset: 0x00003145
		public int SenderType { get; internal set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00004F4E File Offset: 0x0000314E
		// (set) Token: 0x060000FA RID: 250 RVA: 0x00004F56 File Offset: 0x00003156
		public int SenderId { get; internal set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000FB RID: 251 RVA: 0x00004F5F File Offset: 0x0000315F
		public ServerSocket Sender
		{
			get
			{
				return ServerManager.GetSocket(this.SenderType, this.SenderId);
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00004F72 File Offset: 0x00003172
		public virtual void EncodeHeader(ByteStream stream)
		{
			stream.WriteVInt(this.SenderType);
			stream.WriteVInt(this.SenderId);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00004F8C File Offset: 0x0000318C
		public virtual void DecodeHeader(ByteStream stream)
		{
			this.SenderType = stream.ReadVInt();
			this.SenderId = stream.ReadVInt();
		}

		// Token: 0x060000FE RID: 254
		public abstract void Encode(ByteStream stream);

		// Token: 0x060000FF RID: 255
		public abstract void Decode(ByteStream stream);

		// Token: 0x06000100 RID: 256
		public abstract ServerMessageCategory GetMessageCategory();

		// Token: 0x06000101 RID: 257
		public abstract ServerMessageType GetMessageType();

		// Token: 0x04000065 RID: 101
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04000066 RID: 102
		[CompilerGenerated]
		private int int_1;
	}
}
