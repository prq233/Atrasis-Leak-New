using System;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000D6 RID: 214
	public enum AllianceEventStreamEntryType
	{
		// Token: 0x04000398 RID: 920
		KICKED = 1,
		// Token: 0x04000399 RID: 921
		ACCEPTED,
		// Token: 0x0400039A RID: 922
		JOINED,
		// Token: 0x0400039B RID: 923
		LEFT,
		// Token: 0x0400039C RID: 924
		PROMOTED,
		// Token: 0x0400039D RID: 925
		DEMOTED,
		// Token: 0x0400039E RID: 926
		STARTED_WAR,
		// Token: 0x0400039F RID: 927
		CANCELLED_WAR,
		// Token: 0x040003A0 RID: 928
		WAR_NO_MATCH_FOUND,
		// Token: 0x040003A1 RID: 929
		CHANGED_SETTINGS,
		// Token: 0x040003A2 RID: 930
		CANCELLED_ARRANGED_WAR
	}
}
