using System;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000120 RID: 288
	public sealed class LogicComponentFilter : LogicGameObjectFilter
	{
		// Token: 0x06000F48 RID: 3912 RVA: 0x0000A78D File Offset: 0x0000898D
		public void SetComponentType(LogicComponentType type)
		{
			this.logicComponentType_0 = type;
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x0000A796 File Offset: 0x00008996
		public LogicComponentType GetComponentType()
		{
			return this.logicComponentType_0;
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x00002B36 File Offset: 0x00000D36
		public override bool IsComponentFilter()
		{
			return true;
		}

		// Token: 0x06000F4B RID: 3915 RVA: 0x0000A79E File Offset: 0x0000899E
		public override bool TestGameObject(LogicGameObject gameObject)
		{
			return gameObject.GetComponent(this.logicComponentType_0) != null && base.TestGameObject(gameObject);
		}

		// Token: 0x06000F4C RID: 3916 RVA: 0x0000A7B7 File Offset: 0x000089B7
		public bool TestComponent(LogicComponent component)
		{
			return this.TestGameObject(component.GetParent());
		}

		// Token: 0x0400064C RID: 1612
		private LogicComponentType logicComponentType_0;
	}
}
