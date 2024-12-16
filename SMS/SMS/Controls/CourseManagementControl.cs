using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SMS.Controls
{
    public partial class CourseManagementControl : UserControl
    {
        public CourseManagementControl()
        {
            InitializeComponent();

            LoadStudents();

            guna2DateTimePickerStartDateCo.Value = DateTime.Now; // Reset to current date

            GetLatestEnrollmentID();
            SetButtonVisibility(true, false);
        }

        private string connectionString = "Data Source=DESKTOP;Initial Catalog=StudentManagementSystem;Integrated Security=True;";

// Toggle button visibility
        private void SetButtonVisibility(bool showAddButton, bool showUpdateRemoveButtons)
        {
            guna2ButtonAddEnrollmentCo.Visible = showAddButton;
            guna2ButtonUpdateEnrollmentCo.Visible = showUpdateRemoveButtons;
            guna2ButtonRemoveEnrollmentCo.Visible = showUpdateRemoveButtons;
        }

// Validate input fields
        private bool ValidateEnrollmentInputs()
        {
            /*if (guna2DateTimePickerStartDateCo.Value < DateTime.Now)
            {
                MessageBox.Show("Start Date cannot be in the past.", "Input Error");
                return false;
            }*/

            if (string.IsNullOrWhiteSpace(guna2ComboBoxDurationCo.Text))
            {
                MessageBox.Show("Please select a duration.", "Input Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBoxStudentIDCo.Text) ||
                string.IsNullOrWhiteSpace(guna2TextBoxCourseIDCo.Text) ||
                string.IsNullOrWhiteSpace(guna2TextBoxInstructorIDCo.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error");
                return false;
            }

            return true;
        }

// Get the latest Enrollment ID
        private void GetLatestEnrollmentID()
        {
            string query = "SELECT TOP 1 EnrollmentID FROM EnrollmentStudent ORDER BY EnrollmentID DESC";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                var result = cmd.ExecuteScalar();
                string latestID = result?.ToString() ?? "E0000";
                int numericPart = int.Parse(latestID.Substring(1)) + 1;
                guna2TextBoxEnrollmentIDCo.Text = "E" + numericPart.ToString("D4");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching latest Enrollment ID: " + ex.Message, "Error");
            }
        }

// Add enrollment
        private void guna2ButtonAddEnrollmentCo_Click(object sender, EventArgs e)
        {
            AddEnrollment();
        }
        private void AddEnrollment()
        {
            if (!ValidateEnrollmentInputs()) return;

            string query = "INSERT INTO EnrollmentStudent (EnrollmentID, StudentID, CourseID, InstructorID, StartDate, Duration) " +
                           "VALUES (@EnrollmentID, @StudentID, @CourseID, @InstructorID, @StartDate, @Duration)";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@EnrollmentID", guna2TextBoxEnrollmentIDCo.Text);
                cmd.Parameters.AddWithValue("@StudentID", guna2TextBoxStudentIDCo.Text);
                cmd.Parameters.AddWithValue("@CourseID", guna2TextBoxCourseIDCo.Text);
                cmd.Parameters.AddWithValue("@InstructorID", guna2TextBoxInstructorIDCo.Text);
                cmd.Parameters.AddWithValue("@StartDate", guna2DateTimePickerStartDateCo.Value.Date);
                cmd.Parameters.AddWithValue("@Duration", guna2ComboBoxDurationCo.Text);

                connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Enrollment added successfully!", "Success");

                ClearInputs();
                LoadEnrollments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding enrollment: " + ex.Message, "Error");
            }
        }

// Update enrollment
        private void guna2ButtonUpdateEnrollmentCo_Click(object sender, EventArgs e)
        {
            UpdateEnrollment();
        }
        private void UpdateEnrollment()
        {
            if (!ValidateEnrollmentInputs()) return;

            string query = "UPDATE EnrollmentStudent SET StudentID = @StudentID, CourseID = @CourseID, " +
                           "InstructorID = @InstructorID, StartDate = @StartDate, Duration = @Duration " +
                           "WHERE EnrollmentID = @EnrollmentID";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@EnrollmentID", guna2TextBoxEnrollmentIDCo.Text);
                cmd.Parameters.AddWithValue("@StudentID", guna2TextBoxStudentIDCo.Text);
                cmd.Parameters.AddWithValue("@CourseID", guna2TextBoxCourseIDCo.Text);
                cmd.Parameters.AddWithValue("@InstructorID", guna2TextBoxInstructorIDCo.Text);
                cmd.Parameters.AddWithValue("@StartDate", guna2DateTimePickerStartDateCo.Value.Date);
                cmd.Parameters.AddWithValue("@Duration", guna2ComboBoxDurationCo.Text);

                connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Enrollment updated successfully!", "Success");

                ClearInputs();
                LoadEnrollments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating enrollment: " + ex.Message, "Error");
            }
        }

// Remove enrollment
        private void guna2ButtonRemoveEnrollmentCo_Click(object sender, EventArgs e)
        {
            RemoveEnrollment();
        }
        private void RemoveEnrollment()
        {
            string query = "DELETE FROM EnrollmentStudent WHERE EnrollmentID = @EnrollmentID";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@EnrollmentID", guna2TextBoxEnrollmentIDCo.Text);

                connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Enrollment removed successfully!", "Success");

                ClearInputs();
                LoadEnrollments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing enrollment: " + ex.Message, "Error");
            }
        }

// Clear input fields
        private void guna2ButtonClearDataCo_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        private void ClearInputs()
        {
            guna2TextBoxEnrollmentIDCo.Clear();
            guna2TextBoxStudentIDCo.Clear();
            guna2TextBoxCourseIDCo.Clear();
            guna2TextBoxInstructorIDCo.Clear();
            guna2ComboBoxDurationCo.SelectedIndex = -1;
            guna2DateTimePickerStartDateCo.Value = DateTime.Now;

            GetLatestEnrollmentID();
            SetButtonVisibility(true, false);
        }

// Load data into the DataGridView
        private void LoadStudents()
        {
            try
            {
                string query = "SELECT * FROM Student ORDER BY StudentID DESC";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                guna2DataGridViewDetailsBoxCo.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students : " + ex.Message, "Error");
            }
        }

        private void LoadCourses()
        {
            try
            {
                string query = "SELECT * FROM Course ORDER BY CourseID DESC";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                guna2DataGridViewDetailsBoxCo.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses : " + ex.Message, "Error");
            }
        }

        private void LoadInstructors()
        {
            try
            {
                string query = "SELECT * FROM Instructor ORDER BY InstructorID DESC";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                guna2DataGridViewDetailsBoxCo.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading instructors : " + ex.Message, "Error");
            }
        }

        private void LoadEnrollments()
        {
            try
            {
                string query = "SELECT * FROM EnrollmentStudent ORDER BY EnrollmentID DESC";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                guna2DataGridViewDetailsBoxCo.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading enrollments : " + ex.Message, "Error");
            }
        }

        private void guna2ButtonSearchStuIDCo_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void guna2ButtonSearchCouIDCo_Click(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void guna2ButtonSearchInsIDCo_Click(object sender, EventArgs e)
        {
            LoadInstructors();
        }

        private void guna2ButtonSearchEnrIDCo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBoxSearchIDCo.Text))
            {
                LoadEnrollments();
            }
            else
            {
                SearchEnrollment();
            }
           
        }

        private void SearchEnrollment()
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                string query = "SELECT * FROM EnrollmentStudent WHERE EnrollmentID = @EnrollmentID";

                connection = new SqlConnection(connectionString);
                cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EnrollmentID", guna2TextBoxSearchIDCo.Text);

                connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    guna2TextBoxEnrollmentIDCo.Text = reader["EnrollmentID"].ToString();
                    guna2TextBoxStudentIDCo.Text = reader["StudentID"].ToString();
                    guna2TextBoxCourseIDCo.Text = reader["CourseID"].ToString();
                    guna2TextBoxInstructorIDCo.Text = reader["InstructorID"].ToString();
                    guna2DateTimePickerStartDateCo.Value = Convert.ToDateTime(reader["StartDate"]);
                    guna2ComboBoxDurationCo.Text = reader["Duration"].ToString();

                    SetButtonVisibility(false, true); // Adjust button visibility
                }
                else
                {
                    MessageBox.Show("Enrollment not found!", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching for the enrollment: {ex.Message}", "Error");
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
        }


    }
}
