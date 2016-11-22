using TCPServer;
using PolishCalculator;


namespace RemotePolishCalculatorApp
{
	class Program
	{
		static void Main(string[] args)
		{
			PolishCalc calc = new PolishCalc();
			TCPServe server = new TCPServe(calc);
			server.RunServer();

		}
	}
}
