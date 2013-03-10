<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="frmInputTcxm.aspx.cs" Inherits="frmInputTcxm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
        班级：<%= this.Bj %> 录入项目：体测项目 录入状态：<%= InputStatus %>    <br />
        请输入录入密码:<asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="btnCheckPwd" runat="server" Text="开始录入" 
            onclick="btnCheckPwd_Click" />
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            OnRowDataBound="GridView1_RowDataBound" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="bmxh" HeaderText="报名序号" />
                <asp:BoundField DataField="xm" HeaderText="姓名" />
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <%# MidExam.DAL.Bmk.GetXb( Eval("xb") )%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="体测项目">
                    <ItemTemplate>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Value="1">篮球</asp:ListItem>
                            <asp:ListItem Value="2">游泳</asp:ListItem>
                            <asp:ListItem Value="3">掷实心球</asp:ListItem>
                            <asp:ListItem Value="4">立定跳远</asp:ListItem>
                            <asp:ListItem Value="5">跳绳</asp:ListItem>
                            <asp:ListItem Value="6">引体向上(男)</asp:ListItem>
                            <asp:ListItem Value="7">仰卧起坐(女)</asp:ListItem>
                        </asp:CheckBoxList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
        <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" 
            Width="200px" />
    </div>
</asp:Content>
