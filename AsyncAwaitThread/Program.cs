using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitThread
{
    class Program
    {
        public static object locker = new object(); // объект для конкретного потока(обязательно ссылочного типа, static)
        static void Main(string[] args)
        {
            //Threads();

            //DoWorkAsync();

            var result = SaveFileAsync(@"d:\test22\test.txt");

            var input = Console.ReadLine();
            Console.WriteLine(result.Result); //result - возвращение Task<bool> .Result - результат возвращаемого значения
             #region цикл
            //int j = 0;
            //for (int i = 0; i < int.MaxValue; i++)
            //{
            //    j++;
            //    if (j % 10000 == 0)
            //    {
            //        Console.WriteLine("Main");
            //    }
            //}
            #endregion

            Console.ReadLine();
        }
        static async Task<bool> SaveFileAsync(string path)
        {
            var result = await Task.Run(() => SaveFile(path));
            return result;
        }
        static bool SaveFile(string path)
        {
            lock (locker) // доступ только к переменной locker
            {
                var rnd = new Random();
                var text = "";
                for (int i = 0; i < 30000; i++)
                {
                    text += rnd.Next();
                }
            }
            using (var sr = new StreamWriter(path, false, Encoding.UTF8))
            {
                sr.WriteLine();
            }
            return true;
        }
        static async Task DoWorkAsync()
        {
            await Task.Run(() => DoWork()); //при await происходит ожидание завершения операции.
            Console.WriteLine("DoWork Async");
        }

        static void Threads()
        {
            Thread thread = new Thread(new ThreadStart(DoWork)); //ThreadStart для метода без аргументов
            thread.Start();

            Thread thread2 = new Thread(new ParameterizedThreadStart(DoWork2)); //ParameterizedThreadStart может принимать только тип object
            thread2.Start(int.MaxValue);
        }
        static void DoWork()
        {
            int j = 0;
            for(int i = 0; i < int.MaxValue; i++)
            {
                j++;
                if(j % 10000 == 0)
                {
                    Console.WriteLine("DoWork");
                }
            }
        }
        static void DoWork2(object max)
        {
            int j = 0;
            for (int i = 0; i < (int)max; i++)
            {
                j++;
                if (j % 10000 == 0)
                {
                    Console.WriteLine("DoWork 2");
                }
            }
        }
    }
}
