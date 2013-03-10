<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmPwdPrint.aspx.cs" Inherits="frmPwdPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style33
        {
            height: 14.25pt;
            width: 54pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style34
        {
            width: 71pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style35
        {
            width: 54pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style36
        {
            width: 105pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style37
        {
            height: 14.25pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style38
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style39
        {
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style40
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataList ID="DataList1" runat="server">
            <ItemTemplate>
                <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:338pt" u1:str="" width="450" x:str="">
                    <colgroup>
                        <col width="72" />
                        <col width="94" />
                        <col span="2" width="72" />
                        <col width="140" />
                    </colgroup>
                    <tr height="19">
                        <td class="style33" height="19" width="72">
                            班级</td>
                        <td class="style34" width="94">
                            录入项目</td>
                        <td class="style35" width="72">
                            录入密码</td>
                        <td class="style35" width="72">
                            录入人</td>
                        <td class="style36" width="140">
                            录入截止时间</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            　<%# Eval("Bj") %></td>
                        <td class="style38">
                            基本信息</td>
                        <td class="style39">
                        <%# Eval("Base") %>
                            　</td>
                        <td class="style39">
                            　</td>
                        <td class="style39">
                            　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19" colspan="5">
                            　　　　　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            班级</td>
                        <td class="style38">
                            录入项目</td>
                        <td class="style39">
                            录入密码</td>
                        <td class="style39">
                            录入人</td>
                        <td class="style39">
                            录入截止时间</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            　<%# Eval("Bj") %></td>
                        <td class="style38">
                            家庭信息</td>
                        <td class="style39"><%# Eval("Home") %>
                            　</td>
                        <td class="style39">
                            　</td>
                        <td class="style39">
                            　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19" colspan="5">
                            　　　　　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            班级</td>
                        <td class="style38">
                            录入项目</td>
                        <td class="style39">
                            录入密码</td>
                        <td class="style39">
                            录入人</td>
                        <td class="style39">
                            录入截止时间</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            　<%# Eval("Bj") %></td>
                        <td class="style38">
                            获奖与兴趣</td>
                        <td class="style39">
                            　<%# Eval("Czhj")%>/<%# Eval("Xqah")%></td>
                        <td class="style39">
                            　</td>
                        <td class="style39">
                            　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19" colspan="5">
                            　　　　　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            班级</td>
                        <td class="style38">
                            录入项目</td>
                        <td class="style39">
                            录入密码</td>
                        <td class="style39">
                            录入人</td>
                        <td class="style39">
                            录入截止时间</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            　<%# Eval("Bj") %></td>
                        <td class="style38">
                            体测项目</td>
                        <td class="style39">
                            　<%# Eval("Tcxm")%></td>
                        <td class="style39">
                            　</td>
                        <td class="style39">
                            　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19" colspan="5">
                            　　　　　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            班级</td>
                        <td class="style38">
                            录入项目</td>
                        <td class="style39">
                            录入密码</td>
                        <td class="style39">
                            录入人</td>
                        <td class="style39">
                            录入截止时间</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            　<%# Eval("Bj") %></td>
                        <td class="style38">
                            艺术</td>
                        <td class="style39">
                            　<%# Eval("Km61")%></td>
                        <td class="style39">
                            　</td>
                        <td class="style39">
                            　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19" colspan="5">
                            　　　　　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            班级</td>
                        <td class="style38">
                            录入项目</td>
                        <td class="style39">
                            录入密码</td>
                        <td class="style39">
                            录入人</td>
                        <td class="style39">
                            录入截止时间</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            　<%# Eval("Bj") %></td>
                        <td class="style38">
                            劳技</td>
                        <td class="style39">
                            　<%# Eval("Km62")%></td>
                        <td class="style39">
                            　</td>
                        <td class="style39">
                            　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19" colspan="5">
                            　　　　　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            班级</td>
                        <td class="style38">
                            录入项目</td>
                        <td class="style39">
                            录入密码</td>
                        <td class="style39">
                            录入人</td>
                        <td class="style39">
                            录入截止时间</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            　<%# Eval("Bj") %></td>
                        <td class="style38">
                            实验</td>
                        <td class="style39">
                            　<%# Eval("Km63")%></td>
                        <td class="style39">
                            　</td>
                        <td class="style39">
                            　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19" colspan="5">
                            　　　　　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            班级</td>
                        <td class="style38">
                            录入项目</td>
                        <td class="style39">
                            录入密码</td>
                        <td class="style39">
                            录入人</td>
                        <td class="style39">
                            录入截止时间</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            　<%# Eval("Bj") %></td>
                        <td class="style38">
                            审美与艺术</td>
                        <td class="style39">
                            　<%# Eval("Km71")%></td>
                        <td class="style39">
                            　</td>
                        <td class="style39">
                            　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19" colspan="5">
                            　<%# Eval("Bj") %>　　　　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            班级</td>
                        <td class="style38">
                            录入项目</td>
                        <td class="style39">
                            录入密码</td>
                        <td class="style39">
                            录入人</td>
                        <td class="style39">
                            录入截止时间</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            　<%# Eval("Bj") %></td>
                        <td class="style38">
                            运动与健康</td>
                        <td class="style39">
                            　<%# Eval("Km72")%></td>
                        <td class="style39">
                            　</td>
                        <td class="style39">
                            　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19" colspan="5">
                            　　　　　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            班级</td>
                        <td class="style38">
                            录入项目</td>
                        <td class="style39">
                            录入密码</td>
                        <td class="style39">
                            录入人</td>
                        <td class="style39">
                            录入截止时间</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            　<%# Eval("Bj") %></td>
                        <td class="style38">
                            探究与实践</td>
                        <td class="style39">
                            　<%# Eval("Km73")%></td>
                        <td class="style39">
                            　</td>
                        <td class="style39">
                            　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19" colspan="5">
                            　　　　　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            班级</td>
                        <td class="style38">
                            录入项目</td>
                        <td class="style39">
                            录入密码</td>
                        <td class="style39">
                            录入人</td>
                        <td class="style39">
                            录入截止时间</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            　<%# Eval("Bj") %></td>
                        <td class="style38">
                            劳动与技能</td>
                        <td class="style39">
                            　<%# Eval("Km74")%></td>
                        <td class="style39">
                            　</td>
                        <td class="style39">
                            　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19" colspan="5">
                            　　　　　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            班级</td>
                        <td class="style38">
                            录入项目</td>
                        <td class="style39">
                            录入密码</td>
                        <td class="style39">
                            录入人</td>
                        <td class="style39">
                            录入截止时间</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            　<%# Eval("Bj") %></td>
                        <td class="style38">
                            综合评定</td>
                        <td class="style39">
                            　<%# Eval("Zhonghe")%></td>
                        <td class="style39">
                            　</td>
                        <td class="style39">
                            　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19" colspan="5">
                            　　　　　</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            班级</td>
                        <td class="style38">
                            录入项目</td>
                        <td class="style39">
                            录入密码</td>
                        <td class="style39">
                            录入人</td>
                        <td class="style39">
                            录入截止时间</td>
                    </tr>
                    <tr height="19">
                        <td class="style37" height="19">
                            　<%# Eval("Bj") %></td>
                        <td class="style40">
                            志愿填报 
                        </td>
                        <td class="style39">
                            　<%# Eval("Zy")%></td>
                        <td class="style39">
                            　</td>
                        <td class="style39">
                            　</td>
                    </tr>
                </table>
            </ItemTemplate>
            <SeparatorTemplate>
                <br />
            </SeparatorTemplate>
        </asp:DataList>

    </div>
    </form>
</body>
</html>
