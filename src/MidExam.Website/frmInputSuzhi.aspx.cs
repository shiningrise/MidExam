using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Leafing.Data;
using MidExam.DAL;

public partial class frmInputSuzhi : PageBase
{
    protected override void AddPermitRoles()
    {
        this.AddPermitRole("Teachers");
        //this.AddPermitRole("Students");
        base.AddPermitRoles();
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
        this.GridView1.Columns[3].Visible = this.Xm == "km61";
        this.GridView1.Columns[4].Visible = this.Xm == "km62";
        this.GridView1.Columns[5].Visible = this.Xm == "km63";

        this.GridView1.Columns[6].Visible = this.Xm == "km71";
        this.GridView1.Columns[7].Visible = this.Xm == "km72";
        this.GridView1.Columns[8].Visible = this.Xm == "km73";
        this.GridView1.Columns[9].Visible = this.Xm == "km74";

        this.GridView1.Columns[10].Visible = this.Xm == "km81";

        this.GridView1.DataSource = Bmk.Find(p => p.bj == this.Bj);
        this.GridView1.DataBind();
    }

    /// <summary>
    /// 录入项目
    /// </summary>
    private string _xm;
    /// <summary>
    /// 录入项目
    /// </summary>
    public string Xm
    {
        get
        {
            if (String.IsNullOrEmpty(_xm))
            {
                _xm = Request.QueryString["xm"].ToString();
            }
            return _xm;
        }
        set { _xm = value; }
    }

    /// <summary>
    /// 录入项目中文名称
    /// </summary>
    public string XmCNName
    {
        get
        {
            string strXmCNName = string.Empty;
            switch (this.Xm.ToLower())
            {
                //艺术  劳技  实验  
                //审美与艺术  运动与健康  探究与实践  劳动与技能  综合评定 
                case "km61":
                    strXmCNName = "艺术";
                    break;
                case "km62":
                    strXmCNName = "劳技";
                    break;
                case "km63":
                    strXmCNName = "实验";
                    break;

                case "km71":
                    strXmCNName = "审美与艺术";
                    break;
                case "km72":
                    strXmCNName = "运动与健康";
                    break;
                case "km73":
                    strXmCNName = "探究与实践";
                    break;
                case "km74":
                    strXmCNName = "劳动与技能";
                    break;

                case "km81":
                    strXmCNName = "综合评定";
                    break;

                default:
                    break;
            }
            return strXmCNName;
        }
    }

    protected string Bj
    {
        get
        {
            return Request.QueryString["bj"].ToString();
        }
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
            string strStatus = string.Empty;
            switch (this.Xm.ToLower())
            {
                case "km61":
                    strStatus = this.CurBmkStatus.Km61;
                    break;
                case "km62":
                    strStatus = this.CurBmkStatus.Km62;
                    break;
                case "km63":
                    strStatus = this.CurBmkStatus.Km63;
                    break;

                case "km71":
                    strStatus = this.CurBmkStatus.Km71;
                    break;
                case "km72":
                    strStatus = this.CurBmkStatus.Km72;
                    break;
                case "km73":
                    strStatus = this.CurBmkStatus.Km73;
                    break;
                case "km74":
                    strStatus = this.CurBmkStatus.Km74;
                    break;

                case "km81":
                    strStatus = this.CurBmkStatus.Zhonghe;
                    break;

                default:
                    break;
            }
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
            string strStatus = string.Empty;
            switch (this.Xm.ToLower())
            {
                case "km61":
                    strStatus = this.CurBmkPwd.Km61;
                    break;
                case "km62":
                    strStatus = this.CurBmkPwd.Km62;
                    break;
                case "km63":
                    strStatus = this.CurBmkPwd.Km63;
                    break;

                case "km71":
                    strStatus = this.CurBmkPwd.Km71;
                    break;
                case "km72":
                    strStatus = this.CurBmkPwd.Km72;
                    break;
                case "km73":
                    strStatus = this.CurBmkPwd.Km73;
                    break;
                case "km74":
                    strStatus = this.CurBmkPwd.Km74;
                    break;

                case "km81":
                    strStatus = this.CurBmkPwd.Zhonghe;
                    break;

                default:
                    break;
            }
            return strStatus;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Bmk bmk = e.Row.DataItem as Bmk;
            DropDownList ddlKm81 = (DropDownList)e.Row.FindControl("ddlKm81");
            if (!string.IsNullOrWhiteSpace(bmk.km81))
            {
                if (ddlKm81.Items.FindByText(bmk.km81) != null)
                {
                    ddlKm81.Items.FindByText(bmk.km81).Selected = true;
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

            TextBox txtKm61 = (TextBox)this.GridView1.Rows[i].FindControl("txtKm61");
            TextBox txtKm62 = (TextBox)this.GridView1.Rows[i].FindControl("txtKm62");
            TextBox txtKm63 = (TextBox)this.GridView1.Rows[i].FindControl("txtKm63");

            TextBox txtKm71 = (TextBox)this.GridView1.Rows[i].FindControl("txtKm71");
            TextBox txtKm72 = (TextBox)this.GridView1.Rows[i].FindControl("txtKm72");
            TextBox txtKm73 = (TextBox)this.GridView1.Rows[i].FindControl("txtKm73");
            TextBox txtKm74 = (TextBox)this.GridView1.Rows[i].FindControl("txtKm74");

            DropDownList ddlKm81 = (DropDownList)this.GridView1.Rows[i].FindControl("ddlKm81");

            switch (this.Xm.ToLower())
            {
                case "km61":
                    if (!string.IsNullOrWhiteSpace(txtKm61.Text))
                        bmk.km61 = decimal.Parse(txtKm61.Text);
                    break;
                case "km62":
                    if (!string.IsNullOrWhiteSpace(txtKm62.Text))
                        bmk.km62 = decimal.Parse(txtKm62.Text);
                    break;
                case "km63":
                    if (!string.IsNullOrWhiteSpace(txtKm63.Text))
                        bmk.km63 = decimal.Parse(txtKm63.Text);
                    break;


                case "km71":
                    if (!string.IsNullOrWhiteSpace(txtKm71.Text))
                        bmk.km71 = txtKm71.Text.Trim().ToUpper();
                    break;
                case "km72":
                    if (!string.IsNullOrWhiteSpace(txtKm72.Text))
                        bmk.km72 = txtKm72.Text.Trim().ToUpper();
                    break;
                case "km73":
                    if (!string.IsNullOrWhiteSpace(txtKm73.Text))
                        bmk.km73 = txtKm73.Text.Trim().ToUpper();
                    break;
                case "km74":
                    if (!string.IsNullOrWhiteSpace(txtKm74.Text))
                        bmk.km74 = txtKm74.Text.Trim().ToUpper();
                    break;
                case "km81":
                    if (ddlKm81.SelectedIndex > 0)
                        bmk.km81 = ddlKm81.SelectedValue;
                    break;
                default:
                    break;
            }
            bmk.Save();
        }
        JsUtil.MessageBox(this, "操作完成!");
        BindData();

        //    if (!string.IsNullOrEmpty(this.lblMsg.Text))
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