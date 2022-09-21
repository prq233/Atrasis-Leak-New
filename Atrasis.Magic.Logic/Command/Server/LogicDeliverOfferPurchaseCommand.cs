using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Offer;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000178 RID: 376
	public class LogicDeliverOfferPurchaseCommand : LogicServerCommand
	{
		// Token: 0x06001606 RID: 5638 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001607 RID: 5639 RVA: 0x00054D24 File Offset: 0x00052F24
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_2 = stream.ReadVInt();
			this.string_0 = stream.ReadString(900000);
			if (this.logicDeliverableBundle_0 != null)
			{
				this.logicDeliverableBundle_0.Destruct();
				this.logicDeliverableBundle_0 = null;
			}
			this.logicDeliverableBundle_0 = new LogicDeliverableBundle();
			this.logicDeliverableBundle_0.Decode(stream);
			this.logicBillingPackageData_0 = (LogicBillingPackageData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.BILLING_PACKAGE);
		}

		// Token: 0x06001608 RID: 5640 RVA: 0x0000E606 File Offset: 0x0000C806
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteVInt(this.int_2);
			encoder.WriteString(this.string_0);
			this.logicDeliverableBundle_0.Encode(encoder);
			ByteStreamHelper.WriteDataReference(encoder, this.logicBillingPackageData_0);
		}

		// Token: 0x06001609 RID: 5641 RVA: 0x00054D9C File Offset: 0x00052F9C
		public override int Execute(LogicLevel level)
		{
			if (level.GetGameMode().GetState() != 1)
			{
				return -1;
			}
			if (level.GetHomeOwnerAvatar() == null)
			{
				return -2;
			}
			if (this.logicDeliverableBundle_0 == null)
			{
				return -3;
			}
			if (this.logicBillingPackageData_0 != null)
			{
				LogicDeliveryHelper.Deliver(level, this.logicDeliverableBundle_0);
				LogicOffer offerById = level.GetOfferManager().GetOfferById(this.int_2);
				if (offerById != null)
				{
					offerById.SetState(4);
					offerById.AddPayCount(1);
				}
				else
				{
					Debugger.Warning(string.Format("Delivering offerUid:{0}. Offer was no longer found.", this.int_2));
				}
				return 0;
			}
			return -4;
		}

		// Token: 0x0600160A RID: 5642 RVA: 0x0000E63F File Offset: 0x0000C83F
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.DELIVER_OFFER_PURCHASE;
		}

		// Token: 0x0600160B RID: 5643 RVA: 0x0000E643 File Offset: 0x0000C843
		public void SetDatas(int offerId, string transactionId, LogicDeliverableBundle deliverableBundle, LogicBillingPackageData billingPackageData)
		{
			this.int_2 = offerId;
			this.string_0 = transactionId;
			this.logicDeliverableBundle_0 = deliverableBundle;
			this.logicBillingPackageData_0 = billingPackageData;
		}

		// Token: 0x04000C77 RID: 3191
		private int int_2;

		// Token: 0x04000C78 RID: 3192
		private string string_0;

		// Token: 0x04000C79 RID: 3193
		private LogicDeliverableBundle logicDeliverableBundle_0;

		// Token: 0x04000C7A RID: 3194
		private LogicBillingPackageData logicBillingPackageData_0;
	}
}
