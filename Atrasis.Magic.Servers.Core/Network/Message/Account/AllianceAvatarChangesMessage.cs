using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network.Message.Session.Change;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000AA RID: 170
	public class AllianceAvatarChangesMessage : ServerAccountMessage
	{
		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x00007570 File Offset: 0x00005770
		// (set) Token: 0x060004AB RID: 1195 RVA: 0x00007578 File Offset: 0x00005778
		public LogicLong MemberId { get; set; }

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x00007581 File Offset: 0x00005781
		// (set) Token: 0x060004AD RID: 1197 RVA: 0x00007589 File Offset: 0x00005789
		public LogicArrayList<AvatarChange> AvatarChanges { get; set; }

		// Token: 0x060004AE RID: 1198 RVA: 0x0000D114 File Offset: 0x0000B314
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteVInt(this.AvatarChanges.Size());
			for (int i = 0; i < this.AvatarChanges.Size(); i++)
			{
				AvatarChangeFactory.Encode(stream, this.AvatarChanges[i]);
			}
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0000D168 File Offset: 0x0000B368
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.AvatarChanges = new LogicArrayList<AvatarChange>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.AvatarChanges.Add(AvatarChangeFactory.Decode(stream));
			}
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00007592 File Offset: 0x00005792
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_AVATAR_CHANGES;
		}

		// Token: 0x040001FE RID: 510
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x040001FF RID: 511
		[CompilerGenerated]
		private LogicArrayList<AvatarChange> logicArrayList_0;
	}
}
