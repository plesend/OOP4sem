using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Lab02
{
    public partial class SearchQueryBuilder : Form
    {
        private List<Student> students;
        private List<Student> searchResults;

        public List<Student> SearchResults => searchResults;

        public SearchQueryBuilder(List<Student> students)
        {
            InitializeComponent();
            this.students = students;
            InitializeControls();
        }

        private void InitializeControls()
        {
            btnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var query = students.AsQueryable();

                if (!string.IsNullOrEmpty(txtFullName.Text))
                {
                    string fullName = txtFullName.Text.Trim();
                    query = query.Where(s => s.FullName != null && s.FullName.Contains(fullName));
                }

                if (!string.IsNullOrEmpty(txtAge.Text))
                {
                    if (int.TryParse(txtAge.Text, out int age))
                    {
                        query = query.Where(s => s.Age == age);
                    }
                    else
                    {
                        MessageBox.Show("Возраст должен быть числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(txtCourse.Text))
                {
                    if (int.TryParse(txtCourse.Text, out int course))
                    {
                        query = query.Where(s => s.Course == course);
                    }
                    else
                    {
                        MessageBox.Show("Курс должен быть числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(txtPosition.Text))
                {
                    string position = txtPosition.Text.Trim();
                    query = query.Where(s => s.WorkPlace != null && s.WorkPlace.Position != null && 
                                          s.WorkPlace.Position.Contains(position));
                }

                searchResults = query.ToList();

                if (searchResults.Count == 0)
                {
                    MessageBox.Show("По заданным критериям ничего не найдено", "Результат поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 