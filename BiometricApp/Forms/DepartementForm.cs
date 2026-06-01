using HRSchedulingSystem.Models;
using HRSchedulingSystem.Services;

namespace HRSchedulingSystem.Forms
{
    public partial class DepartementForm : Form
    {
        private readonly DepartementService _departementService;
        private readonly SocieteService _societeService;
        private List<Departement> _departements = new();
        private List<Societe> _societes = new();
        private Departement? _selectedDepartement;

        public DepartementForm()
        {
            InitializeComponent();
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

                await LoadDepartements();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadDepartements()
        {
            try
            {
                _departements = (await _departementService.GetAllAsync()).ToList();
                dgvDepartements.DataSource = _departements;

                if (dgvDepartements.Columns.Count > 0)
                {
                    dgvDepartements.Columns["Id"].Visible = false;
                    dgvDepartements.Columns["SocieteId"].Visible = false;
                    if (dgvDepartements.Columns["Societe"] != null)
                        dgvDepartements.Columns["Societe"].Visible = false;
                    dgvDepartements.Columns["Nom"].HeaderText = "Department Name";
                    dgvDepartements.Columns["Nom"].Width = 200;

                    // Add a computed column for Company Name if it doesn't exist
                    if (!dgvDepartements.Columns.Contains("CompanyName"))
                    {
                        var companyColumn = new DataGridViewTextBoxColumn
                        {
                            Name = "CompanyName",
                            HeaderText = "Company",
                            Width = 150,
                            ReadOnly = true
                        };
                        dgvDepartements.Columns.Add(companyColumn);
                    }
                }

                // Populate the company name column
                foreach (DataGridViewRow row in dgvDepartements.Rows)
                {
                    if (row.DataBoundItem is Departement dept)
                    {
                        var societe = _societes.FirstOrDefault(s => s.Id == dept.SocieteId);
                        row.Cells["CompanyName"].Value = societe?.Nom ?? "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDepartements_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDepartements.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDepartements.SelectedRows[0];
                _selectedDepartement = selectedRow.DataBoundItem as Departement;

                if (_selectedDepartement != null)
                {
                    txtNom.Text = _selectedDepartement.Nom;
                    cmbSociete.SelectedValue = _selectedDepartement.SocieteId;
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
                var departement = new Departement
                {
                    Nom = txtNom.Text.Trim(),
                    SocieteId = (int)cmbSociete.SelectedValue
                };

                if (_selectedDepartement == null)
                {
                    await _departementService.CreateAsync(departement);
                    MessageBox.Show("Department created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    departement.Id = _selectedDepartement.Id;
                    await _departementService.UpdateAsync(departement);
                    MessageBox.Show("Department updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadDepartements();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedDepartement == null)
            {
                MessageBox.Show("Please select a department to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete '{_selectedDepartement.Nom}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _departementService.DeleteAsync(_selectedDepartement.Id);
                    MessageBox.Show("Department deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDepartements();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Please enter department name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            if (cmbSociete.SelectedValue == null)
            {
                MessageBox.Show("Please select a company.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSociete.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtNom.Clear();
            cmbSociete.SelectedIndex = -1;
            _selectedDepartement = null;
            dgvDepartements.ClearSelection();
        }
    }
}
