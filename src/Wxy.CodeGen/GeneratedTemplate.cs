using System;
using System.Collections;
using Zeus;
using Zeus.Data;
using Zeus.DotNetScript;
using Zeus.UserInterface;
using MyMeta;
using Dnp.Utils;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Wxy.CodeGen
{
    //GeneratedTemplate : DotNetScriptTemplate
    public class GeneratedTemplate : DotNetScriptTemplate
    {
        public GeneratedTemplate(ZeusContext context) : base(context) { }

        private string buffer;

        public string Buffer
        {
            get { return buffer; }
            set { buffer = value; }
        }
        private string filepath;
        private string Namespace;
        private string BasePageClass;
        private string ClassName;
        private string DatabaseName;
        private string TableName;
        private string PrimaryKey;
        private string PrimaryKeyAlias;
        private string PrimaryKeyLanguageType;
        private ArrayList columns;
        private ITable table;

        // In case if your tables have standard prefixes and you want
        // to remove them from classes, change this.
        private string _tablePrefixRemoval = "FS_CORE_";
        private string _tablePrefixSubstitue = "";

        private string _tableName;
        private string _className;
        private string _nameSpace;
        private string _filePath;
        private string _fileName;
        private string _filePrefix = "stu_";

        //---------------------------------------------------
        // Render() is where you want to write your logic    
        //---------------------------------------------------
        public override void Render()
        {
            string databaseName = input["databaseName"].ToString();
            string tableName = input["tableName"].ToString();
            _tableName = input["tableName"].ToString();
            _className = ToPascalCase(tableName);
            _nameSpace = input["txtNamespace"].ToString();
            _filePath = input["defaultOutputPath"].ToString();
            _fileName = _className + "Controller.cs";

            IDatabase database = MyMeta.Databases[databaseName];
            ITable table = database.Tables[tableName];
            columns = input["lstColumns"] as ArrayList;

            Generate_List_Aspx(table);
            Generate_List_Aspx_cs(table);
            Generate_Edit_Aspx(table);
            Generate_Edit_Aspx_cs(table);

            //	output.write(buffer);
        }

        //生成List页 asp.net webform页面
        private void Generate_List_Aspx(ITable table)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<asp:Content ID=\"Content1\" ContentPlaceHolderID=\"HeadContent\" runat=\"Server\">");
            sb.AppendLine("</asp:Content>");
            sb.AppendLine("<asp:Content ID=\"Content2\" ContentPlaceHolderID=\"MainContent\" runat=\"Server\">");
            sb.AppendLine("    <asp:HyperLink ID=\"ed_add\" runat=\"server\" CssClass=\"btn\" NavigateUrl=\"~/stu_SuzhiEdit.aspx\">添加</asp:HyperLink>");
            sb.AppendLine("    <asp:GridView ID=\"GridView1\" runat=\"server\" AutoGenerateColumns=\"False\" DataKeyNames=\"Id\" CssClass=\"table\">");
            sb.AppendLine("        <Columns>            ");
            foreach (IColumn column in table.Columns)
            {
                if (IsInColumns(column))
                {
                    sb.AppendLine("        <asp:BoundField DataField=\"" + ColumnToPropertyName(column) + "\" HeaderText=\"" + GetDescription(column) + "\" />");
                }
            }
            sb.AppendLine("        </Columns>");
            sb.AppendLine("    </asp:GridView>");
            sb.AppendLine("</asp:Content>");
            sb.AppendLine("");
            _fileName = _filePrefix + table.Name + "_List.aspx";
            output.write(sb.ToString());
            output.save(Path.Combine(_filePath, _fileName), false);
            buffer = buffer + output.text;
            output.clear();
        }

        private void Generate_List_Aspx_cs(ITable table)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Web;");
            sb.AppendLine("using System.Web.UI;");
            sb.AppendLine("using System.Web.UI.WebControls;");
            sb.AppendLine("using MidExam.DAL.Models;");
            sb.AppendLine("using Leafing.Data;");
            sb.AppendLine("");
            sb.AppendLine("public partial class stu_" + table.Name + " : StudentPageBase");
            sb.AppendLine("{");
            sb.AppendLine("    protected void Page_Load(object sender, EventArgs e)");
            sb.AppendLine("    {");
            sb.AppendLine("        if (!IsPostBack)");
            sb.AppendLine("        {");
            sb.AppendLine("            BindData();");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("    private void BindData()");
            sb.AppendLine("    {");
            sb.AppendLine("        this.GridView1.DataSource = " + table.Name + ".Find(p => p.Id > 0 , p => p.bmxh);");
            sb.AppendLine("        this.GridView1.DataBind();");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            _fileName = _filePrefix + table.Name + "_List.aspx.cs";
            output.write(sb.ToString());
            output.save(Path.Combine(_filePath, _fileName), false);
            buffer = buffer + output.text;
            output.clear();
        }

        //生成Edit页 asp.net webform页面
        private void Generate_Edit_Aspx(ITable table)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<asp:Content ID=\"Content1\" ContentPlaceHolderID=\"HeadContent\" runat=\"Server\">");
            sb.AppendLine("</asp:Content>");
            sb.AppendLine("<asp:Content ID=\"Content2\" ContentPlaceHolderID=\"MainContent\" runat=\"Server\">");
            sb.AppendLine("<h1></h1>");
            sb.AppendLine("<div class=\"form-horizontal\">");
            sb.AppendLine("    <fieldset>");
            sb.AppendLine("		<legend>        ");
            sb.AppendLine("		</legend>   ");
            sb.AppendLine("		报名序号：<asp:Label ID=\"lblXH\" runat=\"server\" Text=\"\"></asp:Label>");
            sb.AppendLine("			姓名：<asp:Label ID=\"lblXM\" runat=\"server\" Text=\"\"></asp:Label>");

            foreach (IColumn column in table.Columns)
            {
                if (IsInColumns(column))
                {

                    sb.AppendLine("    <div class=\"control-group\">");
                    sb.AppendLine("        <label class=\"control-label\" for=\"ed_" + ColumnToPropertyName(column) + "\">" + GetDescription(column) + "</label>");
                    sb.AppendLine("        <div class=\"controls\">");
                    if (GetControl(column) == "DropDownList")
                    {
                        sb.AppendLine("            <asp:DropDownList ID=\"ed_" + ColumnToPropertyName(column) + "\" runat=\"server\">");
                        sb.AppendLine("            </asp:DropDownList>");
                    }
                    else
                    {
                        sb.AppendLine("            <asp:TextBox ID=\"ed_" + ColumnToPropertyName(column) + "\" runat=\"server\"></asp:TextBox>");
                    }
                    sb.AppendLine("        </div>");
                    sb.AppendLine("    </div>");
                }
            }
            sb.AppendLine("    </fieldset>");
            sb.AppendLine("</div>");
            sb.AppendLine("</asp:Content>");
            _fileName = _filePrefix + table.Name + "_Edit.aspx";
            output.write(sb.ToString());
            output.save(Path.Combine(_filePath, _fileName), false);
            buffer = buffer + output.text;
            output.clear();
        }

        private void Generate_Edit_Aspx_cs(ITable table)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Web;");
            sb.AppendLine("using System.Web.UI;");
            sb.AppendLine("using System.Web.UI.WebControls;");
            sb.AppendLine("using MidExam.DAL;");
            sb.AppendLine("using MidExam.DAL.Models;");
            sb.AppendLine("using Leafing.Web;");
            sb.AppendLine("");
            sb.AppendLine("public partial class stu_SuzhiEdit : StudentPageBase");
            sb.AppendLine("{");
            sb.AppendLine("    [HttpParameter(AllowEmpty = true)]");
            sb.AppendLine("    private long Id;   ");
            sb.AppendLine("    ");
            sb.AppendLine("    protected void Page_Load(object sender, EventArgs e)");
            sb.AppendLine("    {");
            sb.AppendLine("        if (!IsPostBack)");
            sb.AppendLine("        {");
            sb.AppendLine("            BindData(Id);");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("    private void BindData(long id)");
            sb.AppendLine("    {");
            sb.AppendLine("        this.lblXH.Text = this.CurBmk.bmxh;");
            sb.AppendLine("        this.lblXM.Text = this.CurBmk.xm;");
            sb.AppendLine("        Suzhi sz = Suzhi.FindById(id);");
            sb.AppendLine("        if (sz != null)");
            sb.AppendLine("        {");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("    private void SaveData()");
            sb.AppendLine("    {");
            sb.AppendLine("");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            _fileName = _filePrefix + table.Name + "_Edit.aspx.cs";
            output.write(sb.ToString());
            output.save(Path.Combine(_filePath, _fileName), false);
            buffer = buffer + output.text;
            output.clear();
        }

        private void BuildPublicAccessors(IColumns Columns)
        {
            if (Columns.Count > 0)
            {
                output.writeln("\t\t#region Public Properties");

                foreach (IColumn field in Columns)
                {
                    if (IsInColumns(field))
                    {
                        string fieldAccessor = ColumnToPropertyName(field);
                        string fieldName = ColumnToMemberVariable(field);
                        string fieldType = (field.IsInForeignKey && !field.IsInPrimaryKey ? ToPascalCase(field.ForeignKeys[0].PrimaryTable.Alias.Replace(" ", "")) : ColumnToNHibernateType(field));

                        output.writeln("");
                        //output.writeln( "\t\t/// <summary>" );

                        //foreach( string s in field.Description.Split( new char[] { '\n' } ) )
                        //{
                        //		output.writeln( "\t\t/// " + s );
                        //}
                        //output.writeln( "\t\t/// </summary>" );

                        output.write(ActiveRecordColumnAttributes(field));
                        if (field.IsNullable && IsValueType(field.LanguageType))
                            output.writeln("\t\tpublic " + fieldType + "? " + fieldAccessor + "{ get; set; }");
                        else
                            output.writeln("\t\tpublic " + fieldType + " " + fieldAccessor + "{ get; set; }");
                    }
                }
                output.writeln("\n\t\t#endregion");
            }
        }

        private string ActiveRecordColumnAttributes(IColumn c)
        {
            StringBuilder xml = new StringBuilder();
            if (c.Description.Length > 0)
                xml.Append("\t\t[Display(Name = \"" + c.Description + "\")]\r\n");
            if (!c.IsInPrimaryKey)
            {
                // create sets & such for foreign keys !!!
                if (c.IsInForeignKey)
                {
                    if (c.ForeignKeys.Count > 1)
                    {
                        xml.Append("<!-- More than one foreign column is mapped to ").Append(c.Name).Append(". Include your own custom attributes. -->\r\n\t\t");
                    }
                    else
                    {
                        // Many-to-One relationship.
                        IForeignKey fk = c.ForeignKeys[0];
                        xml.Append("\t\t[BelongsTo(\"")
                           .Append(c.Name);
                        xml.Append("\")]");
                    }
                }
                else
                {
                    // Regular property.
                    if (!c.IsNullable)
                    {
                        xml.Append("\t\t[Required]\r\n");
                    }
                    /*	xml.Append( "\t\t[Property(Column=\"").Append( c.Name ).Append("\"");;
					
                        if( c.LanguageType == "string" )
                        {
                            xml.Append( ", Length=" ).Append( c.CharacterMaxLength );
                        }
                        xml.Append( ")]" );	*/
                }
            }
            else
            {		// c.IsInPrimaryKey is true. Generate primary key.
                /*		xml.Append( "\t\t[PrimaryKey(PrimaryKeyType.Identity ,\"").Append( c.Name ).Append("\"");;
					
                        if( c.LanguageType == "string" )
                        {
                            xml.Append( ", Length=" ).Append( c.CharacterMaxLength );
                        }
                        xml.Append( ")]" );  */
            }
            return xml.ToString();
        }

        #region 辅助方法

        // check if column has been selected via UI
        private bool IsInColumns(IColumn c)
        {
            foreach (string columnName in columns)
            {
                if (columnName == c.Name) return true;
            }
            return false;
        }
        // removes all spaces
        private string TrimSpaces(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, @"\s+", "");
        }

        private bool IsValueType(string type)
        {
            switch (type.ToLower())
            {
                case "sbyte":
                case "byte":
                case "short":
                case "ushort":
                case "int":
                case "uint":
                case "long":
                case "ulong":
                case "char":
                case "float":
                case "double":
                case "bool":
                case "decimal":
                case "DateTime":
                    return true;
                    break;

                default:
                    return false;
                    break;
            }
        }

        private string ToLeadingCaps(string name)
        {
            char[] chars = name.ToLower().ToCharArray();
            chars[0] = Char.ToUpper(chars[0]);
            return new string(chars);
        }

        private string ToLeadingLower(string name)
        {
            char[] chars = name.ToCharArray();
            chars[0] = Char.ToLower(chars[0]);
            return new string(chars);
        }

        /** Babu: This one is used for C# class generation */
        private string ToPascalCase(string name)
        {
            string notStarting_SC = "";
            if (_tablePrefixRemoval != null)
                notStarting_SC = Regex.Replace(name, _tablePrefixRemoval, _tablePrefixSubstitue);
            else
                notStarting_SC = name;
            string notStartingAlpha = Regex.Replace(notStarting_SC, "^[^a-zA-Z]+", "");
            string workingString = ToLowerExceptCamelCase(notStartingAlpha);
            workingString = RemoveSeparatorAndCapNext(workingString);
            return workingString;
        }

        private string ToCamelCase(string name)
        {
            string notStarting_SC = "";
            if (_tablePrefixRemoval != null)
                notStarting_SC = Regex.Replace(name, _tablePrefixRemoval, _tablePrefixSubstitue);
            else
                notStarting_SC = name;
            string notStartingAlpha = Regex.Replace(notStarting_SC, "^[^a-zA-Z]+", "");
            string workingString = ToLowerExceptCamelCase(notStartingAlpha);
            workingString = RemoveSeparatorAndCapNext(workingString);
            char[] chars = workingString.ToCharArray();
            chars[0] = Char.ToLower(chars[0], CultureInfo.InvariantCulture);
            workingString = new string(chars);
            return workingString;
        }

        private string RemoveSeparatorAndCapNext(string input)
        {
            string dashUnderscore = "-_";
            string workingString = input;
            char[] chars = workingString.ToCharArray();
            int under = workingString.IndexOfAny(dashUnderscore.ToCharArray());
            while (under > -1)
            {
                chars[under + 1] = Char.ToUpper(chars[under + 1], CultureInfo.InvariantCulture);
                workingString = new String(chars);
                under = workingString.IndexOfAny(dashUnderscore.ToCharArray(), under + 1);
            }
            chars[0] = Char.ToUpper(chars[0], CultureInfo.InvariantCulture);
            workingString = new string(chars);
            return Regex.Replace(workingString, "[-_]", "");
        }

        private string ToLowerExceptCamelCase(string input)
        {
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                int left = (i > 0 ? i - 1 : i);
                int right = (i < chars.Length - 1 ? i + 1 : i);
                if (i != left && i != right)
                {
                    if (Char.IsUpper(chars[i]) && Char.IsLetter(chars[left]) && Char.IsUpper(chars[left]))
                    {
                        chars[i] = Char.ToLower(chars[i], CultureInfo.InvariantCulture);
                    }
                    else if (Char.IsUpper(chars[i]) && Char.IsLetter(chars[right]) && Char.IsUpper(chars[right]))
                    {
                        chars[i] = Char.ToLower(chars[i], CultureInfo.InvariantCulture);
                    }
                    else if (Char.IsUpper(chars[i]) && !Char.IsLetter(chars[right]))
                    {
                        chars[i] = Char.ToLower(chars[i], CultureInfo.InvariantCulture);
                    }
                }
            }
            chars[chars.Length - 1] = Char.ToLower(chars[chars.Length - 1], CultureInfo.InvariantCulture);
            return new string(chars);
        }

        private int CountRequiredFields(IColumns Columns)
        {
            return Columns.Count - CountNullableFields(Columns);
        }

        private int CountNullableFields(IColumns Columns)
        {
            int i = 0;
            foreach (IColumn c in Columns)
            {
                if (c.IsNullable)
                {
                    i++;
                }
            }
            return i;
        }

        private int CountUniqueFields(IColumns Columns)
        {
            int i = 0;
            foreach (IColumn c in Columns)
            {
                if (!c.IsNullable && c.IsInPrimaryKey)
                {
                    i++;
                }
            }
            return i;
        }

        private string ColumnToPropertyName(IColumn Column)
        {
            return ToPascalCase(UniqueColumn(Column));
        }

        private string ColumnToMemberVariable(IColumn Column)
        {
            return ToCamelCase(UniqueColumn(Column));
        }

        private void GenerateClassTableHeader(IColumns Columns)
        {
            output.writeln("/*");
            output.writeln(" * This class maps to " + _tableName + " with the following columns:");
            foreach (IColumn field in Columns)
            {
                string propertyName = field.Name + "(" + ColumnToPropertyName(field) + ")";
                string fpname = String.Format("{0,-40}", propertyName);
                output.write(" * \t " + fpname);
                output.write("| Type:" + String.Format("{0,-10}", field.DataTypeName));
                output.write("| Len:" + String.Format("{0,-4}", field.CharacterMaxLength));
                output.write("| Nullable:" + String.Format("{0,-1}", field.IsNullable ? "T" : "F"));
                output.write("| PK:" + String.Format("{0,-1}", field.IsInPrimaryKey ? "T" : "F"));
                output.write("| FK:=" + String.Format("{0,-1}", field.IsInForeignKey ? "T" : "F"));
                output.writeln("");
            }
            output.writeln(" */");
        }

        private string UniqueColumn(IColumn Column)
        {
            string c = Column.Alias.Replace(" ", "");
            if (Column.Table != null && Column.Table.Alias.Replace(" ", "") == c)
            {
                c += "Name";
            }
            if (Column.View != null && Column.View.Alias.Replace(" ", "") == c)
            {
                c += "Name";
            }
            return c;
        }

        // nhibernate doesn't have these, so use the existing types
        private string ColumnToNHibernateType(IColumn Column)
        {
            string retVal = Column.LanguageType;

            switch (Column.LanguageType)
            {
                case "sbyte":
                    retVal = "byte";
                    break;
                case "uint":
                    retVal = "int";
                    break;
                case "ulong":
                    retVal = "long";
                    break;
                case "ushort":
                    retVal = "short";
                    break;
            }

            return retVal;
        }

        public string GetDescription(IColumn column)
        {
            if(String.IsNullOrEmpty(column.Description))
                return column.Name;
            string[] list = column.Description.Split('|');
            if (list != null && list.Length >= 1 )
            {
                return list[0];
            }
            return column.Name;
        }

        public string GetControl(IColumn column)
        {
            if (String.IsNullOrEmpty(column.Description))
                return "TextBox";
            string[] list = column.Description.Split('|');
            if (list != null && list.Length >=2 )
            {
                return list[1];
            }
            else
            {
                return "TextBox";
            }
        }

        #endregion
    }
}

//-- Class DotNetScriptTemplate Generated by Zeus
namespace Zeus.DotNetScript
{
    public abstract class DotNetScriptTemplate : _DotNetScriptTemplate
    {
        protected Zeus.UserInterface.GuiController ui;
        protected MyMeta.dbRoot MyMeta;
        protected Dnp.Utils.Utils DnpUtils;
        public DotNetScriptTemplate(IZeusContext context)
            : base(context)
        {
            this.ui = context.Objects["ui"] as Zeus.UserInterface.GuiController;
            this.MyMeta = context.Objects["MyMeta"] as MyMeta.dbRoot;
            this.DnpUtils = context.Objects["DnpUtils"] as Dnp.Utils.Utils;
        }
    }
}