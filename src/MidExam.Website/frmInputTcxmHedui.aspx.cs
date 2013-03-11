using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Leafing.Data;
using MidExam.DAL;

public partial class frmInputTcxmHedui : PageBase
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
            var list = Bmk.Find(p => p.bj == this.Bj, "bmxh");
            if (list.Count > 35)
                this.GridView1.RowStyle.Height = (Unit)23;
            else
                this.GridView1.RowStyle.Height = (Unit)28;

            this.GridView1.DataSource = list;
            this.GridView1.DataBind();

            this.tc1 = 0;
            this.tc2 = 0;
            this.tc3 = 0;
            this.tc4 = 0;
            this.tc5 = 0;
            this.tc6 = 0;
            this.tc7 = 0;
        }
    }

    protected string Bj
    {
        get
        {
            return Request.QueryString["bj"].ToString();
        }
    }

    private int tc1;
    private int tc2;
    private int tc3;
    private int tc4;
    private int tc5;
    private int tc6;
    private int tc7;

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Bmk bmk = (Bmk)e.Row.DataItem;
            if (!String.IsNullOrWhiteSpace(bmk.tcxm) && bmk.tcxm.Length == 2)
            {
                char strTcxm1 = bmk.tcxm[0];
                char strTcxm2 = bmk.tcxm[1];
                switch (strTcxm1)
                {
                    case '1':
                        tc1++;
                        break;
                    case '2':
                        tc2++;
                        break;
                    case '3':
                        tc3++;
                        break;
                    case '4':
                        tc4++;
                        break;
                    case '5':
                        tc5++;
                        break;
                    case '6':
                        tc6++;
                        break;
                    case '7':
                        tc7++;
                        break;
                    default:
                        break;
                }
                switch (strTcxm2)
                {
                    case '1':
                        tc1++;
                        break;
                    case '2':
                        tc2++;
                        break;
                    case '3':
                        tc3++;
                        break;
                    case '4':
                        tc4++;
                        break;
                    case '5':
                        tc5++;
                        break;
                    case '6':
                        tc6++;
                        break;
                    case '7':
                        tc7++;
                        break;
                    default:
                        break;
                }

                Label lblTc1 = (Label)e.Row.FindControl("lblTc1");
                lblTc1.Text = bmk.CheckTcxm('1') ? "√" : "";
                Label lblTc2 = (Label)e.Row.FindControl("lblTc2");
                lblTc2.Text = bmk.CheckTcxm('2') ? "√" : "";
                Label lblTc3 = (Label)e.Row.FindControl("lblTc3");
                lblTc3.Text = bmk.CheckTcxm('3') ? "√" : "";
                Label lblTc4 = (Label)e.Row.FindControl("lblTc4");
                lblTc4.Text = bmk.CheckTcxm('4') ? "√" : "";
                Label lblTc5 = (Label)e.Row.FindControl("lblTc5");
                lblTc5.Text = bmk.CheckTcxm('5') ? "√" : "";
                Label lblTc6 = (Label)e.Row.FindControl("lblTc6");
                lblTc6.Text = bmk.CheckTcxm('6') ? "√" : "";
                Label lblTc7 = (Label)e.Row.FindControl("lblTc7");
                lblTc7.Text = bmk.CheckTcxm('7') ? "√" : "";

            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTc1 = (Label)e.Row.FindControl("lblTc1");
            lblTc1.Text = tc1.ToString();
            Label lblTc2 = (Label)e.Row.FindControl("lblTc2");
            lblTc2.Text = tc2.ToString();
            Label lblTc3 = (Label)e.Row.FindControl("lblTc3");
            lblTc3.Text = tc3.ToString();
            Label lblTc4 = (Label)e.Row.FindControl("lblTc4");
            lblTc4.Text = tc4.ToString();
            Label lblTc5 = (Label)e.Row.FindControl("lblTc5");
            lblTc5.Text = tc5.ToString();
            Label lblTc6 = (Label)e.Row.FindControl("lblTc6");
            lblTc6.Text = tc6.ToString();
            Label lblTc7 = (Label)e.Row.FindControl("lblTc7");
            lblTc7.Text = tc7.ToString();
        }
    }

}