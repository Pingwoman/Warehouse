using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kl5
{
    public class OpenWarehouse : WH, IWarehouse
    {
        //public delegate void WarehouseAdded(string message, Goods g); 
        public delegate void WarehouseAdded(object sender, WarehouseEventArgs e);
        public delegate void incorrectProduct(Goods g);

        public event WarehouseAdded onAdded;
        public event incorrectProduct incorrectAdded; 

        private float area;
        private Address address;
        private Employee employee;

        /*public float Area { get { return area; } set { area = value; } }
        public Address Address { get { return address; } set { address = value; } }
        public Employee Emp { get { return employee; } set { employee = value; } }

        public Dictionary<int, int> goodsDict;
        public Dictionary<int, double> priceDict;
        public Dictionary<int, Goods> goodsList; //sku good_name
        */

        public OpenWarehouse()
        {
            this.goodsDict = new Dictionary<int, int>();
            this.priceDict = new Dictionary<int, double>();
            this.goodsList = new Dictionary<int, Goods>();
        }

        public void addPrice(Goods g, int t, double price)
        {
            
            typesGoods tg = typesGoods.bulk;
            int s = (int)tg;
            if (g.Type == s) throw new MyException();
            priceDict.Add(t, price);
            
        }

        public void addToList(int sku, Goods g)
        {
            goodsList.Add(sku, g);
        }


        public void addGoods(Goods g, int amount)
        {
            onAdded?.Invoke(this, new WarehouseEventArgs("Добавление товара", g));
            typesGoods goodsType = typesGoods.bulk;
            int s = (int)goodsType;
            if (g.Type == s)
            {
                incorrectAdded?.Invoke(g);
                throw new MyException();

            }         
            goodsDict.Add(g.SKU, amount);
            goodsList.Add(g.SKU, g);
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

        public string searchGoods( int sk)
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

        public void transferGoods()
        {
            ;
        }


        public void saveCSV(string filepath)
        {
            try
            {
                if (!File.Exists(filepath))
                {

                    using (var writer = new StreamWriter(filepath, false))
                    {


                        foreach (int s in goodsList.Keys)
                        {
                            if (goodsList.ContainsKey(s))
                            {
                                writer.WriteLine($"{goodsList[s].SKU.ToString()},{goodsList[s].Name}, {goodsList[s].Price.ToString()}");
                            }
                        }



                    }
                }
                else
                {
                    using (var writer = new StreamWriter(filepath, true))
                    {


                        foreach (int s in goodsList.Keys)
                        {
                            if (goodsList.ContainsKey(s))
                            {
                                writer.WriteLine($"{goodsList[s].SKU.ToString()},{goodsList[s].Name}, {goodsList[s].Price.ToString()}");
                            }
                        }



                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }
    }
}
