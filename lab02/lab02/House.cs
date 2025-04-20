using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public class House
    {
        public Address addressess;
        public double Price;

        public House()
        {
            addressess = new Address();
        }
        public string HouseData()
        {
            string data = $"{addressess.Country}, {addressess.City}, {addressess.Location}, {addressess.District}, {addressess.Street}, {addressess.AddressNum} \nКорпус: {addressess.Housing}, Квартира: {addressess.Apartment}\n Стоимость: {Price}";
            return data;
        }
    }
}
