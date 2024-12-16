namespace SMS.Reports
{
    partial class StudentPrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentPrintForm));
            this.crystalReportViewerStudent = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerStudent
            // 
            this.crystalReportViewerStudent.ActiveViewIndex = -1;
            this.crystalReportViewerStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerStudent.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerStudent.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerStudent.Name = "crystalReportViewerStudent";
            this.crystalReportViewerStudent.Size = new System.Drawing.Size(1004, 725);
            this.crystalReportViewerStudent.TabIndex = 0;
            this.crystalReportViewerStudent.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // StudentPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 725);
            this.Controls.Add(this.crystalReportViewerStudent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StudentPrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Print Form";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerStudent;
    }
}