using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for clsUser
/// </summary>
/// 
namespace FairFest.userclasses
{

    public class User
    {
        protected string username;
        protected string password;
        protected string city;
        protected string state;
        protected string country;
        protected string role;
        protected int point;
        //public User node;
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDBFilename=|DataDirectory|Database.mdf;Integrated Security=true;User Instance=true;");

        public User()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public User(string user, string psw)
        {
            this.username = user;
            this.password = psw;
        }

        public int ExecuteCommand(string query)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                return i;
            }
            catch (Exception ex)
            {
                conn.Close();
                return -1;
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //while (dr.Read()) ;
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                return null;
            }
        }
    }

    interface IStaff
    {
        int AddUser(string user, string psw, string city, string state, string country, string role, int point);
        int RemoveUser(string usrname);
        int AsignPreviledge(string whoose, string whoom);
        int RemovePreviledge(string whoose, string whoom);
        DataTable GetAllTransactionAsc();
        DataTable GetAllTransactionDesc();
        DataTable GetUserTransactionAsc(string usr);
        DataTable GetUserTransactionDesc(string usr);
        //DataTable GetCityTransactionAsc(string city);
        //DataTable GetCityTransactionDesc(string city);
    }

    interface IGeneralUser
    {
        DataTable GetAllTransactionAsc();
        DataTable GetAllTransactionDesc();
        DataTable GetUserTransactionAsc(string usr);
        DataTable GetUserTransactionDesc(string usr);
        int RequestPreviledge(string target);
        int GrantPreviledge(string target);
    }

    public class Staff : User,IStaff
    {
        public Staff()
        {
        }
        public Staff(string usr, string psw)
        {
            this.username = usr;
            this.password = psw;
        }

        public int AddUser(string user, string psw, string city, string state, string country, string role, int point)
        {
            return 0;
        }

        public int RemoveUser(string usrname)
        {
            return ExecuteCommand(string.Format("delete from UserTable where username='{0}'", usrname));

        }

        public int AsignPreviledge(string whose, string whom)
        {
            return ExecuteCommand(string.Format("insert into PreviledgeTable (whose,whom) values('{0}','{1}')", whose, whom));

        }

        public int RemovePreviledge(string whose, string whom)
        {
            return ExecuteCommand(string.Format("delete from PreviledgeTable where whose='{0}' and whom='{1}'", whose, whom));
        }

        public DataTable GetAllTransactionAsc()
        {
            return ExecuteQuery("select * from TransactionTable order by amount asc");
        }

        public DataTable GetAllTransactionDesc()
        {
            return ExecuteQuery("select * from TransactionTable order by amount desc");
        }

        public DataTable GetUserTransactionAsc(string usr)
        {
            return ExecuteQuery(string.Format("select * from TransactionTable where payer='{0}' or reciever='{1}' order by amount asc", usr, usr));
        }

        public DataTable GetUserTransactionDesc(string usr)
        {
            return ExecuteQuery(string.Format("select * from TransactionTable where payer='{0}' or reciever='{1}' order by amount desc", usr, usr));
        }

    }

    public class Merchant : User
    {
        public Merchant(string usr, string psw)
        {
            this.username = usr;
            this.password = psw;
        }

        public DataTable GetAllTransaction()
        {
            DataTable prev = ExecuteQuery(string.Format("select whose from PreviledgeTable where whom='{0}'", this.username));
            string query = string.Format("select * from TransactionTable where reciever='{0}'", this.username);
            foreach (DataRow dr in prev.Rows)
            {
                query += " or reciever='" + dr.ItemArray[0].ToString().Trim() + "'";
            }
            return ExecuteQuery(query);
        }
    }
}