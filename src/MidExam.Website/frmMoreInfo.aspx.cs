using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Leafing.Data;
using MidExam.DAL;

public partial class frmMoreInfo : PageBase
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
            this.GridView1.DataSource = Bmk.Find(Condition.Empty,"bmxh"); // Bmk.Find(p => p.bj == this.Bj);
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
}