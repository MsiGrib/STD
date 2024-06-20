namespace STD
{
    partial class stdF
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            exitBtn = new Button();
            minimizeBtn = new Button();
            indexingBtn = new GUI.Controls.castomButton();
            indexing1 = new GUI.Widgets.indexing();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(-3, -1);
            label1.Name = "label1";
            label1.Size = new Size(371, 40);
            label1.TabIndex = 0;
            label1.Text = "System Template Document";
            // 
            // exitBtn
            // 
            exitBtn.BackgroundImageLayout = ImageLayout.None;
            exitBtn.FlatAppearance.BorderSize = 0;
            exitBtn.FlatStyle = FlatStyle.Popup;
            exitBtn.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            exitBtn.Location = new Point(1229, -1);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(64, 53);
            exitBtn.TabIndex = 1;
            exitBtn.Text = "X";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitBtn_Click;
            // 
            // minimizeBtn
            // 
            minimizeBtn.BackgroundImageLayout = ImageLayout.None;
            minimizeBtn.FlatAppearance.BorderSize = 0;
            minimizeBtn.FlatStyle = FlatStyle.Popup;
            minimizeBtn.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            minimizeBtn.Location = new Point(1168, -1);
            minimizeBtn.Name = "minimizeBtn";
            minimizeBtn.Size = new Size(64, 53);
            minimizeBtn.TabIndex = 2;
            minimizeBtn.Text = "_";
            minimizeBtn.UseVisualStyleBackColor = true;
            minimizeBtn.Click += minimizeBtn_Click;
            // 
            // indexingBtn
            // 
            indexingBtn.BackColor = Color.MediumSlateBlue;
            indexingBtn.Background_color = Color.MediumSlateBlue;
            indexingBtn.Border_color = Color.PaleVioletRed;
            indexingBtn.Border_radius = 30;
            indexingBtn.Border_size = 0;
            indexingBtn.FlatAppearance.BorderSize = 0;
            indexingBtn.FlatStyle = FlatStyle.Flat;
            indexingBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            indexingBtn.Fore_color = Color.White;
            indexingBtn.ForeColor = Color.White;
            indexingBtn.Location = new Point(546, 93);
            indexingBtn.Name = "indexingBtn";
            indexingBtn.Size = new Size(259, 103);
            indexingBtn.TabIndex = 3;
            indexingBtn.Text = "Индексация";
            indexingBtn.UseVisualStyleBackColor = false;
            indexingBtn.Click += indexingBtn_Click;
            // 
            // indexing1
            // 
            indexing1.BackColor = Color.White;
            indexing1.Location = new Point(12, 229);
            indexing1.Name = "indexing1";
            indexing1.Size = new Size(1281, 837);
            indexing1.TabIndex = 4;
            // 
            // stdF
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1295, 1070);
            Controls.Add(indexing1);
            Controls.Add(indexingBtn);
            Controls.Add(minimizeBtn);
            Controls.Add(exitBtn);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "stdF";
            Text = " ";
            MouseDown += stdF_MouseDown;
            MouseMove += stdF_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button exitBtn;
        private Button minimizeBtn;
        private GUI.Controls.castomButton indexingBtn;
        private GUI.Widgets.indexing indexing1;
    }
}
