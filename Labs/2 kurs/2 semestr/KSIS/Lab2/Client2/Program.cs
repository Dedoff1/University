using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class TcpClient2
{
    private const int port = 8888;
    private static IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
    static void Main(string[] args)
    {
        TcpClient client = new TcpClient();
        client.Connect(ipAddress, port);
        Console.WriteLine("Подключение к серверу установлено.");
        NetworkStream stream = client.GetStream();
        while (true)
        {
            Console.Write("Введите сообщение: ");
            string message = Console.ReadLine();
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
            byte[] responseData = new byte[256];
            int bytes = stream.Read(responseData, 0, responseData.Length);
            string response = Encoding.Unicode.GetString(responseData, 0, bytes);
            Console.WriteLine("Ответ от сервера: " + response);
            if (string.IsNullOrEmpty(message))
            {
                break;
            }
        }
        client.Close();
    }
}

