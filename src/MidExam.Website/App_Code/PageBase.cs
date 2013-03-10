using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL;

/// <summary>
///PageBase 的摘要说明
/// </summary>
public class PageBase : System.Web.UI.Page
{
	public PageBase()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//

        AddPermitRoles();
        bool permite = this.CheckPermiteRoles();
        if (permite == false)
        {
            HttpContext.Current.Response.Redirect("~/Default.aspx");
        }

        if (this.PermitRoles.Contains("Students") && Bmk.GetCount(p => p.xstbh == this.User.Identity.Name) == 0)
        {
            throw new Exception("中考报名库中没有你的名字，若你是初三学生，请尽快联系教务处解决此问题");
        }
	}

    protected virtual void AddPermitRoles()
    {
        this.AddPermitRole("Administrators");
    }

    protected void AddPermitRole(string roleName)
    {
        this.PermitRoles.Add(roleName);
    }

    protected List<string> PermitRoles= new List<string>();

    protected bool CheckPermiteRoles()
    {
        foreach (var role in this.PermitRoles)
        {
            if (this.User.IsInRole(role))
            {
                return true;
            }
        }
        return false;
    }


}