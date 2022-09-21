using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C5 RID: 453
	public sealed class LogicSetLayoutStateCommand : LogicCommand
	{
		// Token: 0x06001808 RID: 6152 RVA: 0x0000FE29 File Offset: 0x0000E029
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			this.bool_0 = stream.ReadBoolean();
			base.Decode(stream);
		}

		// Token: 0x06001809 RID: 6153 RVA: 0x0000FE56 File Offset: 0x0000E056
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			encoder.WriteBoolean(this.bool_0);
			base.Encode(encoder);
		}

		// Token: 0x0600180A RID: 6154 RVA: 0x0000FE83 File Offset: 0x0000E083
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SET_LAYOUT_STATE;
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600180C RID: 6156 RVA: 0x0005B388 File Offset: 0x00059588
		public override int Execute(LogicLevel level)
		{
			if (this.int_1 == 6)
			{
				return -10;
			}
			if (this.int_1 != 7)
			{
				if (this.int_2 == 0)
				{
					LogicGameObjectFilter logicGameObjectFilter = new LogicGameObjectFilter();
					LogicArrayList<LogicGameObject> logicArrayList = new LogicArrayList<LogicGameObject>(500);
					logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.BUILDING);
					logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.TRAP);
					logicGameObjectFilter.AddGameObjectType(LogicGameObjectType.DECO);
					level.GetGameObjectManager().GetGameObjects(logicArrayList, logicGameObjectFilter);
					for (int i = 0; i < logicArrayList.Size(); i++)
					{
						logicArrayList[i].SetPositionLayoutXY(-1, -1, this.int_1, true);
					}
					logicGameObjectFilter.Destruct();
				}
				level.SetLayoutState(this.int_1, level.GetVillageType(), this.int_2);
				return 0;
			}
			return -11;
		}

		// Token: 0x04000D13 RID: 3347
		private int int_1;

		// Token: 0x04000D14 RID: 3348
		private int int_2;

		// Token: 0x04000D15 RID: 3349
		private bool bool_0;
	}
}
