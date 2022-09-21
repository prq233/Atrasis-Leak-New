using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;

namespace Atrasis.Magic.Logic.GameObject
{
	// Token: 0x0200010F RID: 271
	public sealed class LogicDeco : LogicGameObject
	{
		// Token: 0x06000D60 RID: 3424 RVA: 0x0000987E File Offset: 0x00007A7E
		public LogicDeco(LogicGameObjectData data, LogicLevel level, int villageType) : base(data, level, villageType)
		{
			base.AddComponent(new LogicLayoutComponent(this));
		}

		// Token: 0x06000D61 RID: 3425 RVA: 0x00009895 File Offset: 0x00007A95
		public LogicDecoData GetDecoData()
		{
			return (LogicDecoData)this.m_data;
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x00002D0B File Offset: 0x00000F0B
		public override LogicGameObjectType GetGameObjectType()
		{
			return LogicGameObjectType.DECO;
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x000098A2 File Offset: 0x00007AA2
		public override int GetWidthInTiles()
		{
			return this.GetDecoData().GetWidth();
		}

		// Token: 0x06000D64 RID: 3428 RVA: 0x000098AF File Offset: 0x00007AAF
		public override int GetHeightInTiles()
		{
			return this.GetDecoData().GetHeight();
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x000098BC File Offset: 0x00007ABC
		public override bool IsPassable()
		{
			return this.GetDecoData().IsPassable();
		}
	}
}
