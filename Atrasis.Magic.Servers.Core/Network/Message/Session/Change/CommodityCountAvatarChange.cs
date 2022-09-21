using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000063 RID: 99
	public class CommodityCountAvatarChange : AvatarChange
	{
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600029E RID: 670 RVA: 0x00005F5F File Offset: 0x0000415F
		// (set) Token: 0x0600029F RID: 671 RVA: 0x00005F67 File Offset: 0x00004167
		public int Type { get; set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x00005F70 File Offset: 0x00004170
		// (set) Token: 0x060002A1 RID: 673 RVA: 0x00005F78 File Offset: 0x00004178
		public LogicData Data { get; set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x00005F81 File Offset: 0x00004181
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x00005F89 File Offset: 0x00004189
		public int Count { get; set; }

		// Token: 0x060002A4 RID: 676 RVA: 0x00005F92 File Offset: 0x00004192
		public override void Decode(ByteStream stream)
		{
			this.Type = stream.ReadVInt();
			this.Data = ByteStreamHelper.ReadDataReference(stream);
			this.Count = stream.ReadVInt();
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00005FB8 File Offset: 0x000041B8
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Type);
			ByteStreamHelper.WriteDataReference(stream, this.Data);
			stream.WriteVInt(this.Count);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00005FDE File Offset: 0x000041DE
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetCommodityCount(this.Type, this.Data, this.Count);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00005A53 File Offset: 0x00003C53
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.COMMODITY_COUNT;
		}

		// Token: 0x0400015D RID: 349
		[CompilerGenerated]
		private int int_0;

		// Token: 0x0400015E RID: 350
		[CompilerGenerated]
		private LogicData logicData_0;

		// Token: 0x0400015F RID: 351
		[CompilerGenerated]
		private int int_1;
	}
}
