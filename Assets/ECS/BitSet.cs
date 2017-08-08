

namespace ecs
{

	public class BitSet
	{
		private int[] data;


		public BitSet()
		{
			data = new int[1];
		}


		public BitSet(int bitSize)
		{
			int length = bitSize / sizeof(int) + (bitSize % sizeof(int) == 0 ? 0 : 1);
			if (length < 1)
				length = 1;
			data = new int[length];
		}


		public void Clear()
		{
			for (int i = 0; i < data.Length; ++i)
			{
				data[i] = 0;
			}
		}


		public bool Contains(BitSet other)
		{
			if (other.data.Length > data.Length)
				return false;
			for (int i = 0; i < other.data.Length; ++i)
			{
				if ((data[i] & other.data[i]) != other.data[i])
					return false;
			}
			return true;
		}


		public bool this[int index]
		{
			get
			{
				return Get(index);
			}
			set
			{
				Set(index, value);
			}
		}

		
		private void Set(int index, bool value)
		{
			if (index >= data.Length * sizeof(int))
			{
				int length = index / sizeof(int) + (index % sizeof(int) == 0 ? 0 : 1);
				Grow(length);
			}
			int i = index / sizeof(int);
			int left = index % sizeof(int);
			data[i] |= (value ? 1 : 0) << left;
		}


		private bool Get(int index)
		{
			if (index >= data.Length * sizeof(int))
			{
				int length = index / sizeof(int) + (index % sizeof(int) == 0 ? 0 : 1);
				Grow(length);
			}
			int i = index / sizeof(int);
			int left = index % sizeof(int);
			return (data[i] >> left & 1) > 0;
		}


		private void Grow(int newLength)
		{
			int[] newData = new int[newLength];

			for (int i = 0; i < data.Length; i++)
				newData[i] = data[i];
			for (int i = data.Length; i < newLength; i++)
				newData[i] = 0;

			data = newData;
		}


	}

}