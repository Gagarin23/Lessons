using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollectionLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            GC.Collect(); //сборка мусора по всем поколениям, либо с указанием поколения в ()
            Console.ReadLine();

            using (var c = new MyClass())
            {

            }
        }
    }
}
