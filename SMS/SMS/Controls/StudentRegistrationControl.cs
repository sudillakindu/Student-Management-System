using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SMS.Controls
{
    public partial class StudentRegistrationControl : UserControl
    {

        public StudentRegistrationControl()
        {
            InitializeComponent();

            guna2DateTimePickerDOBRe.Value = DateTime.Now; // Reset to current date
            guna2TextBoxAgeRe.Text = null;

            InitializeDatabase();
            GetLatestStudentID();

            Visible_Guna2ButtonAddStudent(true);
            Visible_Guna2ButtonUpdateStudent_Guna2ButtonRemoveStudent(false);
            LoadStudents();
        }

        private string connectionString;
        private SqlConnection connection;
        //private SqlCommand cmd;
        private void InitializeDatabase()
        {
            connectionString = "Data Source=DESKTOP;Initial Catalog=StudentManagementSystem;Integrated Security=True;";
            connection = new SqlConnection(connectionString);
        }

        private void GetLatestStudentID()
        {
            string query = "SELECT TOP 1 StudentID FROM Student ORDER BY StudentID DESC";
            string latestStudentID;

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Close();

                connection.Open();

                latestStudentID = cmd.ExecuteScalar()?.ToString();

                if (string.IsNullOrEmpty(latestStudentID))
                {
                    latestStudentID = "S0001"; // Example: Start with ID S0001
                }
                else
                {
                    // Extract the numeric part of the ID, increment it, and add the prefix
                    int numericPart = int.Parse(latestStudentID.Substring(1));
                    latestStudentID = "S" + (numericPart + 1).ToString("D4");
                }

                // Set the generated ID in the TextBox
                guna2TextBoxStudentIDRe.Text = latestStudentID;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching latest Student ID : " + ex.Message, "Error");
            }
        }

        private void LoadStudents()
        {
            try
            {
                string query = "SELECT StudentID, Name, Email FROM Student ORDER BY StudentID DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                guna2DataGridViewDetailsBoxRe.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void guna2DateTimePickerDOB_ValueChanged(object sender, EventArgs e)
        {

            DateTime dob = guna2DateTimePickerDOBRe.Value; // Get the selected DOB
            DateTime today = DateTime.Today; // Get the current date

            // Calculate age
            int age = today.Year - dob.Year;
            if (dob > today.AddYears(-age)) age--; // Adjust if the birthday hasn't occurred this year

            // Display age
            guna2TextBoxAgeRe.Text = age.ToString();

        }

        private void Visible_Guna2ButtonAddStudent(Boolean visibleButton)
        {
            guna2ButtonAddStudent.Visible = visibleButton;
        }

        private void Visible_Guna2ButtonUpdateStudent_Guna2ButtonRemoveStudent(Boolean visibleButton)
        {
            guna2ButtonUpdateStudent.Visible = visibleButton;
            guna2ButtonRemoveStudent.Visible = visibleButton;
        }

        private bool ValidateStudentInputs() 
        {
            // Validate Student ID
            if (string.IsNullOrWhiteSpace(guna2TextBoxStudentIDRe.Text))
            {
                MessageBox.Show("Student ID cannot be empty.", "Input Error");
                return false;
            }

            // Validate Name
            if (string.IsNullOrWhiteSpace(guna2TextBoxNameRe.Text))
            {
                MessageBox.Show("Name cannot be empty.", "Input Error");
                return false;
            }

            // Validate DOB
            if (guna2DateTimePickerDOBRe.Value > DateTime.Now)
            {
                MessageBox.Show("DOB cannot be in the future.", "Input Error");
                return false;
            }

            // Validate Age (between 15 and 52)
            if (int.TryParse(guna2TextBoxAgeRe.Text, out int age))
            {
                if (age <= 15 || age >= 52)
                {
                    MessageBox.Show("Age must be between 15 and 52.", "Input Error");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid age.", "Input Error");
                return false;
            }

            // Validate NIC
            if (string.IsNullOrWhiteSpace(guna2TextBoxNICRe.Text))
            {
                MessageBox.Show("NIC cannot be empty.", "Input Error");
                return false;
            }

            // Validate Email (simple check for '@' symbol)
            if (string.IsNullOrWhiteSpace(guna2TextBoxEmailRe.Text) || !guna2TextBoxEmailRe.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address.", "Input Error");
                return false;
            }

            // Validate Phone Number
            if (string.IsNullOrWhiteSpace(guna2TextBoxPhoneNumberRe.Text) || guna2TextBoxPhoneNumberRe.Text.Length != 10)
            {
                MessageBox.Show("Please enter a valid 10-digit phone number.", "Input Error");
                return false;
            }

            // Validate Address
            if (string.IsNullOrWhiteSpace(guna2TextBoxAddressRe.Text))
            {
                MessageBox.Show("Address cannot be empty.", "Input Error");
                return false;
            }

            // Validate Gender (either Male or Female should be selected)
            if (!guna2RadioButtonMale.Checked && !guna2RadioButtonFemale.Checked)
            {
                MessageBox.Show("Please select a gender.", "Input Error");
                return false;
            }

            // Validate Status
            if (string.IsNullOrWhiteSpace(guna2ComboBoxStatusRe.Text))
            {
                MessageBox.Show("Please select a status.", "Input Error");
                return false;
            }

            return true;
        }

        private void guna2ButtonUploadImage_Click(object sender, EventArgs e)
        {
            // Open File Dialog to select an image
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";
            openFileDialog.Title = "Select a Student Picture";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Display the selected image in the PictureBox
                guna2PictureBoxStudentImage.Image = new Bitmap(openFileDialog.FileName);
                guna2PictureBoxStudentImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void guna2ButtonSearchRe_Click(object sender, EventArgs e)
        {
            string searchStudentID = guna2TextBoxSearchStudentIDRe.Text;

            if (!string.IsNullOrWhiteSpace(searchStudentID))
            {
                 
                MessageBox.Show($"Searching for : {searchStudentID}", "Searching");
                //guna2TextBoxStudentIDRe.Text = searchStudentID;
                SearchStudent(searchStudentID);

            }
            else
            {
                MessageBox.Show("Please enter a value to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void SearchStudent(string searchStudentID)
        {
            try
            {
                string query = "SELECT * FROM Student WHERE StudentID = @StudentID";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StudentID", searchStudentID);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    guna2TextBoxStudentIDRe.Text = reader["StudentID"].ToString();
                    guna2TextBoxNameRe.Text = reader["Name"].ToString();
                    guna2DateTimePickerDOBRe.Value = Convert.ToDateTime(reader["DOB"]);
                    //guna2TextBoxAgeRe.Text = reader["Age"].ToString();
                    guna2TextBoxNICRe.Text = reader["NIC"].ToString();
                    guna2TextBoxEmailRe.Text = reader["Email"].ToString();
                    guna2TextBoxPhoneNumberRe.Text = reader["PhoneNumber"].ToString();
                    guna2TextBoxAddressRe.Text = reader["Address"].ToString();

                    //Select gender (Male/Female)
                    if (reader["Gender"].ToString() == "Male")
                    {
                        guna2RadioButtonMale.Checked = true;  
                        guna2RadioButtonFemale.Checked = false;
                    }
                    else if (reader["Gender"].ToString() == "Female")
                    {
                        guna2RadioButtonMale.Checked = false;
                        guna2RadioButtonFemale.Checked = true;
                    }

                    //Select student image
                    if (reader["StudentPicture"] != DBNull.Value)
                    {
                        byte[] imgBytes = (byte[])reader["StudentPicture"];
                        using (MemoryStream ms = new MemoryStream(imgBytes))
                        {
                            guna2PictureBoxStudentImage.Image = Image.FromStream(ms);
                            guna2PictureBoxStudentImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    else
                    {
                        guna2PictureBoxStudentImage.Image = null;
                    }

                    guna2ComboBoxStatusRe.Text = reader["Status"].ToString();

                    Visible_Guna2ButtonAddStudent(false);
                    Visible_Guna2ButtonUpdateStudent_Guna2ButtonRemoveStudent(true);
                }
                else
                {
                    MessageBox.Show("Student not found!", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
            finally
            {
                connection.Close();
            }
        }

        private void guna2ButtonAddStudent_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void AddStudent()
        {
            // Check if inputs are valid before proceeding
            if (!ValidateStudentInputs())
                return;

            try
            {
                string query = "INSERT INTO Student (StudentID, Name, DOB, Age, NIC, Email, PhoneNumber, Address, Gender, Status, StudentPicture) " +
                               "VALUES (@StudentID, @Name, @DOB, @Age, @NIC, @Email, @PhoneNumber, @Address, @Gender, @Status, @StudentPicture)";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@StudentID", guna2TextBoxStudentIDRe.Text);
                cmd.Parameters.AddWithValue("@Name", guna2TextBoxNameRe.Text);
                cmd.Parameters.AddWithValue("@DOB", guna2DateTimePickerDOBRe.Value.Date); // Only add date
                cmd.Parameters.AddWithValue("@Age", guna2TextBoxAgeRe.Text);
                cmd.Parameters.AddWithValue("@NIC", guna2TextBoxNICRe.Text);
                cmd.Parameters.AddWithValue("@Email", guna2TextBoxEmailRe.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", guna2TextBoxPhoneNumberRe.Text);
                cmd.Parameters.AddWithValue("@Address", guna2TextBoxAddressRe.Text);

                // Adding the selected gender (Male/Female)
                if (guna2RadioButtonMale.Checked)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Male");
                }
                else if (guna2RadioButtonFemale.Checked)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Female");
                }

                // Convert Image to Byte Array to save in the database
                if (guna2PictureBoxStudentImage.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    guna2PictureBoxStudentImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    cmd.Parameters.AddWithValue("@StudentPicture", ms.ToArray());
                }
                else
                {
                    // If no image is selected, you can either leave it NULL or set a default image
                    cmd.Parameters.AddWithValue("@StudentPicture", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@Status", guna2ComboBoxStatusRe.Text);

                connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Student added successfully!", "Successful");

                ClearDataRe();
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
            finally
            {
                connection.Close();
            }
        }

        private void guna2ButtonUpdateStudent_Click(object sender, EventArgs e)
        {
            UpdateStudent();
        }

        private void UpdateStudent()
        {
            // Check if inputs are valid before proceeding
            if (!ValidateStudentInputs())
                return;

            try
            {
                string query = "UPDATE Student SET Name = @Name, DOB = @DOB, Age = @Age, NIC = @NIC, Email = @Email, " +
                               "PhoneNumber = @PhoneNumber, Address = @Address, Gender = @Gender, Status = @Status, " +
                               "StudentPicture = @StudentPicture " +
                               "WHERE StudentID = @StudentID";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@StudentID", guna2TextBoxStudentIDRe.Text);
                cmd.Parameters.AddWithValue("@Name", guna2TextBoxNameRe.Text);
                cmd.Parameters.AddWithValue("@DOB", guna2DateTimePickerDOBRe.Value);
                cmd.Parameters.AddWithValue("@Age", guna2TextBoxAgeRe.Text);
                cmd.Parameters.AddWithValue("@NIC", guna2TextBoxNICRe.Text);
                cmd.Parameters.AddWithValue("@Email", guna2TextBoxEmailRe.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", guna2TextBoxPhoneNumberRe.Text);
                cmd.Parameters.AddWithValue("@Address", guna2TextBoxAddressRe.Text);

                // Adding the selected gender (Male/Female)
                if (guna2RadioButtonMale.Checked)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Male");
                }
                else if (guna2RadioButtonFemale.Checked)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Female");
                }

                cmd.Parameters.AddWithValue("@Status", guna2ComboBoxStatusRe.Text);

                // Convert the image to a byte array and add it to the query
                if (guna2PictureBoxStudentImage.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        guna2PictureBoxStudentImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        cmd.Parameters.AddWithValue("@StudentPicture", ms.ToArray());
                    }
                }
                else
                {
                    // If no new image is selected, you can either leave the picture unchanged (set as null) or set a default picture
                    cmd.Parameters.AddWithValue("@StudentPicture", DBNull.Value);
                }

                connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Student updated successfully!", "Successful");

                LoadStudents();
                Visible_Guna2ButtonAddStudent(true);
                Visible_Guna2ButtonUpdateStudent_Guna2ButtonRemoveStudent(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
            finally
            {
                connection.Close();
            }
        }

        private void guna2ButtonRemoveStudent_Click(object sender, EventArgs e)
        {
            RemoveStudent();
        }

        private void RemoveStudent()
        {
            try
            {
                string query = "DELETE FROM Student WHERE StudentID = @StudentID";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@StudentID", guna2TextBoxStudentIDRe.Text);

                connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Student deleted successfully!", "Successful");

                ClearDataRe();
                LoadStudents();
                Visible_Guna2ButtonAddStudent(true);
                Visible_Guna2ButtonUpdateStudent_Guna2ButtonRemoveStudent(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
            finally
            {
                connection.Close();
            }
        }

        private void guna2ButtonClearDataRe_Click(object sender, EventArgs e)
        {
            ClearDataRe();
            Visible_Guna2ButtonAddStudent(true);
            Visible_Guna2ButtonUpdateStudent_Guna2ButtonRemoveStudent(false);
        }

        private void ClearDataRe()
        {
            guna2TextBoxSearchStudentIDRe.Text = "";
            guna2TextBoxStudentIDRe.Text = "";
            guna2TextBoxNameRe.Text = "";
            guna2DateTimePickerDOBRe.Value = DateTime.Now;
            guna2TextBoxAgeRe.Text = "";
            guna2TextBoxNICRe.Text = "";
            guna2TextBoxEmailRe.Text = "";
            guna2TextBoxPhoneNumberRe.Text = "";
            guna2TextBoxAddressRe.Text = "";
            //guna2TextBoxBranchIDRe.Text = "";
            guna2ComboBoxStatusRe.SelectedIndex = -1;
            guna2PictureBoxStudentImage.Image = null;

            guna2RadioButtonMale.Checked = false;
            guna2RadioButtonFemale.Checked = false;

            GetLatestStudentID();
        }

    }
}
