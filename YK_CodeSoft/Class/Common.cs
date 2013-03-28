using System;
using System.Collections.Generic;
using System.Text;

namespace YK_CodeSoft.Class
{
    public static class Common
    {
        /// <summary>
        /// 将传入的字符串首字母大写
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string UpperLetter(string str)
        {
            if (str.Length > 1)
            {
                string strTemp = str.ToUpper();
                return strTemp[0].ToString() + str.Substring(1, str.Length - 1);
            }
            else
                return str.ToUpper();
        }
        /// <summary>
        /// 生成缩进空格
        /// </summary>
        /// <param name="count">缩进次数</param>
        /// <returns></returns>
        public static string SetSpace(int count)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < count; i++)
                str.Append("\t");
            return str.ToString();
        }
        /// <summary>
        /// 根据当前存储的attName和attType生成所有字段的成员变量和公共属性
        /// </summary>
        /// <param name="count">空格缩进数</param>
        /// <returns></returns>
        public static string SetAttribute(int count, string[] attName, string[] attType)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(SetSpace(count) + "#region 成员变量和公共属性");
            for (int i = 0; i < attName.Length; i++)
            {
                str.Append(SetAnnotate(null,count,true,attName[i]));
                str.AppendLine(SetSpace(count) + "private " + GetType(attType[i]) + " _" + attName[i] + ";");
                str.AppendLine(SetSpace(count) + "public " + GetType(attType[i]) + " " + UpperLetter(attName[i]));
                str.AppendLine(SetSpace(count) + "{");
                str.AppendLine(SetSpace(++count) + "set{ _" + attName[i] + " = value; }");
                str.AppendLine(SetSpace(count) + "get{ return _" + attName[i] + "; }");
                str.AppendLine(SetSpace(--count) + "}");
                str.AppendLine("");
            }
            str.AppendLine(SetSpace(count) + "#endregion");
            str.AppendLine("");
            return str.ToString();
        }
        /// <summary>
        /// 根据获得的SQL数据类型名返回C#数据类型名
        /// </summary>
        /// <param name="typeName">SQL数据类型名</param>
        /// <returns>对应的C#数据类型名</returns>
        public static string GetType(string typeName)
        {
            switch (typeName.ToLower())
            {
                case "bigint":
                    return "int";
                case "binary":
                    return "byte[]";
                case "bit":
                    return "bool";
                case "char":
                    return "string";
                case "datetime":
                    return "string";
                case "decimal":
                    return "double";
                case "image":
                    return "byte[]";
                case "money":
                    return "float";
                case "nchar":
                    return "string";
                case "ntext":
                    return "string";
                case "numeric":
                    return "double";
                case "nvarchar":
                    return "string";
                case "real":
                    return "double";
                case "smalldatetime":
                    return "string";
                case "smallint":
                    return "int";
                case "smallmoney":
                    return "float";
                case "text":
                    return "string";
                case "tinyint":
                    return "int";
                case "varbinary":
                    return "byte[]";
                case "varchar":
                    return "string";
                case "int identity":
                    return "int";
                default:
                    return typeName.ToLower();
            }
        }
        /// <summary>
        /// 根据参数名数组生成C#代码注释
        /// </summary>
        /// <param name="paramNames">参数名数组</param>
        /// <param name="count">缩进空格数</param>
        /// <returns></returns>
        public static string SetAnnotate(string[] paramNames, int count, bool isClass, string classInfo)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(SetSpace(count) + "/// <sumary> ");
            str.AppendLine(SetSpace(count) + "/// " + classInfo + " ");
            str.AppendLine(SetSpace(count) + "/// </sumary> ");
            if (!isClass)
            {
                foreach (string name in paramNames)
                    str.AppendLine(SetSpace(count) + "/// <param name=\"" + name + "\"></param> ");
                str.AppendLine(SetSpace(count) + "/// <returns></returns> ");
            }
            return str.ToString();
        }
    }
}
