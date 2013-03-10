using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Leafing.Data;
using MidExam.DAL;

public partial class frmZhiyuanListPrint : PageBase
{
    protected override void AddPermitRoles()
    {
        this.AddPermitRole("Teachers");
        //this.AddPermitRole("Students");
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
            BindData();
        }
    }

    private void BindData()
    {
        this.GridView1.EnableViewState = false;
        this.GridView1.DataSource = Bmk.Find(p => p.bj == this.Bj, "bmxh");
        this.GridView1.DataBind();
        this.GridView1.Caption = string.Format("鹿城实验中学2011级{0}班中考志愿确认表（总共{0}人）", this.GridView1.Rows.Count);
    }
    protected void ddlBj_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected string GetSchoolByNum(object objSchoolNum)
    {
        if (objSchoolNum == null)
            return string.Empty;
        string strRtn = string.Empty;
        switch (objSchoolNum.ToString().Trim())
        {
            case "001":
                strRtn = "001温州中学";
                break;
            case "002":
                strRtn = "002温州二中";
                break;

            case "003":
                strRtn = "003温州市第三中学";
                break;
            case "004":
                strRtn = "004温州市第四中学";
                break;
            case "007":
                strRtn = "007温州市第七中学";
                break;
            case "008":
                strRtn = "008温州市第八中学";
                break;
            case "011":
                strRtn = "011温州市第十一中学";
                break;
            case "012":
                strRtn = "012温州市第十二中学";
                break;
            case "014":
                strRtn = "014温州市第十四中学";
                break;
            case "019":
                strRtn = "019温州市第十九中学";
                break;

            case "021":
                strRtn = "012温州市第二十一中学";
                break;
            case "022":
                strRtn = "014温州市第二十二中学";
                break;
            case "023":
                strRtn = "019温州市第二十三中学";
                break;

            default:
                break;
        }

        return strRtn;
    }


}