using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network.Message.Request;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000043 RID: 67
	public class StartServerSessionMessage : ServerSessionMessage
	{
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000198 RID: 408 RVA: 0x0000554D File Offset: 0x0000374D
		// (set) Token: 0x06000199 RID: 409 RVA: 0x00005555 File Offset: 0x00003755
		public LogicLong AccountId { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600019A RID: 410 RVA: 0x0000555E File Offset: 0x0000375E
		// (set) Token: 0x0600019B RID: 411 RVA: 0x00005566 File Offset: 0x00003766
		public string Country { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600019C RID: 412 RVA: 0x0000556F File Offset: 0x0000376F
		// (set) Token: 0x0600019D RID: 413 RVA: 0x00005577 File Offset: 0x00003777
		public LogicArrayList<int> ServerSocketTypeList { get; set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00005580 File Offset: 0x00003780
		// (set) Token: 0x0600019F RID: 415 RVA: 0x00005588 File Offset: 0x00003788
		public LogicArrayList<int> ServerSocketIdList { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00005591 File Offset: 0x00003791
		// (set) Token: 0x060001A1 RID: 417 RVA: 0x00005599 File Offset: 0x00003799
		public BindServerSocketRequestMessage BindRequestMessage { get; set; }

		// Token: 0x060001A2 RID: 418 RVA: 0x0000BFC8 File Offset: 0x0000A1C8
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
			stream.WriteString(this.Country);
			stream.WriteVInt(this.ServerSocketTypeList.Size());
			for (int i = 0; i < this.ServerSocketTypeList.Size(); i++)
			{
				stream.WriteVInt(this.ServerSocketTypeList[i]);
				stream.WriteVInt(this.ServerSocketIdList[i]);
			}
			if (this.BindRequestMessage != null)
			{
				stream.WriteBoolean(true);
				this.BindRequestMessage.EncodeHeader(stream);
				this.BindRequestMessage.Encode(stream);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000C068 File Offset: 0x0000A268
		public override void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
			this.Country = stream.ReadString(900000);
			this.ServerSocketTypeList = new LogicArrayList<int>();
			this.ServerSocketIdList = new LogicArrayList<int>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.ServerSocketTypeList.Add(stream.ReadVInt());
				this.ServerSocketIdList.Add(stream.ReadVInt());
			}
			if (stream.ReadBoolean())
			{
				this.BindRequestMessage = new BindServerSocketRequestMessage();
				this.BindRequestMessage.DecodeHeader(stream);
				this.BindRequestMessage.Decode(stream);
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x000055A2 File Offset: 0x000037A2
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.START_SERVER_SESSION;
		}

		// Token: 0x040000FA RID: 250
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040000FB RID: 251
		[CompilerGenerated]
		private string string_0;

		// Token: 0x040000FC RID: 252
		[CompilerGenerated]
		private LogicArrayList<int> logicArrayList_0;

		// Token: 0x040000FD RID: 253
		[CompilerGenerated]
		private LogicArrayList<int> logicArrayList_1;

		// Token: 0x040000FE RID: 254
		[CompilerGenerated]
		private BindServerSocketRequestMessage bindServerSocketRequestMessage_0;
	}
}
