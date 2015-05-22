using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace HIMS.BLL
{
    class Version_Controller
    {
        public decimal GetLetestVersionNo()
        {
            decimal VersionNo = 0;

            ///string Ha_Id = ClientInformation.GetOrganizationId(ClientInformation.GetSelectedLoginLevels())[0].ToString();

            //string[] ObjectProfile = new string[3];
            //ObjectProfile[0] = "T"; //Master 
            //ObjectProfile[1] = "S";
            //ObjectProfile[2] = "TT_VERSION_CONTROLLER";

            //string[] OpArgs = new string[2];
            //OpArgs[0] = "GetVersionNo";

            //string[] GeneralArgs = new string[2];
            //GeneralArgs[0] = ClientInformation.GetSessionId();
            //GeneralArgs[1] = Ha_Id;


            //BLReturnObject ret_obj = new BLReturnObject();
            //IServer obj = (IServer)(RemotingHelper.CreateProxy(typeof(IServer)));

            try
            {
                //ret_obj = obj.Retrieve(ObjectProfile, OpArgs, GeneralArgs, null);
                //if (ret_obj.dt_ReturnedTables[0].Rows.Count > 0)
                {
                    //VersionNo = Convert.ToDecimal(ret_obj.dt_ReturnedTables[0].Rows[0][0]);
                }
            }
            //catch (Exception ex)
            //{
            //    //SBSMessageBox.Show(ex.Code + ":" + ex.Message, ButtonType.OK, IconType.Error);
            //}
            catch (Exception ex)
            {
                //SBSFunctionLibrary.SBSClientException CustomException = SBSFunctionLibrary.ExceptionManager.Help(ex);
                //SBSMessageBox.Show(CustomException.Code + CustomException.Message, ButtonType.OK, IconType.Error);
            }
            return VersionNo;
        }

        public Boolean IsLatestVersion()
        {
            decimal LatestVersionNo = GetLetestVersionNo();
            String HelpPath = ConfigurationSettings.AppSettings.Get("HelpPath");
            decimal CurrentVersionNo = Convert.ToDecimal(File.ReadAllText(HelpPath + "version_no.txt"));
            if (CurrentVersionNo != LatestVersionNo)
            {
                //SBSMessageBox.Show("Current Version of System is not Latest.\nYou have to Update it by using Update Program.");
                File.WriteAllText(HelpPath + "latest_version_no.txt", LatestVersionNo.ToString());
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
