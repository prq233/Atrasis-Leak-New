using System;
using System.Globalization;
using System.Text;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Titan.Json
{
	// Token: 0x0200001F RID: 31
	public class LogicJSONParser
	{
		// Token: 0x060000F5 RID: 245 RVA: 0x00006B04 File Offset: 0x00004D04
		public static string CreateJSONString(LogicJSONNode root, int ensureCapacity = 20)
		{
			StringBuilder stringBuilder = new StringBuilder(ensureCapacity);
			root.WriteToString(stringBuilder);
			return stringBuilder.ToString();
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00006B28 File Offset: 0x00004D28
		public static void WriteString(string value, StringBuilder builder)
		{
			builder.Append('"');
			if (!string.IsNullOrEmpty(value))
			{
				foreach (char c in value)
				{
					if (c <= '\r' && c >= '\b')
					{
						switch (c)
						{
						case '\b':
							builder.Append("\\b");
							goto IL_E2;
						case '\t':
							builder.Append("\\t");
							goto IL_E2;
						case '\n':
							builder.Append("\\n");
							goto IL_E2;
						case '\f':
							builder.Append("\\f");
							goto IL_E2;
						case '\r':
							builder.Append("\\r");
							goto IL_E2;
						}
						builder.Append(c);
					}
					else if (c != '"')
					{
						if (c != '/')
						{
							if (c != '\\')
							{
								builder.Append(c);
							}
							else
							{
								builder.Append("\\\\");
							}
						}
						else
						{
							builder.Append("\\/");
						}
					}
					else
					{
						builder.Append("\\\"");
					}
					IL_E2:;
				}
			}
			builder.Append('"');
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00004C92 File Offset: 0x00002E92
		public static void ParseError(string error)
		{
			Debugger.Warning("JSON Parse error: " + error);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00004CA4 File Offset: 0x00002EA4
		public static LogicJSONNode Parse(string json)
		{
			return LogicJSONParser.smethod_0(new LogicJSONParser.Class0(json));
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00006C30 File Offset: 0x00004E30
		private static LogicJSONNode smethod_0(LogicJSONParser.Class0 class0_0)
		{
			class0_0.method_3();
			char c = class0_0.method_2();
			LogicJSONNode result = null;
			if (c <= '[')
			{
				if (c == '"')
				{
					return LogicJSONParser.smethod_3(class0_0);
				}
				if (c == '-')
				{
					return LogicJSONParser.smethod_6(class0_0);
				}
				if (c == '[')
				{
					return LogicJSONParser.smethod_1(class0_0);
				}
			}
			else if (c <= 'n')
			{
				if (c == 'f')
				{
					return LogicJSONParser.smethod_4(class0_0);
				}
				if (c == 'n')
				{
					return LogicJSONParser.smethod_5(class0_0);
				}
			}
			else
			{
				if (c == 't')
				{
					return LogicJSONParser.smethod_4(class0_0);
				}
				if (c == '{')
				{
					return LogicJSONParser.smethod_2(class0_0);
				}
			}
			if (c >= '0' && c <= '9')
			{
				result = LogicJSONParser.smethod_6(class0_0);
			}
			else
			{
				LogicJSONParser.ParseError("Not of any recognized value: " + c.ToString());
			}
			return result;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00004CB1 File Offset: 0x00002EB1
		public static LogicJSONArray ParseArray(string json)
		{
			return LogicJSONParser.smethod_1(new LogicJSONParser.Class0(json));
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00006CE8 File Offset: 0x00004EE8
		private static LogicJSONArray smethod_1(LogicJSONParser.Class0 class0_0)
		{
			class0_0.method_3();
			if (class0_0.method_0() != '[')
			{
				LogicJSONParser.ParseError("Not an array");
				return null;
			}
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			class0_0.method_3();
			char c = class0_0.method_2();
			if (c != '\0')
			{
				if (c == ']')
				{
					class0_0.method_0();
					return logicJSONArray;
				}
				do
				{
					LogicJSONNode logicJSONNode = LogicJSONParser.smethod_0(class0_0);
					if (logicJSONNode == null)
					{
						goto IL_6E;
					}
					logicJSONArray.Add(logicJSONNode);
					class0_0.method_3();
					c = class0_0.method_0();
				}
				while (c == ',');
				if (c == ']')
				{
					return logicJSONArray;
				}
			}
			IL_6E:
			LogicJSONParser.ParseError("Not an array");
			return null;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00004CBE File Offset: 0x00002EBE
		public static LogicJSONObject ParseObject(string json)
		{
			return LogicJSONParser.smethod_2(new LogicJSONParser.Class0(json));
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00006D70 File Offset: 0x00004F70
		private static LogicJSONObject smethod_2(LogicJSONParser.Class0 class0_0)
		{
			class0_0.method_3();
			if (class0_0.method_0() != '{')
			{
				LogicJSONParser.ParseError("Not an object");
				return null;
			}
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			class0_0.method_3();
			char c = class0_0.method_2();
			if (c != '\0')
			{
				if (c == '}')
				{
					class0_0.method_0();
					return logicJSONObject;
				}
				do
				{
					LogicJSONString logicJSONString = LogicJSONParser.smethod_3(class0_0);
					if (logicJSONString == null)
					{
						goto IL_90;
					}
					class0_0.method_3();
					c = class0_0.method_0();
					if (c != ':')
					{
						goto IL_90;
					}
					LogicJSONNode logicJSONNode = LogicJSONParser.smethod_0(class0_0);
					if (logicJSONNode == null)
					{
						goto IL_90;
					}
					logicJSONObject.Put(logicJSONString.GetStringValue(), logicJSONNode);
					class0_0.method_3();
					c = class0_0.method_0();
				}
				while (c == ',');
				if (c == '}')
				{
					return logicJSONObject;
				}
			}
			IL_90:
			LogicJSONParser.ParseError("Not an object");
			return null;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00006E18 File Offset: 0x00005018
		private static LogicJSONString smethod_3(LogicJSONParser.Class0 class0_0)
		{
			class0_0.method_3();
			if (class0_0.method_0() != '"')
			{
				LogicJSONParser.ParseError("Not a string");
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (;;)
			{
				char c = class0_0.method_0();
				if (c == '\0')
				{
					goto IL_C6;
				}
				if (c == '"')
				{
					goto IL_BA;
				}
				if (c == '\\')
				{
					c = class0_0.method_0();
					if (c <= 'b')
					{
						if (c == '\0')
						{
							break;
						}
						if (c == 'b')
						{
							c = '\b';
						}
					}
					else if (c != 'f')
					{
						if (c != 'n')
						{
							switch (c)
							{
							case 'r':
								c = '\r';
								break;
							case 't':
								c = '\t';
								break;
							case 'u':
								c = (char)int.Parse(class0_0.method_1(4), NumberStyles.HexNumber);
								break;
							}
						}
						else
						{
							c = '\n';
						}
					}
					else
					{
						c = '\f';
					}
				}
				stringBuilder.Append(c);
			}
			LogicJSONParser.ParseError("Not a string");
			return null;
			IL_BA:
			return new LogicJSONString(stringBuilder.ToString());
			IL_C6:
			LogicJSONParser.ParseError("Not a string");
			return null;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00006EF8 File Offset: 0x000050F8
		private static LogicJSONBoolean smethod_4(LogicJSONParser.Class0 class0_0)
		{
			class0_0.method_3();
			char c = class0_0.method_0();
			if (c == 'f')
			{
				if (class0_0.method_0() == 'a' && class0_0.method_0() == 'l' && class0_0.method_0() == 's' && class0_0.method_0() == 'e')
				{
					return new LogicJSONBoolean(false);
				}
			}
			else if (c == 't' && class0_0.method_0() == 'r' && class0_0.method_0() == 'u' && class0_0.method_0() == 'e')
			{
				return new LogicJSONBoolean(true);
			}
			LogicJSONParser.ParseError("Not a boolean");
			return null;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00006F7C File Offset: 0x0000517C
		private static LogicJSONNull smethod_5(LogicJSONParser.Class0 class0_0)
		{
			class0_0.method_3();
			if (class0_0.method_0() == 'n' && class0_0.method_0() == 'u' && class0_0.method_0() == 'l' && class0_0.method_0() == 'l')
			{
				return new LogicJSONNull();
			}
			LogicJSONParser.ParseError("Not a null");
			return null;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00006FC8 File Offset: 0x000051C8
		private static LogicJSONNumber smethod_6(LogicJSONParser.Class0 class0_0)
		{
			class0_0.method_3();
			char c = class0_0.method_2();
			int num = 1;
			if (c == '-')
			{
				num = -1;
				c = class0_0.method_0();
			}
			if (c != ',')
			{
				int num2 = 0;
				while ((c = class0_0.method_0()) <= '9' && c >= '0')
				{
					num2 = (int)(c - '0') + 10 * num2;
					if ((c = class0_0.method_2()) > '9' || c < '0')
					{
						break;
					}
				}
				if (c != 'e' && c != 'E')
				{
					if (c != '.')
					{
						return new LogicJSONNumber(num2 * num);
					}
				}
				LogicJSONParser.ParseError("JSON floats not supported");
				return null;
			}
			LogicJSONParser.ParseError("Not a number");
			return null;
		}

		// Token: 0x02000020 RID: 32
		private class Class0
		{
			// Token: 0x06000103 RID: 259 RVA: 0x00004CCB File Offset: 0x00002ECB
			public Class0(string string_1)
			{
				this.string_0 = string_1;
			}

			// Token: 0x06000104 RID: 260 RVA: 0x00007058 File Offset: 0x00005258
			public char method_0()
			{
				if (this.int_0 >= this.string_0.Length)
				{
					return '\0';
				}
				string text = this.string_0;
				int num = this.int_0;
				this.int_0 = num + 1;
				return text[num];
			}

			// Token: 0x06000105 RID: 261 RVA: 0x00004CDA File Offset: 0x00002EDA
			public string method_1(int int_1)
			{
				if (this.int_0 + int_1 >= this.string_0.Length)
				{
					return null;
				}
				string result = this.string_0.Substring(this.int_0, int_1);
				this.int_0 += int_1;
				return result;
			}

			// Token: 0x06000106 RID: 262 RVA: 0x00004D13 File Offset: 0x00002F13
			public char method_2()
			{
				if (this.int_0 >= this.string_0.Length)
				{
					return '\0';
				}
				return this.string_0[this.int_0];
			}

			// Token: 0x06000107 RID: 263 RVA: 0x00007098 File Offset: 0x00005298
			public void method_3()
			{
				char c;
				do
				{
					c = this.method_0();
				}
				while (c <= ' ' && c != '\0');
				this.int_0--;
			}

			// Token: 0x04000039 RID: 57
			private readonly string string_0;

			// Token: 0x0400003A RID: 58
			private int int_0;
		}
	}
}
