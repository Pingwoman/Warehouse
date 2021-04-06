using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kl5
{
    class Program
    {
        public static void onAddedGoods(object sender, WarehouseEventArgs e)
        {
            Console.WriteLine($"Операция {e.Message} товара {e.G.Name} с кодом {e.G.SKU}");
        }
        public static void onIncorrect(Goods g)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Некорректное добавление товара {g.Name} с кодом {g.SKU}");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Employee emp, emp2;
            emp.name = "Harry";
            emp.patronymic = "James";
            emp.surname = "Potter";
            emp.position = "Head";
            
            emp2.name = "Ron";
            emp2.patronymic = "Billius";
            emp2.surname = "Weasley";
            emp2.position = "Head";

            Address address, address2;
            address.country = "KZ";
            address.city = "Almaty";
            address.street = "Diagon Alley";
            address.houseNumber = 20;

            address2.country = "KZ";
            address2.city = "Almaty";
            address2.street = "Diagon Alley";
            address2.houseNumber = 21;

            typesGoods tg = typesGoods.bulk;
            typesGoods tg1 = typesGoods.dimensional;
            typesGoods tg2 = typesGoods.liquid;
            typesGoods tg3 = typesGoods.piece;

            Goods goods = new Goods(1, "гречка", (int)tg, 51.289); 
            Goods goods1 = new Goods(2, "холодильник", (int)tg1, 15.250);
            Goods goods2 = new Goods(3, "сок", (int)tg2, 85.250); 
            Goods goods3 = new Goods(4, "шоколад", (int)tg3, 97.250);

            
            goods.Ttype = Enum.GetName(typeof(typesGoods), goods.Type);
            goods1.Ttype = Enum.GetName(typeof(typesGoods), goods1.Type); 
            goods2.Ttype = Enum.GetName(typeof(typesGoods), goods2.Type);
            goods3.Ttype = Enum.GetName(typeof(typesGoods), goods3.Type);
            
            OpenWarehouse openWarehouse = new OpenWarehouse();
            openWarehouse.setEmployee(emp);
            openWarehouse.Address = address;

            CoveredWarehouse covered = new CoveredWarehouse(); 
            covered.setEmployee(emp2);
            covered.Address = address2;

            covered.onAdded += onAddedGoods;
            openWarehouse.onAdded += onAddedGoods;

            openWarehouse.incorrectAdded += onIncorrect;
           
            try
            {   
                covered.addGoods(18, goods1);
                covered.addGoods(30, goods2);

                //openWarehouse.addGoods(goods3, 18);
                //openWarehouse.addGoods(goods,  15);
                
            }
            catch(MyException mex)
            {
                Console.WriteLine(mex.Message);
            }
            
            Console.WriteLine(covered.searchGoods(2));


            
           
            Console.ReadKey();
        }

    }
}
