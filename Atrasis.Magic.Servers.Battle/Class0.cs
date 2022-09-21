using System;
using Atrasis.Magic.Servers.Core;
using Atrasis.Magic.Servers.Core.Util;

namespace ns0
{
	// Token: 0x02000002 RID: 2
	internal class Class0
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private static void Main(string[] args)
		{
			ServerCore.Init(27, args);
			GClass0.smethod_0();
			ServerCore.Start(new GClass5());
			Console.Title = string.Format("{0} - {1}", ServerUtil.GetServerName(ServerCore.Type), ServerCore.Id);
		}
	}
}
