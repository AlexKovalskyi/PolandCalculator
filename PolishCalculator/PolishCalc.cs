using System;
using Stack;

namespace PolishCalculator
{
	public class PolishCalc : ICalculator
	{
		//TODO: stack => calcStack
		private Stack<double> stack = new Stack<double>();
		//TODO: default ctor is available without declaration.
		public PolishCalc()
		{
		}
		public double Calculate(string data)
		{
			string[] operators = data.Split(' ');
			//TODO: i <= operators.Length - 1 . WTF?
			for (int i = 0; i <= operators.Length - 1; i++)
			{
				double firstNumber;
				bool isNumber = double.TryParse(operators[i], out firstNumber);
				if (isNumber)
				{
					stack.Push(firstNumber);
				}
				else
				{
					//TODO: Replace declaration closer to usage.
					double secondNumber;
					switch (operators[i])
					{
						case "+":
							stack.Push(stack.Pop() + stack.Pop());
							break;
						case "*":
							stack.Push(stack.Pop() * stack.Pop());
							break;
						case "-":
							secondNumber = stack.Pop();
							stack.Push(stack.Pop() - secondNumber);
							break;
						case "/":
							secondNumber = stack.Pop();
							if (secondNumber != 0.0)
							{
								stack.Push(stack.Pop() / secondNumber);
							}
							else
								Console.WriteLine("You cant divide on 0!");
							break;
						default:
							Console.WriteLine("Unknown command.");
							break;
					}
				}
			}
			return stack.Pop();
		}
	}
}
