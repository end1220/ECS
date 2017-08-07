

namespace ecs
{


	public class MutableArray<T> where T : class
	{
		private int count;
		public int Count { get { return count; } }
		private int size;
		private T[] data;


		public MutableArray()
		{
			Init(64);
		}

		public MutableArray(int capacity)
		{
			Init(capacity);
		}

		public MutableArray<T> GetGapless()
		{
			MutableArray<T> bag = new MutableArray<T>(this.count);
			for (int i = 0; i < this.size; i++)
			{
				if (this.data[i] != null)
				{
					bag.Add(data[i]);
				}
			}
			return bag;
		}

		public void Add(T o)
		{
			if (size == count)
				Grow();
			data[count++] = o;
		}

		public void AddRange(MutableArray<T> bag)
		{
			for (int i = 0; i < bag.size; i++)
			{
				Add(bag.data[i]);
			}
		}

		public void Clear()
		{
			for (int i = 0; i < size; i++)
			{
				data[i] = null;
			}
			count = 0;
		}

		public bool Contains(T o)
		{
			for (int i = 0; i < count; i++)
				if (o == data[i])
					return true;

			return false;
		}

		public T Get(int index)
		{
			return (T)data[index];
		}

		public int GetCapacity()
		{
			return size;
		}

		public bool IsEmpty()
		{
			return count == 0;
		}

		public int GetCount()
		{
			return count;
		}

		public bool Remove(T o)
		{
			for (int i = 0; i < count; i++)
			{
				if (o == data[i])
				{
					RemoveAt(i);
					return true;
				}
			}

			return false;
		}

		public T RemoveAt(int index)
		{
			if (count == 0)
				return null;

			T obj = data[index];
			data[index] = data[count - 1];
			data[count - 1] = null;
			count--;
			return (T)obj;
		}

		public bool RemoveRange(MutableArray<T> bag)
		{
			bool mod = false;

			for (int i = 0; i < bag.count; i++)
				for (int j = 0; j < count; j++)
					if (bag.data[i] == data[j])
					{
						RemoveAt(j);
						j--; // ?
						mod = true;
						break;
					}

			return mod;

		}


		public T RemoveLast()
		{
			if (!IsEmpty())
			{
				T obj = data[count - 1];
				data[count - 1] = null;
				--count;
				return (T)obj;
			}

			return null;
		}


		public bool Set(int index, T o)
		{
			if (index >= size) 
				Grow(index * 2);

			if (o == null && data[index] != null)
			{
				count--;
			}
			else if (o != null && data[index] == null)
			{
				count++;
			}

			data[index] = o;
			return true;
		}

		public void DeleteData()
		{
			for (int i = 0; i < size; i++)
			{
				data[i] = null;
			}
			count = 0;
		}

		private void Grow()
		{
			int newCapacity = (int)((size * 3.0f) * 0.5f + 1.0f);
			Grow(newCapacity);
		}

		private void Grow(int newCapacity)
		{
			T[] newData = new T[newCapacity];

			for (int i = 0; i < size; i++)
				newData[i] = data[i];
			for (int i = size; i < newCapacity; i++)
				newData[i] = null;

			size = newCapacity;
			data = newData;
		}

		private void Init(int capacity)
		{
			size = capacity;
			count = 0;
			data = new T[capacity];
			Clear();
		}

	}
}
