using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace lab02
{
    public partial class Main : Form
    {
        public List<House> HousesList = loadFromJSON("D:\\лабораторные работы\\ооп\\lab02\\lab02\\domiki.json");
        public Main()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var AddingForm = new Form1();
            AddingForm.ShowDialog();
            HousesList.Add(AddingForm.Houses);
            AddingForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (HousesList == null ||  HousesList.Count == 0)
            {
                MessageBox.Show("Список домов пуст!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (var house in HousesList)
            {
                richTextBox1.AppendText(house.HouseData()+ "\n\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveToJSON("D:\\лабораторные работы\\ооп\\lab02\\lab02\\domiki.json");
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
    }
}
