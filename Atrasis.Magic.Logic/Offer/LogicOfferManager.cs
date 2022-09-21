using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Time;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Offer
{
	// Token: 0x02000023 RID: 35
	public class LogicOfferManager
	{
		// Token: 0x0600015F RID: 351 RVA: 0x00002F4B File Offset: 0x0000114B
		public LogicOfferManager(LogicLevel level)
		{
			this.logicLevel_0 = level;
			this.logicArrayList_0 = new LogicArrayList<LogicOffer>();
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00017680 File Offset: 0x00015880
		public void Init()
		{
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.GEM_BUNDLE);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicOffer item = new LogicOffer(new LogicBundleOfferData((LogicGemBundleData)table.GetItemAt(i)), this.logicLevel_0);
				this.logicArrayList_0.Add(item);
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00002F65 File Offset: 0x00001165
		public void Destruct()
		{
			this.logicLevel_0 = null;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000176D0 File Offset: 0x000158D0
		public void Load(LogicJSONObject root)
		{
			LogicJSONObject jsonobject = root.GetJSONObject("offer");
			if (jsonobject != null)
			{
				this.logicJSONObject_0 = jsonobject;
				if (this.logicTimer_0 != null)
				{
					this.logicTimer_0.Destruct();
					this.logicTimer_0 = null;
				}
				this.logicTimer_0 = LogicTimer.GetLogicTimer(jsonobject, this.logicLevel_0.GetLogicTime(), "pct", 604800);
				if (jsonobject.Get("t") != null)
				{
					this.bool_0 = true;
				}
				LogicJSONArray jsonarray = jsonobject.GetJSONArray("offers");
				if (jsonarray != null)
				{
					for (int i = 0; i < jsonarray.Size(); i++)
					{
						LogicJSONObject logicJSONObject = (LogicJSONObject)jsonarray.Get(i);
						if (logicJSONObject != null)
						{
							int @int = LogicJSONHelper.GetInt(logicJSONObject, "data", -1);
							if (@int != -1)
							{
								LogicOffer offerById = this.GetOfferById(@int);
								if (offerById != null)
								{
									offerById.Load(logicJSONObject);
								}
							}
						}
						else
						{
							Debugger.Error("LogicOfferManager::load - Offer is NULL!");
						}
					}
				}
				for (int j = 0; j < 2; j++)
				{
					LogicJSONNumber logicJSONNumber = (LogicJSONNumber)jsonobject.Get((j == 1) ? "top2" : "top");
					if (logicJSONNumber != null)
					{
						this.logicOffer_0[j] = this.GetOfferById(logicJSONNumber.GetIntValue());
					}
				}
			}
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000177F4 File Offset: 0x000159F4
		public void Save(LogicJSONObject root)
		{
			if (this.logicJSONObject_0 != null && this.logicLevel_0.GetState() != 1)
			{
				root.Put("offer", this.logicJSONObject_0);
				return;
			}
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			LogicTimer.SetLogicTimer(logicJSONObject, this.logicTimer_0, this.logicLevel_0, "pct");
			if (this.bool_0)
			{
				logicJSONObject.Put("t", new LogicJSONBoolean(true));
			}
			LogicJSONArray logicJSONArray = new LogicJSONArray();
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				LogicJSONObject logicJSONObject2 = this.logicArrayList_0[i].Save();
				if (logicJSONObject2 != null)
				{
					logicJSONArray.Add(logicJSONObject2);
				}
			}
			if (this.logicJSONObject_0 != null)
			{
				LogicJSONArray jsonarray = this.logicJSONObject_0.GetJSONArray("offers");
				if (jsonarray != null)
				{
					for (int j = 0; j < jsonarray.Size(); j++)
					{
						LogicJSONObject logicJSONObject3 = (LogicJSONObject)jsonarray.Get(j);
						if (logicJSONObject3 != null)
						{
							int @int = LogicJSONHelper.GetInt(logicJSONObject, "data", -1);
							if (this.GetOfferById(@int) == null)
							{
								logicJSONArray.Add(logicJSONObject3);
							}
						}
					}
				}
			}
			root.Put("offers", logicJSONArray);
			for (int k = 0; k < 2; k++)
			{
				if (this.logicOffer_0[k] != null)
				{
					root.Put((k == 1) ? "top2" : "top", new LogicJSONNumber(this.logicOffer_0[k].GetData().GetId()));
				}
			}
			root.Put("offer", logicJSONObject);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00002F6E File Offset: 0x0000116E
		public void FastForward(int time)
		{
			if (this.logicTimer_0 != null)
			{
				this.logicTimer_0.FastForward(time);
			}
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00017964 File Offset: 0x00015B64
		public LogicOffer GetOfferById(int id)
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				if (this.logicArrayList_0[i].GetId() == id)
				{
					return this.logicArrayList_0[i];
				}
			}
			return null;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x000179AC File Offset: 0x00015BAC
		public void OfferBuyed(LogicOffer offer)
		{
			LogicOfferData data = offer.GetData();
			if (data.GetLinkedPackageId() != 0)
			{
				this.bool_0 = true;
			}
			int shopFrontPageCooldownAfterPurchaseSeconds = data.GetShopFrontPageCooldownAfterPurchaseSeconds();
			if (shopFrontPageCooldownAfterPurchaseSeconds > 0)
			{
				if (this.logicTimer_0 != null)
				{
					this.logicTimer_0.Destruct();
					this.logicTimer_0 = null;
				}
				this.logicTimer_0 = new LogicTimer();
				this.logicTimer_0.StartTimer(shopFrontPageCooldownAfterPurchaseSeconds, this.logicLevel_0.GetLogicTime(), false, -1);
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00002F84 File Offset: 0x00001184
		public void Tick()
		{
			if (this.logicTimer_0 != null && this.logicTimer_0.GetRemainingSeconds(this.logicLevel_0.GetLogicTime()) <= 0 && this.logicTimer_0 != null)
			{
				this.logicTimer_0.Destruct();
				this.logicTimer_0 = null;
			}
		}

		// Token: 0x04000081 RID: 129
		private LogicLevel logicLevel_0;

		// Token: 0x04000082 RID: 130
		private LogicTimer logicTimer_0;

		// Token: 0x04000083 RID: 131
		private LogicOffer[] logicOffer_0;

		// Token: 0x04000084 RID: 132
		private LogicJSONObject logicJSONObject_0;

		// Token: 0x04000085 RID: 133
		private readonly LogicArrayList<LogicOffer> logicArrayList_0;

		// Token: 0x04000086 RID: 134
		private bool bool_0;
	}
}
