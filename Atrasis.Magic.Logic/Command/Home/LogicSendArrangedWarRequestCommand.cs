using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.GameObject.Component;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C0 RID: 448
	public sealed class LogicSendArrangedWarRequestCommand : LogicCommand
	{
		// Token: 0x060017E6 RID: 6118 RVA: 0x0000FC93 File Offset: 0x0000DE93
		public LogicSendArrangedWarRequestCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<LogicLong>();
		}

		// Token: 0x060017E7 RID: 6119 RVA: 0x0005B0D0 File Offset: 0x000592D0
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			int num = stream.ReadInt();
			if (num > 0)
			{
				this.logicArrayList_0 = new LogicArrayList<LogicLong>();
				this.logicArrayList_0.EnsureCapacity(num);
				if (num > 50)
				{
					Debugger.Error(string.Format("Number of excluded players ({0}) is too high.", num));
				}
				for (int i = 0; i < num; i++)
				{
					this.logicArrayList_0.Add(stream.ReadLong());
				}
			}
			this.logicLong_0 = stream.ReadLong();
			stream.ReadInt();
			stream.ReadInt();
		}

		// Token: 0x060017E8 RID: 6120 RVA: 0x0005B158 File Offset: 0x00059358
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			if (this.logicArrayList_0 != null)
			{
				encoder.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					encoder.WriteLong(this.logicArrayList_0[i]);
				}
			}
			encoder.WriteLong(this.logicLong_0);
			encoder.WriteInt(0);
			encoder.WriteInt(0);
		}

		// Token: 0x060017E9 RID: 6121 RVA: 0x0000FCA6 File Offset: 0x0000DEA6
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SEND_ARRANGED_WAR_REQUEST;
		}

		// Token: 0x060017EA RID: 6122 RVA: 0x0000FCAD File Offset: 0x0000DEAD
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
			this.logicLong_0 = null;
		}

		// Token: 0x060017EB RID: 6123 RVA: 0x0005B1C8 File Offset: 0x000593C8
		public override int Execute(LogicLevel level)
		{
			if (this.logicArrayList_0 != null && this.logicArrayList_0.Size() > LogicDataTables.GetGlobals().GetWarMaxExcludeMembers())
			{
				return -1;
			}
			if (this.logicLong_0 == null)
			{
				return -3;
			}
			LogicAvatar homeOwnerAvatar = level.GetHomeOwnerAvatar();
			if (!homeOwnerAvatar.IsInAlliance())
			{
				return -2;
			}
			if (homeOwnerAvatar.GetAllianceRole() != LogicAvatarAllianceRole.LEADER)
			{
				if (homeOwnerAvatar.GetAllianceRole() != LogicAvatarAllianceRole.CO_LEADER)
				{
					return -3;
				}
			}
			LogicBuilding allianceCastle = level.GetGameObjectManagerAt(0).GetAllianceCastle();
			if (allianceCastle == null)
			{
				return -4;
			}
			LogicBunkerComponent bunkerComponent = allianceCastle.GetBunkerComponent();
			if (bunkerComponent != null && bunkerComponent.GetArrangedWarCooldownTime() == 0)
			{
				bunkerComponent.StartArrangedWarCooldownTime();
				homeOwnerAvatar.GetChangeListener().StartArrangedWar(this.logicArrayList_0, this.logicLong_0, 0, 0, 0);
				return 0;
			}
			return -5;
		}

		// Token: 0x04000D0C RID: 3340
		private LogicArrayList<LogicLong> logicArrayList_0;

		// Token: 0x04000D0D RID: 3341
		private LogicLong logicLong_0;
	}
}
