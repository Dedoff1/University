using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Client
{
    static void Main()
    {
        TcpClient client = new TcpClient("127.0.0.1", 8888);
        NetworkStream stream = client.GetStream();

        Thread receiveThread = new Thread(() => ReceiveMessages(stream));
        receiveThread.Start();

        while (true)
        {
            string message = Console.ReadLine();
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            stream.Write(messageBytes, 0, messageBytes.Length);
        }
    }

    static void ReceiveMessages(NetworkStream stream)
    {
        byte[] buffer = new byte[1024];
        while (true)
        {
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string receivedMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine(receivedMessage);
        }
    }
}
