<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="Youyong_Input.aspx.cs" Inherits="Youyong_Input" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
组别:<asp:TextBox ID="Youyong_Zubie" runat="server"></asp:TextBox>
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            报名序号<asp:TextBox ID="Youyong_bmxh" runat="server"></asp:TextBox>
            成绩<asp:TextBox ID="Youyong_chengji" runat="server"></asp:TextBox>
        </ItemTemplate>
    </asp:DataList>
    <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click"  CssClass="btn btn-primary"/>
</asp:Content>

