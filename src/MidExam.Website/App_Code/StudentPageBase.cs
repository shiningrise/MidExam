using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL;

/// <summary>
///PageBase 的摘要说明
/// </summary>
public class StudentPageBase : PageBase
{
    protected override void AddPermitRoles()
    {
        this.AddPermitRole("Teachers");
        this.AddPermitRole("Students");
        base.AddPermitRoles();
    }

    private Bmk _curBmk;

    public Bmk CurBmk
    {
        get
        {
            if (_curBmk == null)
            {
                if (User.IsInRole("Students"))
                {
                    _curBmk = Bmk.FindOne(p => p.xstbh == Page.User.Identity.Name);
                }
                else if (Request.QueryString["Id"] != null && (User.IsInRole("Administrators") || User.IsInRole("Teachers")))
                {
                    _curBmk = Bmk.FindById(Convert.ToInt64(Request.QueryString["Id"]));
                }
                else
                {
                    Response.Redirect("frmZhiyuanList.aspx");
                }
            }
            if (_curBmk == null)
            {
                throw new Exception("此学生不存在");
            }
            return _curBmk;
        }
        set { _curBmk = value; }
    }

    private BmkStatus _curBmkStatus;

    public BmkStatus CurBmkStatus
    {
        get
        {
            if (_curBmkStatus == null)
            {
                _curBmkStatus = BmkStatus.FindOne(p => p.bj == this.CurBmk.bj);
            }
            if (_curBmkStatus == null)
            {
                Response.Redirect("Default.aspx");
            }
            return _curBmkStatus;
        }
        set { _curBmkStatus = value; }
    }

}