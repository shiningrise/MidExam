using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class User_Index : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "InitPwd")
        {
            //  InitPwd
            string username = e.CommandArgument.ToString().Trim();

            MembershipUser user = Membership.GetUser(username);
            if (user == null)
            {
                user = Membership.CreateUser(username, username);
            }

            if (user.IsLockedOut)
            {
                user.UnlockUser();
            }
            string pwd = user.ResetPassword();
            if (user.ChangePassword(pwd, username))
            {
                //      Response.Write("<script language='javascript'>alert('初始化密码为用户名成功！');</script>");

                //       DataBinder();
                //LogUtil.Add(
                //    String.Format("事件:用户{0}成功初始化了学生{1}的密码", Page.User.Identity.Name, user.UserName)
                //    );
                //JsUtil.MessageBox(this, "初始化密码为用户名成功！");
                Succeed("初始化密码为用户名成功！");
            }
            else
            {
                //       Response.Write("<script language='javascript'>alert('初始化密码为用户名失败！');</script>");
                //LogUtil.Add(
                //    String.Format("事件:用户{0}初始化了学生{1}的密码失败", Page.User.Identity.Name, user.UserName)
                //    );
                this.Fail("初始化密码为用户名失败！");
            }

            this.BindData();
        }
    }

    private void BindData()
    {
        
    }

}