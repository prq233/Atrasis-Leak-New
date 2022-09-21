using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network.Message.Account;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000035 RID: 53
	public class GameAllianceDonationCountMessage : ServerAccountMessage
	{
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600013A RID: 314 RVA: 0x000051B7 File Offset: 0x000033B7
		// (set) Token: 0x0600013B RID: 315 RVA: 0x000051BF File Offset: 0x000033BF
		public int DonationCount { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600013C RID: 316 RVA: 0x000051C8 File Offset: 0x000033C8
		// (set) Token: 0x0600013D RID: 317 RVA: 0x000051D0 File Offset: 0x000033D0
		public int ReceivedDonationCount { get; set; }

		// Token: 0x0600013E RID: 318 RVA: 0x000051D9 File Offset: 0x000033D9
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.DonationCount);
			stream.WriteVInt(this.ReceivedDonationCount);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x000051F3 File Offset: 0x000033F3
		public override void Decode(ByteStream stream)
		{
			this.DonationCount = stream.ReadVInt();
			this.ReceivedDonationCount = stream.ReadVInt();
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000520D File Offset: 0x0000340D
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_ALLIANCE_DONATION_COUNT;
		}

		// Token: 0x040000E8 RID: 232
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040000E9 RID: 233
		[CompilerGenerated]
		private int int_3;
	}
}
