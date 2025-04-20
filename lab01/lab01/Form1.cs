using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string productType = comboBox1.SelectedItem?.ToString();
                double price = Convert.ToDouble(textBox1.Text);
                double amount = Convert.ToDouble(textBox2.Text);
                int amountPerDay = Convert.ToInt32(textBox3.Text);

                if (price <= 0)
                {
                    MessageBox.Show("Мы не выдаем товары бесплатно", "Аферист!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (amount <= 0)
                {
                    MessageBox.Show("Объем не может быть меньше 0 (включительно)", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (amountPerDay < 0)
                {
                    MessageBox.Show("Потребление не может быть меньше 0", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double pricePerAmount = amount / price;

                label2.Text = $"Цена за 1 кг (литр): {pricePerAmount:F2} руб.";

                double priceTaxes = pricePerAmount - pricePerAmount * 0.3;

                label3.Text = $"Цена за 1 кг (литр) с вычетом наценки: {priceTaxes:F2} руб.";

                double pricePerMonth = pricePerAmount * amountPerDay;

                label4.Text = $"Цена за потребление в мес: {pricePerMonth:F2} руб.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }
    }
}
