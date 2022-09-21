using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Chat
{
	// Token: 0x02000077 RID: 119
	public class SendGlobalChatLineMessage : PiranhaMessage
	{
		// Token: 0x0600053C RID: 1340 RVA: 0x000050BD File Offset: 0x000032BD
		public SendGlobalChatLineMessage() : this(0)
		{
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0000328C File Offset: 0x0000148C
		public SendGlobalChatLineMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x000050C6 File Offset: 0x000032C6
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x000050E4 File Offset: 0x000032E4
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x000050FD File Offset: 0x000032FD
		public override short GetMessageType()
		{
			return 14715;
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00002D0B File Offset: 0x00000F0B
		public override int GetServiceNodeType()
		{
			return 6;
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00005104 File Offset: 0x00003304
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x00005113 File Offset: 0x00003313
		public string RemoveMessage()
		{
			string result = this.string_0;
			this.string_0 = null;
			return result;
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x00005122 File Offset: 0x00003322
		public void SetMessage(string message)
		{
			this.string_0 = message;
		}

		// Token: 0x040001F6 RID: 502
		public const int MESSAGE_TYPE = 14715;

		// Token: 0x040001F7 RID: 503
		private string string_0;
	}
}
