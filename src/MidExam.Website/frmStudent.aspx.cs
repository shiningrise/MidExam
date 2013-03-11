using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Leafing.Data;
using System.Web.Security;
using MidExam.DAL;
using System.Configuration;
using System.Text;
using MidExam.DAL.Util;
using System.IO;
using System.Data;

public partial class frmStudent : PageBase
{
    protected override void AddPermitRoles()
    {
        if (User.IsInRole("Students") && Bmk.GetCount(p => p.xstbh == this.User.Identity.Name) == 0)
        {
            throw new Exception("中考报名库中没有你的名字，若你是初三学生，请尽快联系教务处解决此问题");
        }
        this.AddPermitRole("Teachers");
        this.AddPermitRole("Students");
        base.AddPermitRoles();
    }

    private Bmk _curBmk;

    public Bmk CurBmk
    {
        get
        {
            if (_curBmk == null)
            {
                if (User.IsInRole("Students"))
                {
                    _curBmk = Bmk.FindOne(p => p.xstbh == Page.User.Identity.Name);
                }
                else if (Request.QueryString["Id"] != null && ( User.IsInRole("Administrators") || User.IsInRole("Teachers")) )
                {
                    _curBmk = Bmk.FindById(Convert.ToInt64(Request.QueryString["Id"]));
                }
                else
                    Response.Redirect("frmShenhe.aspx");
            }
            if (_curBmk == null)
            { 
                throw new Exception("你所查找的报名记录不存在，请重试");
            }
            return _curBmk;
        }
        set { _curBmk = value; }
    }

    private BmkStatus _curBmkStatus;

    public BmkStatus CurBmkStatus
    {
        get
        {
            if (_curBmkStatus == null)
            {
                _curBmkStatus = BmkStatus.FindOne(p => p.bj == this.CurBmk.bj);
            }
            if (_curBmkStatus == null)
            {
                Response.Redirect("Default.aspx");
            }
            return _curBmkStatus;
        }
        set { _curBmkStatus = value; }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (User.IsInRole("Students") && Membership.ValidateUser(this.CurBmk.xstbh.Trim(), this.CurBmk.xstbh.Trim()))
            //{
            //    Response.Redirect("Account/ChangePassword.aspx");
            //}
            
            this.btnSave.Enabled = User.IsInRole("Administrators") | User.IsInRole("Students");
            BindData();
        }
    }

    private void BindData()
    {
        InitControl();

        if ((this.CurBmk.xb ?? "") == "1")
        {
            this.ddlTcxm1.Items[7].Enabled = false;
            this.ddlTcxm2.Items[7].Enabled = false;
        }
        else
        {
            this.ddlTcxm1.Items[6].Enabled = false;
            this.ddlTcxm2.Items[6].Enabled = false;
        }

        this.txtXm.Text = this.CurBmk.xm;
        this.Image1.ImageUrl = string.Format("{0}{1}.jpg", ConfigurationManager.AppSettings["PhotoPath"], CurBmk.bmxh);
        if (this.ddlSex.Items.FindByValue(this.CurBmk.xb) != null)
        {
            this.ddlSex.Items.FindByValue(this.CurBmk.xb).Selected = true;
        }
        this.txtCsny.Text = this.CurBmk.csny;
        if (this.ddlTy.Items.FindByValue(this.CurBmk.ty) != null)
        {
            this.ddlTy.Items.FindByValue(this.CurBmk.ty).Selected = true;
        }
        if (this.ddlMz.Items.FindByValue(this.CurBmk.mz) != null)
        {
            this.ddlMz.Items.FindByValue(this.CurBmk.mz).Selected = true;
        }
        if (this.ddlKslb.Items.FindByValue(this.CurBmk.kslb) != null)
        {
            this.ddlKslb.Items.FindByValue(this.CurBmk.kslb).Selected = true;
        }
        
        //户口
        if (this.ddlHk.Items.FindByValue(this.CurBmk.hk) != null)
        {
            this.ddlHk.Items.FindByValue(this.CurBmk.hk).Selected = true;
        }
        //家庭住址
        this.txtJtzz.Text = this.CurBmk.jtzz;

        //报名序号
        this.txtBmxh.Text = this.CurBmk.bmxh;
        //身份证号
        this.txtsfzh.Text = this.CurBmk.sfzh;

        this.txtBj.Text = this.CurBmk.bj;
        this.txtBnbh.Text = this.CurBmk.xh;

        this.txtXstbh.Text = this.CurBmk.xstbh;

        this.txtPost.Text = this.CurBmk.post;
        this.txtTel.Text = this.CurBmk.tel;

        if (this.ddlSyqk.Items.FindByValue(this.CurBmk.syqk) != null)
        {
            this.ddlSyqk.Items.FindByValue(this.CurBmk.syqk).Selected = true;
        }

        this.txtBeizhu1.Text = this.CurBmk.bz1;
        this.txtBeizhu2.Text = this.CurBmk.bz2;
        this.txtBeizhu3.Text = this.CurBmk.bz3;
        this.txtBeizhu4.Text = this.CurBmk.bz4;
        this.txtBeizhu5.Text = this.CurBmk.bz5;
        this.txtBeizhu6.Text = this.CurBmk.bz6;

        this.txtCzhj.Text = this.CurBmk.czhj;
        this.txtXqah.Text = this.CurBmk.xqah;

        this.txtFather.Text = this.CurBmk.father;
        this.txtFatherdw.Text = this.CurBmk.fatherdw;
        this.txtFatherzw.Text = this.CurBmk.fatherzw;
        this.txtFathertel.Text = this.CurBmk.fathertel;
        this.txtMother.Text = this.CurBmk.mother;
        this.txtMotherdw.Text = this.CurBmk.motherdw;
        this.txtMotherzw.Text = this.CurBmk.motherzw;
        this.txtMothertel.Text = this.CurBmk.mothertel;

        this.txtBm.Text = this.CurBmk.Bm;//别名

        this.txtByxxdm.Text = this.CurBmk.byxxdm;//毕业学校代码填写毕业学校
        if (this.CurBmk.byxxmc.IsNullOrEmpty())
        {
            this.lblByxxmc.Text = "鹿城实验中学学校代码为2516,若在别校借读，请填写实际就读学校代码";
        }
        else
        {
            this.lblByxxmc.Text = "毕业学校名称:" + this.CurBmk.byxxmc;
        }

        //体测项目
        if (!string.IsNullOrWhiteSpace(this.CurBmk.tcxm) && this.CurBmk.tcxm.Length == 2)
        {
            char tcxm1 = this.CurBmk.tcxm[0];
            char tcxm2 = this.CurBmk.tcxm[1];
            this.ddlTcxm1.Items.FindByValue(tcxm1.ToString()).Selected = true;
            this.ddlTcxm2.Items.FindByValue(tcxm2.ToString()).Selected = true;
        }

        this.btnSave.Enabled = User.IsInRole("Administrators") || this.CurBmk.xstbh.Trim() == this.User.Identity.Name;
        if (this.btnSave.Enabled == false)
        {
            this.btnSave.Text = "仅学生本人才能录入或修改！";
        }
    }

    /// <summary>
    /// 初始化控件读写状态
    /// </summary>
    private void InitControl()
    {
        //this.ddlBmxx.ClearSelection();
        this.ddlHk.ClearSelection();
        this.ddlKslb.ClearSelection();
        this.ddlMz.ClearSelection();
        this.ddlSex.ClearSelection();
        this.ddlSyqk.ClearSelection();
        this.ddlTcxm1.ClearSelection();
        this.ddlTcxm2.ClearSelection();
        if (!User.IsInRole("Administrators"))
        {
            //基本信息能否录入
            bool flagBase = this.CurBmkStatus.Base == "录入";
            //this.ddlBmxx.Enabled = flagBase;
            this.txtBj.Enabled = false;
            this.txtBnbh.Enabled = flagBase;

            this.txtBmxh.Enabled = false;
            this.txtBmxh.ToolTip = "由学校教务处统一编排";
            this.txtsfzh.Enabled = true;
            this.txtsfzh.ToolTip = "18位身份证号码，要与身份证上一致";
            this.txtXstbh.Enabled = false;
            this.txtXm.Enabled = false;
            this.txtXm.ToolTip = "姓名不能有错，若有误请及时联系学校进行改正";

            //this.txtBmxh.Enabled = flagBase;
            //this.txtsfzh.Enabled = flagBase;
            //this.txtXstbh.Enabled = flagBase;
            //this.txtXm.Enabled = flagBase;

            this.txtBm.Enabled = flagBase;
            this.ddlSex.Enabled = flagBase;
            this.txtCsny.Enabled = flagBase;
            this.txtCsny.ToolTip = "出生年月日由8位数字组成，其中8位年份，2位月份，2位日期，如：19990704,";
            this.ddlTy.Enabled = flagBase;//是否团员
            this.ddlMz.Enabled = flagBase;//民族
            this.ddlKslb.Enabled = flagBase; //考生类别：农应，城应
            this.ddlHk.Enabled = flagBase;
            this.txtTel.Enabled = flagBase;
            this.txtJtzz.Enabled = flagBase;
            this.txtPost.Enabled = flagBase;
            this.ddlSyqk.Enabled = flagBase;//生源情况

            this.ddlTcxm1.Enabled = this.CurBmkStatus.Tcxm == "录入";
            this.ddlTcxm2.Enabled = this.CurBmkStatus.Tcxm == "录入";

            this.txtCzhj.Enabled = this.CurBmkStatus.Czhj == "录入";
            this.txtXqah.Enabled = this.CurBmkStatus.Xqah == "录入";

            //父母信息
            this.txtFather.Enabled = this.CurBmkStatus.Home == "录入";
            this.txtFatherdw.Enabled = this.CurBmkStatus.Home == "录入";
            this.txtFatherzw.Enabled = this.CurBmkStatus.Home == "录入";
            this.txtFathertel.Enabled = this.CurBmkStatus.Home == "录入";

            this.txtMother.Enabled = this.CurBmkStatus.Home == "录入";
            this.txtMotherdw.Enabled = this.CurBmkStatus.Home == "录入";
            this.txtMotherzw.Enabled = this.CurBmkStatus.Home == "录入";
            this.txtMothertel.Enabled = this.CurBmkStatus.Home == "录入";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        StringBuilder errMsg = new StringBuilder();
        if (this.CurBmk != null)
        {
            string oldBmkJson = this.CurBmk.Json();
            this.CurBmk.bj = this.txtBj.Text.Trim();
            this.CurBmk.xh = this.txtBnbh.Text.Trim();
            if (IDCardChecker.CheckIDCard(this.txtsfzh.Text) && this.txtsfzh.Text != null)
            {
                if (this.txtsfzh.Text.Substring(6, 8) != this.txtCsny.Text)
                {
                    errMsg.Append("身份证号码中的出生年月日与你所填写的出生年月日不一致!");
                }
                string sexIDCard = this.txtsfzh.Text.Substring(16,1);
                if ("02468Xx".Contains(sexIDCard) && (this.ddlSex.SelectedValue != "2"))
                {
                    errMsg.Append("身份证号码与所选性别不一致!");
                }
                else if ("13579".Contains(sexIDCard) && (this.ddlSex.SelectedValue != "1"))
                {
                    errMsg.Append("身份证号码与所选性别不一致!");
                }
                this.CurBmk.sfzh = this.txtsfzh.Text.Trim();
            }
            else
            {
                errMsg.Append("身份证号码有误!");
            }
            this.CurBmk.xstbh = this.txtXstbh.Text.Trim();
            this.CurBmk.xm = this.txtXm.Text.Trim();
            this.CurBmk.Bm = this.txtBm.Text.Trim();
            if (this.ddlSex.SelectedIndex > 0)
            {
                this.CurBmk.xb = this.ddlSex.SelectedValue;
            }
            else
            {
                errMsg.Append("性别没选择,");
            }

            if (Bmk.ValidateCsny(this.txtCsny.Text))
            {
                this.CurBmk.csny = this.txtCsny.Text.Trim();
            }
            else
            {
                errMsg.Append("出生年月日有误!必须是8位数字(如：19910805),");
            }

            if (this.ddlTy.SelectedIndex > 0)
            {
                this.CurBmk.ty = this.ddlTy.SelectedValue;//团员
            }
            else
            {
                errMsg.Append("是否团员未选择,");
            }

            if (this.ddlMz.SelectedIndex > 0)
            {
                this.CurBmk.mz = this.ddlMz.SelectedValue;//民族
            }
            else
            {
                errMsg.Append("民族未选择,");
            }

            if (this.ddlKslb.SelectedIndex > 0)
            {
                this.CurBmk.kslb = this.ddlKslb.SelectedValue;//考生类别
            }
            else
            {
                errMsg.Append("考生类别未选择,");
            }

            if (this.ddlHk.SelectedIndex > 0)
            {
                this.CurBmk.hk = this.ddlHk.SelectedValue;
            }
            else
            {
                errMsg.Append("户口未选择,");
            }

            if (this.txtTel.Text.IsNullOrEmpty())
            {
                errMsg.Append("联系电话未填写,");
            }
            else
            {
                this.CurBmk.tel = this.txtTel.Text.Trim();
            }

            if (this.txtJtzz.Text.IsNullOrEmpty())
            {
                errMsg.Append("家庭地址未填写,");
            }
            else
            {
                this.CurBmk.jtzz = this.txtJtzz.Text.Trim();
            }

            if (this.txtPost.Text.IsNullOrEmpty())
            {
                errMsg.Append("邮政编码未填写,");
            }
            else
            {
                this.CurBmk.post = this.txtPost.Text.Trim();
            }
            

            if (this.ddlSyqk.SelectedIndex > 0)
            {
                this.CurBmk.syqk = this.ddlSyqk.SelectedValue;
            }
            else
            {
                errMsg.Append("生源情况未选择,");
            }
            

            this.CurBmk.czhj = this.txtCzhj.Text.Trim();
            this.CurBmk.xqah = this.txtXqah.Text.Trim();

            this.CurBmk.father = this.txtFather.Text.Trim();
            this.CurBmk.fatherdw = this.txtFatherdw.Text.Trim();
            this.CurBmk.fatherzw = this.txtFatherzw.Text.Trim();
            this.CurBmk.fathertel = this.txtFathertel.Text.Trim();
            this.CurBmk.mother = this.txtMother.Text.Trim();
            this.CurBmk.motherdw = this.txtMotherdw.Text.Trim();
            this.CurBmk.motherzw = this.txtMotherzw.Text.Trim();
            this.CurBmk.mothertel = this.txtMothertel.Text.Trim();

            this.CurBmk.bz1 = this.txtBeizhu1.Text.Trim();
            this.CurBmk.bz2 = this.txtBeizhu2.Text.Trim();
            this.CurBmk.bz3 = this.txtBeizhu3.Text.Trim();
            this.CurBmk.bz4 = this.txtBeizhu4.Text.Trim();
            this.CurBmk.bz5 = this.txtBeizhu5.Text.Trim();
            this.CurBmk.bz6 = this.txtBeizhu6.Text.Trim();

            this.CurBmk.Bm = this.txtBm.Text.Trim();//别名

            //体测项目

            if (this.ddlTcxm1.SelectedIndex > 0 && this.ddlTcxm2.SelectedIndex > 0)
            {
                char tcxm1 = this.ddlTcxm1.SelectedValue[0];
                char tcxm2 = this.ddlTcxm2.SelectedValue[0];
                if (tcxm1 == tcxm2)
                {
                    errMsg.Append("体育两项选考必须不一样,");
                }
                else
                {
                    if (tcxm1 > tcxm2)
                    {
                        char temp = tcxm1;
                        tcxm1 = tcxm2;
                        tcxm2 = temp;
                    }
                    this.CurBmk.tcxm = tcxm1.ToString() + tcxm2.ToString();
                }
            }
            else
            {
                this.CurBmk.tcxm = "";
            }

            string byxxdm = this.txtByxxdm.Text;
            if (byxxdm.IsNullOrEmpty())
            {
                errMsg.Append("毕业学校代码未填写,");
            }
            else
            {
                string dbfPath = Server.MapPath("~/Data/Dbf/sysdbf/");
                string dbfTable = "schools.DBF";
                DataTable dt = DbfHelper.ToDataTable(dbfPath, dbfTable);
                var rows = dt.Select(string.Format("school = '{0}'",byxxdm));
                if (rows.Length == 1)
                {
                    this.CurBmk.byxxmc = rows[0]["mc"].ToString();
                    this.CurBmk.byxxdm = byxxdm;
                }
                else
                {
                    errMsg.Append("你所填写的就读学校代码有误");
                }
            }

            string newBmkJson = this.CurBmk.Json();
            if (newBmkJson == oldBmkJson)
            {
                JsUtil.MessageBox(this, "您没有改动任何数据!提示:" + errMsg.ToString());
            }
            else
            {
                ValidateHandler vh = new ValidateHandler(true);
                if (vh.ValidateObject(this.CurBmk))
                {
                    if (this.CurBmk.RecordGuid == Guid.Empty)
                    {
                        this.CurBmk.RecordGuid = Guid.NewGuid();
                    }
                    if (this.CurBmk.CurHistoryGuid == Guid.Empty)
                    {
                        this.CurBmk.CurHistoryGuid = Guid.NewGuid();
                    }
                    else
                    {
                        this.CurBmk.PreHistoryGuid = this.CurBmk.CurHistoryGuid;
                        this.CurBmk.CurHistoryGuid = Guid.NewGuid();
                    }
                    this.CurBmk.Save();
                    this.Save2File(this.CurBmk);
                    JsUtil.MessageBox(this, "数据保存成功!提示:" + errMsg.ToString());

                    BindData();
                }
                else
                {
                    JsUtil.MessageBox(this, "数据保存失败!提示:" + vh.ErrorMessages + errMsg.ToString());
                }
            }
            
        }
        else
        {
            throw new Exception("学生信息不存在!");
        }
    }

    /// <summary>
    /// 保存数据到文件
    /// </summary>
    /// <param name="bmk"></param>
    private void Save2File(Bmk bmk)
    {
        string filepath = "~/Data/BmkHistory/" + bmk.RecordGuid.ToString() + ".txt";
        filepath = Server.MapPath(filepath);
        if(!File.Exists(filepath))
            FileHelper.CreateFile(filepath);
        FileHelper.WriteLine(filepath,bmk.Json());
    }
}