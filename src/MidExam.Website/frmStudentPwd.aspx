<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="frmStudentPwd.aspx.cs" Inherits="frmStudentPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
        班级：<asp:DropDownList ID="ddlBj" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBj_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Button ID="btnPwd" runat="server" Text="重置所有学生密码" onclick="btnPwd_Click" />
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" RowHeaderColumn="xm"
            DataKeyNames="Id" ShowFooter="True" OnRowCommand="GridView1_RowCommand">
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
                
                <asp:TemplateField HeaderText="父亲姓名">
                    <ItemTemplate>
                        <%# Eval("Father") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="父亲单位">
                    <ItemTemplate>
                        <%# Eval("Fatherdw") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="父亲电话">
                    <ItemTemplate>
                        <%# Eval("FatherTel") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="母亲姓名">
                    <ItemTemplate>
                        <%# Eval("Mother") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="生源">
                    <ItemTemplate>
                        <%# Eval("syqk")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注5">
                    <ItemTemplate>
                        <%# Eval("bz5") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注6">
                    <ItemTemplate>
                        <%# Eval("bz6")%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
