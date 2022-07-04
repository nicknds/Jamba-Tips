
namespace Jamba_Tips
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TabPage tabPage4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelDailyTips = new System.Windows.Forms.Label();
            this.labelDailyHours = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonRemoveDayEmployee = new System.Windows.Forms.Button();
            this.listBoxDaysEmployees = new System.Windows.Forms.ListBox();
            this.buttonRemoveDay = new System.Windows.Forms.Button();
            this.listBoxDays = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.listBoxOutput = new System.Windows.Forms.ListBox();
            this.checkBoxAutoRead = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelDateRange = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownDays = new System.Windows.Forms.NumericUpDown();
            this.labelTotalTips = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelHourTotal = new System.Windows.Forms.Label();
            this.numericUpDownTips = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTipAllotment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkBoxWhiteListedTips = new System.Windows.Forms.CheckBox();
            this.labelEmployeeHours = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBoxEmployeeDays = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.listBoxEmployees = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.checkBoxNormalizedNames = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHomepage = new System.Windows.Forms.TextBox();
            this.timerLoadDelay = new System.Windows.Forms.Timer(this.components);
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageTables = new System.Windows.Forms.TabPage();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            tabPage4 = new System.Windows.Forms.TabPage();
            tabPage4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageTables.SuspendLayout();
            this.tabPageText.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(this.labelDailyTips);
            tabPage4.Controls.Add(this.labelDailyHours);
            tabPage4.Controls.Add(this.button6);
            tabPage4.Controls.Add(this.buttonRemoveDayEmployee);
            tabPage4.Controls.Add(this.listBoxDaysEmployees);
            tabPage4.Controls.Add(this.buttonRemoveDay);
            tabPage4.Controls.Add(this.listBoxDays);
            tabPage4.Location = new System.Drawing.Point(4, 27);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new System.Drawing.Size(1073, 628);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Days";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // labelDailyTips
            // 
            this.labelDailyTips.AutoSize = true;
            this.labelDailyTips.Location = new System.Drawing.Point(334, 90);
            this.labelDailyTips.Name = "labelDailyTips";
            this.labelDailyTips.Size = new System.Drawing.Size(44, 18);
            this.labelDailyTips.TabIndex = 9;
            this.labelDailyTips.Text = "Tips: ";
            // 
            // labelDailyHours
            // 
            this.labelDailyHours.AutoSize = true;
            this.labelDailyHours.Location = new System.Drawing.Point(334, 72);
            this.labelDailyHours.Name = "labelDailyHours";
            this.labelDailyHours.Size = new System.Drawing.Size(57, 18);
            this.labelDailyHours.TabIndex = 8;
            this.labelDailyHours.Text = "Hours: ";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(334, 39);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 30);
            this.button6.TabIndex = 7;
            this.button6.Text = "Find";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // buttonRemoveDayEmployee
            // 
            this.buttonRemoveDayEmployee.Location = new System.Drawing.Point(823, 3);
            this.buttonRemoveDayEmployee.Name = "buttonRemoveDayEmployee";
            this.buttonRemoveDayEmployee.Size = new System.Drawing.Size(75, 30);
            this.buttonRemoveDayEmployee.TabIndex = 6;
            this.buttonRemoveDayEmployee.Text = "Remove";
            this.buttonRemoveDayEmployee.UseVisualStyleBackColor = true;
            this.buttonRemoveDayEmployee.Click += new System.EventHandler(this.buttonRemoveDayEmployee_Click);
            // 
            // listBoxDaysEmployees
            // 
            this.listBoxDaysEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxDaysEmployees.FormattingEnabled = true;
            this.listBoxDaysEmployees.ItemHeight = 18;
            this.listBoxDaysEmployees.Location = new System.Drawing.Point(497, 3);
            this.listBoxDaysEmployees.Name = "listBoxDaysEmployees";
            this.listBoxDaysEmployees.Size = new System.Drawing.Size(320, 616);
            this.listBoxDaysEmployees.TabIndex = 5;
            // 
            // buttonRemoveDay
            // 
            this.buttonRemoveDay.Location = new System.Drawing.Point(334, 3);
            this.buttonRemoveDay.Name = "buttonRemoveDay";
            this.buttonRemoveDay.Size = new System.Drawing.Size(75, 30);
            this.buttonRemoveDay.TabIndex = 4;
            this.buttonRemoveDay.Text = "Remove";
            this.buttonRemoveDay.UseVisualStyleBackColor = true;
            this.buttonRemoveDay.Click += new System.EventHandler(this.buttonRemoveDay_Click);
            // 
            // listBoxDays
            // 
            this.listBoxDays.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxDays.FormattingEnabled = true;
            this.listBoxDays.ItemHeight = 18;
            this.listBoxDays.Location = new System.Drawing.Point(8, 3);
            this.listBoxDays.Name = "listBoxDays";
            this.listBoxDays.Size = new System.Drawing.Size(320, 616);
            this.listBoxDays.TabIndex = 3;
            this.listBoxDays.SelectedIndexChanged += new System.EventHandler(this.listBoxDays_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1081, 659);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.panelNavigation);
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.checkBoxAutoRead);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1073, 628);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Browser";
            // 
            // panelNavigation
            // 
            this.panelNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelNavigation.Controls.Add(this.button1);
            this.panelNavigation.Controls.Add(this.buttonRead);
            this.panelNavigation.Controls.Add(this.textBoxURL);
            this.panelNavigation.Location = new System.Drawing.Point(8, 3);
            this.panelNavigation.Margin = new System.Windows.Forms.Padding(0);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(958, 30);
            this.panelNavigation.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(799, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRead.Location = new System.Drawing.Point(880, 0);
            this.buttonRead.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 30);
            this.buttonRead.TabIndex = 3;
            this.buttonRead.Text = "Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxURL
            // 
            this.textBoxURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxURL.Location = new System.Drawing.Point(3, 3);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(790, 24);
            this.textBoxURL.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(8, 36);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.webBrowser1);
            this.splitContainer1.Panel1.Controls.Add(this.webView21);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBoxOutput);
            this.splitContainer1.Size = new System.Drawing.Size(1057, 586);
            this.splitContainer1.SplitterDistance = 501;
            this.splitContainer1.TabIndex = 6;
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(250, 250);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = false;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView21.Location = new System.Drawing.Point(0, 0);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(1057, 501);
            this.webView21.Source = new System.Uri("https://google.com", System.UriKind.Absolute);
            this.webView21.TabIndex = 1;
            this.webView21.ZoomFactor = 1D;
            this.webView21.CoreWebView2InitializationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs>(this.webView21_CoreWebView2InitializationCompleted);
            this.webView21.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.webView21_NavigationCompleted);
            this.webView21.SourceChanged += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs>(this.webView21_SourceChanged);
            // 
            // listBoxOutput
            // 
            this.listBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxOutput.FormattingEnabled = true;
            this.listBoxOutput.ItemHeight = 18;
            this.listBoxOutput.Location = new System.Drawing.Point(0, 0);
            this.listBoxOutput.Name = "listBoxOutput";
            this.listBoxOutput.Size = new System.Drawing.Size(1057, 81);
            this.listBoxOutput.TabIndex = 5;
            // 
            // checkBoxAutoRead
            // 
            this.checkBoxAutoRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAutoRead.AutoSize = true;
            this.checkBoxAutoRead.Location = new System.Drawing.Point(969, 8);
            this.checkBoxAutoRead.Name = "checkBoxAutoRead";
            this.checkBoxAutoRead.Size = new System.Drawing.Size(96, 22);
            this.checkBoxAutoRead.TabIndex = 4;
            this.checkBoxAutoRead.Text = "Auto Read";
            this.checkBoxAutoRead.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.labelDateRange);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.numericUpDownDays);
            this.tabPage2.Controls.Add(this.labelTotalTips);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.labelHourTotal);
            this.tabPage2.Controls.Add(this.numericUpDownTips);
            this.tabPage2.Controls.Add(this.dateTimePicker1);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1073, 628);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Calculator";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelDateRange
            // 
            this.labelDateRange.AutoSize = true;
            this.labelDateRange.Location = new System.Drawing.Point(316, 11);
            this.labelDateRange.Name = "labelDateRange";
            this.labelDateRange.Size = new System.Drawing.Size(59, 18);
            this.labelDateRange.TabIndex = 9;
            this.labelDateRange.Text = "Range: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(316, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Calculate Days";
            // 
            // numericUpDownDays
            // 
            this.numericUpDownDays.Location = new System.Drawing.Point(429, 36);
            this.numericUpDownDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numericUpDownDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDays.Name = "numericUpDownDays";
            this.numericUpDownDays.Size = new System.Drawing.Size(101, 24);
            this.numericUpDownDays.TabIndex = 7;
            this.numericUpDownDays.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownDays.ValueChanged += new System.EventHandler(this.numericUpDownDays_ValueChanged);
            // 
            // labelTotalTips
            // 
            this.labelTotalTips.AutoSize = true;
            this.labelTotalTips.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelTotalTips.Location = new System.Drawing.Point(614, 38);
            this.labelTotalTips.Name = "labelTotalTips";
            this.labelTotalTips.Size = new System.Drawing.Size(140, 18);
            this.labelTotalTips.TabIndex = 6;
            this.labelTotalTips.Text = "Counted Tips: $0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total Tips";
            // 
            // labelHourTotal
            // 
            this.labelHourTotal.AutoSize = true;
            this.labelHourTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelHourTotal.Location = new System.Drawing.Point(614, 11);
            this.labelHourTotal.Name = "labelHourTotal";
            this.labelHourTotal.Size = new System.Drawing.Size(102, 18);
            this.labelHourTotal.TabIndex = 4;
            this.labelHourTotal.Text = "Total Hours: 0";
            // 
            // numericUpDownTips
            // 
            this.numericUpDownTips.DecimalPlaces = 2;
            this.numericUpDownTips.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.numericUpDownTips.Location = new System.Drawing.Point(86, 36);
            this.numericUpDownTips.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numericUpDownTips.Name = "numericUpDownTips";
            this.numericUpDownTips.Size = new System.Drawing.Size(224, 24);
            this.numericUpDownTips.TabIndex = 3;
            this.numericUpDownTips.ThousandsSeparator = true;
            this.numericUpDownTips.ValueChanged += new System.EventHandler(this.numericUpDownTips_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.columnHours,
            this.columnPercentage,
            this.columnTipAllotment});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1059, 528);
            this.dataGridView1.TabIndex = 2;
            // 
            // columnName
            // 
            this.columnName.HeaderText = "Employee Name";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            this.columnName.Width = 450;
            // 
            // columnHours
            // 
            this.columnHours.HeaderText = "Hours";
            this.columnHours.Name = "columnHours";
            this.columnHours.ReadOnly = true;
            this.columnHours.Width = 125;
            // 
            // columnPercentage
            // 
            this.columnPercentage.HeaderText = "Percentage";
            this.columnPercentage.Name = "columnPercentage";
            this.columnPercentage.ReadOnly = true;
            this.columnPercentage.Width = 125;
            // 
            // columnTipAllotment
            // 
            this.columnTipAllotment.HeaderText = "Tip Allotment";
            this.columnTipAllotment.Name = "columnTipAllotment";
            this.columnTipAllotment.ReadOnly = true;
            this.columnTipAllotment.Width = 125;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeRecordToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 26);
            // 
            // removeRecordToolStripMenuItem
            // 
            this.removeRecordToolStripMenuItem.Name = "removeRecordToolStripMenuItem";
            this.removeRecordToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.removeRecordToolStripMenuItem.Text = "Remove Record";
            this.removeRecordToolStripMenuItem.Click += new System.EventHandler(this.removeRecordToolStripMenuItem_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dateTimePicker1.Location = new System.Drawing.Point(8, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(302, 24);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBoxWhiteListedTips);
            this.tabPage3.Controls.Add(this.labelEmployeeHours);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.listBoxEmployeeDays);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.listBoxEmployees);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1073, 628);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Employees";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkBoxWhiteListedTips
            // 
            this.checkBoxWhiteListedTips.AutoSize = true;
            this.checkBoxWhiteListedTips.Location = new System.Drawing.Point(334, 39);
            this.checkBoxWhiteListedTips.Name = "checkBoxWhiteListedTips";
            this.checkBoxWhiteListedTips.Size = new System.Drawing.Size(55, 22);
            this.checkBoxWhiteListedTips.TabIndex = 8;
            this.checkBoxWhiteListedTips.Text = "Tips";
            this.checkBoxWhiteListedTips.UseVisualStyleBackColor = true;
            this.checkBoxWhiteListedTips.CheckedChanged += new System.EventHandler(this.checkBoxWhiteListedTips_CheckedChanged);
            // 
            // labelEmployeeHours
            // 
            this.labelEmployeeHours.AutoSize = true;
            this.labelEmployeeHours.Location = new System.Drawing.Point(823, 72);
            this.labelEmployeeHours.Name = "labelEmployeeHours";
            this.labelEmployeeHours.Size = new System.Drawing.Size(57, 18);
            this.labelEmployeeHours.TabIndex = 7;
            this.labelEmployeeHours.Text = "Hours: ";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(823, 39);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 30);
            this.button5.TabIndex = 5;
            this.button5.Text = "Find";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(823, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 30);
            this.button3.TabIndex = 4;
            this.button3.Text = "Remove";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // listBoxEmployeeDays
            // 
            this.listBoxEmployeeDays.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxEmployeeDays.FormattingEnabled = true;
            this.listBoxEmployeeDays.ItemHeight = 18;
            this.listBoxEmployeeDays.Location = new System.Drawing.Point(497, 3);
            this.listBoxEmployeeDays.Name = "listBoxEmployeeDays";
            this.listBoxEmployeeDays.Size = new System.Drawing.Size(320, 616);
            this.listBoxEmployeeDays.TabIndex = 3;
            this.listBoxEmployeeDays.SelectedIndexChanged += new System.EventHandler(this.listBoxEmployeeDays_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(334, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 30);
            this.button4.TabIndex = 2;
            this.button4.Text = "Remove";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listBoxEmployees
            // 
            this.listBoxEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxEmployees.FormattingEnabled = true;
            this.listBoxEmployees.ItemHeight = 18;
            this.listBoxEmployees.Location = new System.Drawing.Point(8, 3);
            this.listBoxEmployees.Name = "listBoxEmployees";
            this.listBoxEmployees.Size = new System.Drawing.Size(320, 616);
            this.listBoxEmployees.TabIndex = 0;
            this.listBoxEmployees.SelectedIndexChanged += new System.EventHandler(this.listBoxEmployees_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button8);
            this.tabPage5.Controls.Add(this.checkBoxNormalizedNames);
            this.tabPage5.Controls.Add(this.button7);
            this.tabPage5.Controls.Add(this.label2);
            this.tabPage5.Controls.Add(this.textBoxHomepage);
            this.tabPage5.Location = new System.Drawing.Point(4, 27);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1073, 628);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Settings";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(8, 108);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 30);
            this.button8.TabIndex = 7;
            this.button8.Text = "Debug";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // checkBoxNormalizedNames
            // 
            this.checkBoxNormalizedNames.AutoSize = true;
            this.checkBoxNormalizedNames.Location = new System.Drawing.Point(11, 44);
            this.checkBoxNormalizedNames.Name = "checkBoxNormalizedNames";
            this.checkBoxNormalizedNames.Size = new System.Drawing.Size(147, 22);
            this.checkBoxNormalizedNames.TabIndex = 6;
            this.checkBoxNormalizedNames.Text = "Normalize Names";
            this.checkBoxNormalizedNames.UseVisualStyleBackColor = true;
            this.checkBoxNormalizedNames.CheckedChanged += new System.EventHandler(this.checkBoxNormalizedNames_CheckedChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(8, 72);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 30);
            this.button7.TabIndex = 5;
            this.button7.Text = "Reset";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Homepage";
            // 
            // textBoxHomepage
            // 
            this.textBoxHomepage.Location = new System.Drawing.Point(130, 3);
            this.textBoxHomepage.Name = "textBoxHomepage";
            this.textBoxHomepage.Size = new System.Drawing.Size(645, 24);
            this.textBoxHomepage.TabIndex = 0;
            this.textBoxHomepage.TextChanged += new System.EventHandler(this.textBoxHomepage_TextChanged);
            // 
            // timerLoadDelay
            // 
            this.timerLoadDelay.Interval = 500;
            this.timerLoadDelay.Tick += new System.EventHandler(this.timerLoadDelay_Tick);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPageTables);
            this.tabControl2.Controls.Add(this.tabPageText);
            this.tabControl2.Location = new System.Drawing.Point(0, 63);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1073, 565);
            this.tabControl2.TabIndex = 10;
            // 
            // tabPageTables
            // 
            this.tabPageTables.Controls.Add(this.dataGridView1);
            this.tabPageTables.Location = new System.Drawing.Point(4, 27);
            this.tabPageTables.Name = "tabPageTables";
            this.tabPageTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTables.Size = new System.Drawing.Size(1065, 534);
            this.tabPageTables.TabIndex = 0;
            this.tabPageTables.Text = "Table";
            this.tabPageTables.UseVisualStyleBackColor = true;
            // 
            // tabPageText
            // 
            this.tabPageText.Controls.Add(this.richTextBoxOutput);
            this.tabPageText.Location = new System.Drawing.Point(4, 27);
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageText.Size = new System.Drawing.Size(1065, 534);
            this.tabPageText.TabIndex = 1;
            this.tabPageText.Text = "Text";
            this.tabPageText.UseVisualStyleBackColor = true;
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOutput.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.ReadOnly = true;
            this.richTextBoxOutput.Size = new System.Drawing.Size(1059, 528);
            this.richTextBoxOutput.TabIndex = 0;
            this.richTextBoxOutput.Text = "";
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1081, 659);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Jamba Tips";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panelNavigation.ResumeLayout(false);
            this.panelNavigation.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPageTables.ResumeLayout(false);
            this.tabPageText.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.CheckBox checkBoxAutoRead;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown numericUpDownTips;
        private System.Windows.Forms.Label labelTotalTips;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelHourTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTipAllotment;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeRecordToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listBoxEmployees;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonRemoveDay;
        private System.Windows.Forms.ListBox listBoxDays;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBoxEmployeeDays;
        private System.Windows.Forms.Button buttonRemoveDayEmployee;
        private System.Windows.Forms.ListBox listBoxDaysEmployees;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHomepage;
        private System.Windows.Forms.Label labelEmployeeHours;
        private System.Windows.Forms.Label labelDailyTips;
        private System.Windows.Forms.Label labelDailyHours;
        private System.Windows.Forms.CheckBox checkBoxWhiteListedTips;
        private System.Windows.Forms.ListBox listBoxOutput;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox checkBoxNormalizedNames;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Timer timerLoadDelay;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownDays;
        private System.Windows.Forms.Label labelDateRange;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPageTables;
        private System.Windows.Forms.TabPage tabPageText;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
    }
}

