using System;
using Stack;

namespace PolishCalculator
{
	public class PolishCalc : ICalculator
	{
		private Stack<double> calcStack = new Stack<double>();
		
		public double Calculate(string data)
		{
			string[] operators = data.Split(' ');
			for (int i = 0; i <= operators.Length; i++)
			{
				double firstNumber;
				bool isNumber = double.TryParse(operators[i], out firstNumber);
				if (isNumber)
				{
					calcStack.Push(firstNumber);
				}
				else
				{
					//TODO: Replace declaration closer to usage.  I can't!
					double secondNumber;
					switch (operators[i])
					{
						case "+":
							calcStack.Push(calcStack.Pop() + calcStack.Pop());
							break;
						case "*":
							calcStack.Push(calcStack.Pop() * calcStack.Pop());
							break;
						case "-":
							secondNumber = calcStack.Pop();
							calcStack.Push(calcStack.Pop() - secondNumber);
							break;
						case "/":
							secondNumber = calcStack.Pop();
							if (secondNumber != 0.0)
							{
								calcStack.Push(calcStack.Pop() / secondNumber);
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
			return calcStack.Pop();
		}
	}
}
