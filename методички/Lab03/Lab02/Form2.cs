using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Lab02
{
    public partial class Form2 : Form
    {
        private List<Student> students;
        private int currentIndex;
        private Student currentStudent;
        private FormForSearch searchForm;
        public event EventHandler<List<Student>> StudentAdded;

        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            students = new List<Student>();
            currentIndex = -1;
            
            поискToolStripMenuItem.Click += поискToolStripMenuItem_Click;
            оПрограммеToolStripMenuItem.Click += AboutMenu_Click;
          
            
            AddNewStudent();
        }

        private void AboutMenu_Click(object sender, EventArgs e)
        {
            string version = "23.1";
            string developer = "Литвинчук Дарья";
            MessageBox.Show(
                $"Версия программы: {version}\nРазработчик: {developer}",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void OpenSearchForm_Click(object sender, EventArgs e)
        {
            if (searchForm == null || searchForm.IsDisposed)
            {
                searchForm = new FormForSearch();
                searchForm.Show();
            }
            else
            {
                searchForm.Activate();
            }
        }

        private void AddNewStudent()
        {
            students.Add(new Student
            {
                Address = new Address(),
                WorkPlace = new WorkPlace(),
                BirthDate = DateTime.Now.AddYears(-18),
                Course = 1
            });
            currentIndex = students.Count - 1;
            LoadStudentData();
        }

        private bool ValidateInput()
        {
            var address = new Address
            {
                City = txtCity.Text,
                PostalCode = txtPostalCode.Text,
                Street = txtStreet.Text,
                House = txtHouse.Text,
                Apartment = txtApartment.Text
            };

            var addressValidationContext = new ValidationContext(address);
            var addressValidationResults = new List<ValidationResult>();
            bool isAddressValid = Validator.TryValidateObject(address, addressValidationContext, addressValidationResults, true);

            if (!isAddressValid)
            {
                string errorMessage = string.Join("\n", addressValidationResults.Select(r => r.ErrorMessage));
                MessageBox.Show(errorMessage, "Ошибка валидации адреса", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var student = new Student
            {
                FullName = txtFullName.Text,
                Age = (int)(DateTime.Now.Year - dtpBirthDate.Value.Year),
                AverageGrade = (double)numAverageGrade.Value,
                Specialization = cmbSpecialization.Text,
                BirthDate = dtpBirthDate.Value,
                Course = trackCourse.Value,
                Group = txtGroup.Text,
                Gender = rbMale.Checked ? "Мужской" : "Женский",
                Address = address,
                WorkPlace = new WorkPlace
                {
                    Company = txtCompany.Text,
                    Position = txtPosition.Text,
                    Experience = (int)numExperience.Value,
                    Salary = (double)numSalary.Value
                }
            };

            var validationContext = new ValidationContext(student);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(student, validationContext, validationResults, true);

            if (!isValid)
            {
                string errorMessage = string.Join("\n", validationResults.Select(r => r.ErrorMessage));
                MessageBox.Show(errorMessage, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rbMale.Checked && !rbFemale.Checked)
            {
                MessageBox.Show("Пожалуйста, выберите пол", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int experience = (int)numExperience.Value;
            if (experience > student.Age)
            {
                MessageBox.Show("Стаж не может быть больше возраста", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbSpecialization.Text))
            {
                MessageBox.Show("Пожалуйста, выберите специальность", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (trackCourse.Value < 1 || trackCourse.Value > 6)
            {
                MessageBox.Show("Курс должен быть от 1 до 6", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGroup.Text))
            {
                MessageBox.Show("Пожалуйста, введите номер группы", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numSalary.Value <= 0)
            {
                MessageBox.Show("Зарплата должна быть больше 0", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void SaveStudentData()
        {
            if (currentIndex < 0 || currentIndex >= students.Count)
                return;

            currentStudent = students[currentIndex];
            currentStudent.FullName = txtFullName.Text;
            DateTime birthDate = dtpBirthDate.Value;
            DateTime today = DateTime.Now;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }
            currentStudent.Age = age;
            currentStudent.Specialization = cmbSpecialization.Text;
            currentStudent.BirthDate = birthDate;
            currentStudent.Course = trackCourse.Value;
            currentStudent.Group = txtGroup.Text;
            currentStudent.AverageGrade = (double)numAverageGrade.Value;
            currentStudent.Gender = rbMale.Checked ? "Мужской" : "Женский";

            currentStudent.Address.City = txtCity.Text;
            currentStudent.Address.PostalCode = txtPostalCode.Text;
            currentStudent.Address.Street = txtStreet.Text;
            currentStudent.Address.House = txtHouse.Text;
            currentStudent.Address.Apartment = txtApartment.Text;

            currentStudent.WorkPlace.Company = txtCompany.Text;
            currentStudent.WorkPlace.Position = txtPosition.Text;
            currentStudent.WorkPlace.Experience = (int)numExperience.Value;
            currentStudent.WorkPlace.Salary = (double)numSalary.Value;
        }

        private void LoadStudentData()
        {
            if (currentIndex < 0 || currentIndex >= students.Count)
                return;

            currentStudent = students[currentIndex];
            txtFullName.Text = currentStudent.FullName;
            
            if (currentStudent.BirthDate < dtpBirthDate.MinDate || currentStudent.BirthDate > dtpBirthDate.MaxDate)
            {
                currentStudent.BirthDate = DateTime.Now.AddYears(-18);
            }
            dtpBirthDate.Value = currentStudent.BirthDate;
            
            cmbSpecialization.Text = currentStudent.Specialization;
            
            if (currentStudent.Course < trackCourse.Minimum || currentStudent.Course > trackCourse.Maximum)
            {
                currentStudent.Course = 1;
            }
            trackCourse.Value = currentStudent.Course;
            lblCourseValue.Text = currentStudent.Course.ToString();
            txtGroup.Text = currentStudent.Group;
            numAverageGrade.Value = (decimal)currentStudent.AverageGrade;
            rbMale.Checked = currentStudent.Gender == "Мужской";
            rbFemale.Checked = currentStudent.Gender == "Женский";

            txtCity.Text = currentStudent.Address.City;
            txtPostalCode.Text = currentStudent.Address.PostalCode;
            txtStreet.Text = currentStudent.Address.Street;
            txtHouse.Text = currentStudent.Address.House;
            txtApartment.Text = currentStudent.Address.Apartment;

            txtCompany.Text = currentStudent.WorkPlace.Company;
            txtPosition.Text = currentStudent.WorkPlace.Position;
            numExperience.Value = currentStudent.WorkPlace.Experience;
            numSalary.Value = (decimal)currentStudent.WorkPlace.Salary;
        }

        private void btnSaveJson_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            SaveStudentData();
            try
            {
                var settings = new JsonSerializerSettings 
                { 
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore
                };

                List<Student> existingStudents = new List<Student>();
                
                if (File.Exists("students.json"))
                {
                    try
                    {
                        string existingJson = File.ReadAllText("students.json");
                        existingStudents = JsonConvert.DeserializeObject<List<Student>>(existingJson, settings) ?? new List<Student>();
                    }
                    catch
                    {
                        existingStudents = new List<Student>();
                    }
                }

                var currentStudent = students[currentIndex];
                var existingStudent = existingStudents.FirstOrDefault(s => 
                    s.FullName == currentStudent.FullName && 
                    s.BirthDate == currentStudent.BirthDate && 
                    s.Group == currentStudent.Group);
                
                if (existingStudent != null)
                {
                    var index = existingStudents.IndexOf(existingStudent);
                    existingStudents[index] = currentStudent;
                    MessageBox.Show("Данные студента обновлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    existingStudents.Add(currentStudent);
                    MessageBox.Show("Добавлен новый студент!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                string jsonString = JsonConvert.SerializeObject(existingStudents, settings);
                File.WriteAllText("students.json", jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadJson_Click(object sender, EventArgs e)
        {
            if (!File.Exists("students.json"))
            {
                MessageBox.Show("Файл students.json не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try 
            {
                string jsonString = File.ReadAllText("students.json");
                if (string.IsNullOrWhiteSpace(jsonString))
                {
                    MessageBox.Show("Файл students.json пуст!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Error = (serializer, args) =>
                    {
                        args.ErrorContext.Handled = true;
                    }
                };

                List<Student> loadedStudents;
                
                try
                {
                    loadedStudents = JsonConvert.DeserializeObject<List<Student>>(jsonString, settings);
                }
                catch
                {
                    try
                    {
                        var singleStudent = JsonConvert.DeserializeObject<Student>(jsonString, settings);
                        loadedStudents = new List<Student> { singleStudent };
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при разборе JSON: {ex.Message}\n\nСодержимое файла:\n{jsonString}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
                if (loadedStudents != null && loadedStudents.Count > 0)
                {
                    students = loadedStudents;
                    foreach (var student in students)
                    {
                        if (student.Address == null) student.Address = new Address();
                        if (student.WorkPlace == null) student.WorkPlace = new WorkPlace();
                        student.FullName = student.FullName ?? "";
                        student.Specialization = student.Specialization ?? "";
                        student.Group = student.Group ?? "";
                        student.Gender = student.Gender ?? "Мужской";
                        student.Address.City = student.Address.City ?? "";
                        student.Address.PostalCode = student.Address.PostalCode ?? "";
                        student.Address.Street = student.Address.Street ?? "";
                        student.Address.House = student.Address.House ?? "";
                        student.Address.Apartment = student.Address.Apartment ?? "";
                        student.WorkPlace.Company = student.WorkPlace.Company ?? "";
                        student.WorkPlace.Position = student.WorkPlace.Position ?? "";
                    }
                    currentIndex = 0;
                    LoadStudentData();
                    MessageBox.Show($"Загружено {students.Count} студентов!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Не удалось загрузить данные из файла. Содержимое файла:\n{jsonString}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AddNewStudent();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}\n\nСтек ошибки: {ex.StackTrace}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddNewStudent();
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            SaveStudentData();
            
            double income = currentStudent.WorkPlace.Salary * 12;
            double expenses = currentStudent.AverageGrade * 10000;
            double profit = income - expenses;

            string result = $"Расчет финансов для студента {currentStudent.FullName}:\n" +
                          $"Годовой доход: {income:C}\n" +
                          $"Расходы на обучение: {expenses:C}\n" +
                          $"Чистая прибыль: {profit:C}";

            MessageBox.Show(result, "Результаты расчета", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < students.Count - 1)
            {
                SaveStudentData();
                currentIndex++;
                LoadStudentData();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                SaveStudentData();
                currentIndex--;
                LoadStudentData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveStudentData();
            AddNewStudent();
        }

        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime birthDate = dtpBirthDate.Value;
            DateTime today = DateTime.Now;
            
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }
            
            if (age > 100)
            {
                MessageBox.Show("Возраст не может превышать 100 лет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpBirthDate.Value = DateTime.Now.AddYears(-100);
            }
        }

        private void trackCourse_Scroll(object sender, EventArgs e)
        {
            lblCourseValue.Text = trackCourse.Value.ToString();
        }

        private void numSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void numExperience_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LoadJsonData()
        {
            try
            {
                if (File.Exists("students.json"))
                {
                    string jsonData = File.ReadAllText("students.json");
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        Error = (sender, args) =>
                        {
                            args.ErrorContext.Handled = true;
                        }
                    };

                    var loadedStudents = JsonConvert.DeserializeObject<List<Student>>(jsonData, settings);
                    
                    if (loadedStudents != null)
                    {
                        foreach (var student in loadedStudents)
                        {
                            if (student != null)
                            {
                                student.FullName = student.FullName ?? "";
                                student.Specialization = student.Specialization ?? "";
                                student.Group = student.Group ?? "";
                                
                                if (student.Address == null)
                                {
                                    student.Address = new Address
                                    {
                                        City = "",
                                        Street = "",
                                        House = "",
                                        PostalCode = ""
                                    };
                                }
                                else
                                {
                                    student.Address.City = student.Address.City ?? "";
                                    student.Address.Street = student.Address.Street ?? "";
                                    student.Address.House = student.Address.House ?? "";
                                    student.Address.PostalCode = student.Address.PostalCode ?? "";
                                }

                                if (student.WorkPlace == null)
                                {
                                    student.WorkPlace = new WorkPlace
                                    {
                                        Company = "",
                                        Position = "",
                                        Experience = 0
                                    };
                                }
                                else
                                {
                                    student.WorkPlace.Company = student.WorkPlace.Company ?? "";
                                    student.WorkPlace.Position = student.WorkPlace.Position ?? "";
                                }
                            }
                        }

                        if (searchForm != null && !searchForm.IsDisposed)
                        {
                            searchForm.LoadData(loadedStudents);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Файл с данными студентов не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searchForm == null || searchForm.IsDisposed)
            {
                searchForm = new FormForSearch();
                searchForm.Show();
            }
            else
            {
                searchForm.Activate();
            }
        }

        private void загрузитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadJsonData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                SaveStudentData();

                string json = JsonConvert.SerializeObject(students, Formatting.Indented);
                File.WriteAllText("students.json", json);
                StudentAdded?.Invoke(this, students);

                MessageBox.Show("Студент успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
