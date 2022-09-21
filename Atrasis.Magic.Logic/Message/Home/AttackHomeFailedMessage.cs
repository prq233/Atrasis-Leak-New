using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x0200003F RID: 63
	public class AttackHomeFailedMessage : PiranhaMessage
	{
		// Token: 0x060002FD RID: 765 RVA: 0x00003CD9 File Offset: 0x00001ED9
		public AttackHomeFailedMessage() : this(0)
		{
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0000328C File Offset: 0x0000148C
		public AttackHomeFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00003CE2 File Offset: 0x00001EE2
		public override void Decode()
		{
			base.Decode();
			this.reason_0 = (AttackHomeFailedMessage.Reason)this.m_stream.ReadInt();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00003D0C File Offset: 0x00001F0C
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.reason_0);
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00003D36 File Offset: 0x00001F36
		public override short GetMessageType()
		{
			return 24103;
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00003D3D File Offset: 0x00001F3D
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000341E File Offset: 0x0000161E
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00003D41 File Offset: 0x00001F41
		public AttackHomeFailedMessage.Reason GetReason()
		{
			return this.reason_0;
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00003D49 File Offset: 0x00001F49
		public void SetReason(AttackHomeFailedMessage.Reason value)
		{
			this.reason_0 = value;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00003D52 File Offset: 0x00001F52
		public int GetProtectionEndSeconds()
		{
			return this.int_0;
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00003D5A File Offset: 0x00001F5A
		public void SetProtectionEndSeconds(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000126 RID: 294
		public const int MESSAGE_TYPE = 24103;

		// Token: 0x04000127 RID: 295
		private AttackHomeFailedMessage.Reason reason_0;

		// Token: 0x04000128 RID: 296
		private int int_0;

		// Token: 0x02000040 RID: 64
		public enum Reason
		{
			// Token: 0x0400012A RID: 298
			GENERIC,
			// Token: 0x0400012B RID: 299
			TARGET_ONLINE,
			// Token: 0x0400012C RID: 300
			ALREADY_UNDER_ATTACK,
			// Token: 0x0400012D RID: 301
			SAME_ALLIANCE,
			// Token: 0x0400012E RID: 302
			SHIELD,
			// Token: 0x0400012F RID: 303
			LEVEL_DIFFERENCE,
			// Token: 0x04000130 RID: 304
			NEWBIE_PROTECTED,
			// Token: 0x04000131 RID: 305
			NO_MATCHES,
			// Token: 0x04000132 RID: 306
			NO_ENOUGH_RESOURCE,
			// Token: 0x04000133 RID: 307
			COOLDOWN_AFTER_MAINTENANCE = 10,
			// Token: 0x04000134 RID: 308
			SHUTDOWN_ATTACK_DISABLED,
			// Token: 0x04000135 RID: 309
			PERSONAL_BREAK_ATTACK_DISABLED,
			// Token: 0x04000136 RID: 310
			TARGET_HAS_GUARD = 16
		}
	}
}
