using System;

namespace FlatBuffers
{
	// Token: 0x02000002 RID: 2
	public class ByteBuffer
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public int Length
		{
			get
			{
				return this._buffer.Length;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000002 RID: 2 RVA: 0x0000205A File Offset: 0x0000025A
		public byte[] Data
		{
			get
			{
				return this._buffer;
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002062 File Offset: 0x00000262
		public ByteBuffer(byte[] buffer) : this(buffer, 0)
		{
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000206C File Offset: 0x0000026C
		public ByteBuffer(byte[] buffer, int pos)
		{
			this._buffer = buffer;
			this._pos = pos;
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020BD File Offset: 0x000002BD
		// (set) Token: 0x06000006 RID: 6 RVA: 0x000020C5 File Offset: 0x000002C5
		public int Position
		{
			get
			{
				return this._pos;
			}
			set
			{
				this._pos = value;
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020CE File Offset: 0x000002CE
		public void Reset()
		{
			this._pos = 0;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020D7 File Offset: 0x000002D7
		public static ushort ReverseBytes(ushort input)
		{
			return (ushort)((int)(input & 255) << 8 | (int)((uint)(input & 65280) >> 8));
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020ED File Offset: 0x000002ED
		public static uint ReverseBytes(uint input)
		{
			return (input & 255U) << 24 | (input & 65280U) << 8 | (input & 16711680U) >> 8 | (input & 4278190080U) >> 24;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002118 File Offset: 0x00000318
		public static ulong ReverseBytes(ulong input)
		{
			return (input & 255UL) << 56 | (input & 65280UL) << 40 | (input & 16711680UL) << 24 | (input & unchecked((ulong)-16777216)) << 8 | (input & 1095216660480UL) >> 8 | (input & 280375465082880UL) >> 24 | (input & 71776119061217280UL) >> 40 | (input & 18374686479671623680UL) >> 56;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002190 File Offset: 0x00000390
		protected void WriteLittleEndian(int offset, int count, ulong data)
		{
			if (BitConverter.IsLittleEndian)
			{
				for (int i = 0; i < count; i++)
				{
					this._buffer[offset + i] = (byte)(data >> i * 8);
				}
				return;
			}
			for (int j = 0; j < count; j++)
			{
				this._buffer[offset + count - 1 - j] = (byte)(data >> j * 8);
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000021E8 File Offset: 0x000003E8
		protected ulong ReadLittleEndian(int offset, int count)
		{
			this.AssertOffsetAndLength(offset, count);
			ulong num = 0UL;
			if (BitConverter.IsLittleEndian)
			{
				for (int i = 0; i < count; i++)
				{
					num |= (ulong)this._buffer[offset + i] << i * 8;
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					num |= (ulong)this._buffer[offset + count - 1 - j] << j * 8;
				}
			}
			return num;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002250 File Offset: 0x00000450
		private void AssertOffsetAndLength(int offset, int length)
		{
			if (offset < 0 || offset >= this._buffer.Length || offset + length > this._buffer.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002274 File Offset: 0x00000474
		public void PutSbyte(int offset, sbyte value)
		{
			this.AssertOffsetAndLength(offset, 1);
			this._buffer[offset] = (byte)value;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002288 File Offset: 0x00000488
		public void PutByte(int offset, byte value)
		{
			this.AssertOffsetAndLength(offset, 1);
			this._buffer[offset] = value;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000229B File Offset: 0x0000049B
		public void Put(int offset, byte value)
		{
			this.PutByte(offset, value);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000022A5 File Offset: 0x000004A5
		public void PutShort(int offset, short value)
		{
			this.AssertOffsetAndLength(offset, 2);
			this.WriteLittleEndian(offset, 2, (ulong)((long)value));
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000022B9 File Offset: 0x000004B9
		public void PutUshort(int offset, ushort value)
		{
			this.AssertOffsetAndLength(offset, 2);
			this.WriteLittleEndian(offset, 2, (ulong)value);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000022CD File Offset: 0x000004CD
		public void PutInt(int offset, int value)
		{
			this.AssertOffsetAndLength(offset, 4);
			this.WriteLittleEndian(offset, 4, (ulong)((long)value));
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000022E1 File Offset: 0x000004E1
		public void PutUint(int offset, uint value)
		{
			this.AssertOffsetAndLength(offset, 4);
			this.WriteLittleEndian(offset, 4, (ulong)value);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000022F5 File Offset: 0x000004F5
		public void PutLong(int offset, long value)
		{
			this.AssertOffsetAndLength(offset, 8);
			this.WriteLittleEndian(offset, 8, (ulong)value);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000022F5 File Offset: 0x000004F5
		public void PutUlong(int offset, ulong value)
		{
			this.AssertOffsetAndLength(offset, 8);
			this.WriteLittleEndian(offset, 8, value);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002308 File Offset: 0x00000508
		public void PutFloat(int offset, float value)
		{
			this.AssertOffsetAndLength(offset, 4);
			this.floathelper[0] = value;
			Buffer.BlockCopy(this.floathelper, 0, this.inthelper, 0, 4);
			this.WriteLittleEndian(offset, 4, (ulong)((long)this.inthelper[0]));
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002340 File Offset: 0x00000540
		public void PutDouble(int offset, double value)
		{
			this.AssertOffsetAndLength(offset, 8);
			this.doublehelper[0] = value;
			Buffer.BlockCopy(this.doublehelper, 0, this.ulonghelper, 0, 8);
			this.WriteLittleEndian(offset, 8, this.ulonghelper[0]);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002377 File Offset: 0x00000577
		public sbyte GetSbyte(int index)
		{
			this.AssertOffsetAndLength(index, 1);
			return (sbyte)this._buffer[index];
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000238A File Offset: 0x0000058A
		public byte Get(int index)
		{
			this.AssertOffsetAndLength(index, 1);
			return this._buffer[index];
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000239C File Offset: 0x0000059C
		public short GetShort(int index)
		{
			return (short)this.ReadLittleEndian(index, 2);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000023A7 File Offset: 0x000005A7
		public ushort GetUshort(int index)
		{
			return (ushort)this.ReadLittleEndian(index, 2);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000023B2 File Offset: 0x000005B2
		public int GetInt(int index)
		{
			return (int)this.ReadLittleEndian(index, 4);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000023BD File Offset: 0x000005BD
		public uint GetUint(int index)
		{
			return (uint)this.ReadLittleEndian(index, 4);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000023C8 File Offset: 0x000005C8
		public long GetLong(int index)
		{
			return (long)this.ReadLittleEndian(index, 8);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000023C8 File Offset: 0x000005C8
		public ulong GetUlong(int index)
		{
			return this.ReadLittleEndian(index, 8);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000023D4 File Offset: 0x000005D4
		public float GetFloat(int index)
		{
			int num = (int)this.ReadLittleEndian(index, 4);
			this.inthelper[0] = num;
			Buffer.BlockCopy(this.inthelper, 0, this.floathelper, 0, 4);
			return this.floathelper[0];
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002410 File Offset: 0x00000610
		public double GetDouble(int index)
		{
			ulong num = this.ReadLittleEndian(index, 8);
			this.ulonghelper[0] = num;
			Buffer.BlockCopy(this.ulonghelper, 0, this.doublehelper, 0, 8);
			return this.doublehelper[0];
		}

		// Token: 0x04000001 RID: 1
		private readonly byte[] _buffer;

		// Token: 0x04000002 RID: 2
		private int _pos;

		// Token: 0x04000003 RID: 3
		private float[] floathelper = new float[1];

		// Token: 0x04000004 RID: 4
		private int[] inthelper = new int[1];

		// Token: 0x04000005 RID: 5
		private double[] doublehelper = new double[1];

		// Token: 0x04000006 RID: 6
		private ulong[] ulonghelper = new ulong[1];
	}
}
