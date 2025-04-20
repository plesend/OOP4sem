using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace Lab02
{
    public partial class SortForm : Form
    {
        public List<Student> Students { get; set; }
        public List<Student> SortedResults { get; set; }

        public SortForm(List<Student> students)
        {
            InitializeComponent();
            Students = students;
            SortedResults = new List<Student>(students);
            InitializeSortControls();
        }

        private void InitializeSortControls()
        {
            cmbSortField.Items.AddRange(new string[] {
                "ФИО",
                "Возраст",
                "Средний балл"
            });
            cmbSortField.SelectedIndex = 0;

            cmbSortOrder.Items.AddRange(new string[] {
                "По возрастанию",
                "По убыванию"
            });
            cmbSortOrder.SelectedIndex = 0;

            btnSort.Click += btnSort_Click;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                string sortField = cmbSortField.Text;
                string sortOrder = cmbSortOrder.Text;
                
                switch (sortField)
                {
                    case "ФИО":
                        SortedResults = sortOrder == "По возрастанию" 
                            ? Students.OrderBy(s => s.FullName).ToList()
                            : Students.OrderByDescending(s => s.FullName).ToList();
                        break;
                    case "Возраст":
                        SortedResults = sortOrder == "По возрастанию"
                            ? Students.OrderBy(s => s.Age).ToList()
                            : Students.OrderByDescending(s => s.Age).ToList();
                        break;
                    case "Средний балл":
                        SortedResults = sortOrder == "По возрастанию"
                            ? Students.OrderBy(s => s.AverageGrade).ToList()
                            : Students.OrderByDescending(s => s.AverageGrade).ToList();
                        break;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сортировке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 