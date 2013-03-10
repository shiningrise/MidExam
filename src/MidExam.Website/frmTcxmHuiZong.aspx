<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="frmTcxmHuiZong.aspx.cs" Inherits="frmTcxmHuiZong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div align="center">
        中考体测项目汇总表<br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" RowHeaderColumn="xm"
            ShowFooter="True" OnRowDataBound="GridView1_RowDataBound">
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
                <asp:BoundField DataField="Bj" HeaderText="班级" />
                <asp:TemplateField HeaderText="篮球">
                    <FooterTemplate>
                        <asp:Label ID="lblTc1" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTc1" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="游泳">
                    <FooterTemplate>
                        <asp:Label ID="lblTc2" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTc2" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="掷实心球">
                    <FooterTemplate>
                        <asp:Label ID="lblTc3" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTc3" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="立定跳远">
                    <FooterTemplate>
                        <asp:Label ID="lblTc4" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTc4" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="跳绳">
                    <FooterTemplate>
                        <asp:Label ID="lblTc5" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTc5" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="引体向上(男)">
                    <FooterTemplate>
                        <asp:Label ID="lblTc6" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTc6" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="仰卧起坐(女)">
                    <FooterTemplate>
                        <asp:Label ID="lblTc7" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTc7" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

