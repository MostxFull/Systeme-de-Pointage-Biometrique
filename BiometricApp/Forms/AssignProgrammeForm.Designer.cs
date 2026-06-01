namespace HRSchedulingSystem.Forms
{
    partial class AssignProgrammeForm
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
            this.dgvAssignments = new System.Windows.Forms.DataGridView();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.cmbProgramme = new System.Windows.Forms.ComboBox();
            this.dtpDateAffectation = new System.Windows.Forms.DateTimePicker();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblProgramme = new System.Windows.Forms.Label();
            this.lblDateAffectation = new System.Windows.Forms.Label();
            this.groupBoxAssignments = new System.Windows.Forms.GroupBox();
            this.groupBoxAssign = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).BeginInit();
            this.groupBoxAssignments.SuspendLayout();
            this.groupBoxAssign.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAssignments
            // 
            this.groupBoxAssignments.Controls.Add(this.dgvAssignments);
            this.groupBoxAssignments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxAssignments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxAssignments.Location = new System.Drawing.Point(15, 15);
            this.groupBoxAssignments.Name = "groupBoxAssignments";
            this.groupBoxAssignments.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxAssignments.Size = new System.Drawing.Size(800, 350);
            this.groupBoxAssignments.TabIndex = 0;
            this.groupBoxAssignments.TabStop = false;
            this.groupBoxAssignments.Text = "Affectations Actuelles";
            // 
            // dgvAssignments
            // 
            this.dgvAssignments.AllowUserToAddRows = false;
            this.dgvAssignments.AllowUserToDeleteRows = false;
            this.dgvAssignments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssignments.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAssignments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAssignments.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvAssignments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.dgvAssignments.Location = new System.Drawing.Point(10, 26);
            this.dgvAssignments.MultiSelect = false;
            this.dgvAssignments.Name = "dgvAssignments";
            this.dgvAssignments.ReadOnly = true;
            this.dgvAssignments.RowHeadersWidth = 51;
            this.dgvAssignments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssignments.Size = new System.Drawing.Size(780, 314);
            this.dgvAssignments.TabIndex = 0;
            // 
            // groupBoxAssign
            // 
            this.groupBoxAssign.Controls.Add(this.btnClear);
            this.groupBoxAssign.Controls.Add(this.btnAssign);
            this.groupBoxAssign.Controls.Add(this.dtpDateAffectation);
            this.groupBoxAssign.Controls.Add(this.lblDateAffectation);
            this.groupBoxAssign.Controls.Add(this.cmbProgramme);
            this.groupBoxAssign.Controls.Add(this.lblProgramme);
            this.groupBoxAssign.Controls.Add(this.cmbEmployee);
            this.groupBoxAssign.Controls.Add(this.lblEmployee);
            this.groupBoxAssign.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxAssign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxAssign.Location = new System.Drawing.Point(15, 375);
            this.groupBoxAssign.Name = "groupBoxAssign";
            this.groupBoxAssign.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxAssign.Size = new System.Drawing.Size(800, 120);
            this.groupBoxAssign.TabIndex = 1;
            this.groupBoxAssign.TabStop = false;
            this.groupBoxAssign.Text = "Affecter un Programme à un Employé";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmployee.Location = new System.Drawing.Point(20, 35);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(57, 15);
            this.lblEmployee.TabIndex = 0;
            this.lblEmployee.Text = "Employé:";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(100, 32);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(200, 23);
            this.cmbEmployee.TabIndex = 1;
            // 
            // lblProgramme
            // 
            this.lblProgramme.AutoSize = true;
            this.lblProgramme.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProgramme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblProgramme.Location = new System.Drawing.Point(320, 35);
            this.lblProgramme.Name = "lblProgramme";
            this.lblProgramme.Size = new System.Drawing.Size(74, 15);
            this.lblProgramme.TabIndex = 2;
            this.lblProgramme.Text = "Programme:";
            // 
            // cmbProgramme
            // 
            this.cmbProgramme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgramme.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbProgramme.FormattingEnabled = true;
            this.cmbProgramme.Location = new System.Drawing.Point(400, 32);
            this.cmbProgramme.Name = "cmbProgramme";
            this.cmbProgramme.Size = new System.Drawing.Size(200, 23);
            this.cmbProgramme.TabIndex = 3;
            // 
            // lblDateAffectation
            // 
            this.lblDateAffectation.AutoSize = true;
            this.lblDateAffectation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateAffectation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDateAffectation.Location = new System.Drawing.Point(20, 70);
            this.lblDateAffectation.Name = "lblDateAffectation";
            this.lblDateAffectation.Size = new System.Drawing.Size(101, 15);
            this.lblDateAffectation.TabIndex = 4;
            this.lblDateAffectation.Text = "Date Affectation:";
            // 
            // dtpDateAffectation
            // 
            this.dtpDateAffectation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDateAffectation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateAffectation.Location = new System.Drawing.Point(130, 67);
            this.dtpDateAffectation.Name = "dtpDateAffectation";
            this.dtpDateAffectation.Size = new System.Drawing.Size(120, 23);
            this.dtpDateAffectation.TabIndex = 5;
            // 
            // btnAssign
            // 
            this.btnAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAssign.FlatAppearance.BorderSize = 0;
            this.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssign.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAssign.ForeColor = System.Drawing.Color.White;
            this.btnAssign.Location = new System.Drawing.Point(620, 32);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(80, 35);
            this.btnAssign.TabIndex = 6;
            this.btnAssign.Text = "Affecter";
            this.btnAssign.UseVisualStyleBackColor = false;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(710, 32);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 35);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Effacer";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // AssignProgrammeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(830, 510);
            this.Controls.Add(this.groupBoxAssign);
            this.Controls.Add(this.groupBoxAssignments);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AssignProgrammeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Affectation de Programmes - HR Scheduling System";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).EndInit();
            this.groupBoxAssignments.ResumeLayout(false);
            this.groupBoxAssign.ResumeLayout(false);
            this.groupBoxAssign.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAssignments;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.ComboBox cmbProgramme;
        private System.Windows.Forms.DateTimePicker dtpDateAffectation;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblProgramme;
        private System.Windows.Forms.Label lblDateAffectation;
        private System.Windows.Forms.GroupBox groupBoxAssignments;
        private System.Windows.Forms.GroupBox groupBoxAssign;
    }
}
