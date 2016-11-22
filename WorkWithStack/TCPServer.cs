using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using PolishCalculator;

namespace TCPServer
{
	public class TCPServer
	{
		private const string SERVER_IP = "127.0.0.1";
		private static int port = 8005;
		private ICalculator calculator;

		public TCPServer(ICalculator calculator)
		{
			this.calculator = calculator;
		}
		public void RunServer()
		{
			// get addresses for socket start
			IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(SERVER_IP), port);

			// create Socket
			Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			try
			{
				// bind a socket to a local point at which we receive data
				listenSocket.Bind(ipPoint);

				//  start listerning
				listenSocket.Listen(10);

				Console.WriteLine("Listening...");

				while (true)
				{
					Socket handler = listenSocket.Accept();
					// get message
					StringBuilder builder = new StringBuilder();
					int bytes = 0; // amount of bytes what we have got
					byte[] data = new byte[256]; // buffer for the received data

					do
					{
						bytes = handler.Receive(data);
						builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
					}
					while (handler.Available > 0);

					Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());

					Console.WriteLine($"Answer: {calculator.Calculate(builder.ToString())}");

					// sending answer
					string message = calculator.Calculate(builder.ToString()).ToString();
					data = Encoding.Unicode.GetBytes(message);
					handler.Send(data);
					// closing socket
					handler.Shutdown(SocketShutdown.Both);
					handler.Close();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
