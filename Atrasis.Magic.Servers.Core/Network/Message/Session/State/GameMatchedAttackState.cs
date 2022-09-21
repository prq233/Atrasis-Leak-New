using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.State
{
	// Token: 0x0200004E RID: 78
	public class GameMatchedAttackState : GameState
	{
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600020C RID: 524 RVA: 0x00005990 File Offset: 0x00003B90
		// (set) Token: 0x0600020D RID: 525 RVA: 0x00005998 File Offset: 0x00003B98
		public LogicLong LiveReplayId { get; set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600020E RID: 526 RVA: 0x000059A1 File Offset: 0x00003BA1
		// (set) Token: 0x0600020F RID: 527 RVA: 0x000059A9 File Offset: 0x00003BA9
		public LogicClientAvatar HomeOwnerAvatar { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000210 RID: 528 RVA: 0x000059B2 File Offset: 0x00003BB2
		// (set) Token: 0x06000211 RID: 529 RVA: 0x000059BA File Offset: 0x00003BBA
		public int MaintenanceTime { get; set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000212 RID: 530 RVA: 0x000059C3 File Offset: 0x00003BC3
		// (set) Token: 0x06000213 RID: 531 RVA: 0x000059CB File Offset: 0x00003BCB
		public bool GameDefenderLocked { get; set; }

		// Token: 0x06000214 RID: 532 RVA: 0x000059D4 File Offset: 0x00003BD4
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			this.HomeOwnerAvatar.Encode(stream);
			stream.WriteVInt(this.MaintenanceTime);
			stream.WriteBoolean(this.GameDefenderLocked);
			stream.WriteLong(this.LiveReplayId);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000C434 File Offset: 0x0000A634
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.HomeOwnerAvatar = new LogicClientAvatar();
			this.HomeOwnerAvatar.Decode(stream);
			this.MaintenanceTime = stream.ReadVInt();
			this.GameDefenderLocked = stream.ReadBoolean();
			this.LiveReplayId = stream.ReadLong();
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000552A File Offset: 0x0000372A
		public override GameStateType GetGameStateType()
		{
			return GameStateType.MATCHED_ATTACK;
		}

		// Token: 0x0400011E RID: 286
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x0400011F RID: 287
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_1;

		// Token: 0x04000120 RID: 288
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04000121 RID: 289
		[CompilerGenerated]
		private bool bool_0;
	}
}
