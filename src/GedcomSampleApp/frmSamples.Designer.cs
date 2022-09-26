
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
            this.SuspendLayout();
            // 
            // btnPersonLoopingAllNames
            // 
            this.btnPersonLoopingAllNames.Location = new System.Drawing.Point(31, 27);
            this.btnPersonLoopingAllNames.Name = "btnPersonLoopingAllNames";
            this.btnPersonLoopingAllNames.Size = new System.Drawing.Size(217, 23);
            this.btnPersonLoopingAllNames.TabIndex = 0;
            this.btnPersonLoopingAllNames.Text = "Loop People (All Names)";
            this.btnPersonLoopingAllNames.UseVisualStyleBackColor = true;
            this.btnPersonLoopingAllNames.Click += new System.EventHandler(this.btnPersonLooping_Click);
            // 
            // frmSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPersonLoopingAllNames);
            this.Name = "frmSample";
            this.Text = "Gedcomm Sample Application";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPersonLoopingAllNames;
    }
}

