<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="frmZhiyuanList.aspx.cs" Inherits="frmZhiyuanList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
        班级：<asp:DropDownList ID="ddlBj" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBj_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:HyperLink ID="hlPrint" runat="server">打印汇总表</asp:HyperLink>

        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            RowHeaderColumn="xm">
            <Columns>
                <asp:BoundField DataField="bmxh" HeaderText="报名号" />
                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/frmZhiyuanEdit.aspx?Id={0}"
                    DataTextField="xm" HeaderText="姓名" Target="_blank" />
                <asp:TemplateField HeaderText="班级">
                    <ItemTemplate>
                        <%# Eval("bj") %>
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
                <asp:TemplateField HeaderText="第一批择校第1志愿">
                    <ItemTemplate>
                        <%# Eval("zy21FullName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="第一批择校第2志愿">
                    <ItemTemplate>
                        <%#Eval("zy22FullName") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="第二批第1志愿">
                    <ItemTemplate>
                        <%# Eval("zy31FullName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="第二批第2志愿">
                    <ItemTemplate>
                        <%#Eval("zy32FullName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="第二批第3志愿">
                    <ItemTemplate>
                        <%# Eval("zy33FullName") %>
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
                
            </Columns>
            
        </asp:GridView>
    </div>
</asp:Content>
