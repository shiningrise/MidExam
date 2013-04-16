using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL;
using Leafing.Data;
using MidExam.DAL.Models;

public partial class Youyong_Index : PageBase
{
    protected override void AddPermitRoles()
    {
        this.AddPermitRole("input");

        base.AddPermitRoles();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CountRenshu();
        }
    }

    private void CountRenshu()
    {
        youyongCount.Text = string.Format("游泳人数{0}", Youyong.GetCount(Condition.Empty));
    }

    protected void btnInit_Click(object sender, EventArgs e)
    {
        var list = Bmk.Find(Condition.Empty);
        foreach (var bmk in list)
        {
            if (bmk.tcxm.Contains("2"))
            {
                Youyong youyong = Youyong.FindOne(p => p.bmxh == bmk.bmxh);
                if (youyong == null)
                {
                    youyong = new Youyong();
                }
                youyong.bmxh = bmk.bmxh;
                youyong.xm = bmk.xm;
                youyong.xb = bmk.xb;
                youyong.Save();
            }
        }
        this.Succeed("游泳学生数据初始化成功");
        CountRenshu();
    }
}