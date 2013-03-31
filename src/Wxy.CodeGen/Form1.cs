using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zeus;

namespace Wxy.CodeGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.context = new ZeusContext();
        }

        private ZeusContext context;

        //private Zeus.UserInterface.GuiController ui;
        //private MyMeta.dbRoot MyMeta;
        //private Dnp.Utils.Utils DnpUtils;

        private void button1_Click(object sender, EventArgs e)
        {
            context.Objects["ui"] = new Zeus.UserInterface.GuiController(this.context);
            context.Objects["MyMeta"] = new MyMeta.dbRoot();
            context.Objects["DnpUtils"] = new MyMeta.dbRoot();

            var gui = new GeneratedGui(context);
            gui.Setup();

            //GeneratedTemplate template = new GeneratedTemplate(context);
            //template.Render();
            //this.textBox1.Text = template.Buffer;
        }
    }
}
