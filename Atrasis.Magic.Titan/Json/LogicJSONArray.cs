using System;
using System.Text;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Titan.Json
{
	// Token: 0x02000018 RID: 24
	public class LogicJSONArray : LogicJSONNode
	{
		// Token: 0x060000CB RID: 203 RVA: 0x00004B27 File Offset: 0x00002D27
		public LogicJSONArray()
		{
			this.logicArrayList_0 = new LogicArrayList<LogicJSONNode>(20);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004B3C File Offset: 0x00002D3C
		public LogicJSONArray(int capacity)
		{
			this.logicArrayList_0 = new LogicArrayList<LogicJSONNode>(capacity);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00004B50 File Offset: 0x00002D50
		public LogicJSONNode Get(int idx)
		{
			return this.logicArrayList_0[idx];
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00004B5E File Offset: 0x00002D5E
		public void Add(LogicJSONNode item)
		{
			this.logicArrayList_0.Add(item);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00006614 File Offset: 0x00004814
		public LogicJSONArray GetJSONArray(int index)
		{
			LogicJSONNode logicJSONNode = this.logicArrayList_0[index];
			if (logicJSONNode.GetJSONNodeType() != LogicJSONNodeType.ARRAY)
			{
				Debugger.Warning(string.Format("LogicJSONObject::getJSONArray wrong type {0}, index {1}", logicJSONNode.GetJSONNodeType(), index));
				return null;
			}
			return (LogicJSONArray)logicJSONNode;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00006660 File Offset: 0x00004860
		public LogicJSONBoolean GetJSONBoolean(int index)
		{
			LogicJSONNode logicJSONNode = this.logicArrayList_0[index];
			if (logicJSONNode.GetJSONNodeType() != LogicJSONNodeType.BOOLEAN)
			{
				Debugger.Warning(string.Format("LogicJSONObject::getJSONBoolean wrong type {0}, index {1}", logicJSONNode.GetJSONNodeType(), index));
				return null;
			}
			return (LogicJSONBoolean)logicJSONNode;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000066AC File Offset: 0x000048AC
		public LogicJSONNumber GetJSONNumber(int index)
		{
			LogicJSONNode logicJSONNode = this.logicArrayList_0[index];
			if (logicJSONNode.GetJSONNodeType() != LogicJSONNodeType.NUMBER)
			{
				Debugger.Warning(string.Format("LogicJSONObject::getJSONNumber wrong type {0}, index {1}", logicJSONNode.GetJSONNodeType(), index));
				return null;
			}
			return (LogicJSONNumber)logicJSONNode;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000066F8 File Offset: 0x000048F8
		public LogicJSONObject GetJSONObject(int index)
		{
			LogicJSONNode logicJSONNode = this.logicArrayList_0[index];
			if (logicJSONNode.GetJSONNodeType() != LogicJSONNodeType.OBJECT)
			{
				Debugger.Warning(string.Concat(new object[]
				{
					"LogicJSONObject::getJSONObject wrong type ",
					logicJSONNode.GetJSONNodeType(),
					", index ",
					index
				}));
				return null;
			}
			return (LogicJSONObject)logicJSONNode;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000675C File Offset: 0x0000495C
		public LogicJSONString GetJSONString(int index)
		{
			LogicJSONNode logicJSONNode = this.logicArrayList_0[index];
			if (logicJSONNode.GetJSONNodeType() != LogicJSONNodeType.STRING)
			{
				Debugger.Warning(string.Format("LogicJSONObject::getJSONString wrong type {0}, index {1}", logicJSONNode.GetJSONNodeType(), index));
				return null;
			}
			return (LogicJSONString)logicJSONNode;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00004B6C File Offset: 0x00002D6C
		public int Size()
		{
			return this.logicArrayList_0.Size();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000044E6 File Offset: 0x000026E6
		public override LogicJSONNodeType GetJSONNodeType()
		{
			return LogicJSONNodeType.ARRAY;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x000067A8 File Offset: 0x000049A8
		public override void WriteToString(StringBuilder builder)
		{
			builder.Append('[');
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (i > 0)
				{
					builder.Append(',');
				}
				this.logicArrayList_0[i].WriteToString(builder);
			}
			builder.Append(']');
		}

		// Token: 0x0400002D RID: 45
		private readonly LogicArrayList<LogicJSONNode> logicArrayList_0;
	}
}
