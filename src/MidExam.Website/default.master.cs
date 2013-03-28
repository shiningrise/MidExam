using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _default : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.BuildMenu(this.NavigationMenu);
        if (!IsPostBack)
        { 
            if (!this.Page.User.IsInRole("Students"))
            {

            }
            
        }
    }

    protected bool IncludeBootstrap
    {
        get
        {
            bool flag = true;
            flag = !this.Request.Url.AbsoluteUri.Contains("frmStudent.aspx");
            flag = flag & !this.Request.Url.AbsoluteUri.Contains("frmZhiyuanEdit.aspx");
            return flag;
        }
    }

    private void BuildMenu(Menu menu)
    {
        menu.Items.Clear();
        MenuItem item = null;

        menu.Items.Add(CreateMenuItem("主页", "~/Default.aspx"));

        if (this.Page.User.IsInRole("Administrators"))
        {
            item = CreateMenuItem("系统管理", "");
            menu.Items.Add(item);
            item.ChildItems.Add(CreateMenuItem("录入状态", "~/frmBmkStatus.aspx"));
            item.ChildItems.Add(CreateMenuItem("录入密码", "~/frmPwd.aspx"));
            item.ChildItems.Add(CreateMenuItem("学生账号", "~/frmStudentPwd.aspx"));
            item.ChildItems.Add(CreateMenuItem("学生导入", "~/frmStudentImport.aspx"));
            item.ChildItems.Add(CreateMenuItem("批量设置", "~/frmBatchSeting.aspx"));
            item.ChildItems.Add(CreateMenuItem("报名点设置", "~/frmBmdxx.aspx"));
        }
        if (this.Page.User.IsInRole("Administrators") || this.Page.User.IsInRole("Teachers"))
        {
            item = CreateMenuItem("数据录入", "~/InputIndex.aspx");
            menu.Items.Add(item);
            item = CreateMenuItem("查询汇总","");
            menu.Items.Add(item);

            item.ChildItems.Add(CreateMenuItem("审核报名信息", "~/frmShenhe.aspx"));
            item.ChildItems.Add(CreateMenuItem("体测项目汇总", "~/frmTcxmHuiZong.aspx"));
            item.ChildItems.Add(CreateMenuItem("综合素质汇总", "~/frmSuzhi.aspx"));
            item.ChildItems.Add(CreateMenuItem("补充信息汇总", "~/frmMoreInfo.aspx"));
            item.ChildItems.Add(CreateMenuItem("志愿汇总", "~/frmZhiyuanList.aspx"));
            item.ChildItems.Add(CreateMenuItem("志愿确认表打印", "~/Print/frmZhiyuanPrint.aspx"));
        }
        if (this.Page.User.IsInRole("Students"))
        {
            menu.Items.Add(CreateMenuItem("中考报名", "~/frmStudent.aspx"));
            menu.Items.Add(CreateMenuItem("填报志愿", "~/frmZhiyuanEdit.aspx"));
            menu.Items.Add(CreateMenuItem("直接A等", "~/frmFastA.aspx"));
        }
        if(this.Request.IsAuthenticated)
        {
            menu.Items.Add(CreateMenuItem("更改密码", "~/Account/ChangePassword.aspx"));
        }

    }

    private MenuItem CreateMenuItem(string text, string url)
    {
        MenuItem item = new MenuItem();
        item.Text = text;
        if (url.IsNullOrEmpty() == false)
        {
            item.NavigateUrl = url;
        }
        else
        {
            item.Selectable = false ;
        }
        return item;
    }
}
