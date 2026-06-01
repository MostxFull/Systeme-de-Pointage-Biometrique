namespace HRSchedulingSystem.Forms
{
    partial class AddDeviceForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.NumericUpDown numNumero;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.Panel panelDeviceList;
        private System.Windows.Forms.Panel panelDeviceForm;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDeviceCount;
        private System.Windows.Forms.Label lblDeviceListTitle;
        private System.Windows.Forms.Splitter splitter1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelMain = new Panel();
            panelDeviceList = new Panel();
            dgvDevices = new DataGridView();
            lblDeviceCount = new Label();
            lblDeviceListTitle = new Label();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnClose = new Button();
            splitter1 = new Splitter();
            panelDeviceForm = new Panel();
            lblTitle = new Label();
            lblNumero = new Label();
            numNumero = new NumericUpDown();
            lblNom = new Label();
            txtNom = new TextBox();
            lblIP = new Label();
            txtIP = new TextBox();
            lblPort = new Label();
            numPort = new NumericUpDown();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnTestConnection = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            panelMain.SuspendLayout();
            panelDeviceList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).BeginInit();
            panelDeviceForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numNumero).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPort).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(236, 240, 241);
            panelMain.Controls.Add(panelDeviceForm);
            panelMain.Controls.Add(splitter1);
            panelMain.Controls.Add(panelDeviceList);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1000, 600);
            panelMain.TabIndex = 0;
            // 
            // panelDeviceList
            // 
            panelDeviceList.BackColor = Color.White;
            panelDeviceList.Controls.Add(dgvDevices);
            panelDeviceList.Controls.Add(lblDeviceCount);
            panelDeviceList.Controls.Add(lblDeviceListTitle);
            panelDeviceList.Controls.Add(btnAdd);
            panelDeviceList.Controls.Add(btnEdit);
            panelDeviceList.Controls.Add(btnDelete);
            panelDeviceList.Controls.Add(btnRefresh);
            panelDeviceList.Controls.Add(btnClose);
            panelDeviceList.Dock = DockStyle.Left;
            panelDeviceList.Location = new Point(0, 0);
            panelDeviceList.Name = "panelDeviceList";
            panelDeviceList.Size = new Size(550, 600);
            panelDeviceList.TabIndex = 0;
            // 
            // lblDeviceListTitle
            // 
            lblDeviceListTitle.AutoSize = true;
            lblDeviceListTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDeviceListTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblDeviceListTitle.Location = new Point(20, 20);
            lblDeviceListTitle.Name = "lblDeviceListTitle";
            lblDeviceListTitle.Size = new Size(165, 25);
            lblDeviceListTitle.TabIndex = 0;
            lblDeviceListTitle.Text = "Liste des Appareils";
            // 
            // dgvDevices
            // 
            dgvDevices.AllowUserToAddRows = false;
            dgvDevices.AllowUserToDeleteRows = false;
            dgvDevices.BackgroundColor = Color.White;
            dgvDevices.BorderStyle = BorderStyle.FixedSingle;
            dgvDevices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDevices.Location = new Point(20, 80);
            dgvDevices.Name = "dgvDevices";
            dgvDevices.ReadOnly = true;
            dgvDevices.RowHeadersVisible = false;
            dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevices.Size = new Size(510, 400);
            dgvDevices.TabIndex = 1;
            // 
            // lblDeviceCount
            // 
            lblDeviceCount.AutoSize = true;
            lblDeviceCount.Font = new Font("Segoe UI", 9F);
            lblDeviceCount.ForeColor = Color.FromArgb(108, 117, 125);
            lblDeviceCount.Location = new Point(20, 490);
            lblDeviceCount.Name = "lblDeviceCount";
            lblDeviceCount.Size = new Size(116, 15);
            lblDeviceCount.TabIndex = 2;
            lblDeviceCount.Text = "Total Appareils: 0";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(40, 167, 69);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(20, 520);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(115, 30);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Ajouter Nouveau";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(255, 193, 7);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(140, 520);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(80, 30);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Modifier";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(230, 520);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 30);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Supprimer";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(23, 162, 184);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(330, 520);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Actualiser";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(450, 520);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(80, 30);
            btnClose.TabIndex = 7;
            btnClose.Text = "Fermer";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(550, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 600);
            splitter1.TabIndex = 1;
            splitter1.TabStop = false;
            // 
            // panelDeviceForm
            // 
            panelDeviceForm.BackColor = Color.FromArgb(236, 240, 241);
            panelDeviceForm.Controls.Add(lblTitle);
            panelDeviceForm.Controls.Add(lblNumero);
            panelDeviceForm.Controls.Add(numNumero);
            panelDeviceForm.Controls.Add(lblNom);
            panelDeviceForm.Controls.Add(txtNom);
            panelDeviceForm.Controls.Add(lblIP);
            panelDeviceForm.Controls.Add(txtIP);
            panelDeviceForm.Controls.Add(lblPort);
            panelDeviceForm.Controls.Add(numPort);
            panelDeviceForm.Controls.Add(lblPassword);
            panelDeviceForm.Controls.Add(txtPassword);
            panelDeviceForm.Controls.Add(btnTestConnection);
            panelDeviceForm.Controls.Add(btnSave);
            panelDeviceForm.Controls.Add(btnCancel);
            panelDeviceForm.Dock = DockStyle.Fill;
            panelDeviceForm.Location = new Point(553, 0);
            panelDeviceForm.Name = "panelDeviceForm";
            panelDeviceForm.Size = new Size(447, 600);
            panelDeviceForm.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(239, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Gestion des Appareils";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Font = new Font("Segoe UI", 9F);
            lblNumero.ForeColor = Color.FromArgb(64, 64, 64);
            lblNumero.Location = new Point(30, 80);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(117, 15);
            lblNumero.TabIndex = 1;
            lblNumero.Text = "Numéro d'Appareil:";
            // 
            // numNumero
            // 
            numNumero.BorderStyle = BorderStyle.FixedSingle;
            numNumero.Font = new Font("Segoe UI", 9F);
            numNumero.Location = new Point(30, 100);
            numNumero.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numNumero.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numNumero.Name = "numNumero";
            numNumero.Size = new Size(380, 23);
            numNumero.TabIndex = 2;
            numNumero.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Font = new Font("Segoe UI", 9F);
            lblNom.ForeColor = Color.FromArgb(64, 64, 64);
            lblNom.Location = new Point(30, 140);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(105, 15);
            lblNom.TabIndex = 3;
            lblNom.Text = "Nom d'Appareil:";
            // 
            // txtNom
            // 
            txtNom.BorderStyle = BorderStyle.FixedSingle;
            txtNom.Font = new Font("Segoe UI", 9F);
            txtNom.Location = new Point(30, 160);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(380, 23);
            txtNom.TabIndex = 4;
            txtNom.TextChanged += txtIP_TextChanged;
            // 
            // lblIP
            // 
            lblIP.AutoSize = true;
            lblIP.Font = new Font("Segoe UI", 9F);
            lblIP.ForeColor = Color.FromArgb(64, 64, 64);
            lblIP.Location = new Point(30, 200);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(70, 15);
            lblIP.TabIndex = 5;
            lblIP.Text = "Adresse IP:";
            // 
            // txtIP
            // 
            txtIP.BorderStyle = BorderStyle.FixedSingle;
            txtIP.Font = new Font("Segoe UI", 9F);
            txtIP.Location = new Point(30, 220);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(240, 23);
            txtIP.TabIndex = 6;
            txtIP.Text = "192.168.1.100";
            txtIP.TextChanged += txtIP_TextChanged;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Font = new Font("Segoe UI", 9F);
            lblPort.ForeColor = Color.FromArgb(64, 64, 64);
            lblPort.Location = new Point(290, 200);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(32, 15);
            lblPort.TabIndex = 7;
            lblPort.Text = "Port:";
            // 
            // numPort
            // 
            numPort.BorderStyle = BorderStyle.FixedSingle;
            numPort.Font = new Font("Segoe UI", 9F);
            numPort.Location = new Point(290, 220);
            numPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPort.Name = "numPort";
            numPort.Size = new Size(120, 23);
            numPort.TabIndex = 8;
            numPort.Value = new decimal(new int[] { 4370, 0, 0, 0 });
            numPort.ValueChanged += numPort_ValueChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F);
            lblPassword.ForeColor = Color.FromArgb(64, 64, 64);
            lblPassword.Location = new Point(30, 260);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(81, 15);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Mot de passe:";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.Location = new Point(30, 280);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(240, 23);
            txtPassword.TabIndex = 10;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnTestConnection
            // 
            btnTestConnection.BackColor = Color.FromArgb(255, 193, 7);
            btnTestConnection.FlatAppearance.BorderSize = 0;
            btnTestConnection.FlatStyle = FlatStyle.Flat;
            btnTestConnection.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTestConnection.ForeColor = Color.White;
            btnTestConnection.Location = new Point(290, 280);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(120, 23);
            btnTestConnection.TabIndex = 11;
            btnTestConnection.Text = "Tester Connexion";
            btnTestConnection.UseVisualStyleBackColor = false;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(40, 167, 69);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(230, 340);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(115, 30);
            btnSave.TabIndex = 12;
            btnSave.Text = "Ajouter Appareil";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(355, 340);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 30);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Annuler";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddDeviceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1000, 600);
            Controls.Add(panelMain);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(1000, 600);
            Name = "AddDeviceForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestion des Appareils";
            panelMain.ResumeLayout(false);
            panelDeviceList.ResumeLayout(false);
            panelDeviceList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).EndInit();
            panelDeviceForm.ResumeLayout(false);
            panelDeviceForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numNumero).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPort).EndInit();
            ResumeLayout(false);
        }
    }
}
