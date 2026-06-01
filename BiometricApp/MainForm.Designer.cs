namespace HRSchedulingSystem
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            masterDataToolStripMenuItem = new ToolStripMenuItem();
            societesToolStripMenuItem = new ToolStripMenuItem();
            departementsToolStripMenuItem = new ToolStripMenuItem();
            servicesToolStripMenuItem = new ToolStripMenuItem();
            employeesToolStripMenuItem = new ToolStripMenuItem();
            shiftsToolStripMenuItem = new ToolStripMenuItem();
            absencesToolStripMenuItem = new ToolStripMenuItem();
            schedulingToolStripMenuItem = new ToolStripMenuItem();
            programmesToolStripMenuItem = new ToolStripMenuItem();
            assignProgrammeToolStripMenuItem = new ToolStripMenuItem();
            viewScheduleToolStripMenuItem = new ToolStripMenuItem();
            attendanceToolStripMenuItem = new ToolStripMenuItem();
            pointageToolStripMenuItem = new ToolStripMenuItem();
            poitageMaunelToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem1 = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem1 = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            panelMain = new Panel();
            panelContent = new Panel();
            tableLayoutMain = new TableLayoutPanel();
            panelMasterData = new Panel();
            btnAbsences = new Button();
            btnShifts = new Button();
            btnServices = new Button();
            btnDepartements = new Button();
            btnSocietes = new Button();
            btnEmployees = new Button();
            lblMasterDataTitle = new Label();
            panelScheduling = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            btnAttendanceCollection = new Button();
            btnSchedules = new Button();
            btnAssignProgramme = new Button();
            btnProgrammes = new Button();
            lblSchedulingTitle = new Label();
            panelQuickStats = new Panel();
            lblPendingAbsences = new Label();
            lblActiveSchedules = new Label();
            lblTotalEmployees = new Label();
            lblQuickStatsTitle = new Label();
            panelHeader = new Panel();
            lblDateTime = new Label();
            lblDescription = new Label();
            lblWelcome = new Label();
            timerDateTime = new System.Windows.Forms.Timer(components);
            actualiserToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            panelMain.SuspendLayout();
            panelContent.SuspendLayout();
            tableLayoutMain.SuspendLayout();
            panelMasterData.SuspendLayout();
            panelScheduling.SuspendLayout();
            panelQuickStats.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.FromArgb(240, 240, 240);
            menuStrip.Font = new Font("Segoe UI", 9F);
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, masterDataToolStripMenuItem, schedulingToolStripMenuItem, attendanceToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(5, 2, 0, 2);
            menuStrip.Size = new Size(1200, 24);
            menuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { actualiserToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 20);
            fileToolStripMenuItem.Text = "&Fichier";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "&Quitter";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // masterDataToolStripMenuItem
            // 
            masterDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { societesToolStripMenuItem, departementsToolStripMenuItem, servicesToolStripMenuItem, employeesToolStripMenuItem, shiftsToolStripMenuItem, absencesToolStripMenuItem });
            masterDataToolStripMenuItem.Name = "masterDataToolStripMenuItem";
            masterDataToolStripMenuItem.Size = new Size(108, 20);
            masterDataToolStripMenuItem.Text = "&Données de Base";
            // 
            // societesToolStripMenuItem
            // 
            societesToolStripMenuItem.Name = "societesToolStripMenuItem";
            societesToolStripMenuItem.Size = new Size(180, 22);
            societesToolStripMenuItem.Text = "&Sociétés";
            societesToolStripMenuItem.Click += societesToolStripMenuItem_Click;
            // 
            // departementsToolStripMenuItem
            // 
            departementsToolStripMenuItem.Name = "departementsToolStripMenuItem";
            departementsToolStripMenuItem.Size = new Size(180, 22);
            departementsToolStripMenuItem.Text = "&Départements";
            departementsToolStripMenuItem.Click += departementsToolStripMenuItem_Click;
            // 
            // servicesToolStripMenuItem
            // 
            servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            servicesToolStripMenuItem.Size = new Size(180, 22);
            servicesToolStripMenuItem.Text = "S&ervices";
            servicesToolStripMenuItem.Click += servicesToolStripMenuItem_Click;
            // 
            // employeesToolStripMenuItem
            // 
            employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            employeesToolStripMenuItem.Size = new Size(180, 22);
            employeesToolStripMenuItem.Text = "&Employés";
            employeesToolStripMenuItem.Click += employeesToolStripMenuItem_Click;
            // 
            // shiftsToolStripMenuItem
            // 
            shiftsToolStripMenuItem.Name = "shiftsToolStripMenuItem";
            shiftsToolStripMenuItem.Size = new Size(180, 22);
            shiftsToolStripMenuItem.Text = "&Équipes";
            shiftsToolStripMenuItem.Click += shiftsToolStripMenuItem_Click;
            // 
            // absencesToolStripMenuItem
            // 
            absencesToolStripMenuItem.Name = "absencesToolStripMenuItem";
            absencesToolStripMenuItem.Size = new Size(180, 22);
            absencesToolStripMenuItem.Text = "&Absences";
            absencesToolStripMenuItem.Click += absencesToolStripMenuItem_Click;
            // 
            // schedulingToolStripMenuItem
            // 
            schedulingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { programmesToolStripMenuItem, assignProgrammeToolStripMenuItem, viewScheduleToolStripMenuItem });
            schedulingToolStripMenuItem.Name = "schedulingToolStripMenuItem";
            schedulingToolStripMenuItem.Size = new Size(85, 20);
            schedulingToolStripMenuItem.Text = "&Planification";
            // 
            // programmesToolStripMenuItem
            // 
            programmesToolStripMenuItem.Name = "programmesToolStripMenuItem";
            programmesToolStripMenuItem.Size = new Size(185, 22);
            programmesToolStripMenuItem.Text = "&Programmes";
            programmesToolStripMenuItem.Click += programmesToolStripMenuItem_Click;
            // 
            // assignProgrammeToolStripMenuItem
            // 
            assignProgrammeToolStripMenuItem.Name = "assignProgrammeToolStripMenuItem";
            assignProgrammeToolStripMenuItem.Size = new Size(185, 22);
            assignProgrammeToolStripMenuItem.Text = "&Assigner Programme";
            assignProgrammeToolStripMenuItem.Click += assignProgrammeToolStripMenuItem_Click;
            // 
            // viewScheduleToolStripMenuItem
            // 
            viewScheduleToolStripMenuItem.Name = "viewScheduleToolStripMenuItem";
            viewScheduleToolStripMenuItem.Size = new Size(185, 22);
            viewScheduleToolStripMenuItem.Text = "&Voir Planning";
            viewScheduleToolStripMenuItem.Click += viewScheduleToolStripMenuItem_Click;
            // 
            // attendanceToolStripMenuItem
            // 
            attendanceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pointageToolStripMenuItem, poitageMaunelToolStripMenuItem });
            attendanceToolStripMenuItem.Name = "attendanceToolStripMenuItem";
            attendanceToolStripMenuItem.Size = new Size(66, 20);
            attendanceToolStripMenuItem.Text = "Présence";
            // 
            // pointageToolStripMenuItem
            // 
            pointageToolStripMenuItem.Name = "pointageToolStripMenuItem";
            pointageToolStripMenuItem.Size = new Size(180, 22);
            pointageToolStripMenuItem.Text = "Pointages";
            pointageToolStripMenuItem.Click += pointageToolStripMenuItem_Click;
            // 
            // poitageMaunelToolStripMenuItem
            // 
            poitageMaunelToolStripMenuItem.Name = "poitageMaunelToolStripMenuItem";
            poitageMaunelToolStripMenuItem.Size = new Size(180, 22);
            poitageMaunelToolStripMenuItem.Text = "Pointage Manuel";
            poitageMaunelToolStripMenuItem.Click += poitageMaunelToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { helpToolStripMenuItem1, aboutToolStripMenuItem, settingsToolStripMenuItem1 });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(43, 20);
            helpToolStripMenuItem.Text = "&Aide";
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            helpToolStripMenuItem1.Size = new Size(180, 22);
            helpToolStripMenuItem1.Text = "Aide";
            helpToolStripMenuItem1.Click += helpToolStripMenuItem1_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(180, 22);
            aboutToolStripMenuItem.Text = "&À propos";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem1
            // 
            settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            settingsToolStripMenuItem1.Size = new Size(180, 22);
            settingsToolStripMenuItem1.Text = "Paramètres";
            settingsToolStripMenuItem1.Click += settingsToolStripMenuItem1_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(240, 240, 240);
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip.Location = new Point(0, 678);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 12, 0);
            statusStrip.Size = new Size(1200, 22);
            statusStrip.TabIndex = 1;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(28, 17);
            statusLabel.Text = "Prêt";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(248, 249, 250);
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 24);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1200, 654);
            panelMain.TabIndex = 2;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(tableLayoutMain);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 100);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(30, 20, 30, 30);
            panelContent.Size = new Size(1200, 554);
            panelContent.TabIndex = 1;
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.ColumnCount = 3;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutMain.Controls.Add(panelMasterData, 0, 0);
            tableLayoutMain.Controls.Add(panelScheduling, 1, 0);
            tableLayoutMain.Controls.Add(panelQuickStats, 2, 0);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(30, 20);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 1;
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutMain.Size = new Size(1140, 504);
            tableLayoutMain.TabIndex = 0;
            // 
            // panelMasterData
            // 
            panelMasterData.BackColor = Color.White;
            panelMasterData.Controls.Add(btnAbsences);
            panelMasterData.Controls.Add(btnShifts);
            panelMasterData.Controls.Add(btnServices);
            panelMasterData.Controls.Add(btnDepartements);
            panelMasterData.Controls.Add(btnSocietes);
            panelMasterData.Controls.Add(btnEmployees);
            panelMasterData.Controls.Add(lblMasterDataTitle);
            panelMasterData.Dock = DockStyle.Fill;
            panelMasterData.Location = new Point(3, 3);
            panelMasterData.Name = "panelMasterData";
            panelMasterData.Padding = new Padding(20);
            panelMasterData.Size = new Size(450, 498);
            panelMasterData.TabIndex = 0;
            // 
            // btnAbsences
            // 
            btnAbsences.BackColor = Color.FromArgb(23, 162, 184);
            btnAbsences.FlatAppearance.BorderSize = 0;
            btnAbsences.FlatStyle = FlatStyle.Flat;
            btnAbsences.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAbsences.ForeColor = Color.White;
            btnAbsences.Location = new Point(220, 210);
            btnAbsences.Name = "btnAbsences";
            btnAbsences.Size = new Size(180, 50);
            btnAbsences.TabIndex = 6;
            btnAbsences.Text = "📅 Absences";
            btnAbsences.UseVisualStyleBackColor = false;
            btnAbsences.Click += absencesToolStripMenuItem_Click;
            btnAbsences.MouseEnter += Button_MouseEnter;
            btnAbsences.MouseLeave += Button_MouseLeave;
            // 
            // btnShifts
            // 
            btnShifts.BackColor = Color.FromArgb(111, 66, 193);
            btnShifts.FlatAppearance.BorderSize = 0;
            btnShifts.FlatStyle = FlatStyle.Flat;
            btnShifts.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnShifts.ForeColor = Color.White;
            btnShifts.Location = new Point(20, 210);
            btnShifts.Name = "btnShifts";
            btnShifts.Size = new Size(180, 50);
            btnShifts.TabIndex = 5;
            btnShifts.Text = "🕐 Équipes";
            btnShifts.UseVisualStyleBackColor = false;
            btnShifts.Click += btnShifts_Click;
            btnShifts.MouseEnter += Button_MouseEnter;
            btnShifts.MouseLeave += Button_MouseLeave;
            // 
            // btnServices
            // 
            btnServices.BackColor = Color.FromArgb(220, 53, 69);
            btnServices.FlatAppearance.BorderSize = 0;
            btnServices.FlatStyle = FlatStyle.Flat;
            btnServices.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnServices.ForeColor = Color.White;
            btnServices.Location = new Point(220, 140);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(180, 50);
            btnServices.TabIndex = 4;
            btnServices.Text = "⚙️ Services";
            btnServices.UseVisualStyleBackColor = false;
            btnServices.Click += servicesToolStripMenuItem_Click;
            btnServices.MouseEnter += Button_MouseEnter;
            btnServices.MouseLeave += Button_MouseLeave;
            // 
            // btnDepartements
            // 
            btnDepartements.BackColor = Color.FromArgb(255, 193, 7);
            btnDepartements.FlatAppearance.BorderSize = 0;
            btnDepartements.FlatStyle = FlatStyle.Flat;
            btnDepartements.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDepartements.ForeColor = Color.White;
            btnDepartements.Location = new Point(20, 140);
            btnDepartements.Name = "btnDepartements";
            btnDepartements.Size = new Size(180, 50);
            btnDepartements.TabIndex = 3;
            btnDepartements.Text = "🏛️ Départements";
            btnDepartements.UseVisualStyleBackColor = false;
            btnDepartements.Click += departementsToolStripMenuItem_Click;
            btnDepartements.MouseEnter += Button_MouseEnter;
            btnDepartements.MouseLeave += Button_MouseLeave;
            // 
            // btnSocietes
            // 
            btnSocietes.BackColor = Color.FromArgb(40, 167, 69);
            btnSocietes.FlatAppearance.BorderSize = 0;
            btnSocietes.FlatStyle = FlatStyle.Flat;
            btnSocietes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSocietes.ForeColor = Color.White;
            btnSocietes.Location = new Point(220, 70);
            btnSocietes.Name = "btnSocietes";
            btnSocietes.Size = new Size(180, 50);
            btnSocietes.TabIndex = 2;
            btnSocietes.Text = "🏢 Sociétés";
            btnSocietes.UseVisualStyleBackColor = false;
            btnSocietes.Click += societesToolStripMenuItem_Click;
            btnSocietes.MouseEnter += Button_MouseEnter;
            btnSocietes.MouseLeave += Button_MouseLeave;
            // 
            // btnEmployees
            // 
            btnEmployees.BackColor = Color.FromArgb(0, 123, 255);
            btnEmployees.FlatAppearance.BorderSize = 0;
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnEmployees.ForeColor = Color.White;
            btnEmployees.Location = new Point(20, 70);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(180, 50);
            btnEmployees.TabIndex = 1;
            btnEmployees.Text = "👥 Employés";
            btnEmployees.UseVisualStyleBackColor = false;
            btnEmployees.Click += btnEmployees_Click;
            btnEmployees.MouseEnter += Button_MouseEnter;
            btnEmployees.MouseLeave += Button_MouseLeave;
            // 
            // lblMasterDataTitle
            // 
            lblMasterDataTitle.AutoSize = true;
            lblMasterDataTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblMasterDataTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblMasterDataTitle.Location = new Point(20, 20);
            lblMasterDataTitle.Name = "lblMasterDataTitle";
            lblMasterDataTitle.Size = new Size(162, 25);
            lblMasterDataTitle.TabIndex = 0;
            lblMasterDataTitle.Text = "Données de Base";
            // 
            // panelScheduling
            // 
            panelScheduling.BackColor = Color.White;
            panelScheduling.Controls.Add(panel1);
            panelScheduling.Controls.Add(label1);
            panelScheduling.Controls.Add(btnAttendanceCollection);
            panelScheduling.Controls.Add(btnSchedules);
            panelScheduling.Controls.Add(btnAssignProgramme);
            panelScheduling.Controls.Add(btnProgrammes);
            panelScheduling.Controls.Add(lblSchedulingTitle);
            panelScheduling.Dock = DockStyle.Fill;
            panelScheduling.Location = new Point(459, 3);
            panelScheduling.Name = "panelScheduling";
            panelScheduling.Padding = new Padding(20);
            panelScheduling.Size = new Size(393, 498);
            panelScheduling.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(248, 249, 250);
            panel1.Location = new Point(0, 322);
            panel1.Name = "panel1";
            panel1.Size = new Size(395, 10);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(33, 37, 41);
            label1.Location = new Point(23, 351);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 5;
            label1.Text = "Présence";
            // 
            // btnAttendanceCollection
            // 
            btnAttendanceCollection.BackColor = Color.FromArgb(156, 39, 176);
            btnAttendanceCollection.FlatAppearance.BorderSize = 0;
            btnAttendanceCollection.FlatStyle = FlatStyle.Flat;
            btnAttendanceCollection.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAttendanceCollection.ForeColor = Color.White;
            btnAttendanceCollection.Location = new Point(20, 404);
            btnAttendanceCollection.Name = "btnAttendanceCollection";
            btnAttendanceCollection.Size = new Size(350, 60);
            btnAttendanceCollection.TabIndex = 4;
            btnAttendanceCollection.Text = "📊 Collecte de Présence";
            btnAttendanceCollection.UseVisualStyleBackColor = false;
            btnAttendanceCollection.Click += btnAttendanceCollection_Click;
            btnAttendanceCollection.MouseEnter += Button_MouseEnter;
            btnAttendanceCollection.MouseLeave += Button_MouseLeave;
            // 
            // btnSchedules
            // 
            btnSchedules.BackColor = Color.FromArgb(63, 81, 181);
            btnSchedules.FlatAppearance.BorderSize = 0;
            btnSchedules.FlatStyle = FlatStyle.Flat;
            btnSchedules.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSchedules.ForeColor = Color.White;
            btnSchedules.Location = new Point(20, 230);
            btnSchedules.Name = "btnSchedules";
            btnSchedules.Size = new Size(350, 60);
            btnSchedules.TabIndex = 3;
            btnSchedules.Text = "📊 Voir Plannings";
            btnSchedules.UseVisualStyleBackColor = false;
            btnSchedules.Click += btnSchedules_Click;
            btnSchedules.MouseEnter += Button_MouseEnter;
            btnSchedules.MouseLeave += Button_MouseLeave;
            // 
            // btnAssignProgramme
            // 
            btnAssignProgramme.BackColor = Color.FromArgb(76, 175, 80);
            btnAssignProgramme.FlatAppearance.BorderSize = 0;
            btnAssignProgramme.FlatStyle = FlatStyle.Flat;
            btnAssignProgramme.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAssignProgramme.ForeColor = Color.White;
            btnAssignProgramme.Location = new Point(20, 150);
            btnAssignProgramme.Name = "btnAssignProgramme";
            btnAssignProgramme.Size = new Size(350, 60);
            btnAssignProgramme.TabIndex = 2;
            btnAssignProgramme.Text = "👤 Assigner Programme";
            btnAssignProgramme.UseVisualStyleBackColor = false;
            btnAssignProgramme.Click += assignProgrammeToolStripMenuItem_Click;
            btnAssignProgramme.MouseEnter += Button_MouseEnter;
            btnAssignProgramme.MouseLeave += Button_MouseLeave;
            // 
            // btnProgrammes
            // 
            btnProgrammes.BackColor = Color.FromArgb(255, 87, 34);
            btnProgrammes.FlatAppearance.BorderSize = 0;
            btnProgrammes.FlatStyle = FlatStyle.Flat;
            btnProgrammes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnProgrammes.ForeColor = Color.White;
            btnProgrammes.Location = new Point(20, 70);
            btnProgrammes.Name = "btnProgrammes";
            btnProgrammes.Size = new Size(350, 60);
            btnProgrammes.TabIndex = 1;
            btnProgrammes.Text = "📋 Gérer Programmes";
            btnProgrammes.UseVisualStyleBackColor = false;
            btnProgrammes.Click += btnProgrammes_Click;
            btnProgrammes.MouseEnter += Button_MouseEnter;
            btnProgrammes.MouseLeave += Button_MouseLeave;
            // 
            // lblSchedulingTitle
            // 
            lblSchedulingTitle.AutoSize = true;
            lblSchedulingTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSchedulingTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblSchedulingTitle.Location = new Point(20, 20);
            lblSchedulingTitle.Name = "lblSchedulingTitle";
            lblSchedulingTitle.Size = new Size(123, 25);
            lblSchedulingTitle.TabIndex = 0;
            lblSchedulingTitle.Text = "Planification";
            // 
            // panelQuickStats
            // 
            panelQuickStats.BackColor = Color.White;
            panelQuickStats.Controls.Add(lblPendingAbsences);
            panelQuickStats.Controls.Add(lblActiveSchedules);
            panelQuickStats.Controls.Add(lblTotalEmployees);
            panelQuickStats.Controls.Add(lblQuickStatsTitle);
            panelQuickStats.Dock = DockStyle.Fill;
            panelQuickStats.Location = new Point(858, 3);
            panelQuickStats.Name = "panelQuickStats";
            panelQuickStats.Padding = new Padding(20);
            panelQuickStats.Size = new Size(279, 498);
            panelQuickStats.TabIndex = 2;
            // 
            // lblPendingAbsences
            // 
            lblPendingAbsences.BackColor = Color.FromArgb(255, 243, 224);
            lblPendingAbsences.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPendingAbsences.ForeColor = Color.FromArgb(230, 81, 0);
            lblPendingAbsences.Location = new Point(20, 270);
            lblPendingAbsences.Name = "lblPendingAbsences";
            lblPendingAbsences.Padding = new Padding(15, 20, 15, 20);
            lblPendingAbsences.Size = new Size(239, 80);
            lblPendingAbsences.TabIndex = 3;
            lblPendingAbsences.Text = "Absences en Attente\n0";
            lblPendingAbsences.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblActiveSchedules
            // 
            lblActiveSchedules.BackColor = Color.FromArgb(227, 242, 253);
            lblActiveSchedules.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblActiveSchedules.ForeColor = Color.FromArgb(1, 87, 155);
            lblActiveSchedules.Location = new Point(20, 170);
            lblActiveSchedules.Name = "lblActiveSchedules";
            lblActiveSchedules.Padding = new Padding(15, 20, 15, 20);
            lblActiveSchedules.Size = new Size(239, 80);
            lblActiveSchedules.TabIndex = 2;
            lblActiveSchedules.Text = "Plannings Actifs\n0";
            lblActiveSchedules.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalEmployees
            // 
            lblTotalEmployees.BackColor = Color.FromArgb(232, 245, 233);
            lblTotalEmployees.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalEmployees.ForeColor = Color.FromArgb(27, 94, 32);
            lblTotalEmployees.Location = new Point(20, 70);
            lblTotalEmployees.Name = "lblTotalEmployees";
            lblTotalEmployees.Padding = new Padding(15, 20, 15, 20);
            lblTotalEmployees.Size = new Size(239, 80);
            lblTotalEmployees.TabIndex = 1;
            lblTotalEmployees.Text = "Total Employés\n0";
            lblTotalEmployees.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblQuickStatsTitle
            // 
            lblQuickStatsTitle.AutoSize = true;
            lblQuickStatsTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblQuickStatsTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblQuickStatsTitle.Location = new Point(20, 20);
            lblQuickStatsTitle.Name = "lblQuickStatsTitle";
            lblQuickStatsTitle.Size = new Size(188, 25);
            lblQuickStatsTitle.TabIndex = 0;
            lblQuickStatsTitle.Text = "Statistiques Rapides";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblDateTime);
            panelHeader.Controls.Add(lblDescription);
            panelHeader.Controls.Add(lblWelcome);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(30, 20, 30, 20);
            panelHeader.Size = new Size(1200, 100);
            panelHeader.TabIndex = 0;
            // 
            // lblDateTime
            // 
            lblDateTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDateTime.Font = new Font("Segoe UI", 10F);
            lblDateTime.ForeColor = Color.FromArgb(108, 117, 125);
            lblDateTime.Location = new Point(900, 30);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(270, 40);
            lblDateTime.TabIndex = 2;
            lblDateTime.Text = "Loading...";
            lblDateTime.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.FromArgb(108, 117, 125);
            lblDescription.Location = new Point(30, 55);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(429, 19);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Gérer efficacement les employés, plannings et programmes de travail";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(33, 37, 41);
            lblWelcome.Location = new Point(30, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(334, 32);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Système de Planification RH";
            // 
            // timerDateTime
            // 
            timerDateTime.Enabled = true;
            timerDateTime.Interval = 1000;
            timerDateTime.Tick += TimerDateTime_Tick;
            // 
            // actualiserToolStripMenuItem
            // 
            actualiserToolStripMenuItem.Name = "actualiserToolStripMenuItem";
            actualiserToolStripMenuItem.Size = new Size(180, 22);
            actualiserToolStripMenuItem.Text = "Actualiser";
            actualiserToolStripMenuItem.Click += actualiserToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(panelMain);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(1000, 600);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Système de Planification RH";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            panelMain.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            tableLayoutMain.ResumeLayout(false);
            panelMasterData.ResumeLayout(false);
            panelMasterData.PerformLayout();
            panelScheduling.ResumeLayout(false);
            panelScheduling.PerformLayout();
            panelQuickStats.ResumeLayout(false);
            panelQuickStats.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem societesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shiftsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem absencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedulingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programmesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignProgrammeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Panel panelMasterData;
        private System.Windows.Forms.Label lblMasterDataTitle;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnSocietes;
        private System.Windows.Forms.Button btnDepartements;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Button btnShifts;
        private System.Windows.Forms.Button btnAbsences;
        private System.Windows.Forms.Panel panelScheduling;
        private System.Windows.Forms.Label lblSchedulingTitle;
        private System.Windows.Forms.Button btnProgrammes;
        private System.Windows.Forms.Button btnAssignProgramme;
        private System.Windows.Forms.Button btnSchedules;
        private System.Windows.Forms.Panel panelQuickStats;
        private System.Windows.Forms.Label lblQuickStatsTitle;
        private System.Windows.Forms.Label lblTotalEmployees;
        private System.Windows.Forms.Label lblActiveSchedules;
        private System.Windows.Forms.Label lblPendingAbsences;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer timerDateTime;
        private Button btnAttendanceCollection;
        private Label label1;
        private ToolStripMenuItem attendanceToolStripMenuItem;
        private ToolStripMenuItem pointageToolStripMenuItem;
        private Panel panel1;
        private ToolStripMenuItem poitageMaunelToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private ToolStripMenuItem settingsToolStripMenuItem1;
        private ToolStripMenuItem actualiserToolStripMenuItem;
    }
}
