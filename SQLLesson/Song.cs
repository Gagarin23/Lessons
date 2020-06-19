using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLesson
{
    public class Song
    {
        //для основного ключа нужно присвоить [Key], если в имени свойства нет "Id"
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
