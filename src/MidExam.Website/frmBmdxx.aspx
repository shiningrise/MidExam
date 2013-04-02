<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true"
    CodeFile="frmBmdxx.aspx.cs" Inherits="frmBmdxx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="control-group">
        <div class="form-horizontal">
            <fieldset>
                <legend></legend>
                <div class="control-group">
                    <label class="control-label" for="ed_UserName">
                        学校管理员用户名</label>
                    <div class="controls">
                        <asp:TextBox ID="ed_UserName" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="ed_bmxxdm">
                        报名学校代码</label>
                    <div class="controls">
                        <asp:TextBox ID="ed_bmxxdm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="ed_bmxxmc">
                        报名学校名称</label>
                    <div class="controls">
                        <asp:TextBox ID="ed_bmxxmc" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="ed_TiyuState">
                        体育加分状态</label>
                    <div class="controls">
                        <asp:DropDownList ID="ed_TiyuState" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="ed_TiyuWiki">
                        体育说明</label>
                    <div class="controls">
                        <asp:TextBox ID="ed_TiyuWiki" runat="server" Rows="10" TextMode="MultiLine" Width="800px"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="ed_SuziState">
                        综合素质等第申请状态</label>
                    <div class="controls">
                        <asp:DropDownList ID="ed_SuziState" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="ed_SuziWiki">
                        等第申请说明</label>
                    <div class="controls">
                        <asp:TextBox ID="ed_SuziWiki" runat="server" Rows="10" TextMode="MultiLine" Width="800px"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="ed_ZhaoguState">
                        政策照顾状态</label>
                    <div class="controls">
                        <asp:DropDownList ID="ed_ZhaoguState" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="ed_ZhaoguWiki">
                        政策照顾说明</label>
                    <div class="controls">
                        <asp:TextBox ID="ed_ZhaoguWiki" runat="server" Rows="10" TextMode="MultiLine" Width="800px"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="ed_JiafenState">
                        特长加分状态</label>
                    <div class="controls">
                        <asp:DropDownList ID="ed_JiafenState" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="ed_JiafenWiki">
                        特长加分说明</label>
                    <div class="controls">
                        <asp:TextBox ID="ed_JiafenWiki" runat="server" Rows="10" TextMode="MultiLine" Width="800px"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="ed_YoushiState">
                        幼师报名状态</label>
                    <div class="controls">
                        <asp:DropDownList ID="ed_YoushiState" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="ed_YoushiWiki">
                        幼师报名说明</label>
                    <div class="controls">
                        <asp:TextBox ID="ed_YoushiWiki" runat="server" Rows="10" TextMode="MultiLine" Width="800px"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="ed_Wiki1">
                        首页公告</label>
                    <div class="controls">
                        <asp:TextBox ID="ed_Wiki1" runat="server" Rows="10" TextMode="MultiLine" Width="800px"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="ed_Wiki2">
                        内部公告</label>
                    <div class="controls">
                        <asp:TextBox ID="ed_Wiki2" runat="server" Rows="10" TextMode="MultiLine" Width="800px"></asp:TextBox>
                    </div>
                </div>
                <div class="form-actions">
                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" CssClass="btn" />
                </div>
            </fieldset>
        </div>
</asp:Content>
