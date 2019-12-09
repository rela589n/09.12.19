namespace Sort
{
    partial class Form3
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
            this.append = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.entryInfo = new System.Windows.Forms.DataGridView();
            this.Manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.entryInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // append
            // 
            this.append.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.append.Location = new System.Drawing.Point(242, 192);
            this.append.Margin = new System.Windows.Forms.Padding(2);
            this.append.Name = "append";
            this.append.Size = new System.Drawing.Size(114, 30);
            this.append.TabIndex = 19;
            this.append.Text = "Append";
            this.append.UseVisualStyleBackColor = true;
            this.append.Click += new System.EventHandler(this.Append_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(138, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Enter full information about entry and press \"Append\"";
            // 
            // entryInfo
            // 
            this.entryInfo.AllowUserToAddRows = false;
            this.entryInfo.AllowUserToDeleteRows = false;
            this.entryInfo.AllowUserToOrderColumns = true;
            this.entryInfo.AllowUserToResizeRows = false;
            this.entryInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.entryInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entryInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manufacturer,
            this.Model,
            this.Year});
            this.entryInfo.Location = new System.Drawing.Point(110, 90);
            this.entryInfo.Margin = new System.Windows.Forms.Padding(2);
            this.entryInfo.Name = "entryInfo";
            this.entryInfo.RowHeadersVisible = false;
            this.entryInfo.RowHeadersWidth = 51;
            this.entryInfo.RowTemplate.Height = 24;
            this.entryInfo.Size = new System.Drawing.Size(381, 48);
            this.entryInfo.TabIndex = 17;
            // 
            // Manufacturer
            // 
            this.Manufacturer.HeaderText = "Manufacturer";
            this.Manufacturer.MinimumWidth = 6;
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.Width = 125;
            // 
            // Model
            // 
            this.Model.HeaderText = "Model";
            this.Model.MinimumWidth = 6;
            this.Model.Name = "Model";
            this.Model.Width = 125;
            // 
            // Year
            // 
            this.Year.HeaderText = "Year";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            this.Year.Width = 125;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.append);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.entryInfo);
            this.Name = "Form3";
            this.Text = "Add element";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.entryInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button append;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView entryInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
    }
}