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
    public partial class Login : AlBaseForm
    {
        public Login()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox_DataBaseName.Enabled = false;
            this.textBox_ServerName.Text = ".";
            this.textBox_Uid.Text = "sa";
            this.textBox_Pwd.Text = "123";
            this.Size = new Size(300, 215);
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确认退出，退出程序？", "温馨提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (!CheckForm())
                return;
            //连接数据库信息
            try
            {
                DatabaseModel model = new DatabaseModel(this.textBox_ServerName.Text, this.comboBox_DataBaseName.Text, this.textBox_Uid.Text, this.textBox_Pwd.Text);
                List<string> list = new DataBase().GetDataBaseInfo(model);
                foreach (string item in list)
                {
                    this.comboBox_DataBaseName.Items.Add(item);
                }
                this.comboBox_DataBaseName.SelectedIndex = 0;
                this.comboBox_DataBaseName.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败！" + ex.Message);
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (!CheckForm())
                return;
            try
            {
                DatabaseModel model = new DatabaseModel(this.textBox_ServerName.Text, this.comboBox_DataBaseName.Text, this.textBox_Uid.Text, this.textBox_Pwd.Text);
                Main main = new Main();
                main.databaseModel = model;
                main.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录失败！" + ex.Message);
            }
        }
        /// <summary>
        /// 验证输入
        /// </summary>
        /// <returns></returns>
        public bool CheckForm()
        {
            if (this.textBox_ServerName.Text == "")
            {
                MessageBox.Show("服务器名不能为空！", "温馨提示", MessageBoxButtons.OK);
                return false;
            }
            if (this.textBox_Uid.Text == "")
            {
                MessageBox.Show("用户账号不能为空！", "温馨提示", MessageBoxButtons.OK);
                return false;
            }
            if (this.textBox_Pwd.Text == "")
            {
                MessageBox.Show("密码不能为空！", "温馨提示", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
