<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="frmSuzhi.aspx.cs" Inherits="frmSuzhi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
        班级：<asp:DropDownList ID="ddlBj" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBj_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" RowHeaderColumn="xm"
            ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="bmxh" HeaderText="报名序号" />
                <asp:TemplateField HeaderText="父亲姓名">
                    <ItemTemplate>
                        <%# Eval("xm")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="性别">
                    <FooterTemplate>
                        人数
                    </FooterTemplate>
                    <ItemTemplate>
                        <%# MidExam.DAL.Bmk.GetXb( Eval("xb") )%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="体测项目">
                    <ItemTemplate>
                        <%# Eval("tcxm") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="艺术">
                    <ItemTemplate>
                        <%# Eval("Km61") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="劳技">
                    <ItemTemplate>
                        <%# Eval("Km62") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="实验">
                    <ItemTemplate>
                        <%# Eval("Km63") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="审美与艺术">
                    <ItemTemplate>
                        <%# Eval("Km71") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="运动与健康">
                    <ItemTemplate>
                        <%# Eval("Km72") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="探究与实践">
                    <ItemTemplate>
                        <%# Eval("Km73") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="劳动与技能">
                    <ItemTemplate>
                        <%# Eval("Km74") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="综合表现等第">
                    <ItemTemplate>
                        <%# Eval("Km81") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--                <asp:TemplateField HeaderText="综合表现评语">
                    <ItemTemplate>
                        <%# Eval("Km8") %>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="父亲">
                    <ItemTemplate>
                        <%# Eval("Father") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="母亲">
                    <ItemTemplate>
                        <%# Eval("Mother") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="生源">
                    <ItemTemplate>
                        <%# Eval("syqk")%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
