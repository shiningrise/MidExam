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
    /// 报名点信息表
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
        /// 体育 0:未启用 1：录入 2核对 3确认
        /// </summary>
        [Description("体育")]
        [Length(100)]
        [AllowNull]
        public string Tiyu { get; set; }

        [Description("体育说明")]
        [AllowNull]
        public string TiyuWiki { get; set; }

        [Description("体育加分")]
        public bool TiyuEnable { get; set; }

        /// <summary>
        /// 等第申请 0:未启用 1：录入 2核对 3确认
        /// </summary>
        [Description("等第申请")]
        [Length(100)]
        [AllowNull]
        public string Suzi { get; set; }

        [Description("等第申请说明")]
        [AllowNull]
        public string SuziWiki { get; set; }

        [Description("启用等第申请")]
        public bool SuziEnable { get; set; }

        /// <summary>
        /// 加分  0:未启用 1：录入 2核对 3确认
        /// </summary>
        [Description("政策照顾")]
        [Length(100)]
        [AllowNull]
        public string Zhaogu { get; set; }

        [Description("政策照顾说明")]
        [AllowNull]
        public string ZhaoguWiki { get; set; }

        [Description("启用政策照顾")]
        public bool ZhaoguEnable { get; set; }

        /// <summary>
        /// 加分  0:未启用 1：录入 2核对 3确认
        /// </summary>
        [Description("加分")]
        [Length(100)]
        [AllowNull]
        public string Jiafen { get; set; }

        [Description("加分说明")]
        [AllowNull]
        public string JiafenWiki { get; set; }

        [Description("启用加分")]
        public bool JiafenEnable { get; set; }

        /// <summary>
        /// 照顾 0:未启用 1：录入 2核对 3确认
        /// </summary>
        [Description("幼师")]
        [Length(100)]
        [AllowNull]
        public string Youshi { get; set; }

        [Description("幼师说明")]
        [AllowNull]
        public string YoushiWiki { get; set; }

        [Description("幼师加分")]
        public bool YoushiEnable { get; set; }

        #endregion

        [Description("首页公告")]
        [AllowNull]
        public string Wiki1 { get; set; }

        [Description("内部公告")]
        [AllowNull]
        public string Wiki2 { get; set; }
    }
}
