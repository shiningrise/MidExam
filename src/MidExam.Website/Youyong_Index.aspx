<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="Youyong_Index.aspx.cs" Inherits="Youyong_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="youyongCount" runat="server" Text=""></asp:Label>
    <asp:Button ID="btnInit" runat="server" Text="游泳学生数据初始化" 
        onclick="btnInit_Click" />
</asp:Content>

