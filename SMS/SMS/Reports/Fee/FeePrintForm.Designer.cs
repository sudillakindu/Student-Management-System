namespace SMS.Reports
{
    partial class FeePrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeePrintForm));
            this.crystalReportViewerFee = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewerFee
            // 
            this.crystalReportViewerFee.ActiveViewIndex = -1;
            this.crystalReportViewerFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerFee.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerFee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerFee.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerFee.Name = "crystalReportViewerFee";
            this.crystalReportViewerFee.Size = new System.Drawing.Size(1004, 725);
            this.crystalReportViewerFee.TabIndex = 0;
            this.crystalReportViewerFee.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FeePrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 725);
            this.Controls.Add(this.crystalReportViewerFee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FeePrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fee Print Form";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerFee;
    }
}