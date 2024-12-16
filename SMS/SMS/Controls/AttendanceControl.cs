using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Controls
{
    public partial class AttendanceControl : UserControl
    {
        public AttendanceControl()
        {
            InitializeComponent();

            guna2DateTimePickerAttendanceDateAtt.Value = DateTime.Now; // Reset to current date

            LoadAttendance();

            SetButtonVisibility(true, false);
        }

        private string connectionString = "Data Source=DESKTOP;Initial Catalog=StudentManagementSystem;Integrated Security=True;";

        private void SetButtonVisibility(bool showAddButton, bool showUpdateRemoveButtons)
        {
            guna2ButtonAddAttendanceAtt.Visible = showAddButton;
            guna2ButtonUpdateAttendanceAtt.Visible = showUpdateRemoveButtons;
            guna2ButtonRemoveAttendanceAtt.Visible = showUpdateRemoveButtons;
        }

        // Load data into the DataGridView
        private void LoadAttendance()
        {
            try
            {
                string query = "SELECT * FROM Attendance ORDER BY AttendanceDate DESC";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                guna2DataGridViewDetailsBoxAtt.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Fees : " + ex.Message, "Error");
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(guna2TextBoxStudentIDAtt.Text) || string.IsNullOrWhiteSpace(guna2TextBoxStudentNameAtt.Text))
            {
                MessageBox.Show("Student ID and Student Name are required.", "Input Error");
                return false;
            }

            if (guna2DateTimePickerAttendanceDateAtt.Value > DateTime.Now)
            {
                MessageBox.Show("Attendance Date cannot be in the future.", "Input Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(guna2ComboBoxAbsentPresentAtt.Text))
            {
                MessageBox.Show("Please select attendance status (Absent/Present).", "Input Error");
                return false;
            }

            return true;
        }

        private void guna2ButtonSearchStdAtt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBoxStudentIDAtt.Text))
            {
                MessageBox.Show("Please enter Student ID!", "Input Error");
                return;
            }

            SearchStudentID();
        }

        private void SearchStudentID()
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                string query = "SELECT StudentID, Name FROM Student WHERE StudentID = @StudentID";

                connection = new SqlConnection(connectionString);
                cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StudentID", guna2TextBoxStudentIDAtt.Text);

                connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    guna2TextBoxStudentIDAtt.Text = reader["StudentID"].ToString();
                    guna2TextBoxStudentNameAtt.Text = reader["Name"].ToString();

                    //SetButtonVisibility(false, true); // Adjust button visibility
                }
                else
                {
                    MessageBox.Show("Student ID not found!", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching for the enrollment : " + ex.Message, "Error");
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
        }

        private void guna2ButtonAddAttendanceAtt_Click(object sender, EventArgs e)
        {
            AddAttendance();
        }

        private void AddAttendance()
        {
            if (!ValidateInputs()) return;

            string query = "INSERT INTO Attendance (StudentID, StudentName, AttendanceDate, AbsentOrPresent) " +
                           "VALUES (@StudentID, @StudentName, @AttendanceDate, @AbsentOrPresent)";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@StudentID", guna2TextBoxStudentIDAtt.Text);
                cmd.Parameters.AddWithValue("@StudentName", guna2TextBoxStudentNameAtt.Text);
                cmd.Parameters.AddWithValue("@AttendanceDate", guna2DateTimePickerAttendanceDateAtt.Value.Date);
                cmd.Parameters.AddWithValue("@AbsentOrPresent", guna2ComboBoxAbsentPresentAtt.Text);

                connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Attendance added successfully!", "Success");

                ClearInputs();
                LoadAttendance();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding attendance: " + ex.Message, "Error");
            }
        }

        private void guna2ButtonClearDataAtt_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            guna2TextBoxStudentIDAtt.Clear();
            guna2TextBoxStudentNameAtt.Clear();
            guna2ComboBoxAbsentPresentAtt.SelectedIndex = -1; // Clear ComboBox selection
            guna2DateTimePickerAttendanceDateAtt.Value = DateTime.Now; // Reset to current date

            SetButtonVisibility(true, false);
        }


        private void guna2ButtonUpdateAttendanceAtt_Click(object sender, EventArgs e)
        {
            UpdateAttendance();
        }

        private void UpdateAttendance()
        {
            if (!ValidateInputs()) return;

            string query = "UPDATE Attendance SET StudentName = @StudentName, AttendanceDate = @AttendanceDate, AbsentOrPresent = @AbsentOrPresent " +
                           "WHERE StudentID = @StudentID";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@StudentID", guna2TextBoxStudentIDAtt.Text);
                cmd.Parameters.AddWithValue("@StudentName", guna2TextBoxStudentNameAtt.Text);
                cmd.Parameters.AddWithValue("@AttendanceDate", guna2DateTimePickerAttendanceDateAtt.Value.Date);
                cmd.Parameters.AddWithValue("@AbsentOrPresent", guna2ComboBoxAbsentPresentAtt.Text);

                connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Attendance updated successfully!", "Success");

                ClearInputs();
                LoadAttendance();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating attendance : " + ex.Message, "Error");
            }
        }


        private void guna2ButtonRemoveAttendanceAtt_Click(object sender, EventArgs e)
        {
            RemoveAttendance();
        }

        private void RemoveAttendance()
        {
            string query = "DELETE FROM Attendance WHERE StudentID = @StudentID AND AttendanceDate = @AttendanceDate";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@StudentID", guna2TextBoxStudentIDAtt.Text);
                cmd.Parameters.AddWithValue("@AttendanceDate", guna2DateTimePickerAttendanceDateAtt.Value.Date);

                connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Attendance removed successfully!", "Success");

                ClearInputs();
                LoadAttendance();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing attendance : " + ex.Message, "Error");
            }
        }

        private void guna2ButtonSearchAttendanceAtt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBoxSearchAttendanceAtt.Text))
            {
                LoadAttendance();
            }
            else
            {
                SearchStudent();
            }
            
        }

        private void SearchStudent()
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            string query = "SELECT * FROM Attendance WHERE StudentID = @StudentID";

            try
            {
                connection = new SqlConnection(connectionString);
                cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@StudentID", guna2TextBoxSearchAttendanceAtt.Text);

                connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Populate the fields with the values from the database
                    guna2TextBoxStudentIDAtt.Text = reader["StudentID"].ToString();
                    guna2TextBoxStudentNameAtt.Text = reader["StudentName"].ToString();
                    guna2DateTimePickerAttendanceDateAtt.Value = Convert.ToDateTime(reader["AttendanceDate"]);
                    guna2ComboBoxAbsentPresentAtt.SelectedItem = reader["AbsentOrPresent"].ToString();

                    SetButtonVisibility(false, true);
                }
                else
                {
                    MessageBox.Show("Student ID not found!", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching student : " + ex.Message, "Error");
            }
        }


    }
}
