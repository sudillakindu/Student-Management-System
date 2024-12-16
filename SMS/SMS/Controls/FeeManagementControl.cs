using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SMS.Controls
{
    public partial class FeeManagementControl : UserControl
    {
        public FeeManagementControl()
        {
            InitializeComponent();

            guna2DateTimePickerPaymentDateFee.Value = DateTime.Now; // Reset to current date

            GetLatestFeeID();
            LoadFees();

            Visible_Guna2TextBoxAmountPaidFee_Guna2TextBoxRemBalanceFee(false);
            SetButtonVisibility(true, false);
        }

        private string connectionString = "Data Source=DESKTOP;Initial Catalog=StudentManagementSystem;Integrated Security=True;";

        private void Visible_Guna2TextBoxAmountPaidFee_Guna2TextBoxRemBalanceFee(Boolean visibleTextBox)
        {
            guna2TextBoxAmountPaidFee.Visible = visibleTextBox;
            guna2TextBoxRemBalanceFee.Visible = visibleTextBox;
        }

        private void SetButtonVisibility(bool showAddButton, bool showUpdateRemoveButtons)
        {
            guna2ButtonAddFee.Visible = showAddButton;
            guna2ButtonUpdateFee.Visible = showUpdateRemoveButtons;
            guna2ButtonRemoveFee.Visible = showUpdateRemoveButtons;
        }

        // Get the latest Fee ID
        private void GetLatestFeeID()
        {
            string query = "SELECT TOP 1 FeeID FROM FeeManagement ORDER BY FeeID DESC";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                var result = cmd.ExecuteScalar();
                string latestID = result?.ToString() ?? "F0000";
                int numericPart = int.Parse(latestID.Substring(1)) + 1;
                guna2TextBoxFeeIDFee.Text = "F" + numericPart.ToString("D4");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching latest Fee ID : " + ex.Message, "Error");
            }
        }

        //
        private void guna2ButtonSearchEnrollmentIDFee_Click(object sender, EventArgs e)
        {
            string SearchEnrollmentID = guna2TextBoxSearchEnrollmentIDFee.Text;

            if (!string.IsNullOrWhiteSpace(SearchEnrollmentID))
            {

                MessageBox.Show("Searching for : " + SearchEnrollmentID, "Searching");
                SearchEnrollment_to_StudentID_CourseID(SearchEnrollmentID);

                string SearchStudentID = guna2TextBoxStudentIDFee.Text;
                SearchStudent_to_Name(SearchStudentID);

                string SearchCourseID = guna2TextBoxCourseIDFee.Text;
                SearchCourse_to_CourseName(SearchCourseID);
            }
            else
            {
                MessageBox.Show("Please enter a value to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SearchEnrollment_to_StudentID_CourseID(string SearchEnrollmentID)
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                string query = "SELECT StudentID, CourseID FROM EnrollmentStudent WHERE EnrollmentID = @EnrollmentID";

                connection = new SqlConnection(connectionString);
                cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EnrollmentID", SearchEnrollmentID);

                connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    guna2TextBoxStudentIDFee.Text = reader["StudentID"].ToString();
                    guna2TextBoxCourseIDFee.Text = reader["CourseID"].ToString();

                }
                else
                {
                    MessageBox.Show("Enrollment not found!", "Info");
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

        private void SearchStudent_to_Name(string SearchStudentID)
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                string query = "SELECT Name FROM Student WHERE StudentID = @StudentID";

                connection = new SqlConnection(connectionString);
                cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StudentID", SearchStudentID);

                connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    guna2TextBoxStudentNameFee.Text = reader["Name"].ToString();
                }
                else
                {
                    //MessageBox.Show("Student Name not found!", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching for the Student Name : " + ex.Message, "Error");
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
        }

        private void SearchCourse_to_CourseName(string SearchCourseID)
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                string query = "SELECT CourseName,CoursePrice FROM Course WHERE CourseID = @CourseID";

                connection = new SqlConnection(connectionString);
                cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CourseID", SearchCourseID);

                connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    guna2TextBoxCourseNameFee.Text = reader["CourseName"].ToString();
                    guna2TextBoxTotalFeeFee.Text = reader["CoursePrice"].ToString();
                }
                else
                {
                    //MessageBox.Show("Course Name not found!", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching for the Course Name : " + ex.Message, "Error");
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
        }

        //
        private void guna2ComboBoxStatusFee_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if SelectedItem is not null
            if (guna2ComboBoxStatusFee.SelectedItem != null &&
                (guna2ComboBoxStatusFee.SelectedItem.ToString() == "Partial" ||
                 guna2ComboBoxStatusFee.SelectedItem.ToString() == "Paid"))
            {
                Visible_Guna2TextBoxAmountPaidFee_Guna2TextBoxRemBalanceFee(true);

                if (guna2ComboBoxStatusFee.SelectedItem.ToString() == "Paid")
                {
                    guna2TextBoxAmountPaidFee.Text = guna2TextBoxTotalFeeFee.Text;

                    UpdateRemainingBalance();
                }
                else
                {
                    guna2TextBoxAmountPaidFee.Clear();
                    guna2TextBoxRemBalanceFee.Clear();
                }  
            }
            else
            {
                //guna2TextBoxAmountPaidFee.Text = "null";
                //guna2TextBoxRemBalanceFee.Text = "null";

                Visible_Guna2TextBoxAmountPaidFee_Guna2TextBoxRemBalanceFee(false);
            }
        }


        //
        private void guna2ButtonCalculateRemBalanceFee_Click(object sender, EventArgs e)
        {
            UpdateRemainingBalance();
        }

        private void UpdateRemainingBalance()
        {
            try
            {
                guna2TextBoxRemBalanceFee.Clear();

                guna2TextBoxRemBalanceFee.Text = Convert.ToString(Convert.ToDecimal(guna2TextBoxTotalFeeFee.Text) - Convert.ToDecimal(guna2TextBoxAmountPaidFee.Text));
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values.");
            }
        }


        //
        private bool ValidateFeeInputs()
        {
            // Validate Fee ID
            if (string.IsNullOrWhiteSpace(guna2TextBoxFeeIDFee.Text))
            {
                MessageBox.Show("Fee ID cannot be empty.", "Input Error");
                return false;
            }

            // Validate Student ID
            if (string.IsNullOrWhiteSpace(guna2TextBoxStudentIDFee.Text))
            {
                MessageBox.Show("Student ID cannot be empty.", "Input Error");
                return false;
            }

            // Validate Student Name
            if (string.IsNullOrWhiteSpace(guna2TextBoxStudentNameFee.Text))
            {
                MessageBox.Show("Student Name cannot be empty.", "Input Error");
                return false;
            }

            // Validate Course ID
            if (string.IsNullOrWhiteSpace(guna2TextBoxCourseIDFee.Text))
            {
                MessageBox.Show("Course ID cannot be empty.", "Input Error");
                return false;
            }

            // Validate Course Name
            if (string.IsNullOrWhiteSpace(guna2TextBoxCourseNameFee.Text))
            {
                MessageBox.Show("Course Name cannot be empty.", "Input Error");
                return false;
            }

            // Validate Total Fee
            if (string.IsNullOrWhiteSpace(guna2TextBoxTotalFeeFee.Text))
            {
                MessageBox.Show("Total Fee cannot be empty.", "Input Error");
                return false;
            }

            // Validate Payment Date
            if (guna2DateTimePickerPaymentDateFee.Value > DateTime.Now)
            {
                MessageBox.Show("Payment Date cannot be in the past.", "Input Error");
                return false;
            }

            // Validate Status
            if (string.IsNullOrWhiteSpace(guna2ComboBoxStatusFee.Text))
            {
                MessageBox.Show("Please select a status.", "Input Error");
                return false;
            }

            // Validate Amount Paid or Remaining Balance
            if (guna2ComboBoxStatusFee.SelectedItem.ToString() == "Partial" || guna2ComboBoxStatusFee.SelectedItem.ToString() == "Paid")
            {
                // Validate Amount Paid
                if (string.IsNullOrWhiteSpace(guna2TextBoxAmountPaidFee.Text))
                {
                    MessageBox.Show("Amount Paid cannot be empty.", "Input Error");
                    return false;
                }

                // Validate Remaining Balance
                if (string.IsNullOrWhiteSpace(guna2TextBoxRemBalanceFee.Text))
                {
                    MessageBox.Show("Remaining Balance cannot be empty.", "Input Error");
                    return false;
                }
            }

            return true;
        }

// Add Fee
        private void guna2ButtonAddFee_Click(object sender, EventArgs e)
        {
            AddFee();
        }
        private void AddFee()
        {
            if (!ValidateFeeInputs()) return;

            string query = "INSERT INTO FeeManagement (EnrollmentID, FeeID, StudentID, StudentName, CourseID, CourseName, PaymentDate, TotalFee, Status, AmountPaid, RemBalance, Note)" +
                           "VALUES (@EnrollmentID, @FeeID, @StudentID, @StudentName, @CourseID, @CourseName, @PaymentDate, @TotalFee, @Status, @AmountPaid, @RemBalance, @Note)";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, connection);

                // Add parameters with values
                cmd.Parameters.AddWithValue("@EnrollmentID", guna2TextBoxSearchEnrollmentIDFee.Text);
                cmd.Parameters.AddWithValue("@FeeID", guna2TextBoxFeeIDFee.Text);
                cmd.Parameters.AddWithValue("@StudentID", guna2TextBoxStudentIDFee.Text);
                cmd.Parameters.AddWithValue("@StudentName", guna2TextBoxStudentNameFee.Text);
                cmd.Parameters.AddWithValue("@CourseID", guna2TextBoxCourseIDFee.Text);
                cmd.Parameters.AddWithValue("@CourseName", guna2TextBoxCourseNameFee.Text);
                cmd.Parameters.AddWithValue("@PaymentDate", guna2DateTimePickerPaymentDateFee.Value.Date);
                cmd.Parameters.AddWithValue("@TotalFee", Convert.ToDecimal(guna2TextBoxTotalFeeFee.Text));
                cmd.Parameters.AddWithValue("@Status", guna2ComboBoxStatusFee.Text);

                if (string.IsNullOrEmpty(guna2TextBoxAmountPaidFee.Text) || string.IsNullOrEmpty(guna2TextBoxRemBalanceFee.Text))
                {
                    // Add null values for the parameters if the textboxes are empty
                    cmd.Parameters.AddWithValue("@AmountPaid", DBNull.Value);
                    cmd.Parameters.AddWithValue("@RemBalance", DBNull.Value);
                }
                else
                {
                    // Add the actual values if the textboxes contain valid data
                    cmd.Parameters.AddWithValue("@AmountPaid", Convert.ToDecimal(guna2TextBoxAmountPaidFee.Text));
                    cmd.Parameters.AddWithValue("@RemBalance", Convert.ToDecimal(guna2TextBoxRemBalanceFee.Text));
                }

                cmd.Parameters.AddWithValue("@Note", guna2TextBoxNoteFee.Text);

                connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Fee added successfully!", "Success");

                ClearInputs();
                LoadFees();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding Fee : " + ex.Message, "Error");
            }
        }

        // Update Fee
        private void guna2ButtonUpdateFee_Click(object sender, EventArgs e)
        {
            UpdateFee();
        }
        private void UpdateFee()
        {
            if (!ValidateFeeInputs()) return;

            string query = "UPDATE FeeManagement SET " +
                           "EnrollmentID = @EnrollmentID, StudentID = @StudentID, " +
                           "StudentName = @StudentName, CourseID = @CourseID, CourseName = @CourseName, " +
                           "PaymentDate = @PaymentDate, TotalFee = @TotalFee, Status = @Status, AmountPaid = @AmountPaid, " +
                           "RemBalance = @RemBalance, Note = @Note " +
                           "WHERE FeeID = @FeeID";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, connection);

                // Add parameters with values
                cmd.Parameters.AddWithValue("@EnrollmentID", guna2TextBoxSearchEnrollmentIDFee.Text);
                cmd.Parameters.AddWithValue("@FeeID", guna2TextBoxFeeIDFee.Text);
                cmd.Parameters.AddWithValue("@StudentID", guna2TextBoxStudentIDFee.Text);
                cmd.Parameters.AddWithValue("@StudentName", guna2TextBoxStudentNameFee.Text);
                cmd.Parameters.AddWithValue("@CourseID", guna2TextBoxCourseIDFee.Text);
                cmd.Parameters.AddWithValue("@CourseName", guna2TextBoxCourseNameFee.Text);
                cmd.Parameters.AddWithValue("@PaymentDate", guna2DateTimePickerPaymentDateFee.Value.Date);
                cmd.Parameters.AddWithValue("@TotalFee", Convert.ToDecimal(guna2TextBoxTotalFeeFee.Text));
                cmd.Parameters.AddWithValue("@Status", guna2ComboBoxStatusFee.Text);

                if (string.IsNullOrEmpty(guna2TextBoxAmountPaidFee.Text) || string.IsNullOrEmpty(guna2TextBoxRemBalanceFee.Text))
                {
                    // Add null values for the parameters if the textboxes are empty
                    cmd.Parameters.AddWithValue("@AmountPaid", DBNull.Value);
                    cmd.Parameters.AddWithValue("@RemBalance", DBNull.Value);
                }
                else
                {
                    // Add the actual values if the textboxes contain valid data
                    cmd.Parameters.AddWithValue("@AmountPaid", Convert.ToDecimal(guna2TextBoxAmountPaidFee.Text));
                    cmd.Parameters.AddWithValue("@RemBalance", Convert.ToDecimal(guna2TextBoxRemBalanceFee.Text));
                }

                cmd.Parameters.AddWithValue("@Note", guna2TextBoxNoteFee.Text);

                connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Fee updated successfully!", "Success");

                ClearInputs();
                LoadFees();

                connection.Close();
            }
            catch (SqlException ex)
            {
                // Handle database-specific errors
                MessageBox.Show("Database error while updating Fee : " + ex.Message, "Error");
            }
            catch (Exception ex)
            {
                // Handle general errors
                MessageBox.Show("Error updating Fee : " + ex.Message, "Error");
            }
        }

        // Remove Fee
        private void guna2ButtonRemoveFee_Click(object sender, EventArgs e)
        {
            RemoveFee();
        }
        private void RemoveFee()
        {
            if (string.IsNullOrEmpty(guna2TextBoxFeeIDFee.Text))
            {
                MessageBox.Show("Please enter a Fee ID to remove.", "Validation Error");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to remove this fee?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }

            string query = "DELETE FROM FeeManagement WHERE FeeID = @FeeID";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@FeeID", guna2TextBoxFeeIDFee.Text);

                connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Fee removed successfully!", "Success");

                ClearInputs();
                LoadFees();


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing Fee : " + ex.Message, "Error");
            }
        }

        // Clear input fields
        private void guna2ButtonClearDataFee_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        private void ClearInputs()
        {
            // Clear the TextBoxes
            guna2TextBoxSearchEnrollmentIDFee.Clear();
            guna2TextBoxFeeIDFee.Clear();
            guna2TextBoxStudentIDFee.Clear();
            guna2TextBoxStudentNameFee.Clear();
            guna2TextBoxCourseIDFee.Clear();
            guna2TextBoxCourseNameFee.Clear();
            guna2TextBoxTotalFeeFee.Clear();
            guna2TextBoxAmountPaidFee.Clear();
            guna2TextBoxRemBalanceFee.Clear();
            guna2TextBoxNoteFee.Clear();

            // Reset ComboBox
            guna2ComboBoxStatusFee.SelectedIndex = -1;

            // Reset DateTimePicker
            guna2DateTimePickerPaymentDateFee.Value = DateTime.Now;

            GetLatestFeeID();
            SetButtonVisibility(true, false);
        }


// Load data into the DataGridView
        private void LoadFees()
        {
            try
            {
                string query = "SELECT FeeID, EnrollmentID, StudentID, Status, RemBalance FROM FeeManagement ORDER BY FeeID DESC";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                guna2DataGridViewDetailsBoxFee.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Fees : " + ex.Message, "Error");
            }
        }

        private void guna2ButtonSearchFeeIDFee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBoxSearchFeeIDFee.Text))
            {
                LoadFees();
            }
            else
            {
                SearchFee();
            }
        }

        private void SearchFee()
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                string query = "SELECT * FROM FeeManagement WHERE FeeID = @FeeID";

                connection = new SqlConnection(connectionString);
                cmd = new SqlCommand(query, connection);

                guna2TextBoxFeeIDFee.Text = guna2TextBoxSearchFeeIDFee.Text;
                cmd.Parameters.AddWithValue("@FeeID", guna2TextBoxSearchFeeIDFee.Text);

                connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Populate the fields with the values from the database
                    guna2TextBoxSearchEnrollmentIDFee.Text = reader["EnrollmentID"].ToString();
                    guna2TextBoxStudentIDFee.Text = reader["StudentID"].ToString();
                    guna2TextBoxStudentNameFee.Text = reader["StudentName"].ToString();
                    guna2TextBoxCourseIDFee.Text = reader["CourseID"].ToString();
                    guna2TextBoxCourseNameFee.Text = reader["CourseName"].ToString();
                    guna2DateTimePickerPaymentDateFee.Value = Convert.ToDateTime(reader["PaymentDate"]);
                    guna2TextBoxTotalFeeFee.Text = reader["TotalFee"].ToString();
                    guna2ComboBoxStatusFee.SelectedItem = reader["Status"].ToString();
                    guna2TextBoxAmountPaidFee.Text = reader["AmountPaid"].ToString();
                    guna2TextBoxRemBalanceFee.Text = reader["RemBalance"].ToString();
                    guna2TextBoxNoteFee.Text = reader["Note"].ToString();

                    SetButtonVisibility(false, true); 
                }
                else
                {
                    MessageBox.Show("Fee ID not found!", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching for the Fee : " + ex.Message, "Error");
            }
            finally
            {
                reader.Close();
                connection.Close();
            }
        }



    }
}
