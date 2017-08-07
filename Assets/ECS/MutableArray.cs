

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

		public void Add(T o)
		{
			if (size == count)
				Grow();
			data[count++] = o;
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

		public T this[int index]
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

		private T Get(int index)
		{
			return data[index];
		}

		private void Set(int index, T o)
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
		}

		public int GetCapacity()
		{
			return size;
		}

		public bool IsEmpty()
		{
			return count == 0;
		}

		public bool Remove(T o)
		{
			if (o == null)
				return false;

			for (int i = 0; i < count; i++)
			{
				if (o == data[i])
				{
					Remove(i);
					return true;
				}
			}
			return false;
		}

		public T Remove(int index)
		{
			if (count == 0)
				return null;

			T obj = data[index];
			data[index] = data[count - 1];
			data[count - 1] = null;
			count--;
			return (T)obj;
		}

		public T RemoveLast()
		{
			if (count > 0)
			{
				T obj = data[count - 1];
				data[count - 1] = null;
				--count;
				return (T)obj;
			}

			return null;
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
