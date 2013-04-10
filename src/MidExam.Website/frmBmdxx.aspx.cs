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
using Leafing.Data;

public partial class frmBmdxx : PageBase
{
    protected override void AddPermitRoles()
    {
        base.AddPermitRoles();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.BindSelectDropDownList(this.ed_TiyuState,PageHelper.GetItems(typeof(RecordState)),"Value","Text");
            this.BindSelectDropDownList(this.ed_YoushiState, PageHelper.GetItems(typeof(RecordState)), "Value", "Text");
            this.BindSelectDropDownList(this.ed_ZhaoguState, PageHelper.GetItems(typeof(RecordState)), "Value", "Text");
            this.BindSelectDropDownList(this.ed_SuziState, PageHelper.GetItems(typeof(RecordState)), "Value", "Text");
            this.BindSelectDropDownList(this.ed_JiafenState, PageHelper.GetItems(typeof(RecordState)), "Value", "Text");
            this.BindSelectDropDownList(this.ed_State, PageHelper.GetItems(typeof(SystemState)), "Value", "Text");
            BindData();
        }
    }

    private void BindData()
    {
        Bmdxx model = Bmdxx.FindOne(Condition.Empty);
        if (model != null)
        {
            this.ed_UserName.SetValue(model.UserName);
            this.ed_bmxxdm.SetValue(model.bmxxdm);
            this.ed_bmxxmc.SetValue(model.bmxxmc);

            this.ed_TiyuState.SetValue(model.TiyuState);
            this.ed_TiyuWiki.SetValue(model.TiyuWiki);
            this.ed_SuziState.SetValue(model.SuziState);
            this.ed_SuziWiki.SetValue(model.SuziWiki);
            this.ed_ZhaoguState.SetValue(model.ZhaoguState);
            this.ed_ZhaoguWiki.SetValue(model.ZhaoguWiki);
            this.ed_JiafenState.SetValue(model.JiafenState);
            this.ed_JiafenWiki.SetValue(model.JiafenWiki);
            this.ed_YoushiState.SetValue(model.YoushiState);
            this.ed_YoushiWiki.SetValue(model.YoushiWiki);
            this.ed_Wiki1.SetValue(model.Wiki1);
            this.ed_Wiki2.SetValue(model.Wiki2);
            this.ed_State.SetValue(model.State);
        }
    }

    private void Save()
    {
        Bmdxx model = Bmdxx.FindOne(Condition.Empty); ;
        if (model == null)
        {
            model = new Bmdxx();
        }
        try
        {
            model.UserName = this.ed_UserName.GetValue();
            model.bmxxdm = this.ed_bmxxdm.GetValue();
            model.bmxxmc = this.ed_bmxxmc.GetValue();

            if (this.ed_TiyuState.SelectedIndex == 0)
            {
                Fail("请选择体育免考缓考申报状态");
                return;
            }
            else
                model.TiyuState = this.ed_TiyuState.GetValue<RecordState>();
            model.TiyuWiki = this.ed_TiyuWiki.GetValue();
            if (this.ed_SuziState.SelectedIndex == 0)
            {
                Fail("请选择综合素质评价等第申报是否启用");
                return;
            }
            else
            {
                model.SuziState = this.ed_SuziState.GetValue<RecordState>();
            }
                
            model.SuziWiki = this.ed_SuziWiki.GetValue();
            if (this.ed_ZhaoguState.SelectedIndex == 0)
            {
                Fail("请选择政策照顾申报状态");
                return;
            }
            else
                model.ZhaoguState = this.ed_ZhaoguState.GetValue<RecordState>(); 
            model.ZhaoguWiki = this.ed_ZhaoguWiki.GetValue();
            if (this.ed_JiafenState.SelectedIndex == 0)
            {
                Fail("请选择特长加分申报状态");
                return;
            }
            else
                model.JiafenState = this.ed_JiafenState.GetValue<RecordState>(); ;
            model.JiafenWiki = this.ed_JiafenWiki.GetValue();
            if (this.ed_YoushiState.SelectedIndex == 0)
            {
                Fail("请选择特长加分状态");
                return;
            }
            else
                model.YoushiState = this.ed_YoushiState.GetValue<RecordState>();
            model.YoushiWiki = this.ed_YoushiWiki.GetValue();
            model.Wiki1 = this.ed_Wiki1.GetValue();
            model.Wiki2 = this.ed_Wiki2.GetValue();
            if (this.ed_State.SelectedIndex == 0)
            {
                Fail("请选择系统状态");
                return;
            }
            else
                model.State = this.ed_State.GetValue<SystemState>();
            model.Save();
            this.Save(model);
        }
        catch(Exception ex)
        {
            this.Fail("保存失败!" + ex.Message);
        }
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.Save();
        this.BindData();   
    }
}