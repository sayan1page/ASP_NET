using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Data.SqlClient;


public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label6.Visible = false;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string role;
        switch (CheckBoxList1.SelectedIndex)
        {
            case 0:
                role = "Merchant";
                break;
            case 1:
                role = "Consumer";
                break;
            case 2:
                role = "Candidate";
                break;
            default:
                role = "Admin";
                break;
        }

        string strSQL = "insert into UserTable (username,password,previledge,city,state)"+
            string.Format("values('{0}','{1}','{2}','{3}','{4}')", TextBox1.Text,TextBox2.Text,role,TextBox3.Text,TextBox4.Text);
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDBFilename=|DataDirectory|Database.mdf;Integrated Security=true;User Instance=true;");
        SqlCommand cmd = new SqlCommand(strSQL, conn);
        try
            {
                conn.Open();
                int i=cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Label6.Text = "Successfully User Created";
                    Label6.Visible = true;
                }
                conn.Close();
            }
        catch(Exception ex)
        {
            Label6.Text=ex.ToString();
            Label6.Visible=true;
            conn.Close();

        }

          
    }
}
