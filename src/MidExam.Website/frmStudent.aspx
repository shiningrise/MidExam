<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="frmStudent.aspx.cs" Inherits="frmStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style6
        {
            width: 920px;
            border-collapse: collapse;
            border: 1px;
            border-color: Black;
            border-style: solid;
        }
        .style8
        {
            width: 132px;
        }
        .style11
        {
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
        <p align="center">
            2011年温州市局直属高中段学校招生报名登记表
            <br />
<%--            学校：<asp:DropDownList ID="ddlBmxx" runat="server">
                <asp:ListItem Value="2516">鹿城实验中学</asp:ListItem>
            </asp:DropDownList>--%>
            &nbsp; 班级：<asp:TextBox ID="txtBj" runat="server" MaxLength="2" Width="30px"></asp:TextBox>
            班内编号：<asp:TextBox ID="txtBnbh" runat="server" Width="30px" MaxLength="2"></asp:TextBox>
            报名序号:<asp:TextBox ID="txtBmxh" runat="server" Width="100px"></asp:TextBox>
            身份证号码：<asp:TextBox ID="txtsfzh" runat="server" Width="160px"></asp:TextBox>
            学籍辅号<asp:TextBox ID="txtXstbh" runat="server" Width="100px"></asp:TextBox>
            &nbsp;<table class="style6" border="1" bordercolorlight="#000000">
                <tr>
                    <td class="style11">
                        姓名
                    </td>
                    <td class="style11">
                        <asp:TextBox ID="txtXm" runat="server" Width="70px"></asp:TextBox>
                    </td>
                    <td class="style11">
                        别名
                    </td>
                    <td class="style11">
                        <asp:TextBox ID="txtBm" runat="server" Width="70px"></asp:TextBox>
                        &nbsp;
                    </td>
                    <td class="style11">
                        性别
                    </td>
                    <td class="style11">
                        <asp:DropDownList ID="ddlSex" runat="server">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="1">男</asp:ListItem>
                            <asp:ListItem Value="2">女</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style11">
                        出生年月日&nbsp;
                    </td>
                    <td class="style11">
                        <asp:TextBox ID="txtCsny" runat="server" Width="90px"></asp:TextBox>
                    </td>
                    <td rowspan="6" class="style8">
                        <asp:Image ID="Image1" runat="server" Height="200px" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td class="style11" colspan="2">
                        &nbsp; &nbsp; 是否团员
                    </td>
                    <td class="style11">
                        <asp:DropDownList ID="ddlTy" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style11">
                        &nbsp;民族
                    </td>
                    <td class="style11">
                        <asp:DropDownList ID="ddlMz" runat="server">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="1">汉族</asp:ListItem>
                            <asp:ListItem Value="2">少数民族</asp:ListItem>
                        </asp:DropDownList>
                        <td class="style11" colspan="2">
                            农村应届或城市应届
                        </td>
                        <td class="style11">
                            <asp:DropDownList ID="ddlKslb" runat="server">
                                <asp:ListItem Value="0">请选择</asp:ListItem>
                                <asp:ListItem Value="1">城应</asp:ListItem>
                                <asp:ListItem Value="2">农应</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td class="style11" colspan="2">
                        &nbsp; &nbsp; 户口(乡县)
                    </td>
                    <td class="style11">
                        <asp:DropDownList ID="ddlHk" runat="server">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="25">鹿城区</asp:ListItem>
                            <asp:ListItem Value="26">龙湾区</asp:ListItem>
                            <asp:ListItem Value="27">瓯海区</asp:ListItem>
                            <asp:ListItem Value="28">洞头县</asp:ListItem>
                            <asp:ListItem Value="29">乐清市</asp:ListItem>
                            <asp:ListItem Value="30">永嘉县</asp:ListItem>
                            <asp:ListItem Value="31">瑞安市</asp:ListItem>
                            <asp:ListItem Value="32">平阳县</asp:ListItem>
                            <asp:ListItem Value="33">苍南县</asp:ListItem>
                            <asp:ListItem Value="34">文成县</asp:ListItem>
                            <asp:ListItem Value="35">泰顺县</asp:ListItem>
                            <asp:ListItem Value="99">外市</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style11">
                        联系电话&nbsp;
                    </td>
                    <td class="style11" colspan="3">
                        &nbsp;<asp:TextBox ID="txtTel" runat="server" Width="300px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="style11">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style11" colspan="2">
                        家庭地址
                    </td>
                    <td class="style11" colspan="4">
                        <asp:TextBox ID="txtJtzz" runat="server" Width="400px"></asp:TextBox>
                    </td>
                    <td class="style11">
                        邮政编码
                    </td>
                    <td class="style11">
                        <asp:TextBox ID="txtPost" runat="server" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style11" colspan="2">
                        生源情况
                    </td>
                    <td class="style11" colspan="5">
                        <asp:DropDownList ID="ddlSyqk" runat="server">
                            <asp:ListItem Value="">请选择</asp:ListItem>
                            <asp:ListItem Value="0">0|本县户籍考生在本县学校就读(考听力、文化、收费)</asp:ListItem>
                            <asp:ListItem Value="1">1|外县户籍考生在本县学校就读，并准备在就读县录取(考听力、文化、收费)</asp:ListItem>
                            <asp:ListItem Value="7">7|外县户籍考生在本县学校就读,并回原籍所在县报名录取(考听力,不考文化,不收费)</asp:ListItem>
                            <asp:ListItem Value="8">8|本县户籍考生在外县学校就读，回原籍所在县报名录取(不考听力、考文化、收费)</asp:ListItem>
                            <asp:ListItem Value="9">9|市外就读的本县户籍考生回原籍报名录取(考听力、文化、收费)</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style11">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style11" colspan="2">
                        体育选考
                    </td>
                    <td class="style11">
                        <asp:DropDownList ID="ddlTcxm1" runat="server">
                            <asp:ListItem Value="0">项目1</asp:ListItem>
                            <asp:ListItem Value="1">篮球</asp:ListItem>
                            <asp:ListItem Value="2">游泳</asp:ListItem>
                            <asp:ListItem Value="3">掷实心球</asp:ListItem>
                            <asp:ListItem Value="4">立定跳远</asp:ListItem>
                            <asp:ListItem Value="5">跳绳</asp:ListItem>
                            <asp:ListItem Value="6">引体向上(男)</asp:ListItem>
                            <asp:ListItem Value="7">仰卧起坐(女)</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style11">
                        <asp:DropDownList ID="ddlTcxm2" runat="server">
                            <asp:ListItem Value="0">项目2</asp:ListItem>
                            <asp:ListItem Value="1">篮球</asp:ListItem>
                            <asp:ListItem Value="2">游泳</asp:ListItem>
                            <asp:ListItem Value="3">掷实心球</asp:ListItem>
                            <asp:ListItem Value="4">立定跳远</asp:ListItem>
                            <asp:ListItem Value="5">跳绳</asp:ListItem>
                            <asp:ListItem Value="6">引体向上(男)</asp:ListItem>
                            <asp:ListItem Value="7">仰卧起坐(女)</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style11" colspan="4">
                        <% if (Page.User.IsInRole("Administrators"))
                           {%>备注1<asp:TextBox ID="txtBeizhu1" runat="server" Width="30px" MaxLength="2"></asp:TextBox>
                        备注2<asp:TextBox ID="txtBeizhu2" runat="server" Width="30px" MaxLength="2"></asp:TextBox>
                        备注3<asp:TextBox ID="txtBeizhu3" runat="server" Width="50px" MaxLength="8"></asp:TextBox>
                        备注4:<asp:TextBox ID="txtBeizhu4" runat="server" Width="50px" MaxLength="1"></asp:TextBox>
                        <%} %>
                    </td>
                </tr>
                <tr>
                    <td class="style11" colspan="2">
                        初中阶段奖惩情况
                    </td>
                    <td class="style11" colspan="3">
                        <asp:TextBox ID="txtCzhj" runat="server" Height="50px" TextMode="MultiLine" 
                            Width="300px" MaxLength="118" ToolTip="限110字内"></asp:TextBox>
                    </td>
                    <td class="style11">
                        初中阶段有何特长
                    </td>
                    <td class="style11" colspan="3">
                        <asp:TextBox ID="txtXqah" runat="server" Height="50px" TextMode="MultiLine" 
                            Width="300px" MaxLength="60" ToolTip="限60字"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </p>
        <table class="style6" border="1" bordercolorlight="#000000">
            <tr>
                <td>
                    称谓
                </td>
                <td>
                    姓名
                </td>
                <td>
                    工作单位
                </td>
                <td>
                    职务
                </td>
                <td>
                    联系电话、手机
                </td>
            </tr>
            <tr>
                <td>
                    父
                </td>
                <td>
                    <asp:TextBox ID="txtFather" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtFatherdw" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtFatherzw" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtFathertel" runat="server" MaxLength="17" style="ime-mode:disabled"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    母
                </td>
                <td>
                    <asp:TextBox ID="txtMother" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtMotherdw" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtMotherzw" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtMothertel" runat="server" MaxLength="17" style="ime-mode:disabled"></asp:TextBox>
                </td>
            </tr>
        </table>
        备注5:<asp:TextBox ID="txtBeizhu5" runat="server" Width="200px" MaxLength="100"></asp:TextBox>
        <% if (Page.User.IsInRole("Administrators"))
           {%>备注6:<asp:TextBox ID="txtBeizhu6" runat="server" Width="200px" MaxLength="500"></asp:TextBox>
        <% } %>
        <asp:Button ID="btnSave" runat="server" Text="保存" Width="221px" OnClick="btnSave_Click" />
    </div>
</asp:Content>
