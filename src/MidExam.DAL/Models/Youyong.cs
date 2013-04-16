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
    public class Youyong : DbObjectModel<Youyong>
    {
        #region 记录索引
        ///// <summary>
        ///// 报名表GUID
        ///// </summary>
        //[Description("报名表GUID")]
        //public Guid BmkGuid { get; set; }

        ///// <summary>
        ///// 报名学校代码
        ///// </summary>
        //[Length(4)]
        //[Description("报名学校代码")]
        //public string bmxxdm { get; set; }

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

        [AllowNull]
        [Length(1)]
        [Description("性别")]
        public string xb { get; set; }

        #endregion

        #region 表格主要内容

        #region 1录

        [Description("1录成绩")]
        public int? Chengji1 { get; set; }

        [Description("1录序号")]
        public int? Xh1 { get; set; }

        [Description("1录用户")]
        [AllowNull, Length(50)]
        public string UserName1 { get; set; }

        [Description("1录时间")]
        public DateTime? InputDateTime1 { get; set; }

        #endregion

        #region 2录

        [Description("2录成绩")]
        public int? Chengji2 { get; set; }

        [Description("2录序号")]
        public int? Xh2 { get; set; }

        [Description("2录用户")]
        [AllowNull, Length(50)]
        public string UserName2 { get; set; }

        [Description("2录时间")]
        public DateTime? InputDateTime2 { get; set; }

        #endregion

        #region 最终成绩

        [Description("成绩")]
        public int? Chengji { get; set; }

        [Description("分数")]
        public int? Fenshu { get; set; }

        [Description("录入用户")]
        [AllowNull, Length(50)]
        public string UserName { get; set; }

        [Description("录入时间")]
        public DateTime? InputDateTime { get; set; }

        #endregion

        /// <summary>
        /// 自动审核
        /// </summary>
        public bool? InputCheck { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [AllowNull,Length(200)]
        [Description("备注")]
        public string Beizhu { get; set; }


        #endregion

        /// <summary>
        /// 未启用，录入，核对,确认
        /// </summary>
        [Description("记录状态")]
        [AllowNull,Length(20)]
        public string Status { get; set; }
    }
}
