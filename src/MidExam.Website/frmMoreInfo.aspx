<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="frmMoreInfo.aspx.cs" Inherits="frmMoreInfo" %>

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
                <asp:BoundField DataField="bmxh" HeaderText="报名号" />
                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/frmStudent.aspx?Id={0}"
                    DataTextField="xm" HeaderText="姓名" Target="_blank" />
                <asp:TemplateField HeaderText="班级">
                    <FooterTemplate>
                        人数
                    </FooterTemplate>
                    <ItemTemplate>
                        <%# Eval("bj") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注5(学生)">
                    <ItemTemplate>
                        <%# Eval("bz5") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注6(教师)">
                    <ItemTemplate>
                        <%# Eval("bz6")%>
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
                <asp:TemplateField HeaderText="母亲单位">
                    <ItemTemplate>
                        <%# Eval("Motherdw")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="母亲电话">
                    <ItemTemplate>
                        <%# Eval("Mothertel")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="兴趣爱好">
                    <ItemTemplate>
                        <%# Eval("Xqah") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="初中获奖">
                    <ItemTemplate>
                        <%# Eval("czhj") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="综合品德评语">
                    <ItemTemplate>
                        <%# Eval("Km8")%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
