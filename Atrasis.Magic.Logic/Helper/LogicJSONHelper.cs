using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Offer;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Helper
{
	// Token: 0x0200010B RID: 267
	public static class LogicJSONHelper
	{
		// Token: 0x06000CB9 RID: 3257 RVA: 0x0002BBFC File Offset: 0x00029DFC
		public static bool GetBool(LogicJSONObject jsonObject, string key)
		{
			LogicJSONBoolean jsonboolean = jsonObject.GetJSONBoolean(key);
			return jsonboolean != null && jsonboolean.IsTrue();
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x000092F6 File Offset: 0x000074F6
		public static LogicLong GetLogicLong(LogicJSONObject jsonObject, string key)
		{
			return new LogicLong(LogicJSONHelper.GetInt(jsonObject, key + "_hi"), LogicJSONHelper.GetInt(jsonObject, key + "_lo"));
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x0000931F File Offset: 0x0000751F
		public static void SetInt(LogicJSONObject jsonObject, string key, int value)
		{
			jsonObject.Put(key, new LogicJSONNumber(value));
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x0000932E File Offset: 0x0000752E
		public static void SetString(LogicJSONObject jsonObject, string key, string value)
		{
			jsonObject.Put(key, new LogicJSONString(value));
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x0000933D File Offset: 0x0000753D
		public static void SetBool(LogicJSONObject jsonObject, string key, bool value)
		{
			jsonObject.Put(key, new LogicJSONBoolean(value));
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x0000934C File Offset: 0x0000754C
		public static void SetLogicLong(LogicJSONObject jsonObject, string key, LogicLong value)
		{
			if (value != null)
			{
				LogicJSONHelper.SetInt(jsonObject, key + "_hi", value.GetHigherInt());
				LogicJSONHelper.SetInt(jsonObject, key + "_lo", value.GetLowerInt());
			}
		}

		// Token: 0x06000CBF RID: 3263 RVA: 0x0000937F File Offset: 0x0000757F
		public static int GetInt(LogicJSONObject jsonObject, string key)
		{
			return LogicJSONHelper.GetInt(jsonObject, key, -1, true);
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x0000938A File Offset: 0x0000758A
		public static int GetInt(LogicJSONObject jsonObject, string key, int defaultValue)
		{
			return LogicJSONHelper.GetInt(jsonObject, key, defaultValue, false);
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x0002BC1C File Offset: 0x00029E1C
		public static int GetInt(LogicJSONObject jsonObject, string key, int defaultValue, bool throwIfNotExist)
		{
			if (jsonObject != null && key.Length != 0)
			{
				LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber(key);
				if (jsonnumber != null)
				{
					return jsonnumber.GetIntValue();
				}
				if (!throwIfNotExist)
				{
					return defaultValue;
				}
				Debugger.Error(string.Format("Json number with key='{0}' not found!", key));
			}
			return -1;
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x00009395 File Offset: 0x00007595
		public static string GetString(LogicJSONObject jsonObject, string key)
		{
			return LogicJSONHelper.GetString(jsonObject, key, string.Empty, true);
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x0002BC5C File Offset: 0x00029E5C
		public static string GetString(LogicJSONObject jsonObject, string key, string defaultValue, bool throwIfNotExist)
		{
			if (jsonObject != null && key.Length != 0)
			{
				LogicJSONString jsonstring = jsonObject.GetJSONString(key);
				if (jsonstring != null)
				{
					return jsonstring.GetStringValue();
				}
				if (!throwIfNotExist)
				{
					return defaultValue;
				}
				Debugger.Error(string.Format("Json string with key='{0}' not found!", key));
			}
			return null;
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x000093A4 File Offset: 0x000075A4
		public static LogicData GetLogicData(LogicJSONObject jsonObject, string key)
		{
			LogicData dataById = LogicDataTables.GetDataById(LogicStringUtil.ConvertToInt(LogicJSONHelper.GetString(jsonObject, key, string.Empty, true)));
			if (dataById == null)
			{
				Debugger.Error("Unable to load data. key:" + key);
			}
			return dataById;
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x000093D0 File Offset: 0x000075D0
		public static LogicDeliverable GetLogicDeliverable(LogicJSONObject jsonObject)
		{
			LogicDeliverable logicDeliverable = LogicDeliverableFactory.CreateByType(LogicStringUtil.ConvertToInt(LogicJSONHelper.GetString(jsonObject, "type")));
			logicDeliverable.ReadFromJSON(jsonObject);
			return logicDeliverable;
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x0002BC9C File Offset: 0x00029E9C
		public static void SetLogicData(LogicJSONObject jsonObject, string key, LogicData value)
		{
			if (value != null)
			{
				jsonObject.Put(key, new LogicJSONString(value.GetGlobalID().ToString()));
				return;
			}
			Debugger.Error("Unable to set null data. key:" + key);
		}
	}
}
