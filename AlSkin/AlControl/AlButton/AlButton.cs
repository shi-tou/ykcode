//作者：阿龙(Along)
//QQ号：646494711
//QQ群：57218890
//网站：http://www.8timer.com
//博客：http://www.cnblogs.com/Along729/
//声明：未经作者许可，任何人不得发布出售该源码，请尊重别人的劳动成果，谢谢大家支持
using System;
using System.Drawing;
using System.Text;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AlSkin.AlClass;

namespace AlSkin.AlControl.AlButton
{
    //枚鼠标状态
    public enum State
    {
        Normal = 1,
        MouseOver = 2,
        MouseDown = 3,
        Disable = 4,
        Default = 5
    }

    /// <summary>
    /// Button控件
    /// </summary>
    public class AlButton : Button
    {
        #region 声明
        private State state = State.Normal;
        public Bitmap _BackImg = ImageObject.GetResBitmap("AlSkin.AlSkinImg.AlButtonImg.Bottom2.png");
        public Rectangle _BacklightLTRB;
        public bool _IsTabFocus=true;
        Brush brush;
        #endregion

        #region 构造
        public AlButton()
        {
            try
            {
                this.SetStyle(ControlStyles.DoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                this.SetStyle(ControlStyles.StandardDoubleClick, false);
                this.SetStyle(ControlStyles.Selectable, true);
                this.ResizeRedraw = true;
                this.BackColor = Color.Transparent;
            }
            catch { }
        }
        #endregion

        #region 属性
        [CategoryAttribute("阿龙自定义属性"), Description("按钮背景图片")]
        public Bitmap BackImg
        {
            get { return this._BackImg; }
            set { 
                _BackImg = value;
                this.Invalidate(); 
            }
        }

        [CategoryAttribute("阿龙自定义属性"), Description("按钮背景光泽重绘边界")]
        public Rectangle BacklightLTRB
        {
            get { return this._BacklightLTRB; }
            set { _BacklightLTRB = value; }
        }

        [DefaultValue(true)]
        [CategoryAttribute("阿龙自定义属性"), Description("是否允许Tab焦点")]
        public bool IsTabFocus
        {
            get { return this._IsTabFocus; }
            set { _IsTabFocus = value; }
        }
        #endregion

        #region 重载
        protected override void OnMouseEnter(EventArgs e)
        {
            state = State.MouseOver;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            state = State.Normal;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;

            state = State.MouseDown;
            this.Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                state = State.Normal;
            this.Invalidate();
            base.OnMouseUp(e);
        }

        /// <summary>
        /// 重绘控件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (BackImg == null)
            {
                base.OnPaint(e);
                return;
            }

            int i = (int)state;
            if (this.Focused && state != State.MouseDown && _IsTabFocus==true) i = 5;
            if (!this.Enabled) i = 4;
            Rectangle rc = this.ClientRectangle;
            Graphics g = e.Graphics;

            base.InvokePaintBackground(this, new PaintEventArgs(e.Graphics, base.ClientRectangle));
            try
            {
                if (BackImg != null)
                {
                    if (_BacklightLTRB !=Rectangle.Empty)
                    {

                        ImageDrawRect.DrawRect(g, BackImg, rc, Rectangle.FromLTRB(_BacklightLTRB.X, _BacklightLTRB.Y, _BacklightLTRB.Width, _BacklightLTRB.Height),i,5);
                    }
                    else
                    {
                        ImageDrawRect.DrawRect(g, BackImg, rc, Rectangle.FromLTRB(10, 10, 10, 10), i, 5);
                    }
                   
                }
            }
            catch
            { }

            Image img = null;
            Size txts, imgs;

            txts = Size.Empty;
            imgs = Size.Empty;

            if (this.Image != null)
            {
                img = this.Image;
            }
            else if (this.ImageList != null && this.ImageIndex != -1)
            {
                img = this.ImageList.Images[this.ImageIndex];
            }

            if (img != null)
            {
                imgs.Width = img.Width;
                imgs.Height = img.Height;
            }

            StringFormat format1;
            using (format1 = new StringFormat())
            {
                format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
                SizeF ef1 = g.MeasureString(this.Text, this.Font, new SizeF((float)rc.Width, (float)rc.Height), format1);
                txts = Size.Ceiling(ef1);
            }

            rc.Inflate(-4, -4);
            if (imgs.Width * imgs.Height != 0)
            {
                Rectangle imgr = rc;
                imgr = ImageDrawRect.HAlignWithin(imgs, imgr, this.ImageAlign);
                imgr = ImageDrawRect.VAlignWithin(imgs, imgr, this.ImageAlign);
                if (!this.Enabled)
                {
                    ControlPaint.DrawImageDisabled(g, img, imgr.Left, imgr.Top, this.BackColor);
                }
                else
                {
                    g.DrawImage(img, imgr.Left, imgr.Top, img.Width, img.Height);
                }
            }

            Rectangle txtr = rc;
            txtr = ImageDrawRect.HAlignWithin(txts, txtr, this.TextAlign);
            txtr = ImageDrawRect.VAlignWithin(txts, txtr, this.TextAlign);
            
            format1 = new StringFormat();
            format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

            if (this.RightToLeft == RightToLeft.Yes)
            {
                format1.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
            }
            brush = new SolidBrush(this.ForeColor);
            g.DrawString(this.Text, this.Font, brush, (RectangleF)txtr, format1);
            brush.Dispose();

        }
        #endregion

        #region 释放资源
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _BackImg.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }

}
