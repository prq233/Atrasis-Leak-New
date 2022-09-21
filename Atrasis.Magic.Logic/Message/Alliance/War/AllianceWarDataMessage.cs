using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance.War
{
	// Token: 0x020000CA RID: 202
	public class AllianceWarDataMessage : PiranhaMessage
	{
		// Token: 0x060008C1 RID: 2241 RVA: 0x00007025 File Offset: 0x00005225
		public AllianceWarDataMessage() : this(0)
		{
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceWarDataMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0000702E File Offset: 0x0000522E
		public override void Decode()
		{
			base.Decode();
			this.allianceWarEntry_0 = new AllianceWarEntry();
			this.allianceWarEntry_0.Decode(this.m_stream);
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x00007052 File Offset: 0x00005252
		public override void Encode()
		{
			base.Encode();
			this.allianceWarEntry_0.Encode(this.m_stream);
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x0000706B File Offset: 0x0000526B
		public override short GetMessageType()
		{
			return 24329;
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x00007072 File Offset: 0x00005272
		public AllianceWarEntry GetAllianceWarEntry()
		{
			return this.allianceWarEntry_0;
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x0000707A File Offset: 0x0000527A
		public void SetAllianceWarEntry(AllianceWarEntry list)
		{
			this.allianceWarEntry_0 = list;
		}

		// Token: 0x0400035A RID: 858
		public const int MESSAGE_TYPE = 24329;

		// Token: 0x0400035B RID: 859
		private AllianceWarEntry allianceWarEntry_0;
	}
}
