using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using Leafing.Data;
using MidExam.DAL;

public partial class frmStudentPwd : PageBase
{
    protected override void AddPermitRoles()
    {
        //this.AddPermitRole("Teachers");
        //this.AddPermitRole("Students");
        base.AddPermitRoles();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 0; i < Bmk.BanjiCount; i++)
            {
                this.ddlBj.Items.Add(new ListItem((i + 1).ToString().PadLeft(2, '0')));
            }
            this.ddlBj.Items.Add(new ListItem("所有班级", "00"));
            BindData();
        }
    }

    private void BindData()
    {
        if (this.ddlBj.SelectedIndex == this.ddlBj.Items.Count - 1)
        {
            this.GridView1.DataSource = Bmk.Find( Condition.Empty, "bmxh"); // Bmk.Find(p => p.bj == this.Bj);
        }
        else
        {
            this.GridView1.DataSource = Bmk.Find(p => p.bj == this.ddlBj.SelectedValue, "bmxh");
        }

        this.GridView1.DataBind();
        lblMsg.Text = string.Format("总共{0}人", this.GridView1.Rows.Count);
    }
    protected void ddlBj_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "InitPwd")
        {
            //  InitPwd
            string Xh = e.CommandArgument.ToString().Trim();
            ;
            MembershipUser user = Membership.GetUser(Xh);
            if (user == null)
            {
                user = Membership.CreateUser(Xh, Xh);
            }

            if (!Roles.IsUserInRole(Xh, "Students"))
            {
                Roles.AddUserToRole(Xh, "Students");
            }
            if (user.IsLockedOut)
            {
                user.UnlockUser();
            }
            string pwd = user.ResetPassword();
            if (user.ChangePassword(pwd, Xh))
            {
                //      Response.Write("<script language='javascript'>alert('初始化密码为用户名成功！');</script>");

                //       DataBinder();
                //LogUtil.Add(
                //    String.Format("事件:用户{0}成功初始化了学生{1}的密码", Page.User.Identity.Name, user.UserName)
                //    );
                JsUtil.MessageBox(this, "初始化密码为用户名成功！");
            }
            else
            {
                //       Response.Write("<script language='javascript'>alert('初始化密码为用户名失败！');</script>");
                //LogUtil.Add(
                //    String.Format("事件:用户{0}初始化了学生{1}的密码失败", Page.User.Identity.Name, user.UserName)
                //    );
                JsUtil.MessageBox(this, "初始化密码为用户名失败！");
            }

            this.BindData();
        }
    }
    protected void btnPwd_Click(object sender, EventArgs e)
    {
        PasswordGenerator pg = new PasswordGenerator();
        pg.ExcludeSymbols = true;
        pg.Exclusions = "0oABCDEFGHIJKLMNOPQRSTUVWXYZ`~!@#$^*()-_=+[]{}\\|;:'\",./";
        pg.Maximum = 10;
        pg.Minimum = 6;

        var list = Bmk.Find(Condition.Empty);
        foreach (var stu in list)
        {
            string xh = stu.xstbh.Trim();
            MembershipUser user = Membership.GetUser(xh);
            if (user != null)
            {
                string oldPwd = user.ResetPassword();
                stu.Password = pg.Generate();
                stu.Save();
                user.ChangePassword(oldPwd, stu.Password.Trim());
                if (Roles.IsUserInRole(xh, "Students") == false)
                {
                    Roles.AddUserToRole(xh, "Students");
                }
            }
            else
            {
                stu.Password = pg.Generate();
                stu.Save();
                Membership.CreateUser(xh, stu.Password.Trim());
                if (Roles.IsUserInRole(xh, "Students") == false)
                {
                    Roles.AddUserToRole(xh,"Students");
                }
            }
        }
        this.BindData();
    }
}