using System;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x0200001D RID: 29
	public class LogicDeliverableGift : LogicDeliverableBundle
	{
		// Token: 0x0600012C RID: 300 RVA: 0x00002CCA File Offset: 0x00000ECA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00002CD2 File Offset: 0x00000ED2
		public override void WriteToJSON(LogicJSONObject jsonObject)
		{
			base.WriteToJSON(jsonObject);
			jsonObject.Put("giftLimit", new LogicJSONNumber(this.int_0));
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00002CF1 File Offset: 0x00000EF1
		public override void ReadFromJSON(LogicJSONObject jsonObject)
		{
			base.ReadFromJSON(jsonObject);
			this.int_0 = LogicJSONHelper.GetInt(jsonObject, "giftLimit");
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00002D0B File Offset: 0x00000F0B
		public override int GetDeliverableType()
		{
			return 6;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00002D0E File Offset: 0x00000F0E
		public override bool Deliver(LogicLevel level)
		{
			level.GetHomeOwnerAvatar().GetChangeListener().DeliverableAllianceGift(this);
			return true;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00002D22 File Offset: 0x00000F22
		public override bool CanBeDeliver(LogicLevel level)
		{
			return level.GetHomeOwnerAvatar().IsInAlliance();
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00002D2F File Offset: 0x00000F2F
		public int GetGiftLimit()
		{
			return this.int_0;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00002D37 File Offset: 0x00000F37
		public void SetGiftLimit(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000074 RID: 116
		private int int_0;
	}
}
