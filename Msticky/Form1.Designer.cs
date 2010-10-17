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
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axQTControl1 = new AxQTOControlLib.AxQTControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mopenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mhistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.increaseOpacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseOpacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityMaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityMinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cCWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetRotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.iconizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.freezeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.moveWindowLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveWindowRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveWindowUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveWindowDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.moveImageLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveImageRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveImageUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveImageDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 136);
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.Checked = true;
            this.topToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.topToolStripMenuItem.Text = "Top";
            this.topToolStripMenuItem.Click += new System.EventHandler(this.topToolStripMenuItem_Click);
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
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.hideMenuToolStripMenuItem,
            this.mhelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(410, 26);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mopenToolStripMenuItem,
            this.mhistoryToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 22);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mopenToolStripMenuItem
            // 
            this.mopenToolStripMenuItem.Name = "mopenToolStripMenuItem";
            this.mopenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mopenToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.mopenToolStripMenuItem.Text = "&Open File";
            this.mopenToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // mhistoryToolStripMenuItem
            // 
            this.mhistoryToolStripMenuItem.Name = "mhistoryToolStripMenuItem";
            this.mhistoryToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.mhistoryToolStripMenuItem.Text = "History";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.fitToolStripMenuItem,
            this.toolStripSeparator2,
            this.increaseOpacityToolStripMenuItem,
            this.decreaseOpacityToolStripMenuItem,
            this.opacityMaxToolStripMenuItem,
            this.opacityMinToolStripMenuItem,
            this.toolStripSeparator3,
            this.cWToolStripMenuItem,
            this.cCWToolStripMenuItem,
            this.resetRotationToolStripMenuItem,
            this.toolStripSeparator4,
            this.iconizeToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.ShortcutKeyDisplayString = "X";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom &In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.ShortcutKeyDisplayString = "C";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom &Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // fitToolStripMenuItem
            // 
            this.fitToolStripMenuItem.Name = "fitToolStripMenuItem";
            this.fitToolStripMenuItem.ShortcutKeyDisplayString = "Z";
            this.fitToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.fitToolStripMenuItem.Text = "&Fit";
            this.fitToolStripMenuItem.Click += new System.EventHandler(this.fitToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(212, 6);
            // 
            // increaseOpacityToolStripMenuItem
            // 
            this.increaseOpacityToolStripMenuItem.Name = "increaseOpacityToolStripMenuItem";
            this.increaseOpacityToolStripMenuItem.ShortcutKeyDisplayString = "A";
            this.increaseOpacityToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.increaseOpacityToolStripMenuItem.Text = "I&ncrease Opacity";
            this.increaseOpacityToolStripMenuItem.Click += new System.EventHandler(this.increaseOpacityToolStripMenuItem_Click);
            // 
            // decreaseOpacityToolStripMenuItem
            // 
            this.decreaseOpacityToolStripMenuItem.Name = "decreaseOpacityToolStripMenuItem";
            this.decreaseOpacityToolStripMenuItem.ShortcutKeyDisplayString = "S";
            this.decreaseOpacityToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.decreaseOpacityToolStripMenuItem.Text = "&Decrease Opacity";
            this.decreaseOpacityToolStripMenuItem.Click += new System.EventHandler(this.decreaseOpacityToolStripMenuItem_Click);
            // 
            // opacityMaxToolStripMenuItem
            // 
            this.opacityMaxToolStripMenuItem.Name = "opacityMaxToolStripMenuItem";
            this.opacityMaxToolStripMenuItem.ShortcutKeyDisplayString = "Shift+A";
            this.opacityMaxToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.opacityMaxToolStripMenuItem.Text = "Opacity Max";
            this.opacityMaxToolStripMenuItem.Click += new System.EventHandler(this.opacityMaxToolStripMenuItem_Click);
            // 
            // opacityMinToolStripMenuItem
            // 
            this.opacityMinToolStripMenuItem.Name = "opacityMinToolStripMenuItem";
            this.opacityMinToolStripMenuItem.ShortcutKeyDisplayString = "Shift+S";
            this.opacityMinToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.opacityMinToolStripMenuItem.Text = "Opacity Min";
            this.opacityMinToolStripMenuItem.Click += new System.EventHandler(this.opacityMinToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(212, 6);
            // 
            // cWToolStripMenuItem
            // 
            this.cWToolStripMenuItem.Name = "cWToolStripMenuItem";
            this.cWToolStripMenuItem.ShortcutKeyDisplayString = "W";
            this.cWToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.cWToolStripMenuItem.Text = "CW";
            this.cWToolStripMenuItem.ToolTipText = "ClockWise Rotation";
            this.cWToolStripMenuItem.Click += new System.EventHandler(this.cWToolStripMenuItem_Click);
            // 
            // cCWToolStripMenuItem
            // 
            this.cCWToolStripMenuItem.Name = "cCWToolStripMenuItem";
            this.cCWToolStripMenuItem.ShortcutKeyDisplayString = "R";
            this.cCWToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.cCWToolStripMenuItem.Text = "CCW";
            this.cCWToolStripMenuItem.ToolTipText = "CounterClockWise Rotation";
            this.cCWToolStripMenuItem.Click += new System.EventHandler(this.cCWToolStripMenuItem_Click);
            // 
            // resetRotationToolStripMenuItem
            // 
            this.resetRotationToolStripMenuItem.Name = "resetRotationToolStripMenuItem";
            this.resetRotationToolStripMenuItem.ShortcutKeyDisplayString = "Shift+R";
            this.resetRotationToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.resetRotationToolStripMenuItem.Text = "Reset Rotation";
            this.resetRotationToolStripMenuItem.Click += new System.EventHandler(this.resetRotationToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(212, 6);
            // 
            // iconizeToolStripMenuItem
            // 
            this.iconizeToolStripMenuItem.Name = "iconizeToolStripMenuItem";
            this.iconizeToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.iconizeToolStripMenuItem.Text = "Iconize";
            this.iconizeToolStripMenuItem.Click += new System.EventHandler(this.iconizeToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topToolStripMenuItem1,
            this.freezeToolStripMenuItem1,
            this.toolStripSeparator5,
            this.moveWindowLeftToolStripMenuItem,
            this.moveWindowRightToolStripMenuItem,
            this.moveWindowUpToolStripMenuItem,
            this.moveWindowDownToolStripMenuItem,
            this.toolStripSeparator6,
            this.moveImageLeftToolStripMenuItem,
            this.moveImageRightToolStripMenuItem,
            this.moveImageUpToolStripMenuItem,
            this.moveImageDownToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(66, 22);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // topToolStripMenuItem1
            // 
            this.topToolStripMenuItem1.Checked = true;
            this.topToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topToolStripMenuItem1.Name = "topToolStripMenuItem1";
            this.topToolStripMenuItem1.Size = new System.Drawing.Size(258, 22);
            this.topToolStripMenuItem1.Text = "Top";
            this.topToolStripMenuItem1.Click += new System.EventHandler(this.topToolStripMenuItem_Click);
            // 
            // freezeToolStripMenuItem1
            // 
            this.freezeToolStripMenuItem1.Name = "freezeToolStripMenuItem1";
            this.freezeToolStripMenuItem1.Size = new System.Drawing.Size(258, 22);
            this.freezeToolStripMenuItem1.Text = "Freeze";
            this.freezeToolStripMenuItem1.Visible = false;
            this.freezeToolStripMenuItem1.Click += new System.EventHandler(this.freezeToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(255, 6);
            // 
            // moveWindowLeftToolStripMenuItem
            // 
            this.moveWindowLeftToolStripMenuItem.Name = "moveWindowLeftToolStripMenuItem";
            this.moveWindowLeftToolStripMenuItem.ShortcutKeyDisplayString = "Left";
            this.moveWindowLeftToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.moveWindowLeftToolStripMenuItem.Text = "Move Window Left";
            this.moveWindowLeftToolStripMenuItem.Click += new System.EventHandler(this.moveWindowLeftToolStripMenuItem_Click);
            // 
            // moveWindowRightToolStripMenuItem
            // 
            this.moveWindowRightToolStripMenuItem.Name = "moveWindowRightToolStripMenuItem";
            this.moveWindowRightToolStripMenuItem.ShortcutKeyDisplayString = "Right";
            this.moveWindowRightToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.moveWindowRightToolStripMenuItem.Text = "Move Window Right";
            this.moveWindowRightToolStripMenuItem.Click += new System.EventHandler(this.moveWindowRightToolStripMenuItem_Click);
            // 
            // moveWindowUpToolStripMenuItem
            // 
            this.moveWindowUpToolStripMenuItem.Name = "moveWindowUpToolStripMenuItem";
            this.moveWindowUpToolStripMenuItem.ShortcutKeyDisplayString = "Up";
            this.moveWindowUpToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.moveWindowUpToolStripMenuItem.Text = "Move Window Up";
            this.moveWindowUpToolStripMenuItem.Click += new System.EventHandler(this.moveWindowUpToolStripMenuItem_Click);
            // 
            // moveWindowDownToolStripMenuItem
            // 
            this.moveWindowDownToolStripMenuItem.Name = "moveWindowDownToolStripMenuItem";
            this.moveWindowDownToolStripMenuItem.ShortcutKeyDisplayString = "Down";
            this.moveWindowDownToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.moveWindowDownToolStripMenuItem.Text = "Move Window Down";
            this.moveWindowDownToolStripMenuItem.Click += new System.EventHandler(this.moveWindowDownToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(255, 6);
            // 
            // moveImageLeftToolStripMenuItem
            // 
            this.moveImageLeftToolStripMenuItem.Name = "moveImageLeftToolStripMenuItem";
            this.moveImageLeftToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.moveImageLeftToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.moveImageLeftToolStripMenuItem.Text = "Move Image Left";
            this.moveImageLeftToolStripMenuItem.Click += new System.EventHandler(this.moveImageLeftToolStripMenuItem_Click);
            // 
            // moveImageRightToolStripMenuItem
            // 
            this.moveImageRightToolStripMenuItem.Name = "moveImageRightToolStripMenuItem";
            this.moveImageRightToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.moveImageRightToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.moveImageRightToolStripMenuItem.Text = "Move Image Right";
            this.moveImageRightToolStripMenuItem.Click += new System.EventHandler(this.moveImageRightToolStripMenuItem_Click);
            // 
            // moveImageUpToolStripMenuItem
            // 
            this.moveImageUpToolStripMenuItem.Name = "moveImageUpToolStripMenuItem";
            this.moveImageUpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.moveImageUpToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.moveImageUpToolStripMenuItem.Text = "Move Image Up";
            this.moveImageUpToolStripMenuItem.Click += new System.EventHandler(this.moveImageUpToolStripMenuItem_Click);
            // 
            // moveImageDownToolStripMenuItem
            // 
            this.moveImageDownToolStripMenuItem.Name = "moveImageDownToolStripMenuItem";
            this.moveImageDownToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.moveImageDownToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.moveImageDownToolStripMenuItem.Text = "Move Image Down";
            this.moveImageDownToolStripMenuItem.Click += new System.EventHandler(this.moveImageDownToolStripMenuItem_Click);
            // 
            // hideMenuToolStripMenuItem
            // 
            this.hideMenuToolStripMenuItem.Name = "hideMenuToolStripMenuItem";
            this.hideMenuToolStripMenuItem.Size = new System.Drawing.Size(81, 22);
            this.hideMenuToolStripMenuItem.Text = "Hide &Menu";
            this.hideMenuToolStripMenuItem.Click += new System.EventHandler(this.hideMenuToolStripMenuItem_Click);
            // 
            // mhelpToolStripMenuItem
            // 
            this.mhelpToolStripMenuItem.Name = "mhelpToolStripMenuItem";
            this.mhelpToolStripMenuItem.Size = new System.Drawing.Size(46, 22);
            this.mhelpToolStripMenuItem.Text = "&Help";
            this.mhelpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 277);
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
        private System.Windows.Forms.ToolStripMenuItem hideMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mhelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mopenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mhistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem increaseOpacityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decreaseOpacityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opacityMaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opacityMinToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cCWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetRotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem iconizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveWindowLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveWindowRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveWindowUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveWindowDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem moveImageLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveImageRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveImageUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveImageDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem topToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem freezeToolStripMenuItem1;
    }
}

