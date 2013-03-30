using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL;
using MidExam.DAL.Models;
using Leafing.Web;

public partial class stu_SuzhiEdit : StudentPageBase
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
        //txtBeizhu5.Text = this.CurBmk.bz5;

        this.lblXH.Text = this.CurBmk.bmxh;
        this.lblXM.Text = this.CurBmk.xm;

        ListItem li = new ListItem();

        //Guid bmkGuid = CurBmk.RecordGuid;

        //Suzhi fa = Suzhi.FindOne(p => p.BmkGuid == bmkGuid && p.Xiangmu == this.ed_Xiangmu.SelectedValue);
        Suzhi sz = Suzhi.FindById(id);
        if (sz != null)
        {
            if (this.ed_Xiangmu.SelectedIndex == 0)
            {
                this.MessageBox("请选择类别");
            }
        }
    }

    private void SaveData()
    {

    }

}