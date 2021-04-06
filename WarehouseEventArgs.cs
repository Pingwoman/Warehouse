using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kl5
{
    public class WarehouseEventArgs
    {

        public string Message { get; }

        public Goods G { get; }

        public WarehouseEventArgs(string mess, Goods g)
        {
            Message = mess;
            G = g;
        }


    }
}
