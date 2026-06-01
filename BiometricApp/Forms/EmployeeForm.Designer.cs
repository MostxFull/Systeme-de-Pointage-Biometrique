namespace HRSchedulingSystem.Forms
{
    partial class EmployeeForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvEmployees = new DataGridView();
            groupBoxList = new GroupBox();
            groupBoxDetails = new GroupBox();
            label1 = new Label();
            txtBiometric = new TextBox();
            lblPhoto = new Label();
            lblService = new Label();
            lblPoste = new Label();
            lblNbJourtravail = new Label();
            lblNbHeuretravail = new Label();
            lblSalaire = new Label();
            lblTelephone = new Label();
            lblDateEmbauche = new Label();
            lblDateNaissance = new Label();
            lblGenre = new Label();
            lblCIN = new Label();
            lblEmail = new Label();
            lblMatricule = new Label();
            lblPrenom = new Label();
            lblNom = new Label();
            btnDelete = new Button();
            btnSave = new Button();
            btnNew = new Button();
            btnUploadPhoto = new Button();
            picPhoto = new PictureBox();
            cmbService = new ComboBox();
            txtPoste = new TextBox();
            txtNbJourtravail = new TextBox();
            txtNbHeuretravail = new TextBox();
            txtSalaire = new TextBox();
            chkStatut = new CheckBox();
            txtTelephone = new TextBox();
            dtpDateEmbauche = new DateTimePicker();
            dtpDateNaissance = new DateTimePicker();
            cmbGenre = new ComboBox();
            txtCIN = new TextBox();
            txtEmail = new TextBox();
            txtMatricule = new TextBox();
            txtPrenom = new TextBox();
            txtNom = new TextBox();
            groupBoxSearch = new GroupBox();
            btnClearSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            groupBoxList.SuspendLayout();
            groupBoxDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
            groupBoxSearch.SuspendLayout();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvEmployees.DefaultCellStyle = dataGridViewCellStyle2;
            dgvEmployees.Dock = DockStyle.Fill;
            dgvEmployees.GridColor = Color.FromArgb(189, 195, 199);
            dgvEmployees.Location = new Point(10, 26);
            dgvEmployees.MultiSelect = false;
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(980, 264);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.SelectionChanged += dgvEmployees_SelectionChanged;
            // 
            // groupBoxList
            // 
            groupBoxList.Controls.Add(dgvEmployees);
            groupBoxList.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxList.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxList.Location = new Point(15, 78);
            groupBoxList.Name = "groupBoxList";
            groupBoxList.Padding = new Padding(10);
            groupBoxList.Size = new Size(1000, 300);
            groupBoxList.TabIndex = 0;
            groupBoxList.TabStop = false;
            groupBoxList.Text = "Liste des Employés";
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Controls.Add(label1);
            groupBoxDetails.Controls.Add(txtBiometric);
            groupBoxDetails.Controls.Add(lblPhoto);
            groupBoxDetails.Controls.Add(lblService);
            groupBoxDetails.Controls.Add(lblPoste);
            groupBoxDetails.Controls.Add(lblNbJourtravail);
            groupBoxDetails.Controls.Add(lblNbHeuretravail);
            groupBoxDetails.Controls.Add(lblSalaire);
            groupBoxDetails.Controls.Add(lblTelephone);
            groupBoxDetails.Controls.Add(lblDateEmbauche);
            groupBoxDetails.Controls.Add(lblDateNaissance);
            groupBoxDetails.Controls.Add(lblGenre);
            groupBoxDetails.Controls.Add(lblCIN);
            groupBoxDetails.Controls.Add(lblEmail);
            groupBoxDetails.Controls.Add(lblMatricule);
            groupBoxDetails.Controls.Add(lblPrenom);
            groupBoxDetails.Controls.Add(lblNom);
            groupBoxDetails.Controls.Add(btnDelete);
            groupBoxDetails.Controls.Add(btnSave);
            groupBoxDetails.Controls.Add(btnNew);
            groupBoxDetails.Controls.Add(btnUploadPhoto);
            groupBoxDetails.Controls.Add(picPhoto);
            groupBoxDetails.Controls.Add(cmbService);
            groupBoxDetails.Controls.Add(txtPoste);
            groupBoxDetails.Controls.Add(txtNbJourtravail);
            groupBoxDetails.Controls.Add(txtNbHeuretravail);
            groupBoxDetails.Controls.Add(txtSalaire);
            groupBoxDetails.Controls.Add(chkStatut);
            groupBoxDetails.Controls.Add(txtTelephone);
            groupBoxDetails.Controls.Add(dtpDateEmbauche);
            groupBoxDetails.Controls.Add(dtpDateNaissance);
            groupBoxDetails.Controls.Add(cmbGenre);
            groupBoxDetails.Controls.Add(txtCIN);
            groupBoxDetails.Controls.Add(txtEmail);
            groupBoxDetails.Controls.Add(txtMatricule);
            groupBoxDetails.Controls.Add(txtPrenom);
            groupBoxDetails.Controls.Add(txtNom);
            groupBoxDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxDetails.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxDetails.Location = new Point(15, 390);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Padding = new Padding(10);
            groupBoxDetails.Size = new Size(1000, 280);
            groupBoxDetails.TabIndex = 1;
            groupBoxDetails.TabStop = false;
            groupBoxDetails.Text = "Détails de l'Employé";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(298, 217);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 35;
            label1.Text = "Biometric Id:";
            // 
            // txtBiometric
            // 
            txtBiometric.Font = new Font("Segoe UI", 9F);
            txtBiometric.Location = new Point(402, 214);
            txtBiometric.MaxLength = 100;
            txtBiometric.Name = "txtBiometric";
            txtBiometric.Size = new Size(150, 23);
            txtBiometric.TabIndex = 36;
            txtBiometric.TextChanged += textBox1_TextChanged;
            // 
            // lblPhoto
            // 
            lblPhoto.AutoSize = true;
            lblPhoto.Font = new Font("Segoe UI", 9F);
            lblPhoto.ForeColor = Color.FromArgb(64, 64, 64);
            lblPhoto.Location = new Point(601, 48);
            lblPhoto.Name = "lblPhoto";
            lblPhoto.Size = new Size(42, 15);
            lblPhoto.TabIndex = 29;
            lblPhoto.Text = "Photo:";
            lblPhoto.Click += lblPhoto_Click;
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Font = new Font("Segoe UI", 9F);
            lblService.ForeColor = Color.FromArgb(64, 64, 64);
            lblService.Location = new Point(20, 245);
            lblService.Name = "lblService";
            lblService.Size = new Size(47, 15);
            lblService.TabIndex = 27;
            lblService.Text = "Service:";
            // 
            // lblPoste
            // 
            lblPoste.AutoSize = true;
            lblPoste.Font = new Font("Segoe UI", 9F);
            lblPoste.ForeColor = Color.FromArgb(64, 64, 64);
            lblPoste.Location = new Point(298, 188);
            lblPoste.Name = "lblPoste";
            lblPoste.Size = new Size(39, 15);
            lblPoste.TabIndex = 25;
            lblPoste.Text = "Poste:";
            // 
            // lblNbJourtravail
            // 
            lblNbJourtravail.AutoSize = true;
            lblNbJourtravail.Font = new Font("Segoe UI", 9F);
            lblNbJourtravail.ForeColor = Color.FromArgb(64, 64, 64);
            lblNbJourtravail.Location = new Point(20, 215);
            lblNbJourtravail.Name = "lblNbJourtravail";
            lblNbJourtravail.Size = new Size(88, 15);
            lblNbJourtravail.TabIndex = 23;
            lblNbJourtravail.Text = "Jours de travail:";
            // 
            // lblNbHeuretravail
            // 
            lblNbHeuretravail.AutoSize = true;
            lblNbHeuretravail.Font = new Font("Segoe UI", 9F);
            lblNbHeuretravail.ForeColor = Color.FromArgb(64, 64, 64);
            lblNbHeuretravail.Location = new Point(298, 158);
            lblNbHeuretravail.Name = "lblNbHeuretravail";
            lblNbHeuretravail.Size = new Size(98, 15);
            lblNbHeuretravail.TabIndex = 21;
            lblNbHeuretravail.Text = "Heures de travail:";
            // 
            // lblSalaire
            // 
            lblSalaire.AutoSize = true;
            lblSalaire.Font = new Font("Segoe UI", 9F);
            lblSalaire.ForeColor = Color.FromArgb(64, 64, 64);
            lblSalaire.Location = new Point(20, 185);
            lblSalaire.Name = "lblSalaire";
            lblSalaire.Size = new Size(44, 15);
            lblSalaire.TabIndex = 19;
            lblSalaire.Text = "Salaire:";
            // 
            // lblTelephone
            // 
            lblTelephone.AutoSize = true;
            lblTelephone.Font = new Font("Segoe UI", 9F);
            lblTelephone.ForeColor = Color.FromArgb(64, 64, 64);
            lblTelephone.Location = new Point(20, 155);
            lblTelephone.Name = "lblTelephone";
            lblTelephone.Size = new Size(64, 15);
            lblTelephone.TabIndex = 16;
            lblTelephone.Text = "Téléphone:";
            // 
            // lblDateEmbauche
            // 
            lblDateEmbauche.AutoSize = true;
            lblDateEmbauche.Font = new Font("Segoe UI", 9F);
            lblDateEmbauche.ForeColor = Color.FromArgb(64, 64, 64);
            lblDateEmbauche.Location = new Point(298, 128);
            lblDateEmbauche.Name = "lblDateEmbauche";
            lblDateEmbauche.Size = new Size(103, 15);
            lblDateEmbauche.TabIndex = 14;
            lblDateEmbauche.Text = "Date d'embauche:";
            // 
            // lblDateNaissance
            // 
            lblDateNaissance.AutoSize = true;
            lblDateNaissance.Font = new Font("Segoe UI", 9F);
            lblDateNaissance.ForeColor = Color.FromArgb(64, 64, 64);
            lblDateNaissance.Location = new Point(20, 125);
            lblDateNaissance.Name = "lblDateNaissance";
            lblDateNaissance.Size = new Size(104, 15);
            lblDateNaissance.TabIndex = 12;
            lblDateNaissance.Text = "Date de naissance:";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Segoe UI", 9F);
            lblGenre.ForeColor = Color.FromArgb(64, 64, 64);
            lblGenre.Location = new Point(298, 98);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(41, 15);
            lblGenre.TabIndex = 10;
            lblGenre.Text = "Genre:";
            // 
            // lblCIN
            // 
            lblCIN.AutoSize = true;
            lblCIN.Font = new Font("Segoe UI", 9F);
            lblCIN.ForeColor = Color.FromArgb(64, 64, 64);
            lblCIN.Location = new Point(20, 95);
            lblCIN.Name = "lblCIN";
            lblCIN.Size = new Size(30, 15);
            lblCIN.TabIndex = 8;
            lblCIN.Text = "CIN:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.ForeColor = Color.FromArgb(64, 64, 64);
            lblEmail.Location = new Point(298, 68);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // lblMatricule
            // 
            lblMatricule.AutoSize = true;
            lblMatricule.Font = new Font("Segoe UI", 9F);
            lblMatricule.ForeColor = Color.FromArgb(64, 64, 64);
            lblMatricule.Location = new Point(20, 65);
            lblMatricule.Name = "lblMatricule";
            lblMatricule.Size = new Size(60, 15);
            lblMatricule.TabIndex = 4;
            lblMatricule.Text = "Matricule:";
            // 
            // lblPrenom
            // 
            lblPrenom.AutoSize = true;
            lblPrenom.Font = new Font("Segoe UI", 9F);
            lblPrenom.ForeColor = Color.FromArgb(64, 64, 64);
            lblPrenom.Location = new Point(298, 38);
            lblPrenom.Name = "lblPrenom";
            lblPrenom.Size = new Size(52, 15);
            lblPrenom.TabIndex = 2;
            lblPrenom.Text = "Prénom:";
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Font = new Font("Segoe UI", 9F);
            lblNom.ForeColor = Color.FromArgb(64, 64, 64);
            lblNom.Location = new Point(20, 35);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(37, 15);
            lblNom.TabIndex = 0;
            lblNom.Text = "Nom:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(801, 120);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 30);
            btnDelete.TabIndex = 34;
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
            btnSave.Location = new Point(801, 80);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 30);
            btnSave.TabIndex = 33;
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
            btnNew.Location = new Point(801, 40);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(80, 30);
            btnNew.TabIndex = 32;
            btnNew.Text = "Nouveau";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // btnUploadPhoto
            // 
            btnUploadPhoto.BackColor = Color.FromArgb(52, 152, 219);
            btnUploadPhoto.FlatAppearance.BorderSize = 0;
            btnUploadPhoto.FlatStyle = FlatStyle.Flat;
            btnUploadPhoto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUploadPhoto.ForeColor = Color.White;
            btnUploadPhoto.Location = new Point(651, 198);
            btnUploadPhoto.Name = "btnUploadPhoto";
            btnUploadPhoto.Size = new Size(120, 30);
            btnUploadPhoto.TabIndex = 31;
            btnUploadPhoto.Text = "Charger Photo";
            btnUploadPhoto.UseVisualStyleBackColor = false;
            btnUploadPhoto.Click += btnUploadPhoto_Click;
            // 
            // picPhoto
            // 
            picPhoto.BorderStyle = BorderStyle.FixedSingle;
            picPhoto.Location = new Point(651, 40);
            picPhoto.Name = "picPhoto";
            picPhoto.Size = new Size(120, 150);
            picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            picPhoto.TabIndex = 30;
            picPhoto.TabStop = false;
            picPhoto.Click += picPhoto_Click;
            // 
            // cmbService
            // 
            cmbService.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbService.Font = new Font("Segoe UI", 9F);
            cmbService.FormattingEnabled = true;
            cmbService.Location = new Point(124, 242);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(150, 23);
            cmbService.TabIndex = 28;
            // 
            // txtPoste
            // 
            txtPoste.Font = new Font("Segoe UI", 9F);
            txtPoste.Location = new Point(402, 185);
            txtPoste.MaxLength = 100;
            txtPoste.Name = "txtPoste";
            txtPoste.Size = new Size(150, 23);
            txtPoste.TabIndex = 26;
            // 
            // txtNbJourtravail
            // 
            txtNbJourtravail.Font = new Font("Segoe UI", 9F);
            txtNbJourtravail.Location = new Point(124, 212);
            txtNbJourtravail.Name = "txtNbJourtravail";
            txtNbJourtravail.Size = new Size(150, 23);
            txtNbJourtravail.TabIndex = 24;
            // 
            // txtNbHeuretravail
            // 
            txtNbHeuretravail.Font = new Font("Segoe UI", 9F);
            txtNbHeuretravail.Location = new Point(402, 155);
            txtNbHeuretravail.Name = "txtNbHeuretravail";
            txtNbHeuretravail.Size = new Size(150, 23);
            txtNbHeuretravail.TabIndex = 22;
            // 
            // txtSalaire
            // 
            txtSalaire.Font = new Font("Segoe UI", 9F);
            txtSalaire.Location = new Point(124, 182);
            txtSalaire.Name = "txtSalaire";
            txtSalaire.Size = new Size(150, 23);
            txtSalaire.TabIndex = 20;
            // 
            // chkStatut
            // 
            chkStatut.AutoSize = true;
            chkStatut.Checked = true;
            chkStatut.CheckState = CheckState.Checked;
            chkStatut.Font = new Font("Segoe UI", 9F);
            chkStatut.ForeColor = Color.FromArgb(64, 64, 64);
            chkStatut.Location = new Point(402, 248);
            chkStatut.Name = "chkStatut";
            chkStatut.Size = new Size(51, 19);
            chkStatut.TabIndex = 18;
            chkStatut.Text = "Actif";
            chkStatut.UseVisualStyleBackColor = true;
            // 
            // txtTelephone
            // 
            txtTelephone.Font = new Font("Segoe UI", 9F);
            txtTelephone.Location = new Point(124, 152);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(150, 23);
            txtTelephone.TabIndex = 17;
            // 
            // dtpDateEmbauche
            // 
            dtpDateEmbauche.Font = new Font("Segoe UI", 9F);
            dtpDateEmbauche.Format = DateTimePickerFormat.Short;
            dtpDateEmbauche.Location = new Point(402, 125);
            dtpDateEmbauche.Name = "dtpDateEmbauche";
            dtpDateEmbauche.Size = new Size(150, 23);
            dtpDateEmbauche.TabIndex = 15;
            // 
            // dtpDateNaissance
            // 
            dtpDateNaissance.Font = new Font("Segoe UI", 9F);
            dtpDateNaissance.Format = DateTimePickerFormat.Short;
            dtpDateNaissance.Location = new Point(124, 122);
            dtpDateNaissance.Name = "dtpDateNaissance";
            dtpDateNaissance.Size = new Size(150, 23);
            dtpDateNaissance.TabIndex = 13;
            // 
            // cmbGenre
            // 
            cmbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenre.Font = new Font("Segoe UI", 9F);
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(402, 95);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(150, 23);
            cmbGenre.TabIndex = 11;
            // 
            // txtCIN
            // 
            txtCIN.Font = new Font("Segoe UI", 9F);
            txtCIN.Location = new Point(124, 92);
            txtCIN.MaxLength = 20;
            txtCIN.Name = "txtCIN";
            txtCIN.Size = new Size(150, 23);
            txtCIN.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(402, 65);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(150, 23);
            txtEmail.TabIndex = 7;
            // 
            // txtMatricule
            // 
            txtMatricule.Font = new Font("Segoe UI", 9F);
            txtMatricule.Location = new Point(124, 62);
            txtMatricule.MaxLength = 50;
            txtMatricule.Name = "txtMatricule";
            txtMatricule.Size = new Size(150, 23);
            txtMatricule.TabIndex = 5;
            // 
            // txtPrenom
            // 
            txtPrenom.Font = new Font("Segoe UI", 9F);
            txtPrenom.Location = new Point(402, 35);
            txtPrenom.MaxLength = 100;
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(150, 23);
            txtPrenom.TabIndex = 3;
            // 
            // txtNom
            // 
            txtNom.Font = new Font("Segoe UI", 9F);
            txtNom.Location = new Point(124, 32);
            txtNom.MaxLength = 100;
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(150, 23);
            txtNom.TabIndex = 1;
            // 
            // groupBoxSearch
            // 
            groupBoxSearch.Controls.Add(btnClearSearch);
            groupBoxSearch.Controls.Add(txtSearch);
            groupBoxSearch.Controls.Add(lblSearch);
            groupBoxSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxSearch.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxSearch.Location = new Point(15, 15);
            groupBoxSearch.Name = "groupBoxSearch";
            groupBoxSearch.Padding = new Padding(10);
            groupBoxSearch.Size = new Size(1000, 60);
            groupBoxSearch.TabIndex = 0;
            groupBoxSearch.TabStop = false;
            groupBoxSearch.Text = "Recherche d'Employés";
            // 
            // btnClearSearch
            // 
            btnClearSearch.BackColor = Color.FromArgb(149, 165, 166);
            btnClearSearch.FlatAppearance.BorderSize = 0;
            btnClearSearch.FlatStyle = FlatStyle.Flat;
            btnClearSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearSearch.ForeColor = Color.White;
            btnClearSearch.Location = new Point(380, 21);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(75, 25);
            btnClearSearch.TabIndex = 2;
            btnClearSearch.Text = "Effacer";
            btnClearSearch.UseVisualStyleBackColor = false;
            btnClearSearch.Click += btnClearSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.Location = new Point(70, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Rechercher par nom, prénom ou matricule...";
            txtSearch.Size = new Size(300, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F);
            lblSearch.ForeColor = Color.FromArgb(64, 64, 64);
            lblSearch.Location = new Point(20, 25);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(37, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Nom:";
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1030, 685);
            Controls.Add(groupBoxSearch);
            Controls.Add(groupBoxDetails);
            Controls.Add(groupBoxList);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion des Employés - HR Scheduling System";
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            groupBoxList.ResumeLayout(false);
            groupBoxDetails.ResumeLayout(false);
            groupBoxDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
            groupBoxSearch.ResumeLayout(false);
            groupBoxSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtMatricule;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCIN;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.DateTimePicker dtpDateNaissance;
        private System.Windows.Forms.DateTimePicker dtpDateEmbauche;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.CheckBox chkStatut;
        private System.Windows.Forms.TextBox txtSalaire;
        private System.Windows.Forms.TextBox txtNbHeuretravail;
        private System.Windows.Forms.TextBox txtNbJourtravail;
        private System.Windows.Forms.TextBox txtPoste;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblMatricule;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblCIN;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblDateNaissance;
        private System.Windows.Forms.Label lblDateEmbauche;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.Label lblSalaire;
        private System.Windows.Forms.Label lblNbHeuretravail;
        private System.Windows.Forms.Label lblNbJourtravail;
        private System.Windows.Forms.Label lblPoste;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private Label label1;
        private TextBox txtBiometric;
    }
}
