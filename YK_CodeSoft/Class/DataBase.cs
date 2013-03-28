using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YK_CodeSoft.Class
{
    /// <summary>
    /// 服务器数据库信息操作类
    /// </summary>
    public class DataBase
    {
        /// <summary>
        /// 获取服务器数据库信息
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public List<string> GetDataBaseInfo(DatabaseModel model)
        {
            try
            {
                //获取列出当前系统中的数据库信息（数据库名、数据库大小、数据库类别）
                DbHelperSQL.connectionString = "server=" + model.ServerName.Trim() + ";database =master;uid = " + model.Uid.Trim() + "; pwd = " + model.Pwd;
                DataSet ds = DbHelperSQL.Query("exec sp_databases");
                List<string> list = new List<string>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(dr[0].ToString());
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// //获取数据库中表的信息（数据库名、拥有者、表名、表类别、备注）
        /// </summary>
        /// <param name="Login1"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetTableInfo(DatabaseModel model)
        {
            try
            {
                DbHelperSQL.connectionString = "server=" + model.ServerName.Trim() + ";database =" + model.DataBaseName.ToString() + ";uid = " + model.Uid + "; pwd = " + model.Pwd;
                DataSet ds = DbHelperSQL.Query("sp_tables null,'dbo'");
                Dictionary<string, string> list = new Dictionary<string, string>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(dr[2].ToString(), dr[3].ToString());//表名、表类别作为键值
                }
                return list;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取表或视图的列信息
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<string> GetTableColumns(string TableName, DatabaseModel model)
        {
            try
            {
                DbHelperSQL.connectionString = "server=" + model.ServerName.Trim() + ";database =" + model.DataBaseName.ToString() + ";uid = " + model.Uid + "; pwd = " + model.Pwd;
                DataSet ds = DbHelperSQL.Query("sp_columns " + TableName.ToString().Trim());
                List<string> list = new List<string>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(dr[3].ToString() + " [" + dr[5].ToString() + "]");
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取表或视图的列信息
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<TableColumnsModel> GetTableColumnsModel(string TableName, DatabaseModel model)
        {
            try
            {
                DbHelperSQL.connectionString = "server=" + model.ServerName.Trim() + ";database =" + model.DataBaseName.ToString() + ";uid = " + model.Uid + "; pwd = " + model.Pwd;
                DataSet ds = DbHelperSQL.Query("sp_columns " + TableName.ToString().Trim());
                List<TableColumnsModel> list = new List<TableColumnsModel>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TableColumnsModel tcModel = new TableColumnsModel();
                    tcModel.ColumnsName = dr[3].ToString();
                    tcModel.DataType = dr[5].ToString();
                    tcModel.Length = dr[7].ToString();
                    tcModel.Mydecimal = dr[8].ToString();
                    list.Add(tcModel);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取表的主键
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Login1"></param>
        /// <returns></returns>
        public List<string> GetTablePrimaryKey(string TableName, DatabaseModel model)
        {
            try
            {
                DbHelperSQL.connectionString = "server=" + model.ServerName.Trim() + ";database =" + model.DataBaseName.ToString() + ";uid = " + model.Uid + "; pwd = " + model.Pwd;
                DataSet st = DbHelperSQL.Query("exec sp_pkeys @table_name='" + TableName + "'");
                List<string> list = new List<string>();
                foreach (DataRow dr in st.Tables[0].Rows)
                {
                    list.Add(dr[3].ToString());
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
