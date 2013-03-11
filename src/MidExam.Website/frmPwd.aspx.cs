using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Leafing.Data;
using MidExam.DAL;

public partial class frmPwd : PageBase
{
    protected override void AddPermitRoles()
    {
        //this.AddPermitRole("Teachers");
        
        base.AddPermitRoles();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        this.GridView1.DataSource = BmkPwd.Find(Condition.Empty);
        this.GridView1.DataBind();
    }
    protected void btnInput_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        PasswordGenerator pg = new PasswordGenerator();
        pg.ExcludeSymbols = true;
        pg.Maximum = 4;
        pg.Minimum = 2;
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            BmkPwd bmkPwd = BmkPwd.FindById((long)this.GridView1.DataKeys[i].Value);
            CheckBox chkBase = (CheckBox)this.GridView1.Rows[i].FindControl("chkBase");
            CheckBox chkBaseFoot = (CheckBox)this.GridView1.FooterRow.FindControl("chkBase");
            if (chkBase.Checked || chkBaseFoot.Checked)
            {
                bmkPwd.Base = pg.Generate();
            }
            CheckBox chkHome = (CheckBox)this.GridView1.Rows[i].FindControl("chkHome");
            CheckBox chkHomeFoot = (CheckBox)this.GridView1.FooterRow.FindControl("chkHome");
            if (chkHome.Checked || chkHomeFoot.Checked)
            {
                bmkPwd.Home = pg.Generate();
            }
            CheckBox chkCzhj = (CheckBox)this.GridView1.Rows[i].FindControl("chkCzhj");
            CheckBox chkCzhjFoot = (CheckBox)this.GridView1.FooterRow.FindControl("chkCzhj");
            if (chkCzhj.Checked || chkCzhjFoot.Checked)
            {
                bmkPwd.Czhj = pg.Generate();
            }
            CheckBox chkXqah = (CheckBox)this.GridView1.Rows[i].FindControl("chkXqah");
            CheckBox chkXqahFoot = (CheckBox)this.GridView1.FooterRow.FindControl("chkXqah");
            if (chkXqah.Checked || chkXqahFoot.Checked)
            {
                bmkPwd.Xqah = pg.Generate();
            }
            CheckBox chkTcxm = (CheckBox)this.GridView1.Rows[i].FindControl("chkTcxm");
            CheckBox chkTcxmFoot = (CheckBox)this.GridView1.FooterRow.FindControl("chkTcxm");
            if (chkTcxm.Checked || chkTcxmFoot.Checked)
            {
                bmkPwd.Tcxm =  pg.Generate();
            }
            //
            CheckBox chkKm61 = (CheckBox)this.GridView1.Rows[i].FindControl("chkKm61");
            CheckBox chkKm61Foot = (CheckBox)this.GridView1.FooterRow.FindControl("chkKm61");
            if (chkKm61.Checked || chkKm61Foot.Checked)
            {
                bmkPwd.Km61 = pg.Generate();
            }
            CheckBox chkKm62 = (CheckBox)this.GridView1.Rows[i].FindControl("chkKm62");
            CheckBox chkKm62Foot = (CheckBox)this.GridView1.FooterRow.FindControl("chkKm62");
            if (chkKm62.Checked || chkKm62Foot.Checked)
            {
                bmkPwd.Km62 = pg.Generate();
            }
            CheckBox chkKm63 = (CheckBox)this.GridView1.Rows[i].FindControl("chkKm63");
            CheckBox chkKm63Foot = (CheckBox)this.GridView1.FooterRow.FindControl("chkKm63");
            if (chkKm63.Checked || chkKm63Foot.Checked)
            {
                bmkPwd.Km63 = pg.Generate();
            }
            //
            //
            CheckBox chkKm71 = (CheckBox)this.GridView1.Rows[i].FindControl("chkKm71");
            CheckBox chkKm71Foot = (CheckBox)this.GridView1.FooterRow.FindControl("chkKm71");
            if (chkKm71.Checked || chkKm71Foot.Checked)
            {
                bmkPwd.Km71 = pg.Generate();
            }
            CheckBox chkKm72 = (CheckBox)this.GridView1.Rows[i].FindControl("chkKm72");
            CheckBox chkKm72Foot = (CheckBox)this.GridView1.FooterRow.FindControl("chkKm72");
            if (chkKm72.Checked || chkKm72Foot.Checked)
            {
                bmkPwd.Km72 = pg.Generate();
            }
            CheckBox chkKm73 = (CheckBox)this.GridView1.Rows[i].FindControl("chkKm73");
            CheckBox chkKm73Foot = (CheckBox)this.GridView1.FooterRow.FindControl("chkKm73");
            if (chkKm73.Checked || chkKm73Foot.Checked)
            {
                bmkPwd.Km73 = pg.Generate();
            }
            CheckBox chkKm74 = (CheckBox)this.GridView1.Rows[i].FindControl("chkKm74");
            CheckBox chkKm74Foot = (CheckBox)this.GridView1.FooterRow.FindControl("chkKm74");
            if (chkKm74.Checked || chkKm74Foot.Checked)
            {
                bmkPwd.Km74 = pg.Generate();
            }

            //
            CheckBox chkZhonghe = (CheckBox)this.GridView1.Rows[i].FindControl("chkZhonghe");
            CheckBox chkZhongheFoot = (CheckBox)this.GridView1.FooterRow.FindControl("chkZhonghe");
            if (chkZhonghe.Checked || chkZhongheFoot.Checked)
            {
                bmkPwd.Zhonghe = pg.Generate();
            }
            CheckBox chkZy = (CheckBox)this.GridView1.Rows[i].FindControl("chkZy");
            CheckBox chkZyFoot = (CheckBox)this.GridView1.FooterRow.FindControl("chkZy");
            if (chkZy.Checked || chkZyFoot.Checked)
            {
                bmkPwd.Zy = pg.Generate();
            }

            bmkPwd.Save();
        }
        BindData();
    }


    /// <summary>
    /// 状态初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnInit_Click(object sender, EventArgs e)
    {
        for (int i = 1; i <= MidExam.DAL.Bmk.BanjiCount; i++)
        {
            BmkPwd bmkPwd = BmkPwd.FindOne(p => p.bj == i.ToString().PadLeft(2, '0'));
            if (bmkPwd == null)
            {
                bmkPwd = new BmkPwd();
                bmkPwd.bj = i.ToString().PadLeft(2, '0');
            }
            bmkPwd.Save();
        }
        BindData();
        //   JsUtil.MessageBox(this,"OK!");
    }
}