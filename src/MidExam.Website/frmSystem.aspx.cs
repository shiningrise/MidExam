using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Leafing.Data;
using DbEntryMembership;
using System.Web.Security;
using MidExam.DAL.Util;
using MidExam.DAL.Models;

public partial class frmSystem : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnTableReCreate_Click(object sender, EventArgs e)
    {
        if (Membership.ValidateUser(this.User.Identity.Name, this.ed_Passwrod.Text))
        {
            switch (this.ed_TableName.Text)
            {
                case "Suzhi":
                    DbEntry.DropAndCreate(typeof(Suzhi));
                    break;
                default:
                    break;
            }
            Succeed();
        }
        else
        {
            Fail("密码错");
        }
    }
}