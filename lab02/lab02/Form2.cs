using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lab02
{
    public partial class Form2 : Form
    {
        public static Address address;
       
        public double resultPriceForm2;
        public Form2()
        {
            InitializeComponent();
           

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        comboBox2.Items.Add("Астана");
                        comboBox2.Items.Add("Актобе");
                        comboBox2.Items.Add("Павлодар");
                        break;
                    }
                case 1:
                    {
                        comboBox2.Items.Add("Минск");
                        comboBox2.Items.Add("Лида");
                        comboBox2.Items.Add("Гродно");
                        break;
                    }
                case 2:
                    {
                        comboBox2.Items.Add("Ташкент");
                        comboBox2.Items.Add("Самарканд");
                        comboBox2.Items.Add("Нукус");
                        break;
                    }
                case 3:
                    {
                        comboBox2.Items.Add("Душанбе");
                        comboBox2.Items.Add("Худжанд");
                        comboBox2.Items.Add("Куляб");
                        break;
                    }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string country = comboBox1.SelectedItem?.ToString();
            string city = comboBox2.SelectedItem?.ToString();
            string location = comboBox4.SelectedItem?.ToString();
            string district = textBox1.Text;
            string street = textBox2.Text;
            int addressNum = int.Parse(textBox4.Text);
            int housing = int.Parse(textBox5.Text);//корпус
            int apartment = int.Parse(textBox6.Text);

            if (addressNum < 0)
            {
                MessageBox.Show("Введите действительные данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (housing < 0)
            {
                MessageBox.Show("Введите действительные данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (apartment < 0)
            {
                MessageBox.Show("Введите действительные данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double basePriceForm2 = 1500;
            double addedPriceForm2 = basePriceForm2;
            //Казахстан Беларусь Узбекистан Таджикистан

            switch (country)
            {
                case "Казахстан":
                    addedPriceForm2 += basePriceForm2 * 1.2;
                    break;
                case "Беларусь":
                    addedPriceForm2 += basePriceForm2 * 1.4;
                    break;
                case "Узбекистан":
                    addedPriceForm2 += basePriceForm2 * 1.1;
                    break;
                case "Таджикистан":
                    addedPriceForm2 += basePriceForm2 * 1.1;
                    break;
            }

            //Центр города Рядом с метро В населенном п., нет метро За мкадом
            switch (location)
            {
                case "Центр города":
                    addedPriceForm2 += basePriceForm2 * 2.0;
                    break;
                case "Рядом с метро":
                    addedPriceForm2 += basePriceForm2 * 1.5;
                    break;
                case "В населенном п., нет метро":
                    addedPriceForm2 += basePriceForm2 * 1.3;
                    break;
                case "За мкадом":
                    addedPriceForm2 += basePriceForm2 * 1.1;
                    break;
            }

            resultPriceForm2 = addedPriceForm2;
            
            address = new Address(country, city, location, district, street, addressNum, housing, apartment);

            Close();
        }
        public static Address GetAddress()
        { 
            return address;
        }

    }

}
