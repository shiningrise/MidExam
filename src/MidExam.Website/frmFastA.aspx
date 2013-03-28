<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="frmFastA.aspx.cs" Inherits="frmFastA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <p>
        报名序号：<asp:Label ID="lblXH" runat="server" Text=""></asp:Label>
        姓名：<asp:Label ID="lblXM" runat="server" Text=""></asp:Label>
    </p>
    <p>
        类别
        <asp:DropDownList ID="ed_Leibie" runat="server">
            <asp:ListItem Text="请选择" Value=""></asp:ListItem>
            <asp:ListItem Text="劳动与技能" Value="劳动与技能"></asp:ListItem>
            <asp:ListItem Text="运动与健康" Value="运动与健康"></asp:ListItem>
            <asp:ListItem Text="审美与艺术" Value="审美与艺术"></asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        获奖证书名称与颁发单位
        <asp:TextBox ID="ed_Pingju" runat="server"></asp:TextBox>
    </p>
    <p>
        备注5:<asp:TextBox ID="txtBeizhu5" runat="server" Width="300px" MaxLength="300"></asp:TextBox>此备注仅用于与学校教务处交流，不上报中招办。
    </p>
    <p>
        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" />
        <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="btn" />
    </p>
    <p>
        审核状态： 班主任审核(  
        <asp:Label ID="ed_Shenhe1" runat="server" Text=""></asp:Label>  ) 
        教务处审核(   
        <asp:Label ID="ed_Shenhe2" runat="server" Text=""></asp:Label> )
    </p>
</asp:Content>
