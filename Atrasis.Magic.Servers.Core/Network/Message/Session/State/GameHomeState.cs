using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Command;
using Atrasis.Magic.Logic.Command.Server;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.State
{
	// Token: 0x0200004D RID: 77
	public class GameHomeState : GameState
	{
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001FC RID: 508 RVA: 0x00005927 File Offset: 0x00003B27
		// (set) Token: 0x060001FD RID: 509 RVA: 0x0000592F File Offset: 0x00003B2F
		public int RemainingShieldTimeSeconds { get; set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001FE RID: 510 RVA: 0x00005938 File Offset: 0x00003B38
		// (set) Token: 0x060001FF RID: 511 RVA: 0x00005940 File Offset: 0x00003B40
		public int RemainingGuardTimeSeconds { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000200 RID: 512 RVA: 0x00005949 File Offset: 0x00003B49
		// (set) Token: 0x06000201 RID: 513 RVA: 0x00005951 File Offset: 0x00003B51
		public int MaintenanceTime { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000202 RID: 514 RVA: 0x0000595A File Offset: 0x00003B5A
		// (set) Token: 0x06000203 RID: 515 RVA: 0x00005962 File Offset: 0x00003B62
		public int LayoutId { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000204 RID: 516 RVA: 0x0000596B File Offset: 0x00003B6B
		// (set) Token: 0x06000205 RID: 517 RVA: 0x00005973 File Offset: 0x00003B73
		public int MapId { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000206 RID: 518 RVA: 0x0000597C File Offset: 0x00003B7C
		// (set) Token: 0x06000207 RID: 519 RVA: 0x00005984 File Offset: 0x00003B84
		public LogicArrayList<LogicServerCommand> ServerCommands { get; set; }

		// Token: 0x06000208 RID: 520 RVA: 0x0000C324 File Offset: 0x0000A524
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			stream.WriteVInt(this.RemainingShieldTimeSeconds);
			stream.WriteVInt(this.RemainingGuardTimeSeconds);
			stream.WriteVInt(this.MaintenanceTime);
			stream.WriteVInt(this.LayoutId);
			stream.WriteVInt(this.MapId);
			stream.WriteVInt(this.ServerCommands.Size());
			for (int i = 0; i < this.ServerCommands.Size(); i++)
			{
				LogicCommandManager.EncodeCommand(stream, this.ServerCommands[i]);
			}
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000C3B0 File Offset: 0x0000A5B0
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.RemainingShieldTimeSeconds = stream.ReadVInt();
			this.RemainingGuardTimeSeconds = stream.ReadVInt();
			this.MaintenanceTime = stream.ReadVInt();
			this.LayoutId = stream.ReadVInt();
			this.MapId = stream.ReadVInt();
			this.ServerCommands = new LogicArrayList<LogicServerCommand>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.ServerCommands.Add((LogicServerCommand)LogicCommandManager.DecodeCommand(stream));
			}
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0000598D File Offset: 0x00003B8D
		public override GameStateType GetGameStateType()
		{
			return GameStateType.HOME;
		}

		// Token: 0x04000118 RID: 280
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04000119 RID: 281
		[CompilerGenerated]
		private int int_2;

		// Token: 0x0400011A RID: 282
		[CompilerGenerated]
		private int int_3;

		// Token: 0x0400011B RID: 283
		[CompilerGenerated]
		private int int_4;

		// Token: 0x0400011C RID: 284
		[CompilerGenerated]
		private int int_5;

		// Token: 0x0400011D RID: 285
		[CompilerGenerated]
		private LogicArrayList<LogicServerCommand> logicArrayList_0;
	}
}
