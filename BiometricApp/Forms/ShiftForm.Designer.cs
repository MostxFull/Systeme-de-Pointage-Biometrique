namespace HRSchedulingSystem.Forms
{
    partial class ShiftForm
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
            dgvShifts = new DataGridView();
            txtNom = new TextBox();
            dtpHeureDebut = new DateTimePicker();
            dtpHeureFin = new DateTimePicker();
            txtRetardautorise = new TextBox();
            txtDepartautorise = new TextBox();
            btnNew = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            lblNom = new Label();
            lblHeureDebut = new Label();
            lblHeureFin = new Label();
            lblRetardautorise = new Label();
            lblDepartautorise = new Label();
            groupBoxList = new GroupBox();
            groupBoxDetails = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvShifts).BeginInit();
            groupBoxList.SuspendLayout();
            groupBoxDetails.SuspendLayout();
            SuspendLayout();
            // 
            // dgvShifts
            // 
            dgvShifts.AllowUserToAddRows = false;
            dgvShifts.AllowUserToDeleteRows = false;
            dgvShifts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvShifts.BackgroundColor = Color.White;
            dgvShifts.BorderStyle = BorderStyle.None;
            dgvShifts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShifts.Dock = DockStyle.Fill;
            dgvShifts.Font = new Font("Segoe UI", 9F);
            dgvShifts.GridColor = Color.FromArgb(189, 195, 199);
            dgvShifts.Location = new Point(10, 26);
            dgvShifts.MultiSelect = false;
            dgvShifts.Name = "dgvShifts";
            dgvShifts.ReadOnly = true;
            dgvShifts.RowHeadersWidth = 51;
            dgvShifts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShifts.Size = new Size(740, 284);
            dgvShifts.TabIndex = 0;
            dgvShifts.SelectionChanged += dgvShifts_SelectionChanged;
            // 
            // txtNom
            // 
            txtNom.Font = new Font("Segoe UI", 9F);
            txtNom.Location = new Point(193, 32);
            txtNom.MaxLength = 100;
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(277, 23);
            txtNom.TabIndex = 1;
            // 
            // dtpHeureDebut
            // 
            dtpHeureDebut.Font = new Font("Segoe UI", 9F);
            dtpHeureDebut.Format = DateTimePickerFormat.Time;
            dtpHeureDebut.Location = new Point(193, 61);
            dtpHeureDebut.Name = "dtpHeureDebut";
            dtpHeureDebut.ShowUpDown = true;
            dtpHeureDebut.Size = new Size(100, 23);
            dtpHeureDebut.TabIndex = 3;
            // 
            // dtpHeureFin
            // 
            dtpHeureFin.Font = new Font("Segoe UI", 9F);
            dtpHeureFin.Format = DateTimePickerFormat.Time;
            dtpHeureFin.Location = new Point(370, 62);
            dtpHeureFin.Name = "dtpHeureFin";
            dtpHeureFin.ShowUpDown = true;
            dtpHeureFin.Size = new Size(100, 23);
            dtpHeureFin.TabIndex = 5;
            // 
            // txtRetardautorise
            // 
            txtRetardautorise.Font = new Font("Segoe UI", 9F);
            txtRetardautorise.Location = new Point(193, 91);
            txtRetardautorise.Name = "txtRetardautorise";
            txtRetardautorise.Size = new Size(100, 23);
            txtRetardautorise.TabIndex = 7;
            txtRetardautorise.Text = "0";
            // 
            // txtDepartautorise
            // 
            txtDepartautorise.Font = new Font("Segoe UI", 9F);
            txtDepartautorise.Location = new Point(193, 120);
            txtDepartautorise.Name = "txtDepartautorise";
            txtDepartautorise.Size = new Size(100, 23);
            txtDepartautorise.TabIndex = 9;
            txtDepartautorise.Text = "0";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(149, 165, 166);
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(520, 32);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(80, 30);
            btnNew.TabIndex = 10;
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
            btnSave.Location = new Point(610, 32);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 30);
            btnSave.TabIndex = 11;
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
            btnDelete.Location = new Point(520, 72);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 30);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Supprimer";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Font = new Font("Segoe UI", 9F);
            lblNom.ForeColor = Color.FromArgb(64, 64, 64);
            lblNom.Location = new Point(20, 35);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(86, 15);
            lblNom.TabIndex = 0;
            lblNom.Text = "Nom d'équipe:";
            // 
            // lblHeureDebut
            // 
            lblHeureDebut.AutoSize = true;
            lblHeureDebut.Font = new Font("Segoe UI", 9F);
            lblHeureDebut.ForeColor = Color.FromArgb(64, 64, 64);
            lblHeureDebut.Location = new Point(20, 65);
            lblHeureDebut.Name = "lblHeureDebut";
            lblHeureDebut.Size = new Size(76, 15);
            lblHeureDebut.TabIndex = 2;
            lblHeureDebut.Text = "Heure début:";
            // 
            // lblHeureFin
            // 
            lblHeureFin.AutoSize = true;
            lblHeureFin.Font = new Font("Segoe UI", 9F);
            lblHeureFin.ForeColor = Color.FromArgb(64, 64, 64);
            lblHeureFin.Location = new Point(300, 65);
            lblHeureFin.Name = "lblHeureFin";
            lblHeureFin.Size = new Size(59, 15);
            lblHeureFin.TabIndex = 4;
            lblHeureFin.Text = "Heure fin:";
            // 
            // lblRetardautorise
            // 
            lblRetardautorise.AutoSize = true;
            lblRetardautorise.Font = new Font("Segoe UI", 9F);
            lblRetardautorise.ForeColor = Color.FromArgb(64, 64, 64);
            lblRetardautorise.Location = new Point(20, 95);
            lblRetardautorise.Name = "lblRetardautorise";
            lblRetardautorise.Size = new Size(121, 15);
            lblRetardautorise.TabIndex = 6;
            lblRetardautorise.Text = "Retard autorisé (min):";
            // 
            // lblDepartautorise
            // 
            lblDepartautorise.AutoSize = true;
            lblDepartautorise.Font = new Font("Segoe UI", 9F);
            lblDepartautorise.ForeColor = Color.FromArgb(64, 64, 64);
            lblDepartautorise.Location = new Point(20, 125);
            lblDepartautorise.Name = "lblDepartautorise";
            lblDepartautorise.Size = new Size(167, 15);
            lblDepartautorise.TabIndex = 8;
            lblDepartautorise.Text = "Départ anticipé autorisé (min):";
            // 
            // groupBoxList
            // 
            groupBoxList.Controls.Add(dgvShifts);
            groupBoxList.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxList.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxList.Location = new Point(15, 15);
            groupBoxList.Name = "groupBoxList";
            groupBoxList.Padding = new Padding(10);
            groupBoxList.Size = new Size(760, 320);
            groupBoxList.TabIndex = 0;
            groupBoxList.TabStop = false;
            groupBoxList.Text = "Liste des Équipes";
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Controls.Add(lblDepartautorise);
            groupBoxDetails.Controls.Add(lblRetardautorise);
            groupBoxDetails.Controls.Add(lblHeureFin);
            groupBoxDetails.Controls.Add(lblHeureDebut);
            groupBoxDetails.Controls.Add(lblNom);
            groupBoxDetails.Controls.Add(btnDelete);
            groupBoxDetails.Controls.Add(btnSave);
            groupBoxDetails.Controls.Add(btnNew);
            groupBoxDetails.Controls.Add(txtDepartautorise);
            groupBoxDetails.Controls.Add(txtRetardautorise);
            groupBoxDetails.Controls.Add(dtpHeureFin);
            groupBoxDetails.Controls.Add(dtpHeureDebut);
            groupBoxDetails.Controls.Add(txtNom);
            groupBoxDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxDetails.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxDetails.Location = new Point(15, 345);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Padding = new Padding(10);
            groupBoxDetails.Size = new Size(760, 150);
            groupBoxDetails.TabIndex = 1;
            groupBoxDetails.TabStop = false;
            groupBoxDetails.Text = "Détails de l'Équipe";
            // 
            // ShiftForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(790, 507);
            Controls.Add(groupBoxDetails);
            Controls.Add(groupBoxList);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ShiftForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion des Équipes - HR Scheduling System";
            ((System.ComponentModel.ISupportInitialize)dgvShifts).EndInit();
            groupBoxList.ResumeLayout(false);
            groupBoxDetails.ResumeLayout(false);
            groupBoxDetails.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShifts;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.DateTimePicker dtpHeureDebut;
        private System.Windows.Forms.DateTimePicker dtpHeureFin;
        private System.Windows.Forms.TextBox txtRetardautorise;
        private System.Windows.Forms.TextBox txtDepartautorise;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblHeureDebut;
        private System.Windows.Forms.Label lblHeureFin;
        private System.Windows.Forms.Label lblRetardautorise;
        private System.Windows.Forms.Label lblDepartautorise;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.GroupBox groupBoxDetails;
    }
}
