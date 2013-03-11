using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Leafing.Data;

public partial class InputIndex : PageBase
{
    protected override void AddPermitRoles()
    {
        this.AddPermitRole("Teachers");
        base.AddPermitRoles();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

}