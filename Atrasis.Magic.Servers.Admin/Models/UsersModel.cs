using System;
using Atrasis.Magic.Logic.Message.Scoring;
using Atrasis.Magic.Servers.Admin.Controllers;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Admin.Models
{
	// Token: 0x02000012 RID: 18
	public class UsersModel : BaseModel
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600005D RID: 93 RVA: 0x0000231C File Offset: 0x0000051C
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00002324 File Offset: 0x00000524
		public LogicArrayList<AvatarRankingEntry> MainLeaderboard { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600005F RID: 95 RVA: 0x0000232D File Offset: 0x0000052D
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00002335 File Offset: 0x00000535
		public LogicArrayList<AvatarDuelRankingEntry> SecondaryLeaderboard { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000061 RID: 97 RVA: 0x0000233E File Offset: 0x0000053E
		// (set) Token: 0x06000062 RID: 98 RVA: 0x00002346 File Offset: 0x00000546
		public LogicArrayList<GameUser> Users { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000063 RID: 99 RVA: 0x0000234F File Offset: 0x0000054F
		// (set) Token: 0x06000064 RID: 100 RVA: 0x00002357 File Offset: 0x00000557
		public PanelController.UserSearch CurrentFilter { get; set; }
	}
}
