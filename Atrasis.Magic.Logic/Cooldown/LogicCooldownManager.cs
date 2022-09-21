using System;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Cooldown
{
	// Token: 0x0200016B RID: 363
	public class LogicCooldownManager
	{
		// Token: 0x060015A7 RID: 5543 RVA: 0x0000E1AD File Offset: 0x0000C3AD
		public LogicCooldownManager()
		{
			this.logicArrayList_0 = new LogicArrayList<LogicCooldown>();
		}

		// Token: 0x060015A8 RID: 5544 RVA: 0x0000E1C0 File Offset: 0x0000C3C0
		public void Destruct()
		{
			this.DeleteCooldowns();
		}

		// Token: 0x060015A9 RID: 5545 RVA: 0x0000E1C8 File Offset: 0x0000C3C8
		public void DeleteCooldowns()
		{
			this.logicArrayList_0.Destruct();
		}

		// Token: 0x060015AA RID: 5546 RVA: 0x00053A5C File Offset: 0x00051C5C
		public void Tick()
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				this.logicArrayList_0[i].Tick();
				if (this.logicArrayList_0[i].GetCooldownSeconds() <= 0)
				{
					this.logicArrayList_0.Remove(i);
				}
			}
		}

		// Token: 0x060015AB RID: 5547 RVA: 0x00053AB0 File Offset: 0x00051CB0
		public void FastForwardTime(int secs)
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				this.logicArrayList_0[i].FastForwardTime(secs);
			}
		}

		// Token: 0x060015AC RID: 5548 RVA: 0x00053AE8 File Offset: 0x00051CE8
		public void Load(LogicJSONObject jsonObject)
		{
			LogicJSONArray jsonarray = jsonObject.GetJSONArray("cooldowns");
			if (jsonarray != null)
			{
				int num = jsonarray.Size();
				for (int i = 0; i < num; i++)
				{
					LogicCooldown logicCooldown = new LogicCooldown();
					logicCooldown.Load(jsonarray.GetJSONObject(i));
					this.logicArrayList_0.Add(logicCooldown);
				}
			}
		}

		// Token: 0x060015AD RID: 5549 RVA: 0x00053B38 File Offset: 0x00051D38
		public void Save(LogicJSONObject jsonObject)
		{
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				this.logicArrayList_0[i].Save(logicJSONObject);
				logicJSONArray.Add(logicJSONObject);
			}
			jsonObject.Put("cooldowns", logicJSONArray);
		}

		// Token: 0x060015AE RID: 5550 RVA: 0x0000E1D5 File Offset: 0x0000C3D5
		public void AddCooldown(int targetGlobalId, int cooldownSecs)
		{
			this.logicArrayList_0.Add(new LogicCooldown(targetGlobalId, cooldownSecs));
		}

		// Token: 0x060015AF RID: 5551 RVA: 0x00053B8C File Offset: 0x00051D8C
		public int GetCooldownSeconds(int targetGlobalId)
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetTargetGlobalId() == targetGlobalId)
				{
					return this.logicArrayList_0[i].GetCooldownSeconds();
				}
			}
			return 0;
		}

		// Token: 0x04000BD2 RID: 3026
		private readonly LogicArrayList<LogicCooldown> logicArrayList_0;
	}
}
