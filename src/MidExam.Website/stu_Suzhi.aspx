<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="stu_Suzhi.aspx.cs" Inherits="stu_Suzhi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <asp:HyperLink ID="ed_add" runat="server" CssClass="btn" NavigateUrl="~/stu_SuzhiEdit.aspx">添加</asp:HyperLink>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="table">
        <Columns>            
        <asp:BoundField DataField="Bmxxdm" HeaderText="报名学校代码" />
        <asp:BoundField DataField="Bmxh" HeaderText="报名序号" />
        <asp:BoundField DataField="Xm" HeaderText="姓名" />
        <asp:BoundField DataField="Xiangmu" HeaderText="测评项目" />
        <asp:BoundField DataField="Fangshi" HeaderText="认定方式" />
        <asp:BoundField DataField="Dengdi" HeaderText="申请等第" />
        <asp:BoundField DataField="Jiangxiang" HeaderText="所获奖项" />
        <asp:BoundField DataField="Danwei" HeaderText="颁奖单位" />
        <asp:BoundField DataField="Shijian" HeaderText="颁奖时间" />
        <asp:BoundField DataField="Chegnji" HeaderText="历年等弟" />
        <asp:BoundField DataField="Beizhu0" HeaderText="学生备注" />
        <asp:BoundField DataField="Beizhu1" HeaderText="班级备注" />
        <asp:BoundField DataField="Beizhu2" HeaderText="学校备注" />
        <asp:BoundField DataField="Beizhu3" HeaderText="教育局审核" />
        <asp:BoundField DataField="Status" HeaderText="记录状态" />
        </Columns>
    </asp:GridView>
</asp:Content>
