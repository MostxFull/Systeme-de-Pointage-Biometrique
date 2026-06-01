namespace HRSchedulingSystem.Forms
{
    partial class AbsenceForm
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
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.cmbFilterSociete = new System.Windows.Forms.ComboBox();
            this.cmbFilterEmployee = new System.Windows.Forms.ComboBox();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.dtpFilterStart = new System.Windows.Forms.DateTimePicker();
            this.dtpFilterEnd = new System.Windows.Forms.DateTimePicker();
            this.chkFilterByDate = new System.Windows.Forms.CheckBox();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblFilterSociete = new System.Windows.Forms.Label();
            this.lblFilterEmployee = new System.Windows.Forms.Label();
            this.lblFilterType = new System.Windows.Forms.Label();
            this.lblFilterStart = new System.Windows.Forms.Label();
            this.lblFilterEnd = new System.Windows.Forms.Label();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.dgvAbsences = new System.Windows.Forms.DataGridView();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.cmbSociete = new System.Windows.Forms.ComboBox();
            this.cmbDepartement = new System.Windows.Forms.ComboBox();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.cmbTypeAbsence = new System.Windows.Forms.ComboBox();
            this.dtpDateDebut = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblSociete = new System.Windows.Forms.Label();
            this.lblDepartement = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblTypeAbsence = new System.Windows.Forms.Label();
            this.lblDateDebut = new System.Windows.Forms.Label();
            this.lblDateFin = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.groupBoxFilters.SuspendLayout();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsences)).BeginInit();
            this.groupBoxDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.btnExport);
            this.groupBoxFilters.Controls.Add(this.btnClearFilters);
            this.groupBoxFilters.Controls.Add(this.btnApplyFilters);
            this.groupBoxFilters.Controls.Add(this.lblFilterEnd);
            this.groupBoxFilters.Controls.Add(this.lblFilterStart);
            this.groupBoxFilters.Controls.Add(this.lblFilterType);
            this.groupBoxFilters.Controls.Add(this.lblFilterEmployee);
            this.groupBoxFilters.Controls.Add(this.lblFilterSociete);
            this.groupBoxFilters.Controls.Add(this.chkFilterByDate);
            this.groupBoxFilters.Controls.Add(this.dtpFilterEnd);
            this.groupBoxFilters.Controls.Add(this.dtpFilterStart);
            this.groupBoxFilters.Controls.Add(this.cmbFilterType);
            this.groupBoxFilters.Controls.Add(this.cmbFilterEmployee);
            this.groupBoxFilters.Controls.Add(this.cmbFilterSociete);
            this.groupBoxFilters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxFilters.Location = new System.Drawing.Point(15, 15);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxFilters.Size = new System.Drawing.Size(1200, 110);
            this.groupBoxFilters.TabIndex = 0;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filtres";
            // 
            // lblFilterSociete
            // 
            this.lblFilterSociete.AutoSize = true;
            this.lblFilterSociete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterSociete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFilterSociete.Location = new System.Drawing.Point(20, 30);
            this.lblFilterSociete.Name = "lblFilterSociete";
            this.lblFilterSociete.Size = new System.Drawing.Size(50, 15);
            this.lblFilterSociete.TabIndex = 0;
            this.lblFilterSociete.Text = "Société:";
            // 
            // cmbFilterSociete
            // 
            this.cmbFilterSociete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterSociete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilterSociete.FormattingEnabled = true;
            this.cmbFilterSociete.Location = new System.Drawing.Point(80, 27);
            this.cmbFilterSociete.Name = "cmbFilterSociete";
            this.cmbFilterSociete.Size = new System.Drawing.Size(150, 23);
            this.cmbFilterSociete.TabIndex = 1;
            // 
            // lblFilterEmployee
            // 
            this.lblFilterEmployee.AutoSize = true;
            this.lblFilterEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFilterEmployee.Location = new System.Drawing.Point(250, 30);
            this.lblFilterEmployee.Name = "lblFilterEmployee";
            this.lblFilterEmployee.Size = new System.Drawing.Size(57, 15);
            this.lblFilterEmployee.TabIndex = 2;
            this.lblFilterEmployee.Text = "Employé:";
            // 
            // cmbFilterEmployee
            // 
            this.cmbFilterEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilterEmployee.FormattingEnabled = true;
            this.cmbFilterEmployee.Location = new System.Drawing.Point(320, 27);
            this.cmbFilterEmployee.Name = "cmbFilterEmployee";
            this.cmbFilterEmployee.Size = new System.Drawing.Size(150, 23);
            this.cmbFilterEmployee.TabIndex = 3;
            // 
            // lblFilterType
            // 
            this.lblFilterType.AutoSize = true;
            this.lblFilterType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFilterType.Location = new System.Drawing.Point(490, 30);
            this.lblFilterType.Name = "lblFilterType";
            this.lblFilterType.Size = new System.Drawing.Size(34, 15);
            this.lblFilterType.TabIndex = 4;
            this.lblFilterType.Text = "Type:";
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Location = new System.Drawing.Point(530, 27);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(150, 23);
            this.cmbFilterType.TabIndex = 5;
            // 
            // chkFilterByDate
            // 
            this.chkFilterByDate.AutoSize = true;
            this.chkFilterByDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkFilterByDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkFilterByDate.Location = new System.Drawing.Point(20, 60);
            this.chkFilterByDate.Name = "chkFilterByDate";
            this.chkFilterByDate.Size = new System.Drawing.Size(104, 19);
            this.chkFilterByDate.TabIndex = 6;
            this.chkFilterByDate.Text = "Filtrer par date";
            this.chkFilterByDate.UseVisualStyleBackColor = true;
            this.chkFilterByDate.CheckedChanged += new System.EventHandler(this.chkFilterByDate_CheckedChanged);
            // 
            // lblFilterStart
            // 
            this.lblFilterStart.AutoSize = true;
            this.lblFilterStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFilterStart.Location = new System.Drawing.Point(140, 62);
            this.lblFilterStart.Name = "lblFilterStart";
            this.lblFilterStart.Size = new System.Drawing.Size(24, 15);
            this.lblFilterStart.TabIndex = 7;
            this.lblFilterStart.Text = "Du:";
            // 
            // dtpFilterStart
            // 
            this.dtpFilterStart.Enabled = false;
            this.dtpFilterStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFilterStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterStart.Location = new System.Drawing.Point(170, 59);
            this.dtpFilterStart.Name = "dtpFilterStart";
            this.dtpFilterStart.Size = new System.Drawing.Size(100, 23);
            this.dtpFilterStart.TabIndex = 8;
            // 
            // lblFilterEnd
            // 
            this.lblFilterEnd.AutoSize = true;
            this.lblFilterEnd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFilterEnd.Location = new System.Drawing.Point(290, 62);
            this.lblFilterEnd.Name = "lblFilterEnd";
            this.lblFilterEnd.Size = new System.Drawing.Size(23, 15);
            this.lblFilterEnd.TabIndex = 9;
            this.lblFilterEnd.Text = "Au:";
            // 
            // dtpFilterEnd
            // 
            this.dtpFilterEnd.Enabled = false;
            this.dtpFilterEnd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFilterEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterEnd.Location = new System.Drawing.Point(320, 59);
            this.dtpFilterEnd.Name = "dtpFilterEnd";
            this.dtpFilterEnd.Size = new System.Drawing.Size(100, 23);
            this.dtpFilterEnd.TabIndex = 10;
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnApplyFilters.FlatAppearance.BorderSize = 0;
            this.btnApplyFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApplyFilters.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilters.Location = new System.Drawing.Point(900, 27);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(90, 35);
            this.btnApplyFilters.TabIndex = 11;
            this.btnApplyFilters.Text = "Appliquer";
            this.btnApplyFilters.UseVisualStyleBackColor = false;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClearFilters.FlatAppearance.BorderSize = 0;
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearFilters.ForeColor = System.Drawing.Color.White;
            this.btnClearFilters.Location = new System.Drawing.Point(1000, 27);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(90, 35);
            this.btnClearFilters.TabIndex = 12;
            this.btnClearFilters.Text = "Effacer";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(1100, 27);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 35);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Exporter";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.dgvAbsences);
            this.groupBoxList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxList.Location = new System.Drawing.Point(15, 135);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxList.Size = new System.Drawing.Size(1200, 350);
            this.groupBoxList.TabIndex = 1;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "Liste des Absences";
            // 
            // dgvAbsences
            // 
            this.dgvAbsences.AllowUserToAddRows = false;
            this.dgvAbsences.AllowUserToDeleteRows = false;
            this.dgvAbsences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAbsences.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAbsences.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAbsences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbsences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAbsences.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvAbsences.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.dgvAbsences.Location = new System.Drawing.Point(10, 26);
            this.dgvAbsences.MultiSelect = false;
            this.dgvAbsences.Name = "dgvAbsences";
            this.dgvAbsences.ReadOnly = true;
            this.dgvAbsences.RowHeadersWidth = 51;
            this.dgvAbsences.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAbsences.Size = new System.Drawing.Size(1180, 314);
            this.dgvAbsences.TabIndex = 0;
            this.dgvAbsences.SelectionChanged += new System.EventHandler(this.dgvAbsences_SelectionChanged);
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.lblDescription);
            this.groupBoxDetails.Controls.Add(this.lblDateFin);
            this.groupBoxDetails.Controls.Add(this.lblDateDebut);
            this.groupBoxDetails.Controls.Add(this.lblTypeAbsence);
            this.groupBoxDetails.Controls.Add(this.lblEmployee);
            this.groupBoxDetails.Controls.Add(this.lblService);
            this.groupBoxDetails.Controls.Add(this.lblDepartement);
            this.groupBoxDetails.Controls.Add(this.lblSociete);
            this.groupBoxDetails.Controls.Add(this.btnDelete);
            this.groupBoxDetails.Controls.Add(this.btnSave);
            this.groupBoxDetails.Controls.Add(this.btnNew);
            this.groupBoxDetails.Controls.Add(this.txtDescription);
            this.groupBoxDetails.Controls.Add(this.dtpDateFin);
            this.groupBoxDetails.Controls.Add(this.dtpDateDebut);
            this.groupBoxDetails.Controls.Add(this.cmbTypeAbsence);
            this.groupBoxDetails.Controls.Add(this.cmbEmployee);
            this.groupBoxDetails.Controls.Add(this.cmbService);
            this.groupBoxDetails.Controls.Add(this.cmbDepartement);
            this.groupBoxDetails.Controls.Add(this.cmbSociete);
            this.groupBoxDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxDetails.Location = new System.Drawing.Point(15, 495);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxDetails.Size = new System.Drawing.Size(1200, 180);
            this.groupBoxDetails.TabIndex = 2;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Détails de l'Absence";
            // 
            // lblSociete
            // 
            this.lblSociete.AutoSize = true;
            this.lblSociete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSociete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSociete.Location = new System.Drawing.Point(20, 35);
            this.lblSociete.Name = "lblSociete";
            this.lblSociete.Size = new System.Drawing.Size(50, 15);
            this.lblSociete.TabIndex = 0;
            this.lblSociete.Text = "Société:";
            // 
            // cmbSociete
            // 
            this.cmbSociete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSociete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSociete.FormattingEnabled = true;
            this.cmbSociete.Location = new System.Drawing.Point(100, 32);
            this.cmbSociete.Name = "cmbSociete";
            this.cmbSociete.Size = new System.Drawing.Size(150, 23);
            this.cmbSociete.TabIndex = 1;
            this.cmbSociete.SelectedIndexChanged += new System.EventHandler(this.cmbSociete_SelectedIndexChanged);
            // 
            // lblDepartement
            // 
            this.lblDepartement.AutoSize = true;
            this.lblDepartement.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDepartement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDepartement.Location = new System.Drawing.Point(270, 35);
            this.lblDepartement.Name = "lblDepartement";
            this.lblDepartement.Size = new System.Drawing.Size(82, 15);
            this.lblDepartement.TabIndex = 2;
            this.lblDepartement.Text = "Département:";
            // 
            // cmbDepartement
            // 
            this.cmbDepartement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartement.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbDepartement.FormattingEnabled = true;
            this.cmbDepartement.Location = new System.Drawing.Point(360, 32);
            this.cmbDepartement.Name = "cmbDepartement";
            this.cmbDepartement.Size = new System.Drawing.Size(150, 23);
            this.cmbDepartement.TabIndex = 3;
            this.cmbDepartement.SelectedIndexChanged += new System.EventHandler(this.cmbDepartement_SelectedIndexChanged);
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblService.Location = new System.Drawing.Point(530, 35);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(47, 15);
            this.lblService.TabIndex = 4;
            this.lblService.Text = "Service:";
            // 
            // cmbService
            // 
            this.cmbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbService.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Location = new System.Drawing.Point(590, 32);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(150, 23);
            this.cmbService.TabIndex = 5;
            this.cmbService.SelectedIndexChanged += new System.EventHandler(this.cmbService_SelectedIndexChanged);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmployee.Location = new System.Drawing.Point(760, 35);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(57, 15);
            this.lblEmployee.TabIndex = 6;
            this.lblEmployee.Text = "Employé:";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(830, 32);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(150, 23);
            this.cmbEmployee.TabIndex = 7;
            // 
            // lblTypeAbsence
            // 
            this.lblTypeAbsence.AutoSize = true;
            this.lblTypeAbsence.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTypeAbsence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTypeAbsence.Location = new System.Drawing.Point(20, 75);
            this.lblTypeAbsence.Name = "lblTypeAbsence";
            this.lblTypeAbsence.Size = new System.Drawing.Size(88, 15);
            this.lblTypeAbsence.TabIndex = 8;
            this.lblTypeAbsence.Text = "Type d'absence:";
            // 
            // cmbTypeAbsence
            // 
            this.cmbTypeAbsence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeAbsence.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTypeAbsence.FormattingEnabled = true;
            this.cmbTypeAbsence.Location = new System.Drawing.Point(120, 72);
            this.cmbTypeAbsence.Name = "cmbTypeAbsence";
            this.cmbTypeAbsence.Size = new System.Drawing.Size(150, 23);
            this.cmbTypeAbsence.TabIndex = 9;
            // 
            // lblDateDebut
            // 
            this.lblDateDebut.AutoSize = true;
            this.lblDateDebut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateDebut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDateDebut.Location = new System.Drawing.Point(290, 75);
            this.lblDateDebut.Name = "lblDateDebut";
            this.lblDateDebut.Size = new System.Drawing.Size(71, 15);
            this.lblDateDebut.TabIndex = 10;
            this.lblDateDebut.Text = "Date début:";
            // 
            // dtpDateDebut
            // 
            this.dtpDateDebut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDebut.Location = new System.Drawing.Point(370, 72);
            this.dtpDateDebut.Name = "dtpDateDebut";
            this.dtpDateDebut.Size = new System.Drawing.Size(120, 23);
            this.dtpDateDebut.TabIndex = 11;
            // 
            // lblDateFin
            // 
            this.lblDateFin.AutoSize = true;
            this.lblDateFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDateFin.Location = new System.Drawing.Point(510, 75);
            this.lblDateFin.Name = "lblDateFin";
            this.lblDateFin.Size = new System.Drawing.Size(55, 15);
            this.lblDateFin.TabIndex = 12;
            this.lblDateFin.Text = "Date fin:";
            // 
            // dtpDateFin
            // 
            this.dtpDateFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFin.Location = new System.Drawing.Point(570, 72);
            this.dtpDateFin.Name = "dtpDateFin";
            this.dtpDateFin.Size = new System.Drawing.Size(120, 23);
            this.dtpDateFin.TabIndex = 13;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescription.Location = new System.Drawing.Point(20, 115);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(70, 15);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(100, 112);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(400, 60);
            this.txtDescription.TabIndex = 15;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(1000, 32);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 35);
            this.btnNew.TabIndex = 16;
            this.btnNew.Text = "Nouveau";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1090, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 35);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Enregistrer";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1090, 72);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 35);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // AbsenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1230, 690);
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.groupBoxList);
            this.Controls.Add(this.groupBoxFilters);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AbsenceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des Absences - HR Scheduling System";
            this.groupBoxFilters.ResumeLayout(false);
            this.groupBoxFilters.PerformLayout();
            this.groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsences)).EndInit();
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dgvAbsences;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.ComboBox cmbSociete;
        private System.Windows.Forms.ComboBox cmbDepartement;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.ComboBox cmbTypeAbsence;
        private System.Windows.Forms.DateTimePicker dtpDateDebut;
        private System.Windows.Forms.DateTimePicker dtpDateFin;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblSociete;
        private System.Windows.Forms.Label lblDepartement;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblTypeAbsence;
        private System.Windows.Forms.Label lblDateDebut;
        private System.Windows.Forms.Label lblDateFin;
        private System.Windows.Forms.Label lblDescription;
    }
}
