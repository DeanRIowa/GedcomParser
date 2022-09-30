
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
            this.btnPersonLoopingSpouses = new System.Windows.Forms.Button();
            this.btnPersonMarriage = new System.Windows.Forms.Button();
            this.btnLoadGedcomFile = new System.Windows.Forms.Button();
            this.btnPersonChildren = new System.Windows.Forms.Button();
            this.lblGedComLoaded = new System.Windows.Forms.Label();
            this.btunPersonParents = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btunPersonSiblings = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPersonPlaces = new System.Windows.Forms.Button();
            this.btnPersonsParentsExtender = new System.Windows.Forms.Button();
            this.bthPersonChildrenExtender = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnFileChooser = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtRawData = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtOutputData = new System.Windows.Forms.TextBox();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPersonLoopingAllNames
            // 
            this.btnPersonLoopingAllNames.Location = new System.Drawing.Point(14, 22);
            this.btnPersonLoopingAllNames.Name = "btnPersonLoopingAllNames";
            this.btnPersonLoopingAllNames.Size = new System.Drawing.Size(211, 23);
            this.btnPersonLoopingAllNames.TabIndex = 0;
            this.btnPersonLoopingAllNames.Text = "All People Names";
            this.btnPersonLoopingAllNames.UseVisualStyleBackColor = true;
            this.btnPersonLoopingAllNames.Click += new System.EventHandler(this.btnPersonLooping_Click);
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 15;
            this.lstResults.Location = new System.Drawing.Point(15, 15);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(1217, 694);
            this.lstResults.TabIndex = 1;
            // 
            // btnPersonLoopingSpouses
            // 
            this.btnPersonLoopingSpouses.Location = new System.Drawing.Point(13, 60);
            this.btnPersonLoopingSpouses.Name = "btnPersonLoopingSpouses";
            this.btnPersonLoopingSpouses.Size = new System.Drawing.Size(212, 23);
            this.btnPersonLoopingSpouses.TabIndex = 3;
            this.btnPersonLoopingSpouses.Text = "Spouses Collection";
            this.btnPersonLoopingSpouses.UseVisualStyleBackColor = true;
            this.btnPersonLoopingSpouses.Click += new System.EventHandler(this.btnPersonLoopingSpouses_Click);
            // 
            // btnPersonMarriage
            // 
            this.btnPersonMarriage.Location = new System.Drawing.Point(13, 98);
            this.btnPersonMarriage.Name = "btnPersonMarriage";
            this.btnPersonMarriage.Size = new System.Drawing.Size(212, 23);
            this.btnPersonMarriage.TabIndex = 4;
            this.btnPersonMarriage.Text = "All People Marriages";
            this.btnPersonMarriage.UseVisualStyleBackColor = true;
            this.btnPersonMarriage.Click += new System.EventHandler(this.btnPersonMarriage_Click);
            // 
            // btnLoadGedcomFile
            // 
            this.btnLoadGedcomFile.Location = new System.Drawing.Point(25, 45);
            this.btnLoadGedcomFile.Name = "btnLoadGedcomFile";
            this.btnLoadGedcomFile.Size = new System.Drawing.Size(217, 23);
            this.btnLoadGedcomFile.TabIndex = 5;
            this.btnLoadGedcomFile.Text = "Load Gedcom File";
            this.btnLoadGedcomFile.UseVisualStyleBackColor = true;
            this.btnLoadGedcomFile.Click += new System.EventHandler(this.btnLoadGedcomFile_Click);
            // 
            // btnPersonChildren
            // 
            this.btnPersonChildren.Location = new System.Drawing.Point(13, 133);
            this.btnPersonChildren.Name = "btnPersonChildren";
            this.btnPersonChildren.Size = new System.Drawing.Size(212, 23);
            this.btnPersonChildren.TabIndex = 6;
            this.btnPersonChildren.Text = "All People Children";
            this.btnPersonChildren.UseVisualStyleBackColor = true;
            this.btnPersonChildren.Click += new System.EventHandler(this.btnPersonChildren_Click);
            // 
            // lblGedComLoaded
            // 
            this.lblGedComLoaded.AutoSize = true;
            this.lblGedComLoaded.BackColor = System.Drawing.Color.Red;
            this.lblGedComLoaded.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGedComLoaded.ForeColor = System.Drawing.Color.White;
            this.lblGedComLoaded.Location = new System.Drawing.Point(684, 14);
            this.lblGedComLoaded.Name = "lblGedComLoaded";
            this.lblGedComLoaded.Size = new System.Drawing.Size(145, 15);
            this.lblGedComLoaded.TabIndex = 7;
            this.lblGedComLoaded.Text = "GEDCom File Not Loaded";
            // 
            // btunPersonParents
            // 
            this.btunPersonParents.Location = new System.Drawing.Point(15, 167);
            this.btunPersonParents.Name = "btunPersonParents";
            this.btunPersonParents.Size = new System.Drawing.Size(210, 23);
            this.btunPersonParents.TabIndex = 8;
            this.btunPersonParents.Text = "All People Parents";
            this.btunPersonParents.UseVisualStyleBackColor = true;
            this.btunPersonParents.Click += new System.EventHandler(this.btunPersonParents_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btunPersonSiblings);
            this.groupBox1.Controls.Add(this.btnPersonLoopingAllNames);
            this.groupBox1.Controls.Add(this.btnPersonLoopingSpouses);
            this.groupBox1.Controls.Add(this.btnPersonMarriage);
            this.groupBox1.Controls.Add(this.btunPersonParents);
            this.groupBox1.Controls.Add(this.btnPersonChildren);
            this.groupBox1.Location = new System.Drawing.Point(10, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 235);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Standard";
            // 
            // btunPersonSiblings
            // 
            this.btunPersonSiblings.Location = new System.Drawing.Point(15, 201);
            this.btunPersonSiblings.Name = "btunPersonSiblings";
            this.btunPersonSiblings.Size = new System.Drawing.Size(210, 23);
            this.btunPersonSiblings.TabIndex = 9;
            this.btunPersonSiblings.Text = "All People Siblings";
            this.btunPersonSiblings.UseVisualStyleBackColor = true;
            this.btunPersonSiblings.Click += new System.EventHandler(this.btunPersonSiblings_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPersonPlaces);
            this.groupBox2.Controls.Add(this.btnPersonsParentsExtender);
            this.groupBox2.Controls.Add(this.bthPersonChildrenExtender);
            this.groupBox2.Location = new System.Drawing.Point(10, 326);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 134);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Using Extenders";
            // 
            // btnPersonPlaces
            // 
            this.btnPersonPlaces.Location = new System.Drawing.Point(19, 98);
            this.btnPersonPlaces.Name = "btnPersonPlaces";
            this.btnPersonPlaces.Size = new System.Drawing.Size(206, 23);
            this.btnPersonPlaces.TabIndex = 0;
            this.btnPersonPlaces.Text = "Person Places";
            this.btnPersonPlaces.UseVisualStyleBackColor = true;
            this.btnPersonPlaces.Click += new System.EventHandler(this.btnPersonPlaces_Click);
            // 
            // btnPersonsParentsExtender
            // 
            this.btnPersonsParentsExtender.Location = new System.Drawing.Point(15, 66);
            this.btnPersonsParentsExtender.Name = "btnPersonsParentsExtender";
            this.btnPersonsParentsExtender.Size = new System.Drawing.Size(210, 23);
            this.btnPersonsParentsExtender.TabIndex = 1;
            this.btnPersonsParentsExtender.Text = "All People Parents";
            this.btnPersonsParentsExtender.UseVisualStyleBackColor = true;
            this.btnPersonsParentsExtender.Click += new System.EventHandler(this.btnPersonsParentsExtender_Click);
            // 
            // bthPersonChildrenExtender
            // 
            this.bthPersonChildrenExtender.Location = new System.Drawing.Point(15, 33);
            this.bthPersonChildrenExtender.Name = "bthPersonChildrenExtender";
            this.bthPersonChildrenExtender.Size = new System.Drawing.Size(210, 23);
            this.bthPersonChildrenExtender.TabIndex = 0;
            this.bthPersonChildrenExtender.Text = "All People Children";
            this.bthPersonChildrenExtender.UseVisualStyleBackColor = true;
            this.bthPersonChildrenExtender.Click += new System.EventHandler(this.bthPersonChildrenExtender_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "File:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(59, 10);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(574, 23);
            this.txtFileName.TabIndex = 14;
            // 
            // btnFileChooser
            // 
            this.btnFileChooser.Location = new System.Drawing.Point(632, 10);
            this.btnFileChooser.Name = "btnFileChooser";
            this.btnFileChooser.Size = new System.Drawing.Size(29, 23);
            this.btnFileChooser.TabIndex = 15;
            this.btnFileChooser.Text = "...";
            this.btnFileChooser.UseVisualStyleBackColor = true;
            this.btnFileChooser.Click += new System.EventHandler(this.btnFileChooser_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(269, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1260, 750);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstResults);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1252, 722);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Filter Results";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtRawData);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1252, 722);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Raw Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtRawData
            // 
            this.txtRawData.Location = new System.Drawing.Point(16, 11);
            this.txtRawData.Multiline = true;
            this.txtRawData.Name = "txtRawData";
            this.txtRawData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRawData.Size = new System.Drawing.Size(1217, 705);
            this.txtRawData.TabIndex = 17;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtOutputData);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1252, 722);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Data Output";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtOutputData
            // 
            this.txtOutputData.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOutputData.Location = new System.Drawing.Point(16, 16);
            this.txtOutputData.Multiline = true;
            this.txtOutputData.Name = "txtOutputData";
            this.txtOutputData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutputData.Size = new System.Drawing.Size(1215, 680);
            this.txtOutputData.TabIndex = 0;
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.BackColor = System.Drawing.Color.Yellow;
            this.lblProcessing.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProcessing.ForeColor = System.Drawing.Color.Black;
            this.lblProcessing.Location = new System.Drawing.Point(844, 14);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(66, 15);
            this.lblProcessing.TabIndex = 17;
            this.lblProcessing.Text = "Processing";
            this.lblProcessing.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 504);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Testing Only";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1547, 814);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblProcessing);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnFileChooser);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblGedComLoaded);
            this.Controls.Add(this.btnLoadGedcomFile);
            this.Name = "frmSample";
            this.Text = "Gedcomm Sample Application";
            this.Load += new System.EventHandler(this.frmSample_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPersonLoopingAllNames;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Button btnPersonLoopingSpouses;
        private System.Windows.Forms.Button btnPersonMarriage;
        private System.Windows.Forms.Button btnLoadGedcomFile;
        private System.Windows.Forms.Button btnPersonChildren;
        private System.Windows.Forms.Label lblGedComLoaded;
        private System.Windows.Forms.Button btunPersonParents;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bthPersonChildrenExtender;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnFileChooser;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtRawData;
        private System.Windows.Forms.Label lblProcessing;
        private System.Windows.Forms.Button btnPersonsParentsExtender;
        private System.Windows.Forms.Button btunPersonSiblings;
        private System.Windows.Forms.Button btnPersonPlaces;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtOutputData;
        private System.Windows.Forms.Button button1;
    }
}

