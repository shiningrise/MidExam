//****************************OleDbHelper类***************************
using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.ComponentModel;
//
// Access&Excel : Provider=Microsoft.Jet.OLEDB.4.0; Data Source=
// vfp :  Provider=VFPOLEDB.1;Data Source='bmk.dbf';Collating Sequence=MACHINE;
// oleDbConnectionString
// String conn = ConfigurationManager.ConnectionStrings["VfpConnectionString"].ToString();

namespace MidExam.DAL
{
    /// <summary>
    /// OleDbHelper类封装对Access数据库的添加、删除、修改和选择等操作
    /// </summary>
    public static class OleDbHelper
    {
        private static void CreateErrorLog(Exception errorLog)
        {
            throw errorLog;
        }

        #region 数据库链接

        /// <summary>   
        /// 返回数据库连接  
        /// </summary>   
        /// <returns></returns>  
        public static OleDbConnection GetOleDbConnection(string oleDbConnectionString)
        {
            if (!String.IsNullOrWhiteSpace(oleDbConnectionString))
                return new OleDbConnection(oleDbConnectionString);
            else
                return new OleDbConnection(ConfigurationManager.ConnectionStrings["OleDbConnectionString"].ToString());
        }

        private static readonly string RETURNVALUE = "RETURNVALUE";

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public static void Close(OleDbConnection conn)
        {
            ///判断连接是否已经创建
            if (conn != null)
            {
                ///判断连接的状态是否打开
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            if (conn != null)
            {
                conn.Dispose();
                conn = null;
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public static void Close(OleDbDataReader dr)
        {
            if (dr != null)
            {
                if ( !dr.IsClosed )
                {
                    dr.Close();
                }

                dr.Dispose();
                dr = null;
            }
        }

        #endregion 数据库链接

        #region 执行SQL语句
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="cmdText"></param>
        public static void ExcuteSQL(string oleDbConnectionString, string cmdText)
        {
            using (OleDbConnection conn = GetOleDbConnection(oleDbConnectionString))
            {
                OleDbCommand cmd = CreateOleDbCommand(conn, cmdText, null);
                try
                {
                    conn.Open();
                    ///执行SQL语句
                    cmd.ExecuteNonQuery();
                    ///关闭数据库的连接
                    Close(conn);
                }
                catch (Exception ex)
                {
                    ///记录错误日志
                    CreateErrorLog(ex);
                }
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="prams">SQL语句所需参数</param>
        /// <returns>返回值</returns>
        public static void ExcuteSQL(string oleDbConnectionString, string cmdText, OleDbParameter[] prams)
        {
            OleDbConnection conn = GetOleDbConnection(oleDbConnectionString);
            OleDbCommand cmd = CreateOleDbCommand(conn, cmdText, prams);
            try
            {
                conn.Open();
                ///执行SQL语句
                cmd.ExecuteNonQuery();
                ///关闭数据库的连接
                Close(conn);
            }
            catch (Exception ex)
            {
                ///记录错误日志
                CreateErrorLog(ex);
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>  
        /// <param name="dataReader">返回DataReader对象</param>
        public static void ExcuteSQL(OleDbConnection conn, string cmdText, out OleDbDataReader dataReader)
        {
            conn.Open();
            ///创建Command
            OleDbCommand cmd = CreateOleDbCommand(conn, cmdText, null);
            try
            {
                ///读取数据
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                dataReader = null;
                ///记录错误日志
                CreateErrorLog(ex);
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="prams">SQL语句所需参数</param>
        /// <param name="dataReader">返回DataReader对象</param>
        public static void ExcuteSQL(OleDbConnection conn, string cmdText, OleDbParameter[] prams, out OleDbDataReader dataReader)
        {
            ///创建Command
            OleDbCommand cmd = CreateOleDbCommand(conn, cmdText, prams);
            try
            {
                ///读取数据
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                dataReader = null;
                ///记录错误日志
                CreateErrorLog(ex);
            }
        }

        /// <summary>   
        /// 执行SQL语句并返回数据表   
        /// </summary>   
        /// <param name="Sqlstr">SQL语句</param>   
        /// <returns></returns>   
        public static DataTable ExecuteDataTable(string oleDbConnectionString, String Sqlstr)
        {
            using (OleDbConnection conn = GetOleDbConnection(oleDbConnectionString))
            {
                OleDbDataAdapter da = new OleDbDataAdapter(Sqlstr, conn);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        /// <summary>   
        /// 执行SQL语句并返回数据表   
        /// </summary>   
        /// <param name="Sqlstr">SQL语句</param>   
        /// <returns></returns>   
        public static DataTable ExecuteDataTable(string oleDbConnectionString, String Sqlstr, OleDbParameter[] prams)
        {
            using (OleDbConnection conn = GetOleDbConnection(oleDbConnectionString))
            {
                ///创建Command
                OleDbCommand cmd = CreateOleDbCommand(conn, Sqlstr, null);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="dataSet">DataSet对象</param>
        public static void ExcuteSQL(string oleDbConnectionString, string cmdText, ref DataSet dataSet)
        {
            OleDbConnection conn = GetOleDbConnection(oleDbConnectionString);
            if (dataSet == null)
            {
                dataSet = new DataSet();
            }
            ///创建OleDbDataAdapter
            OleDbDataAdapter da = CreateOleDbDataAdapter(conn,cmdText, null);

            try
            {
                ///读取数据
                da.Fill(dataSet);
                ///关闭数据库的连接
                Close(conn);
            }
            catch (Exception ex)
            {
                ///记录错误日志
                CreateErrorLog(ex);
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="prams">SQL语句所需参数</param>
        /// <param name="dataSet">DataSet对象</param>
        public static void ExcuteSQL(string oleDbConnectionString, string cmdText, OleDbParameter[] prams, ref DataSet dataSet)
        {
            OleDbConnection conn = GetOleDbConnection(oleDbConnectionString);
            if (dataSet == null)
            {
                dataSet = new DataSet();
            }
            ///创建OleDbDataAdapter
            OleDbDataAdapter da = CreateOleDbDataAdapter(conn,cmdText, prams);

            try
            {
                ///读取数据
                da.Fill(dataSet);
                ///关闭数据库的连接
                Close(conn);
            }
            catch (Exception ex)
            {
                ///记录错误日志
                CreateErrorLog(ex);
            }
        }

        #endregion 执行SQL语句

        #region Command Util

        /// <summary>
        /// 创建一个OleDbCommand对象以此来执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="prams">SQL语句所需参数</param>
        /// <returns>返回OleDbCommand对象</returns>
        private static OleDbCommand CreateOleDbCommand(OleDbConnection conn, string cmdText, OleDbParameter[] prams)
        {
            ///设置Command
            OleDbCommand cmd = new OleDbCommand(cmdText, conn);

            ///添加到语句的参数
            if (prams != null)
            {
                foreach (OleDbParameter parameter in prams)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            ///添加返回参数ReturnValue
      //      cmd.Parameters.Add(OleDbHelper.RETURNVALUE, OleDbType.Integer, 4);

            //返回创建的OleDbCommand对象
            return cmd;
        }

        /// <summary>
        /// 创建一个OleDbDataAdapter对象，用此来执行SQL语句
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="prams">SQL语句所需参数</param>
        /// <returns>返回OleDbDataAdapter对象</returns>
        private static OleDbDataAdapter CreateOleDbDataAdapter(OleDbConnection conn,string cmdText, OleDbParameter[] prams)
        {
            ///设置OleDbDataAdapter对象
            OleDbDataAdapter da = new OleDbDataAdapter(cmdText, conn);

            ///添加到语句的参数
            if (prams != null)
            {
                foreach (OleDbParameter parameter in prams)
                {
                    da.SelectCommand.Parameters.Add(parameter);
                }
            }

            ///添加返回参数ReturnValue
            //da.SelectCommand.Parameters.Add(
            //    new OleDbParameter(RETURNVALUE, OleDbType.Integer, 4, ParameterDirection.ReturnValue,
            //    false, 0, 0, string.Empty, DataRowVersion.Default, null));

            ///返回创建的OleDbDataAdapter对象
            return da;
        }

        /// <summary>
        /// 生成SQL语句参数
        /// </summary>
        /// <param name="ParamName">参数名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Direction">参数方向</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public static OleDbParameter CreateParam(string ParamName, OleDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            OleDbParameter param;

            ///当参数大小为0时，不使用该参数大小值
            if (Size > 0)
            {
                param = new OleDbParameter(ParamName, DbType, Size);
            }
            else
            {
                ///当参数大小为0时，不使用该参数大小值
                param = new OleDbParameter(ParamName, DbType);
            }

            ///创建输出类型的参数
            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
            {
                param.Value = Value;
            }

            ///返回创建的参数
            return param;
        }

        /// <summary>
        /// 传入输入参数
        /// </summary>
        /// <param name="ParamName">参数名称</param>
        /// <param name="DbType">参数类型</param></param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的parameter 对象</returns>
        public static OleDbParameter CreateInParam(string ParamName, OleDbType DbType, int Size, object Value)
        {
            return CreateParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
            // oleDbHelper.CreateInParam("@TypeName",OleDbType.Char,255,TypeName)
        }

        /// <summary>
        /// 传入返回值参数
        /// </summary>
        /// <param name="ParamName">参数名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <returns>新的 parameter 对象</returns>
        public static OleDbParameter CreateOutParam(string ParamName, OleDbType DbType, int Size)
        {
            return CreateParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// 传入返回值参数
        /// </summary>
        /// <param name="ParamName">参数名称</param>
        /// <param name="DbType">参数类型</param>
        /// <param name="Size">参数大小</param>
        /// <returns>新的 parameter 对象</returns>
        public static OleDbParameter CreateReturnParam(string ParamName, OleDbType DbType, int Size)
        {
            return CreateParam(ParamName, DbType, Size, ParameterDirection.ReturnValue, null);
        }

        #endregion 
    }
}
