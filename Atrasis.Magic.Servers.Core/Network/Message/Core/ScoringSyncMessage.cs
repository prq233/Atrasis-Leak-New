using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Database.Document;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x020000A2 RID: 162
	public class ScoringSyncMessage : ServerCoreMessage
	{
		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x00007367 File Offset: 0x00005567
		// (set) Token: 0x06000475 RID: 1141 RVA: 0x0000736F File Offset: 0x0000556F
		public SeasonDocument CurrentSeasonDocument { get; set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x00007378 File Offset: 0x00005578
		// (set) Token: 0x06000477 RID: 1143 RVA: 0x00007380 File Offset: 0x00005580
		public SeasonDocument LastSeasonDocument { get; set; }

		// Token: 0x06000478 RID: 1144 RVA: 0x00007389 File Offset: 0x00005589
		public override void Encode(ByteStream stream)
		{
			CouchbaseDocument.Encode(stream, this.CurrentSeasonDocument);
			if (this.LastSeasonDocument != null)
			{
				stream.WriteBoolean(true);
				CouchbaseDocument.Encode(stream, this.LastSeasonDocument);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x000073BA File Offset: 0x000055BA
		public override void Decode(ByteStream stream)
		{
			this.CurrentSeasonDocument = CouchbaseDocument.Decode<SeasonDocument>(stream);
			if (stream.ReadBoolean())
			{
				this.LastSeasonDocument = CouchbaseDocument.Decode<SeasonDocument>(stream);
			}
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x000073DC File Offset: 0x000055DC
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SCORING_SYNC;
		}

		// Token: 0x040001F2 RID: 498
		[CompilerGenerated]
		private SeasonDocument seasonDocument_0;

		// Token: 0x040001F3 RID: 499
		[CompilerGenerated]
		private SeasonDocument seasonDocument_1;
	}
}
