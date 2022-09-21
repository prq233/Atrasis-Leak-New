using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x020000A5 RID: 165
	public class ServerLogMessage : ServerCoreMessage
	{
		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x000073EA File Offset: 0x000055EA
		// (set) Token: 0x06000483 RID: 1155 RVA: 0x000073F2 File Offset: 0x000055F2
		public int LogType { get; set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x000073FB File Offset: 0x000055FB
		// (set) Token: 0x06000485 RID: 1157 RVA: 0x00007403 File Offset: 0x00005603
		public string Message { get; set; }

		// Token: 0x06000486 RID: 1158 RVA: 0x0000740C File Offset: 0x0000560C
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.LogType);
			stream.WriteString(this.Message);
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00007426 File Offset: 0x00005626
		public override void Decode(ByteStream stream)
		{
			this.LogType = stream.ReadVInt();
			this.Message = stream.ReadString(900000);
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00007445 File Offset: 0x00005645
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SERVER_LOG;
		}

		// Token: 0x040001F4 RID: 500
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040001F5 RID: 501
		[CompilerGenerated]
		private string string_0;
	}
}
