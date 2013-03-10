<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="frmZhiyuanPrint.aspx.cs" Inherits="Print_frmZhiyuanPrint" %>

<%@ Register Namespace="MidExam.Web" TagPrefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   报名序号开始 <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
   报名序号结束 <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

    <asp:Button ID="btnShow" runat="server" Text="显示" onclick="btnShow_Click" />
    <br />

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(集合)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="878px">
        <ServerReport ReportServerUrl="" />
        <LocalReport ReportPath="Print\Report.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="BmkDS1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>

    <cc1:BmkDS ID="BmkDS1" runat="server" DefaultOrderBy="Bmxh">
    </cc1:BmkDS>
</asp:Content>

