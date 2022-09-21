using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.State
{
	// Token: 0x02000051 RID: 81
	public abstract class GameState
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000224 RID: 548 RVA: 0x00005A9F File Offset: 0x00003C9F
		// (set) Token: 0x06000225 RID: 549 RVA: 0x00005AA7 File Offset: 0x00003CA7
		public LogicClientAvatar PlayerAvatar { get; set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000226 RID: 550 RVA: 0x00005AB0 File Offset: 0x00003CB0
		// (set) Token: 0x06000227 RID: 551 RVA: 0x00005AB8 File Offset: 0x00003CB8
		public LogicLong HomeId { get; set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000228 RID: 552 RVA: 0x00005AC1 File Offset: 0x00003CC1
		// (set) Token: 0x06000229 RID: 553 RVA: 0x00005AC9 File Offset: 0x00003CC9
		public byte[] HomeData { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600022A RID: 554 RVA: 0x00005AD2 File Offset: 0x00003CD2
		// (set) Token: 0x0600022B RID: 555 RVA: 0x00005ADA File Offset: 0x00003CDA
		public int SaveTime { get; set; } = -1;

		// Token: 0x0600022C RID: 556 RVA: 0x00005AE3 File Offset: 0x00003CE3
		public virtual void Encode(ByteStream stream)
		{
			this.PlayerAvatar.Encode(stream);
			stream.WriteLong(this.HomeId);
			stream.WriteBytes(this.HomeData, this.HomeData.Length);
			stream.WriteVInt(this.SaveTime);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000C484 File Offset: 0x0000A684
		public virtual void Decode(ByteStream stream)
		{
			this.PlayerAvatar = new LogicClientAvatar();
			this.PlayerAvatar.Decode(stream);
			this.HomeId = stream.ReadLong();
			this.HomeData = stream.ReadBytes(stream.ReadBytesLength(), 900000);
			this.SaveTime = stream.ReadVInt();
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00005B1D File Offset: 0x00003D1D
		public virtual SimulationServiceNodeType GetSimulationServiceNodeType()
		{
			return SimulationServiceNodeType.HOME;
		}

		// Token: 0x0600022F RID: 559
		public abstract GameStateType GetGameStateType();

		// Token: 0x04000124 RID: 292
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000125 RID: 293
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x04000126 RID: 294
		[CompilerGenerated]
		private byte[] byte_0;

		// Token: 0x04000127 RID: 295
		[CompilerGenerated]
		private int int_0;
	}
}
