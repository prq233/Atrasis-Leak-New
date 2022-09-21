using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Command.Battle;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic
{
	// Token: 0x02000003 RID: 3
	public class LogicNpcAttack
	{
		// Token: 0x06000011 RID: 17 RVA: 0x00011EA0 File Offset: 0x000100A0
		public LogicNpcAttack(LogicLevel level)
		{
			this.int_0 = -1;
			this.int_1 = -1;
			this.logicLevel_0 = level;
			this.logicNpcAvatar_0 = (LogicNpcAvatar)level.GetVisitorAvatar();
			this.logicBuildingClassData_0 = LogicDataTables.GetBuildingClassByName("Defense", null);
			if (this.logicBuildingClassData_0 == null)
			{
				Debugger.Error("LogicNpcAttack - Unable to find Defense building class");
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000020D2 File Offset: 0x000002D2
		public void Destruct()
		{
			this.logicLevel_0 = null;
			this.logicNpcAvatar_0 = null;
			this.logicBuildingClassData_0 = null;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00011EFC File Offset: 0x000100FC
		public bool PlaceOneUnit()
		{
			if (this.int_0 == -1 && this.int_1 == -1)
			{
				int startY = this.logicLevel_0.GetPlayArea().GetStartY();
				int widthInTiles = this.logicLevel_0.GetWidthInTiles();
				int num = -1;
				for (int i = 0; i < widthInTiles; i++)
				{
					int num2 = (startY - 1) / 2;
					int j = 0;
					while (j < startY - 1)
					{
						int num3 = ((widthInTiles >> 1) - i) * ((widthInTiles >> 1) - i) + num2 * num2;
						if ((num == -1 || num3 < num) && this.logicLevel_0.GetTileMap().GetTile(i, j).GetPassableFlag() != 0)
						{
							this.int_0 = i;
							this.int_1 = j;
							num = num3;
						}
						j++;
						num2--;
					}
				}
			}
			if (this.int_0 == -1 && this.int_1 == -1)
			{
				Debugger.Error("LogicNpcAttack::placeOneUnit - No attack position found!");
			}
			else
			{
				LogicArrayList<LogicDataSlot> units = this.logicNpcAvatar_0.GetUnits();
				for (int k = 0; k < units.Size(); k++)
				{
					LogicDataSlot logicDataSlot = units[k];
					if (logicDataSlot.GetCount() > 0)
					{
						LogicCharacter logicCharacter = LogicPlaceAttackerCommand.PlaceAttacker(this.logicNpcAvatar_0, (LogicCharacterData)logicDataSlot.GetData(), this.logicLevel_0, this.int_0 << 9, this.int_1 << 9);
						if (!this.bool_1)
						{
							logicCharacter.GetListener().MapUnlocked();
						}
						logicCharacter.GetCombatComponent().SetPreferredTarget(this.logicBuildingClassData_0, 100, false);
						this.bool_1 = true;
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000020E9 File Offset: 0x000002E9
		public void Tick()
		{
			if (!this.bool_0)
			{
				this.int_2 -= 64;
				if (this.int_2 <= 0)
				{
					this.bool_0 = !this.PlaceOneUnit();
					this.int_2 = 200;
				}
			}
		}

		// Token: 0x04000011 RID: 17
		private LogicLevel logicLevel_0;

		// Token: 0x04000012 RID: 18
		private LogicNpcAvatar logicNpcAvatar_0;

		// Token: 0x04000013 RID: 19
		private LogicBuildingClassData logicBuildingClassData_0;

		// Token: 0x04000014 RID: 20
		private bool bool_0;

		// Token: 0x04000015 RID: 21
		private bool bool_1;

		// Token: 0x04000016 RID: 22
		private int int_0;

		// Token: 0x04000017 RID: 23
		private int int_1;

		// Token: 0x04000018 RID: 24
		private int int_2;
	}
}
