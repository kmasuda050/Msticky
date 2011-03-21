using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace Msticky
{
    public partial class SettingDialog : Form
    {
        private XmlSerializableNameValueCollection collection;
        private string current;

        public SettingDialog()
        {
            InitializeComponent();

            current = null;

            this.rotateNumericUpDown.Value = (decimal)Properties.Settings.Default.Rotate;
            this.zoomNumericUpDown.Value = Properties.Settings.Default.Zoom;

            collection = new XmlSerializableNameValueCollection(Properties.Settings.Default.Shortcut);
            foreach (string key in collection.AllKeys)
            {
                this.listBox1.Items.Add(key);
            }

            this.listBox1.SetSelected(0, true);
        }

        private void UpdateShortcut()
        {
            if (textBox1.Text.Length <= 0)
            {
                return;
            }

            Keys shortcut = (Keys)Convert.ToInt32(textBox1.Text[0]);
            if (ctrlCheckBox.Checked)
            {
                shortcut |= Keys.Control;
            }
            if (shiftCheckBox.Checked)
            {
                shortcut |= Keys.Shift;
            }

            String value = ((int)shortcut).ToString();

            foreach (string key in collection.AllKeys)
            {
                if (key.Equals(current))
                    continue;

                if (value.Equals(collection.Get(key)))
                {
                    this.warningLabel.Text = "[Warning] Duplicate!\n" + shortcut.ToString().Replace(", ", "+") +"\n" + key;
                    textBox1.Text = "";
                    return;
                }
            }

            this.warningLabel.Text = "";
            collection.Set(current, value);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (current != null)
                UpdateShortcut();

            warningLabel.Text = "";
            current = listBox1.Text;

            string v = collection.Get(listBox1.Text);
            Keys value = (Keys)int.Parse(v);
            this.ctrlCheckBox.Checked = ((Keys.Control & value) != 0) ? true : false;
            this.shiftCheckBox.Checked = ((Keys.Shift & value) != 0) ? true : false;
            this.textBox1.Text = Convert.ToChar(value & (~Keys.Control) & (~Keys.Shift)).ToString();
            this.currentHotkeyLabel.Text = value.ToString().Replace(", ", "+");
        }

        private void SaveConfig()
        {
            Properties.Settings.Default.Rotate = (float)this.rotateNumericUpDown.Value;
            Properties.Settings.Default.Zoom = (int)this.zoomNumericUpDown.Value;
            Properties.Settings.Default.Shortcut = new XmlSerializableNameValueCollection(collection);
            Properties.Settings.Default.Save();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            UpdateShortcut();

            SaveConfig();

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateShortcut();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Initialize All Configuration. OK?", "", MessageBoxButtons.OKCancel);
            switch (result)
            {
                case DialogResult.OK:
                    Config.Initialize();
                    this.Close();
                    break;
            }
        }
    }
}
