using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HRSchedulingSystem.Models;
using HRSchedulingSystem.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HRSchedulingSystem.Forms
{
    public partial class AddDeviceForm : Form
    {
        private DatabaseHelper databaseHelper;
        private List<Pointeuse> devices;
        private Pointeuse selectedDevice;
        private bool isEditMode = false;

        public AddDeviceForm()
        {
            InitializeComponent();
            databaseHelper = new DatabaseHelper();
            devices = new List<Pointeuse>();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadDevices();
            SetupDeviceList();
            ClearForm();
            UpdateButtonStates();
        }

        private void LoadDevices()
        {
            try
            {
                devices.Clear();
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                connection.Open();

                var query = "SELECT Id, Numero, Nom, IP, Port, Password FROM Pointeuse ORDER BY Nom";
                using var command = new SqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    devices.Add(new Pointeuse
                    {
                        Id = reader.GetInt32("Id"),
                        Numero = reader.GetInt32("Numero"),
                        Nom = reader.GetString("Nom"),
                        IP = reader.GetString("IP"),
                        Port = reader.GetInt32("Port"),
                        Password = reader.IsDBNull("Password") ? "" : reader.GetString("Password")
                    });
                }

                RefreshDeviceList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des appareils : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDeviceList()
        {
            dgvDevices.AutoGenerateColumns = false;
            dgvDevices.Columns.Clear();

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50,
                ReadOnly = true
            });

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Numero",
                HeaderText = "Numéro",
                DataPropertyName = "Numero",
                Width = 80,
                ReadOnly = true
            });

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nom",
                HeaderText = "Nom de l'Appareil",
                DataPropertyName = "Nom",
                Width = 150,
                ReadOnly = true
            });

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IP",
                HeaderText = "Adresse IP",
                DataPropertyName = "IP",
                Width = 120,
                ReadOnly = true
            });

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Port",
                HeaderText = "Port",
                DataPropertyName = "Port",
                Width = 80,
                ReadOnly = true
            });

            dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevices.MultiSelect = false;
            dgvDevices.SelectionChanged += DgvDevices_SelectionChanged;
        }

        private void RefreshDeviceList()
        {
            dgvDevices.DataSource = null;
            dgvDevices.DataSource = devices;
            lblDeviceCount.Text = $"Total Appareils : {devices.Count}";
        }

        private void DgvDevices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDevices.SelectedRows.Count > 0)
            {
                var selectedRow = dgvDevices.SelectedRows[0];
                selectedDevice = selectedRow.DataBoundItem as Pointeuse;
                LoadDeviceToForm(selectedDevice);
                UpdateButtonStates();
            }
            else
            {
                selectedDevice = null;
                UpdateButtonStates();
            }
        }

        private void LoadDeviceToForm(Pointeuse device)
        {
            if (device != null)
            {
                numNumero.Value = device.Numero;
                txtNom.Text = device.Nom;
                txtIP.Text = device.IP;
                numPort.Value = device.Port;
                txtPassword.Text = device.Password;
            }
        }

        private void ClearForm()
        {
            numNumero.Value = 1;
            txtNom.Text = "";
            txtIP.Text = "192.168.1.100";
            numPort.Value = 4370;
            txtPassword.Text = "";
            selectedDevice = null;
            isEditMode = false;
            lblTitle.Text = "Gestion des Appareils";
            btnSave.Text = "Ajouter Appareil";
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = selectedDevice != null;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
            btnTestConnection.Enabled = !string.IsNullOrWhiteSpace(txtIP.Text) && numPort.Value > 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            isEditMode = false;
            lblTitle.Text = "Ajouter Nouvel Appareil";
            btnSave.Text = "Ajouter Appareil";
            txtNom.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedDevice != null)
            {
                isEditMode = true;
                lblTitle.Text = $"Modifier Appareil : {selectedDevice.Nom}";
                btnSave.Text = "Mettre à Jour";
                txtNom.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedDevice == null) return;

            var result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer l'appareil '{selectedDevice.Nom}' ?\n\n" +
                "Cette action ne peut pas être annulée et peut affecter les enregistrements de présence.",
                "Confirmer la Suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteDevice(selectedDevice);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    var device = new Pointeuse
                    {
                        Id = isEditMode ? selectedDevice.Id : 0,
                        Numero = (int)numNumero.Value,
                        Nom = txtNom.Text.Trim(),
                        IP = txtIP.Text.Trim(),
                        Port = (int)numPort.Value,
                        Password = txtPassword.Text.Trim()
                    };

                    bool success = isEditMode ? UpdateDevice(device) : SaveDevice(device);

                    if (success)
                    {
                        string action = isEditMode ? "mis à jour" : "ajouté";
                        MessageBox.Show($"Appareil {action} avec succès !", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDevices();
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sauvegarde de l'appareil : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                ClearForm();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDevices();
            ClearForm();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIP.Text) || numPort.Value == 0)
                {
                    MessageBox.Show("Veuillez d'abord saisir l'adresse IP et le port.", "Erreur de Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnTestConnection.Enabled = false;
                btnTestConnection.Text = "Test en cours...";
                Application.DoEvents();

                // Test connection using ZktecoService
                using var service = new HRSchedulingSystem.Services.ZktecoService();
                bool connected = service.Connect(txtIP.Text.Trim(), (int)numPort.Value, (int)numNumero.Value);

                if (connected)
                {
                    MessageBox.Show("Connexion réussie !", "Résultat du Test",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    service.Disconnect();
                }
                else
                {
                    MessageBox.Show("Échec de la connexion. Veuillez vérifier l'adresse IP, le port et l'état de l'appareil.",
                        "Résultat du Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du test de connexion : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnTestConnection.Enabled = true;
                btnTestConnection.Text = "Tester Connexion";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Veuillez saisir le nom de l'appareil.", "Erreur de Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIP.Text))
            {
                MessageBox.Show("Veuillez saisir l'adresse IP.", "Erreur de Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIP.Focus();
                return false;
            }

            if (!System.Net.IPAddress.TryParse(txtIP.Text.Trim(), out _))
            {
                MessageBox.Show("Veuillez saisir une adresse IP valide.", "Erreur de Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIP.Focus();
                return false;
            }

            if (numPort.Value < 1 || numPort.Value > 65535)
            {
                MessageBox.Show("Veuillez saisir un numéro de port valide (1-65535).", "Erreur de Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPort.Focus();
                return false;
            }

            // Check for duplicate IP:Port combination (excluding current device in edit mode)
            var existingDevice = devices.FirstOrDefault(d =>
                d.IP == txtIP.Text.Trim() &&
                d.Port == (int)numPort.Value &&
                (!isEditMode || d.Id != selectedDevice.Id));

            if (existingDevice != null)
            {
                MessageBox.Show($"Un appareil avec l'IP {txtIP.Text.Trim()}:{numPort.Value} existe déjà.",
                    "Appareil Dupliqué", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool SaveDevice(Pointeuse device)
        {
            try
            {
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                connection.Open();

                var insertQuery = @"INSERT INTO Pointeuse (Numero, Nom, IP, Port, Password) 
                                   VALUES (@Numero, @Nom, @IP, @Port, @Password)";
                using var insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@Numero", device.Numero);
                insertCommand.Parameters.AddWithValue("@Nom", device.Nom);
                insertCommand.Parameters.AddWithValue("@IP", device.IP);
                insertCommand.Parameters.AddWithValue("@Port", device.Port);
                insertCommand.Parameters.AddWithValue("@Password", device.Password ?? "");

                return insertCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de base de données : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool UpdateDevice(Pointeuse device)
        {
            try
            {
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                connection.Open();

                var updateQuery = @"UPDATE Pointeuse SET 
                                   Numero = @Numero, Nom = @Nom, IP = @IP, Port = @Port, Password = @Password 
                                   WHERE Id = @Id";
                using var updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@Id", device.Id);
                updateCommand.Parameters.AddWithValue("@Numero", device.Numero);
                updateCommand.Parameters.AddWithValue("@Nom", device.Nom);
                updateCommand.Parameters.AddWithValue("@IP", device.IP);
                updateCommand.Parameters.AddWithValue("@Port", device.Port);
                updateCommand.Parameters.AddWithValue("@Password", device.Password ?? "");

                return updateCommand.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de base de données : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void DeleteDevice(Pointeuse device)
        {
            try
            {
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                connection.Open();

                // Check if device has attendance records
                var checkQuery = "SELECT COUNT(*) FROM Pointage WHERE PointeuseId = @DeviceId";
                using var checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@DeviceId", device.Id);
                int attendanceCount = (int)checkCommand.ExecuteScalar();

                if (attendanceCount > 0)
                {
                    var result = MessageBox.Show(
                        $"Cet appareil a {attendanceCount} enregistrements de présence associés.\n\n" +
                        "Supprimer cet appareil supprimera également tous les enregistrements de présence associés.\n" +
                        "Voulez-vous continuer ?",
                        "Attention : Enregistrements Associés Trouvés",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result != DialogResult.Yes)
                        return;

                    // Delete associated attendance records first
                    var deleteAttendanceQuery = "DELETE FROM Pointage WHERE PointeuseId = @DeviceId";
                    using var deleteAttendanceCommand = new SqlCommand(deleteAttendanceQuery, connection);
                    deleteAttendanceCommand.Parameters.AddWithValue("@DeviceId", device.Id);
                    deleteAttendanceCommand.ExecuteNonQuery();
                }

                // Delete the device
                var deleteQuery = "DELETE FROM Pointeuse WHERE Id = @Id";
                using var deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@Id", device.Id);

                if (deleteCommand.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show($"Appareil '{device.Nom}' supprimé avec succès !", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDevices();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Échec de la suppression de l'appareil.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression de l'appareil : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }
    }
}
