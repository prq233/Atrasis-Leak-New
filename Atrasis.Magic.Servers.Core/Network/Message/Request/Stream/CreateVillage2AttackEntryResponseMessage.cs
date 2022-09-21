using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000092 RID: 146
	public class CreateVillage2AttackEntryResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600040E RID: 1038 RVA: 0x00006F90 File Offset: 0x00005190
		// (set) Token: 0x0600040F RID: 1039 RVA: 0x00006F98 File Offset: 0x00005198
		public Village2AttackEntry Entry { get; set; }

		// Token: 0x06000410 RID: 1040 RVA: 0x00006FA1 File Offset: 0x000051A1
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteVInt((int)this.Entry.GetAttackEntryType());
				this.Entry.Encode(stream);
			}
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00006FC8 File Offset: 0x000051C8
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.Entry = Village2AttackEntryFactory.CreateAttackEntryByType((Village2AttackEntryType)stream.ReadVInt());
				this.Entry.Decode(stream);
			}
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00006FEF File Offset: 0x000051EF
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_VILLAGE2_ATTACK_ENTRY_RESPONSE;
		}

		// Token: 0x040001DA RID: 474
		[CompilerGenerated]
		private Village2AttackEntry village2AttackEntry_0;
	}
}
