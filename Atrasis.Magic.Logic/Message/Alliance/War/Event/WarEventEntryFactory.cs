using System;

namespace Atrasis.Magic.Logic.Message.Alliance.War.Event
{
	// Token: 0x020000D4 RID: 212
	public static class WarEventEntryFactory
	{
		// Token: 0x06000928 RID: 2344 RVA: 0x00007349 File Offset: 0x00005549
		public static WarEventEntry CreateWarEventEntryByType(int type)
		{
			if (type == 1)
			{
				return new AttackWarEventEntry();
			}
			return null;
		}
	}
}
