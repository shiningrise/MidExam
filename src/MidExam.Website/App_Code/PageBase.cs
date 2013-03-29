using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL;
using System.IO;

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

    /// <summary>
    /// 显示信息框
    /// </summary>
    /// <param name="msg"></param>
    protected void MessageBox(string msg)
    {
        JsUtil.MessageBox(this, msg);
    }


    protected void Save<T>(T dbEntityModel)
        where T : global::Leafing.Data.Definition.DbObjectModel<T, long>, new()
    {
        Leafing.Data.ValidateHandler vh = new Leafing.Data.ValidateHandler();
        if (vh.ValidateObject(dbEntityModel))
        {
            dbEntityModel.Save();
            Succeed();
        }
        else
        {
            string strMsg = string.Empty;
            Fail(vh, strMsg);
        }
    }

    protected void Succeed()
    {
        this.MessageBox("操作成功");
    }

    protected void Fail(string strMsg)
    {
        this.MessageBox("操作失败:" + strMsg);
    }

    protected void Fail(Leafing.Data.ValidateHandler vh, string strMsg)
    {
        foreach (var item in vh.ErrorMessages)
        {
            strMsg += item.Value + "\n\b";
        }
        this.MessageBox(strMsg);
    }

    /// <summary>
    /// 文件下载
    /// </summary>
    /// <param name="filePath">文件在服务器的绝对路径</param>
    public void DownLoadFile(string filePath)
    {
        DownLoadFile(filePath, System.IO.Path.GetFileName(filePath));
    }

    /// <summary>
    /// 文件下载
    /// </summary>
    /// <param name="filePath">文件在服务器的绝对路径</param>
    public void DownLoadFile(string filePath, string saveAsFileName)
    {
        //string filePath = Server.MapPath(".") + "\\" + filePath;
        string UserAgent = Request.ServerVariables["http_user_agent"].ToLower();
        if (UserAgent.IndexOf("firefox") == -1)
            saveAsFileName = HttpUtility.UrlEncode(saveAsFileName, System.Text.Encoding.UTF8);
        if (File.Exists(filePath))
        {
            FileInfo file = new FileInfo(filePath);
            Response.Clear();
            Response.ClearHeaders();
            Response.Buffer = false;
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
            Response.AddHeader("Content-Disposition", "attachment; filename=" + saveAsFileName); //解决中文文件名乱码    
            Response.AddHeader("Content-length", file.Length.ToString());
            Response.ContentType = "appliction/octet-stream";
            Response.WriteFile(file.FullName);
            Response.Flush();
            Response.End();
        }
        else
        {
            Response.Write("文件不存在");
        }
    }

}