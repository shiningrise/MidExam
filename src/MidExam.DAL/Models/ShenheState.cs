using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MidExam.DAL.Models
{

    /// <summary>
    /// 审核状态: 0:待审核，1：退回修改，2，审核不通过，3审核通过
    /// </summary>
    public enum ShenheState
    {
        [Display(Name = "待审核")]
        Wait,
        [Display(Name = "退回修改")]
        Back,
        [Display(Name = "审核不通过")]
        UnPass,
        [Display(Name = "审核通过")]
        Pass
    }
}
