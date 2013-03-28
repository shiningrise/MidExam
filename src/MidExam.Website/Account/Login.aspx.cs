using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL.Models;
using Leafing.Data;

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
        if (!IsPostBack)
        {
            var markdown = new MarkdownSharp.Markdown();
            Bmdxx bmd = Bmdxx.FindOne(Condition.Empty);
            if (bmd != null)
            {
                var html = markdown.Transform(bmd.Wiki1);
                this.ed_Wiki1.Text = html;

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
