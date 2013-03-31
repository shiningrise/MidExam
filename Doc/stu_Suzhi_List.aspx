<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:HyperLink ID="ed_add" runat="server" CssClass="btn" NavigateUrl="~/stu_SuzhiEdit.aspx">添加</asp:HyperLink>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="table">
        <Columns>            
        <asp:BoundField DataField="Bmxh" HeaderText="报名序号" />
        <asp:BoundField DataField="Xm" HeaderText="姓名" />
        <asp:BoundField DataField="Xiangmu" HeaderText="测评项目" />
        <asp:BoundField DataField="Fangshi" HeaderText="认定方式" />
        <asp:BoundField DataField="Dengdi" HeaderText="申请等第" />
        <asp:BoundField DataField="Jiangxiang" HeaderText="所获奖项" />
        <asp:BoundField DataField="Danwei" HeaderText="颁奖单位" />
        <asp:BoundField DataField="Shijian" HeaderText="颁奖时间" />
        <asp:BoundField DataField="Chegnji" HeaderText="历年等弟" />
        <asp:BoundField DataField="Shenhe1" HeaderText="班级审核" />
        <asp:BoundField DataField="Shenhe2" HeaderText="学校审核" />
        <asp:BoundField DataField="Status" HeaderText="记录状态" />
        </Columns>
    </asp:GridView>
</asp:Content>

