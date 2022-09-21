using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000C9 RID: 201
	public class UpdateVillage2AttackEntryMessage : ServerAccountMessage
	{
		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x00007F23 File Offset: 0x00006123
		// (set) Token: 0x060005AD RID: 1453 RVA: 0x00007F2B File Offset: 0x0000612B
		public Village2AttackEntry Entry { get; set; }

		// Token: 0x060005AE RID: 1454 RVA: 0x00007F34 File Offset: 0x00006134
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt((int)this.Entry.GetAttackEntryType());
			this.Entry.Encode(stream);
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00007F53 File Offset: 0x00006153
		public override void Decode(ByteStream stream)
		{
			this.Entry = Village2AttackEntryFactory.CreateAttackEntryByType((Village2AttackEntryType)stream.ReadVInt());
			this.Entry.Decode(stream);
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00007F72 File Offset: 0x00006172
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.UPDATE_VILLAGE2_ATTACK_ENTRY;
		}

		// Token: 0x04000241 RID: 577
		[CompilerGenerated]
		private Village2AttackEntry village2AttackEntry_0;
	}
}
