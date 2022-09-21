using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x0200009E RID: 158
	public class EventLogMessage : ServerCoreMessage
	{
		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600045C RID: 1116 RVA: 0x00007290 File Offset: 0x00005490
		// (set) Token: 0x0600045D RID: 1117 RVA: 0x00007298 File Offset: 0x00005498
		public string Type { get; set; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600045E RID: 1118 RVA: 0x000072A1 File Offset: 0x000054A1
		// (set) Token: 0x0600045F RID: 1119 RVA: 0x000072A9 File Offset: 0x000054A9
		public string Message { get; set; }

		// Token: 0x06000460 RID: 1120 RVA: 0x000072B2 File Offset: 0x000054B2
		public override void Encode(ByteStream stream)
		{
			stream.WriteString(this.Type);
			stream.WriteString(this.Message);
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x000072CC File Offset: 0x000054CC
		public override void Decode(ByteStream stream)
		{
			this.Type = stream.ReadString(900000);
			this.Message = stream.ReadString(900000);
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x000072F0 File Offset: 0x000054F0
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.EVENT_LOG;
		}

		// Token: 0x040001EE RID: 494
		[CompilerGenerated]
		private string string_0;

		// Token: 0x040001EF RID: 495
		[CompilerGenerated]
		private string string_1;
	}
}
