using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL;
using MidExam.DAL.Models;
using MidExam.DAL.Util;
using Leafing.Web;

public partial class stu_Tiyu_Edit : StudentPageBase
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
        Tiyu model = Tiyu.FindById(this.Id);
        if (model != null)
        {
            this.ed_Id.SetValue(model.Id);
            this.ed_bmxxdm.SetValue(model.bmxxdm);
            this.ed_BmkGuid.SetValue(model.BmkGuid);
            this.ed_bmxh.SetValue(model.bmxh);
            this.ed_xm.SetValue(model.xm);
            this.ed_Leibie.SetValue(model.Leibie);
            this.ed_Pingju.SetValue(model.Pingju);
            this.ed_Beizhu.SetValue(model.Beizhu);
            this.ed_Shenhe1.SetValue(model.Shenhe1);
            this.ed_Shenhe2.SetValue(model.Shenhe2);
            this.ed_Shenhe3.SetValue(model.Shenhe3);
            this.ed_Beizhu0.SetValue(model.Beizhu0);
            this.ed_Beizhu1.SetValue(model.Beizhu1);
            this.ed_Beizhu2.SetValue(model.Beizhu2);
            this.ed_Beizhu3.SetValue(model.Beizhu3);
            this.ed_Status.SetValue(model.Status);
        }
    }

    private void Save()
    {
        Tiyu model = Tiyu.FindById(this.Id);
        if (this.Id == 0)
            model = new Tiyu();
        if (model != null)
        {
            model.BmkGuid = this.CurBmk.RecordGuid;
            model.bmxxdm = this.CurBmk.bmxh.Substring(0, 4);
            model.Status = "保存";
            model.bmxh = this.CurBmk.bmxh;
            model.xm = this.CurBmk.xm;
            //model.Id = this.ed_Id.GetValue();
            model.bmxxdm = this.ed_bmxxdm.GetValue();
            model.BmkGuid = this.ed_BmkGuid.GetValue();
            model.bmxh = this.ed_bmxh.GetValue();
            model.xm = this.ed_xm.GetValue();
            model.Leibie = this.ed_Leibie.GetValue<TiyuLeibie>();
            model.Pingju = this.ed_Pingju.GetValue();
            model.Beizhu = this.ed_Beizhu.GetValue();
            model.Shenhe1 = this.ed_Shenhe1.GetValue<ShenheState>();
            model.Shenhe2 = this.ed_Shenhe2.GetValue<ShenheState>();
            model.Shenhe3 = this.ed_Shenhe3.GetValue<ShenheState>();
            model.Beizhu0 = this.ed_Beizhu0.GetValue();
            model.Beizhu1 = this.ed_Beizhu1.GetValue();
            model.Beizhu2 = this.ed_Beizhu2.GetValue();
            model.Beizhu3 = this.ed_Beizhu3.GetValue();
            model.Status = this.ed_Status.GetValue();
            model.Save();
            this.Succeed();
        }
        else
        {
            this.Fail("保存失败!");
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.Save();
    }
}