namespace HIMS
{
    partial class ReportForm
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
            this.dataSetDemo = new HIMS.XSD.DataSetDemo();
            this.dataSetDemoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usermstBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.user_mstTableAdapter = new HIMS.XSD.DataSetDemoTableAdapters.user_mstTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDemoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usermstBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.usermstBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HIMS.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(730, 457);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetDemo
            // 
            this.dataSetDemo.DataSetName = "DataSetDemo";
            this.dataSetDemo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetDemoBindingSource
            // 
            this.dataSetDemoBindingSource.DataSource = this.dataSetDemo;
            this.dataSetDemoBindingSource.Position = 0;
            // 
            // usermstBindingSource
            // 
            this.usermstBindingSource.DataMember = "user_mst";
            this.usermstBindingSource.DataSource = this.dataSetDemoBindingSource;
            // 
            // user_mstTableAdapter
            // 
            this.user_mstTableAdapter.ClearBeforeFill = true;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 457);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDemoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usermstBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private XSD.DataSetDemo dataSetDemo;
        private System.Windows.Forms.BindingSource dataSetDemoBindingSource;
        private System.Windows.Forms.BindingSource usermstBindingSource;
        private XSD.DataSetDemoTableAdapters.user_mstTableAdapter user_mstTableAdapter;
    }
}