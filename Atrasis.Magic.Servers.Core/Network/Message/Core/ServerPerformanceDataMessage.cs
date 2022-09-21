using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x020000A6 RID: 166
	public class ServerPerformanceDataMessage : ServerCoreMessage
	{
		// Token: 0x1700010F RID: 271
		// (get) Token: 0x0600048A RID: 1162 RVA: 0x0000744C File Offset: 0x0000564C
		// (set) Token: 0x0600048B RID: 1163 RVA: 0x00007454 File Offset: 0x00005654
		public int SessionCount { get; set; }

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x0000745D File Offset: 0x0000565D
		// (set) Token: 0x0600048D RID: 1165 RVA: 0x00007465 File Offset: 0x00005665
		public int ClusterCount { get; set; }

		// Token: 0x0600048E RID: 1166 RVA: 0x0000746E File Offset: 0x0000566E
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.SessionCount);
			stream.WriteVInt(this.ClusterCount);
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00007488 File Offset: 0x00005688
		public override void Decode(ByteStream stream)
		{
			this.SessionCount = stream.ReadVInt();
			this.ClusterCount = stream.ReadVInt();
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x000074A2 File Offset: 0x000056A2
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SERVER_PERFORMANCE_DATA;
		}

		// Token: 0x040001F6 RID: 502
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040001F7 RID: 503
		[CompilerGenerated]
		private int int_3;
	}
}
