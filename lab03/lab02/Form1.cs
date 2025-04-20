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
using static lab02.Form2;
using static System.Windows.Forms.MonthCalendar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace lab02
{
    
    public partial class Form1 : Form

    {
        private Main mainForm;
        public House Houses;
        public List<House> HousesList;
        public Address address;
        public double resultPriceForm2;
        public Form1(Main main)
        {
            InitializeComponent();
            this.mainForm = main;
            Houses = new House();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double area = double.Parse(textBox1.Text);
                int rooms = trackBar1.Value;
                int year = (int)numericUpDown1.Value;
                string material = comboBox1.SelectedItem?.ToString();
                int floor = (int)numericUpDown2.Value;

                double basePrice = 1500; // цена за 1 м2 самой квартиры в баксах
                double addedPrice = basePrice;

                //if (area < 0)
                //{
                //    MessageBox.Show("Введите действительные данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //if (floor < 0 || floor > 30)
                //{
                //    MessageBox.Show("Введите действительные данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                Houses.area = area;
                Houses.rooms = rooms;
                Houses.year = year;
                Houses.material = material;
                Houses.floor = floor;
                Houses.area = area;
                var validationResults = DomikiValidation.GetValidationResults(Houses);
                
                if (validationResults.Count > 0)
                {
                    MessageBox.Show("чтото пошло не так");
                    return;
                }
                addedPrice = addedPrice * area;

                //Дерево Кирпич Блоки земли Алмазы Изумруд
                switch (material) //наценка за материал дома хз я не строител
                {
                    case "Дерево":
                        addedPrice *= 1.2;
                        break;
                    case "Кирпич":
                        addedPrice *= 1.3;
                        break;
                    case "Блоки земли":
                        addedPrice *= 1.0;
                        break;
                    case "Алмазы":
                        addedPrice *= 2.5;
                        break;
                    case "Изумруд":
                        addedPrice *= 2.0;
                        break;
                }

                switch (rooms) //наценка за колво коммнат хз я не лагист
                {
                    case 1:
                        addedPrice += basePrice * 1.1;
                        break;
                    case 2:
                        addedPrice += basePrice * 1.2;
                        break;
                    case 3:
                        addedPrice += basePrice * 1.3;
                        break;
                    case 4:
                        addedPrice += basePrice * 1.4;
                        break;
                    case 5:
                        addedPrice += basePrice * 1.5;
                        break;
                }

                if (checkBox1.Checked) addedPrice += 5000;
                if (checkBox2.Checked) addedPrice += 10000;
                if (checkBox3.Checked) addedPrice += 7000;
                if (checkBox4.Checked) addedPrice += 7000;
                if (checkBox5.Checked) addedPrice += 5000;
                if (checkBox6.Checked) addedPrice += 8000;

                
                if (year >= 1950 || year < 2000)
                {
                    addedPrice += basePrice * 1.0;
                }
                if (year > 2000 || year < 2010)
                {
                    addedPrice += basePrice * 1.1;
                }
                if (year > 2010 || year <= 2025)
                {
                    addedPrice += basePrice * 1.2;
                }

                addedPrice += resultPriceForm2;

                label9.Text = $"Итого: {addedPrice:F2}р.";


                //        public double area;
                //public int rooms;
                //public int year;
                //public string material;
                //public int floor;
                //public double Price;

               
                Houses.Price = addedPrice;
               
                UpdateRichTextBox();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                int rooms = trackBar1.Value;

                switch (rooms) //наценка за колво коммнат хз я не лагист
                {
                    case 1:
                        label3.Text = $"Количество комнат: 1";
                        break;
                    case 2:
                        label3.Text = $"Количество комнат: 2";
                        break;
                    case 3:
                        label3.Text = $"Количество комнат: 3";
                        break;
                    case 4:
                        label3.Text = $"Количество комнат: 4";
                        break;
                    case 5:
                        label3.Text = $"Количество комнат: 5";
                        break;
                }
            }
            catch { }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.ShowDialog();
            resultPriceForm2 = form.resultPriceForm2;
            //Houses.addressess = form.address;
            address = lab02.Form2.GetAddress();
            Houses.addressess = address;
            richTextBox1.Text = Houses.HouseData();
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            //if (numericUpDown1.Value < 1950)
            //{
            //    MessageBox.Show("Наша компания не может предложить дома, построенные раньше 1950 года", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (numericUpDown1.Value > 2025)
            //{
            //    MessageBox.Show("Введите корректный год", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
        }
        private void UpdateRichTextBox()
        {
            
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            if (Houses.addressess == null)
            {
                MessageBox.Show("Сначала добавьте адрес!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var validationResults = DomikiValidation.GetValidationResults(Houses.addressess);

            if (validationResults.Count > 0)
            {
                MessageBox.Show(validationResults[0].ErrorMessage);
                return;
            }

            if (HousesList == null)
            {
                HousesList = new List<House>();
            }

            //var context = new ValidationContext(Houses.Price)
            //{
            //    MemberName = nameof(Houses.Price)
            //};
            //var results = new List<ValidationResult>();

            //bool isValid = Validator.TryValidateProperty(Houses.Price, context, results);

            //if (!isValid)
            //{
            //    MessageBox.Show(results[0].ErrorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            HousesList.Add(new House { addressess = Houses.addressess });

            MessageBox.Show("Дом добавлен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            mainForm.Show();     
            mainForm.Activate(); 
            this.Hide();
        }
    }
}
