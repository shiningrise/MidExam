<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="frmBatchSeting.aspx.cs" Inherits="frmBatchSeting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    4位学校号<asp:TextBox ID="txtXuexiao" runat="server"></asp:TextBox>
    1位科类号
    <asp:DropDownList ID="ddlKelei" runat="server">
        <asp:ListItem Value="0">请选择科类</asp:ListItem>
        <asp:ListItem Value="6">6普高</asp:ListItem>
        <asp:ListItem Value="7">7师范</asp:ListItem>
        <asp:ListItem Value="8">8中职</asp:ListItem>
        <asp:ListItem Value="9">9不分科类</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlMakeType" runat="server">
        <asp:ListItem Value="0">请选报名序号生成方式</asp:ListItem>
        <asp:ListItem Value="1">按学籍辅号顺序</asp:ListItem>
        <asp:ListItem Value="3">按班级、学籍辅号顺序</asp:ListItem>
        <asp:ListItem Value="4">按市内外、班级、学籍辅号</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnMakeBmxh" runat="server" Text="生成报名序号" 
        onclick="btnMakeBmxh_Click" />
        <hr />
        毕业学校代码为空记录批量设置:
    毕业学校代码<asp:TextBox ID="txtByxxdm" runat="server"></asp:TextBox> 
    毕业学校名称<asp:TextBox ID="txtByxxmc" runat="server"></asp:TextBox> 
    <asp:Button ID="btnBatchSeting" runat="server" Text="批量设置" onclick="btnBatchSeting_Click" />
    <hr />
    <asp:Button ID="btnTy" runat="server" Text="团员字段为空设为-否" onclick="btnTy_Click" />
    <hr />
    请输入邮政编码:<asp:TextBox ID="txtPost" runat="server"></asp:TextBox>
    <asp:Button ID="btnPost" runat="server" Text="邮政编码为空或错误批量设置" 
        onclick="btnPost_Click" />
</asp:Content>

