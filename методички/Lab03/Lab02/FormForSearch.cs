using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Timers;

namespace Lab02
{
    public partial class FormForSearch : Form
    {
        private List<Student> students;
        private List<Student> searchResults;
        private System.Timers.Timer timer;
        private string lastAction = "-";

        public FormForSearch()
        {
            InitializeComponent();
            InitializeSearchControls();
            InitializeDataGrid();
            InitializeToolStrip();
            
            students = new List<Student>();
            searchResults = new List<Student>();

            показатьПанельИнструментовToolStripMenuItem.Click += показатьПанельИнструментовToolStripMenuItem_Click;

            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            UpdateStatusStrip();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateDateTime()));
            }
            else
            {
                UpdateDateTime();
            }
        }

        private void UpdateDateTime()
        {
            lblDateTime.Text = $"Дата и время: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";
        }

        private void UpdateStatusStrip()
        {
            lblObjectCount.Text = $"Количество объектов: {searchResults.Count}";
            lblLastAction.Text = $"Последнее действие: {lastAction}";
            UpdateDateTime();
        }

        private void SetLastAction(string action)
        {
            lastAction = action;
            UpdateStatusStrip();
        }

        private void InitializeToolStrip()
        {
            toolStripBtnSearch.Click += (s, e) =>
            {
                using (var searchForm = new SearchForm(students))
                {
                    if (searchForm.ShowDialog() == DialogResult.OK)
                    {
                        searchResults = searchForm.SearchResults;
                        DisplaySearchResults();
                        SetLastAction("Выполнен поиск через панель инструментов");
                    }
                }
            };

            toolStripBtnSort.Click += (s, e) =>
            {
                using (var sortForm = new SortForm(students))
                {
                    if (sortForm.ShowDialog() == DialogResult.OK)
                    {
                        searchResults = sortForm.SortedResults;
                        DisplaySearchResults();
                        SetLastAction("Выполнена сортировка через панель инструментов");
                    }
                }
            };

            toolStripBtnClear.Click += (s, e) =>
            {
                searchResults = new List<Student>(students);
                DisplaySearchResults();
                SetLastAction("Очистка результатов поиска");
            };

            toolStripBtnDelete.Click += (s, e) =>
            {
                if (dataGridResults.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?", "Подтверждение",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int index = dataGridResults.SelectedRows[0].Index;
                        if (index >= 0 && index < searchResults.Count)
                        {
                            var deletedStudent = searchResults[index];
                            searchResults.RemoveAt(index);
                            DisplaySearchResults();
                            SetLastAction($"Удалена запись: {deletedStudent.FullName}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите запись для удаления", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            toolStripBtnBack.Click += (s, e) =>
            {
                if (dataGridResults.SelectedRows.Count > 0)
                {
                    int currentIndex = dataGridResults.SelectedRows[0].Index;
                    if (currentIndex > 0)
                    {
                        dataGridResults.ClearSelection();
                        dataGridResults.Rows[currentIndex - 1].Selected = true;
                        dataGridResults.FirstDisplayedScrollingRowIndex = currentIndex - 1;
                        SetLastAction("Переход к предыдущей записи");
                    }
                }
                else if (dataGridResults.Rows.Count > 0)
                {
                    dataGridResults.Rows[0].Selected = true;
                    dataGridResults.FirstDisplayedScrollingRowIndex = 0;
                    SetLastAction("Переход к первой записи");
                }
            };

            toolStripBtnForward.Click += (s, e) =>
            {
                if (dataGridResults.SelectedRows.Count > 0)
                {
                    int currentIndex = dataGridResults.SelectedRows[0].Index;
                    if (currentIndex < dataGridResults.Rows.Count - 1)
                    {
                        dataGridResults.ClearSelection();
                        dataGridResults.Rows[currentIndex + 1].Selected = true;
                        dataGridResults.FirstDisplayedScrollingRowIndex = currentIndex + 1;
                        SetLastAction("Переход к следующей записи");
                    }
                }
                else if (dataGridResults.Rows.Count > 0)
                {
                    dataGridResults.Rows[0].Selected = true;
                    dataGridResults.FirstDisplayedScrollingRowIndex = 0;
                    SetLastAction("Переход к первой записи");
                }
            };

            toolStripBtnCombinedSearch.Click += (s, e) =>
            {
                using (var searchBuilder = new SearchQueryBuilder(students))
                {
                    if (searchBuilder.ShowDialog() == DialogResult.OK)
                    {
                        searchResults = searchBuilder.SearchResults;
                        DisplaySearchResults();
                        SetLastAction("Выполнен комбинированный поиск");
                    }
                }
            };
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
                "Компания",
            });
            cmbSearchCriteria.SelectedIndex = 0;

            cmbSearchType.Items.AddRange(new string[] {
                "Точное совпадение",
                "Регулярное выражение"
            });
            cmbSearchType.SelectedIndex = 0;

            cmbSearchType.SelectedIndexChanged += (s, e) =>
            {
                if (cmbSearchType.Text == "Регулярное выражение")
                {
                    MessageBox.Show(
                        "Примеры регулярных выражений:\n" +
                        "^А - начинается с буквы 'А'\n" +
                        "ов$ - заканчивается на 'ов'\n" +
                        "иван - содержит 'иван'",
                        "Подсказка по регулярным выражениям",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            };

            cmbSortCriteria.Items.AddRange(new string[] {
                "ФИО (по возрастанию)",
                "ФИО (по убыванию)",
                "Возраст (по возрастанию)",
                "Возраст (по убыванию)",
                "Средний балл (по возрастанию)",
                "Средний балл (по убыванию)"
            });
            cmbSortCriteria.SelectedIndex = 0;

            txtSearchValue.TextChanged += txtSearchValue_TextChanged;
        }

        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchValue.Text.Trim()))
            {
                searchResults = new List<Student>(students);
                DisplaySearchResults();
            }
        }

        private void InitializeDataGrid()
        {
            dataGridResults.Columns.Clear();

            dataGridResults.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn 
                { 
                    Name = "ФИО",
                    HeaderText = "ФИО",
                    Width = 120,
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "Возраст",
                    HeaderText = "Возраст",
                    Width = 60,
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "Специальн.",
                    HeaderText = "Специальн.",
                    Width = 100,
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "Курс",
                    HeaderText = "Курс",
                    Width = 60,
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "Группа",
                    HeaderText = "Группа",
                    Width = 80,
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "СреднийБалл",
                    HeaderText = "Ср. балл",
                    Width = 60,
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "Город",
                    HeaderText = "Город",
                    Width = 100,
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "Компания",
                    HeaderText = "Компания",
                    Width = 100,
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "Должность",
                    HeaderText = "Должность",
                    Width = 100,
                    ReadOnly = true
                }
            });

            dataGridResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridResults.AllowUserToAddRows = false;
            dataGridResults.AllowUserToDeleteRows = false;
            dataGridResults.ReadOnly = true;
            dataGridResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridResults.MultiSelect = false;
            dataGridResults.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridResults.ScrollBars = ScrollBars.Vertical;

            this.MinimumSize = new Size(950, 400);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchCriteria = cmbSearchCriteria.Text;
                string searchType = cmbSearchType.Text;
                string searchValue = txtSearchValue.Text;

                var query = students.AsQueryable();

                switch (searchType)
                {
                    case "Точное совпадение":
                        query = ExactMatch(query, searchCriteria, searchValue);
                        break;
                    case "Регулярное выражение":
                        query = RegexMatch(query, searchCriteria, searchValue);
                        break;
                }

                searchResults = query.ToList();
                UpdateResultsGrid();
                SetLastAction($"Поиск по критерию: {searchCriteria}");
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
                case "Должность":
                    return query.Where(s => s.WorkPlace != null && s.WorkPlace.Position == value);
                default:
                    return query;
            }
        }

        private IQueryable<Student> RegexMatch(IQueryable<Student> query, string criteria, string pattern)
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
                    case "Должность":
                        return query.Where(s => s.WorkPlace != null && regex.IsMatch(s.WorkPlace.Position ?? ""));
                    default:
                        return query;
                }
            }
            catch (ArgumentException)
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

        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                string sortCriteria = cmbSortCriteria.Text;
                string sortDirection = "";
                
                switch (sortCriteria)
                {
                    case "ФИО (по возрастанию)":
                        searchResults = searchResults.OrderBy(s => s.FullName).ToList();
                        sortDirection = "по возрастанию";
                        break;
                    case "ФИО (по убыванию)":
                        searchResults = searchResults.OrderByDescending(s => s.FullName).ToList();
                        sortDirection = "по убыванию";
                        break;
                    case "Возраст (по возрастанию)":
                        searchResults = searchResults.OrderBy(s => s.Age).ToList();
                        sortDirection = "по возрастанию";
                        break;
                    case "Возраст (по убыванию)":
                        searchResults = searchResults.OrderByDescending(s => s.Age).ToList();
                        sortDirection = "по убыванию";
                        break;
                    case "Средний балл (по возрастанию)":
                        searchResults = searchResults.OrderBy(s => s.AverageGrade).ToList();
                        sortDirection = "по возрастанию";
                        break;
                    case "Средний балл (по убыванию)":
                        searchResults = searchResults.OrderByDescending(s => s.AverageGrade).ToList();
                        sortDirection = "по убыванию";
                        break;
                }

                UpdateResultsGrid();
                SetLastAction($"Сортировка по {sortCriteria.Replace(" (по возрастанию)", "").Replace(" (по убыванию)", "")} {sortDirection}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сортировке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            try
            {
                var settings = new JsonSerializerSettings 
                { 
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore
                };
                string json = JsonConvert.SerializeObject(searchResults, settings);
                File.WriteAllText("search_results.json", json);
                SetLastAction("Сохранение результатов поиска");
                MessageBox.Show("Результаты поиска сохранены в файл search_results.json", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении результатов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateResultsGrid()
        {
            try
            {
                dataGridResults.Rows.Clear();

                if (searchResults != null)
                {
                    foreach (var student in searchResults)
                    {
                        if (student != null)
                        {
                            dataGridResults.Rows.Add(
                                student.FullName ?? "",
                                student.Age,
                                student.Specialization ?? "",
                                student.Course,
                                student.Group ?? "",
                                student.AverageGrade,
                                student.Address?.City ?? "",
                                student.WorkPlace?.Company ?? "",
                                student.WorkPlace?.Position ?? ""
                            );
                        }
                    }
                }

                dataGridResults.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении таблицы: {ex.Message}\n\nСтек вызовов: {ex.StackTrace}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("students.json"))
                {
                    string json = File.ReadAllText("students.json");
                    students = JsonConvert.DeserializeObject<List<Student>>(json) ?? new List<Student>();
                    searchResults = new List<Student>(students);
                    UpdateResultsGrid();
                    SetLastAction("Загрузка данных из файла");
                }
                else
                {
                    MessageBox.Show("Файл students.json не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadData(List<Student> loadedStudents)
        {
            try
            {
                students = loadedStudents ?? new List<Student>();
                searchResults = new List<Student>(students);
                InitializeDataGrid();
                UpdateResultsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplaySearchResults()
        {
            UpdateResultsGrid();
        }

        private void показатьПанельИнструментовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = показатьПанельИнструментовToolStripMenuItem.Checked;
            dataGridResults.Location = new Point(300, показатьПанельИнструментовToolStripMenuItem.Checked ? 64 : 40);
            dataGridResults.Size = new Size(682, показатьПанельИнструментовToolStripMenuItem.Checked ? 449 : 473);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            timer.Stop();
            timer.Dispose();
        }

        private void dataGridResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripBtnBack_Click(object sender, EventArgs e)
        {

        }

        private void toolStripBtnForward_Click(object sender, EventArgs e)
        {

        }

        private void lblLastAction_Click(object sender, EventArgs e)
        {

        }
    }
}
