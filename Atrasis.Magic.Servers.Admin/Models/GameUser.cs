using System;
using Atrasis.Magic.Servers.Core.Database.Document;

namespace Atrasis.Magic.Servers.Admin.Models
{
	// Token: 0x02000013 RID: 19
	public class GameUser
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00002360 File Offset: 0x00000560
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00002368 File Offset: 0x00000568
		public long Id { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00002371 File Offset: 0x00000571
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00002379 File Offset: 0x00000579
		public string Tag { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002382 File Offset: 0x00000582
		// (set) Token: 0x0600006B RID: 107 RVA: 0x0000238A File Offset: 0x0000058A
		public string Name { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002393 File Offset: 0x00000593
		// (set) Token: 0x0600006D RID: 109 RVA: 0x0000239B File Offset: 0x0000059B
		public string Alliance { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600006E RID: 110 RVA: 0x000023A4 File Offset: 0x000005A4
		// (set) Token: 0x0600006F RID: 111 RVA: 0x000023AC File Offset: 0x000005AC
		public int ExpLevel { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000070 RID: 112 RVA: 0x000023B5 File Offset: 0x000005B5
		// (set) Token: 0x06000071 RID: 113 RVA: 0x000023BD File Offset: 0x000005BD
		public int Score { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000023C6 File Offset: 0x000005C6
		// (set) Token: 0x06000073 RID: 115 RVA: 0x000023CE File Offset: 0x000005CE
		public int DuelScore { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000074 RID: 116 RVA: 0x000023D7 File Offset: 0x000005D7
		// (set) Token: 0x06000075 RID: 117 RVA: 0x000023DF File Offset: 0x000005DF
		public AccountState Status { get; set; }
	}
}
