using HRSchedulingSystem.Models;
using HRSchedulingSystem.Services;

namespace HRSchedulingSystem.Forms
{
    public partial class ServiceForm : Form
    {
        private readonly ServiceService _serviceService;
        private readonly DepartementService _departementService;
        private readonly SocieteService _societeService;
        private List<Service> _services = new();
        private List<Departement> _departements = new();
        private List<Societe> _societes = new();
        private Service? _selectedService;

        public ServiceForm()
        {
            InitializeComponent();
            _serviceService = new ServiceService();
            _departementService = new DepartementService();
            _societeService = new SocieteService();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                _societes = (await _societeService.GetAllAsync()).ToList();
                cmbSociete.DataSource = _societes;
                cmbSociete.DisplayMember = "Nom";
                cmbSociete.ValueMember = "Id";
                cmbSociete.SelectedIndex = -1;

                _departements = (await _departementService.GetAllAsync()).ToList();

                await LoadServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadServices()
        {
            try
            {
                _services = (await _serviceService.GetAllAsync()).ToList();
                dgvServices.DataSource = _services;

                if (dgvServices.Columns.Count > 0)
                {
                    dgvServices.Columns["Id"].Visible = false;
                    dgvServices.Columns["DepartementId"].Visible = false;
                    if (dgvServices.Columns["Departement"] != null)
                        dgvServices.Columns["Departement"].Visible = false;
                    dgvServices.Columns["Nom"].HeaderText = "Service Name";
                    dgvServices.Columns["Nom"].Width = 200;

                    // Add a computed column for Department Name if it doesn't exist
                    if (!dgvServices.Columns.Contains("DepartmentName"))
                    {
                        var deptColumn = new DataGridViewTextBoxColumn
                        {
                            Name = "DepartmentName",
                            HeaderText = "Department",
                            Width = 150,
                            ReadOnly = true
                        };
                        dgvServices.Columns.Add(deptColumn);
                    }
                }

                // Populate the department name column
                foreach (DataGridViewRow row in dgvServices.Rows)
                {
                    if (row.DataBoundItem is Service service)
                    {
                        var departement = _departements.FirstOrDefault(d => d.Id == service.DepartementId);
                        row.Cells["DepartmentName"].Value = departement?.Nom ?? "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading services: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbDepartement_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDepartement = cmbDepartement.SelectedItem as Departement;
            if (selectedDepartement == null)
            {
                // Show all services if no department selected
                await LoadServices();
                return;
            }

            try
            {
                var filteredServices = await _serviceService.GetServicesByDepartementAsync(selectedDepartement.Id);

                dgvServices.DataSource = filteredServices.ToList();

                // Reconfigure columns for filtered view
                if (dgvServices.Columns.Count > 0)
                {
                    dgvServices.Columns["Id"].Visible = false;
                    dgvServices.Columns["DepartementId"].Visible = false;
                    if (dgvServices.Columns["Departement"] != null)
                        dgvServices.Columns["Departement"].Visible = false;
                    dgvServices.Columns["Nom"].HeaderText = "Service Name";
                    dgvServices.Columns["Nom"].Width = 300;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering services: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count > 0)
            {
                var selectedRow = dgvServices.SelectedRows[0];
                _selectedService = selectedRow.DataBoundItem as Service;

                if (_selectedService != null)
                {
                    txtNom.Text = _selectedService.Nom;

                    // Find and select the corresponding societe and departement
                    var departement = _departements.FirstOrDefault(d => d.Id == _selectedService.DepartementId);
                    if (departement != null)
                    {
                        var societe = _societes.FirstOrDefault(s => s.Id == departement.SocieteId);
                        if (societe != null)
                        {
                            cmbSociete.SelectedItem = societe;
                            // This will trigger the cascade and load departments
                        }
                        cmbDepartement.SelectedValue = _selectedService.DepartementId;
                    }
                }
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
                var service = new Service
                {
                    Nom = txtNom.Text.Trim(),
                    DepartementId = (int)cmbDepartement.SelectedValue
                };

                if (_selectedService == null)
                {
                    await _serviceService.CreateAsync(service);
                    MessageBox.Show("Service created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    service.Id = _selectedService.Id;
                    await _serviceService.UpdateAsync(service);
                    MessageBox.Show("Service updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadServices();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedService == null)
            {
                MessageBox.Show("Please select a service to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete '{_selectedService.Nom}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _serviceService.DeleteAsync(_selectedService.Id);
                    MessageBox.Show("Service deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadServices();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Please enter service name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            if (cmbSociete.SelectedValue == null)
            {
                MessageBox.Show("Please select a company.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSociete.Focus();
                return false;
            }

            if (cmbDepartement.SelectedValue == null)
            {
                MessageBox.Show("Please select a department.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartement.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtNom.Clear();
            cmbSociete.SelectedIndex = -1;
            cmbDepartement.DataSource = null;
            _selectedService = null;
            dgvServices.ClearSelection();
        }
    }
}
