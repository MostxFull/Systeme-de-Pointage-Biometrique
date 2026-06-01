using ClosedXML.Excel;
using HRSchedulingSystem.Models;
using HRSchedulingSystem.Services;

namespace HRSchedulingSystem.Forms
{
    public partial class AbsenceForm : Form
    {
        private readonly AbsenceService _absenceService;
        private readonly SocieteService _societeService;
        private readonly DepartementService _departementService;
        private readonly ServiceService _serviceService;
        private readonly EmployeeService _employeeService;

        private List<AbsenceView> _absences = new();
        private List<AbsenceView> _allAbsences = new();
        private List<Societe> _societes = new();
        private List<Departement> _departements = new();
        private List<Service> _services = new();
        private List<Employee> _employees = new();
        private Absence? _selectedAbsence;

        private readonly string[] _absenceTypes = {
            "Congé Payé",
            "Congé Maladie",
            "Congé de Maternité",
            "Congé de Paternité",
            "Absence Injustifiée",
            "Formation",
            "Mission",
            "Autre"
        };

        public AbsenceForm()
        {
            InitializeComponent();
            _absenceService = new AbsenceService();
            _societeService = new SocieteService();
            _departementService = new DepartementService();
            _serviceService = new ServiceService();
            _employeeService = new EmployeeService();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                // Load absence types
                cmbTypeAbsence.Items.AddRange(_absenceTypes);
                cmbFilterType.Items.Add("Tous les types");
                cmbFilterType.Items.AddRange(_absenceTypes);
                cmbFilterType.SelectedIndex = 0;

                // Load societes
                _societes = (await _societeService.GetAllAsync()).ToList();
                var societesWithAll = new List<Societe> { new() { Id = 0, Nom = "Toutes les sociétés" } };
                societesWithAll.AddRange(_societes);

                cmbSociete.DataSource = new List<Societe>(_societes);
                cmbSociete.DisplayMember = "Nom";
                cmbSociete.ValueMember = "Id";
                cmbSociete.SelectedIndex = -1;

                cmbFilterSociete.DataSource = societesWithAll;
                cmbFilterSociete.DisplayMember = "Nom";
                cmbFilterSociete.ValueMember = "Id";
                cmbFilterSociete.SelectedIndex = 0;

                // Load departements
                _departements = (await _departementService.GetAllAsync()).ToList();

                // Load services
                _services = (await _serviceService.GetAllAsync()).ToList();

                // Load employees
                _employees = (await _employeeService.GetAllAsync()).ToList();
                var employeesWithAll = new List<Employee> { new() { Id = 0, Nom = "Tous les employés", Prenom = "" } };
                employeesWithAll.AddRange(_employees);

                cmbFilterEmployee.DataSource = employeesWithAll;
                cmbFilterEmployee.DisplayMember = "Nom";
                cmbFilterEmployee.ValueMember = "Id";
                cmbFilterEmployee.SelectedIndex = 0;

                // Set default date filter to current month
                dtpFilterStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtpFilterEnd.Value = DateTime.Now.Date;

                await LoadAbsences();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadAbsences()
        {
            try
            {
                _allAbsences = (await _absenceService.GetAllAsync()).ToList();
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading absences: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            var filteredAbsences = _allAbsences.AsEnumerable();

            var selectedFilterEmployee = cmbFilterEmployee.SelectedItem as Employee;
            if (selectedFilterEmployee != null && selectedFilterEmployee.Id != 0)
            {
                var selectedEmployeeId = selectedFilterEmployee.Id;
                filteredAbsences = filteredAbsences.Where(a =>
                    _employees.Any(e => e.Id == selectedEmployeeId &&
                        $"{e.Nom} {e.Prenom}".Equals(a.EmployeeName, StringComparison.OrdinalIgnoreCase)));
            }

            var selectedFilterSociete = cmbFilterSociete.SelectedItem as Societe;
            if (selectedFilterSociete != null && selectedFilterSociete.Id != 0)
            {
                filteredAbsences = filteredAbsences.Where(a => a.SocieteName.Equals(selectedFilterSociete.Nom, StringComparison.OrdinalIgnoreCase));
            }

            // Filter by absence type
            if (cmbFilterType.SelectedIndex > 0)
            {
                var selectedType = cmbFilterType.SelectedItem.ToString();
                filteredAbsences = filteredAbsences.Where(a => a.TypeAbsence.Equals(selectedType, StringComparison.OrdinalIgnoreCase));
            }

            // Filter by date range
            if (chkFilterByDate.Checked)
            {
                var startDate = dtpFilterStart.Value.Date;
                var endDate = dtpFilterEnd.Value.Date;
                filteredAbsences = filteredAbsences.Where(a => a.DateDebut <= endDate && a.DateFin >= startDate);
            }

            // Convert to List before assigning
            _absences = filteredAbsences.ToList();
            dgvAbsences.DataSource = _absences;
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            if (dgvAbsences.Columns.Count > 0)
            {
                dgvAbsences.Columns["Id"].Visible = false;
                dgvAbsences.Columns["EmployeeName"].HeaderText = "Employé";
                dgvAbsences.Columns["EmployeeName"].Width = 150;
                dgvAbsences.Columns["ServiceName"].HeaderText = "Service";
                dgvAbsences.Columns["ServiceName"].Width = 120;
                dgvAbsences.Columns["DepartementName"].HeaderText = "Département";
                dgvAbsences.Columns["DepartementName"].Width = 120;
                dgvAbsences.Columns["SocieteName"].HeaderText = "Société";
                dgvAbsences.Columns["SocieteName"].Width = 120;
                dgvAbsences.Columns["TypeAbsence"].HeaderText = "Type";
                dgvAbsences.Columns["TypeAbsence"].Width = 120;
                dgvAbsences.Columns["DateDebut"].HeaderText = "Date Début";
                dgvAbsences.Columns["DateDebut"].Width = 100;
                dgvAbsences.Columns["DateFin"].HeaderText = "Date Fin";
                dgvAbsences.Columns["DateFin"].Width = 100;
                dgvAbsences.Columns["NbJours"].HeaderText = "Nb Jours";
                dgvAbsences.Columns["NbJours"].Width = 80;
                dgvAbsences.Columns["Description"].HeaderText = "Description";
                dgvAbsences.Columns["Description"].Width = 200;
                dgvAbsences.Columns["DateCreation"].HeaderText = "Créé le";
                dgvAbsences.Columns["DateCreation"].Width = 100;
            }
        }

        private async void cmbSociete_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSociete = cmbSociete.SelectedItem as Societe;
            if (selectedSociete == null) return;

            try
            {
                var filteredDepartements = await _departementService.GetDepartementsBySocieteAsync(selectedSociete.Id);

                cmbDepartement.DataSource = filteredDepartements.ToList();
                cmbDepartement.DisplayMember = "Nom";
                cmbDepartement.ValueMember = "Id";
                cmbDepartement.SelectedIndex = -1;

                cmbService.DataSource = null;
                cmbEmployee.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbDepartement_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDepartement = cmbDepartement.SelectedItem as Departement;
            if (selectedDepartement == null) return;

            try
            {
                var filteredServices = await _serviceService.GetServicesByDepartementAsync(selectedDepartement.Id);

                cmbService.DataSource = filteredServices.ToList();
                cmbService.DisplayMember = "Nom";
                cmbService.ValueMember = "Id";
                cmbService.SelectedIndex = -1;

                cmbEmployee.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading services: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedService = cmbService.SelectedItem as Service;
            if (selectedService == null) return;

            try
            {
                var filteredEmployees = await _employeeService.GetEmployeesByServiceAsync(selectedService.Id);

                cmbEmployee.DataSource = filteredEmployees.ToList();
                cmbEmployee.DisplayMember = "Nom";
                cmbEmployee.ValueMember = "Id";
                cmbEmployee.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAbsences_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAbsences.SelectedRows.Count > 0)
            {
                var selectedRow = dgvAbsences.SelectedRows[0];
                var selectedAbsenceView = selectedRow.DataBoundItem as AbsenceView;

                if (selectedAbsenceView != null)
                {
                    LoadAbsenceForEdit(selectedAbsenceView.Id);
                }
            }
        }

        private async void LoadAbsenceForEdit(int absenceId)
        {
            try
            {
                _selectedAbsence = await _absenceService.GetByIdAsync(absenceId);
                if (_selectedAbsence != null)
                {
                    var employee = _employees.FirstOrDefault(e => e.Id == _selectedAbsence.EmployeeId);
                    if (employee != null)
                    {
                        var service = _services.FirstOrDefault(s => s.Id == employee.ServiceId);
                        var departement = _departements.FirstOrDefault(d => d.Id == service?.DepartementId);
                        var societe = _societes.FirstOrDefault(s => s.Id == departement?.SocieteId);

                        if (societe != null)
                        {
                            cmbSociete.SelectedItem = societe;
                            if (departement != null)
                            {
                                cmbDepartement.SelectedItem = departement;
                                if (service != null)
                                {
                                    cmbService.SelectedItem = service;
                                    cmbEmployee.SelectedItem = employee;
                                }
                            }
                        }
                    }

                    cmbTypeAbsence.SelectedItem = _selectedAbsence.TypeAbsence;
                    dtpDateDebut.Value = _selectedAbsence.DateDebut;
                    dtpDateFin.Value = _selectedAbsence.DateFin;
                    txtDescription.Text = _selectedAbsence.Description ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading absence details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                var absence = new Absence
                {
                    EmployeeId = ((Employee)cmbEmployee.SelectedItem).Id,
                    TypeAbsence = cmbTypeAbsence.SelectedItem.ToString()!,
                    DateDebut = dtpDateDebut.Value.Date,
                    DateFin = dtpDateFin.Value.Date,
                    Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim(),
                    DateCreation = DateTime.Now
                };

                if (_selectedAbsence == null)
                {
                    await _absenceService.CreateAsync(absence);
                    MessageBox.Show("Absence créée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    absence.Id = _selectedAbsence.Id;
                    absence.DateCreation = _selectedAbsence.DateCreation;
                    await _absenceService.UpdateAsync(absence);
                    MessageBox.Show("Absence mise à jour avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadAbsences();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedAbsence == null)
            {
                MessageBox.Show("Veuillez sélectionner une absence à supprimer.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette absence?",
                "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _absenceService.DeleteAsync(_selectedAbsence.Id);
                    MessageBox.Show("Absence supprimée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadAbsences();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateForm()
        {
            if (cmbSociete.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une société.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSociete.Focus();
                return false;
            }

            if (cmbDepartement.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un département.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartement.Focus();
                return false;
            }

            if (cmbService.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un service.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbService.Focus();
                return false;
            }

            if (cmbEmployee.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un employé.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEmployee.Focus();
                return false;
            }

            if (cmbTypeAbsence.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un type d'absence.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTypeAbsence.Focus();
                return false;
            }

            if (dtpDateFin.Value < dtpDateDebut.Value)
            {
                MessageBox.Show("La date de fin ne peut pas être antérieure à la date de début.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDateFin.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            cmbSociete.SelectedIndex = -1;
            cmbDepartement.DataSource = null;
            cmbService.DataSource = null;
            cmbEmployee.DataSource = null;
            cmbTypeAbsence.SelectedIndex = -1;
            dtpDateDebut.Value = DateTime.Now;
            dtpDateFin.Value = DateTime.Now;
            txtDescription.Clear();
            _selectedAbsence = null;
            dgvAbsences.ClearSelection();
        }

        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbFilterSociete.SelectedIndex = 0;
            cmbFilterEmployee.SelectedIndex = 0;
            cmbFilterType.SelectedIndex = 0;
            chkFilterByDate.Checked = false;
            dtpFilterStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFilterEnd.Value = DateTime.Now.Date;
            ApplyFilters();
        }

        private void chkFilterByDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFilterStart.Enabled = chkFilterByDate.Checked;
            dtpFilterEnd.Enabled = chkFilterByDate.Checked;
            if (chkFilterByDate.Checked)
            {
                ApplyFilters();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_absences.Count == 0)
            {
                MessageBox.Show("Aucune donnée à exporter.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.Title = "Exporter les absences";
                saveFileDialog.FileName = $"Absences_{DateTime.Now:yyyyMMdd}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Absences");

                    // Add headers
                    worksheet.Cell(1, 1).Value = "Employé";
                    worksheet.Cell(1, 2).Value = "Service";
                    worksheet.Cell(1, 3).Value = "Département";
                    worksheet.Cell(1, 4).Value = "Société";
                    worksheet.Cell(1, 5).Value = "Type";
                    worksheet.Cell(1, 6).Value = "Date Début";
                    worksheet.Cell(1, 7).Value = "Date Fin";
                    worksheet.Cell(1, 8).Value = "Nb Jours";
                    worksheet.Cell(1, 9).Value = "Description";
                    worksheet.Cell(1, 10).Value = "Créé le";

                    // Style headers
                    var headerRange = worksheet.Range(1, 1, 1, 10);
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                    headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Add data
                    int row = 2;
                    foreach (var absence in _absences)
                    {
                        worksheet.Cell(row, 1).Value = absence.EmployeeName;
                        worksheet.Cell(row, 2).Value = absence.ServiceName;
                        worksheet.Cell(row, 3).Value = absence.DepartementName;
                        worksheet.Cell(row, 4).Value = absence.SocieteName;
                        worksheet.Cell(row, 5).Value = absence.TypeAbsence;
                        worksheet.Cell(row, 6).Value = absence.DateDebut;
                        worksheet.Cell(row, 7).Value = absence.DateFin;
                        worksheet.Cell(row, 8).Value = absence.NbJours;
                        worksheet.Cell(row, 9).Value = absence.Description ?? "";
                        worksheet.Cell(row, 10).Value = absence.DateCreation;

                        // Format date columns
                        worksheet.Cell(row, 6).Style.DateFormat.Format = "dd/MM/yyyy";
                        worksheet.Cell(row, 7).Style.DateFormat.Format = "dd/MM/yyyy";
                        worksheet.Cell(row, 10).Style.DateFormat.Format = "dd/MM/yyyy HH:mm";

                        row++;
                    }

                    // Auto-fit columns
                    worksheet.Columns().AdjustToContents();

                    // Add borders to data
                    var dataRange = worksheet.Range(1, 1, row - 1, 10);
                    dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                    dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Add summary
                    worksheet.Cell(row + 1, 1).Value = "Total des absences:";
                    worksheet.Cell(row + 1, 2).Value = _absences.Count;
                    worksheet.Cell(row + 1, 1).Style.Font.Bold = true;
                    worksheet.Cell(row + 1, 2).Style.Font.Bold = true;

                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Données exportées avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'exportation: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
