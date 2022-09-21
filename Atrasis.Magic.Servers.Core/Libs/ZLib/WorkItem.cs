using System;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000DA RID: 218
	internal class WorkItem
	{
		// Token: 0x0600066C RID: 1644 RVA: 0x00013BD4 File Offset: 0x00011DD4
		public WorkItem(int size, CompressionLevel compressLevel, CompressionStrategy strategy, int ix)
		{
			this.buffer = new byte[size];
			int num = size + (size / 32768 + 1) * 5 * 2;
			this.compressed = new byte[num];
			this.compressor = new ZLibCodec();
			this.compressor.InitializeDeflate(compressLevel, false);
			this.compressor.OutputBuffer = this.compressed;
			this.compressor.InputBuffer = this.buffer;
			this.index = ix;
		}

		// Token: 0x04000321 RID: 801
		public byte[] buffer;

		// Token: 0x04000322 RID: 802
		public byte[] compressed;

		// Token: 0x04000323 RID: 803
		public int crc;

		// Token: 0x04000324 RID: 804
		public int index;

		// Token: 0x04000325 RID: 805
		public int ordinal;

		// Token: 0x04000326 RID: 806
		public int inputBytesAvailable;

		// Token: 0x04000327 RID: 807
		public int compressedBytesAvailable;

		// Token: 0x04000328 RID: 808
		public ZLibCodec compressor;
	}
}
