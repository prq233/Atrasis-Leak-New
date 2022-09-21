using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;

namespace Atrasis.Magic.Logic.Command.Battle
{
	// Token: 0x020001EF RID: 495
	public sealed class LogicTriggerTeslaCommand : LogicCommand
	{
		// Token: 0x06001930 RID: 6448 RVA: 0x00010BE4 File Offset: 0x0000EDE4
		public LogicTriggerTeslaCommand()
		{
			this.logicJSONObject_0 = new LogicJSONObject();
		}

		// Token: 0x06001931 RID: 6449 RVA: 0x00010BF7 File Offset: 0x0000EDF7
		public LogicTriggerTeslaCommand(LogicGameObject gameObject) : this()
		{
			this.int_1 = gameObject.GetGlobalID();
			this.logicGameObjectData_0 = gameObject.GetData();
			gameObject.Save(this.logicJSONObject_0, 0);
		}

		// Token: 0x06001932 RID: 6450 RVA: 0x0005FD6C File Offset: 0x0005DF6C
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadVInt();
			this.logicGameObjectData_0 = (LogicGameObjectData)LogicDataTables.GetDataById(stream.ReadVInt());
			this.logicJSONObject_0 = LogicJSONParser.ParseObject(stream.ReadString(900000) ?? string.Empty);
			base.Decode(stream);
		}

		// Token: 0x06001933 RID: 6451 RVA: 0x00010C24 File Offset: 0x0000EE24
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteVInt(this.int_1);
			encoder.WriteVInt(this.logicGameObjectData_0.GetGlobalID());
			encoder.WriteString(LogicJSONParser.CreateJSONString(this.logicJSONObject_0, 20));
			base.Encode(encoder);
		}

		// Token: 0x06001934 RID: 6452 RVA: 0x00010C5D File Offset: 0x0000EE5D
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TRIGGER_TESLA;
		}

		// Token: 0x06001935 RID: 6453 RVA: 0x00010C64 File Offset: 0x0000EE64
		public override void Destruct()
		{
			base.Destruct();
			this.logicGameObjectData_0 = null;
			this.logicJSONObject_0 = null;
		}

		// Token: 0x06001936 RID: 6454 RVA: 0x0005FDC4 File Offset: 0x0005DFC4
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
			if (logicGameObject == null || logicGameObject.GetGameObjectType() != LogicGameObjectType.BUILDING)
			{
				Debugger.Warning("PGO == NULL in LogicTriggerTeslaCommand");
				return -2;
			}
			if (logicGameObject.IsHidden())
			{
				LogicBuilding logicBuilding = (LogicBuilding)logicGameObject;
				level.GetGameObjectManager().GetListener().AddGameObject(logicGameObject);
				logicGameObject.LoadingFinished();
				logicGameObject.GetListener().RefreshState();
				logicBuilding.Trigger();
				return 0;
			}
			Debugger.Warning("PGO building not hidden");
			return -3;
		}

		// Token: 0x06001937 RID: 6455 RVA: 0x0005FE80 File Offset: 0x0005E080
		public override void LoadFromJSON(LogicJSONObject jsonRoot)
		{
			LogicJSONObject jsonobject = jsonRoot.GetJSONObject("base");
			if (jsonobject == null)
			{
				Debugger.Error("Replay LogicTriggerTeslaCommand load failed! Base missing!");
			}
			base.LoadFromJSON(jsonobject);
			this.int_1 = jsonRoot.GetJSONNumber("id").GetIntValue();
			this.logicGameObjectData_0 = (LogicGameObjectData)LogicDataTables.GetDataById(jsonRoot.GetJSONNumber("dataid").GetIntValue());
			this.logicJSONObject_0 = jsonRoot.GetJSONObject("objs");
		}

		// Token: 0x06001938 RID: 6456 RVA: 0x0005FEF4 File Offset: 0x0005E0F4
		public override LogicJSONObject GetJSONForReplay()
		{
			LogicJSONObject logicJSONObject = new LogicJSONObject();
			logicJSONObject.Put("base", base.GetJSONForReplay());
			logicJSONObject.Put("id", new LogicJSONNumber(this.int_1));
			logicJSONObject.Put("dataid", new LogicJSONNumber(this.logicGameObjectData_0.GetGlobalID()));
			logicJSONObject.Put("objs", this.logicJSONObject_0);
			return logicJSONObject;
		}

		// Token: 0x04000DA3 RID: 3491
		private int int_1;

		// Token: 0x04000DA4 RID: 3492
		private LogicJSONObject logicJSONObject_0;

		// Token: 0x04000DA5 RID: 3493
		private LogicGameObjectData logicGameObjectData_0;
	}
}
