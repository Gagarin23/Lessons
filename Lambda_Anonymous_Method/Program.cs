using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Anonymous_Method
{
    class Program
    {
        public delegate int MyHandler(int i);
        static void Main(string[] args)
        {
            var lesson = new Lesson("Programming");
            lesson.Started += (sender, date) =>
            {
                Console.WriteLine(sender);
                Console.WriteLine(date);
            };
            lesson.Start();

            var list = new List<int>();
            for(int i = 0; i < 100; i++)
            {
                list.Add(i);
            }
            var res = list.Aggregate((x, y) => x + y);
            Console.WriteLine(res);

            var result1 = Agr(list, delegate (int i)
            {
                var r = i * i;
                Console.WriteLine(r);
                return r;
            });

            var result2 = Agr(list, x => x * x * x);

            MyHandler handler = delegate (int i)
            {
                var r = i * i;
                Console.WriteLine(r);
                return r;
            };
            handler(88);

            MyHandler lambdaHandler = (i) => /*i * i;*/
            {
                var r = i * i;
                Console.WriteLine(r);
                return r;
            };

            lambdaHandler(99);
            Console.ReadLine();
        }

        public static int Agr(List<int> list, MyHandler handler) //динамический метод, в который можно передать другой метод или лямбда выражение
        {
            int result = 0;
            foreach(var item in list)
            {
                result += handler(item);
            }
            return result;
        }
    }
}
