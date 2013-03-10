using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Leafing.Data;
using System.Web.Security;
using MidExam.DAL;
using System.Configuration;

public partial class frmZhiyuanEdit : PageBase
{
    protected override void AddPermitRoles()
    {
        this.AddPermitRole("Teachers");
        this.AddPermitRole("Students");
        base.AddPermitRoles();
    }

    private Bmk _curBmk;

    public Bmk CurBmk
    {
        get
        {
            if (_curBmk == null)
            {
                if (User.IsInRole("Students"))
                {
                    _curBmk = Bmk.FindOne(p => p.xstbh == Page.User.Identity.Name);
                }
                else if (Request.QueryString["Id"] != null && (User.IsInRole("Administrators") || User.IsInRole("Teachers")))
                {
                    _curBmk = Bmk.FindById(Convert.ToInt64(Request.QueryString["Id"]));
                }
                else
                {
                    Response.Redirect("frmZhiyuanList.aspx");
                }
            }
            if (_curBmk == null)
            {
                throw new Exception("此学生不存在");
            }
            return _curBmk;
        }
        set { _curBmk = value; }
    }

    private BmkStatus _curBmkStatus;

    public BmkStatus CurBmkStatus
    {
        get
        {
            if (_curBmkStatus == null)
            {
                _curBmkStatus = BmkStatus.FindOne(p => p.bj == this.CurBmk.bj);
            }
            if (_curBmkStatus == null)
            {
                Response.Redirect("Default.aspx");
            }
            return _curBmkStatus;
        }
        set { _curBmkStatus = value; }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (User.IsInRole("Students") && Membership.ValidateUser(this.CurBmk.xstbh.Trim(), this.CurBmk.xstbh.Trim()))
            //{
            //    Response.Redirect("Account/ChangePassword.aspx");
            //}

            this.btnSave.Enabled = User.IsInRole("Administrators") | User.IsInRole("Students");
            BindData();
        }
    }

    private void BindData()
    {
        InitControl();

        txtBeizhu5.Text = this.CurBmk.bz5;

        this.lblXH.Text = this.CurBmk.bmxh;
        this.lblXM.Text = this.CurBmk.xm;

        this.Label1.Text = this.CurBmk.km81;
        this.Label2.Text = string.Format("{0}{1}{2}{3}", this.CurBmk.km71, this.CurBmk.km72, this.CurBmk.km73, this.CurBmk.km74);

        this.ddlZy11.ClearSelection();
        this.ddlZy12.ClearSelection();

        this.ddlZy21.ClearSelection();
        this.ddlZy22.ClearSelection();

        this.ddlZy31.ClearSelection();
        this.ddlZy32.ClearSelection();
        this.ddlZy33.ClearSelection();

        this.rblJb.ClearSelection();
        this.rblFc.ClearSelection();

        if (!string.IsNullOrWhiteSpace(this.CurBmk.zy11) && this.ddlZy11.Items.FindByValue(this.CurBmk.zy11.Trim()) != null)
        {
            this.ddlZy11.Items.FindByValue(this.CurBmk.zy11.Trim()).Selected = true; ;
        }
        if (!string.IsNullOrWhiteSpace(this.CurBmk.zy12) && this.ddlZy12.Items.FindByValue(this.CurBmk.zy12.Trim()) != null)
        {
            this.ddlZy12.Items.FindByValue(this.CurBmk.zy12.Trim()).Selected = true; ;
        }

        if (!string.IsNullOrWhiteSpace(this.CurBmk.zy21) && this.ddlZy21.Items.FindByValue(this.CurBmk.zy21.Trim()) != null)
        {
            this.ddlZy21.Items.FindByValue(this.CurBmk.zy21.Trim()).Selected = true; ;
        }
        if (!string.IsNullOrWhiteSpace(this.CurBmk.zy22) && this.ddlZy22.Items.FindByValue(this.CurBmk.zy22.Trim()) != null)
        {
            this.ddlZy22.Items.FindByValue(this.CurBmk.zy22.Trim()).Selected = true; ;
        }

        if (!string.IsNullOrWhiteSpace(this.CurBmk.zy31) && this.ddlZy31.Items.FindByValue(this.CurBmk.zy31.Trim()) != null)
        {
            this.ddlZy31.Items.FindByValue(this.CurBmk.zy31.Trim()).Selected = true; ;
        }
        if (!string.IsNullOrWhiteSpace(this.CurBmk.zy32) && this.ddlZy32.Items.FindByValue(this.CurBmk.zy32.Trim()) != null)
        {
            this.ddlZy32.Items.FindByValue(this.CurBmk.zy32.Trim()).Selected = true; ;
        }
        if (!string.IsNullOrWhiteSpace(this.CurBmk.zy33) && this.ddlZy33.Items.FindByValue(this.CurBmk.zy33.Trim()) != null)
        {
            this.ddlZy33.Items.FindByValue(this.CurBmk.zy33.Trim()).Selected = true; ;
        }

        if (!string.IsNullOrWhiteSpace(this.CurBmk.jb) && this.rblJb.Items.FindByValue(this.CurBmk.jb.Trim()) != null)
        {
            this.rblJb.Items.FindByValue(this.CurBmk.jb.Trim()).Selected = true; ;
        }
        if (!string.IsNullOrWhiteSpace(this.CurBmk.fc) && this.rblJb.Items.FindByValue(this.CurBmk.fc.Trim()) != null)
        {
            this.rblFc.Items.FindByValue(this.CurBmk.fc.Trim()).Selected = true; ;
        }

        this.btnSave.Enabled = User.IsInRole("Administrators") || this.CurBmk.xstbh.Trim() == this.User.Identity.Name;
        if (this.btnSave.Enabled == false)
        {
            this.btnSave.Text = "仅学生本人才能录入或修改！";
        }
    }

    /// <summary>
    /// 初始化控件读写状态
    /// </summary>
    private void InitControl()
    {
        if (!User.IsInRole("Administrators"))
        {
            //能否录入
            this.ddlZy11.Enabled = this.CurBmkStatus.Zy == "录入";
            this.ddlZy12.Enabled = this.CurBmkStatus.Zy == "录入";
            this.ddlZy21.Enabled = this.CurBmkStatus.Zy == "录入";
            this.ddlZy22.Enabled = this.CurBmkStatus.Zy == "录入";

            this.ddlZy31.Enabled = this.CurBmkStatus.Zy == "录入";
            this.ddlZy32.Enabled = this.CurBmkStatus.Zy == "录入";
            this.ddlZy33.Enabled = this.CurBmkStatus.Zy == "录入";

            this.rblJb.Enabled = this.CurBmkStatus.Zy == "录入";
            this.rblFc.Enabled = this.CurBmkStatus.Zy == "录入";

            this.btnSave.Enabled = this.CurBmkStatus.Zy == "录入";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.CurBmk != null)
        {
            if (this.ddlZy11.SelectedIndex > 0)
            {
                this.CurBmk.zy11 = this.ddlZy11.SelectedValue;
            }
            else
            {
                this.CurBmk.zy11 = string.Empty;
            }

            if (this.ddlZy12.SelectedIndex > 0)
            {
                this.CurBmk.zy12 = this.ddlZy12.SelectedValue;
            }
            else
            {
                this.CurBmk.zy12 = string.Empty;
            }

            if (this.ddlZy21.SelectedIndex > 0)
            {
                this.CurBmk.zy21 = this.ddlZy21.SelectedValue;
            }
            else
            {
                this.CurBmk.zy21 = string.Empty;
            }

            if (this.ddlZy22.SelectedIndex > 0)
            {
                this.CurBmk.zy22 = this.ddlZy22.SelectedValue;
            }
            else
            {
                this.CurBmk.zy22 = string.Empty;
            }

            if (this.ddlZy31.SelectedIndex > 0)
            {
                this.CurBmk.zy31 = this.ddlZy31.SelectedValue;
            }
            else
            {
                this.CurBmk.zy31 = string.Empty;
            }

            if (this.ddlZy32.SelectedIndex > 0)
            {
                this.CurBmk.zy32 = this.ddlZy32.SelectedValue;
            }
            else
            {
                this.CurBmk.zy32 = string.Empty;
            }

            if (this.ddlZy33.SelectedIndex > 0)
            {
                this.CurBmk.zy33 = this.ddlZy33.SelectedValue;
            }
            else
            {
                this.CurBmk.zy33 = string.Empty;
            }

            if (this.rblJb.SelectedIndex >= 0)
                this.CurBmk.jb = this.rblJb.SelectedValue;
            else
            {
                this.CurBmk.jb = "0";
            }

            if (this.rblFc.SelectedIndex >= 0)
                this.CurBmk.fc = this.rblFc.SelectedValue;
            else
            {
                this.CurBmk.fc = "0";
            }
            this.CurBmk.bz5 = txtBeizhu5.Text;
            this.CurBmk.Save();
            BindData();

            JsUtil.MessageBox(this, "数据保存成功!");
        }
    }

}