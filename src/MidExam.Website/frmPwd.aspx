<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="frmPwd.aspx.cs" Inherits="frmPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Button ID="btnInit" runat="server" OnClick="btnInit_Click" Text="初始化" />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="frmPwdPrint.aspx" Target="_blank">打印密码</asp:HyperLink>
    <br />
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="Id" AutoGenerateColumns="False"
        ShowFooter="True" Width="920px">
        <Columns>
            <asp:BoundField DataField="Bj" HeaderText="班级" />
            <asp:TemplateField HeaderText="基本信息">
                <FooterTemplate>
                    <asp:CheckBox ID="chkBase" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkBase" runat="server" />
                    <%# Eval("Base") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="家庭信息">
                <FooterTemplate>
                    <asp:CheckBox ID="chkHome" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkHome" runat="server" />
                    <%# Eval("Home") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="获奖">
                <FooterTemplate>
                    <asp:CheckBox ID="chkCzhj" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkCzhj" runat="server" />
                    <%# Eval("Czhj")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="兴趣">
                <FooterTemplate>
                    <asp:CheckBox ID="chkXqah" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkXqah" runat="server" />
                    <%# Eval("Xqah")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="体测项目">
                <FooterTemplate>
                <asp:CheckBox ID="chkTcxm" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkTcxm" runat="server" />
                    <%# Eval("Tcxm")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="艺术">
                <FooterTemplate>
                <asp:CheckBox ID="chkKm61" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkKm61" runat="server" />
                    <%# Eval("Km61")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="劳技">
                <FooterTemplate>
                <asp:CheckBox ID="chkKm62" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkKm62" runat="server" />
                    <%# Eval("Km62")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="实验">
                <FooterTemplate>
                <asp:CheckBox ID="chkKm63" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkKm63" runat="server" />
                    <%# Eval("Km63")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="审美与艺术">
                <FooterTemplate>
                <asp:CheckBox ID="chkKm71" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkKm71" runat="server" />
                    <%# Eval("Km71")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="运动与健康">
                <FooterTemplate>
                <asp:CheckBox ID="chkKm72" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkKm72" runat="server" />
                    <%# Eval("Km72")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="探究与实践">
                <FooterTemplate>
                <asp:CheckBox ID="chkKm73" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkKm73" runat="server" />
                    <%# Eval("Km73")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="劳动与技能">
                <FooterTemplate>
                <asp:CheckBox ID="chkKm74" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkKm74" runat="server" />
                    <%# Eval("Km74")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="综合评定">
                <FooterTemplate>
                <asp:CheckBox ID="chkZhonghe" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkZhonghe" runat="server" />
                    <%# Eval("Zhonghe")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="志愿填报">
                <FooterTemplate>
                <asp:CheckBox ID="chkZy" runat="server" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkZy" runat="server" />
                    <%# Eval("Zy")%>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    &nbsp;<asp:Button ID="btnInput0" runat="server" Text="密码重置" 
        OnClick="btnInput_Click" />
    </asp:Content>

