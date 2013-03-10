<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmInputTcxmHedui.aspx.cs"
    Inherits="frmInputTcxmHedui" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        中考体测项目核对表<br />
        班级：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        班主任:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        日期:
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" RowHeaderColumn="xm"
            ShowFooter="True" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="bmxh" HeaderText="报名序号" />
                <asp:BoundField DataField="xm" HeaderText="姓名" />
                <asp:TemplateField HeaderText="性别">
                    <FooterTemplate>
                        人数
                    </FooterTemplate>
                    <ItemTemplate>
                        <%# MidExam.DAL.Bmk.GetXb( Eval("xb") )%>
                    </ItemTemplate>
                </asp:TemplateField>
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
                <asp:TemplateField HeaderText="学生签字">
                    <HeaderStyle Width="100px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
