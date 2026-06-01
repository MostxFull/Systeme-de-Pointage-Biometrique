using HRSchedulingSystem.Models;
using HRSchedulingSystem.Services;

namespace HRSchedulingSystem.Forms
{
    public partial class AssignProgrammeForm : Form
    {
        private readonly ProgrammeService _programmeService;
        private readonly EmployeeService _employeeService;
        private List<Employee> _employees = new();
        private List<Programme> _programmes = new();
        private List<EmployeeAssignmentView> _assignments = new();

        public AssignProgrammeForm()
        {
            InitializeComponent();
            _programmeService = new ProgrammeService();
            _employeeService = new EmployeeService();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                _employees = (await _employeeService.GetAllAsync()).ToList();
                cmbEmployee.DataSource = _employees;
                cmbEmployee.DisplayMember = "Nom";
                cmbEmployee.ValueMember = "Id";

                _programmes = (await _programmeService.GetAllAsync()).ToList();
                cmbProgramme.DataSource = _programmes;
                cmbProgramme.DisplayMember = "Nom";
                cmbProgramme.ValueMember = "Id";

                await LoadAssignments();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadAssignments()
        {
            try
            {
                _assignments = (await _programmeService.GetEmployeeAssignmentsAsync()).ToList();
                dgvAssignments.DataSource = _assignments;
                
                if (dgvAssignments.Columns.Count > 0)
                {
                    dgvAssignments.Columns["EmployeeName"].HeaderText = "Employee";
                    dgvAssignments.Columns["ProgrammeName"].HeaderText = "Programme";
                    dgvAssignments.Columns["DateAffectation"].HeaderText = "Assignment Date";
                    dgvAssignments.Columns["ServiceName"].HeaderText = "Service";
                    dgvAssignments.Columns["DepartementName"].HeaderText = "Department";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading assignments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAssign_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                await _programmeService.AssignToEmployeeAsync(
                    (int)cmbEmployee.SelectedValue,
                    (int)cmbProgramme.SelectedValue,
                    dtpDateAffectation.Value.Date);

                MessageBox.Show("Programme assigned to employee successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadAssignments();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error assigning programme: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Please select an employee.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEmployee.Focus();
                return false;
            }

            if (cmbProgramme.SelectedValue == null)
            {
                MessageBox.Show("Please select a programme.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProgramme.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            cmbEmployee.SelectedIndex = -1;
            cmbProgramme.SelectedIndex = -1;
            dtpDateAffectation.Value = DateTime.Now;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
