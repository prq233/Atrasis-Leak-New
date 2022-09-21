using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001BA RID: 442
	public sealed class LogicResumeBoostTrainingCommand : LogicCommand
	{
		// Token: 0x060017BB RID: 6075 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicResumeBoostTrainingCommand()
		{
		}

		// Token: 0x060017BC RID: 6076 RVA: 0x0000FAC6 File Offset: 0x0000DCC6
		public LogicResumeBoostTrainingCommand(int gameObjectId)
		{
			this.int_1 = gameObjectId;
		}

		// Token: 0x060017BD RID: 6077 RVA: 0x0000FAD5 File Offset: 0x0000DCD5
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060017BE RID: 6078 RVA: 0x0000FAEA File Offset: 0x0000DCEA
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060017BF RID: 6079 RVA: 0x0000FAFF File Offset: 0x0000DCFF
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.RESUME_BOOST_TRAINING;
		}

		// Token: 0x060017C0 RID: 6080 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017C1 RID: 6081 RVA: 0x0005A78C File Offset: 0x0005898C
		public override int Execute(LogicLevel level)
		{
			if (LogicDataTables.GetGlobals().UseNewTraining())
			{
				LogicUnitProduction logicUnitProduction = (this.int_1 == -2) ? level.GetGameObjectManager().GetUnitProduction() : ((this.int_1 == -1) ? level.GetGameObjectManager().GetSpellProduction() : null);
				if (logicUnitProduction != null)
				{
					logicUnitProduction.SetBoostPause(false);
					this.UpdateProductionHouseListeners(level);
				}
				return 0;
			}
			LogicGameObject gameObjectByID = level.GetGameObjectManager().GetGameObjectByID(this.int_1);
			if (gameObjectByID != null && gameObjectByID.GetGameObjectType() == LogicGameObjectType.BUILDING && gameObjectByID.IsBoostPaused())
			{
				LogicBuilding logicBuilding = (LogicBuilding)gameObjectByID;
				if (logicBuilding.CanStopBoost())
				{
					logicBuilding.SetBoostPause(false);
					logicBuilding.GetListener().RefreshState();
					return 0;
				}
			}
			return -1;
		}

		// Token: 0x060017C2 RID: 6082 RVA: 0x0005A830 File Offset: 0x00058A30
		public void UpdateProductionHouseListeners(LogicLevel level)
		{
			LogicArrayList<LogicGameObject> gameObjects = level.GetGameObjectManager().GetGameObjects(LogicGameObjectType.BUILDING);
			for (int i = 0; i < gameObjects.Size(); i++)
			{
				LogicBuilding logicBuilding = (LogicBuilding)gameObjects[i];
				if (logicBuilding.GetBuildingData().GetUnitProduction(0) > 0)
				{
					logicBuilding.GetListener().RefreshState();
				}
			}
		}

		// Token: 0x04000CFE RID: 3326
		private int int_1;
	}
}
