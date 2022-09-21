using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.GameObject.Listener
{
	// Token: 0x0200011A RID: 282
	public class LogicGameObjectListener
	{
		// Token: 0x06000EB3 RID: 3763 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void Destruct()
		{
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void RefreshPositionFromLogic()
		{
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void RefreshState()
		{
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void RandomizeStartingFrame()
		{
		}

		// Token: 0x06000EB7 RID: 3767 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void Damaged()
		{
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void ResourcesCollected(LogicResourceData data, int count, bool unk)
		{
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void RefreshResourceCount()
		{
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void XpGained(int count)
		{
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void LoadedFromJSON()
		{
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void MapUnlocked()
		{
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void ExtraCharacterAdded(LogicCharacterData character, LogicBuilding baseBuilding)
		{
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void CancelNotification()
		{
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void UnitRemoved(LogicCombatItemData data)
		{
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void PlayEffect(LogicEffectData data)
		{
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void PlayEffect(LogicEffectData data, int offsetX, int offsetY)
		{
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void PlayTargetedEffect(LogicEffectData data, LogicGameObject gameObject, LogicVector2 target)
		{
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void SpottedEnemy()
		{
		}
	}
}
