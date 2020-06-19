using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLesson
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; } //int? - целочисленное значение способное принять null
        public string Type { get; set; }
        public virtual ICollection<Song> Songs { get; set; } //хранение таблицы Song в таблице Group
    }
}
