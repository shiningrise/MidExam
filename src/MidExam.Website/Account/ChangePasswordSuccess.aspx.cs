using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_ChangePasswordSuccess : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void AddPermitRoles()
    {
        this.AddPermitRole("Administrators");
        this.AddPermitRole("Teachers");
        this.AddPermitRole("Students");
    }
}
