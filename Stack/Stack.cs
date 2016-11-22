using System;
using System.Collections;
using System.Linq;

namespace Stack
{
	public class Stack<T> : IEnumerable
	{
		//TODO: stack => expression
		T[] stack;
		public int Count()
		{
			//TODO: What if stack == null ? 
			return stack.Count();
		}

		public void Push(T item)
		{
			//TODO: stack == null is the sames as this.Contains()
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
			//TODO: rewrite to ternary operation, and you will see more. mother fucker blind copypaster.
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
			//TODO: what if stack == null? 
			return stack.GetEnumerator();
		}

	}
}
