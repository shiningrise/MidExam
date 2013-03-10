using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
  //      RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        if (Request.IsAuthenticated)
        {
            if (User.IsInRole("Students"))
            {
        //        Response.Redirect("frmStudent.aspx");
                Response.Redirect("~/frmZhiyuanEdit.aspx");
            }
        }
    }
    protected void LoginUser_LoggedIn(object sender, EventArgs e)
    {
        if (this.LoginUser.UserName == this.LoginUser.Password)
        {
            Response.Redirect("~/Account/ChangePassword.aspx");
        }
        if (User.IsInRole("Students"))
        {
            //        Response.Redirect("frmStudent.aspx");
            Response.Redirect("~/frmZhiyuanEdit.aspx");
        }
    }
}
