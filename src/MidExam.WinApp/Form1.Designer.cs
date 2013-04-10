namespace MidExam.WinApp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miShowData = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miImportStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.CepingDengdiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miUpdateTo = new System.Windows.Forms.ToolStripMenuItem();
            this.miUpdateToSuzhi = new System.Windows.Forms.ToolStripMenuItem();
            this.更新志愿信息到中考系统报名点版ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新报名表信息到中考系统报名点版ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bmxh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xstbh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcxm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tyf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km71 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km72 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km73 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km74 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km81 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.km8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syqk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Father = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mother = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.导入ToolStripMenuItem,
            this.导出ToolStripMenuItem,
            this.打印ToolStripMenuItem,
            this.同步ToolStripMenuItem,
            this.审核ToolStripMenuItem,
            this.QuitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(669, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miShowData});
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.显示ToolStripMenuItem.Text = "显示";
            // 
            // miShowData
            // 
            this.miShowData.Name = "miShowData";
            this.miShowData.Size = new System.Drawing.Size(142, 22);
            this.miShowData.Text = "显示报名信息";
            this.miShowData.Click += new System.EventHandler(this.miShowData_Click);
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miImportStudent,
            this.CepingDengdiToolStripMenuItem});
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.导入ToolStripMenuItem.Text = "导入";
            // 
            // miImportStudent
            // 
            this.miImportStudent.Name = "miImportStudent";
            this.miImportStudent.Size = new System.Drawing.Size(142, 22);
            this.miImportStudent.Text = "导入学生名单";
            this.miImportStudent.Click += new System.EventHandler(this.miImportStudent_Click);
            // 
            // CepingDengdiToolStripMenuItem
            // 
            this.CepingDengdiToolStripMenuItem.Name = "CepingDengdiToolStripMenuItem";
            this.CepingDengdiToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.CepingDengdiToolStripMenuItem.Text = "导入综合素质";
            this.CepingDengdiToolStripMenuItem.Click += new System.EventHandler(this.导入综合测评等第ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.导出ToolStripMenuItem.Text = "导出";
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.打印ToolStripMenuItem.Text = "打印";
            // 
            // 同步ToolStripMenuItem
            // 
            this.同步ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUpdateTo,
            this.miUpdateToSuzhi,
            this.更新志愿信息到中考系统报名点版ToolStripMenuItem,
            this.更新报名表信息到中考系统报名点版ToolStripMenuItem});
            this.同步ToolStripMenuItem.Name = "同步ToolStripMenuItem";
            this.同步ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.同步ToolStripMenuItem.Text = "同步";
            // 
            // miUpdateTo
            // 
            this.miUpdateTo.Name = "miUpdateTo";
            this.miUpdateTo.Size = new System.Drawing.Size(250, 22);
            this.miUpdateTo.Text = "更新体测项目到中考系统报名点版";
            this.miUpdateTo.Click += new System.EventHandler(this.miUpdateTo_Click);
            // 
            // miUpdateToSuzhi
            // 
            this.miUpdateToSuzhi.Name = "miUpdateToSuzhi";
            this.miUpdateToSuzhi.Size = new System.Drawing.Size(250, 22);
            this.miUpdateToSuzhi.Text = "更新素质数据到中考系统报名点版";
            this.miUpdateToSuzhi.Click += new System.EventHandler(this.miUpdateToSuzhi_Click);
            // 
            // 更新志愿信息到中考系统报名点版ToolStripMenuItem
            // 
            this.更新志愿信息到中考系统报名点版ToolStripMenuItem.Name = "更新志愿信息到中考系统报名点版ToolStripMenuItem";
            this.更新志愿信息到中考系统报名点版ToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.更新志愿信息到中考系统报名点版ToolStripMenuItem.Text = "更新志愿信息到中考系统报名点版";
            this.更新志愿信息到中考系统报名点版ToolStripMenuItem.Click += new System.EventHandler(this.更新志愿信息到中考系统报名点版ToolStripMenuItem_Click);
            // 
            // 更新报名表信息到中考系统报名点版ToolStripMenuItem
            // 
            this.更新报名表信息到中考系统报名点版ToolStripMenuItem.Name = "更新报名表信息到中考系统报名点版ToolStripMenuItem";
            this.更新报名表信息到中考系统报名点版ToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.更新报名表信息到中考系统报名点版ToolStripMenuItem.Text = "更新报名信息到中考系统报名点版";
            this.更新报名表信息到中考系统报名点版ToolStripMenuItem.Click += new System.EventHandler(this.更新报名表信息到中考系统报名点版ToolStripMenuItem_Click);
            // 
            // 审核ToolStripMenuItem
            // 
            this.审核ToolStripMenuItem.Name = "审核ToolStripMenuItem";
            this.审核ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.审核ToolStripMenuItem.Text = "审核";
            // 
            // QuitToolStripMenuItem
            // 
            this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
            this.QuitToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.QuitToolStripMenuItem.Text = "退出";
            this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bmxh,
            this.xm,
            this.xstbh,
            this.bj,
            this.xh,
            this.tcxm,
            this.Tyf,
            this.km71,
            this.km72,
            this.km73,
            this.km74,
            this.km81,
            this.km8,
            this.syqk,
            this.Father,
            this.Mother});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(1, 500, 1, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(669, 415);
            this.dataGridView1.TabIndex = 0;
            // 
            // bmxh
            // 
            this.bmxh.DataPropertyName = "bmxh";
            this.bmxh.FillWeight = 50F;
            this.bmxh.Frozen = true;
            this.bmxh.HeaderText = "报名序号";
            this.bmxh.Name = "bmxh";
            this.bmxh.ReadOnly = true;
            this.bmxh.Width = 80;
            // 
            // xm
            // 
            this.xm.DataPropertyName = "xm";
            this.xm.Frozen = true;
            this.xm.HeaderText = "姓名";
            this.xm.Name = "xm";
            this.xm.ReadOnly = true;
            this.xm.Width = 60;
            // 
            // xstbh
            // 
            this.xstbh.DataPropertyName = "xstbh";
            this.xstbh.Frozen = true;
            this.xstbh.HeaderText = "学籍辅号";
            this.xstbh.Name = "xstbh";
            this.xstbh.ReadOnly = true;
            // 
            // bj
            // 
            this.bj.DataPropertyName = "bj";
            this.bj.HeaderText = "班号";
            this.bj.Name = "bj";
            this.bj.ReadOnly = true;
            // 
            // xh
            // 
            this.xh.DataPropertyName = "xh";
            this.xh.HeaderText = "班内编号";
            this.xh.Name = "xh";
            this.xh.ReadOnly = true;
            // 
            // tcxm
            // 
            this.tcxm.DataPropertyName = "tcxm";
            this.tcxm.HeaderText = "体测项目";
            this.tcxm.Name = "tcxm";
            this.tcxm.ReadOnly = true;
            // 
            // Tyf
            // 
            this.Tyf.DataPropertyName = "tyf";
            this.Tyf.HeaderText = "体育";
            this.Tyf.Name = "Tyf";
            this.Tyf.ReadOnly = true;
            // 
            // km71
            // 
            this.km71.DataPropertyName = "km71";
            this.km71.HeaderText = "审美与艺术";
            this.km71.Name = "km71";
            this.km71.ReadOnly = true;
            // 
            // km72
            // 
            this.km72.DataPropertyName = "km72";
            this.km72.HeaderText = "运动与健康";
            this.km72.Name = "km72";
            this.km72.ReadOnly = true;
            // 
            // km73
            // 
            this.km73.DataPropertyName = "km73";
            this.km73.HeaderText = "探究与实践";
            this.km73.Name = "km73";
            this.km73.ReadOnly = true;
            // 
            // km74
            // 
            this.km74.DataPropertyName = "km74";
            this.km74.HeaderText = "劳动与技能";
            this.km74.Name = "km74";
            this.km74.ReadOnly = true;
            // 
            // km81
            // 
            this.km81.DataPropertyName = "km81";
            this.km81.HeaderText = "综合表现评定";
            this.km81.Name = "km81";
            this.km81.ReadOnly = true;
            // 
            // km8
            // 
            this.km8.DataPropertyName = "km8";
            this.km8.HeaderText = "综合表现评语";
            this.km8.Name = "km8";
            this.km8.ReadOnly = true;
            // 
            // syqk
            // 
            this.syqk.DataPropertyName = "syqk";
            this.syqk.HeaderText = "生源情况";
            this.syqk.Name = "syqk";
            this.syqk.ReadOnly = true;
            // 
            // Father
            // 
            this.Father.DataPropertyName = "Father";
            this.Father.HeaderText = "父亲";
            this.Father.Name = "Father";
            this.Father.ReadOnly = true;
            // 
            // Mother
            // 
            this.Mother.DataPropertyName = "Mother";
            this.Mother.HeaderText = "母亲";
            this.Mother.Name = "Mother";
            this.Mother.ReadOnly = true;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Location = new System.Drawing.Point(0, 439);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(669, 58);
            this.txtLog.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(669, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(669, 519);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "分布式中考报名系统(同步到招办系统)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同步ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 审核ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miImportStudent;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miShowData;
        private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miUpdateTo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem miUpdateToSuzhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn bmxh;
        private System.Windows.Forms.DataGridViewTextBoxColumn xm;
        private System.Windows.Forms.DataGridViewTextBoxColumn xstbh;
        private System.Windows.Forms.DataGridViewTextBoxColumn bj;
        private System.Windows.Forms.DataGridViewTextBoxColumn xh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcxm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tyf;
        private System.Windows.Forms.DataGridViewTextBoxColumn km71;
        private System.Windows.Forms.DataGridViewTextBoxColumn km72;
        private System.Windows.Forms.DataGridViewTextBoxColumn km73;
        private System.Windows.Forms.DataGridViewTextBoxColumn km74;
        private System.Windows.Forms.DataGridViewTextBoxColumn km81;
        private System.Windows.Forms.DataGridViewTextBoxColumn km8;
        private System.Windows.Forms.DataGridViewTextBoxColumn syqk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Father;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mother;
        private System.Windows.Forms.ToolStripMenuItem CepingDengdiToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem 更新志愿信息到中考系统报名点版ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新报名表信息到中考系统报名点版ToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

