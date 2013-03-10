<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="frmInputPingyu.aspx.cs" Inherits="frmInputPingyu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div align="center">
班级：<%= this.Bj %> 录入项目：综合表现评语 录入状态：<%= InputStatus %>    <br />
        请输入录入密码:<asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="btnCheckPwd" runat="server" Text="开始录入" 
            onclick="btnCheckPwd_Click" />
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Id" AllowPaging="True" 
            onpageindexchanging="GridView1_PageIndexChanging" PageSize="5">
            <Columns>
                <asp:BoundField DataField="bmxh" HeaderText="报名序号" />
                <asp:BoundField DataField="xm" HeaderText="姓名" />
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <%# MidExam.DAL.Bmk.GetXb( Eval("xb") )%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="综合表现评语">
                    <ItemTemplate>
                        <asp:TextBox ID="txtKm8" runat="server" Text='<%# Eval("Km8") %>' Rows="3" 
                            TextMode="MultiLine" Width="600px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
        </asp:GridView>
        <br />

        <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" 
            Width="200px" />

        <asp:Button ID="btnSaveAndNext" runat="server" Text="保存并转到下一页"  
            Width="200px" onclick="btnSaveAndNext_Click" />
    </div>
</asp:Content>

