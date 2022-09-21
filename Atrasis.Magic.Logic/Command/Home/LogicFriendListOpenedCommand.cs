using System;
using Atrasis.Magic.Logic.Level;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A5 RID: 421
	public sealed class LogicFriendListOpenedCommand : LogicCommand
	{
		// Token: 0x06001738 RID: 5944 RVA: 0x0000F352 File Offset: 0x0000D552
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.FRIEND_LIST_OPENED;
		}

		// Token: 0x06001739 RID: 5945 RVA: 0x0000EB45 File Offset: 0x0000CD45
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600173A RID: 5946 RVA: 0x0000F359 File Offset: 0x0000D559
		public override int Execute(LogicLevel level)
		{
			level.GetPlayerAvatar().UpdateLastFriendListOpened();
			return 0;
		}
	}
}
