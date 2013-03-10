using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Leafing.Data;
using MidExam.DAL;

public partial class frmPwdPrint : PageBase
{
    protected override void AddPermitRoles()
    {
        this.AddPermitRole("Teachers");
        this.AddPermitRole("Students");
        base.AddPermitRoles();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.DataList1.DataSource = BmkPwd.Find(Condition.Empty);
            this.DataList1.DataBind();
        }
    }
}