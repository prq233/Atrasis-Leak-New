using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000C3 RID: 195
	public class LiveReplayRemoveSpectatorMessage : ServerAccountMessage
	{
		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x00007DF3 File Offset: 0x00005FF3
		// (set) Token: 0x0600058B RID: 1419 RVA: 0x00007DFB File Offset: 0x00005FFB
		public long SessionId { get; set; }

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600058C RID: 1420 RVA: 0x00007E04 File Offset: 0x00006004
		// (set) Token: 0x0600058D RID: 1421 RVA: 0x00007E0C File Offset: 0x0000600C
		public int SlotId { get; set; }

		// Token: 0x0600058E RID: 1422 RVA: 0x00007E15 File Offset: 0x00006015
		public override void Encode(ByteStream stream)
		{
			stream.WriteLongLong(this.SessionId);
			stream.WriteVInt(this.SlotId);
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00007E2F File Offset: 0x0000602F
		public override void Decode(ByteStream stream)
		{
			this.SessionId = stream.ReadLongLong();
			this.SlotId = stream.ReadVInt();
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00007E49 File Offset: 0x00006049
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LIVE_REPLAY_REMOVE_SPECTATOR;
		}

		// Token: 0x0400023C RID: 572
		[CompilerGenerated]
		private long long_0;

		// Token: 0x0400023D RID: 573
		[CompilerGenerated]
		private int int_2;
	}
}
