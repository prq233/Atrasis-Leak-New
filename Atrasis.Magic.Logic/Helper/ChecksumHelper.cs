using System;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Helper
{
	// Token: 0x02000108 RID: 264
	public class ChecksumHelper
	{
		// Token: 0x06000CA8 RID: 3240 RVA: 0x000092AE File Offset: 0x000074AE
		public ChecksumHelper(LogicJSONObject root)
		{
			if (root != null)
			{
				this.logicArrayList_0 = new LogicArrayList<LogicJSONNode>(16);
				this.logicArrayList_0.Add(root);
			}
		}

		// Token: 0x06000CA9 RID: 3241 RVA: 0x0002B690 File Offset: 0x00029890
		public void StartObject(string name)
		{
			if (this.logicArrayList_0 != null)
			{
				LogicJSONObject logicJSONObject = new LogicJSONObject();
				LogicJSONNode logicJSONNode = this.logicArrayList_0[this.logicArrayList_0.Size() - 1];
				if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.OBJECT)
				{
					((LogicJSONObject)logicJSONNode).Put(name, logicJSONObject);
				}
				else if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.ARRAY)
				{
					((LogicJSONArray)logicJSONNode).Add(logicJSONObject);
					logicJSONObject.Put("name", new LogicJSONString(name));
				}
				this.logicArrayList_0.Add(logicJSONObject);
			}
		}

		// Token: 0x06000CAA RID: 3242 RVA: 0x0002B710 File Offset: 0x00029910
		public void EndObject()
		{
			if (this.logicArrayList_0 != null)
			{
				Debugger.DoAssert(this.logicArrayList_0[this.logicArrayList_0.Size() - 1].GetJSONNodeType() == LogicJSONNodeType.OBJECT, "ChecksumHelper::endObject() called but top is not an object");
				Debugger.DoAssert(this.logicArrayList_0.Size() > 1, "ChecksumHelper::endObject() - size is too small");
				this.logicArrayList_0.Remove(this.logicArrayList_0.Size() - 1);
			}
		}

		// Token: 0x06000CAB RID: 3243 RVA: 0x0002B784 File Offset: 0x00029984
		public void StartArray(string name)
		{
			if (this.logicArrayList_0 != null)
			{
				LogicJSONNode logicJSONNode = this.logicArrayList_0[this.logicArrayList_0.Size() - 1];
				if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.OBJECT)
				{
					LogicJSONArray item = new LogicJSONArray();
					((LogicJSONObject)logicJSONNode).Put(name, item);
					this.logicArrayList_0.Add(item);
					return;
				}
				if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.ARRAY)
				{
					Debugger.DoAssert(((LogicJSONArray)logicJSONNode).Size() != 0, "ChecksumHelper::startArray can't handle the truth (array inside array)");
				}
			}
		}

		// Token: 0x06000CAC RID: 3244 RVA: 0x0002B800 File Offset: 0x00029A00
		public void EndArray()
		{
			if (this.logicArrayList_0 != null)
			{
				Debugger.DoAssert(this.logicArrayList_0[this.logicArrayList_0.Size() - 1].GetJSONNodeType() == LogicJSONNodeType.ARRAY, "ChecksumHelper::endArray() called but top is not an array");
				Debugger.DoAssert(this.logicArrayList_0.Size() > 1, "ChecksumHelper::endArray() - size is too small");
				this.logicArrayList_0.Remove(this.logicArrayList_0.Size() - 1);
			}
		}

		// Token: 0x06000CAD RID: 3245 RVA: 0x0002B874 File Offset: 0x00029A74
		public void WriteValue(string name, int value)
		{
			this.int_0 += value;
			if (this.logicArrayList_0 != null)
			{
				LogicJSONNode logicJSONNode = this.logicArrayList_0[this.logicArrayList_0.Size() - 1];
				if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.OBJECT)
				{
					((LogicJSONObject)logicJSONNode).Put(name, new LogicJSONNumber(value));
					return;
				}
				if (logicJSONNode.GetJSONNodeType() == LogicJSONNodeType.ARRAY)
				{
					((LogicJSONArray)logicJSONNode).Add(new LogicJSONString(string.Format("{0} {1}", name, value)));
				}
			}
		}

		// Token: 0x06000CAE RID: 3246 RVA: 0x000092D2 File Offset: 0x000074D2
		public int GetChecksum()
		{
			return this.int_0;
		}

		// Token: 0x06000CAF RID: 3247 RVA: 0x000092DA File Offset: 0x000074DA
		public void Destruct()
		{
			if (this.logicArrayList_0 != null)
			{
				this.logicArrayList_0.Destruct();
				this.logicArrayList_0 = null;
			}
		}

		// Token: 0x0400050B RID: 1291
		private int int_0;

		// Token: 0x0400050C RID: 1292
		private LogicArrayList<LogicJSONNode> logicArrayList_0;
	}
}
