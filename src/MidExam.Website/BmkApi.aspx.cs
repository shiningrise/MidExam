using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MidExam.DAL;
using Leafing.Data;
using Newtonsoft.Json;

public partial class BmkApi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string cmd = Request.QueryString["cmd"] ?? "LoadAll";
        switch (cmd)
        {
            case "LoadAdd":
                Response.Write(LoadAdd());
                
                break;
            default:
                Response.Write(LoadAdd());
                break;
        }
        Response.End();
    }

    private string LoadAdd()
    {
        var bmkList = Bmk.Find(Condition.Empty);
        return JsonConvert.SerializeObject(bmkList);
    }
}