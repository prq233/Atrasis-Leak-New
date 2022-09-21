using System;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x02000113 RID: 275
	public class LogicGameObjectFilter
	{
		// Token: 0x06000DBD RID: 3517 RVA: 0x00009AC2 File Offset: 0x00007CC2
		public LogicGameObjectFilter()
		{
			this.int_0 = -1;
		}

		// Token: 0x06000DBE RID: 3518 RVA: 0x00009AD1 File Offset: 0x00007CD1
		public virtual void Destruct()
		{
			this.bool_1 = null;
			if (this.logicArrayList_0 != null)
			{
				this.logicArrayList_0.Destruct();
				this.logicArrayList_0 = null;
			}
		}

		// Token: 0x06000DBF RID: 3519 RVA: 0x00009AF4 File Offset: 0x00007CF4
		public bool ContainsGameObjectType(int type)
		{
			return this.bool_1 == null || this.bool_1[type];
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x00009B08 File Offset: 0x00007D08
		public void AddGameObjectType(LogicGameObjectType type)
		{
			if (this.bool_1 == null)
			{
				this.bool_1 = new bool[9];
			}
			this.bool_1[(int)type] = true;
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x00030BDC File Offset: 0x0002EDDC
		public virtual bool TestGameObject(LogicGameObject gameObject)
		{
			if (this.bool_1 != null && !this.bool_1[(int)gameObject.GetGameObjectType()])
			{
				return false;
			}
			if (this.logicArrayList_0 != null && this.logicArrayList_0.IndexOf(gameObject) != -1)
			{
				return false;
			}
			if (this.int_0 != -1)
			{
				LogicHitpointComponent hitpointComponent = gameObject.GetHitpointComponent();
				if (hitpointComponent != null)
				{
					bool flag;
					return hitpointComponent.GetHitpoints() > 0 && ((flag = hitpointComponent.IsEnemyForTeam(this.int_0)) || !this.bool_0) && (this.bool_0 || !flag);
				}
			}
			return true;
		}

		// Token: 0x06000DC2 RID: 3522 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool IsComponentFilter()
		{
			return false;
		}

		// Token: 0x06000DC3 RID: 3523 RVA: 0x00030C64 File Offset: 0x0002EE64
		public void PassEnemyOnly(LogicGameObject gameObject)
		{
			LogicHitpointComponent hitpointComponent = gameObject.GetHitpointComponent();
			if (hitpointComponent != null)
			{
				this.int_0 = hitpointComponent.GetTeam();
				this.bool_0 = true;
				return;
			}
			this.int_0 = -1;
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x00030C98 File Offset: 0x0002EE98
		public void PassFriendlyOnly(LogicGameObject gameObject)
		{
			LogicHitpointComponent hitpointComponent = gameObject.GetHitpointComponent();
			if (hitpointComponent != null)
			{
				this.int_0 = hitpointComponent.GetTeam();
				this.bool_0 = false;
				return;
			}
			this.int_0 = -1;
		}

		// Token: 0x06000DC5 RID: 3525 RVA: 0x00009B28 File Offset: 0x00007D28
		public void RemoveAllIgnoreObjects()
		{
			if (this.logicArrayList_0 != null)
			{
				this.logicArrayList_0.Destruct();
				this.logicArrayList_0 = null;
			}
		}

		// Token: 0x06000DC6 RID: 3526 RVA: 0x00009B44 File Offset: 0x00007D44
		public void AddIgnoreObject(LogicGameObject gameObject)
		{
			if (this.logicArrayList_0 == null)
			{
				this.logicArrayList_0 = new LogicArrayList<LogicGameObject>();
			}
			this.logicArrayList_0.Add(gameObject);
		}

		// Token: 0x0400055E RID: 1374
		private int int_0;

		// Token: 0x0400055F RID: 1375
		private bool bool_0;

		// Token: 0x04000560 RID: 1376
		private bool[] bool_1;

		// Token: 0x04000561 RID: 1377
		private LogicArrayList<LogicGameObject> logicArrayList_0;
	}
}
