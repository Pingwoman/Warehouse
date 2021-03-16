using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kl5
{
    class CoveredWarehouse : IWarehouse
    {
        private float area;
        private Address address;
        private Employee employee;

        public float Area { get { return area; } set { area = value; } }
        public Address Address { get { return address; } set { address = value; } }
        public Employee Emp { get { return employee; } set { employee = value; } }
        public Dictionary<int, int> goodsDict;
        public Dictionary<int, double> priceDict;
        public Dictionary<int, Goods> goodsList;


        public CoveredWarehouse(/*Goods g, int t*/) 
        {
            this.goodsDict = new Dictionary<int, int>();
            this.priceDict = new Dictionary<int, double>();
            this.goodsList = new Dictionary<int, Goods>();
        } 

        

        public void addGoods(int t, int amount)
        {
            goodsDict.Add(t, amount);
            
        }

        public void addPrice(int t, double price) 
        { 
            priceDict.Add(t, price);
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

        public void addToList( int sku, Goods g)
        {
            goodsList.Add(sku, g);
        }

        public void searchGoods(int sk)
        {
            ;
            
        }

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
