using STD.GUI.Controls;

namespace STD
{
    public partial class stdF : Form
    {
        int iFormX, iFormY, iMouseX, iMouseY;
        public stdF()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(roundForm.CreateRoundRectRgn(0, 0, Width, Height, 18, 18));
            exitBtn.FlatAppearance.BorderSize = 0;
            exitBtn.FlatStyle = FlatStyle.Flat;
            minimizeBtn.FlatAppearance.BorderSize = 0;
            minimizeBtn.FlatStyle = FlatStyle.Flat;
            indexing1.Visible = true;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void stdF_MouseDown(object sender, MouseEventArgs e)
        {
            iFormX = this.Location.X;
            iFormY = this.Location.Y;
            iMouseX = MousePosition.X;
            iMouseY = MousePosition.Y;
        }

        private void stdF_MouseMove(object sender, MouseEventArgs e)
        {
            int iMouseX2 = MousePosition.X;
            int iMouseY2 = MousePosition.Y;
            if (e.Button == MouseButtons.Left)
                this.Location = new Point(iFormX + (iMouseX2 - iMouseX), iFormY + (iMouseY2 - iMouseY));
        }

        private void indexingBtn_Click(object sender, EventArgs e)
        {
            indexing1.Visible = true;
        }
    }
}
