<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="frmStudentExport.aspx.cs" Inherits="frmStudentExport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Button ID="btnJsonExport" runat="server" Text="导出Json数据文件并下载" 
        onclick="btnJsonExport_Click" />
</asp:Content>

