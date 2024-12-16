using SMS.Reports;
using SMS.Reports.Attendance;
using SMS.Reports.Fee;
using SMS.Reports.Student;
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
    public partial class ReportControl : UserControl
    {
        public ReportControl()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=DESKTOP;Initial Catalog=StudentManagementSystem;Integrated Security=True;";

        private void ReportControl_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadFees();
            LoadAttendance();
        }

        private void guna2ButtonStudentRegistrationReport_Click(object sender, EventArgs e)
        {
            StudentPrintForm spf = new StudentPrintForm();
            spf.Show();

            try
            {
                string query = "SELECT * FROM Student ORDER BY StudentID DESC";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                connection.Open();

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Student");

                StudentCrystalReport scr = new StudentCrystalReport();
                scr.SetDataSource(dataSet);

                spf.crystalReportViewerStudent.ReportSource = scr;
                spf.crystalReportViewerStudent.Refresh();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + ex.Message, "Error");
            }
        }

        private void guna2ButtonFeeManagementReport_Click(object sender, EventArgs e)
        {
            FeePrintForm fpf = new FeePrintForm();
            fpf.Show();

            try
            {
                string query = "SELECT * FROM FeeManagement ORDER BY FeeID DESC";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                connection.Open();

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Attendance");

                FeeCrystalReport fcr = new FeeCrystalReport();
                fcr.SetDataSource(dataSet);

                fpf.crystalReportViewerFee.ReportSource = fcr;
                fpf.crystalReportViewerFee.Refresh();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + ex.Message, "Error");
            }
        }

        private void guna2ButtonStudentAttendanceReport_Click(object sender, EventArgs e)
        {
            AttendancePrintForm apf = new AttendancePrintForm();
            apf.Show();

            try
            {
                string query = "SELECT * FROM Attendance ORDER BY AttendanceDate DESC";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                connection.Open();
               
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Attendance");

                AttendanceCrystalReport acr = new AttendanceCrystalReport();
                acr.SetDataSource(dataSet);

                apf.crystalReportViewerAttendance.ReportSource = acr;
                apf.crystalReportViewerAttendance.Refresh();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : " + ex.Message, "Error");
            }           
        }

        private void LoadStudents()
        {
            try
            {
                string query = "SELECT * FROM Student ORDER BY StudentID DESC";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                guna2DataGridViewStudentRegistrationReport.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Students : " + ex.Message, "Error");
            }
        }

        private void LoadFees()
        {
            try
            {
                string query = "SELECT * FROM FeeManagement ORDER BY FeeID DESC";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                guna2DataGridViewFeeManagementReport.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Fees : " + ex.Message, "Error");
            }
        }

        private void LoadAttendance()
        {
            try
            {
                string query = "SELECT * FROM Attendance ORDER BY AttendanceDate DESC";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                guna2DataGridViewStudentAttendanceReport.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Attendances : " + ex.Message, "Error");
            }
        }

    }
}
