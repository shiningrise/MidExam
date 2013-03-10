<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="frmShenhe.aspx.cs" Inherits="frmShenhe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
        生源情况
        <asp:DropDownList ID="ddlSyqk" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlSyqk_SelectedIndexChanged">
            <asp:ListItem Value="0">0|本县户籍考生在本县学校就读(考听力、文化、收费)</asp:ListItem>
            <asp:ListItem Value="1">1|外县户籍考生在本县学校就读，并准备在就读县录取(考听力、文化、收费)</asp:ListItem>
            <asp:ListItem Value="7">7|外县户籍考生在本县学校就读,并回原籍所在县报名录取(考听力,不考文化,不收费)</asp:ListItem>
            <asp:ListItem Value="8">8|本县户籍考生在外县学校就读，回原籍所在县报名录取(不考听力、考文化、收费)</asp:ListItem>
            <asp:ListItem Value="9">9|市外就读的本县户籍考生回原籍报名录取(考听力、文化、收费)</asp:ListItem>
        </asp:DropDownList>
    班级：
        <asp:DropDownList ID="ddlBj" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlBj_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" RowHeaderColumn="xm"
            ShowFooter="True" onrowdatabound="GridView1_RowDataBound">
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
                <asp:TemplateField HeaderText="体测项目">
                    <ItemTemplate>
                        <%# Eval("tcxm") %>
                    </ItemTemplate>
                </asp:TemplateField>
  <%--              <asp:TemplateField HeaderText="父亲姓名">
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
                --%>
<%--                <asp:TemplateField HeaderText="母亲单位">
                    <ItemTemplate>
                        <%# Eval("Motherdw")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="母亲电话">
                    <ItemTemplate>
                        <%# Eval("Mothertel")%>
                    </ItemTemplate>
                </asp:TemplateField>--%>
<%--                <asp:TemplateField HeaderText="兴趣爱好">
                    <ItemTemplate>
                        <%# Eval("Xqah") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="初中获奖">
                    <ItemTemplate>
                        <%# Eval("czhj") %>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:BoundField DataField="Bj" HeaderText="班级" />
                <asp:TemplateField HeaderText="户口">
                    <ItemTemplate>
                        <asp:Literal ID="litHk" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="生源">
                    <ItemTemplate>
                        <asp:Literal ID="litSyqk" runat="server"></asp:Literal>
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
