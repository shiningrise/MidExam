<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="frmSystem.aspx.cs" Inherits="frmSystem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    请输入密码<asp:TextBox ID="ed_Passwrod" runat="server" TextMode="Password"></asp:TextBox>
    <hr />
    请输入重建的表名<asp:TextBox ID="ed_TableName" runat="server"></asp:TextBox>
    <asp:Button ID="btnTableReCreate" runat="server" Text="执行" 
        onclick="btnTableReCreate_Click" />
</asp:Content>

