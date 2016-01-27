using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Barcode_Reader_Demo
{
    class RoundedRectanglePanel : Panel
    {
        public RoundedRectanglePanel() : base()
        {
            this.Padding = new Padding(1, 1, 1, 1);
            this.SizeChanged += new EventHandler(RoundedRectanglePanel_SizeChanged);
        }

        void RoundedRectanglePanel_SizeChanged(object sender, EventArgs e)
        {
            var bmp = new Bitmap(Bounds.Width, Bounds.Height);
            var g = Graphics.FromImage(bmp);

            var bounds = new Rectangle(0, 0, Bounds.Width, Bounds.Height);
            var cTopBorder = Color.FromArgb(255, 221, 221, 221);
            var cBottomBorder = Color.FromArgb(255, 165, 165, 165);
            var cTop = Color.FromArgb(255, 0xFA, 0xFA, 0xFA);
            var cBottom = Color.FromArgb(255, 0xEB, 0xEB, 0xEB);
            var backBrush = new System.Drawing.Drawing2D.LinearGradientBrush(bounds.Location, new Point(bounds.Left, bounds.Bottom), cTop, cBottom);
            var borderBrush = new LinearGradientBrush(bounds.Location, new Point(bounds.Left, bounds.Bottom), cTopBorder, cBottomBorder);
            var pen = new Pen(borderBrush);
            var graphicPath = GetRoundedRect(new RectangleF(bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1), 3);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillPath(backBrush, graphicPath);
            g.DrawPath(pen, graphicPath);

            this.BackgroundImage = bmp;

            backBrush.Dispose();
            borderBrush.Dispose();
            pen.Dispose();
            graphicPath.Dispose();
            g.Dispose();
        }

        #region Refrenced (CodeProject)
        private static GraphicsPath GetRoundedRect(RectangleF baseRect,
           float radius)
        {
            // if corner radius is less than or equal to zero, 
            // return the original rectangle 
            if (radius <= 0.0F)
            {
                var mPath = new GraphicsPath();
                mPath.AddRectangle(baseRect);
                mPath.CloseFigure();
                return mPath;
            }

            // if the corner radius is greater than or equal to 
            // half the width, or height (whichever is shorter) 
            // then return a capsule instead of a lozenge 
            if (radius >= (Math.Min(baseRect.Width, baseRect.Height)) / 2.0)
                return GetCapsule(baseRect);

            // create the arc for the rectangle sides and declare 
            // a graphics path object for the drawing 
            var diameter = radius * 2.0F;
            var sizeF = new SizeF(diameter, diameter);
            var arc = new RectangleF(baseRect.Location, sizeF);
            var path = new System.Drawing.Drawing2D.GraphicsPath();

            // top left arc 
            path.AddArc(arc, 180, 90);

            // top right arc 
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc 
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private static GraphicsPath GetCapsule(RectangleF baseRect)
        {
            float diameter;
            RectangleF arc;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            try
            {
                if (baseRect.Width > baseRect.Height)
                {
                    // return horizontal capsule 
                    diameter = baseRect.Height;
                    var sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = baseRect.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (baseRect.Width < baseRect.Height)
                {
                    // return vertical capsule 
                    diameter = baseRect.Width;
                    var sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = baseRect.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else
                {
                    // return circle 
                    path.AddEllipse(baseRect);
                }
            }
            catch (Exception ex)
            {
                path.AddEllipse(baseRect);
            }
            finally
            {
                path.CloseFigure();
            }
            return path;
        }
        #endregion Refrenced (CodeProject)
    }
}
