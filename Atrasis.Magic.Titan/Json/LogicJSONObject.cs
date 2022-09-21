using System;
using System.Text;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Titan.Json
{
	// Token: 0x0200001E RID: 30
	public class LogicJSONObject : LogicJSONNode
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x00004C0A File Offset: 0x00002E0A
		public LogicJSONObject()
		{
			this.logicArrayList_0 = new LogicArrayList<string>(20);
			this.logicArrayList_1 = new LogicArrayList<LogicJSONNode>(20);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00004C2C File Offset: 0x00002E2C
		public LogicJSONObject(int capacity)
		{
			this.logicArrayList_0 = new LogicArrayList<string>(capacity);
			this.logicArrayList_1 = new LogicArrayList<LogicJSONNode>(capacity);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00004C4C File Offset: 0x00002E4C
		public void Destruct()
		{
			if (this.logicArrayList_0 != null)
			{
				this.logicArrayList_0.Destruct();
				this.logicArrayList_0 = null;
			}
			if (this.logicArrayList_1 != null)
			{
				this.logicArrayList_1.Destruct();
				this.logicArrayList_1 = null;
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000067FC File Offset: 0x000049FC
		public LogicJSONNode Get(string key)
		{
			int num = this.logicArrayList_0.IndexOf(key);
			if (num == -1)
			{
				return null;
			}
			return this.logicArrayList_1[num];
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00006828 File Offset: 0x00004A28
		public LogicJSONArray GetJSONArray(string key)
		{
			int num = this.logicArrayList_0.IndexOf(key);
			if (num == -1)
			{
				return null;
			}
			LogicJSONNode logicJSONNode = this.logicArrayList_1[num];
			if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.ARRAY)
			{
				return (LogicJSONArray)logicJSONNode;
			}
			Debugger.Warning(string.Format("LogicJSONObject::getJSONArray type is {0}, key {1}", logicJSONNode.GetJSONNodeType(), key));
			return null;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00006884 File Offset: 0x00004A84
		public LogicJSONBoolean GetJSONBoolean(string key)
		{
			int num = this.logicArrayList_0.IndexOf(key);
			if (num == -1)
			{
				return null;
			}
			LogicJSONNode logicJSONNode = this.logicArrayList_1[num];
			if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.BOOLEAN)
			{
				return (LogicJSONBoolean)logicJSONNode;
			}
			Debugger.Warning(string.Format("LogicJSONObject::getJSONBoolean type is {0}, key {1}", logicJSONNode.GetJSONNodeType(), key));
			return null;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000068E0 File Offset: 0x00004AE0
		public LogicJSONNumber GetJSONNumber(string key)
		{
			int num = this.logicArrayList_0.IndexOf(key);
			if (num == -1)
			{
				return null;
			}
			LogicJSONNode logicJSONNode = this.logicArrayList_1[num];
			if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.NUMBER)
			{
				return (LogicJSONNumber)logicJSONNode;
			}
			Debugger.Warning(string.Format("LogicJSONObject::getJSONNumber type is {0}, key {1}", logicJSONNode.GetJSONNodeType(), key));
			return null;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000693C File Offset: 0x00004B3C
		public LogicJSONObject GetJSONObject(string key)
		{
			int num = this.logicArrayList_0.IndexOf(key);
			if (num == -1)
			{
				return null;
			}
			LogicJSONNode logicJSONNode = this.logicArrayList_1[num];
			if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.OBJECT)
			{
				return (LogicJSONObject)logicJSONNode;
			}
			Debugger.Warning(string.Format("LogicJSONObject::getJSONObject type is {0}, key {1}", logicJSONNode.GetJSONNodeType(), key));
			return null;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00006998 File Offset: 0x00004B98
		public LogicJSONString GetJSONString(string key)
		{
			int num = this.logicArrayList_0.IndexOf(key);
			if (num == -1)
			{
				return null;
			}
			LogicJSONNode logicJSONNode = this.logicArrayList_1[num];
			if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.STRING)
			{
				return (LogicJSONString)logicJSONNode;
			}
			Debugger.Warning(string.Format("LogicJSONObject::getJSONString type is {0}, key {1}", logicJSONNode.GetJSONNodeType(), key));
			return null;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000069F4 File Offset: 0x00004BF4
		public void Put(string key, LogicJSONNode item)
		{
			if (this.logicArrayList_0.IndexOf(key) != -1)
			{
				Debugger.Error(string.Format("LogicJSONObject::put already contains key {0}", key));
				return;
			}
			if (this.logicArrayList_1.IndexOf(item) != -1)
			{
				Debugger.Error(string.Format("LogicJSONObject::put already contains the given JSONNode pointer. Key {0}", key));
				return;
			}
			this.logicArrayList_1.Add(item);
			this.logicArrayList_0.Add(key);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00006A5C File Offset: 0x00004C5C
		public void Remove(string key)
		{
			int num = this.logicArrayList_0.IndexOf(key);
			if (num != -1)
			{
				this.logicArrayList_0.Remove(num);
				this.logicArrayList_1.Remove(num);
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00004C82 File Offset: 0x00002E82
		public int GetObjectCount()
		{
			return this.logicArrayList_1.Size();
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00004C8F File Offset: 0x00002E8F
		public override LogicJSONNodeType GetJSONNodeType()
		{
			return LogicJSONNodeType.OBJECT;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00006A94 File Offset: 0x00004C94
		public override void WriteToString(StringBuilder builder)
		{
			builder.Append('{');
			for (int i = 0; i < this.logicArrayList_1.Size(); i++)
			{
				if (i > 0)
				{
					builder.Append(',');
				}
				LogicJSONParser.WriteString(this.logicArrayList_0[i], builder);
				builder.Append(':');
				this.logicArrayList_1[i].WriteToString(builder);
			}
			builder.Append('}');
		}

		// Token: 0x04000037 RID: 55
		private LogicArrayList<string> logicArrayList_0;

		// Token: 0x04000038 RID: 56
		private LogicArrayList<LogicJSONNode> logicArrayList_1;
	}
}
