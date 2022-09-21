using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001BC RID: 444
	public sealed class LogicSaveBaseLayoutCommand : LogicCommand
	{
		// Token: 0x060017CA RID: 6090 RVA: 0x0000FB42 File Offset: 0x0000DD42
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060017CB RID: 6091 RVA: 0x0000FB63 File Offset: 0x0000DD63
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x060017CC RID: 6092 RVA: 0x0000FB84 File Offset: 0x0000DD84
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SAVE_BASE_LAYOUT;
		}

		// Token: 0x060017CD RID: 6093 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017CE RID: 6094 RVA: 0x0005AA64 File Offset: 0x00058C64
		public override int Execute(LogicLevel level)
		{
			if (this.int_1 == 6)
			{
				return 10;
			}
			if (this.int_1 != 7)
			{
				LogicGameObjectFilter logicGameObjectFilter = new LogicGameObjectFilter();
				LogicArrayList<LogicGameObject> logicArrayList = new LogicArrayList<LogicGameObject>(500);
				int num = 0;
				logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.BUILDING);
				logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.TRAP);
				logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.DECO);
				level.GetGameObjectManager().GetGameObjects(logicArrayList, logicGameObjectFilter);
				for (int i = 0; i < logicArrayList.Size(); i++)
				{
					LogicGameObject logicGameObject = logicArrayList[i];
					LogicVector2 positionLayout = logicArrayList[i].GetPositionLayout(this.int_1, true);
					int x = positionLayout.m_x;
					int y = positionLayout.m_y;
					if (x != -1 && y != -1)
					{
						int num2 = x + logicGameObject.GetWidthInTiles();
						int num3 = y + logicGameObject.GetHeightInTiles();
						for (int j = 0; j < logicArrayList.Size(); j++)
						{
							LogicGameObject logicGameObject2 = logicArrayList[j];
							if (logicGameObject2 != logicGameObject)
							{
								LogicVector2 positionLayout2 = logicGameObject2.GetPositionLayout(this.int_1, true);
								int x2 = positionLayout2.m_x;
								int y2 = positionLayout2.m_y;
								if (x2 != -1 && y2 != -1)
								{
									int num4 = x2 + logicGameObject2.GetWidthInTiles();
									int num5 = y2 + logicGameObject2.GetHeightInTiles();
									if (num2 > x2 && num3 > y2 && x < num4 && y < num5)
									{
										Debugger.Warning("LogicSaveBaseLayoutCommand: overlap");
										return -1;
									}
								}
							}
						}
					}
				}
				for (int k = 0; k < logicArrayList.Size(); k++)
				{
					LogicGameObject logicGameObject3 = logicArrayList[k];
					LogicVector2 positionLayout3 = logicGameObject3.GetPositionLayout(this.int_1, true);
					LogicVector2 positionLayout4 = logicGameObject3.GetPositionLayout(this.int_1, false);
					if (logicGameObject3.GetGameObjectType() != LogicGameObjectType.DECO && (positionLayout4.m_x != positionLayout3.m_x || positionLayout4.m_y != positionLayout3.m_y))
					{
						num++;
					}
					logicGameObject3.SetPositionLayoutXY(positionLayout3.m_x, positionLayout3.m_y, this.int_1, false);
				}
				logicGameObjectFilter.Destruct();
				if (num > 0 && level.GetHomeOwnerAvatar().GetTownHallLevel() >= LogicDataTables.GetGlobals().GetChallengeBaseCooldownEnabledTownHall())
				{
					level.SetLayoutCooldownSecs(this.int_1, LogicDataTables.GetGlobals().GetChallengeBaseSaveCooldown());
				}
				return 0;
			}
			return -11;
		}

		// Token: 0x04000D05 RID: 3333
		private int int_1;

		// Token: 0x04000D06 RID: 3334
		private int int_2;
	}
}
