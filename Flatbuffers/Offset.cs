using System;

namespace FlatBuffers
{
	// Token: 0x02000005 RID: 5
	public struct Offset<T> where T : class
	{
		// Token: 0x0600005A RID: 90 RVA: 0x00002E1F File Offset: 0x0000101F
		public Offset(int value)
		{
			this.Value = value;
		}

		// Token: 0x04000010 RID: 16
		public int Value;
	}
}
