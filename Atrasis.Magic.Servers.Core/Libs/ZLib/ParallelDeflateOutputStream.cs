using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000DB RID: 219
	public class ParallelDeflateOutputStream : Stream
	{
		// Token: 0x0600066D RID: 1645 RVA: 0x000086B8 File Offset: 0x000068B8
		public ParallelDeflateOutputStream(Stream stream) : this(stream, CompressionLevel.Default, CompressionStrategy.Default, false)
		{
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x000086C4 File Offset: 0x000068C4
		public ParallelDeflateOutputStream(Stream stream, CompressionLevel level) : this(stream, level, CompressionStrategy.Default, false)
		{
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x000086D0 File Offset: 0x000068D0
		public ParallelDeflateOutputStream(Stream stream, bool leaveOpen) : this(stream, CompressionLevel.Default, CompressionStrategy.Default, leaveOpen)
		{
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x000086DC File Offset: 0x000068DC
		public ParallelDeflateOutputStream(Stream stream, CompressionLevel level, bool leaveOpen) : this(stream, CompressionLevel.Default, CompressionStrategy.Default, leaveOpen)
		{
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x00013C54 File Offset: 0x00011E54
		public ParallelDeflateOutputStream(Stream stream, CompressionLevel level, CompressionStrategy strategy, bool leaveOpen)
		{
			this.m_outStream = stream;
			this.m_compressLevel = level;
			this.Strategy = strategy;
			this.m_leaveOpen = leaveOpen;
			this.MaxBufferPairs = 16;
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x000086E8 File Offset: 0x000068E8
		public CompressionStrategy Strategy { get; }

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000673 RID: 1651 RVA: 0x000086F0 File Offset: 0x000068F0
		// (set) Token: 0x06000674 RID: 1652 RVA: 0x000086F8 File Offset: 0x000068F8
		public int MaxBufferPairs
		{
			get
			{
				return this.m_maxBufferPairs;
			}
			set
			{
				if (value < 4)
				{
					throw new ArgumentException("MaxBufferPairs", "Value must be 4 or greater.");
				}
				this.m_maxBufferPairs = value;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000675 RID: 1653 RVA: 0x00008715 File Offset: 0x00006915
		// (set) Token: 0x06000676 RID: 1654 RVA: 0x0000871D File Offset: 0x0000691D
		public int BufferSize
		{
			get
			{
				return this.m_bufferSize;
			}
			set
			{
				if (value < 1024)
				{
					throw new ArgumentOutOfRangeException("BufferSize", "BufferSize must be greater than 1024 bytes");
				}
				this.m_bufferSize = value;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000677 RID: 1655 RVA: 0x0000873E File Offset: 0x0000693E
		// (set) Token: 0x06000678 RID: 1656 RVA: 0x00008746 File Offset: 0x00006946
		public int Crc32 { get; private set; }

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x0000874F File Offset: 0x0000694F
		// (set) Token: 0x0600067A RID: 1658 RVA: 0x00008757 File Offset: 0x00006957
		public long BytesProcessed { get; private set; }

		// Token: 0x0600067B RID: 1659 RVA: 0x00013CC4 File Offset: 0x00011EC4
		private void m_InitializePoolOfWorkItems()
		{
			this.m_toWrite = new Queue<int>();
			this.m_toFill = new Queue<int>();
			this.m_pool = new List<WorkItem>();
			int num = ParallelDeflateOutputStream.BufferPairsPerCore * Environment.ProcessorCount;
			num = Math.Min(num, this.m_maxBufferPairs);
			for (int i = 0; i < num; i++)
			{
				this.m_pool.Add(new WorkItem(this.m_bufferSize, this.m_compressLevel, this.Strategy, i));
				this.m_toFill.Enqueue(i);
			}
			this.m_newlyCompressedBlob = new AutoResetEvent(false);
			this.m_runningCrc = new CRC32();
			this.m_currentlyFilling = -1;
			this.m_lastFilled = -1;
			this.m_lastWritten = -1;
			this.m_latestCompressed = -1;
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x00013D7C File Offset: 0x00011F7C
		public override void Write(byte[] buffer, int offset, int count)
		{
			bool mustWait = false;
			if (this.m_isClosed)
			{
				throw new InvalidOperationException();
			}
			if (this.m_pendingException != null)
			{
				this.m_handlingException = true;
				Exception pendingException = this.m_pendingException;
				this.m_pendingException = null;
				throw pendingException;
			}
			if (count == 0)
			{
				return;
			}
			if (!this.m_firstWriteDone)
			{
				this.m_InitializePoolOfWorkItems();
				this.m_firstWriteDone = true;
			}
			for (;;)
			{
				this.EmitPendingBuffers(false, mustWait);
				mustWait = false;
				int num;
				if (this.m_currentlyFilling >= 0)
				{
					num = this.m_currentlyFilling;
					goto IL_82;
				}
				if (this.m_toFill.Count != 0)
				{
					num = this.m_toFill.Dequeue();
					this.m_lastFilled++;
					goto IL_82;
				}
				mustWait = true;
				IL_120:
				if (count <= 0)
				{
					break;
				}
				continue;
				IL_82:
				WorkItem workItem = this.m_pool[num];
				int num2 = (workItem.buffer.Length - workItem.inputBytesAvailable > count) ? count : (workItem.buffer.Length - workItem.inputBytesAvailable);
				workItem.ordinal = this.m_lastFilled;
				Buffer.BlockCopy(buffer, offset, workItem.buffer, workItem.inputBytesAvailable, num2);
				count -= num2;
				offset += num2;
				workItem.inputBytesAvailable += num2;
				if (workItem.inputBytesAvailable != workItem.buffer.Length)
				{
					this.m_currentlyFilling = num;
					goto IL_120;
				}
				if (ThreadPool.QueueUserWorkItem(new WaitCallback(this.m_DeflateOne), workItem))
				{
					this.m_currentlyFilling = -1;
					goto IL_120;
				}
				goto IL_14C;
			}
			return;
			IL_14C:
			throw new Exception("Cannot enqueue workitem");
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x00013EE0 File Offset: 0x000120E0
		private void m_FlushFinish()
		{
			byte[] array = new byte[128];
			ZLibCodec zlibCodec = new ZLibCodec();
			int num = zlibCodec.InitializeDeflate(this.m_compressLevel, false);
			zlibCodec.InputBuffer = null;
			zlibCodec.NextIn = 0;
			zlibCodec.AvailableBytesIn = 0;
			zlibCodec.OutputBuffer = array;
			zlibCodec.NextOut = 0;
			zlibCodec.AvailableBytesOut = array.Length;
			num = zlibCodec.Deflate(FlushType.Finish);
			if (num != 1 && num != 0)
			{
				throw new Exception("deflating: " + zlibCodec.Message);
			}
			if (array.Length - zlibCodec.AvailableBytesOut > 0)
			{
				this.m_outStream.Write(array, 0, array.Length - zlibCodec.AvailableBytesOut);
			}
			zlibCodec.EndDeflate();
			this.Crc32 = this.m_runningCrc.Crc32Result;
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00013F9C File Offset: 0x0001219C
		private void m_Flush(bool lastInput)
		{
			if (this.m_isClosed)
			{
				throw new InvalidOperationException();
			}
			if (this.emitting)
			{
				return;
			}
			if (this.m_currentlyFilling >= 0)
			{
				WorkItem wi = this.m_pool[this.m_currentlyFilling];
				this.m_DeflateOne(wi);
				this.m_currentlyFilling = -1;
			}
			if (lastInput)
			{
				this.EmitPendingBuffers(true, false);
				this.m_FlushFinish();
				return;
			}
			this.EmitPendingBuffers(false, false);
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00008760 File Offset: 0x00006960
		public override void Flush()
		{
			if (this.m_pendingException != null)
			{
				this.m_handlingException = true;
				Exception pendingException = this.m_pendingException;
				this.m_pendingException = null;
				throw pendingException;
			}
			if (this.m_handlingException)
			{
				return;
			}
			this.m_Flush(false);
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x00014004 File Offset: 0x00012204
		public override void Close()
		{
			if (this.m_pendingException != null)
			{
				this.m_handlingException = true;
				Exception pendingException = this.m_pendingException;
				this.m_pendingException = null;
				throw pendingException;
			}
			if (this.m_handlingException)
			{
				return;
			}
			if (this.m_isClosed)
			{
				return;
			}
			this.m_Flush(true);
			if (!this.m_leaveOpen)
			{
				this.m_outStream.Close();
			}
			this.m_isClosed = true;
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x00008795 File Offset: 0x00006995
		public new void Dispose()
		{
			this.Close();
			this.m_pool = null;
			this.Dispose(true);
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x000087AB File Offset: 0x000069AB
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x00014068 File Offset: 0x00012268
		public void Reset(Stream stream)
		{
			if (!this.m_firstWriteDone)
			{
				return;
			}
			this.m_toWrite.Clear();
			this.m_toFill.Clear();
			foreach (WorkItem workItem in this.m_pool)
			{
				this.m_toFill.Enqueue(workItem.index);
				workItem.ordinal = -1;
			}
			this.m_firstWriteDone = false;
			this.BytesProcessed = 0L;
			this.m_runningCrc = new CRC32();
			this.m_isClosed = false;
			this.m_currentlyFilling = -1;
			this.m_lastFilled = -1;
			this.m_lastWritten = -1;
			this.m_latestCompressed = -1;
			this.m_outStream = stream;
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x00014138 File Offset: 0x00012338
		private void EmitPendingBuffers(bool doAll, bool mustWait)
		{
			if (this.emitting)
			{
				return;
			}
			this.emitting = true;
			if (doAll || mustWait)
			{
				this.m_newlyCompressedBlob.WaitOne();
			}
			do
			{
				int num = -1;
				int num2 = doAll ? 200 : (mustWait ? -1 : 0);
				int num3 = -1;
				do
				{
					if (Monitor.TryEnter(this.m_toWrite, num2))
					{
						num3 = -1;
						try
						{
							if (this.m_toWrite.Count > 0)
							{
								num3 = this.m_toWrite.Dequeue();
							}
						}
						finally
						{
							Monitor.Exit(this.m_toWrite);
						}
						if (num3 >= 0)
						{
							WorkItem workItem = this.m_pool[num3];
							if (workItem.ordinal != this.m_lastWritten + 1)
							{
								Queue<int> toWrite = this.m_toWrite;
								lock (toWrite)
								{
									this.m_toWrite.Enqueue(num3);
								}
								if (num == num3)
								{
									this.m_newlyCompressedBlob.WaitOne();
									num = -1;
								}
								else if (num == -1)
								{
									num = num3;
								}
							}
							else
							{
								num = -1;
								this.m_outStream.Write(workItem.compressed, 0, workItem.compressedBytesAvailable);
								this.m_runningCrc.Combine(workItem.crc, workItem.inputBytesAvailable);
								this.BytesProcessed += (long)workItem.inputBytesAvailable;
								workItem.inputBytesAvailable = 0;
								this.m_lastWritten = workItem.ordinal;
								this.m_toFill.Enqueue(workItem.index);
								if (num2 == -1)
								{
									num2 = 0;
								}
							}
						}
					}
					else
					{
						num3 = -1;
					}
				}
				while (num3 >= 0);
				if (!doAll)
				{
					break;
				}
			}
			while (this.m_lastWritten != this.m_latestCompressed);
			this.emitting = false;
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x00014304 File Offset: 0x00012504
		private void m_DeflateOne(object wi)
		{
			WorkItem workItem = (WorkItem)wi;
			try
			{
				CRC32 crc = new CRC32();
				crc.SlurpBlock(workItem.buffer, 0, workItem.inputBytesAvailable);
				this.DeflateOneSegment(workItem);
				workItem.crc = crc.Crc32Result;
				object obj = this.m_latestLock;
				lock (obj)
				{
					if (workItem.ordinal > this.m_latestCompressed)
					{
						this.m_latestCompressed = workItem.ordinal;
					}
				}
				Queue<int> toWrite = this.m_toWrite;
				lock (toWrite)
				{
					this.m_toWrite.Enqueue(workItem.index);
				}
				this.m_newlyCompressedBlob.Set();
			}
			catch (Exception pendingException)
			{
				object obj = this.m_eLock;
				lock (obj)
				{
					if (this.m_pendingException != null)
					{
						this.m_pendingException = pendingException;
					}
				}
			}
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x00014424 File Offset: 0x00012624
		private bool DeflateOneSegment(WorkItem workitem)
		{
			ZLibCodec compressor = workitem.compressor;
			compressor.ResetDeflate();
			compressor.NextIn = 0;
			compressor.AvailableBytesIn = workitem.inputBytesAvailable;
			compressor.NextOut = 0;
			compressor.AvailableBytesOut = workitem.compressed.Length;
			do
			{
				compressor.Deflate(FlushType.None);
			}
			while (compressor.AvailableBytesIn > 0 || compressor.AvailableBytesOut == 0);
			compressor.Deflate(FlushType.Sync);
			workitem.compressedBytesAvailable = (int)compressor.TotalBytesOut;
			return true;
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0001449C File Offset: 0x0001269C
		[Conditional("Trace")]
		private void TraceOutput(ParallelDeflateOutputStream.TraceBits bits, string format, params object[] varParams)
		{
			if ((bits & this.m_DesiredTrace) != ParallelDeflateOutputStream.TraceBits.None)
			{
				object outputLock = this.m_outputLock;
				lock (outputLock)
				{
					int hashCode = Thread.CurrentThread.GetHashCode();
					Console.ForegroundColor = hashCode % 8 + ConsoleColor.DarkGray;
					Console.Write("{0:000} PDOS ", hashCode);
					Console.WriteLine(format, varParams);
					Console.ResetColor();
				}
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000688 RID: 1672 RVA: 0x0000598D File Offset: 0x00003B8D
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000689 RID: 1673 RVA: 0x0000598D File Offset: 0x00003B8D
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x0600068A RID: 1674 RVA: 0x000087B4 File Offset: 0x000069B4
		public override bool CanWrite
		{
			get
			{
				return this.m_outStream.CanWrite;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x0600068B RID: 1675 RVA: 0x0000815C File Offset: 0x0000635C
		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600068C RID: 1676 RVA: 0x000087C1 File Offset: 0x000069C1
		// (set) Token: 0x0600068D RID: 1677 RVA: 0x0000815C File Offset: 0x0000635C
		public override long Position
		{
			get
			{
				return this.m_outStream.Position;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0000815C File Offset: 0x0000635C
		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0000815C File Offset: 0x0000635C
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0000815C File Offset: 0x0000635C
		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x04000329 RID: 809
		private static readonly int IO_BUFFER_SIZE_DEFAULT = 65536;

		// Token: 0x0400032A RID: 810
		private static readonly int BufferPairsPerCore = 4;

		// Token: 0x0400032B RID: 811
		private List<WorkItem> m_pool;

		// Token: 0x0400032C RID: 812
		private readonly bool m_leaveOpen;

		// Token: 0x0400032D RID: 813
		private bool emitting;

		// Token: 0x0400032E RID: 814
		private Stream m_outStream;

		// Token: 0x0400032F RID: 815
		private int m_maxBufferPairs;

		// Token: 0x04000330 RID: 816
		private int m_bufferSize = ParallelDeflateOutputStream.IO_BUFFER_SIZE_DEFAULT;

		// Token: 0x04000331 RID: 817
		private AutoResetEvent m_newlyCompressedBlob;

		// Token: 0x04000332 RID: 818
		private readonly object m_outputLock = new object();

		// Token: 0x04000333 RID: 819
		private bool m_isClosed;

		// Token: 0x04000334 RID: 820
		private bool m_firstWriteDone;

		// Token: 0x04000335 RID: 821
		private int m_currentlyFilling;

		// Token: 0x04000336 RID: 822
		private int m_lastFilled;

		// Token: 0x04000337 RID: 823
		private int m_lastWritten;

		// Token: 0x04000338 RID: 824
		private int m_latestCompressed;

		// Token: 0x04000339 RID: 825
		private CRC32 m_runningCrc;

		// Token: 0x0400033A RID: 826
		private readonly object m_latestLock = new object();

		// Token: 0x0400033B RID: 827
		private Queue<int> m_toWrite;

		// Token: 0x0400033C RID: 828
		private Queue<int> m_toFill;

		// Token: 0x0400033D RID: 829
		private readonly CompressionLevel m_compressLevel;

		// Token: 0x0400033E RID: 830
		private volatile Exception m_pendingException;

		// Token: 0x0400033F RID: 831
		private bool m_handlingException;

		// Token: 0x04000340 RID: 832
		private readonly object m_eLock = new object();

		// Token: 0x04000341 RID: 833
		private readonly ParallelDeflateOutputStream.TraceBits m_DesiredTrace = ParallelDeflateOutputStream.TraceBits.EmitLock | ParallelDeflateOutputStream.TraceBits.EmitEnter | ParallelDeflateOutputStream.TraceBits.EmitBegin | ParallelDeflateOutputStream.TraceBits.EmitDone | ParallelDeflateOutputStream.TraceBits.EmitSkip | ParallelDeflateOutputStream.TraceBits.Session | ParallelDeflateOutputStream.TraceBits.Compress | ParallelDeflateOutputStream.TraceBits.WriteEnter | ParallelDeflateOutputStream.TraceBits.WriteTake;

		// Token: 0x020000DC RID: 220
		[Flags]
		private enum TraceBits : uint
		{
			// Token: 0x04000346 RID: 838
			None = 0U,
			// Token: 0x04000347 RID: 839
			NotUsed1 = 1U,
			// Token: 0x04000348 RID: 840
			EmitLock = 2U,
			// Token: 0x04000349 RID: 841
			EmitEnter = 4U,
			// Token: 0x0400034A RID: 842
			EmitBegin = 8U,
			// Token: 0x0400034B RID: 843
			EmitDone = 16U,
			// Token: 0x0400034C RID: 844
			EmitSkip = 32U,
			// Token: 0x0400034D RID: 845
			EmitAll = 58U,
			// Token: 0x0400034E RID: 846
			Flush = 64U,
			// Token: 0x0400034F RID: 847
			Lifecycle = 128U,
			// Token: 0x04000350 RID: 848
			Session = 256U,
			// Token: 0x04000351 RID: 849
			Synch = 512U,
			// Token: 0x04000352 RID: 850
			Instance = 1024U,
			// Token: 0x04000353 RID: 851
			Compress = 2048U,
			// Token: 0x04000354 RID: 852
			Write = 4096U,
			// Token: 0x04000355 RID: 853
			WriteEnter = 8192U,
			// Token: 0x04000356 RID: 854
			WriteTake = 16384U,
			// Token: 0x04000357 RID: 855
			All = 4294967295U
		}
	}
}
