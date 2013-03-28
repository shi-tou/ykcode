namespace YK_CodeSoft
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView_TableView = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView_Info = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox_Code = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_ClassName = new System.Windows.Forms.TextBox();
            this.textBox_Namespace = new System.Windows.Forms.TextBox();
            this.radioButton_BLL = new System.Windows.Forms.RadioButton();
            this.radioButton_DAL = new System.Windows.Forms.RadioButton();
            this.radioButton_Model = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_SelectNo = new System.Windows.Forms.Button();
            this.button_Invert = new System.Windows.Forms.Button();
            this.button_SelectAll = new System.Windows.Forms.Button();
            this.button_CreateCode = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox_Exists = new System.Windows.Forms.CheckBox();
            this.checkBox_GetList = new System.Windows.Forms.CheckBox();
            this.checkBox_GetMaxID = new System.Windows.Forms.CheckBox();
            this.checkBox_GetModel = new System.Windows.Forms.CheckBox();
            this.checkBox_Delete = new System.Windows.Forms.CheckBox();
            this.checkBox_Update = new System.Windows.Forms.CheckBox();
            this.checkBox_Add = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.treeView_TableView);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 398);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库表视图";
            // 
            // treeView_TableView
            // 
            this.treeView_TableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_TableView.Location = new System.Drawing.Point(3, 17);
            this.treeView_TableView.Name = "treeView_TableView";
            this.treeView_TableView.Size = new System.Drawing.Size(174, 378);
            this.treeView_TableView.TabIndex = 0;
            this.treeView_TableView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_TableView_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(198, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(652, 219);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView_Info);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(644, 193);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView_Info
            // 
            this.listView_Info.CheckBoxes = true;
            this.listView_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Info.GridLines = true;
            this.listView_Info.Location = new System.Drawing.Point(3, 3);
            this.listView_Info.Name = "listView_Info";
            this.listView_Info.Size = new System.Drawing.Size(638, 187);
            this.listView_Info.SmallImageList = this.imageList1;
            this.listView_Info.TabIndex = 0;
            this.listView_Info.UseCompatibleStateImageBehavior = false;
            this.listView_Info.View = System.Windows.Forms.View.Details;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "folder.JPG");
            this.imageList1.Images.SetKeyName(9, "db.JPG");
            this.imageList1.Images.SetKeyName(10, "tbl.JPG");
            this.imageList1.Images.SetKeyName(11, "view.JPG");
            this.imageList1.Images.SetKeyName(12, "col.JPG");
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.richTextBox_Code);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(594, 193);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // richTextBox_Code
            // 
            this.richTextBox_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_Code.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_Code.Name = "richTextBox_Code";
            this.richTextBox_Code.Size = new System.Drawing.Size(588, 187);
            this.richTextBox_Code.TabIndex = 0;
            this.richTextBox_Code.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "类 名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "命名空间：";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox_ClassName);
            this.groupBox3.Controls.Add(this.textBox_Namespace);
            this.groupBox3.Controls.Add(this.radioButton_BLL);
            this.groupBox3.Controls.Add(this.radioButton_DAL);
            this.groupBox3.Controls.Add(this.radioButton_Model);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox3.Location = new System.Drawing.Point(202, 323);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(641, 45);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "代码类型";
            // 
            // textBox_ClassName
            // 
            this.textBox_ClassName.Location = new System.Drawing.Point(464, 16);
            this.textBox_ClassName.Name = "textBox_ClassName";
            this.textBox_ClassName.Size = new System.Drawing.Size(120, 21);
            this.textBox_ClassName.TabIndex = 5;
            // 
            // textBox_Namespace
            // 
            this.textBox_Namespace.Location = new System.Drawing.Point(310, 16);
            this.textBox_Namespace.Name = "textBox_Namespace";
            this.textBox_Namespace.Size = new System.Drawing.Size(95, 21);
            this.textBox_Namespace.TabIndex = 5;
            this.textBox_Namespace.Text = "Models";
            // 
            // radioButton_BLL
            // 
            this.radioButton_BLL.AutoSize = true;
            this.radioButton_BLL.Location = new System.Drawing.Point(158, 18);
            this.radioButton_BLL.Name = "radioButton_BLL";
            this.radioButton_BLL.Size = new System.Drawing.Size(41, 16);
            this.radioButton_BLL.TabIndex = 4;
            this.radioButton_BLL.Text = "BLL";
            this.radioButton_BLL.UseVisualStyleBackColor = true;
            // 
            // radioButton_DAL
            // 
            this.radioButton_DAL.AutoSize = true;
            this.radioButton_DAL.Location = new System.Drawing.Point(107, 18);
            this.radioButton_DAL.Name = "radioButton_DAL";
            this.radioButton_DAL.Size = new System.Drawing.Size(41, 16);
            this.radioButton_DAL.TabIndex = 3;
            this.radioButton_DAL.TabStop = true;
            this.radioButton_DAL.Text = "DAL";
            this.radioButton_DAL.UseVisualStyleBackColor = true;
            // 
            // radioButton_Model
            // 
            this.radioButton_Model.AutoSize = true;
            this.radioButton_Model.Checked = true;
            this.radioButton_Model.Location = new System.Drawing.Point(44, 18);
            this.radioButton_Model.Name = "radioButton_Model";
            this.radioButton_Model.Size = new System.Drawing.Size(53, 16);
            this.radioButton_Model.TabIndex = 2;
            this.radioButton_Model.TabStop = true;
            this.radioButton_Model.Text = "Model";
            this.radioButton_Model.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button_SelectNo);
            this.groupBox2.Controls.Add(this.button_Invert);
            this.groupBox2.Controls.Add(this.button_SelectAll);
            this.groupBox2.Location = new System.Drawing.Point(198, 277);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(645, 42);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // button_SelectNo
            // 
            this.button_SelectNo.Location = new System.Drawing.Point(215, 12);
            this.button_SelectNo.Name = "button_SelectNo";
            this.button_SelectNo.Size = new System.Drawing.Size(75, 23);
            this.button_SelectNo.TabIndex = 0;
            this.button_SelectNo.Text = "取消";
            this.button_SelectNo.UseVisualStyleBackColor = true;
            this.button_SelectNo.Click += new System.EventHandler(this.button_SelectNo_Click);
            // 
            // button_Invert
            // 
            this.button_Invert.Location = new System.Drawing.Point(121, 12);
            this.button_Invert.Name = "button_Invert";
            this.button_Invert.Size = new System.Drawing.Size(75, 23);
            this.button_Invert.TabIndex = 0;
            this.button_Invert.Text = "反选";
            this.button_Invert.UseVisualStyleBackColor = true;
            this.button_Invert.Click += new System.EventHandler(this.button_Invert_Click);
            // 
            // button_SelectAll
            // 
            this.button_SelectAll.Location = new System.Drawing.Point(27, 12);
            this.button_SelectAll.Name = "button_SelectAll";
            this.button_SelectAll.Size = new System.Drawing.Size(75, 23);
            this.button_SelectAll.TabIndex = 0;
            this.button_SelectAll.Text = "全选";
            this.button_SelectAll.UseVisualStyleBackColor = true;
            this.button_SelectAll.Click += new System.EventHandler(this.button_SelectAll_Click);
            // 
            // button_CreateCode
            // 
            this.button_CreateCode.BackColor = System.Drawing.Color.Transparent;
            this.button_CreateCode.Location = new System.Drawing.Point(614, 449);
            this.button_CreateCode.Name = "button_CreateCode";
            this.button_CreateCode.Size = new System.Drawing.Size(75, 23);
            this.button_CreateCode.TabIndex = 8;
            this.button_CreateCode.Text = "生成代码";
            this.button_CreateCode.UseVisualStyleBackColor = false;
            this.button_CreateCode.Click += new System.EventHandler(this.button_CreateCode_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.checkBox_Exists);
            this.groupBox4.Controls.Add(this.checkBox_GetList);
            this.groupBox4.Controls.Add(this.checkBox_GetMaxID);
            this.groupBox4.Controls.Add(this.checkBox_GetModel);
            this.groupBox4.Controls.Add(this.checkBox_Delete);
            this.groupBox4.Controls.Add(this.checkBox_Update);
            this.groupBox4.Controls.Add(this.checkBox_Add);
            this.groupBox4.Location = new System.Drawing.Point(205, 372);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(638, 72);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "方法选择";
            // 
            // checkBox_Exists
            // 
            this.checkBox_Exists.AutoSize = true;
            this.checkBox_Exists.Checked = true;
            this.checkBox_Exists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Exists.Location = new System.Drawing.Point(248, 42);
            this.checkBox_Exists.Name = "checkBox_Exists";
            this.checkBox_Exists.Size = new System.Drawing.Size(60, 16);
            this.checkBox_Exists.TabIndex = 1;
            this.checkBox_Exists.Text = "Exists";
            this.checkBox_Exists.UseVisualStyleBackColor = true;
            // 
            // checkBox_GetList
            // 
            this.checkBox_GetList.AutoSize = true;
            this.checkBox_GetList.Checked = true;
            this.checkBox_GetList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_GetList.Location = new System.Drawing.Point(28, 42);
            this.checkBox_GetList.Name = "checkBox_GetList";
            this.checkBox_GetList.Size = new System.Drawing.Size(66, 16);
            this.checkBox_GetList.TabIndex = 0;
            this.checkBox_GetList.Text = "GetList";
            this.checkBox_GetList.UseVisualStyleBackColor = true;
            // 
            // checkBox_GetMaxID
            // 
            this.checkBox_GetMaxID.AutoSize = true;
            this.checkBox_GetMaxID.Checked = true;
            this.checkBox_GetMaxID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_GetMaxID.Location = new System.Drawing.Point(128, 42);
            this.checkBox_GetMaxID.Name = "checkBox_GetMaxID";
            this.checkBox_GetMaxID.Size = new System.Drawing.Size(72, 16);
            this.checkBox_GetMaxID.TabIndex = 0;
            this.checkBox_GetMaxID.Text = "GetMaxID";
            this.checkBox_GetMaxID.UseVisualStyleBackColor = true;
            // 
            // checkBox_GetModel
            // 
            this.checkBox_GetModel.AutoSize = true;
            this.checkBox_GetModel.Checked = true;
            this.checkBox_GetModel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_GetModel.Location = new System.Drawing.Point(364, 19);
            this.checkBox_GetModel.Name = "checkBox_GetModel";
            this.checkBox_GetModel.Size = new System.Drawing.Size(72, 16);
            this.checkBox_GetModel.TabIndex = 0;
            this.checkBox_GetModel.Text = "GetModel";
            this.checkBox_GetModel.UseVisualStyleBackColor = true;
            // 
            // checkBox_Delete
            // 
            this.checkBox_Delete.AutoSize = true;
            this.checkBox_Delete.Checked = true;
            this.checkBox_Delete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Delete.Location = new System.Drawing.Point(128, 19);
            this.checkBox_Delete.Name = "checkBox_Delete";
            this.checkBox_Delete.Size = new System.Drawing.Size(60, 16);
            this.checkBox_Delete.TabIndex = 0;
            this.checkBox_Delete.Text = "Delete";
            this.checkBox_Delete.UseVisualStyleBackColor = true;
            // 
            // checkBox_Update
            // 
            this.checkBox_Update.AutoSize = true;
            this.checkBox_Update.Checked = true;
            this.checkBox_Update.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Update.Location = new System.Drawing.Point(246, 19);
            this.checkBox_Update.Name = "checkBox_Update";
            this.checkBox_Update.Size = new System.Drawing.Size(60, 16);
            this.checkBox_Update.TabIndex = 0;
            this.checkBox_Update.Text = "Update";
            this.checkBox_Update.UseVisualStyleBackColor = true;
            // 
            // checkBox_Add
            // 
            this.checkBox_Add.AutoSize = true;
            this.checkBox_Add.Checked = true;
            this.checkBox_Add.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Add.Location = new System.Drawing.Point(28, 19);
            this.checkBox_Add.Name = "checkBox_Add";
            this.checkBox_Add.Size = new System.Drawing.Size(42, 16);
            this.checkBox_Add.TabIndex = 0;
            this.checkBox_Add.Text = "Add";
            this.checkBox_Add.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BacklightImg = global::YK_CodeSoft.Properties.Resources.all_inside03_bkg;
            this.ClientSize = new System.Drawing.Size(860, 500);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button_CreateCode);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.FormSystemBtnSet = AlSkin.AlForm.AlBaseForm.FormSystemBtn.btn_miniAndbtn_close;
            this.Name = "Main";
            this.Text = "云客代码生成器--技术小杨";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.button_CreateCode, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeView_TableView;
        private System.Windows.Forms.ListView listView_Info;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_ClassName;
        private System.Windows.Forms.TextBox textBox_Namespace;
        private System.Windows.Forms.RadioButton radioButton_BLL;
        private System.Windows.Forms.RadioButton radioButton_DAL;
        private System.Windows.Forms.RadioButton radioButton_Model;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_SelectNo;
        private System.Windows.Forms.Button button_Invert;
        private System.Windows.Forms.Button button_SelectAll;
        private System.Windows.Forms.Button button_CreateCode;
        private System.Windows.Forms.RichTextBox richTextBox_Code;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox_Exists;
        private System.Windows.Forms.CheckBox checkBox_GetList;
        private System.Windows.Forms.CheckBox checkBox_GetMaxID;
        private System.Windows.Forms.CheckBox checkBox_GetModel;
        private System.Windows.Forms.CheckBox checkBox_Delete;
        private System.Windows.Forms.CheckBox checkBox_Update;
        private System.Windows.Forms.CheckBox checkBox_Add;
    }
}