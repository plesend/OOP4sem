using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
namespace lab02
{
    public class House
    {
        [Required(ErrorMessage = "Вы не ввели адрес дома")]
        public Address addressess { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Вы не ввели метраж квартиры")]
        public double area { get; set; }
        [Required(ErrorMessage = "Вы не ввели количество комнат")]
        public int rooms { get; set; }
        [Range(1950, 2025, ErrorMessage = "Вы ввели невалидный год постройки")]
        public int year { get; set; }
        [Required(ErrorMessage = "Вы не ввели материал дома")]
        public string material { get; set; }
        [Required(ErrorMessage = "Вы не ввели этаж дома")]

        public int floor { get; set; }
        public double Price { get; set; }

        public House()
        {
            addressess = new Address();
        }
        public string HouseData()
        {
            string addressData = $"{addressess.Country}, {addressess.City}, {addressess.Location}, {addressess.District}, {addressess.Street}, {addressess.AddressNum} \nКорпус: {addressess.Housing}, Квартира: {addressess.Apartment}\nСтоимость: {Price}\n";
            string innerData = $"Метраж: {area},\nКол-во комнат: {rooms},\nГод потройки: {year},\nМатериал: {material},\n Этаж: {floor}";
            string fullData = addressData + innerData;
            return fullData;
        }
    }
}
