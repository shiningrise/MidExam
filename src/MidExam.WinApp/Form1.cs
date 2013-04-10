using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Leafing.Data;

using System.Data.OleDb;
using System.Collections;

using MidExam.DAL;
using RestSharp;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;
using System.Threading;

namespace MidExam.WinApp
{
    public partial class Form1 : Form
    {
        private DataTable TempDataTable;
        private List<Bmk> _BmkList;
        private string _VfpConnection;

        public string VfpConnection
        {
            get {
                string connStr = "Provider=VFPOLEDB.1;Data Source='{0}\\userdbfs\\bmk.dbf';Collating Sequence=MACHINE;";
                var appRootPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                WriteLog(appRootPath);
                if (appRootPath.EndsWith("\\"))
                    appRootPath = appRootPath.TrimEnd('\\');
                WriteLog(appRootPath);
                appRootPath = appRootPath.Substring(0,appRootPath.LastIndexOf('\\'));
                WriteLog(appRootPath);
                _VfpConnection = string.Format(connStr, appRootPath);
                //connectionString = Path.Combine(connectionString, ConfigurationManager.ConnectionStrings["VfpConnectionString"].ToString());
                WriteLog(_VfpConnection);
                return _VfpConnection; 
            }
        }

        public List<Bmk> BmkList
        {
            get {
                if (_BmkList == null)
                {
                    var client = new RestClient(ConfigurationManager.AppSettings["RestClient"].ToString());
                    var request = new RestRequest(ConfigurationManager.AppSettings["RestRequest"].ToString(), Method.GET);
                    IRestResponse response = client.Execute(request);
                    var content = response.Content;

                    if (!content.IsNullOrEmpty())
                    {
                        _BmkList = JsonConvert.DeserializeObject<List<Bmk>>(content);
                    }
                    else
                    {
                        _BmkList = new List<Bmk>();
                    }
                }
                return _BmkList;
            }
        }

        public Form1()
        {
            TempDataTable = new DataTable();
            InitializeComponent();

            this.dataGridView1.AutoGenerateColumns = false;
        }

        //显示报名信息
        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        /// <summary>
        /// 显示报名信息
        /// </summary>
        private void ShowData()
        {
            this.bindingSource1.DataSource = BmkList;//.OrderBy(p => p.xstbh);
            this.dataGridView1.DataSource = bindingSource1;
        }

        private void btnImportStudent_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 学生名单导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = this.openFileDialog1.FileName;
            this.WriteLog("\n你选择了以下文件用于导入学生名单：" + filePath);
            string fileExt = System.IO.Path.GetExtension(filePath);
            this.WriteLog(string.Format("你选择了{0}文件", fileExt));
            switch (fileExt.ToLower())
            {
                case ".dbf":
                    string connectionString = string.Format("Provider=VFPOLEDB.1;Data Source='{0}';Collating Sequence=MACHINE;", filePath);
                    this.TempDataTable = OleDbHelper.ExecuteDataTable(connectionString,
                    string.Format("select * from {0}", System.IO.Path.GetFileNameWithoutExtension(filePath))
                    );
                    WriteLog(System.IO.Path.GetFileNameWithoutExtension(filePath));
                    if (ImportStudent(this.TempDataTable))
                    {
                        this.ShowData();
                    }
                    break;
                default:
                    break;
            }

            this.WriteLog("导入成功。");
        }

        public void WriteLog(string logMessage)
        {
            this.txtLog.Text += "\r\n" + System.DateTime.Now + ":" + logMessage;
        }

        /// <summary>
        /// 导入学生名单
        /// </summary>
        /// <param name="datatable">数据表</param>
        /// <returns>是否成功</returns>
        private bool ImportStudent(DataTable datatable)
        {
            foreach (DataRow dr in datatable.Rows)
            {
                Bmk bmk = Bmk.FindOne(p => p.bmxh == dr["bmxh"].ToString());
                if (bmk == null)
                    bmk = new Bmk();
                bmk.byxxdm = dr["byxxdm"].ToString();
                bmk.byxxmc = dr["byxxmc"].ToString();

                bmk.bmxh = dr["bmxh"].ToString();
                bmk.xm = dr["xm"].ToString();

                bmk.bj = dr["class"].ToString();
                bmk.xh = dr["xh"].ToString();
                bmk.xstbh = dr["xstbh"].ToString();
                bmk.sfzh = dr["sfzh"].ToString();

                bmk.xb = dr["xb"].ToString();
                bmk.csny = dr["csny"].ToString();
                bmk.ty = dr["ty"].ToString();
                bmk.mz = dr["mz"].ToString();
                bmk.kslb = dr["kslb"].ToString();
                bmk.hk = dr["hk"].ToString();
                bmk.tel = dr["tel"].ToString();
                bmk.jtzz = dr["jtzz"].ToString();
                bmk.post = dr["post"].ToString();
                bmk.syqk = dr["syqk"].ToString();

                bmk.bz1 = dr["bz1"].ToString();
                bmk.bz2 = dr["bz2"].ToString();
                bmk.bz3 = dr["bz3"].ToString();
                bmk.bz4 = dr["bz4"].ToString();

                bmk.Save();
            }
            return true;
        }

        /// <summary>
        /// 菜单：导入学生名单，目前只有dbf文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miImportStudent_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Title = "请打开用于导入数据表bmk.dbf";
            this.openFileDialog1.Filter = "报名系统导入数据表(*.dbf)|*.dbf";
            this.openFileDialog1.FileName = "bmk.dbf";
            this.openFileDialog1.AddExtension = true;
            this.openFileDialog1.ShowDialog();
        }

        /// <summary>
        /// 菜单：显示报名信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miShowData_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        /// <summary>
        /// 更新（同步）体测项目 数据到 中考报名系统（报名点版）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miUpdateTo_Click(object sender, EventArgs e)
        {
            this.toolStripProgressBar1.Maximum = this.BmkList.Count;
            Thread PullTcxmThread = new Thread(new ThreadStart(this.PullTcxm));
            PullTcxmThread.Start();  
        }

        /// <summary>
        /// 拉取体测项目
        /// </summary>
        public void PullTcxm()
        {
            int i = 0;
            foreach (var bmk in this.BmkList)
            {
                OleDbParameter[] param = new OleDbParameter[2];
                param[0] = OleDbHelper.CreateInParam("tcxm", OleDbType.Char, 2, bmk.tcxm);
                param[1] = OleDbHelper.CreateInParam("bmxh", OleDbType.Char, 9, bmk.bmxh);
                string strSql = @"update bmk set tcxm = ? where bmxh = ? ";
                OleDbHelper.ExcuteSQL(this.VfpConnection, strSql, param);
                i++;
                this.toolStripProgressBar1.Value = i;
                this.toolStripStatusLabel1.Text = string.Format("拉取体测项目{0}/{1}", i, this.BmkList.Count);
            }
            MessageBox.Show("OK!");
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 更新 艺术劳技术实验数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miUpdateToSuzhi_Click(object sender, EventArgs e)
        {

            foreach (var bmk in this.BmkList)
            {
                ArrayList al = new ArrayList();

                //素科成绩
                //al.Add(OleDbHelper.CreateInParam("km61", OleDbType.Decimal, 2, bmk.km61));
                //al.Add(OleDbHelper.CreateInParam("km62", OleDbType.Decimal, 2, bmk.km62));
                //al.Add(OleDbHelper.CreateInParam("km63", OleDbType.Decimal, 2, bmk.km63));
                //al.Add(OleDbHelper.CreateInParam("km6", OleDbType.Decimal, 2, bmk.km6));

                //测评等第
                al.Add(OleDbHelper.CreateInParam("km71", OleDbType.Char, 1, bmk.km71));
                al.Add(OleDbHelper.CreateInParam("km72", OleDbType.Char, 1, bmk.km72));
                al.Add(OleDbHelper.CreateInParam("km73", OleDbType.Char, 1, bmk.km73));
                al.Add(OleDbHelper.CreateInParam("km74", OleDbType.Char, 1, bmk.km74));

                //综合表现评定
                al.Add(OleDbHelper.CreateInParam("km8", OleDbType.LongVarChar, 1024, bmk.km8));
                al.Add(OleDbHelper.CreateInParam("km81", OleDbType.Char, 10, bmk.km81));

                //报名序号
                al.Add(OleDbHelper.CreateInParam("bmxh", OleDbType.Char, 9, bmk.bmxh));

                string strSql = @"update bmk  ";
                strSql += " set km71 = ? , km72 = ? ,km73 = ? , km74 = ?  ";
                strSql += " ,km8 = ? , km81 = ? ";
                strSql += " where bmxh = ? ";

                //OleDbHelper.ExcuteSQL(this.VfpConnection, strSql, (OleDbParameter[])al.ToArray(typeof(OleDbParameter)));
            }
            MessageBox.Show("OK!");
        }

        /// <summary>
        /// 导入综合测评等第
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 导入综合测评等第ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog2.Title = "请打开用于导入Excel数据表";
            this.openFileDialog2.Filter = "综合素质数据表(*.xls)|*.xls";
            this.openFileDialog2.FileName = "";
            this.openFileDialog2.AddExtension = true;
            this.openFileDialog2.ShowDialog();
        }

        /// <summary>
        /// 导入综合测评等第
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = this.openFileDialog2.FileName;
            this.WriteLog("\n你选择了以下文件用于导入学生综合素质信息：" + filePath);
            string fileExt = System.IO.Path.GetExtension(filePath);
            this.WriteLog(string.Format("你选择了{0}文件", fileExt));
            switch (fileExt.ToLower())
            {
                case ".xls":
                    WriteLog(System.IO.Path.GetFileNameWithoutExtension(filePath));
                    DataSet ds = MidExam.DAL.Util.ExcelHelper.ExcelToDS(filePath);
                    DataTable dt = ds.Tables[0];
                    if (ImportZhongheSuzi(dt))
                    {
                        this.ShowData();
                    }
                    break;
                default:
                    break;
            }

            this.WriteLog("导入成功。");
        }

        /// <summary>
        /// 导入综合素质数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool ImportZhongheSuzi(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                string xjh = dr["学籍号"].ToString();
                Bmk bmk = Bmk.FindOne(p => p.xstbh == xjh);
                if (bmk != null)
                {
                    // 审美与艺术	运动与健康	探究与实践	劳动与技能	综合表现
                    if (dt.Columns.Contains("审美与艺术"))
                        bmk.km71 = dr["审美与艺术"].ToString();
                    if (dt.Columns.Contains("运动与健康"))
                        bmk.km72 = dr["运动与健康"].ToString();
                    if (dt.Columns.Contains("探究与实践"))
                        bmk.km73 = dr["探究与实践"].ToString();
                    if (dt.Columns.Contains("劳动与技能"))
                        bmk.km74 = dr["劳动与技能"].ToString();
                    if (dt.Columns.Contains("综合表现评定"))
                        bmk.km81 = dr["综合表现评定"].ToString();
                    if (dt.Columns.Contains("综合表现评语"))
                        bmk.km8 = dr["综合表现评语"].ToString();
                    bmk.Save();
                }
            }
            return true;
        }

        private void 更新志愿信息到中考系统报名点版ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.toolStripProgressBar1.Maximum = this.BmkList.Count;
            Thread PullZhiyuan = new Thread(new ThreadStart(this.PullZhiyuan));
            PullZhiyuan.Start();  
        }

        private void PullZhiyuan()
        {
            int i = 0;
            foreach (var bmk in this.BmkList)
            {
                ArrayList al = new ArrayList();

                //测评等第
                al.Add(OleDbHelper.CreateInParam("zy11", OleDbType.Char, 3, bmk.zy11));
                al.Add(OleDbHelper.CreateInParam("zy12", OleDbType.Char, 3, bmk.zy12));
                al.Add(OleDbHelper.CreateInParam("zy21", OleDbType.Char, 3, bmk.zy21));
                al.Add(OleDbHelper.CreateInParam("zy22", OleDbType.Char, 3, bmk.zy22));
                al.Add(OleDbHelper.CreateInParam("zy31", OleDbType.Char, 3, bmk.zy31));
                al.Add(OleDbHelper.CreateInParam("zy32", OleDbType.Char, 3, bmk.zy32));
                al.Add(OleDbHelper.CreateInParam("zy33", OleDbType.Char, 3, bmk.zy33));

                al.Add(OleDbHelper.CreateInParam("jb", OleDbType.Char, 1, bmk.jb));
                al.Add(OleDbHelper.CreateInParam("fc", OleDbType.Char, 1, bmk.fc));

                //报名序号
                al.Add(OleDbHelper.CreateInParam("bmxh", OleDbType.Char, 9, bmk.bmxh));

                string strSql = @"update bmk  ";
                strSql += " set zy11 = ? , zy12 = ? ,zy21 = ? , zy22 = ?,zy31 = ? , zy32 = ?, zy33 = ? , jb = ? , fc = ?  ";
                strSql += " where bmxh = ? ";
                OleDbHelper.ExcuteSQL(this.VfpConnection, strSql, (OleDbParameter[])al.ToArray(typeof(OleDbParameter)));
                i++;
                this.toolStripProgressBar1.Value = i;
                this.toolStripStatusLabel1.Text = string.Format("拉取志愿信息{0}/{1}", i, this.BmkList.Count);
            }
            MessageBox.Show("OK!");
        }

        private void 更新报名表信息到中考系统报名点版ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int insertCount = 0;
            int updateCount = 0;
            foreach (var bmk in this.BmkList)
            {
                if (UpdateBmkBase(bmk) <= 0)
                {
                //    insertCount += InsertBmkBase(bmk);
                    continue;
                }
                updateCount += 1;
            }
            MessageBox.Show(string.Format("插入记录{0}条,更新记录{1}条", insertCount, updateCount));
        }

        /// <summary>
        /// 插入报名信息表
        /// </summary>
        /// <param name="bmk"></param>
        /// <returns></returns>
        private int InsertBmkBase(Bmk bmk)
        {
            ArrayList al = new ArrayList();
            //报名序号
            al.Add(OleDbHelper.CreateInParam("bmxh", OleDbType.Char, 9, bmk.bmxh ?? ""));
            al.Add(OleDbHelper.CreateInParam("xstbh", OleDbType.Char, 9, bmk.xstbh));
            al.Add(OleDbHelper.CreateInParam("sfzh", OleDbType.Char, 18, bmk.sfzh));
            
            al.Add(OleDbHelper.CreateInParam("xb", OleDbType.Char, 1, bmk.xb));
            al.Add(OleDbHelper.CreateInParam("mz", OleDbType.Char, 1, bmk.mz));
            al.Add(OleDbHelper.CreateInParam("csny", OleDbType.Char, 8, bmk.csny));
            al.Add(OleDbHelper.CreateInParam("hk", OleDbType.Char, 2, bmk.hk));
            al.Add(OleDbHelper.CreateInParam("syqk", OleDbType.Char, 1, bmk.syqk));

            al.Add(OleDbHelper.CreateInParam("kslb", OleDbType.Char, 1, bmk.kslb));
            al.Add(OleDbHelper.CreateInParam("byxxdm", OleDbType.Char, 4, bmk.byxxdm));
            al.Add(OleDbHelper.CreateInParam("byxxmc", OleDbType.Char, 16, bmk.byxxmc));
            al.Add(OleDbHelper.CreateInParam("xh", OleDbType.Char, 2, bmk.xh));
            al.Add(OleDbHelper.CreateInParam("class", OleDbType.Char, 2, bmk.bj));

            al.Add(OleDbHelper.CreateInParam("jtzz", OleDbType.Char, 50, bmk.jtzz));
            al.Add(OleDbHelper.CreateInParam("tel", OleDbType.Char, 30, bmk.tel));
            al.Add(OleDbHelper.CreateInParam("post", OleDbType.Char, 6, bmk.post));
            al.Add(OleDbHelper.CreateInParam("zkzh", OleDbType.Char, 11, bmk.zkzh));

            string strSql = @"insert into bmk (bmxh,xstbh,sfzh,  
                    xb,mz,csny,hk,syqk,  kslb,byxxdm,byxxmc,xh,class,   
                    jtzz,tel,post)";
            strSql += " values (?,?,?,  ?,?,?,?,?,  ?,?,?,?,?,  ?,?,?) ";
            Debug.Write(strSql);
            return OleDbHelper.ExcuteSQL(this.VfpConnection, strSql, (OleDbParameter[])al.ToArray(typeof(OleDbParameter)));
        //    return 1;
        }

        /// <summary>
        /// 更新数据到报名
        /// </summary>
        /// <param name="bmk"></param>
        private int UpdateBmkBase(Bmk bmk)
        {
            ArrayList al = new ArrayList();

            //报名序号
            al.Add(OleDbHelper.CreateInParam("bmxh", OleDbType.Char, 9, bmk.bmxh));
            al.Add(OleDbHelper.CreateInParam("xm", OleDbType.Char, 8, bmk.xm));
            al.Add(OleDbHelper.CreateInParam("sfzh", OleDbType.Char, 18, bmk.sfzh));
            al.Add(OleDbHelper.CreateInParam("xb", OleDbType.Char, 1, bmk.xb));
            al.Add(OleDbHelper.CreateInParam("mz", OleDbType.Char, 1, bmk.mz));
            al.Add(OleDbHelper.CreateInParam("csny", OleDbType.Char, 8, bmk.csny));
            al.Add(OleDbHelper.CreateInParam("hk", OleDbType.Char, 2, bmk.hk));
            al.Add(OleDbHelper.CreateInParam("syqk", OleDbType.Char, 1, bmk.syqk));

            al.Add(OleDbHelper.CreateInParam("kslb", OleDbType.Char, 1, bmk.kslb));
            al.Add(OleDbHelper.CreateInParam("byxxdm", OleDbType.Char, 4, bmk.byxxdm));
            al.Add(OleDbHelper.CreateInParam("byxxmc", OleDbType.Char, 16, bmk.byxxmc));
            al.Add(OleDbHelper.CreateInParam("xh", OleDbType.Char, 2, bmk.xh));
            al.Add(OleDbHelper.CreateInParam("class", OleDbType.Char, 2, bmk.bj));

            al.Add(OleDbHelper.CreateInParam("jtzz", OleDbType.Char, 50, bmk.jtzz));
            al.Add(OleDbHelper.CreateInParam("tel", OleDbType.Char, 30, bmk.tel));
            al.Add(OleDbHelper.CreateInParam("post", OleDbType.Char, 6, bmk.post));
            al.Add(OleDbHelper.CreateInParam("ty", OleDbType.Char, 1, bmk.ty ));
            al.Add(OleDbHelper.CreateInParam("bz1", OleDbType.Char, 2, bmk.bz1));

            
            al.Add(OleDbHelper.CreateInParam("xstbh", OleDbType.Char, 9, bmk.xstbh));

            string strSql = @"update bmk  ";//
            strSql += " set bmxh = ? , xm = ? , sfzh = ? , xb = ? ,mz = ? , csny = ?, hk = ? ,syqk= ? , kslb = ? , byxxdm = ?, byxxmc = ?, xh = ? , class = ? , jtzz = ? , tel = ?  , post = ? ,ty = ? ,bz1 = ? ";
            strSql += " where xstbh = ? ";
            return OleDbHelper.ExcuteSQL(this.VfpConnection, strSql, (OleDbParameter[])al.ToArray(typeof(OleDbParameter)));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
