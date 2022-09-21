using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.State
{
	// Token: 0x0200004A RID: 74
	public class GameChallengeAttackState : GameState
	{
		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00005760 File Offset: 0x00003960
		// (set) Token: 0x060001DC RID: 476 RVA: 0x00005768 File Offset: 0x00003968
		public LogicLong LiveReplayId { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00005771 File Offset: 0x00003971
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00005779 File Offset: 0x00003979
		public LogicLong StreamId { get; set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00005782 File Offset: 0x00003982
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x0000578A File Offset: 0x0000398A
		public LogicLong AllianceId { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00005793 File Offset: 0x00003993
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x0000579B File Offset: 0x0000399B
		public int MapId { get; set; }

		// Token: 0x060001E3 RID: 483 RVA: 0x000057A4 File Offset: 0x000039A4
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteLong(this.LiveReplayId);
			stream.WriteLong(this.StreamId);
			stream.WriteLong(this.AllianceId);
			stream.WriteVInt(this.MapId);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x000057DD File Offset: 0x000039DD
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.LiveReplayId = stream.ReadLong();
			this.StreamId = stream.ReadLong();
			this.AllianceId = stream.ReadLong();
			this.MapId = stream.ReadVInt();
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00005816 File Offset: 0x00003A16
		public override GameStateType GetGameStateType()
		{
			return GameStateType.CHALLENGE_ATTACK;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00005819 File Offset: 0x00003A19
		public override SimulationServiceNodeType GetSimulationServiceNodeType()
		{
			return SimulationServiceNodeType.BATTLE;
		}

		// Token: 0x0400010F RID: 271
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000110 RID: 272
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x04000111 RID: 273
		[CompilerGenerated]
		private LogicLong logicLong_3;

		// Token: 0x04000112 RID: 274
		[CompilerGenerated]
		private int int_1;
	}
}
