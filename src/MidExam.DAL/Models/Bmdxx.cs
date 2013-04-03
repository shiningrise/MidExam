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
        [Description("体育加分状态|DropDownList")]
        public RecordState TiyuState { get; set; }

        [Description("体育说明|textarea")]
        [AllowNull]
        public string TiyuWiki { get; set; }

        /// <summary>
        /// 等第申请 0:未启用 1：录入 2核对 3确认
        /// </summary>
        [Description("综合素质等第申请状态|DropDownList")]
        public RecordState SuziState { get; set; }

        [Description("等第申请说明|textarea")]
        [AllowNull]
        public string SuziWiki { get; set; }

        /// <summary>
        /// 加分  0:未启用 1：录入 2核对 3确认
        /// </summary>

        [Description("政策照顾状态|DropDownList")]
        public RecordState ZhaoguState { get; set; }

        [Description("政策照顾说明|textarea")]
        [AllowNull]
        public string ZhaoguWiki { get; set; }


        /// <summary>
        /// 加分  0:未启用 1：录入 2核对 3确认
        /// </summary>
        [Description("特长加分状态|DropDownList")]
        public RecordState JiafenState { get; set; }

        [Description("特长加分说明|textarea")]
        [AllowNull]
        public string JiafenWiki { get; set; }

        /// <summary>
        /// 照顾 0:未启用 1：录入 2核对 3确认
        /// </summary>
        [Description("幼师报名状态|DropDownList")]
        public RecordState YoushiState { get; set; }

        [Description("幼师报名说明|textarea")]
        [AllowNull]
        public string YoushiWiki { get; set; }

        #endregion

        [Description("首页公告|textarea")]
        [AllowNull]
        public string Wiki1 { get; set; }

        [Description("内部公告|textarea")]
        [AllowNull]
        public string Wiki2 { get; set; }

        [Description("系统状态|DropDownList")]
        public SystemState State { get; set; }
    }
}
