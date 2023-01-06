namespace Jamba_Tips
{
    partial class DataFilterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataFilterForm));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.buttonAddFilter = new System.Windows.Forms.Button();
            this.buttonRemoveFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(13, 88);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(368, 576);
            this.listBox1.TabIndex = 0;
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilter.Location = new System.Drawing.Point(13, 14);
            this.textBoxFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(368, 29);
            this.textBoxFilter.TabIndex = 1;
            // 
            // buttonAddFilter
            // 
            this.buttonAddFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddFilter.Location = new System.Drawing.Point(13, 51);
            this.buttonAddFilter.Name = "buttonAddFilter";
            this.buttonAddFilter.Size = new System.Drawing.Size(135, 29);
            this.buttonAddFilter.TabIndex = 2;
            this.buttonAddFilter.Text = "Add Filter";
            this.buttonAddFilter.UseVisualStyleBackColor = true;
            this.buttonAddFilter.Click += new System.EventHandler(this.buttonAddFilter_Click);
            // 
            // buttonRemoveFilter
            // 
            this.buttonRemoveFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveFilter.Location = new System.Drawing.Point(246, 51);
            this.buttonRemoveFilter.Name = "buttonRemoveFilter";
            this.buttonRemoveFilter.Size = new System.Drawing.Size(135, 29);
            this.buttonRemoveFilter.TabIndex = 3;
            this.buttonRemoveFilter.Text = "Remove Filter";
            this.buttonRemoveFilter.UseVisualStyleBackColor = true;
            this.buttonRemoveFilter.Click += new System.EventHandler(this.buttonRemoveFilter_Click);
            // 
            // DataFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 680);
            this.Controls.Add(this.buttonRemoveFilter);
            this.Controls.Add(this.buttonAddFilter);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(320, 260);
            this.Name = "DataFilterForm";
            this.Text = "Data Filters";
            this.Load += new System.EventHandler(this.DataFilterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Button buttonAddFilter;
        private System.Windows.Forms.Button buttonRemoveFilter;
    }
}