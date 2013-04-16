<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="User_Index.aspx.cs" Inherits="User_Index" %>

<%@ Register Assembly="DbEntryMembership" Namespace="DbEntryMembership" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="Id" DataSourceID="DbEntryMembershipUserDataSource1" 
        onrowcommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                SortExpression="Id" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            <asp:TemplateField HeaderText="密码初始化" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="InitPwd"
                        CommandArgument='<%#Eval("UserName")%>' Text="密码初始化"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <cc1:DbEntryMembershipUserDataSource ID="DbEntryMembershipUserDataSource1" runat="server" />
</asp:Content>
