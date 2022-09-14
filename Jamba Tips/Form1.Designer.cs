
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.listBoxOutput = new System.Windows.Forms.ListBox();
            this.checkBoxClipboardMonitor = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageTables = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.labelDateRange = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownDays = new System.Windows.Forms.NumericUpDown();
            this.labelTotalTips = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelHourTotal = new System.Windows.Forms.Label();
            this.numericUpDownTips = new System.Windows.Forms.NumericUpDown();
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
            this.timerClipboardMonitor = new System.Windows.Forms.Timer(this.components);
            this.buttonAddEmployeeManual = new System.Windows.Forms.Button();
            this.textBoxEmployeeNameManual = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerEmployeeManual = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownEmployeeTipsManual = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStripDataGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTipAllotment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tabPage4 = new System.Windows.Forms.TabPage();
            tabPage4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPageText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTips)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEmployeeTipsManual)).BeginInit();
            this.contextMenuStripDataGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage4
            // 
            tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(197)))), ((int)(((byte)(60)))));
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
            this.listBoxDaysEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(88)))));
            this.listBoxDaysEmployees.ForeColor = System.Drawing.Color.White;
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
            this.listBoxDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(88)))));
            this.listBoxDays.ForeColor = System.Drawing.Color.White;
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
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(197)))), ((int)(((byte)(60)))));
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.listBoxOutput);
            this.tabPage1.Controls.Add(this.checkBoxClipboardMonitor);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1073, 628);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data Entry";
            // 
            // listBoxOutput
            // 
            this.listBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(88)))));
            this.listBoxOutput.ForeColor = System.Drawing.Color.White;
            this.listBoxOutput.FormattingEnabled = true;
            this.listBoxOutput.ItemHeight = 18;
            this.listBoxOutput.Location = new System.Drawing.Point(8, 106);
            this.listBoxOutput.Name = "listBoxOutput";
            this.listBoxOutput.Size = new System.Drawing.Size(1057, 508);
            this.listBoxOutput.TabIndex = 5;
            // 
            // checkBoxClipboardMonitor
            // 
            this.checkBoxClipboardMonitor.AutoSize = true;
            this.checkBoxClipboardMonitor.Checked = true;
            this.checkBoxClipboardMonitor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxClipboardMonitor.Location = new System.Drawing.Point(8, 6);
            this.checkBoxClipboardMonitor.Name = "checkBoxClipboardMonitor";
            this.checkBoxClipboardMonitor.Size = new System.Drawing.Size(163, 22);
            this.checkBoxClipboardMonitor.TabIndex = 8;
            this.checkBoxClipboardMonitor.Text = "Clipboard Data Entry";
            this.checkBoxClipboardMonitor.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(197)))), ((int)(((byte)(60)))));
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
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(88)))));
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(192)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.columnHours,
            this.columnTipAllotment});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStripDataGridView;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(1059, 528);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
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
            this.richTextBoxOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(192)))), ((int)(((byte)(76)))));
            this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOutput.ForeColor = System.Drawing.Color.White;
            this.richTextBoxOutput.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.ReadOnly = true;
            this.richTextBoxOutput.Size = new System.Drawing.Size(1059, 528);
            this.richTextBoxOutput.TabIndex = 0;
            this.richTextBoxOutput.Text = "";
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
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(197)))), ((int)(((byte)(60)))));
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
            this.listBoxEmployeeDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(88)))));
            this.listBoxEmployeeDays.ForeColor = System.Drawing.Color.White;
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
            this.listBoxEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(112)))), ((int)(((byte)(88)))));
            this.listBoxEmployees.ForeColor = System.Drawing.Color.White;
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
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(197)))), ((int)(((byte)(60)))));
            this.tabPage5.Controls.Add(this.button8);
            this.tabPage5.Controls.Add(this.checkBoxNormalizedNames);
            this.tabPage5.Controls.Add(this.button7);
            this.tabPage5.Location = new System.Drawing.Point(4, 27);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1073, 628);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Settings";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(5, 67);
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
            this.checkBoxNormalizedNames.Location = new System.Drawing.Point(8, 3);
            this.checkBoxNormalizedNames.Name = "checkBoxNormalizedNames";
            this.checkBoxNormalizedNames.Size = new System.Drawing.Size(147, 22);
            this.checkBoxNormalizedNames.TabIndex = 6;
            this.checkBoxNormalizedNames.Text = "Normalize Names";
            this.checkBoxNormalizedNames.UseVisualStyleBackColor = true;
            this.checkBoxNormalizedNames.CheckedChanged += new System.EventHandler(this.checkBoxNormalizedNames_CheckedChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(5, 31);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 30);
            this.button7.TabIndex = 5;
            this.button7.Text = "Reset";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // timerClipboardMonitor
            // 
            this.timerClipboardMonitor.Enabled = true;
            this.timerClipboardMonitor.Interval = 500;
            this.timerClipboardMonitor.Tick += new System.EventHandler(this.timerClipboardMonitor_Tick);
            // 
            // buttonAddEmployeeManual
            // 
            this.buttonAddEmployeeManual.Location = new System.Drawing.Point(3, 23);
            this.buttonAddEmployeeManual.Name = "buttonAddEmployeeManual";
            this.buttonAddEmployeeManual.Size = new System.Drawing.Size(75, 30);
            this.buttonAddEmployeeManual.TabIndex = 9;
            this.buttonAddEmployeeManual.Text = "Add";
            this.buttonAddEmployeeManual.UseVisualStyleBackColor = true;
            this.buttonAddEmployeeManual.Click += new System.EventHandler(this.buttonAddEmployeeManual_Click);
            // 
            // textBoxEmployeeNameManual
            // 
            this.textBoxEmployeeNameManual.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxEmployeeNameManual.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxEmployeeNameManual.Location = new System.Drawing.Point(84, 26);
            this.textBoxEmployeeNameManual.Name = "textBoxEmployeeNameManual";
            this.textBoxEmployeeNameManual.Size = new System.Drawing.Size(306, 24);
            this.textBoxEmployeeNameManual.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(212)))), ((int)(((byte)(97)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numericUpDownEmployeeTipsManual);
            this.panel1.Controls.Add(this.dateTimePickerEmployeeManual);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonAddEmployeeManual);
            this.panel1.Controls.Add(this.textBoxEmployeeNameManual);
            this.panel1.Location = new System.Drawing.Point(8, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 66);
            this.panel1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Employee Name";
            // 
            // dateTimePickerEmployeeManual
            // 
            this.dateTimePickerEmployeeManual.Location = new System.Drawing.Point(522, 26);
            this.dateTimePickerEmployeeManual.Name = "dateTimePickerEmployeeManual";
            this.dateTimePickerEmployeeManual.Size = new System.Drawing.Size(280, 24);
            this.dateTimePickerEmployeeManual.TabIndex = 12;
            // 
            // numericUpDownEmployeeTipsManual
            // 
            this.numericUpDownEmployeeTipsManual.DecimalPlaces = 2;
            this.numericUpDownEmployeeTipsManual.Location = new System.Drawing.Point(396, 26);
            this.numericUpDownEmployeeTipsManual.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownEmployeeTipsManual.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownEmployeeTipsManual.Name = "numericUpDownEmployeeTipsManual";
            this.numericUpDownEmployeeTipsManual.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownEmployeeTipsManual.TabIndex = 13;
            this.numericUpDownEmployeeTipsManual.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(393, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Hours";
            // 
            // contextMenuStripDataGridView
            // 
            this.contextMenuStripDataGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteRowToolStripMenuItem});
            this.contextMenuStripDataGridView.Name = "contextMenuStripDataGridView";
            this.contextMenuStripDataGridView.Size = new System.Drawing.Size(134, 26);
            this.contextMenuStripDataGridView.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripDataGridView_Opening);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.deleteRowToolStripMenuItem_Click);
            // 
            // columnName
            // 
            this.columnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            this.columnName.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnName.FillWeight = 450F;
            this.columnName.HeaderText = "Employee Name";
            this.columnName.Name = "columnName";
            // 
            // columnHours
            // 
            this.columnHours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnHours.FillWeight = 180F;
            this.columnHours.HeaderText = "Hours";
            this.columnHours.Name = "columnHours";
            // 
            // columnTipAllotment
            // 
            this.columnTipAllotment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnTipAllotment.FillWeight = 180F;
            this.columnTipAllotment.HeaderText = "Tip Allotment";
            this.columnTipAllotment.Name = "columnTipAllotment";
            this.columnTipAllotment.ReadOnly = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(128)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(1081, 659);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Jamba Tips";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPageTables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPageText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTips)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEmployeeTipsManual)).EndInit();
            this.contextMenuStripDataGridView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown numericUpDownTips;
        private System.Windows.Forms.Label labelTotalTips;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelHourTotal;
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
        private System.Windows.Forms.Label labelEmployeeHours;
        private System.Windows.Forms.Label labelDailyTips;
        private System.Windows.Forms.Label labelDailyHours;
        private System.Windows.Forms.CheckBox checkBoxWhiteListedTips;
        private System.Windows.Forms.ListBox listBoxOutput;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox checkBoxNormalizedNames;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownDays;
        private System.Windows.Forms.Label labelDateRange;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPageTables;
        private System.Windows.Forms.TabPage tabPageText;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.Timer timerClipboardMonitor;
        private System.Windows.Forms.CheckBox checkBoxClipboardMonitor;
        private System.Windows.Forms.Button buttonAddEmployeeManual;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownEmployeeTipsManual;
        private System.Windows.Forms.DateTimePicker dateTimePickerEmployeeManual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEmployeeNameManual;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDataGridView;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTipAllotment;
    }
}

