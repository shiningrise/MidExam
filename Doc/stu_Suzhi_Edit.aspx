<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
<h1></h1>
<div class="form-horizontal">
    <fieldset>
		<legend>        
		</legend>   
		报名序号：<asp:Label ID="lblXH" runat="server" Text=""></asp:Label>
			姓名：<asp:Label ID="lblXM" runat="server" Text=""></asp:Label>
    <div class="control-group">
        <label class="control-label" for="ed_Bmxh">报名序号</label>
        <div class="controls">
            <asp:TextBox ID="ed_Bmxh" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Xm">姓名</label>
        <div class="controls">
            <asp:TextBox ID="ed_Xm" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Xiangmu">测评项目</label>
        <div class="controls">
            <asp:DropDownList ID="ed_Xiangmu" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Fangshi">认定方式</label>
        <div class="controls">
            <asp:DropDownList ID="ed_Fangshi" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Dengdi">申请等第</label>
        <div class="controls">
            <asp:DropDownList ID="ed_Dengdi" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Jiangxiang">所获奖项</label>
        <div class="controls">
            <asp:TextBox ID="ed_Jiangxiang" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Danwei">颁奖单位</label>
        <div class="controls">
            <asp:TextBox ID="ed_Danwei" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Shijian">颁奖时间</label>
        <div class="controls">
            <asp:TextBox ID="ed_Shijian" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Chegnji">历年等弟</label>
        <div class="controls">
            <asp:TextBox ID="ed_Chegnji" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Shenhe1">班级审核</label>
        <div class="controls">
            <asp:DropDownList ID="ed_Shenhe1" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Shenhe2">学校审核</label>
        <div class="controls">
            <asp:DropDownList ID="ed_Shenhe2" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="ed_Status">记录状态</label>
        <div class="controls">
            <asp:DropDownList ID="ed_Status" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    </fieldset>
</div>
</asp:Content>
