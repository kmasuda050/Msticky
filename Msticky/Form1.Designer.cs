namespace Msticky
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axQTControl1 = new AxQTOControlLib.AxQTControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mopenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mhistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mhelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axQTControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(37, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topToolStripMenuItem,
            this.openToolStripMenuItem,
            this.historyToolStripMenuItem,
            this.freezeToolStripMenuItem,
            this.showMenuToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 158);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open File";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.historyToolStripMenuItem.Text = "History";
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.Checked = true;
            this.topToolStripMenuItem.CheckOnClick = true;
            this.topToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.topToolStripMenuItem.Text = "Top";
            this.topToolStripMenuItem.Click += new System.EventHandler(this.topToolStripMenuItem_Click);
            // 
            // freezeToolStripMenuItem
            // 
            this.freezeToolStripMenuItem.CheckOnClick = true;
            this.freezeToolStripMenuItem.Name = "freezeToolStripMenuItem";
            this.freezeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.freezeToolStripMenuItem.Text = "Freeze";
            this.freezeToolStripMenuItem.Visible = false;
            this.freezeToolStripMenuItem.Click += new System.EventHandler(this.freezeToolStripMenuItem_Click);
            // 
            // showMenuToolStripMenuItem
            // 
            this.showMenuToolStripMenuItem.Name = "showMenuToolStripMenuItem";
            this.showMenuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showMenuToolStripMenuItem.Text = "Show Menu";
            this.showMenuToolStripMenuItem.Visible = false;
            this.showMenuToolStripMenuItem.Click += new System.EventHandler(this.showMenuToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // axQTControl1
            // 
            this.axQTControl1.Enabled = true;
            this.axQTControl1.Location = new System.Drawing.Point(0, 0);
            this.axQTControl1.Name = "axQTControl1";
            this.axQTControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axQTControl1.OcxState")));
            this.axQTControl1.Size = new System.Drawing.Size(192, 192);
            this.axQTControl1.TabIndex = 1;
            this.axQTControl1.Visible = false;
            this.axQTControl1.MouseUpEvent += new AxQTOControlLib._IQTControlEvents_MouseUpEventHandler(this.axQTControl1_MouseUpEvent);
            this.axQTControl1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.axQTControl1_PreviewKeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mopenToolStripMenuItem,
            this.mhistoryToolStripMenuItem,
            this.hideMenuToolStripMenuItem,
            this.mhelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(327, 26);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mopenToolStripMenuItem
            // 
            this.mopenToolStripMenuItem.Name = "mopenToolStripMenuItem";
            this.mopenToolStripMenuItem.Size = new System.Drawing.Size(74, 22);
            this.mopenToolStripMenuItem.Text = "Open File";
            this.mopenToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // mhistoryToolStripMenuItem
            // 
            this.mhistoryToolStripMenuItem.Name = "mhistoryToolStripMenuItem";
            this.mhistoryToolStripMenuItem.Size = new System.Drawing.Size(62, 22);
            this.mhistoryToolStripMenuItem.Text = "History";
            // 
            // hideMenuToolStripMenuItem
            // 
            this.hideMenuToolStripMenuItem.Name = "hideMenuToolStripMenuItem";
            this.hideMenuToolStripMenuItem.Size = new System.Drawing.Size(81, 22);
            this.hideMenuToolStripMenuItem.Text = "Hide Menu";
            this.hideMenuToolStripMenuItem.Click += new System.EventHandler(this.hideMenuToolStripMenuItem_Click);
            // 
            // mhelpToolStripMenuItem
            // 
            this.mhelpToolStripMenuItem.Name = "mhelpToolStripMenuItem";
            this.mhelpToolStripMenuItem.Size = new System.Drawing.Size(46, 22);
            this.mhelpToolStripMenuItem.Text = "Help";
            this.mhelpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 276);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.axQTControl1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Msticky";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Form1_DragOver);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseWheel);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axQTControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freezeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private AxQTOControlLib.AxQTControl axQTControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mopenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mhistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mhelpToolStripMenuItem;
    }
}

