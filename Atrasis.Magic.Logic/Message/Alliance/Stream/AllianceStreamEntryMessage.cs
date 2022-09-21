using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000D8 RID: 216
	public class AllianceStreamEntryMessage : PiranhaMessage
	{
		// Token: 0x06000941 RID: 2369 RVA: 0x00007476 File Offset: 0x00005676
		public AllianceStreamEntryMessage() : this(0)
		{
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceStreamEntryMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0000747F File Offset: 0x0000567F
		public override void Decode()
		{
			base.Decode();
			this.streamEntry_0 = StreamEntryFactory.CreateStreamEntryByType((StreamEntryType)this.m_stream.ReadInt());
			this.streamEntry_0.Decode(this.m_stream);
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x000074AE File Offset: 0x000056AE
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.streamEntry_0.GetStreamEntryType());
			this.streamEntry_0.Encode(this.m_stream);
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x000074DD File Offset: 0x000056DD
		public override short GetMessageType()
		{
			return 24312;
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x000074E4 File Offset: 0x000056E4
		public override void Destruct()
		{
			base.Destruct();
			this.streamEntry_0 = null;
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x000074F3 File Offset: 0x000056F3
		public StreamEntry GetStreamEntryId()
		{
			return this.streamEntry_0;
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x000074FB File Offset: 0x000056FB
		public void SetStreamEntry(StreamEntry value)
		{
			this.streamEntry_0 = value;
		}

		// Token: 0x040003A6 RID: 934
		public const int MESSAGE_TYPE = 24312;

		// Token: 0x040003A7 RID: 935
		private StreamEntry streamEntry_0;
	}
}
