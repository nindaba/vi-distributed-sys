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
public class ProjectClient
{
    static void Main(string[] args)
    {
        TcpClient myClient = new TcpClient("localhost", 2222);
        NetworkStream str = myClient.GetStream();
        while (true)
        {
            Console.Write("Number to send: ");
            string data = Console.ReadLine();
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            str.Write(buffer, 0, buffer.Length);
            Console.WriteLine($"Sent: '{data}'");
            if (data == "FINISH") break;
        }
        str.Close();
        myClient.Close();
    }
}