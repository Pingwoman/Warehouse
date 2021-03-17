using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kl5
{
    class MyException : Exception
    {
        public MyException() : base("На открытый склад нельзя помещать сыпучие продукты.")
        { 
            
        }

    }
}
