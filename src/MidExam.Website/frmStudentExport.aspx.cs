using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using MidExam.DAL;
using Leafing.Data;

public partial class frmStudentExport : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnJsonExport_Click(object sender, EventArgs e)
    {
        var bmkList = Bmk.Find(Condition.Empty);
        Download(JsonConvert.SerializeObject(bmkList));
    }

}