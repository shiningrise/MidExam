<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="frmInputSuzhi.aspx.cs" Inherits="frmInputSuzhi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
<%--    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>--%>
   <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('input:text:first').focus();
            var $inp = $('input:text');
            $inp.bind('keydown', function (e) {
                var key = e.which;
                if (key == 13) {
                    e.preventDefault();
                    var nxtIdx = $inp.index(this) + 1;
                    $(":input:text:eq(" + nxtIdx + ")").focus();
                }
                else {
                    if ($inp.attr("class") == "km6") {
                        if ((e.which >= 48 && e.which <= 57) || (e.which >= 96 && e.which <= 105)) {

                        }
                        else {
                            alert('只能输入<=10的数字');
                        }
                        return (e.which >= 48 && e.which <= 57) || (e.which >= 96 && e.which <= 105);
                    }
                    else if ($inp.attr("class") == "km7") {
                        if (e.which == 20 || e.which == 65 || e.which == 80 || e.which == 69) {
                        }
                        else {
                            alert("只能输入APE");
                        }
                        return (e.which == 20 || e.which == 65 || e.which == 80 || e.which == 69);
                    }
                    else {
                    }
                }
            });

            $inp.bind('keyup', function (e) {
                var key = e.which;
                if (key == 13) {
                    e.preventDefault();
                    return;
                }
                if ($inp.attr("class") == "km6") {
                    if ((e.which >= 48 && e.which <= 57) || (e.which >= 96 && e.which <= 105)) {
                        if (parseInt($(this).val(), 10) > 10) {
                            $(this).val('');
                            alert('只能输入<=10的数字');
                        }
                    }
                    else {
                        alert('只能输入<=10的数字');
                    }
                    return (e.which >= 48 && e.which <= 57) || (e.which >= 96 && e.which <= 105);
                }
            })
        });
    </script>
    <style type="text/css">
        .km6
        {
            
        }
        .km7
        {
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
    班级：<%= this.Bj %> 录入项目：<%= XmCNName %> 录入状态：<%= InputStatus %>    <br />
        请输入录入密码:<asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="btnCheckPwd" runat="server" Text="开始录入" 
            onclick="btnCheckPwd_Click" />
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
            DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="bmxh" HeaderText="报名序号" />
                <asp:BoundField DataField="xm" HeaderText="姓名" />
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <%# MidExam.DAL.Bmk.GetXb( Eval("xb") )%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="艺术">
                    <ItemTemplate>
                        <asp:TextBox ID="txtKm61" runat="server" class="km6" MaxLength="2" Style="ime-mode: disabled"
                            Text='<%# Eval("Km61") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="劳技">
                    <ItemTemplate>
                        <asp:TextBox ID="txtKm62" runat="server" class="km6" MaxLength="2" Style="ime-mode: disabled"
                            Text='<%# Eval("Km62") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="实验">
                    <ItemTemplate>
                        <asp:TextBox ID="txtKm63" runat="server" class="km6" MaxLength="2" Style="ime-mode: disabled"
                            Text='<%# Eval("Km63") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="审美与艺术">
                    <ItemTemplate>
                        <asp:TextBox ID="txtKm71" runat="server" class="km7" MaxLength="1" Style="ime-mode: disabled"
                            Text='<%# Eval("Km71") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="运动与健康">
                    <ItemTemplate>
                        <asp:TextBox ID="txtKm72" runat="server" class="km7" MaxLength="1" Style="ime-mode: disabled"
                            Text='<%# Eval("Km72") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="探究与实践">
                    <ItemTemplate>
                        <asp:TextBox ID="txtKm73" runat="server" class="km7" MaxLength="1" Style="ime-mode: disabled"
                            Text='<%# Eval("Km73") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="劳动与技能">
                    <ItemTemplate>
                        <asp:TextBox ID="txtKm74" runat="server" class="km7" MaxLength="1" Style="ime-mode: disabled"
                            Text='<%# Eval("Km74") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="综合表现等第">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlKm81" runat="server">
                            <asp:ListItem>请选择</asp:ListItem>
                            <asp:ListItem>优良</asp:ListItem>
                            <asp:ListItem>合格</asp:ListItem>
                            <asp:ListItem>不合格</asp:ListItem>
                        </asp:DropDownList>
                       
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
        <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" Width="200px" />
    </div>
</asp:Content>
