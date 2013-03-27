<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="frmBmdxx.aspx.cs" Inherits="frmBmdxx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    学校管理员<asp:TextBox ID="ed_UserName" runat="server" Text=""></asp:TextBox><br />

    报名学校代码<asp:TextBox ID="ed_bmxxdm" runat="server" Text=""></asp:TextBox><br />

    报名学校名称<asp:TextBox ID="ed_bmxxmc" runat="server" Text=""></asp:TextBox><br />

    首页公告<asp:TextBox ID="ed_wiki1" 
        runat="server" Text="" Rows="15" TextMode="MultiLine" Width="900px"></asp:TextBox><br />

    内部公告<asp:TextBox ID="ed_wiki2" runat="server" Text=""  Rows="15" TextMode="MultiLine" Width="900px"></asp:TextBox><br />

    <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" />
</asp:Content>

