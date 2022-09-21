using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Offer;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000177 RID: 375
	public class LogicContinueOfferPurchaseCommand : LogicServerCommand
	{
		// Token: 0x06001600 RID: 5632 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001601 RID: 5633 RVA: 0x0000E5D8 File Offset: 0x0000C7D8
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_2 = stream.ReadVInt();
		}

		// Token: 0x06001602 RID: 5634 RVA: 0x0000E5ED File Offset: 0x0000C7ED
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteVInt(this.int_2);
		}

		// Token: 0x06001603 RID: 5635 RVA: 0x00054CE4 File Offset: 0x00052EE4
		public override int Execute(LogicLevel level)
		{
			if (level.GetState() != 1)
			{
				return -1;
			}
			LogicOffer offerById = level.GetOfferManager().GetOfferById(this.int_2);
			if (offerById.GetState() == 1)
			{
				offerById.SetState(2);
				return 0;
			}
			return -2;
		}

		// Token: 0x06001604 RID: 5636 RVA: 0x0000E602 File Offset: 0x0000C802
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CONTINUE_OFFER_PURCHASE;
		}

		// Token: 0x04000C76 RID: 3190
		private int int_2;
	}
}
