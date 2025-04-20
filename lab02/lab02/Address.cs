using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public int AddressNum { get; set; }
        public int Housing { get; set; }
        public int Apartment { get; set; }
        public Address(string country, string city, string location, string district,
                   string street, int addressNum, int housing, int apartment)
        {
            Country = country;
            City = city;
            Location = location;
            District = district;
            Street = street;
            AddressNum = addressNum;
            Housing = housing;
            Apartment = apartment;
        }
        public Address()
        {
            Country = "";
            City = "";
            Location = "";
            District = "";
            Street = "";
            AddressNum = 0;
            Housing = 0;
            Apartment = 0;
        }
    }
}
