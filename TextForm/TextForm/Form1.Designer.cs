namespace TextForm
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
            this.TextField = new System.Windows.Forms.RichTextBox();
            this.numeracyPanel = new System.Windows.Forms.Panel();
            this.opPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // TextField
            // 
            this.TextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextField.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextField.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TextField.Location = new System.Drawing.Point(7, 8);
            this.TextField.Margin = new System.Windows.Forms.Padding(2);
            this.TextField.Name = "TextField";
            this.TextField.ReadOnly = true;
            this.TextField.Size = new System.Drawing.Size(489, 67);
            this.TextField.TabIndex = 1;
            this.TextField.Text = "";
            this.TextField.WordWrap = false;
            this.TextField.TextChanged += new System.EventHandler(this.TextField_TextChanged);
            // 
            // numeracyPanel
            // 
            this.numeracyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numeracyPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.numeracyPanel.Location = new System.Drawing.Point(8, 79);
            this.numeracyPanel.Margin = new System.Windows.Forms.Padding(2);
            this.numeracyPanel.Name = "numeracyPanel";
            this.numeracyPanel.Size = new System.Drawing.Size(321, 241);
            this.numeracyPanel.TabIndex = 2;
            // 
            // opPanel
            // 
            this.opPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.opPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.opPanel.Location = new System.Drawing.Point(333, 79);
            this.opPanel.Margin = new System.Windows.Forms.Padding(2);
            this.opPanel.Name = "opPanel";
            this.opPanel.Size = new System.Drawing.Size(159, 241);
            this.opPanel.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(503, 328);
            this.Controls.Add(this.opPanel);
            this.Controls.Add(this.numeracyPanel);
            this.Controls.Add(this.TextField);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox TextField;
        private System.Windows.Forms.Panel numeracyPanel;
        private System.Windows.Forms.Panel opPanel;
    }
}

