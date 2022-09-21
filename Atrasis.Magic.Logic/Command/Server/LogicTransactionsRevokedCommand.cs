using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000186 RID: 390
	public class LogicTransactionsRevokedCommand : LogicServerCommand
	{
		// Token: 0x06001668 RID: 5736 RVA: 0x0000EA6C File Offset: 0x0000CC6C
		public void SetAmount(int diamondCount)
		{
			this.int_2 = diamondCount;
		}

		// Token: 0x06001669 RID: 5737 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600166A RID: 5738 RVA: 0x0000EA75 File Offset: 0x0000CC75
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_2 = stream.ReadInt();
		}

		// Token: 0x0600166B RID: 5739 RVA: 0x0000EA8A File Offset: 0x0000CC8A
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteInt(this.int_2);
		}

		// Token: 0x0600166C RID: 5740 RVA: 0x00056110 File Offset: 0x00054310
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetDiamonds(playerAvatar.GetDiamonds() - this.int_2);
				if (playerAvatar.GetFreeDiamonds() > playerAvatar.GetDiamonds())
				{
					playerAvatar.SetFreeDiamonds(playerAvatar.GetDiamonds());
				}
				playerAvatar.AddCumulativePurchasedDiamonds(-this.int_2);
				return 0;
			}
			return -1;
		}

		// Token: 0x0600166D RID: 5741 RVA: 0x00007717 File Offset: 0x00005917
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TRANSACTIONS_REVOKED;
		}

		// Token: 0x04000C9D RID: 3229
		private int int_2;
	}
}
