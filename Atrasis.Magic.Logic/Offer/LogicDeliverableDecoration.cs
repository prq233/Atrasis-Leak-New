using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x0200001B RID: 27
	public class LogicDeliverableDecoration : LogicDeliverable
	{
		// Token: 0x06000121 RID: 289 RVA: 0x00002C05 File Offset: 0x00000E05
		public override void Destruct()
		{
			base.Destruct();
			this.logicDecoData_0 = null;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00002C14 File Offset: 0x00000E14
		public override void WriteToJSON(LogicJSONObject jsonObject)
		{
			base.WriteToJSON(jsonObject);
			LogicJSONHelper.SetLogicData(jsonObject, "decoration", this.logicDecoData_0);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00002C2E File Offset: 0x00000E2E
		public override void ReadFromJSON(LogicJSONObject jsonObject)
		{
			base.ReadFromJSON(jsonObject);
			this.logicDecoData_0 = (LogicDecoData)LogicJSONHelper.GetLogicData(jsonObject, "decoration");
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00002C4D File Offset: 0x00000E4D
		public override int GetDeliverableType()
		{
			return 3;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00002C50 File Offset: 0x00000E50
		public override bool Deliver(LogicLevel level)
		{
			if (this.CanBeDeliver(level))
			{
				level.AddUnplacedObject(new LogicDataSlot(this.logicDecoData_0, 0));
				return true;
			}
			return false;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00002C70 File Offset: 0x00000E70
		public override bool CanBeDeliver(LogicLevel level)
		{
			return level.GetObjectCount(this.logicDecoData_0, this.logicDecoData_0.GetVillageType()) < this.logicDecoData_0.GetMaxCount();
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00002C96 File Offset: 0x00000E96
		public override LogicDeliverableBundle Compensate(LogicLevel level)
		{
			LogicDeliverableBundle logicDeliverableBundle = new LogicDeliverableBundle();
			logicDeliverableBundle.AddResources(this.logicDecoData_0.GetBuildResource(), this.logicDecoData_0.GetBuildCost());
			return logicDeliverableBundle;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00002CB9 File Offset: 0x00000EB9
		public LogicDecoData GetDecorationData()
		{
			return this.logicDecoData_0;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00002CC1 File Offset: 0x00000EC1
		public void SetDecorationData(LogicDecoData data)
		{
			this.logicDecoData_0 = data;
		}

		// Token: 0x04000073 RID: 115
		private LogicDecoData logicDecoData_0;
	}
}
