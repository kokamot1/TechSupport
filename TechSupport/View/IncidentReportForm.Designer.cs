namespace TechSupport
{
    partial class IncidentReportForm
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet1 = new TechSupport.DataSet1();
            this.openIncidentsAssignedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openIncidentsAssignedTableAdapter = new TechSupport.DataSet1TableAdapters.OpenIncidentsAssignedTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openIncidentsAssignedBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "OpenIncidentsAssigned";
            reportDataSource1.Value = this.openIncidentsAssignedBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TechSupport.View.IncidentsAssignedReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(888, 441);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // openIncidentsAssignedBindingSource
            // 
            this.openIncidentsAssignedBindingSource.DataMember = "OpenIncidentsAssigned";
            this.openIncidentsAssignedBindingSource.DataSource = this.dataSet1;
            // 
            // openIncidentsAssignedTableAdapter
            // 
            this.openIncidentsAssignedTableAdapter.ClearBeforeFill = true;
            // 
            // IncidentReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 441);
            this.Controls.Add(this.reportViewer1);
            this.Name = "IncidentReportForm";
            this.Text = "Open Incidents Assigned to Technicians";
            this.Load += new System.EventHandler(this.IncidentReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openIncidentsAssignedBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource openIncidentsAssignedBindingSource;
        private DataSet1TableAdapters.OpenIncidentsAssignedTableAdapter openIncidentsAssignedTableAdapter;
    }
}