using System;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Avatar.Change
{
	// Token: 0x02000202 RID: 514
	public class LogicAvatarChange
	{
		// Token: 0x06001B20 RID: 6944 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void Destruct()
		{
		}

		// Token: 0x06001B21 RID: 6945 RVA: 0x00011BC1 File Offset: 0x0000FDC1
		public virtual int GetAvatarChangeType()
		{
			Debugger.Error("LogicAvatarChange::getAvatarChangeType() must be overridden");
			return 0;
		}

		// Token: 0x06001B22 RID: 6946 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void Decode(ByteStream stream)
		{
		}

		// Token: 0x06001B23 RID: 6947 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void Encode(ChecksumEncoder encoder)
		{
		}

		// Token: 0x06001B24 RID: 6948 RVA: 0x00002463 File Offset: 0x00000663
		public virtual void ApplyAvatarChange(LogicClientAvatar avatar)
		{
		}
	}
}
