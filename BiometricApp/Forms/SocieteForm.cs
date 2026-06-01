using HRSchedulingSystem.Models;
using HRSchedulingSystem.Services;
using System.Text.RegularExpressions;

namespace HRSchedulingSystem.Forms
{
    public partial class SocieteForm : Form
    {
        private readonly SocieteService _societeService;
        private List<Societe> _societes = new();
        private Societe? _selectedSociete;
        private byte[]? _logoData;

        public SocieteForm()
        {
            InitializeComponent();
            _societeService = new SocieteService();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                await LoadSocietes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadSocietes()
        {
            try
            {
                _societes = (await _societeService.GetAllAsync()).ToList();
                dgvSocietes.DataSource = _societes;

                if (dgvSocietes.Columns.Count > 0)
                {
                    dgvSocietes.Columns["Id"].Visible = false;
                    dgvSocietes.Columns["Logo"].Visible = false;
                    dgvSocietes.Columns["Nom"].HeaderText = "Company Name";
                    dgvSocietes.Columns["Nom"].Width = 150;
                    dgvSocietes.Columns["RaisonSociale"].HeaderText = "Legal Name";
                    dgvSocietes.Columns["RaisonSociale"].Width = 180;
                    dgvSocietes.Columns["Adresse"].HeaderText = "Address";
                    dgvSocietes.Columns["Adresse"].Width = 200;
                    dgvSocietes.Columns["Telephone"].HeaderText = "Phone";
                    dgvSocietes.Columns["Telephone"].Width = 120;
                    dgvSocietes.Columns["Email"].HeaderText = "Email";
                    dgvSocietes.Columns["Email"].Width = 150;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading companies: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSocietes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSocietes.SelectedRows.Count > 0)
            {
                var selectedRow = dgvSocietes.SelectedRows[0];
                _selectedSociete = selectedRow.DataBoundItem as Societe;

                if (_selectedSociete != null)
                {
                    txtNom.Text = _selectedSociete.Nom;
                    txtRaisonSociale.Text = _selectedSociete.RaisonSociale ?? "";
                    txtAdresse.Text = _selectedSociete.Adresse ?? "";
                    txtTelephone.Text = _selectedSociete.Telephone ?? "";
                    txtEmail.Text = _selectedSociete.Email ?? "";

                    _logoData = _selectedSociete.Logo;
                    if (_logoData != null)
                    {
                        using var ms = new MemoryStream(_logoData);
                        picLogo.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        picLogo.Image = null;
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
            if (!await ValidateForm()) return;

            try
            { 
                var societe = new Societe
                {
                    Nom = txtNom.Text.Trim(),
                    RaisonSociale = string.IsNullOrWhiteSpace(txtRaisonSociale.Text) ? null : txtRaisonSociale.Text.Trim(),
                    Adresse = string.IsNullOrWhiteSpace(txtAdresse.Text) ? null : txtAdresse.Text.Trim(),
                    Telephone = string.IsNullOrWhiteSpace(txtTelephone.Text) ? null : txtTelephone.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Logo = _logoData
                };

                if (_selectedSociete == null)
                {
                    await _societeService.CreateAsync(societe);
                    MessageBox.Show("Company created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    societe.Id = _selectedSociete.Id;
                    await _societeService.UpdateAsync(societe);
                    MessageBox.Show("Company updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadSocietes();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving company: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedSociete == null)
            {
                MessageBox.Show("Please select a company to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete '{_selectedSociete.Nom}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _societeService.DeleteAsync(_selectedSociete.Id);
                    MessageBox.Show("Company deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadSocietes();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting company: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUploadLogo_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Select Company Logo";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Check file size (limit to 5MB)
                    var fileInfo = new FileInfo(openFileDialog.FileName);
                    if (fileInfo.Length > 5 * 1024 * 1024)
                    {
                        MessageBox.Show("Logo file size must be less than 5MB.", "File Size Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _logoData = File.ReadAllBytes(openFileDialog.FileName);
                    picLogo.Image = Image.FromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading logo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRemoveLogo_Click(object sender, EventArgs e)
        {
            _logoData = null;
            picLogo.Image = null;
        }

        private async Task<bool> ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Please enter a company name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            // Validate email format if provided
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!IsValidEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }

                // Check email uniqueness
                var isEmailUnique = await _societeService.IsEmailUniqueAsync(txtEmail.Text.Trim(), _selectedSociete?.Id);
                if (!isEmailUnique)
                {
                    MessageBox.Show("This email address is already in use by another company.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            // Validate phone format if provided
            if (!string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                if (!IsValidPhoneNumber(txtTelephone.Text.Trim()))
                {
                    MessageBox.Show("Please enter a valid phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelephone.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return emailRegex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Allow various phone number formats
            var phoneRegex = new Regex(@"^[\+]?[0-9\s\-$$$$]{7,20}$");
            return phoneRegex.IsMatch(phoneNumber);
        }

        private void ClearForm()
        {
            txtNom.Clear();
            txtRaisonSociale.Clear();
            txtAdresse.Clear();
            txtTelephone.Clear();
            txtEmail.Clear();
            picLogo.Image = null;
            _logoData = null;
            _selectedSociete = null;
            dgvSocietes.ClearSelection();
        }
    }
}
