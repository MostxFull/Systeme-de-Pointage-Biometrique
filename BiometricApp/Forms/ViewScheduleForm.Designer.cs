namespace HRSchedulingSystem.Forms
{
    partial class ViewScheduleForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvSchedule = new DataGridView();
            cmbEmployee = new ComboBox();
            dtpWeekStart = new DateTimePicker();
            btnViewSchedule = new Button();
            btnPreviousWeek = new Button();
            btnNextWeek = new Button();
            btnCurrentWeek = new Button();
            btnExport = new Button();
            lblEmployee = new Label();
            lblWeekStart = new Label();
            lblEmployeeInfo = new Label();
            groupBoxFilters = new GroupBox();
            groupBoxSchedule = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            groupBoxFilters.SuspendLayout();
            groupBoxSchedule.SuspendLayout();
            SuspendLayout();
            // 
            // dgvSchedule
            // 
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.AllowUserToDeleteRows = false;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.BackgroundColor = Color.White;
            dgvSchedule.BorderStyle = BorderStyle.None;
            dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedule.Font = new Font("Segoe UI", 9F);
            dgvSchedule.GridColor = Color.FromArgb(189, 195, 199);
            dgvSchedule.Location = new Point(20, 50);
            dgvSchedule.MultiSelect = false;
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.ReadOnly = true;
            dgvSchedule.RowHeadersWidth = 51;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.Size = new Size(860, 330);
            dgvSchedule.TabIndex = 1;
            // 
            // cmbEmployee
            // 
            cmbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployee.Font = new Font("Segoe UI", 9F);
            cmbEmployee.FormattingEnabled = true;
            cmbEmployee.Location = new Point(90, 32);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(200, 23);
            cmbEmployee.TabIndex = 1;
            // 
            // dtpWeekStart
            // 
            dtpWeekStart.Font = new Font("Segoe UI", 9F);
            dtpWeekStart.Format = DateTimePickerFormat.Short;
            dtpWeekStart.Location = new Point(410, 32);
            dtpWeekStart.Name = "dtpWeekStart";
            dtpWeekStart.Size = new Size(126, 23);
            dtpWeekStart.TabIndex = 3;
            // 
            // btnViewSchedule
            // 
            btnViewSchedule.BackColor = Color.FromArgb(52, 152, 219);
            btnViewSchedule.FlatAppearance.BorderSize = 0;
            btnViewSchedule.FlatStyle = FlatStyle.Flat;
            btnViewSchedule.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnViewSchedule.ForeColor = Color.White;
            btnViewSchedule.Location = new Point(550, 32);
            btnViewSchedule.Name = "btnViewSchedule";
            btnViewSchedule.Size = new Size(100, 30);
            btnViewSchedule.TabIndex = 4;
            btnViewSchedule.Text = "Voir Planning";
            btnViewSchedule.UseVisualStyleBackColor = false;
            btnViewSchedule.Click += btnViewSchedule_Click;
            // 
            // btnPreviousWeek
            // 
            btnPreviousWeek.BackColor = Color.FromArgb(149, 165, 166);
            btnPreviousWeek.FlatAppearance.BorderSize = 0;
            btnPreviousWeek.FlatStyle = FlatStyle.Flat;
            btnPreviousWeek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPreviousWeek.ForeColor = Color.White;
            btnPreviousWeek.Location = new Point(410, 61);
            btnPreviousWeek.Name = "btnPreviousWeek";
            btnPreviousWeek.Size = new Size(25, 25);
            btnPreviousWeek.TabIndex = 5;
            btnPreviousWeek.Text = "< Précédent";
            btnPreviousWeek.UseVisualStyleBackColor = true;
            btnPreviousWeek.Click += btnPreviousWeek_Click;
            // 
            // btnNextWeek
            // 
            btnNextWeek.BackColor = Color.FromArgb(149, 165, 166);
            btnNextWeek.FlatAppearance.BorderSize = 0;
            btnNextWeek.FlatStyle = FlatStyle.Flat;
            btnNextWeek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNextWeek.ForeColor = Color.White;
            btnNextWeek.Location = new Point(511, 61);
            btnNextWeek.Name = "btnNextWeek";
            btnNextWeek.Size = new Size(25, 25);
            btnNextWeek.TabIndex = 6;
            btnNextWeek.Text = ">";
            btnNextWeek.UseVisualStyleBackColor = true;
            btnNextWeek.Click += btnNextWeek_Click;
            // 
            // btnCurrentWeek
            // 
            btnCurrentWeek.BackColor = Color.FromArgb(149, 165, 166);
            btnCurrentWeek.FlatAppearance.BorderSize = 0;
            btnCurrentWeek.FlatStyle = FlatStyle.Flat;
            btnCurrentWeek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCurrentWeek.ForeColor = Color.White;
            btnCurrentWeek.Location = new Point(441, 61);
            btnCurrentWeek.Name = "btnCurrentWeek";
            btnCurrentWeek.Size = new Size(64, 25);
            btnCurrentWeek.TabIndex = 7;
            btnCurrentWeek.Text = "Semaine actuelle";
            btnCurrentWeek.UseVisualStyleBackColor = true;
            btnCurrentWeek.Click += btnCurrentWeek_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(46, 204, 113);
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(670, 32);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(90, 30);
            btnExport.TabIndex = 8;
            btnExport.Text = "Exporter CSV";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Font = new Font("Segoe UI", 9F);
            lblEmployee.ForeColor = Color.FromArgb(64, 64, 64);
            lblEmployee.Location = new Point(20, 35);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(56, 15);
            lblEmployee.TabIndex = 0;
            lblEmployee.Text = "Employé:";
            // 
            // lblWeekStart
            // 
            lblWeekStart.AutoSize = true;
            lblWeekStart.Font = new Font("Segoe UI", 9F);
            lblWeekStart.ForeColor = Color.FromArgb(64, 64, 64);
            lblWeekStart.Location = new Point(310, 35);
            lblWeekStart.Name = "lblWeekStart";
            lblWeekStart.Size = new Size(89, 15);
            lblWeekStart.TabIndex = 2;
            lblWeekStart.Text = "Début semaine:";
            // 
            // lblEmployeeInfo
            // 
            lblEmployeeInfo.AutoSize = true;
            lblEmployeeInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmployeeInfo.ForeColor = Color.FromArgb(64, 64, 64);
            lblEmployeeInfo.Location = new Point(20, 25);
            lblEmployeeInfo.Name = "lblEmployeeInfo";
            lblEmployeeInfo.Size = new Size(263, 15);
            lblEmployeeInfo.TabIndex = 0;
            lblEmployeeInfo.Text = "Sélectionner un employé pour voir le planning";
            // 
            // groupBoxFilters
            // 
            groupBoxFilters.Controls.Add(btnExport);
            groupBoxFilters.Controls.Add(btnNextWeek);
            groupBoxFilters.Controls.Add(btnPreviousWeek);
            groupBoxFilters.Controls.Add(btnCurrentWeek);
            groupBoxFilters.Controls.Add(btnViewSchedule);
            groupBoxFilters.Controls.Add(dtpWeekStart);
            groupBoxFilters.Controls.Add(lblWeekStart);
            groupBoxFilters.Controls.Add(cmbEmployee);
            groupBoxFilters.Controls.Add(lblEmployee);
            groupBoxFilters.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxFilters.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxFilters.Location = new Point(15, 15);
            groupBoxFilters.Name = "groupBoxFilters";
            groupBoxFilters.Padding = new Padding(10);
            groupBoxFilters.Size = new Size(900, 99);
            groupBoxFilters.TabIndex = 0;
            groupBoxFilters.TabStop = false;
            groupBoxFilters.Text = "Filtres de Planning";
            // 
            // groupBoxSchedule
            // 
            groupBoxSchedule.Controls.Add(dgvSchedule);
            groupBoxSchedule.Controls.Add(lblEmployeeInfo);
            groupBoxSchedule.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxSchedule.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxSchedule.Location = new Point(15, 120);
            groupBoxSchedule.Name = "groupBoxSchedule";
            groupBoxSchedule.Padding = new Padding(10);
            groupBoxSchedule.Size = new Size(900, 385);
            groupBoxSchedule.TabIndex = 1;
            groupBoxSchedule.TabStop = false;
            groupBoxSchedule.Text = "Planning de l'Employé";
            // 
            // ViewScheduleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(930, 520);
            Controls.Add(groupBoxSchedule);
            Controls.Add(groupBoxFilters);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ViewScheduleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Visualiseur de Planning - HR Scheduling System";
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            groupBoxFilters.ResumeLayout(false);
            groupBoxFilters.PerformLayout();
            groupBoxSchedule.ResumeLayout(false);
            groupBoxSchedule.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.DateTimePicker dtpWeekStart;
        private System.Windows.Forms.Button btnViewSchedule;
        private System.Windows.Forms.Button btnPreviousWeek;
        private System.Windows.Forms.Button btnNextWeek;
        private System.Windows.Forms.Button btnCurrentWeek;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblWeekStart;
        private System.Windows.Forms.Label lblEmployeeInfo;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.GroupBox groupBoxSchedule;
    }
}
