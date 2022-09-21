using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.State
{
	// Token: 0x0200004F RID: 79
	public class GameNpcAttackState : GameState
	{
		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000218 RID: 536 RVA: 0x00005A0D File Offset: 0x00003C0D
		// (set) Token: 0x06000219 RID: 537 RVA: 0x00005A15 File Offset: 0x00003C15
		public LogicNpcAvatar NpcAvatar { get; set; }

		// Token: 0x0600021A RID: 538 RVA: 0x00005A1E File Offset: 0x00003C1E
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			this.NpcAvatar.Encode(stream);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00005A33 File Offset: 0x00003C33
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.NpcAvatar = new LogicNpcAvatar();
			this.NpcAvatar.Decode(stream);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00005A53 File Offset: 0x00003C53
		public override GameStateType GetGameStateType()
		{
			return GameStateType.NPC_ATTACK;
		}

		// Token: 0x04000122 RID: 290
		[CompilerGenerated]
		private LogicNpcAvatar logicNpcAvatar_0;
	}
}
