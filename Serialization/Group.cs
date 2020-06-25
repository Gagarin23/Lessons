using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [DataContract]
    public class Group
    {
        private readonly Random rnd = new Random(Guid.NewGuid().ToByteArray().Sum(x => x + x));
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public string Name { get; set; }

        public Group()
        {
            Number = rnd.Next(1, 10);
            Name = "Группа" + Number;
        }
        public Group(int number, string name)
        {
            Number = number;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
