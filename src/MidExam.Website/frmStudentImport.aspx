<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="frmStudentImport.aspx.cs" Inherits="frmStudentImport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Label ID="msg" runat="server" Text=""></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/down/student.xls">点击此处下载导入模板(Excel2003格式)</asp:HyperLink>
    <br />
    <asp:FileUpload ID="fileUpload" runat="server" Width="400px" />
    <asp:Button ID="btnImport" runat="server" Text="导入" onclick="btnImport_Click" CssClass="btn" />
    <hr />
    远程地址：<asp:TextBox ID="ed_RestClient" runat="server"></asp:TextBox>
    远程路径：<asp:TextBox ID="ed_RestRequest" runat="server"></asp:TextBox>
    <asp:Button ID="btnRemoteImport" runat="server" Text="远程导入" CssClass="btn" 
        onclick="btnRemoteImport_Click" />
</asp:Content>
