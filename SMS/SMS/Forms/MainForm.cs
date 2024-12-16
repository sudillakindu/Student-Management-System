using SMS.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class MainForm : Form
    {

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void guna2CirclePictureBoxMainDragForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Add Border
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );


        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2HtmlLabelDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            guna2HtmlLabelTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private string username;

        public MainForm(string username)
        {
            InitializeComponent();
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 65, 65));

            timer1.Interval = 1000;  // 1 second interval
            timer1.Start();

            guna2HtmlLabelDate.Text = DateTime.Now.ToString("yyyy-MM-dd");                            
            guna2HtmlLabelTime.Text = DateTime.Now.ToString("HH:mm:ss");

            this.username = username;

            // Set the label text to display the username
            guna2HtmlLabelMainFormUsername.Text = "Hi, " + username + "!";  // Update this to match your label name in FormDashboard
        }

        private void guna2ButtonLogOut_Click(object sender, EventArgs e)
        {
            LoginForm loginPanelForm = new LoginForm();
            this.Hide();
            loginPanelForm.ShowDialog();
            this.Close();
        }

        private void LoadControl(UserControl control)
        {
            // Clear any existing controls in the panel
            guna2PanelContentPanel.Controls.Clear();

            // Dock the user control to fill the panel
            control.Dock = DockStyle.Fill;

            // Add the control to the panel
            guna2PanelContentPanel.Controls.Add(control);
        }


        private void guna2ButtonDashboardControl_Click(object sender, EventArgs e)
        {
            LoadControl(new f());
        }

        private void guna2ButtonStudentRegistrationControl_Click(object sender, EventArgs e)
        {
            LoadControl(new StudentRegistrationControl());
        }

        private void guna2ButtonCourseManagementControl_Click(object sender, EventArgs e)
        {
            LoadControl(new CourseManagementControl());
        }

        private void guna2ButtonFeeManagementControl_Click(object sender, EventArgs e)
        {
            LoadControl(new FeeManagementControl());
        }

        private void guna2ButtonAttendanceControl_Click(object sender, EventArgs e)
        {
            LoadControl(new AttendanceControl());
        }

        private void guna2ButtonReportControl_Click(object sender, EventArgs e)
        {
            LoadControl(new ReportControl());
        }
    }
}
