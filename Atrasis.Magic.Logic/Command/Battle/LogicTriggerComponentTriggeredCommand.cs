using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001ED RID: 493
	public sealed class LogicTriggerComponentTriggeredCommand : LogicCommand
	{
		// Token: 0x0600191F RID: 6431 RVA: 0x00010B07 File Offset: 0x0000ED07
		public LogicTriggerComponentTriggeredCommand()
		{
			this.logicJSONObject_0 = new LogicJSONObject();
		}

		// Token: 0x06001920 RID: 6432 RVA: 0x00010B1A File Offset: 0x0000ED1A
		public LogicTriggerComponentTriggeredCommand(LogicGameObject gameObject) : this()
		{
			this.int_1 = gameObject.GetGlobalID();
			this.logicGameObjectData_0 = gameObject.GetData();
			gameObject.Save(this.logicJSONObject_0, 0);
		}

		// Token: 0x06001921 RID: 6433 RVA: 0x0005FA24 File Offset: 0x0005DC24
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadVInt();
			this.logicGameObjectData_0 = (LogicGameObjectData)LogicDataTables.GetDataById(stream.ReadVInt());
			this.logicJSONObject_0 = LogicJSONParser.ParseObject(stream.ReadString(900000) ?? string.Empty);
			base.Decode(stream);
		}

		// Token: 0x06001922 RID: 6434 RVA: 0x00010B47 File Offset: 0x0000ED47
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteVInt(this.int_1);
			encoder.WriteVInt(this.logicGameObjectData_0.GetGlobalID());
			encoder.WriteString(LogicJSONParser.CreateJSONString(this.logicJSONObject_0, 20));
			base.Encode(encoder);
		}

		// Token: 0x06001923 RID: 6435 RVA: 0x00010B80 File Offset: 0x0000ED80
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TRIGGER_COMPONENT_TRIGGERED;
		}

		// Token: 0x06001924 RID: 6436 RVA: 0x00010B87 File Offset: 0x0000ED87
		public override void Destruct()
		{
			base.Destruct();
			this.logicGameObjectData_0 = null;
			this.logicJSONObject_0 = null;
		}

		// Token: 0x06001925 RID: 6437 RVA: 0x0005FA7C File Offset: 0x0005DC7C
		public override int Execute(LogicLevel level)
		{
			if (level == null)
			{
				return -1;
			}
			LogicGameObject logicGameObject;
			if (level.GetState() == 5)
			{
				logicGameObject = LogicGameObjectFactory.CreateGameObject(this.logicGameObjectData_0, level, level.GetVillageType());
				logicGameObject.Load(this.logicJSONObject_0);
				level.GetGameObjectManager().AddGameObject(logicGameObject, -1);
			}
			else
			{
				logicGameObject = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			}
			if (logicGameObject != null)
			{
				if (logicGameObject.GetGameObjectType() == LogicGameObjectType.TRAP)
				{
					LogicGameObject logicGameObject2 = (LogicTrap)logicGameObject;
					level.GetGameObjectManager().GetListener().AddGameObject(logicGameObject);
					logicGameObject.LoadingFinished();
					logicGameObject.GetListener().RefreshState();
					LogicTriggerComponent triggerComponent = logicGameObject2.GetTriggerComponent();
					if (triggerComponent != null)
					{
						triggerComponent.SetTriggered();
					}
				}
				return 0;
			}
			Debugger.Warning("PGO == NULL in LogicTriggerComponentTriggeredCommand");
			return -2;
		}

		// Token: 0x06001926 RID: 6438 RVA: 0x0005FB2C File Offset: 0x0005DD2C
		public override void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONObject jsonobject = jsonRoot.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("Replay LogicTriggerComponentTriggeredCommand load failed! Base missing!");
			}
			base.LoadFromJSON(jsonobject);
			this.int_1 = jsonRoot.GetJSONNumber("id").GetIntValue();
			this.logicGameObjectData_0 = (LogicGameObjectData)LogicDataTables.GetDataById(jsonRoot.GetJSONNumber("dataid").GetIntValue());
			this.logicJSONObject_0 = jsonRoot.GetJSONObject("objs");
		}

		// Token: 0x06001927 RID: 6439 RVA: 0x0005FBA0 File Offset: 0x0005DDA0
		public override LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("base", base.GetJSONForReplay());
			logicJSONObject.Put("id", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("dataid", new LogicJSONNumber(this.logicGameObjectData_0.GetGlobalID()));
			logicJSONObject.Put("objs", this.logicJSONObject_0);
			return logicJSONObject;
		}

		// Token: 0x04000D9F RID: 3487
		private int int_1;

		// Token: 0x04000DA0 RID: 3488
		private LogicJSONObject logicJSONObject_0;

		// Token: 0x04000DA1 RID: 3489
		private LogicGameObjectData logicGameObjectData_0;
	}
}
