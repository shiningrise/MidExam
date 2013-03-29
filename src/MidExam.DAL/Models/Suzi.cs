using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Leafing.Data;
using Leafing.Data.Definition;
using Newtonsoft.Json;

namespace MidExam.DAL.Models
{
    
    /// <summary>
    /// 直接认定A等
    /// </summary>
    public class Suzi : DbObjectModel<Suzi>
    {
        #region 记录索引

        /// <summary>
        /// 报名学校代码
        /// </summary>
        [Length(4)]
        [Description("报名学校代码")]
        public string bmxxdm { get; set; }

        /// <summary>
        /// 报名表GUID
        /// </summary>
        [Description("报名表GUID")]
        public Guid BmkGuid { get; set; }

        #endregion

        #region 表格主要内容

        /// <summary>
        /// 报名序号
        /// </summary>
        [AllowNull]
        [Length(9)]
        [Description("报名序号")]
        public string bmxh { get; set; }

        [Length(8)]
        [Description("姓名")]
        public string xm { get; set; }

        /// <summary>
        /// 测评项目 劳动与技能，运动与健康，审美与艺术
        /// </summary>
        [AllowNull]
        [Length(100)]
        [Description("测评项目")]
        public string Xiangmu { get; set; }

        [AllowNull]
        [Length(100)]
        [Description("认定方式")]
        public string Fangshi { get; set; }

        /// <summary>
        /// 所获奖项
        /// </summary>
        [AllowNull]
        [Length(100)]
        [Description("所获奖项")]
        public string Jiangxiang { get; set; }

        /// <summary>
        /// 颁奖单位
        /// </summary>
        [AllowNull]
        [Length(100)]
        [Description("颁奖单位")]
        public string Danwei { get; set; }

        /// <summary>
        /// 颁奖时间
        /// </summary>
        [AllowNull]
        [Length(100)]
        [Description("颁奖时间")]
        public string Shijian { get; set; }

        /// <summary>
        /// 历年等弟
        /// </summary>
        [AllowNull]
        [Length(100)]
        [Description("历年等弟")]
        public string Chegnji { get; set; }

        #endregion
        
        #region 审核与备注

        /// <summary>
        /// 班级审核: 0:待审核，1：退回修改，2，审核不通过，3审核通过
        /// </summary>
        [Description("班级审核")]
        public int Shenhe1 { get; set; }

        /// <summary>
        /// 学校审核: 0:待审核，1：退回修改，2，审核不通过，3审核通过
        /// </summary>
        [Description("学校审核")]
        public int Shenhe2 { get; set; }

        /// <summary>
        /// 学校审核: 0:待审核，1：退回修改，2，审核不通过，3审核通过
        /// </summary>
        [Description("学校审核")]
        public int Shenhe3 { get; set; }

        /// <summary>
        /// 学生备注
        /// </summary>
        [AllowNull]
        [Length(100)]
        [Description("学生备注")]
        public string Beizhu0 { get; set; }

        /// <summary>
        /// 学校备注
        /// </summary>
        [AllowNull]
        [Length(100)]
        [Description("班级备注")]
        public string Beizhu1 { get; set; }

        /// <summary>
        /// 学校备注
        /// </summary>
        [AllowNull]
        [Length(100)]
        [Description("学校备注")]
        public string Beizhu2 { get; set; }

        /// <summary>
        /// 教育局审核
        /// </summary>
        [AllowNull]
        [Length(100)]
        [Description("教育局审核")]
        public string Beizhu3 { get; set; }

        #endregion

        /// <summary>
        /// 软件删除
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 未启用，录入，核对,确认
        /// </summary>
        [Description("记录状态")]
        [Length(100)]
        public string Status { get; set; }

        /// <summary>
        /// 认定方式:直接认定 普通认定
        /// </summary>
        public static class PARAMETER
        {
            public static string FANGSHI_ZHIJIE = "直接认定";
            public static string FANGSHI_PUTONG = "普通认定";

            public static string XIANGMU_YISHU = "审美与艺术";
            public static string XIANGMU_YUNDONG = "运动与健康";
            public static string XIANGMU_YANJIU = "探究与实践";
            public static string XIANGMU_LAOJI = "劳动与技能";
        }

    }
}
