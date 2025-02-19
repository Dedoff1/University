using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;

class Server
{
    static List<NetworkStream> connectedClients = new List<NetworkStream>();

    static void Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 8888);
        server.Start();
        Console.WriteLine("Server has started.");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            connectedClients.Add(stream);
            Console.WriteLine("Client connected.");

            Thread thread = new Thread(() => HandleClient(stream));
            thread.Start();
        }
    }

    static void HandleClient(NetworkStream stream)
    {
        byte[] buffer = new byte[1024];
        while (true)
        {
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            if (bytesRead == 0)
            {
                connectedClients.Remove(stream);
                break;
            }
            string currentTime = DateTime.Now.ToString("HH:mm");
            string message = $"{currentTime}: {Encoding.ASCII.GetString(buffer, 0, bytesRead)}";
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);

            foreach (var clientStream in connectedClients)
            {
                clientStream.Write(messageBytes, 0, messageBytes.Length);
            }
        }
    }
}
