using System;
using System.Windows.Forms;

namespace Jamba_Tips
{
    public partial class DataFilterForm : Form
    {
        public Form1 parent;

        public DataFilterForm()
        {
            InitializeComponent();
        }

        private void DataFilterForm_Load(object sender, EventArgs e)
        {
            foreach (string filter in parent.filters)
                listBox1.Items.Add(filter);
            Form1.ColorScheme colorScheme;
            if (parent.GetColorScheme(parent.currentScheme, out colorScheme))
                Form1.PaintApplication(this, colorScheme);
        }

        private void buttonAddFilter_Click(object sender, EventArgs e)
        {
            if (textBoxFilter.Text.Length > 0 && parent.filters.Add(textBoxFilter.Text.ToLower()))
            {
                listBox1.Items.Add(textBoxFilter.Text);
                textBoxFilter.Text = "";
                parent.StartAutosave();
            }
        }

        private void buttonRemoveFilter_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0 && listBox1.SelectedItems.Count == 1 && listBox1.SelectedIndex >= 0 && listBox1.SelectedItem != null)
            {
                string filter = listBox1.SelectedItem.ToString().ToLower();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                if (parent.filters.Remove(filter))
                    parent.StartAutosave();
            }
        }
    }
}
