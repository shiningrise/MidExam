using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using MidExam.DAL;
using Leafing.Data;

public partial class frmStudentExport : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnJsonExport_Click(object sender, EventArgs e)
    {
        var bmkList = Bmk.Find(Condition.Empty);
        Download(JsonConvert.SerializeObject(bmkList));
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
}