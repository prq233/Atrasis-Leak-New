using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000AE RID: 174
	public class AllianceChallengeSpectatorCountMessage : ServerAccountMessage
	{
		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x000076FD File Offset: 0x000058FD
		// (set) Token: 0x060004CF RID: 1231 RVA: 0x00007705 File Offset: 0x00005905
		public LogicLong StreamId { get; set; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x0000770E File Offset: 0x0000590E
		// (set) Token: 0x060004D1 RID: 1233 RVA: 0x00007716 File Offset: 0x00005916
		public int Count { get; set; }

		// Token: 0x060004D2 RID: 1234 RVA: 0x0000771F File Offset: 0x0000591F
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.StreamId);
			stream.WriteVInt(this.Count);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00007739 File Offset: 0x00005939
		public override void Decode(ByteStream stream)
		{
			this.StreamId = stream.ReadLong();
			this.Count = stream.ReadVInt();
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00007753 File Offset: 0x00005953
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_CHALLENGE_SPECTATOR_COUNT;
		}

		// Token: 0x04000208 RID: 520
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000209 RID: 521
		[CompilerGenerated]
		private int int_2;
	}
}
