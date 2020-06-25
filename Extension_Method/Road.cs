using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Method
{
    public sealed class Road //sealed - запечатанный класс
    {
        public string Number { get; set; }
        public int Lenght { get; set; }

        public override string ToString()
        {
            return $"Дорога {Number} общей протяженностью {Lenght}";
        }
    }
}
