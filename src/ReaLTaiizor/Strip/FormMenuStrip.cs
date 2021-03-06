﻿#region Imports

using System.Windows.Forms;

#endregion

namespace ReaLTaiizor
{
    #region FormMenuStrip

    public class FormMenuStrip : MenuStrip
    {

        public FormMenuStrip()
        {
            Renderer = new ControlRenderer();
        }

        public new ControlRenderer Renderer
        {
            get { return (ControlRenderer)base.Renderer; }
            set { base.Renderer = value; }
        }

    }

    #endregion
}