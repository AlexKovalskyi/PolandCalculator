using System;
using System.Collections;
using System.Linq;

namespace Stack
{
	public class Stack<T> : IEnumerable
	{
		T[] array;
		public int Count()
		{
			if (array == null)
			{
				throw new NullReferenceException();
			}
			else
			{
				return array.Count();
			}
		}

		public void Push(T item)
		{
			if (!this.Contains())
			{
				array = new T[] { item };
			}
			else
			{
				Array.Resize<T>(ref array, array.Length + 1);
				array[array.Length - 1] = item;
			}
		}

		public T Pop()
		{
			var item = array[array.Length - 1];
			if (item != null)
			{
				Array.Resize(ref array, array.Length - 1);
				return item;
			}
			else
			{
				throw new InvalidOperationException();
			}

		}
		public T Peek()
		{
			return array[array.Length - 1];
		}

		public bool Contains()
		{
			return (array != null) ? true : false;
		}

		public IEnumerator GetEnumerator()
		{
			if (this.Contains())
			{
				return array.GetEnumerator();
			}
			else
			{
				throw new NullReferenceException();
			}
			
		}

	}
}
