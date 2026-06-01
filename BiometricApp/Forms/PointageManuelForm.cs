using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRSchedulingSystem.Models;
using HRSchedulingSystem.Services;
using Microsoft.Data.SqlClient;
using HRSchedulingSystem.Data;
using System.IO;
using System.Data;
using ClosedXML.Excel;

namespace HRSchedulingSystem.Forms
{
    public partial class PointageManuelForm : Form
    {
        private readonly SocieteService _societeService;
        private readonly DepartementService _departementService;
        private readonly ServiceService _serviceService;
        private readonly EmployeeService _employeeService;
        private readonly DatabaseHelper _databaseHelper;

        private List<PointageView> _pointages = new();
        private List<PointageView> _allPointages = new();
        private List<Societe> _societes = new();
        private List<Departement> _departements = new();
        private List<Service> _services = new();
        private List<Employee> _employees = new();
        private List<Pointeuse> _pointeuses = new();
        private Pointage? _selectedPointage;

        private readonly string[] _pointageTypes = { "IN", "OUT" };

        public PointageManuelForm()
        {
            InitializeComponent();
            _societeService = new SocieteService();
            _departementService = new DepartementService();
            _serviceService = new ServiceService();
            _employeeService = new EmployeeService();
            _databaseHelper = new DatabaseHelper();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                // Load pointage types
                cmbType.Items.AddRange(_pointageTypes);
                cmbFilterType.Items.Add("Tous les types");
                cmbFilterType.Items.AddRange(_pointageTypes);
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

                // Initialize employee filter as empty - will be populated when service is selected
                var employeesWithAll = new List<object> { new { Id = 0, Nom = "Tous les employés" } };
                cmbFilterEmployee.DataSource = employeesWithAll;
                cmbFilterEmployee.DisplayMember = "Nom";
                cmbFilterEmployee.ValueMember = "Id";
                cmbFilterEmployee.SelectedIndex = 0;

                // Load services for filter
                var servicesWithAll = new List<object> { new { Id = 0, Nom = "Tous les services" } };
                servicesWithAll.AddRange(_services.Select(s => new { Id = s.Id, Nom = s.Nom }));

                cmbFilterService.DataSource = servicesWithAll;
                cmbFilterService.DisplayMember = "Nom";
                cmbFilterService.ValueMember = "Id";
                cmbFilterService.SelectedIndex = 0;

                // Subscribe to service filter change event
                cmbFilterService.SelectedIndexChanged += cmbFilterService_SelectedIndexChanged;

                // Load pointeuses
                await LoadPointeuses();

                // Set default date filter to current month
                dtpFilterStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtpFilterEnd.Value = DateTime.Now.Date;

                // Set default values
                dtpDate.Value = DateTime.Today;
                dtpHeure.Value = DateTime.Now;

                await LoadPointages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadPointeuses()
        {
            try
            {
                _pointeuses = await GetPointeusesFromDatabase();

                cmbPointeuse.DataSource = new List<Pointeuse>(_pointeuses);
                cmbPointeuse.DisplayMember = "Nom";
                cmbPointeuse.ValueMember = "Id";
                cmbPointeuse.SelectedIndex = _pointeuses.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading devices: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<Pointeuse>> GetPointeusesFromDatabase()
        {
            var pointeuseList = new List<Pointeuse>();

            try
            {
                using var connection = new SqlConnection(_databaseHelper.GetConnectionString());
                await connection.OpenAsync();

                var query = "SELECT Id, Numero, Nom, IP, Port FROM Pointeuse ORDER BY Nom";
                using var command = new SqlCommand(query, connection);
                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    pointeuseList.Add(new Pointeuse
                    {
                        Id = reader.GetInt32("Id"),
                        Numero = reader.GetInt32("Numero"),
                        Nom = reader.GetString("Nom"),
                        IP = reader.GetString("IP"),
                        Port = reader.GetInt32("Port")
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading pointeuses: {ex.Message}");
            }

            return pointeuseList;
        }

        private async Task LoadPointages()
        {
            try
            {
                _allPointages = await GetPointagesFromDatabase();
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pointages: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<PointageView>> GetPointagesFromDatabase()
        {
            var pointageList = new List<PointageView>();

            try
            {
                using var connection = new SqlConnection(_databaseHelper.GetConnectionString());
                await connection.OpenAsync();

                var query = @"
                    SELECT p.Id, p.DateTime, p.Type, p.Flag, p.EmployeeId, p.PointeuseId,
                           e.Nom + ' ' + e.Prenom as EmployeeName, e.Matricule,
                           s.Nom as ServiceName,
                           d.Nom as DepartementName,
                           soc.Nom as SocieteName,
                           pt.Nom as PointeuseName
                    FROM Pointage p
                    INNER JOIN Employee e ON p.EmployeeId = e.Id
                    INNER JOIN Service s ON e.ServiceId = s.Id
                    INNER JOIN Departement d ON s.DepartementId = d.Id
                    INNER JOIN Societe soc ON d.SocieteId = soc.Id
                    INNER JOIN Pointeuse pt ON p.PointeuseId = pt.Id
                    ORDER BY p.DateTime DESC";

                using var command = new SqlCommand(query, connection);
                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    pointageList.Add(new PointageView
                    {
                        Id = reader.GetInt32("Id"),
                        DateTime = reader.GetDateTime("DateTime"),
                        Type = reader.GetString("Type"),
                        Flag = reader.GetString("Flag"),
                        EmployeeId = reader.GetInt32("EmployeeId"),
                        PointeuseId = reader.GetInt32("PointeuseId"),
                        EmployeeName = reader.GetString("EmployeeName"),
                        Matricule = reader.GetString("Matricule"),
                        ServiceName = reader.GetString("ServiceName"),
                        DepartementName = reader.GetString("DepartementName"),
                        SocieteName = reader.GetString("SocieteName"),
                        PointeuseName = reader.GetString("PointeuseName")
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading pointages: {ex.Message}");
            }

            return pointageList;
        }

        private void ApplyFilters()
        {
            var filteredPointages = _allPointages.AsEnumerable();

            // Filter by employee
            if (cmbFilterEmployee.SelectedValue != null && (int)cmbFilterEmployee.SelectedValue != 0)
            {
                var selectedEmployeeId = (int)cmbFilterEmployee.SelectedValue;
                filteredPointages = filteredPointages.Where(p => p.EmployeeId == selectedEmployeeId);
            }

            // Filter by service
            if (cmbFilterService.SelectedValue != null && (int)cmbFilterService.SelectedValue != 0)
            {
                var selectedServiceId = (int)cmbFilterService.SelectedValue;
                var serviceEmployeeIds = _employees.Where(e => e.ServiceId == selectedServiceId).Select(e => e.Id).ToList();
                filteredPointages = filteredPointages.Where(p => serviceEmployeeIds.Contains(p.EmployeeId));
            }

            var selectedFilterSociete = cmbFilterSociete.SelectedItem as Societe;
            if (selectedFilterSociete != null && selectedFilterSociete.Id != 0)
            {
                filteredPointages = filteredPointages.Where(p => p.SocieteName.Equals(selectedFilterSociete.Nom, StringComparison.OrdinalIgnoreCase));
            }

            // Filter by pointage type
            if (cmbFilterType.SelectedIndex > 0)
            {
                var selectedType = cmbFilterType.SelectedItem.ToString();
                filteredPointages = filteredPointages.Where(p => p.Type.Equals(selectedType, StringComparison.OrdinalIgnoreCase));
            }

            // Filter by date range
            if (chkFilterByDate.Checked)
            {
                var startDate = dtpFilterStart.Value.Date;
                var endDate = dtpFilterEnd.Value.Date.AddDays(1).AddTicks(-1);
                filteredPointages = filteredPointages.Where(p => p.DateTime >= startDate && p.DateTime <= endDate);
            }

            _pointages = filteredPointages.ToList();
            dgvPointages.DataSource = _pointages;
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            if (dgvPointages.Columns.Count > 0)
            {
                dgvPointages.Columns["Id"].Visible = false;
                dgvPointages.Columns["EmployeeId"].Visible = false;
                dgvPointages.Columns["PointeuseId"].Visible = false;
                dgvPointages.Columns["EmployeeName"].HeaderText = "Employé";
                dgvPointages.Columns["EmployeeName"].Width = 150;
                dgvPointages.Columns["Matricule"].HeaderText = "Matricule";
                dgvPointages.Columns["Matricule"].Width = 100;
                dgvPointages.Columns["ServiceName"].HeaderText = "Service";
                dgvPointages.Columns["ServiceName"].Width = 120;
                dgvPointages.Columns["DepartementName"].HeaderText = "Département";
                dgvPointages.Columns["DepartementName"].Width = 120;
                dgvPointages.Columns["SocieteName"].HeaderText = "Société";
                dgvPointages.Columns["SocieteName"].Width = 120;
                dgvPointages.Columns["DateTime"].HeaderText = "Date/Heure";
                dgvPointages.Columns["DateTime"].Width = 130;
                dgvPointages.Columns["Type"].HeaderText = "Type";
                dgvPointages.Columns["Type"].Width = 60;
                dgvPointages.Columns["Flag"].HeaderText = "Source";
                dgvPointages.Columns["Flag"].Width = 80;
                dgvPointages.Columns["PointeuseName"].HeaderText = "Pointeuse";
                dgvPointages.Columns["PointeuseName"].Width = 120;
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
                var employeeDisplayList = filteredEmployees.Select(e => new
                {
                    Id = e.Id,
                    Nom = e.Nom,
                    Employee = e
                }).ToList();

                cmbEmployee.DataSource = employeeDisplayList;
                cmbEmployee.DisplayMember = "Nom";
                cmbEmployee.ValueMember = "Id";
                cmbEmployee.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPointages_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPointages.SelectedRows.Count > 0)
            {
                var selectedRow = dgvPointages.SelectedRows[0];
                var selectedPointageView = selectedRow.DataBoundItem as PointageView;

                if (selectedPointageView != null)
                {
                    LoadPointageForEdit(selectedPointageView.Id);
                }
            }
        }

        private async void LoadPointageForEdit(int pointageId)
        {
            try
            {
                _selectedPointage = await GetPointageById(pointageId);
                if (_selectedPointage != null)
                {
                    var employee = _employees.FirstOrDefault(e => e.Id == _selectedPointage.EmployeeId);
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
                                    // Find the matching employee in the combo
                                    cmbEmployee.SelectedValue = employee.Id;
                                }
                            }
                        }
                    }

                    cmbType.SelectedItem = _selectedPointage.Type;
                    dtpDate.Value = _selectedPointage.DateTime.Date;
                    dtpHeure.Value = _selectedPointage.DateTime;

                    var pointeuse = _pointeuses.FirstOrDefault(p => p.Id == _selectedPointage.PointeuseId);
                    if (pointeuse != null)
                    {
                        cmbPointeuse.SelectedItem = pointeuse;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pointage details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<Pointage> GetPointageById(int id)
        {
            try
            {
                using var connection = new SqlConnection(_databaseHelper.GetConnectionString());
                await connection.OpenAsync();

                var query = "SELECT Id, DateTime, Type, Flag, EmployeeId, PointeuseId FROM Pointage WHERE Id = @Id";
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new Pointage
                    {
                        Id = reader.GetInt32("Id"),
                        DateTime = reader.GetDateTime("DateTime"),
                        Type = reader.GetString("Type"),
                        Flag = reader.GetString("Flag"),
                        EmployeeId = reader.GetInt32("EmployeeId"),
                        PointeuseId = reader.GetInt32("PointeuseId")
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading pointage: {ex.Message}");
            }

            return null;
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
                var selectedEmployeeItem = cmbEmployee.SelectedItem;
                var employeeId = (int)cmbEmployee.SelectedValue;

                var pointage = new Pointage
                {
                    EmployeeId = employeeId,
                    Type = cmbType.SelectedItem.ToString()!,
                    DateTime = dtpDate.Value.Date.Add(dtpHeure.Value.TimeOfDay),
                    Flag = "manuel",
                    PointeuseId = ((Pointeuse)cmbPointeuse.SelectedItem).Id
                };

                if (_selectedPointage == null)
                {
                    await CreatePointage(pointage);
                    MessageBox.Show("Pointage créé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    pointage.Id = _selectedPointage.Id;
                    await UpdatePointage(pointage);
                    MessageBox.Show("Pointage mis à jour avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadPointages();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedPointage == null)
            {
                MessageBox.Show("Veuillez sélectionner un pointage à supprimer.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce pointage?",
                "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await DeletePointage(_selectedPointage.Id);
                    MessageBox.Show("Pointage supprimé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadPointages();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task CreatePointage(Pointage pointage)
        {
            using var connection = new SqlConnection(_databaseHelper.GetConnectionString());
            await connection.OpenAsync();

            var query = @"INSERT INTO Pointage (DateTime, Type, Flag, EmployeeId, PointeuseId) 
                         VALUES (@DateTime, @Type, @Flag, @EmployeeId, @PointeuseId)";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DateTime", pointage.DateTime);
            command.Parameters.AddWithValue("@Type", pointage.Type);
            command.Parameters.AddWithValue("@Flag", pointage.Flag);
            command.Parameters.AddWithValue("@EmployeeId", pointage.EmployeeId);
            command.Parameters.AddWithValue("@PointeuseId", pointage.PointeuseId);

            await command.ExecuteNonQueryAsync();
        }

        private async Task UpdatePointage(Pointage pointage)
        {
            using var connection = new SqlConnection(_databaseHelper.GetConnectionString());
            await connection.OpenAsync();

            var query = @"UPDATE Pointage SET DateTime = @DateTime, Type = @Type, Flag = @Flag, 
                         EmployeeId = @EmployeeId, PointeuseId = @PointeuseId WHERE Id = @Id";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", pointage.Id);
            command.Parameters.AddWithValue("@DateTime", pointage.DateTime);
            command.Parameters.AddWithValue("@Type", pointage.Type);
            command.Parameters.AddWithValue("@Flag", pointage.Flag);
            command.Parameters.AddWithValue("@EmployeeId", pointage.EmployeeId);
            command.Parameters.AddWithValue("@PointeuseId", pointage.PointeuseId);

            await command.ExecuteNonQueryAsync();
        }

        private async Task DeletePointage(int id)
        {
            using var connection = new SqlConnection(_databaseHelper.GetConnectionString());
            await connection.OpenAsync();

            var query = "DELETE FROM Pointage WHERE Id = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            await command.ExecuteNonQueryAsync();
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

            if (cmbType.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un type de pointage.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbType.Focus();
                return false;
            }

            if (cmbPointeuse.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une pointeuse.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPointeuse.Focus();
                return false;
            }

            if (dtpDate.Value.Date > DateTime.Today)
            {
                MessageBox.Show("La date de pointage ne peut pas être dans le futur.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDate.Focus();
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
            cmbType.SelectedIndex = -1;
            dtpDate.Value = DateTime.Today;
            dtpHeure.Value = DateTime.Now;
            if (cmbPointeuse.Items.Count > 0)
                cmbPointeuse.SelectedIndex = 0;
            _selectedPointage = null;
            dgvPointages.ClearSelection();
        }

        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbFilterSociete.SelectedIndex = 0;
            cmbFilterService.SelectedIndex = 0; // This will trigger employee reload
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
            if (_pointages.Count == 0)
            {
                MessageBox.Show("Aucune donnée à exporter.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.Title = "Exporter les pointages";
                saveFileDialog.FileName = $"Pointages_{DateTime.Now:yyyyMMdd}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Pointages");

                    // Add headers
                    worksheet.Cell(1, 1).Value = "Employé";
                    worksheet.Cell(1, 2).Value = "Matricule";
                    worksheet.Cell(1, 3).Value = "Service";
                    worksheet.Cell(1, 4).Value = "Département";
                    worksheet.Cell(1, 5).Value = "Société";
                    worksheet.Cell(1, 6).Value = "Date/Heure";
                    worksheet.Cell(1, 7).Value = "Type";
                    worksheet.Cell(1, 8).Value = "Source";
                    worksheet.Cell(1, 9).Value = "Pointeuse";

                    // Style headers
                    var headerRange = worksheet.Range(1, 1, 1, 9);
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightGreen;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                    headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Add data
                    int row = 2;
                    foreach (var pointage in _pointages)
                    {
                        worksheet.Cell(row, 1).Value = pointage.EmployeeName;
                        worksheet.Cell(row, 2).Value = pointage.Matricule;
                        worksheet.Cell(row, 3).Value = pointage.ServiceName;
                        worksheet.Cell(row, 4).Value = pointage.DepartementName;
                        worksheet.Cell(row, 5).Value = pointage.SocieteName;
                        worksheet.Cell(row, 6).Value = pointage.DateTime;
                        worksheet.Cell(row, 7).Value = pointage.Type;
                        worksheet.Cell(row, 8).Value = pointage.Flag;
                        worksheet.Cell(row, 9).Value = pointage.PointeuseName;

                        // Format date column
                        worksheet.Cell(row, 6).Style.DateFormat.Format = "dd/mm/yyyy hh:mm:ss";

                        // Color code by type
                        if (pointage.Type == "IN")
                        {
                            worksheet.Cell(row, 7).Style.Fill.BackgroundColor = XLColor.LightGreen;
                        }
                        else if (pointage.Type == "OUT")
                        {
                            worksheet.Cell(row, 7).Style.Fill.BackgroundColor = XLColor.LightCoral;
                        }

                        // Color code by source
                        if (pointage.Flag == "manuel")
                        {
                            worksheet.Cell(row, 8).Style.Fill.BackgroundColor = XLColor.LightYellow;
                        }

                        row++;
                    }

                    // Auto-fit columns
                    worksheet.Columns().AdjustToContents();

                    // Add borders to data
                    var dataRange = worksheet.Range(1, 1, row - 1, 9);
                    dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                    dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Add summary
                    worksheet.Cell(row + 1, 1).Value = "Total des pointages:";
                    worksheet.Cell(row + 1, 2).Value = _pointages.Count;
                    worksheet.Cell(row + 2, 1).Value = "Pointages manuels:";
                    worksheet.Cell(row + 2, 2).Value = _pointages.Count(p => p.Flag == "manuel");
                    worksheet.Cell(row + 3, 1).Value = "Pointages automatiques:";
                    worksheet.Cell(row + 3, 2).Value = _pointages.Count(p => p.Flag != "manuel");

                    // Style summary
                    var summaryRange = worksheet.Range(row + 1, 1, row + 3, 2);
                    summaryRange.Style.Font.Bold = true;

                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Données exportées avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'exportation: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void cmbFilterService_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmployeesForServiceFilter();
        }

        private void LoadEmployeesForServiceFilter()
        {
            try
            {
                var employeesWithAll = new List<object> { new { Id = 0, Nom = "Tous les employés" } };

                if (cmbFilterService.SelectedValue != null && (int)cmbFilterService.SelectedValue != 0)
                {
                    var selectedServiceId = (int)cmbFilterService.SelectedValue;
                    var filteredEmployees = _employees.Where(e => e.ServiceId == selectedServiceId).ToList();
                    employeesWithAll.AddRange(filteredEmployees.Select(e => new { Id = e.Id, Nom = e.Nom }));
                }
                else
                {
                    // If "Tous les services" is selected, show all employees
                    employeesWithAll.AddRange(_employees.Select(e => new { Id = e.Id, Nom = e.Nom }));
                }

                cmbFilterEmployee.DataSource = employeesWithAll;
                cmbFilterEmployee.DisplayMember = "Nom";
                cmbFilterEmployee.ValueMember = "Id";
                cmbFilterEmployee.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees for service filter: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBoxFilters_Enter(object sender, EventArgs e)
        {

        }
    }

    

    
}
