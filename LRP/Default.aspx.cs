using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
    }
    protected void Button_OK_Click(object sender, EventArgs e)
    {
        string role = "None";
        if (TextBox1.Text == "" && TextBox2.Text == "")
        {
            Label1.Visible = true;
            Label1.Text = "Please enter username & password";
        }
        if(TextBox1.Text != "" && TextBox2.Text != "")
        {
            FairFest.userclasses.clsLogin logInObject = new FairFest.userclasses.clsLogin();
            role = logInObject.check_login(TextBox1.Text, TextBox2.Text);
            if (role.Contains("None") || role.Contains("Error In Connection:"))
            {
                Label1.Text = "LogIn Failure";
                Label1.Visible = true;
            }
            if(role.Contains("Admin"))
            {
                Session.Add("username", TextBox1.Text);
                Session.Add("password", TextBox2.Text);
                Response.Redirect("Admin.aspx");
            }
            if(role.Contains("Merchant"))
            {
                Session.Add("username", TextBox1.Text);
                Session.Add("password", TextBox2.Text);
                Response.Redirect("Merchant.aspx");  
            }
        }
        //Response.Redirect("login.aspx?exp=session");
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
}
