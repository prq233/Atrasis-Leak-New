using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance.Stream
{
	// Token: 0x020000E0 RID: 224
	public class ChatToAllianceStreamMessage : PiranhaMessage
	{
		// Token: 0x060009CD RID: 2509 RVA: 0x0000789B File Offset: 0x00005A9B
		public ChatToAllianceStreamMessage() : this(0)
		{
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x0000328C File Offset: 0x0000148C
		public ChatToAllianceStreamMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x000078A4 File Offset: 0x00005AA4
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x000078C2 File Offset: 0x00005AC2
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x000078DB File Offset: 0x00005ADB
		public override short GetMessageType()
		{
			return 14315;
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x000046E0 File Offset: 0x000028E0
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x000078E2 File Offset: 0x00005AE2
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x000078F1 File Offset: 0x00005AF1
		public string RemoveMessage()
		{
			string result = this.string_0;
			this.string_0 = null;
			return result;
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x00007900 File Offset: 0x00005B00
		public void SetMessage(string message)
		{
			this.string_0 = message;
		}

		// Token: 0x040003D5 RID: 981
		public const int MESSAGE_TYPE = 14315;

		// Token: 0x040003D6 RID: 982
		private string string_0;
	}
}
