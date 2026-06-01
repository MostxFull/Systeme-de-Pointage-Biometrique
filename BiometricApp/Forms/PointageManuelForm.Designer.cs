namespace HRSchedulingSystem.Forms
{
    partial class PointageManuelForm
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
            groupBoxFilters = new GroupBox();
            lblFilterService = new Label();
            cmbFilterService = new ComboBox();
            btnExport = new Button();
            btnClearFilters = new Button();
            btnApplyFilters = new Button();
            lblFilterEnd = new Label();
            lblFilterStart = new Label();
            lblFilterType = new Label();
            lblFilterEmployee = new Label();
            lblFilterSociete = new Label();
            chkFilterByDate = new CheckBox();
            dtpFilterEnd = new DateTimePicker();
            dtpFilterStart = new DateTimePicker();
            cmbFilterType = new ComboBox();
            cmbFilterEmployee = new ComboBox();
            cmbFilterSociete = new ComboBox();
            groupBoxList = new GroupBox();
            dgvPointages = new DataGridView();
            groupBoxDetails = new GroupBox();
            lblPointeuse = new Label();
            lblHeure = new Label();
            lblDate = new Label();
            lblType = new Label();
            lblEmployee = new Label();
            lblService = new Label();
            lblDepartement = new Label();
            lblSociete = new Label();
            btnDelete = new Button();
            btnSave = new Button();
            btnNew = new Button();
            cmbPointeuse = new ComboBox();
            dtpHeure = new DateTimePicker();
            dtpDate = new DateTimePicker();
            cmbType = new ComboBox();
            cmbEmployee = new ComboBox();
            cmbService = new ComboBox();
            cmbDepartement = new ComboBox();
            cmbSociete = new ComboBox();
            groupBoxFilters.SuspendLayout();
            groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPointages).BeginInit();
            groupBoxDetails.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxFilters
            // 
            groupBoxFilters.Controls.Add(lblFilterService);
            groupBoxFilters.Controls.Add(cmbFilterService);
            groupBoxFilters.Controls.Add(btnExport);
            groupBoxFilters.Controls.Add(btnClearFilters);
            groupBoxFilters.Controls.Add(btnApplyFilters);
            groupBoxFilters.Controls.Add(lblFilterEnd);
            groupBoxFilters.Controls.Add(lblFilterStart);
            groupBoxFilters.Controls.Add(lblFilterType);
            groupBoxFilters.Controls.Add(lblFilterEmployee);
            groupBoxFilters.Controls.Add(lblFilterSociete);
            groupBoxFilters.Controls.Add(chkFilterByDate);
            groupBoxFilters.Controls.Add(dtpFilterEnd);
            groupBoxFilters.Controls.Add(dtpFilterStart);
            groupBoxFilters.Controls.Add(cmbFilterType);
            groupBoxFilters.Controls.Add(cmbFilterEmployee);
            groupBoxFilters.Controls.Add(cmbFilterSociete);
            groupBoxFilters.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxFilters.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxFilters.Location = new Point(15, 15);
            groupBoxFilters.Name = "groupBoxFilters";
            groupBoxFilters.Padding = new Padding(10);
            groupBoxFilters.Size = new Size(1200, 110);
            groupBoxFilters.TabIndex = 0;
            groupBoxFilters.TabStop = false;
            groupBoxFilters.Text = "Filtres";
            groupBoxFilters.Enter += groupBoxFilters_Enter;
            // 
            // lblFilterService
            // 
            lblFilterService.AutoSize = true;
            lblFilterService.Font = new Font("Segoe UI", 9F);
            lblFilterService.ForeColor = Color.FromArgb(64, 64, 64);
            lblFilterService.Location = new Point(254, 30);
            lblFilterService.Name = "lblFilterService";
            lblFilterService.Size = new Size(47, 15);
            lblFilterService.TabIndex = 14;
            lblFilterService.Text = "Service:";
            // 
            // cmbFilterService
            // 
            cmbFilterService.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterService.Font = new Font("Segoe UI", 9F);
            cmbFilterService.FormattingEnabled = true;
            cmbFilterService.Location = new Point(304, 27);
            cmbFilterService.Name = "cmbFilterService";
            cmbFilterService.Size = new Size(116, 23);
            cmbFilterService.TabIndex = 15;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(46, 204, 113);
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(1100, 27);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(90, 35);
            btnExport.TabIndex = 13;
            btnExport.Text = "Exporter";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnClearFilters
            // 
            btnClearFilters.BackColor = Color.FromArgb(149, 165, 166);
            btnClearFilters.FlatAppearance.BorderSize = 0;
            btnClearFilters.FlatStyle = FlatStyle.Flat;
            btnClearFilters.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearFilters.ForeColor = Color.White;
            btnClearFilters.Location = new Point(1000, 27);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(90, 35);
            btnClearFilters.TabIndex = 12;
            btnClearFilters.Text = "Effacer";
            btnClearFilters.UseVisualStyleBackColor = false;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // btnApplyFilters
            // 
            btnApplyFilters.BackColor = Color.FromArgb(52, 152, 219);
            btnApplyFilters.FlatAppearance.BorderSize = 0;
            btnApplyFilters.FlatStyle = FlatStyle.Flat;
            btnApplyFilters.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnApplyFilters.ForeColor = Color.White;
            btnApplyFilters.Location = new Point(900, 27);
            btnApplyFilters.Name = "btnApplyFilters";
            btnApplyFilters.Size = new Size(90, 35);
            btnApplyFilters.TabIndex = 11;
            btnApplyFilters.Text = "Appliquer";
            btnApplyFilters.UseVisualStyleBackColor = false;
            btnApplyFilters.Click += btnApplyFilters_Click;
            // 
            // lblFilterEnd
            // 
            lblFilterEnd.AutoSize = true;
            lblFilterEnd.Font = new Font("Segoe UI", 9F);
            lblFilterEnd.ForeColor = Color.FromArgb(64, 64, 64);
            lblFilterEnd.Location = new Point(290, 62);
            lblFilterEnd.Name = "lblFilterEnd";
            lblFilterEnd.Size = new Size(25, 15);
            lblFilterEnd.TabIndex = 9;
            lblFilterEnd.Text = "Au:";
            // 
            // lblFilterStart
            // 
            lblFilterStart.AutoSize = true;
            lblFilterStart.Font = new Font("Segoe UI", 9F);
            lblFilterStart.ForeColor = Color.FromArgb(64, 64, 64);
            lblFilterStart.Location = new Point(140, 62);
            lblFilterStart.Name = "lblFilterStart";
            lblFilterStart.Size = new Size(25, 15);
            lblFilterStart.TabIndex = 7;
            lblFilterStart.Text = "Du:";
            // 
            // lblFilterType
            // 
            lblFilterType.AutoSize = true;
            lblFilterType.Font = new Font("Segoe UI", 9F);
            lblFilterType.ForeColor = Color.FromArgb(64, 64, 64);
            lblFilterType.Location = new Point(670, 32);
            lblFilterType.Name = "lblFilterType";
            lblFilterType.Size = new Size(34, 15);
            lblFilterType.TabIndex = 4;
            lblFilterType.Text = "Type:";
            // 
            // lblFilterEmployee
            // 
            lblFilterEmployee.AutoSize = true;
            lblFilterEmployee.Font = new Font("Segoe UI", 9F);
            lblFilterEmployee.ForeColor = Color.FromArgb(64, 64, 64);
            lblFilterEmployee.Location = new Point(440, 30);
            lblFilterEmployee.Name = "lblFilterEmployee";
            lblFilterEmployee.Size = new Size(56, 15);
            lblFilterEmployee.TabIndex = 2;
            lblFilterEmployee.Text = "Employé:";
            // 
            // lblFilterSociete
            // 
            lblFilterSociete.AutoSize = true;
            lblFilterSociete.Font = new Font("Segoe UI", 9F);
            lblFilterSociete.ForeColor = Color.FromArgb(64, 64, 64);
            lblFilterSociete.Location = new Point(20, 30);
            lblFilterSociete.Name = "lblFilterSociete";
            lblFilterSociete.Size = new Size(48, 15);
            lblFilterSociete.TabIndex = 0;
            lblFilterSociete.Text = "Société:";
            // 
            // chkFilterByDate
            // 
            chkFilterByDate.AutoSize = true;
            chkFilterByDate.Font = new Font("Segoe UI", 9F);
            chkFilterByDate.ForeColor = Color.FromArgb(64, 64, 64);
            chkFilterByDate.Location = new Point(20, 60);
            chkFilterByDate.Name = "chkFilterByDate";
            chkFilterByDate.Size = new Size(102, 19);
            chkFilterByDate.TabIndex = 6;
            chkFilterByDate.Text = "Filtrer par date";
            chkFilterByDate.UseVisualStyleBackColor = true;
            chkFilterByDate.CheckedChanged += chkFilterByDate_CheckedChanged;
            // 
            // dtpFilterEnd
            // 
            dtpFilterEnd.Enabled = false;
            dtpFilterEnd.Font = new Font("Segoe UI", 9F);
            dtpFilterEnd.Format = DateTimePickerFormat.Short;
            dtpFilterEnd.Location = new Point(320, 59);
            dtpFilterEnd.Name = "dtpFilterEnd";
            dtpFilterEnd.Size = new Size(100, 23);
            dtpFilterEnd.TabIndex = 10;
            // 
            // dtpFilterStart
            // 
            dtpFilterStart.Enabled = false;
            dtpFilterStart.Font = new Font("Segoe UI", 9F);
            dtpFilterStart.Format = DateTimePickerFormat.Short;
            dtpFilterStart.Location = new Point(170, 59);
            dtpFilterStart.Name = "dtpFilterStart";
            dtpFilterStart.Size = new Size(100, 23);
            dtpFilterStart.TabIndex = 8;
            // 
            // cmbFilterType
            // 
            cmbFilterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterType.Font = new Font("Segoe UI", 9F);
            cmbFilterType.FormattingEnabled = true;
            cmbFilterType.Location = new Point(710, 29);
            cmbFilterType.Name = "cmbFilterType";
            cmbFilterType.Size = new Size(137, 23);
            cmbFilterType.TabIndex = 5;
            // 
            // cmbFilterEmployee
            // 
            cmbFilterEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterEmployee.Font = new Font("Segoe UI", 9F);
            cmbFilterEmployee.FormattingEnabled = true;
            cmbFilterEmployee.Location = new Point(510, 27);
            cmbFilterEmployee.Name = "cmbFilterEmployee";
            cmbFilterEmployee.Size = new Size(150, 23);
            cmbFilterEmployee.TabIndex = 3;
            // 
            // cmbFilterSociete
            // 
            cmbFilterSociete.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterSociete.Font = new Font("Segoe UI", 9F);
            cmbFilterSociete.FormattingEnabled = true;
            cmbFilterSociete.Location = new Point(80, 27);
            cmbFilterSociete.Name = "cmbFilterSociete";
            cmbFilterSociete.Size = new Size(150, 23);
            cmbFilterSociete.TabIndex = 1;
            // 
            // groupBoxList
            // 
            groupBoxList.Controls.Add(dgvPointages);
            groupBoxList.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxList.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxList.Location = new Point(15, 135);
            groupBoxList.Name = "groupBoxList";
            groupBoxList.Padding = new Padding(10);
            groupBoxList.Size = new Size(1200, 350);
            groupBoxList.TabIndex = 1;
            groupBoxList.TabStop = false;
            groupBoxList.Text = "Liste des Pointages";
            // 
            // dgvPointages
            // 
            dgvPointages.AllowUserToAddRows = false;
            dgvPointages.AllowUserToDeleteRows = false;
            dgvPointages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPointages.BackgroundColor = SystemColors.Window;
            dgvPointages.BorderStyle = BorderStyle.None;
            dgvPointages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPointages.Dock = DockStyle.Fill;
            dgvPointages.Font = new Font("Segoe UI", 9F);
            dgvPointages.GridColor = Color.FromArgb(189, 195, 199);
            dgvPointages.Location = new Point(10, 26);
            dgvPointages.MultiSelect = false;
            dgvPointages.Name = "dgvPointages";
            dgvPointages.ReadOnly = true;
            dgvPointages.RowHeadersWidth = 51;
            dgvPointages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPointages.Size = new Size(1180, 314);
            dgvPointages.TabIndex = 0;
            dgvPointages.SelectionChanged += dgvPointages_SelectionChanged;
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Controls.Add(lblPointeuse);
            groupBoxDetails.Controls.Add(lblHeure);
            groupBoxDetails.Controls.Add(lblDate);
            groupBoxDetails.Controls.Add(lblType);
            groupBoxDetails.Controls.Add(lblEmployee);
            groupBoxDetails.Controls.Add(lblService);
            groupBoxDetails.Controls.Add(lblDepartement);
            groupBoxDetails.Controls.Add(lblSociete);
            groupBoxDetails.Controls.Add(btnDelete);
            groupBoxDetails.Controls.Add(btnSave);
            groupBoxDetails.Controls.Add(btnNew);
            groupBoxDetails.Controls.Add(cmbPointeuse);
            groupBoxDetails.Controls.Add(dtpHeure);
            groupBoxDetails.Controls.Add(dtpDate);
            groupBoxDetails.Controls.Add(cmbType);
            groupBoxDetails.Controls.Add(cmbEmployee);
            groupBoxDetails.Controls.Add(cmbService);
            groupBoxDetails.Controls.Add(cmbDepartement);
            groupBoxDetails.Controls.Add(cmbSociete);
            groupBoxDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxDetails.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxDetails.Location = new Point(15, 495);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Padding = new Padding(10);
            groupBoxDetails.Size = new Size(1200, 140);
            groupBoxDetails.TabIndex = 2;
            groupBoxDetails.TabStop = false;
            groupBoxDetails.Text = "Détails du Pointage";
            // 
            // lblPointeuse
            // 
            lblPointeuse.AutoSize = true;
            lblPointeuse.Font = new Font("Segoe UI", 9F);
            lblPointeuse.ForeColor = Color.FromArgb(64, 64, 64);
            lblPointeuse.Location = new Point(650, 75);
            lblPointeuse.Name = "lblPointeuse";
            lblPointeuse.Size = new Size(62, 15);
            lblPointeuse.TabIndex = 14;
            lblPointeuse.Text = "Pointeuse:";
            // 
            // lblHeure
            // 
            lblHeure.AutoSize = true;
            lblHeure.Font = new Font("Segoe UI", 9F);
            lblHeure.ForeColor = Color.FromArgb(64, 64, 64);
            lblHeure.Location = new Point(460, 75);
            lblHeure.Name = "lblHeure";
            lblHeure.Size = new Size(42, 15);
            lblHeure.TabIndex = 12;
            lblHeure.Text = "Heure:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 9F);
            lblDate.ForeColor = Color.FromArgb(64, 64, 64);
            lblDate.Location = new Point(270, 75);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(34, 15);
            lblDate.TabIndex = 10;
            lblDate.Text = "Date:";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 9F);
            lblType.ForeColor = Color.FromArgb(64, 64, 64);
            lblType.Location = new Point(20, 75);
            lblType.Name = "lblType";
            lblType.Size = new Size(34, 15);
            lblType.TabIndex = 8;
            lblType.Text = "Type:";
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Font = new Font("Segoe UI", 9F);
            lblEmployee.ForeColor = Color.FromArgb(64, 64, 64);
            lblEmployee.Location = new Point(760, 35);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(56, 15);
            lblEmployee.TabIndex = 6;
            lblEmployee.Text = "Employé:";
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Font = new Font("Segoe UI", 9F);
            lblService.ForeColor = Color.FromArgb(64, 64, 64);
            lblService.Location = new Point(530, 35);
            lblService.Name = "lblService";
            lblService.Size = new Size(47, 15);
            lblService.TabIndex = 4;
            lblService.Text = "Service:";
            // 
            // lblDepartement
            // 
            lblDepartement.AutoSize = true;
            lblDepartement.Font = new Font("Segoe UI", 9F);
            lblDepartement.ForeColor = Color.FromArgb(64, 64, 64);
            lblDepartement.Location = new Point(270, 35);
            lblDepartement.Name = "lblDepartement";
            lblDepartement.Size = new Size(79, 15);
            lblDepartement.TabIndex = 2;
            lblDepartement.Text = "Département:";
            // 
            // lblSociete
            // 
            lblSociete.AutoSize = true;
            lblSociete.Font = new Font("Segoe UI", 9F);
            lblSociete.ForeColor = Color.FromArgb(64, 64, 64);
            lblSociete.Location = new Point(20, 35);
            lblSociete.Name = "lblSociete";
            lblSociete.Size = new Size(48, 15);
            lblSociete.TabIndex = 0;
            lblSociete.Text = "Société:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(1090, 72);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 35);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Supprimer";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(1090, 32);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 35);
            btnSave.TabIndex = 17;
            btnSave.Text = "Enregistrer";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(149, 165, 166);
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(1000, 32);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(80, 35);
            btnNew.TabIndex = 16;
            btnNew.Text = "Nouveau";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // cmbPointeuse
            // 
            cmbPointeuse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPointeuse.Font = new Font("Segoe UI", 9F);
            cmbPointeuse.FormattingEnabled = true;
            cmbPointeuse.Location = new Point(720, 72);
            cmbPointeuse.Name = "cmbPointeuse";
            cmbPointeuse.Size = new Size(150, 23);
            cmbPointeuse.TabIndex = 15;
            // 
            // dtpHeure
            // 
            dtpHeure.Font = new Font("Segoe UI", 9F);
            dtpHeure.Format = DateTimePickerFormat.Time;
            dtpHeure.Location = new Point(510, 72);
            dtpHeure.Name = "dtpHeure";
            dtpHeure.ShowUpDown = true;
            dtpHeure.Size = new Size(120, 23);
            dtpHeure.TabIndex = 13;
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Segoe UI", 9F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(320, 72);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(120, 23);
            dtpDate.TabIndex = 11;
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Font = new Font("Segoe UI", 9F);
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(100, 72);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(150, 23);
            cmbType.TabIndex = 9;
            // 
            // cmbEmployee
            // 
            cmbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployee.Font = new Font("Segoe UI", 9F);
            cmbEmployee.FormattingEnabled = true;
            cmbEmployee.Location = new Point(830, 32);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(150, 23);
            cmbEmployee.TabIndex = 7;
            // 
            // cmbService
            // 
            cmbService.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbService.Font = new Font("Segoe UI", 9F);
            cmbService.FormattingEnabled = true;
            cmbService.Location = new Point(590, 32);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(150, 23);
            cmbService.TabIndex = 5;
            cmbService.SelectedIndexChanged += cmbService_SelectedIndexChanged;
            // 
            // cmbDepartement
            // 
            cmbDepartement.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartement.Font = new Font("Segoe UI", 9F);
            cmbDepartement.FormattingEnabled = true;
            cmbDepartement.Location = new Point(360, 32);
            cmbDepartement.Name = "cmbDepartement";
            cmbDepartement.Size = new Size(150, 23);
            cmbDepartement.TabIndex = 3;
            cmbDepartement.SelectedIndexChanged += cmbDepartement_SelectedIndexChanged;
            // 
            // cmbSociete
            // 
            cmbSociete.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSociete.Font = new Font("Segoe UI", 9F);
            cmbSociete.FormattingEnabled = true;
            cmbSociete.Location = new Point(100, 32);
            cmbSociete.Name = "cmbSociete";
            cmbSociete.Size = new Size(150, 23);
            cmbSociete.TabIndex = 1;
            cmbSociete.SelectedIndexChanged += cmbSociete_SelectedIndexChanged;
            // 
            // PointageManuelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1230, 650);
            Controls.Add(groupBoxDetails);
            Controls.Add(groupBoxList);
            Controls.Add(groupBoxFilters);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "PointageManuelForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion des Pointages Manuels - HR Scheduling System";
            groupBoxFilters.ResumeLayout(false);
            groupBoxFilters.PerformLayout();
            groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPointages).EndInit();
            groupBoxDetails.ResumeLayout(false);
            groupBoxDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.ComboBox cmbFilterSociete;
        private System.Windows.Forms.ComboBox cmbFilterEmployee;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.DateTimePicker dtpFilterStart;
        private System.Windows.Forms.DateTimePicker dtpFilterEnd;
        private System.Windows.Forms.CheckBox chkFilterByDate;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblFilterSociete;
        private System.Windows.Forms.Label lblFilterEmployee;
        private System.Windows.Forms.Label lblFilterType;
        private System.Windows.Forms.Label lblFilterStart;
        private System.Windows.Forms.Label lblFilterEnd;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView dgvPointages;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.ComboBox cmbSociete;
        private System.Windows.Forms.ComboBox cmbDepartement;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpHeure;
        private System.Windows.Forms.ComboBox cmbPointeuse;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblSociete;
        private System.Windows.Forms.Label lblDepartement;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblHeure;
        private System.Windows.Forms.Label lblPointeuse;
        private System.Windows.Forms.Label lblFilterService;
        private System.Windows.Forms.ComboBox cmbFilterService;
    }
}
