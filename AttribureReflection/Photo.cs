using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribureReflection
{
    
    public class Photo
    {
        
        public string Path { get; set; }
        [Geo(10, 20)]
        public string Name { get; set; }
        public Photo(string name)
        {
            Name = name;
        }
    }
}
