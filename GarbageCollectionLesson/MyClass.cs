using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollectionLesson
{
    class MyClass : IDisposable //интерфейс для работы с using
    {
        public MyClass() { } //конструктор

        ~MyClass() { } //деструктор

        public void Dispose()
        {
            GC.Collect(); //вызов сборщика
        }


    }
}
