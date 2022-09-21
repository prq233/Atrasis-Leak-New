using System;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000CE RID: 206
	internal sealed class DeflateManager
	{
		// Token: 0x060005DE RID: 1502 RVA: 0x0000DB74 File Offset: 0x0000BD74
		internal DeflateManager()
		{
			this.dyn_ltree = new short[DeflateManager.HEAP_SIZE * 2];
			this.dyn_dtree = new short[(2 * InternalConstants.D_CODES + 1) * 2];
			this.bl_tree = new short[(2 * InternalConstants.BL_CODES + 1) * 2];
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0000DC28 File Offset: 0x0000BE28
		private void m_InitializeLazyMatch()
		{
			this.window_size = 2 * this.w_size;
			Array.Clear(this.head, 0, this.hash_size);
			this.config = DeflateManager.Config.Lookup(this.compressionLevel);
			this.SetDeflater();
			this.strstart = 0;
			this.block_start = 0;
			this.lookahead = 0;
			this.match_length = (this.prev_length = DeflateManager.MIN_MATCH - 1);
			this.match_available = 0;
			this.ins_h = 0;
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0000DCA8 File Offset: 0x0000BEA8
		private void m_InitializeTreeData()
		{
			this.treeLiterals.dyn_tree = this.dyn_ltree;
			this.treeLiterals.staticTree = StaticTree.Literals;
			this.treeDistances.dyn_tree = this.dyn_dtree;
			this.treeDistances.staticTree = StaticTree.Distances;
			this.treeBitLengths.dyn_tree = this.bl_tree;
			this.treeBitLengths.staticTree = StaticTree.BitLengths;
			this.bi_buf = 0;
			this.bi_valid = 0;
			this.last_eob_len = 8;
			this.m_InitializeBlocks();
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0000DD34 File Offset: 0x0000BF34
		internal void m_InitializeBlocks()
		{
			for (int i = 0; i < InternalConstants.L_CODES; i++)
			{
				this.dyn_ltree[i * 2] = 0;
			}
			for (int j = 0; j < InternalConstants.D_CODES; j++)
			{
				this.dyn_dtree[j * 2] = 0;
			}
			for (int k = 0; k < InternalConstants.BL_CODES; k++)
			{
				this.bl_tree[k * 2] = 0;
			}
			this.dyn_ltree[DeflateManager.END_BLOCK * 2] = 1;
			this.static_len = 0;
			this.opt_len = 0;
			this.matches = 0;
			this.last_lit = 0;
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0000DDC0 File Offset: 0x0000BFC0
		internal void pqdownheap(short[] tree, int k)
		{
			int num = this.heap[k];
			for (int i = k << 1; i <= this.heap_len; i <<= 1)
			{
				if (i < this.heap_len && DeflateManager.m_IsSmaller(tree, this.heap[i + 1], this.heap[i], this.depth))
				{
					i++;
				}
				if (DeflateManager.m_IsSmaller(tree, num, this.heap[i], this.depth))
				{
					break;
				}
				this.heap[k] = this.heap[i];
				k = i;
			}
			this.heap[k] = num;
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0000DE4C File Offset: 0x0000C04C
		internal static bool m_IsSmaller(short[] tree, int n, int m, sbyte[] depth)
		{
			short num = tree[n * 2];
			short num2 = tree[m * 2];
			return num < num2 || (num == num2 && depth[n] <= depth[m]);
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0000DE7C File Offset: 0x0000C07C
		internal void scan_tree(short[] tree, int max_code)
		{
			int num = -1;
			int num2 = (int)tree[1];
			int num3 = 0;
			int num4 = 7;
			int num5 = 4;
			if (num2 == 0)
			{
				num4 = 138;
				num5 = 3;
			}
			tree[(max_code + 1) * 2 + 1] = short.MaxValue;
			for (int i = 0; i <= max_code; i++)
			{
				int num6 = num2;
				num2 = (int)tree[(i + 1) * 2 + 1];
				if (++num3 >= num4 || num6 != num2)
				{
					if (num3 < num5)
					{
						this.bl_tree[num6 * 2] = (short)((int)this.bl_tree[num6 * 2] + num3);
					}
					else if (num6 != 0)
					{
						if (num6 != num)
						{
							short[] array = this.bl_tree;
							int num7 = num6 * 2;
							array[num7] += 1;
						}
						short[] array2 = this.bl_tree;
						int num8 = InternalConstants.REP_3_6 * 2;
						array2[num8] += 1;
					}
					else if (num3 <= 10)
					{
						short[] array3 = this.bl_tree;
						int num9 = InternalConstants.REPZ_3_10 * 2;
						array3[num9] += 1;
					}
					else
					{
						short[] array4 = this.bl_tree;
						int num10 = InternalConstants.REPZ_11_138 * 2;
						array4[num10] += 1;
					}
					num3 = 0;
					num = num6;
					if (num2 == 0)
					{
						num4 = 138;
						num5 = 3;
					}
					else if (num6 == num2)
					{
						num4 = 6;
						num5 = 3;
					}
					else
					{
						num4 = 7;
						num5 = 4;
					}
				}
			}
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x0000DF98 File Offset: 0x0000C198
		internal int build_bl_tree()
		{
			this.scan_tree(this.dyn_ltree, this.treeLiterals.max_code);
			this.scan_tree(this.dyn_dtree, this.treeDistances.max_code);
			this.treeBitLengths.build_tree(this);
			int num = InternalConstants.BL_CODES - 1;
			while (num >= 3 && this.bl_tree[(int)(Tree.bl_order[num] * 2 + 1)] == 0)
			{
				num--;
			}
			this.opt_len += 3 * (num + 1) + 5 + 5 + 4;
			return num;
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x0000E020 File Offset: 0x0000C220
		internal void send_all_trees(int lcodes, int dcodes, int blcodes)
		{
			this.send_bits(lcodes - 257, 5);
			this.send_bits(dcodes - 1, 5);
			this.send_bits(blcodes - 4, 4);
			for (int i = 0; i < blcodes; i++)
			{
				this.send_bits((int)this.bl_tree[(int)(Tree.bl_order[i] * 2 + 1)], 3);
			}
			this.send_tree(this.dyn_ltree, lcodes - 1);
			this.send_tree(this.dyn_dtree, dcodes - 1);
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0000E094 File Offset: 0x0000C294
		internal void send_tree(short[] tree, int max_code)
		{
			int num = -1;
			int num2 = (int)tree[1];
			int num3 = 0;
			int num4 = 7;
			int num5 = 4;
			if (num2 == 0)
			{
				num4 = 138;
				num5 = 3;
			}
			for (int i = 0; i <= max_code; i++)
			{
				int num6 = num2;
				num2 = (int)tree[(i + 1) * 2 + 1];
				if (++num3 >= num4 || num6 != num2)
				{
					if (num3 < num5)
					{
						do
						{
							this.send_code(num6, this.bl_tree);
						}
						while (--num3 != 0);
					}
					else if (num6 != 0)
					{
						if (num6 != num)
						{
							this.send_code(num6, this.bl_tree);
							num3--;
						}
						this.send_code(InternalConstants.REP_3_6, this.bl_tree);
						this.send_bits(num3 - 3, 2);
					}
					else if (num3 <= 10)
					{
						this.send_code(InternalConstants.REPZ_3_10, this.bl_tree);
						this.send_bits(num3 - 3, 3);
					}
					else
					{
						this.send_code(InternalConstants.REPZ_11_138, this.bl_tree);
						this.send_bits(num3 - 11, 7);
					}
					num3 = 0;
					num = num6;
					if (num2 == 0)
					{
						num4 = 138;
						num5 = 3;
					}
					else if (num6 == num2)
					{
						num4 = 6;
						num5 = 3;
					}
					else
					{
						num4 = 7;
						num5 = 4;
					}
				}
			}
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x00008196 File Offset: 0x00006396
		private void put_bytes(byte[] p, int start, int len)
		{
			Array.Copy(p, start, this.pending, this.pendingCount, len);
			this.pendingCount += len;
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0000E1AC File Offset: 0x0000C3AC
		internal void send_code(int c, short[] tree)
		{
			int num = c * 2;
			this.send_bits((int)tree[num] & 65535, (int)tree[num + 1] & 65535);
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0000E1D8 File Offset: 0x0000C3D8
		internal void send_bits(int value, int length)
		{
			if (this.bi_valid > DeflateManager.Buf_size - length)
			{
				this.bi_buf |= (short)(value << this.bi_valid & 65535);
				byte[] array = this.pending;
				int num = this.pendingCount;
				this.pendingCount = num + 1;
				array[num] = (byte)this.bi_buf;
				byte[] array2 = this.pending;
				num = this.pendingCount;
				this.pendingCount = num + 1;
				array2[num] = (byte)(this.bi_buf >> 8);
				this.bi_buf = (short)((uint)value >> DeflateManager.Buf_size - this.bi_valid);
				this.bi_valid += length - DeflateManager.Buf_size;
				return;
			}
			this.bi_buf |= (short)(value << this.bi_valid & 65535);
			this.bi_valid += length;
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0000E2B4 File Offset: 0x0000C4B4
		internal void m_tr_align()
		{
			this.send_bits(DeflateManager.STATIC_TREES << 1, 3);
			this.send_code(DeflateManager.END_BLOCK, StaticTree.lengthAndLiteralsTreeCodes);
			this.bi_flush();
			if (1 + this.last_eob_len + 10 - this.bi_valid < 9)
			{
				this.send_bits(DeflateManager.STATIC_TREES << 1, 3);
				this.send_code(DeflateManager.END_BLOCK, StaticTree.lengthAndLiteralsTreeCodes);
				this.bi_flush();
			}
			this.last_eob_len = 7;
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0000E328 File Offset: 0x0000C528
		internal bool m_tr_tally(int dist, int lc)
		{
			this.pending[this.m_distanceOffset + this.last_lit * 2] = (byte)((uint)dist >> 8);
			this.pending[this.m_distanceOffset + this.last_lit * 2 + 1] = (byte)dist;
			this.pending[this.m_lengthOffset + this.last_lit] = (byte)lc;
			this.last_lit++;
			if (dist == 0)
			{
				short[] array = this.dyn_ltree;
				int num = lc * 2;
				array[num] += 1;
			}
			else
			{
				this.matches++;
				dist--;
				short[] array2 = this.dyn_ltree;
				int num2 = ((int)Tree.LengthCode[lc] + InternalConstants.LITERALS + 1) * 2;
				array2[num2] += 1;
				short[] array3 = this.dyn_dtree;
				int num3 = Tree.DistanceCode(dist) * 2;
				array3[num3] += 1;
			}
			if ((this.last_lit & 8191) == 0 && this.compressionLevel > CompressionLevel.Level2)
			{
				int num4 = this.last_lit << 3;
				int num5 = this.strstart - this.block_start;
				for (int i = 0; i < InternalConstants.D_CODES; i++)
				{
					num4 = (int)((long)num4 + (long)this.dyn_dtree[i * 2] * (5L + (long)Tree.ExtraDistanceBits[i]));
				}
				num4 >>= 3;
				if (this.matches < this.last_lit / 2 && num4 < num5 / 2)
				{
					return true;
				}
			}
			return this.last_lit == this.lit_bufsize - 1 || this.last_lit == this.lit_bufsize;
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x0000E494 File Offset: 0x0000C694
		internal void send_compressed_block(short[] ltree, short[] dtree)
		{
			int num = 0;
			if (this.last_lit != 0)
			{
				do
				{
					int num2 = this.m_distanceOffset + num * 2;
					int num3 = ((int)this.pending[num2] << 8 & 65280) | (int)(this.pending[num2 + 1] & byte.MaxValue);
					int num4 = (int)(this.pending[this.m_lengthOffset + num] & byte.MaxValue);
					num++;
					if (num3 == 0)
					{
						this.send_code(num4, ltree);
					}
					else
					{
						int num5 = (int)Tree.LengthCode[num4];
						this.send_code(num5 + InternalConstants.LITERALS + 1, ltree);
						int num6 = Tree.ExtraLengthBits[num5];
						if (num6 != 0)
						{
							num4 -= Tree.LengthBase[num5];
							this.send_bits(num4, num6);
						}
						num3--;
						num5 = Tree.DistanceCode(num3);
						this.send_code(num5, dtree);
						num6 = Tree.ExtraDistanceBits[num5];
						if (num6 != 0)
						{
							num3 -= Tree.DistanceBase[num5];
							this.send_bits(num3, num6);
						}
					}
				}
				while (num < this.last_lit);
			}
			this.send_code(DeflateManager.END_BLOCK, ltree);
			this.last_eob_len = (int)ltree[DeflateManager.END_BLOCK * 2 + 1];
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x0000E5A4 File Offset: 0x0000C7A4
		internal void set_data_type()
		{
			int i = 0;
			int num = 0;
			int num2 = 0;
			while (i < 7)
			{
				num2 += (int)this.dyn_ltree[i * 2];
				i++;
			}
			while (i < 128)
			{
				num += (int)this.dyn_ltree[i * 2];
				i++;
			}
			while (i < InternalConstants.LITERALS)
			{
				num2 += (int)this.dyn_ltree[i * 2];
				i++;
			}
			this.data_type = (sbyte)((num2 > num >> 2) ? DeflateManager.Z_BINARY : DeflateManager.Z_ASCII);
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x0000E620 File Offset: 0x0000C820
		internal void bi_flush()
		{
			if (this.bi_valid == 16)
			{
				byte[] array = this.pending;
				int num = this.pendingCount;
				this.pendingCount = num + 1;
				array[num] = (byte)this.bi_buf;
				byte[] array2 = this.pending;
				num = this.pendingCount;
				this.pendingCount = num + 1;
				array2[num] = (byte)(this.bi_buf >> 8);
				this.bi_buf = 0;
				this.bi_valid = 0;
				return;
			}
			if (this.bi_valid >= 8)
			{
				byte[] array3 = this.pending;
				int num = this.pendingCount;
				this.pendingCount = num + 1;
				array3[num] = (byte)this.bi_buf;
				this.bi_buf = (short)(this.bi_buf >> 8);
				this.bi_valid -= 8;
			}
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x0000E6CC File Offset: 0x0000C8CC
		internal void bi_windup()
		{
			if (this.bi_valid > 8)
			{
				byte[] array = this.pending;
				int num = this.pendingCount;
				this.pendingCount = num + 1;
				array[num] = (byte)this.bi_buf;
				byte[] array2 = this.pending;
				num = this.pendingCount;
				this.pendingCount = num + 1;
				array2[num] = (byte)(this.bi_buf >> 8);
			}
			else if (this.bi_valid > 0)
			{
				byte[] array3 = this.pending;
				int num = this.pendingCount;
				this.pendingCount = num + 1;
				array3[num] = (byte)this.bi_buf;
			}
			this.bi_buf = 0;
			this.bi_valid = 0;
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x0000E75C File Offset: 0x0000C95C
		internal void copy_block(int buf, int len, bool header)
		{
			this.bi_windup();
			this.last_eob_len = 8;
			if (header)
			{
				byte[] array = this.pending;
				int num = this.pendingCount;
				this.pendingCount = num + 1;
				array[num] = (byte)len;
				byte[] array2 = this.pending;
				num = this.pendingCount;
				this.pendingCount = num + 1;
				array2[num] = (byte)(len >> 8);
				byte[] array3 = this.pending;
				num = this.pendingCount;
				this.pendingCount = num + 1;
				array3[num] = (byte)(~(byte)len);
				byte[] array4 = this.pending;
				num = this.pendingCount;
				this.pendingCount = num + 1;
				array4[num] = (byte)(~len >> 8);
			}
			this.put_bytes(this.window, buf, len);
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x000081BA File Offset: 0x000063BA
		internal void flush_block_only(bool eof)
		{
			this.m_tr_flush_block((this.block_start >= 0) ? this.block_start : -1, this.strstart - this.block_start, eof);
			this.block_start = this.strstart;
			this.m_codec.flush_pending();
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0000E7F8 File Offset: 0x0000C9F8
		internal BlockState DeflateNone(FlushType flush)
		{
			int num = 65535;
			if (65535 > this.pending.Length - 5)
			{
				num = this.pending.Length - 5;
			}
			for (;;)
			{
				if (this.lookahead <= 1)
				{
					this.m_fillWindow();
					if (this.lookahead == 0 && flush == FlushType.None)
					{
						return BlockState.NeedMore;
					}
					if (this.lookahead == 0)
					{
						goto IL_E9;
					}
				}
				this.strstart += this.lookahead;
				this.lookahead = 0;
				int num2 = this.block_start + num;
				if (this.strstart == 0 || this.strstart >= num2)
				{
					this.lookahead = this.strstart - num2;
					this.strstart = num2;
					this.flush_block_only(false);
					if (this.m_codec.AvailableBytesOut == 0)
					{
						return BlockState.NeedMore;
					}
				}
				if (this.strstart - this.block_start >= this.w_size - DeflateManager.MIN_LOOKAHEAD)
				{
					this.flush_block_only(false);
					if (this.m_codec.AvailableBytesOut == 0)
					{
						break;
					}
				}
			}
			return BlockState.NeedMore;
			IL_E9:
			this.flush_block_only(flush == FlushType.Finish);
			if (this.m_codec.AvailableBytesOut == 0)
			{
				if (flush != FlushType.Finish)
				{
					return BlockState.NeedMore;
				}
				return BlockState.FinishStarted;
			}
			else
			{
				if (flush != FlushType.Finish)
				{
					return BlockState.BlockDone;
				}
				return BlockState.FinishDone;
			}
			return BlockState.NeedMore;
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x000081F9 File Offset: 0x000063F9
		internal void m_tr_stored_block(int buf, int stored_len, bool eof)
		{
			this.send_bits((DeflateManager.STORED_BLOCK << 1) + (eof ? 1 : 0), 3);
			this.copy_block(buf, stored_len, true);
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x0000E918 File Offset: 0x0000CB18
		internal void m_tr_flush_block(int buf, int stored_len, bool eof)
		{
			int num = 0;
			int num2;
			int num3;
			if (this.compressionLevel > CompressionLevel.None)
			{
				if ((int)this.data_type == DeflateManager.Z_UNKNOWN)
				{
					this.set_data_type();
				}
				this.treeLiterals.build_tree(this);
				this.treeDistances.build_tree(this);
				num = this.build_bl_tree();
				num2 = this.opt_len + 3 + 7 >> 3;
				num3 = this.static_len + 3 + 7 >> 3;
				if (num3 <= num2)
				{
					num2 = num3;
				}
			}
			else
			{
				num3 = (num2 = stored_len + 5);
			}
			if (stored_len + 4 <= num2 && buf != -1)
			{
				this.m_tr_stored_block(buf, stored_len, eof);
			}
			else if (num3 == num2)
			{
				this.send_bits((DeflateManager.STATIC_TREES << 1) + (eof ? 1 : 0), 3);
				this.send_compressed_block(StaticTree.lengthAndLiteralsTreeCodes, StaticTree.distTreeCodes);
			}
			else
			{
				this.send_bits((DeflateManager.DYN_TREES << 1) + (eof ? 1 : 0), 3);
				this.send_all_trees(this.treeLiterals.max_code + 1, this.treeDistances.max_code + 1, num + 1);
				this.send_compressed_block(this.dyn_ltree, this.dyn_dtree);
			}
			this.m_InitializeBlocks();
			if (eof)
			{
				this.bi_windup();
			}
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x0000EA28 File Offset: 0x0000CC28
		private void m_fillWindow()
		{
			do
			{
				int num = this.window_size - this.lookahead - this.strstart;
				int num2;
				if (num == 0 && this.strstart == 0 && this.lookahead == 0)
				{
					num = this.w_size;
				}
				else if (num == -1)
				{
					num--;
				}
				else if (this.strstart >= this.w_size + this.w_size - DeflateManager.MIN_LOOKAHEAD)
				{
					Array.Copy(this.window, this.w_size, this.window, 0, this.w_size);
					this.match_start -= this.w_size;
					this.strstart -= this.w_size;
					this.block_start -= this.w_size;
					num2 = this.hash_size;
					int num3 = num2;
					do
					{
						int num4 = (int)this.head[--num3] & 65535;
						this.head[num3] = (short)((num4 < this.w_size) ? 0 : (num4 - this.w_size));
					}
					while (--num2 != 0);
					num2 = this.w_size;
					num3 = num2;
					do
					{
						int num4 = (int)this.prev[--num3] & 65535;
						this.prev[num3] = (short)((num4 < this.w_size) ? 0 : (num4 - this.w_size));
					}
					while (--num2 != 0);
					num += this.w_size;
				}
				if (this.m_codec.AvailableBytesIn == 0)
				{
					return;
				}
				num2 = this.m_codec.read_buf(this.window, this.strstart + this.lookahead, num);
				this.lookahead += num2;
				if (this.lookahead >= DeflateManager.MIN_MATCH)
				{
					this.ins_h = (int)(this.window[this.strstart] & byte.MaxValue);
					this.ins_h = ((this.ins_h << this.hash_shift ^ (int)(this.window[this.strstart + 1] & byte.MaxValue)) & this.hash_mask);
				}
				if (this.lookahead >= DeflateManager.MIN_LOOKAHEAD)
				{
					break;
				}
			}
			while (this.m_codec.AvailableBytesIn != 0);
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x0000EC38 File Offset: 0x0000CE38
		internal BlockState DeflateFast(FlushType flush)
		{
			int num = 0;
			for (;;)
			{
				if (this.lookahead < DeflateManager.MIN_LOOKAHEAD)
				{
					this.m_fillWindow();
					if (this.lookahead < DeflateManager.MIN_LOOKAHEAD && flush == FlushType.None)
					{
						return BlockState.NeedMore;
					}
					if (this.lookahead == 0)
					{
						goto IL_2EE;
					}
				}
				if (this.lookahead >= DeflateManager.MIN_MATCH)
				{
					this.ins_h = ((this.ins_h << this.hash_shift ^ (int)(this.window[this.strstart + (DeflateManager.MIN_MATCH - 1)] & byte.MaxValue)) & this.hash_mask);
					num = ((int)this.head[this.ins_h] & 65535);
					this.prev[this.strstart & this.w_mask] = this.head[this.ins_h];
					this.head[this.ins_h] = (short)this.strstart;
				}
				if ((long)num != 0L && (this.strstart - num & 65535) <= this.w_size - DeflateManager.MIN_LOOKAHEAD && this.compressionStrategy != CompressionStrategy.HuffmanOnly)
				{
					this.match_length = this.longest_match(num);
				}
				bool flag;
				if (this.match_length >= DeflateManager.MIN_MATCH)
				{
					flag = this.m_tr_tally(this.strstart - this.match_start, this.match_length - DeflateManager.MIN_MATCH);
					this.lookahead -= this.match_length;
					if (this.match_length <= this.config.MaxLazy && this.lookahead >= DeflateManager.MIN_MATCH)
					{
						this.match_length--;
						int num2;
						do
						{
							this.strstart++;
							this.ins_h = ((this.ins_h << this.hash_shift ^ (int)(this.window[this.strstart + (DeflateManager.MIN_MATCH - 1)] & byte.MaxValue)) & this.hash_mask);
							num = ((int)this.head[this.ins_h] & 65535);
							this.prev[this.strstart & this.w_mask] = this.head[this.ins_h];
							this.head[this.ins_h] = (short)this.strstart;
							num2 = this.match_length - 1;
							this.match_length = num2;
						}
						while (num2 != 0);
						this.strstart++;
					}
					else
					{
						this.strstart += this.match_length;
						this.match_length = 0;
						this.ins_h = (int)(this.window[this.strstart] & byte.MaxValue);
						this.ins_h = ((this.ins_h << this.hash_shift ^ (int)(this.window[this.strstart + 1] & byte.MaxValue)) & this.hash_mask);
					}
				}
				else
				{
					flag = this.m_tr_tally(0, (int)(this.window[this.strstart] & byte.MaxValue));
					this.lookahead--;
					this.strstart++;
				}
				if (flag)
				{
					this.flush_block_only(false);
					if (this.m_codec.AvailableBytesOut == 0)
					{
						break;
					}
				}
			}
			return BlockState.NeedMore;
			IL_2EE:
			this.flush_block_only(flush == FlushType.Finish);
			if (this.m_codec.AvailableBytesOut == 0)
			{
				if (flush == FlushType.Finish)
				{
					return BlockState.FinishStarted;
				}
				return BlockState.NeedMore;
			}
			else
			{
				if (flush != FlushType.Finish)
				{
					return BlockState.BlockDone;
				}
				return BlockState.FinishDone;
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0000EF5C File Offset: 0x0000D15C
		internal BlockState DeflateSlow(FlushType flush)
		{
			int num = 0;
			for (;;)
			{
				if (this.lookahead < DeflateManager.MIN_LOOKAHEAD)
				{
					this.m_fillWindow();
					if (this.lookahead < DeflateManager.MIN_LOOKAHEAD && flush == FlushType.None)
					{
						return BlockState.NeedMore;
					}
					if (this.lookahead == 0)
					{
						goto IL_383;
					}
				}
				if (this.lookahead >= DeflateManager.MIN_MATCH)
				{
					this.ins_h = ((this.ins_h << this.hash_shift ^ (int)(this.window[this.strstart + (DeflateManager.MIN_MATCH - 1)] & byte.MaxValue)) & this.hash_mask);
					num = ((int)this.head[this.ins_h] & 65535);
					this.prev[this.strstart & this.w_mask] = this.head[this.ins_h];
					this.head[this.ins_h] = (short)this.strstart;
				}
				this.prev_length = this.match_length;
				this.prev_match = this.match_start;
				this.match_length = DeflateManager.MIN_MATCH - 1;
				if (num != 0 && this.prev_length < this.config.MaxLazy && (this.strstart - num & 65535) <= this.w_size - DeflateManager.MIN_LOOKAHEAD)
				{
					if (this.compressionStrategy != CompressionStrategy.HuffmanOnly)
					{
						this.match_length = this.longest_match(num);
					}
					if (this.match_length <= 5 && (this.compressionStrategy == CompressionStrategy.Filtered || (this.match_length == DeflateManager.MIN_MATCH && this.strstart - this.match_start > 4096)))
					{
						this.match_length = DeflateManager.MIN_MATCH - 1;
					}
				}
				if (this.prev_length >= DeflateManager.MIN_MATCH && this.match_length <= this.prev_length)
				{
					int num2 = this.strstart + this.lookahead - DeflateManager.MIN_MATCH;
					bool flag = this.m_tr_tally(this.strstart - 1 - this.prev_match, this.prev_length - DeflateManager.MIN_MATCH);
					this.lookahead -= this.prev_length - 1;
					this.prev_length -= 2;
					int num3;
					do
					{
						num3 = this.strstart + 1;
						this.strstart = num3;
						if (num3 <= num2)
						{
							this.ins_h = ((this.ins_h << this.hash_shift ^ (int)(this.window[this.strstart + (DeflateManager.MIN_MATCH - 1)] & byte.MaxValue)) & this.hash_mask);
							num = ((int)this.head[this.ins_h] & 65535);
							this.prev[this.strstart & this.w_mask] = this.head[this.ins_h];
							this.head[this.ins_h] = (short)this.strstart;
						}
						num3 = this.prev_length - 1;
						this.prev_length = num3;
					}
					while (num3 != 0);
					this.match_available = 0;
					this.match_length = DeflateManager.MIN_MATCH - 1;
					this.strstart++;
					if (flag)
					{
						this.flush_block_only(false);
						if (this.m_codec.AvailableBytesOut == 0)
						{
							break;
						}
					}
				}
				else if (this.match_available != 0)
				{
					if (this.m_tr_tally(0, (int)(this.window[this.strstart - 1] & 255)))
					{
						this.flush_block_only(false);
					}
					this.strstart++;
					this.lookahead--;
					if (this.m_codec.AvailableBytesOut == 0)
					{
						return BlockState.NeedMore;
					}
				}
				else
				{
					this.match_available = 1;
					this.strstart++;
					this.lookahead--;
				}
			}
			return BlockState.NeedMore;
			IL_383:
			if (this.match_available != 0)
			{
				bool flag = this.m_tr_tally(0, (int)(this.window[this.strstart - 1] & byte.MaxValue));
				this.match_available = 0;
			}
			this.flush_block_only(flush == FlushType.Finish);
			if (this.m_codec.AvailableBytesOut == 0)
			{
				if (flush == FlushType.Finish)
				{
					return BlockState.FinishStarted;
				}
				return BlockState.NeedMore;
			}
			else
			{
				if (flush != FlushType.Finish)
				{
					return BlockState.BlockDone;
				}
				return BlockState.FinishDone;
			}
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x0000F344 File Offset: 0x0000D544
		internal int longest_match(int cur_match)
		{
			int num = this.config.MaxChainLength;
			int num2 = this.strstart;
			int num3 = this.prev_length;
			int num4 = (this.strstart > this.w_size - DeflateManager.MIN_LOOKAHEAD) ? (this.strstart - (this.w_size - DeflateManager.MIN_LOOKAHEAD)) : 0;
			int niceLength = this.config.NiceLength;
			int num5 = this.w_mask;
			int num6 = this.strstart + DeflateManager.MAX_MATCH;
			byte b = this.window[num2 + num3 - 1];
			byte b2 = this.window[num2 + num3];
			if (this.prev_length >= this.config.GoodLength)
			{
				num >>= 2;
			}
			if (niceLength > this.lookahead)
			{
				niceLength = this.lookahead;
			}
			do
			{
				int num7 = cur_match;
				if (this.window[num7 + num3] == b2 && this.window[num7 + num3 - 1] == b && this.window[num7] == this.window[num2] && this.window[++num7] == this.window[num2 + 1])
				{
					num2 += 2;
					num7++;
					while (this.window[++num2] == this.window[++num7] && this.window[++num2] == this.window[++num7] && this.window[++num2] == this.window[++num7] && this.window[++num2] == this.window[++num7] && this.window[++num2] == this.window[++num7] && this.window[++num2] == this.window[++num7] && this.window[++num2] == this.window[++num7] && this.window[++num2] == this.window[++num7] && num2 < num6)
					{
					}
					int num8 = DeflateManager.MAX_MATCH - (num6 - num2);
					num2 = num6 - DeflateManager.MAX_MATCH;
					if (num8 > num3)
					{
						this.match_start = cur_match;
						num3 = num8;
						if (num8 >= niceLength)
						{
							break;
						}
						b = this.window[num2 + num3 - 1];
						b2 = this.window[num2 + num3];
					}
				}
				if ((cur_match = ((int)this.prev[cur_match & num5] & 65535)) <= num4)
				{
					break;
				}
			}
			while (--num != 0);
			if (num3 <= this.lookahead)
			{
				return num3;
			}
			return this.lookahead;
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060005FA RID: 1530 RVA: 0x0000821A File Offset: 0x0000641A
		// (set) Token: 0x060005FB RID: 1531 RVA: 0x00008222 File Offset: 0x00006422
		internal bool WantRfc1950HeaderBytes { get; set; } = true;

		// Token: 0x060005FC RID: 1532 RVA: 0x0000822B File Offset: 0x0000642B
		internal int Initialize(ZLibCodec codec, CompressionLevel level)
		{
			return this.Initialize(codec, level, 15);
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00008237 File Offset: 0x00006437
		internal int Initialize(ZLibCodec codec, CompressionLevel level, int bits)
		{
			return this.Initialize(codec, level, bits, DeflateManager.MEM_LEVEL_DEFAULT, CompressionStrategy.Default);
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00008248 File Offset: 0x00006448
		internal int Initialize(ZLibCodec codec, CompressionLevel level, int bits, CompressionStrategy compressionStrategy)
		{
			return this.Initialize(codec, level, bits, DeflateManager.MEM_LEVEL_DEFAULT, compressionStrategy);
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0000F5D8 File Offset: 0x0000D7D8
		internal int Initialize(ZLibCodec codec, CompressionLevel level, int windowBits, int memLevel, CompressionStrategy strategy)
		{
			this.m_codec = codec;
			this.m_codec.Message = null;
			if (windowBits < 9 || windowBits > 15)
			{
				throw new ZLibException("windowBits must be in the range 9..15.");
			}
			if (memLevel < 1 || memLevel > DeflateManager.MEM_LEVEL_MAX)
			{
				throw new ZLibException(string.Format("memLevel must be in the range 1.. {0}", DeflateManager.MEM_LEVEL_MAX));
			}
			this.m_codec.dstate = this;
			this.w_bits = windowBits;
			this.w_size = 1 << this.w_bits;
			this.w_mask = this.w_size - 1;
			this.hash_bits = memLevel + 7;
			this.hash_size = 1 << this.hash_bits;
			this.hash_mask = this.hash_size - 1;
			this.hash_shift = (this.hash_bits + DeflateManager.MIN_MATCH - 1) / DeflateManager.MIN_MATCH;
			this.window = new byte[this.w_size * 2];
			this.prev = new short[this.w_size];
			this.head = new short[this.hash_size];
			this.lit_bufsize = 1 << memLevel + 6;
			this.pending = new byte[this.lit_bufsize * 4];
			this.m_distanceOffset = this.lit_bufsize;
			this.m_lengthOffset = 3 * this.lit_bufsize;
			this.compressionLevel = level;
			this.compressionStrategy = strategy;
			this.Reset();
			return 0;
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0000F734 File Offset: 0x0000D934
		internal void Reset()
		{
			ZLibCodec codec = this.m_codec;
			this.m_codec.TotalBytesOut = 0L;
			codec.TotalBytesIn = 0L;
			this.m_codec.Message = null;
			this.pendingCount = 0;
			this.nextPending = 0;
			this.Rfc1950BytesEmitted = false;
			this.status = (this.WantRfc1950HeaderBytes ? DeflateManager.INIT_STATE : DeflateManager.BUSY_STATE);
			this.m_codec.m_Adler32 = Adler.Adler32(0U, null, 0, 0);
			this.last_flush = 0;
			this.m_InitializeTreeData();
			this.m_InitializeLazyMatch();
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0000F7CC File Offset: 0x0000D9CC
		internal int End()
		{
			if (this.status != DeflateManager.INIT_STATE && this.status != DeflateManager.BUSY_STATE && this.status != DeflateManager.FINISH_STATE)
			{
				return -2;
			}
			this.pending = null;
			this.head = null;
			this.prev = null;
			this.window = null;
			if (this.status != DeflateManager.BUSY_STATE)
			{
				return 0;
			}
			return -3;
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0000F830 File Offset: 0x0000DA30
		private void SetDeflater()
		{
			switch (this.config.Flavor)
			{
			case DeflateFlavor.Store:
				this.DeflateFunction = new DeflateManager.CompressFunc(this.DeflateNone);
				return;
			case DeflateFlavor.Fast:
				this.DeflateFunction = new DeflateManager.CompressFunc(this.DeflateFast);
				return;
			case DeflateFlavor.Slow:
				this.DeflateFunction = new DeflateManager.CompressFunc(this.DeflateSlow);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0000F894 File Offset: 0x0000DA94
		internal int SetParams(CompressionLevel level, CompressionStrategy strategy)
		{
			int result = 0;
			if (this.compressionLevel != level)
			{
				DeflateManager.Config config = DeflateManager.Config.Lookup(level);
				if (config.Flavor != this.config.Flavor && this.m_codec.TotalBytesIn != 0L)
				{
					result = this.m_codec.Deflate(FlushType.Partial);
				}
				this.compressionLevel = level;
				this.config = config;
				this.SetDeflater();
			}
			this.compressionStrategy = strategy;
			return result;
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x0000F8FC File Offset: 0x0000DAFC
		internal int SetDictionary(byte[] dictionary)
		{
			int num = dictionary.Length;
			int sourceIndex = 0;
			if (dictionary != null)
			{
				if (this.status == DeflateManager.INIT_STATE)
				{
					this.m_codec.m_Adler32 = Adler.Adler32(this.m_codec.m_Adler32, dictionary, 0, dictionary.Length);
					if (num < DeflateManager.MIN_MATCH)
					{
						return 0;
					}
					if (num > this.w_size - DeflateManager.MIN_LOOKAHEAD)
					{
						num = this.w_size - DeflateManager.MIN_LOOKAHEAD;
						sourceIndex = dictionary.Length - num;
					}
					Array.Copy(dictionary, sourceIndex, this.window, 0, num);
					this.strstart = num;
					this.block_start = num;
					this.ins_h = (int)(this.window[0] & byte.MaxValue);
					this.ins_h = ((this.ins_h << this.hash_shift ^ (int)(this.window[1] & byte.MaxValue)) & this.hash_mask);
					for (int i = 0; i <= num - DeflateManager.MIN_MATCH; i++)
					{
						this.ins_h = ((this.ins_h << this.hash_shift ^ (int)(this.window[i + (DeflateManager.MIN_MATCH - 1)] & byte.MaxValue)) & this.hash_mask);
						this.prev[i & this.w_mask] = this.head[this.ins_h];
						this.head[this.ins_h] = (short)i;
					}
					return 0;
				}
			}
			throw new ZLibException("Stream error.");
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0000FA50 File Offset: 0x0000DC50
		internal int Deflate(FlushType flush)
		{
			if (this.m_codec.OutputBuffer != null && (this.m_codec.InputBuffer != null || this.m_codec.AvailableBytesIn == 0))
			{
				if (this.status != DeflateManager.FINISH_STATE || flush == FlushType.Finish)
				{
					if (this.m_codec.AvailableBytesOut == 0)
					{
						this.m_codec.Message = DeflateManager.m_ErrorMessage[7];
						throw new ZLibException("OutputBuffer is full (AvailableBytesOut == 0)");
					}
					int num = this.last_flush;
					this.last_flush = (int)flush;
					int num4;
					if (this.status == DeflateManager.INIT_STATE)
					{
						int num2 = DeflateManager.Z_DEFLATED + (this.w_bits - 8 << 4) << 8;
						int num3 = (this.compressionLevel - CompressionLevel.BestSpeed & 255) >> 1;
						if (num3 > 3)
						{
							num3 = 3;
						}
						num2 |= num3 << 6;
						if (this.strstart != 0)
						{
							num2 |= DeflateManager.PRESET_DICT;
						}
						num2 += 31 - num2 % 31;
						this.status = DeflateManager.BUSY_STATE;
						byte[] array = this.pending;
						num4 = this.pendingCount;
						this.pendingCount = num4 + 1;
						array[num4] = (byte)(num2 >> 8);
						byte[] array2 = this.pending;
						num4 = this.pendingCount;
						this.pendingCount = num4 + 1;
						array2[num4] = (byte)num2;
						if (this.strstart != 0)
						{
							byte[] array3 = this.pending;
							num4 = this.pendingCount;
							this.pendingCount = num4 + 1;
							array3[num4] = (byte)((this.m_codec.m_Adler32 & 4278190080U) >> 24);
							byte[] array4 = this.pending;
							num4 = this.pendingCount;
							this.pendingCount = num4 + 1;
							array4[num4] = (byte)((this.m_codec.m_Adler32 & 16711680U) >> 16);
							byte[] array5 = this.pending;
							num4 = this.pendingCount;
							this.pendingCount = num4 + 1;
							array5[num4] = (byte)((this.m_codec.m_Adler32 & 65280U) >> 8);
							byte[] array6 = this.pending;
							num4 = this.pendingCount;
							this.pendingCount = num4 + 1;
							array6[num4] = (byte)(this.m_codec.m_Adler32 & 255U);
						}
						this.m_codec.m_Adler32 = Adler.Adler32(0U, null, 0, 0);
					}
					if (this.pendingCount != 0)
					{
						this.m_codec.flush_pending();
						if (this.m_codec.AvailableBytesOut == 0)
						{
							this.last_flush = -1;
							return 0;
						}
					}
					else if (this.m_codec.AvailableBytesIn == 0 && flush <= (FlushType)num && flush != FlushType.Finish)
					{
						return 0;
					}
					if (this.status == DeflateManager.FINISH_STATE && this.m_codec.AvailableBytesIn != 0)
					{
						this.m_codec.Message = DeflateManager.m_ErrorMessage[7];
						throw new ZLibException("status == FINISH_STATE && m_codec.AvailableBytesIn != 0");
					}
					if (this.m_codec.AvailableBytesIn != 0 || this.lookahead != 0 || (flush != FlushType.None && this.status != DeflateManager.FINISH_STATE))
					{
						BlockState blockState = this.DeflateFunction(flush);
						if (blockState == BlockState.FinishStarted || blockState == BlockState.FinishDone)
						{
							this.status = DeflateManager.FINISH_STATE;
						}
						if (blockState != BlockState.NeedMore)
						{
							if (blockState != BlockState.FinishStarted)
							{
								if (blockState != BlockState.BlockDone)
								{
									goto IL_319;
								}
								if (flush == FlushType.Partial)
								{
									this.m_tr_align();
								}
								else
								{
									this.m_tr_stored_block(0, 0, false);
									if (flush == FlushType.Full)
									{
										for (int i = 0; i < this.hash_size; i++)
										{
											this.head[i] = 0;
										}
									}
								}
								this.m_codec.flush_pending();
								if (this.m_codec.AvailableBytesOut == 0)
								{
									this.last_flush = -1;
									return 0;
								}
								goto IL_319;
							}
						}
						if (this.m_codec.AvailableBytesOut == 0)
						{
							this.last_flush = -1;
						}
						return 0;
					}
					IL_319:
					if (flush != FlushType.Finish)
					{
						return 0;
					}
					if (!this.WantRfc1950HeaderBytes || this.Rfc1950BytesEmitted)
					{
						return 1;
					}
					byte[] array7 = this.pending;
					num4 = this.pendingCount;
					this.pendingCount = num4 + 1;
					array7[num4] = (byte)((this.m_codec.m_Adler32 & 4278190080U) >> 24);
					byte[] array8 = this.pending;
					num4 = this.pendingCount;
					this.pendingCount = num4 + 1;
					array8[num4] = (byte)((this.m_codec.m_Adler32 & 16711680U) >> 16);
					byte[] array9 = this.pending;
					num4 = this.pendingCount;
					this.pendingCount = num4 + 1;
					array9[num4] = (byte)((this.m_codec.m_Adler32 & 65280U) >> 8);
					byte[] array10 = this.pending;
					num4 = this.pendingCount;
					this.pendingCount = num4 + 1;
					array10[num4] = (byte)(this.m_codec.m_Adler32 & 255U);
					this.m_codec.flush_pending();
					this.Rfc1950BytesEmitted = true;
					if (this.pendingCount == 0)
					{
						return 1;
					}
					return 0;
				}
			}
			this.m_codec.Message = DeflateManager.m_ErrorMessage[4];
			throw new ZLibException(string.Format("Something is fishy. [{0}]", this.m_codec.Message));
		}

		// Token: 0x04000256 RID: 598
		private static readonly int MEM_LEVEL_MAX = 9;

		// Token: 0x04000257 RID: 599
		private static readonly int MEM_LEVEL_DEFAULT = 8;

		// Token: 0x04000258 RID: 600
		private DeflateManager.CompressFunc DeflateFunction;

		// Token: 0x04000259 RID: 601
		private static readonly string[] m_ErrorMessage = new string[]
		{
			"need dictionary",
			"stream end",
			"",
			"file error",
			"stream error",
			"data error",
			"insufficient memory",
			"buffer error",
			"incompatible version",
			""
		};

		// Token: 0x0400025A RID: 602
		private static readonly int PRESET_DICT = 32;

		// Token: 0x0400025B RID: 603
		private static readonly int INIT_STATE = 42;

		// Token: 0x0400025C RID: 604
		private static readonly int BUSY_STATE = 113;

		// Token: 0x0400025D RID: 605
		private static readonly int FINISH_STATE = 666;

		// Token: 0x0400025E RID: 606
		private static readonly int Z_DEFLATED = 8;

		// Token: 0x0400025F RID: 607
		private static readonly int STORED_BLOCK = 0;

		// Token: 0x04000260 RID: 608
		private static readonly int STATIC_TREES = 1;

		// Token: 0x04000261 RID: 609
		private static readonly int DYN_TREES = 2;

		// Token: 0x04000262 RID: 610
		private static readonly int Z_BINARY = 0;

		// Token: 0x04000263 RID: 611
		private static readonly int Z_ASCII = 1;

		// Token: 0x04000264 RID: 612
		private static readonly int Z_UNKNOWN = 2;

		// Token: 0x04000265 RID: 613
		private static readonly int Buf_size = 16;

		// Token: 0x04000266 RID: 614
		private static readonly int MIN_MATCH = 3;

		// Token: 0x04000267 RID: 615
		private static readonly int MAX_MATCH = 258;

		// Token: 0x04000268 RID: 616
		private static readonly int MIN_LOOKAHEAD = DeflateManager.MAX_MATCH + DeflateManager.MIN_MATCH + 1;

		// Token: 0x04000269 RID: 617
		private static readonly int HEAP_SIZE = 2 * InternalConstants.L_CODES + 1;

		// Token: 0x0400026A RID: 618
		private static readonly int END_BLOCK = 256;

		// Token: 0x0400026B RID: 619
		internal ZLibCodec m_codec;

		// Token: 0x0400026C RID: 620
		internal int status;

		// Token: 0x0400026D RID: 621
		internal byte[] pending;

		// Token: 0x0400026E RID: 622
		internal int nextPending;

		// Token: 0x0400026F RID: 623
		internal int pendingCount;

		// Token: 0x04000270 RID: 624
		internal sbyte data_type;

		// Token: 0x04000271 RID: 625
		internal int last_flush;

		// Token: 0x04000272 RID: 626
		internal int w_size;

		// Token: 0x04000273 RID: 627
		internal int w_bits;

		// Token: 0x04000274 RID: 628
		internal int w_mask;

		// Token: 0x04000275 RID: 629
		internal byte[] window;

		// Token: 0x04000276 RID: 630
		internal int window_size;

		// Token: 0x04000277 RID: 631
		internal short[] prev;

		// Token: 0x04000278 RID: 632
		internal short[] head;

		// Token: 0x04000279 RID: 633
		internal int ins_h;

		// Token: 0x0400027A RID: 634
		internal int hash_size;

		// Token: 0x0400027B RID: 635
		internal int hash_bits;

		// Token: 0x0400027C RID: 636
		internal int hash_mask;

		// Token: 0x0400027D RID: 637
		internal int hash_shift;

		// Token: 0x0400027E RID: 638
		internal int block_start;

		// Token: 0x0400027F RID: 639
		private DeflateManager.Config config;

		// Token: 0x04000280 RID: 640
		internal int match_length;

		// Token: 0x04000281 RID: 641
		internal int prev_match;

		// Token: 0x04000282 RID: 642
		internal int match_available;

		// Token: 0x04000283 RID: 643
		internal int strstart;

		// Token: 0x04000284 RID: 644
		internal int match_start;

		// Token: 0x04000285 RID: 645
		internal int lookahead;

		// Token: 0x04000286 RID: 646
		internal int prev_length;

		// Token: 0x04000287 RID: 647
		internal CompressionLevel compressionLevel;

		// Token: 0x04000288 RID: 648
		internal CompressionStrategy compressionStrategy;

		// Token: 0x04000289 RID: 649
		internal short[] dyn_ltree;

		// Token: 0x0400028A RID: 650
		internal short[] dyn_dtree;

		// Token: 0x0400028B RID: 651
		internal short[] bl_tree;

		// Token: 0x0400028C RID: 652
		internal Tree treeLiterals = new Tree();

		// Token: 0x0400028D RID: 653
		internal Tree treeDistances = new Tree();

		// Token: 0x0400028E RID: 654
		internal Tree treeBitLengths = new Tree();

		// Token: 0x0400028F RID: 655
		internal short[] bl_count = new short[InternalConstants.MAX_BITS + 1];

		// Token: 0x04000290 RID: 656
		internal int[] heap = new int[2 * InternalConstants.L_CODES + 1];

		// Token: 0x04000291 RID: 657
		internal int heap_len;

		// Token: 0x04000292 RID: 658
		internal int heap_max;

		// Token: 0x04000293 RID: 659
		internal sbyte[] depth = new sbyte[2 * InternalConstants.L_CODES + 1];

		// Token: 0x04000294 RID: 660
		internal int m_lengthOffset;

		// Token: 0x04000295 RID: 661
		internal int lit_bufsize;

		// Token: 0x04000296 RID: 662
		internal int last_lit;

		// Token: 0x04000297 RID: 663
		internal int m_distanceOffset;

		// Token: 0x04000298 RID: 664
		internal int opt_len;

		// Token: 0x04000299 RID: 665
		internal int static_len;

		// Token: 0x0400029A RID: 666
		internal int matches;

		// Token: 0x0400029B RID: 667
		internal int last_eob_len;

		// Token: 0x0400029C RID: 668
		internal short bi_buf;

		// Token: 0x0400029D RID: 669
		internal int bi_valid;

		// Token: 0x0400029E RID: 670
		private bool Rfc1950BytesEmitted;

		// Token: 0x020000CF RID: 207
		// (Invoke) Token: 0x06000608 RID: 1544
		internal delegate BlockState CompressFunc(FlushType flush);

		// Token: 0x020000D0 RID: 208
		internal class Config
		{
			// Token: 0x0600060B RID: 1547 RVA: 0x0000825A File Offset: 0x0000645A
			private Config(int goodLength, int maxLazy, int niceLength, int maxChainLength, DeflateFlavor flavor)
			{
				this.GoodLength = goodLength;
				this.MaxLazy = maxLazy;
				this.NiceLength = niceLength;
				this.MaxChainLength = maxChainLength;
				this.Flavor = flavor;
			}

			// Token: 0x0600060C RID: 1548 RVA: 0x00008287 File Offset: 0x00006487
			public static DeflateManager.Config Lookup(CompressionLevel level)
			{
				return DeflateManager.Config.Table[(int)level];
			}

			// Token: 0x040002A0 RID: 672
			internal int GoodLength;

			// Token: 0x040002A1 RID: 673
			internal int MaxLazy;

			// Token: 0x040002A2 RID: 674
			internal int NiceLength;

			// Token: 0x040002A3 RID: 675
			internal int MaxChainLength;

			// Token: 0x040002A4 RID: 676
			internal DeflateFlavor Flavor;

			// Token: 0x040002A5 RID: 677
			private static readonly DeflateManager.Config[] Table = new DeflateManager.Config[]
			{
				new DeflateManager.Config(0, 0, 0, 0, DeflateFlavor.Store),
				new DeflateManager.Config(4, 4, 8, 4, DeflateFlavor.Fast),
				new DeflateManager.Config(4, 5, 16, 8, DeflateFlavor.Fast),
				new DeflateManager.Config(4, 6, 32, 32, DeflateFlavor.Fast),
				new DeflateManager.Config(4, 4, 16, 16, DeflateFlavor.Slow),
				new DeflateManager.Config(8, 16, 32, 32, DeflateFlavor.Slow),
				new DeflateManager.Config(8, 16, 128, 128, DeflateFlavor.Slow),
				new DeflateManager.Config(8, 32, 128, 256, DeflateFlavor.Slow),
				new DeflateManager.Config(32, 128, 258, 1024, DeflateFlavor.Slow),
				new DeflateManager.Config(32, 258, 258, 4096, DeflateFlavor.Slow)
			};
		}
	}
}
