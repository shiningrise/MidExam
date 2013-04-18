using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL.Models;
using System.Text;

public partial class Youyong_Input : PageBase
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
            BindData();
            this.btnSave.Enabled = "input1,input2".Contains(this.User.Identity.Name);
            if (this.btnSave.Enabled == false)
                this.Info("只有input1,input2用户才有权限录入");
        }
    }

    private void BindData()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(i);
        }
        this.DataList1.DataSource = list;
        this.DataList1.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < this.DataList1.Items.Count; i++)
        {
            var dr = this.DataList1.Items[i];
            var txtBmxh = dr.FindControl("Youyong_bmxh") as TextBox;
            string bmxh = txtBmxh.Text;
            if (bmxh.IsNullOrEmpty() == false)
            {
                if (bmxh.Trim().Length != 9)
                {
                    this.Fail(string.Format("报名序号{0}有误，报名序号必须是9位!", bmxh));
                    continue;
                }
                Youyong youyong = Youyong.FindOne(p => p.bmxh == bmxh);
                if (youyong == null)
                {
                    this.Fail(string.Format("报名序号{0}的学生没选考游泳!", bmxh));
                    continue;
                }
                if (youyong.InputCheck == true)
                {
                    this.Fail(string.Format("报名序号{0}的学生成绩{1}已经录入并核对，不再允许录入或修改!", bmxh, youyong.Chengji));
                    continue;
                }
                var txtChengji = dr.FindControl("Youyong_chengji") as TextBox;
                string strChengji = txtChengji.Text;
                var aChengji = strChengji.Split('.');
                if (aChengji.Length != 2)
                {
                    this.Fail(string.Format("报名序号{0}的学生游泳成绩录入格式错误,请以小数点代替分录入,录入时要关闭中文输入法!", bmxh));
                    continue;
                }
                int? chengji = null;
                try
                {
                    chengji = int.Parse(aChengji[1]);
                    if (chengji > 59 && chengji < 0)
                    {
                        this.Fail("秒不能大于等于60小于0");
                        continue;
                    }

                    chengji = int.Parse(aChengji[0]) * 60 + int.Parse(aChengji[1]);
                }
                catch (Exception)
                {
                    //this.Fail(ex.Message);
                    this.Fail(string.Format("报名序号{0}的学生游泳成绩录入格式错误,请以小数点代替分录入,录入时要关闭中文输入法!", bmxh));
                    continue;
                }

                if ("input1" == this.User.Identity.Name)
                {
                    if (youyong.Chengji2 != null && youyong.Chengji2 != chengji)
                    {
                        this.Fail(string.Format("报名序号{0}的学生游泳成绩{1}秒与2录的成绩{2}秒不一致，请核对"
                            , youyong.bmxh, chengji, youyong.Chengji2));
                    }
                    youyong.Chengji1 = chengji;
                    
                    youyong.InputDateTime1 = System.DateTime.Now;
                    this.Succeed(string.Format("1录成功,报名序号{0} 姓名{1} 性别{2} 成绩{3}分{4}秒 得分{5}"
                        , youyong.bmxh, youyong.xm, GetXb(youyong.xb), chengji / 60, chengji % 60, Defen(youyong, chengji)));
                }

                if ("input2" == this.User.Identity.Name)
                {
                    if (youyong.Chengji1 != null && youyong.Chengji1 != chengji)
                    {
                        this.Fail(string.Format("报名序号{0}的学生游泳成绩{1}秒与1录的成绩{2}秒不一致，请核对"
                            , youyong.bmxh, chengji, youyong.Chengji1));
                    }
                    youyong.Chengji2 = chengji;
                    youyong.InputDateTime2 = System.DateTime.Now;
                    this.Succeed(string.Format("1录成功,报名序号{0} 姓名{1} 性别{2} 成绩{3}分{4}秒 得分{5}"
                        , youyong.bmxh, youyong.xm, GetXb(youyong.xb), chengji / 60, chengji % 60, Defen(youyong, chengji)));
                }
                if (youyong.Chengji1 != null && youyong.Chengji2 != null 
                    && youyong.Chengji1 == youyong.Chengji2)
                {
                    youyong.Chengji = youyong.Chengji1;
                    youyong.Fenshu = Defen(youyong, youyong.Chengji);
                    youyong.InputCheck = true;
                }
                else
                {
                    youyong.InputCheck = false;
                }
                txtBmxh.Text = string.Empty;
                txtChengji.Text = string.Empty;
                youyong.Save();
            }
        }
        this.Succeed();
    }

    private object GetXb(string xb)
    {
        if (xb == "1")
            return "男";
        else if (xb == "2")
            return "女";
        else
            return "性别有误";
    }

    /// <summary>
    /// 根据游泳成绩算得分
    /// </summary>
    /// <param name="youyong"></param>
    /// <param name="chengji"></param>
    /// <returns></returns>
    private int? Defen(Youyong youyong, int? chengji)
    {
        int? fenshu = -1;
        //男生 210 - 300
        if (youyong.xb == "1")
        {
            if (chengji > 300)
                fenshu = 0;
            fenshu = (300 - chengji) / 10 + 1;
            if (fenshu > 10)
                fenshu = 10;
        }
        else if (youyong.xb == "2")
        {
            //女生 240 - 330
            if (chengji > 330)
                fenshu = 0;
            fenshu = (330 - chengji) / 10 + 1;
            if (fenshu > 10)
                fenshu = 10;
        }
        
        return fenshu;
    }

}