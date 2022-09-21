using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C3 RID: 451
	public sealed class LogicSetCurrentVillageCommand : LogicCommand
	{
		// Token: 0x060017F9 RID: 6137 RVA: 0x0000EB66 File Offset: 0x0000CD66
		public LogicSetCurrentVillageCommand()
		{
		}

		// Token: 0x060017FA RID: 6138 RVA: 0x0000FD4C File Offset: 0x0000DF4C
		public LogicSetCurrentVillageCommand(int villageType)
		{
			this.int_1 = villageType;
		}

		// Token: 0x060017FB RID: 6139 RVA: 0x0000FD5B File Offset: 0x0000DF5B
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060017FC RID: 6140 RVA: 0x0000FD70 File Offset: 0x0000DF70
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x060017FD RID: 6141 RVA: 0x0000FD85 File Offset: 0x0000DF85
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SET_CURRENT_VILLAGE;
		}

		// Token: 0x060017FE RID: 6142 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060017FF RID: 6143 RVA: 0x0000FD8C File Offset: 0x0000DF8C
		public override int Execute(LogicLevel level)
		{
			if (this.int_1 < 0)
			{
				return -1;
			}
			if (this.int_1 > 1)
			{
				return -2;
			}
			if (this.int_1 != level.GetVillageType())
			{
				level.GetGameObjectManagerAt(1).GetTownHall();
				return this.ChangeVillage(level, false);
			}
			return -3;
		}

		// Token: 0x06001800 RID: 6144 RVA: 0x0005B30C File Offset: 0x0005950C
		public int ChangeVillage(LogicLevel level, bool force)
		{
			if (this.int_1 != 0 && !force)
			{
				LogicVillageObject shipyard = level.GetGameObjectManagerAt(0).GetShipyard();
				if (shipyard == null || shipyard.GetUpgradeLevel() <= 0)
				{
					return -23;
				}
			}
			if (level.GetGameObjectManagerAt(1).GetTownHall() != null)
			{
				level.SetVillageType(this.int_1);
				if (level.GetState() == 1)
				{
					level.GetPlayerAvatar().SetVariableByName("VillageToGoTo", this.int_1);
				}
				level.GetGameObjectManager().RespawnObstacles();
			}
			return 0;
		}

		// Token: 0x04000D11 RID: 3345
		private int int_1;
	}
}
