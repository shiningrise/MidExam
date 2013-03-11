using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Leafing.Data;
using MidExam.DAL;


public partial class frmInputTcxmEmpty : PageBase
{
    protected override void AddPermitRoles()
    {
        this.AddPermitRole("Teachers");
        
        base.AddPermitRoles();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.GridView1.DataSource = Bmk.Find(p => p.bj == this.Bj, "bmxh");
            this.GridView1.DataBind();
        }
    }

    protected string Bj
    {
        get
        {
            return Request.QueryString["bj"].ToString();
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {

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
        }
    }
}