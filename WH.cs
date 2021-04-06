using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kl5
{
    public class WH
    {
        private float area;
        private Address address;
        private Employee employee;

        public float Area { get { return area; } set { area = value; } }
        public Address Address { get { return address; } set { address = value; } }
        public Employee Emp { get { return employee; } set { employee = value; } }
        public Dictionary<int, int> goodsDict; //sku amount
        public Dictionary<int, double> priceDict; // sku price
        public Dictionary<int, Goods> goodsList;
    }
}
