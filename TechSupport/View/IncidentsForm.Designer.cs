namespace TechSupport
{
    partial class IncidentsForm
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
            this.IncidentsListView = new System.Windows.Forms.ListView();
            this.ProductCodeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateOpenedCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CustomerCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TechnicianCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TitleCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // IncidentsListView
            // 
            this.IncidentsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProductCodeCol,
            this.DateOpenedCol,
            this.CustomerCol,
            this.TechnicianCol,
            this.TitleCol});
            this.IncidentsListView.Location = new System.Drawing.Point(0, 0);
            this.IncidentsListView.Name = "IncidentsListView";
            this.IncidentsListView.Size = new System.Drawing.Size(880, 581);
            this.IncidentsListView.TabIndex = 0;
            this.IncidentsListView.UseCompatibleStateImageBehavior = false;
            this.IncidentsListView.View = System.Windows.Forms.View.Details;
            // 
            // ProductCodeCol
            // 
            this.ProductCodeCol.Text = "Product Code";
            this.ProductCodeCol.Width = 116;
            // 
            // DateOpenedCol
            // 
            this.DateOpenedCol.Text = "Date Opened";
            this.DateOpenedCol.Width = 116;
            // 
            // CustomerCol
            // 
            this.CustomerCol.Text = "Customer";
            this.CustomerCol.Width = 160;
            // 
            // TechnicianCol
            // 
            this.TechnicianCol.Text = "Technician";
            this.TechnicianCol.Width = 160;
            // 
            // TitleCol
            // 
            this.TitleCol.Text = "Title";
            this.TitleCol.Width = 291;
            // 
            // IncidentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 581);
            this.Controls.Add(this.IncidentsListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "IncidentsForm";
            this.Text = "Open Incidents";
            this.Load += new System.EventHandler(this.IncidentsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView IncidentsListView;
        private System.Windows.Forms.ColumnHeader ProductCodeCol;
        private System.Windows.Forms.ColumnHeader DateOpenedCol;
        private System.Windows.Forms.ColumnHeader CustomerCol;
        private System.Windows.Forms.ColumnHeader TechnicianCol;
        private System.Windows.Forms.ColumnHeader TitleCol;

    }
}