using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B9 RID: 185
	public class DuelAttackEventMessage : ServerAccountMessage
	{
		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x00007AE5 File Offset: 0x00005CE5
		// (set) Token: 0x06000537 RID: 1335 RVA: 0x00007AED File Offset: 0x00005CED
		public LogicLong AvatarId { get; set; }

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x00007AF6 File Offset: 0x00005CF6
		// (set) Token: 0x06000539 RID: 1337 RVA: 0x00007AFE File Offset: 0x00005CFE
		public int Type { get; set; }

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x00007B07 File Offset: 0x00005D07
		// (set) Token: 0x0600053B RID: 1339 RVA: 0x00007B0F File Offset: 0x00005D0F
		public int Stars { get; set; }

		// Token: 0x0600053C RID: 1340 RVA: 0x00007B18 File Offset: 0x00005D18
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AvatarId);
			stream.WriteVInt(this.Type);
			stream.WriteVInt(this.Stars);
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00007B3E File Offset: 0x00005D3E
		public override void Decode(ByteStream stream)
		{
			this.AvatarId = stream.ReadLong();
			this.Type = stream.ReadVInt();
			this.Stars = stream.ReadVInt();
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00007B64 File Offset: 0x00005D64
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.DUEL_ATTACK_EVENT;
		}

		// Token: 0x04000226 RID: 550
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000227 RID: 551
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000228 RID: 552
		[CompilerGenerated]
		private int int_3;
	}
}
