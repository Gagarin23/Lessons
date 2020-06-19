using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TCP
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //создаем сокет
            #region tcp socket в режиме ожидания
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(5);
            #endregion

            while (true) //обработчик конкретного клиента(создаётся отдельно под каждого клиента и в конце уничтожается)
            {
                var listener = tcpSocket.Accept(); //слушает
                var buffer = new byte[256]; //буффер
                var size = 0; //кол-во реально полученных байт
                var data = new StringBuilder(); //общее хранилище

                do
                {
                    size = listener.Receive(buffer); //получает байты из буффера и записывает реальный размер в size
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size)); //дописываем данные в хранилище из буффера 
                }
                while (listener.Available > 0); //пока есть данные, будет читать их

                Console.WriteLine(data);

                listener.Send(Encoding.UTF8.GetBytes("Успех"));

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
            #endregion

        }
    }
}
