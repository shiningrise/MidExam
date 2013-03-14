<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="frmShenhe.aspx.cs" Inherits="frmShenhe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
        户口
        <asp:DropDownList ID="ddlHk" runat="server" >
            <asp:ListItem Value="0">全部</asp:ListItem>
            <asp:ListItem Value="1">施教区</asp:ListItem>
            <asp:ListItem Value="2">市内外县</asp:ListItem>
            <asp:ListItem Value="3">市外</asp:ListItem>
        </asp:DropDownList>
        生源情况
        <asp:DropDownList ID="ddlSyqk" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlSyqk_SelectedIndexChanged">
            <asp:ListItem Value="0">全部</asp:ListItem>
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

        排序
        <asp:DropDownList ID="ddlOrder" runat="server">
            <asp:ListItem Value="2">按户口</asp:ListItem>
            <asp:ListItem Value="0">按学籍号</asp:ListItem>
            <asp:ListItem Value="1">按报名序号</asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="btnShow" runat="server" Text="显示" onclick="btnShow_Click" />
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" RowHeaderColumn="xm"
            ShowFooter="True" onrowdatabound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="bmxh" HeaderText="报名序号" />
                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/frmStudent.aspx?Id={0}"
                    DataTextField="xm" HeaderText="姓名" Target="_blank" />
                <asp:BoundField DataField="bj" HeaderText="班级" />
                <asp:BoundField DataField="xh" HeaderText="班内编号" />
                <asp:BoundField DataField="xstbh" HeaderText="学籍辅号" />

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

                <asp:BoundField DataField="sfzh" HeaderText="学籍主号" />
                <asp:BoundField DataField="xb" HeaderText="性别" />
                <asp:BoundField DataField="mz" HeaderText="民族" />
                <asp:BoundField DataField="csny" HeaderText="出生年月" />
                
                <asp:BoundField DataField="ty" HeaderText="团员?" />
                <asp:BoundField DataField="post" HeaderText="邮编" />

                <asp:TemplateField HeaderText="联系电话">
                    <ItemTemplate>
                        <asp:Literal ID="litTel" runat="server"  Text='<%# Eval("tel") %>'></asp:Literal>
                    </ItemTemplate>
                    <HeaderStyle Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="家庭地址">
                    <ItemTemplate>
                        <asp:Literal ID="litJtzz" runat="server"  Text='<%# Eval("jtzz") %>'></asp:Literal>
                    </ItemTemplate>
                    <HeaderStyle Width="150px" />
                </asp:TemplateField>

                <asp:BoundField DataField="byxxdm" HeaderText="毕业学校代码" />
                <asp:BoundField DataField="byxxmc" HeaderText="毕业学校名称" />

                

                <asp:TemplateField HeaderText="备注5">
                    <ItemTemplate>
                        <%# Eval("bz5") %>
                    </ItemTemplate>
                    <HeaderStyle Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注6">
                    <ItemTemplate>
                        <%# Eval("bz6")%>
                    </ItemTemplate>
                    <HeaderStyle Width="50px" />
                </asp:TemplateField>
            </Columns>
            <RowStyle Height="50px" />
        </asp:GridView>
        
    </div>
</asp:Content>
