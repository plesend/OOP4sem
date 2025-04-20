using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public class Address
    {
        [Required(ErrorMessage = "нужна страна")]
        public string Country { get; set; }
        [Required(ErrorMessage = "нужен город")]

        public string City { get; set; }
        [Required(ErrorMessage = "нужна локація")]

        public string Location { get; set; }
        [Required(ErrorMessage = "нужен район")]

        public string District { get; set; }
        [Required(ErrorMessage = "нужна уліца")]

        public string Street { get; set; }
        [Range(0, int.MaxValue,ErrorMessage ="номер дома больше нуля")]
        public int AddressNum { get; set; }
        [Range(0,int.MaxValue,ErrorMessage ="номер корпуса больше нуля")]
        public int Housing { get; set; }
        [NotZero(ErrorMessage = "Квартира не должна быть 0")]

        public int? Apartment { get; set; }
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
        }
    }
}
