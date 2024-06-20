using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STD.GUI.Controls
{
    internal class castomButton : Button
    {
        private int border_size = 0;
        private int border_radius = 40;
        private Color border_color = Color.PaleVioletRed;


        #region Propertis
        public int Border_size
        {
            get
            {
                return border_size;
            }
            set
            {
                border_size = value;
                this.Invalidate();
            }

        }
        public int Border_radius
        {
            get
            {
                return border_radius;
            }
            set
            {
                if (value <= this.Height)
                    border_radius = value;
                else
                    border_radius = this.Height;
                this.Invalidate();
            }
        }
        public Color Border_color
        {
            get
            {
                return border_color;
            }
            set
            {
                border_color = value;
                this.Invalidate();
            }
        }
        public Color Background_color
        {
            get
            {
                return this.BackColor;
            }
            set
            {
                this.BackColor = value;
            }
        }
        public Color Fore_color
        {
            get
            {
                return this.ForeColor;
            }
            set
            {
                this.ForeColor = value;
            }
        }
        #endregion

        public castomButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(button_resize);
        }


        private GraphicsPath get_figure_path(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF rect_surface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rect_border = new RectangleF(1, 1, this.Width - 0.8f, this.Height - 1);

            if (border_radius > 2) // Rouder button
            {
                using (GraphicsPath path_surface = get_figure_path(rect_surface, border_radius))
                using (GraphicsPath path_border = get_figure_path(rect_border, border_radius - 1f))
                using (Pen pen_surface = new Pen(this.Parent.BackColor, 2))
                using (Pen pen_border = new Pen(border_color, border_size))
                {
                    pen_border.Alignment = PenAlignment.Inset;

                    // Button surface
                    this.Region = new Region(path_surface);

                    // Draw surface border for HD result
                    pevent.Graphics.DrawPath(pen_surface, path_surface);

                    // Button border
                    if (border_size >= 1)
                        // Draw control border
                        pevent.Graphics.DrawPath(pen_border, path_border);
                }
            }
            else // Normal button
            {
                // Button surface
                this.Region = new Region(rect_surface);

                // Button border
                if (border_size >= 1)
                {
                    using (Pen pen_border = new Pen(border_color, border_size))
                    {
                        pen_border.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(pen_border, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColor_changed);
        }

        private void Container_BackColor_changed(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }
        private void button_resize(object sender, EventArgs e)
        {
            if (border_radius > this.Height)
                border_radius = this.Height;
        }
    }
}