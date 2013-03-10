using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leafing.Data;
using Leafing.Data.Definition;
 

namespace MidExam.DAL
{
    //班级  基本信息  家庭信息 获奖 与 兴趣 体测项目  艺术 劳技 实验 审美与艺术  运动与健康 探究与实践 劳动与技能 综合评定  志愿填报  中考成绩 
    /// <summary>
    /// 录入状态控制表
    /// </summary>
    public  class BmkStatus : DbObjectModel<BmkStatus>
    {
        /// <summary>
        /// 班级号
        /// </summary>
        [AllowNull]
        [Length(10)]
        [DbColumn("class")]
        public  string bj { get; set; }

        /// <summary>
        /// 基本信息
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Base { get; set; }

        /// <summary>
        /// 家庭信息
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Home { get; set; }

        /// <summary>
        /// 初中获奖
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Czhj { get; set; }

        /// <summary>
        /// 兴趣爱好(特长)
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Xqah { get; set; }

        /// <summary>
        /// 体测项目
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Tcxm { get; set; }

        /// <summary>
        /// 艺术 劳技 实验
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Km61 { get; set; }

        /// <summary>
        /// 艺术 劳技 实验
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Km62 { get; set; }

        /// <summary>
        /// 艺术 劳技 实验
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Km63 { get; set; }

        /// <summary>
        /// 审美与艺术  运动与健康 探究与实践 劳动与技能
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Km71 { get; set; }

        /// <summary>
        /// 审美与艺术  运动与健康 探究与实践 劳动与技能
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Km72 { get; set; }

        /// <summary>
        /// 审美与艺术  运动与健康 探究与实践 劳动与技能
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Km73 { get; set; }

        /// <summary>
        /// 审美与艺术  运动与健康 探究与实践 劳动与技能
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Km74 { get; set; }


        //综合评定  志愿填报  中考成绩
        /// <summary>
        /// 综合评定
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Zhonghe { get; set; }

        /// <summary>
        /// 志愿填报
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Zy { get; set; }

        /// <summary>
        /// 中考成绩
        /// </summary>
        [AllowNull]
        [Length(10)]
        public  string Zk { get; set; }
    }
}
