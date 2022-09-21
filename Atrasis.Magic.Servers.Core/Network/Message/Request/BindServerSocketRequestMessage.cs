using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000076 RID: 118
	public class BindServerSocketRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x0600034E RID: 846 RVA: 0x00006773 File Offset: 0x00004973
		// (set) Token: 0x0600034F RID: 847 RVA: 0x0000677B File Offset: 0x0000497B
		public long SessionId { get; set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000350 RID: 848 RVA: 0x00006784 File Offset: 0x00004984
		// (set) Token: 0x06000351 RID: 849 RVA: 0x0000678C File Offset: 0x0000498C
		public int ServerType { get; set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000352 RID: 850 RVA: 0x00006795 File Offset: 0x00004995
		// (set) Token: 0x06000353 RID: 851 RVA: 0x0000679D File Offset: 0x0000499D
		public int ServerId { get; set; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000354 RID: 852 RVA: 0x000067A6 File Offset: 0x000049A6
		// (set) Token: 0x06000355 RID: 853 RVA: 0x000067AE File Offset: 0x000049AE
		public ServerSessionMessage InitSessionMessage { get; set; }

		// Token: 0x06000356 RID: 854 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void Encode(ByteStream stream)
		{
			stream.WriteLongLong(this.SessionId);
			stream.WriteVInt(this.ServerType);
			stream.WriteVInt(this.ServerId);
			stream.WriteBoolean(this.InitSessionMessage != null);
			if (this.InitSessionMessage != null)
			{
				stream.WriteBoolean(true);
				stream.WriteShort((short)this.InitSessionMessage.GetMessageType());
				this.InitSessionMessage.EncodeHeader(stream);
				this.InitSessionMessage.Encode(stream);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000C9FC File Offset: 0x0000ABFC
		public override void Decode(ByteStream stream)
		{
			this.SessionId = stream.ReadLongLong();
			this.ServerType = stream.ReadVInt();
			this.ServerId = stream.ReadVInt();
			if (stream.ReadBoolean())
			{
				this.InitSessionMessage = (ServerSessionMessage)ServerMessageFactory.CreateMessageByType((ServerMessageType)stream.ReadShort());
				this.InitSessionMessage.DecodeHeader(stream);
				this.InitSessionMessage.Decode(stream);
			}
		}

		// Token: 0x06000358 RID: 856 RVA: 0x000067B7 File Offset: 0x000049B7
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.BIND_SERVER_SOCKET_REQUEST;
		}

		// Token: 0x04000189 RID: 393
		[CompilerGenerated]
		private long long_1;

		// Token: 0x0400018A RID: 394
		[CompilerGenerated]
		private int int_2;

		// Token: 0x0400018B RID: 395
		[CompilerGenerated]
		private int int_3;

		// Token: 0x0400018C RID: 396
		[CompilerGenerated]
		private ServerSessionMessage serverSessionMessage_0;
	}
}
