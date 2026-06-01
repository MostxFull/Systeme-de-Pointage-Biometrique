using System.Drawing;
using ClosedXML.Excel;
using HRSchedulingSystem.Models;
using HRSchedulingSystem.Services;

namespace HRSchedulingSystem.Forms
{
    public partial class ViewScheduleForm : Form
    {
        private readonly ProgrammeService _programmeService;
        private readonly EmployeeService _employeeService;
        private List<Employee> _employees = new();
        private List<EmployeeScheduleView> _schedules = new();

        public ViewScheduleForm()
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

                dtpWeekStart.Value = GetStartOfWeek(DateTime.Now);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DateTime GetStartOfWeek(DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private async void btnViewSchedule_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Please select an employee.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var employeeId = (int)cmbEmployee.SelectedValue;
                var weekStart = dtpWeekStart.Value.Date;

                _schedules = (await _programmeService.GetEmployeeWeeklyScheduleAsync(employeeId, weekStart)).ToList();

                // Create a more readable schedule view
                var scheduleDisplay = _schedules.Select(s => new
                {
                    Day = GetDayName(s.JourDeSemaine),
                    DayNumber = s.JourDeSemaine,
                    Date = weekStart.AddDays(s.JourDeSemaine),
                    Shift = s.ShiftNom,
                    StartTime = s.HeureDebut.ToString(@"hh\:mm"),
                    EndTime = s.HeureFin.ToString(@"hh\:mm"),
                    Programme = s.ProgrammeName,
                    AssignmentDate = s.DateAffectation.ToShortDateString()
                }).OrderBy(s => s.DayNumber).ToList();

                dgvSchedule.DataSource = scheduleDisplay;

                if (dgvSchedule.Columns.Count > 0)
                {
                    dgvSchedule.Columns["DayNumber"].Visible = false;
                    dgvSchedule.Columns["Day"].HeaderText = "Day";
                    dgvSchedule.Columns["Date"].HeaderText = "Date";
                    dgvSchedule.Columns["Shift"].HeaderText = "Shift";
                    dgvSchedule.Columns["StartTime"].HeaderText = "Start";
                    dgvSchedule.Columns["EndTime"].HeaderText = "End";
                    dgvSchedule.Columns["Programme"].HeaderText = "Programme";
                    dgvSchedule.Columns["AssignmentDate"].HeaderText = "Assigned On";
                }

                var selectedEmployee = _employees.FirstOrDefault(e => e.Id == employeeId);
                lblEmployeeInfo.Text = $"Schedule for: {selectedEmployee?.Nom} {selectedEmployee?.Prenom} - Week of {weekStart.ToShortDateString()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading schedule: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDayName(int dayOfWeek)
        {
            return dayOfWeek switch
            {
                0 => "Dimanche",
                1 => "Lundi",
                2 => "Mardi",
                3 => "Mercredi",
                4 => "Jeudi",
                5 => "Vendredi",
                6 => "Samedi",
                _ => "Unknown"
            };
        }

        private void btnPreviousWeek_Click(object sender, EventArgs e)
        {
            dtpWeekStart.Value = dtpWeekStart.Value.AddDays(-7);
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            dtpWeekStart.Value = dtpWeekStart.Value.AddDays(7);
        }

        private void btnCurrentWeek_Click(object sender, EventArgs e)
        {
            dtpWeekStart.Value = GetStartOfWeek(DateTime.Now);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_schedules.Count == 0)
            {
                MessageBox.Show("No schedule data to export. Please view a schedule first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.Title = "Export Schedule";
                saveFileDialog.FileName = $"Schedule_{DateTime.Now:yyyyMMdd}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Schedule");

                    var selectedEmployee = _employees.FirstOrDefault(e => e.Id == (int)cmbEmployee.SelectedValue);
                    var weekStart = dtpWeekStart.Value.Date;

                    // Add title
                    worksheet.Cell(1, 1).Value = $"Schedule for: {selectedEmployee?.Nom} {selectedEmployee?.Prenom}";
                    worksheet.Cell(2, 1).Value = $"Week of: {weekStart.ToShortDateString()}";
                    worksheet.Range(1, 1, 1, 7).Merge();
                    worksheet.Range(2, 1, 2, 7).Merge();
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                    worksheet.Cell(2, 1).Style.Font.Bold = true;

                    // Add headers
                    worksheet.Cell(4, 1).Value = "Day";
                    worksheet.Cell(4, 2).Value = "Date";
                    worksheet.Cell(4, 3).Value = "Shift";
                    worksheet.Cell(4, 4).Value = "Start Time";
                    worksheet.Cell(4, 5).Value = "End Time";
                    worksheet.Cell(4, 6).Value = "Programme";
                    worksheet.Cell(4, 7).Value = "Assignment Date";

                    // Style headers
                    var headerRange = worksheet.Range(4, 1, 4, 7);
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                    headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Add data
                    int row = 5;
                    foreach (var schedule in _schedules.OrderBy(s => s.JourDeSemaine))
                    {
                        worksheet.Cell(row, 1).Value = GetDayName(schedule.JourDeSemaine);
                        worksheet.Cell(row, 2).Value = weekStart.AddDays(schedule.JourDeSemaine);
                        worksheet.Cell(row, 3).Value = schedule.ShiftNom;
                        worksheet.Cell(row, 4).Value = schedule.HeureDebut.ToString(@"hh\:mm");
                        worksheet.Cell(row, 5).Value = schedule.HeureFin.ToString(@"hh\:mm");
                        worksheet.Cell(row, 6).Value = schedule.ProgrammeName;
                        worksheet.Cell(row, 7).Value = schedule.DateAffectation;

                        // Format date columns
                        worksheet.Cell(row, 2).Style.DateFormat.Format = "dd/mm/yyyy";
                        worksheet.Cell(row, 7).Style.DateFormat.Format = "dd/mm/yyyy";

                        // Color code weekends
                        if (schedule.JourDeSemaine == 0 || schedule.JourDeSemaine == 6) // Sunday or Saturday
                        {
                            worksheet.Range(row, 1, row, 7).Style.Fill.BackgroundColor = XLColor.LightGray;
                        }

                        row++;
                    }

                    // Auto-fit columns
                    worksheet.Columns().AdjustToContents();

                    // Add borders to data
                    var dataRange = worksheet.Range(4, 1, row - 1, 7);
                    dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                    dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Add summary
                    worksheet.Cell(row + 1, 1).Value = "Total working days:";
                    worksheet.Cell(row + 1, 2).Value = _schedules.Count;
                    worksheet.Cell(row + 2, 1).Value = "Total hours:";
                    var totalHours = _schedules.Sum(s => (s.HeureFin - s.HeureDebut).TotalHours);
                    worksheet.Cell(row + 2, 2).Value = $"{totalHours:F1} hours";

                    // Style summary
                    var summaryRange = worksheet.Range(row + 1, 1, row + 2, 2);
                    summaryRange.Style.Font.Bold = true;

                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Schedule exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting schedule: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}