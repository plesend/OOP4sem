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
            address = new Address();
            address.Country = comboBox1.SelectedItem?.ToString();
            address.City = comboBox2.SelectedItem?.ToString();
            address.Location = comboBox4.SelectedItem?.ToString();
            address.District = textBox1.Text;
            address.Street = textBox2.Text;
            var validationResults = DomikiValidation.GetValidationResults(address);
            if (validationResults.Count > 0)
            {
                MessageBox.Show(validationResults[0].ErrorMessage);
                return;
            }

            if (int.TryParse(textBox4.Text, out int value0))
            {
                address.AddressNum = value0;
            }
            else
            {
                MessageBox.Show("ведити правельные даныи (леха сказал, что так правильно, я верю тебе, говорящая картинка)", "Ашыбка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(textBox5.Text, out int value1))
            {
                address.Housing = value1;
            }
            else
            {
                MessageBox.Show("ведити правельные даныи (леха сказал, что так правильно, я верю тебе, говорящая картинка)", "Ашыбка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(textBox6.Text, out int value2))
            {
                address.Apartment = value2;
            }
            else
            {
                MessageBox.Show("ведити правельные даныи (леха сказал, что так правильно, я верю тебе, говорящая картинка)", "Ашыбка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //address.AddressNum = int.TryParse(textBox4?.Text);
            //address.Housing = int.Parse(textBox5?.Text);//корпус
            //address.Apartment = int.Parse(textBox6?.Text);

            //if (addressNum < 0)
            //{
            //    MessageBox.Show("Введите действительные данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (housing < 0)
            //{
            //    MessageBox.Show("Введите действительные данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (apartment < 0)
            //{
            //    MessageBox.Show("Введите действительные данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            double basePriceForm2 = 1500;
            double addedPriceForm2 = basePriceForm2;
            //Казахстан Беларусь Узбекистан Таджикистан

            switch (address.Country)
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
            switch (address.Location)
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
            

            Close();
        }
        public static Address GetAddress()
        { 
            return address;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
