using System;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Lab02
{
    public partial class SearchForm : Form
    {
        public List<Student> Students { get; set; }
        public List<Student> SearchResults { get; set; }

        public SearchForm(List<Student> students)
        {
            InitializeComponent();
            Students = students;
            SearchResults = new List<Student>(students);
            InitializeSearchControls();

            btnSearch.Click += btnSearch_Click;
            
            txtSearchValue.TextChanged += txtSearchValue_TextChanged;
        }

        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchValue.Text.Trim()))
            {
                SearchResults = new List<Student>(Students);
            }
        }

        private void InitializeSearchControls()
        {
            cmbSearchCriteria.Items.AddRange(new string[] {
                "ФИО",
                "Возраст",
                "Специальность",
                "Курс",
                "Группа",
                "Средний балл",
                "Город",
                "Компания"
            });
            cmbSearchCriteria.SelectedIndex = 0;

            cmbSearchType.Items.AddRange(new string[] {
                "Точное совпадение",
                "Регулярное выражение",
            });
            cmbSearchType.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtSearchValue.Text.Trim();
                
                if (string.IsNullOrEmpty(searchValue))
                {
                    SearchResults = new List<Student>(Students);
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                string searchCriteria = cmbSearchCriteria.Text;
                string searchType = cmbSearchType.Text;

                var query = Students.AsQueryable();

                switch (searchType)
                {
                    case "Точное совпадение":
                        query = ExactMatch(query, searchCriteria, searchValue);
                        break;
                    case "Регулярное выражение":
                        query = RegexMatch(query, searchCriteria, searchValue);
                        break;
                }

                SearchResults = query.ToList();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IQueryable<Student> ExactMatch(IQueryable<Student> query, string criteria, string value)
        {
            switch (criteria)
            {
                case "ФИО":
                    return query.Where(s => s.FullName == value);
                case "Возраст":
                    return query.Where(s => s.Age.ToString() == value);
                case "Специальность":
                    return query.Where(s => s.Specialization == value);
                case "Курс":
                    return query.Where(s => s.Course.ToString() == value);
                case "Группа":
                    return query.Where(s => s.Group == value);
                case "Средний балл":
                    return query.Where(s => s.AverageGrade.ToString() == value);
                case "Город":
                    return query.Where(s => s.Address != null && s.Address.City == value);
                case "Компания":
                    return query.Where(s => s.WorkPlace != null && s.WorkPlace.Company == value);
                default:
                    return query;
            }
        }

        private IQueryable<Student> RegexMatch(IQueryable<Student> query, string criteria, string pattern)
        {
            try
            {
                var regex = new Regex(pattern);
                switch (criteria)
                {
                    case "ФИО":
                        return query.Where(s => regex.IsMatch(s.FullName ?? ""));
                    case "Специальность":
                        return query.Where(s => regex.IsMatch(s.Specialization ?? ""));
                    case "Группа":
                        return query.Where(s => regex.IsMatch(s.Group ?? ""));
                    case "Город":
                        return query.Where(s => s.Address != null && regex.IsMatch(s.Address.City ?? ""));
                    case "Компания":
                        return query.Where(s => s.WorkPlace != null && regex.IsMatch(s.WorkPlace.Company ?? ""));
                    default:
                        return query;
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Некорректное регулярное выражение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return query;
            }
        }

    }
} 