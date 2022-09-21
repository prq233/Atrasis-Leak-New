using System;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000132 RID: 306
	public class GlobalID
	{
		// Token: 0x06001097 RID: 4247 RVA: 0x0000B3A3 File Offset: 0x000095A3
		public static int CreateGlobalID(int classId, int instanceId)
		{
			return 1000000 * classId + instanceId;
		}

		// Token: 0x06001098 RID: 4248 RVA: 0x0000B3AE File Offset: 0x000095AE
		public static int GetInstanceID(int globalId)
		{
			return globalId % 1000000;
		}

		// Token: 0x06001099 RID: 4249 RVA: 0x0000B3B7 File Offset: 0x000095B7
		public static int GetClassID(int globalId)
		{
			return globalId / 1000000;
		}
	}
}
