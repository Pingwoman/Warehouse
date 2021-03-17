using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kl5
{
    class Program
    {
 
        static void Main(string[] args)
        {

            Employee emp;
            emp.name = "Harry";
            emp.patronymic = "Jsmes";
            emp.surname = "Potter";
            emp.position = "Head";


            Address address;
            address.country = "KZ";
            address.city = "Almaty";
            address.street = "Diagon Alley";
            address.houseNumber = 20;

            typesGoods tg = typesGoods.bulk;
            typesGoods tg1 = typesGoods.dimensional;
            typesGoods tg2 = typesGoods.liquid;
            typesGoods tg3 = typesGoods.piece;

            Goods goods = new Goods(1, "product #1", (int)tg, 51.289); 
            Goods goods1 = new Goods(2, "product #2", (int)tg1, 15.250);
            Goods goods2 = new Goods(3, "product #3", (int)tg2, 85.250); 
            Goods goods3 = new Goods(4, "product #4", (int)tg3, 97.250);

            
            goods.Ttype = Enum.GetName(typeof(typesGoods), goods.Type);
            goods1.Ttype = Enum.GetName(typeof(typesGoods), goods1.Type); 
            goods2.Ttype = Enum.GetName(typeof(typesGoods), goods2.Type);
            goods3.Ttype = Enum.GetName(typeof(typesGoods), goods3.Type);

            
            OpenWarehouse openWarehouse = new OpenWarehouse();
            openWarehouse.Emp = emp;
            openWarehouse.Address = address;

            try
            {   
                openWarehouse.addGoods(goods3, goods3.SKU, 39);
                openWarehouse.addGoods(goods2, goods2.SKU, 30);
                openWarehouse.addGoods(goods1, goods1.SKU, 18);
                openWarehouse.addGoods(goods, goods.SKU, 15);
                Console.WriteLine("Товар успешно добавлен на склад");
            }
            catch(MyException mex)
            {
                Console.WriteLine(mex.Message);
            }
            finally
            {
                Console.WriteLine("Конец загрузки товара");
            }


            try
            {
                openWarehouse.addPrice(goods1, goods1.SKU, goods1.Price); 
                openWarehouse.addPrice(goods2, goods2.SKU, goods2.Price);
                openWarehouse.addPrice(goods3, goods3.SKU, goods3.Price);
                openWarehouse.addPrice(goods, goods.SKU, goods.Price);
                
            }
            catch(MyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Конец добавления цен на товар.");
            }

            double db = openWarehouse.calculationGoods(openWarehouse.priceDict);

            Console.ReadKey();
        }
    }
}
