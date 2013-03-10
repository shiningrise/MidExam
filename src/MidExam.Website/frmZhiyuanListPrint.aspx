<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmZhiyuanListPrint.aspx.cs"
    Inherits="frmZhiyuanListPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 12px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" RowHeaderColumn="xm">
            <Columns>
                <asp:BoundField DataField="bmxh" HeaderText="报名号" />
                <asp:TemplateField HeaderText="学生姓名">
                    <ItemTemplate>
                        <%# Eval("xm")%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="第一批第1志愿">
                    <ItemTemplate>
                        <%#  Eval("zy11FullName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="第一批第2志愿">
                    <ItemTemplate>
                        <%# Eval("zy12FullName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="第二批第1志愿">
                    <ItemTemplate>
                        <%# Eval("zy21FullName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="第二批第2志愿">
                    <ItemTemplate>
                        <%#Eval("zy22FullName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="第二批第3志愿">
                    <ItemTemplate>
                        <%# Eval("zy23FullName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="兼报">
                    <ItemTemplate>
                        <%# Eval("jbFullName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="服从">
                    <ItemTemplate>
                        <%# Eval("fcFullName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="学生签字"></asp:TemplateField>
                <asp:TemplateField HeaderText="家长签字"></asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
