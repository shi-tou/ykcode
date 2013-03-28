using System;
using System.Collections.Generic;
using System.Text;

namespace YK_CodeSoft.Class
{
    /// <summary>
    /// 用于描述表结构的类
    /// </summary>
    public class TableColumnsModel
    {
        public TableColumnsModel()
        { }
        public TableColumnsModel(string columnsname, string datatype, string length, string mydecimal)
        {
            _columnsname = columnsname;
            _datatype = datatype;
            _length = length;
            _mydecimal = mydecimal;
        }
        private string _columnsname;
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnsName
        {
            get { return _columnsname; }
            set { _columnsname = value; }
        }
        private string _datatype;
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType
        {
            get { return _datatype; }
            set { _datatype = value; }
        }
        private string _length;
        /// <summary>
        /// 长度
        /// </summary>
        public string Length
        {
            get { return _length; }
            set { _length = value; }
        }
        private string _mydecimal;
        /// <summary>
        /// 小数位数（精度）
        /// </summary>
        public string Mydecimal
        {
            get { return _mydecimal; }
            set { _mydecimal = value; }
        }
    }
}

