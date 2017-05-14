namespace BubbleSort_Main
{
    partial class mainForm
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
            this.newTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.testLabel = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.ListBox();
            this.testProgress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTestToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1205, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newTestToolStripMenuItem
            // 
            this.newTestToolStripMenuItem.ForeColor = System.Drawing.Color.Lime;
            this.newTestToolStripMenuItem.Name = "newTestToolStripMenuItem";
            this.newTestToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.newTestToolStripMenuItem.Text = "Nový test";
            this.newTestToolStripMenuItem.Click += new System.EventHandler(this.newTestToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 546);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // testLabel
            // 
            this.testLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.testLabel.AutoSize = true;
            this.testLabel.ForeColor = System.Drawing.Color.Lime;
            this.testLabel.Location = new System.Drawing.Point(799, 54);
            this.testLabel.Name = "testLabel";
            this.testLabel.Size = new System.Drawing.Size(98, 13);
            this.testLabel.TabIndex = 2;
            this.testLabel.Text = "Naměřené hodnoty";
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.log.BackColor = System.Drawing.Color.Black;
            this.log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.log.ForeColor = System.Drawing.Color.Lime;
            this.log.FormattingEnabled = true;
            this.log.Items.AddRange(new object[] {
            "TEST LOG"});
            this.log.Location = new System.Drawing.Point(799, 99);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(394, 444);
            this.log.TabIndex = 1;
            // 
            // testProgress
            // 
            this.testProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.testProgress.BackColor = System.Drawing.Color.Black;
            this.testProgress.ForeColor = System.Drawing.Color.Lime;
            this.testProgress.Location = new System.Drawing.Point(799, 70);
            this.testProgress.Name = "testProgress";
            this.testProgress.Size = new System.Drawing.Size(394, 23);
            this.testProgress.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(940, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Teoretické hodnoty";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1205, 570);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.testLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.testProgress);
            this.Controls.Add(this.log);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Lime;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Text = "Testování časové závislosti řadícího algorytmu BubbleSort";
            this.SizeChanged += new System.EventHandler(this.mainForm_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newTestToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label testLabel;
        private System.Windows.Forms.ListBox log;
        private System.Windows.Forms.ProgressBar testProgress;
        private System.Windows.Forms.Label label1;
    }
}

