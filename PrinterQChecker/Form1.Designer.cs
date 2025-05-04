namespace PrinterQChecker
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
            this.btnLoadPrinters = new System.Windows.Forms.Button();
            this.lstPrinters = new System.Windows.Forms.ListBox();
            this.lstJobs = new System.Windows.Forms.ListBox();
            this.LblPrinterName = new System.Windows.Forms.Label();
            this.LblPrintQue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoadPrinters
            // 
            this.btnLoadPrinters.Location = new System.Drawing.Point(12, 3);
            this.btnLoadPrinters.Name = "btnLoadPrinters";
            this.btnLoadPrinters.Size = new System.Drawing.Size(136, 57);
            this.btnLoadPrinters.TabIndex = 0;
            this.btnLoadPrinters.Text = "โหลด Printer";
            this.btnLoadPrinters.UseVisualStyleBackColor = true;
            this.btnLoadPrinters.Click += new System.EventHandler(this.btnLoadPrinters_Click);
            // 
            // lstPrinters
            // 
            this.lstPrinters.FormattingEnabled = true;
            this.lstPrinters.Location = new System.Drawing.Point(12, 120);
            this.lstPrinters.Name = "lstPrinters";
            this.lstPrinters.Size = new System.Drawing.Size(492, 433);
            this.lstPrinters.TabIndex = 1;
            this.lstPrinters.SelectedIndexChanged += new System.EventHandler(this.lstPrinters_SelectedIndexChanged);
            // 
            // lstJobs
            // 
            this.lstJobs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstJobs.FormattingEnabled = true;
            this.lstJobs.ItemHeight = 20;
            this.lstJobs.Location = new System.Drawing.Point(568, 120);
            this.lstJobs.Name = "lstJobs";
            this.lstJobs.Size = new System.Drawing.Size(707, 444);
            this.lstJobs.TabIndex = 2;
            // 
            // LblPrinterName
            // 
            this.LblPrinterName.AutoSize = true;
            this.LblPrinterName.Location = new System.Drawing.Point(12, 87);
            this.LblPrinterName.Name = "LblPrinterName";
            this.LblPrinterName.Size = new System.Drawing.Size(88, 13);
            this.LblPrinterName.TabIndex = 3;
            this.LblPrinterName.Text = "รายชื่อเครื่องปริ้น";
            // 
            // LblPrintQue
            // 
            this.LblPrintQue.AutoSize = true;
            this.LblPrintQue.Location = new System.Drawing.Point(565, 87);
            this.LblPrintQue.Name = "LblPrintQue";
            this.LblPrintQue.Size = new System.Drawing.Size(77, 13);
            this.LblPrintQue.TabIndex = 4;
            this.LblPrintQue.Text = "รายการคิวปริ้น";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 654);
            this.Controls.Add(this.LblPrintQue);
            this.Controls.Add(this.LblPrinterName);
            this.Controls.Add(this.lstJobs);
            this.Controls.Add(this.lstPrinters);
            this.Controls.Add(this.btnLoadPrinters);
            this.Name = "Form1";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadPrinters;
        private System.Windows.Forms.ListBox lstPrinters;
        private System.Windows.Forms.ListBox lstJobs;
        private System.Windows.Forms.Label LblPrinterName;
        private System.Windows.Forms.Label LblPrintQue;
    }
}

