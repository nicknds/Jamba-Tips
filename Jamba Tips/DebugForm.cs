using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Jamba_Tips
{
    public partial class DebugForm : Form
    {
        private List<string> outputList = new List<string>();

        private int outputLength = 0;

        public Form1 parent;

        private SetTextDelegate setTextDelegate;

        public DebugForm()
        {
            InitializeComponent();
            setTextDelegate = SetRichboxText;
        }

        private delegate void SetTextDelegate(string text);

        private void SetRichboxText(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                Action safeWrite = delegate { SetRichboxText(text); };
                richTextBox1.Invoke(safeWrite);
            }
            else
                richTextBox1.Text = text;
        }

        public void AddOutput(string text)
        {
            if (text != null && text.Length > 0)
            {
                outputList.Insert(0, text);
                outputLength += text.Length;
                while (outputLength > 100000 || outputList.Count > 50)
                {
                    outputLength -= outputList[outputList.Count - 1].Length;
                    outputList.RemoveAt(outputList.Count - 1);
                }

                StringBuilder builder = new StringBuilder();

                foreach (string line in outputList)
                    builder.AppendLine(line);

                setTextDelegate.Invoke(builder.ToString());
            }
        }

        private void timerParentReader_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (KeyValuePair<string, Stopwatch> kvp in parent.timerList)
            {
                listBox1.Items.Add($"{kvp.Key} : {TimeString(kvp.Value.Elapsed)}");
            }
        }

        private string TimeString(TimeSpan span)
        {
            StringBuilder builder = new StringBuilder();

            if (span.Hours > 0.0)
                builder.Append($"{span.Hours}H");

            if (span.Minutes > 0.0)
                builder.Append($"{(builder.Length == 0 ? " " : "")}{span.Minutes}M");

            if (span.Seconds > 0.0)
                builder.Append($"{(builder.Length == 0 ? " " : "")}{span.Seconds}M");

            builder.Append($"{(builder.Length == 0 ? " " : "")}{span.Milliseconds}MS");

            return builder.ToString();
        }

        private void buttonTestEmployees_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i = 1; i <= 25; i++)
            {
                for (int d = 0; d < 14; d++)
                {
                    if (rnd.Next(1, 10) >= 4)
                    {
                        Form1.EmployeeDay employeeDay = new Form1.EmployeeDay();
                        employeeDay.name = $"Test, Employee ({i})";
                        employeeDay.hours = parent.RoundMoney((decimal)Math.Max(2.0, rnd.NextDouble() * 8.0));
                        employeeDay.day = parent.RoundTime(DateTime.Now.AddDays(d));
                        parent.AddDay(employeeDay);
                    }
                }
            }
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            Form1.ColorScheme colorScheme;
            if (parent.GetColorScheme(parent.currentScheme, out colorScheme))
                Form1.PaintApplication(this, colorScheme);
        }
    }
}
