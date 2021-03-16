using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kl5
{
    class OpenWarehouse : IWarehouse
    {
        private float area;
        private Address address;
        private Employee employee;

        public float Area { get { return area; } set { area = value; } }
        public Address Address { get { return address; } set { address = value; } }
        public Employee Emp { get { return employee; } set { employee = value; } }

        public Dictionary<int, int> goodsDict;
        public Dictionary<int, double> priceDict;

        public OpenWarehouse()
        {
            this.goodsDict = new Dictionary<int, int>();
            this.priceDict = new Dictionary<int, double>();
        }

        public void addPrice(Goods g, int t, double price)
        {
            //priceDict.Add(t, price);
            typesGoods tg = typesGoods.bulk;
            int s = (int)tg;
            if (g.Type == s)
            {
                s=0;
            }
            else
            {
                priceDict.Add(t, price);
            }
        }

        public void addGoods(Goods g, int t, int amount)
        {
            typesGoods goodsType = typesGoods.bulk;
            int s = (int)goodsType;
            if (g.Type == s)
            {
                s = 0; 
            }
            else
            {
                goodsDict.Add(t, amount);
            }
        }

        public double calculationGoods(Dictionary<int, double> dict)
        {
            double c = 0;
            foreach (double gc in dict.Values) 
            {
                 c = c + gc;
            }
            return c;
        } 

        /**public void searchGoods(string g, int sk)
        {
            string n;
            if (g.Type == sk)
            {
                return g.Name;
            }
            else {
                return n = "Not found";
            }
        }**/

        public void setEmployee(Employee emp)
        {
            employee = emp;
        }

        public void transfetGoods()
        {
            ;
        }
    }
}
