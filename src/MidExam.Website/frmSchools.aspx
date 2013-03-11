<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="frmSchools.aspx.cs" Inherits="frmSchools" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="gvSchool" runat="server" AutoGenerateColumns="False" EnableViewState="false">
        <Columns>
            <asp:BoundField DataField="school" HeaderText="学校代码" />
            <asp:BoundField DataField="mc" HeaderText="学校名称" />
            <asp:BoundField DataField="jc" HeaderText="学校简称" />
            <asp:BoundField DataField="sxmc" HeaderText="所属区县" />
        </Columns>
    </asp:GridView>
</asp:Content>

