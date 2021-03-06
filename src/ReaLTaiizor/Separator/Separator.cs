﻿#region Imports

using System.Drawing;
using System.Windows.Forms;

#endregion

namespace ReaLTaiizor
{
    #region Separator

    public class Separator : Control
    {
        #region Properties

        private Color _LineColor = Color.Gray;
        public Color LineColor
        {
            get { return _LineColor; }
            set
            {
                _LineColor = value;
                Invalidate();
            }
        }

        #endregion

        public Separator()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            Size = new Size(120, 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine(new Pen(LineColor), 0, 5, Width, 5);
        }
    }

    #endregion
}