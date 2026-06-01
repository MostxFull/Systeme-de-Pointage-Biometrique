using HRSchedulingSystem.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using HRSchedulingSystem.Services;
using System.Threading.Tasks;

namespace HRSchedulingSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            UpdateDateTime();
            timerDateTime.Start();
            await LoadQuickStatsAsync();
            statusLabel.Text = "Système de Planification RH Prêt";
        }

        private void TimerDateTime_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            lblDateTime.Text = $"{DateTime.Now:dddd dd MMMM yyyy}\n{DateTime.Now:HH:mm:ss}";
        }

        private async Task LoadQuickStatsAsync()
        {
            try
            {
                statusLabel.Text = "Chargement des statistiques...";

                // Initialize services
                var employeeService = new EmployeeService();
                var programmeService = new ProgrammeService();
                var absenceService = new AbsenceService();

                // Load data from database
                var employees = await employeeService.GetAllAsync();
                var employeeAssignments = await programmeService.GetEmployeeAssignmentsAsync();
                var todayAbsences = await absenceService.GetByDateRangeAsync(DateTime.Today, DateTime.Today);

                // Calculate statistics
                var totalEmployees = employees.Count();
                var activeEmployees = employees.Count(e => e.Statut);
                var inactiveEmployees = totalEmployees - activeEmployees;

                var totalSchedules = employeeAssignments.Count();
                var recentSchedules = employeeAssignments.Count(a => a.DateAffectation >= DateTime.Today.AddDays(-30));

                var todayAbsenceCount = todayAbsences.Count();
                var thisWeekAbsences = await absenceService.GetByDateRangeAsync(
                    DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek),
                    DateTime.Today.AddDays(6 - (int)DateTime.Today.DayOfWeek));
                var weeklyAbsenceCount = thisWeekAbsences.Count();

                // Update UI with real data
                lblTotalEmployees.Text = $"Total Employés\n{totalEmployees:N0}\n({activeEmployees} Actifs, {inactiveEmployees} Inactifs)";
                lblActiveSchedules.Text = $"Affectations Employés\n{totalSchedules:N0}\n({recentSchedules} Récentes)";
                lblPendingAbsences.Text = $"Absences Aujourd'hui\n{todayAbsenceCount:N0}\n({weeklyAbsenceCount} Cette Semaine)";

                statusLabel.Text = $"Statistiques chargées avec succès - {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                // Handle errors gracefully
                lblTotalEmployees.Text = "Total Employés\nErreur de chargement";
                lblActiveSchedules.Text = "Plannings Actifs\nErreur de chargement";
                lblPendingAbsences.Text = "Absences en Attente\nErreur de chargement";

                statusLabel.Text = $"Erreur lors du chargement des statistiques: {ex.Message}";

                // Log the error (you could implement proper logging here)
                System.Diagnostics.Debug.WriteLine($"LoadQuickStats Error: {ex}");
            }
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = LightenColor(btn.BackColor, 0.1f);
                btn.Cursor = Cursors.Hand;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = DarkenColor(btn.BackColor, 0.1f);
                btn.Cursor = Cursors.Default;
            }
        }

        private Color LightenColor(Color color, float factor)
        {
            return Color.FromArgb(
                color.A,
                Math.Min(255, (int)(color.R + (255 - color.R) * factor)),
                Math.Min(255, (int)(color.G + (255 - color.G) * factor)),
                Math.Min(255, (int)(color.B + (255 - color.B) * factor))
            );
        }

        private Color DarkenColor(Color color, float factor)
        {
            return Color.FromArgb(
                color.A,
                Math.Max(0, (int)(color.R * (1 - factor))),
                Math.Max(0, (int)(color.G * (1 - factor))),
                Math.Max(0, (int)(color.B * (1 - factor)))
            );
        }

        // Menu and Button Event Handlers
        private void societesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SocieteForm();
            form.ShowDialog();
        }

        private void departementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DepartementForm();
            form.ShowDialog();
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ServiceForm();
            form.ShowDialog();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new EmployeeForm();
            form.ShowDialog();
        }

        private void shiftsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ShiftForm();
            form.ShowDialog();
        }

        private void programmesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProgrammeForm();
            form.ShowDialog();
        }

        private void assignProgrammeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AssignProgrammeForm();
            form.ShowDialog();
        }

        private void viewScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ViewScheduleForm();
            form.ShowDialog();
        }

        private void absencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AbsenceForm();
            form.ShowDialog();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            employeesToolStripMenuItem_Click(sender, e);
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            viewScheduleToolStripMenuItem_Click(sender, e);
        }

        private void btnProgrammes_Click(object sender, EventArgs e)
        {
            programmesToolStripMenuItem_Click(sender, e);
        }

        private void btnShifts_Click(object sender, EventArgs e)
        {
            shiftsToolStripMenuItem_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir quitter l'application ?",
                "Confirmation de Sortie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aboutMessage = @"- SYSTÈME DE PLANIFICATION RH
Version 1.0.2 - Édition Professionnelle

- DESCRIPTION
Solution complète de gestion des ressources humaines incluant la planification des horaires, la gestion des employés et le suivi biométrique des présences.

- FONCTIONNALITÉS PRINCIPALES
• Gestion complète des employés et départements
• Création et assignation de programmes de travail
• Suivi biométrique des présences en temps réel
• Gestion des absences et congés
• Rapports et statistiques détaillés
• Interface multilingue (Français/Anglais)

- TECHNOLOGIES
• Framework: .NET 8.0 / C# WinForms
• Base de données: SQL Server
• Biométrie: ZKTeco SDK
• Rapports: ClosedXML

- DÉVELOPPEMENT
Développé avec les meilleures pratiques de développement logiciel et une architecture modulaire pour une maintenance optimale.

- SUPPORT TECHNIQUE
Pour toute assistance technique, contactez votre administrateur système.

© 2024 - Tous droits réservés";

            MessageBox.Show(aboutMessage, "À Propos du Système", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnRefreshStats_Click(object sender, EventArgs e)
        {
            await LoadQuickStatsAsync();
        }

        private void btnAttendanceCollection_Click(object sender, EventArgs e)
        {
            pointageToolStripMenuItem_Click(sender, e);
        }

        private async void actualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await LoadQuickStatsAsync();
            statusLabel.Text = "Données actualisées avec succès";
        }

        private void toolStripBtnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La fonctionnalité d'exportation sera bientôt disponible.", "Exportation de Données", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pointageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AttendanceCollectionForm();
            form.ShowDialog();
        }

        private void poitageMaunelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PointageManuelForm();
            form.ShowDialog();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string helpContent = @"- GUIDE D'UTILISATION - SYSTÈME DE PLANIFICATION RH

- ÉCRAN PRINCIPAL
L'écran principal affiche trois sections principales :
• Données de Base : Gestion des informations fondamentales
• Planification : Création et gestion des horaires
• Statistiques Rapides : Vue d'ensemble en temps réel

- DONNÉES DE BASE

- SOCIÉTÉS
• Créer et gérer les différentes sociétés
• Définir les informations légales et contacts

- DÉPARTEMENTS  
• Organiser la structure organisationnelle
• Associer les départements aux sociétés

- SERVICES
• Créer des services au sein des départements
• Définir les responsabilités et hiérarchies

- EMPLOYÉS
• Enregistrer les informations personnelles
• Assigner aux départements et services
• Gérer les statuts (actif/inactif)

- ÉQUIPES (SHIFTS)
• Définir les horaires de travail
• Créer des plages horaires flexibles
• Gérer les pauses et temps de travail

- ABSENCES
• Enregistrer les congés et absences
• Suivre les types d'absences
• Générer des rapports de présence

- PLANIFICATION

- PROGRAMMES
• Créer des programmes de travail hebdomadaires
• Assigner des équipes par jour
• Définir les périodes d'application

- ASSIGNATION
• Affecter les programmes aux employés
• Gérer les dates d'affectation
• Suivre l'historique des assignations

- VISUALISATION
• Consulter les plannings par employé
• Vue calendaire des horaires
• Exportation vers Excel

- PRÉSENCE

- COLLECTE BIOMÉTRIQUE
• Connexion aux appareils ZKTeco
• Collecte automatique des pointages
• Surveillance en temps réel

? POINTAGE MANUEL
• Saisie manuelle des présences
• Correction des pointages
• Gestion des cas exceptionnels

- CONSEILS D'UTILISATION

1- DÉMARRAGE
• Commencez par créer les sociétés et départements
• Ajoutez les services et employés
• Définissez les équipes de travail

2- PLANIFICATION
• Créez des programmes types
• Assignez-les aux employés
• Vérifiez les plannings générés

3- SUIVI
• Configurez les appareils biométriques
• Surveillez les collectes de présence
• Consultez régulièrement les statistiques

- RACCOURCIS CLAVIER
• Alt + F : Menu Fichier
• Alt + D : Données de Base
• Alt + P : Planification
• Alt + A : Aide
• F5 : Actualiser les données

- BESOIN D'AIDE ?
Pour une assistance personnalisée, contactez votre administrateur système ou consultez la documentation technique complète.";

            // Create a custom help form for better presentation
            Form helpForm = new Form()
            {
                Text = "Guide d'Utilisation - Système RH",
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = true,
                MinimizeBox = false,
                Icon = this.Icon
            };

            TextBox helpTextBox = new TextBox()
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F),
                Text = helpContent,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(33, 37, 41)
            };

            Panel buttonPanel = new Panel()
            {
                Height = 50,
                Dock = DockStyle.Bottom,
                BackColor = Color.FromArgb(248, 249, 250)
            };

            Button closeButton = new Button()
            {
                Text = "Fermer",
                Size = new Size(100, 30),
                Anchor = AnchorStyles.Right,
                Location = new Point(680, 10),
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (s, ev) => helpForm.Close();

            Button printButton = new Button()
            {
                Text = "Imprimer",
                Size = new Size(100, 30),
                Anchor = AnchorStyles.Right,
                Location = new Point(570, 10),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            printButton.FlatAppearance.BorderSize = 0;
            printButton.Click += (s, ev) => {
                MessageBox.Show("Fonctionnalité d'impression à venir.", "Impression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            buttonPanel.Controls.Add(closeButton);
            buttonPanel.Controls.Add(printButton);
            helpForm.Controls.Add(helpTextBox);
            helpForm.Controls.Add(buttonPanel);

            helpForm.ShowDialog(this);
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string settingsMessage = @"- PARAMÈTRES SYSTÈME

- CONFIGURATION DISPONIBLE
• Configuration de la base de données
• Paramètres de connexion biométrique
• Préférences d'interface utilisateur
• Gestion des sauvegardes

- FONCTIONNALITÉS À VENIR
• Personnalisation des thèmes
• Configuration des notifications
• Paramètres de sécurité avancés
• Gestion des utilisateurs et permissions

- ACCÈS ADMINISTRATEUR
Certains paramètres nécessitent des privilèges administrateur. Contactez votre administrateur système pour modifier la configuration avancée.

- PROCHAINE MISE À JOUR
La section paramètres complète sera disponible dans la version 1.1.0";

            MessageBox.Show(settingsMessage, "Paramètres Système", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
