using HRSchedulingSystem.Models;
using HRSchedulingSystem.Services;

namespace HRSchedulingSystem.Forms
{
    public partial class ShiftForm : Form
    {
        private readonly ShiftService _shiftService;
        private List<Shift> _shifts = new();
        private Shift? _selectedShift;

        public ShiftForm()
        {
            InitializeComponent();
            _shiftService = new ShiftService();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                await LoadShifts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadShifts()
        {
            try
            {
                _shifts = (await _shiftService.GetAllAsync()).ToList();
                dgvShifts.DataSource = _shifts;
                
                if (dgvShifts.Columns.Count > 0)
                {
                    dgvShifts.Columns["Id"].Visible = false;
                    dgvShifts.Columns["Nom"].HeaderText = "Shift Name";
                    dgvShifts.Columns["HeureDebut"].HeaderText = "Start Time";
                    dgvShifts.Columns["HeureFin"].HeaderText = "End Time";
                    dgvShifts.Columns["Retardautorise"].HeaderText = "Late Allowed (min)";
                    dgvShifts.Columns["Departautorise"].HeaderText = "Early Leave (min)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading shifts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvShifts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvShifts.SelectedRows.Count > 0)
            {
                var selectedRow = dgvShifts.SelectedRows[0];
                _selectedShift = selectedRow.DataBoundItem as Shift;
                
                if (_selectedShift != null)
                {
                    txtNom.Text = _selectedShift.Nom;
                    dtpHeureDebut.Value = DateTime.Today.Add(_selectedShift.HeureDebut);
                    dtpHeureFin.Value = DateTime.Today.Add(_selectedShift.HeureFin);
                    txtRetardautorise.Text = _selectedShift.Retardautorise.ToString();
                    txtDepartautorise.Text = _selectedShift.Departautorise.ToString();
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
                var shift = new Shift
                {
                    Nom = txtNom.Text.Trim(),
                    HeureDebut = dtpHeureDebut.Value.TimeOfDay,
                    HeureFin = dtpHeureFin.Value.TimeOfDay,
                    Retardautorise = double.Parse(txtRetardautorise.Text),
                    Departautorise = double.Parse(txtDepartautorise.Text)
                };

                if (_selectedShift == null)
                {
                    await _shiftService.CreateAsync(shift);
                    MessageBox.Show("Shift created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    shift.Id = _selectedShift.Id;
                    await _shiftService.UpdateAsync(shift);
                    MessageBox.Show("Shift updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadShifts();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving shift: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedShift == null)
            {
                MessageBox.Show("Please select a shift to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete '{_selectedShift.Nom}'?", 
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _shiftService.DeleteAsync(_selectedShift.Id);
                    MessageBox.Show("Shift deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadShifts();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting shift: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Please enter a shift name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            if (!double.TryParse(txtRetardautorise.Text, out _))
            {
                MessageBox.Show("Please enter a valid number for late allowed.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRetardautorise.Focus();
                return false;
            }

            if (!double.TryParse(txtDepartautorise.Text, out _))
            {
                MessageBox.Show("Please enter a valid number for early leave allowed.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDepartautorise.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtNom.Clear();
            dtpHeureDebut.Value = DateTime.Today.AddHours(8);
            dtpHeureFin.Value = DateTime.Today.AddHours(17);
            txtRetardautorise.Text = "0";
            txtDepartautorise.Text = "0";
            _selectedShift = null;
            dgvShifts.ClearSelection();
        }
    }
}
