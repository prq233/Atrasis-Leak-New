using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000099 RID: 153
	public class LoadReplayStreamResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000436 RID: 1078 RVA: 0x00007116 File Offset: 0x00005316
		// (set) Token: 0x06000437 RID: 1079 RVA: 0x0000711E File Offset: 0x0000531E
		public byte[] StreamData { get; set; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000438 RID: 1080 RVA: 0x00007127 File Offset: 0x00005327
		// (set) Token: 0x06000439 RID: 1081 RVA: 0x0000712F File Offset: 0x0000532F
		public int MajorVersion { get; set; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x00007138 File Offset: 0x00005338
		// (set) Token: 0x0600043B RID: 1083 RVA: 0x00007140 File Offset: 0x00005340
		public int BuildVersion { get; set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x00007149 File Offset: 0x00005349
		// (set) Token: 0x0600043D RID: 1085 RVA: 0x00007151 File Offset: 0x00005351
		public int ContentVersion { get; set; }

		// Token: 0x0600043E RID: 1086 RVA: 0x0000CEC0 File Offset: 0x0000B0C0
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteBytes(this.StreamData, this.StreamData.Length);
				stream.WriteVInt(this.MajorVersion);
				stream.WriteVInt(this.BuildVersion);
				stream.WriteVInt(this.ContentVersion);
			}
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0000CF10 File Offset: 0x0000B110
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.StreamData = stream.ReadBytes(stream.ReadBytesLength(), 900000);
				this.MajorVersion = stream.ReadVInt();
				this.BuildVersion = stream.ReadVInt();
				this.ContentVersion = stream.ReadVInt();
			}
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x0000715A File Offset: 0x0000535A
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_REPLAY_STREAM_RESPONSE;
		}

		// Token: 0x040001E5 RID: 485
		[CompilerGenerated]
		private byte[] byte_0;

		// Token: 0x040001E6 RID: 486
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040001E7 RID: 487
		[CompilerGenerated]
		private int int_3;

		// Token: 0x040001E8 RID: 488
		[CompilerGenerated]
		private int int_4;
	}
}
