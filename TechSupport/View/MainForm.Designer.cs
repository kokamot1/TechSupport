namespace TechSupport
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incidentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayOpenIncidentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewIncidentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateIncidentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewOpenIncidentsByTechnicianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.incidentsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1091, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // incidentsToolStripMenuItem
            // 
            this.incidentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayOpenIncidentsToolStripMenuItem,
            this.addNewIncidentToolStripMenuItem,
            this.updateIncidentToolStripMenuItem,
            this.viewOpenIncidentsByTechnicianToolStripMenuItem});
            this.incidentsToolStripMenuItem.Name = "incidentsToolStripMenuItem";
            this.incidentsToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.incidentsToolStripMenuItem.Text = "Incidents";
            // 
            // displayOpenIncidentsToolStripMenuItem
            // 
            this.displayOpenIncidentsToolStripMenuItem.Name = "displayOpenIncidentsToolStripMenuItem";
            this.displayOpenIncidentsToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.displayOpenIncidentsToolStripMenuItem.Text = "Display Open Incidents";
            this.displayOpenIncidentsToolStripMenuItem.Click += new System.EventHandler(this.displayOpenIncidentsToolStripMenuItem_Click);
            // 
            // addNewIncidentToolStripMenuItem
            // 
            this.addNewIncidentToolStripMenuItem.Name = "addNewIncidentToolStripMenuItem";
            this.addNewIncidentToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.addNewIncidentToolStripMenuItem.Text = "Add New Incident";
            this.addNewIncidentToolStripMenuItem.Click += new System.EventHandler(this.addNewIncidentToolStripMenuItem_Click);
            // 
            // updateIncidentToolStripMenuItem
            // 
            this.updateIncidentToolStripMenuItem.Name = "updateIncidentToolStripMenuItem";
            this.updateIncidentToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.updateIncidentToolStripMenuItem.Text = "Update Incident";
            this.updateIncidentToolStripMenuItem.Click += new System.EventHandler(this.updateIncidentToolStripMenuItem_Click);
            // 
            // viewOpenIncidentsByTechnicianToolStripMenuItem
            // 
            this.viewOpenIncidentsByTechnicianToolStripMenuItem.Name = "viewOpenIncidentsByTechnicianToolStripMenuItem";
            this.viewOpenIncidentsByTechnicianToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.viewOpenIncidentsByTechnicianToolStripMenuItem.Text = "View Open Incidents By Technician";
            this.viewOpenIncidentsByTechnicianToolStripMenuItem.Click += new System.EventHandler(this.viewOpenIncidentsByTechnicianToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 709);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incidentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayOpenIncidentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewIncidentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateIncidentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewOpenIncidentsByTechnicianToolStripMenuItem;
    }
}