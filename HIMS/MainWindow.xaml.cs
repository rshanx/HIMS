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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using HIMS.BLL;
using HIMS.Transaction.Reception;
using System.Configuration;

namespace HIMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIMS.Properties.Settings.HIMSConnectionString"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt;
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            #region commented
            //   MessageBox.Show("hello");
         //   ReportForm obj = new ReportForm();
            //   obj.Show();
            #endregion
            Encryption enc = new Encryption();
            string userid = tbuser.Text.ToString();
            string pwd =  enc.encrypt(tbpwd.Password.ToString());
            bool result = logincheck(userid, pwd);
            if (result)
            {
                Home objhome = new Home();
                this.Hide();
                objhome.Show();
            }
            else
            {
                MessageBox.Show("Wrong UserID/Password ");
            }
        }

        private bool logincheck(string userid, string pwd)
        {
            string q = "select *  from user_mst where user_id='"+userid+"' and password='"+pwd+"' ";
            cmd = new SqlCommand(q,con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            ///throw new NotImplementedException();
        }

        #region other events

        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {
          ///  MessageBox.Show("text changed");
        }

        private void tbuser_SelectionChanged(object sender, RoutedEventArgs e)
        {
        //    MessageBox.Show("selection changed");
        }


        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Designed By VIVEK AP");
        //}
        #endregion
    }
}
