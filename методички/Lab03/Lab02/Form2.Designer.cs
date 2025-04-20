namespace Lab02
{
    partial class Form2 : System.Windows.Forms.Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.cmbSpecialization = new System.Windows.Forms.ComboBox();
            this.lblSpecialization = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.trackCourse = new System.Windows.Forms.TrackBar();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblCourseValue = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.numAverageGrade = new System.Windows.Forms.NumericUpDown();
            this.lblAverageGrade = new System.Windows.Forms.Label();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.lblGender = new System.Windows.Forms.Label();
            this.grpAddress = new System.Windows.Forms.GroupBox();
            this.txtApartment = new System.Windows.Forms.TextBox();
            this.lblApartment = new System.Windows.Forms.Label();
            this.txtHouse = new System.Windows.Forms.TextBox();
            this.lblHouse = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.grpWorkPlace = new System.Windows.Forms.GroupBox();
            this.numSalary = new System.Windows.Forms.NumericUpDown();
            this.lblSalary = new System.Windows.Forms.Label();
            this.numExperience = new System.Windows.Forms.NumericUpDown();
            this.lblExperience = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.btnSaveJson = new System.Windows.Forms.Button();
            this.btnLoadJson = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackCourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAverageGrade)).BeginInit();
            this.grpAddress.SuspendLayout();
            this.grpWorkPlace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExperience)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.ForeColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.поискToolStripMenuItem.Text = "Поиск";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtFullName.Location = new System.Drawing.Point(16, 73);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(300, 27);
            this.txtFullName.TabIndex = 30;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblFullName.Location = new System.Drawing.Point(15, 49);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(45, 20);
            this.lblFullName.TabIndex = 21;
            this.lblFullName.Text = "ФИО:";
            // 
            // cmbSpecialization
            // 
            this.cmbSpecialization.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecialization.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSpecialization.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmbSpecialization.FormattingEnabled = true;
            this.cmbSpecialization.Items.AddRange(new object[] {
            "Программирование",
            "Дизайн",
            "Маркетинг",
            "Менеджмент"});
            this.cmbSpecialization.Location = new System.Drawing.Point(16, 146);
            this.cmbSpecialization.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSpecialization.Name = "cmbSpecialization";
            this.cmbSpecialization.Size = new System.Drawing.Size(300, 28);
            this.cmbSpecialization.TabIndex = 28;
            // 
            // lblSpecialization
            // 
            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.BackColor = System.Drawing.Color.Transparent;
            this.lblSpecialization.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSpecialization.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblSpecialization.Location = new System.Drawing.Point(16, 113);
            this.lblSpecialization.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Size = new System.Drawing.Size(119, 20);
            this.lblSpecialization.TabIndex = 17;
            this.lblSpecialization.Text = "Специальность:";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpBirthDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpBirthDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dtpBirthDate.Location = new System.Drawing.Point(398, 73);
            this.dtpBirthDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(300, 27);
            this.dtpBirthDate.TabIndex = 27;
            this.dtpBirthDate.ValueChanged += new System.EventHandler(this.dtpBirthDate_ValueChanged);
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.BackColor = System.Drawing.Color.Transparent;
            this.lblBirthDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBirthDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblBirthDate.Location = new System.Drawing.Point(494, 49);
            this.lblBirthDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(119, 20);
            this.lblBirthDate.TabIndex = 15;
            this.lblBirthDate.Text = "Дата рождения:";
            // 
            // trackCourse
            // 
            this.trackCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.trackCourse.Location = new System.Drawing.Point(16, 221);
            this.trackCourse.Maximum = 6;
            this.trackCourse.Minimum = 1;
            this.trackCourse.Name = "trackCourse";
            this.trackCourse.Size = new System.Drawing.Size(200, 56);
            this.trackCourse.TabIndex = 26;
            this.trackCourse.Value = 1;
            this.trackCourse.Scroll += new System.EventHandler(this.trackCourse_Scroll);
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.BackColor = System.Drawing.Color.Transparent;
            this.lblCourse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblCourse.Location = new System.Drawing.Point(16, 198);
            this.lblCourse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(44, 20);
            this.lblCourse.TabIndex = 13;
            this.lblCourse.Text = "Курс:";
            // 
            // lblCourseValue
            // 
            this.lblCourseValue.AutoSize = true;
            this.lblCourseValue.BackColor = System.Drawing.Color.Transparent;
            this.lblCourseValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCourseValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblCourseValue.Location = new System.Drawing.Point(223, 221);
            this.lblCourseValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCourseValue.Name = "lblCourseValue";
            this.lblCourseValue.Size = new System.Drawing.Size(17, 20);
            this.lblCourseValue.TabIndex = 14;
            this.lblCourseValue.Text = "1";
            // 
            // txtGroup
            // 
            this.txtGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtGroup.Location = new System.Drawing.Point(16, 313);
            this.txtGroup.Margin = new System.Windows.Forms.Padding(4);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(200, 27);
            this.txtGroup.TabIndex = 25;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.BackColor = System.Drawing.Color.Transparent;
            this.lblGroup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblGroup.Location = new System.Drawing.Point(16, 289);
            this.lblGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(61, 20);
            this.lblGroup.TabIndex = 11;
            this.lblGroup.Text = "Группа:";
            // 
            // numAverageGrade
            // 
            this.numAverageGrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.numAverageGrade.DecimalPlaces = 1;
            this.numAverageGrade.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numAverageGrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.numAverageGrade.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numAverageGrade.Location = new System.Drawing.Point(16, 374);
            this.numAverageGrade.Margin = new System.Windows.Forms.Padding(4);
            this.numAverageGrade.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numAverageGrade.Name = "numAverageGrade";
            this.numAverageGrade.Size = new System.Drawing.Size(200, 27);
            this.numAverageGrade.TabIndex = 24;
            // 
            // lblAverageGrade
            // 
            this.lblAverageGrade.AutoSize = true;
            this.lblAverageGrade.BackColor = System.Drawing.Color.Transparent;
            this.lblAverageGrade.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAverageGrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblAverageGrade.Location = new System.Drawing.Point(15, 350);
            this.lblAverageGrade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAverageGrade.Name = "lblAverageGrade";
            this.lblAverageGrade.Size = new System.Drawing.Size(110, 20);
            this.lblAverageGrade.TabIndex = 9;
            this.lblAverageGrade.Text = "Средний балл:";
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbMale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.rbMale.Location = new System.Drawing.Point(326, 335);
            this.rbMale.Margin = new System.Windows.Forms.Padding(4);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(93, 24);
            this.rbMale.TabIndex = 6;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Мужской";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbFemale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.rbFemale.Location = new System.Drawing.Point(420, 335);
            this.rbFemale.Margin = new System.Windows.Forms.Padding(4);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(92, 24);
            this.rbFemale.TabIndex = 5;
            this.rbFemale.Text = "Женский";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblGender.Location = new System.Drawing.Point(323, 309);
            this.lblGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(40, 20);
            this.lblGender.TabIndex = 7;
            this.lblGender.Text = "Пол:";
            // 
            // grpAddress
            // 
            this.grpAddress.BackColor = System.Drawing.Color.White;
            this.grpAddress.Controls.Add(this.txtApartment);
            this.grpAddress.Controls.Add(this.lblApartment);
            this.grpAddress.Controls.Add(this.txtHouse);
            this.grpAddress.Controls.Add(this.lblHouse);
            this.grpAddress.Controls.Add(this.txtStreet);
            this.grpAddress.Controls.Add(this.lblStreet);
            this.grpAddress.Controls.Add(this.txtPostalCode);
            this.grpAddress.Controls.Add(this.lblPostalCode);
            this.grpAddress.Controls.Add(this.txtCity);
            this.grpAddress.Controls.Add(this.lblCity);
            this.grpAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.grpAddress.Location = new System.Drawing.Point(16, 408);
            this.grpAddress.Margin = new System.Windows.Forms.Padding(4);
            this.grpAddress.Name = "grpAddress";
            this.grpAddress.Padding = new System.Windows.Forms.Padding(4);
            this.grpAddress.Size = new System.Drawing.Size(300, 310);
            this.grpAddress.TabIndex = 4;
            this.grpAddress.TabStop = false;
            this.grpAddress.Text = "Адрес";
            // 
            // txtApartment
            // 
            this.txtApartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtApartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApartment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtApartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtApartment.Location = new System.Drawing.Point(8, 271);
            this.txtApartment.Margin = new System.Windows.Forms.Padding(4);
            this.txtApartment.Name = "txtApartment";
            this.txtApartment.Size = new System.Drawing.Size(280, 27);
            this.txtApartment.TabIndex = 0;
            this.txtApartment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApartment_KeyPress);
            // 
            // lblApartment
            // 
            this.lblApartment.AutoSize = true;
            this.lblApartment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblApartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblApartment.Location = new System.Drawing.Point(7, 236);
            this.lblApartment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApartment.Name = "lblApartment";
            this.lblApartment.Size = new System.Drawing.Size(78, 20);
            this.lblApartment.TabIndex = 1;
            this.lblApartment.Text = "Квартира:";
            // 
            // txtHouse
            // 
            this.txtHouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHouse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHouse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtHouse.Location = new System.Drawing.Point(8, 205);
            this.txtHouse.Margin = new System.Windows.Forms.Padding(4);
            this.txtHouse.Name = "txtHouse";
            this.txtHouse.Size = new System.Drawing.Size(280, 27);
            this.txtHouse.TabIndex = 2;
            this.txtHouse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHouse_KeyPress);
            // 
            // lblHouse
            // 
            this.lblHouse.AutoSize = true;
            this.lblHouse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHouse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblHouse.Location = new System.Drawing.Point(8, 181);
            this.lblHouse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHouse.Name = "lblHouse";
            this.lblHouse.Size = new System.Drawing.Size(42, 20);
            this.lblHouse.TabIndex = 3;
            this.lblHouse.Text = "Дом:";
            // 
            // txtStreet
            // 
            this.txtStreet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtStreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStreet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStreet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtStreet.Location = new System.Drawing.Point(8, 131);
            this.txtStreet.Margin = new System.Windows.Forms.Padding(4);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(280, 27);
            this.txtStreet.TabIndex = 4;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStreet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblStreet.Location = new System.Drawing.Point(8, 107);
            this.lblStreet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(55, 20);
            this.lblStreet.TabIndex = 5;
            this.lblStreet.Text = "Улица:";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtPostalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPostalCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPostalCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtPostalCode.Location = new System.Drawing.Point(8, 76);
            this.txtPostalCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(280, 27);
            this.txtPostalCode.TabIndex = 30;
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPostalCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblPostalCode.Location = new System.Drawing.Point(8, 52);
            this.lblPostalCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(62, 20);
            this.lblPostalCode.TabIndex = 7;
            this.lblPostalCode.Text = "Индекс:";
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtCity.Location = new System.Drawing.Point(8, 23);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(280, 27);
            this.txtCity.TabIndex = 8;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblCity.Location = new System.Drawing.Point(8, 4);
            this.lblCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(54, 20);
            this.lblCity.TabIndex = 9;
            this.lblCity.Text = "Город:";
            // 
            // grpWorkPlace
            // 
            this.grpWorkPlace.BackColor = System.Drawing.Color.White;
            this.grpWorkPlace.Controls.Add(this.numSalary);
            this.grpWorkPlace.Controls.Add(this.lblSalary);
            this.grpWorkPlace.Controls.Add(this.numExperience);
            this.grpWorkPlace.Controls.Add(this.lblExperience);
            this.grpWorkPlace.Controls.Add(this.txtPosition);
            this.grpWorkPlace.Controls.Add(this.lblPosition);
            this.grpWorkPlace.Controls.Add(this.txtCompany);
            this.grpWorkPlace.Controls.Add(this.lblCompany);
            this.grpWorkPlace.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpWorkPlace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.grpWorkPlace.Location = new System.Drawing.Point(324, 408);
            this.grpWorkPlace.Margin = new System.Windows.Forms.Padding(4);
            this.grpWorkPlace.Name = "grpWorkPlace";
            this.grpWorkPlace.Padding = new System.Windows.Forms.Padding(4);
            this.grpWorkPlace.Size = new System.Drawing.Size(300, 310);
            this.grpWorkPlace.TabIndex = 3;
            this.grpWorkPlace.TabStop = false;
            this.grpWorkPlace.Text = "Место работы";
            // 
            // numSalary
            // 
            this.numSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.numSalary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numSalary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.numSalary.Location = new System.Drawing.Point(8, 271);
            this.numSalary.Margin = new System.Windows.Forms.Padding(4);
            this.numSalary.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numSalary.Name = "numSalary";
            this.numSalary.Size = new System.Drawing.Size(280, 27);
            this.numSalary.TabIndex = 0;
            this.numSalary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numSalary_KeyPress);
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSalary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblSalary.Location = new System.Drawing.Point(8, 236);
            this.lblSalary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(76, 20);
            this.lblSalary.TabIndex = 1;
            this.lblSalary.Text = "Зарплата:";
            // 
            // numExperience
            // 
            this.numExperience.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.numExperience.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numExperience.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.numExperience.Location = new System.Drawing.Point(8, 196);
            this.numExperience.Margin = new System.Windows.Forms.Padding(4);
            this.numExperience.Name = "numExperience";
            this.numExperience.Size = new System.Drawing.Size(280, 27);
            this.numExperience.TabIndex = 2;
            this.numExperience.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numExperience_KeyPress);
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblExperience.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblExperience.Location = new System.Drawing.Point(7, 158);
            this.lblExperience.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(46, 20);
            this.lblExperience.TabIndex = 3;
            this.lblExperience.Text = "Стаж:";
            // 
            // txtPosition
            // 
            this.txtPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPosition.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtPosition.Location = new System.Drawing.Point(8, 128);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(4);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(280, 27);
            this.txtPosition.TabIndex = 4;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblPosition.Location = new System.Drawing.Point(4, 100);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(89, 20);
            this.lblPosition.TabIndex = 5;
            this.lblPosition.Text = "Должность:";
            // 
            // txtCompany
            // 
            this.txtCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompany.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtCompany.Location = new System.Drawing.Point(8, 70);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(280, 27);
            this.txtCompany.TabIndex = 6;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblCompany.Location = new System.Drawing.Point(7, 46);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(84, 20);
            this.lblCompany.TabIndex = 7;
            this.lblCompany.Text = "Компания:";
            // 
            // btnSaveJson
            // 
            this.btnSaveJson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveJson.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSaveJson.ForeColor = System.Drawing.Color.White;
            this.btnSaveJson.Location = new System.Drawing.Point(226, 741);
            this.btnSaveJson.Name = "btnSaveJson";
            this.btnSaveJson.Size = new System.Drawing.Size(150, 40);
            this.btnSaveJson.TabIndex = 4;
            this.btnSaveJson.Text = "Сохранить JSON";
            this.btnSaveJson.UseVisualStyleBackColor = false;
            this.btnSaveJson.Click += new System.EventHandler(this.btnSaveJson_Click);
            // 
            // btnLoadJson
            // 
            this.btnLoadJson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLoadJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadJson.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoadJson.ForeColor = System.Drawing.Color.White;
            this.btnLoadJson.Location = new System.Drawing.Point(382, 741);
            this.btnLoadJson.Name = "btnLoadJson";
            this.btnLoadJson.Size = new System.Drawing.Size(150, 40);
            this.btnLoadJson.TabIndex = 6;
            this.btnLoadJson.Text = "Загрузить JSON";
            this.btnLoadJson.UseVisualStyleBackColor = false;
            this.btnLoadJson.Click += new System.EventHandler(this.btnLoadJson_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(16, 741);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(150, 40);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "Рассчитать";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(608, 741);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 40);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "→";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(538, 741);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(64, 40);
            this.btnPrevious.TabIndex = 10;
            this.btnPrevious.Text = "←";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(694, 741);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 40);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 850);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnLoadJson);
            this.Controls.Add(this.btnSaveJson);
            this.Controls.Add(this.grpWorkPlace);
            this.Controls.Add(this.grpAddress);
            this.Controls.Add(this.rbFemale);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.numAverageGrade);
            this.Controls.Add(this.lblAverageGrade);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.trackCourse);
            this.Controls.Add(this.lblCourseValue);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.cmbSpecialization);
            this.Controls.Add(this.lblSpecialization);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление студентами";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackCourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAverageGrade)).EndInit();
            this.grpAddress.ResumeLayout(false);
            this.grpAddress.PerformLayout();
            this.grpWorkPlace.ResumeLayout(false);
            this.grpWorkPlace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExperience)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.ComboBox cmbSpecialization;
        private System.Windows.Forms.Label lblSpecialization;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.TrackBar trackCourse;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblCourseValue;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.NumericUpDown numAverageGrade;
        private System.Windows.Forms.Label lblAverageGrade;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.GroupBox grpAddress;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.MaskedTextBox mtxtPostalCode;
        private System.Windows.Forms.Label lblPostalCode;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtHouse;
        private System.Windows.Forms.Label lblHouse;
        private System.Windows.Forms.TextBox txtApartment;
        private System.Windows.Forms.Label lblApartment;
        private System.Windows.Forms.GroupBox grpWorkPlace;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.NumericUpDown numExperience;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.NumericUpDown numSalary;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Button btnSaveJson;
        private System.Windows.Forms.Button btnLoadJson;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnAdd;
    }
}