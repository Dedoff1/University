using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class TcpServer
{
    private const int port = 8888;
    static void Main(string[] args)
    {
        TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
        server.Start();
        Console.WriteLine("Сервер запущен. Ожидание подключений...");
        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Новый клиент подключен.");
            Thread clientThread = new Thread(() => HandleClient(client));
            clientThread.Start();
        }
    }

    static void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        while (true)
        {
            byte[] data = new byte[256];
            int bytes = stream.Read(data, 0, data.Length);
            string message = Encoding.Unicode.GetString(data, 0, bytes);
            Console.WriteLine("Получено сообщение: " + message);
            if (string.IsNullOrEmpty(message))
            {
                client.Close();
                break;
            }
            foreach (TcpClient otherClient in clients)
            {
                if (otherClient != client)
                {
                    NetworkStream otherStream = otherClient.GetStream();
                    otherStream.Write(data, 0, bytes);
                }
            }
        }
    }
}
