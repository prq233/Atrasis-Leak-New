using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.GameObject.Listener;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B6 RID: 438
	public sealed class LogicRemoveUnitsCommand : LogicCommand
	{
		// Token: 0x060017A4 RID: 6052 RVA: 0x0000F98D File Offset: 0x0000DB8D
		public LogicRemoveUnitsCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<int>();
			this.logicArrayList_1 = new LogicArrayList<int>();
			this.logicArrayList_2 = new LogicArrayList<int>();
			this.logicArrayList_3 = new LogicArrayList<LogicCombatItemData>();
		}

		// Token: 0x060017A5 RID: 6053 RVA: 0x0005A0C8 File Offset: 0x000582C8
		public override void Decode(ByteStream stream)
		{
			int i = 0;
			int num = stream.ReadInt();
			while (i < num)
			{
				this.logicArrayList_0.Add(stream.ReadInt());
				this.logicArrayList_3.Add((LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream, (stream.ReadInt() != 0) ? LogicDataType.SPELL : LogicDataType.CHARACTER));
				this.logicArrayList_2.Add(stream.ReadInt());
				this.logicArrayList_1.Add(stream.ReadInt());
				i++;
			}
			base.Decode(stream);
		}

		// Token: 0x060017A6 RID: 6054 RVA: 0x0005A148 File Offset: 0x00058348
		public override void Encode(ChecksumEncoder encoder)
		{
			for (int i = 0; i < this.logicArrayList_0.Size(); i++)
			{
				encoder.WriteInt(this.logicArrayList_0[i]);
				ByteStreamHelper.WriteDataReference(encoder, this.logicArrayList_3[i]);
				encoder.WriteInt(this.logicArrayList_2[i]);
				encoder.WriteInt(this.logicArrayList_1[i]);
			}
			base.Encode(encoder);
		}

		// Token: 0x060017A7 RID: 6055 RVA: 0x0000F9C1 File Offset: 0x0000DBC1
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.REMOVE_UNITS;
		}

		// Token: 0x060017A8 RID: 6056 RVA: 0x0005A1BC File Offset: 0x000583BC
		public override int Execute(LogicLevel level)
		{
			for (int i = 0; i < this.logicArrayList_2.Size(); i++)
			{
				if (this.logicArrayList_2[i] < 0)
				{
					return -1;
				}
			}
			if (LogicDataTables.GetGlobals().EnableTroopDeletion() && level.GetState() == 1 && this.logicArrayList_3.Size() > 0)
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				int num = 0;
				for (int j = 0; j < this.logicArrayList_3.Size(); j++)
				{
					LogicCombatItemData logicCombatItemData = this.logicArrayList_3[j];
					int num2 = this.logicArrayList_2[j];
					if (this.logicArrayList_0[j] != 0)
					{
						int upgLevel = this.logicArrayList_1[j];
						if (logicCombatItemData.GetCombatItemType() != LogicCombatItemType.CHARACTER)
						{
							if (logicCombatItemData.GetCombatItemType() == LogicCombatItemType.SPELL)
							{
								playerAvatar.SetAllianceUnitCount(logicCombatItemData, upgLevel, LogicMath.Max(0, playerAvatar.GetAllianceUnitCount(logicCombatItemData, upgLevel) - num2));
								for (int k = 0; k < num2; k++)
								{
									playerAvatar.GetChangeListener().AllianceUnitRemoved(logicCombatItemData, upgLevel);
								}
								num |= 2;
							}
						}
						else
						{
							LogicBuilding allianceCastle = level.GetGameObjectManagerAt(0).GetAllianceCastle();
							if (allianceCastle != null)
							{
								LogicBunkerComponent bunkerComponent = allianceCastle.GetBunkerComponent();
								int unitTypeIndex = bunkerComponent.GetUnitTypeIndex(logicCombatItemData);
								if (unitTypeIndex != -1 && bunkerComponent.GetUnitCount(unitTypeIndex) > 0)
								{
									bunkerComponent.RemoveUnits(logicCombatItemData, upgLevel, num2);
									playerAvatar.SetAllianceUnitCount(logicCombatItemData, upgLevel, LogicMath.Max(0, playerAvatar.GetAllianceUnitCount(logicCombatItemData, upgLevel) - num2));
									num |= 1;
									for (int l = 0; l < num2; l++)
									{
										playerAvatar.GetChangeListener().AllianceUnitRemoved(logicCombatItemData, upgLevel);
									}
								}
							}
						}
					}
					else
					{
						if (playerAvatar != null && logicCombatItemData != null)
						{
							playerAvatar.CommodityCountChangeHelper(0, logicCombatItemData, -num2);
						}
						LogicArrayList<LogicComponent> components = level.GetComponentManager().GetComponents(LogicComponentType.UNIT_STORAGE);
						for (int m = 0; m < components.Size(); m++)
						{
							if (num2 > 0)
							{
								LogicUnitStorageComponent logicUnitStorageComponent = (LogicUnitStorageComponent)components[m];
								int unitTypeIndex2 = logicUnitStorageComponent.GetUnitTypeIndex(logicCombatItemData);
								if (unitTypeIndex2 != -1)
								{
									int num3 = logicUnitStorageComponent.GetUnitCount(unitTypeIndex2);
									if (num3 > 0)
									{
										num3 = LogicMath.Min(num3, num2);
										logicUnitStorageComponent.RemoveUnits(logicCombatItemData, num3);
										int num4 = 2;
										if (logicCombatItemData.GetCombatItemType() == LogicCombatItemType.CHARACTER)
										{
											if (logicUnitStorageComponent.GetParentListener() != null)
											{
												LogicGameObjectListener parentListener = logicUnitStorageComponent.GetParentListener();
												for (int n = 0; n < num3; n++)
												{
													parentListener.UnitRemoved(logicCombatItemData);
												}
											}
											num4 = 1;
										}
										num2 -= num3;
										num |= num4;
									}
								}
							}
						}
					}
				}
				switch (num)
				{
				case 1:
					if (LogicDataTables.GetGlobals().UseNewTraining())
					{
						level.GetGameObjectManager().GetUnitProduction().MergeSlots();
					}
					break;
				case 2:
					if (LogicDataTables.GetGlobals().UseNewTraining())
					{
						level.GetGameObjectManager().GetSpellProduction().MergeSlots();
					}
					break;
				case 3:
					if (LogicDataTables.GetGlobals().UseNewTraining())
					{
						level.GetGameObjectManager().GetUnitProduction().MergeSlots();
						level.GetGameObjectManager().GetSpellProduction().MergeSlots();
					}
					break;
				}
			}
			return 0;
		}

		// Token: 0x04000CF5 RID: 3317
		private readonly LogicArrayList<int> logicArrayList_0;

		// Token: 0x04000CF6 RID: 3318
		private readonly LogicArrayList<int> logicArrayList_1;

		// Token: 0x04000CF7 RID: 3319
		private readonly LogicArrayList<int> logicArrayList_2;

		// Token: 0x04000CF8 RID: 3320
		private readonly LogicArrayList<LogicCombatItemData> logicArrayList_3;
	}
}
