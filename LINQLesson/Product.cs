using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLesson
{
    class Product
    {
        public string Name { get; set; }
        public int Energy { get; set; }
        public override string ToString()
        {
            return $"{Name} ({Energy})";
        }
    }
}
