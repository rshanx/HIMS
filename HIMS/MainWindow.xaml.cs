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
using HIMS.XSD;
using HIMS.Transaction.Reception;
using System.Configuration;
using MahApps.Metro.Controls;

namespace HIMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            tbuser.Focus();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIMS.Properties.Settings.HIMSConnectionString"].ConnectionString);
        SqlCommand cmd,cmd_license;
        SqlDataAdapter da,da_license;
        DataSet ds;
        DataTable dt,dt_license;
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            #region commented
            //   MessageBox.Show("hello");
         //   ReportForm obj = new ReportForm();
            //   obj.Show();
            #endregion

            //#region Verify licensing
            //bool is_first_time_login;
            //try
            //{
            //    string h_id = Constants.hospial_id;
            //    string q = "select * from license where hospital_id ='"+h_id+"' ";
            //    con.Open();
            //    cmd_license = new SqlCommand(q, con);
            //    da_license = new SqlDataAdapter(cmd_license);
            //    dt_license = new DataTable();
            //    da_license.Fill(dt_license);
            //    con.Close();
            //    if(dt_license.Rows.Count ==1)
            //    {
            //        is_first_time_login = false;
            //    }
            //    else if(dt_license.Rows.Count <= 0)
            //    {
            //        ClientInformation obj = new ClientInformation();
            //        is_first_time_login = false;//is first time is true but we have to set in table false
            //        //DataRow row = DS_license.licenseRow;
            //        //DS_license.dt_licenseRow row = DS_license.dt_licenseRow();
            //        DateTime d1 = DateTime.Now;
            //        DateTime d2 = d1.AddDays(30);
            //        string is_purchased = Constants.FLAG_N;
            //        string cancel_flag = Constants.FLAG_N;
            //        string created_by = "VIVEK";
            //        DateTime created_date =  d1;
            //        string created_host = "VIVEK-PC";
            //        string is_first;
            //        if(is_first_time_login)
            //        {
            //             is_first = Constants.FLAG_Y;
            //        }
            //        else
            //        {
            //            is_first = Constants.FLAG_N;
            //        }
            //        string ins_q = " INSERT INTO LICENSE ([hospital_id],[is_first_time],[trial_start_date],[trial_end_date],[is_purchased],[cancel_flag],[created_by],[created_date],[created_host]) values ('" + h_id + "','" + is_first + "',CONVERT(VARCHAR,'" + d1 + "',103),CONVERT(VARCHAR,'" + d2 + "',103),'" + Constants.FLAG_N + "','" + cancel_flag + "',CONVERT(VARCHAR,'" + created_date + "',103),'" + created_by + "','" + created_host + "') ";

            //        con.Open();
            //        SqlCommand cmd_ins = new SqlCommand(ins_q, con);
            //        int i = cmd_ins.ExecuteNonQuery();
            //        if (i == 1)
            //        {
            //            MessageBox.Show("your trial period start for 30 days");
            //        }
            //        else
            //        {
            //            MessageBox.Show("error while updating trial period in license table");
            //        }
            //        con.Close();
            //    }
            //}
            //catch(Exception exc)
            //{
            //    MessageBox.Show("error :\n" + exc.Message);
            //}
            //#endregion

            #region Check Latest Version
            #endregion

            #region Initial Validation
            if (tbuser.Text == string.Empty)
            {
                MessageBox.Show("Please enter Username");
                return;
            }
            if(tbpwd.Password == string.Empty)
            {
                MessageBox.Show("Please enter Password");
                return;
            }
            #endregion

            #region Login Check
            try
            {
                Encryption enc = new Encryption();
                string userid = tbuser.Text.ToString();
                string pwd = enc.encrypt(tbpwd.Password.ToString());
                bool result = logincheck(userid, pwd);

                if (result)
                {
                    //Home objhome = new Home();
                    Reception objhome = new Reception();
                    this.Hide();
                    objhome.Show();
                }
                else
                {
                    MessageBox.Show("Wrong UserID/Password ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred" + ex.Message);
            }
            #endregion
            
        }

        private bool logincheck(string userid, string pwd)
        {
            string q = "select *  from user_mst where user_id='"+userid+"' and password='"+pwd+"' ";
            con.Close();
            con.Close();
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

        private void Login_Closed(object sender, EventArgs e)
        {
            
        }


        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Designed By VIVEK AP");
        //}
        #endregion
    }
}
