using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Permissions;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;


namespace HIMS.BLL
{
    /// <summary>
    /// Summary description for EncryptPassword.
    /// RSA Algorithm
    /// Take two Prime number p and q
    /// Now find value of n = p * q
    /// Find value of z = (p - 1) * (q - 1)
    /// Take value of d relative to prime number (where d less than z and, d & z have not any common factor except 1)
    /// Now take value of e, So that it satisfied following formula 
    /// ((e * d) - 1) mod z) == 0
    ///	Divide the plaintext into single character,so that P belong to interval (0 less than or equal P less than n)
    ///	To encrypt a message P, compute C = pow(P,e) mod n (where C = encrypt value of P)
    ///	To decrypt a message C, compute P = pow(C,d) mod n (where P = decrypt value of C)
    ///	
    ///	Example:
    ///	Let p = 3 and q = 11
    ///	we get n = 33 and z = 20
    ///	Let d = 7 so that d less than z, d & z have no common factor
    ///	Now find value of e using formula ((e * d) - 1) mod z) == 0
    ///	we get e = 3.
    ///		Plaintext(P)					Ciphertext(C)						After decryption
    ///	Symbolic	Numeric		pow(P,3)	pow(p,3) mod 33		pow(C,7)	pow(C,7) mod 33		Symobolic	
    ///		S		  19		 6859			   28		  13492928512			19				S
    ///		U		  21		 9261			   21		   1801088541			21				U			
    /// </summary>
    public class Encryption
    {
        private DataTable dtparameterinfo = new DataTable();
        public Encryption()
        {
            //String help_path = System.Configuration.ConfigurationSettings.AppSettings.Get("HelpPath") + "temp";
            //String temp = help_path + @"\login_parameter_info.txt";
            //if (File.Exists(temp))
            //{
            //    dtparameterinfo = SBSFunctionLibrary.TextFiletoDataTable(temp);
            //    //dStoreParameterInfo.ImportFile(ConfigurationSettings.AppSettings.Get("HelpPath") + "login_parameter_info.txt", FileSaveAsType.Text);
            //}
        }

        public string encrypt(string password)
        {
            int p = 11, q = 13;
            double n, z, d, e;
            d = e = 0;
            string encryptpassword = "";

            n = p * q;
            z = (p - 1) * (q - 1);

            //find value of d
            for (int i = 2; i < z; i++)
            {
                if ((z % i) != 0)
                {
                    d = i;
                    break;
                }
            }

            //find value of e
            for (int i = 1; i < z; i++)
            {
                if (((d * i) - 1) % z == 0)
                {
                    e = i;
                    break;
                }
            }

            //encrypt given string
            char[] chararray = password.ToCharArray();
            for (int i = 0; i < chararray.Length; i++)
            {
                double ascii = (byte)chararray[i];
                int ciphertext = Convert.ToInt16(Math.Pow(ascii, e) % n);
                //encryptpassword += Convert.ToChar(ciphertext).ToString();
                encryptpassword += ciphertext.ToString();
            }
            return (encryptpassword);
        }

        public bool ValidatePassword(String stPassword)
        {
            String passlength = "";
            String passalpha = "";
            String passnumber = "";
            if (dtparameterinfo.Rows.Count > 0)
            {
                passalpha = dtparameterinfo.Rows[0]["param_value"].ToString();
                passlength = dtparameterinfo.Rows[1]["param_value"].ToString();
                passnumber = dtparameterinfo.Rows[2]["param_value"].ToString();
            }

            int DigitCount = 0, CharCount = 0, SpecialCount = 0;
            char[] charPassword = stPassword.ToCharArray();

            if (charPassword.Length > Convert.ToInt16(passlength))
            {
                //SBSMessageBox.Show("Maximum Length of Your Password can not Exceed " + passlength + "Character");
                return false;
            }
            for (int i = 0; i < charPassword.Length; i++)
            {
                int ascii = (byte)charPassword[i];
                if (ascii >= 48 && ascii <= 57)
                    DigitCount++;
                else if ((ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122))
                    CharCount++;
                else
                    SpecialCount++;
            }
            if ((CharCount > Convert.ToInt16(passalpha)) || (DigitCount > Convert.ToInt16(passnumber)))
            {
                return false;
            }
            else
                return true;

        }
    }
}
