using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.State
{
	// Token: 0x0200004B RID: 75
	public class GameDuelState : GameState
	{
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x00005825 File Offset: 0x00003A25
		// (set) Token: 0x060001E9 RID: 489 RVA: 0x0000582D File Offset: 0x00003A2D
		public LogicLong AvatarId { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001EA RID: 490 RVA: 0x00005836 File Offset: 0x00003A36
		// (set) Token: 0x060001EB RID: 491 RVA: 0x0000583E File Offset: 0x00003A3E
		public LogicLong DuelEntryId { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00005847 File Offset: 0x00003A47
		// (set) Token: 0x060001ED RID: 493 RVA: 0x0000584F File Offset: 0x00003A4F
		public LogicLong LiveReplayId { get; set; }

		// Token: 0x060001EE RID: 494 RVA: 0x00005858 File Offset: 0x00003A58
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteLong(this.AvatarId);
			stream.WriteLong(this.DuelEntryId);
			stream.WriteLong(this.LiveReplayId);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00005885 File Offset: 0x00003A85
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.AvatarId = stream.ReadLong();
			this.DuelEntryId = stream.ReadLong();
			this.LiveReplayId = stream.ReadLong();
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x000058B2 File Offset: 0x00003AB2
		public override GameStateType GetGameStateType()
		{
			return GameStateType.DUEL;
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00005819 File Offset: 0x00003A19
		public override SimulationServiceNodeType GetSimulationServiceNodeType()
		{
			return SimulationServiceNodeType.BATTLE;
		}

		// Token: 0x04000113 RID: 275
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000114 RID: 276
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x04000115 RID: 277
		[CompilerGenerated]
		private LogicLong logicLong_3;
	}
}
