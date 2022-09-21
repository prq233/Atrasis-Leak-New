using System;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Atrasis.Magic.Servers.Admin.Logic
{
	// Token: 0x02000015 RID: 21
	public class SessionEntry
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600007E RID: 126 RVA: 0x0000242F File Offset: 0x0000062F
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00002437 File Offset: 0x00000637
		public string Token { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00002440 File Offset: 0x00000640
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00002448 File Offset: 0x00000648
		public string User { get; set; }

		// Token: 0x06000082 RID: 130 RVA: 0x00002451 File Offset: 0x00000651
		public SessionEntry(string user, string token)
		{
			this.User = user;
			this.Token = token;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00002467 File Offset: 0x00000667
		public static SessionEntry Load(RedisValue value)
		{
			return JsonConvert.DeserializeObject<SessionEntry>(value);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00002474 File Offset: 0x00000674
		public static string Save(SessionEntry entry)
		{
			return JsonConvert.SerializeObject(entry, Formatting.Indented);
		}
	}
}
