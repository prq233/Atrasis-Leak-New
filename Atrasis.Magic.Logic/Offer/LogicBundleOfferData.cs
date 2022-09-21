using System;
using Atrasis.Magic.Logic.Data;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x02000017 RID: 23
	public class LogicBundleOfferData : LogicOfferData
	{
		// Token: 0x060000FC RID: 252 RVA: 0x00002AE3 File Offset: 0x00000CE3
		public LogicBundleOfferData(LogicGemBundleData data)
		{
			this.m_offerId = data.GetGlobalID();
			this.m_linkedPackageId = data.GetLinkedPackageId();
			this.m_shopFrontPageCooldownAfterPurchaseSecs = data.GetShopFrontPageCooldownAfterPurchaseSeconds();
		}
	}
}
