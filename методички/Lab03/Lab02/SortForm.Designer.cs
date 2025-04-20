namespace Lab02
{
    partial class SortForm
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
            this.components = new System.ComponentModel.Container();
            this.lblSortField = new System.Windows.Forms.Label();
            this.cmbSortField = new System.Windows.Forms.ComboBox();
            this.lblSortOrder = new System.Windows.Forms.Label();
            this.cmbSortOrder = new System.Windows.Forms.ComboBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSortField
            // 
            this.lblSortField.AutoSize = true;
            this.lblSortField.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblSortField.Location = new System.Drawing.Point(20, 70);
            this.lblSortField.Name = "lblSortField";
            this.lblSortField.Size = new System.Drawing.Size(150, 15);
            this.lblSortField.TabIndex = 0;
            this.lblSortField.Text = "Поле для сортировки:";
            // 
            // cmbSortField
            // 
            this.cmbSortField.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.cmbSortField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSortField.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.cmbSortField.ForeColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.cmbSortField.Location = new System.Drawing.Point(20, 90);
            this.cmbSortField.Name = "cmbSortField";
            this.cmbSortField.Size = new System.Drawing.Size(340, 23);
            this.cmbSortField.TabIndex = 1;
            // 
            // lblSortOrder
            // 
            this.lblSortOrder.AutoSize = true;
            this.lblSortOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblSortOrder.ForeColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.lblSortOrder.Location = new System.Drawing.Point(20, 130);
            this.lblSortOrder.Name = "lblSortOrder";
            this.lblSortOrder.Size = new System.Drawing.Size(150, 15);
            this.lblSortOrder.TabIndex = 2;
            this.lblSortOrder.Text = "Порядок сортировки:";
            // 
            // cmbSortOrder
            // 
            this.cmbSortOrder.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.cmbSortOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSortOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.cmbSortOrder.ForeColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.cmbSortOrder.Location = new System.Drawing.Point(20, 150);
            this.cmbSortOrder.Name = "cmbSortOrder";
            this.cmbSortOrder.Size = new System.Drawing.Size(340, 23);
            this.cmbSortOrder.TabIndex = 3;
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnSort.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnSort.ForeColor = System.Drawing.Color.White;
            this.btnSort.Location = new System.Drawing.Point(20, 190);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(160, 30);
            this.btnSort.TabIndex = 4;
            this.btnSort.Text = "Сортировать";
            this.btnSort.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.btnCancel.Location = new System.Drawing.Point(200, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 40);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сортировка";
            // 
            // SortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 240);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.cmbSortOrder);
            this.Controls.Add(this.lblSortOrder);
            this.Controls.Add(this.cmbSortField);
            this.Controls.Add(this.lblSortField);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.ForeColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SortForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Сортировка";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSortField;
        private System.Windows.Forms.ComboBox cmbSortField;
        private System.Windows.Forms.Label lblSortOrder;
        private System.Windows.Forms.ComboBox cmbSortOrder;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
} 