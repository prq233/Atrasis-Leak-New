using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Helper
{
	// Token: 0x02000107 RID: 263
	public static class ByteStreamHelper
	{
		// Token: 0x06000CA3 RID: 3235 RVA: 0x0000925A File Offset: 0x0000745A
		public static LogicCompressibleString ReadCompressableStringOrNull(ByteStream stream)
		{
			if (stream.ReadBoolean())
			{
				return null;
			}
			LogicCompressibleString logicCompressibleString = new LogicCompressibleString();
			logicCompressibleString.Decode(stream);
			return logicCompressibleString;
		}

		// Token: 0x06000CA4 RID: 3236 RVA: 0x00009272 File Offset: 0x00007472
		public static LogicData ReadDataReference(ByteStream stream)
		{
			return LogicDataTables.GetDataById(stream.ReadInt());
		}

		// Token: 0x06000CA5 RID: 3237 RVA: 0x0002B668 File Offset: 0x00029868
		public static LogicData ReadDataReference(ByteStream stream, LogicDataType tableIndex)
		{
			int globalId = stream.ReadInt();
			if (GlobalID.GetClassID(globalId) == (int)(tableIndex + 1))
			{
				return LogicDataTables.GetDataById(globalId);
			}
			return null;
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x0000927F File Offset: 0x0000747F
		public static void WriteCompressableStringOrNull(ChecksumEncoder encoder, LogicCompressibleString compressibleString)
		{
			if (compressibleString == null)
			{
				encoder.WriteBoolean(false);
				return;
			}
			encoder.WriteBoolean(true);
			compressibleString.Encode(encoder);
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x0000929A File Offset: 0x0000749A
		public static void WriteDataReference(ChecksumEncoder encoder, LogicData data)
		{
			encoder.WriteInt((data != null) ? data.GetGlobalID() : 0);
		}
	}
}
