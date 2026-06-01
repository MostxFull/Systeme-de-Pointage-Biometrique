namespace HRSchedulingSystem.Forms
{
    partial class AttendanceCollectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnConnectAll;
        private System.Windows.Forms.Button btnDisconnectAll;
        private System.Windows.Forms.Button btnStartPolling;
        private System.Windows.Forms.Button btnStopPolling;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.NumericUpDown numPollingInterval;
        private System.Windows.Forms.Label lblPollingInterval;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBoxDevices;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.GroupBox groupBoxAttendance;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.GroupBox groupBoxLogs;
        private System.Windows.Forms.TextBox txtErrorLog;
        private System.Windows.Forms.Label lblTitle;

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
            panelTop = new Panel();
            button1 = new Button();
            lblTitle = new Label();
            btnConnectAll = new Button();
            btnDisconnectAll = new Button();
            btnStartPolling = new Button();
            btnStopPolling = new Button();
            btnAddDevice = new Button();
            btnClearLogs = new Button();
            btnRefresh = new Button();
            lblPollingInterval = new Label();
            numPollingInterval = new NumericUpDown();
            lblStatus = new Label();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            groupBoxDevices = new GroupBox();
            dgvDevices = new DataGridView();
            groupBoxAttendance = new GroupBox();
            dgvAttendance = new DataGridView();
            groupBoxLogs = new GroupBox();
            txtErrorLog = new TextBox();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPollingInterval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBoxDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).BeginInit();
            groupBoxAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            groupBoxLogs.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(button1);
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(btnConnectAll);
            panelTop.Controls.Add(btnDisconnectAll);
            panelTop.Controls.Add(btnStartPolling);
            panelTop.Controls.Add(btnStopPolling);
            panelTop.Controls.Add(btnAddDevice);
            panelTop.Controls.Add(btnClearLogs);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(lblPollingInterval);
            panelTop.Controls.Add(numPollingInterval);
            panelTop.Controls.Add(lblStatus);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1200, 100);
            panelTop.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(23, 162, 184);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1071, 15);
            button1.Name = "button1";
            button1.Size = new Size(119, 30);
            button1.TabIndex = 11;
            button1.Text = "Gestion Pointage";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Location = new Point(25, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(361, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Collecte de Présence Biométrique";
            // 
            // btnConnectAll
            // 
            btnConnectAll.BackColor = Color.FromArgb(40, 167, 69);
            btnConnectAll.FlatAppearance.BorderSize = 0;
            btnConnectAll.FlatStyle = FlatStyle.Flat;
            btnConnectAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConnectAll.ForeColor = Color.White;
            btnConnectAll.Location = new Point(25, 48);
            btnConnectAll.Name = "btnConnectAll";
            btnConnectAll.Size = new Size(90, 43);
            btnConnectAll.TabIndex = 1;
            btnConnectAll.Text = "Connecter Tout";
            btnConnectAll.UseVisualStyleBackColor = false;
            btnConnectAll.Click += btnConnectAll_Click;
            // 
            // btnDisconnectAll
            // 
            btnDisconnectAll.BackColor = Color.FromArgb(220, 53, 69);
            btnDisconnectAll.FlatAppearance.BorderSize = 0;
            btnDisconnectAll.FlatStyle = FlatStyle.Flat;
            btnDisconnectAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDisconnectAll.ForeColor = Color.White;
            btnDisconnectAll.Location = new Point(125, 48);
            btnDisconnectAll.Name = "btnDisconnectAll";
            btnDisconnectAll.Size = new Size(90, 43);
            btnDisconnectAll.TabIndex = 2;
            btnDisconnectAll.Text = "Déconnecter Tout";
            btnDisconnectAll.UseVisualStyleBackColor = false;
            btnDisconnectAll.Click += btnDisconnectAll_Click;
            // 
            // btnStartPolling
            // 
            btnStartPolling.BackColor = Color.FromArgb(0, 123, 255);
            btnStartPolling.FlatAppearance.BorderSize = 0;
            btnStartPolling.FlatStyle = FlatStyle.Flat;
            btnStartPolling.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStartPolling.ForeColor = Color.White;
            btnStartPolling.Location = new Point(225, 48);
            btnStartPolling.Name = "btnStartPolling";
            btnStartPolling.Size = new Size(90, 43);
            btnStartPolling.TabIndex = 3;
            btnStartPolling.Text = "Démarrer Collecte";
            btnStartPolling.UseVisualStyleBackColor = false;
            btnStartPolling.Click += btnStartPolling_Click;
            // 
            // btnStopPolling
            // 
            btnStopPolling.BackColor = Color.FromArgb(255, 193, 7);
            btnStopPolling.Enabled = false;
            btnStopPolling.FlatAppearance.BorderSize = 0;
            btnStopPolling.FlatStyle = FlatStyle.Flat;
            btnStopPolling.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStopPolling.ForeColor = Color.White;
            btnStopPolling.Location = new Point(321, 48);
            btnStopPolling.Name = "btnStopPolling";
            btnStopPolling.Size = new Size(94, 43);
            btnStopPolling.TabIndex = 4;
            btnStopPolling.Text = "Arrêter Collecte";
            btnStopPolling.UseVisualStyleBackColor = false;
            btnStopPolling.Click += btnStopPolling_Click;
            // 
            // btnAddDevice
            // 
            btnAddDevice.BackColor = Color.FromArgb(111, 66, 193);
            btnAddDevice.FlatAppearance.BorderSize = 0;
            btnAddDevice.FlatStyle = FlatStyle.Flat;
            btnAddDevice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddDevice.ForeColor = Color.White;
            btnAddDevice.Location = new Point(425, 48);
            btnAddDevice.Name = "btnAddDevice";
            btnAddDevice.Size = new Size(110, 43);
            btnAddDevice.TabIndex = 5;
            btnAddDevice.Text = "Ajouter Appareil";
            btnAddDevice.UseVisualStyleBackColor = false;
            btnAddDevice.Click += btnAddDevice_Click;
            // 
            // btnClearLogs
            // 
            btnClearLogs.BackColor = Color.FromArgb(108, 117, 125);
            btnClearLogs.FlatAppearance.BorderSize = 0;
            btnClearLogs.FlatStyle = FlatStyle.Flat;
            btnClearLogs.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearLogs.ForeColor = Color.White;
            btnClearLogs.Location = new Point(541, 48);
            btnClearLogs.Name = "btnClearLogs";
            btnClearLogs.Size = new Size(90, 42);
            btnClearLogs.TabIndex = 6;
            btnClearLogs.Text = "Effacer Logs";
            btnClearLogs.UseVisualStyleBackColor = false;
            btnClearLogs.Click += btnClearLogs_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(23, 162, 184);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(637, 48);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 43);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Actualiser";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblPollingInterval
            // 
            lblPollingInterval.AutoSize = true;
            lblPollingInterval.Font = new Font("Segoe UI", 9F);
            lblPollingInterval.ForeColor = Color.FromArgb(64, 64, 64);
            lblPollingInterval.Location = new Point(743, 60);
            lblPollingInterval.Name = "lblPollingInterval";
            lblPollingInterval.Size = new Size(136, 15);
            lblPollingInterval.TabIndex = 8;
            lblPollingInterval.Text = "Intervalle de Collecte (s):";
            // 
            // numPollingInterval
            // 
            numPollingInterval.BorderStyle = BorderStyle.FixedSingle;
            numPollingInterval.Font = new Font("Segoe UI", 9F);
            numPollingInterval.Location = new Point(885, 58);
            numPollingInterval.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numPollingInterval.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numPollingInterval.Name = "numPollingInterval";
            numPollingInterval.Size = new Size(60, 23);
            numPollingInterval.TabIndex = 9;
            numPollingInterval.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(40, 167, 69);
            lblStatus.Location = new Point(959, 60);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(37, 19);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Prêt";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 100);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBoxLogs);
            splitContainer1.Size = new Size(1200, 600);
            splitContainer1.SplitterDistance = 400;
            splitContainer1.TabIndex = 11;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(groupBoxDevices);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(groupBoxAttendance);
            splitContainer2.Size = new Size(1200, 400);
            splitContainer2.SplitterDistance = 400;
            splitContainer2.TabIndex = 0;
            // 
            // groupBoxDevices
            // 
            groupBoxDevices.Controls.Add(dgvDevices);
            groupBoxDevices.Dock = DockStyle.Fill;
            groupBoxDevices.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxDevices.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxDevices.Location = new Point(0, 0);
            groupBoxDevices.Name = "groupBoxDevices";
            groupBoxDevices.Padding = new Padding(10);
            groupBoxDevices.Size = new Size(400, 400);
            groupBoxDevices.TabIndex = 0;
            groupBoxDevices.TabStop = false;
            groupBoxDevices.Text = "Appareils Biométriques";
            // 
            // dgvDevices
            // 
            dgvDevices.AllowUserToAddRows = false;
            dgvDevices.AllowUserToDeleteRows = false;
            dgvDevices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDevices.BackgroundColor = Color.White;
            dgvDevices.BorderStyle = BorderStyle.None;
            dgvDevices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDevices.Dock = DockStyle.Fill;
            dgvDevices.Font = new Font("Segoe UI", 9F);
            dgvDevices.Location = new Point(10, 28);
            dgvDevices.Name = "dgvDevices";
            dgvDevices.ReadOnly = true;
            dgvDevices.RowHeadersVisible = false;
            dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevices.Size = new Size(380, 362);
            dgvDevices.TabIndex = 0;
            // 
            // groupBoxAttendance
            // 
            groupBoxAttendance.Controls.Add(dgvAttendance);
            groupBoxAttendance.Dock = DockStyle.Fill;
            groupBoxAttendance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxAttendance.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxAttendance.Location = new Point(0, 0);
            groupBoxAttendance.Name = "groupBoxAttendance";
            groupBoxAttendance.Padding = new Padding(10);
            groupBoxAttendance.Size = new Size(796, 400);
            groupBoxAttendance.TabIndex = 0;
            groupBoxAttendance.TabStop = false;
            groupBoxAttendance.Text = "Logs de Présence en Direct";
            // 
            // dgvAttendance
            // 
            dgvAttendance.AllowUserToAddRows = false;
            dgvAttendance.AllowUserToDeleteRows = false;
            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance.BackgroundColor = Color.White;
            dgvAttendance.BorderStyle = BorderStyle.None;
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendance.Dock = DockStyle.Fill;
            dgvAttendance.Font = new Font("Segoe UI", 9F);
            dgvAttendance.Location = new Point(10, 28);
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.ReadOnly = true;
            dgvAttendance.RowHeadersVisible = false;
            dgvAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttendance.Size = new Size(776, 362);
            dgvAttendance.TabIndex = 0;
            // 
            // groupBoxLogs
            // 
            groupBoxLogs.Controls.Add(txtErrorLog);
            groupBoxLogs.Dock = DockStyle.Fill;
            groupBoxLogs.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxLogs.ForeColor = Color.FromArgb(64, 64, 64);
            groupBoxLogs.Location = new Point(0, 0);
            groupBoxLogs.Name = "groupBoxLogs";
            groupBoxLogs.Padding = new Padding(10);
            groupBoxLogs.Size = new Size(1200, 196);
            groupBoxLogs.TabIndex = 0;
            groupBoxLogs.TabStop = false;
            groupBoxLogs.Text = "Logs Système et Erreurs";
            // 
            // txtErrorLog
            // 
            txtErrorLog.BackColor = Color.FromArgb(248, 249, 250);
            txtErrorLog.BorderStyle = BorderStyle.None;
            txtErrorLog.Dock = DockStyle.Fill;
            txtErrorLog.Font = new Font("Consolas", 9F);
            txtErrorLog.Location = new Point(10, 28);
            txtErrorLog.Multiline = true;
            txtErrorLog.Name = "txtErrorLog";
            txtErrorLog.ReadOnly = true;
            txtErrorLog.ScrollBars = ScrollBars.Vertical;
            txtErrorLog.Size = new Size(1180, 158);
            txtErrorLog.TabIndex = 0;
            // 
            // AttendanceCollectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1200, 700);
            Controls.Add(splitContainer1);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1000, 600);
            Name = "AttendanceCollectionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Système de Collecte de Présence Biométrique";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPollingInterval).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBoxDevices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDevices).EndInit();
            groupBoxAttendance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            groupBoxLogs.ResumeLayout(false);
            groupBoxLogs.PerformLayout();
            ResumeLayout(false);
        }
        private Button button1;
    }
}
