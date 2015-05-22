using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIMS
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetDemo.user_mst' table. You can move, or remove it, as needed.
            this.user_mstTableAdapter.Fill(this.dataSetDemo.user_mst);

            this.reportViewer1.RefreshReport();
        }
    }
}
