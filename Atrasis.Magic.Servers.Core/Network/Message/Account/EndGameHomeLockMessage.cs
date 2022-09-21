using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000BC RID: 188
	public class EndGameHomeLockMessage : ServerAccountMessage
	{
		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000556 RID: 1366 RVA: 0x00007C24 File Offset: 0x00005E24
		// (set) Token: 0x06000557 RID: 1367 RVA: 0x00007C2C File Offset: 0x00005E2C
		public LogicLong AttackerId { get; set; }

		// Token: 0x06000558 RID: 1368 RVA: 0x00007C35 File Offset: 0x00005E35
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AttackerId);
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00007C43 File Offset: 0x00005E43
		public override void Decode(ByteStream stream)
		{
			this.AttackerId = stream.ReadLong();
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x00007C51 File Offset: 0x00005E51
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.END_GAME_HOME_LOCK;
		}

		// Token: 0x04000230 RID: 560
		[CompilerGenerated]
		private LogicLong logicLong_1;
	}
}
