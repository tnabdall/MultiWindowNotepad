namespace MenuDemonstration
{
    partial class TextEditorForm
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
            this.components = new System.ComponentModel.Container();
            this.mainTextBox = new System.Windows.Forms.TextBox();
            this.colourContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colourContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTextBox
            // 
            this.mainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTextBox.ContextMenuStrip = this.colourContextMenuStrip;
            this.mainTextBox.Location = new System.Drawing.Point(1, 0);
            this.mainTextBox.Multiline = true;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.Size = new System.Drawing.Size(534, 579);
            this.mainTextBox.TabIndex = 0;
            this.mainTextBox.TextChanged += new System.EventHandler(this.mainTextBox_TextChanged);
            // 
            // colourContextMenuStrip
            // 
            this.colourContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackToolStripMenuItem,
            this.redToolStripMenuItem,
            this.blueToolStripMenuItem,
            this.vertToolStripMenuItem});
            this.colourContextMenuStrip.Name = "colourContextMenuStrip";
            this.colourContextMenuStrip.Size = new System.Drawing.Size(103, 92);
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.redToolStripMenuItem.Tag = "Red";
            this.redToolStripMenuItem.Text = "Red";
            this.redToolStripMenuItem.Click += new System.EventHandler(this.TextEditColourChanged);
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.blueToolStripMenuItem.Tag = "Blue";
            this.blueToolStripMenuItem.Text = "Blue";
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.TextEditColourChanged);
            // 
            // vertToolStripMenuItem
            // 
            this.vertToolStripMenuItem.Name = "vertToolStripMenuItem";
            this.vertToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vertToolStripMenuItem.Tag = "Green";
            this.vertToolStripMenuItem.Text = "Vert";
            this.vertToolStripMenuItem.Click += new System.EventHandler(this.TextEditColourChanged);
            // 
            // blackToolStripMenuItem
            // 
            this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            this.blackToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.blackToolStripMenuItem.Tag = "Black";
            this.blackToolStripMenuItem.Text = "Black";
            this.blackToolStripMenuItem.Click += new System.EventHandler(this.TextEditColourChanged);
            // 
            // TextEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 580);
            this.Controls.Add(this.mainTextBox);
            this.Name = "TextEditorForm";
            this.Text = "untitled.txt";
            this.colourContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mainTextBox;
        private System.Windows.Forms.ContextMenuStrip colourContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vertToolStripMenuItem;
    }
}