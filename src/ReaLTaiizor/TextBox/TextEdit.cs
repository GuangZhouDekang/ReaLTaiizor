﻿#region Imports

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

#endregion

namespace ReaLTaiizor
{
    #region TextEdit

    [DefaultEvent("TextChanged")]
    public class TextEdit : Control
    {
        #region Variables

        public TextBox ReaLTaiizorTB = new TextBox();
        private int _maxchars = 32767;
        private bool _ReadOnly;
        private bool _Multiline;
        private Image _Image;
        private Size _ImageSize;
        private HorizontalAlignment ALNType;
        private bool isPasswordMasked = false;
        private Pen P1;
        private SolidBrush B1;
        private GraphicsPath Shape;

        #endregion
        #region Properties

        public HorizontalAlignment TextAlignment
        {
            get
            {
                return ALNType;
            }
            set
            {
                ALNType = value;
                Invalidate();
            }
        }
        public int MaxLength
        {
            get
            {
                return _maxchars;
            }
            set
            {
                _maxchars = value;
                ReaLTaiizorTB.MaxLength = MaxLength;
                Invalidate();
            }
        }

        public bool UseSystemPasswordChar
        {
            get
            {
                return isPasswordMasked;
            }
            set
            {
                ReaLTaiizorTB.UseSystemPasswordChar = UseSystemPasswordChar;
                isPasswordMasked = value;
                Invalidate();
            }
        }
        public bool ReadOnly
        {
            get
            {
                return _ReadOnly;
            }
            set
            {
                _ReadOnly = value;
                if (ReaLTaiizorTB != null)
                    ReaLTaiizorTB.ReadOnly = value;
            }
        }
        public bool Multiline
        {
            get
            {
                return _Multiline;
            }
            set
            {
                _Multiline = value;
                if (ReaLTaiizorTB != null)
                {
                    ReaLTaiizorTB.Multiline = value;

                    if (value)
                        ReaLTaiizorTB.Height = Height - 23;
                    else
                        Height = ReaLTaiizorTB.Height + 23;
                }
            }
        }

        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                if (value == null)
                    _ImageSize = Size.Empty;
                else
                    _ImageSize = value.Size;

                _Image = value;

                if (Image == null)
                    ReaLTaiizorTB.Location = new Point(8, 10);
                else
                    ReaLTaiizorTB.Location = new Point(35, 11);
                Invalidate();
            }
        }

        protected Size ImageSize
        {
            get
            {
                return _ImageSize;
            }
        }

        #endregion
        #region EventArgs

        private void _Enter(object Obj, EventArgs e)
        {
            P1 = new Pen(Color.FromArgb(32, 34, 37));
            Refresh();
        }

        private void _Leave(object Obj, EventArgs e)
        {
            P1 = new Pen(Color.FromArgb(32, 41, 50));
            Refresh();
        }

        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = ReaLTaiizorTB.Text;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            ReaLTaiizorTB.Text = Text;
            Invalidate();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            ReaLTaiizorTB.ForeColor = ForeColor;
            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ReaLTaiizorTB.Font = Font;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        private void _OnKeyDown(object Obj, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                ReaLTaiizorTB.SelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                ReaLTaiizorTB.Copy();
                e.SuppressKeyPress = true;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_Multiline)
                ReaLTaiizorTB.Height = Height - 23;
            else
                Height = ReaLTaiizorTB.Height + 23;

            Shape = new GraphicsPath();
            Shape.AddArc(0, 0, 10, 10, 180, 90);
            Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            Shape.CloseAllFigures();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            ReaLTaiizorTB.Focus();
        }

        public void _TextChanged(object sender, EventArgs e)
        {
            Text = ReaLTaiizorTB.Text;
        }

        public void _BaseTextChanged(object sender, EventArgs e)
        {
            ReaLTaiizorTB.Text = Text;
        }

        #endregion

        public void AddTextBox()
        {
            ReaLTaiizorTB.Location = new Point(8, 10);
            ReaLTaiizorTB.Text = String.Empty;
            ReaLTaiizorTB.BorderStyle = BorderStyle.None;
            ReaLTaiizorTB.TextAlign = HorizontalAlignment.Left;
            ReaLTaiizorTB.Font = Font;
            ReaLTaiizorTB.UseSystemPasswordChar = UseSystemPasswordChar;
            ReaLTaiizorTB.Multiline = false;
            ReaLTaiizorTB.BackColor = Color.FromArgb(66, 76, 85);
            ReaLTaiizorTB.ForeColor = ForeColor;
            ReaLTaiizorTB.ScrollBars = ScrollBars.None;
            ReaLTaiizorTB.KeyDown += _OnKeyDown;
            ReaLTaiizorTB.Enter += _Enter;
            ReaLTaiizorTB.Leave += _Leave;
            ReaLTaiizorTB.TextChanged += OnBaseTextChanged;
        }

        public TextEdit()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            AddTextBox();
            Controls.Add(ReaLTaiizorTB);

            P1 = new Pen(Color.FromArgb(32, 41, 50));
            B1 = new SolidBrush(Color.FromArgb(66, 76, 85));
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(176, 183, 191);

            Text = null;
            Font = new Font("Tahoma", 11);
            Size = new Size(135, 43);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.AntiAlias;


            if (Image == null)
                ReaLTaiizorTB.Width = Width - 18;
            else
                ReaLTaiizorTB.Width = Width - 45;

            ReaLTaiizorTB.TextAlign = TextAlignment;
            ReaLTaiizorTB.UseSystemPasswordChar = UseSystemPasswordChar;

            G.Clear(Color.Transparent);

            G.FillPath(B1, Shape);
            G.DrawPath(P1, Shape);

            if (Image != null)
            {
                G.DrawImage(_Image, 5, 8, 24, 24);
                // 24x24 is the perfect size of the image
            }

            e.Graphics.DrawImage((Image)(B.Clone()), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion
}