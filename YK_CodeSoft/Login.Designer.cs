namespace YK_CodeSoft
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.textBox_ServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Uid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Pwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Connect = new AlSkin.AlControl.AlButton.AlButton();
            this.btn_Login = new AlSkin.AlControl.AlButton.AlButton();
            this.btn_Cancel = new AlSkin.AlControl.AlButton.AlButton();
            this.comboBox_DataBaseName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox_ServerName
            // 
            this.textBox_ServerName.Location = new System.Drawing.Point(110, 51);
            this.textBox_ServerName.Name = "textBox_ServerName";
            this.textBox_ServerName.Size = new System.Drawing.Size(144, 21);
            this.textBox_ServerName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(39, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "服务器名：";
            // 
            // textBox_Uid
            // 
            this.textBox_Uid.Location = new System.Drawing.Point(110, 78);
            this.textBox_Uid.Name = "textBox_Uid";
            this.textBox_Uid.Size = new System.Drawing.Size(144, 21);
            this.textBox_Uid.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(39, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "用户账号：";
            // 
            // textBox_Pwd
            // 
            this.textBox_Pwd.Location = new System.Drawing.Point(110, 105);
            this.textBox_Pwd.Name = "textBox_Pwd";
            this.textBox_Pwd.PasswordChar = '●';
            this.textBox_Pwd.Size = new System.Drawing.Size(144, 21);
            this.textBox_Pwd.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(39, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "用户密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(39, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "数据库名：";
            // 
            // btn_Connect
            // 
            this.btn_Connect.BackColor = System.Drawing.Color.Transparent;
            this.btn_Connect.BackImg = ((System.Drawing.Bitmap)(resources.GetObject("btn_Connect.BackImg")));
            this.btn_Connect.BacklightLTRB = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_Connect.ForeColor = System.Drawing.Color.Black;
            this.btn_Connect.Location = new System.Drawing.Point(32, 168);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(66, 23);
            this.btn_Connect.TabIndex = 6;
            this.btn_Connect.Text = "测试连接";
            this.btn_Connect.UseVisualStyleBackColor = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.Transparent;
            this.btn_Login.BackImg = ((System.Drawing.Bitmap)(resources.GetObject("btn_Login.BackImg")));
            this.btn_Login.BacklightLTRB = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_Login.ForeColor = System.Drawing.Color.Black;
            this.btn_Login.Location = new System.Drawing.Point(113, 168);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(66, 23);
            this.btn_Login.TabIndex = 6;
            this.btn_Login.Text = "登录";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.BackImg = ((System.Drawing.Bitmap)(resources.GetObject("btn_Cancel.BackImg")));
            this.btn_Cancel.BacklightLTRB = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Location = new System.Drawing.Point(194, 168);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(66, 23);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "退出";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // comboBox_DataBaseName
            // 
            this.comboBox_DataBaseName.FormattingEnabled = true;
            this.comboBox_DataBaseName.Location = new System.Drawing.Point(110, 132);
            this.comboBox_DataBaseName.Name = "comboBox_DataBaseName";
            this.comboBox_DataBaseName.Size = new System.Drawing.Size(141, 20);
            this.comboBox_DataBaseName.TabIndex = 7;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BacklightImg = global::YK_CodeSoft.Properties.Resources.all_inside03_bkg;
            this.ClientSize = new System.Drawing.Size(300, 215);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Uid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Pwd);
            this.Controls.Add(this.comboBox_DataBaseName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ServerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.btn_Cancel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormSystemBtnSet = AlSkin.AlForm.AlBaseForm.FormSystemBtn.btn_close;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码生成器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.btn_Cancel, 0);
            this.Controls.SetChildIndex(this.btn_Login, 0);
            this.Controls.SetChildIndex(this.btn_Connect, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.textBox_ServerName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.comboBox_DataBaseName, 0);
            this.Controls.SetChildIndex(this.textBox_Pwd, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.textBox_Uid, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Uid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Pwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private AlSkin.AlControl.AlButton.AlButton btn_Connect;
        private AlSkin.AlControl.AlButton.AlButton btn_Login;
        private AlSkin.AlControl.AlButton.AlButton btn_Cancel;
        private System.Windows.Forms.ComboBox comboBox_DataBaseName;
    }
}

