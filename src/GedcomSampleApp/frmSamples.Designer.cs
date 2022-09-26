
namespace GedcomSampleApp
{
    partial class frmSample
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPersonLoopingAllNames = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPersonLoopingAllNames
            // 
            this.btnPersonLoopingAllNames.Location = new System.Drawing.Point(30, 15);
            this.btnPersonLoopingAllNames.Name = "btnPersonLoopingAllNames";
            this.btnPersonLoopingAllNames.Size = new System.Drawing.Size(217, 23);
            this.btnPersonLoopingAllNames.TabIndex = 0;
            this.btnPersonLoopingAllNames.Text = "Loop People (All Names)";
            this.btnPersonLoopingAllNames.UseVisualStyleBackColor = true;
            this.btnPersonLoopingAllNames.Click += new System.EventHandler(this.btnPersonLooping_Click);
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 15;
            this.lstResults.Location = new System.Drawing.Point(274, 45);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(1106, 559);
            this.lstResults.TabIndex = 1;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(274, 19);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(47, 15);
            this.lblResults.TabIndex = 2;
            this.lblResults.Text = "Results:";
            // 
            // frmSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 614);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnPersonLoopingAllNames);
            this.Name = "frmSample";
            this.Text = "Gedcomm Sample Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPersonLoopingAllNames;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Label lblResults;
    }
}

