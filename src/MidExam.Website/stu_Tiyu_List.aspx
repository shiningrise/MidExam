<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="stu_Tiyu_List.aspx.cs" Inherits="stu_Tiyu_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:HyperLink ID="ed_add" runat="server" CssClass="btn" NavigateUrl="~/stu_SuzhiEdit.aspx">添加</asp:HyperLink>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="table">
        <Columns>            
        <asp:BoundField DataField="Id" HeaderText="Id" />
        <asp:BoundField DataField="bmxxdm" HeaderText="报名学校代码" />
        <asp:BoundField DataField="BmkGuid" HeaderText="报名表GUID" />
        <asp:BoundField DataField="bmxh" HeaderText="报名序号" />
        <asp:BoundField DataField="xm" HeaderText="姓名" />
        <asp:BoundField DataField="Leibie" HeaderText="类别" />
        <asp:BoundField DataField="Pingju" HeaderText="原因" />
        <asp:BoundField DataField="Beizhu" HeaderText="备注" />
        <asp:BoundField DataField="Shenhe1" HeaderText="班级审核" />
        <asp:BoundField DataField="Shenhe2" HeaderText="学校审核" />
        <asp:BoundField DataField="Shenhe3" HeaderText="招办审核" />
        <asp:BoundField DataField="Beizhu0" HeaderText="学生备注" />
        <asp:BoundField DataField="Beizhu1" HeaderText="班级备注" />
        <asp:BoundField DataField="Beizhu2" HeaderText="学校备注" />
        <asp:BoundField DataField="Beizhu3" HeaderText="教育局审核" />
        <asp:BoundField DataField="Status" HeaderText="记录状态" />
        </Columns>
    </asp:GridView>
</asp:Content>

