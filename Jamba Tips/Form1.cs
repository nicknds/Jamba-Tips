using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamba_Tips
{
    public partial class Form1 : Form
    {
        //Variables

        public SortedList<string, EmployeeTotal> employeeTotalList = new SortedList<string, EmployeeTotal>();

        public SortedList<DateTime, double> dailyTipValues = new SortedList<DateTime, double>();

        public List<string> blacklistedEmployees = new List<string>();

        public bool loading = false, webviewInitialized = false, readingPage = false, gettingEmployeeInfo = false, gettingTimesheet = false,
                    navigatedHome = false;

        public DebugForm debugForm;

        public SortedList<string, Stopwatch> timerList = new SortedList<string, Stopwatch>();

        public enum ReadStatus
        {
            Idle,
            Reading,
            Read
        };

        public ReadStatus readStatus = ReadStatus.Read;

        public string empInfo = "", timesheet = "";

        //Main functions

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loading = true;
            SetReadStatus(ReadStatus.Read);
            if (Properties.Settings.Default.HomepageURL.Length > 0)
                try
                {
                    textBoxHomepage.Text = Properties.Settings.Default.HomepageURL;
                }
                catch { }
            foreach (string str in Properties.Settings.Default.BlacklistedEmployees)
                blacklistedEmployees.Add(str);
            LoadEmployees();
            checkBoxNormalizedNames.Checked = Properties.Settings.Default.NormalizedNames;
            if (employeeTotalList.Count > 0)
                Output($"Loaded employees: {employeeTotalList.Count}");
            if (dailyTipValues.Count > 0)
                Output($"Loaded tips: {dailyTipValues.Count}");
            if (blacklistedEmployees.Count > 0)
                Output($"Employees excluded from tips: {blacklistedEmployees.Count}");
            loading = false;
        }

        public void SaveEmployees()
        {
            Record("Saving Data");
            Output("Saving before close...");
            Properties.Settings.Default.EmployeeDays.Clear();

            foreach (KeyValuePair<string, EmployeeTotal> kvpA in employeeTotalList)
            {
                foreach (KeyValuePair<DateTime, EmployeeDay> kvpB in kvpA.Value.employeeDays)
                {
                    Properties.Settings.Default.EmployeeDays.Add(kvpB.Value.ToString());
                }
            }

            Properties.Settings.Default.DailyTips.Clear();

            foreach (KeyValuePair<DateTime, double> kvpA in dailyTipValues)
            {
                Properties.Settings.Default.DailyTips.Add($"{kvpA.Value}♠{kvpA.Key.Month}♠{kvpA.Key.Day}♠");
            }

            Properties.Settings.Default.BlacklistedEmployees.Clear();

            foreach (string str in blacklistedEmployees)
            {
                Properties.Settings.Default.BlacklistedEmployees.Add(str);
            }

            Properties.Settings.Default.Save();
            Record("Saving Data", false);
        }

        public void LoadEmployees()
        {
            Record("Loading Data");
            foreach (string str in Properties.Settings.Default.EmployeeDays)
            {
                AddDay(new EmployeeDay(str));
            }

            string[] args;
            foreach (string str in Properties.Settings.Default.DailyTips)
            {
                args = str.Split('♠');
                dailyTipValues[new DateTime(DateTime.Now.Year, int.Parse(args[1]), int.Parse(args[2]))] = double.Parse(args[0]);
            }
            Record("Loading Data", false);
        }

        public double RoundMoney(double value)
        {
            return Math.Floor(value * 100.0) / 100.0;
        }

        public DateTime RoundTime(DateTime time)
        {
            return new DateTime(DateTime.Now.Year, time.Month, time.Day);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveEmployees();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 1:
                    CalculateCurrentDate();
                    break;
                case 2:
                    RefreshEmployeeList();
                    break;
                case 3:
                    RefreshDayList();
                    break;
            }
        }

        public void Output(string text)
        {
            if (listBoxOutput.InvokeRequired)
            {
                Action safeWrite = delegate { Output(text); };
                listBoxOutput.Invoke(safeWrite);
            }
            else
            {
                listBoxOutput.Items.Insert(0, $"{DateTime.Now.ToLongTimeString()} {text}");
                if (listBoxOutput.Items.Count > 50)
                    listBoxOutput.Items.RemoveAt(50);
            }
        }

        public void LongOutput(string text)
        {
            if (debugForm != null)
                debugForm.AddOutput(text);
        }

        public Color StatusColor()
        {
            switch (readStatus)
            {
                case ReadStatus.Idle:
                    return Color.Green;
                case ReadStatus.Reading:
                    return Color.Yellow;
                case ReadStatus.Read:
                    return Color.Red;
                default:
                    return Color.Green;
            }
        }

        public void Record(string key, bool start = true)
        {
            if (!start)
            {
                if (timerList.ContainsKey(key))
                    timerList[key].Stop();
            }
            else if (!timerList.ContainsKey(key))
            {
                timerList[key] = new Stopwatch();
                timerList[key].Start();
            }
            else
            {
                timerList[key].Restart();
            }
        }

        //Browser tab

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                try
                {
                    if (webviewInitialized)
                    {
                        webView21.CoreWebView2.Navigate($"file:///{((string[])e.Data.GetData(DataFormats.FileDrop, false))[0]}");
                    }
                }
                catch { }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void timerLoadDelay_Tick(object sender, EventArgs e)
        {
            timerLoadDelay.Stop();
            try
            {
                ReadDocument(webBrowser1.Document);
                Output("Reading complete.");
            }
            catch { Output("Error parsing document"); }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            timerLoadDelay.Stop();
            timerLoadDelay.Start();
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            timerLoadDelay.Stop();
        }

        private void webView21_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            if (webviewInitialized)
                textBoxURL.Text = webView21.CoreWebView2.Source;
        }

        private void webView21_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (!navigatedHome && webviewInitialized)
            {
                navigatedHome = true;
                if (Properties.Settings.Default.HomepageURL.Length > 0)
                    try
                    {
                        MainNavigation(Properties.Settings.Default.HomepageURL);
                    }
                    catch { }
            }
            if (readStatus == ReadStatus.Read)
                SetReadStatus(ReadStatus.Idle);
            if (checkBoxAutoRead.Checked)
                ReadPage();
        }

        private void webView21_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            webviewInitialized = true;
            Output("WebView2 initialized.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainNavigation(textBoxURL.Text);
        }

        public void MainNavigation(string text)
        {
            if (text.Length > 0 && webviewInitialized)
            {
                try
                {
                    string url = text;
                    if (!PassingURL(url)) url = $"https://{url}";
                    webView21.CoreWebView2.Navigate(url);
                }
                catch { }
            }
        }

        public bool PassingURL(string text)
        {
            string url = text.ToLower();
            return url.StartsWith("http://") || url.StartsWith("https://");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReadPage();
        }

        public void ReadPage()
        {
            if (webviewInitialized && !readingPage)
            {
                Record("Starting Task");
                readingPage = true;
                SetReadStatus(ReadStatus.Reading);
                Output("Reading HTML in background.");
                //webView21.CoreWebView2.ExecuteScriptAsync("document.body.outerHTML").ContinueWith(FinalizeTask);
                webView21.CoreWebView2.ExecuteScriptAsync("document.getElementById(\"tbltimesheet\").outerHTML").ContinueWith(FinalizeTimesheet);
                webView21.CoreWebView2.ExecuteScriptAsync("document.getElementById(\"empInfo\").outerHTML").ContinueWith(FinalizeEmployeeInfo);
                gettingEmployeeInfo = true;
                gettingTimesheet = true;
                Record("Starting Task", false);
            }
        }

        public void FinalizeTimesheet(Task<string> task)
        {
            try
            {
                if (task.Result != null && task.Result.Length > 0)
                {
                    string decoded = System.Web.Helpers.Json.Decode<string>(task.Result);
                    timesheet = decoded;
                    gettingTimesheet = false;
                    if (!gettingEmployeeInfo)
                        GenerateLocalDocument($"{empInfo}{Environment.NewLine}{timesheet}");
                }
                else
                {
                    LongOutput("Decoded JSON was blank.");
                }
            }
            catch { LongOutput("Error caught decoding JSON."); }
        }

        public void FinalizeEmployeeInfo(Task<string> task)
        {
            try
            {
                if (task.Result != null && task.Result.Length > 0)
                {
                    string decoded = System.Web.Helpers.Json.Decode<string>(task.Result);
                    empInfo = decoded;
                    gettingEmployeeInfo = false;
                    if (!gettingTimesheet)
                        GenerateLocalDocument($"{empInfo}{Environment.NewLine}{timesheet}");
                }
                else
                {
                    LongOutput("Decoded JSON was blank.");
                }
            }
            catch { LongOutput("Error caught decoding JSON."); }
        }

        public void GenerateLocalDocument(string htmlText)
        {
            try
            {
                Record("Generating File");
                Stream fileStream = File.Create(HTMLFileLocation());
                StreamWriter writer = new StreamWriter(fileStream);
                writer.AutoFlush = true;
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("<!DOCTYPE html>");
                builder.AppendLine("<html lang=\"en\">");
                builder.AppendLine("<head>");
                builder.AppendLine("    <meta charset=\"UTF - 8\">");
                builder.AppendLine("    <meta http-equiv=\"X - UA - Compatible\" content=\"IE = edge\">");
                builder.AppendLine("    <meta name=\"viewport\" content=\"width = device - width, initial - scale = 1.0\">");
                builder.AppendLine("    <title>Document</title>");
                builder.AppendLine("</head>");
                builder.AppendLine("<body>");
                builder.AppendLine(htmlText);
                builder.AppendLine("</body>");
                builder.AppendLine("</html>");
                writer.Write(builder.ToString());
                writer.Close();
                NavigateSubBrowser(String.Format("file:///{0}/temp.html", Directory.GetCurrentDirectory()));
                empInfo = "";
                timesheet = "";
                Record("Generating File", false);
            }
            catch { Output("Error getting days"); }
        }

        public void NavigateSubBrowser(string url)
        {
            if (webBrowser1.InvokeRequired)
            {
                Action safeNav = delegate { NavigateSubBrowser(url); };
                webBrowser1.Invoke(safeNav);
            }
            else
            {
                webBrowser1.Url = new Uri(url);
            }
        }

        public void ReadDocument(HtmlDocument document)
        {
            try
            {
                Record("Reading Document");
                HtmlElement timesheetElement = document.GetElementById("tbltimesheet");
                if (timesheetElement != null)
                {
                    HtmlElementCollection rows = timesheetElement.Children[1].Children;

                    string name = "";

                    if (!GetName(document, ref name)) return;

                    DateTime day = DateTime.Now;

                    double hours = 0;

                    for (int i = 0; i < rows.Count; i++)
                    {
                        try
                        {
                            if (GetDate(document, i, ref day) && GetHours(document, i, ref hours) && hours > 0.0)
                            {
                                EmployeeDay employeeDay = new EmployeeDay { day = day, hours = hours, name = name };
                                AddDay(employeeDay);
                                hours = 0;
                            }
                        }
                        catch { }
                    }
                }
                Record("Reading Document", false);
            }
            catch
            {
                Output("Unable to get information! This may not be the correct page.");
                Record("Reading Document", false);
            }
            SetReadStatus(ReadStatus.Read);
            readingPage = false;
        }

        public bool GetName(HtmlDocument document, ref string name)
        {
            try
            {
                name = document.GetElementById("empInfo").Children[1].Children[1].Children[0].Children[0].Children[0].Children[0].InnerText;
                if (Properties.Settings.Default.NormalizedNames)
                {
                    int index = name.IndexOf("(");
                    if (index > 0)
                    {
                        name = name.Substring(0, index).Trim();
                    }
                }
                return true;
            }
            catch { Output("Unable to find employee name! This may not be the correct page."); }
            return false;
        }

        public bool GetDate(HtmlDocument document, int day, ref DateTime date)
        {
            try
            {
                string dateString = document.GetElementById("tbltimesheet").Children[1].Children[day].Children[0].InnerText;
                if (dateString == null) return false;
                int index = dateString.IndexOf("(") + 1;
                dateString = dateString.Substring(index);
                index = dateString.IndexOf(")");
                dateString = dateString.Substring(0, index);
                string[] dateArray = dateString.Split('/');
                date = new DateTime(DateTime.Now.Year, int.Parse(dateArray[0]), int.Parse(dateArray[1]));
                return true;
            }
            catch { }
            return false;
        }

        public bool GetHours(HtmlDocument document, int day, ref double hours)
        {
            try
            {
                hours = double.Parse(document.GetElementById("tbltimesheet").Children[1].Children[day].Children[8].Children[0].Children[0].InnerText);
                return true;
            }
            catch { }
            return false;
        }

        public void AddDay(EmployeeDay day)
        {
            if (!employeeTotalList.ContainsKey(day.name))
                employeeTotalList[day.name] = new EmployeeTotal();

            if (!loading)
            {
                if (!employeeTotalList[day.name].employeeDays.ContainsKey(day.day))
                {
                    Output($"Added record for {day.name} with {day.hours} hours on {day.day.Month}/{day.day.Day}");
                }
                else
                {
                    Output($"Updated record for {day.name} with {day.hours} hours on {day.day.Month}/{day.day.Day}");
                }
            }
            employeeTotalList[day.name].employeeDays[day.day] = new EmployeeDay(day);
        }

        public string HTMLFileLocation()
        {
            string location = Application.ExecutablePath;
            int index = location.LastIndexOf(Path.DirectorySeparatorChar);
            location = location.Substring(0, index);
            return Path.Combine(location, "temp.html");
        }

        public void SetReadStatus(ReadStatus status)
        {
            readStatus = status;
            panelNavigation.BackColor = StatusColor();
        }

        //Calculator tab

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CalculateCurrentDate();
        }

        public void CalculateDate(DateTime dateTime)
        {
            DateTime key = RoundTime(dateTime);

            SortedList<string, EmployeeDay> currentDay = new SortedList<string, EmployeeDay>();

            double totalHours = 0, percentage, allottedTips = 0, tips = (double)numericUpDownTips.Value, remainder = 0;

            foreach (KeyValuePair<string, EmployeeTotal> kvpA in employeeTotalList)
            {
                if (kvpA.Value.employeeDays.ContainsKey(key) && !blacklistedEmployees.Contains(kvpA.Key))
                {
                    currentDay[kvpA.Key] = new EmployeeDay(kvpA.Value.employeeDays[key]);
                    totalHours += currentDay[kvpA.Key].hours;
                }
            }

            dataGridView1.Rows.Clear();

            foreach (KeyValuePair<string, EmployeeDay> kvpA in currentDay)
            {
                percentage = kvpA.Value.hours / totalHours;
                kvpA.Value.calculatedTips = percentage * tips;
                remainder += kvpA.Value.calculatedTips - RoundMoney(kvpA.Value.calculatedTips);
                kvpA.Value.calculatedTips = RoundMoney(kvpA.Value.calculatedTips);
                allottedTips += kvpA.Value.calculatedTips;
            }

            if (allottedTips < tips)
            {
                string highestEmployee = "";
                double highestHours = 0;
                foreach (KeyValuePair<string, EmployeeDay> kvpA in currentDay)
                {
                    if (kvpA.Value.hours > highestHours)
                    {
                        highestEmployee = kvpA.Key;
                        highestHours = kvpA.Value.hours;
                    }
                }
                if (highestEmployee.Length > 0)
                {
                    currentDay[highestEmployee].calculatedTips += remainder;
                    allottedTips += remainder;
                }
            }

            foreach (KeyValuePair<string, EmployeeDay> kvpA in currentDay)
            {
                percentage = kvpA.Value.hours / totalHours;
                dataGridView1.Rows.Add(new string[] { kvpA.Key, kvpA.Value.hours.ToString("N4"), $"{(percentage * 100.0).ToString("N4")}%", $"${kvpA.Value.calculatedTips}" });
            }

            labelHourTotal.Text = $"Total Hours: {totalHours.ToString("N4")}";
            labelTotalTips.Text = $"Total Tips: ${allottedTips.ToString("N2")}";
        }

        private void numericUpDownTips_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownTips.Value > 0m)
            {
                dailyTipValues[RoundTime(dateTimePicker1.Value)] = (double)numericUpDownTips.Value;
                if (!loading)
                    CalculateCurrentDate();
            }
        }

        public void CalculateCurrentDate()
        {
            loading = true;
            DateTime key = RoundTime(dateTimePicker1.Value);
            if (dailyTipValues.ContainsKey(key))
                numericUpDownTips.Value = (decimal)dailyTipValues[key];
            else
                numericUpDownTips.Value = 0;
            loading = false;

            CalculateDate(dateTimePicker1.Value);
        }

        public void RemoveDay(EmployeeDay day)
        {
            if (employeeTotalList.ContainsKey(day.name) && employeeTotalList[day.name].employeeDays.ContainsKey(day.day))
            {
                employeeTotalList[day.name].employeeDays.Remove(day.day);
                if (employeeTotalList[day.name].employeeDays.Count == 0)
                    employeeTotalList.Remove(day.name);
            }
        }

        private void removeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DateTime key;
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    key = RoundTime(dateTimePicker1.Value);
                    RemoveDay(new EmployeeDay() { name = dataGridView1.SelectedRows[i].Cells[0].Value.ToString(), day = key });
                }
                CalculateCurrentDate();
            }
        }

        //Employee list tab

        private void listBoxEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectionOK(listBoxEmployees))
            {
                listBoxEmployeeDays.Items.Clear();
                string key = listBoxEmployees.SelectedItem.ToString();
                checkBoxWhiteListedTips.Checked = !blacklistedEmployees.Contains(key);
                if (employeeTotalList.ContainsKey(key))
                {
                    foreach (KeyValuePair<DateTime, EmployeeDay> kvpA in employeeTotalList[key].employeeDays)
                    {
                        listBoxEmployeeDays.Items.Add($"{kvpA.Key.Month}/{kvpA.Key.Day}");
                    }
                }
            }
        }

        public void RefreshEmployeeList()
        {
            listBoxEmployees.Items.Clear();
            listBoxEmployeeDays.Items.Clear();
            labelEmployeeHours.Text = "Hours:";
            loading = true;
            checkBoxWhiteListedTips.Checked = false;
            loading = false;
            foreach (KeyValuePair<string, EmployeeTotal> kvpA in employeeTotalList)
            {
                listBoxEmployees.Items.Add(kvpA.Key);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (SelectionOK(listBoxEmployees))
            {
                try
                {
                    employeeTotalList.Remove(listBoxEmployees.SelectedItem.ToString());
                    listBoxEmployees.Items.RemoveAt(listBoxEmployees.SelectedIndex);
                }
                catch { }
            }
        }

        public bool SelectionOK(ListBox listBox)
        {
            return listBox.SelectedItem != null && listBox.SelectedItems.Count == 1;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (SelectionOK(listBoxEmployeeDays) && SelectionOK(listBoxEmployees))
            {
                string[] args = listBoxEmployeeDays.SelectedItem.ToString().Split('/');
                DateTime timeKey = new DateTime(DateTime.Now.Year, int.Parse(args[0]), int.Parse(args[1]));
                string nameKey = listBoxEmployees.SelectedItem.ToString();
                if (employeeTotalList.ContainsKey(nameKey) && employeeTotalList[nameKey].employeeDays.ContainsKey(timeKey))
                {
                    employeeTotalList[nameKey].employeeDays.Remove(timeKey);
                    listBoxEmployeeDays.Items.RemoveAt(listBoxEmployeeDays.SelectedIndex);
                    if (employeeTotalList[nameKey].employeeDays.Count == 0)
                    {
                        employeeTotalList.Remove(nameKey);
                        listBoxEmployees.Items.RemoveAt(listBoxEmployees.SelectedIndex);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (SelectionOK(listBoxEmployeeDays) && SelectionOK(listBoxEmployees))
            {
                string[] args = listBoxEmployeeDays.SelectedItem.ToString().Split('/');
                DateTime timeKey = new DateTime(DateTime.Now.Year, int.Parse(args[0]), int.Parse(args[1]));
                dateTimePicker1.Value = timeKey;
                tabControl1.SelectedIndex = 1;
            }
        }

        private void listBoxEmployeeDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectionOK(listBoxEmployees) && SelectionOK(listBoxEmployeeDays))
            {
                string[] args = listBoxEmployeeDays.SelectedItem.ToString().Split('/');
                DateTime timeKey = new DateTime(DateTime.Now.Year, int.Parse(args[0]), int.Parse(args[1]));
                string nameKey = listBoxEmployees.SelectedItem.ToString();
                if (employeeTotalList.ContainsKey(nameKey) && employeeTotalList[nameKey].employeeDays.ContainsKey(timeKey))
                {
                    labelEmployeeHours.Text = $"Hours: {employeeTotalList[nameKey].employeeDays[timeKey].hours.ToString("N4")}";
                }
            }
        }

        private void checkBoxWhiteListedTips_CheckedChanged(object sender, EventArgs e)
        {
            if (!loading && SelectionOK(listBoxEmployees))
            {
                string nameKey = listBoxEmployees.SelectedItem.ToString();
                if (checkBoxWhiteListedTips.Checked)
                {
                    blacklistedEmployees.Remove(nameKey);
                }
                else if (!blacklistedEmployees.Contains(nameKey))
                {
                    blacklistedEmployees.Add(nameKey);
                }
            }
        }

        //Days list tab

        public void RefreshDayList()
        {
            SortedList<DateTime, int> employeeDays = new SortedList<DateTime, int>();
            foreach (KeyValuePair<string, EmployeeTotal> kvpA in employeeTotalList)
            {
                foreach (KeyValuePair<DateTime, EmployeeDay> kvpB in kvpA.Value.employeeDays)
                {
                    if (!employeeDays.ContainsKey(kvpB.Key))
                        employeeDays[kvpB.Key] = 0;
                }
            }
            listBoxDays.Items.Clear();
            listBoxDaysEmployees.Items.Clear();
            labelDailyHours.Text = "Hours:";
            labelDailyTips.Text = "Tips:";

            foreach (KeyValuePair<DateTime, int> kvpA in employeeDays)
            {
                listBoxDays.Items.Add($"{kvpA.Key.Month}/{kvpA.Key.Day}");
            }
        }

        public DateTime ConvertLine(string line)
        {
            string[] array = line.Split('/');
            return new DateTime(DateTime.Now.Year, int.Parse(array[0]), int.Parse(array[1]));
        }

        private void buttonRemoveDay_Click(object sender, EventArgs e)
        {
            if (listBoxDays.SelectedItem != null && listBoxDays.SelectedItems.Count == 1)
            {
                RemoveDay(ConvertLine(listBoxDays.SelectedItem.ToString()));
                listBoxDays.Items.RemoveAt(listBoxDays.SelectedIndex);
            }
        }

        public void RemoveDay(DateTime time)
        {
            List<string> removedEmployees = new List<string>();
            foreach (KeyValuePair<string, EmployeeTotal> kvpA in employeeTotalList)
            {
                if (kvpA.Value.employeeDays.ContainsKey(time))
                {
                    kvpA.Value.employeeDays.Remove(time);
                    if (kvpA.Value.employeeDays.Count == 0)
                        removedEmployees.Add(kvpA.Key);
                }
            }
            foreach (string key in removedEmployees)
            {
                employeeTotalList.Remove(key);
            }
        }

        private void buttonRemoveDayEmployee_Click(object sender, EventArgs e)
        {
            if (SelectionOK(listBoxDaysEmployees) && SelectionOK(listBoxDays))
            {
                string[] args = listBoxDays.SelectedItem.ToString().Split('/');
                DateTime timeKey = new DateTime(DateTime.Now.Year, int.Parse(args[0]), int.Parse(args[1]));
                string nameKey = listBoxDaysEmployees.SelectedItem.ToString();
                if (employeeTotalList.ContainsKey(nameKey) && employeeTotalList[nameKey].employeeDays.ContainsKey(timeKey))
                {
                    employeeTotalList[nameKey].employeeDays.Remove(timeKey);
                    listBoxDaysEmployees.Items.RemoveAt(listBoxDaysEmployees.SelectedIndex);
                    if (employeeTotalList[nameKey].employeeDays.Count == 0)
                    {
                        employeeTotalList.Remove(nameKey);
                    }
                    if (listBoxDaysEmployees.Items.Count == 0)
                    {
                        listBoxDays.Items.RemoveAt(listBoxDays.SelectedIndex);
                    }
                }
            }
        }

        private void listBoxDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxDaysEmployees.Items.Clear();
            if (SelectionOK(listBoxDays))
            {
                string[] args = listBoxDays.SelectedItem.ToString().Split('/');
                double totalHours = 0;
                DateTime timeKey = new DateTime(DateTime.Now.Year, int.Parse(args[0]), int.Parse(args[1]));
                foreach (KeyValuePair<string, EmployeeTotal> kvpA in employeeTotalList)
                {
                    if (kvpA.Value.employeeDays.ContainsKey(timeKey))
                    {
                        listBoxDaysEmployees.Items.Add(kvpA.Key);
                        if (!blacklistedEmployees.Contains(kvpA.Key))
                            totalHours += kvpA.Value.employeeDays[timeKey].hours;
                    }
                }
                if (dailyTipValues.ContainsKey(timeKey))
                    labelDailyTips.Text = $"Tips: ${dailyTipValues[timeKey].ToString("N2")}";
                else
                    labelDailyTips.Text = "Tips: $0.00";

                labelDailyHours.Text = $"Hours: {totalHours.ToString("N4")}";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (SelectionOK(listBoxDays))
            {
                string[] args = listBoxDays.SelectedItem.ToString().Split('/');
                DateTime timeKey = new DateTime(DateTime.Now.Year, int.Parse(args[0]), int.Parse(args[1]));
                dateTimePicker1.Value = timeKey;
                tabControl1.SelectedIndex = 1;
            }
        }

        //Settings tab

        private void textBoxHomepage_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                Properties.Settings.Default.HomepageURL = textBoxHomepage.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            employeeTotalList.Clear();
            dailyTipValues.Clear();
            blacklistedEmployees.Clear();
        }

        private void checkBoxNormalizedNames_CheckedChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                Properties.Settings.Default.NormalizedNames = checkBoxNormalizedNames.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (debugForm == null)
            {
                debugForm = new DebugForm();
                debugForm.parent = this;
                debugForm.FormClosed += DebugFormClosed;
                debugForm.Show();
            }
            else debugForm.Show();
        }

        private void DebugFormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                debugForm = null;
            }
            catch { }
        }

        //Classes

        public class EmployeeDay
        {
            public string name = "";
            public DateTime day = new DateTime(1, 1, 1);
            public double hours = 0, calculatedTips = 0;

            public EmployeeDay()
            {

            }

            public EmployeeDay(EmployeeDay origDay)
            {
                name = origDay.name;
                day = origDay.day;
                hours = origDay.hours;
            }

            public EmployeeDay(string str)
            {
                string[] array = str.Split('♠');
                name = array[0];
                hours = double.Parse(array[1]);
                day = new DateTime(DateTime.Now.Year, int.Parse(array[2]), int.Parse(array[3]));
            }

            public override string ToString()
            {
                return $"{name}♠{hours}♠{day.Month}♠{day.Day}";
            }
        }

        public class EmployeeTotal
        {
            public SortedList<DateTime, EmployeeDay> employeeDays = new SortedList<DateTime, EmployeeDay>();
        }
    }
}
