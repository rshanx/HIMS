using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Net;

namespace HIMS.BLL
{
    /// <summary>
    /// Summary description for ClientInformation.
    /// </summary>
    /// 
    /****************************************************************************************************
     * 
     * The purpose of following ClientInformation class is to store information about the current logged 
     * on user. So other programmer can use information related to this client.
     * 
     * ***************************************************************************************************/

    public class ClientInformation
    {

        //public static BLReturnObject RetrieveFromServer(String[] ObjectProfile, String[] OpArgs, String[] GeneralArgs, DataWindowChanges[] dwc_UploadData)
        //{
        //    BLReturnObject ret_obj = new BLReturnObject();
        //    IServer ser_obj = (IServer)RemotingHelper.CreateProxy(typeof(IServer));
        //    ArrayList ArrayDataUpload;

        //    if (dwc_UploadData != null && dwc_UploadData.Length > 0)
        //    {
        //        ArrayDataUpload = new ArrayList(dwc_UploadData.Length);
        //        for (int i = 0; i < dwc_UploadData.Length; i++)
        //        {
        //            ArrayDataUpload.Add(dwc_UploadData[i].ToByteArray());
        //        }
        //        return ser_obj.Retrieve(ObjectProfile, OpArgs, GeneralArgs, ArrayDataUpload);
        //    }
        //    else
        //    {
        //        return ser_obj.Retrieve(ObjectProfile, OpArgs, GeneralArgs, null);
        //    }
        //    //ret_obj = ser_obj.Retrieve(ObjectProfile, OpArgs, GeneralArgs, dwc);

        //}

        //public static BLReturnObject RetrieveFromServer(String[] ObjectProfile, Object[] OpArgs, String[] GeneralArgs, DataWindowChanges[] dwc_UploadData, DataSet ds_uploaddata)
        //{
        //    BLReturnObject ret_obj = new BLReturnObject();
        //    IServer ser_obj = (IServer)RemotingHelper.CreateProxy(typeof(IServer));
        //    ArrayList ArrayDataUpload;

        //    if (dwc_UploadData != null && dwc_UploadData.Length > 0)
        //    {
        //        ArrayDataUpload = new ArrayList(dwc_UploadData.Length);
        //        for (int i = 0; i < dwc_UploadData.Length; i++)
        //        {
        //            ArrayDataUpload.Add(dwc_UploadData[i].ToByteArray());
        //        }
        //        return ser_obj.Retrieve(ObjectProfile, OpArgs, GeneralArgs, ArrayDataUpload, ds_uploaddata);
        //    }
        //    else
        //    {
        //        return ser_obj.Retrieve(ObjectProfile, OpArgs, GeneralArgs, null, ds_uploaddata);
        //    }
        //}

        

        #region Added By Vivek
        public static ArrayList GetDistinctColumnValues(DataTable dt, string ColumnName)
        {
            ArrayList UniqueValues = new ArrayList();
            string sortorder = ColumnName + " DESC";
            dt.DefaultView.Sort = sortorder;
            DataTable sorted_table = dt.DefaultView.ToTable();
            UniqueValues.Add(sorted_table.Rows[0][ColumnName].ToString());
            for (int i = 0; i < sorted_table.Rows.Count; i++)
            {
                if (sorted_table.Rows[i][ColumnName].ToString() == UniqueValues[UniqueValues.Count - 1].ToString())
                    continue;
                else
                    UniqueValues.Add(sorted_table.Rows[i][ColumnName].ToString());
            }
            return UniqueValues;
        }
        public static DataTable getDistinctColumnValues(DataTable d_table, string ColumnName)
        {
            DataTable unique_dt = new DataTable();
            if (!IsNull(d_table, true))
            {
                unique_dt.Columns.Add(ColumnName, typeof(object));
                string sortorder = ColumnName + " DESC";
                d_table.DefaultView.Sort = sortorder;
                DataTable sorted_table = d_table.DefaultView.ToTable();

                DataRow dr = unique_dt.NewRow();
                dr[ColumnName] = sorted_table.Rows[0][ColumnName].ToString();
                unique_dt.Rows.Add(dr);
                for (int i = 0; i < sorted_table.Rows.Count; i++)
                {
                    if (sorted_table.Rows[i][ColumnName].ToString() == unique_dt.Rows[unique_dt.Rows.Count - 1][ColumnName].ToString())
                        continue;
                    else
                    {
                        DataRow row = unique_dt.NewRow();
                        row[ColumnName] = sorted_table.Rows[i][ColumnName].ToString();
                        if (row[ColumnName].ToString() != string.Empty)
                            unique_dt.Rows.Add(row);
                    }
                }
            }
            return unique_dt;
        }
        public static DataTable GetDistintColumnsRowValues(DataTable d_table, string ColumnName)
        {
            DataTable unique_dt = new DataTable();

            if (!IsNull(d_table, true))
            {
                unique_dt = d_table.Clone();

                string sortorder = ColumnName + " DESC";
                d_table.DefaultView.Sort = sortorder;
                DataTable sorted_table = d_table.DefaultView.ToTable();
                //sorted table contains orginal data with DESC sort order.




                unique_dt.ImportRow(sorted_table.Rows[0]);
                for (int i = 0; i < sorted_table.Rows.Count; i++)
                {
                    if (sorted_table.Rows[i][ColumnName].ToString() == unique_dt.Rows[unique_dt.Rows.Count - 1][ColumnName].ToString())
                        continue;
                    else
                    {

                        DataRow row = GetRow(d_table, ColumnName, sorted_table.Rows[i][ColumnName].ToString());
                        unique_dt.ImportRow(row);

                    }
                }
            }
            if (!IsNull(unique_dt, true))
            {
                unique_dt.DefaultView.Sort = ColumnName + " ASC";
                unique_dt = unique_dt.DefaultView.ToTable();
            }
            return unique_dt;
        }
        public static DataRow GetRow(DataTable dt, string column, string value)
        {
            DataRow[] drow = dt.Select(column + "='" + value + "'");
            if (drow.Length > 0)
                return drow[0];
            return null;

        }
        public static Boolean IsNull(object val)
        {
            if (val == null || val == DBNull.Value)
                return true;
            return false;
        }
        public static Boolean IsNull(object val, Boolean SearchEmptyVal)
        {
            if (IsNull(val))
                return true;
            if (SearchEmptyVal)
            {
                if (val is String)
                    if (val.ToString().Trim() == String.Empty)
                        return true;
                if (val is DataTable)
                    if (((DataTable)val).Rows.Count == 0)
                        return true;
                if (val is DataSet)
                    if (((DataSet)val).Tables.Count == 0)
                        return true;
                if (val is System.Collections.ArrayList)
                    if (((System.Collections.ArrayList)val).Count == 0)
                        return true;
                if (val is Array)
                    if (((Array)val).Length == 0)
                        return true;
            }
            return false;
        }
        #endregion

        ////SessionId of the currently logged on client
        private static String SessionId;

        ////flag is used to execute SetValue function only once
        private static bool flag = false;

        ////LoginLevel stores total login level in the system
        private static Byte LoginLevel;

        ////UserId will be used to store user id of the currently logged on client
        private static String UserId = "";

        ////LevelNames stores name of the levels
        ////e.g. "Company" , "Business Unit" etc.
        private static ArrayList LevelNames = new ArrayList();

        ////Selected levels at the time of login will be stored in SelectedLoginLevels
        private static ArrayList SelectedLoginLevels = new ArrayList();


        ////Store the today's date as per the server machine
        private static DateTime ServerDateTime;

        ////following function will be called by the login module.
        ////afterwards if anybody calls it, he won't be able to set the variables 
        ////that is the magic behind this function
        ////problem is we needed global values , 
        ////accessed by any body,
        ////initialized at the run time when server sends these information,
        ////also it should be initialized only once !!!!!!!!!!!!!!!!!
        ////and no body should be able to tamper these values.
        public static void SetValues(String tUserId, String tSessionID, Byte tLoginLevel, ArrayList tLevelNames,
                                    ArrayList tSelectedLoginLevels, DateTime tServerDateTime)
        {
            if (flag == false)
            {
                UserId = tUserId;
                SessionId = tSessionID;
                LoginLevel = tLoginLevel;
                LevelNames = tLevelNames;
                SelectedLoginLevels = tSelectedLoginLevels;
                ServerDateTime = tServerDateTime;
                flag = true;
            }
        }

        //Get your user id
        public static String GetUserId()
        {
            return UserId;
        }

        //Get your user IP
        public static string GetHostIP()
        {
            //get the ip address of this machine
            //IPHostEntry hostInfo = Dns.GetHostByName(Dns.GetHostName());
            // Get the IP address list that resolves to the host names  					
            IPHostEntry hostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] address = hostInfo.AddressList;

            //return address[0].ToString(); // Commented by Krishna As on 07-11-2009 

            /*****************************************************\
             * Added by Krishna As on 07-11-2009, If HostId Lenght is > 15, it give error Message in SERVER
             * Fail to update DataBase due to Maxlength Violation of Created Host.
             * 
             * Bcz of that here we check if HostId Lenght is > 15, Substring this ID Up to 15 Charactor and set to server.
             * 
             */
            String _HostId = address[0].ToString();
            if (_HostId.Length > 15)
                _HostId = _HostId.Substring(0, 15);
            return _HostId.ToString();
            /******************************************************/
        }
        //Get your Host Name
        public static string GetHostName()
        {
            return Dns.GetHostName();
        }

        ////Get your session id
        public static String GetSessionId()
        {
            return SessionId;
        }

        ////Get login levels availabe in the system
        public static Byte GetLoginLevel()
        {
            return LoginLevel;
        }
        ////Get today's date
        public static DateTime GetToday()
        {
            return Today;
        }
        public static DateTime Today
        {
            get
            {
                return ServerDateTime;
            }
        }

        ////A new data store will be created by using file, which are saved at the time of login,
        ////UserSales area is sent by the server and stored locally.
        ////every time you call this function you will get instance
        ////because if you store this object globally and simplay returns it,
        ////it will create problems because .net returns objects by reference
        ////so any modification made in the copy of this object will be reflected in the globally availabe object
        ////so next time when you return this object modified object will be retured, not the original one
        ////so be careful while returning any object
        //public static DataTable GetUserHospitalArea()
        //{
        //    String help_path = System.Configuration.ConfigurationSettings.AppSettings.Get("HelpPath") + "temp";
        //    DataTable dtUserHospitalArea = new DataTable();
        //    DataTable dtUserSalesAreatemp = new DataTable();
        //    dtUserSalesAreatemp = SBSFunctionLibrary.TextFiletoDataTable(help_path + @"\user_Hospital_area.txt");
        //    return dtUserSalesAreatemp;
        //}

        //////A new data store will be created by using file, which are saved at the time of login,
        //////SaDesc is sent by the server and stored locally
        //public static DataTable GetHaDesc()
        //{
        //    String help_path = System.Configuration.ConfigurationManager.AppSettings.Get("HelpPath") + "temp";
        //    DataTable dtHaDesc = new DataTable();
        //    DataTable dtSaDesctemp = new DataTable();
        //    dtSaDesctemp = SBSFunctionLibrary.TextFiletoDataTable(help_path + @"\ha_desc.txt");
        //    return dtSaDesctemp;
        //}


        ////new copy of level names will be created and returned.
        public static ArrayList GetLevelNames()
        {
            ArrayList temp = new ArrayList();
            for (int i = 0; i < LevelNames.Count; i++)
                temp.Add(LevelNames[i].ToString());
            return temp;
        }

        ////Selected login levels will be returned
        public static ArrayList GetSelectedLoginLevels()
        {
            ArrayList temp = new ArrayList();
            for (int i = 0; i < SelectedLoginLevels.Count; i++)
                temp.Add(SelectedLoginLevels[i].ToString());

            return temp;
        }
        ////Following function accepts array of levels and returns according to that
        ////arraylist of sa_id
        ////it can return multiple sa_id if there are
        //public static ArrayList GetOrganizationId(ArrayList tLevelNames)
        //{
        //    ArrayList OrgId = new ArrayList();
        //    //if (tLevelNames.Count > 5 || tLevelNames.Count <= 0)
        //    if (tLevelNames.Count <= 0)
        //    {
        //        return null;
        //    }
        //    String FilterExpression = "";
        //    String help_path = System.Configuration.ConfigurationManager.AppSettings.Get("HelpPath") + "temp";
        //    DataTable dtUserHospitalAreatemp = new DataTable();// new DataStore(ConfigurationSettings.AppSettings.Get("GeneralPBLCommon"), "d_usersalesarea");
        //    dtUserHospitalAreatemp = SBSFunctionLibrary.TextFiletoDataTable(help_path + @"\user_Hospital_area.txt");

        //    ArrayList ColumnNames = new ArrayList();
        //    for (int i = 1; i <= LevelNames.Count; i++)
        //    {
        //        ColumnNames.Add("Level" + i);
        //    }
        //    for (int i = 0; i < 5; i++)
        //    {
        //        if (i < 4)
        //            FilterExpression += ColumnNames[i] + "='" + tLevelNames[i] + "' AND ";
        //        else
        //            FilterExpression += ColumnNames[i] + "='" + tLevelNames[i] + "'";
        //    }

        //    DataRow[] fillter_row = dtUserHospitalAreatemp.Select(FilterExpression);

        //    for (int i = 0; i < fillter_row.Length; i++)
        //    {
        //        OrgId.Add(fillter_row[i]["ha_id"].ToString());
        //    }
        //    return OrgId;
        //}
        //public static ArrayList GetAllSAIDs()
        //{
        //    DataTable dt_UserHospitalAreas = ClientInformation.GetUserHospitalArea();
        //    ArrayList arrHAID = new ArrayList();
        //    for (int i = 0; i < dt_UserHospitalAreas.Rows.Count; i++)
        //        arrHAID.Add(dt_UserHospitalAreas.Rows[i]["ha_id"].ToString());
        //    return arrHAID;
        //}

        // Added by Krishna 01-09-2009 For Get Company Name & Address Details
        //public static Boolean GetComapnyDetails(ArrayList tLevelNames, ref String _CompanyName, ref ArrayList _CompanyAddress, ref String _CompanyCityName, ref String _pinCode, ref String _PhNo1, ref String _Phno2)
        //{
        //    if (tLevelNames.Count <= 0)
        //    {
        //        return false;
        //    }
        //    String FilterExpression = "";
        //    String help_path = System.Configuration.ConfigurationManager.AppSettings.Get("HelpPath") + "temp";
        //    //String help_path = System.Windows.Forms.Application.StartupPath.ToString() + "\\Help\\" + "temp";
        //    DataTable dtUserHospitalAreatemp = new DataTable();// new DataStore(ConfigurationSettings.AppSettings.Get("GeneralPBLCommon"), "d_usersalesarea");
        //    dtUserHospitalAreatemp = SBSFunctionLibrary.TextFiletoDataTable(help_path + @"\user_Hospital_area.txt");

        //    ArrayList ColumnNames = new ArrayList();
        //    for (int i = 1; i <= LevelNames.Count; i++)
        //    {
        //        ColumnNames.Add("Level" + i);
        //    }
        //    for (int i = 0; i < 5; i++)
        //    {
        //        if (i < 4)
        //            FilterExpression += ColumnNames[i] + "='" + tLevelNames[i] + "' AND ";
        //        else
        //            FilterExpression += ColumnNames[i] + "='" + tLevelNames[i] + "'";
        //    }

        //    DataRow[] fillter_row = dtUserHospitalAreatemp.Select(FilterExpression);

        //    for (int i = 0; i < fillter_row.Length; i++)
        //    {
        //        _CompanyName = fillter_row[i]["ha_name"].ToString();
        //        _CompanyAddress.Add(fillter_row[i]["address1"].ToString());
        //        _CompanyAddress.Add(fillter_row[i]["address2"].ToString());
        //        _CompanyAddress.Add(fillter_row[i]["address3"].ToString());
        //        _CompanyAddress.Add(fillter_row[i]["address4"].ToString());
        //        _CompanyCityName = fillter_row[i]["city_name"].ToString();
        //        _CompanyCityName = fillter_row[i]["zipcode"].ToString();
        //        _CompanyCityName = fillter_row[i]["phone_no1"].ToString();
        //        _CompanyCityName = fillter_row[i]["phone_no2"].ToString();
        //    }

        //    return true;
        //}
    }
}
