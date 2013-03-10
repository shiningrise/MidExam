using System.Web;
using System.Web.UI;

/// <summary>
/// JsUtil 的摘要说明
/// </summary>
public class JsUtil
{
    private static string ScriptBegin = "<script language=\"JavaScript\">";
    private static string ScriptEnd = "</script>";

    public static void ConfirmMessageBox(Page page, string PageTarget, string Content)
    {
        string ConfirmContent = "var retValue=window.alert('" + Content + "');" + "if(retValue){window.location='" +
                                PageTarget + "';}";

        ConfirmContent = ScriptBegin + ConfirmContent + ScriptEnd;


        if (page.ClientScript.IsStartupScriptRegistered("confirm") != true)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "confirm", ConfirmContent);
        }
        //    Response.Write(strScript);
    }

    /// <summary>
    /// 显示提示框
    /// </summary>
    /// <param name="page"></param>
    /// <param name="Content"></param>
    public static void MessageBox(Page page, string Content)
    {
        if (page.ClientScript.IsStartupScriptRegistered("alert") != true)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "alert", "<script>function ShowAlert(){alert('" + Content + "');}window.onload=ShowAlert;</script>");
        }
    }
}