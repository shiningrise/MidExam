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
    /// 报名点学校
    /// </summary>
    public class Bmdxx : DbObjectModel<Bmdxx>
    {
        /// <summary>
        /// 学校管理员用户名
        /// </summary>
        [Length(40)]
        [Description("学校管理员用户名")]
        [AllowNull]
        public string UserName { get; set; }

        /// <summary>
        /// 报名学校代码
        /// </summary>
        [Length(4)]
        [Description("报名学校代码")]
        [AllowNull]
        public string bmxxdm { get; set; }

        /// <summary>
        /// 报名学校名称
        /// </summary>
        [Length(30)]
        [Description("报名学校名称")]
        [AllowNull]
        public string bmxxmc { get; set; }

        /// <summary>
        /// 人数
        /// </summary>
        [Description("人数")]
        public long rs { get; set; }

        [Description("人数")]
        public long yap_rs { get; set; }

        [Description("人数")]
        public long wap_rs { get; set; }

        [Description("人数")]
        public long bmxhq { get; set; }

        [Description("人数")]
        public long bmxhz { get; set; }

        #region 权限控制

        /// <summary>
        /// 直接A 0:未启用 1：录入 2核对 3确认
        /// </summary>
        [Description("直接A")]
        [Length(100)]
        [AllowNull]
        public string FastA { get; set; }

        /// <summary>
        /// 加分  0:未启用 1：录入 2核对 3确认
        /// </summary>
        [Description("加分")]
        [Length(100)]
        [AllowNull]
        public string Jiafen { get; set; }

        /// <summary>
        /// 体育 0:未启用 1：录入 2核对 3确认
        /// </summary>
        [Description("体育")]
        [Length(100)]
        [AllowNull]
        public string Tiyu { get; set; }

        /// <summary>
        /// 照顾 0:未启用 1：录入 2核对 3确认
        /// </summary>
        [Description("照顾")]
        [Length(100)]
        [AllowNull]
        public string Zhaogu { get; set; }

        /// <summary>
        /// 照顾 0:未启用 1：录入 2核对 3确认
        /// </summary>
        [Description("幼师")]
        [Length(100)]
        [AllowNull]
        public string Youshi { get; set; }

        #endregion

        [Description("首页公告")]
        [AllowNull]
        public string Wiki1 { get; set; }

        [Description("内部公告")]
        [AllowNull]
        public string Wiki2 { get; set; }
    }
}
