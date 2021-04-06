using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kl5
{
    public class Reports
    {
        public void lessThan3(WH h)
        {
            string list = "";
            foreach (int s in h.goodsDict.Keys)
            {
                if(h.goodsDict[s] < 3)
                {
                    list += $"{h.goodsList[s].Name}, ";
                }
            }

            Console.Write(list);
        }

        public int averageAmount (WH wH)
        {
            int overall=0;
            foreach (int s in wH.goodsDict.Values)
            {
                overall += s;
            }
            return overall;
        }

    }
}
