using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x020000A8 RID: 168
	public class ServerStatusMessage : ServerCoreMessage
	{
		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000496 RID: 1174 RVA: 0x000074B0 File Offset: 0x000056B0
		// (set) Token: 0x06000497 RID: 1175 RVA: 0x000074B8 File Offset: 0x000056B8
		public ServerStatusType Type { get; set; }

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x000074C1 File Offset: 0x000056C1
		// (set) Token: 0x06000499 RID: 1177 RVA: 0x000074C9 File Offset: 0x000056C9
		public int Time { get; set; }

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x000074D2 File Offset: 0x000056D2
		// (set) Token: 0x0600049B RID: 1179 RVA: 0x000074DA File Offset: 0x000056DA
		public int NextTime { get; set; }

		// Token: 0x0600049C RID: 1180 RVA: 0x000074E3 File Offset: 0x000056E3
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt((int)this.Type);
			stream.WriteVInt(this.Time);
			stream.WriteVInt(this.NextTime);
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00007509 File Offset: 0x00005709
		public override void Decode(ByteStream stream)
		{
			this.Type = (ServerStatusType)stream.ReadVInt();
			this.Time = stream.ReadVInt();
			this.NextTime = stream.ReadVInt();
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0000752F File Offset: 0x0000572F
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SERVER_STATUS;
		}

		// Token: 0x040001F8 RID: 504
		[CompilerGenerated]
		private ServerStatusType serverStatusType_0;

		// Token: 0x040001F9 RID: 505
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040001FA RID: 506
		[CompilerGenerated]
		private int int_3;
	}
}
