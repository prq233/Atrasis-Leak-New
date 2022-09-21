using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200005F RID: 95
	public abstract class AvatarChange
	{
		// Token: 0x06000291 RID: 657
		public abstract void Decode(ByteStream stream);

		// Token: 0x06000292 RID: 658
		public abstract void Encode(ByteStream stream);

		// Token: 0x06000293 RID: 659
		public abstract void ApplyAvatarChange(LogicClientAvatar avatar);

		// Token: 0x06000294 RID: 660
		public abstract void ApplyAvatarChange(AllianceMemberEntry memberEntry);

		// Token: 0x06000295 RID: 661
		public abstract AvatarChangeType GetAvatarChangeType();

		// Token: 0x02000060 RID: 96
		// (Invoke) Token: 0x06000298 RID: 664
		public delegate void AvatarChangeExecuted(LogicClientAvatar playerAvatar);
	}
}
