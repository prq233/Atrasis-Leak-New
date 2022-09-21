using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D3 RID: 467
	public sealed class LogicStartAllianceWarCommand : LogicCommand
	{
		// Token: 0x06001865 RID: 6245 RVA: 0x00010215 File Offset: 0x0000E415
		public LogicStartAllianceWarCommand()
		{
			this.logicArrayList_0 = new LogicArrayList<LogicLong>();
		}

		// Token: 0x06001866 RID: 6246 RVA: 0x0005BA60 File Offset: 0x00059C60
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
		}

		// Token: 0x06001867 RID: 6247 RVA: 0x0005BAD0 File Offset: 0x00059CD0
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
		}

		// Token: 0x06001868 RID: 6248 RVA: 0x00010228 File Offset: 0x0000E428
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.START_ALLIANCE_WAR;
		}

		// Token: 0x06001869 RID: 6249 RVA: 0x0001022F File Offset: 0x0000E42F
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x0600186A RID: 6250 RVA: 0x0005BB28 File Offset: 0x00059D28
		public override int Execute(LogicLevel level)
		{
			if (this.logicArrayList_0 != null && this.logicArrayList_0.Size() > LogicDataTables.GetGlobals().GetWarMaxExcludeMembers())
			{
				return -1;
			}
			LogicAvatar homeOwnerAvatar = level.GetHomeOwnerAvatar();
			if (homeOwnerAvatar.IsInAlliance())
			{
				if (homeOwnerAvatar.GetAllianceRole() != LogicAvatarAllianceRole.LEADER)
				{
					if (homeOwnerAvatar.GetAllianceRole() != LogicAvatarAllianceRole.CO_LEADER)
					{
						return -3;
					}
				}
				homeOwnerAvatar.GetChangeListener().StartWar(this.logicArrayList_0);
				return 0;
			}
			return -2;
		}

		// Token: 0x04000D27 RID: 3367
		private LogicArrayList<LogicLong> logicArrayList_0;
	}
}
