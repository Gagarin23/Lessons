using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sw = new StreamWriter("path/", true, Encoding.UTF8))
            {
                sw.WriteLine("text");
            }
            using (var sr = new StreamReader("path/", Encoding.UTF8))
            {
                while (!sr.EndOfStream) //построчное чтение до конца файла
                {
                    sr.ReadLine();
                }
                sr.DiscardBufferedData(); //очистка буффера
                sr.BaseStream.Seek(0, SeekOrigin.Begin); //переход в начало потока
            }
        }
    }
}
