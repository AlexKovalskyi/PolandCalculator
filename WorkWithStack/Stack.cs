using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithStack
{
	public class Stack<T> : IEnumerable
	{
		T[] stack;
		public int Count()
		{
			return stack.Count();
		}

		public void Push(T item)
		{
			if (stack == null)
			{
				stack = new T[] { item };
			}
			else
			{
				Array.Resize<T>(ref stack, stack.Length + 1);
				stack[stack.Length - 1] = item;
			}
		}

		public T Pop()
		{
			var item = stack[stack.Length - 1];
			if (item != null)
			{
				Array.Resize(ref stack, stack.Length - 1);
				return item;
			}
			else
			{
				throw new InvalidOperationException();
			}

		}
		public T Peek()
		{
			return stack[stack.Length - 1];
		}

		public bool Contains()
		{
			if (stack != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public IEnumerator GetEnumerator()
		{
			return stack.GetEnumerator();
		}

	}
}
