using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Barcode_Reader_Demo
{
    class TabHead : Label
    {
        private bool m_bMultiTabHead;

        public bool MultiTabHead
        {
            get { return m_bMultiTabHead; }
            set { m_bMultiTabHead = value; }
        }

        private int m_iIndex;

        public int Index
        {
            get { return m_iIndex; }
            set { m_iIndex = value; }
        }

        public enum TabHeadState
        {
            SELECTED,
            FOLDED,
            ALLFOLDED
        }

        private TabHeadState m_enumState = TabHeadState.ALLFOLDED;

        public TabHeadState State
        {
            get { return m_enumState; }
            set 
            { 
                m_enumState = value;
                Invalidate();
            }
        }

        protected override void  OnPaintBackground(PaintEventArgs pevent)
        {
            var rec = pevent.ClipRectangle;
            if (m_bMultiTabHead)
            {
                if (m_enumState == TabHeadState.SELECTED)
                {
                    base.OnPaintBackground(pevent);
                }               
                else
                {
                    var cTop = Color.FromArgb(255, 0xFA, 0xFA, 0xFA);
                    var cBottom = Color.FromArgb(255, 0xEB, 0xEB, 0xEB);
                    var backBrush = new LinearGradientBrush(rec.Location, new Point(rec.Left, rec.Bottom), cTop, cBottom);
                    pevent.Graphics.FillRectangle(backBrush, pevent.ClipRectangle);
                    backBrush.Dispose();

                    var pen = new Pen(Color.FromArgb(255, 208, 208, 208), 1);
                    if (m_enumState != TabHeadState.ALLFOLDED)
                    {
                        var penBottom = new Pen(Color.FromArgb(255, 165, 165, 165), 1);
                        pevent.Graphics.DrawLine(penBottom, rec.Left, rec.Bottom - 1, rec.Right - 1, rec.Bottom - 1);
                        penBottom.Dispose();
                        pevent.Graphics.DrawLine(pen, rec.Right - 1, rec.Top, rec.Right - 1, rec.Bottom - 1);
                    }

                    if (m_iIndex % 3 == 1 || m_iIndex % 3 == 2)
                        pevent.Graphics.DrawLine(pen, rec.Left, rec.Top, rec.Left, rec.Bottom - 1);
                    
                    pen.Dispose();
                }
            }
            else
            {
                var cTop = Color.FromArgb(255, 0xFA, 0xFA, 0xFA);
                var cBottom = Color.FromArgb(255, 0xEB, 0xEB, 0xEB);
                var backBrush = new LinearGradientBrush(rec.Location, new Point(rec.Left, rec.Bottom), cTop, cBottom);
                pevent.Graphics.FillRectangle(backBrush, pevent.ClipRectangle);
                backBrush.Dispose();
            }
        }
    }
}
