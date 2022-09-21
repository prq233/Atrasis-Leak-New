using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.State
{
	// Token: 0x02000050 RID: 80
	public class GameNpcDuelState : GameState
	{
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600021E RID: 542 RVA: 0x00005A56 File Offset: 0x00003C56
		// (set) Token: 0x0600021F RID: 543 RVA: 0x00005A5E File Offset: 0x00003C5E
		public LogicNpcAvatar NpcAvatar { get; set; }

		// Token: 0x06000220 RID: 544 RVA: 0x00005A67 File Offset: 0x00003C67
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			this.NpcAvatar.Encode(stream);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00005A7C File Offset: 0x00003C7C
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.NpcAvatar = new LogicNpcAvatar();
			this.NpcAvatar.Decode(stream);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00005A9C File Offset: 0x00003C9C
		public override GameStateType GetGameStateType()
		{
			return GameStateType.NPC_DUEL;
		}

		// Token: 0x04000123 RID: 291
		[CompilerGenerated]
		private LogicNpcAvatar logicNpcAvatar_0;
	}
}
