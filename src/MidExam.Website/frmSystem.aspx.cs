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

public partial class frmSystem : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnTableReCreate_Click(object sender, EventArgs e)
    {
        if (!Membership.ValidateUser(this.User.Identity.Name, this.ed_Passwrod.Text))
        {
            try
            {
                DbEntry.DropAndCreate(Type.GetType(this.ed_TableName.Text));
                Succeed();
            }
            catch (Exception ex)
            {
                Fail(ex.Message);
            }
        }

    }
}