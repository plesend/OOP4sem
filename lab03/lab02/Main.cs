using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lab02
{
    public partial class Main : Form
    {

        private Form1 form1;

        public List<House> HousesList = loadFromJSON("D:\\лабораторные работы\\ооп\\lab03\\lab02\\domiki.json");

        public List<House> SearchResult {  get; set; }
        public Main()
        {
            InitializeComponent();
            form1 = new Form1(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var AddingForm = new Form1(this);
            AddingForm.ShowDialog();
            HousesList.Add(AddingForm.Houses);
            AddingForm.Close();
            label3.Text = "Последнее действие: добавить дом";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (HousesList == null || HousesList.Count == 0)
            {
                HousesList = loadFromJSON("D:\\лабораторные работы\\ооп\\lab03\\lab02\\domiki.json");
            }

            if (HousesList.Count == 0)
            {
                MessageBox.Show("Список домов пуст!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SearchResult = HousesList; 
            UpdateResultsGrid();
            label3.Text = "Последнее действие: показать список";
            label2.Text = $"Объектов: {HousesList.Count}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveToJSON("D:\\лабораторные работы\\ооп\\lab03\\lab02\\domiki.json");
            label3.Text = "Последнее действие: сохранено в файл";
        }
        public static List<House> loadFromJSON(string _filepath)
        {
            if (File.Exists(_filepath))
            { 
                string json = File.ReadAllText(_filepath);
                if (string.IsNullOrEmpty(json))
                {
                    return new List<House>();
                }
                return JsonConvert.DeserializeObject<List<House>>(json);
            }
            else
            {
                MessageBox.Show("але");
            }
            return new List<House>();
        }

        private void saveToJSON(string _filepath)
        {
            string json = JsonConvert.SerializeObject(HousesList, Formatting.Indented);
            File.WriteAllText(_filepath, json);
        }
        private void saveToJSONSearch(string _filepath)
        {
            string json = JsonConvert.SerializeObject(SearchResult, Formatting.Indented);
            File.WriteAllText(_filepath, json);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchCriteria = comboBox1.Text;
            string searchType = comboBox2.Text;
            string searchValue = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Введите значение для поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var query = HousesList.AsQueryable();

            switch (searchType)
            {
                case "Полное совпадение":
                    query = ExactMatch(query, searchCriteria, searchValue);
                    break;
                case "Регулярное выражение":
                    query = RegexMatch(query, searchCriteria, searchValue);
                    break;
            }

            SearchResult = query.ToList(); 
            UpdateResultsGrid();

            saveToJSONSearch("D:\\лабораторные работы\\ооп\\методички\\Lab03\\Lab02\\JSONS\\Search.json");
            label3.Text = "Последнее действие: поиск по списку";
            label2.Text = $"Объектов: {SearchResult.Count}";
        }

        private IQueryable<House> ExactMatch(IQueryable<House> query, string criteria, string value)
        {
            switch (criteria)
            {
                case "Адрес":
                    return query.Where(s => s.addressess.Street == value); 
                case "Номер дома":
                    return query.Where(s => s.addressess.AddressNum.ToString() == value);
                case "Цена":
                    return query.Where(s => s.Price.ToString() == value);
                case "Страна":
                    return query.Where(s => s.addressess.Country == value);
                default:
                    return query;
            }
        }

        private IQueryable<House> RegexMatch(IQueryable<House> query, string criteria, string pattern)
        {
            try
            {

                if (!pattern.StartsWith("^"))
                    pattern = "^.*" + pattern;
                if (!pattern.EndsWith("$"))
                    pattern = pattern + ".*$";

                var regex = new Regex(pattern, RegexOptions.IgnoreCase);

                switch (criteria)
                {
                    case "Адрес":
                        return query.Where(s => s.addressess.Street != null && regex.IsMatch(s.addressess.Street ?? ""));
                    case "Номер дома":
                        return query.Where(s => regex.IsMatch(s.addressess.AddressNum.ToString()));
                    case "Страна":
                        return query.Where(s => s.addressess.Country != null && regex.IsMatch(s.addressess.Country ?? ""));
                    case "Город":
                        return query.Where(s => s.addressess.City != null && regex.IsMatch(s.addressess.City ?? ""));
                    case "Цена":
                        return query.Where(s => regex.IsMatch(s.Price.ToString()));
                    default:
                        return query;
                }
            }
            catch
            {
                MessageBox.Show(
                    "Некорректное регулярное выражение.\n\n" +
                    "Примеры правильных выражений:\n" +
                    "^А - начинается с буквы 'А'\n" +
                    "ов$ - заканчивается на 'ов'\n" +
                    "иван - содержит 'иван'\n" +
                    "^Иван.*ов$ - начинается с 'Иван' и заканчивается на 'ов'",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return query;
            }

        }

        private void UpdateResultsGrid()
        {
            try
            {
                dataGridView1.Rows.Clear();

                if (SearchResult != null)
                {
                    foreach (var house in SearchResult)
                    {
                        dataGridView1.Rows.Add(
                            house.addressess.Street ?? "",
                            house.addressess.AddressNum,
                            house.addressess.Country ?? "",
                            house.addressess.City ?? "",
                            house.Price
                        );
                    }
                }

                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении таблицы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 
        private void Main_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sortCriteria = comboBox3.Text;

            switch (sortCriteria)
            { 
                case "Цена (по возр.)":
                    {
                        SearchResult = SearchResult.OrderBy(h => h.Price).ToList();
                        break;
                    }
                case "Цена (по убыв.)":
                    {
                        SearchResult = SearchResult.OrderByDescending(h => h.Price).ToList();
                        break;
                    }
                case "Страна (по возр.)":
                    {
                        SearchResult = SearchResult.OrderBy(h => h.addressess.Country).ToList(); 
                        break; 
                    }
                case "Страна (по убыв.)":
                    {
                        SearchResult = SearchResult.OrderByDescending(h => h.addressess.Country).ToList();
                        break;
                    }
                default: Console.WriteLine("poop fart"); break;
            }
            UpdateResultsGrid();

            label3.Text = "Последнее действие: сорти... аахахха ахахХАХАХА";

        }
        //Цена (по возр.)
        //Цена(по убыв.)
        //Страна(по возр.)
        //Страна(по убыв.)
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string searchCriteria = comboBox1.Text;
            string searchType = comboBox2.Text;
            string searchValue = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Введите значение для поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var query = HousesList.AsQueryable();

            switch (searchType)
            {
                case "Полное совпадение":
                    query = ExactMatch(query, searchCriteria, searchValue);
                    break;
                case "Регулярное выражение":
                    query = RegexMatch(query, searchCriteria, searchValue);
                    break;
            }

            SearchResult = query.ToList();
            UpdateResultsGrid();

            saveToJSONSearch("D:\\лабораторные работы\\ооп\\методички\\Lab03\\Lab02\\JSONS\\Search.json");
            label3.Text = "Последнее действие: поиск по списку";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            label3.Text = "Последнее действие: список очищен";
        }

        private void button11_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sortCriteria = comboBox3.Text;

            switch (sortCriteria)
            {
                case "Цена (по возр.)":
                    {
                        SearchResult = SearchResult.OrderBy(h => h.Price).ToList();
                        break;
                    }
                case "Цена (по убыв.)":
                    {
                        SearchResult = SearchResult.OrderByDescending(h => h.Price).ToList();
                        break;
                    }
                case "Страна (по возр.)":
                    {
                        SearchResult = SearchResult.OrderBy(h => h.addressess.Country).ToList();
                        break;
                    }
                case "Страна (по убыв.)":
                    {
                        SearchResult = SearchResult.OrderByDescending(h => h.addressess.Country).ToList();
                        break;
                    }
                default: Console.WriteLine("poop fart"); break;
            }
            UpdateResultsGrid();
            label3.Text = "Последнее действие: сорти... аахахха ахахХАХАХА";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            form1.Show();       
            form1.Activate();   
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = "ну не пикай...";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label3.Text = "Последнее действие: удалить";
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }
    }
}
