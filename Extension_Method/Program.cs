using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            var input = Console.ReadLine();

            if(int.TryParse(input, out int result))
            {
                //var isEven = IsEven(result);
                if (result.IsEven())
                {
                    Console.WriteLine($"{result} - четное");
                }
                else
                {
                    Console.WriteLine($"{result} - нечетное");
                }

                int h = 182;
                h.IsDivideBy(7);
                144.IsDivideBy(4);

                var list = new List<Road>();
            }
            else
            {
                Console.WriteLine("Ошибка");
            }

            var roads = new List<Road>();
            for(int i = 0; i < 10; i++)
            {
                var road = new Road();
                road.CreateRandemRoad(1000, 10000);
                roads.Add(road);
            }

            var roadsName = roads.ConverterToString();
            Console.WriteLine(roadsName);

            Console.ReadLine();
        }
    }
}
