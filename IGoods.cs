using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kl5
{

    enum typesGoods : int 
    {
        liquid = 1,
        piece = 2,
        dimensional = 3,
        bulk = 4
    }

    interface IGoods
    {
        string Name { get; set; }
        int SKU { get; set; }
        string Description { get; set; }
        double Price { get; set; }
        string Unit { get; set; }
        int Type { get; set; }
        string Ttype { get; set; }
    }
}
