using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL;
using Leafing.Data;

public partial class frmBatchSeting : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 生成报名序号
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnMakeBmxh_Click(object sender, EventArgs e)
    {
        int xuexiao = 0;
        if (this.txtXuexiao.Text.Length != 4 || int.TryParse(this.txtXuexiao.Text,out xuexiao) != true)
        {
            this.MessageBox("报名序号必须为4位数字");
            return;
        }
        if (this.ddlKelei.SelectedIndex == 0)
        {
            this.MessageBox("请选择科类");
            return;
        }
        if (this.ddlMakeType.SelectedIndex == 0)
        {
            this.MessageBox("请选择生成方式");
            return;
        }
        MakeBmxh(this.txtXuexiao.Text, this.ddlKelei.SelectedValue, this.ddlMakeType.SelectedValue);
    }

    /// <summary>
    /// 生成报名序号
    /// </summary>
    /// <param name="xuexiao"></param>
    /// <param name="kelei"></param>
    /// <param name="makeType"></param>
    private void MakeBmxh(string xuexiao, string kelei, string makeType)
    {
        if (makeType == "4")
        {
            int xh = 1;//序号
            var list1 = Bmk.Find(p => p.hk != "88" && p.hk != "99", "class,xstbh");
            foreach (var bmk in list1)
            {
                bmk.bmxh = string.Format("{0}{1}{2}", xuexiao, kelei, xh.ToString().PadLeft(4, '0'));
                bmk.Save();
                xh++;
            }
            var list2 = Bmk.Find(p => p.hk == "88" || p.hk == "99", "class,xstbh");
            foreach (var bmk in list2)
            {
                bmk.bmxh = string.Format("{0}{1}{2}", xuexiao, kelei, xh.ToString().PadLeft(4, '0'));
                bmk.Save();
                xh++;
            }
            this.MessageBox("OK");
        }
        else
        {
            MessageBox("未实现");
        }
    }
    protected void btnBatchSeting_Click(object sender, EventArgs e)
    {
        var list = Bmk.Find(Condition.Empty);
        foreach (var item in list)
        {
            if (item.byxxdm.IsNullOrEmpty())
            {
                item.byxxdm = this.txtByxxdm.Text;
                item.byxxmc = this.txtByxxmc.Text;
                item.Save();
            }
        }
        this.MessageBox("OK");
    }

    /// <summary>
    /// 邮政编码为空设为
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPost_Click(object sender, EventArgs e)
    {
        if (this.txtPost.Text.Length != 6)
        {
            this.MessageBox("邮政编码必须为6位");
            return;
        }
        var list = Bmk.Find(Condition.Empty);
        foreach (var item in list)
        {
            if (item.post.Length != 6)
            {
                item.post = this.txtPost.Text;
                item.post = this.txtPost.Text;
                item.Save();
            }
        }
        this.MessageBox("OK");
    }
    protected void btnTy_Click(object sender, EventArgs e)
    {
        var list = Bmk.Find(Condition.Empty);
        foreach (var item in list)
        {
            if (item.ty.IsNullOrEmpty())
            {
                item.ty = "0";
                item.Save();
            }
        }
        this.MessageBox("OK");
    }
}