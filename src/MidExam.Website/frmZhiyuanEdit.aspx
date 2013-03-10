<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="frmZhiyuanEdit.aspx.cs" Inherits="frmZhiyuanEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <p>
        报名序号：<asp:Label ID="lblXH" runat="server" Text=""></asp:Label>
        姓名：<asp:Label ID="lblXM" runat="server" Text=""></asp:Label>
        综合表现评定:<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        测评等第总评:<asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </p>
    <p>
        第一批：省一级重点中学(公费生) 1、<asp:DropDownList ID="ddlZy11" runat="server">
            <asp:ListItem>请选择</asp:ListItem>
            <asp:ListItem Value="001">001温州中学</asp:ListItem>
            <asp:ListItem Value="002">002温州二中</asp:ListItem>
        </asp:DropDownList>
        2、<asp:DropDownList ID="ddlZy12" runat="server">
            <asp:ListItem>请选择</asp:ListItem>
            <asp:ListItem Value="001">001温州中学</asp:ListItem>
            <asp:ListItem Value="002">002温州二中</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        第一批：省一级重点中学（择校生） 1、<asp:DropDownList ID="ddlZy21" runat="server">
            <asp:ListItem>请选择</asp:ListItem>
            <asp:ListItem Value="101">101温州中学择校</asp:ListItem>
            <asp:ListItem Value="102">102温州二中择校</asp:ListItem>
        </asp:DropDownList>
        2、<asp:DropDownList ID="ddlZy22" runat="server">
            <asp:ListItem>请选择</asp:ListItem>
            <asp:ListItem Value="101">101温州中学择校</asp:ListItem>
            <asp:ListItem Value="102">102温州二中择校</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        第三批：普通高中 
        1、<asp:DropDownList ID="ddlZy31" runat="server">
            <asp:ListItem>请选择</asp:ListItem>
            <asp:ListItem Value="003">003温州市第二外国语</asp:ListItem>
            <asp:ListItem Value="004">004温州三中</asp:ListItem>
            <asp:ListItem Value="005">005温州四中</asp:ListItem>
            <asp:ListItem Value="006">006温州七中</asp:ListItem>
            <asp:ListItem Value="007">007温州八中</asp:ListItem>
            <asp:ListItem Value="008">008温州十一中</asp:ListItem>
            <asp:ListItem Value="009">009温州十四中</asp:ListItem>
            <asp:ListItem Value="010">010温州十九中</asp:ListItem>
            <asp:ListItem Value="011">011温州二十一中</asp:ListItem>
            <asp:ListItem Value="012">012温州二十二中</asp:ListItem>
            <asp:ListItem Value="013">013温州二十三中</asp:ListItem>
        </asp:DropDownList>
        2、<asp:DropDownList ID="ddlZy32" runat="server">
        <asp:ListItem>请选择</asp:ListItem>
           <asp:ListItem Value="003">003温州市第二外国语</asp:ListItem>
            <asp:ListItem Value="004">004温州三中</asp:ListItem>
            <asp:ListItem Value="005">005温州四中</asp:ListItem>
            <asp:ListItem Value="006">006温州七中</asp:ListItem>
            <asp:ListItem Value="007">007温州八中</asp:ListItem>
            <asp:ListItem Value="008">008温州十一中</asp:ListItem>
            <asp:ListItem Value="009">009温州十四中</asp:ListItem>
            <asp:ListItem Value="010">010温州十九中</asp:ListItem>
            <asp:ListItem Value="011">011温州二十一中</asp:ListItem>
            <asp:ListItem Value="012">012温州二十二中</asp:ListItem>
            <asp:ListItem Value="013">013温州二十三中</asp:ListItem>
        </asp:DropDownList>
        3、<asp:DropDownList ID="ddlZy33" runat="server">
        <asp:ListItem>请选择</asp:ListItem>
           <asp:ListItem Value="003">003温州市第二外国语</asp:ListItem>
            <asp:ListItem Value="004">004温州三中</asp:ListItem>
            <asp:ListItem Value="005">005温州四中</asp:ListItem>
            <asp:ListItem Value="006">006温州七中</asp:ListItem>
            <asp:ListItem Value="007">007温州八中</asp:ListItem>
            <asp:ListItem Value="008">008温州十一中</asp:ListItem>
            <asp:ListItem Value="009">009温州十四中</asp:ListItem>
            <asp:ListItem Value="010">010温州十九中</asp:ListItem>
            <asp:ListItem Value="011">011温州二十一中</asp:ListItem>
            <asp:ListItem Value="012">012温州二十二中</asp:ListItem>
            <asp:ListItem Value="013">013温州二十三中</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        学前教育大专班
        <asp:RadioButtonList ID="rblJb" runat="server" RepeatDirection="Horizontal" 
            RepeatLayout="Flow">
            <asp:ListItem Value="0">不兼报</asp:ListItem>
            <asp:ListItem Value="1">兼报</asp:ListItem>
        </asp:RadioButtonList>
        普通高中是否服从分配
        <asp:RadioButtonList ID="rblFc" runat="server" RepeatDirection="Horizontal" 
            RepeatLayout="Flow">
            <asp:ListItem Value="0">否</asp:ListItem>
            <asp:ListItem Value="1">是</asp:ListItem>
        </asp:RadioButtonList>
    </p>
    <p>
       备注5:<asp:TextBox ID="txtBeizhu5" runat="server" Width="300px" MaxLength="300"></asp:TextBox>此备注仅用于与学校教务处交流，不上报中招办。
    </p>
    <asp:Button ID="btnSave" runat="server" Text="保存" Width="500px" 
    onclick="btnSave_Click" />
</asp:Content>
