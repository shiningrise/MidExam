using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Authentication;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Page.User.IsInRole("Students"))
        {
            Response.Redirect("frmStudent.aspx");
        }
        else if (Page.User.IsInRole("Administrators"))
        {
            this.NavigationMenu.Items[2].Enabled = true;
            this.NavigationMenu.Items[3].Enabled = true;
            this.NavigationMenu.Items[4].Enabled = true;
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
}
