using System;
using System.Collections.Generic;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Chat;

namespace ns0
{
	// Token: 0x0200000A RID: 10
	public class GClass5
	{
		// Token: 0x0600001E RID: 30 RVA: 0x000021C8 File Offset: 0x000003C8
		public GClass5()
		{
			this.dictionary_0 = new Dictionary<long, GClass1>(256);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000021E0 File Offset: 0x000003E0
		public void method_0(GClass1 gclass1_0)
		{
			if (this.method_2())
			{
				throw new Exception("ChatInstance.add: instance is full");
			}
			this.dictionary_0.Add(gclass1_0.Id, gclass1_0);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002207 File Offset: 0x00000407
		public void method_1(GClass1 gclass1_0)
		{
			if (!this.dictionary_0.Remove(gclass1_0.Id))
			{
				throw new Exception("ChatInstance.remove: session is not in instance");
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002227 File Offset: 0x00000427
		public bool method_2()
		{
			return this.dictionary_0.Count >= 256;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002A7C File Offset: 0x00000C7C
		public void method_3(LogicClientAvatar logicClientAvatar_0, string string_0)
		{
			GlobalChatLineMessage globalChatLineMessage = new GlobalChatLineMessage();
			globalChatLineMessage.SetMessage(string_0);
			globalChatLineMessage.SetAvatarName(logicClientAvatar_0.GetName());
			globalChatLineMessage.SetAvatarExpLevel(logicClientAvatar_0.GetExpLevel());
			globalChatLineMessage.SetAvatarLeagueType(logicClientAvatar_0.GetLeagueType());
			globalChatLineMessage.SetAvatarId(logicClientAvatar_0.GetId());
			globalChatLineMessage.SetHomeId(logicClientAvatar_0.GetCurrentHomeId());
			if (logicClientAvatar_0.IsInAlliance())
			{
				globalChatLineMessage.SetAllianceId(logicClientAvatar_0.GetAllianceId());
				globalChatLineMessage.SetAllianceName(logicClientAvatar_0.GetAllianceName());
				globalChatLineMessage.SetAllianceBadgeId(logicClientAvatar_0.GetAllianceBadgeId());
			}
			foreach (GClass1 gclass in this.dictionary_0.Values)
			{
				gclass.SendPiranhaMessage(globalChatLineMessage, 1);
			}
		}

		// Token: 0x0400000A RID: 10
		private const int int_0 = 256;

		// Token: 0x0400000B RID: 11
		private readonly Dictionary<long, GClass1> dictionary_0;
	}
}
