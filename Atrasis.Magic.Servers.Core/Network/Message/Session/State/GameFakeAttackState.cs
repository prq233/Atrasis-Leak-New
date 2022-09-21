using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.State
{
	// Token: 0x0200004C RID: 76
	public class GameFakeAttackState : GameState
	{
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x000058B5 File Offset: 0x00003AB5
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x000058BD File Offset: 0x00003ABD
		public LogicClientAvatar HomeOwnerAvatar { get; set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x000058C6 File Offset: 0x00003AC6
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x000058CE File Offset: 0x00003ACE
		public int MaintenanceTime { get; set; }

		// Token: 0x060001F7 RID: 503 RVA: 0x000058D7 File Offset: 0x00003AD7
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			this.HomeOwnerAvatar.Encode(stream);
			stream.WriteVInt(this.MaintenanceTime);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x000058F8 File Offset: 0x00003AF8
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.HomeOwnerAvatar = new LogicClientAvatar();
			this.HomeOwnerAvatar.Decode(stream);
			this.MaintenanceTime = stream.ReadVInt();
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00005924 File Offset: 0x00003B24
		public override GameStateType GetGameStateType()
		{
			return GameStateType.FAKE_ATTACK;
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00005819 File Offset: 0x00003A19
		public override SimulationServiceNodeType GetSimulationServiceNodeType()
		{
			return SimulationServiceNodeType.BATTLE;
		}

		// Token: 0x04000116 RID: 278
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_1;

		// Token: 0x04000117 RID: 279
		[CompilerGenerated]
		private int int_1;
	}
}
