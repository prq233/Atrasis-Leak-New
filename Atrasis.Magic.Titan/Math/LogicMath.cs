using System;

namespace Atrasis.Magic.Titan.Math
{
	// Token: 0x02000014 RID: 20
	public static class LogicMath
	{
		// Token: 0x06000095 RID: 149 RVA: 0x00004895 File Offset: 0x00002A95
		public static int Abs(int value)
		{
			if (value < 0)
			{
				return -value;
			}
			return value;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000489F File Offset: 0x00002A9F
		public static int Cos(int angle)
		{
			return LogicMath.Sin(angle + 90);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000048AA File Offset: 0x00002AAA
		public static int Cos(int angleA, int angleB)
		{
			return LogicMath.Sin(angleA + 90, angleB);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00005D54 File Offset: 0x00003F54
		public static int GetAngle(int x, int y)
		{
			if (x == 0 && y == 0)
			{
				return 0;
			}
			if (x > 0 && y >= 0)
			{
				if (y >= x)
				{
					return (int)(90 - LogicMath.byte_1[(x << 7) / y]);
				}
				return (int)LogicMath.byte_1[(y << 7) / x];
			}
			else
			{
				int num = LogicMath.Abs(x);
				if (x <= 0 && y > 0)
				{
					if (num < y)
					{
						return (int)(90 + LogicMath.byte_1[(num << 7) / y]);
					}
					return (int)(180 - LogicMath.byte_1[(y << 7) / num]);
				}
				else
				{
					int num2 = LogicMath.Abs(y);
					if (x < 0 && y <= 0)
					{
						if (num2 < num)
						{
							return (int)(180 + LogicMath.byte_1[(num2 << 7) / num]);
						}
						if (num2 == 0)
						{
							return 0;
						}
						return 270 - (int)LogicMath.byte_1[(num << 7) / num2];
					}
					else
					{
						if (num < num2)
						{
							return 270 + (int)LogicMath.byte_1[(num << 7) / num2];
						}
						if (num == 0)
						{
							return 0;
						}
						return LogicMath.NormalizeAngle360(360 - (int)LogicMath.byte_1[(num2 << 7) / num]);
					}
				}
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000048B6 File Offset: 0x00002AB6
		public static int GetAngleBetween(int angle1, int angle2)
		{
			return LogicMath.Abs(LogicMath.NormalizeAngle180(angle1 - angle2));
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000048C5 File Offset: 0x00002AC5
		public static int GetRotatedX(int x, int y, int angle)
		{
			return (x * LogicMath.Cos(angle) - y * LogicMath.Sin(angle)) / 1024;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000048DE File Offset: 0x00002ADE
		public static int GetRotatedY(int x, int y, int angle)
		{
			return (x * LogicMath.Sin(angle) + y * LogicMath.Cos(angle)) / 1024;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000048F7 File Offset: 0x00002AF7
		public static int NormalizeAngle180(int angle)
		{
			angle = LogicMath.NormalizeAngle360(angle);
			if (angle >= 180)
			{
				return angle - 360;
			}
			return angle;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004912 File Offset: 0x00002B12
		public static int NormalizeAngle360(int angle)
		{
			angle %= 360;
			if (angle < 0)
			{
				return angle + 360;
			}
			return angle;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00005E34 File Offset: 0x00004034
		public static int Sin(int angle)
		{
			angle = LogicMath.NormalizeAngle360(angle);
			if (angle < 180)
			{
				if (angle > 90)
				{
					angle = 180 - angle;
				}
				return LogicMath.int_0[angle];
			}
			angle -= 180;
			if (angle > 90)
			{
				angle = 180 - angle;
			}
			return -LogicMath.int_0[angle];
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00005E88 File Offset: 0x00004088
		public static int Sin(int angleA, int angleB)
		{
			angleA = LogicMath.NormalizeAngle360(angleA);
			if (angleA < 180)
			{
				if (angleA > 90)
				{
					angleA = 180 - angleA;
				}
				return LogicMath.int_0[angleA] * angleB / 1024;
			}
			angleA -= 180;
			if (angleA > 90)
			{
				angleA = 180 - angleA;
			}
			return -LogicMath.int_0[angleA] * angleB / 1024;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00005EEC File Offset: 0x000040EC
		public unsafe static int Sqrt(int value)
		{
			byte[] array;
			byte* ptr;
			if ((array = LogicMath.byte_0) != null && array.Length != 0)
			{
				ptr = &array[0];
			}
			else
			{
				ptr = null;
			}
			if (value >= 65536)
			{
				if (value >= 16777216)
				{
					int num;
					if (value >= 268435456)
					{
						if (value >= 1073741824)
						{
							if (value == 2147483647)
							{
								return 65535;
							}
							num = (int)ptr[value >> 24] << 8;
						}
						else
						{
							num = (int)ptr[value >> 22] << 7;
						}
					}
					else if (value >= 67108864)
					{
						num = (int)ptr[value >> 20] << 6;
					}
					else
					{
						num = (int)ptr[value >> 18] << 5;
					}
					num = num + 1 + value / num >> 1;
					num = num + 1 + value / num >> 1;
					if (num * num > value)
					{
						return num - 1;
					}
					return num;
				}
				else
				{
					int num;
					if (value >= 1048576)
					{
						if (value >= 4194304)
						{
							num = (int)ptr[value >> 16] << 4;
						}
						else
						{
							num = (int)ptr[value >> 14] << 3;
						}
					}
					else if (value >= 262144)
					{
						num = (int)ptr[value >> 12] << 2;
					}
					else
					{
						num = (int)ptr[value >> 10] << 1;
					}
					num = num + 1 + value / num >> 1;
					if (num * num > value)
					{
						return num - 1;
					}
					return num;
				}
			}
			else if (value >= 256)
			{
				int num2;
				if (value >= 4096)
				{
					if (value >= 16384)
					{
						num2 = (int)(ptr[value >> 8] + 1);
					}
					else
					{
						num2 = (ptr[value >> 6] >> 1) + 1;
					}
				}
				else if (value >= 1024)
				{
					num2 = (ptr[value >> 4] >> 2) + 1;
				}
				else
				{
					num2 = (ptr[value >> 2] >> 3) + 1;
				}
				if (num2 * num2 > value)
				{
					return num2 - 1;
				}
				return num2;
			}
			else
			{
				if (value >= 0)
				{
					return ptr[value] >> 4;
				}
				return -1;
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000492A File Offset: 0x00002B2A
		public static int Clamp(int clampValue, int minValue, int maxValue)
		{
			if (clampValue >= maxValue)
			{
				return maxValue;
			}
			if (clampValue <= minValue)
			{
				return minValue;
			}
			return clampValue;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00004939 File Offset: 0x00002B39
		public static int Max(int valueA, int valueB)
		{
			if (valueA >= valueB)
			{
				return valueA;
			}
			return valueB;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004942 File Offset: 0x00002B42
		public static int Min(int valueA, int valueB)
		{
			if (valueA <= valueB)
			{
				return valueA;
			}
			return valueB;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00006060 File Offset: 0x00004260
		public static int GetRadius(int x, int y)
		{
			x = LogicMath.Abs(x);
			y = LogicMath.Abs(y);
			int num = LogicMath.Max(x, y);
			int num2 = LogicMath.Min(x, y);
			return num + (53 * num2 >> 7);
		}

		// Token: 0x04000024 RID: 36
		private static readonly byte[] byte_0 = new byte[]
		{
			0,
			16,
			22,
			27,
			32,
			35,
			39,
			42,
			45,
			48,
			50,
			53,
			55,
			57,
			59,
			61,
			64,
			65,
			67,
			69,
			71,
			73,
			75,
			76,
			78,
			80,
			81,
			83,
			84,
			86,
			87,
			89,
			90,
			91,
			93,
			94,
			96,
			97,
			98,
			99,
			101,
			102,
			103,
			104,
			106,
			107,
			108,
			109,
			110,
			112,
			113,
			114,
			115,
			116,
			117,
			118,
			119,
			120,
			121,
			122,
			123,
			124,
			125,
			126,
			128,
			128,
			129,
			130,
			131,
			132,
			133,
			134,
			135,
			136,
			137,
			138,
			139,
			140,
			141,
			142,
			143,
			144,
			144,
			145,
			146,
			147,
			148,
			149,
			150,
			150,
			151,
			152,
			153,
			154,
			155,
			155,
			156,
			157,
			158,
			159,
			160,
			160,
			161,
			162,
			163,
			163,
			164,
			165,
			166,
			167,
			167,
			168,
			169,
			170,
			170,
			171,
			172,
			173,
			173,
			174,
			175,
			176,
			176,
			177,
			178,
			178,
			179,
			180,
			181,
			181,
			182,
			183,
			183,
			184,
			185,
			185,
			186,
			187,
			187,
			188,
			189,
			189,
			190,
			191,
			192,
			192,
			193,
			193,
			194,
			195,
			195,
			196,
			197,
			197,
			198,
			199,
			199,
			200,
			201,
			201,
			202,
			203,
			203,
			204,
			204,
			205,
			206,
			206,
			207,
			208,
			208,
			209,
			209,
			210,
			211,
			211,
			212,
			212,
			213,
			214,
			214,
			215,
			215,
			216,
			217,
			217,
			218,
			218,
			219,
			219,
			220,
			221,
			221,
			222,
			222,
			223,
			224,
			224,
			225,
			225,
			226,
			226,
			227,
			227,
			228,
			229,
			229,
			230,
			230,
			231,
			231,
			232,
			232,
			233,
			234,
			234,
			235,
			235,
			236,
			236,
			237,
			237,
			238,
			238,
			239,
			240,
			240,
			241,
			241,
			242,
			242,
			243,
			243,
			244,
			244,
			245,
			245,
			246,
			246,
			247,
			247,
			248,
			248,
			249,
			249,
			250,
			250,
			251,
			251,
			252,
			252,
			253,
			253,
			254,
			254,
			byte.MaxValue
		};

		// Token: 0x04000025 RID: 37
		private static readonly byte[] byte_1 = new byte[]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			8,
			8,
			8,
			9,
			9,
			10,
			10,
			11,
			11,
			11,
			12,
			12,
			13,
			13,
			14,
			14,
			14,
			15,
			15,
			16,
			16,
			17,
			17,
			17,
			18,
			18,
			19,
			19,
			19,
			20,
			20,
			21,
			21,
			21,
			22,
			22,
			22,
			23,
			23,
			24,
			24,
			24,
			25,
			25,
			25,
			26,
			26,
			27,
			27,
			27,
			28,
			28,
			28,
			29,
			29,
			29,
			30,
			30,
			30,
			31,
			31,
			31,
			32,
			32,
			32,
			33,
			33,
			33,
			34,
			34,
			34,
			35,
			35,
			35,
			35,
			36,
			36,
			36,
			37,
			37,
			37,
			37,
			38,
			38,
			38,
			39,
			39,
			39,
			39,
			40,
			40,
			40,
			40,
			41,
			41,
			41,
			41,
			42,
			42,
			42,
			42,
			43,
			43,
			43,
			43,
			44,
			44,
			44,
			44,
			45,
			45,
			45
		};

		// Token: 0x04000026 RID: 38
		private static readonly int[] int_0 = new int[]
		{
			0,
			18,
			36,
			54,
			71,
			89,
			107,
			125,
			143,
			160,
			178,
			195,
			213,
			230,
			248,
			265,
			282,
			299,
			316,
			333,
			350,
			367,
			384,
			400,
			416,
			433,
			449,
			465,
			481,
			496,
			512,
			527,
			543,
			558,
			573,
			587,
			602,
			616,
			630,
			644,
			658,
			672,
			685,
			698,
			711,
			724,
			737,
			749,
			761,
			773,
			784,
			796,
			807,
			818,
			828,
			839,
			849,
			859,
			868,
			878,
			887,
			896,
			904,
			912,
			920,
			928,
			935,
			943,
			949,
			956,
			962,
			968,
			974,
			979,
			984,
			989,
			994,
			998,
			1002,
			1005,
			1008,
			1011,
			1014,
			1016,
			1018,
			1020,
			1022,
			1023,
			1023,
			1024,
			1024
		};
	}
}
