using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.State
{
	// Token: 0x02000056 RID: 86
	public class GameVisitState : GameState
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600023B RID: 571 RVA: 0x00005B8D File Offset: 0x00003D8D
		// (set) Token: 0x0600023C RID: 572 RVA: 0x00005B95 File Offset: 0x00003D95
		public LogicClientAvatar HomeOwnerAvatar { get; set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00005B9E File Offset: 0x00003D9E
		// (set) Token: 0x0600023E RID: 574 RVA: 0x00005BA6 File Offset: 0x00003DA6
		public int VisitType { get; set; }

		// Token: 0x0600023F RID: 575 RVA: 0x00005BAF File Offset: 0x00003DAF
		public override void Encode(ByteStream stream)
		{
			base.Encode(stream);
			this.HomeOwnerAvatar.Encode(stream);
			stream.WriteVInt(this.VisitType);
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00005BD0 File Offset: 0x00003DD0
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.HomeOwnerAvatar = new LogicClientAvatar();
			this.HomeOwnerAvatar.Decode(stream);
			this.VisitType = stream.ReadVInt();
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00005BFC File Offset: 0x00003DFC
		public override GameStateType GetGameStateType()
		{
			return GameStateType.VISIT;
		}

		// Token: 0x04000135 RID: 309
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_1;

		// Token: 0x04000136 RID: 310
		[CompilerGenerated]
		private int int_1;
	}
}
