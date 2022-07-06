using System;
using System.Text;

namespace FlatBuffers
{
	// Token: 0x02000009 RID: 9
	public abstract class Table
	{
		// Token: 0x0600005E RID: 94 RVA: 0x00002E44 File Offset: 0x00001044
		protected int __offset(int vtableOffset)
		{
			int num = this.bb_pos - this.bb.GetInt(this.bb_pos);
			if (vtableOffset >= (int)this.bb.GetShort(num))
			{
				return 0;
			}
			return (int)this.bb.GetShort(num + vtableOffset);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002E89 File Offset: 0x00001089
		protected int __indirect(int offset)
		{
			return offset + this.bb.GetInt(offset);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002E9C File Offset: 0x0000109C
		protected string __string(int offset)
		{
			offset += this.bb.GetInt(offset);
			int @int = this.bb.GetInt(offset);
			int index = offset + 4;
			return Encoding.UTF8.GetString(this.bb.Data, index, @int);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002EE1 File Offset: 0x000010E1
		protected int __vector_len(int offset)
		{
			offset += this.bb_pos;
			offset += this.bb.GetInt(offset);
			return this.bb.GetInt(offset);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002F09 File Offset: 0x00001109
		protected int __vector(int offset)
		{
			offset += this.bb_pos;
			return offset + this.bb.GetInt(offset) + 4;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002F25 File Offset: 0x00001125
		protected TTable __union<TTable>(TTable t, int offset) where TTable : Table
		{
			offset += this.bb_pos;
			t.bb_pos = offset + this.bb.GetInt(offset);
			t.bb = this.bb;
			return t;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002F5C File Offset: 0x0000115C
		protected static bool __has_identifier(ByteBuffer bb, string ident)
		{
			if (ident.Length != 4)
			{
				throw new ArgumentException("FlatBuffers: file identifier must be length " + 4, "ident");
			}
			for (int i = 0; i < 4; i++)
			{
				if (ident[i] != (char)bb.Get(bb.Position + 4 + i))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04000015 RID: 21
		protected int bb_pos;

		// Token: 0x04000016 RID: 22
		protected ByteBuffer bb;
	}
}
