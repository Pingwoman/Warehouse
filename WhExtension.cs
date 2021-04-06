using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kl5
{
    public static class WhExtension
    {

        public static string SKU_Name (this Goods g)
        {
            return $"{g.SKU} - {g.Name}";
        }

        public static string goodsOfBothWarehouses(this CoveredWarehouse covered, OpenWarehouse open)
        {
            string list = "";
            foreach (int s in covered.goodsList.Keys)
            {
                if (open.goodsList.ContainsKey(s))
                {
                    list += $"{open.goodsList[s].Name}, ";
                }
            }

            return list;
        }


        


    }
}
