using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x0200009B RID: 155
	public class LoadVillage2AttackEntryResponseMessage : ServerResponseMessage
	{
		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x00007195 File Offset: 0x00005395
		// (set) Token: 0x06000449 RID: 1097 RVA: 0x0000719D File Offset: 0x0000539D
		public Village2AttackEntry Entry { get; set; }

		// Token: 0x0600044A RID: 1098 RVA: 0x000071A6 File Offset: 0x000053A6
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteVInt((int)this.Entry.GetAttackEntryType());
				this.Entry.Encode(stream);
			}
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x000071CD File Offset: 0x000053CD
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.Entry = Village2AttackEntryFactory.CreateAttackEntryByType((Village2AttackEntryType)stream.ReadVInt());
				this.Entry.Decode(stream);
			}
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x000071F4 File Offset: 0x000053F4
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_VILLAGE2_ATTACK_ENTRY_RESPONSE;
		}

		// Token: 0x040001EA RID: 490
		[CompilerGenerated]
		private Village2AttackEntry village2AttackEntry_0;
	}
}
