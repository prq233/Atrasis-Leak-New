using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Offer;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Helper
{
	// Token: 0x02000109 RID: 265
	public static class LogicDeliveryHelper
	{
		// Token: 0x06000CB0 RID: 3248 RVA: 0x0002B8F8 File Offset: 0x00029AF8
		public static void Deliver(LogicLevel level, LogicDeliverable deliverable)
		{
			Debugger.DoAssert(deliverable != null, "Deliverable is null!");
			if (deliverable.GetDeliverableType() == 5)
			{
				LogicDeliverableBundle logicDeliverableBundle = (LogicDeliverableBundle)deliverable;
				for (int i = 0; i < logicDeliverableBundle.GetDeliverableCount(); i++)
				{
					LogicDeliveryHelper.Deliver(level, logicDeliverableBundle.GetDeliverable(i));
				}
				return;
			}
			if (!deliverable.Deliver(level))
			{
				LogicDeliverable logicDeliverable = deliverable.Compensate(level);
				if (logicDeliverable != null && !logicDeliverable.Deliver(level))
				{
					Debugger.Error("Delivery compensation failed!");
				}
			}
		}
	}
}
