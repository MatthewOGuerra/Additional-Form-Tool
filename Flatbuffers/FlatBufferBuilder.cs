using System;
using System.Text;

namespace FlatBuffers
{
	// Token: 0x02000003 RID: 3
	public class FlatBufferBuilder
	{
		// Token: 0x06000023 RID: 35 RVA: 0x0000244C File Offset: 0x0000064C
		public FlatBufferBuilder(int initialSize)
		{
			if (initialSize <= 0)
			{
				throw new ArgumentOutOfRangeException("initialSize", initialSize, "Must be greater than zero");
			}
			this._space = initialSize;
			this._bb = new ByteBuffer(new byte[initialSize]);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000024A8 File Offset: 0x000006A8
		public void Clear()
		{
			this._space = this._bb.Length;
			this._bb.Reset();
			this._minAlign = 1;
			this._vtable = null;
			this._objectStart = 0;
			this._vtables = new int[16];
			this._numVtables = 0;
			this._vectorNumElems = 0;
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002501 File Offset: 0x00000701
		public int Offset
		{
			get
			{
				return this._bb.Length - this._space;
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002518 File Offset: 0x00000718
		public void Pad(int size)
		{
			for (int i = 0; i < size; i++)
			{
				ByteBuffer bb = this._bb;
				int num = this._space - 1;
				this._space = num;
				bb.PutByte(num, 0);
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002550 File Offset: 0x00000750
		private void GrowBuffer()
		{
			byte[] data = this._bb.Data;
			int num = data.Length;
			if (((long)num & unchecked((long)(unchecked((ulong)-1073741824L)))) != 0L)
			{
				throw new Exception("FlatBuffers: cannot grow buffer beyond 2 gigabytes.");
			}
			int num2 = num << 1;
			byte[] array = new byte[num2];
			Buffer.BlockCopy(data, 0, array, num2 - num, num);
			this._bb = new ByteBuffer(array, num2);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000025A8 File Offset: 0x000007A8
		public void Prep(int size, int additionalBytes)
		{
			if (size > this._minAlign)
			{
				this._minAlign = size;
			}
			int num = ~(this._bb.Length - this._space + additionalBytes) + 1 & size - 1;
			while (this._space < num + size + additionalBytes)
			{
				int length = this._bb.Length;
				this.GrowBuffer();
				this._space += this._bb.Length - length;
			}
			this.Pad(num);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002624 File Offset: 0x00000824
		public void PutBool(bool x)
		{
			this._bb.PutByte(--this._space, (byte)(x ? 1 : 0));
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002658 File Offset: 0x00000858
		public void PutSbyte(sbyte x)
		{
			this._bb.PutSbyte(--this._space, x);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002684 File Offset: 0x00000884
		public void PutByte(byte x)
		{
			this._bb.PutByte(--this._space, x);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000026B0 File Offset: 0x000008B0
		public void PutShort(short x)
		{
			this._bb.PutShort(this._space -= 2, x);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000026DC File Offset: 0x000008DC
		public void PutUshort(ushort x)
		{
			this._bb.PutUshort(this._space -= 2, x);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002708 File Offset: 0x00000908
		public void PutInt(int x)
		{
			this._bb.PutInt(this._space -= 4, x);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002734 File Offset: 0x00000934
		public void PutUint(uint x)
		{
			this._bb.PutUint(this._space -= 4, x);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002760 File Offset: 0x00000960
		public void PutLong(long x)
		{
			this._bb.PutLong(this._space -= 8, x);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000278C File Offset: 0x0000098C
		public void PutUlong(ulong x)
		{
			this._bb.PutUlong(this._space -= 8, x);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000027B8 File Offset: 0x000009B8
		public void PutFloat(float x)
		{
			this._bb.PutFloat(this._space -= 4, x);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000027E4 File Offset: 0x000009E4
		public void PutDouble(double x)
		{
			this._bb.PutDouble(this._space -= 8, x);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000280E File Offset: 0x00000A0E
		public void AddBool(bool x)
		{
			this.Prep(1, 0);
			this.PutBool(x);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000281F File Offset: 0x00000A1F
		public void AddSbyte(sbyte x)
		{
			this.Prep(1, 0);
			this.PutSbyte(x);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002830 File Offset: 0x00000A30
		public void AddByte(byte x)
		{
			this.Prep(1, 0);
			this.PutByte(x);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002841 File Offset: 0x00000A41
		public void AddShort(short x)
		{
			this.Prep(2, 0);
			this.PutShort(x);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002852 File Offset: 0x00000A52
		public void AddUshort(ushort x)
		{
			this.Prep(2, 0);
			this.PutUshort(x);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002863 File Offset: 0x00000A63
		public void AddInt(int x)
		{
			this.Prep(4, 0);
			this.PutInt(x);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002874 File Offset: 0x00000A74
		public void AddUint(uint x)
		{
			this.Prep(4, 0);
			this.PutUint(x);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002885 File Offset: 0x00000A85
		public void AddLong(long x)
		{
			this.Prep(8, 0);
			this.PutLong(x);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002896 File Offset: 0x00000A96
		public void AddUlong(ulong x)
		{
			this.Prep(8, 0);
			this.PutUlong(x);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000028A7 File Offset: 0x00000AA7
		public void AddFloat(float x)
		{
			this.Prep(4, 0);
			this.PutFloat(x);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000028B8 File Offset: 0x00000AB8
		public void AddDouble(double x)
		{
			this.Prep(8, 0);
			this.PutDouble(x);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000028C9 File Offset: 0x00000AC9
		public void AddOffset(int off)
		{
			this.Prep(4, 0);
			if (off > this.Offset)
			{
				throw new ArgumentException();
			}
			off = this.Offset - off + 4;
			this.PutInt(off);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000028F5 File Offset: 0x00000AF5
		public void StartVector(int elemSize, int count, int alignment)
		{
			this.NotNested();
			this._vectorNumElems = count;
			this.Prep(4, elemSize * count);
			this.Prep(alignment, elemSize * count);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002918 File Offset: 0x00000B18
		public VectorOffset EndVector()
		{
			this.PutInt(this._vectorNumElems);
			return new VectorOffset(this.Offset);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002931 File Offset: 0x00000B31
		public void Nested(int obj)
		{
			if (obj != this.Offset)
			{
				throw new Exception("FlatBuffers: struct must be serialized inline.");
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002947 File Offset: 0x00000B47
		public void NotNested()
		{
			if (this._vtable != null)
			{
				throw new Exception("FlatBuffers: object serialization must not be nested.");
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000295C File Offset: 0x00000B5C
		public void StartObject(int numfields)
		{
			this.NotNested();
			this._vtable = new int[numfields];
			this._objectStart = this.Offset;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000297C File Offset: 0x00000B7C
		public void Slot(int voffset)
		{
			this._vtable[voffset] = this.Offset;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000298C File Offset: 0x00000B8C
		public void AddBool(int o, bool x, bool d)
		{
			if (x != d)
			{
				this.AddBool(x);
				this.Slot(o);
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000029A0 File Offset: 0x00000BA0
		public void AddSbyte(int o, sbyte x, sbyte d)
		{
			if (x != d)
			{
				this.AddSbyte(x);
				this.Slot(o);
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000029B4 File Offset: 0x00000BB4
		public void AddByte(int o, byte x, byte d)
		{
			if (x != d)
			{
				this.AddByte(x);
				this.Slot(o);
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000029C8 File Offset: 0x00000BC8
		public void AddShort(int o, short x, int d)
		{
			if ((int)x != d)
			{
				this.AddShort(x);
				this.Slot(o);
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000029DC File Offset: 0x00000BDC
		public void AddUshort(int o, ushort x, ushort d)
		{
			if (x != d)
			{
				this.AddUshort(x);
				this.Slot(o);
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000029F0 File Offset: 0x00000BF0
		public void AddInt(int o, int x, int d)
		{
			if (x != d)
			{
				this.AddInt(x);
				this.Slot(o);
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002A04 File Offset: 0x00000C04
		public void AddUint(int o, uint x, uint d)
		{
			if (x != d)
			{
				this.AddUint(x);
				this.Slot(o);
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002A18 File Offset: 0x00000C18
		public void AddLong(int o, long x, long d)
		{
			if (x != d)
			{
				this.AddLong(x);
				this.Slot(o);
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002A2C File Offset: 0x00000C2C
		public void AddUlong(int o, ulong x, ulong d)
		{
			if (x != d)
			{
				this.AddUlong(x);
				this.Slot(o);
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002A40 File Offset: 0x00000C40
		public void AddFloat(int o, float x, double d)
		{
			if ((double)x != d)
			{
				this.AddFloat(x);
				this.Slot(o);
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002A55 File Offset: 0x00000C55
		public void AddDouble(int o, double x, double d)
		{
			if (x != d)
			{
				this.AddDouble(x);
				this.Slot(o);
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002A69 File Offset: 0x00000C69
		public void AddOffset(int o, int x, int d)
		{
			if (x != d)
			{
				this.AddOffset(x);
				this.Slot(o);
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002A80 File Offset: 0x00000C80
		public StringOffset CreateString(string s)
		{
			this.NotNested();
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			this.AddByte(0);
			this.StartVector(1, bytes.Length, 1);
			Buffer.BlockCopy(bytes, 0, this._bb.Data, this._space -= bytes.Length, bytes.Length);
			return new StringOffset(this.EndVector().Value);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002AE9 File Offset: 0x00000CE9
		public void AddStruct(int voffset, int x, int d)
		{
			if (x != d)
			{
				this.Nested(x);
				this.Slot(voffset);
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002B00 File Offset: 0x00000D00
		public int EndObject()
		{
			if (this._vtable == null)
			{
				throw new InvalidOperationException("Flatbuffers: calling endObject without a startObject");
			}
			this.AddInt(0);
			int offset = this.Offset;
			for (int i = this._vtable.Length - 1; i >= 0; i--)
			{
				short x = (short)((this._vtable[i] != 0) ? (offset - this._vtable[i]) : 0);
				this.AddShort(x);
			}
			this.AddShort((short)(offset - this._objectStart));
			this.AddShort((short)((this._vtable.Length + 2) * 2));
			int num = 0;
			for (int j = 0; j < this._numVtables; j++)
			{
				int num2 = this._bb.Length - this._vtables[j];
				int space = this._space;
				short @short = this._bb.GetShort(num2);
				if (@short == this._bb.GetShort(space))
				{
					for (int k = 2; k < (int)@short; k += 2)
					{
						if (this._bb.GetShort(num2 + k) != this._bb.GetShort(space + k))
						{
							goto IL_100;
						}
					}
					num = this._vtables[j];
					break;
				}
				IL_100:;
			}
			if (num != 0)
			{
				this._space = this._bb.Length - offset;
				this._bb.PutInt(this._space, num - offset);
			}
			else
			{
				if (this._numVtables == this._vtables.Length)
				{
					int[] array = new int[this._numVtables * 2];
					Array.Copy(this._vtables, array, this._vtables.Length);
					this._vtables = array;
				}
				int[] vtables = this._vtables;
				int numVtables = this._numVtables;
				this._numVtables = numVtables + 1;
				vtables[numVtables] = this.Offset;
				this._bb.PutInt(this._bb.Length - offset, this.Offset - offset);
			}
			this._vtable = null;
			return offset;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002CD4 File Offset: 0x00000ED4
		public void Required(int table, int field)
		{
			int num = this._bb.Length - table;
			int num2 = num - this._bb.GetInt(num);
			if (this._bb.GetShort(num2 + field) == 0)
			{
				throw new InvalidOperationException("FlatBuffers: field " + field + " must be set");
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002D2C File Offset: 0x00000F2C
		public void Finish(int rootTable)
		{
			this.Prep(this._minAlign, 4);
			this.AddOffset(rootTable);
			this._bb.Position = this._space;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002D53 File Offset: 0x00000F53
		public ByteBuffer DataBuffer
		{
			get
			{
				return this._bb;
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002D5C File Offset: 0x00000F5C
		public byte[] SizedByteArray()
		{
			byte[] array = new byte[this._bb.Data.Length - this._bb.Position];
			Buffer.BlockCopy(this._bb.Data, this._bb.Position, array, 0, this._bb.Data.Length - this._bb.Position);
			return array;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002DC0 File Offset: 0x00000FC0
		public void Finish(int rootTable, string fileIdentifier)
		{
			this.Prep(this._minAlign, 8);
			if (fileIdentifier.Length != 4)
			{
				throw new ArgumentException("FlatBuffers: file identifier must be length " + 4, "fileIdentifier");
			}
			for (int i = 3; i >= 0; i--)
			{
				this.AddByte((byte)fileIdentifier[i]);
			}
			this.Finish(rootTable);
		}

		// Token: 0x04000007 RID: 7
		private int _space;

		// Token: 0x04000008 RID: 8
		private ByteBuffer _bb;

		// Token: 0x04000009 RID: 9
		private int _minAlign = 1;

		// Token: 0x0400000A RID: 10
		private int[] _vtable;

		// Token: 0x0400000B RID: 11
		private int _objectStart;

		// Token: 0x0400000C RID: 12
		private int[] _vtables = new int[16];

		// Token: 0x0400000D RID: 13
		private int _numVtables;

		// Token: 0x0400000E RID: 14
		private int _vectorNumElems;
	}
}
