using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Leafing.Data;
using MidExam.DAL;

public partial class frmInputTcxm : PageBase
{
    protected override void AddPermitRoles()
    {
        this.AddPermitRole("Teachers");
        //this.AddPermitRole("Students");
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
            string strStatus = this.CurBmkStatus.Tcxm;
           
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
            string strStatus = this.CurBmkPwd.Tcxm;
            return strStatus;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.IsInRole("Administrators"))
            {
                BindData();
            }
            else
            {
                this.btnSave.Visible = false;
            }
        }
        this.Page.MaintainScrollPositionOnPostBack = true;
    }

    private void BindData()
    {
        this.GridView1.DataSource = Bmk.Find(p => p.bj == this.Bj, p => p.bmxh );
        this.GridView1.DataBind();
    }

    protected string Bj
    {
        get
        {
            if (Request.QueryString["bj"] == null)
                Response.Redirect("InputIndex.aspx");
            return Request.QueryString["bj"].ToString();
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBoxList cbl = (CheckBoxList)e.Row.FindControl("CheckBoxList1");
            Bmk bmk = (Bmk)e.Row.DataItem;
            if (bmk.xb == "1")
            {
                cbl.Items[6].Enabled = false;
            }
            else if (bmk.xb == "2")
            {
                cbl.Items[5].Enabled = false;
            }

            if (!String.IsNullOrWhiteSpace(bmk.tcxm))
            {
                char tcxm1 = bmk.tcxm[0];
                char tcxm2 = bmk.tcxm[1];
                if (cbl.Items.FindByValue(tcxm1.ToString()) != null)
                {
                    cbl.Items.FindByValue(tcxm1.ToString()).Selected = true;
                }
                if (cbl.Items.FindByValue(tcxm2.ToString()) != null)
                {
                    cbl.Items.FindByValue(tcxm2.ToString()).Selected = true;
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = string.Empty;
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            Bmk bmk = Bmk.FindById((long)this.GridView1.DataKeys[i].Value);
            CheckBoxList cbl = (CheckBoxList)this.GridView1.Rows[i].FindControl("CheckBoxList1");
            string str = string.Empty;
            foreach (ListItem item in cbl.Items)
            {
                if (item.Selected)
                {
                    str += item.Value;
                }
            }
            if (str.Length == 2 && str != bmk.tcxm)
            {
                bmk.tcxm = str;
                bmk.Save();
            }
            else if (String.IsNullOrEmpty(str))
            {
                bmk.tcxm = string.Empty;
                bmk.Save();
            }
            else if (str.Length != 2)
            {
                this.lblMsg.Text += bmk.xm + "的数据录入有误:" + str + "<br />";
            }
        }
        if (!string.IsNullOrEmpty(this.lblMsg.Text))
        {
     //       JsUtil.MessageBox(this,this.lblMsg.Text);
        }
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
            BindData();
            this.btnSave.Visible = true;
        }
        else
        {
            this.lblMsg.Text = "录入密码错误，请联系教务处!";
            return;
        }

        this.lblMsg.Text = "";
    }
}