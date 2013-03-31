using System;
using System.Collections;
using Zeus;
using Zeus.Data;
using Zeus.DotNetScript;
using Zeus.UserInterface;
using MyMeta;
using Dnp.Utils;

namespace Wxy.CodeGen
{

    public class GeneratedGui : DotNetScriptGui
    {
        public GeneratedGui(ZeusContext context) : base(context) { }

        public override void Setup()
        {
            ui.Title = "ASP.NET InlineGrid (CSharp dOOdads)";
            ui.Width = 350;
            ui.Height = 450;

            // width of labels
            int lableWidth = 120;

            // Grab default output path
            string sOutputPath = "";
            if (input.Contains("defaultOutputPath"))
            {
                sOutputPath = input["defaultOutputPath"].ToString();
            }

            // Setup Folder selection input control.
            GuiLabel lblPath = ui.AddLabel("lblPath", "Select the output path:", "Select the output path in the field below.");
            GuiTextBox txtPath = ui.AddTextBox("txtPath", sOutputPath, "Select the Output Path.");
            GuiFilePicker btnPath = ui.AddFilePicker("btnPath", "Select Path", "Select the Output Path.", "txtPath", true);

            // size text box and button
            txtPath.Width = 250;
            btnPath.Width = ui.Width - txtPath.Left - txtPath.Width - 20;

            // position button
            btnPath.Top = txtPath.Top;
            btnPath.Left = txtPath.Left + txtPath.Width;

            GuiLabel lblNamespace = ui.AddLabel("lblNamespace", "Namespace: ", "Provide namespace.");
            GuiTextBox txtNamespace = ui.AddTextBox("txtNamespace", "FineSchool.MvcApp.Areas.Admin.Controllers", "Provide your namespace.");

            // size label and text box
            lblNamespace.Width = lableWidth;
            txtNamespace.Width = ui.Width - lblNamespace.Left - lblNamespace.Width - 20;

            // position text box
            txtNamespace.Top = lblNamespace.Top;
            txtNamespace.Left = lblNamespace.Left + lblNamespace.Width;

            // Setup Database selection combobox.
            GuiLabel lblDatabases = ui.AddLabel("lblDatabases", "Select a database:", "Select a database in the dropdown below.");
            GuiComboBox cmbDatabases = ui.AddComboBox("databaseName", "Select a database.");

            // size label and combo box
            lblDatabases.Width = lableWidth;
            cmbDatabases.Width = ui.Width - lblDatabases.Left - lblDatabases.Width - 20;

            // position combo box
            cmbDatabases.Top = lblDatabases.Top;
            cmbDatabases.Left = lblDatabases.Left + lblDatabases.Width;

            // Setup Tables selection multi-select listbox.
            GuiLabel lblTables = ui.AddLabel("lblTables", "Select table:", "Select table from the combobox below.");
            GuiComboBox cmbTables = ui.AddComboBox("tableName", "Select a table.");

            // size label and combo box
            lblTables.Width = lableWidth;
            cmbTables.Width = ui.Width - lblTables.Left - lblTables.Width - 20;

            // position combo box
            cmbTables.Top = lblTables.Top;
            cmbTables.Left = lblTables.Left + lblTables.Width;

            // setup columns list box
            GuiLabel lblColumns = ui.AddLabel("lblColumns", "Select columns:", "Select columns from the listbox below.");
            GuiListBox lstColumns = ui.AddListBox("lstColumns", "Select columns.");

            // size label and combo box
            lstColumns.Height = 150;
            lblColumns.Width = lableWidth;
            lstColumns.Width = ui.Width - lblColumns.Left - lblColumns.Width - 20;

            // position combo box
            lstColumns.Top = lblColumns.Top;
            lstColumns.Left = lblColumns.Left + lblColumns.Width;

            // bind data to the controls
            cmbDatabases.BindData(MyMeta.Databases);
            cmbDatabases.SelectedValue = MyMeta.DefaultDatabase.Name;
            cmbTables.BindData(MyMeta.Databases[cmbDatabases.SelectedValue].Tables);


            // Attach the onchange event to the cmbDatabases control.
            cmbDatabases.AttachEvent("onchange", "cmbDatabases_onchange");
            cmbTables.AttachEvent("onchange", "cmbTables_onchange");
            cmbTables.SelectedValue = "Suzhi";
            lstColumns.BindData(MyMeta.Databases[cmbDatabases.SelectedValue].Tables[cmbTables.SelectedValue].Columns);

            ui.ShowGui = true;
        }

        public void cmbDatabases_onchange(GuiComboBox control)
        {
            GuiComboBox cmbDatabases = ui["databaseName"] as GuiComboBox;
            GuiComboBox cmbTables = ui["tableName"] as GuiComboBox;

            cmbTables.BindData(MyMeta.Databases[cmbDatabases.SelectedValue].Tables);

            // clear columns list
            GuiListBox lstColumns = ui["lstColumns"] as GuiListBox;
            lstColumns.Clear();
        }

        public void cmbTables_onchange(GuiComboBox control)
        {
            try
            {
                GuiComboBox cmbDatabases = ui["databaseName"] as GuiComboBox;
                GuiComboBox cmbTables = ui["tableName"] as GuiComboBox;
                GuiListBox lstColumns = ui["lstColumns"] as GuiListBox;
                lstColumns.BindData(MyMeta.Databases[cmbDatabases.SelectedValue].Tables[cmbTables.SelectedValue].Columns);
            }
            catch (Exception ex)
            {
            }
        }
    }

}
//-- Class DotNetScriptGui Generated by Zeus
namespace Zeus.DotNetScript
{
    public abstract class DotNetScriptGui : _DotNetScriptGui
    {
        protected Zeus.UserInterface.GuiController ui;
        protected MyMeta.dbRoot MyMeta;
        protected Dnp.Utils.Utils DnpUtils;
        public DotNetScriptGui(IZeusContext context)
            : base(context)
        {
            this.ui = context.Objects["ui"] as Zeus.UserInterface.GuiController;
            this.MyMeta = context.Objects["MyMeta"] as MyMeta.dbRoot;
            this.DnpUtils = context.Objects["DnpUtils"] as Dnp.Utils.Utils;
        }
    }
}