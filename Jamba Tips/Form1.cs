using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Jamba_Tips
{
    public partial class Form1 : Form
    {
        #region Variables

        public SortedList<string, EmployeeTotal> employeeTotalList = new SortedList<string, EmployeeTotal>();

        public SortedList<DateTime, SortedList<int, decimal>> dailyTipValues = new SortedList<DateTime, SortedList<int, decimal>>();

        public HashSet<string> filters = new HashSet<string>(), blacklistedEmployees = new HashSet<string>();

        public bool loading = false, normalizeNames;

        public DebugForm debugForm;

        public DataFilterForm dataFilterForm;

        public SortedList<string, Stopwatch> timerList = new SortedList<string, Stopwatch>();

        public List<ColorScheme> colorSchemes = new List<ColorScheme>();

        public string[] monthsInYear = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public string lastClipBoard = "", currentCellString = "", currentScheme = "Black & Gold";

        public decimal currentCellDecimal = 0m;

        public CurrentCellType currentCellType = CurrentCellType.None;

        public Dictionary<DateTime, List<string>> flaggedDays= new Dictionary<DateTime, List<string>>();

        public enum CurrentCellType
        {
            Name,
            Hours,
            None
        };

        public enum ExtractionStatus
        {
            Success,
            Failure,
            Filtered
        };

        #endregion


        #region Initialization

        public Form1()
        {
            InitializeComponent();
            filters.Add("sick");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loading = true;
            labelVersion.Text = $"Version: {Assembly.GetExecutingAssembly().GetName().Version}";
            LoadColorSchemes();

            LoadData2();

            comboBoxColorSchemes.Text = currentScheme;

            if (employeeTotalList.Count > 0)
                Output($"Loaded employees: {employeeTotalList.Count}");
            if (dailyTipValues.Count > 0)
                Output($"Loaded tips: {dailyTipValues.Count}");
            if (blacklistedEmployees.Count > 0)
                Output($"Employees excluded from tips: {blacklistedEmployees.Count}");

            SetAutoFill();

            if (checkBoxClipboardMonitor.Checked && Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();
                if (clipboardText != String.Empty && !CompareStrings(clipboardText, lastClipBoard))
                    lastClipBoard = clipboardText;
            }

            loading = false;
        }

        private void LoadColorSchemes()
        {
            colorSchemes.Add(new ColorScheme("Black & Gold",
                System.Drawing.Color.FromArgb(255, 0, 0, 0),
                System.Drawing.Color.FromArgb(255, 0, 0, 0),
                System.Drawing.Color.FromArgb(255, 0, 0, 0),
                System.Drawing.Color.FromArgb(255, 255, 215, 0)));

            colorSchemes.Add(new ColorScheme("Autumn 1",
                System.Drawing.ColorTranslator.FromHtml("#3F0D12"),
                System.Drawing.ColorTranslator.FromHtml("#A71D31"),
                System.Drawing.ColorTranslator.FromHtml("#51291E"),
                System.Drawing.ColorTranslator.FromHtml("#D5BF86")));

            colorSchemes.Add(new ColorScheme("Fruity",
                System.Drawing.ColorTranslator.FromHtml("#23F0C7"),
                System.Drawing.ColorTranslator.FromHtml("#EF767A"),
                System.Drawing.ColorTranslator.FromHtml("#BE5A38"),
                System.Drawing.ColorTranslator.FromHtml("#6457A6")));

            colorSchemes.Add(new ColorScheme("Night-time Forest",
                System.Drawing.ColorTranslator.FromHtml("#2E6171"),
                System.Drawing.ColorTranslator.FromHtml("#556F7A"),
                System.Drawing.ColorTranslator.FromHtml("#815E5B"),
                System.Drawing.ColorTranslator.FromHtml("#B79FAD")));

            colorSchemes.Add(new ColorScheme("Light Pumpkin",
                System.Drawing.ColorTranslator.FromHtml("#FA9F42"),
                System.Drawing.ColorTranslator.FromHtml("#ACE4AA"),
                System.Drawing.ColorTranslator.FromHtml("#840032"),
                System.Drawing.ColorTranslator.FromHtml("#02040F")));

            colorSchemes.Add(new ColorScheme("Clear Sky",
                System.Drawing.ColorTranslator.FromHtml("#119DA4"),
                System.Drawing.ColorTranslator.FromHtml("#0C7489"),
                System.Drawing.ColorTranslator.FromHtml("#06BCC1"),
                System.Drawing.ColorTranslator.FromHtml("#040404")));

            colorSchemes.Add(new ColorScheme("Space",
                System.Drawing.ColorTranslator.FromHtml("#0F1108"),
                System.Drawing.ColorTranslator.FromHtml("#241909"),
                System.Drawing.ColorTranslator.FromHtml("#262626"),
                System.Drawing.ColorTranslator.FromHtml("#CAD8DE")));

            colorSchemes.Add(new ColorScheme("Warm",
                System.Drawing.ColorTranslator.FromHtml("#3A3335"),
                System.Drawing.ColorTranslator.FromHtml("#D81E5B"),
                System.Drawing.ColorTranslator.FromHtml("#F0544F"),
                System.Drawing.ColorTranslator.FromHtml("#FDF0D5")));

            colorSchemes.Add(new ColorScheme("Moonrise",
                System.Drawing.ColorTranslator.FromHtml("#0F1108"),
                System.Drawing.ColorTranslator.FromHtml("#9882AC"),
                System.Drawing.ColorTranslator.FromHtml("#73648A"),
                System.Drawing.ColorTranslator.FromHtml("#CAD8DE")));

            colorSchemes.Add(new ColorScheme("Summer 1",
                System.Drawing.ColorTranslator.FromHtml("#C84630"),
                System.Drawing.ColorTranslator.FromHtml("#235789"),
                System.Drawing.ColorTranslator.FromHtml("#C1292E"),
                System.Drawing.ColorTranslator.FromHtml("#F1D302")));

            colorSchemes.Add(new ColorScheme("Garden",
                System.Drawing.ColorTranslator.FromHtml("#363537"),
                System.Drawing.ColorTranslator.FromHtml("#EF2D56"),
                System.Drawing.ColorTranslator.FromHtml("#302F4D"),
                System.Drawing.ColorTranslator.FromHtml("#8CD867")));

            colorSchemes.Add(new ColorScheme("Dusk",
                System.Drawing.ColorTranslator.FromHtml("#484A47"),
                System.Drawing.ColorTranslator.FromHtml("#5C6D70"),
                System.Drawing.ColorTranslator.FromHtml("#A37774"),
                System.Drawing.ColorTranslator.FromHtml("#E88873")));

            colorSchemes.Add(new ColorScheme("Creekside",
                System.Drawing.ColorTranslator.FromHtml("#1A281F"),
                System.Drawing.ColorTranslator.FromHtml("#635255"),
                System.Drawing.ColorTranslator.FromHtml("#CE7B91"),
                System.Drawing.ColorTranslator.FromHtml("#C0E8F9")));

            colorSchemes.Add(new ColorScheme("Sweet",
                System.Drawing.ColorTranslator.FromHtml("#26547C"),
                System.Drawing.ColorTranslator.FromHtml("#EF476F"),
                System.Drawing.ColorTranslator.FromHtml("#401F3E"),
                System.Drawing.ColorTranslator.FromHtml("#EDF4ED")));

            colorSchemes.Add(new ColorScheme("Desert Oasis",
                System.Drawing.ColorTranslator.FromHtml("#0A210F"),
                System.Drawing.ColorTranslator.FromHtml("#14591D"),
                System.Drawing.ColorTranslator.FromHtml("#99AA38"),
                System.Drawing.ColorTranslator.FromHtml("#E1E289")));

            colorSchemes.Add(new ColorScheme("Earth & Stone",
                System.Drawing.ColorTranslator.FromHtml("#463F3A"),
                System.Drawing.ColorTranslator.FromHtml("#8A817C"),
                System.Drawing.ColorTranslator.FromHtml("#BCB8B1"),
                System.Drawing.ColorTranslator.FromHtml("#F4F3EE")));

            colorSchemes.Add(new ColorScheme("Evening Lights",
                System.Drawing.ColorTranslator.FromHtml("#0E1116"),
                System.Drawing.ColorTranslator.FromHtml("#374A67"),
                System.Drawing.ColorTranslator.FromHtml("#595758"),
                System.Drawing.ColorTranslator.FromHtml("#9E7B9B")));


            foreach (ColorScheme colorScheme in colorSchemes)
            {
                comboBoxColorSchemes.Items.Add(colorScheme.name);
            }
        }

        #endregion


        #region Main Functions

        public void SaveData2()
        {
            Record("Saving Data");

            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Color Scheme={currentScheme}");
            builder.AppendLine($"Normalized Names={normalizeNames}");
            builder.Append("Filters=");
            int filterCount = 0, blackListCount = 0;
            foreach (string filter in filters)
            {
                builder.Append($"{(filterCount > 0 ? "‡" : "")}{filter}");
                filterCount++;
            }
            builder.AppendLine();

            foreach (KeyValuePair<string, EmployeeTotal> kvpA in employeeTotalList)
            {
                foreach (KeyValuePair<DateTime, EmployeeDay> kvpB in kvpA.Value.employeeDays)
                {
                    builder.AppendLine($"Employee Day={kvpB.Value.ToString()}");
                }
            }

            foreach (KeyValuePair<DateTime, SortedList<int, decimal>> kvpA in dailyTipValues)
            {
                foreach (KeyValuePair<int, decimal> kvpB in kvpA.Value)
                    builder.AppendLine($"Tips={kvpB.Value}♠{kvpA.Key.Month}♠{kvpA.Key.Day}♠{kvpB.Key}");
            }

            builder.Append("Blacklist=");
            foreach (string str in blacklistedEmployees)
            {
                builder.Append($"{(blackListCount > 0 ? "‡" : "")}{str}");
                blackListCount++;
            }
            builder.AppendLine();

            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "Jamba.Tips.data"), builder.ToString().TrimEnd());
        }

        public void LoadData2()
        {
            Record("Loading Data");
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Jamba.Tips.data");
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                while (!reader.EndOfStream)
                {
                    LoadLine(reader.ReadLine().Trim());
                }
                reader.Close();
            }
            //Backwards compatible settings
            foreach (string str in Properties.Settings.Default.EmployeeDays)
            {
                AddDay(new EmployeeDay(str));
            }

            string[] args;
            DateTime key;
            int dayKey;
            //Backwards compatible settings
            foreach (string str in Properties.Settings.Default.DailyTips)
            {
                args = str.Split('♠');
                key = new DateTime(DateTime.Now.Year, int.Parse(args[1]), int.Parse(args[2]));
                if (args.Length < 4 || args[3].Length == 0 || !int.TryParse(args[3], out dayKey))
                    dayKey = 7;
                if (!dailyTipValues.ContainsKey(key))
                    dailyTipValues[key] = new SortedList<int, decimal>();
                dailyTipValues[key][dayKey] = decimal.Parse(args[0]);
            }
            Record("Loading Data", false);
        }

        public void LoadLine(string text)
        {
            string key, data;
            int index = text.IndexOf("=");
            if (index <= 0) return;
            key = text.Substring(0, index);
            data = text.Substring(index + 1);
            bool dataBoolean = String.Compare(data, "true", true) == 0;

            switch (key)
            {
                case "Employee Day":
                    AddDay(new EmployeeDay(data));
                    break;
                case "Tips":
                    AddTip(data);
                    break;
                case "Blacklist":
                    string[] blackListArray = data.Split(new char[] { '‡' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < blackListArray.Length; i++)
                        if (blackListArray[i].Length > 0)
                            blacklistedEmployees.Add(blackListArray[i]);
                    break;
                case "Normalized Names":
                    normalizeNames = dataBoolean;
                    checkBoxNormalizedNames.Checked = normalizeNames;
                    break;
                case "Color Scheme":
                    PaintThisApplication(data);
                    break;
                case "Filters":
                    string[] filterArray = data.Split(new char[] { '‡' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < filterArray.Length; i++)
                        if (filterArray[i].Length > 0)
                            filters.Add(filterArray[i].ToLower());
                    break;
            }
        }

        public void AddTip(string text)
        {
            string[] args;
            DateTime key;
            int dayKey;
            args = text.Split('♠');
            key = new DateTime(DateTime.Now.Year, int.Parse(args[1]), int.Parse(args[2]));
            if (args.Length < 4 || args[3].Length == 0 || !int.TryParse(args[3], out dayKey))
                dayKey = 7;
            if (!dailyTipValues.ContainsKey(key))
                dailyTipValues[key] = new SortedList<int, decimal>();
            dailyTipValues[key][dayKey] = decimal.Parse(args[0]);
        }

        public decimal RoundMoney(decimal value)
        {
            return Math.Floor(value * 100.0m) / 100.0m;
        }

        public DateTime RoundTime(DateTime time)
        {
            return new DateTime(DateTime.Now.Year, time.Month, time.Day);
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

        public bool CompareStrings(string a, string b)
        {
            return a.Length == b.Length && String.Compare(a, b) == 0;
        }

        public void StartAutosave()
        {
            timerAutoSave.Stop();
            timerAutoSave.Start();
        }

        public static void PaintControl(Control control, ColorScheme scheme)
        {
            control.ForeColor = scheme.h4;

            if ((control is Panel && !(control is TabControl) && !(control is TabPage)) || control is ListBox || control is ComboBox || control is TextBox || control is RichTextBox)
            {
                control.BackColor = scheme.h1;
            }
            if (control is DataGridView)
            {
                DataGridView dgv = (DataGridView)control;
                dgv.BackgroundColor = scheme.h1;
                dgv.DefaultCellStyle.BackColor = scheme.h1;
                dgv.DefaultCellStyle.ForeColor = scheme.h4;
                dgv.RowHeadersDefaultCellStyle.BackColor = scheme.h1;
                dgv.RowHeadersDefaultCellStyle.ForeColor = scheme.h4;
                dgv.RowsDefaultCellStyle.BackColor = scheme.h1;
                dgv.RowsDefaultCellStyle.ForeColor = scheme.h4;
                dgv.AlternatingRowsDefaultCellStyle.BackColor = scheme.h1;
                dgv.AlternatingRowsDefaultCellStyle.ForeColor = scheme.h4;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = scheme.h1;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = scheme.h4;
            }
            if (control is TableLayoutPanel)
            {
                control.BackColor = scheme.h3;
            }
            if (control is TabControl)
            {
                control.BackColor = scheme.h2;
                foreach (TabPage tabPage in ((TabControl)control).TabPages)
                {
                    tabPage.BackColor = scheme.h2;
                    tabPage.ForeColor = scheme.h4;
                }
            }
            foreach (Control child in control.Controls)
            {
                PaintControl(child, scheme);
            }
        }

        public void PaintThisApplication(string schemeName)
        {
            ColorScheme scheme;
            if (!CompareStrings(schemeName, currentScheme) && GetColorScheme(schemeName, out scheme))
            {
                currentScheme = schemeName;
                StartAutosave();
                PaintApplication(this, scheme);
            }
        }

        public static void PaintApplication(Form form, ColorScheme scheme)
        {
            form.BackColor = scheme.h1;
            form.ForeColor = scheme.h4;
            foreach (Control control in form.Controls)
            {
                PaintControl(control, scheme);
            }
        }

        public bool GetColorScheme(string schemeName, out ColorScheme colorScheme)
        {
            foreach (ColorScheme scheme in colorSchemes)
                if (CompareStrings(scheme.name, schemeName))
                {
                    colorScheme = scheme;
                    return true;
                }
            colorScheme = new ColorScheme("", System.Drawing.Color.Black, System.Drawing.Color.Black,
                System.Drawing.Color.Black, System.Drawing.Color.Black);
            return false;
        }

        #endregion


        #region Form1 Controls

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Output("Saving before close...");
            SaveData2();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    SetAutoFill();
                    break;
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

        private void timerAutoSave_Tick(object sender, EventArgs e)
        {
            timerAutoSave.Stop();
            SaveData2();
        }

        #endregion


        #region Data Entry Tab

        private void timerClipboardMonitor_Tick(object sender, EventArgs e)
        {
            if (checkBoxClipboardMonitor.Checked && Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();
                if (clipboardText != String.Empty && !CompareStrings(clipboardText, lastClipBoard))
                {
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(Properties.Resources.collierhs_colinlib__elevator_ding);
                    snd.Play();
                    ParseStringData(clipboardText);
                    lastClipBoard = clipboardText;
                }
            }
        }

        public void ParseStringData(string text)
        {
            try
            {
                int index;
                string subString, name, weekA, weekB,
                    keyName = "Timecard Editor",
                    keyTimeCardStart = "Allocation  (tax)",
                    keyTimeCardEnd = "Approve By Date";
                string[] lineArray;
                bool filteredDay = false;
                List<string> rowList = new List<string>();

                //Get name
                index = text.IndexOf(keyName);
                subString = text.Substring(index);
                lineArray = subString.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                name = normalizeNames ? NormalizeName(lineArray[1]) : lineArray[1];
                LongOutput($"Name from clipboard: {name}");

                //Get timecard
                index = text.IndexOf(keyTimeCardStart);
                subString = text.Substring(index);
                index = text.IndexOf("MON (");
                subString = text.Substring(index);
                index = subString.IndexOf(keyTimeCardEnd);
                subString = subString.Substring(0, index);

                index = subString.LastIndexOf("MON (");
                weekA = subString.Substring(0, index).Trim();
                weekB = subString.Substring(index).Trim();
                //LongOutput($"Week A: {weekA}");
                //LongOutput($"Week B: {weekB}");

                for (int i = 1; i <= 7; i++)
                {
                    if (ExtractDay(ref weekA, name) == ExtractionStatus.Filtered)
                        filteredDay = true;
                }
                for (int i = 1; i <= 7; i++)
                {
                    if (ExtractDay(ref weekB, name) == ExtractionStatus.Filtered)
                        filteredDay = true;
                }

                //Play sound if a day was filtered
                if (filteredDay)
                {
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(Properties.Resources.kizilsungur__sweetalertsound4);
                    snd.Play();
                }

                flaggedDays.Clear();
            }
            catch { LongOutput("Error caught parsing clipboard data. "); }
        }

        public ExtractionStatus ExtractDay(ref string text, string name)
        {
            try
            {
                LongOutput($"Extracting Day: {text}");
                string[] dayKeys = new string[] { "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN" },
                    lineArray;
                int index = text.IndexOf(dayKeys[0]), subIndex, dayIndex = 0;
                string currentLine, finalKey = "Weekly Totals";
                decimal parsedHours = 0m, bestHours = 0m;
                DateTime parsedDate;

                for (int i = 1; i < dayKeys.Length; i++)
                {
                    subIndex = text.IndexOf(dayKeys[i]);
                    if (index == -1 || (subIndex >= 0 && subIndex < index))
                    {
                        index = subIndex;
                        dayIndex = i;
                    }
                }

                text = text.Substring(index);

                dayIndex++;
                if (dayIndex >= dayKeys.Length)
                    dayIndex = 0;

                subIndex = text.IndexOf(dayKeys[dayIndex]);
                if (subIndex == -1)
                    subIndex = text.IndexOf(finalKey);

                currentLine = text.Substring(0, subIndex);
                text = text.Substring(subIndex);

                lineArray = currentLine.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder builder = new StringBuilder();
                if (lineArray.Length > 0)
                {
                    if (GetDate(lineArray[0], out parsedDate))
                    {
                        lineArray = lineArray[lineArray.Length - 1].Split('	');
                        for (int i = 0; i < lineArray.Length; i++)
                            builder.Append($"{(builder.Length > 0 ? ", " : "")}'{lineArray[i]}'");
                        for (int i = 0; i < lineArray.Length; i++)
                        {
                            if (IsFiltered(lineArray[i]))
                            {
                                if (!flaggedDays.ContainsKey(parsedDate))
                                    flaggedDays[parsedDate] = new List<string>();
                                flaggedDays[parsedDate].Add(name);
                                continue;
                            }
                            if (decimal.TryParse(lineArray[i], out parsedHours) && parsedHours > 0m)
                                bestHours = parsedHours;
                        }
                        if (bestHours > 0m)
                        {
                            if (!flaggedDays.ContainsKey(parsedDate) || !flaggedDays[parsedDate].Contains(name))
                            {
                                AddDay(new EmployeeDay() { name = name, day = parsedDate, hours = bestHours });
                                return ExtractionStatus.Success;
                            }
                            else
                            {
                                Output($"ALERT: Filtered Day For Employee '{name}' On {parsedDate.ToShortDateString()} With {bestHours.ToString("N2")} Hours");
                                return ExtractionStatus.Filtered;
                            }
                        }
                    }
                }
            }
            catch { }
            return ExtractionStatus.Failure;
        }

        public bool GetDate(string text, out DateTime date)
        {
            try
            {
                string subText = text;
                int index = subText.IndexOf("(");
                subText = subText.Substring(index + 1);
                index = subText.IndexOf(")");
                subText = subText.Substring(0, index);
                string[] args = subText.Split('/');
                date = RoundTime(new DateTime(DateTime.Now.Year, int.Parse(args[0]), int.Parse(args[1])));
                return true;
            }
            catch { }
            date = DateTime.Now;
            return false;
        }

        public string NormalizeName(string givenName)
        {
            string name = givenName;
            int index = name.IndexOf("(");
            if (index > 0)
            {
                name = name.Substring(0, index).Trim();
            }
            return name;
        }

        public void AddDay(EmployeeDay day)
        {
            if (IsNameReversed(day.name))
                day.name = ReverseName(day.name);

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
                StartAutosave();
            }
            employeeTotalList[day.name].employeeDays[day.day] = new EmployeeDay(day);
        }

        private void buttonAddEmployeeManual_Click(object sender, EventArgs e)
        {
            if (comboBoxEmployeeName.Text.Length > 0)
            {
                AddDay(new EmployeeDay { name = comboBoxEmployeeName.Text, day = RoundTime(dateTimePickerEmployeeManual.Value), hours = numericUpDownEmployeeTipsManual.Value });
                comboBoxEmployeeName.Text = "";
                SetAutoFill();
            }
        }

        public void SetAutoFill()
        {
            List<string> reversibleNames = new List<string>();
            reversibleNames.AddRange(employeeTotalList.Keys.ToArray());
            comboBoxEmployeeName.Items.Clear();
            comboBoxEmployeeName.Items.AddRange(reversibleNames.ToArray());
            for (int i = 0, m = reversibleNames.Count; i < m; i++)
                reversibleNames.Add(ReverseName(reversibleNames[i]));
            comboBoxEmployeeName.AutoCompleteCustomSource.Clear();
            comboBoxEmployeeName.AutoCompleteCustomSource.AddRange(reversibleNames.ToArray());
        }

        public bool IsNameReversed(string name)
        {
            return name.Contains(";") && name.EndsWith("*");
        }

        public string ReverseName(string name)
        {
            int index = name.IndexOf(",");
            string separator = ";";
            if (index < 0 && name.EndsWith("*"))
            {
                name = name.Substring(0, name.Length - 1);
                index = name.IndexOf(";");
                separator = ",";
            }
            if (index <= 0) return name;

            return $"{name.Substring(index + 1).Trim()}{separator} {name.Substring(0, index).Trim()}{(String.Compare(";", separator) == 0 ? "*" : "")}";
        }

        public bool IsFiltered(string data)
        {
            if (data.Length > 0)
            {
                string lowData = data.ToLower();
                foreach (string filter in filters)
                    if (lowData.Contains(filter))
                        return true;
            }
            return false;
        }

        public void SetNormalizedNames(bool normalized)
        {
            normalizeNames = normalized;
            loading = true;
            checkBoxNormalizedNames.Checked = normalizeNames;
            loading = false;
        }

        #endregion


        #region Calculator Tab

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CalculateCurrentDate();
        }

        private void checkBoxWholeNumbers_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCurrentDate();
        }

        public void BalanceTips(ref decimal allocatedTips, ref SortedList<string, EmployeeDay> currentDay, decimal desiredTips)
        {
            if (allocatedTips == desiredTips || currentDay.Count == 0)
                return;

            List<EmployeeDay> sortedDays = new List<EmployeeDay>();
            foreach (KeyValuePair<string, EmployeeDay> kvpA in currentDay)
                sortedDays.Add(new EmployeeDay(kvpA.Value));
            sortedDays = sortedDays.OrderByDescending(x => x.hours).ToList();

            int reps = 0;
            while (allocatedTips > desiredTips && reps < 5000)
            {
                for (int i = 0; i < sortedDays.Count && allocatedTips > desiredTips; i++)
                {
                    currentDay[sortedDays[i].name].calculatedTips -= 0.01m;
                    allocatedTips -= 0.01m;
                    reps++;
                }
            }
            reps = 0;
            while (allocatedTips < desiredTips && reps < 5000)
            {
                for (int i = 0; i < sortedDays.Count && allocatedTips < desiredTips; i++)
                {
                    currentDay[sortedDays[i].name].calculatedTips += 0.01m;
                    allocatedTips += 0.01m;
                    reps++;
                }
            }
        }

        public void CalculateDate(DateTime dateTime, TimeSpan timeSpanLength)
        {
            SortedList<string, EmployeeDay> currentDay = new SortedList<string, EmployeeDay>();
            Dictionary<string, string> employeeSubInfo = new Dictionary<string, string>();
            StringBuilder builder = new StringBuilder(), postBuilder = new StringBuilder();

            decimal totalHours = 0, percentage, allocatedTips = 0, tips = (decimal)numericUpDownTips.Value, remainder = 0;

            foreach (KeyValuePair<string, EmployeeTotal> kvpA in employeeTotalList)
            {
                for (int i = 0; i < timeSpanLength.Days; i++)
                {
                    DateTime key = RoundTime(dateTime.AddDays(i));
                    if (kvpA.Value.employeeDays.ContainsKey(key) && !blacklistedEmployees.Contains(kvpA.Key))
                    {
                        if (!currentDay.ContainsKey(kvpA.Key))
                            currentDay[kvpA.Key] = new EmployeeDay(kvpA.Value.employeeDays[key]);
                        else
                            currentDay[kvpA.Key].hours += kvpA.Value.employeeDays[key].hours;
                        totalHours += kvpA.Value.employeeDays[key].hours;
                        if (postBuilder.Length > 0)
                            postBuilder.Append(", ");
                        postBuilder.Append($"{key.Month}/{key.Day} {kvpA.Value.employeeDays[key].hours.ToString("N2")}");
                    }
                }
                employeeSubInfo[kvpA.Key] = postBuilder.ToString();
                postBuilder.Clear();
            }

            dataGridView1.Rows.Clear();

            if (currentDay.Count == 0) allocatedTips = tips;

            foreach (KeyValuePair<string, EmployeeDay> kvpA in currentDay)
            {
                percentage = kvpA.Value.hours / totalHours;
                kvpA.Value.calculatedTips = percentage * tips;
                remainder += kvpA.Value.calculatedTips - RoundMoney(kvpA.Value.calculatedTips);
                kvpA.Value.calculatedTips = RoundMoney(kvpA.Value.calculatedTips);
                allocatedTips += kvpA.Value.calculatedTips;
            }

            if (allocatedTips != tips)
            {
                if (allocatedTips < tips)
                {
                    LongOutput($"Allocated tips (${allocatedTips.ToString("N2")}) are below tips (${tips.ToString("N2")})");
                    LongOutput($"Allocating extra tips (${remainder.ToString("N2")})");
                }
                else if (allocatedTips > tips)
                {
                    LongOutput($"Allocated tips (${allocatedTips.ToString("N2")}) are above tips (${tips.ToString("N2")})");
                    LongOutput($"Removing extra tips (${remainder.ToString("N2")})");
                }
                BalanceTips(ref allocatedTips, ref currentDay, tips);
            }
            else
            {
                LongOutput($"Allocated tips (${allocatedTips.ToString("N2")}) are equal to given tips (${tips.ToString("N2")})");
            }

            if (checkBoxWholeNumbers.Checked && currentDay.Count > 0)
            {
                remainder = 0m;
                foreach (KeyValuePair<string, EmployeeDay> kvpA in currentDay)
                {
                    if (kvpA.Value.calculatedTips > Math.Floor(kvpA.Value.calculatedTips))
                    {
                        remainder += kvpA.Value.calculatedTips - Math.Floor(kvpA.Value.calculatedTips);
                        kvpA.Value.calculatedTips = Math.Floor(kvpA.Value.calculatedTips);
                    }
                }
                List<EmployeeDay> sortedDays = new List<EmployeeDay>();
                foreach (KeyValuePair<string, EmployeeDay> kvpA in currentDay)
                    sortedDays.Add(new EmployeeDay(kvpA.Value));
                sortedDays = sortedDays.OrderByDescending(x => x.hours).ToList();
                int reps = 0;
                while (remainder >= 1m && reps < 5000)
                {
                    for (int i = 0; i < sortedDays.Count && remainder >= 1m; i++)
                    {
                        currentDay[sortedDays[i].name].calculatedTips += 1m;
                        remainder -= 1m;
                        reps++;
                    }
                }
            }
            allocatedTips = 0m;
            foreach (KeyValuePair<string, EmployeeDay> kvpA in currentDay)
                allocatedTips += kvpA.Value.calculatedTips;

            builder.AppendLine($"Total Hours: {totalHours.ToString("N4").PadRight(12)}");
            builder.AppendLine($"Input Tips: {tips.ToString("N2").PadRight(12)}");
            builder.AppendLine($"Allocated Tips: {allocatedTips.ToString("N2").PadRight(12)}");
            builder.AppendLine($"Date Range: {dateTime.ToShortDateString()} - {dateTime.AddDays(timeSpanLength.Days - 1).ToShortDateString()}{Environment.NewLine}");

            foreach (KeyValuePair<string, EmployeeDay> kvpA in currentDay)
            {
                percentage = kvpA.Value.hours / totalHours;
                dataGridView1.Rows.Add(new string[] { kvpA.Key, kvpA.Value.hours.ToString("N4"), $"${kvpA.Value.calculatedTips:N2}" });
                builder.AppendLine($"{kvpA.Key.PadRight(35)} {kvpA.Value.hours.ToString("N4").PadRight(12)} ${kvpA.Value.calculatedTips:N2}");
                builder.AppendLine($"    {employeeSubInfo[kvpA.Key]}");
            }
            remainder = tips - allocatedTips;

            richTextBoxOutput.Text = builder.ToString().Trim();
            labelHourTotal.Text = $"Total Hours: {totalHours:N4}";
            labelTotalTips.Text = $"Counted Tips: ${allocatedTips:N2}{(remainder != 0m ? $", Remainder: ${remainder:N2}" : "")}";
        }

        private void numericUpDownTips_ValueChanged(object sender, EventArgs e)
        {
            DateTime key = RoundTime(dateTimePicker1.Value);
            if (numericUpDownTips.Value > 0m)
            {
                if (!dailyTipValues.ContainsKey(key))
                    dailyTipValues[key] = new SortedList<int, decimal>();
                dailyTipValues[key][(int)numericUpDownDays.Value] = (decimal)numericUpDownTips.Value;
                if (!loading)
                {
                    StartAutosave();
                    CalculateCurrentDate();
                }
            }
            else
            {
                if (dailyTipValues.ContainsKey(key) && dailyTipValues[key].ContainsKey((int)numericUpDownDays.Value))
                {
                    dailyTipValues[key].Remove((int)numericUpDownDays.Value);
                    if (dailyTipValues[key].Count == 0)
                        dailyTipValues.Remove(key);
                    StartAutosave();
                }
            }
        }

        public void CalculateCurrentDate()
        {
            loading = true;
            DateTime key = RoundTime(dateTimePicker1.Value), endRange;
            endRange = key.AddDays((int)numericUpDownDays.Value - 1);
            if (dailyTipValues.ContainsKey(key) && dailyTipValues[key].ContainsKey((int)numericUpDownDays.Value))
            {
                numericUpDownTips.Value = (decimal)dailyTipValues[key][(int)numericUpDownDays.Value];
            }
            else
                numericUpDownTips.Value = 0;
            labelDateRange.Text = $"Range: {endRange.DayOfWeek}, {monthsInYear[endRange.Month - 1]} {endRange.Day}, {endRange.Year}";

            loading = false;

            CalculateDate(dateTimePicker1.Value, TimeSpan.FromDays((int)numericUpDownDays.Value));

            //Set manual to single day only
            if (numericUpDownDays.Value == 1m)
            {
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
            else
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            dataGridView1.Columns[2].ReadOnly = true;
        }

        private void numericUpDownDays_ValueChanged(object sender, EventArgs e)
        {
            CalculateCurrentDate();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            String cellValue = (String)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (cellValue == null)
                cellValue = "";
            switch (e.ColumnIndex)
            {
                case 0:
                    currentCellType = CurrentCellType.Name;
                    break;
                case 1:
                    currentCellType = CurrentCellType.Hours;
                    break;
                default:
                    currentCellType = CurrentCellType.None;
                    return;
            }
                
            switch (currentCellType)
            {
                case CurrentCellType.Name:
                    currentCellString = cellValue;
                    break;
                case CurrentCellType.Hours:
                    if (!decimal.TryParse(cellValue, out currentCellDecimal))
                        currentCellDecimal = 0m;
                    break;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CurrentCellType cellType;
            String cellValue = (String)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (cellValue == null)
                cellValue = "";
            decimal cellDecimal;
            switch (e.ColumnIndex)
            {
                case 0:
                    cellType = CurrentCellType.Name;
                    break;
                case 1:
                    cellType = CurrentCellType.Hours;
                    break;
                default:
                    cellType = CurrentCellType.None;
                    return;
            }
            switch (cellType)
            {
                case CurrentCellType.Name:
                    if (cellValue.Length == 0 && currentCellString.Length > 0) // No name entered, revert to previous value
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = currentCellString;
                    }
                    else if (cellValue.Length > 0 && currentCellString.Length > 0 && String.Compare(cellValue, currentCellString) != 0) // Name changed
                    {
                        if (employeeTotalList.ContainsKey(currentCellString))
                        {
                            if (employeeTotalList.ContainsKey(cellValue)) //Merge existing employees
                            {
                                foreach (KeyValuePair<DateTime, EmployeeDay> kvp in employeeTotalList[currentCellString].employeeDays)
                                    employeeTotalList[cellValue].employeeDays[kvp.Key] = kvp.Value.Duplicate();
                                employeeTotalList.Remove(currentCellString);
                                Output($"Merged Employees '{currentCellString}' and '{cellValue}'");
                            }
                            else // Rename employee
                            {
                                employeeTotalList[cellValue] = employeeTotalList[currentCellString].Duplicate();
                                employeeTotalList.Remove(currentCellString);
                            }
                            Output($"Renamed Employee '{currentCellString}' to '{cellValue}'");
                        }
                        else
                        {
                            employeeTotalList[cellValue] = new EmployeeTotal();
                        }
                    }
                    currentCellString = "";
                    break;
                case CurrentCellType.Hours:
                    if (!decimal.TryParse(cellValue, out cellDecimal) || cellDecimal < 0m) // Invalid value entered, reverting to previous value
                    {
                        if (currentCellDecimal > 0m)
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = currentCellDecimal;
                    }
                    else //Valid hours >= 0 entered, adding/updating new day
                    {
                        String employeeName = (String)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                        AddDay(new EmployeeDay { name = employeeName, day = RoundTime(dateTimePicker1.Value), hours = cellDecimal });
                    }
                    currentCellDecimal = 0m;
                    break;
            }
        }

        private void contextMenuStripDataGridView_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (numericUpDownDays.Value != 1m)
                e.Cancel = true;
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0 || dataGridView1.SelectedRows.Count > 0)
            {
                String cellValue = "";
                int rowIndex = -1;
                if (dataGridView1.SelectedCells.Count == 1)
                {
                    cellValue = (String)dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value;
                    rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                }
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    cellValue = (String)dataGridView1.SelectedRows[0].Cells[0].Value;
                    rowIndex = dataGridView1.SelectedRows[0].Index;
                }
                if (cellValue == null)
                    cellValue = "";
                if (cellValue.Length > 0 && rowIndex >= 0)
                {
                    if (dataGridView1.Rows[rowIndex].IsNewRow)
                        return;
                    if (employeeTotalList.ContainsKey(cellValue) && employeeTotalList[cellValue].employeeDays.Remove(RoundTime(dateTimePicker1.Value)))
                    {
                        Output($"Removed day for '{cellValue}' on {RoundTime(dateTimePicker1.Value).ToShortDateString()}");
                        if (employeeTotalList[cellValue].employeeDays.Count == 0)
                        {
                            employeeTotalList.Remove(cellValue);
                            Output($"Employee '{cellValue}' automatically removed with no days remaining");
                        }
                    }
                    dataGridView1.Rows.RemoveAt(rowIndex);
                    currentCellDecimal = 0m;
                    currentCellString = "";
                    currentCellType = CurrentCellType.None;
                }
            }
        }

        private void checkBoxColorlessTable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxColorlessTable.Checked)
            {
                PaintControl(dataGridView1, new ColorScheme("B&W", System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.White, System.Drawing.Color.Black));
                dataGridView1.ClearSelection();
            }
            else
            {
                ColorScheme colorScheme;
                if (GetColorScheme(currentScheme, out colorScheme))
                    PaintControl(dataGridView1, colorScheme);
            }
        }

        #endregion


        #region Employee List Tab

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
                    StartAutosave();
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
                    StartAutosave();
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
                    blacklistedEmployees.Remove(nameKey);
                else
                    blacklistedEmployees.Add(nameKey);
                StartAutosave();
            }
        }

        #endregion


        #region Days List Tab

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
                StartAutosave();
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
                    StartAutosave();
                }
            }
        }

        private void listBoxDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxDaysEmployees.Items.Clear();
            if (SelectionOK(listBoxDays))
            {
                string[] args = listBoxDays.SelectedItem.ToString().Split('/');
                decimal totalHours = 0;
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
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (KeyValuePair<int, decimal> kvp in dailyTipValues[timeKey])
                    {
                        builder.AppendLine();
                        builder.Append($"{kvp.Key}D - ${kvp.Value.ToString("N2")}");
                    }    
                    labelDailyTips.Text = $"Tips:{builder.ToString()}";
                }
                else
                    labelDailyTips.Text = "Tips:";

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

        #endregion


        #region Settings Tab

        private void button7_Click(object sender, EventArgs e)
        {
            employeeTotalList.Clear();
            dailyTipValues.Clear();
            blacklistedEmployees.Clear();
        }

        private void checkBoxNormalizedNames_CheckedChanged(object sender, EventArgs e)
        {
            if (!loading && normalizeNames != checkBoxNormalizedNames.Checked)
            {
                normalizeNames = checkBoxNormalizedNames.Checked;
                StartAutosave();
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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/nicknds/Jamba-Tips/releases");
        }

        private void comboBoxColorSchemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && comboBoxColorSchemes.SelectedItem != null && comboBoxColorSchemes.Text.Length > 0)
            {
                PaintThisApplication(comboBoxColorSchemes.Text);
            }
        }

        private void buttonFilters_Click(object sender, EventArgs e)
        {
            if (dataFilterForm == null)
            {
                dataFilterForm = new DataFilterForm();
                dataFilterForm.parent = this;
                dataFilterForm.FormClosed += DataFilterForm_FormClosed;
                dataFilterForm.Show();
            }
        }

        private void DataFilterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                dataFilterForm.Dispose();
            }
            catch { }
            try
            {
                dataFilterForm = null;
            }
            catch { }
        }

        #endregion


        #region Classes

        public struct ColorScheme
        {
            public System.Drawing.Color[] colors;
            public string name;
            public System.Drawing.Color h1 { get { return colors[0]; } }
            public System.Drawing.Color h2 { get { return colors[1]; } }
            public System.Drawing.Color h3 { get { return colors[2]; } }
            public System.Drawing.Color h4 { get { return colors[3]; } }

            public ColorScheme(string name, System.Drawing.Color color1, System.Drawing.Color color2, System.Drawing.Color color3, System.Drawing.Color color4)
            {
                this.name = name;
                colors = new System.Drawing.Color[4];
                colors[0] = color1;
                colors[1] = color2;
                colors[2] = color3;
                colors[3] = color4;
            }
        }

        public class EmployeeDay
        {
            public string name = "";
            public DateTime day = new DateTime(1, 1, 1);
            public decimal hours = 0, calculatedTips = 0;

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
                hours = decimal.Parse(array[1]);
                day = new DateTime(DateTime.Now.Year, int.Parse(array[2]), int.Parse(array[3]));
            }

            public override string ToString()
            {
                return $"{name}♠{hours}♠{day.Month}♠{day.Day}";
            }

            public EmployeeDay Duplicate()
            {
                return new EmployeeDay { name = name, day = day, hours = hours, calculatedTips = calculatedTips };
            }
        }

        public class EmployeeTotal
        {
            public SortedList<DateTime, EmployeeDay> employeeDays = new SortedList<DateTime, EmployeeDay>();

            public EmployeeTotal Duplicate()
            {
                EmployeeTotal employeeTotal = new EmployeeTotal();
                foreach (KeyValuePair<DateTime, EmployeeDay> kvp in employeeDays)
                    employeeTotal.employeeDays[kvp.Key] = kvp.Value.Duplicate();
                return employeeTotal;
            }
        }

        #endregion
    }
}