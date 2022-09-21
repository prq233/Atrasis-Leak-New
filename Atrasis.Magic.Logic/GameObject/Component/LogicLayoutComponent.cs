using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Mode;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Json;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.GameObject.Component
{
	// Token: 0x02000125 RID: 293
	public sealed class LogicLayoutComponent : LogicComponent
	{
		// Token: 0x06000FAF RID: 4015 RVA: 0x000431F4 File Offset: 0x000413F4
		public LogicLayoutComponent(LogicGameObject gameObject) : base(gameObject)
		{
			this.logicVector2_0 = new LogicVector2[8];
			this.logicVector2_1 = new LogicVector2[8];
			for (int i = 0; i < 8; i++)
			{
				this.logicVector2_0[i] = new LogicVector2(-1, -1);
				this.logicVector2_1[i] = new LogicVector2(-1, -1);
			}
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x0004324C File Offset: 0x0004144C
		public override void Destruct()
		{
			base.Destruct();
			for (int i = 0; i < this.logicVector2_0.Length; i++)
			{
				if (this.logicVector2_0[i] != null)
				{
					this.logicVector2_0[i].Destruct();
					this.logicVector2_0[i] = null;
				}
			}
			for (int j = 0; j < this.logicVector2_1.Length; j++)
			{
				if (this.logicVector2_1[j] != null)
				{
					this.logicVector2_1[j].Destruct();
					this.logicVector2_1[j] = null;
				}
			}
		}

		// Token: 0x06000FB1 RID: 4017 RVA: 0x00003B77 File Offset: 0x00001D77
		public override LogicComponentType GetComponentType()
		{
			return LogicComponentType.LAYOUT;
		}

		// Token: 0x06000FB2 RID: 4018 RVA: 0x000432C8 File Offset: 0x000414C8
		public override void Load(LogicJSONObject jsonObject)
		{
			LogicLevel level = this.m_parent.GetLevel();
			int villageType = this.m_parent.GetVillageType();
			int activeLayout = level.GetActiveLayout();
			for (int i = 0; i < 8; i++)
			{
				if (i == activeLayout)
				{
					this.logicVector2_0[i].Set(this.m_parent.GetTileX(), this.m_parent.GetTileY());
				}
				else
				{
					LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber(this.GetLayoutVariableNameX(i, false));
					LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber(this.GetLayoutVariableNameY(i, false));
					if (jsonnumber != null && jsonnumber2 != null)
					{
						this.logicVector2_0[i].Set(jsonnumber.GetIntValue(), jsonnumber2.GetIntValue());
					}
				}
			}
			for (int j = 0; j < 8; j++)
			{
				if (level.GetLayoutState(j, villageType) == 1)
				{
					LogicJSONNumber jsonnumber3 = jsonObject.GetJSONNumber(this.GetLayoutVariableNameX(j, true));
					LogicJSONNumber jsonnumber4 = jsonObject.GetJSONNumber(this.GetLayoutVariableNameY(j, true));
					if (jsonnumber3 != null && jsonnumber4 != null)
					{
						this.logicVector2_1[j].Set(jsonnumber3.GetIntValue(), jsonnumber4.GetIntValue());
					}
				}
			}
		}

		// Token: 0x06000FB3 RID: 4019 RVA: 0x000433D0 File Offset: 0x000415D0
		public override void LoadFromSnapshot(LogicJSONObject jsonObject)
		{
			LogicLevel level = this.m_parent.GetLevel();
			LogicGameMode gameMode = level.GetGameMode();
			if (gameMode.GetVisitType() == 1 || gameMode.GetVisitType() == 4 || gameMode.GetVisitType() == 5)
			{
				int num = 7;
				if (gameMode.GetVisitType() != 4 || !level.IsArrangedWar())
				{
					int warLayout = level.GetWarLayout();
					if (warLayout >= 0 && level.IsWarBase())
					{
						num = warLayout;
					}
					else
					{
						num = level.GetActiveLayout();
					}
				}
				LogicJSONNumber jsonnumber = jsonObject.GetJSONNumber(this.GetLayoutVariableNameX(num, false));
				LogicJSONNumber jsonnumber2 = jsonObject.GetJSONNumber(this.GetLayoutVariableNameY(num, false));
				if (jsonnumber != null && jsonnumber2 != null)
				{
					this.m_parent.SetInitialPosition(jsonnumber.GetIntValue() << 9, jsonnumber2.GetIntValue() << 9);
					Debugger.DoAssert(num < 8, "Layout index out of bands");
					this.logicVector2_0[num].Set(jsonnumber.GetIntValue(), jsonnumber2.GetIntValue());
				}
			}
		}

		// Token: 0x06000FB4 RID: 4020 RVA: 0x000434B0 File Offset: 0x000416B0
		public override void Save(LogicJSONObject jsonObject, int villageType)
		{
			LogicLevel level = this.m_parent.GetLevel();
			int activeLayout = this.m_parent.GetLevel().GetActiveLayout(villageType);
			for (int i = 0; i < 8; i++)
			{
				LogicVector2 logicVector = this.logicVector2_1[i];
				if (logicVector.m_x != -1 && logicVector.m_y != -1 && level.GetLayoutState(i, villageType) == 1)
				{
					jsonObject.Put(this.GetLayoutVariableNameX(i, true), new LogicJSONNumber(logicVector.m_x));
					jsonObject.Put(this.GetLayoutVariableNameY(i, true), new LogicJSONNumber(logicVector.m_y));
				}
			}
			for (int j = 0; j < 8; j++)
			{
				if (j != activeLayout)
				{
					LogicVector2 logicVector2 = this.logicVector2_0[j];
					if (logicVector2.m_x != -1 && logicVector2.m_y != -1)
					{
						jsonObject.Put(this.GetLayoutVariableNameX(j, false), new LogicJSONNumber(logicVector2.m_x));
						jsonObject.Put(this.GetLayoutVariableNameY(j, false), new LogicJSONNumber(logicVector2.m_y));
					}
				}
			}
		}

		// Token: 0x06000FB5 RID: 4021 RVA: 0x000435AC File Offset: 0x000417AC
		public override void SaveToSnapshot(LogicJSONObject jsonObject, int layoutId)
		{
			if (!this.m_parent.GetLevel().IsWarBase() && layoutId <= 5 && layoutId != 0 && layoutId != 2)
			{
				if (layoutId != 3)
				{
					jsonObject.Put("x", new LogicJSONNumber(this.m_parent.GetTileX()));
					jsonObject.Put("y", new LogicJSONNumber(this.m_parent.GetTileY()));
					return;
				}
			}
			Debugger.DoAssert(layoutId < 8, "Layout index out of bounds");
			jsonObject.Put("x", new LogicJSONNumber(this.logicVector2_0[layoutId].m_x));
			jsonObject.Put("y", new LogicJSONNumber(this.logicVector2_0[layoutId].m_y));
		}

		// Token: 0x06000FB6 RID: 4022 RVA: 0x0000AB18 File Offset: 0x00008D18
		public LogicVector2 GetPositionLayout(int idx)
		{
			Debugger.DoAssert(idx < 8, "Layout index out of bounds");
			return this.logicVector2_0[idx];
		}

		// Token: 0x06000FB7 RID: 4023 RVA: 0x0000AB31 File Offset: 0x00008D31
		public LogicVector2 GetEditModePositionLayout(int idx)
		{
			Debugger.DoAssert(idx < 8, "Layout index out of bounds");
			return this.logicVector2_1[idx];
		}

		// Token: 0x06000FB8 RID: 4024 RVA: 0x0004365C File Offset: 0x0004185C
		public string GetLayoutVariableNameX(int idx, bool draf)
		{
			if (draf)
			{
				switch (idx)
				{
				case 0:
					return "emx";
				case 1:
					return "e1x";
				case 2:
					return "e2x";
				case 3:
					return "e3x";
				case 4:
					return "e4x";
				case 5:
					return "e5x";
				case 6:
					return "e6x";
				case 7:
					return "e7x";
				default:
					Debugger.Error("Layout index out of bounds");
					return "emx";
				}
			}
			else
			{
				switch (idx)
				{
				case 0:
					return "lmx";
				case 1:
					return "l1x";
				case 2:
					return "l2x";
				case 3:
					return "l3x";
				case 4:
					return "l4x";
				case 5:
					return "l5x";
				case 6:
					return "l6x";
				case 7:
					return "l7x";
				default:
					Debugger.Error("Layout index out of bounds");
					return "lmx";
				}
			}
		}

		// Token: 0x06000FB9 RID: 4025 RVA: 0x00043738 File Offset: 0x00041938
		public string GetLayoutVariableNameY(int idx, bool draft)
		{
			if (draft)
			{
				switch (idx)
				{
				case 0:
					return "emy";
				case 1:
					return "e1y";
				case 2:
					return "e2y";
				case 3:
					return "e3y";
				case 4:
					return "e4y";
				case 5:
					return "e5y";
				case 6:
					return "e6y";
				case 7:
					return "e7y";
				default:
					Debugger.Error("Layout index out of bounds");
					return "emy";
				}
			}
			else
			{
				switch (idx)
				{
				case 0:
					return "lmy";
				case 1:
					return "l1y";
				case 2:
					return "l2y";
				case 3:
					return "l3y";
				case 4:
					return "l4y";
				case 5:
					return "l5y";
				case 6:
					return "l6y";
				case 7:
					return "l7y";
				default:
					Debugger.Error("Layout index out of bounds");
					return "l1x";
				}
			}
		}

		// Token: 0x06000FBA RID: 4026 RVA: 0x00043814 File Offset: 0x00041A14
		public string GetLayoutVariableNameTrapDirection(int idx, bool draft)
		{
			if (draft)
			{
				switch (idx)
				{
				case 0:
					return "trapd_draft";
				case 1:
					return "trapd_draft_war";
				case 2:
					return "trapd_d2";
				case 3:
					return "trapd_d3";
				case 4:
					return "trapd_d4";
				case 5:
					return "trapd_d5";
				case 6:
					return "trapd_d6";
				case 7:
					return "trapd_d7";
				default:
					Debugger.Error("Layout index out of bounds");
					return "trapd_draft";
				}
			}
			else
			{
				switch (idx)
				{
				case 0:
					return "trapd";
				case 1:
					return "trapd_war";
				case 2:
					return "trapd2";
				case 3:
					return "trapd3";
				case 4:
					return "trapd4";
				case 5:
					return "trapd5";
				case 6:
					return "trapd6";
				case 7:
					return "trapd7";
				default:
					Debugger.Error("Layout index out of bounds");
					return "trapd";
				}
			}
		}

		// Token: 0x06000FBB RID: 4027 RVA: 0x000438F0 File Offset: 0x00041AF0
		public string GetLayoutVariableNameAirMode(int idx, bool draft)
		{
			if (draft)
			{
				switch (idx)
				{
				case 0:
					return "air_mode_draft";
				case 1:
					return "air_mode_draft_war";
				case 2:
					return "air_mode_d2";
				case 3:
					return "air_mode_d3";
				case 4:
					return "air_mode_d4";
				case 5:
					return "air_mode_d5";
				case 6:
					return "air_mode_d6";
				case 7:
					return "air_mode_d7";
				default:
					Debugger.Error("Layout index out of bounds");
					return "air_mode_draft";
				}
			}
			else
			{
				switch (idx)
				{
				case 0:
					return "air_mode";
				case 1:
					return "air_mode_war";
				case 2:
					return "air_mode2";
				case 3:
					return "air_mode3";
				case 4:
					return "air_mode4";
				case 5:
					return "air_mode5";
				case 6:
					return "air_mode6";
				case 7:
					return "air_mode7";
				default:
					Debugger.Error("Layout index out of bounds");
					return "air_mode";
				}
			}
		}

		// Token: 0x06000FBC RID: 4028 RVA: 0x0000AB4A File Offset: 0x00008D4A
		public void SetPositionLayout(int idx, int x, int y)
		{
			Debugger.DoAssert(idx < 8, "Layout index out of bands");
			this.logicVector2_0[idx].Set(x, y);
		}

		// Token: 0x06000FBD RID: 4029 RVA: 0x0000AB6A File Offset: 0x00008D6A
		public void SetEditModePositionLayout(int idx, int x, int y)
		{
			Debugger.DoAssert(idx < 8, "Layout index out of bands");
			this.logicVector2_1[idx].Set(x, y);
		}

		// Token: 0x04000671 RID: 1649
		private readonly LogicVector2[] logicVector2_0;

		// Token: 0x04000672 RID: 1650
		private readonly LogicVector2[] logicVector2_1;
	}
}
