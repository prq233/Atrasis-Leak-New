using System;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x0200001C RID: 28
	public static class LogicDeliverableFactory
	{
		// Token: 0x0600012B RID: 299 RVA: 0x000174E4 File Offset: 0x000156E4
		public static LogicDeliverable CreateByType(int type)
		{
			switch (type)
			{
			case 1:
				return new LogicDeliverableResource();
			case 2:
				return new LogicDeliverableBuilding();
			case 3:
				return new LogicDeliverableDecoration();
			case 4:
				return new LogicDeliverableSpecial();
			case 5:
				return new LogicDeliverableBundle();
			case 6:
				return new LogicDeliverableGift();
			case 7:
				return new LogicDeliverableScaledMultiplier();
			default:
				Debugger.Error("Unknown delivery type " + type);
				return null;
			}
		}
	}
}
