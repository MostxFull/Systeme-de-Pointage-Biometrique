using HRSchedulingSystem.Models;
using HRSchedulingSystem.Services;
using Timer = System.Windows.Forms.Timer;

namespace HRSchedulingSystem.Forms
{
    public partial class EmployeeForm : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly ServiceService _serviceService;
        private List<Employee> _employees = new();
        private List<Service> _services = new();
        private Employee? _selectedEmployee;
        private byte[]? _photoData;
        private List<Employee> _allEmployees = new();
        private Timer _searchTimer;

        public EmployeeForm()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _serviceService = new ServiceService();
            LoadData();
            _searchTimer = new Timer();
        }

        private async void LoadData()
        {
            try
            {
                _services = (await _serviceService.GetAllAsync()).ToList();
                cmbService.DataSource = _services;
                cmbService.DisplayMember = "Nom";
                cmbService.ValueMember = "Id";

                cmbGenre.Items.AddRange(new[] { "Homme", "Femme" });

                await LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadEmployees()
        {
            try
            {
                _allEmployees = (await _employeeService.GetAllAsync()).ToList();
                _employees = _allEmployees;
                dgvEmployees.DataSource = _employees;

                if (dgvEmployees.Columns.Count > 0)
                {
                    dgvEmployees.Columns["Id"].Visible = false;
                    dgvEmployees.Columns["ServiceId"].Visible = false;
                    dgvEmployees.Columns["Service"].Visible = false;
                    dgvEmployees.Columns["Photo"].Visible = false;
                    dgvEmployees.Columns["Nom"].HeaderText = "Last Name";
                    dgvEmployees.Columns["Prenom"].HeaderText = "First Name";
                    dgvEmployees.Columns["Matricule"].HeaderText = "Employee ID";
                    dgvEmployees.Columns["BiometricId"].HeaderText = "Biometric ID";
                    dgvEmployees.Columns["Email"].HeaderText = "Email";
                    dgvEmployees.Columns["CIN"].HeaderText = "National ID";
                    dgvEmployees.Columns["Genre"].HeaderText = "Gender";
                    dgvEmployees.Columns["DateNaissance"].HeaderText = "Birth Date";
                    dgvEmployees.Columns["DateEmbauche"].HeaderText = "Hire Date";
                    dgvEmployees.Columns["Telephone"].HeaderText = "Phone";
                    dgvEmployees.Columns["Statut"].HeaderText = "Active";
                    dgvEmployees.Columns["Salaire"].HeaderText = "Salary";
                    dgvEmployees.Columns["NbHeuretravail"].HeaderText = "Work Hours";
                    dgvEmployees.Columns["NbJourtravail"].HeaderText = "Work Days";
                    dgvEmployees.Columns["Poste"].HeaderText = "Position";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                var selectedRow = dgvEmployees.SelectedRows[0];
                _selectedEmployee = selectedRow.DataBoundItem as Employee;

                if (_selectedEmployee != null)
                {
                    txtNom.Text = _selectedEmployee.Nom;
                    txtPrenom.Text = _selectedEmployee.Prenom;
                    txtMatricule.Text = _selectedEmployee.Matricule;
                    txtBiometric.Text = _selectedEmployee.BiometricId ?? "";
                    txtEmail.Text = _selectedEmployee.Email ?? "";
                    txtCIN.Text = _selectedEmployee.CIN;
                    cmbGenre.SelectedItem = _selectedEmployee.Genre;
                    dtpDateNaissance.Value = _selectedEmployee.DateNaissance;
                    dtpDateEmbauche.Value = _selectedEmployee.DateEmbauche;
                    txtTelephone.Text = _selectedEmployee.Telephone?.ToString() ?? "";
                    chkStatut.Checked = _selectedEmployee.Statut;
                    txtSalaire.Text = _selectedEmployee.Salaire?.ToString() ?? "";
                    txtNbHeuretravail.Text = _selectedEmployee.NbHeuretravail?.ToString() ?? "";
                    txtNbJourtravail.Text = _selectedEmployee.NbJourtravail?.ToString() ?? "";
                    txtPoste.Text = _selectedEmployee.Poste ?? "";
                    cmbService.SelectedValue = _selectedEmployee.ServiceId;

                    _photoData = _selectedEmployee.Photo;
                    if (_photoData != null)
                    {
                        using var ms = new MemoryStream(_photoData);
                        picPhoto.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        picPhoto.Image = null;
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

                var employee = new Employee
                {
                    Nom = txtNom.Text.Trim(),
                    Prenom = txtPrenom.Text.Trim(),
                    Matricule = txtMatricule.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    CIN = txtCIN.Text.Trim(),
                    Genre = cmbGenre.SelectedItem.ToString()!,
                    DateNaissance = dtpDateNaissance.Value.Date,
                    DateEmbauche = dtpDateEmbauche.Value.Date,
                    Telephone = string.IsNullOrWhiteSpace(txtTelephone.Text) ? null : long.Parse(txtTelephone.Text),
                    BiometricId = string.IsNullOrWhiteSpace(txtBiometric.Text) ? null : txtBiometric.Text.Trim(),
                    Statut = chkStatut.Checked,
                    Salaire = string.IsNullOrWhiteSpace(txtSalaire.Text) ? null : double.Parse(txtSalaire.Text),
                    NbHeuretravail = string.IsNullOrWhiteSpace(txtNbHeuretravail.Text) ? null : int.Parse(txtNbHeuretravail.Text),
                    NbJourtravail = string.IsNullOrWhiteSpace(txtNbJourtravail.Text) ? null : int.Parse(txtNbJourtravail.Text),
                    Poste = string.IsNullOrWhiteSpace(txtPoste.Text) ? null : txtPoste.Text.Trim(),
                    ServiceId = (int)cmbService.SelectedValue,
                    Photo = _photoData
                };

                if (_selectedEmployee == null)
                {
                    await _employeeService.CreateAsync(employee);
                    MessageBox.Show("Employee created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    employee.Id = _selectedEmployee.Id;
                    await _employeeService.UpdateAsync(employee);
                    MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadEmployees();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete '{_selectedEmployee.Nom} {_selectedEmployee.Prenom}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _employeeService.DeleteAsync(_selectedEmployee.Id);
                    MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadEmployees();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Select Employee Photo";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _photoData = File.ReadAllBytes(openFileDialog.FileName);
                    picPhoto.Image = Image.FromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading photo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Please enter last name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Please enter first name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrenom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatricule.Text))
            {
                MessageBox.Show("Please enter employee ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatricule.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCIN.Text))
            {
                MessageBox.Show("Please enter national ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCIN.Focus();
                return false;
            }

            if (cmbGenre.SelectedItem == null)
            {
                MessageBox.Show("Please select gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGenre.Focus();
                return false;
            }

            if (cmbService.SelectedValue == null)
            {
                MessageBox.Show("Please select a service.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbService.Focus();
                return false;
            }


            return true;
        }

        private void ClearForm()
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtMatricule.Clear();
            txtEmail.Clear();
            txtCIN.Clear();
            cmbGenre.SelectedIndex = -1;
            dtpDateNaissance.Value = DateTime.Now.AddYears(-25);
            dtpDateEmbauche.Value = DateTime.Now;
            txtTelephone.Clear();
            chkStatut.Checked = true;
            txtSalaire.Clear();
            txtNbHeuretravail.Clear();
            txtNbJourtravail.Clear();
            txtPoste.Clear();
            txtBiometric.Clear();
            cmbService.SelectedIndex = -1;
            picPhoto.Image = null;
            _photoData = null;
            _selectedEmployee = null;
            dgvEmployees.ClearSelection();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _searchTimer?.Stop();
            _searchTimer = new Timer();
            _searchTimer.Interval = 300; // 300ms delay
            _searchTimer.Tick += (s, args) =>
            {
                _searchTimer.Stop();
                FilterEmployees();
            };
            _searchTimer.Start();
        }

        private void FilterEmployees()
        {
            var searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                _employees = _allEmployees;
            }
            else
            {
                _employees = _allEmployees.Where(emp =>
                    emp.Nom.ToLower().Contains(searchTerm) ||
                    emp.Prenom.ToLower().Contains(searchTerm) ||
                    $"{emp.Nom} {emp.Prenom}".ToLower().Contains(searchTerm) ||
                    $"{emp.Prenom} {emp.Nom}".ToLower().Contains(searchTerm) ||
                    (emp.Matricule?.ToLower().Contains(searchTerm) ?? false)
                ).ToList();
            }

            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = _employees;

            // Reapply column settings
            if (dgvEmployees.Columns.Count > 0)
            {
                dgvEmployees.Columns["Id"].Visible = false;
                dgvEmployees.Columns["ServiceId"].Visible = false;
                dgvEmployees.Columns["Service"].Visible = false;
                dgvEmployees.Columns["Photo"].Visible = false;
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            FilterEmployees();
        }

        private void picPhoto_Click(object sender, EventArgs e)
        {

        }
        private void lblPhoto_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
