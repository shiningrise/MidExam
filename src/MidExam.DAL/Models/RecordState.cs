using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MidExam.DAL.Models
{
    /// <summary>
    /// 0:未启用 1：录入 2核对 3确定
    /// </summary>
    public enum RecordState
    {
        [Display(Name="禁用")]
        Disable,
        [Display(Name = "录入")]
        Input,
        [Display(Name = "核对")]
        Check,
        [Display(Name = "确定")]
        Decide
    }
}
