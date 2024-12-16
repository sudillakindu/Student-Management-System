using LiveCharts.Wpf;
using LiveCharts;
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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LiveCharts.Defaults;
using SeriesCollection = LiveCharts.SeriesCollection;
using Axis = LiveCharts.Wpf.Axis;

namespace SMS.Controls
{
    public partial class f : UserControl
    {
        public f()
        {
            InitializeComponent();

            InitializeDatabase();

            GetTotalStudentCount();
            GetTotalTeacherCount();
            GetTotalCourseCount();

            LoadGenderPieChart();
            LoadStatusPieChart();
            LoadPaymentPieChart();

            LoadChartData();
        }

        private string connectionString;
        private SqlConnection connection;
        //private SqlCommand cmd;
        private void InitializeDatabase()
        {
            connectionString = "Data Source=DESKTOP;Initial Catalog=StudentManagementSystem;Integrated Security=True;";
            connection = new SqlConnection(connectionString);
        }



        private void GetTotalStudentCount()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Student";

                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                guna2HtmlLabelTotalStudents.Text = cmd.ExecuteScalar().ToString();

                connection.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}", "Error");
            }
        }



        private void GetTotalTeacherCount()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Instructor";

                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                guna2HtmlLabelTotalTeachers.Text = cmd.ExecuteScalar().ToString();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}", "Error");
            }
        }



        private void GetTotalCourseCount()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Course";

                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                guna2HtmlLabelTotalCourses.Text = cmd.ExecuteScalar().ToString();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}", "Error");
            }
        }



        private void LoadGenderPieChart()
        {
            try
            {
                string query = "SELECT Gender, COUNT(*) AS Count FROM Student GROUP BY Gender";
              
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                pieChartGender.Series.Clear();
                while (reader.Read())
                {
                    var gender = reader["Gender"]?.ToString() ?? "Unknown";
                    var count = reader["Count"] as int? ?? 0;

                    pieChartGender.Series.Add(new PieSeries
                    {
                        Title = gender,
                        Values = new ChartValues<int> { count },
                        DataLabels = true
                    });
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Error : " + ex.Message, "Error");
            }
            finally
            {
                connection.Close();
            }
        }



        private void LoadStatusPieChart()
        {
            try
            {
                string query = "SELECT Status, COUNT(*) AS Count FROM Student GROUP BY Status";

                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                pieChartStatus.Series.Clear();
                while (reader.Read())
                {
                    var status = reader["Status"]?.ToString() ?? "Unknown";
                    var count = reader["Count"] as int? ?? 0;

                    pieChartStatus.Series.Add(new PieSeries
                    {
                        Title = status,
                        Values = new ChartValues<int> { count },
                        DataLabels = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error");
            }
            finally
            {
                connection.Close();
            }
        }



        private void LoadPaymentPieChart()
        {
            try
            {
                string query = "SELECT Status, COUNT(*) AS Count FROM FeeManagement GROUP BY Status";

                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                pieChartPayment.Series.Clear();
                while (reader.Read())
                {
                    var gender = reader["Status"]?.ToString() ?? "Unknown";
                    var count = reader["Count"] as int? ?? 0;

                    pieChartPayment.Series.Add(new PieSeries
                    {
                        Title = gender,
                        Values = new ChartValues<int> { count },
                        DataLabels = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error");
            }
            finally
            {
                connection.Close();
            }
        }



        private void LoadChartData() 
        {
            //Create a list to store RegisterDate and StudentCount
            var enrollmentData = new List<DateTimePoint>();

            //Fetch data from the database
            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"
                    SELECT TOP 50 CAST(RegisterDate AS DATE) AS RegisterDate, COUNT(*) AS StudentCount
                    FROM Student
                    GROUP BY CAST(RegisterDate AS DATE)
                    ORDER BY RegisterDate DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                enrollmentData.Add(new DateTimePoint(
                    reader.GetDateTime(0),   // X-axis: RegisterDate
                    reader.GetInt32(1)      // Y-axis: Count of Students
                ));
            }

            //Reverse data to display oldest date first
            enrollmentData.Reverse();

            //Prepare chart values
            var chartValues = new ChartValues<DateTimePoint>(enrollmentData);

            //Configure the line chart
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Student Count by Enrollment Date",
                    Values = chartValues,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8
                }
            };

            //Configure the X-axis for dates
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Enrollment Date",
                LabelFormatter = value => new DateTime((long)value).ToString("MMM dd, yyyy"), // Format dates
            });

            //Configure the Y-axis for student count
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Student Count",
                LabelFormatter = value => (value).ToString() // Format as numeric
            });

            connection.Close();
        }





































    }
}
