using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000085 RID: 133
	public class LiveReplayAddSpectatorRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060003BE RID: 958 RVA: 0x00006B6C File Offset: 0x00004D6C
		// (set) Token: 0x060003BF RID: 959 RVA: 0x00006B74 File Offset: 0x00004D74
		public LogicLong LiveReplayId { get; set; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x00006B7D File Offset: 0x00004D7D
		// (set) Token: 0x060003C1 RID: 961 RVA: 0x00006B85 File Offset: 0x00004D85
		public long SessionId { get; set; }

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x00006B8E File Offset: 0x00004D8E
		// (set) Token: 0x060003C3 RID: 963 RVA: 0x00006B96 File Offset: 0x00004D96
		public int SlotId { get; set; }

		// Token: 0x060003C4 RID: 964 RVA: 0x00006B9F File Offset: 0x00004D9F
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.LiveReplayId);
			stream.WriteLongLong(this.SessionId);
			stream.WriteVInt(this.SlotId);
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00006BC5 File Offset: 0x00004DC5
		public override void Decode(ByteStream stream)
		{
			this.LiveReplayId = stream.ReadLong();
			this.SessionId = stream.ReadLongLong();
			this.SlotId = stream.ReadVInt();
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00006BEB File Offset: 0x00004DEB
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LIVE_REPLAY_ADD_SPECTATOR_REQUEST;
		}

		// Token: 0x040001BD RID: 445
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040001BE RID: 446
		[CompilerGenerated]
		private long long_1;

		// Token: 0x040001BF RID: 447
		[CompilerGenerated]
		private int int_2;
	}
}
