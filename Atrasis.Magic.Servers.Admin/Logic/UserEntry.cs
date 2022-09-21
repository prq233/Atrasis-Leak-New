using System;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000016 RID: 22
	public class UserEntry
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000085 RID: 133 RVA: 0x0000247D File Offset: 0x0000067D
		// (set) Token: 0x06000086 RID: 134 RVA: 0x00002485 File Offset: 0x00000685
		public string User { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000087 RID: 135 RVA: 0x0000248E File Offset: 0x0000068E
		// (set) Token: 0x06000088 RID: 136 RVA: 0x00002496 File Offset: 0x00000696
		public string Password { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000089 RID: 137 RVA: 0x0000249F File Offset: 0x0000069F
		// (set) Token: 0x0600008A RID: 138 RVA: 0x000024A7 File Offset: 0x000006A7
		public bool CanOpenServersPage { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600008B RID: 139 RVA: 0x000024B0 File Offset: 0x000006B0
		// (set) Token: 0x0600008C RID: 140 RVA: 0x000024B8 File Offset: 0x000006B8
		public bool CanOpenUsersPage { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000024C1 File Offset: 0x000006C1
		// (set) Token: 0x0600008E RID: 142 RVA: 0x000024C9 File Offset: 0x000006C9
		public bool CanOpenUserProfilePage { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600008F RID: 143 RVA: 0x000024D2 File Offset: 0x000006D2
		// (set) Token: 0x06000090 RID: 144 RVA: 0x000024DA File Offset: 0x000006DA
		public bool CanOpenLogsPage { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000091 RID: 145 RVA: 0x000024E3 File Offset: 0x000006E3
		// (set) Token: 0x06000092 RID: 146 RVA: 0x000024EB File Offset: 0x000006EB
		public bool CanOpenServerEventsPage { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000093 RID: 147 RVA: 0x000024F4 File Offset: 0x000006F4
		// (set) Token: 0x06000094 RID: 148 RVA: 0x000024FC File Offset: 0x000006FC
		public bool CanChangeServerStatus { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00002505 File Offset: 0x00000705
		// (set) Token: 0x06000096 RID: 150 RVA: 0x0000250D File Offset: 0x0000070D
		public bool CanExecuteAdminCommand { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00002516 File Offset: 0x00000716
		// (set) Token: 0x06000098 RID: 152 RVA: 0x0000251E File Offset: 0x0000071E
		public bool CanExecuteDebugCommand { get; set; }

		// Token: 0x06000099 RID: 153 RVA: 0x00002527 File Offset: 0x00000727
		public static UserEntry Load(RedisValue value)
		{
			return JsonConvert.DeserializeObject<UserEntry>(value);
		}
	}
}
