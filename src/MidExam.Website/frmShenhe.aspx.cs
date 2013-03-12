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
        if (this.ddlBj.SelectedIndex == this.ddlBj.Items.Count - 1)
        {
            this.GridView1.DataSource = Bmk.Find(Condition.Empty, "bmxh"); // Bmk.Find(p => p.bj == this.Bj);
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

    /// <summary>
    /// 生源情况统计
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlSyqk_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GridView1.EnableViewState = false;
        this.GridView1.DataSource = Bmk.Find(p => p.syqk == this.ddlSyqk.SelectedValue, "bmxh");

        this.GridView1.DataBind();
        lblMsg.Text = string.Format("总共{0}人", this.GridView1.Rows.Count);
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
                    case "0": litSyqk.Text = "0施教区"; break;
                    case "1": litSyqk.Text = "1择校生"; break;
                    case "7": litSyqk.Text = "7回原籍"; break;
                    default:
                        break;
                }
                
            }
        }

    }
}