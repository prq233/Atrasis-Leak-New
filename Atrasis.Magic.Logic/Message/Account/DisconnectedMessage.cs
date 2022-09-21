using System;
using Atrasis.Magic.Titan.Message.Account;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000ED RID: 237
	public class DisconnectedMessage : TitanDisconnectedMessage
	{
		// Token: 0x06000AAB RID: 2731 RVA: 0x000080AF File Offset: 0x000062AF
		public DisconnectedMessage() : this(0)
		{
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x000080B8 File Offset: 0x000062B8
		public DisconnectedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x000080C1 File Offset: 0x000062C1
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x000080C9 File Offset: 0x000062C9
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x000080D1 File Offset: 0x000062D1
		public override void Destruct()
		{
			base.Destruct();
		}
	}
}
