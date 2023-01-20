/**

Group members:
--------------
Nindaba Arthur 57086
Rashi Sonavani 56480
Manthan Pathak 56458

*/

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
public class ProjectServer
{
    static void Main(string[] args)
    {
        TcpListener sock = new TcpListener(IPAddress.Parse("127.0.0.1"), 2222);
        sock.Start();
        TcpClient client = sock.AcceptTcpClient();
        IPEndPoint client_end_point = (IPEndPoint)client.Client.RemoteEndPoint;
        IPAddress client_addr = client_end_point.Address;
        Console.WriteLine($"Accepted connection from {client_addr}:{client_end_point.Port}.");
        NetworkStream stream = client.GetStream();
        const int buf_size = 1024;
        byte[] bytes = new byte[buf_size];
        string data;
        Int32 sum = 0;
        while (true)
        {
            int bytesCount = stream.Read(bytes, 0, bytes.Length);
            data = System.Text.Encoding.ASCII.GetString(bytes, 0, bytesCount);
            if (data == "FINISH") break;
            sum += Int32.Parse(data);
            Console.WriteLine($"Received '{data}'");
        } // end while
        Console.WriteLine($"The Sum of the recieved numbers is {sum}");
        Console.WriteLine($"Closed the connection with {client_addr}:{client_end_point.Port}.");
    
    }
}