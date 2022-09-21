using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000BF RID: 191
	public class GameHomeProtectionUpdateMessage : ServerAccountMessage
	{
		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x00007C98 File Offset: 0x00005E98
		// (set) Token: 0x06000567 RID: 1383 RVA: 0x00007CA0 File Offset: 0x00005EA0
		public int ShieldTimeSeconds { get; set; } = -1;

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x00007CA9 File Offset: 0x00005EA9
		// (set) Token: 0x06000569 RID: 1385 RVA: 0x00007CB1 File Offset: 0x00005EB1
		public int GuardTimeSeconds { get; set; } = -1;

		// Token: 0x0600056A RID: 1386 RVA: 0x00007CBA File Offset: 0x00005EBA
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.ShieldTimeSeconds);
			stream.WriteVInt(this.GuardTimeSeconds);
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x00007CD4 File Offset: 0x00005ED4
		public override void Decode(ByteStream stream)
		{
			this.ShieldTimeSeconds = stream.ReadVInt();
			this.GuardTimeSeconds = stream.ReadVInt();
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x00007CEE File Offset: 0x00005EEE
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_HOME_PROTECTION_UPDATE;
		}

		// Token: 0x04000232 RID: 562
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000233 RID: 563
		[CompilerGenerated]
		private int int_3;
	}
}
