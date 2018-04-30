namespace Prj01PostCodes
{
    partial class MainFrm
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
            this.btnFindPath = new System.Windows.Forms.Button();
            this.TBFolderPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBLinesWithPostCode = new System.Windows.Forms.TextBox();
            this.btnFindLines_regEx = new System.Windows.Forms.Button();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFindPath
            // 
            this.btnFindPath.Location = new System.Drawing.Point(636, 20);
            this.btnFindPath.Name = "btnFindPath";
            this.btnFindPath.Size = new System.Drawing.Size(101, 33);
            this.btnFindPath.TabIndex = 0;
            this.btnFindPath.Text = "Step 1) Find Path";
            this.btnFindPath.UseVisualStyleBackColor = true;
            this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
            // 
            // TBFolderPath
            // 
            this.TBFolderPath.Location = new System.Drawing.Point(101, 27);
            this.TBFolderPath.Name = "TBFolderPath";
            this.TBFolderPath.Size = new System.Drawing.Size(512, 20);
            this.TBFolderPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path";
            // 
            // TBLinesWithPostCode
            // 
            this.TBLinesWithPostCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBLinesWithPostCode.Location = new System.Drawing.Point(104, 114);
            this.TBLinesWithPostCode.Multiline = true;
            this.TBLinesWithPostCode.Name = "TBLinesWithPostCode";
            this.TBLinesWithPostCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TBLinesWithPostCode.Size = new System.Drawing.Size(633, 390);
            this.TBLinesWithPostCode.TabIndex = 3;
            // 
            // btnFindLines_regEx
            // 
            this.btnFindLines_regEx.Location = new System.Drawing.Point(284, 66);
            this.btnFindLines_regEx.Name = "btnFindLines_regEx";
            this.btnFindLines_regEx.Size = new System.Drawing.Size(227, 37);
            this.btnFindLines_regEx.TabIndex = 4;
            this.btnFindLines_regEx.Text = "Setp 2) Find Lines (RegEx)";
            this.btnFindLines_regEx.UseVisualStyleBackColor = true;
            this.btnFindLines_regEx.Click += new System.EventHandler(this.btnFindLines_regEx_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Result";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 537);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFindLines_regEx);
            this.Controls.Add(this.TBLinesWithPostCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBFolderPath);
            this.Controls.Add(this.btnFindPath);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Post Codes from Legacy Flat Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindPath;
        private System.Windows.Forms.TextBox TBFolderPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBLinesWithPostCode;
        private System.Windows.Forms.Button btnFindLines_regEx;
        private System.Windows.Forms.FolderBrowserDialog FBD;
        private System.Windows.Forms.Label label2;
    }
}

