
using System.Data.OleDb;

using System; 
using System.IO; 
using System.Data; 
using System.Text; 
using System.Collections;

using System.Drawing;

using System.Web;

using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace MidExam.DAL.Util
{
	/// <summary>
	/// ExcelHelper 的摘要说明。
	/// </summary>
	public class ExcelHelper
	{
		public ExcelHelper()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        /// <summary>
        /// 获取Sheet表名
        /// </summary>
        /// <param name="excelFilePath">文件地址</param>
        /// <returns>Sheet表名ArrayList</returns>
        public static List<Sheet> GetSheetNameList(string excelFilePath)
        {
            string filePath = excelFilePath;
            if (File.Exists(filePath) == false)
            {
                throw new FileNotFoundException("用于导入的文件不存在");
            }
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection objConn = new OleDbConnection(strConn);

            List<Sheet> SheetNameList = new List<Sheet>();

            try
            {
                objConn.Open();

                DataTable dtExcelSchema = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                string SheetName = "";

                for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
                {
                    SheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();
                    Sheet sheet = new Sheet(SheetName);
                    SheetNameList.Add(sheet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objConn.Close();
            }
            return SheetNameList;
        }

		/// <summary>
		/// 读取Excel文档
		/// </summary>
		/// <param name="Path">文件名称</param>
		/// <returns>返回一个数据集</returns>
		public static DataSet ExcelToDS(string Path)
		{
			try
			{
				string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +"Data Source="+ Path +";"+"Extended Properties=Excel 8.0;";
				OleDbConnection conn = new OleDbConnection(strConn);
				conn.Open();  
				string strExcel = "";   
				OleDbDataAdapter myCommand = null;
				DataSet ds = null;
				strExcel="select * from [Sheet1$]";
				myCommand = new OleDbDataAdapter(strExcel, strConn);
				ds = new DataSet();
				myCommand.Fill(ds,"table1");   
				return ds;
			}
			catch(System.Data.OleDb.OleDbException ex)
			{
				System.Diagnostics.Debug.WriteLine ("写入Excel发生错误："+ex.Message );
				return null;
			}
		}

        public static DataSet ExcelToDS(string Path,string sheetName)
        {
            try
            {
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                string strExcel = "";
                OleDbDataAdapter myCommand = null;
                DataSet ds = null;
                strExcel = string.Format("select * from [{0}]", sheetName); ;
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                ds = new DataSet();
                myCommand.Fill(ds, "table1");
                return ds;
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                System.Diagnostics.Debug.WriteLine("写入Excel发生错误：" + ex.Message);
                return null;
            }
        }

        public static DataTable ExcelToDataTable(string Path, string sheetName)
        {
            try
            {
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                string strExcel = "";
                OleDbDataAdapter myCommand = null;
                DataSet ds = null;
                strExcel = string.Format("select * from [{0}$]", sheetName); ;
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                ds = new DataSet();
                myCommand.Fill(ds, "table1");
                DataTable dt = null;
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                return dt ;
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                System.Diagnostics.Debug.WriteLine("写入Excel发生错误：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取Excel文件地工作表名列表
        /// </summary>
        /// <param name="excelFilePath">Excel文件地址</param>
        /// <returns>包括所有SheetName的ArrayList</returns>


		public static void DataTableToExcel(System.Data.DataView dataview,string Path,Hashtable NameMap)
		{
			try
			{
				string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +"Data Source="+ Path +";"+"Extended Properties=Excel 8.0;";
				OleDbConnection conn = new OleDbConnection(strConn);
				conn.Open();  
				System.Data.OleDb.OleDbCommand cmd=new OleDbCommand ();
				cmd.Connection = conn;

				string strSql = string.Empty ,strSql1 = string.Empty ;
				int i , j ;

				for(  i = 0 ; i < dataview.Count ; i++ )
				{
					
					strSql = "INSERT INTO [sheet1$] (";
					strSql1 = ") values(";
					for(  j = 0 ; j < dataview.Table.Columns.Count ; j++)
					{
						if( NameMap.ContainsKey( dataview.Table.Columns[j].ColumnName ) )
						{
							strSql += NameMap[dataview.Table.Columns[j].ColumnName] +"," ;  //2414210
							strSql1 += "'" +dataview[i][j].ToString() + "',";
						}
						
					}
					
					try
					{
						if( strSql.EndsWith(",") ) 
							strSql = strSql.Substring(0,strSql.Length - 1 ) ;
						if( strSql1.EndsWith(",") ) 
							strSql1 = strSql1.Substring(0,strSql1.Length - 1 ) ;

						strSql1 = strSql1 + ")";
						strSql = strSql + strSql1 ;

						cmd.CommandText = strSql ;
						cmd.ExecuteNonQuery();
					}
					catch(Exception ex)
					{
						System.Diagnostics.Debug.WriteLine ("写入Excel发生错误："+ strSql + strSql1 + ex.Message );
                        throw new Exception(strSql + ex.Message);
					}
				}
				conn.Close ();
			}
			catch(System.Data.OleDb.OleDbException ex)
			{
				System.Diagnostics.Debug.WriteLine ("写入Excel发生错误："+ex.Message );
			}
		}

		public static void DataTableToExcel(System.Data.DataView dataview,string Path)
		{
			try
			{
				string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +"Data Source="+ Path +";"+"Extended Properties=Excel 8.0;";
				OleDbConnection conn = new OleDbConnection(strConn);
				conn.Open();  
				System.Data.OleDb.OleDbCommand cmd=new OleDbCommand ();
				cmd.Connection = conn;

				string strSql = string.Empty ,strSql1 = string.Empty ;
				int i , j ;

				for(  i = 0 ; i < dataview.Count ; i++ )
				{
					
					strSql = "INSERT INTO [sheet1$] (";
					strSql1 = ") values(";
					for(  j = 0 ; j < dataview.Table.Columns.Count ; j++)
					{
						strSql += dataview.Table.Columns[j].ColumnName +"," ;  
						strSql1 += "'" +dataview[i][j].ToString() + "',";
					}
			//		
					try
					{
						if( strSql.EndsWith(",") ) 
							strSql = strSql.Substring(0,strSql.Length - 1 ) ;
						if( strSql1.EndsWith(",") ) 
							strSql1 = strSql1.Substring(0,strSql1.Length - 1 ) ;
						strSql1 = strSql1 + ")";
						strSql = strSql + strSql1 ;
						cmd.CommandText = strSql  ;
						cmd.ExecuteNonQuery();
					}
					catch(Exception ex)
					{
						System.Diagnostics.Debug.WriteLine ("写入Excel发生错误："+ strSql + ex.Message );
                        throw new Exception(strSql + ex.Message);
					}
				}
				conn.Close ();
			}
			catch(System.Data.OleDb.OleDbException ex)
			{
				System.Diagnostics.Debug.WriteLine ("写入Excel发生错误："+ex.Message );
			}
		}


       
	}

    public class Sheet
    {
        private string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Name
        {
            get 
            {
                string _name = this.Value;
                if (_name.StartsWith("'"))
                {
                    _name = _name.Substring(1);
                }
                if (_name.EndsWith("'"))
                {
                    _name = _name.Substring( 0,_name.Length - 1 );
                }
                if (_name.EndsWith("$"))
                {
                    _name = _name.Substring(0, _name.Length - 1);
                }
                return _name; 
            }
        }

        public Sheet()
        {
        }

        public Sheet( string sheetValue)
        {
            this._value = sheetValue;
        }
    }

    public class ExcelXmlHelper
    {
        public int PageCount = 0;
        public System.Collections.ArrayList ExcelTableListOut = new System.Collections.ArrayList();

        #region 初始化工作
        public string WorkbookTemplate;
        public string WorksheetTemplate;

        public string TableTemplate;

        public System.Collections.ArrayList TableRowTemplate;
        public string RowBreaksTemplate;
        public int PageRowCount;
        public int PageBreakRowNum;

        public void LoadWorkbookTemplate(string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader sr = File.OpenText(fileName);
                WorkbookTemplate = sr.ReadToEnd();
                sr.Close();
            }
            else
            {
                throw new FileNotFoundException("加裁Excel的xml模板文件时，找不到文件", fileName);
            }
            InitWorksheetTemplate();
            InitTableTemplate();

            InitRowBreaksTemplate();

            InitTableRowTemplate();

            InitPageRowCount();
            InitPageBreakRowNum();
        }
        private void InitWorksheetTemplate()
        {
            string ResultString = null;
            try
            {
                Regex RegexObj = new Regex("<Worksheet[^>]*>(.*?)</Worksheet>",
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
                ResultString = RegexObj.Match(WorkbookTemplate).Value;
            }
            catch (ArgumentException )
            {
                // Syntax error in the regular expression
            }
            WorksheetTemplate = ResultString;
            WorkbookTemplate = WorkbookTemplate.Replace(WorksheetTemplate, "$WorksheetTemplate$");
        }
        private void InitTableTemplate()
        {
            string ResultString = null;
            try
            {
                Regex RegexObj = new Regex("<Table[^>]*>(.*?)</Table>",
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
                ResultString = RegexObj.Match(WorksheetTemplate).Value;
            }
            catch (ArgumentException)
            {
                // Syntax error in the regular expression
            }
            TableTemplate = ResultString;
            WorksheetTemplate = WorksheetTemplate.Replace(TableTemplate, "$TableTemplate$");
        }
        private void InitRowBreaksTemplate()
        {
            string ResultString = null;
            //try
            //{
            //    //<PageBreaks xmlns="urn:schemas-microsoft-com:office:excel">
            //    Regex RegexObj = new Regex("(<RowBreaks>.*?</RowBreaks>)",
            //        RegexOptions.Singleline | RegexOptions.IgnoreCase);
            //    ResultString = RegexObj.Match(WorksheetTemplate).Value;
            //}
            //catch (ArgumentException ex)
            //{
            //    // Syntax error in the regular expression
            //}
            ;
            int i = WorksheetTemplate.IndexOf("<RowBreaks>");
            int j = WorksheetTemplate.IndexOf("</RowBreaks>");
            ResultString = WorksheetTemplate.Substring(i,j-i+12);

            RowBreaksTemplate = ResultString;
            WorksheetTemplate = WorksheetTemplate.Replace(RowBreaksTemplate, "$RowBreaksTemplate$");
        }
        private void InitTableRowTemplate()
        {
            try
            {
                TableRowTemplate = new System.Collections.ArrayList();
                Regex RegexObj = new Regex("<Row\\s[^>]*>(.*?)</Row>|<Row\\s[^/]*/>",
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
                Match MatchResults = RegexObj.Match(this.TableTemplate);

                bool isFirst = true;
                while (MatchResults.Success)
                {
                    TableRowTemplate.Add(MatchResults.Value);
                    if (isFirst)
                    {
                        this.TableTemplate = this.TableTemplate.Replace(MatchResults.Value, "$TableRowTemplate$");
                        isFirst = false;
                    }
                    else
                    {
                        this.TableTemplate = this.TableTemplate.Replace(MatchResults.Value, "");
                    }
                    MatchResults = MatchResults.NextMatch();
                }

            }
            catch (ArgumentException )
            {
                // Syntax error in the regular expression
            }
            //     WorksheetTemplate = WorksheetTemplate.Replace(RowBreaksTemplate, "$RowBreaksTemplate$");
        }
        private void InitPageRowCount()
        {
            string ResultString = null;
            ResultString = Regex.Match(this.TableTemplate, "ss:ExpandedRowCount=\"(\\d*)\"",
                    RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups[1].Value;
            PageRowCount = Int32.Parse(ResultString);
        }
        private void InitPageBreakRowNum()
        {
            string ResultString = null;
            try
            {
                ResultString = Regex.Match(this.RowBreaksTemplate, "<Row>(.*?)</Row>",
                    RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups[1].Value;
            }
            catch (ArgumentException )
            {
                // Syntax error in the regular expression
            }
            this.PageBreakRowNum = Int32.Parse(ResultString);
        }
        #endregion

        /// <summary>
        /// 添加新页
        /// </summary>
        /// <returns></returns>
        public void AddExcelPage()
        {
            string strRtn = string.Empty;
            foreach (string str in this.TableRowTemplate)
            {
                strRtn += str;
            }
            ExcelTableListOut.Add(strRtn);
            PageCount++;
        }

        /// <summary>
        /// 替换标签项
        /// </summary>
        /// <param name="strExcelPage"></param>
        /// <param name="strSrc"></param>
        /// <param name="strTarget"></param>
        /// <returns></returns>
        public void Replace(string strSrc, string strTarget)
        {
            string str = ExcelTableListOut[ExcelTableListOut.Count - 1].ToString();
            str = str.Replace(strSrc, strTarget);
            ExcelTableListOut[ExcelTableListOut.Count - 1] = str;
        }

        /// <summary>
        /// 删除所有标签
        /// </summary>
        /// <param name="strExcelPage"></param>
        private void ClearLabel(string strExcelPage)
        {
            try
            {
                strExcelPage = Regex.Replace(strExcelPage, "\\$(.*?)\\$", "",
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
            }
            catch (ArgumentException )
            {
                // Syntax error in the regular expression
            }
        }

        private string _excelFile;

        public string ExcelFile
        {
            get { return _excelFile; }
            set { _excelFile = value; }
        }

        public string MakeExcelFile()
        {
            string strRtn = string.Empty;
            foreach (string str in this.ExcelTableListOut)
            {
                strRtn += str;
            }
            this.TableTemplate = this.TableTemplate.Replace("$TableRowTemplate$", strRtn);

            string strTemp = string.Format("ss:ExpandedRowCount=\"{0}\"", this.PageRowCount * this.PageCount);

            try
            {
                this.TableTemplate = Regex.Replace(this.TableTemplate, "ss:ExpandedRowCount=\"(\\d*)\"", strTemp,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
            }
            catch (ArgumentException )
            {
                // Syntax error in the regular expression
            }

            string strRowBreaks = "";
            for (int j = 1; j < this.PageCount; j++)
            {
                strRowBreaks += string.Format("<RowBreak><Row>{0}</Row></RowBreak>", this.PageRowCount * j);
            }
            strRowBreaks = string.Format("<RowBreaks>{0}</RowBreaks>", strRowBreaks);
            this.WorksheetTemplate = this.WorksheetTemplate.Replace("$RowBreaksTemplate$", strRowBreaks);

            this.WorksheetTemplate = this.WorksheetTemplate.Replace("$TableTemplate$", this.TableTemplate);
            this.WorkbookTemplate = this.WorkbookTemplate.Replace("$WorksheetTemplate$", this.WorksheetTemplate);

            this.WorkbookTemplate.Replace("<?xml version=\"1.0\"?>", "<?xml version=\"1.0\" encoding=\"GB2312\"?>");

            return this.WorkbookTemplate;
        }
    }
}
