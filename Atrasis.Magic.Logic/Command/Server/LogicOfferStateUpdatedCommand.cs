using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Offer;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000181 RID: 385
	public class LogicOfferStateUpdatedCommand : LogicServerCommand
	{
		// Token: 0x06001645 RID: 5701 RVA: 0x0000E2EC File Offset: 0x0000C4EC
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001646 RID: 5702 RVA: 0x0000E90B File Offset: 0x0000CB0B
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_3 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
		}

		// Token: 0x06001647 RID: 5703 RVA: 0x0000E92C File Offset: 0x0000CB2C
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_2);
		}

		// Token: 0x06001648 RID: 5704 RVA: 0x00055E5C File Offset: 0x0005405C
		public override int Execute(LogicLevel level)
		{
			LogicOffer offerById = level.GetOfferManager().GetOfferById(this.int_3);
			if (offerById != null)
			{
				offerById.SetState(this.int_2);
				return 0;
			}
			Debugger.Warning(string.Format("Offer not found when updating offer state for id: {0} to state: {1}", this.int_3, this.int_2));
			return -2;
		}

		// Token: 0x06001649 RID: 5705 RVA: 0x0000E94D File Offset: 0x0000CB4D
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.OFFER_STATE_UPDATED;
		}

		// Token: 0x04000C96 RID: 3222
		private int int_2;

		// Token: 0x04000C97 RID: 3223
		private int int_3;
	}
}
