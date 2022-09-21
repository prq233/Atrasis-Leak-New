using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000AB RID: 171
	public class AllianceChallengeLiveReplayIdMessage : ServerAccountMessage
	{
		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060004B2 RID: 1202 RVA: 0x00007599 File Offset: 0x00005799
		// (set) Token: 0x060004B3 RID: 1203 RVA: 0x000075A1 File Offset: 0x000057A1
		public LogicLong LiveReplayId { get; set; }

		// Token: 0x060004B4 RID: 1204 RVA: 0x000075AA File Offset: 0x000057AA
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.LiveReplayId);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x000075B8 File Offset: 0x000057B8
		public override void Decode(ByteStream stream)
		{
			this.LiveReplayId = stream.ReadLong();
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x000075C6 File Offset: 0x000057C6
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_CHALLENGE_LIVE_REPLAY_ID;
		}

		// Token: 0x04000200 RID: 512
		[CompilerGenerated]
		private LogicLong logicLong_1;
	}
}
