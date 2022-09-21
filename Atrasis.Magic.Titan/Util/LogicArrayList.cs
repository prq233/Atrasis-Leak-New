using System;

namespace Atrasis.Magic.Titan.Util
{
	// Token: 0x02000005 RID: 5
	public class LogicArrayList<T>
	{
		// Token: 0x0600000C RID: 12 RVA: 0x000042D1 File Offset: 0x000024D1
		public LogicArrayList()
		{
			this.gparam_0 = new T[0];
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000042E5 File Offset: 0x000024E5
		public LogicArrayList(int initialCapacity)
		{
			this.gparam_0 = new T[initialCapacity];
		}

		// Token: 0x17000001 RID: 1
		public T this[int index]
		{
			get
			{
				return this.gparam_0[index];
			}
			set
			{
				this.gparam_0[index] = value;
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00005520 File Offset: 0x00003720
		public void Add(T item)
		{
			int num = this.gparam_0.Length;
			if (num == this.int_0)
			{
				this.EnsureCapacity((num != 0) ? (num * 2) : 5);
			}
			T[] array = this.gparam_0;
			int num2 = this.int_0;
			this.int_0 = num2 + 1;
			array[num2] = item;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000556C File Offset: 0x0000376C
		public void Add(int index, T item)
		{
			int num = this.gparam_0.Length;
			if (num == this.int_0)
			{
				this.EnsureCapacity((num != 0) ? (num * 2) : 5);
			}
			if (this.int_0 > index)
			{
				Array.Copy(this.gparam_0, index, this.gparam_0, index + 1, this.int_0 - index);
			}
			this.gparam_0[index] = item;
			this.int_0++;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000055DC File Offset: 0x000037DC
		public void AddAll(LogicArrayList<T> array)
		{
			this.EnsureCapacity(this.int_0 + array.int_0);
			int i = 0;
			int num = array.int_0;
			while (i < num)
			{
				T[] array2 = this.gparam_0;
				int num2 = this.int_0;
				this.int_0 = num2 + 1;
				array2[num2] = array[i];
				i++;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00004316 File Offset: 0x00002516
		public int IndexOf(T item)
		{
			return Array.IndexOf<T>(this.gparam_0, item, 0, this.int_0);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00005634 File Offset: 0x00003834
		public void Remove(int index)
		{
			if ((ulong)index < (ulong)((long)this.int_0))
			{
				this.int_0--;
				if (index != this.int_0)
				{
					Array.Copy(this.gparam_0, index + 1, this.gparam_0, index, this.int_0 - index);
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000432B File Offset: 0x0000252B
		public void EnsureCapacity(int count)
		{
			if (this.gparam_0.Length < count)
			{
				Array.Resize<T>(ref this.gparam_0, count);
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00004344 File Offset: 0x00002544
		public int Size()
		{
			return this.int_0;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000434C File Offset: 0x0000254C
		public void Clear()
		{
			this.int_0 = 0;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00004355 File Offset: 0x00002555
		public void Destruct()
		{
			this.gparam_0 = null;
			this.int_0 = 0;
		}

		// Token: 0x04000004 RID: 4
		private T[] gparam_0;

		// Token: 0x04000005 RID: 5
		private int int_0;
	}
}
