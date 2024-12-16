namespace SMS.Reports
{
    partial class AttendancePrintForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendancePrintForm));
            this.crystalReportViewerAttendance = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerAttendance
            // 
            this.crystalReportViewerAttendance.ActiveViewIndex = -1;
            this.crystalReportViewerAttendance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerAttendance.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerAttendance.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerAttendance.Name = "crystalReportViewerAttendance";
            this.crystalReportViewerAttendance.Size = new System.Drawing.Size(1004, 725);
            this.crystalReportViewerAttendance.TabIndex = 0;
            this.crystalReportViewerAttendance.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // AttendancePrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 725);
            this.Controls.Add(this.crystalReportViewerAttendance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AttendancePrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance Print Form";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerAttendance;
    }
}