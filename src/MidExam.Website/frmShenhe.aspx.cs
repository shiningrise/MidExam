using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Leafing.Data;
using MidExam.DAL;

public partial class frmShenhe : PageBase
{
    protected override void AddPermitRoles()
    {
        this.AddPermitRole("Teachers");
        base.AddPermitRoles();
    }

    protected string Bj
    {
        get
        {
            return Request.QueryString["bj"].ToString();
        }
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
        this.GridView1.EnableViewState = false;
        Condition con = null ;
        string orderStr = "";
        switch (this.ddlHk.SelectedValue)
        {
            case "1":
                con &= CK.K["hk"] == "25";
                break;
            case "2":
                con &= CK.K["hk"] != "25";
                con &= CK.K["hk"] != "88";
                con &= CK.K["hk"] != "99";
                break;
            case "3":
                con &= (CK.K["hk"] == "88" | CK.K["hk"] == "99");
                break;
            default:
                break;
        }
        if(this.ddlSyqk.SelectedIndex > 0 )
        {
            con &= CK.K["syqk"] == this.ddlSyqk.SelectedValue;
        }
        if (this.ddlBj.SelectedIndex != this.ddlBj.Items.Count - 1)
        {
            con &= CK.K["class"] == this.ddlBj.SelectedValue;
        }
        switch (this.ddlOrder.SelectedValue)
        {   
            case "0":
                orderStr = "xstbh";
                break;
            case "1":
                orderStr = "bmxh";
                break;
            case "2":
                orderStr = "hk,xstbh";
                break;
            default:
                orderStr = "hk,xstbh";
                break;
        }

        this.GridView1.DataSource = Bmk.Find(con, orderStr);
        this.GridView1.DataBind();
        lblMsg.Text = string.Format("总共{0}人", this.GridView1.Rows.Count);
    }
    protected void ddlBj_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    /// <summary>
    /// 生源情况统计
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlSyqk_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Literal litHk = (Literal)e.Row.FindControl("litHk");
            Bmk bmk = e.Row.DataItem as Bmk;
            if (!string.IsNullOrEmpty(bmk.hk))
            {
                switch (bmk.hk)
                {
                    case "25": litHk.Text = "25鹿城区"; break;
                    case "26": litHk.Text = "26龙湾区"; break;
                    case "27": litHk.Text = "27瓯海区"; break;
                    case "28": litHk.Text = "28洞头县"; break;
                    case "29": litHk.Text = "29乐清市"; break;
                    case "30": litHk.Text = "30永嘉县"; break;
                    case "31": litHk.Text = "31瑞安市"; break;
                    case "32": litHk.Text = "32平阳县"; break;
                    case "33": litHk.Text = "33苍南县"; break;
                    case "34": litHk.Text = "34文成县"; break;
                    case "35": litHk.Text = "35泰顺县"; break;
                    case "36": litHk.Text = "36开发区"; break;    
                    case "88": litHk.Text = "88省内市外"; break;
                    case "99": litHk.Text = "99浙江省外"; break;
                    default: litHk.Text = ""; break;
                }
            }
            if (!string.IsNullOrWhiteSpace(bmk.hk) && !string.IsNullOrWhiteSpace(bmk.syqk))
            {
                if (bmk.hk == "25" && bmk.syqk != "0")
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
                if (bmk.hk != "25" && bmk.syqk == "0")
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }

            Literal litSyqk = (Literal)e.Row.FindControl("litSyqk");
            if (!string.IsNullOrWhiteSpace(bmk.syqk))
            {
                switch (bmk.syqk)
                {
                    case "0": litSyqk.Text = "0本县"; break;
                    case "1": litSyqk.Text = "1外县"; break;
                    case "7": litSyqk.Text = "7回原籍"; break;
                    default:
                        break;
                }
                
            }
        }

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        this.BindData();
    }
}