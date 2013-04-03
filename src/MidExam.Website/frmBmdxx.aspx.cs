﻿using System;
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

            model.TiyuState = this.ed_TiyuState.GetValue<RecordState>();
            model.TiyuWiki = this.ed_TiyuWiki.GetValue();
            model.SuziState = this.ed_SuziState.GetValue<RecordState>();
            model.SuziWiki = this.ed_SuziWiki.GetValue();
            model.ZhaoguState = this.ed_ZhaoguState.GetValue<RecordState>(); 
            model.ZhaoguWiki = this.ed_ZhaoguWiki.GetValue();
            model.JiafenState = this.ed_JiafenState.GetValue<RecordState>(); ;
            model.JiafenWiki = this.ed_JiafenWiki.GetValue();
            model.YoushiState = this.ed_YoushiState.GetValue<RecordState>();
            model.YoushiWiki = this.ed_YoushiWiki.GetValue();
            model.Wiki1 = this.ed_Wiki1.GetValue();
            model.Wiki2 = this.ed_Wiki2.GetValue();
            model.State = this.ed_State.GetValue<SystemState>();
            model.Save();
            this.Succeed();
 
        }
        catch(Exception ex)
        {
            this.Fail("保存失败!" + ex.Message);
        }
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //this.Save();
        //this.BindData();   
    }
}