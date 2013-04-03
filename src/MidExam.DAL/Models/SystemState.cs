using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MidExam.DAL.Models
{
    public enum SystemState
    {
        [Display(Name = "停止")]
        Stop,
        [Display(Name="运行中")]
        Running = 1,
        [Display(Name = "维护中")]
        Wait
    }
}
