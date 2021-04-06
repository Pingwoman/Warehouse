using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kl5
{
    public class CoveredWarehouse : WH, IWarehouse
    {


        //public delegate void WarehouseAdded(string message, Goods g);
        public delegate void WarehouseAdded(object sender, WarehouseEventArgs e);
        public event WarehouseAdded onAdded;


        private float area;
        private Address address;
        private Employee employee;
        /**
        public float Area { get { return area; } set { area = value; } }
        public Address Address { get { return address; } set { address = value; } }
        public Employee Emp { get { return employee; } set { employee = value; } }
        public Dictionary<int, int> goodsDict; //sku amount
        public Dictionary<int, double> priceDict; // sku price
        public Dictionary<int, Goods> goodsList; //sku good_name
        */

        public CoveredWarehouse() 
        {
            this.goodsDict = new Dictionary<int, int>();
            this.priceDict = new Dictionary<int, double>();
            this.goodsList = new Dictionary<int, Goods>();
        } 

        

        public void addGoods(int amount, Goods goods)
        {
            onAdded?.Invoke(this, new WarehouseEventArgs("Добавление товара", goods));
            //onAdded?.Invoke("Добавление товара", goods);
            goodsDict.Add(goods.SKU, amount);
            goodsList.Add(goods.SKU, goods);
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

        public string searchGoods(int sk)
        {
            string n;

            if (goodsList.ContainsKey(sk))
            {
                n = goodsList[sk].Name; 
                return n;
            }
            else
            {
                return "Error";
            }
           
                      
        }

        public void setEmployee(Employee emp)
        {
            employee = emp;
        }

        public void transferGoods(Goods g, int n, CoveredWarehouse c=null, OpenWarehouse o=null)
        {
            n = goodsDict[g.SKU];
            if (c != null)
            {
                c.addToList(g.SKU, g);
                c.addGoods(n, g);
                //goodsList.Remove(g.SKU);
                //cc.goodsList.Add(g.SKU, g);
            }

            if(o != null)
            {
                o.addGoods(g, n);
                o.addToList(g.SKU, g);
            }
            
        }
    }
}
