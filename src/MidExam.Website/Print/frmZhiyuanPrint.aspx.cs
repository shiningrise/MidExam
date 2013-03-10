using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Leafing.Data;

public partial class Print_frmZhiyuanPrint : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.BmkDS1.Condition = Condition.False;
            this.ReportViewer1.LocalReport.DisplayName = "鹿城实验中学中考志愿确认单";
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        this.BmkDS1.Condition = CK.K["Bmxh"] >= this.TextBox1.Text
            && CK.K["Bmxh"] <= this.TextBox2.Text;
        this.ReportViewer1.LocalReport.Refresh();
    }
}