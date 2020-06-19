using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intarface
{
    public class Cyborg : ICar, IPerson
    {
        public void Create()
        {
            throw new NotImplementedException();
        }

        int ICar.Move(int distance)
        {
            return distance / 40;
        }

        int IPerson.Move(int distance)
        {
            return distance / 5;
        }
    }
}
