using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000046 RID: 70
	public class StopSessionMessage : ServerSessionMessage
	{
		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001AB RID: 427 RVA: 0x000055B0 File Offset: 0x000037B0
		// (set) Token: 0x060001AC RID: 428 RVA: 0x000055B8 File Offset: 0x000037B8
		public int Reason { get; set; }

		// Token: 0x060001AD RID: 429 RVA: 0x000055C1 File Offset: 0x000037C1
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Reason);
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000055CF File Offset: 0x000037CF
		public override void Decode(ByteStream stream)
		{
			this.Reason = stream.ReadVInt();
		}

		// Token: 0x060001AF RID: 431 RVA: 0x000055DD File Offset: 0x000037DD
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.STOP_SESSION;
		}

		// Token: 0x040000FF RID: 255
		[CompilerGenerated]
		private int int_2;
	}
}
