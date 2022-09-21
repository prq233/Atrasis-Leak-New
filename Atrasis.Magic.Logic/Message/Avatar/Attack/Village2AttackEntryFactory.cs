using System;

namespace Atrasis.Magic.Logic.Message.Avatar.Attack
{
	// Token: 0x020000A0 RID: 160
	public class Village2AttackEntryFactory
	{
		// Token: 0x060006E7 RID: 1767 RVA: 0x00005FE2 File Offset: 0x000041E2
		public static Village2AttackEntry CreateAttackEntryByType(Village2AttackEntryType type)
		{
			if (type == Village2AttackEntryType.BASE)
			{
				return new Village2AttackEntry();
			}
			if (type != Village2AttackEntryType.BATTLE_RESULT)
			{
				return null;
			}
			return new Village2BattleResultAttackEntry();
		}
	}
}
