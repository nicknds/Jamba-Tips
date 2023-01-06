using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamba_Tips
{
    public partial class DataFilterForm : Form
    {
        public Form1 parent;

        private HashSet<string> filterSet = new HashSet<string>();

        public DataFilterForm()
        {
            InitializeComponent();
        }

        private void DataFilterForm_Load(object sender, EventArgs e)
        {
            foreach (string filter in Properties.Settings.Default.Filters)
            {
                listBox1.Items.Add(filter);
                filterSet.Add(filter.ToLower());
            }
            Form1.ColorScheme colorScheme;
            if (parent.GetColorScheme(Properties.Settings.Default.ColorScheme, out colorScheme))
                Form1.PaintApplication(this, colorScheme);
        }

        private void buttonAddFilter_Click(object sender, EventArgs e)
        {
            if (textBoxFilter.Text.Length > 0 && filterSet.Add(textBoxFilter.Text.ToLower()))
            {
                listBox1.Items.Add(textBoxFilter.Text);
                Properties.Settings.Default.Filters.Add(textBoxFilter.Text.ToLower());
                Properties.Settings.Default.Save();
                textBoxFilter.Text = "";
                parent.UpdateFilters();
            }
        }

        private void buttonRemoveFilter_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0 && listBox1.SelectedItems.Count == 1 && listBox1.SelectedIndex >= 0 && listBox1.SelectedItem != null)
            {
                string filter = listBox1.SelectedItem.ToString().ToLower();
                filterSet.Remove(filter);
                Properties.Settings.Default.Filters.Remove(filter);
                Properties.Settings.Default.Save();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                parent.UpdateFilters();
            }
        }
    }
}
