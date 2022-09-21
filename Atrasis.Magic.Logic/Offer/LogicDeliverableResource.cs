using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x0200001E RID: 30
	public class LogicDeliverableResource : LogicDeliverable
	{
		// Token: 0x06000135 RID: 309 RVA: 0x00002D48 File Offset: 0x00000F48
		public override void WriteToJSON(LogicJSONObject jsonObject)
		{
			base.WriteToJSON(jsonObject);
			LogicJSONHelper.SetLogicData(jsonObject, "resource", this.logicResourceData_0);
			jsonObject.Put("resourceAmount", new LogicJSONNumber(this.int_0));
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00002D78 File Offset: 0x00000F78
		public override void ReadFromJSON(LogicJSONObject jsonObject)
		{
			base.ReadFromJSON(jsonObject);
			this.logicResourceData_0 = (LogicResourceData)LogicJSONHelper.GetLogicData(jsonObject, "resource");
			this.int_0 = LogicJSONHelper.GetInt(jsonObject, "resourceAmount");
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00002B36 File Offset: 0x00000D36
		public override int GetDeliverableType()
		{
			return 1;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00017558 File Offset: 0x00015758
		public override bool Deliver(LogicLevel level)
		{
			LogicAvatar homeOwnerAvatar = level.GetHomeOwnerAvatar();
			int count = homeOwnerAvatar.GetResourceCount(this.logicResourceData_0) + this.int_0;
			homeOwnerAvatar.SetResourceCount(this.logicResourceData_0, count);
			homeOwnerAvatar.GetChangeListener().CommodityCountChanged(0, this.logicResourceData_0, count);
			return true;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00002DA8 File Offset: 0x00000FA8
		public LogicResourceData GetResourceData()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00002DB0 File Offset: 0x00000FB0
		public void SetResourceData(LogicResourceData data)
		{
			this.logicResourceData_0 = data;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00002DB9 File Offset: 0x00000FB9
		public int GetResourceAmount()
		{
			return this.int_0;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00002DC1 File Offset: 0x00000FC1
		public void SetResourceAmount(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000075 RID: 117
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000076 RID: 118
		private int int_0;
	}
}
