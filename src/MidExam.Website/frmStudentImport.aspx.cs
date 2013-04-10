using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL.Util;
using System.Data;
using System.IO;
using MidExam.DAL;
using System.Configuration;
using Newtonsoft.Json;
using RestSharp;
using MidExam.DAL.Util;

public partial class frmStudentImport : PageBase
{
    protected override void AddPermitRoles()
    {
        this.AddPermitRole("Teachers");
        base.AddPermitRoles();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ed_RestClient.Text = ConfigurationManager.AppSettings["RestClient"].ToString();
            this.ed_RestRequest.Text = ConfigurationManager.AppSettings["RestRequest"].ToString();
        }
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        if (!fileUpload.HasFile)
        {
            JsUtil.MessageBox(this, "请选择指定格式的Excel文件，或json格式文本文件");
            return;
        }
        if (fileUpload.FileContent.Length == 0)
        {
            JsUtil.MessageBox(this, "文件的内容为空");
            return;
        }
        string fileExt = Path.GetExtension(fileUpload.FileName);
        fileExt = fileExt.ToLower();
        string[] fileExtAllow = new[]{".xls;",".xlsx",".txt"};
        if (!fileExtAllow.Contains(fileExt))
        {
            JsUtil.MessageBox(this, "只能上传指定格式文件");
            return;
        }
        string filepath = Path.Combine(Server.MapPath("~/tmp/"), System.DateTime.Now.ToString("yyyyMMdd") + fileExt);
        try
        {
            fileUpload.SaveAs(filepath);
            if (fileExt == ".txt")
            {
                string strContent = File.ReadAllText(filepath);
                ImportFromJson(strContent);
            }
            else
            {
                ImportFromExcel(filepath);
            }
            this.Succeed();
        }
        catch (Exception ex)
        {
            Fail(ex.Message);
        }
        
    }


    /// <summary>
    /// 从excel文件导入
    /// </summary>
    /// <param name="filepath"></param>
    private void ImportFromExcel(string filepath)
    {
        var list = ExcelHelper.GetSheetNameList(filepath);
        string sheetName = "Sheet1";
        if (list.Count == 0)
        {
            throw new Exception("Excel文件中不存在任何表格");
        }
        else
        {
            bool flag = false;
            foreach (var item in list)
            {
                if (item.Name == sheetName)
                {
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                sheetName = list[0].Name;
            }
        }
        DataTable datatable = ExcelHelper.ExcelToDataTable(filepath, sheetName);

        //报名序号	学籍主号 	姓名	 班级	班内编号	 性别	出生日期	 民族	
        //政治面貌	户籍类别	 家庭电话	监护人手机	现居住地址	家庭邮码	 学籍辅号
        int total = 0;//总共
        int import = 0; //导入数据
        if (datatable.Columns.Contains("学籍辅号") && datatable.Columns.Contains("姓名")
            && datatable.Columns.Contains("班级"))
        {
            foreach (DataRow row in datatable.Rows)
            {
                total++;
                string xstbh = row["学籍辅号"].ToString();
                string xm = row["姓名"].ToString();
                string bj = row["班级"].ToString();
                if (!xstbh.IsNullOrEmpty())
                {
                    var stu = Bmk.FindOne(p => p.xstbh == xstbh);
                    if (stu == null)
                    {
                        stu = new Bmk();
                        stu.xstbh = xstbh;
                    }
                    stu.xm = xm;
                    if (bj.IsNullOrEmpty() == false)
                        stu.bj = bj.Substring(bj.IndexOf('(') + 1).TrimEnd(')').PadLeft(2, '0'); ;
                    stu.Save();
                    import++;
                }
            }
            JsUtil.MessageBox(this, string.Format("学生总共{0}人,导入{1}", total, import));
        }
        else
        {
            JsUtil.MessageBox(this, "学籍辅号 姓名 班级 这3列必须存在");
        }
    }

    protected void btnRemoteImport_Click(object sender, EventArgs e)
    {
        var client = new RestClient(this.ed_RestClient.GetValue());
        var request = new RestRequest(this.ed_RestRequest.GetValue(), Method.GET);
        IRestResponse response = client.Execute(request);
        var content = response.Content;
        if (content.IsNullOrEmpty() == false)
        {
            ImportFromJson(content);
            this.Succeed();
        }
        else
        {
            this.Fail();
        }
        
    }

    private static void ImportFromJson(string jsonContent)
    {
        var list = JsonConvert.DeserializeObject<List<Bmk>>(jsonContent);
        foreach (var item in list)
        {
            var bmk = Bmk.FindOne(p => p.RecordGuid == item.RecordGuid);
            if (bmk == null)
            {
                bmk = new Bmk();
            }
            ModelCopier.CopyModel(item, bmk, new[] { "Id" });
            bmk.Save();
        }
    }
}