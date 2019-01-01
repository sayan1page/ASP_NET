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

public partial class Admin : System.Web.UI.Page
{
    FairFest.userclasses.Staff us;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        us = new FairFest.userclasses.Staff(Session["username"].ToString(), Session["password"].ToString());
        GridView1.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        us.RemoveUser(TextBox1.Text);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        us.AsignPreviledge(TextBox2.Text, TextBox3.Text);
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        us.RemovePreviledge(TextBox2.Text, TextBox3.Text);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (TextBox4.Text == "")
        {
            DataTable dt = us.GetAllTransactionAsc();
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            GridView1.Visible = true;
            //dt.DefaultView=GridView1;
        }
        else
        {
            DataTable dt = us.GetUserTransactionAsc(TextBox4.Text);
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            GridView1.Visible = true;
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        if (TextBox4.Text == "")
        {
            DataTable dt = us.GetAllTransactionDesc();
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            GridView1.Visible = true;
        }
        else
        {
            DataTable dt = us.GetUserTransactionDesc(TextBox4.Text);
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
            GridView1.Visible = true;
        }

    }
}
