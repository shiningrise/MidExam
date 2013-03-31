using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL;
using MidExam.DAL.Models;
using Leafing.Web;

public partial class stu_Suzhi_Edit : StudentPageBase
{
    [HttpParameter(AllowEmpty = true)]
    private long Id;   
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData(Id);
        }
    }

    private void BindData(long id)
    {
		Suzhi model = Suzhi.FindById(this.Id);
        if (model != null)
        {
			this.ed_Bmxh.SetValue(model.Bmxh);
			this.ed_Xm.SetValue(model.Xm);
			this.ed_Xiangmu.SetValue(model.Xiangmu);
			this.ed_Fangshi.SetValue(model.Fangshi);
			this.ed_Dengdi.SetValue(model.Dengdi);
			this.ed_Jiangxiang.SetValue(model.Jiangxiang);
			this.ed_Danwei.SetValue(model.Danwei);
			this.ed_Shijian.SetValue(model.Shijian);
			this.ed_Chegnji.SetValue(model.Chegnji);
			this.ed_Shenhe1.SetValue(model.Shenhe1);
			this.ed_Shenhe2.SetValue(model.Shenhe2);
			this.ed_Status.SetValue(model.Status);
        }
    }

    private void SaveData()
    {
			Suzhi model = Suzhi.FindById(this.Id);
        if (this.Id == 0)
            model = new Suzhi();
        if (model != null)
        {
            model.BmkGuid = this.CurBmk.RecordGuid;
            model.bmxxdm = this.CurBmk.bmxh.Substring(0, 4);
            model.Status = "保存";
            model.bmxh = this.CurBmk.bmxh;
            model.xm = this.CurBmk.xm;

            model.Bmxh = this.ed_Bmxh.GetValue();

            model.Save();
            model.bmxh = this.CurBmk.bmxh;
            model.xm = this.CurBmk.xm;

            model.Xm = this.ed_Xm.GetValue();

            model.Save();
            model.bmxh = this.CurBmk.bmxh;
            model.xm = this.CurBmk.xm;

            model.Xiangmu = this.ed_Xiangmu.GetValue();

            model.Save();
            model.bmxh = this.CurBmk.bmxh;
            model.xm = this.CurBmk.xm;

            model.Fangshi = this.ed_Fangshi.GetValue();

            model.Save();
            model.bmxh = this.CurBmk.bmxh;
            model.xm = this.CurBmk.xm;

            model.Dengdi = this.ed_Dengdi.GetValue();

            model.Save();
            model.bmxh = this.CurBmk.bmxh;
            model.xm = this.CurBmk.xm;

            model.Jiangxiang = this.ed_Jiangxiang.GetValue();

            model.Save();
            model.bmxh = this.CurBmk.bmxh;
            model.xm = this.CurBmk.xm;

            model.Danwei = this.ed_Danwei.GetValue();

            model.Save();
            model.bmxh = this.CurBmk.bmxh;
            model.xm = this.CurBmk.xm;

            model.Shijian = this.ed_Shijian.GetValue();

            model.Save();
            model.bmxh = this.CurBmk.bmxh;
            model.xm = this.CurBmk.xm;

            model.Chegnji = this.ed_Chegnji.GetValue();

            model.Save();
            model.bmxh = this.CurBmk.bmxh;
            model.xm = this.CurBmk.xm;

            model.Shenhe1 = this.ed_Shenhe1.GetValue();

            model.Save();
            model.bmxh = this.CurBmk.bmxh;
            model.xm = this.CurBmk.xm;

            model.Shenhe2 = this.ed_Shenhe2.GetValue();

            model.Save();
            model.bmxh = this.CurBmk.bmxh;
            model.xm = this.CurBmk.xm;

            model.Status = this.ed_Status.GetValue();

            model.Save();
            this.Succeed();
        }
        else
        {
            this.Fail("保存失败!");
        }

    }
}
