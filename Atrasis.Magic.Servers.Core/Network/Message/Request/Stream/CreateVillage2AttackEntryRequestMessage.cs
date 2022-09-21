using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000091 RID: 145
	public class CreateVillage2AttackEntryRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x00006F11 File Offset: 0x00005111
		// (set) Token: 0x06000407 RID: 1031 RVA: 0x00006F19 File Offset: 0x00005119
		public LogicLong OwnerId { get; set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x00006F22 File Offset: 0x00005122
		// (set) Token: 0x06000409 RID: 1033 RVA: 0x00006F2A File Offset: 0x0000512A
		public Village2AttackEntry Entry { get; set; }

		// Token: 0x0600040A RID: 1034 RVA: 0x00006F33 File Offset: 0x00005133
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.OwnerId);
			stream.WriteVInt((int)this.Entry.GetAttackEntryType());
			this.Entry.Encode(stream);
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x00006F5E File Offset: 0x0000515E
		public override void Decode(ByteStream stream)
		{
			this.OwnerId = stream.ReadLong();
			this.Entry = Village2AttackEntryFactory.CreateAttackEntryByType((Village2AttackEntryType)stream.ReadVInt());
			this.Entry.Decode(stream);
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00006F89 File Offset: 0x00005189
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_VILLAGE2_ATTACK_ENTRY_REQUEST;
		}

		// Token: 0x040001D8 RID: 472
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040001D9 RID: 473
		[CompilerGenerated]
		private Village2AttackEntry village2AttackEntry_0;
	}
}
