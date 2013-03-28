using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Leafing.Data;
using MidExam.DAL;
using DbEntryMembership;
using System.Web.Security;
using System.Diagnostics;
using MidExam.DAL.Models;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SystemInit();

            var markdown = new MarkdownSharp.Markdown();
            Bmdxx bmd = Bmdxx.FindOne(Condition.Empty);
            if (bmd != null)
            {
                var html = markdown.Transform(bmd.Wiki1);
                this.ed_Wiki1.Text = html;

                html = markdown.Transform(bmd.Wiki2);
                this.ed_Wiki2.Text = html;
            }
            
        }
        
        if (!Request.IsAuthenticated)
        {
            Response.Redirect("~/Account/Login.aspx");
        }

        //if (Request.IsAuthenticated && !User.IsInRole("Administrators"))
        //{
        //    if (User.IsInRole("Students"))
        //    {
        //        Response.Redirect("frmStudent.aspx");
        //    }
        //    else if (User.IsInRole("Teachers"))
        //    {
        //        Response.Redirect("InputIndex.aspx");
        //    }

        //}

        if (Request.IsAuthenticated)
        {
            this.Login1.Visible = false;
        }

    }

    private static void SystemInit()
    {

        Bmk.GetCount(Condition.Empty);

        if (!Roles.RoleExists("Administrators"))
            Roles.CreateRole("Administrators");
        if (!Roles.RoleExists("Teachers"))
            Roles.CreateRole("Teachers");
        if (!Roles.RoleExists("Students"))
            Roles.CreateRole("Students");
        if (Membership.GetUser("admin") == null)
        {
            Membership.CreateUser("admin", "admin");
        }
        if (!Roles.IsUserInRole("admin", "Administrators"))
            Roles.AddUserToRole("admin", "Administrators");
        if (!Roles.IsUserInRole("admin", "Teachers"))
            Roles.AddUserToRole("admin", "Teachers");
    }

    private static void CreateRole(string roleName)
    {
        if (DbEntryRole.FindOne(p => p.Name == roleName) == null)
        {
            new DbEntryRole { Name = roleName }.Save();
        }
    }

    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        if (this.Login1.UserName == this.Login1.Password)
        {
            Response.Redirect("Account/ChangePassword.aspx");
        }
    }
}
