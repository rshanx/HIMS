using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Data;
using MahApps.Metro.Controls.Dialogs;

namespace HIMS.BLL
{
    class General_Utilities
    {

        #region database var
        
        #endregion

        #region Added By Vivek On 22-05-2015 Amount To Word Funtions

        public static String amount_to_word(int number)
        {
            String finalstr = String.Empty;
            int reminder, pass = 1;

            if (number != 0)
            {
                while (number != 0)
                {
                    if (pass == 2)
                    {
                        reminder = number % 10;
                        number = number / 10;
                    }
                    else
                    {
                        reminder = number % 100;
                        number = number / 100;
                    }
                    if (reminder != 0)
                        finalstr = String.Concat(String.Concat(number_to_word(reminder), word(pass), finalstr));
                    pass++;
                }
            }
            else
                finalstr = "Zero ";
            return finalstr;
        }

        private static String number_to_word(int num)
        {
            String str1;
            switch (num)
            {
                case 1:
                    return "One ";
                case 2:
                    return "Two ";
                case 3:
                    return "Three ";
                case 4:
                    return "Four ";
                case 5:
                    return "Five ";
                case 6:
                    return "Six ";
                case 7:
                    return "Seven ";
                case 8:
                    return "Eight ";
                case 9:
                    return "Nine ";
                case 10:
                    return "Ten ";
                case 11:
                    return "Eleven ";
                case 12:
                    return "Twelve ";
                case 13:
                    return "Thirteen ";
                case 14:
                    return "Fourteen ";
                case 15:
                    return "Fifteen ";
                case 16:
                    return "Sixteen ";
                case 17:
                    return "Seventeen ";
                case 18:
                    return "Eighteen ";
                case 19:
                    return "Nineteen ";
                case 20:
                    return "Twenty ";
                case 30:
                    return "Thirty ";
                case 40:
                    return "Fourty ";
                case 50:
                    return "Fifty ";
                case 60:
                    return "Sixty ";
                case 70:
                    return "Seventy ";
                case 80:
                    return "Eighty ";
                case 90:
                    return "Ninety ";
                default:
                    {
                        if (num >= 20)
                        {
                            str1 = number_to_word((num / 10) * 10);
                            return String.Concat(str1, number_to_word(num % 10));
                        }
                        else
                            return String.Empty;
                    }
            }
        }

        private static String word(int pass)
        {
            switch (pass)
            {
                case 2:
                    return "Hundred ";
                case 3:
                    return "Thousand ";
                case 4:
                    return "Lacs ";
                case 5:
                    return "Crore ";
                case 6:
                    return "Billion ";
                default:
                    return String.Empty;
            }
        }

        public static bool IsValidNumber(string number)
        {
            if (number.Trim() == string.Empty)
                return false;
            char[] cr = number.ToCharArray();

            for (int i = 0; i < cr.Length; i++)
            {
                string sr = cr[i].ToString();
                if (!CheckValidNumberornot(sr))
                    return false;
            }

            return true;

        }

        private static bool CheckValidNumberornot(string value)
        {
            string[] no = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            bool result = false;

            for (int i = 0; i < no.Length; i++)
            {
                if (no[i].ToString().Contains(value))
                    return true;
            }

            return result;
        }

        #endregion

        #region Added By Vivek on 22-08-2015 Get Next Doc No
        public static int GetNextDocNoFromTable(string table_name,string column_name)
        {
            try
            {
                int next_doc_no=0;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIMS.Properties.Settings.HIMSConnectionString"].ConnectionString);
                SqlCommand cmd,cmd1;
                SqlDataAdapter da,da1;
                DataTable dt=new DataTable();
                DataTable dt1 = new DataTable();
                //query to retrieve primary key from table name
                string q = "SELECT column_name FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1 "+
                            "AND table_name = '"+table_name+"'";
                con.Open();
                cmd = new SqlCommand(q, con);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if(dt.Rows.Count >0)
                {
                    //DataRow[] dr= dt.Select("column_name like '" + column_name + "'");
                    string column;
                    //if (dr[0][0].ToString() != string.Empty)
                    //{
                    //    column = dr[0][0].ToString();
                    //}
                    //else if(column_name != string.Empty)
                    //{
                    //    column = column_name;
                    //}
                    //else
                    //{
                    //    return -888;//no column passed
                    //}
                    column = dt.Rows[0][0].ToString();
                    q = string.Empty;
                    q="select "+column+" from "+table_name+" order by "+column+" DESC";
                    cmd1 = new SqlCommand(q,con);
                    da1 = new SqlDataAdapter(cmd1);
                    da1.Fill(dt1);
                    if(dt1.Rows.Count >0)
                    {
                        next_doc_no= Convert.ToInt32(dt1.Rows[0][0])+1;
                    }
                    else
                    {
                        next_doc_no= 1;
                    }
                }
                else
                {
                    //no primary key in table
                    return -999;
                }
                return next_doc_no;
            }
            catch(Exception ex)
            {
                return -1;
            }
            
        }
        #endregion

        #region Added By Vivek as on 23-08-2015 to get all list of table names from db
        public static DataTable GetTables()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIMS.Properties.Settings.HIMSConnectionString"].ConnectionString);
                SqlCommand cmd;
                SqlDataAdapter da;
                DataTable dt=new DataTable();
                
                //query to retrieve table name
                string q = "SELECT [TABLE_NAME] FROM INFORMATION_SCHEMA.TABLES";
                con.Open();
                cmd = new SqlCommand(q, con);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;                
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }
        #endregion

        #region Added by Vivek as on 23-08-2015 to get all column name from table
        public static DataTable GetColumns(string table)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIMS.Properties.Settings.HIMSConnectionString"].ConnectionString);
                SqlCommand cmd;
                SqlDataAdapter da;
                DataTable dt = new DataTable();

                //query to retrieve table name
                string q = "SELECT [COLUMN_NAME] FROM INFORMATION_SCHEMA.COLUMNS where [TABLE_NAME]='"+table+"'";
                con.Open();
                cmd = new SqlCommand(q, con);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }
        #endregion

        //#region Added by Vivek as on 16-09-2015 to show please wait dialog
        //private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    var controller = await this.ShowProgressAsync("Please wait...", "We will logged you in..!");

        //    await Task.Delay(1000);

        //    controller.SetCancelable(true);

        //    double i = 0.0;
        //    while (i < 3.0)
        //    {
        //        double val = (i / 100.0) * 50.0;
        //        controller.SetProgress(val);
        //        controller.SetMessage("Processing: ...");

        //        if (controller.IsCanceled)
        //            break; //canceled progressdialog auto closes.

        //        i += 1.0;

        //        await Task.Delay(1000);
        //    }

        //    await controller.CloseAsync();

        //    //if (controller.IsCanceled)
        //    //{
        //    //    await this.ShowMessageAsync("No cupcakes!", "You stopped baking!");
        //    //}
        //    //else
        //    //{
        //    //    await this.ShowMessageAsync("Cupcakes!", "Your cupcakes are finished! Enjoy!");
        //    //}
        //}
        //#endregion

    }
}
