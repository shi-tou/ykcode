namespace AlSkin.AlForm
{
    partial class AlBaseForm
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
                _BacklightImg.Dispose();
                btn_closeImg.Dispose();
                btn_maxImg.Dispose();
                btn_miniImg.Dispose();
                btn_restoreImg.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlBaseForm));
            this.btn_restore = new AlSkin.AlControl.AlButton.AlButton();
            this.btn_mini = new AlSkin.AlControl.AlButton.AlButton();
            this.btn_max = new AlSkin.AlControl.AlButton.AlButton();
            this.btn_close = new AlSkin.AlControl.AlButton.AlButton();
            this.SuspendLayout();
            // 
            // btn_restore
            // 
            this.btn_restore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_restore.BackColor = System.Drawing.Color.Transparent;
            this.btn_restore.BackImg = ((System.Drawing.Bitmap)(resources.GetObject("btn_restore.BackImg")));
            this.btn_restore.BacklightLTRB = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_restore.IsTabFocus = false;
            this.btn_restore.Location = new System.Drawing.Point(464, 30);
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.Size = new System.Drawing.Size(25, 18);
            this.btn_restore.TabIndex = 3;
            this.btn_restore.UseVisualStyleBackColor = true;
            this.btn_restore.Click += new System.EventHandler(this.btn_restore_Click);
            // 
            // btn_mini
            // 
            this.btn_mini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_mini.BackColor = System.Drawing.Color.Transparent;
            this.btn_mini.BackImg = ((System.Drawing.Bitmap)(resources.GetObject("btn_mini.BackImg")));
            this.btn_mini.BacklightLTRB = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_mini.IsTabFocus = false;
            this.btn_mini.Location = new System.Drawing.Point(435, 6);
            this.btn_mini.Name = "btn_mini";
            this.btn_mini.Size = new System.Drawing.Size(25, 18);
            this.btn_mini.TabIndex = 2;
            this.btn_mini.UseVisualStyleBackColor = true;
            this.btn_mini.Click += new System.EventHandler(this.btn_mini_Click);
            // 
            // btn_max
            // 
            this.btn_max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_max.BackColor = System.Drawing.Color.Transparent;
            this.btn_max.BackImg = ((System.Drawing.Bitmap)(resources.GetObject("btn_max.BackImg")));
            this.btn_max.BacklightLTRB = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_max.IsTabFocus = false;
            this.btn_max.Location = new System.Drawing.Point(464, 6);
            this.btn_max.Name = "btn_max";
            this.btn_max.Size = new System.Drawing.Size(25, 18);
            this.btn_max.TabIndex = 1;
            this.btn_max.UseVisualStyleBackColor = true;
            this.btn_max.Click += new System.EventHandler(this.btn_max_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BackImg = ((System.Drawing.Bitmap)(resources.GetObject("btn_close.BackImg")));
            this.btn_close.BacklightLTRB = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn_close.IsTabFocus = false;
            this.btn_close.Location = new System.Drawing.Point(495, 6);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(38, 18);
            this.btn_close.TabIndex = 0;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // AlBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(174)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(537, 399);
            this.Controls.Add(this.btn_restore);
            this.Controls.Add(this.btn_mini);
            this.Controls.Add(this.btn_max);
            this.Controls.Add(this.btn_close);
            this.Name = "AlBaseForm";
            this.Text = "AlBaseForm";
            this.ResumeLayout(false);

        }

        #endregion

        private AlSkin.AlControl.AlButton.AlButton btn_close;
        private AlSkin.AlControl.AlButton.AlButton btn_max;
        private AlSkin.AlControl.AlButton.AlButton btn_mini;
        private AlSkin.AlControl.AlButton.AlButton btn_restore;
    }
}