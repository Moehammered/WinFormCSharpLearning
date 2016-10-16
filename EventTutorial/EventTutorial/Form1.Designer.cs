namespace EventTutorial
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buttonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(426, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // buttonsToolStripMenuItem
            // 
            this.buttonsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.button1ToolStripMenuItem,
            this.button4ToolStripMenuItem,
            this.button6ToolStripMenuItem,
            this.button9ToolStripMenuItem});
            this.buttonsToolStripMenuItem.Name = "buttonsToolStripMenuItem";
            this.buttonsToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.buttonsToolStripMenuItem.Text = "Buttons";
            this.buttonsToolStripMenuItem.Click += new System.EventHandler(this.buttonsToolStripMenuItem_Click);
            // 
            // button1ToolStripMenuItem
            // 
            this.button1ToolStripMenuItem.Name = "button1ToolStripMenuItem";
            this.button1ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.button1ToolStripMenuItem.Text = "1 Button";
            this.button1ToolStripMenuItem.Click += new System.EventHandler(this.button1ToolStripMenuItem_Click);
            // 
            // button4ToolStripMenuItem
            // 
            this.button4ToolStripMenuItem.Name = "button4ToolStripMenuItem";
            this.button4ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.button4ToolStripMenuItem.Text = "4 Button";
            this.button4ToolStripMenuItem.Click += new System.EventHandler(this.button4ToolStripMenuItem_Click);
            // 
            // button9ToolStripMenuItem
            // 
            this.button9ToolStripMenuItem.Name = "button9ToolStripMenuItem";
            this.button9ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.button9ToolStripMenuItem.Text = "9 Button";
            this.button9ToolStripMenuItem.Click += new System.EventHandler(this.button9ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 368);
            this.panel1.TabIndex = 1;
            // 
            // button6ToolStripMenuItem
            // 
            this.button6ToolStripMenuItem.Name = "button6ToolStripMenuItem";
            this.button6ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.button6ToolStripMenuItem.Text = "6 Button";
            this.button6ToolStripMenuItem.Click += new System.EventHandler(this.button6ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 403);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem buttonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem button1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem button4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem button9ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem button6ToolStripMenuItem;
    }
}

