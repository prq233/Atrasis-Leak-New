using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x0200009D RID: 157
	public class ClusterPerformanceDataMessage : ServerCoreMessage
	{
		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x0000720A File Offset: 0x0000540A
		// (set) Token: 0x06000453 RID: 1107 RVA: 0x00007212 File Offset: 0x00005412
		public int Id { get; set; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000454 RID: 1108 RVA: 0x0000721B File Offset: 0x0000541B
		// (set) Token: 0x06000455 RID: 1109 RVA: 0x00007223 File Offset: 0x00005423
		public int SessionCount { get; set; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x0000722C File Offset: 0x0000542C
		// (set) Token: 0x06000457 RID: 1111 RVA: 0x00007234 File Offset: 0x00005434
		public int Ping { get; set; }

		// Token: 0x06000458 RID: 1112 RVA: 0x0000723D File Offset: 0x0000543D
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Id);
			stream.WriteVInt(this.SessionCount);
			stream.WriteVInt(this.Ping);
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00007263 File Offset: 0x00005463
		public override void Decode(ByteStream stream)
		{
			this.Id = stream.ReadVInt();
			this.SessionCount = stream.ReadVInt();
			this.Ping = stream.ReadVInt();
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00007289 File Offset: 0x00005489
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CLUSTER_PERFORMANCE_DATA;
		}

		// Token: 0x040001EB RID: 491
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040001EC RID: 492
		[CompilerGenerated]
		private int int_3;

		// Token: 0x040001ED RID: 493
		[CompilerGenerated]
		private int int_4;
	}
}
