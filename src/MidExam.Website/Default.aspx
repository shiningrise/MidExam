<%@ Page Title="主页" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" Visible="false"
            onloggedin="Login1_LoggedIn">
        </asp:Login>
    <br />
    <asp:Literal ID="ed_Wiki2" runat="server"></asp:Literal>
    <br />
    <asp:Literal ID="ed_Wiki1" runat="server"></asp:Literal>
</asp:Content>
