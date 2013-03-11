using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace MidExam.DAL
{
    public abstract class DbfHelper
    {
        /// <summary>   
        /// 执行SQL语句并返回数据表   
        /// </summary>   
        /// <param name="Sqlstr">SQL语句</param>   
        /// <returns></returns>   
        public static DataTable ExecuteDataTable(string tablePath, string tableName)
        {
            using (OleDbConnection conn = GetOleDbConnection(tablePath, tableName))
            {
                OleDbDataAdapter da = new OleDbDataAdapter("select * from " + tableName, conn);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }


        public static OleDbConnection GetOleDbConnection(string tablePath, string tableName)
        {
            //Provider=VFPOLEDB.1;Data Source='D:\userdbfs\bmk.dbf';Collating Sequence=MACHINE;"
            //Provider=Microsoft.Jet.OLEDB.4.0;Data   Source=F:\DBF文件;Extended   Properties=dBASE   5.0
            string tableFullPath = Path.Combine(tablePath, tableName);
            return OleDbHelper.GetOleDbConnection(string.Format("Provider=VFPOLEDB.1;Data Source='{0}';Collating Sequence=MACHINE;", tableFullPath));
        }
    }
}
