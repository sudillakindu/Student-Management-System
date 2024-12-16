using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class LoginForm : Form
    {

        //Fields
        private int borderRadius = 20;
        private int borderSize = 7;
        private Color borderColor = Color.FromArgb(3, 136, 242);

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void FormLoginPanel_MouseDown(object sender, MouseEventArgs e)
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

        //Add Border Colour
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the rounded border
            using (GraphicsPath path = new GraphicsPath())
            using (Pen borderPen = new Pen(borderColor, borderSize))
            {
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                path.AddArc(this.Width - 22, 0, borderRadius, borderRadius, 270, 90);
                path.AddArc(this.Width - 22, this.Height - 22, borderRadius, borderRadius, 0, 90);
                path.AddArc(0, this.Height - 22, borderRadius, borderRadius, 90, 90);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(borderPen, path);
            }
        }

        public LoginForm()
        {
            InitializeComponent();
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, borderRadius, borderRadius));
        }

        private void guna2ImageButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ImageButtonFacebook_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://web.facebook.com/sudilmallikaarachchi/",
                UseShellExecute = true
            });
        }

        private void guna2ImageButtonInstagram_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.instagram.com/sudillakindu/",
                UseShellExecute = true
            });
        }

        private void guna2ImageButtonWhatsapp_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://web.whatsapp.com/",
                UseShellExecute = true
            });
        }

        private void Guna2ButtonSignUp_Click(object sender, EventArgs e)
        {
            string username = guna2UsernameTextBox.Text;
            string password = guna2PasswordTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                guna2UsernameTextBox.BorderColor = Color.FromArgb(0, 0, 0);
                guna2PasswordTextBox.BorderColor = Color.FromArgb(0, 0, 0);
                MessageBox.Show("Username or password cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2UsernameTextBox.BorderColor = Color.FromArgb(0, 136, 242);
                guna2PasswordTextBox.BorderColor = Color.FromArgb(0, 136, 242);
            }
            else if ((username == "sudil" && password == "sudil") || (username == "deerga" && password == "deerga") || (username == "prathibha" && password == "prathibha"))
            {
                guna2UsernameTextBox.BorderColor = Color.FromArgb(0, 136, 242);
                guna2PasswordTextBox.BorderColor = Color.FromArgb(0, 136, 242);
                MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Open the FormDashboard and hide the login form
                MainForm dashboardForm = new MainForm(username);
                this.Hide();
                dashboardForm.ShowDialog();
                this.Close();
            }
            else
            {
                guna2UsernameTextBox.BorderColor = Color.FromArgb(255, 0, 0);
                guna2PasswordTextBox.BorderColor = Color.FromArgb(255, 0, 0);
                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2UsernameTextBox.BorderColor = Color.FromArgb(0, 136, 242);
                guna2PasswordTextBox.BorderColor = Color.FromArgb(0, 136, 242);
            }

            // Clear the input fields
            guna2UsernameTextBox.Text = "";
            guna2PasswordTextBox.Text = "";
        }












    }
}
