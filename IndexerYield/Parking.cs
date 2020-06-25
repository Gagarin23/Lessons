using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerYield
{
    class Parking : IEnumerable<Car>
    {

        private List<Car> _cars = new List<Car>();
        private const int MaxCars = 100;

        public Car this[string number]
        {
            get
            {
                var car = _cars.FirstOrDefault(c => c.Number == number);
                return car;
            }
        }

        public Car this[int position]
        {
            get
            {
                if(position < _cars.Count)
                {
                    return _cars[position];
                }
                return null;
            }
            set
            {
                if (position < _cars.Count)
                {
                    _cars[position] = value;
                }
            }
        }

        public string Name { get; set; }
        public int Count => _cars.Count; //быстрый доступ к приватному свойству и только на чтение
        public int Add(Car car)
        {
            if(car == null)
            {
                throw new ArgumentNullException(nameof(car), "null!");
            }

            if(_cars.Count < MaxCars)
            {
                _cars.Add(car);
                return _cars.Count - 1;
            }
            return -1;
        }

        public void GoOut(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException(nameof(number), "Number is null or empty");
            }

            var car = _cars.FirstOrDefault(c => c.Number == number);
            if(car != null)
            {
                _cars.Remove(car);
            }
        }
        public IEnumerable GetNames() //реализация перебора по свойству объекта
        {
            foreach (var car in _cars)
            {
                yield return car.Name;
            }
        }
        public IEnumerable GetNumbers() //реализация перебора по свойству объекта
        {
            foreach(var car in _cars)
            {
                yield return car.Number;
            }
        }

        public IEnumerator<Car> GetEnumerator()
        {
            return _cars.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cars.GetEnumerator();
        }
    }

    public class ParkingEnumerator : IEnumerator
    {
        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
