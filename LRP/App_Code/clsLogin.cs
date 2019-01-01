using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;

//Imports MSDASC


namespace FairFest.userclasses
{
    public class clsLogin
    {
                       
        public string check_login(string login, string passwd)
        {
            string previledge="None";

            string strSQL = string.Format("SELECT previledge FROM UserTable where username='{0}' and password='{1}'", login, passwd);
            SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDBFilename=|DataDirectory|Database.mdf;Integrated Security=true;User Instance=true;");
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    previledge = dr["previledge"].ToString();
                }
                return previledge;
            }
            catch (Exception ex)
            {
                conn.Close();
                conn.Dispose();
                return "Error In Connection:" + ex.ToString();
            }
            
        }
    }
}

