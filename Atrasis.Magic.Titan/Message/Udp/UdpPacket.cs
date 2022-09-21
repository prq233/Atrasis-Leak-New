using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Titan.Message.Udp
{
	// Token: 0x0200000B RID: 11
	public class UdpPacket
	{
		// Token: 0x06000039 RID: 57 RVA: 0x0000445C File Offset: 0x0000265C
		public UdpPacket()
		{
			this.logicArrayList_0 = new LogicArrayList<UdpMessage>();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00005978 File Offset: 0x00003B78
		public void Decode(byte[] buffer, int length, LogicMessageFactory factory)
		{
			ByteStream byteStream = new ByteStream(buffer, length);
			if (!byteStream.IsAtEnd())
			{
				this.int_0 = byteStream.ReadVInt();
				if (this.int_0 <= 1400)
				{
					this.byte_0 = byteStream.ReadBytes(this.int_0, 1400);
					if (!byteStream.IsAtEnd())
					{
						int num = byteStream.ReadVInt();
						if (num <= 1400)
						{
							this.logicArrayList_0.EnsureCapacity(num);
							for (int i = 0; i < num; i++)
							{
								UdpMessage udpMessage = new UdpMessage();
								udpMessage.Decode(byteStream, factory);
								if (udpMessage.GetPiranhaMessage() == null)
								{
									break;
								}
								this.logicArrayList_0.Add(udpMessage);
							}
						}
					}
				}
			}
			byteStream.Destruct();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00005A20 File Offset: 0x00003C20
		public void Encode(ByteStream byteStream)
		{
			if (this.int_0 != 0 || this.logicArrayList_0.Size() != 0)
			{
				byteStream.WriteVInt(this.int_0);
				byteStream.WriteBytes(this.byte_0, this.int_0);
				ByteStream byteStream2 = new ByteStream(1400 - byteStream.GetOffset());
				if (this.logicArrayList_0.Size() > 0)
				{
					int length = 0;
					int num = 0;
					int i = this.logicArrayList_0.Size() - 1;
					while (i >= 0)
					{
						this.logicArrayList_0[i].Encode(byteStream2);
						if (byteStream2.GetLength() + byteStream.GetLength() <= 1410)
						{
							i--;
							num++;
							length = byteStream2.GetLength();
						}
						else
						{
							Debugger.Warning("UdpPacket::encode over max size");
							IL_AF:
							if (num > 0)
							{
								byteStream2.WriteVInt(num);
								byteStream2.WriteBytes(byteStream2.GetByteArray(), length);
								goto IL_C7;
							}
							goto IL_C7;
						}
					}
					goto IL_AF;
				}
				IL_C7:
				byteStream2.Destruct();
				if (byteStream.GetLength() > 1400)
				{
					Debugger.Warning("UdpPacket::encode too big");
				}
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000446F File Offset: 0x0000266F
		public void AddMessage(UdpMessage message)
		{
			this.logicArrayList_0.Add(message);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000447D File Offset: 0x0000267D
		public LogicArrayList<UdpMessage> GetMessages()
		{
			return this.logicArrayList_0;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004485 File Offset: 0x00002685
		public byte[] GetAckMessageIds()
		{
			return this.byte_0;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000448D File Offset: 0x0000268D
		public int GetAckMessageIdCount()
		{
			return this.int_0;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00004495 File Offset: 0x00002695
		public void SetAckMessageIds(byte[] ackMessageIds, int count)
		{
			this.byte_0 = ackMessageIds;
			this.int_0 = count;
		}

		// Token: 0x0400000C RID: 12
		private readonly LogicArrayList<UdpMessage> logicArrayList_0;

		// Token: 0x0400000D RID: 13
		private byte[] byte_0;

		// Token: 0x0400000E RID: 14
		private int int_0;
	}
}
