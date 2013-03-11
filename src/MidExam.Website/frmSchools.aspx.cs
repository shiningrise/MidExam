using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL;

public partial class frmSchools : PageBase
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
            string dbfPath = Server.MapPath("~/Data/Dbf/sysdbf/");
            string dbfTable = "schools.DBF";
            this.gvSchool.DataSource = DbfHelper.ToDataTable(dbfPath,dbfTable);
            this.gvSchool.DataBind();
        }
    }
}