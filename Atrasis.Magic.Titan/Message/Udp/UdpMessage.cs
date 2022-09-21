using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Titan.Message.Udp
{
	// Token: 0x0200000A RID: 10
	public class UdpMessage
	{
		// Token: 0x06000030 RID: 48 RVA: 0x000042C9 File Offset: 0x000024C9
		public UdpMessage()
		{
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000441A File Offset: 0x0000261A
		public UdpMessage(byte messageId)
		{
			this.int_0 = (int)messageId;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00004429 File Offset: 0x00002629
		public int GetMessageId()
		{
			return this.int_0;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004431 File Offset: 0x00002631
		public PiranhaMessage GetPiranhaMessage()
		{
			return this.piranhaMessage_0;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004439 File Offset: 0x00002639
		public PiranhaMessage RemovePiranhaMessage()
		{
			PiranhaMessage result = this.piranhaMessage_0;
			this.piranhaMessage_0 = null;
			return result;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00004448 File Offset: 0x00002648
		public void SetPiranhaMessage(PiranhaMessage message)
		{
			this.piranhaMessage_0 = message;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000058B0 File Offset: 0x00003AB0
		public void Decode(ByteStream stream, LogicMessageFactory factory)
		{
			this.int_0 = (int)stream.ReadByte();
			int num = stream.ReadVInt();
			this.piranhaMessage_0 = factory.CreateMessageByType(num);
			if (this.piranhaMessage_0 != null)
			{
				int length = stream.ReadVInt();
				this.piranhaMessage_0.GetByteStream().SetByteArray(stream.ReadBytes(length, 900000), length);
				return;
			}
			Debugger.Warning("UdpMessage::decode unable to read message type " + num);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00005920 File Offset: 0x00003B20
		public void Encode(ByteStream stream)
		{
			int encodingLength = this.piranhaMessage_0.GetEncodingLength();
			stream.WriteByte((byte)this.int_0);
			stream.WriteVInt((int)this.piranhaMessage_0.GetMessageType());
			stream.WriteVInt(encodingLength);
			stream.WriteBytesWithoutLength(this.piranhaMessage_0.GetByteStream().GetByteArray(), encodingLength);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00004451 File Offset: 0x00002651
		public bool IsMoreRecent(char messageId)
		{
			return this.int_0 > (int)messageId;
		}

		// Token: 0x0400000A RID: 10
		private int int_0;

		// Token: 0x0400000B RID: 11
		private PiranhaMessage piranhaMessage_0;
	}
}
