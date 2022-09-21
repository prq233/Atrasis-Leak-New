using System;
using Atrasis.Magic.Logic.GameObject.Listener;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x0200011E RID: 286
	public class LogicComponent
	{
		// Token: 0x06000F37 RID: 3895 RVA: 0x0000A720 File Offset: 0x00008920
		public LogicComponent(LogicGameObject gameObject)
		{
			this.m_parent = gameObject;
			this.m_enabled = true;
		}

		// Token: 0x06000F38 RID: 3896 RVA: 0x0000A736 File Offset: 0x00008936
		public virtual void Destruct()
		{
			this.m_parent.GetLevel().GetComponentManagerAt(this.m_parent.GetVillageType()).RemoveComponent(this);
			this.m_enabled = false;
			this.m_parent = null;
		}

		// Token: 0x06000F39 RID: 3897 RVA: 0x0000A767 File Offset: 0x00008967
		public LogicGameObject GetParent()
		{
			return this.m_parent;
		}

		// Token: 0x06000F3A RID: 3898 RVA: 0x0000A76F File Offset: 0x0000896F
		public LogicGameObjectListener GetParentListener()
		{
			return this.m_parent.GetListener();
		}

		// Token: 0x06000F3B RID: 3899 RVA: 0x0000A77C File Offset: 0x0000897C
		public bool IsEnabled()
		{
			return this.m_enabled;
		}

		// Token: 0x06000F3C RID: 3900 RVA: 0x0000A784 File Offset: 0x00008984
		public void SetEnabled(bool value)
		{
			this.m_enabled = value;
		}

		// Token: 0x06000F3D RID: 3901 RVA: 0x00002465 File Offset: 0x00000665
		public virtual LogicComponentType GetComponentType()
		{
			return LogicComponentType.UNIT_STORAGE;
		}

		// Token: 0x06000F3E RID: 3902 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void RemoveGameObjectReferences(LogicGameObject gameObject)
		{
		}

		// Token: 0x06000F3F RID: 3903 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void FastForwardTime(int time)
		{
		}

		// Token: 0x06000F40 RID: 3904 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void GetChecksum(ChecksumHelper checksum)
		{
		}

		// Token: 0x06000F41 RID: 3905 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void SubTick()
		{
		}

		// Token: 0x06000F42 RID: 3906 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void Tick()
		{
		}

		// Token: 0x06000F43 RID: 3907 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void Load(LogicJSONObject jsonObject)
		{
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
		}

		// Token: 0x06000F45 RID: 3909 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void Save(LogicJSONObject jsonObject, int villageType)
		{
		}

		// Token: 0x06000F46 RID: 3910 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void SaveToSnapshot(LogicJSONObject jsonObject, int layoutId)
		{
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void LoadingFinished()
		{
		}

		// Token: 0x04000637 RID: 1591
		public const int COMPONENT_TYPE_COUNT = 17;

		// Token: 0x04000638 RID: 1592
		protected bool m_enabled;

		// Token: 0x04000639 RID: 1593
		protected LogicGameObject m_parent;
	}
}
