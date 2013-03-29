using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL;
using MidExam.DAL.Models;

public partial class frmSuzi : StudentPageBase
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();


            //if (User.IsInRole("Students") && Membership.ValidateUser(this.CurBmk.xstbh.Trim(), this.CurBmk.xstbh.Trim()))
            //{
            //    Response.Redirect("Account/ChangePassword.aspx");
            //}

            //this.btnSave.Enabled = User.IsInRole("Administrators") | User.IsInRole("Students");
            //BindData();
        }
    }

    private void BindData()
    {
        txtBeizhu5.Text = this.CurBmk.bz5;

        this.lblXH.Text = this.CurBmk.bmxh;
        this.lblXM.Text = this.CurBmk.xm;

        Guid bmkGuid = CurBmk.RecordGuid;
        if (this.ed_Xiangmu.SelectedIndex == 0)
        {
            this.MessageBox("请选择类别");
        }
        Suzi fa = Suzi.FindOne(p => p.BmkGuid == bmkGuid && p.Xiangmu == this.ed_Xiangmu.SelectedValue);
        if (fa != null)
        {
            //this.ed_Pingju.Text = this.ed_Leibie.SelectedValue
            //this.ed_Shenhe1
        }
    }

    private void SaveData()
    {

    }

}