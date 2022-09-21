using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000BB RID: 187
	public class DuelResultMessage : ServerAccountMessage
	{
		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000548 RID: 1352 RVA: 0x00007BC8 File Offset: 0x00005DC8
		// (set) Token: 0x06000549 RID: 1353 RVA: 0x00007BD0 File Offset: 0x00005DD0
		public LogicLong AvatarId { get; set; }

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x0600054A RID: 1354 RVA: 0x00007BD9 File Offset: 0x00005DD9
		// (set) Token: 0x0600054B RID: 1355 RVA: 0x00007BE1 File Offset: 0x00005DE1
		public LogicLong ReplayId { get; set; }

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x00007BEA File Offset: 0x00005DEA
		// (set) Token: 0x0600054D RID: 1357 RVA: 0x00007BF2 File Offset: 0x00005DF2
		public string BattleLog { get; set; }

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x0600054E RID: 1358 RVA: 0x00007BFB File Offset: 0x00005DFB
		// (set) Token: 0x0600054F RID: 1359 RVA: 0x00007C03 File Offset: 0x00005E03
		public int DestructionPercentage { get; set; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000550 RID: 1360 RVA: 0x00007C0C File Offset: 0x00005E0C
		// (set) Token: 0x06000551 RID: 1361 RVA: 0x00007C14 File Offset: 0x00005E14
		public int Stars { get; set; }

		// Token: 0x06000552 RID: 1362 RVA: 0x0000D450 File Offset: 0x0000B650
		public override void Encode(ByteStream stream)
		{
			if (this.ReplayId != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.ReplayId);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			stream.WriteLong(this.AvatarId);
			stream.WriteString(this.BattleLog);
			stream.WriteVInt(this.DestructionPercentage);
			stream.WriteVInt(this.Stars);
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0000D4B4 File Offset: 0x0000B6B4
		public override void Decode(ByteStream stream)
		{
			if (stream.ReadBoolean())
			{
				this.ReplayId = stream.ReadLong();
			}
			this.AvatarId = stream.ReadLong();
			this.BattleLog = stream.ReadString(900000);
			this.DestructionPercentage = stream.ReadVInt();
			this.Stars = stream.ReadVInt();
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x00007C1D File Offset: 0x00005E1D
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.DUEL_RESULT;
		}

		// Token: 0x0400022B RID: 555
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x0400022C RID: 556
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x0400022D RID: 557
		[CompilerGenerated]
		private string string_0;

		// Token: 0x0400022E RID: 558
		[CompilerGenerated]
		private int int_2;

		// Token: 0x0400022F RID: 559
		[CompilerGenerated]
		private int int_3;
	}
}
