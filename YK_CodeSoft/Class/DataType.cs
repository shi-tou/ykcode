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
        private string ReturnType;
        public DataType()
        {

        }
        public string ConvertType(string Type)
        {
            switch (Type.Trim())
            {
                case "char": this.ReturnType = "string"; break;
                case "varchar": this.ReturnType = "string"; break;
                case "text": this.ReturnType = "string"; break;
                case "datetime": this.ReturnType = "string"; break;
                case "smdlldatetime": this.ReturnType = "string"; break;
                case "nchar": this.ReturnType = "string"; break;
                case "nvarchar": this.ReturnType = "string"; break;
                case "ntext": this.ReturnType = "string"; break;
                case "binary": this.ReturnType = "string"; break;
                case "varbinary": this.ReturnType = "string"; break;
                case "image": this.ReturnType = "string"; break;
                case "bit": this.ReturnType = "int"; break;
                case "tinyint": this.ReturnType = "int"; break;
                case "smallint": this.ReturnType = "int"; break;
                case "int": this.ReturnType = "int"; break;
                case "bigint": this.ReturnType = "int"; break;
                case "numeric": this.ReturnType = "int"; break;
                case "decimal": this.ReturnType = "int"; break;
                case "int identity": this.ReturnType = "int"; break;
                case "smallmoney": this.ReturnType = "decimal"; break;
                case "money": this.ReturnType = "decimal"; break;
                case "float": this.ReturnType = "float"; break;
                case "real": this.ReturnType = "float"; break;
                default: this.ReturnType = "1"; break;
            }
            return ReturnType;
        }
    }
    /// <summary>
    /// SQL数据库基本数据类型(基于Parameter)
    /// </summary>
    public class BuilderDALParamDataType
    {
        private string ReturnType;
        public BuilderDALParamDataType()
        {
        }
        public string ConvertType(string Type)
        {
            switch (Type.Trim())
            {
                case "char": this.ReturnType = "Char"; break;
                case "varchar": this.ReturnType = "VarChar"; break;
                case "text": this.ReturnType = "Text"; break;
                case "datetime": this.ReturnType = "DateTime"; break;
                case "smdlldatetime": this.ReturnType = "SmdllDateTime"; break;
                case "nchar": this.ReturnType = "NChar"; break;
                case "nvarchar": this.ReturnType = "NVarChar"; break;
                case "ntext": this.ReturnType = "NText"; break;
                case "binary": this.ReturnType = "Binary"; break;
                case "varbinary": this.ReturnType = "VarBinary"; break;
                case "image": this.ReturnType = "Image"; break;
                case "bit": this.ReturnType = "Bit"; break;
                case "tinyint": this.ReturnType = "TinyInt"; break;
                case "smallint": this.ReturnType = "SmallInt"; break;
                case "int": this.ReturnType = "Int"; break;
                case "bigint": this.ReturnType = "BigInt"; break;
                case "numeric": this.ReturnType = "Decimal"; break;
                case "decimal": this.ReturnType = "Decimal"; break;
                case "int identity": this.ReturnType = "Int"; break;
                case "smallmoney": this.ReturnType = "SmallMoney"; break;
                case "money": this.ReturnType = "Money"; break;
                case "float": this.ReturnType = "Float"; break;
                case "real": this.ReturnType = "Real"; break;
                default: this.ReturnType = "1"; break;

            }
            return ReturnType;
        }
    }
}
