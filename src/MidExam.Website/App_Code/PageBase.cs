using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL;
using System.IO;
using System.ComponentModel;
using MidExam.DAL.Util;
using Leafing.Data.Definition;
using System.Collections;
using System.Text;

/// <summary>
///PageBase 的摘要说明
/// </summary>
public class PageBase : Leafing.Web.SmartPageBase
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

    /// <summary>
    /// 获取绝对URL
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    protected string Url(string url)
    {
        return ResolveUrl(url);
    }
    

    #region 权限
    protected virtual void AddPermitRoles()
    {
        this.AddPermitRole("Administrators");
    }

    protected void AddPermitRole(string roleName)
    {
        this.PermitRoles.Add(roleName);
    }

    protected List<string> PermitRoles = new List<string>();

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

    #endregion
    
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

    public enum AlertType
    {
        Warning,
        Info,
        Error,
        Danger,
        Success,
    }

    protected void Alert(string Content,AlertType alertType)
    {
        StringBuilder sb = new StringBuilder();
        switch (alertType)
        {
            case AlertType.Warning:
                sb.AppendLine("    <div class=\"alert alert-block\">");
                break;
            case AlertType.Info:
                sb.AppendLine("    <div class=\"alert alert-info\">");
                break;
            case AlertType.Danger:
            case AlertType.Error:
                sb.AppendLine("    <div class=\"alert alert-error\">");
                break;
            case AlertType.Success:
                sb.AppendLine("    <div class=\"alert alert-success\">");
                break;
            default:
                sb.AppendLine("    <div class=\"alert\">");
                break;
        }
        sb.AppendLine(" <button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>");
        sb.AppendLine(Content);
        sb.AppendLine("    </div>");
        System.Web.UI.WebControls.Literal ErrMsg = (System.Web.UI.WebControls.Literal)this.Page.Form.FindControl("ErrMsg");
        if (ErrMsg == null)
        {
            ErrMsg = new System.Web.UI.WebControls.Literal();
            this.Page.Form.Controls.AddAt(0, ErrMsg);
        }
        ErrMsg.Text = sb.ToString();
    }

    #region 辅助方法

    protected void Succeed()
    {
        Alert("操作成功.", AlertType.Success);
        //this.MessageBox("操作成功");
    }

    protected void Succeed(string msg)
    {
        Alert("操作成功." + msg, AlertType.Success);
        //this.MessageBox("操作成功:" + msg);
    }

    protected void Fail(string msg)
    {
        Alert("操作失败:" + msg, AlertType.Error);
        //this.MessageBox("操作失败:" + strMsg);
    }

    protected void Fail(Leafing.Data.ValidateHandler vh, string strMsg)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<ul>");
        foreach (var item in vh.ErrorMessages)
        {
            sb.AppendLine("<li>" + item.Value + "</li>");
        }
        sb.AppendLine("</ul>");
        this.MessageBox(sb.ToString());
    }

    protected void BindSelectDropDownList(DropDownList dl, IList li, string valueField, string TextField)
    {
        dl.DataSource = li;
        dl.DataValueField = valueField;
        dl.DataTextField = TextField;
        dl.DataBind();

        ListItem listItem = new ListItem();
        listItem.Text = "请选择";
        listItem.Value = "-1";
        dl.Items.Insert(0, listItem);
    }

    protected void BindSelectDropDownList(DropDownList dl, IList li)
    {
        dl.DataSource = li;
        dl.DataBind();

        ListItem listItem = new ListItem();
        listItem.Text = "请选择";
        listItem.Value = "-1";
        dl.Items.Insert(0, listItem);
    }
    
    /// <summary>
    /// 显示信息框
    /// </summary>
    /// <param name="msg"></param>
    protected void MessageBox(string msg)
    {
        JsUtil.MessageBox(this, msg);
    }

    #endregion
    
    #region 文件下载
    
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

    protected void Download(string txtContent)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "GB2312";
        Response.AppendHeader("Content-Disposition", "attachment;filename=bmk2516.txt");
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "text/plain"; //设置输出文件类型为txt文件。
        this.EnableViewState = false;
        System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN", true);
        Response.Write(txtContent);
        Response.End();
    }

    #endregion

    #region Page Model

    private string _controlNamePrefix = "ed_";
    /// <summary>
    /// 自动绑定的 控件名前缀
    /// </summary>
    public virtual string ControlNamePrefix
    {
        get { return _controlNamePrefix; }
        set { _controlNamePrefix = value; }
    }

    /// <summary>
    /// 实体Model字段数据自动绑定到Page页面中的控件
    /// </summary>
    protected void Model2Page(DbObjectBase model)
    {
        PropertyDescriptorCollection modelProperties = TypeDescriptor.GetProperties(model);
        foreach (PropertyDescriptor pd in modelProperties)
        {
            string ctrlName = string.Format("{0}{1}", this.ControlNamePrefix, pd.Name);
            WebControl ctl = (WebControl)PageHelper.GetWebControl(this.Page, ctrlName);
            if (ctl != null)
            {
                object value = pd.GetValue(model);
                if (value != null)
                    ctl.SetValue(value.ToString());
            }
        }
    }

    /// <summary>
    /// Page页面中的控件 自动绑定到 实体Model字段数据
    /// </summary>
    protected void Page2Model(DbObjectBase model)
    {
        PropertyDescriptorCollection modelProperties = TypeDescriptor.GetProperties(model);

        //Response.Clear();
        foreach (PropertyDescriptor pd in modelProperties)
        {
            string ctrlName = string.Format("{0}{1}", this.ControlNamePrefix, pd.Name);
            WebControl ctl = (WebControl)PageHelper.GetWebControl(this.Page, ctrlName);
            if (ctl != null)
            {
                object value = ctl.GetValue();
                pd.SetValue(model, value);
            }
        }
    }

    #endregion
}