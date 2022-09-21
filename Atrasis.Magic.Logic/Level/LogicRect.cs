using System;

namespace Atrasis.Magic.Logic.Level
{
	// Token: 0x02000101 RID: 257
	public struct LogicRect
	{
		// Token: 0x06000C3B RID: 3131 RVA: 0x00008DFF File Offset: 0x00006FFF
		public LogicRect(int startX, int startY, int endX, int endY)
		{
			this.m_startX = startX;
			this.m_startY = startY;
			this.m_endX = endX;
			this.m_endY = endY;
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x00008E1E File Offset: 0x0000701E
		public int GetStartX()
		{
			return this.m_startX;
		}

		// Token: 0x06000C3D RID: 3133 RVA: 0x00008E26 File Offset: 0x00007026
		public int GetStartY()
		{
			return this.m_startY;
		}

		// Token: 0x06000C3E RID: 3134 RVA: 0x00008E2E File Offset: 0x0000702E
		public int GetEndX()
		{
			return this.m_endX;
		}

		// Token: 0x06000C3F RID: 3135 RVA: 0x00008E36 File Offset: 0x00007036
		public int GetEndY()
		{
			return this.m_endY;
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x00008E3E File Offset: 0x0000703E
		public bool IsInside(int x, int y)
		{
			return this.m_startX <= x && this.m_startY <= y && this.m_endX >= x && this.m_endY >= y;
		}

		// Token: 0x06000C41 RID: 3137 RVA: 0x00008E69 File Offset: 0x00007069
		public bool IsInside(LogicRect rect)
		{
			return this.m_startX <= rect.m_startX && this.m_startY <= rect.m_startY && this.m_endX > rect.m_endX && this.m_endY > rect.m_endY;
		}

		// Token: 0x040004E9 RID: 1257
		public readonly int m_startX;

		// Token: 0x040004EA RID: 1258
		public readonly int m_startY;

		// Token: 0x040004EB RID: 1259
		public readonly int m_endX;

		// Token: 0x040004EC RID: 1260
		public readonly int m_endY;
	}
}
