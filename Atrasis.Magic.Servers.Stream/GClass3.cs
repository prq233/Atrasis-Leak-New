using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Logic.Message.Alliance.Stream;

namespace ns0
{
	// Token: 0x02000006 RID: 6
	public class GClass3
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002578 File Offset: 0x00000778
		public static void smethod_0(StreamEntry streamEntry_0, AllianceMemberEntry allianceMemberEntry_0)
		{
			streamEntry_0.SetSenderAvatarId(allianceMemberEntry_0.GetAvatarId());
			streamEntry_0.SetSenderHomeId(allianceMemberEntry_0.GetHomeId());
			streamEntry_0.SetSenderName(allianceMemberEntry_0.GetName());
			streamEntry_0.SetSenderLevel(allianceMemberEntry_0.GetExpLevel());
			streamEntry_0.SetSenderLeagueType(allianceMemberEntry_0.GetLeagueType());
			streamEntry_0.SetSenderRole(allianceMemberEntry_0.GetAllianceRole());
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000025D0 File Offset: 0x000007D0
		public static void smethod_1(StreamEntry streamEntry_0, LogicClientAvatar logicClientAvatar_0)
		{
			streamEntry_0.SetSenderAvatarId(logicClientAvatar_0.GetId());
			streamEntry_0.SetSenderHomeId(logicClientAvatar_0.GetCurrentHomeId());
			streamEntry_0.SetSenderName(logicClientAvatar_0.GetName());
			streamEntry_0.SetSenderLevel(logicClientAvatar_0.GetExpLevel());
			streamEntry_0.SetSenderLeagueType(logicClientAvatar_0.GetLeagueType());
			streamEntry_0.SetSenderRole(logicClientAvatar_0.GetAllianceRole());
		}
	}
}
