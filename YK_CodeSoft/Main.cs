using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AlSkin.AlForm;
using YK_CodeSoft.Class;

namespace YK_CodeSoft
{
    public partial class Main : AlBaseForm
    {
        #region 成员变量
        //选中的行
        private int SelectRow = 0;
        //字段名数组
        private string[] attName;
        //字段类型数组
        private string[] attType;
        //类名
        private string className;
        //命名空间
        private string classNameSpace;
        //关键字数组
        private List<string> keys = new List<string>{"using","namespace","private","public","class"
                                            ,"#region","#endregion","new","string","int","float"
                                            ,"double","void","object","value","return","set","get"
                                            };
        //类名或接口名数组
        private List<string> classes = new List<string> { "Serializable", "IComparable", "IComparer", "" };
        //特殊符号数组
        private List<string> marks = new List<string> { " ", "\n", ";", ":", "{", "}", "[", "]", "/", "<", ">", "(", ")" };
        #endregion

        /// <summary>
        /// 连数据库基本信息对象
        /// </summary>
        public DatabaseModel databaseModel;
        public Main()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            CreateTree();
            CreateListViewColumns();
        }
        #region 对窗体左侧树型控件进行操作
        /// <summary>
        /// //构建树（数据库、表、视图等信息）
        /// </summary>
        private void CreateTree()
        {
            //获取数据库中表的信息（数据库名、表名、拥有者、表类别、备注）
            Dictionary<string, string> list = new DataBase().GetTableInfo(databaseModel);
            //树的根节点（数据库名作为根节点名称）
            TreeNode rootNode = new TreeNode(databaseModel.DataBaseName);
            rootNode.ImageIndex = 9;//节点图片
            //子节点-->表
            TreeNode tableNode = rootNode.Nodes.Add("表");
            tableNode.ImageIndex = 8;//节点图片
            //子节点-->视图
            TreeNode viewNode = rootNode.Nodes.Add("视图");
            viewNode.ImageIndex = 8;//节点图片
            foreach (string tName in list.Keys)
            {
                //据表名创建节点
                TreeNode node = new TreeNode(tName);
                //根据表名或视图名获取列信息
                List<string> columnsList = new DataBase().GetTableColumns(tName, databaseModel);
                foreach (string cName in columnsList)
                {
                    //据列名创建节点
                    TreeNode columnsNode = new TreeNode(cName);
                    columnsNode.ImageIndex = 12;//节点图片
                    node.Nodes.Add(columnsNode);
                }
                if (list[tName].ToString() == "TABLE")//添加到表节点下
                {
                    node.ImageIndex = 10;//节点图片
                    tableNode.Nodes.Add(node);
                }
                else //添加到视图节点下
                {
                    node.ImageIndex = 11;
                    viewNode.Nodes.Add(node);
                }
            }
            this.treeView_TableView.Nodes.Add(rootNode);//添加根节点到树控件
            rootNode.Expand();//设置展开
        }
        /// <summary>
        /// 树节点选择之后(在列表中显示相关表信息)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void treeView_TableView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView_TableView.SelectedNode;//选中的节点
            string tableName = "";
            switch (node.Level)//树的深度
            {
                case 2://点击表名
                    tableName = Common.UpperLetter(node.Text);//获取表名
                    break;
                case 3://点击表字段
                    tableName = Common.UpperLetter(node.Parent.Text);//获取点击字段所属的表名
                    break;
                default:
                    return;
            }
            className = tableName.Replace(" ", "");//过滤空格
            this.textBox_ClassName.Text = className;//赋值类名文本框
            classes.Add(className);//给类名或接口名数组添加一个数据
            SelectRow = 1;
            //显示表结构数据
            BindListView(tableName);            
            //初始化每一行处于选中状态
            SelectAll();
            //存储字段名及字段类型
            attName = new string[listView_Info.Items.Count];//根据列表列数初始化长度
            attType = new string[listView_Info.Items.Count];
            int x = 0;
            foreach (ListViewItem item in listView_Info.Items)//存储字段名及字段类型，方便后面生成代码。
            {
                attName[x] = item.SubItems[1].Text;
                attType[x] = item.SubItems[2].Text;
                x++;
            }
        }
        
        #endregion

        #region 对右侧的ListView控件进行操作（显示表的结构,全选、不选、取消选择）
        /// <summary>
        /// 创建ListView的列标题
        /// </summary>
        private void CreateListViewColumns()
        {
            this.listView_Info.View = View.Details;//设置显示方式
            listView_Info.Columns.Add("序号", 60, HorizontalAlignment.Center);
            listView_Info.Columns.Add("列名", 100, HorizontalAlignment.Center);
            listView_Info.Columns.Add("数据类型", 100, HorizontalAlignment.Center);
            listView_Info.Columns.Add("长度", 50, HorizontalAlignment.Center);
            listView_Info.Columns.Add("小数", 50, HorizontalAlignment.Center);
        }
        /// <summary>
        /// 选定表后，显示表结构数据信息到列表中
        /// </summary>
        private void BindListView(string tableName)
        {           
            try
            {
                this.listView_Info.Items.Clear();
                List<TableColumnsModel> listModel = new DataBase().GetTableColumnsModel(tableName, databaseModel);
                int num = 1;
                foreach (TableColumnsModel model in listModel)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = Convert.ToString(num);//项文本--序号
                    item.ImageIndex = 0;
                    item.SubItems.Add(model.ColumnsName);//列名
                    item.SubItems.Add(model.DataType);//类型
                    item.SubItems.Add(model.Length);//长度
                    item.SubItems.Add(model.Mydecimal);//精度
                    listView_Info.Items.Add(item);
                    num++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        } 
        /// <summary>
        /// 选中所有记录
        /// </summary>
        private void SelectAll()
        {
            int count = this.listView_Info.Items.Count;
            for (int i = 0; i < count; i++)
            {
                this.listView_Info.Items[i].Checked = true;
            }
        }
        /// <summary>
        /// 反选记录
        /// </summary>
        private void Invert()
        {            
            int count = this.listView_Info.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.listView_Info.Items[i].Checked == true)
                    this.listView_Info.Items[i].Checked = false;
                else
                    this.listView_Info.Items[i].Checked = true;
            }
        }
        /// <summary>
        /// 取消选择记录
        /// </summary>
        public void SelectNo()
        {
            int count = this.listView_Info.Items.Count;
            for (int i = 0; i < count; i++)
            {
                this.listView_Info.Items[i].Checked = false;
            }
        }
        private void button_SelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }
        private void button_Invert_Click(object sender, EventArgs e)
        {
            Invert();
        }
        private void button_SelectNo_Click(object sender, EventArgs e)
        {
            SelectNo();
        }
        #endregion

        #region 执行生成操作
        /// <summary>
        /// 执行生成操作
        /// </summary>
        private void button_CreateCode_Click(object sender, EventArgs e)
        {
            if (SelectRow != 1)
            {
                MessageBox.Show("你没选择表", "提示");
                return;
            }
            int ListViewCount = this.listView_Info.Items.Count;//表字段数据
            int ListViewCheckCount = 0;//选中字段数
            for (int i = 0; i < ListViewCount; i++)
            {
                if (this.listView_Info.Items[i].Checked == true)
                {
                    ListViewCheckCount += 1;
                }
            }
            int DataLength = 0;
            DataType objTypeData = new DataType();
            BuilderDALParamDataType objBuilderDALParamDataType = new BuilderDALParamDataType();
            List<string> listColor = new List<string>();
            List<string> listColor2 = new List<string>();
            StringBuilder sb = new StringBuilder();
            Boolean hasIdentity = false;//是否有自增列
            string IdentityName = null;//自增列名
            #region 取表自增列
            for (int i = 0; i < ListViewCount; i++)
            {
                if (this.listView_Info.Items[i].SubItems[2].Text == "int identity")
                {
                    hasIdentity = true;
                    IdentityName = this.listView_Info.Items[i].SubItems[1].Text;
                }
            }
            #endregion
            List<string> listP = new DataBase().GetTablePrimaryKey(className, databaseModel);//取表里的主键   
            className = this.textBox_ClassName.Text;//获取类名
            classNameSpace = this.textBox_Namespace.Text;
            if (this.radioButton_Model.Checked)
            {
                #region 生成Model代码
                if (classNameSpace == "" || className == "")
                {
                    MessageBox.Show("请填写您的命名空间和Model类名.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                sb.AppendLine("using System;");
                sb.AppendLine("using System.Collections.Generic;");
                sb.AppendLine("using System.Text;");
                sb.AppendLine();
                sb.AppendLine("namespace " + classNameSpace);
                sb.AppendLine("{");
                sb.AppendLine("\t[Serializable]");
                sb.AppendLine("\tpublic class " + className);
                sb.AppendLine("\t{");
                sb.Append(Common.SetAttribute(2, attName, attType));
                sb.AppendLine("\t}");
                sb.AppendLine("}");
                #endregion
            }
            else if (this.radioButton_DAL.Checked)
            {
                #region 生成DAL
                sb.Append("using System;" + Environment.NewLine);
                sb.Append("using System.Data;" + Environment.NewLine);
                sb.Append("using System.Text;" + Environment.NewLine);
                sb.Append("using System.Collections.Generic;" + Environment.NewLine);
                sb.Append("using DBUtility;//请先添加引用" + Environment.NewLine + Environment.NewLine);
                sb.Append("namespace DAL" + Environment.NewLine + "{" + Environment.NewLine);
                sb.Append("\t/// <summary>" + Environment.NewLine + "\t/// 数据访问类" + this.className.ToString().Trim() + "。" + Environment.NewLine + "\t/// </summary>" + Environment.NewLine);
                sb.Append("\tpublic class " + className.ToString().Trim() + Environment.NewLine);
                sb.Append("\t{" + Environment.NewLine);
                sb.Append("\t\tpublic " + className.ToString().Trim() + "() {}" + Environment.NewLine);
                sb.Append("\t\t#region  成员方法" + Environment.NewLine);
                #region 基于Parameter方式
                int flag = 0;
                if (checkBox_Add.Checked == true)//add
                {
                    //完成
                    #region ADD
                    sb.Append("\t\t/// <summary>" + Environment.NewLine + "\t\t/// 增加一条数据" + Environment.NewLine + "\t\t/// </summary>" + Environment.NewLine + Environment.NewLine);
                    if (hasIdentity)
                    {
                        sb.Append("\t\tpublic int Add(Model." + this.className.ToString().Trim() + " model)" + Environment.NewLine);
                    }
                    else
                    {
                        sb.Append("\t\tpublic void Add(Model." + this.className.ToString().Trim() + " model)" + Environment.NewLine);
                    }
                    sb.Append("\t\t{" + Environment.NewLine);
                    sb.Append("\t\t\tStringBuilder strSql=new StringBuilder();" + Environment.NewLine);
                    sb.Append("\t\t\tstrSql.Append(" + '"' + "insert into " + this.className.ToString().Trim() + "(" + '"' + ')' + ";" + Environment.NewLine);                    
                    sb.Append("\t\t\tstrSql.Append(" + '"');
                    for (int i = 0; i < ListViewCount; i++)
                    {
                        if (this.listView_Info.Items[i].Checked == true)
                        {                           
                            if (this.listView_Info.Items[i].SubItems[2].Text != "int identity")
                            {
                                if(flag!=0)
                                    sb.Append(",");
                                sb.Append(this.listView_Info.Items[i].SubItems[1].Text.Trim());
                                flag++;
                            }
                        }
                    }
                    sb.Append(")" + '"' + ");" + Environment.NewLine);
                    sb.Append("\t\t\tstrSql.Append(" + '"' + " values (" + '"' + ");" + Environment.NewLine);
                    sb.Append("\t\t\tstrSql.Append(" + '"');
                    flag = 0;
                    for (int i = 0; i < ListViewCount; i++)
                    {
                        if (this.listView_Info.Items[i].Checked == true)
                        {
                            if (this.listView_Info.Items[i].SubItems[2].Text != "int identity")
                            {
                                if (flag != 0)
                                    sb.Append(",");
                                sb.Append("@" + this.listView_Info.Items[i].SubItems[1].Text.Trim());
                                flag++;
                            }
                        }
                    }
                    sb.Append(")" + '"' + ");" + Environment.NewLine);
                    if (hasIdentity)
                    {
                        sb.Append("\t\t\tstrSql.Append(" + '"' + ";select @@IDENTITY" + '"' + ");" + Environment.NewLine);
                    }
                    sb.Append("\t\t\tSqlParameter[] parameters = {" + Environment.NewLine);
                    flag = 0;
                    for (int i = 0; i < ListViewCount; i++)
                    {
                        if (this.listView_Info.Items[i].Checked == true)
                        {
                            if (this.listView_Info.Items[i].SubItems[2].Text != "int identity")
                            {
                                if (flag != 0)
                                    sb.Append("," + Environment.NewLine);
                                if (this.listView_Info.Items[i].SubItems[2].Text.Trim() != "datetime" && this.listView_Info.Items[i].SubItems[2].Text.Trim() != "money" && this.listView_Info.Items[i].SubItems[2].Text.Trim() != "smdlldatatime" && this.listView_Info.Items[i].SubItems[2].Text.Trim() != "smdllmoney")
                                {
                                    sb.Append("\t\t\t\tnew SqlParameter(" + '"' + "@" + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + ",SqlDbType." + objBuilderDALParamDataType.ConvertType(this.listView_Info.Items[i].SubItems[2].Text.Trim()) + "," + this.listView_Info.Items[i].SubItems[3].Text.Trim() + ")");
                                }
                                else if (this.listView_Info.Items[i].SubItems[2].Text.Trim() == "money" || this.listView_Info.Items[i].SubItems[2].Text.Trim() == "smdllmoney")
                                {
                                    sb.Append("\t\t\t\tnew SqlParameter(" + '"' + "@" + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + ",SqlDbType." + objBuilderDALParamDataType.ConvertType(this.listView_Info.Items[i].SubItems[2].Text.Trim()) + ",8)");
                                }
                                else if (this.listView_Info.Items[i].SubItems[2].Text.Trim() == "datetime" || this.listView_Info.Items[i].SubItems[2].Text.Trim() == "smdlldatetime")
                                {
                                    sb.Append("\t\t\t\tnew SqlParameter(" + '"' + "@" + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + ",SqlDbType." + objBuilderDALParamDataType.ConvertType(this.listView_Info.Items[i].SubItems[2].Text.Trim()) + ")");
                                }
                                flag++;
                            }
                        }
                    }
                    sb.Append(Environment.NewLine);
                    sb.Append("\t\t\t};" + Environment.NewLine);
                    int ParametersInt = 0;
                    for (int i = 0; i < ListViewCount; i++)
                    {
                        if (this.listView_Info.Items[i].Checked == true)
                        {
                            if (this.listView_Info.Items[i].Checked == true && this.listView_Info.Items[i].SubItems[2].Text != "int identity")
                            {
                                sb.Append("\t\t\tparameters[" + ParametersInt + "].Value = model." + this.listView_Info.Items[i].SubItems[1].Text + ";" + Environment.NewLine);
                                ParametersInt++;
                            }
                        }
                    }
                    if (hasIdentity)
                    {
                        sb.Append("\t\t\tobject obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);" + Environment.NewLine);
                        sb.Append("\t\t\tif(obj == null)" + Environment.NewLine);
                        sb.Append("\t\t\t{" + Environment.NewLine + "\t\t\treturn 1 ;" + Environment.NewLine + "\t\t\t}" + Environment.NewLine);
                        sb.Append("\t\t\telse" + Environment.NewLine);
                        sb.Append("\t\t\t{" + Environment.NewLine);
                        sb.Append("\t\t\treturn Convert.ToInt32(obj);" + Environment.NewLine);
                        sb.Append("\t\t\t}" + Environment.NewLine);
                    }
                    else
                    {
                        sb.Append("\t\t\tDbHelperSQL.ExecuteSql(strSql.ToString(),parameters);" + Environment.NewLine);
                    }
                    sb.Append("\t\t}" + Environment.NewLine);
                    #endregion  //完成
                }
                if (checkBox_Update.Checked == true)//Update
                {
                    //完成
                    #region Update
                    sb.Append("\t\t/// <summary>" + Environment.NewLine + "\t\t/// 更新一条数据" + Environment.NewLine + "\t\t/// </summary>" + Environment.NewLine + Environment.NewLine);
                    sb.Append("\t\tpublic void UpDate(Model." + this.className.ToString().Trim() + " model)" + Environment.NewLine);
                    sb.Append("\t\t{" + Environment.NewLine);
                    sb.Append("\t\t\tStringBuilder strSql=new StringBuilder();" + Environment.NewLine);
                    sb.Append("\t\t\tstrSql.Append(" + '"' + "update " + this.className.ToString().Trim() + " set" + '"' + ')' + ";" + Environment.NewLine);
                    
                    string PName = "";
                    foreach (string abc in listP)
                    {
                        PName = abc;
                    }
                    flag = 0;
                    for (int b = 0; b < ListViewCount; b++)
                    {
                        if (this.listView_Info.Items[b].Checked == true)
                        {
                            if (this.listView_Info.Items[b].SubItems[2].Text != "int identity" && PName != this.listView_Info.Items[b].SubItems[1].Text)
                            {
                                
                                sb.Append("\t\t\tstrSql.Append(" + '"');
                                if (flag != 0)
                                    sb.Append(",");
                                sb.Append(this.listView_Info.Items[b].SubItems[1].Text.Trim() + "=@" + this.listView_Info.Items[b].SubItems[1].Text.Trim());
                                sb.Append('"' + ");" + Environment.NewLine);
                                flag++;
                            }
                        }
                    }
                    sb.Append("\t\t\tstrSql.Append(" + '"' + " where ");

                    #region 添加条件
                    flag = 0;
                    //自增
                    if (IdentityName != null)
                    {
                        sb.Append(IdentityName + "=@" + IdentityName + " " + '"' + ");" + Environment.NewLine);
                    }
                    else if (listP.Count != 0)//主键
                    {
                        sb.Append(listP[0].ToString() + "=@" + listP[0].ToString() + " " + '"' + ");" + Environment.NewLine);

                    }
                    else if (IdentityName == null && listP.Count == 0)//自增 AND 主键 全无
                    {
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            if (flag != 0)
                                sb.Append(" and ");
                            sb.Append(this.listView_Info.Items[b].SubItems[1].Text.Trim() + "=@" + this.listView_Info.Items[b].SubItems[1].Text.Trim());
                            flag++;                          
                        }
                        sb.Append(" " + '"' + ");" + Environment.NewLine);
                    }
                    #endregion
                    sb.Append("\t\t\tSqlParameter[] parameters = {" + Environment.NewLine);
                    flag = 0;
                    for (int i = 0; i < ListViewCount; i++)
                    {
                        if (this.listView_Info.Items[i].Checked == true)
                        {
                            if (flag != 0)
                                sb.Append("," + Environment.NewLine);
                            if (this.listView_Info.Items[i].SubItems[2].Text.Trim() != "datetime" && this.listView_Info.Items[i].SubItems[2].Text.Trim() != "money" && this.listView_Info.Items[i].SubItems[2].Text.Trim() != "smdlldatatime" && this.listView_Info.Items[i].SubItems[2].Text.Trim() != "smdllmoney")
                            {
                                sb.Append("\t\t\t\tnew SqlParameter(" + '"' + "@" + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + ",SqlDbType." + objBuilderDALParamDataType.ConvertType(this.listView_Info.Items[i].SubItems[2].Text.Trim()) + "," + this.listView_Info.Items[i].SubItems[3].Text.Trim() + ")");
                            }
                            else if (this.listView_Info.Items[i].SubItems[2].Text.Trim() == "money" || this.listView_Info.Items[i].SubItems[2].Text.Trim() == "smdllmoney")
                            {
                                sb.Append("\t\t\t\tnew SqlParameter(" + '"' + "@" + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + ",SqlDbType." + objBuilderDALParamDataType.ConvertType(this.listView_Info.Items[i].SubItems[2].Text.Trim()) + ",8)");
                            }
                            else if (this.listView_Info.Items[i].SubItems[2].Text.Trim() == "datetime" || this.listView_Info.Items[i].SubItems[2].Text.Trim() == "smdlldatetime")
                            {
                                sb.Append("\t\t\t\tnew SqlParameter(" + '"' + "@" + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + ",SqlDbType." + objBuilderDALParamDataType.ConvertType(this.listView_Info.Items[i].SubItems[2].Text.Trim()) + ")");
                            }
                            flag++;
                        }
                    }
                    sb.Append(Environment.NewLine);
                    sb.Append("\t\t\t};" + Environment.NewLine);
                    int ParametersInt = 0;
                    for (int i = 0; i < ListViewCount; i++)
                    {
                        if (this.listView_Info.Items[i].Checked == true)
                        {
                            if (this.listView_Info.Items[i].Checked == true)
                            {
                                sb.Append("\t\t\tparameters[" + ParametersInt + "].Value = model." + this.listView_Info.Items[i].SubItems[1].Text + ";" + Environment.NewLine);
                                ParametersInt++;
                            }
                        }
                    }
                    sb.Append("\t\t\tDbHelperSQL.ExecuteSql(strSql.ToString(),parameters);" + Environment.NewLine);
                    sb.Append("\t\t}" + Environment.NewLine);
                    #endregion
                }
                if (checkBox_Delete.Checked == true)//Delete
                {
                    //完成
                    #region Delete
                    sb.Append("\t\t/// <summary>" + Environment.NewLine + "\t/// 删除一条数据" + Environment.NewLine + "\t/// </summary>" + Environment.NewLine + Environment.NewLine);
                    //自增
                    if (IdentityName != null)
                    {
                        sb.Append("\t\tpublic void Delete(int " + IdentityName.ToString().Trim() + ")" + Environment.NewLine);
                        sb.Append("\t\t{" + Environment.NewLine + "\t\tStringBuilder strSql=new StringBuilder();" + Environment.NewLine + "\t\tstrSql.Append(" + '"' + "delete " + this.className.ToString().Trim() + " " + '"' + ");" + Environment.NewLine);
                        sb.Append("\t\t\tstrSql.Append(" + '"' + " where " + IdentityName + "=@" + IdentityName + '"' + ");" + Environment.NewLine);
                        sb.Append("\t\t\tSqlParameter[] parameters = {new SqlParameter(" + '"' + "@" + IdentityName + '"' + ", SqlDbType.Int,4)};" + Environment.NewLine);
                        sb.Append("\t\t\tparameters[0].Value = " + IdentityName + ";" + Environment.NewLine);
                        sb.Append("\t\t\tDbHelperSQL.ExecuteSql(strSql.ToString(),parameters);" + Environment.NewLine + "\t }" + Environment.NewLine);

                    }
                    //主键
                    else if (listP.Count != 0)
                    {
                        string DataType2 = "";
                        string DataType3 = "";
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            if (this.listView_Info.Items[b].SubItems[1].Text == listP[0].ToString())
                            {
                                DataType2 = objTypeData.ConvertType(this.listView_Info.Items[b].SubItems[2].Text.ToString().Trim());
                                DataType3 = objBuilderDALParamDataType.ConvertType(this.listView_Info.Items[b].SubItems[2].Text.ToString().Trim());
                                DataLength = Convert.ToInt32(this.listView_Info.Items[b].SubItems[3].Text);
                                break;
                            }
                        }
                        sb.Append("\t\t\tpublic void Delete(" + DataType2.ToString() + " " + listP[0].ToString().Trim() + " )" + Environment.NewLine);
                        sb.Append("\t\t{" + Environment.NewLine + "\t\tStringBuilder strSql=new StringBuilder();" + Environment.NewLine + "\t\tstrSql.Append(" + '"' + "delete " + this.className.ToString().Trim() + " " + '"' + ");" + Environment.NewLine);
                        sb.Append("\t\t\tstrSql.Append(" + '"' + " where " + listP[0].ToString() + "=@" + listP[0].ToString() + '"' + ");" + Environment.NewLine);
                        sb.Append("\t\t\tSqlParameter[] parameters = {" + Environment.NewLine + "\t\t\t\tnew SqlParameter(" + '"' + "@" + listP[0].ToString() + '"' + ", SqlDbType." + DataType3 + "," + DataLength + ")" + Environment.NewLine + "\t\t};" + Environment.NewLine);
                        sb.Append("\t\t\tparameters[0].Value = " + listP[0].ToString() + ";" + Environment.NewLine);
                        sb.Append("\t\t\tDbHelperSQL.ExecuteSql(strSql.ToString(),parameters);" + Environment.NewLine + "\t }" + Environment.NewLine);

                    }
                    //自增 AND 主键 全无
                    else
                    {
                        sb.Append("\t\tpublic void Delete( ");
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            sb.Append(objTypeData.ConvertType(this.listView_Info.Items[b].SubItems[2].Text.ToString().Trim()) + " " + this.listView_Info.Items[b].SubItems[1].Text.ToString().Trim() + " ");
                            if ((this.listView_Info.Items.Count - 1) != b)
                            {
                                sb.Append(",");
                            }
                        }
                        sb.Append(")" + Environment.NewLine);
                        sb.Append("\t\t{" + Environment.NewLine + "\t\t\tStringBuilder strSql=new StringBuilder();" + Environment.NewLine + "\t\t\tstrSql.Append(" + '"' + "delete " + this.className.ToString().Trim() + " " + '"' + ");" + Environment.NewLine);
                        sb.Append("\t\t\tstrSql.Append(" + '"' + "where ");
                        if (IdentityName == null)
                        {
                            for (int i = 0; i < ListViewCount; i++)
                            {
                                sb.Append(this.listView_Info.Items[i].SubItems[1].Text.Trim() + "=@" + this.listView_Info.Items[i].SubItems[1].Text.Trim());
                                if (i != ListViewCount - 1)
                                {
                                    sb.Append(" and ");
                                }
                            }
                            sb.Append(" " + '"' + ");" + Environment.NewLine);
                        }
                        sb.Append("\t\t\tSqlParameter[] parameters = {" + Environment.NewLine);
                        flag = 0;
                        for (int i = 0; i < ListViewCount; i++)
                        {
                            if (this.listView_Info.Items[i].SubItems[2].Text != "int identity")
                            {
                                if (flag != 0)
                                    sb.Append("," + Environment.NewLine);                               
                                if (this.listView_Info.Items[i].SubItems[2].Text.Trim() != "datetime" && this.listView_Info.Items[i].SubItems[2].Text.Trim() != "money" && this.listView_Info.Items[i].SubItems[2].Text.Trim() != "smdlldatatime" && this.listView_Info.Items[i].SubItems[2].Text.Trim() != "smdllmoney" && this.listView_Info.Items[i].SubItems[2].Text.Trim() != "bigint")
                                {
                                    sb.Append("\t\t\t\tnew SqlParameter(" + '"' + "@" + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + ",SqlDbType." + objBuilderDALParamDataType.ConvertType(this.listView_Info.Items[i].SubItems[2].Text.Trim()) + "," + this.listView_Info.Items[i].SubItems[3].Text.Trim() + ")");
                                }
                                else if (this.listView_Info.Items[i].SubItems[2].Text.Trim() == "money" || this.listView_Info.Items[i].SubItems[2].Text.Trim() == "smdllmoney")
                                {
                                    sb.Append("\t\t\t\tnew SqlParameter(" + '"' + "@" + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + ",SqlDbType." + objBuilderDALParamDataType.ConvertType(this.listView_Info.Items[i].SubItems[2].Text.Trim()) + ")");
                                }
                                else if (this.listView_Info.Items[i].SubItems[2].Text.Trim() == "datetime" || this.listView_Info.Items[i].SubItems[2].Text.Trim() == "smdlldatetime" || this.listView_Info.Items[i].SubItems[2].Text.Trim() == "bigint")
                                {
                                    sb.Append("\t\t\t\tnew SqlParameter(" + '"' + "@" + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + ",SqlDbType." + objBuilderDALParamDataType.ConvertType(this.listView_Info.Items[i].SubItems[2].Text.Trim()) + ")");
                                }
                                flag++;
                            }

                        }
                        sb.Append(Environment.NewLine);
                        sb.Append("\t\t\t};" + Environment.NewLine);
                        int ParametersInt = 0;
                        for (int b = 0; b < ListViewCount; b++)
                        {

                            if (this.listView_Info.Items[b].SubItems[2].Text != "int identity")
                            {
                                sb.Append("\t\t\tparameters[" + ParametersInt + "].Value = model." + this.listView_Info.Items[b].SubItems[1].Text + ";" + Environment.NewLine);
                                ParametersInt++;
                            }

                        }
                        sb.Append("\t\t\tDbHelperSQL.ExecuteSql(strSql.ToString(),parameters);" + Environment.NewLine);
                        sb.Append("\t\t}" + Environment.NewLine);
                    }

                    #endregion
                } if (checkBox_GetModel.Checked == true)//GetModel
                {
                    //完成
                    #region GetModel
                    sb.Append("\t\t/// <summary>" + Environment.NewLine + "\t\t/// 得到一个对象实体" + Environment.NewLine + "\t\t/// </summary>" + Environment.NewLine + Environment.NewLine);
                    //自增
                    if (IdentityName != null)
                    {
                        flag = 0;
                        sb.Append("\t\tpublic Model." + this.className.ToString().Trim() + " GetModel(int " + IdentityName.Trim() + ")" + Environment.NewLine + "\t\t{" + Environment.NewLine);
                        sb.Append("\t\t\tStringBuilder strSql=new StringBuilder();" + Environment.NewLine);
                        sb.Append("\t\t\tstrSql.Append(" + '"' + "select ");
                        for (int i = 0; i < ListViewCount; i++)
                        {
                            if (this.listView_Info.Items[i].Checked == true)
                            {
                                if (flag != 0)
                                    sb.Append(", ");
                                sb.Append(this.listView_Info.Items[i].SubItems[1].Text.Trim());
                                flag++;
                            }
                        }

                        sb.Append(" from  " + this.className.ToString().Trim() + '"' + ");" + Environment.NewLine);
                        sb.Append("\t\t\tstrSql.Append(" + '"' + " where " + IdentityName + "=@" + IdentityName + " " + '"' + ");" + Environment.NewLine);
                        sb.Append("\t\t\tSqlParameter[] parameters = { " + Environment.NewLine + "\t\t\t\tnew SqlParameter(" + '"' + "@" + IdentityName + '"' + ", SqlDbType.Int,4 )" + Environment.NewLine + " \t\t};" + Environment.NewLine);
                        sb.Append("\t\t\tparameters[0].Value = " + IdentityName + ";" + Environment.NewLine);
                        sb.Append("\t\t\tModel." + this.className.ToString().Trim() + " model = new Model." + this.className.ToString().Trim() + "();" + Environment.NewLine);
                        sb.Append("\t\t\tDataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);" + Environment.NewLine);
                        sb.Append("\t\t\tif(ds.Tables[0].Rows.Count>0)" + Environment.NewLine);
                        sb.Append("\t\t\t{" + Environment.NewLine);
                        for (int i = 0; i < ListViewCount; i++)
                        {
                            if (this.listView_Info.Items[i].Checked == true)
                            {
                                string GetType = this.listView_Info.Items[i].SubItems[2].Text.ToString();
                                if (objTypeData.ConvertType(GetType) == "int" && GetType != "money" && GetType != "smallmoney")
                                {
                                    sb.Append("\t\t\tif(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString()!=" + '"' + '"' + ")" + Environment.NewLine);
                                    sb.Append("\t\t\t{" + Environment.NewLine);
                                    sb.Append("\t\t\t\tmodel." + this.listView_Info.Items[i].SubItems[1].Text.Trim() + "=int.Parse(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString());" + Environment.NewLine);
                                    sb.Append("\t\t\t}" + Environment.NewLine);
                                }
                                else if (GetType == "money" || GetType == "smallmoney")
                                {
                                    sb.Append("\t\t\tif(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString()!=" + '"' + '"' + ")" + Environment.NewLine);
                                    sb.Append("\t\t\t{" + Environment.NewLine);
                                    sb.Append("\t\t\t\tmodel." + this.listView_Info.Items[i].SubItems[1].Text.Trim() + "=decimal.Parse(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString());" + Environment.NewLine);
                                    sb.Append("\t\t\t}" + Environment.NewLine);
                                }
                                else if (GetType == "datetime" || GetType == "smdlldatetime")
                                {
                                    sb.Append("\t\t\tif(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString()!=" + '"' + '"' + ")" + Environment.NewLine);
                                    sb.Append("\t\t\t{" + Environment.NewLine);
                                    sb.Append("\t\t\t\tmodel." + this.listView_Info.Items[i].SubItems[1].Text.Trim() + "=DateTime.Parse(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString());" + Environment.NewLine);
                                    sb.Append("\t\t\t}" + Environment.NewLine);
                                }
                                else
                                {
                                    sb.Append("\t\t\tmodel." + this.listView_Info.Items[i].SubItems[1].Text.Trim() + "=ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString();" + Environment.NewLine);
                                }
                            }
                        }
                        sb.Append("\t\t\t return model;" + Environment.NewLine);
                        sb.Append("\t\t}" + Environment.NewLine);
                        sb.Append("\t\telse" + Environment.NewLine);
                        sb.Append("\t\t{" + Environment.NewLine);
                        sb.Append("\t\treturn null;" + Environment.NewLine);
                        sb.Append("\t\t}" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);

                    }
                    //主键
                    else if (listP.Count != 0)
                    {
                        string DataType2 = "";
                        string DataType3 = "";
                        flag = 0;
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            if (this.listView_Info.Items[b].SubItems[1].Text == listP[0].ToString())
                            {
                                DataType2 = objTypeData.ConvertType(this.listView_Info.Items[b].SubItems[2].Text.ToString().Trim());
                                DataType3 = objBuilderDALParamDataType.ConvertType(this.listView_Info.Items[b].SubItems[2].Text.ToString().Trim());
                                DataLength = Convert.ToInt32(this.listView_Info.Items[b].SubItems[3].Text);
                                break;
                            }
                        }
                        sb.Append("\t\tpublic Model." + this.className.ToString().Trim() + " GetModel(" + DataType2.ToString() + " " + listP[0].ToString().Trim() + " )" + Environment.NewLine);
                        sb.Append("\t\t\t{" + Environment.NewLine + "\t\t\t\tStringBuilder strSql=new StringBuilder();" + Environment.NewLine + "\t\t\tstrSql.Append(" + '"' + "select ");
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            if (this.listView_Info.Items[b].Checked == true)
                            {
                              if(flag!=0)
                                  sb.Append(", ");
                                sb.Append(this.listView_Info.Items[b].SubItems[1].Text.Trim());
                                flag++;
                            }
                        }
                        sb.Append(" from " + this.className.ToString().Trim() + '"' + ");" + Environment.NewLine);
                        sb.Append("\t\t\tstrSql.Append(" + '"' + " where " + listP[0] + "=@" + listP[0] + ");" + Environment.NewLine);
                        sb.Append("\t\t\tSqlParameter[] parameters = { " + Environment.NewLine + "\t\t\t\tnew SqlParameter(" + '"' + "@" + listP[0].Trim() + '"' + ", SqlDbType." + DataType3 + "," + DataLength + " )" + Environment.NewLine + " \t\t\t};" + Environment.NewLine);
                        sb.Append("\t\t\tparameters[0].Value = " + listP[0].Trim() + ";" + Environment.NewLine);
                        sb.Append("\t\t\tModel.tb_Application model=new Model.tb_Application();" + Environment.NewLine);
                        sb.Append("\t\t\tDataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);" + Environment.NewLine);

                        sb.Append("\t\t\tif(ds.Tables[0].Rows.Count>0)" + Environment.NewLine);
                        sb.Append("\t\t\t{" + Environment.NewLine);
                        for (int i = 0; i < ListViewCount; i++)
                        {
                            if (this.listView_Info.Items[i].Checked == true)
                            {
                                string GetType = this.listView_Info.Items[i].SubItems[2].Text.ToString();
                                if (objTypeData.ConvertType(GetType) == "int" && GetType != "money" && GetType != "smallmoney")
                                {
                                    sb.Append("\t\t\t\tif(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString()!=" + '"' + '"' + ")" + Environment.NewLine);
                                    sb.Append("\t\t\t\t{" + Environment.NewLine);
                                    sb.Append("\t\t\t\t\tmodel." + this.listView_Info.Items[i].SubItems[1].Text.Trim() + "=int.Parse(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString());" + Environment.NewLine);
                                    sb.Append("\t\t\t\t}" + Environment.NewLine);
                                }
                                else if (GetType == "money" || GetType == "smallmoney")
                                {
                                    sb.Append("\t\t\tif(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString()!=" + '"' + '"' + ")" + Environment.NewLine);
                                    sb.Append("\t\t\t{" + Environment.NewLine);
                                    sb.Append("\t\t\t\tmodel." + this.listView_Info.Items[i].SubItems[1].Text.Trim() + "=decimal.Parse(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString());" + Environment.NewLine);
                                    sb.Append("\t\t\t}" + Environment.NewLine);
                                }

                                else if (GetType == "datetime" || GetType == "smdlldatetime")
                                {
                                    sb.Append("\t\t\tif(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString()!=" + '"' + '"' + ")" + Environment.NewLine);
                                    sb.Append("\t\t\t{" + Environment.NewLine);
                                    sb.Append("\t\t\t\tmodel." + this.listView_Info.Items[i].SubItems[1].Text.Trim() + "=DateTime.Parse(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString());" + Environment.NewLine);
                                    sb.Append("\t\t\t}" + Environment.NewLine);
                                }
                                else
                                {
                                    sb.Append("\t\t\tmodel." + this.listView_Info.Items[i].SubItems[1].Text.Trim() + "=ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString();" + Environment.NewLine);
                                }
                            }
                        }
                        sb.Append("\t\t\t return model;" + Environment.NewLine);
                        sb.Append("\t\t}" + Environment.NewLine);
                        sb.Append("\t\telse" + Environment.NewLine);
                        sb.Append("\t\t{" + Environment.NewLine);
                        sb.Append("\t\treturn null;" + Environment.NewLine);
                        sb.Append("\t\t}" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);

                    }
                    //自增 AND 主键 全无
                    else
                    {
                        sb.Append("\t\tpublic Model." + this.className.ToString().Trim() + " GetModel( ");
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            sb.Append(objTypeData.ConvertType(this.listView_Info.Items[b].SubItems[2].Text.ToString().Trim()) + " " + this.listView_Info.Items[b].SubItems[1].Text.ToString().Trim() + " ");
                            if ((this.listView_Info.Items.Count - 1) != b)
                            {
                                sb.Append(",");
                            }
                        }
                        sb.Append(" )" + Environment.NewLine);
                        sb.Append("\t {" + Environment.NewLine + "\t\tStringBuilder strSql=new StringBuilder();" + Environment.NewLine);
                        sb.Append("\t\tstrSql.Append(" + '"' + "select ");
                        flag = 0;
                        for (int i = 0; i < ListViewCount; i++)
                        {
                            if (this.listView_Info.Items[i].Checked == true)
                            {
                                if (flag != 0)
                                    sb.Append(",");
                                sb.Append(this.listView_Info.Items[i].SubItems[1].Text.Trim());
                                flag++;
                            }
                        }
                        sb.Append(" " + '"' + ");" + Environment.NewLine);
                        sb.Append("\t\tstrSql.Append(" + '"' + "where ");
                        flag = 0;
                        for (int i = 0; i < ListViewCount; i++)
                        {
                            if (flag != 0)
                                sb.Append(" and ");
                            sb.Append(this.listView_Info.Items[i].SubItems[1].Text.Trim() + "=@" + this.listView_Info.Items[i].SubItems[1].Text.Trim());
                            flag++;
                        }
                        sb.Append(" " + '"' + ");" + Environment.NewLine);
                        sb.Append("\t\tSqlParameter[] parameters = {" + Environment.NewLine);
                        flag = 0;
                        for (int i = 0; i < ListViewCount; i++)
                        {
                            if (this.listView_Info.Items[i].SubItems[2].Text != "int identity")
                            {
                                if (flag != 0)
                                    sb.Append("," + Environment.NewLine);
                                if (this.listView_Info.Items[i].SubItems[2].Text.Trim() != "datetime" && this.listView_Info.Items[i].SubItems[2].Text.Trim() != "money" && this.listView_Info.Items[i].SubItems[2].Text.Trim() != "smdlldatatime" && this.listView_Info.Items[i].SubItems[2].Text.Trim() != "smdllmoney" && this.listView_Info.Items[i].SubItems[2].Text.Trim() != "bigint")
                                {
                                    sb.Append("\t\tnew SqlParameter(" + '"' + "@" + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + ",SqlDbType." + objBuilderDALParamDataType.ConvertType(this.listView_Info.Items[i].SubItems[2].Text.Trim()) + "," + this.listView_Info.Items[i].SubItems[3].Text.Trim() + ")");
                                }
                                else if (this.listView_Info.Items[i].SubItems[2].Text.Trim() == "money" || this.listView_Info.Items[i].SubItems[2].Text.Trim() == "smdllmoney")
                                {
                                    sb.Append("\t\tnew SqlParameter(" + '"' + "@" + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + ",SqlDbType." + objBuilderDALParamDataType.ConvertType(this.listView_Info.Items[i].SubItems[2].Text.Trim()) + ")");
                                }
                                else if (this.listView_Info.Items[i].SubItems[2].Text.Trim() == "datetime" || this.listView_Info.Items[i].SubItems[2].Text.Trim() == "smdlldatetime" || this.listView_Info.Items[i].SubItems[2].Text.Trim() == "bigint")
                                {
                                    sb.Append("\t\tnew SqlParameter(" + '"' + "@" + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + ",SqlDbType." + objBuilderDALParamDataType.ConvertType(this.listView_Info.Items[i].SubItems[2].Text.Trim()) + ")");
                                }                               
                                flag++;
                            }

                        }
                        sb.Append( Environment.NewLine);
                        sb.Append("\t\t};" + Environment.NewLine);
                        int ParametersInt = 0;
                        for (int b = 0; b < ListViewCount; b++)
                        {

                            if (this.listView_Info.Items[b].SubItems[2].Text != "int identity")
                            {
                                sb.Append("\t\tparameters[" + ParametersInt + "].Value = model." + this.listView_Info.Items[b].SubItems[1].Text + ";" + Environment.NewLine);
                                ParametersInt++;
                            }

                        }
                        sb.Append("\t\tModel.tb_Application model=new Model.tb_Application();" + Environment.NewLine);
                        sb.Append("\t\tDataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);" + Environment.NewLine);

                        sb.Append("\t\tif(ds.Tables[0].Rows.Count>0)" + Environment.NewLine);
                        sb.Append("\t\t{" + Environment.NewLine);
                        for (int i = 0; i < ListViewCount; i++)
                        {
                            if (this.listView_Info.Items[i].Checked == true)
                            {
                                string GetType = this.listView_Info.Items[i].SubItems[2].Text.ToString();
                                if (objTypeData.ConvertType(GetType) == "int" && GetType != "money" && GetType != "smallmoney")
                                {
                                    sb.Append("\t\t\tif(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString()!=" + '"' + '"' + ")" + Environment.NewLine);
                                    sb.Append("\t\t\t{" + Environment.NewLine);
                                    sb.Append("\t\t\t\tmodel." + this.listView_Info.Items[i].SubItems[1].Text.Trim() + "=int.Parse(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString());" + Environment.NewLine);
                                    sb.Append("\t\t\t}" + Environment.NewLine);
                                }
                                else if (GetType == "money" || GetType == "smallmoney")
                                {
                                    sb.Append("\t\t\tif(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString()!=" + '"' + '"' + ")" + Environment.NewLine);
                                    sb.Append("\t\t\t{" + Environment.NewLine);
                                    sb.Append("\t\t\t\tmodel." + this.listView_Info.Items[i].SubItems[1].Text.Trim() + "=decimal.Parse(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString());" + Environment.NewLine);
                                    sb.Append("\t\t\t}" + Environment.NewLine);
                                }
                                else if (GetType == "datetime" || GetType == "smdlldatetime")
                                {
                                    sb.Append("\t\t\tif(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString()!=" + '"' + '"' + ")" + Environment.NewLine);
                                    sb.Append("\t\t\t{" + Environment.NewLine);
                                    sb.Append("\t\t\t\tmodel." + this.listView_Info.Items[i].SubItems[1].Text.Trim() + "=DateTime.Parse(ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString());" + Environment.NewLine);
                                    sb.Append("\t\t\t}" + Environment.NewLine);
                                }
                                else
                                {
                                    sb.Append("\t\t\tmodel." + this.listView_Info.Items[i].SubItems[1].Text.Trim() + "=ds.Tables[0].Rows[0][" + '"' + this.listView_Info.Items[i].SubItems[1].Text.Trim() + '"' + "].ToString();" + Environment.NewLine);
                                }
                            }
                        }
                        sb.Append("\t\t\t return model;" + Environment.NewLine);
                        sb.Append("\t\t}" + Environment.NewLine);
                        sb.Append("\t\telse" + Environment.NewLine);
                        sb.Append("\t\t{" + Environment.NewLine);
                        sb.Append("\t\treturn null;" + Environment.NewLine);
                        sb.Append("\t\t}" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);
                    }

                    #endregion
                } if (checkBox_GetList.Checked == true)//GetList
                {
                    //完成
                    #region GetList
                    sb.Append("\t/// <summary>" + Environment.NewLine + "\t/// 获得数据列表" + Environment.NewLine + "\t/// </summary>" + Environment.NewLine + Environment.NewLine);
                    sb.Append("\tpublic DataSet GetList(string strWhere)" + Environment.NewLine);
                    sb.Append("\t{" + Environment.NewLine);
                    sb.Append("\t\tStringBuilder strSql=new StringBuilder();" + Environment.NewLine);
                    sb.Append("\t\tstrSql.Append(" + '"' + "select " + " ");
                    flag = 0;
                    for (int i = 0; i < ListViewCount; i++)
                    {
                        if (this.listView_Info.Items[i].Checked == true)
                        {
                            if (flag != 0)
                                sb.Append(", ");
                            sb.Append(this.listView_Info.Items[i].SubItems[1].Text.Trim());
                        }
                    }
                    sb.Append("" + '"' + ");" + Environment.NewLine);
                    sb.Append("\t\tstrSql.Append(" + '"' + " FROM " + this.className.Trim() + " " + '"' + ");" + Environment.NewLine);
                    sb.Append("\t\tif(strWhere.Trim()!=" + '"' + '"' + ")" + Environment.NewLine);
                    sb.Append("\t\t{" + Environment.NewLine);
                    sb.Append("\t\t\tstrSql.Append(" + '"' + " where " + '"' + "+strWhere);" + Environment.NewLine);
                    sb.Append("\t\t}" + Environment.NewLine);
                    sb.Append("\t\treturn DbHelperSQL.Query(strSql.ToString());" + Environment.NewLine);
                    sb.Append("\t}" + Environment.NewLine);

                    #endregion
                }
                if (checkBox_Exists.Checked == true)//Exists
                {
                    //完成
                    #region Exists
                    sb.Append("\t/// <summary>" + Environment.NewLine + "\t/// 是否存在该记录" + Environment.NewLine + "\t/// </summary>" + Environment.NewLine + Environment.NewLine);
                    //自增
                    if (IdentityName != null)
                    {

                        sb.Append("\tpublic bool Exists(int " + IdentityName.Trim() + ")" + Environment.NewLine);
                        sb.Append("\t{" + Environment.NewLine);
                        sb.Append("\t\tStringBuilder strSql=new StringBuilder();" + Environment.NewLine);
                        sb.Append("\t\tstrSql.Append(" + '"' + "select count(1) from " + this.className.Trim() + " " + " ");
                        sb.Append("" + '"' + ");" + Environment.NewLine);
                        sb.Append("\t\tstrSql.Append(" + '"' + " FROM " + this.className.Trim() + " " + '"' + ");" + Environment.NewLine);
                        sb.Append("\t\tSqlParameter[] parameters = { new SqlParameter(" + '"' + "@" + IdentityName.Trim() + '"' + ", SqlDbType.Int,4) };" + Environment.NewLine);
                        sb.Append("\t\tparameters[0].Value = " + IdentityName.Trim() + ";" + Environment.NewLine);
                        sb.Append("\t\treturn DbHelperSQL.Exists(strSql.ToString(),parameters);" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);
                    }
                    #endregion
                }
                if (checkBox_GetMaxID.Checked == true)//GetMaxID
                {
                }
                #endregion

                sb.Append("\t#endregion  成员方法" + Environment.NewLine);
                sb.Append(" }" + Environment.NewLine);
                sb.Append("}" + Environment.NewLine);


                #endregion
            }
            else if (this.radioButton_BLL.Checked)
            {
                #region 生成BLL
                sb.Append("using System;" + Environment.NewLine + "using　System.Data;" + Environment.NewLine + "using Model;" + Environment.NewLine);
                sb.Append("namespace BLL;  //请先添加引用" + Environment.NewLine);
                sb.Append("{" + Environment.NewLine);
                sb.Append("\tpublic class " + this.className.Trim() + "" + Environment.NewLine);
                sb.Append("\t{" + Environment.NewLine);
                sb.Append("\t\tprivate readonly DAL." + this.className.Trim() + " dal=new DAL." + this.className.Trim() + "();" + Environment.NewLine);
                sb.Append("\t\tpublic " + this.className.Trim() + "()" + Environment.NewLine + "\t{}" + Environment.NewLine);
                sb.Append("\t\t#region  成员方法" + Environment.NewLine);
                if (this.checkBox_Add.Checked == true)//Add
                {
                    //完成
                    #region Add
                    sb.Append("\t/// <summary>" + Environment.NewLine + "\t/// 增加一条数据" + Environment.NewLine + "\t/// </summary>" + Environment.NewLine + Environment.NewLine);
                    if (IdentityName != null)
                    {
                        sb.Append("\tpublic int  Add(Model." + this.className.Trim() + " model)" + Environment.NewLine);
                        sb.Append("\t{" + Environment.NewLine);
                        sb.Append("\t\treturn dal.Add(model);" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);
                    }
                    else
                    {
                        sb.Append("\tpublic void  Add(Model." + this.className.Trim() + " model)" + Environment.NewLine);
                        sb.Append("\t{" + Environment.NewLine);
                        sb.Append("\t\treturn dal.Add(model);" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);
                    }
                    #endregion
                }

                if (this.checkBox_Update.Checked == true)//Update
                {
                    //完成
                    #region Update
                    sb.Append("\t/// <summary>" + Environment.NewLine + "\t  /// 更新一条数据" + Environment.NewLine + "\t  /// </summary>" + Environment.NewLine + Environment.NewLine);
                    sb.Append("\tpublic void  Update(Model." + this.className.Trim() + " model)" + Environment.NewLine);
                    sb.Append("\t{" + Environment.NewLine);
                    sb.Append("\t\tdal.Update(model);" + Environment.NewLine);
                    sb.Append("\t\t}" + Environment.NewLine);
                    #endregion
                }

                if (this.checkBox_Delete.Checked == true)//Delete
                {
                    //完成
                    #region Delete
                    sb.Append("\t/// <summary>" + Environment.NewLine + "\t/// 删除一条数据" + Environment.NewLine + "\t/// </summary>" + Environment.NewLine + Environment.NewLine);
                    if (IdentityName != null)
                    {
                        sb.Append("\t public void  Delete(int " + IdentityName + " )" + Environment.NewLine);
                        sb.Append("\t{" + Environment.NewLine);
                        sb.Append("\t\tdal.Delete(" + IdentityName + ");" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);
                    }
                    else if (listP.Count != 0)//主键
                    {
                        string DataType2 = "";
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            if (this.listView_Info.Items[b].SubItems[1].Text == listP[0].ToString())
                            {
                                DataType2 = objTypeData.ConvertType(this.listView_Info.Items[b].SubItems[2].Text.ToString().Trim());
                                break;
                            }
                        }
                        sb.Append("\tpublic void  Delete(" + DataType2 + " " + listP[0].ToString().Trim() + " )" + Environment.NewLine);
                        sb.Append("\t{" + Environment.NewLine);
                        sb.Append("\t\tdal.Delete(" + listP[0].ToString().Trim() + ");" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);
                    }
                    else if (IdentityName == null && listP.Count == 0)//自增 AND 主键 全无
                    {
                        sb.Append("\tpublic void Delete( ");
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            sb.Append(objTypeData.ConvertType(this.listView_Info.Items[b].SubItems[2].Text.ToString().Trim()) + " " + this.listView_Info.Items[b].SubItems[1].Text.ToString().Trim() + " ");
                            if ((this.listView_Info.Items.Count - 1) != b)
                            {
                                sb.Append(",");
                            }

                        }
                        sb.Append(")" + Environment.NewLine);
                        sb.Append("\t{" + Environment.NewLine);
                        sb.Append("\t\tdal.Delete(");
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            if (this.listView_Info.Items[b].SubItems[2].Text != "int identity")
                            {
                                sb.Append(this.listView_Info.Items[b].SubItems[1].Text.ToString().Trim());
                                if ((this.listView_Info.Items.Count - 1) != b)
                                {
                                    sb.Append(",");
                                }
                            }
                        }
                        sb.Append(");" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);
                    }
                    #endregion
                }

                if (this.checkBox_GetModel.Checked == true)//GetModel
                {
                    //完成
                    #region GetModel

                    sb.Append("\t/// <summary>" + Environment.NewLine + "\t/// 得到一个对象实体" + Environment.NewLine + "\t/// </summary>" + Environment.NewLine + Environment.NewLine);
                    if (IdentityName != null)
                    {
                        sb.Append("\tpublic Model." + this.className + " GetModel(int " + IdentityName + " )" + Environment.NewLine);
                        sb.Append("\t{" + Environment.NewLine);
                        sb.Append("\t\treturn dal.GetModel(" + IdentityName + ");" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);
                    }
                    else if (listP.Count != 0)//主键
                    {
                        string DataType2 = "";
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            if (this.listView_Info.Items[b].SubItems[1].Text == listP[0].ToString())
                            {
                                DataType2 = objTypeData.ConvertType(this.listView_Info.Items[b].SubItems[2].Text.ToString().Trim());
                                break;
                            }
                        }
                        sb.Append("\tpublic Model." + this.className + " GetModel(" + DataType2 + " " + listP[0].ToString().Trim() + " )" + Environment.NewLine);
                        sb.Append("\t{" + Environment.NewLine);
                        sb.Append("\t\treturn dal.GetModel(" + listP[0].ToString().Trim() + ");" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);
                    }
                    else if (IdentityName == null && listP.Count == 0)//自增 AND 主键 全无
                    {
                        sb.Append("\tpublic Model." + this.className + " GetModel( ");
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            sb.Append(objTypeData.ConvertType(this.listView_Info.Items[b].SubItems[2].Text.ToString().Trim()) + " " + this.listView_Info.Items[b].SubItems[1].Text.ToString().Trim() + " ");
                            if ((this.listView_Info.Items.Count - 1) != b)
                            {
                                sb.Append(",");
                            }

                        }
                        sb.Append(")" + Environment.NewLine);
                        sb.Append("\t{" + Environment.NewLine);
                        sb.Append("\t\treturn dal.GetModel(");
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            if (this.listView_Info.Items[b].SubItems[2].Text != "int identity")
                            {
                                sb.Append(this.listView_Info.Items[b].SubItems[1].Text.ToString().Trim());
                                if ((this.listView_Info.Items.Count - 1) != b)
                                {
                                    sb.Append(",");
                                }
                            }
                        }
                        sb.Append(");" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);
                    }
                    #endregion
                }

                if (this.checkBox_GetMaxID.Checked == true)//GetMaxID
                {
                    if (IdentityName != null)
                    {
                    }
                    else if (listP.Count != 0)//主键
                    {
                    }
                    else if (IdentityName == null && listP.Count == 0)//自增 AND 主键 全无
                    {
                    }
                }

                if (this.checkBox_GetList.Checked == true)//GetList
                {
                    //完成
                    #region GetList
                    sb.Append("\t/// <summary>" + Environment.NewLine + "\t/// 获得数据列表" + Environment.NewLine + "\t/// </summary>" + Environment.NewLine + Environment.NewLine);
                    sb.Append("\tpublic DataSet GetList(string strWhere)" + Environment.NewLine);
                    sb.Append("\t{" + Environment.NewLine);
                    sb.Append("\t\treturn dal.GetList(strWhere);" + Environment.NewLine);
                    sb.Append("\t}" + Environment.NewLine);
                    sb.Append("\t/// <summary>" + Environment.NewLine + "\t/// 获得数据列表" + Environment.NewLine + "\t/// </summary>" + Environment.NewLine + Environment.NewLine);
                    sb.Append("\tpublic DataSet GetList()" + Environment.NewLine);
                    sb.Append("\t{" + Environment.NewLine);
                    sb.Append("\t\treturn dal.GetList(" + '"' + '"' + ");" + Environment.NewLine);
                    sb.Append("\t}" + Environment.NewLine);
                    #endregion
                }

                if (this.checkBox_Exists.Checked == true)//Exists
                {
                    //完成
                    #region Exists

                    sb.Append("\t/// <summary>" + Environment.NewLine + "\t/// 是否存在该记录" + Environment.NewLine + "\t/// </summary>" + Environment.NewLine + Environment.NewLine);
                    if (IdentityName != null)
                    {
                        sb.Append("\tpublic bool Exists(int " + IdentityName + " )" + Environment.NewLine);
                        sb.Append("\t{" + Environment.NewLine);
                        sb.Append("\t\treturn dal.Exists(" + IdentityName + ");" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);
                    }
                    else if (listP.Count != 0)//主键
                    {
                        string DataType2 = "";
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            if (this.listView_Info.Items[b].SubItems[1].Text == listP[0].ToString())
                            {
                                DataType2 = objTypeData.ConvertType(this.listView_Info.Items[b].SubItems[2].Text.ToString().Trim());
                                break;
                            }
                        }
                        sb.Append("\tpublic bool Exists(" + DataType2 + " " + listP[0].ToString().Trim() + " )" + Environment.NewLine);
                        sb.Append("\t{" + Environment.NewLine);
                        sb.Append("\t\treturn dal.Exists(" + listP[0].ToString().Trim() + ");" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);
                    }
                    else if (IdentityName == null && listP.Count == 0)//自增 AND 主键 全无
                    {
                        sb.Append("\tpublic bool Exists( ");
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            sb.Append(objTypeData.ConvertType(this.listView_Info.Items[b].SubItems[2].Text.ToString().Trim()) + " " + this.listView_Info.Items[b].SubItems[1].Text.ToString().Trim() + " ");
                            if ((this.listView_Info.Items.Count - 1) != b)
                            {
                                sb.Append(",");
                            }

                        }
                        sb.Append(")" + Environment.NewLine);
                        sb.Append("\t{" + Environment.NewLine);
                        sb.Append("\t\treturn dal.Exists(");
                        for (int b = 0; b < ListViewCount; b++)
                        {
                            if (this.listView_Info.Items[b].SubItems[2].Text != "int identity")
                            {
                                sb.Append(this.listView_Info.Items[b].SubItems[1].Text.ToString().Trim());
                                if ((this.listView_Info.Items.Count - 1) != b)
                                {
                                    sb.Append(",");
                                }
                            }
                        }
                        sb.Append(");" + Environment.NewLine);
                        sb.Append("\t}" + Environment.NewLine);
                    }
                    #endregion
                }

                sb.Append("\t#endregion  成员方法" + Environment.NewLine);
                sb.Append("\t}" + Environment.NewLine);
                sb.Append("}" + Environment.NewLine);
                #endregion
            }
            this.richTextBox_Code.Clear();
            this.richTextBox_Code.Text = sb.ToString();
            this.tabControl1.SelectedIndex = 1;//跳转面板
            //#region 还原RichTextBox值
            //int index = this.txtCode.SelectionStart;
            //this.txtCode.SelectAll();
            //this.txtCode.SelectionColor = Color.Black; 
            //#endregion
            SetKeyColor();
            SetColor();
        }
        #endregion

        #region 设置关键字、类、接口、注释的颜色
        /// <summary>
        /// 更改关键字、类名、接口名的颜色
        /// </summary>
        private void SetKeyColor()
        {
            //更改关键字的颜色
            int start = 0;
            int end = 0;
            string strText = this.richTextBox_Code.Text;
            StringBuilder sbTemp = new StringBuilder();
            foreach (char x in strText.ToCharArray())
            {
                //没遇到特殊字符，则将char添加到sbTemp,否则进行检查
                if (marks.Contains(x.ToString()))
                {
                    if (keys.Contains(sbTemp.ToString().Replace("\t","")))//检查关键字数组
                    {
                        this.richTextBox_Code.Select(start, sbTemp.Length);
                        this.richTextBox_Code.SelectionColor = Color.Blue;
                    }
                    if (classes.Contains(sbTemp.ToString().Replace("\t", "")))//检查类名或接口
                    {
                        this.richTextBox_Code.Select(start, sbTemp.Length);
                        this.richTextBox_Code.SelectionColor = Color.CadetBlue;
                    }
                    start = ++end;//重新计算开始位置
                    sbTemp.Length = 0;//清空临时变量
                }
                else
                {
                    sbTemp.Append(x.ToString());
                    end++;
                }
            }
        }
        /// <summary>
        /// //设置注释的颜色
        /// </summary>
        private void SetColor()
        {
            //更改注释的颜色
            string text = this.richTextBox_Code.Text;
            int count = 0;
            while (true)
            {
                int _start = text.IndexOf("///", count) + 3;
                if (_start == 2)
                    break;
                int _end = text.IndexOf('\n', _start);
                count = _end;
                string str = text.Substring(_start, _end - _start);
                str = str.Trim();
                if (str[0] == '<' && str[str.Length - 1] == '>')
                {
                    this.richTextBox_Code.Select(_start - 3, (_end - _start) + 3);
                    this.richTextBox_Code.SelectionColor = Color.Gray;
                }
                else
                {
                    this.richTextBox_Code.Select(_start - 3, 3);
                    this.richTextBox_Code.SelectionColor = Color.Gray;
                    this.richTextBox_Code.Select(_start, (_end - _start) + 3);
                    this.richTextBox_Code.SelectionColor = Color.Green;
                }
            }
        }
        #endregion
        
    }
}