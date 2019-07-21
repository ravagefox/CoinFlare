namespace CoinFlare
{
    partial class UI
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
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPTIONSToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.aIToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(722, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eXITToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.optionsToolStripMenuItem.Text = "OPTIONS";
            // 
            // eXITToolStripMenuItem
            // 
            this.eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            this.eXITToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.eXITToolStripMenuItem.Text = "EXIT";
            // 
            // aIToolStripMenuItem
            // 
            this.aIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledToolStripMenuItem,
            this.graphsToolStripMenuItem,
            this.rulesToolStripMenuItem,
            this.oPTIONSToolStripMenuItem1});
            this.aIToolStripMenuItem.Name = "aIToolStripMenuItem";
            this.aIToolStripMenuItem.Size = new System.Drawing.Size(30, 20);
            this.aIToolStripMenuItem.Text = "AI";
            // 
            // enabledToolStripMenuItem
            // 
            this.enabledToolStripMenuItem.CheckOnClick = true;
            this.enabledToolStripMenuItem.Name = "enabledToolStripMenuItem";
            this.enabledToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.enabledToolStripMenuItem.Text = "ENABLED";
            // 
            // graphsToolStripMenuItem
            // 
            this.graphsToolStripMenuItem.Name = "graphsToolStripMenuItem";
            this.graphsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.graphsToolStripMenuItem.Text = "GRAPHS";
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.rulesToolStripMenuItem.Text = "RULES";
            // 
            // oPTIONSToolStripMenuItem1
            // 
            this.oPTIONSToolStripMenuItem1.Name = "oPTIONSToolStripMenuItem1";
            this.oPTIONSToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.oPTIONSToolStripMenuItem1.Text = "OPTIONS";
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.hELPToolStripMenuItem.Text = "HELP";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(722, 333);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 357);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoinFlare";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oPTIONSToolStripMenuItem1;
    }
}