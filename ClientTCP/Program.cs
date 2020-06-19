using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //создаем сокет

            Console.WriteLine("Введите сообщение");
            var message = Console.ReadLine();

            var data = Encoding.UTF8.GetBytes(message);
            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);

            var buffer = new byte[256]; //буффер
            var size = 0; //кол-во реально полученных байт
            var answer = new StringBuilder(); //ответ с сервера

            do
            {
                size = tcpSocket.Receive(buffer); //получает байты из буффера и записывает реальный размер в size
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size)); //дописываем данные из буффера 
            }
            while (tcpSocket.Available > 0); //пока есть данные, будет читать их

            Console.WriteLine(answer.ToString());

            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();
            Console.ReadLine();
        }
    }
}
