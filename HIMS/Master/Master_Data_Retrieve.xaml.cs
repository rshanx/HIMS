using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Data;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;

namespace HIMS.Master
{
    /// <summary>
    /// Interaction logic for Master_Data_Retrieve.xaml
    /// </summary>
    public partial class Master_Data_Retrieve : Window
    {
        
        public Master_Data_Retrieve()
        {
            InitializeComponent();
            DataTable dt= BLL.General_Utilities.GetTables();
            combotbl.ItemsSource = dt.DefaultView;
            //combotbl.SelectedItem = "TABLE_NAME";
            //combotbl.SelectedValue = "TABLE_NAME";
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
        }

        private void combotbl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable dt1 = BLL.General_Utilities.GetColumns(combotbl.SelectedValue.ToString());
            
            combocol.ItemsSource = dt1.DefaultView;
            //combocol.SelectedItem = "COLUMN_NAME";
            //combocol.SelectedValue = "COLUMN_NAME";
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIMS.Properties.Settings.HIMSConnectionString"].ConnectionString);
                SqlCommand cmd;
                SqlDataAdapter da;
                DataTable dt = new DataTable();

                //query to retrieve table name
                string q = "SELECT * FROM " +"["+ combotbl.SelectedValue +"]";
                con.Open();
                cmd = new SqlCommand(q, con);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    tblGrid.ItemsSource = dt.DefaultView;
                }
                else
                {
                    MessageBox.Show("No Data in this table");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("DATABASE RELATED ERROR \n"+ex.Message);
            }
        }

    }
}
