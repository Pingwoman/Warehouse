using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kl5
{

    struct Address
    {
        public string country;
        public string city;
        public string street;
        public int houseNumber;

        public Address(string country, string city, string street, int housnumber)
        {
            this.country = country;
            this.city = city;
            this.street = street;
            this.houseNumber = housnumber;
        }
    }


    struct Employee 
    { 
        public string surname; 
        public string name; 
        public string patronymic;
        public string position;
        public Employee(string surname, string name, string patronymic, string position = "Head of warehouse")
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.position = position;
        }
    }

    interface IWarehouse
    {
        float Area { get; set; }
        Address Address { get; set; }
        Employee Emp { get; set; }
        //void addGoods(int t, int amount);
        void transfetGoods();
        //void searchGoods(string g, int sk);
        double calculationGoods(Dictionary<int, double> dict);
        void setEmployee(Employee employee);

    }
}
