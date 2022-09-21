using System;
using Atrasis.Magic.Logic.Message.Alliance.War;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Battle
{
	// Token: 0x02000078 RID: 120
	public class AllianceWarEventMessage : PiranhaMessage
	{
		// Token: 0x06000545 RID: 1349 RVA: 0x0000512B File Offset: 0x0000332B
		public AllianceWarEventMessage() : this(0)
		{
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0000328C File Offset: 0x0000148C
		public AllianceWarEventMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x00005134 File Offset: 0x00003334
		public override void Decode()
		{
			base.Decode();
			this.allianceWarMemberEntry_0 = new AllianceWarMemberEntry();
			this.allianceWarMemberEntry_0.Decode(this.m_stream);
			this.eventType_0 = (AllianceWarEventMessage.EventType)this.m_stream.ReadInt();
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00005169 File Offset: 0x00003369
		public override void Encode()
		{
			base.Encode();
			this.allianceWarMemberEntry_0.Encode(this.m_stream);
			this.m_stream.WriteInt((int)this.eventType_0);
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x00005193 File Offset: 0x00003393
		public override short GetMessageType()
		{
			return 25006;
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x040001F8 RID: 504
		public const int MESSAGE_TYPE = 25006;

		// Token: 0x040001F9 RID: 505
		private AllianceWarMemberEntry allianceWarMemberEntry_0;

		// Token: 0x040001FA RID: 506
		private AllianceWarEventMessage.EventType eventType_0;

		// Token: 0x02000079 RID: 121
		public enum EventType
		{
			// Token: 0x040001FC RID: 508
			DESTRUCTION_25_PERCENT,
			// Token: 0x040001FD RID: 509
			DESTRUCTION_50_PERCENT,
			// Token: 0x040001FE RID: 510
			DESTRUCTION_75_PERCENT,
			// Token: 0x040001FF RID: 511
			TOWN_HALL_DESTROYED
		}
	}
}
