using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x02000019 RID: 25
	public class LogicDeliverableBuilding : LogicDeliverable
	{
		// Token: 0x06000107 RID: 263 RVA: 0x00002B39 File Offset: 0x00000D39
		public override void Destruct()
		{
			base.Destruct();
			this.logicBuildingData_0 = null;
			this.int_1 = 0;
			this.int_0 = 0;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00017194 File Offset: 0x00015394
		public override void WriteToJSON(LogicJSONObject jsonObject)
		{
			base.WriteToJSON(jsonObject);
			LogicJSONHelper.SetLogicData(jsonObject, "building", this.logicBuildingData_0);
			jsonObject.Put("buildingNumber", new LogicJSONNumber(this.int_1));
			jsonObject.Put("buildingLevel", new LogicJSONNumber(this.int_0));
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000171E8 File Offset: 0x000153E8
		public override void ReadFromJSON(LogicJSONObject jsonObject)
		{
			base.ReadFromJSON(jsonObject);
			this.logicBuildingData_0 = (LogicBuildingData)LogicJSONHelper.GetLogicData(jsonObject, "building");
			this.int_1 = LogicJSONHelper.GetInt(jsonObject, "buildingNumber");
			this.int_0 = LogicJSONHelper.GetInt(jsonObject, "buildingLevel");
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00002B56 File Offset: 0x00000D56
		public override int GetDeliverableType()
		{
			return 2;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00002B59 File Offset: 0x00000D59
		public override bool Deliver(LogicLevel level)
		{
			if (this.CanBeDeliver(level))
			{
				level.AddUnplacedObject(new LogicDataSlot(this.logicBuildingData_0, this.int_0));
				return true;
			}
			return false;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00017234 File Offset: 0x00015434
		public override bool CanBeDeliver(LogicLevel level)
		{
			int objectCount = level.GetObjectCount(this.logicBuildingData_0, this.logicBuildingData_0.GetVillageType());
			int unlockedBuildingCount = LogicDataTables.GetTownHallLevel((this.logicBuildingData_0.GetVillageType() == 1) ? level.GetHomeOwnerAvatar().GetVillage2TownHallLevel() : level.GetHomeOwnerAvatar().GetTownHallLevel()).GetUnlockedBuildingCount(this.logicBuildingData_0);
			return (objectCount < unlockedBuildingCount && this.int_1 == 0) || this.int_1 == objectCount + 1;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000172AC File Offset: 0x000154AC
		public override LogicDeliverableBundle Compensate(LogicLevel level)
		{
			LogicDeliverableBundle logicDeliverableBundle = new LogicDeliverableBundle();
			if (this.logicBuildingData_0.IsWorkerBuilding())
			{
				logicDeliverableBundle.AddResources(this.logicBuildingData_0.GetBuildResource(0), LogicDataTables.GetGlobals().GetWorkerCost(level));
			}
			else
			{
				for (int i = 0; i <= this.int_0; i++)
				{
					logicDeliverableBundle.AddResources(this.logicBuildingData_0.GetBuildResource(i), this.logicBuildingData_0.GetBuildCost(i, level));
				}
			}
			return logicDeliverableBundle;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00002B7E File Offset: 0x00000D7E
		public LogicBuildingData GetBuildingData()
		{
			return this.logicBuildingData_0;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00002B86 File Offset: 0x00000D86
		public void SetBuildingData(LogicBuildingData data)
		{
			this.logicBuildingData_0 = data;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00002B8F File Offset: 0x00000D8F
		public int GetBuildingLevel()
		{
			return this.int_0;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00002B97 File Offset: 0x00000D97
		public void SetBuildingLevel(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00002BA0 File Offset: 0x00000DA0
		public int GetBuildingCount()
		{
			return this.int_1;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00002BA8 File Offset: 0x00000DA8
		public void SetBuildingCount(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x0400006F RID: 111
		private LogicBuildingData logicBuildingData_0;

		// Token: 0x04000070 RID: 112
		private int int_0;

		// Token: 0x04000071 RID: 113
		private int int_1;
	}
}
