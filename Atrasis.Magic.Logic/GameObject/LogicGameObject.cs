using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.GameObject.Listener;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x02000110 RID: 272
	public class LogicGameObject
	{
		// Token: 0x06000D66 RID: 3430 RVA: 0x000302C0 File Offset: 0x0002E4C0
		public LogicGameObject(LogicGameObjectData data, LogicLevel level, int villageType)
		{
			Debugger.DoAssert(villageType < 2, "VillageType not set! Game object has not been added to LogicGameObjectManager.");
			this.m_data = data;
			this.m_level = level;
			this.m_villageType = villageType;
			this.m_position = new LogicVector2();
			this.m_listener = new LogicGameObjectListener();
			this.m_components = new LogicComponent[17];
		}

		// Token: 0x06000D67 RID: 3431 RVA: 0x0003031C File Offset: 0x0002E51C
		public virtual void Destruct()
		{
			if (this.m_level != null)
			{
				this.m_level.GetTileMap().RemoveGameObject(this);
			}
			for (int i = 0; i < 17; i++)
			{
				if (this.m_components[i] != null)
				{
					this.m_components[i].Destruct();
					this.m_components[i] = null;
				}
			}
			if (this.m_position != null)
			{
				this.m_position.Destruct();
				this.m_position = null;
			}
			if (this.m_listener != null)
			{
				this.m_listener.Destruct();
				this.m_listener = null;
			}
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void RemoveGameObjectReferences(LogicGameObject gameObject)
		{
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x000098C9 File Offset: 0x00007AC9
		public virtual void DeathEvent()
		{
			this.m_level.GetTileMap().RefreshPassable(this);
			if (this.m_listener != null)
			{
				this.m_listener.RefreshState();
			}
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void SpawnEvent(LogicCharacterData data, int count, int upgLevel)
		{
		}

		// Token: 0x06000D6B RID: 3435 RVA: 0x000303A4 File Offset: 0x0002E5A4
		public void AddComponent(LogicComponent component)
		{
			LogicComponentType componentType = component.GetComponentType();
			if (this.m_components[(int)componentType] == null)
			{
				this.m_level.GetComponentManagerAt(this.m_villageType).AddComponent(component);
				this.m_components[(int)componentType] = component;
				return;
			}
			Debugger.Error("LogicGameObject::addComponent - Component is already added.");
		}

		// Token: 0x06000D6C RID: 3436 RVA: 0x000303F0 File Offset: 0x0002E5F0
		public void EnableComponent(LogicComponentType componentType, bool enable)
		{
			LogicComponent logicComponent = this.m_components[(int)componentType];
			if (logicComponent != null)
			{
				logicComponent.SetEnabled(enable);
			}
		}

		// Token: 0x06000D6D RID: 3437 RVA: 0x000098EF File Offset: 0x00007AEF
		public int GetX()
		{
			return this.m_position.m_x;
		}

		// Token: 0x06000D6E RID: 3438 RVA: 0x000098FC File Offset: 0x00007AFC
		public int GetY()
		{
			return this.m_position.m_y;
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x00009909 File Offset: 0x00007B09
		public int GetTileX()
		{
			return this.m_position.m_x >> 9;
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x00009919 File Offset: 0x00007B19
		public virtual int GetMidX()
		{
			return this.m_position.m_x + (this.GetWidthInTiles() << 8);
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x0000992F File Offset: 0x00007B2F
		public int GetTileY()
		{
			return this.m_position.m_y >> 9;
		}

		// Token: 0x06000D72 RID: 3442 RVA: 0x0000993F File Offset: 0x00007B3F
		public virtual int GetMidY()
		{
			return this.m_position.m_y + (this.GetHeightInTiles() << 8);
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x00030410 File Offset: 0x0002E610
		public int GetDistanceSquaredTo(LogicGameObject gameObject)
		{
			int num = this.GetMidX() - gameObject.GetMidX();
			int num2 = this.GetMidY() - gameObject.GetMidY();
			return num * num + num2 * num2;
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x00009955 File Offset: 0x00007B55
		public int GetVillageType()
		{
			return this.m_villageType;
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x0000995D File Offset: 0x00007B5D
		public int GetGlobalID()
		{
			return this.m_globalId;
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x00009965 File Offset: 0x00007B65
		public LogicGameObjectData GetData()
		{
			return this.m_data;
		}

		// Token: 0x06000D77 RID: 3447 RVA: 0x0000996D File Offset: 0x00007B6D
		public LogicLevel GetLevel()
		{
			return this.m_level;
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x00009975 File Offset: 0x00007B75
		public LogicGameObjectListener GetListener()
		{
			return this.m_listener;
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x00030440 File Offset: 0x0002E640
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public LogicComponent GetComponent(LogicComponentType componentType)
		{
			LogicComponent logicComponent = this.m_components[(int)componentType];
			if (logicComponent != null && logicComponent.IsEnabled())
			{
				return logicComponent;
			}
			return null;
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x00030464 File Offset: 0x0002E664
		public LogicCombatComponent GetCombatComponent(bool enabledOnly)
		{
			LogicCombatComponent logicCombatComponent = (LogicCombatComponent)this.m_components[1];
			if (logicCombatComponent != null && (!enabledOnly || logicCombatComponent.IsEnabled()))
			{
				return logicCombatComponent;
			}
			return null;
		}

		// Token: 0x06000D7B RID: 3451 RVA: 0x0000997D File Offset: 0x00007B7D
		public LogicCombatComponent GetCombatComponent()
		{
			return (LogicCombatComponent)this.GetComponent(LogicComponentType.COMBAT);
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x0000998B File Offset: 0x00007B8B
		public LogicHitpointComponent GetHitpointComponent()
		{
			return (LogicHitpointComponent)this.GetComponent(LogicComponentType.HITPOINT);
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x00009999 File Offset: 0x00007B99
		public LogicMovementComponent GetMovementComponent()
		{
			return (LogicMovementComponent)this.GetComponent(LogicComponentType.MOVEMENT);
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x000099A7 File Offset: 0x00007BA7
		public LogicResourceProductionComponent GetResourceProductionComponent()
		{
			return (LogicResourceProductionComponent)this.GetComponent(LogicComponentType.RESOURCE_PRODUCTION);
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x000099B5 File Offset: 0x00007BB5
		public LogicBunkerComponent GetBunkerComponent()
		{
			return (LogicBunkerComponent)this.GetComponent(LogicComponentType.BUNKER);
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x000099C3 File Offset: 0x00007BC3
		public LogicTriggerComponent GetTriggerComponent()
		{
			return (LogicTriggerComponent)this.GetComponent(LogicComponentType.TRIGGER);
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x000099D1 File Offset: 0x00007BD1
		public LogicLayoutComponent GetLayoutComponent()
		{
			return (LogicLayoutComponent)this.GetComponent(LogicComponentType.LAYOUT);
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x000099E0 File Offset: 0x00007BE0
		public LogicDefenceUnitProductionComponent GetDefenceUnitProduction()
		{
			return (LogicDefenceUnitProductionComponent)this.GetComponent(LogicComponentType.DEFENCE_UNIT_PRODUCTION);
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x000099EF File Offset: 0x00007BEF
		public void RemoveComponent(LogicComponentType componentType)
		{
			if (this.m_components[(int)componentType] != null)
			{
				this.m_components[(int)componentType].Destruct();
				this.m_components[(int)componentType] = null;
			}
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x00030490 File Offset: 0x0002E690
		public void Shrink(int time, int speedBoost)
		{
			LogicCombatComponent combatComponent = this.GetCombatComponent();
			if (combatComponent != null)
			{
				combatComponent.Boost(0, speedBoost, time);
			}
			LogicMovementComponent movementComponent = this.GetMovementComponent();
			if (movementComponent != null)
			{
				movementComponent.GetMovementSystem().Boost(speedBoost, time * 4);
			}
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x000304CC File Offset: 0x0002E6CC
		public void Freeze(int time, int delay)
		{
			if (this.int_0 > 0 && this.int_1 == 0)
			{
				this.int_0 = LogicMath.Max(time - delay, this.int_0);
				return;
			}
			if (this.int_1 > 0)
			{
				this.int_1 = LogicMath.Max(delay, this.int_1);
				this.int_0 = LogicMath.Max(time, this.int_0);
				return;
			}
			this.int_0 = time;
			this.int_1 = delay;
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x0003053C File Offset: 0x0002E73C
		public bool IsFrozen()
		{
			if (this.int_0 > 0 && this.int_1 == 0)
			{
				LogicMovementComponent movementComponent = this.GetMovementComponent();
				return movementComponent == null || !movementComponent.IsInNotPassablePosition();
			}
			return false;
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x00009A11 File Offset: 0x00007C11
		public bool IsPreventsHealing()
		{
			return this.int_3 > 0;
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x00009A1C File Offset: 0x00007C1C
		public bool IsDamagedRecently()
		{
			return this.int_2 > 0;
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x00009A27 File Offset: 0x00007C27
		public bool IsStealthy()
		{
			return this.int_4 > 0;
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x00009A32 File Offset: 0x00007C32
		public void SetStealthTime(int time)
		{
			this.int_4 = time;
		}

		// Token: 0x06000D8B RID: 3467 RVA: 0x00009A3B File Offset: 0x00007C3B
		public void SetDamageTime(int time)
		{
			this.int_2 = time;
		}

		// Token: 0x06000D8C RID: 3468 RVA: 0x00009A44 File Offset: 0x00007C44
		public void SetPreventsHealingTime(int time)
		{
			this.int_3 = time;
		}

		// Token: 0x06000D8D RID: 3469 RVA: 0x00009A4D File Offset: 0x00007C4D
		public LogicComponentManager GetComponentManager()
		{
			return this.m_level.GetComponentManagerAt(this.m_villageType);
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x00009A60 File Offset: 0x00007C60
		public LogicGameObjectManager GetGameObjectManager()
		{
			return this.m_level.GetGameObjectManagerAt(this.m_villageType);
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x00009A73 File Offset: 0x00007C73
		public void RefreshPassable()
		{
			this.m_level.GetTileMap().RefreshPassable(this);
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x00009A86 File Offset: 0x00007C86
		public LogicVector2 GetPosition()
		{
			return this.m_position;
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x00009A8E File Offset: 0x00007C8E
		public void SetPosition(LogicVector2 vector2)
		{
			this.m_position.Set(vector2.m_x, vector2.m_y);
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x00030574 File Offset: 0x0002E774
		public void SetPositionXY(int x, int y)
		{
			if (this.m_position.m_x != x || this.m_position.m_y != y)
			{
				int tileX = this.GetTileX();
				int tileY = this.GetTileY();
				this.m_position.Set(x, y);
				LogicLayoutComponent layoutComponent = this.GetLayoutComponent();
				if (layoutComponent != null)
				{
					layoutComponent.SetPositionLayout(this.m_level.GetActiveLayout(), x >> 9, y >> 9);
				}
				if (this.m_globalId != 0)
				{
					this.m_level.GetTileMap().GameObjectMoved(this, tileX, tileY);
				}
			}
		}

		// Token: 0x06000D93 RID: 3475 RVA: 0x000305F8 File Offset: 0x0002E7F8
		public LogicVector2 GetPositionLayout(int layoutId, bool editMode)
		{
			LogicLayoutComponent layoutComponent = this.GetLayoutComponent();
			Debugger.DoAssert(layoutComponent != null, "LayoutComponent is null");
			if (editMode)
			{
				return layoutComponent.GetEditModePositionLayout(layoutId);
			}
			return layoutComponent.GetPositionLayout(layoutId);
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x00030630 File Offset: 0x0002E830
		public void SetPositionLayoutXY(int tileX, int tileY, int activeLayout, bool editMode)
		{
			if (this.m_components[13] != null)
			{
				LogicLayoutComponent logicLayoutComponent = (LogicLayoutComponent)this.m_components[13];
				if (logicLayoutComponent.IsEnabled())
				{
					if (editMode)
					{
						logicLayoutComponent.SetEditModePositionLayout(activeLayout, tileX, tileY);
						return;
					}
					logicLayoutComponent.SetPositionLayout(activeLayout, tileX, tileY);
				}
			}
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x00009AA7 File Offset: 0x00007CA7
		public void SetGlobalID(int globalId)
		{
			this.m_globalId = globalId;
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x00009AB0 File Offset: 0x00007CB0
		public void SetSeed(int seed)
		{
			this.m_seed = seed;
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x00030678 File Offset: 0x0002E878
		public int Rand(int rnd)
		{
			int num = this.m_seed + rnd;
			if (num == 0)
			{
				num = -1;
			}
			int num2 = num ^ num << 14 ^ (num ^ num << 14) >> 16;
			return (num2 ^ 32 * num2) & int.MaxValue;
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x00009AB9 File Offset: 0x00007CB9
		public void SetListener(LogicGameObjectListener listener)
		{
			this.m_listener = listener;
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x000306B0 File Offset: 0x0002E8B0
		public void XpGainHelper(int xp, LogicAvatar homeOwnerAvatar, bool inHomeState)
		{
			LogicClientAvatar playerAvatar = this.m_level.GetPlayerAvatar();
			if (!homeOwnerAvatar.IsInExpLevelCap() && (homeOwnerAvatar == playerAvatar && this.m_level.GetState() == 1 && inHomeState) && this.m_listener != null)
			{
				this.m_listener.XpGained(xp);
			}
			homeOwnerAvatar.XpGainHelper(xp);
		}

		// Token: 0x06000D9A RID: 3482 RVA: 0x00030708 File Offset: 0x0002E908
		public virtual void SetInitialPosition(int x, int y)
		{
			this.m_position.Set(x, y);
			LogicLayoutComponent layoutComponent = this.GetLayoutComponent();
			if (layoutComponent != null && this.m_level != null)
			{
				layoutComponent.SetPositionLayout(this.m_level.GetActiveLayout(), x >> 9, y >> 9);
			}
		}

		// Token: 0x06000D9B RID: 3483 RVA: 0x00002465 File Offset: 0x00000665
		public virtual int GetDirection()
		{
			return 0;
		}

		// Token: 0x06000D9C RID: 3484 RVA: 0x00002B36 File Offset: 0x00000D36
		public virtual int PassableSubtilesAtEdge()
		{
			return 1;
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x00002465 File Offset: 0x00000665
		public virtual LogicGameObjectType GetGameObjectType()
		{
			return LogicGameObjectType.BUILDING;
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x00002B36 File Offset: 0x00000D36
		public virtual bool IsStaticObject()
		{
			return true;
		}

		// Token: 0x06000D9F RID: 3487 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool IsHidden()
		{
			return false;
		}

		// Token: 0x06000DA0 RID: 3488 RVA: 0x00030750 File Offset: 0x0002E950
		public bool IsAlive()
		{
			LogicHitpointComponent hitpointComponent = this.GetHitpointComponent();
			return hitpointComponent == null || hitpointComponent.GetHitpoints() > 0;
		}

		// Token: 0x06000DA1 RID: 3489 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool IsBuilding()
		{
			return false;
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x00030774 File Offset: 0x0002E974
		public virtual bool IsFlying()
		{
			LogicMovementComponent movementComponent = this.GetMovementComponent();
			return movementComponent != null && movementComponent.IsFlying();
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x00002B36 File Offset: 0x00000D36
		public virtual bool IsPassable()
		{
			return true;
		}

		// Token: 0x06000DA4 RID: 3492 RVA: 0x00002B36 File Offset: 0x00000D36
		public virtual bool IsUnbuildable()
		{
			return true;
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool IsWall()
		{
			return false;
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool IsHero()
		{
			return false;
		}

		// Token: 0x06000DA7 RID: 3495 RVA: 0x00002465 File Offset: 0x00000665
		public virtual int PathFinderCost()
		{
			return 0;
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x00002B36 File Offset: 0x00000D36
		public virtual int GetHeightInTiles()
		{
			return 1;
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x00002B36 File Offset: 0x00000D36
		public virtual int GetWidthInTiles()
		{
			return 1;
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x00002465 File Offset: 0x00000665
		public virtual int GetRemainingBoostTime()
		{
			return 0;
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool IsBoostPaused()
		{
			return false;
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void StopBoost()
		{
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x00002B30 File Offset: 0x00000D30
		public virtual int GetMaxFastForwardTime()
		{
			return -1;
		}

		// Token: 0x06000DAE RID: 3502 RVA: 0x00002465 File Offset: 0x00000665
		public virtual bool ShouldDestruct()
		{
			return false;
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x00002465 File Offset: 0x00000665
		public virtual int GetStrengthWeight()
		{
			return 0;
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x00030794 File Offset: 0x0002E994
		public virtual void FastForwardTime(int secs)
		{
			for (int i = 0; i < 17; i++)
			{
				LogicComponent logicComponent = this.m_components[i];
				if (logicComponent != null && logicComponent.IsEnabled())
				{
					logicComponent.FastForwardTime(secs);
				}
			}
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void FastForwardBoost(int secs)
		{
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x00002465 File Offset: 0x00000665
		public virtual int GetHitEffectOffset()
		{
			return 0;
		}

		// Token: 0x06000DB3 RID: 3507 RVA: 0x000307CC File Offset: 0x0002E9CC
		public virtual void GetChecksum(ChecksumHelper checksum, bool includeGameObjects)
		{
			if (includeGameObjects)
			{
				checksum.StartObject("LogicGameObject");
				checksum.WriteValue("type", (int)this.GetGameObjectType());
				checksum.WriteValue("globalID", this.m_globalId);
				checksum.WriteValue("dataGlobalID", this.m_data.GetGlobalID());
				checksum.WriteValue("x", this.GetX());
				checksum.WriteValue("y", this.GetY());
				checksum.WriteValue("seed", this.m_seed);
				LogicHitpointComponent hitpointComponent = this.GetHitpointComponent();
				if (hitpointComponent != null)
				{
					checksum.WriteValue("m_hp", hitpointComponent.GetHitpoints());
					checksum.WriteValue("m_maxHP", hitpointComponent.GetMaxHitpoints());
				}
				LogicCombatComponent combatComponent = this.GetCombatComponent();
				if (combatComponent != null)
				{
					LogicGameObject target = combatComponent.GetTarget(0);
					if (target != null)
					{
						checksum.WriteValue("target", target.GetGlobalID());
					}
				}
				checksum.EndObject();
			}
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void SubTick()
		{
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x000308B0 File Offset: 0x0002EAB0
		public virtual void Tick()
		{
			if (this.int_0 > 0 && this.int_1 == 0)
			{
				this.int_0--;
			}
			else if (this.int_1 > 0)
			{
				this.int_1--;
			}
			if (this.int_3 > 0)
			{
				this.int_3--;
			}
			if (this.int_4 > 0)
			{
				this.int_4--;
			}
			if (this.int_2 > 0)
			{
				this.int_2--;
			}
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x0003093C File Offset: 0x0002EB3C
		public virtual void Load(LogicJSONObject jsonObject)
		{
			this.LoadPosition(jsonObject);
			for (int i = 0; i < 17; i++)
			{
				LogicComponent logicComponent = this.m_components[i];
				if (logicComponent != null)
				{
					logicComponent.Load(jsonObject);
				}
			}
		}

		// Token: 0x06000DB7 RID: 3511 RVA: 0x00030970 File Offset: 0x0002EB70
		public virtual void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("x");
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("y");
			if (jsonnumber == null || jsonnumber2 == null)
			{
				Debugger.Error("LogicGameObject::load - x or y is NULL!");
			}
			this.SetInitialPosition(jsonnumber.GetIntValue() << 9, jsonnumber2.GetIntValue() << 9);
			for (int i = 0; i < 17; i++)
			{
				LogicComponent logicComponent = this.m_components[i];
				if (logicComponent != null)
				{
					logicComponent.LoadFromSnapshot(jsonObject);
				}
			}
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x000309E0 File Offset: 0x0002EBE0
		public void LoadPosition(LogicJSONObject jsonObject)
		{
			LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber("x");
			LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber("y");
			if (jsonnumber == null || jsonnumber2 == null)
			{
				Debugger.Error("LogicGameObject::load - x or y is NULL!");
			}
			this.SetInitialPosition(jsonnumber.GetIntValue() << 9, jsonnumber2.GetIntValue() << 9);
		}

		// Token: 0x06000DB9 RID: 3513 RVA: 0x00030A30 File Offset: 0x0002EC30
		public virtual void Save(LogicJSONObject jsonObject, int villageType)
		{
			jsonObject.Put("x", new LogicJSONNumber(this.GetTileX() & 63));
			jsonObject.Put("y", new LogicJSONNumber(this.GetTileY() & 63));
			for (int i = 0; i < 17; i++)
			{
				LogicComponent logicComponent = this.m_components[i];
				if (logicComponent != null)
				{
					logicComponent.Save(jsonObject, villageType);
				}
			}
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x00030A90 File Offset: 0x0002EC90
		public virtual void SaveToSnapshot(LogicJSONObject jsonObject, int layoutId)
		{
			for (int i = 0; i < 17; i++)
			{
				LogicComponent logicComponent = this.m_components[i];
				if (logicComponent != null)
				{
					logicComponent.SaveToSnapshot(jsonObject, layoutId);
				}
			}
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x00030AC0 File Offset: 0x0002ECC0
		public virtual void LoadingFinished()
		{
			for (int i = 0; i < 17; i++)
			{
				LogicComponent logicComponent = this.m_components[i];
				if (logicComponent != null)
				{
					logicComponent.LoadingFinished();
				}
			}
		}

		// Token: 0x04000546 RID: 1350
		public const int GAMEOBJECT_TYPE_COUNT = 9;

		// Token: 0x04000547 RID: 1351
		protected readonly LogicGameObjectData m_data;

		// Token: 0x04000548 RID: 1352
		protected readonly LogicLevel m_level;

		// Token: 0x04000549 RID: 1353
		protected readonly LogicComponent[] m_components;

		// Token: 0x0400054A RID: 1354
		protected LogicVector2 m_position;

		// Token: 0x0400054B RID: 1355
		protected LogicGameObjectListener m_listener;

		// Token: 0x0400054C RID: 1356
		protected int m_villageType;

		// Token: 0x0400054D RID: 1357
		protected int m_globalId;

		// Token: 0x0400054E RID: 1358
		protected int m_seed;

		// Token: 0x0400054F RID: 1359
		private int int_0;

		// Token: 0x04000550 RID: 1360
		private int int_1;

		// Token: 0x04000551 RID: 1361
		private int int_2;

		// Token: 0x04000552 RID: 1362
		private int int_3;

		// Token: 0x04000553 RID: 1363
		private int int_4;
	}
}
