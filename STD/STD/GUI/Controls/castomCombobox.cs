using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STD.GUI.Controls
{
    [DefaultEvent("OnSelectedIndexChanged")]
    internal class castomCombobox : UserControl
    {
        private Color back_color = Color.WhiteSmoke;
        private Color icon_color = Color.MediumSlateBlue;
        private Color list_back_color = Color.FromArgb(230, 228, 245);
        private Color list_text_color = Color.DimGray;
        private Color border_color = Color.MediumSlateBlue;
        private int border_size = 1;
        private int border_radius = 40;

        // Items
        private ComboBox cmb_list;
        private Label lbl_text;
        private Button btn_icon;

        // Events
        public event EventHandler OnSelectedIndexChanged; // Default event


        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items
        {
            get
            {
                return cmb_list.Items;
            }
        }
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        public object DataSource
        {
            get
            {
                return cmb_list.DataSource;
            }
            set
            {
                cmb_list.DataSource = value;
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get
            {
                return cmb_list.AutoCompleteCustomSource;
            }
            set
            {
                cmb_list.AutoCompleteCustomSource = value;
            }
        }
        [Browsable(true)]
        [DefaultValue(AutoCompleteSource.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return cmb_list.AutoCompleteSource;
            }
            set
            {
                cmb_list.AutoCompleteSource = value;
            }
        }
        [Browsable(true)]
        [DefaultValue(AutoCompleteMode.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return cmb_list.AutoCompleteMode;
            }
            set
            {
                cmb_list.AutoCompleteMode = value;
            }
        }
        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get
            {
                return cmb_list.SelectedItem;
            }
            set
            {
                cmb_list.SelectedItem = value;
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get
            {
                return cmb_list.SelectedIndex;
            }
            set
            {
                cmb_list.SelectedIndex = value;
            }
        }
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string DisplayMember
        {
            get
            {
                return cmb_list.DisplayMember;
            }
            set
            {
                cmb_list.DisplayMember = value;
            }
        }
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            get
            {
                return cmb_list.ValueMember;
            }
            set
            {
                cmb_list.ValueMember = value;
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
        public new Color BackColor
        {
            get
            {
                return back_color;
            }
            set
            {
                back_color = value;
                lbl_text.BackColor = back_color;
                btn_icon.BackColor = back_color;
            }
        }
        public Color IconColor
        {
            get
            {
                return icon_color;
            }
            set
            {
                icon_color = value;
                btn_icon.Invalidate(); //Redraw icon
            }
        }
        public Color ListBackColor
        {
            get
            {
                return list_back_color;
            }
            set
            {
                list_back_color = value;
                cmb_list.BackColor = list_back_color;
            }
        }
        public Color ListTextColor
        {
            get
            {
                return list_text_color;
            }
            set
            {
                list_text_color = value;
                cmb_list.ForeColor = list_text_color;
            }
        }
        public Color BorderColor
        {
            get
            {
                return border_color;
            }
            set
            {
                border_color = value;
                base.BackColor = border_color; //Border Color
            }
        }
        public int BorderSize
        {
            get
            {
                return border_size;
            }
            set
            {
                border_size = value;
                this.Padding = new Padding(border_size); //Border Size
                adjust_ComboBox_Dimensions();
            }
        }
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                lbl_text.ForeColor = value;
            }
        }
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                lbl_text.Font = value;
                cmb_list.Font = value; //Optional
            }
        }
        public string Texts
        {
            get
            {
                return lbl_text.Text;
            }
            set
            {
                lbl_text.Text = value;
            }
        }
        public ComboBoxStyle DropDownStyle
        {
            get
            {
                return cmb_list.DropDownStyle;
            }
            set
            {
                if (cmb_list.DropDownStyle != ComboBoxStyle.Simple)
                    cmb_list.DropDownStyle = value;
            }
        }

        #endregion

        public castomCombobox()
        {
            cmb_list = new ComboBox();
            lbl_text = new Label();
            btn_icon = new Button();
            this.SuspendLayout();

            // Combobox Dropdown list
            cmb_list.BackColor = back_color;
            cmb_list.Font = new Font(this.Font.Name, 10f);
            cmb_list.ForeColor = list_text_color;
            cmb_list.SelectedIndexChanged += new EventHandler(combobox_selected_index_changed); // Default event
            cmb_list.TextChanged += new EventHandler(combobox_text_changed); // Refresh text


            // Button Icon
            btn_icon.Dock = DockStyle.Right;
            btn_icon.FlatStyle = FlatStyle.Flat;
            btn_icon.FlatAppearance.BorderSize = 0;
            btn_icon.BackColor = back_color;
            btn_icon.Size = new Size(30, 30);
            btn_icon.Cursor = Cursors.Hand;
            btn_icon.Click += new EventHandler(icon_click); // Open dropdown list
            btn_icon.Paint += new PaintEventHandler(icon_paint); // Draw icon

            // Label Text
            lbl_text.Dock = DockStyle.Fill;
            lbl_text.AutoSize = false;
            lbl_text.BackColor = back_color;
            lbl_text.TextAlign = ContentAlignment.MiddleLeft;
            lbl_text.Padding = new Padding(0, 0, 0, 0);
            lbl_text.Font = new Font(this.Font.Name, 10f);
            lbl_text.Click += new EventHandler(surface_click); // Selected combobox

            // User Controls
            this.Controls.Add(lbl_text); // 2
            this.Controls.Add(btn_icon); // 1
            this.Controls.Add(cmb_list); // 0
            this.MinimumSize = new Size(100, 30);
            this.Size = new Size(100, 30);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(border_size); // Border size
            this.Font = new Font(this.Font.Name, 10F);
            base.BackColor = border_color; //Border Color
            this.ResumeLayout();
            adjust_ComboBox_Dimensions();

            this.Resize += new EventHandler(button_resize);
        }

        private void adjust_ComboBox_Dimensions()
        {
            cmb_list.Width = this.Width - 5;
            cmb_list.Location = new Point()
            {
                X = this.Width - this.Padding.Right - cmb_list.Width,
                Y = lbl_text.Bottom - cmb_list.Height
            };
        }

        private void surface_click(object sender, EventArgs e)
        {
            // Attach label click to user control click
            this.OnClick(e);
            // Select combo box
            cmb_list.Select();
            if (cmb_list.DropDownStyle == ComboBoxStyle.DropDownList)
                cmb_list.DroppedDown = true; // Open dropdown list
        }


        private void icon_paint(object sender, PaintEventArgs e)
        {
            //Fields
            int iconWidht = 14;
            int iconHeight = 6;
            var rectIcon = new Rectangle((btn_icon.Width - iconWidht) / 2, (btn_icon.Height - iconHeight) / 2, iconWidht, iconHeight);
            Graphics graph = e.Graphics;
            //Draw arrow down icon
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(icon_color, 2))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidht / 2), rectIcon.Bottom);
                path.AddLine(rectIcon.X + (iconWidht / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                graph.DrawPath(pen, path);
            }
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

        private void icon_click(object sender, EventArgs e)
        {
            // Open dropdown list
            cmb_list.Select();
            cmb_list.DroppedDown = true;
        }

        private void combobox_text_changed(object sender, EventArgs e)
        {
            //Refresh text
            lbl_text.Text = cmb_list.Text;
        }

        private void combobox_selected_index_changed(object sender, EventArgs e)
        {
            if (OnSelectedIndexChanged != null)
                OnSelectedIndexChanged.Invoke(sender, e);
            // Refresh text
            lbl_text.Text = cmb_list.Text;
        }

        private void Surface_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void Surface_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            adjust_ComboBox_Dimensions();
        }
        private void button_resize(object sender, EventArgs e)
        {
            if (border_radius > this.Height)
                border_radius = this.Height;
        }
    }
}
