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
        string[] fileExtAllow = new[] { ".xls;", ".xlsx", ".txt" };
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
            Bmk bmk = null;
            if (item.bmxh.IsNullOrEmpty() == false)
            {
                bmk = Bmk.FindOne(p => p.bmxh == item.bmxh);
            }
            else
            {
                bmk = Bmk.FindOne(p => p.RecordGuid == item.RecordGuid);
            }
            if (bmk == null)
            {
                bmk = new Bmk();
            }
            ModelCopier.CopyModel(item, bmk, new[] { "Id" });
            bmk.Save();
        }
    }
    /// <summary>
    /// 从~/Data/Dbf/userdbfs/bmk.dbf导入数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnImportFromDatapath_Click(object sender, EventArgs e)
    {
        string dbfPath = Server.MapPath("~/Data/Dbf/userdbfs/");
        string dbfTable = "bmk.dbf";

        DataTable dt = DbfHelper.ToDataTable(dbfPath, dbfTable);
        foreach (DataRow dr in dt.Rows)
        {
            string bmxh = dr["bmxh"].ToString();
            Bmk bmk = Bmk.FindOne(p => p.bmxh == bmxh);
            if (bmk == null)
            {
                bmk = new Bmk();
                bmk.RecordGuid = Guid.NewGuid();
                bmk.bmxh = bmxh;
            }
            bmk.xm = dr["xm"].ToString();
            bmk.xb = dr["xb"].ToString();
            bmk.xstbh = dr["xstbh"].ToString();

            bmk.bmxh = dr["bmxh"].ToString();
            bmk.zkzh = dr["zkzh"].ToString();
            bmk.xm = dr["xm"].ToString();
            bmk.sfzh = dr["sfzh"].ToString();
            bmk.xb = dr["xb"].ToString();
            bmk.mz = dr["mz"].ToString();
            bmk.csny = dr["csny"].ToString();
            bmk.ty = dr["ty"].ToString();
            bmk.tcxm = dr["tcxm"].ToString();
            bmk.hk = dr["hk"].ToString();
            bmk.xz = dr["xz"].ToString();
            bmk.kslb = dr["kslb"].ToString();
            bmk.byxxdm = dr["byxxdm"].ToString();
            bmk.byxxmc = dr["byxxmc"].ToString();
            bmk.xh = dr["xh"].ToString();
            bmk.bj = dr["class"].ToString();

            bmk.kl = dr["kl"].ToString();
            bmk.jtzz = dr["jtzz"].ToString();
            bmk.tel = dr["tel"].ToString();
            bmk.post = dr["post"].ToString();
            bmk.bz1 = dr["bz1"].ToString();
            bmk.bz2 = dr["bz2"].ToString();
            bmk.bz3 = dr["bz3"].ToString();
            bmk.bz4 = dr["bz4"].ToString();
            bmk.xstbh = dr["xstbh"].ToString();
            bmk.kddm = dr["kddm"].ToString();
            bmk.kdmc = dr["kdmc"].ToString();
            bmk.scbm = dr["scbm"].ToString();
            bmk.tbsch = dr["tbsch"].ToString();
            bmk.zwh = dr["zwh"].ToString();
            bmk.scmh = dr["scmh"].ToString();
            //bmk.km1 = dr["km1"].to();
            //bmk.km2 = dr["km2"].ToString();
            //bmk.km3 = dr["km3"].ToString();
            //bmk.km31 = dr["km31"].ToString();
            //bmk.km32 = dr["km32"].ToString();
            //bmk.km4 = dr["km4"].ToString();
            //bmk.km5 = dr["km5"].ToString();
            //bmk.km51 = dr["km51"].ToString();
            //bmk.km61 = dr["km61"].ToString();
            //bmk.km62 = dr["km62"].ToString();
            //bmk.km621 = dr["km621"].ToString();
            //bmk.km63 = dr["km63"].ToString();
            //bmk.km6 = dr["km6"].ToString();
            bmk.km71 = dr["km71"].ToString();
            bmk.km72 = dr["km72"].ToString();
            bmk.km73 = dr["km73"].ToString();
            bmk.km74 = dr["km74"].ToString();
            bmk.km81 = dr["km81"].ToString();
            //bmk.tyf = dr["tyf"].ToString();
            //bmk.tzf = dr["tzf"].ToString();
            //bmk.tcf = dr["tcf"].ToString();
            //bmk.zf = dr["zf"].ToString();
            //bmk.tot1 = dr["tot1"].ToString();
            //bmk.tot2 = dr["tot2"].ToString();
            //bmk.mch = dr["mch"].ToString();
            //bmk.tzdm = dr["tzdm"].ToString();
            //bmk.tzmc = dr["tzmc"].ToString();
            bmk.tcdm = dr["tcdm"].ToString();
            bmk.tcmc = dr["tcmc"].ToString();
            bmk.zy11 = dr["zy11"].ToString();
            bmk.zy12 = dr["zy12"].ToString();
            bmk.zy13 = dr["zy13"].ToString();
            bmk.zy21 = dr["zy21"].ToString();
            bmk.zy22 = dr["zy22"].ToString();
            bmk.zy23 = dr["zy23"].ToString();
            bmk.zy31 = dr["zy31"].ToString();
            bmk.zy32 = dr["zy32"].ToString();
            bmk.zy33 = dr["zy33"].ToString();
            bmk.zy41 = dr["zy41"].ToString();
            bmk.zy42 = dr["zy42"].ToString();
            bmk.zy43 = dr["zy43"].ToString();
            bmk.zy51 = dr["zy51"].ToString();
            bmk.zy52 = dr["zy52"].ToString();
            bmk.zy53 = dr["zy53"].ToString();
            bmk.fc = dr["fc"].ToString();
            bmk.jb = dr["jb"].ToString();
            bmk.syqk = dr["syqk"].ToString();

            bmk.Save();
        }
        this.Succeed("导入完毕!");
    }
}