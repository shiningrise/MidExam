using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Request.IsAuthenticated)
        //{
        //    Response.Redirect("~/Default.aspx");
        //}

        if (Request.QueryString["bmxh"] != null )
        {
            this.NavigationMenu.Items[1].NavigateUrl = String.Format("frmStudent.aspx?bmxh={0}", Request.QueryString["bmxh"]);
            this.NavigationMenu.Items[2].NavigateUrl = String.Format("frmZhiyuanEdit.aspx?bmxh={0}", Request.QueryString["bmxh"]);
       
        }
        this.NavigationMenu.Items[3].Enabled = Page.User.IsInRole("Students");

    }
}
