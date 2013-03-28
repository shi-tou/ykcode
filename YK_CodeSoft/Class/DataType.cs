using System;
using System.Collections.Generic;
using System.Text;

namespace YK_CodeSoft.Class
{
    /// <summary>
    /// C#基本数据类型
    /// </summary>
    public class DataType
    {
        private string RetrunType;
        public DataType()
        {

        }
        public string ConvertType(string Type)
        {
            switch (Type.Trim())
            {
                case "char": this.RetrunType = "string"; break;
                case "varchar": this.RetrunType = "string"; break;
                case "text": this.RetrunType = "string"; break;
                case "datetime": this.RetrunType = "string"; break;
                case "smdlldatetime": this.RetrunType = "string"; break;
                case "nchar": this.RetrunType = "string"; break;
                case "nvarchar": this.RetrunType = "string"; break;
                case "ntext": this.RetrunType = "string"; break;
                case "binary": this.RetrunType = "string"; break;
                case "varbinary": this.RetrunType = "string"; break;
                case "image": this.RetrunType = "string"; break;
                case "bit": this.RetrunType = "int"; break;
                case "tinyint": this.RetrunType = "int"; break;
                case "smallint": this.RetrunType = "int"; break;
                case "int": this.RetrunType = "int"; break;
                case "bigint": this.RetrunType = "int"; break;
                case "numeric": this.RetrunType = "int"; break;
                case "decimal": this.RetrunType = "int"; break;
                case "int identity": this.RetrunType = "int"; break;
                case "smallmoney": this.RetrunType = "decimal"; break;
                case "money": this.RetrunType = "decimal"; break;
                case "float": this.RetrunType = "float"; break;
                case "real": this.RetrunType = "float"; break;
                default: this.RetrunType = "1"; break;
            }
            return RetrunType;
        }
    }
    /// <summary>
    /// SQL数据库基本数据类型(基于Parameter)
    /// </summary>
    public class BuilderDALParamDataType
    {
        private string RetrunType;
        public BuilderDALParamDataType()
        {
        }
        public string ConvertType(string Type)
        {
            switch (Type.Trim())
            {
                case "char": this.RetrunType = "Char"; break;
                case "varchar": this.RetrunType = "VarChar"; break;
                case "text": this.RetrunType = "Text"; break;
                case "datetime": this.RetrunType = "DateTime"; break;
                case "smdlldatetime": this.RetrunType = "SmdllDateTime"; break;
                case "nchar": this.RetrunType = "NChar"; break;
                case "nvarchar": this.RetrunType = "NVarChar"; break;
                case "ntext": this.RetrunType = "NText"; break;
                case "binary": this.RetrunType = "Binary"; break;
                case "varbinary": this.RetrunType = "VarBinary"; break;
                case "image": this.RetrunType = "Image"; break;
                case "bit": this.RetrunType = "Bit"; break;
                case "tinyint": this.RetrunType = "TinyInt"; break;
                case "smallint": this.RetrunType = "SmallInt"; break;
                case "int": this.RetrunType = "Int"; break;
                case "bigint": this.RetrunType = "BigInt"; break;
                case "numeric": this.RetrunType = "Decimal"; break;
                case "decimal": this.RetrunType = "Decimal"; break;
                case "int identity": this.RetrunType = "Int"; break;
                case "smallmoney": this.RetrunType = "SmallMoney"; break;
                case "money": this.RetrunType = "Money"; break;
                case "float": this.RetrunType = "Float"; break;
                case "real": this.RetrunType = "Real"; break;
                default: this.RetrunType = "1"; break;

            }
            return RetrunType;
        }
    }
}
