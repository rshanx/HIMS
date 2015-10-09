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
using MahApps.Metro;

namespace HIMS.Transaction.Reception
{
    /// <summary>
    /// Interaction logic for Reception.xaml
    /// </summary>
    public partial class Reception : Window
    {
        int i = 0, j = 0;
        DateTime today = DateTime.Now;
        string name;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIMS.Properties.Settings.HIMSConnectionString"].ConnectionString);
        //SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader dr;
        

        public Reception()
        {
           InitializeComponent();
           try
           {
               string q = "select * from appoint_temp";
               con.Open();
               SqlCommand cmd = new SqlCommand("select * from apoint_temp", con);
               DataSet dt = new DataSet();
               da = new SqlDataAdapter(cmd);
               da.Fill(dt);
               grid_appoint.ItemsSource = dt.Tables[0].DefaultView;
           }
           catch (Exception e)
           {
               MessageBox.Show("DATABASE RELATED ERROR \n"+e.Message);
           }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (i == 1)
            {
                cancelgb.IsEnabled = true;
                txtCancel.Focus();
                ///tagb.IsEnabled = false;
                ///
            }
            else
            {
                cancelgb.IsEnabled = false;
                i=0;
                txtCancel.Text = "";
                btnCancel.Focus();
            }
            
        }

        private void tabtn_Click(object sender, RoutedEventArgs e)
        {
            j++;
            if(j==1)
            {
                tagb.IsEnabled = true;
                txtTel.Focus();
            }
            else
            {
                tagb.IsEnabled = false;
                j = 0;
                txtTel.Text = "";
                btnTel.Focus();
            }
            
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
           
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OPD.OPD obj = new OPD.OPD();
            obj.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //con.Open();
            //string q = "INSERT INTO Appoint (SrNo
            //                   ,[RegDate]
            //                   ,[TokenNo]
            //                   ,[DrC]
            //                   ,[CaseNo]
            //                   ,[OpdNo]
            //                   ,[Name]
            //                   ,[AppDate]
            //                   ,[AppTime]
            //                   ,[Note1]
            //                   ,[PApp]
            //                   ,[ArTime]
            //                   ,[BillNo]
            //                   ,[Amount]
            //                   ,[Plocation]
            //                   ,[Height]
            //                   ,[Weight]
            //                   ,[BP]
            //                   ,[AppTag]
            //                   ,[T2Dr]
            //                   ,[SaveTime]
            //                   ,[OutTime]
            //                   ,[TNO]
            //                   ,[CatSrNo]
            //                   ,[SpecSrNo]
            //                   ,[MDRTIME]
            //                   ,[DrNote]
            //                   ,[CntNo]
            //                   ,[AppStatus])
            //             VALUES
            //                   (<SrNo, int,>
            //                   ,<RegDate, smalldatetime,>
            //                   ,<TokenNo, smallint,>
            //                   ,<DrC, int,>
            //                   ,<CaseNo, nvarchar(15),>
            //                   ,<OpdNo, int,>
            //                   ,<Name, nvarchar(50),>
            //                   ,<AppDate, smalldatetime,>
            //                   ,<AppTime, real,>
            //                   ,<Note1, nvarchar(50),>
            //                   ,<PApp, smallint,>
            //                   ,<ArTime, nvarchar(5),>
            //                   ,<BillNo, int,>
            //                   ,<Amount, money,>
            //                   ,<Plocation, nvarchar(3),>
            //                   ,<Height, nvarchar(50),>
            //                   ,<Weight, nvarchar(50),>
            //                   ,<BP, nvarchar(50),>
            //                   ,<AppTag, int,>
            //                   ,<T2Dr, int,>
            //                   ,<SaveTime, ntext,>
            //                   ,<OutTime, int,>
            //                   ,<TNO, int,>
            //                   ,<CatSrNo, int,>
            //                   ,<SpecSrNo, int,>
            //                   ,<MDRTIME, float,>
            //                   ,<DrNote, ntext,>
            //                   ,<CntNo, int,>
            //                   ,<AppStatus, int,>)";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Transaction.Transaction_Home obj = new Transaction_Home();
            //obj.Show();
        }

       
       
        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var appTheme = ThemeManager.GetAppTheme("BaseDark");
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);
        }
        private void Light_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var appTheme = ThemeManager.GetAppTheme("BaseLight");
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Red"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Green"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Blue"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Purple_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Purple"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Orange_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Orange"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Lime_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Lime"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Emerald_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Emerald"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Teald_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Teal"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Cyan_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Cyan"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Cobalt_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Cobalt"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Indigo_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Indigo"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Violet_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Violet"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Pink_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Pink"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Magenta_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Magenta"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Crimson_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Crimson"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
            
        }

        private void Amber_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Amber"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Yellow_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Yellow"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Brown_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Brown"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Olive_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Olive"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Steel_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Steel"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Mauve_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Mauve"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Taupe_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Taupe"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }

        private void Sienna_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Sienna"),
                                        ThemeManager.GetAppTheme(theme.Item1.Name));
        }       
    }
}
