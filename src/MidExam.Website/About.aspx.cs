using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using DbEntryMembership;
using Leafing.Data;

public partial class About : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DbEntryMembershipUser.GetCount(Condition.Empty) == 0)
        {
            Membership.CreateUser("admin", "admin");
        }
    }
}
