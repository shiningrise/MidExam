<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="frmStudentPwd.aspx.cs" Inherits="frmStudentPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
        班级：<asp:DropDownList ID="ddlBj" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBj_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Button ID="btnPwd" runat="server" Text="重置所有学生密码" onclick="btnPwd_Click" Visible="false" />
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" RowHeaderColumn="xm"
            DataKeyNames="Id" ShowFooter="True" OnRowCommand="GridView1_RowCommand" 
            onrowdeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="bmxh" HeaderText="报名序号" />
                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/frmStudent.aspx?Id={0}"
                    DataTextField="xm" HeaderText="姓名" Target="_blank" />
                <asp:TemplateField HeaderText="性别">
                    <FooterTemplate>
                        人数
                    </FooterTemplate>
                    <ItemTemplate>
                        <%# MidExam.DAL.Bmk.GetXb( Eval("xb") )%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="学籍号">
                    <ItemTemplate>
                        <%# Eval("xstbh") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="密码初始化" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="InitPwd"
                            CommandArgument='<%#Eval("xstbh")%>' Text="密码初始化"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="初始密码">
                    <ItemTemplate>
                        <%# Eval("Password")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sfzh" HeaderText="学籍主号" />
                <asp:BoundField DataField="xb" HeaderText="性别" />
                <asp:BoundField DataField="mz" HeaderText="民族" />
                <asp:BoundField DataField="csny" HeaderText="出生年月" />
                
                <asp:BoundField DataField="xh" HeaderText="班内编号" />
                <asp:BoundField DataField="bj" HeaderText="班级" />
                <asp:BoundField DataField="tel" HeaderText="联系电话" />
                <asp:BoundField DataField="jtzz" HeaderText="家庭地址" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
