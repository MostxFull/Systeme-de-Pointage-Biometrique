using HRSchedulingSystem.Models;
using HRSchedulingSystem.Services;

namespace HRSchedulingSystem.Forms
{
    public partial class ProgrammeForm : Form
    {
        private readonly ProgrammeService _programmeService;
        private readonly ShiftService _shiftService;
        private List<Programme> _programmes = new();
        private List<Shift> _shifts = new();
        private Programme? _selectedProgramme;
        private List<ProgrammeHoraire> _programmeHoraires = new();
        private List<HoraireTravail> _horaireTravailList = new();

        // Shift checkboxes
        private List<CheckBox> _shiftCheckBoxes = new();

        // Day checkboxes
        private CheckBox chkLundi = new();
        private CheckBox chkMardi = new();
        private CheckBox chkMercredi = new();
        private CheckBox chkJeudi = new();
        private CheckBox chkVendredi = new();
        private CheckBox chkSamedi = new();
        private CheckBox chkDimanche = new();

        public ProgrammeForm()
        {
            InitializeComponent();
            _programmeService = new ProgrammeService();
            _shiftService = new ShiftService();
            LoadData();
            SetupDayCheckboxes();
        }

        private void SetupDayCheckboxes()
        {
            // Configure day checkboxes
            chkLundi.Text = "Lundi";
            chkLundi.Tag = DayOfWeek.Monday;
            chkMardi.Text = "Mardi";
            chkMardi.Tag = DayOfWeek.Tuesday;
            chkMercredi.Text = "Mercredi";
            chkMercredi.Tag = DayOfWeek.Wednesday;
            chkJeudi.Text = "Jeudi";
            chkJeudi.Tag = DayOfWeek.Thursday;
            chkVendredi.Text = "Vendredi";
            chkVendredi.Tag = DayOfWeek.Friday;
            chkSamedi.Text = "Samedi";
            chkSamedi.Tag = DayOfWeek.Saturday;
            chkDimanche.Text = "Dimanche";
            chkDimanche.Tag = DayOfWeek.Sunday;

            // Add to group box
            groupBoxDays.Controls.Add(chkLundi);
            groupBoxDays.Controls.Add(chkMardi);
            groupBoxDays.Controls.Add(chkMercredi);
            groupBoxDays.Controls.Add(chkJeudi);
            groupBoxDays.Controls.Add(chkVendredi);
            groupBoxDays.Controls.Add(chkSamedi);
            groupBoxDays.Controls.Add(chkDimanche);

            // Position checkboxes
            int x = 20, y = 25;
            foreach (CheckBox chk in new[] { chkLundi, chkMardi, chkMercredi, chkJeudi, chkVendredi, chkSamedi, chkDimanche })
            {
                chk.Location = new Point(x, y);
                chk.AutoSize = true;
                y += 25;
            }
        }

        private async void LoadData()
        {
            try
            {
                _shifts = (await _shiftService.GetAllAsync()).ToList();
                SetupShiftCheckboxes();
                await LoadProgrammes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupShiftCheckboxes()
        {
            // Clear existing checkboxes
            foreach (var chk in _shiftCheckBoxes)
            {
                groupBoxShifts.Controls.Remove(chk);
            }
            _shiftCheckBoxes.Clear();

            // Create checkboxes for each shift
            int y = 25;
            foreach (var shift in _shifts)
            {
                var chkShift = new CheckBox
                {
                    Text = $"{shift.Nom} [{shift.HeureDebut:hh\\:mm} - {shift.HeureFin:hh\\:mm}]",
                    Tag = shift,
                    Location = new Point(20, y),
                    AutoSize = true
                };

                // Make shifts mutually exclusive (like radio buttons)
                chkShift.CheckedChanged += (s, e) =>
                {
                    if (chkShift.Checked)
                    {
                        // Uncheck all other shift checkboxes
                        foreach (var otherChk in _shiftCheckBoxes)
                        {
                            if (otherChk != chkShift)
                                otherChk.Checked = false;
                        }
                    }
                };

                _shiftCheckBoxes.Add(chkShift);
                groupBoxShifts.Controls.Add(chkShift);
                y += 25;
            }
        }

        private async Task LoadProgrammes()
        {
            try
            {
                _programmes = (await _programmeService.GetAllAsync()).ToList();
                dgvProgrammes.DataSource = _programmes;

                if (dgvProgrammes.Columns.Count > 0)
                {
                    dgvProgrammes.Columns["Id"].Visible = false;
                    dgvProgrammes.Columns["Nom"].HeaderText = "Programme Name";
                    dgvProgrammes.Columns["DateDebut"].HeaderText = "Start Date";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading programmes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadProgrammeHoraires()
        {
            if (_selectedProgramme == null) return;

            try
            {
                _programmeHoraires = (await _programmeService.GetProgrammeHorairesAsync(_selectedProgramme.Id)).ToList();

                // Convert to HoraireTravail for display
                _horaireTravailList = _programmeHoraires.Select(h => new HoraireTravail
                {
                    Jour = (DayOfWeek)(h.JourDeSemaine == 0 ? 7 : h.JourDeSemaine), // Convert Sunday from 0 to 7
                    HeureDebut = _shifts.FirstOrDefault(s => s.Id == h.ShiftId)?.HeureDebut ?? TimeSpan.Zero,
                    HeureFin = _shifts.FirstOrDefault(s => s.Id == h.ShiftId)?.HeureFin ?? TimeSpan.Zero,
                    DateDebut = _selectedProgramme?.DateDebut ?? DateTime.Now, // Add null check here
                    ShiftName = _shifts.FirstOrDefault(s => s.Id == h.ShiftId)?.Nom ?? "Unknown"
                }).ToList();

                RefreshWeeklyGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading programme schedules: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshWeeklyGrid()
        {
            var scheduleDisplay = _horaireTravailList.Select(h => new
            {
                Day = GetFrenchDayName(h.Jour),
                DayNumber = (int)h.Jour,
                Shift = h.ShiftName,
                StartTime = h.HeureDebut.ToString(@"hh\:mm"),
                EndTime = h.HeureFin.ToString(@"hh\:mm"),
                StartDate = h.DateDebut.ToShortDateString()
            }).OrderBy(s => s.DayNumber == 7 ? 0 : s.DayNumber).ToList(); // Sunday first

            dgvWeeklySchedule.DataSource = scheduleDisplay;

            if (dgvWeeklySchedule.Columns.Count > 0)
            {
                dgvWeeklySchedule.Columns["DayNumber"].Visible = false;
                dgvWeeklySchedule.Columns["Day"].HeaderText = "Day";
                dgvWeeklySchedule.Columns["Shift"].HeaderText = "Shift";
                dgvWeeklySchedule.Columns["StartTime"].HeaderText = "Start";
                dgvWeeklySchedule.Columns["EndTime"].HeaderText = "End";
                dgvWeeklySchedule.Columns["StartDate"].HeaderText = "Week Start";
            }
        }

        private string GetFrenchDayName(DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Monday => "Lundi",
                DayOfWeek.Tuesday => "Mardi",
                DayOfWeek.Wednesday => "Mercredi",
                DayOfWeek.Thursday => "Jeudi",
                DayOfWeek.Friday => "Vendredi",
                DayOfWeek.Saturday => "Samedi",
                DayOfWeek.Sunday => "Dimanche",
                _ => "Unknown"
            };
        }

        private async void dgvProgrammes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProgrammes.SelectedRows.Count > 0)
            {
                var selectedRow = dgvProgrammes.SelectedRows[0];
                _selectedProgramme = selectedRow.DataBoundItem as Programme;

                if (_selectedProgramme != null)
                {
                    txtNom.Text = _selectedProgramme.Nom;
                    dtpDateDebut.Value = _selectedProgramme.DateDebut;
                    dtpPeriodStart.Value = _selectedProgramme.DateDebut;
                    await LoadProgrammeHoraires();
                }
            }
            else
            {
                // Handle case when no programme is selected
                _selectedProgramme = null;
                dgvWeeklySchedule.DataSource = null;
                _horaireTravailList.Clear();
                _programmeHoraires.Clear();
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
                var programme = new Programme
                {
                    Nom = txtNom.Text.Trim(),
                    DateDebut = dtpDateDebut.Value.Date
                };

                if (_selectedProgramme == null)
                {
                    await _programmeService.CreateAsync(programme);
                    MessageBox.Show("Programme created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    programme.Id = _selectedProgramme.Id;
                    await _programmeService.UpdateAsync(programme);
                    MessageBox.Show("Programme updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await LoadProgrammes();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving programme: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProgramme == null)
            {
                MessageBox.Show("Please select a programme to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete '{_selectedProgramme.Nom}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _programmeService.DeleteAsync(_selectedProgramme.Id);
                    MessageBox.Show("Programme deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProgrammes();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting programme: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnAddSchedule_Click(object sender, EventArgs e)
        {
            if (_selectedProgramme == null)
            {
                MessageBox.Show("Please select a programme first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected shift
            var selectedShift = _shiftCheckBoxes.FirstOrDefault(chk => chk.Checked)?.Tag as Shift;
            if (selectedShift == null)
            {
                MessageBox.Show("Please select a shift category.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected days
            var selectedDays = new List<DayOfWeek>();
            var dayCheckboxes = new[] { chkLundi, chkMardi, chkMercredi, chkJeudi, chkVendredi, chkSamedi, chkDimanche };

            foreach (var chk in dayCheckboxes)
            {
                if (chk.Checked)
                {
                    selectedDays.Add((DayOfWeek)chk.Tag);
                }
            }

            if (selectedDays.Count == 0)
            {
                MessageBox.Show("Please select at least one day of the week.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var periodStart = dtpPeriodStart.Value.Date;

                // Add schedule entries for each selected day
                foreach (var day in selectedDays)
                {
                    // Convert DayOfWeek to database format (0=Sunday, 1=Monday, etc.)
                    int dayNumber = day == DayOfWeek.Sunday ? 0 : (int)day;

                    await _programmeService.AddShiftToProgrammeAsync(
                        _selectedProgramme.Id,
                        dayNumber,
                        selectedShift.Id);

                    // Add to in-memory list for immediate display
                    _horaireTravailList.Add(new HoraireTravail
                    {
                        Jour = day,
                        HeureDebut = selectedShift.HeureDebut,
                        HeureFin = selectedShift.HeureFin,
                        DateDebut = periodStart,
                        ShiftName = selectedShift.Nom
                    });
                }

                MessageBox.Show($"Schedule added successfully for {selectedDays.Count} day(s)!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the display
                RefreshWeeklyGrid();
                await LoadProgrammeHoraires();

                // Clear selections
                ClearScheduleSelections();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding schedule: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearScheduleSelections()
        {
            // Uncheck all shift checkboxes
            foreach (var chk in _shiftCheckBoxes)
            {
                chk.Checked = false;
            }

            // Uncheck all day checkboxes
            var dayCheckboxes = new[] { chkLundi, chkMardi, chkMercredi, chkJeudi, chkVendredi, chkSamedi, chkDimanche };
            foreach (var chk in dayCheckboxes)
            {
                chk.Checked = false;
            }
        }

        private async void btnRemoveSchedule_Click(object sender, EventArgs e)
        {
            if (dgvWeeklySchedule.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a schedule entry to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to remove this schedule entry?",
                "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Find the corresponding ProgrammeHoraire entry to remove
                    var selectedRow = dgvWeeklySchedule.SelectedRows[0];
                    var dayNumber = (int)selectedRow.Cells["DayNumber"].Value;

                    var horaireToRemove = _programmeHoraires.FirstOrDefault(h => h.JourDeSemaine == dayNumber);
                    if (horaireToRemove != null)
                    {
                        await _programmeService.RemoveShiftFromProgrammeAsync(horaireToRemove.Id);
                        MessageBox.Show("Schedule entry removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadProgrammeHoraires();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error removing schedule: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSelectWorkdays_Click(object sender, EventArgs e)
        {
            // Quick select Monday to Friday
            chkLundi.Checked = true;
            chkMardi.Checked = true;
            chkMercredi.Checked = true;
            chkJeudi.Checked = true;
            chkVendredi.Checked = true;
            chkSamedi.Checked = false;
            chkDimanche.Checked = false;
        }

        private void btnSelectWeekend_Click(object sender, EventArgs e)
        {
            // Quick select Saturday and Sunday
            chkLundi.Checked = false;
            chkMardi.Checked = false;
            chkMercredi.Checked = false;
            chkJeudi.Checked = false;
            chkVendredi.Checked = false;
            chkSamedi.Checked = true;
            chkDimanche.Checked = true;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            // Select all days
            var dayCheckboxes = new[] { chkLundi, chkMardi, chkMercredi, chkJeudi, chkVendredi, chkSamedi, chkDimanche };
            foreach (var chk in dayCheckboxes)
            {
                chk.Checked = true;
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            // Clear all selections
            ClearScheduleSelections();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Please enter a programme name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtNom.Clear();
            dtpDateDebut.Value = DateTime.Now;
            dtpPeriodStart.Value = DateTime.Now;
            _selectedProgramme = null;
            dgvProgrammes.ClearSelection();
            dgvWeeklySchedule.DataSource = null;
            _horaireTravailList.Clear();
            _programmeHoraires.Clear(); // Add this line to clear programme horaires
            ClearScheduleSelections();
        }
    }

    
}
