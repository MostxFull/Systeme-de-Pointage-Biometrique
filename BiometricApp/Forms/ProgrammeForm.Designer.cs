namespace HRSchedulingSystem.Forms
{
    partial class ProgrammeForm
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
            dgvProgrammes = new DataGridView();
            dgvWeeklySchedule = new DataGridView();
            txtNom = new TextBox();
            dtpDateDebut = new DateTimePicker();
            dtpPeriodStart = new DateTimePicker();
            btnNew = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnAddSchedule = new Button();
            btnRemoveSchedule = new Button();
            btnSelectWorkdays = new Button();
            btnSelectWeekend = new Button();
            btnSelectAll = new Button();
            btnClearAll = new Button();
            lblNom = new Label();
            lblDateDebut = new Label();
            lblPeriodStart = new Label();
            groupBoxProgrammes = new GroupBox();
            groupBoxDetails = new GroupBox();
            groupBoxWeeklySchedule = new GroupBox();
            groupBoxShifts = new GroupBox();
            groupBoxDays = new GroupBox();
            groupBoxPeriod = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvProgrammes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvWeeklySchedule).BeginInit();
            groupBoxProgrammes.SuspendLayout();
            groupBoxDetails.SuspendLayout();
            groupBoxWeeklySchedule.SuspendLayout();
            groupBoxDays.SuspendLayout();
            groupBoxPeriod.SuspendLayout();
            SuspendLayout();
            // 
            // dgvProgrammes
            // 
            dgvProgrammes.AllowUserToAddRows = false;
            dgvProgrammes.AllowUserToDeleteRows = false;
            dgvProgrammes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProgrammes.BackgroundColor = Color.White;
            dgvProgrammes.BorderStyle = BorderStyle.None;
            dgvProgrammes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProgrammes.Dock = DockStyle.Fill;
            dgvProgrammes.Font = new Font("Segoe UI", 9F);
            dgvProgrammes.GridColor = Color.FromArgb(189, 195, 199);
            dgvProgrammes.Location = new Point(10, 26);
            dgvProgrammes.MultiSelect = false;
            dgvProgrammes.Name = "dgvProgrammes";
            dgvProgrammes.ReadOnly = true;
            dgvProgrammes.RowHeadersWidth = 51;
            dgvProgrammes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProgrammes.Size = new Size(380, 214);
            dgvProgrammes.TabIndex = 0;
            dgvProgrammes.SelectionChanged += dgvProgrammes_SelectionChanged;
            // 
            // dgvWeeklySchedule
            // 
            dgvWeeklySchedule.AllowUserToAddRows = false;
            dgvWeeklySchedule.AllowUserToDeleteRows = false;
            dgvWeeklySchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWeeklySchedule.BackgroundColor = Color.White;
            dgvWeeklySchedule.BorderStyle = BorderStyle.None;
            dgvWeeklySchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWeeklySchedule.Font = new Font("Segoe UI", 9F);
            dgvWeeklySchedule.GridColor = Color.FromArgb(189, 195, 199);
            dgvWeeklySchedule.Location = new Point(6, 19);
            dgvWeeklySchedule.MultiSelect = false;
            dgvWeeklySchedule.Name = "dgvWeeklySchedule";
            dgvWeeklySchedule.ReadOnly = true;
            dgvWeeklySchedule.RowHeadersWidth = 51;
            dgvWeeklySchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWeeklySchedule.Size = new Size(514, 190);
            dgvWeeklySchedule.TabIndex = 0;
            // 
            // txtNom
            // 
            txtNom.Font = new Font("Segoe UI", 9F);
            txtNom.Location = new Point(71, 32);
            txtNom.MaxLength = 100;
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(150, 23);
            txtNom.TabIndex = 1;
            // 
            // dtpDateDebut
            // 
            dtpDateDebut.Font = new Font("Segoe UI", 9F);
            dtpDateDebut.Format = DateTimePickerFormat.Short;
            dtpDateDebut.Location = new Point(81, 62);
            dtpDateDebut.Name = "dtpDateDebut";
            dtpDateDebut.Size = new Size(120, 23);
            dtpDateDebut.TabIndex = 3;
            // 
            // dtpPeriodStart
            // 
            dtpPeriodStart.Font = new Font("Segoe UI", 9F);
            dtpPeriodStart.Format = DateTimePickerFormat.Short;
            dtpPeriodStart.Location = new Point(90, 32);
            dtpPeriodStart.Name = "dtpPeriodStart";
            dtpPeriodStart.Size = new Size(120, 23);
            dtpPeriodStart.TabIndex = 1;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(149, 165, 166);
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(227, 32);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(74, 30);
            btnNew.TabIndex = 4;
            btnNew.Text = "Nouveau";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(310, 32);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 30);
            btnSave.TabIndex = 5;
            btnSave.Text = "Enregistrer";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(310, 67);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 30);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Supprimer";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAddSchedule
            // 
            btnAddSchedule.BackColor = Color.FromArgb(52, 152, 219);
            btnAddSchedule.FlatAppearance.BorderSize = 0;
            btnAddSchedule.FlatStyle = FlatStyle.Flat;
            btnAddSchedule.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddSchedule.ForeColor = Color.White;
            btnAddSchedule.Location = new Point(412, 24);
            btnAddSchedule.Name = "btnAddSchedule";
            btnAddSchedule.Size = new Size(110, 35);
            btnAddSchedule.TabIndex = 2;
            btnAddSchedule.Text = "Ajouter Planning";
            btnAddSchedule.UseVisualStyleBackColor = false;
            btnAddSchedule.Click += btnAddSchedule_Click;
            // 
            // btnRemoveSchedule
            // 
            btnRemoveSchedule.BackColor = Color.FromArgb(231, 76, 60);
            btnRemoveSchedule.FlatAppearance.BorderSize = 0;
            btnRemoveSchedule.FlatStyle = FlatStyle.Flat;
            btnRemoveSchedule.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRemoveSchedule.ForeColor = Color.White;
            btnRemoveSchedule.Location = new Point(428, 215);
            btnRemoveSchedule.Name = "btnRemoveSchedule";
            btnRemoveSchedule.Size = new Size(94, 30);
            btnRemoveSchedule.TabIndex = 1;
            btnRemoveSchedule.Text = "Supprimer";
            btnRemoveSchedule.UseVisualStyleBackColor = false;
            btnRemoveSchedule.Click += btnRemoveSchedule_Click;
            // 
            // btnSelectWorkdays
            // 
            btnSelectWorkdays.BackColor = Color.FromArgb(52, 152, 219);
            btnSelectWorkdays.FlatAppearance.BorderSize = 0;
            btnSelectWorkdays.FlatStyle = FlatStyle.Flat;
            btnSelectWorkdays.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSelectWorkdays.ForeColor = Color.White;
            btnSelectWorkdays.Location = new Point(182, 37);
            btnSelectWorkdays.Name = "btnSelectWorkdays";
            btnSelectWorkdays.Size = new Size(78, 25);
            btnSelectWorkdays.TabIndex = 0;
            btnSelectWorkdays.Text = "Semaine";
            btnSelectWorkdays.UseVisualStyleBackColor = false;
            btnSelectWorkdays.Click += btnSelectWorkdays_Click;
            // 
            // btnSelectWeekend
            // 
            btnSelectWeekend.BackColor = Color.FromArgb(241, 196, 15);
            btnSelectWeekend.FlatAppearance.BorderSize = 0;
            btnSelectWeekend.FlatStyle = FlatStyle.Flat;
            btnSelectWeekend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSelectWeekend.ForeColor = Color.White;
            btnSelectWeekend.Location = new Point(182, 64);
            btnSelectWeekend.Name = "btnSelectWeekend";
            btnSelectWeekend.Size = new Size(78, 25);
            btnSelectWeekend.TabIndex = 1;
            btnSelectWeekend.Text = "Week-end";
            btnSelectWeekend.UseVisualStyleBackColor = false;
            btnSelectWeekend.Click += btnSelectWeekend_Click;
            // 
            // btnSelectAll
            // 
            btnSelectAll.BackColor = Color.FromArgb(46, 204, 113);
            btnSelectAll.FlatAppearance.BorderSize = 0;
            btnSelectAll.FlatStyle = FlatStyle.Flat;
            btnSelectAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSelectAll.ForeColor = Color.White;
            btnSelectAll.Location = new Point(182, 95);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(78, 23);
            btnSelectAll.TabIndex = 2;
            btnSelectAll.Text = "Tout";
            btnSelectAll.UseVisualStyleBackColor = false;
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // btnClearAll
            // 
            btnClearAll.BackColor = Color.FromArgb(149, 165, 166);
            btnClearAll.FlatAppearance.BorderSize = 0;
            btnClearAll.FlatStyle = FlatStyle.Flat;
            btnClearAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearAll.ForeColor = Color.White;
            btnClearAll.Location = new Point(182, 122);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(78, 24);
            btnClearAll.TabIndex = 3;
            btnClearAll.Text = "Effacer";
            btnClearAll.UseVisualStyleBackColor = false;
            btnClearAll.Click += btnClearAll_Click;
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Font = new Font("Segoe UI", 9F);
            lblNom.ForeColor = Color.FromArgb(64, 64, 64);
            lblNom.Location = new Point(11, 35);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(37, 15);
            lblNom.TabIndex = 0;
            lblNom.Text = "Nom:";
            // 
            // lblDateDebut
            // 
            lblDateDebut.AutoSize = true;
            lblDateDebut.Font = new Font("Segoe UI", 9F);
            lblDateDebut.ForeColor = Color.FromArgb(64, 64, 64);
            lblDateDebut.Location = new Point(11, 65);
            lblDateDebut.Name = "lblDateDebut";
            lblDateDebut.Size = new Size(68, 15);
            lblDateDebut.TabIndex = 2;
            lblDateDebut.Text = "Date début:";
            // 
            // lblPeriodStart
            // 
            lblPeriodStart.AutoSize = true;
            lblPeriodStart.Font = new Font("Segoe UI", 9F);
            lblPeriodStart.ForeColor = Color.FromArgb(64, 64, 64);
            lblPeriodStart.Location = new Point(20, 35);
            lblPeriodStart.Name = "lblPeriodStart";
            lblPeriodStart.Size = new Size(68, 15);
            lblPeriodStart.TabIndex = 0;
            lblPeriodStart.Text = "Date début:";
            // 
            // groupBoxProgrammes
            // 
            groupBoxProgrammes.Controls.Add(dgvProgrammes);
            groupBoxProgrammes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxProgrammes.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxProgrammes.Location = new Point(15, 15);
            groupBoxProgrammes.Name = "groupBoxProgrammes";
            groupBoxProgrammes.Padding = new Padding(10);
            groupBoxProgrammes.Size = new Size(400, 250);
            groupBoxProgrammes.TabIndex = 0;
            groupBoxProgrammes.TabStop = false;
            groupBoxProgrammes.Text = "Liste des Programmes";
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Controls.Add(btnDelete);
            groupBoxDetails.Controls.Add(btnSave);
            groupBoxDetails.Controls.Add(btnNew);
            groupBoxDetails.Controls.Add(dtpDateDebut);
            groupBoxDetails.Controls.Add(lblDateDebut);
            groupBoxDetails.Controls.Add(txtNom);
            groupBoxDetails.Controls.Add(lblNom);
            groupBoxDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxDetails.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxDetails.Location = new Point(15, 275);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Padding = new Padding(10);
            groupBoxDetails.Size = new Size(400, 110);
            groupBoxDetails.TabIndex = 1;
            groupBoxDetails.TabStop = false;
            groupBoxDetails.Text = "Détails du Programme";
            // 
            // groupBoxWeeklySchedule
            // 
            groupBoxWeeklySchedule.Controls.Add(btnRemoveSchedule);
            groupBoxWeeklySchedule.Controls.Add(dgvWeeklySchedule);
            groupBoxWeeklySchedule.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxWeeklySchedule.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxWeeklySchedule.Location = new Point(430, 15);
            groupBoxWeeklySchedule.Name = "groupBoxWeeklySchedule";
            groupBoxWeeklySchedule.Size = new Size(528, 250);
            groupBoxWeeklySchedule.TabIndex = 2;
            groupBoxWeeklySchedule.TabStop = false;
            groupBoxWeeklySchedule.Text = "Planning Hebdomadaire";
            // 
            // groupBoxShifts
            // 
            groupBoxShifts.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxShifts.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxShifts.Location = new Point(430, 275);
            groupBoxShifts.Name = "groupBoxShifts";
            groupBoxShifts.Size = new Size(250, 217);
            groupBoxShifts.TabIndex = 3;
            groupBoxShifts.TabStop = false;
            groupBoxShifts.Text = "Sélectionner la catégorie d'équipe:";
            // 
            // groupBoxDays
            // 
            groupBoxDays.Controls.Add(btnClearAll);
            groupBoxDays.Controls.Add(btnSelectAll);
            groupBoxDays.Controls.Add(btnSelectWeekend);
            groupBoxDays.Controls.Add(btnSelectWorkdays);
            groupBoxDays.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxDays.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxDays.Location = new Point(690, 275);
            groupBoxDays.Name = "groupBoxDays";
            groupBoxDays.Size = new Size(268, 217);
            groupBoxDays.TabIndex = 4;
            groupBoxDays.TabStop = false;
            groupBoxDays.Text = "Appliquer aux jours suivants:";
            // 
            // groupBoxPeriod
            // 
            groupBoxPeriod.Controls.Add(btnAddSchedule);
            groupBoxPeriod.Controls.Add(dtpPeriodStart);
            groupBoxPeriod.Controls.Add(lblPeriodStart);
            groupBoxPeriod.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxPeriod.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxPeriod.Location = new Point(430, 498);
            groupBoxPeriod.Name = "groupBoxPeriod";
            groupBoxPeriod.Size = new Size(528, 74);
            groupBoxPeriod.TabIndex = 5;
            groupBoxPeriod.TabStop = false;
            groupBoxPeriod.Text = "Sélectionner la date de début pour appliquer cette période:";
            // 
            // ProgrammeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(977, 584);
            Controls.Add(groupBoxPeriod);
            Controls.Add(groupBoxDays);
            Controls.Add(groupBoxShifts);
            Controls.Add(groupBoxWeeklySchedule);
            Controls.Add(groupBoxDetails);
            Controls.Add(groupBoxProgrammes);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ProgrammeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion des Programmes - HR Scheduling System";
            ((System.ComponentModel.ISupportInitialize)dgvProgrammes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvWeeklySchedule).EndInit();
            groupBoxProgrammes.ResumeLayout(false);
            groupBoxDetails.ResumeLayout(false);
            groupBoxDetails.PerformLayout();
            groupBoxWeeklySchedule.ResumeLayout(false);
            groupBoxDays.ResumeLayout(false);
            groupBoxPeriod.ResumeLayout(false);
            groupBoxPeriod.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProgrammes;
        private System.Windows.Forms.DataGridView dgvWeeklySchedule;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.DateTimePicker dtpDateDebut;
        private System.Windows.Forms.DateTimePicker dtpPeriodStart;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnRemoveSchedule;
        private System.Windows.Forms.Button btnSelectWorkdays;
        private System.Windows.Forms.Button btnSelectWeekend;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblDateDebut;
        private System.Windows.Forms.Label lblPeriodStart;
        private System.Windows.Forms.GroupBox groupBoxProgrammes;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.GroupBox groupBoxWeeklySchedule;
        private System.Windows.Forms.GroupBox groupBoxShifts;
        private System.Windows.Forms.GroupBox groupBoxDays;
        private System.Windows.Forms.GroupBox groupBoxPeriod;
    }
}
