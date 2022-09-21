using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Titan.CSV
{
	// Token: 0x02000028 RID: 40
	public class CSVNode
	{
		// Token: 0x06000159 RID: 345 RVA: 0x000050D0 File Offset: 0x000032D0
		public CSVNode(string[] lines, string fileName)
		{
			this.string_0 = fileName;
			this.Load(lines);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000803C File Offset: 0x0000623C
		public void Load(string[] lines)
		{
			this.csvtable_0 = new CSVTable(this, lines.Length);
			if (lines.Length >= 2)
			{
				LogicArrayList<string> logicArrayList = this.ParseLine(lines[0]);
				LogicArrayList<string> logicArrayList2 = this.ParseLine(lines[1]);
				for (int i = 0; i < logicArrayList.Size(); i++)
				{
					this.csvtable_0.AddColumn(logicArrayList[i]);
				}
				for (int j = 0; j < logicArrayList2.Size(); j++)
				{
					string text = logicArrayList2[j];
					int type = -1;
					if (!string.IsNullOrEmpty(text))
					{
						if (string.Equals(text, "string", StringComparison.OrdinalIgnoreCase))
						{
							type = 0;
						}
						else if (string.Equals(text, "int", StringComparison.OrdinalIgnoreCase))
						{
							type = 1;
						}
						else if (string.Equals(text, "boolean", StringComparison.OrdinalIgnoreCase))
						{
							type = 2;
						}
						else
						{
							Debugger.Error(string.Format("Invalid column type '{0}', column name {1}, file {2}. Expecting: int/string/boolean.", logicArrayList2[j], logicArrayList[j], this.string_0));
						}
					}
					this.csvtable_0.AddColumnType(type);
				}
				this.csvtable_0.ValidateColumnTypes();
				if (lines.Length > 2)
				{
					for (int k = 2; k < lines.Length; k++)
					{
						LogicArrayList<string> logicArrayList3 = this.ParseLine(lines[k]);
						if (logicArrayList3.Size() > 0)
						{
							if (!string.IsNullOrEmpty(logicArrayList3[0]))
							{
								this.csvtable_0.CreateRow();
							}
							for (int l = 0; l < logicArrayList3.Size(); l++)
							{
								this.csvtable_0.AddAndConvertValue(logicArrayList3[l], l);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x000081B0 File Offset: 0x000063B0
		public LogicArrayList<string> ParseLine(string line)
		{
			bool flag = false;
			string text = string.Empty;
			LogicArrayList<string> logicArrayList = new LogicArrayList<string>();
			for (int i = 0; i < line.Length; i++)
			{
				char c = line[i];
				if (c == '"')
				{
					if (flag)
					{
						if (i + 1 < line.Length && line[i + 1] == '"')
						{
							text += c.ToString();
						}
						else
						{
							flag = false;
						}
					}
					else
					{
						flag = true;
					}
				}
				else if (c == ',' && !flag)
				{
					logicArrayList.Add(text);
					text = string.Empty;
				}
				else
				{
					text += c.ToString();
				}
			}
			logicArrayList.Add(text);
			return logicArrayList;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x000050E6 File Offset: 0x000032E6
		public string GetFileName()
		{
			return this.string_0;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x000050EE File Offset: 0x000032EE
		public CSVTable GetTable()
		{
			return this.csvtable_0;
		}

		// Token: 0x0400004A RID: 74
		private readonly string string_0;

		// Token: 0x0400004B RID: 75
		private CSVTable csvtable_0;
	}
}
