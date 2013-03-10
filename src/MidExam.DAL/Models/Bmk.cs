using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Leafing.Data;
using Leafing.Data.Definition;

namespace MidExam.DAL
{
    public class Bmk : DbObjectModel<Bmk>
    {
        [AllowNull]
        [Length(9)]
        [Description("报名序号")]
        public string bmxh { get; set; }
        [AllowNull]
        [Length(11)]
        [Description("准考证号")]
        public string zkzh { get; set; }
        [Length(8)]
        [Description("姓名")]
        public string xm { get; set; }
        [AllowNull]
        [Length(18)]
        [Description("学籍主号")]
        public string sfzh { get; set; }
        [AllowNull]
        [Length(1)]
        [Description("性别")]
        public string xb { get; set; }
        [AllowNull]
        [Length(1)]
        [Description("民族")]
        public string mz { get; set; }
        [AllowNull]
        [Length(8)]
        [Description("出生年月")]
        public string csny { get; set; }
        [AllowNull]
        [Length(1)]
        public string ty { get; set; }
        [AllowNull]
        [Length(2)]
        [Description("体测项目")]
        public string tcxm { get; set; }
        [AllowNull]
        [Length(2)]
        public string hk { get; set; }
        [AllowNull]
        [Length(2)]
        public string xz { get; set; }
        [AllowNull]
        [Length(1)]
        [Description("考生类别")]
        public string kslb { get; set; }
        [AllowNull]
        [Length(4)]
        [Description("毕业学校代码")]
        public string byxxdm { get; set; }
        [AllowNull]
        [Length(16)]
        [Description("毕业学校名称")]
        public string byxxmc { get; set; }
        [AllowNull]
        [Length(2)]
        [Description("学号")]
        public string xh { get; set; }
        [AllowNull]
        [Length(2)]
        [Description("班级")]
        [DbColumn("class")]
        public string bj { get; set; }//class
        [AllowNull]
        [Length(1)]
        public string kl { get; set; }
        [AllowNull]
        [Length(50)]
        public string jtzz { get; set; }
        [AllowNull]
        [Length(30)]
        public string tel { get; set; }
        [AllowNull]
        [Length(6)]
        public string post { get; set; }
        [AllowNull]
        [Length(2)]
        public string bz1 { get; set; }
        [AllowNull]
        [Length(2)]
        public string bz2 { get; set; }
        [AllowNull]
        [Length(8)]
        public string bz3 { get; set; }
        [AllowNull]
        [Length(1)]
        public string bz4 { get; set; }
        [AllowNull]
        [Length(30)]
        [Description("学籍辅号")]
        public string xstbh { get; set; }
        [AllowNull]
        [Length(4)]
        public string kddm { get; set; }
        [AllowNull]
        [Length(20)]
        public string kdmc { get; set; }
        [AllowNull]
        [Length(2)]
        public string scbm { get; set; }
        [AllowNull]
        [Length(4)]
        public string tbsch { get; set; }
        [AllowNull]
        [Length(2)]
        public string zwh { get; set; }
        [AllowNull]
        [Length(5)]
        public string scmh { get; set; }
        public System.Decimal? km1 { get; set; }
        public System.Decimal? km2 { get; set; }
        public System.Decimal? km3 { get; set; }
        public System.Decimal? km31 { get; set; }
        public System.Decimal? km32 { get; set; }
        public System.Decimal? km4 { get; set; }
        public System.Decimal? km5 { get; set; }
        [AllowNull]
        [Length(1)]
        public string km51 { get; set; }
        public System.Decimal? km61 { get; set; }
        public System.Decimal? km62 { get; set; }
        [AllowNull]
        [Length(1)]
        public string km621 { get; set; }
        public System.Decimal? km63 { get; set; }
        public System.Decimal? km6 { get; set; }
        [AllowNull]
        [Length(1)]
        public string km71 { get; set; }
        [AllowNull]
        [Length(1)]
        public string km72 { get; set; }
        [AllowNull]
        [Length(1)]
        public string km73 { get; set; }
        [AllowNull]
        [Length(1)]
        public string km74 { get; set; }
        [AllowNull]
        public string km8 { get; set; }
        [AllowNull]
        [Length(10)]
        public string km81 { get; set; }
        public System.Decimal? tyf { get; set; }
        public System.Decimal? tzf { get; set; }
        public System.Decimal? tcf { get; set; }
        public System.Decimal? zf { get; set; }
        public System.Decimal? tot1 { get; set; }
        public System.Decimal? tot2 { get; set; }
        [AllowNull]
        [Length(8)]
        public string mch { get; set; }
        [AllowNull]
        [Length(2)]
        public string tzdm { get; set; }
        [AllowNull]
        [Length(20)]
        public string tzmc { get; set; }
        [AllowNull]
        [Length(2)]
        public string tcdm { get; set; }
        [AllowNull]
        [Length(20)]
        public string tcmc { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy11 { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy12 { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy13 { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy21 { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy22 { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy23 { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy31 { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy32 { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy33 { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy41 { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy42 { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy43 { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy51 { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy52 { get; set; }
        [AllowNull]
        [Length(3)]
        public string zy53 { get; set; }
        [AllowNull]
        [Length(1)]
        public string fc { get; set; }
        [AllowNull]
        [Length(1)]
        public string jb { get; set; }
        [AllowNull]
        [Length(1)]
        public string syqk { get; set; }

        /* 学生报名信息补充 狐狸头*/
        [AllowNull]
        [Length(10)]
        public string father { get; set; }
        [AllowNull]
        [Length(26)]
        public string fatherdw { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        [AllowNull]
        [Length(26)]
        public string fatherzw { get; set; }
        [AllowNull]
        [Length(17)]
        public string fathertel { get; set; }
        [AllowNull]
        [Length(10)]
        public string mother { get; set; }
        [AllowNull]
        [Length(30)]
        public string motherdw { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        [AllowNull]
        [Length(26)]
        public string motherzw { get; set; }
        [AllowNull]
        [Length(17)]
        public string mothertel { get; set; }
        [AllowNull]
        [Length(60)]
        public string xqah { get; set; }
        [AllowNull]
        [Length(118)]
        public string czhj { get; set; }
        //[AllowNull]
        //public  string zhbxpy { get; set; }
        [AllowNull]
        public string bz5 { get; set; }

        [AllowNull]
        public string bz6 { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        [Length(8)]
        [AllowNull]
        public string Bm { get; set; }

        [Length(128)]
        [Description("密码")]
        [AllowNull]
        public string Password { get; set; }

        [Description("加密方式")]
        public int? PasswordFormat { get; set; }

        [Length(128)]
        [Description("密钥")]
        [AllowNull]
        public string PasswordSalt { get; set; }

        /// <summary>
        /// 记录Guid
        /// </summary>
        [Description("记录GUID")]
        public Guid RecordGuid { get; set; }
        /// <summary>
        /// 当前记录日志GUID
        /// </summary>
        public Guid CurHistoryGuid { get; set; }
        /// <summary>
        /// 前记录日志GUID
        /// </summary>
        public Guid PreHistoryGuid { get; set; }

        [Exclude]
        public string Zy11FullName
        {
            get
            {
                return GetSchooNameByNum(this.zy11);
            }
        }
        [Exclude]
        public string Zy12FullName
        {
            get
            {
                return GetSchooNameByNum(this.zy12);
            }
        }
        [Exclude]
        public string Zy21FullName
        {
            get
            {
                return GetSchooNameByNum(this.zy21);
            }
        }
        [Exclude]
        public string Zy22FullName
        {
            get
            {
                return GetSchooNameByNum(this.zy22);
            }
        }
        [Exclude]
        public string Zy23FullName
        {
            get
            {
                return GetSchooNameByNum(this.zy23);
            }
        }

        [Exclude]
        public string Zy31FullName
        {
            get
            {
                return GetSchooNameByNum(this.zy31);
            }
        }
        [Exclude]
        public string Zy32FullName
        {
            get
            {
                return GetSchooNameByNum(this.zy32);
            }
        }
        [Exclude]
        public string Zy33FullName
        {
            get
            {
                return GetSchooNameByNum(this.zy33);
            }
        }

        [Exclude]
        public string FcFullName
        {
            get
            {
                if (this.fc == "1")
                {
                    return "是";
                }
                else
                    return "否";
            }
        }

        [Exclude]
        public string JbFullName
        {
            get
            {
                if (this.jb == "1")
                {
                    return "是";
                }
                else
                    return "否";
            }
        }


        public string GetSchooNameByNum(object objSchoolNum)
        {
            if (objSchoolNum == null)
                return string.Empty;
            string strRtn = string.Empty;
            switch (objSchoolNum.ToString().Trim())
            {
                case "001":
                    strRtn = "001温州中学";
                    break;
                case "002":
                    strRtn = "002温州二中";
                    break;

                case "101":
                    strRtn = "101温州中学择校";
                    break;
                case "102":
                    strRtn = "102温州二中择校";
                    break;

                case "003":
                    strRtn = "003温州市第二外国语";
                    break;
                case "004":
                    strRtn = "004温州三中";
                    break;
                case "005":
                    strRtn = "005温州四中";
                    break;
                case "006":
                    strRtn = "006温州七中";
                    break;
                case "007":
                    strRtn = "007温州八中";
                    break;
                case "008":
                    strRtn = "008温州十一中";
                    break;
                case "009":
                    strRtn = "009温州十四中";
                    break;
                case "010":
                    strRtn = "010温州十九中";
                    break;
                case "011":
                    strRtn = "011温州二十一中";
                    break;
                case "012":
                    strRtn = "012温州二十二中";
                    break;
                case "013":
                    strRtn = "013温州二十三中";
                    break;

                default:
                    break;
            }

            return strRtn;
        }



        /* 方法 */

        public static string GetXb(object dm)
        {
            if (dm == null)
                return "";
            if (dm.ToString() == "1")
                return "男";
            else
                return "女";
        }

        /// <summary>
        /// 班级数量
        /// </summary>
        public static int BanjiCount
        {
            get
            {
                string strSql = "SELECT count( distinct class ) FROM Bmk";
                object count = DbEntry.Provider.ExecuteScalar(strSql);
                if (count != null)
                {
                    return Convert.ToInt32(count);
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool CheckTcxm(char tcDM)
        {
            char ch = (char)tcDM;
            if (this.tcxm.Trim().Length != 2)
            {
                return false;
            }
            else
            {
                return ch == this.tcxm[0] | ch == this.tcxm[1];
            }
        }

        /// <summary>
        /// 检验出生年月日
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool ValidateCsny(string riqi)
        {
            if (riqi.Length != 8)
                return false;
            riqi = string.Format("{0}-{1}-{2}", riqi.Substring(0, 2)
                , riqi.Substring(4, 2), riqi.Substring(6, 2));
            DateTime tmp = new DateTime();
            return DateTime.TryParse(riqi, out tmp);
        }
    }



}
