using System;
using System.Collections.Generic;
using System.Text;

namespace YK_CodeSoft.Class
{
    /// <summary>
    /// 连接数据库基本信息
    /// </summary>
    public class DatabaseModel
    {
        public DatabaseModel()
        {
        }
        public DatabaseModel(string servername, string databasename,string uid,string pwd)
        {
            _servername = servername;
            _databasename = databasename;
            _uid = uid;
            _pwd = pwd;
        }
        private string _servername;
        /// <summary>
        /// 服务器名
        /// </summary>
        public string ServerName
        {
            get { return _servername; }
            set { _servername = value; }
        }
        private string _databasename;
        /// <summary>
        /// 数据库名
        /// </summary>
        public string DataBaseName
        {
            get { return _databasename; }
            set { _databasename = value; }
        }
        private string _uid;
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        private string _pwd;
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }       
    }
}
