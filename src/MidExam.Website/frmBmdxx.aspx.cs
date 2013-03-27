using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL.Models;
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
            Bmdxx bmd = Bmdxx.FindOne(Condition.Empty);
            if (bmd != null)
            {
                this.ed_UserName.Text = bmd.UserName ;
                this.ed_bmxxdm.Text = bmd.bmxxdm;
                this.ed_bmxxmc.Text = bmd.bmxxmc;
                this.ed_wiki1.Text = bmd.Wiki1;
                this.ed_wiki2.Text = bmd.Wiki2;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Bmdxx bmd = Bmdxx.FindOne(Condition.Empty);
        if (bmd == null)
        {
            bmd = new Bmdxx();
        }
        bmd.UserName = this.ed_UserName.Text;
        bmd.bmxxdm = this.ed_bmxxdm.Text;
        bmd.bmxxmc = this.ed_bmxxmc.Text;
        bmd.Wiki1 = this.ed_wiki1.Text;
        bmd.Wiki2 = this.ed_wiki2.Text;
        //bmd.Save();
        Save(bmd);
            
    }

}