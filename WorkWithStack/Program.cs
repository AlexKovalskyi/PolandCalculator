using System;

namespace WorkWithStack
{
	class Program
	{
		static void Main(string[] args)
		{
			ReadConsole read = new ReadConsole();

			PolandCalculator calculator = new PolandCalculator();

			double result = calculator.Calculate(read.GetDataFromConsole());
			Console.WriteLine(result);
			Console.Read();

			TCPServer clas = new TCPServer();
			clas.RunServer();
		}
	}
}
