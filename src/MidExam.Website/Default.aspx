<%@ Page Title="主页" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        欢迎使用 !
    </h2>
    <p>
        <a href="frmStudent.aspx">点击此处核对或修改报名信息</a> 
    </p>
    <p>
        <a href="frmZhiyuanEdit.aspx">点击此处核对或修改志愿填报信息</a> 
    </p>
    <p>
        <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" Visible="false"
            onloggedin="Login1_LoggedIn">
        </asp:Login>
    </p>
</asp:Content>
