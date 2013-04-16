using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL.Models;
using Leafing.Data;

public partial class Youyong_Shenhe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            BindData();
    }

    private void BindData()
    {
        this.GridView1.DataSource = Youyong.Find(Condition.Empty,"bmxh");
        this.GridView1.DataBind();
    }
}