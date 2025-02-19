using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class TcpClient
{
    private const int port = 8888;
    private static IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
    static void Main(string[] args)
    {
        using (System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient())
        {
            client.Connect(ipAddress, port);
            Console.WriteLine("Подключено к серверу.");
            NetworkStream stream = client.GetStream();
            while (true)
            {
                Console.Write("Введите сообщение: ");
                string message = Console.ReadLine();
                if (string.IsNullOrEmpty(message))
                {
                    break;
                }
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Отправлено: " + message);
                byte[] responseData = new byte[256];
                int bytes = stream.Read(responseData, 0, responseData.Length);
                string response = Encoding.Unicode.GetString(responseData, 0, bytes);
                Console.WriteLine("Сервер: " + response);
            }
            Console.WriteLine("Отключено от сервера.");
        }
    }
}
