using System;
using System.Windows.Forms;
using System.Drawing;

namespace Lab02
{
    partial class FormForSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьПанельИнструментовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSortCriteria = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSearchCriteria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.btnLoadFiles = new System.Windows.Forms.Button();
            this.dataGridResults = new System.Windows.Forms.DataGridView();
            this.btnSaveResults = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnSort = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnCombinedSearch = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblObjectCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.separator1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLastAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.separator2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.ForeColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.видToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(300, 37);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(682, 28);
            this.menuStrip1.TabIndex = 4;
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показатьПанельИнструментовToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // показатьПанельИнструментовToolStripMenuItem
            // 
            this.показатьПанельИнструментовToolStripMenuItem.Checked = true;
            this.показатьПанельИнструментовToolStripMenuItem.CheckOnClick = true;
            this.показатьПанельИнструментовToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.показатьПанельИнструментовToolStripMenuItem.Name = "показатьПанельИнструментовToolStripMenuItem";
            this.показатьПанельИнструментовToolStripMenuItem.Size = new System.Drawing.Size(312, 26);
            this.показатьПанельИнструментовToolStripMenuItem.Text = "Показать панель инструментов";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnLoadFiles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(300, 527);
            this.panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbSortCriteria);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.btnSort);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(10, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(280, 120);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сортировка";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Критерий:";
            // 
            // cmbSortCriteria
            // 
            this.cmbSortCriteria.BackColor = System.Drawing.Color.White;
            this.cmbSortCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortCriteria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSortCriteria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmbSortCriteria.Location = new System.Drawing.Point(15, 55);
            this.cmbSortCriteria.Name = "cmbSortCriteria";
            this.cmbSortCriteria.Size = new System.Drawing.Size(260, 28);
            this.cmbSortCriteria.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSearch.Location = new System.Drawing.Point(15, 85);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(125, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.Color.White;
            this.btnSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSort.Location = new System.Drawing.Point(150, 85);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(125, 30);
            this.btnSort.TabIndex = 3;
            this.btnSort.Text = "Сортировать";
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbSearchCriteria);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbSearchType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSearchValue);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(280, 220);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры поиска";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Критерий:";
            // 
            // cmbSearchCriteria
            // 
            this.cmbSearchCriteria.BackColor = System.Drawing.Color.White;
            this.cmbSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchCriteria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSearchCriteria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmbSearchCriteria.Location = new System.Drawing.Point(15, 55);
            this.cmbSearchCriteria.Name = "cmbSearchCriteria";
            this.cmbSearchCriteria.Size = new System.Drawing.Size(260, 28);
            this.cmbSearchCriteria.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип поиска:";
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.BackColor = System.Drawing.Color.White;
            this.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSearchType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmbSearchType.Location = new System.Drawing.Point(15, 115);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(260, 28);
            this.cmbSearchType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Значение:";
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.BackColor = System.Drawing.Color.White;
            this.txtSearchValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtSearchValue.Location = new System.Drawing.Point(15, 175);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(260, 27);
            this.txtSearchValue.TabIndex = 5;
            // 
            // btnLoadFiles
            // 
            this.btnLoadFiles.BackColor = System.Drawing.Color.White;
            this.btnLoadFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadFiles.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoadFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLoadFiles.Location = new System.Drawing.Point(25, 472);
            this.btnLoadFiles.Name = "btnLoadFiles";
            this.btnLoadFiles.Size = new System.Drawing.Size(260, 35);
            this.btnLoadFiles.TabIndex = 2;
            this.btnLoadFiles.Text = "Загрузить файлы";
            this.btnLoadFiles.UseVisualStyleBackColor = false;
            this.btnLoadFiles.Click += new System.EventHandler(this.btnLoadFiles_Click);
            // 
            // dataGridResults
            // 
            this.dataGridResults.AllowUserToAddRows = false;
            this.dataGridResults.AllowUserToDeleteRows = false;
            this.dataGridResults.BackgroundColor = System.Drawing.Color.White;
            this.dataGridResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridResults.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridResults.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dataGridResults.Location = new System.Drawing.Point(300, 64);
            this.dataGridResults.Name = "dataGridResults";
            this.dataGridResults.ReadOnly = true;
            this.dataGridResults.RowHeadersVisible = false;
            this.dataGridResults.RowHeadersWidth = 51;
            this.dataGridResults.Size = new System.Drawing.Size(682, 449);
            this.dataGridResults.TabIndex = 1;
            this.dataGridResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridResults_CellContentClick);
            // 
            // btnSaveResults
            // 
            this.btnSaveResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveResults.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSaveResults.ForeColor = System.Drawing.Color.White;
            this.btnSaveResults.Location = new System.Drawing.Point(300, 487);
            this.btnSaveResults.Name = "btnSaveResults";
            this.btnSaveResults.Size = new System.Drawing.Size(682, 40);
            this.btnSaveResults.TabIndex = 0;
            this.btnSaveResults.Text = "Сохранить результаты";
            this.btnSaveResults.UseVisualStyleBackColor = false;
            this.btnSaveResults.Click += new System.EventHandler(this.btnSaveResults_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnSearch,
            this.toolStripSeparator1,
            this.toolStripBtnSort,
            this.toolStripSeparator2,
            this.toolStripBtnClear,
            this.toolStripBtnDelete,
            this.toolStripSeparator3,
            this.toolStripBtnBack,
            this.toolStripBtnForward,
            this.toolStripBtnCombinedSearch});
            this.toolStrip.Location = new System.Drawing.Point(300, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(682, 37);
            this.toolStrip.TabIndex = 3;
            // 
            // toolStripBtnSearch
            // 
            this.toolStripBtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripBtnSearch.ForeColor = System.Drawing.Color.White;
            this.toolStripBtnSearch.Name = "toolStripBtnSearch";
            this.toolStripBtnSearch.Size = new System.Drawing.Size(56, 24);
            this.toolStripBtnSearch.Text = "Поиск";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripBtnSort
            // 
            this.toolStripBtnSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnSort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripBtnSort.ForeColor = System.Drawing.Color.White;
            this.toolStripBtnSort.Name = "toolStripBtnSort";
            this.toolStripBtnSort.Size = new System.Drawing.Size(96, 24);
            this.toolStripBtnSort.Text = "Сортировка";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripBtnClear
            // 
            this.toolStripBtnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripBtnClear.ForeColor = System.Drawing.Color.White;
            this.toolStripBtnClear.Name = "toolStripBtnClear";
            this.toolStripBtnClear.Size = new System.Drawing.Size(77, 24);
            this.toolStripBtnClear.Text = "Очистить";
            // 
            // toolStripBtnDelete
            // 
            this.toolStripBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripBtnDelete.ForeColor = System.Drawing.Color.White;
            this.toolStripBtnDelete.Name = "toolStripBtnDelete";
            this.toolStripBtnDelete.Size = new System.Drawing.Size(69, 24);
            this.toolStripBtnDelete.Text = "Удалить";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripBtnBack
            // 
            this.toolStripBtnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripBtnBack.ForeColor = System.Drawing.Color.White;
            this.toolStripBtnBack.Name = "toolStripBtnBack";
            this.toolStripBtnBack.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnBack.Text = "←";
            this.toolStripBtnBack.Click += new System.EventHandler(this.toolStripBtnBack_Click);
            // 
            // toolStripBtnForward
            // 
            this.toolStripBtnForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnForward.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripBtnForward.ForeColor = System.Drawing.Color.White;
            this.toolStripBtnForward.Name = "toolStripBtnForward";
            this.toolStripBtnForward.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnForward.Text = "→";
            this.toolStripBtnForward.Click += new System.EventHandler(this.toolStripBtnForward_Click);
            // 
            // toolStripBtnCombinedSearch
            // 
            this.toolStripBtnCombinedSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBtnCombinedSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripBtnCombinedSearch.ForeColor = System.Drawing.Color.White;
            this.toolStripBtnCombinedSearch.Name = "toolStripBtnCombinedSearch";
            this.toolStripBtnCombinedSearch.Size = new System.Drawing.Size(195, 24);
            this.toolStripBtnCombinedSearch.Text = "Комбинированный поиск";
            this.toolStripBtnCombinedSearch.ToolTipText = "Комбинированный поиск";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip.ForeColor = System.Drawing.Color.White;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblObjectCount,
            this.separator1,
            this.lblLastAction,
            this.separator2,
            this.lblDateTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 527);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(982, 26);
            this.statusStrip.TabIndex = 5;
            // 
            // lblObjectCount
            // 
            this.lblObjectCount.Name = "lblObjectCount";
            this.lblObjectCount.Size = new System.Drawing.Size(174, 20);
            this.lblObjectCount.Text = "Количество объектов: 0";
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(13, 20);
            this.separator1.Text = "|";
            // 
            // lblLastAction
            // 
            this.lblLastAction.Name = "lblLastAction";
            this.lblLastAction.Size = new System.Drawing.Size(165, 20);
            this.lblLastAction.Text = "Последнее действие: -";
            this.lblLastAction.Click += new System.EventHandler(this.lblLastAction_Click);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(13, 20);
            this.separator2.Text = "|";
            // 
            // lblDateTime
            // 
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(109, 20);
            this.lblDateTime.Text = "Дата и время: ";
            // 
            // FormForSearch
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.btnSaveResults);
            this.Controls.Add(this.dataGridResults);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "FormForSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск и сортировка студентов";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSearchCriteria;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbSortCriteria;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.DataGridView dataGridResults;
        private System.Windows.Forms.Button btnSaveResults;
        private System.Windows.Forms.Button btnLoadFiles;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripBtnSearch;
        private System.Windows.Forms.ToolStripButton toolStripBtnSort;
        private System.Windows.Forms.ToolStripButton toolStripBtnClear;
        private System.Windows.Forms.ToolStripButton toolStripBtnDelete;
        private System.Windows.Forms.ToolStripButton toolStripBtnBack;
        private System.Windows.Forms.ToolStripButton toolStripBtnForward;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripBtnCombinedSearch;
        private System.Windows.Forms.ToolStripMenuItem показатьПанельИнструментовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblObjectCount;
        private System.Windows.Forms.ToolStripStatusLabel lblLastAction;
        private System.Windows.Forms.ToolStripStatusLabel lblDateTime;
        private System.Windows.Forms.ToolStripStatusLabel separator1;
        private System.Windows.Forms.ToolStripStatusLabel separator2;
    }
}