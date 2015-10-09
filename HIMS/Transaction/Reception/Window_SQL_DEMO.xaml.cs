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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HIMS.Transaction.Reception
{
    /// <summary>
    /// Interaction logic for Window_SQL_DEMO.xaml
    /// </summary>
    public partial class Window_SQL_DEMO : Window
    {
        
        public Window_SQL_DEMO()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIMS.Properties.Settings.HIMSConnectionString"].ConnectionString);
            con.Open();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("select * from temp_table",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            gw.ItemsSource = ds.Tables[0].DefaultView;

        }
        //static void abc(object sender,SqlRowUpdatingEventArgs e)
        //{
            
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XSD.DS_table_temp1 ds = new XSD.DS_table_temp1();

            DataRow dr = ds.Tables[0].NewRow();
            dr["id"] = BLL.General_Utilities.GetNextDocNoFromTable("temp_table", "");
            dr["name"] = tb1.Text;
            dr["city"] = tb2.Text;
            ds.Tables[0].Rows.Add(dr);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIMS.Properties.Settings.HIMSConnectionString"].ConnectionString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder cmdb = new SqlCommandBuilder(da);
            

            var TA = new XSD.DS_table_temp1TableAdapters.temp_tableTableAdapter();
            TA.Insert(BLL.General_Utilities.GetNextDocNoFromTable("temp_table", ""),tb1.Text,tb2.Text);
            
            //da.Update(ds, "temp_table");
            //da.RowUpdated += new SqlRowUpdatedEventHandler(abc);
            //TA.
            MessageBox.Show("inserted in temp_table");
            XSD.DS_TableTableAdapters.TableTableAdapter ta2 = new XSD.DS_TableTableAdapters.TableTableAdapter();
            ta2.Insert("ce");
            MessageBox.Show("inserted in table");
            TA.Update("mitesh", "ahmedabad", 5, "hitesh", "computer");
            return;
            
            //BLL.ExecSql obj = new BLL.ExecSql();
            ////string val = tb1.Text +"'"+","+tb2.Text +"'";
            //string[] val = new string[2];
            //val[0] = tb1.Text;
            //val[1] = tb2.Text;
            //ds.Tables[0].Rows.Add(val);
            
            //string[] col = new string[2];
            //col[0] = "name";
            //col[1] = "city";
            //BLL.ExecSql.insert("TEMP_TABLE", col, val);
        }

        private void abc(object sender, SqlRowUpdatedEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIMS.Properties.Settings.HIMSConnectionString"].ConnectionString);

            SqlCommand cmd = new SqlCommand("select @@identity from temp_table",e.Command.Connection);
            e.Row["id"] = cmd.ExecuteScalar();
            e.Row.AcceptChanges();

            //throw new NotImplementedException();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Transaction.Transaction_Home obj = new Transaction_Home();
            //obj.Show();
        }
        
    }
}
