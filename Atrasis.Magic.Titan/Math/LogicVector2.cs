using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Titan.Math
{
	// Token: 0x02000017 RID: 23
	public class LogicVector2
	{
		// Token: 0x060000B4 RID: 180 RVA: 0x000042C9 File Offset: 0x000024C9
		public LogicVector2()
		{
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004994 File Offset: 0x00002B94
		public LogicVector2(int x, int y)
		{
			this.m_x = x;
			this.m_y = y;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000049AA File Offset: 0x00002BAA
		public void Destruct()
		{
			this.m_x = 0;
			this.m_y = 0;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000049BA File Offset: 0x00002BBA
		public void Add(LogicVector2 vector2)
		{
			this.m_x += vector2.m_x;
			this.m_y += vector2.m_y;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000049E2 File Offset: 0x00002BE2
		public LogicVector2 Clone()
		{
			return new LogicVector2(this.m_x, this.m_y);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000049F5 File Offset: 0x00002BF5
		public int Dot(LogicVector2 vector2)
		{
			return this.m_x * vector2.m_x + this.m_y * vector2.m_y;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00004A12 File Offset: 0x00002C12
		public int GetAngle()
		{
			return LogicMath.GetAngle(this.m_x, this.m_y);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00004A25 File Offset: 0x00002C25
		public int GetAngleBetween(int x, int y)
		{
			return LogicMath.GetAngleBetween(LogicMath.GetAngle(this.m_x, this.m_y), LogicMath.GetAngle(x, y));
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00006334 File Offset: 0x00004534
		public int GetDistance(LogicVector2 vector2)
		{
			int num = this.m_x - vector2.m_x;
			int value = int.MaxValue;
			if (num + 46340 <= 92680)
			{
				int num2 = this.m_y - vector2.m_y;
				if (num2 + 46340 <= 92680)
				{
					int num3 = num * num;
					int num4 = num2 * num2;
					if ((ulong)num4 < (ulong)((long)num3 ^ 2147483647L))
					{
						value = num3 + num4;
					}
				}
			}
			return LogicMath.Sqrt(value);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000063A4 File Offset: 0x000045A4
		public int GetDistanceSquared(LogicVector2 vector2)
		{
			int num = this.m_x - vector2.m_x;
			int result = int.MaxValue;
			if (num + 46340 <= 92680)
			{
				int num2 = this.m_y - vector2.m_y;
				if (num2 + 46340 <= 92680)
				{
					int num3 = num * num;
					int num4 = num2 * num2;
					if ((ulong)num4 < (ulong)((long)num3 ^ 2147483647L))
					{
						result = num3 + num4;
					}
				}
			}
			return result;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00006410 File Offset: 0x00004610
		public int GetDistanceSquaredTo(int x, int y)
		{
			int result = int.MaxValue;
			x -= this.m_x;
			if (x + 46340 <= 92680)
			{
				y -= this.m_y;
				if (y + 46340 <= 92680)
				{
					int num = x * x;
					int num2 = y * y;
					if ((ulong)num2 < (ulong)((long)num ^ 2147483647L))
					{
						result = num + num2;
					}
				}
			}
			return result;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00006470 File Offset: 0x00004670
		public int GetLength()
		{
			int value = int.MaxValue;
			if (46340 - this.m_x <= 92680 && 46340 - this.m_y <= 92680)
			{
				int num = this.m_x * this.m_x;
				int num2 = this.m_y * this.m_y;
				if ((ulong)num2 < (ulong)((long)num ^ 2147483647L))
				{
					value = num + num2;
				}
			}
			return LogicMath.Sqrt(value);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000064E0 File Offset: 0x000046E0
		public int GetLengthSquared()
		{
			int result = int.MaxValue;
			if (46340 - this.m_x <= 92680 && 46340 - this.m_y <= 92680)
			{
				int num = this.m_x * this.m_x;
				int num2 = this.m_y * this.m_y;
				if ((ulong)num2 < (ulong)((long)num ^ 2147483647L))
				{
					result = num + num2;
				}
			}
			return result;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004A44 File Offset: 0x00002C44
		public bool IsEqual(LogicVector2 vector2)
		{
			return this.m_x == vector2.m_x && this.m_y == vector2.m_y;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004A64 File Offset: 0x00002C64
		public bool IsInArea(int minX, int minY, int maxX, int maxY)
		{
			return this.m_x >= minX && this.m_y >= minY && this.m_x < minX + maxX && this.m_y < maxY + minY;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004A93 File Offset: 0x00002C93
		public void Multiply(LogicVector2 vector2)
		{
			this.m_x *= vector2.m_x;
			this.m_y *= vector2.m_y;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000654C File Offset: 0x0000474C
		public int Normalize(int value)
		{
			int length = this.GetLength();
			if (length != 0)
			{
				this.m_x = this.m_x * value / length;
				this.m_y = this.m_y * value / length;
			}
			return length;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00006584 File Offset: 0x00004784
		public void Rotate(int degrees)
		{
			int rotatedX = LogicMath.GetRotatedX(this.m_x, this.m_y, degrees);
			int rotatedY = LogicMath.GetRotatedY(this.m_x, this.m_y, degrees);
			this.m_x = rotatedX;
			this.m_y = rotatedY;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00004ABB File Offset: 0x00002CBB
		public void Set(int x, int y)
		{
			this.m_x = x;
			this.m_y = y;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004ACB File Offset: 0x00002CCB
		public void Substract(LogicVector2 vector2)
		{
			this.m_x -= vector2.m_x;
			this.m_y -= vector2.m_y;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004AF3 File Offset: 0x00002CF3
		public void Decode(ByteStream stream)
		{
			this.m_x = stream.ReadInt();
			this.m_y = stream.ReadInt();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004B0D File Offset: 0x00002D0D
		public void Encode(ChecksumEncoder stream)
		{
			stream.WriteInt(this.m_x);
			stream.WriteInt(this.m_y);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000065C8 File Offset: 0x000047C8
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"LogicVector2(",
				this.m_x,
				",",
				this.m_y,
				")"
			});
		}

		// Token: 0x0400002B RID: 43
		public int m_x;

		// Token: 0x0400002C RID: 44
		public int m_y;
	}
}
