using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var products = new List<Product>();
            for(var i = 0; i < 10; i++)
            {
                var product = new Product()
                {
                    Name = "Продукт" + i,
                    Energy = rnd.Next(10, 12)
                };
                products.Add(product);
            }

            var result = from item in products //перебор элементов на подобии foreach
                         where item.Energy < 200 //условие перебора
                         orderby item.Energy //упорядочить 
                         select item; //выбор элемента

            var result2 = products.Where(item => item.Energy < 200)
                .Where(item => item.Energy < 200 || item.Energy > 400); //допустимая форма записи

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
            

            var selectCollection = products.Select(product => product.Energy); //вытащили элемент и положили в результирующую коллекцию
            foreach (var item in selectCollection)
            {
                Console.WriteLine(item);
            }

            var orderbyCollection = products.OrderBy(product => product.Energy)
                .ThenByDescending(product => product.Name); //упорядочить по нескольким условиям
            foreach (var item in orderbyCollection)
            {
                Console.WriteLine(item);
            }

            var groupbyCollection = products.GroupBy(product => product.Energy); //группировка, в которой переменная представляет собой группы в виде словаря
            foreach(var group in groupbyCollection)
            {
                Console.WriteLine($"Ключ: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"\t{item}");
                }
                Console.WriteLine();
            }

            products.Reverse(); //переворачивает список
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(products.All(item => item.Energy == 10)); //возвращает булево значение если все элементы удовлетворяют условие
            Console.WriteLine(products.Any(item => item.Energy == 10)); //возвращает булево значение если хотябы один элемент удовлетворяет условие
            Console.WriteLine(products.Contains(products[5])); //возвращает булево значение если заданный элемент принадлежит коллекции

            var array = new int[] { 1, 2, 3, 4 };
            var array2 = new int[] { 3, 4, 5, 6 };
            var uinion = array.Union(array2); //объединение массивов сразу с удалением дубликатов
            foreach (var item in uinion)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var intersect = array.Intersect(array2); //возвращает повторяющиеся значения
            foreach (var item in intersect)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var except = array.Except(array2); //возврат разность множеств
            foreach (var item in except)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var sum = array.Sum();//сумма всех значений коллекции
            Console.WriteLine(sum);
            var min = products.Min(p => p.Energy);
            var max = products.Max(p => p.Energy);
            var aggregate = array.Aggregate((x, y) => x * y); //умножение первого элемента на следующий
            Console.WriteLine(aggregate);
            Console.WriteLine();

            var sum2 = array.Skip(1).Take(2).Sum(); //Skip пропускает заданное количество элементов 
            Console.WriteLine(sum2);
            var sum3 = array.Take(2).Sum(); //Take задает количество элементов, которое необьходимо взять
            Console.WriteLine(sum3);

            var first = array.FirstOrDefault(); //первый элемент коллекции, если коллеция пуста, то 0 или null
            var last = array.LastOrDefault(); //последний элемент коллекции, если коллеция пуста, то 0 или null
            var first2 = array.First(); //вернет первый элемент, но при пустой коллекции выдаст исключение

            /*var single = products.Single(x => x.Energy == 10)*/; //возвращает элемент соответствующий заданным условиям, если значение не уникально - получим исключение
            var first3 = products.First(x => x.Energy == 10); //возвратит первый элемент соответствующий заданному условию

            var elementAt = products.ElementAt(0); //получить элемент по индексу
            Console.WriteLine(elementAt);

            Console.ReadLine();
        }
    }
}
