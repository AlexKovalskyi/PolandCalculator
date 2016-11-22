using PolishCalculator;


namespace RemotePolishCalculatorApp
{
	class Program
	{
		static void Main(string[] args)
		{
			PolishCalc calc = new PolishCalc();
			TCPServer.TCPServer server = new TCPServer.TCPServer(calc);
			server.RunServer();

		}
	}
}
