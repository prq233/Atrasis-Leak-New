using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;

namespace Atrasis.Magic.Logic
{
	// Token: 0x02000004 RID: 4
	public class LogicTargetList
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00012078 File Offset: 0x00010278
		public LogicTargetList()
		{
			this.logicGameObject_0 = new LogicGameObject[10];
			this.int_2 = new int[10];
			this.Clear();
			this.int_0 = LogicDataTables.GetGlobals().GetCharVersusCharRandomDistanceLimit();
			this.int_1 = LogicDataTables.GetGlobals().GetTargetListSize();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002125 File Offset: 0x00000325
		public void Destruct()
		{
			this.Clear();
			this.int_0 = 0;
			this.int_1 = 3;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000120CC File Offset: 0x000102CC
		public void Clear()
		{
			for (int i = 0; i < 10; i++)
			{
				this.logicGameObject_0[i] = null;
				this.int_2[i] = int.MaxValue;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000120FC File Offset: 0x000102FC
		public LogicGameObject EvaluateTargets(LogicMovementComponent component)
		{
			if (component == null || component.IsFlying() || this.int_1 <= 1)
			{
				return this.logicGameObject_0[0];
			}
			bool flag = true;
			int num = 0;
			int num2 = int.MaxValue;
			int num3 = 0;
			LogicGameObject result = null;
			for (int i = 0; i < this.int_1; i++)
			{
				LogicGameObject logicGameObject = this.logicGameObject_0[i];
				if (logicGameObject != null)
				{
					LogicCombatComponent combatComponent = component.GetParent().GetCombatComponent();
					if (combatComponent != null && combatComponent.IsInRange(logicGameObject))
					{
						return logicGameObject;
					}
					int num4 = component.EvaluateTargetCost(logicGameObject);
					if (logicGameObject.GetMovementComponent() == null)
					{
						flag = false;
					}
					if (num4 > num3)
					{
						num3 = num4;
					}
					if (num4 < num2)
					{
						num2 = num4;
						result = logicGameObject;
					}
					num++;
				}
			}
			if (num >= 2 && flag && num2 != 2147483647 && num3 - num2 < this.int_0)
			{
				return this.logicGameObject_0[component.GetParent().GetGlobalID() % num];
			}
			return result;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000121E4 File Offset: 0x000103E4
		public void AddCandidate(LogicGameObject target, int cost)
		{
			int num = -1;
			for (int i = 0; i < this.int_1; i++)
			{
				if (this.int_2[i] > cost)
				{
					num = i;
					IL_22:
					if (num != -1)
					{
						Array.Copy(this.logicGameObject_0, num, this.logicGameObject_0, num + 1, this.int_1 - num);
						Array.Copy(this.int_2, num, this.int_2, num + 1, this.int_1 - num);
						this.logicGameObject_0[num] = target;
						this.int_2[num] = cost;
					}
					return;
				}
			}
			goto IL_22;
		}

		// Token: 0x04000019 RID: 25
		private int int_0;

		// Token: 0x0400001A RID: 26
		private int int_1;

		// Token: 0x0400001B RID: 27
		private readonly LogicGameObject[] logicGameObject_0;

		// Token: 0x0400001C RID: 28
		private readonly int[] int_2;
	}
}
