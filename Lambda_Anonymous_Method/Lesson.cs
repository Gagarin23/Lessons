using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Anonymous_Method
{
    class Lesson
    {
        public string Name { get; }
        public DateTime Begin { get; private set; }
        public event EventHandler<DateTime> Started;

        public Lesson(string name)
        {
            Name = name;
        }

        public void Start()
        {
            Begin = DateTime.Now;
            Started?.Invoke(this, Begin);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
