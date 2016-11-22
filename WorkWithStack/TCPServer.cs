using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using PolishCalculator;

namespace TCPServer
{
	public class TCPServe
	{
		//TODO: access modifier missed
		const string SERVER_IP = "127.0.0.1";
		//TODO: access modifier missed
		static int port = 8005;
		private ICalculator calculator;

		public TCPServe(ICalculator calculator)
		{
			this.calculator = calculator;
		}
		public void RunServer()
		{
			//TODO: Russion comments for dummies
			// получаем адреса для запуска сокета
			IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(SERVER_IP), port);

			// создаем сокет
			Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			try
			{
				// связываем сокет с локальной точкой, по которой будем принимать данные
				listenSocket.Bind(ipPoint);

				// начинаем прослушивание
				listenSocket.Listen(10);

				Console.WriteLine("Listening...");

				while (true)
				{
					Socket handler = listenSocket.Accept();
					// получаем сообщение
					StringBuilder builder = new StringBuilder();
					int bytes = 0; // количество полученных байтов
					byte[] data = new byte[256]; // буфер для получаемых данных

					do
					{
						bytes = handler.Receive(data);
						builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
					}
					while (handler.Available > 0);

					Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());

					Console.WriteLine($"Answer: {calculator.Calculate(builder.ToString())}");

					// отправляем ответ
					string message = calculator.Calculate(builder.ToString()).ToString();
					data = Encoding.Unicode.GetBytes(message);
					handler.Send(data);
					// закрываем сокет
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
