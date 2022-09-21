using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x02000112 RID: 274
	public static class LogicGameObjectFactory
	{
		// Token: 0x06000DBC RID: 3516 RVA: 0x00030AEC File Offset: 0x0002ECEC
		public static LogicGameObject CreateGameObject(LogicGameObjectData data, LogicLevel level, int villageType)
		{
			LogicGameObject result = null;
			LogicDataType dataType = data.GetDataType();
			if (dataType <= LogicDataType.ALLIANCE_PORTAL)
			{
				if (dataType <= LogicDataType.OBSTACLE)
				{
					if (dataType == LogicDataType.BUILDING)
					{
						return new LogicBuilding(data, level, villageType);
					}
					switch (dataType)
					{
					case LogicDataType.CHARACTER:
						goto IL_D7;
					case LogicDataType.PROJECTILE:
						return new LogicProjectile(data, level, villageType);
					case LogicDataType.OBSTACLE:
						return new LogicObstacle(data, level, villageType);
					}
				}
				else
				{
					if (dataType == LogicDataType.TRAP)
					{
						return new LogicTrap(data, level, villageType);
					}
					if (dataType == LogicDataType.ALLIANCE_PORTAL)
					{
						return new LogicAlliancePortal(data, level, villageType);
					}
				}
			}
			else if (dataType <= LogicDataType.SPELL)
			{
				if (dataType == LogicDataType.DECO)
				{
					return new LogicDeco(data, level, villageType);
				}
				if (dataType == LogicDataType.SPELL)
				{
					return new LogicSpell(data, level, villageType);
				}
			}
			else
			{
				if (dataType == LogicDataType.HERO)
				{
					goto IL_D7;
				}
				if (dataType == LogicDataType.VILLAGE_OBJECT)
				{
					return new LogicVillageObject(data, level, villageType);
				}
			}
			Debugger.Warning("Trying to create game object with data that does not inherit LogicGameObjectData. GlobalId=" + data.GetGlobalID());
			return result;
			IL_D7:
			result = new LogicCharacter(data, level, villageType);
			return result;
		}
	}
}
