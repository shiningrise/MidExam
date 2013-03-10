using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teacher : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.User.IsInRole("Teachers") && !Page.User.IsInRole("Administrators"))
        //{
        //    Response.Redirect("Default.aspx");
        //}
    }
}
