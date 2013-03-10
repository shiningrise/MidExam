<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="InputIndex.aspx.cs" Inherits="InputIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 12.75pt;
            width: 26pt;
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
        .style3
        {
            height: 25pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 26pt;
        }
        .style5
        {
            width: 45pt;
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
        .style6
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 45pt;
        }
        .style7
        {
            width: 61pt;
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
        .style8
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 61pt;
        }
        .style9
        {
            width: 38pt;
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
        .style10
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 38pt;
        }
        .style11
        {
            width: 29pt;
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
        .style12
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 29pt;
        }
        .style13
        {
            width: 28pt;
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
        .style14
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 28pt;
        }
        .style17
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 59pt;
        }
        .style18
        {
            width: 59pt;
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
        .style19
        {
            width: 47pt;
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
        .style20
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 47pt;
        }
        .style21
        {
            width: 68pt;
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
        .style22
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 68pt;
        }
        .style23
        {
            width: 49pt;
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
        .style24
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 49pt;
        }
        .style25
        {
            width: 57pt;
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
        .style26
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 57pt;
        }
        .style29
        {
            width: 64pt;
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
        .style30
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 64pt;
        }
        .style31
        {
            width: 60pt;
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
        .style32
        {
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 60pt;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse;
        width: 100%;" x:str="">
        <colgroup>
            <col style="mso-width-source: userset; mso-width-alt: 1499;" />
            <col span="1" />
            <col span="1" />
            <col span="1" />
            <col span="1" />
            <col span="1" />
            <col span="1" />
            <col span="1" />
            <col span="1" />
            <col span="1" />
            <col span="1" />
            <col span="1" />
            <col span="1" />
            <col span="1" />
            <col span="1" style="width: 48pt" width="64" />
        </colgroup>
        <tr height="17">
            <td class="style1" height="17">
                班级
            </td>
            <td class="style5">
                基本信息
            </td>
            <td class="style5">
                家庭信息
            </td>
            <td class="style21">
                获奖与兴趣
            </td>
            <td class="style7">
                体测项目
            </td>
            <td class="style9">
                艺术
            </td>
            <td class="style11">
                劳技
            </td>
            <td class="style13">
                实验
            </td>
            <td class="style25">
                审美与艺术
            </td>
            <td class="style18">
                运动与健康
            </td>
            <td class="style29">
                探究与实践
            </td>
            <td class="style31">
                劳动与技能
            </td>
            <td class="style5">
                综合评定
            </td>
            <td class="style19">
                志愿填报
            </td>
            <td class="style23">
                中考成绩
            </td>
        </tr>
        <% for (int i = 0; i < MidExam.DAL.Bmk.BanjiCount; i++)
           {
        %>
        <tr height="17">
            <td class="style3" height="17" x:str="'01">
                <% = (i+1).ToString().PadLeft(2,'0') %>
            </td>
            <td class="style6">

            </td>
            <td class="style6">
                &nbsp;
            </td>
            <td class="style22">
                &nbsp;
            </td>
            <td class="style8">
                <a href="frmInputTcxmEmpty.aspx?bj=<%= (i+1).ToString().PadLeft(2,'0') %>&xm=tyxm"
                    target="_blank">打印空表</a><br />
                <a href="frmInputTcxm.aspx?bj=<%= (i+1).ToString().PadLeft(2,'0') %>&xm=tyxm">录入数据</a><br />
                <a href="frmInputTcxmHedui.aspx?bj=<%= (i+1).ToString().PadLeft(2,'0') %>&xm=tyxm"
                    target="_blank">打印核对表</a><br />
            </td>
            <td class="style10">
                <a href="frmInputSuzhi.aspx?bj=<%= (i+1).ToString().PadLeft(2,'0') %>&xm=km61">录入</a><br />
            </td>
            <td class="style12">
                <a href="frmInputSuzhi.aspx?bj=<%= (i+1).ToString().PadLeft(2,'0') %>&xm=km62">录入</a><br />
            </td>
            <td class="style14">
                <a href="frmInputSuzhi.aspx?bj=<%= (i+1).ToString().PadLeft(2,'0') %>&xm=km63">录入</a><br />
            </td>
            <td class="style26">
                <a href="frmInputSuzhi.aspx?bj=<%= (i+1).ToString().PadLeft(2,'0') %>&xm=km71">录入</a><br />
            </td>
            <td class="style17">
                <a href="frmInputSuzhi.aspx?bj=<%= (i+1).ToString().PadLeft(2,'0') %>&xm=km72">录入</a><br />
            </td>
            <td class="style30">
                <a href="frmInputSuzhi.aspx?bj=<%= (i+1).ToString().PadLeft(2,'0') %>&xm=km73">录入</a><br />
            </td>
            <td class="style32">
                <a href="frmInputSuzhi.aspx?bj=<%= (i+1).ToString().PadLeft(2,'0') %>&xm=km74">录入</a><br />
            </td>
            <td class="style6">
                <a href="frmInputSuzhi.aspx?bj=<%= (i+1).ToString().PadLeft(2,'0') %>&xm=km81">等第</a><br />
                &nbsp; <a href="frmInputPingyu.aspx?bj=<%= (i+1).ToString().PadLeft(2,'0') %>&xm=km80">评语</a><br />
            </td>
            <td class="style20">
                &nbsp;
            </td>
            <td class="style24">
            </td>
        </tr>
        <%    } %>
    </table>
    &nbsp;
</asp:Content>
