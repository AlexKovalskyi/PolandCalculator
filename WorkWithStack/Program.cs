using System;

namespace WorkWithStack
{
	class Program
	{
		static void Main(string[] args)
		{
			ReadConsole read = new ReadConsole();

			PolandCalculator calculator = new PolandCalculator(read.GetDataFromConsole());

			double result = calculator.Calculate();
			Console.WriteLine(result);
			Console.Read();
		}
	}
}
