using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x0200001F RID: 31
	public class LogicDeliverableScaledMultiplier : LogicDeliverable
	{
		// Token: 0x0600013E RID: 318 RVA: 0x00002DCA File Offset: 0x00000FCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00002DD2 File Offset: 0x00000FD2
		public override void WriteToJSON(LogicJSONObject jsonObject)
		{
			base.WriteToJSON(jsonObject);
			LogicJSONHelper.SetLogicData(jsonObject, "scaledResource", this.logicResourceData_0);
			jsonObject.Put("scaledResourceMultiplier", new LogicJSONNumber(this.int_0));
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00002E02 File Offset: 0x00001002
		public override void ReadFromJSON(LogicJSONObject jsonObject)
		{
			base.ReadFromJSON(jsonObject);
			this.logicResourceData_0 = (LogicResourceData)LogicJSONHelper.GetLogicData(jsonObject, "scaledResource");
			this.int_0 = LogicJSONHelper.GetInt(jsonObject, "scaledResourceMultiplier");
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00002E32 File Offset: 0x00001032
		public override int GetDeliverableType()
		{
			return 7;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000175A0 File Offset: 0x000157A0
		public override bool Deliver(LogicLevel level)
		{
			LogicAvatar homeOwnerAvatar = level.GetHomeOwnerAvatar();
			int count = homeOwnerAvatar.GetResourceCount(this.logicResourceData_0) + this.int_0;
			homeOwnerAvatar.SetResourceCount(this.logicResourceData_0, count);
			homeOwnerAvatar.GetChangeListener().CommodityCountChanged(0, this.logicResourceData_0, count);
			return true;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00002B36 File Offset: 0x00000D36
		public override bool CanBeDeliver(LogicLevel level)
		{
			return true;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00002E35 File Offset: 0x00001035
		public LogicResourceData GetScaledResourceData()
		{
			return this.logicResourceData_0;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00002E3D File Offset: 0x0000103D
		public void SetScaledResourceData(LogicResourceData data)
		{
			this.logicResourceData_0 = data;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00002E46 File Offset: 0x00001046
		public int GetScaledResourceMultiplier()
		{
			return this.int_0;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00002E4E File Offset: 0x0000104E
		public void SetScaledResourceMultiplier(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000077 RID: 119
		private LogicResourceData logicResourceData_0;

		// Token: 0x04000078 RID: 120
		private int int_0;
	}
}
