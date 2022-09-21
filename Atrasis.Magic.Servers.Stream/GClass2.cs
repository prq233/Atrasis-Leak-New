using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;

namespace ns0
{
	// Token: 0x02000005 RID: 5
	public class GClass2
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000024D0 File Offset: 0x000006D0
		public static AllianceMemberEntry smethod_0(LogicClientAvatar logicClientAvatar_0)
		{
			AllianceMemberEntry allianceMemberEntry = new AllianceMemberEntry();
			GClass2.smethod_1(logicClientAvatar_0, allianceMemberEntry, null);
			return allianceMemberEntry;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000024EC File Offset: 0x000006EC
		public static void smethod_1(LogicClientAvatar logicClientAvatar_0, AllianceMemberEntry allianceMemberEntry_0, GClass8 gclass8_0 = null)
		{
			bool flag = logicClientAvatar_0.GetScore() != allianceMemberEntry_0.GetScore();
			allianceMemberEntry_0.SetAvatarId(logicClientAvatar_0.GetId());
			allianceMemberEntry_0.SetHomeId(logicClientAvatar_0.GetCurrentHomeId());
			allianceMemberEntry_0.SetName(logicClientAvatar_0.GetName());
			allianceMemberEntry_0.SetExpLevel(logicClientAvatar_0.GetExpLevel());
			allianceMemberEntry_0.SetLeagueType(logicClientAvatar_0.GetLeagueType());
			allianceMemberEntry_0.SetScore(logicClientAvatar_0.GetScore());
			allianceMemberEntry_0.SetDuelScore(logicClientAvatar_0.GetDuelScore());
			allianceMemberEntry_0.SetWarPreference(logicClientAvatar_0.GetWarPreference());
			if (gclass8_0 != null && flag)
			{
				gclass8_0.method_8();
			}
		}
	}
}
