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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DbEntryMembershipUser.GetCount(Condition.Empty) == 0)
        {
            Membership.CreateUser("admin", "admin");
        }
        CreateRole("Administrators");
        CreateRole("Teachers");
        CreateRole("Students");
        Roles.AddUserToRoles("admin", new[] { "Administrators", "Teachers" });

        if (!Request.IsAuthenticated)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
        

        Bmk.GetCount(Condition.Empty);
        Debug.Write(User.IsInRole("Administrators").ToString());
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
