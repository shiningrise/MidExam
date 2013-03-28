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
    /// 政策照顾
    /// </summary>
    public class Youshi : DbObjectModel<Youshi>
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
        /// 未启用，录入，核对,确认
        /// </summary>
        [Description("记录状态")]
        [Length(100)]
        public string Status { get; set; }
    }
}
