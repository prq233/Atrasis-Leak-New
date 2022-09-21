using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000086 RID: 134
	public class LiveReplayAddSpectatorResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x00006BF2 File Offset: 0x00004DF2
		// (set) Token: 0x060003C9 RID: 969 RVA: 0x00006BFA File Offset: 0x00004DFA
		public LiveReplayAddSpectatorResponseMessage.Reason ErrorCode { get; set; }

		// Token: 0x060003CA RID: 970 RVA: 0x00006C03 File Offset: 0x00004E03
		public override void Encode(ByteStream stream)
		{
			if (!base.Success)
			{
				stream.WriteVInt((int)this.ErrorCode);
			}
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00006C19 File Offset: 0x00004E19
		public override void Decode(ByteStream stream)
		{
			if (!base.Success)
			{
				this.ErrorCode = (LiveReplayAddSpectatorResponseMessage.Reason)stream.ReadVInt();
			}
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00006C2F File Offset: 0x00004E2F
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LIVE_REPLAY_ADD_SPECTATOR_RESPONSE;
		}

		// Token: 0x040001C0 RID: 448
		[CompilerGenerated]
		private LiveReplayAddSpectatorResponseMessage.Reason reason_0;

		// Token: 0x02000087 RID: 135
		public enum Reason
		{
			// Token: 0x040001C2 RID: 450
			NOT_EXISTS,
			// Token: 0x040001C3 RID: 451
			FULL
		}
	}
}
