using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL;
using MidExam.DAL.Models;
using Leafing.Web;
using MidExam.DAL.Util;

public partial class stu_Suzhi_Edit : StudentPageBase
{
    private long _Id;
    public long Id
    {
        get {
            if (Request.QueryString["Id"] != null)
            {
                _Id = Request.QueryString["Id"].ToLong();
            }
            return _Id; 
        }
        set { _Id = value; }
    }   
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    protected override void OnPreLoad(EventArgs e)
    {
        if (!IsPostBack)
        {
            this.btnSubmit.Visible = false;
            this.BindSelectDropDownList(this.ed_Fangshi, Suzhi.ListFangshi());
            this.BindSelectDropDownList(this.ed_Xiangmu, Suzhi.ListXiangmu());
            this.BindSelectDropDownList(this.ed_Dengdi, Suzhi.ListDengdi());
        }
        base.OnPreLoad(e);
    }

    private void BindData()
    {
        this.lblXH.Text = this.CurBmk.bmxh;
        this.lblXM.Text = this.CurBmk.xm;

        Suzhi model = Suzhi.FindById(this.Id);
        if (model != null)
        {
            this.ed_Xiangmu.SetValue(model.Xiangmu);
            this.ed_Fangshi.SetValue(model.Fangshi);
            this.ed_Dengdi.SetValue(model.Dengdi);
            this.ed_Jiangxiang.SetValue(model.Jiangxiang);
            this.ed_Danwei.SetValue(model.Danwei);
            this.ed_Shijian.SetValue(model.Shijian);
            this.ed_Chegnji.SetValue(model.Chegnji);
            this.ed_Shenhe1.SetValue(model.Shenhe1);
            this.ed_Shenhe2.SetValue(model.Shenhe2);
        }
    }

    private void Save()
    {
        Suzhi sz = Suzhi.FindById(this.Id);
        if (this.Id == 0)
            sz = new Suzhi();
        if (sz != null)
        {
            sz.BmkGuid = this.CurBmk.RecordGuid;
            sz.bmxxdm = this.CurBmk.bmxh.Substring(0, 4);
            sz.Status = "保存";
            sz.bmxh = this.CurBmk.bmxh;
            sz.xm = this.CurBmk.xm;

            sz.Fangshi = this.ed_Fangshi.GetValue();
            sz.Xiangmu = this.ed_Xiangmu.GetValue();
            sz.Dengdi = this.ed_Dengdi.GetValue();
            sz.Jiangxiang = this.ed_Jiangxiang.GetValue();
            sz.Danwei = this.ed_Danwei.GetValue();
            sz.Shijian = this.ed_Shijian.GetValue();

            sz.Save();
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        this.Save();
    }
}