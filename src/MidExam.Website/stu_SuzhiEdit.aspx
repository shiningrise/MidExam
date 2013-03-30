<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="stu_SuzhiEdit.aspx.cs" Inherits="stu_SuzhiEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
<h1>综合素质测评等第申请</h1>
<div class="form-horizontal">
    <fieldset>
    <legend>        
    报名序号：<asp:Label ID="lblXH" runat="server" Text=""></asp:Label>
        姓名：<asp:Label ID="lblXM" runat="server" Text=""></asp:Label>
    </legend>   
    <div class="control-group">
        <label class="control-label" for="ed_Fangshi">认定方式</label>
        <div class="controls">
            <asp:DropDownList ID="ed_Fangshi" runat="server">
                <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                <asp:ListItem Text="审美与艺术" Value="审美与艺术"></asp:ListItem>
                <asp:ListItem Text="运动与健康" Value="运动与健康"></asp:ListItem>
                <asp:ListItem Text="探究与实践" Value="探究与实践"></asp:ListItem>
                <asp:ListItem Text="劳动与技能" Value="劳动与技能"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div> 
    <div class="control-group">
        <label class="control-label" for="ed_Xiangmu">项目</label>
        <div class="controls">
            <asp:DropDownList ID="ed_Xiangmu" runat="server">
                <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                <asp:ListItem Text="审美与艺术" Value="审美与艺术"></asp:ListItem>
                <asp:ListItem Text="运动与健康" Value="运动与健康"></asp:ListItem>
                <asp:ListItem Text="探究与实践" Value="探究与实践"></asp:ListItem>
                <asp:ListItem Text="劳动与技能" Value="劳动与技能"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Dengdi">申请等第</label>
        <div class="controls">
            <asp:DropDownList ID="ed_Dengdi" runat="server">
                <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                <asp:ListItem Text="审美与艺术" Value="审美与艺术"></asp:ListItem>
                <asp:ListItem Text="运动与健康" Value="运动与健康"></asp:ListItem>
                <asp:ListItem Text="探究与实践" Value="探究与实践"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Jiangxiang">所获奖项</label>
        <div class="controls">
            <asp:TextBox ID="ed_Jiangxiang" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Danwei">颁奖单位</label>
        <div class="controls">
            <asp:TextBox ID="ed_Danwei" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Shijian">颁奖时间</label>
        <div class="controls">
            <asp:TextBox ID="ed_Shijian" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Chegnji">历年等弟</label>
        <div class="controls">
            <asp:TextBox ID="ed_Chegnji" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Beizhu0">学生备注</label>
        <div class="controls">
            <asp:TextBox ID="ed_Beizhu0" runat="server"></asp:TextBox>
            此备注仅用于与学校教务处交流
        </div>
    </div>
    <div class="form-actions">
        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn" />
        <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="btn" />
    </div>
    <p>
        审核状态： 班主任审核(  
        <asp:Label ID="ed_Shenhe1" runat="server" Text=""></asp:Label>  ) 
        教务处审核(   
        <asp:Label ID="ed_Shenhe2" runat="server" Text=""></asp:Label> )
    </p>
    </fieldset>
</div>
</asp:Content>
