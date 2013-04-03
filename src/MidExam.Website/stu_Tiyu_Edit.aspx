<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="stu_Tiyu_Edit.aspx.cs" Inherits="stu_Tiyu_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
<h1></h1>
<div class="form-horizontal">
    <fieldset>
		<legend>        
		</legend>   
		报名序号：<asp:Label ID="lblXH" runat="server" Text=""></asp:Label>
			姓名：<asp:Label ID="lblXM" runat="server" Text=""></asp:Label>
    <div class="control-group">
        <label class="control-label" for="ed_Id">Id</label>
        <div class="controls">
            <asp:TextBox ID="ed_Id" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_bmxxdm">报名学校代码</label>
        <div class="controls">
            <asp:TextBox ID="ed_bmxxdm" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_BmkGuid">报名表GUID</label>
        <div class="controls">
            <asp:TextBox ID="ed_BmkGuid" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_bmxh">报名序号</label>
        <div class="controls">
            <asp:TextBox ID="ed_bmxh" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_xm">姓名</label>
        <div class="controls">
            <asp:TextBox ID="ed_xm" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Leibie">类别</label>
        <div class="controls">
            <asp:TextBox ID="ed_Leibie" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Pingju">原因</label>
        <div class="controls">
            <asp:TextBox ID="ed_Pingju" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Beizhu">备注</label>
        <div class="controls">
            <asp:TextBox ID="ed_Beizhu" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Shenhe1">班级审核</label>
        <div class="controls">
            <asp:TextBox ID="ed_Shenhe1" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Shenhe2">学校审核</label>
        <div class="controls">
            <asp:TextBox ID="ed_Shenhe2" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Shenhe3">招办审核</label>
        <div class="controls">
            <asp:TextBox ID="ed_Shenhe3" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Beizhu0">学生备注</label>
        <div class="controls">
            <asp:TextBox ID="ed_Beizhu0" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Beizhu1">班级备注</label>
        <div class="controls">
            <asp:TextBox ID="ed_Beizhu1" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Beizhu2">学校备注</label>
        <div class="controls">
            <asp:TextBox ID="ed_Beizhu2" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Beizhu3">教育局审核</label>
        <div class="controls">
            <asp:TextBox ID="ed_Beizhu3" runat="server" ></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Status">记录状态</label>
        <div class="controls">
            <asp:TextBox ID="ed_Status" runat="server" ></asp:TextBox>
        </div>
    </div>
				   <div class="form-actions">
                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" CssClass="btn" />
                </div>

    </fieldset>
</div>
</asp:Content>


