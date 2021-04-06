using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kl5
{
    public class Goods : IGoods
    {
        private string name;
        private int sku;
        private string desc;
        private double price;
        private string unit;
        private int type;
        private string ttype;
        
        public Goods(int ssku, string sname, int stype, double sprice )
        {
            this.SKU = ssku;
            this.Name = sname;
            this.Type = stype;
            this.Price = sprice;
        }

        public Goods(int ssku)
        {
            this.SKU = ssku;
            
        }

        public Goods()
        {


        }

        public string Name { get {return name; } set { name = value; } }
        public int SKU { get {return sku; } set {sku = value; } }
        public string Description { get { return desc; } set { desc = value; } }
        public double Price { get { return price; } set { price = value; } }
        public string Unit { get { return unit; } set { unit = value; } }
        public int Type { get { return type; } set { type = value; } }
        public string Ttype { get { return ttype; } set { ttype = value; } }

    }
}
