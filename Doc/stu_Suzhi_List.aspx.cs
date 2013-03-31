using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL.Models;
using Leafing.Data;

public partial class stu_Suzhi_List : StudentPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        this.GridView1.DataSource = Suzhi.Find(p => p.Id > 0 , p => p.bmxh);
        this.GridView1.DataBind();
    }
}
