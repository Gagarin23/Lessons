using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribureReflection
{
    [AttributeUsage(AttributeTargets.Property)] //привязываем аттрибут к типу
    class GeoAttribute : System.Attribute
    {
        public int  X { get; set; }
        public int Y { get; set; }

        public GeoAttribute() { }
        public GeoAttribute(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"[{X},{Y}]";
        }
    }
}
