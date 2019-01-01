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

public partial class Merchant : System.Web.UI.Page
{
    FairFest.userclasses.Merchant us;

    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        us = new FairFest.userclasses.Merchant(Session["username"].ToString(), Session["password"].ToString());
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = us.GetAllTransaction();
        GridView1.DataSource = dt.DefaultView;
        GridView1.DataBind();
        GridView1.Visible = true;
    }
}
