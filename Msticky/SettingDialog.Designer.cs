namespace Msticky
{
    partial class SettingDialog
    {
        /// <summary>
        /// 必要なデザイナー変数です。
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rotateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.zoomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.zoomIncrementLabel = new System.Windows.Forms.Label();
            this.rotateIncrementLabel = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.warningLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.ctrlCheckBox = new System.Windows.Forms.CheckBox();
            this.shiftCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.currentHotkeyLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomNumericUpDown)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.CausesValidation = false;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(231, 316);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.MinimumSize = new System.Drawing.Size(200, 200);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rotateNumericUpDown);
            this.splitContainer1.Panel1.Controls.Add(this.zoomNumericUpDown);
            this.splitContainer1.Panel1.Controls.Add(this.zoomIncrementLabel);
            this.splitContainer1.Panel1.Controls.Add(this.rotateIncrementLabel);
            this.splitContainer1.Panel1MinSize = 94;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(436, 425);
            this.splitContainer1.SplitterDistance = 94;
            this.splitContainer1.TabIndex = 0;
            // 
            // rotateNumericUpDown
            // 
            this.rotateNumericUpDown.Location = new System.Drawing.Point(143, 13);
            this.rotateNumericUpDown.Name = "rotateNumericUpDown";
            this.rotateNumericUpDown.Size = new System.Drawing.Size(120, 19);
            this.rotateNumericUpDown.TabIndex = 4;
            // 
            // zoomNumericUpDown
            // 
            this.zoomNumericUpDown.AutoSize = true;
            this.zoomNumericUpDown.Location = new System.Drawing.Point(143, 50);
            this.zoomNumericUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.zoomNumericUpDown.Name = "zoomNumericUpDown";
            this.zoomNumericUpDown.Size = new System.Drawing.Size(120, 19);
            this.zoomNumericUpDown.TabIndex = 3;
            // 
            // zoomIncrementLabel
            // 
            this.zoomIncrementLabel.AutoSize = true;
            this.zoomIncrementLabel.Location = new System.Drawing.Point(19, 52);
            this.zoomIncrementLabel.Name = "zoomIncrementLabel";
            this.zoomIncrementLabel.Size = new System.Drawing.Size(87, 12);
            this.zoomIncrementLabel.TabIndex = 1;
            this.zoomIncrementLabel.Text = "Zoom Increment";
            // 
            // rotateIncrementLabel
            // 
            this.rotateIncrementLabel.AutoSize = true;
            this.rotateIncrementLabel.Location = new System.Drawing.Point(17, 15);
            this.rotateIncrementLabel.Name = "rotateIncrementLabel";
            this.rotateIncrementLabel.Size = new System.Drawing.Size(93, 12);
            this.rotateIncrementLabel.TabIndex = 0;
            this.rotateIncrementLabel.Text = "Rotate Increment";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button1);
            this.splitContainer2.Panel2.Controls.Add(this.warningLabel);
            this.splitContainer2.Panel2.Controls.Add(this.okButton);
            this.splitContainer2.Panel2.Controls.Add(this.ctrlCheckBox);
            this.splitContainer2.Panel2.Controls.Add(this.shiftCheckBox);
            this.splitContainer2.Panel2.Controls.Add(this.textBox1);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.currentHotkeyLabel);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(436, 327);
            this.splitContainer2.SplitterDistance = 246;
            this.splitContainer2.TabIndex = 0;
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(17, 223);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(0, 12);
            this.warningLabel.TabIndex = 7;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(14, 171);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // ctrlCheckBox
            // 
            this.ctrlCheckBox.AutoSize = true;
            this.ctrlCheckBox.Location = new System.Drawing.Point(14, 121);
            this.ctrlCheckBox.Name = "ctrlCheckBox";
            this.ctrlCheckBox.Size = new System.Drawing.Size(43, 16);
            this.ctrlCheckBox.TabIndex = 5;
            this.ctrlCheckBox.Text = "Ctrl";
            this.ctrlCheckBox.UseVisualStyleBackColor = true;
            // 
            // shiftCheckBox
            // 
            this.shiftCheckBox.AutoSize = true;
            this.shiftCheckBox.Location = new System.Drawing.Point(14, 98);
            this.shiftCheckBox.Name = "shiftCheckBox";
            this.shiftCheckBox.Size = new System.Drawing.Size(48, 16);
            this.shiftCheckBox.TabIndex = 4;
            this.shiftCheckBox.Text = "Shift";
            this.shiftCheckBox.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(12, 72);
            this.textBox1.MaxLength = 1;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 19);
            this.textBox1.TabIndex = 3;
            this.textBox1.WordWrap = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "New";
            // 
            // currentHotkeyLabel
            // 
            this.currentHotkeyLabel.AutoSize = true;
            this.currentHotkeyLabel.Location = new System.Drawing.Point(12, 30);
            this.currentHotkeyLabel.Name = "currentHotkeyLabel";
            this.currentHotkeyLabel.Size = new System.Drawing.Size(106, 12);
            this.currentHotkeyLabel.TabIndex = 1;
            this.currentHotkeyLabel.Text = "CurrentHotkeyLabel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 26);
            this.button1.TabIndex = 8;
            this.button1.Text = "Initialize All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SettingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 425);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingDialog";
            this.Text = "Setting";
            this.TopMost = true;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rotateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomNumericUpDown)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label rotateIncrementLabel;
        private System.Windows.Forms.Label zoomIncrementLabel;
        private System.Windows.Forms.NumericUpDown rotateNumericUpDown;
        private System.Windows.Forms.NumericUpDown zoomNumericUpDown;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentHotkeyLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox shiftCheckBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox ctrlCheckBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Button button1;
    }
}