using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string GetDescription(string Description)
    {
        string[] list = Description.Split('|');
        if (list.Length > 0)
        {
            return list[0];
        }
        else
        {
            return Description;
        }
    }

    public string GetControl(string Description)
    {
        string[] list = Description.Split('|');
        if (list.Length > 0)
        {
            return list[1];
        }
        else
        {
            return "TextBox";
        }
    }
}