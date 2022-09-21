using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000071 RID: 113
	public class AllianceJoinRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000326 RID: 806 RVA: 0x000065B9 File Offset: 0x000047B9
		// (set) Token: 0x06000327 RID: 807 RVA: 0x000065C1 File Offset: 0x000047C1
		public LogicLong AllianceId { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000328 RID: 808 RVA: 0x000065CA File Offset: 0x000047CA
		// (set) Token: 0x06000329 RID: 809 RVA: 0x000065D2 File Offset: 0x000047D2
		public LogicClientAvatar Avatar { get; set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600032A RID: 810 RVA: 0x000065DB File Offset: 0x000047DB
		// (set) Token: 0x0600032B RID: 811 RVA: 0x000065E3 File Offset: 0x000047E3
		public bool Created { get; set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600032C RID: 812 RVA: 0x000065EC File Offset: 0x000047EC
		// (set) Token: 0x0600032D RID: 813 RVA: 0x000065F4 File Offset: 0x000047F4
		public bool Invited { get; set; }

		// Token: 0x0600032E RID: 814 RVA: 0x000065FD File Offset: 0x000047FD
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AllianceId);
			stream.WriteBoolean(this.Created);
			stream.WriteBoolean(this.Invited);
			this.Avatar.Encode(stream);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000662F File Offset: 0x0000482F
		public override void Decode(ByteStream stream)
		{
			this.AllianceId = stream.ReadLong();
			this.Created = stream.ReadBoolean();
			this.Invited = stream.ReadBoolean();
			this.Avatar = new LogicClientAvatar();
			this.Avatar.Decode(stream);
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0000666C File Offset: 0x0000486C
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_JOIN_REQUEST;
		}

		// Token: 0x04000177 RID: 375
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x04000178 RID: 376
		[CompilerGenerated]
		private LogicClientAvatar logicClientAvatar_0;

		// Token: 0x04000179 RID: 377
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x0400017A RID: 378
		[CompilerGenerated]
		private bool bool_1;
	}
}
