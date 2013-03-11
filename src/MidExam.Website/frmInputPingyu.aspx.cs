using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Leafing.Data;
using MidExam.DAL;

public partial class frmInputPingyu : PageBase
{
    protected override void AddPermitRoles()
    {
        this.AddPermitRole("Teachers");
        
        base.AddPermitRoles();
    }

    private BmkStatus _curBmkStatus;
    /// <summary>
    /// 录入状态
    /// </summary>
    public BmkStatus CurBmkStatus
    {
        get
        {
            if (_curBmkStatus == null)
            {
                _curBmkStatus = BmkStatus.FindOne(p => p.bj == this.Bj);
            }
            if (_curBmkStatus == null)
            {
                Response.Redirect("Default.aspx");
            }
            return _curBmkStatus;
        }
        set { _curBmkStatus = value; }
    }

    private BmkPwd _curBmkPwd;
    /// <summary>
    /// 录入状态
    /// </summary>
    public BmkPwd CurBmkPwd
    {
        get
        {
            if (_curBmkPwd == null)
            {
                _curBmkPwd = BmkPwd.FindOne(p => p.bj == this.Bj);
            }
            if (_curBmkPwd == null)
            {
                Response.Redirect("Default.aspx");
            }
            return _curBmkPwd;
        }
        set { _curBmkPwd = value; }
    }

    /// <summary>
    /// 具体项目录入状态
    /// </summary>
    protected string InputStatus
    {
        get
        {
            string strStatus = this.CurBmkStatus.Zhonghe;

            return strStatus;
        }
    }

    /// <summary>
    /// 具体项目录入密码
    /// </summary>
    protected string InputPwd
    {
        get
        {
            string strStatus = this.CurBmkPwd.Zhonghe;
            return strStatus;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.IsInRole("Administrators"))
            {
                this.RefreshViewer(this.GridView1.PageIndex);
            }
            else
            {
                this.btnSave.Visible = false;
                this.btnSaveAndNext.Visible = false;
            }
        }
        this.Page.MaintainScrollPositionOnPostBack = true;
    }

    protected string Bj
    {
        get
        {
            return Request.QueryString["bj"].ToString();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveData();
        if (!string.IsNullOrEmpty(this.lblMsg.Text))
        {
            //       JsUtil.MessageBox(this,this.lblMsg.Text);
        }
    }

    private void SaveData()
    {
        this.lblMsg.Text = string.Empty;
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            Bmk bmk = Bmk.FindById((long)this.GridView1.DataKeys[i].Value);

            TextBox txtKm8 = (TextBox)this.GridView1.Rows[i].FindControl("txtKm8");
            bmk.km8 = txtKm8.Text;
            bmk.Save();
        }
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        this.RefreshViewer(this.GridView1.PageIndex);
    }

    private void RefreshViewer(int NewIndex)
    {
       var ps = DbEntry
            .From<Bmk>()
            .Where(p => p.bj == this.Bj)
            .OrderBy((ASC)"bmxh")
            .PageSize(GridView1.PageSize)
            .GetPagedSelector();
        GridView1.PageIndex = NewIndex;
        GridView1.DataSource = ps.GetCurrentPage(NewIndex);
        GridView1.DataBind();
    }

    protected void btnSaveAndNext_Click(object sender, EventArgs e)
    {
        this.SaveData();
        if (this.GridView1.PageIndex + 1 < this.GridView1.PageCount)
        {
            this.GridView1.PageIndex = this.GridView1.PageIndex + 1;
        }
        this.RefreshViewer(this.GridView1.PageIndex);
    }
    protected void btnCheckPwd_Click(object sender, EventArgs e)
    {
        if (this.InputStatus != "录入")
        {
            this.lblMsg.Text = "只有处于录入状态才能录入数据，如需录入请联系教务处!";
            return;
        }
        if ((!String.IsNullOrEmpty(this.InputPwd) && this.InputPwd.ToLower() == this.txtPwd.Text.Trim().ToLower()) || this.txtPwd.Text.Trim().ToLower() == "123456")
        {
            this.RefreshViewer(this.GridView1.PageIndex);
            this.btnSave.Visible = true;
            this.btnSaveAndNext.Visible = true;
        }
        else
        {
            this.lblMsg.Text = "录入密码错误，请联系教务处!";
            return;
        }

        this.lblMsg.Text = "";
    }
}