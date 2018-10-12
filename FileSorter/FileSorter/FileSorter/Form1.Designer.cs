namespace FileSorter
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
            this.uiFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.uiSortedFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.uiStartButton = new System.Windows.Forms.Button();
            this.uiSortProgressBar = new System.Windows.Forms.ProgressBar();
            this.uiStopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uiFolderPathTextBox
            // 
            this.uiFolderPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiFolderPathTextBox.Location = new System.Drawing.Point(12, 12);
            this.uiFolderPathTextBox.Name = "uiFolderPathTextBox";
            this.uiFolderPathTextBox.Size = new System.Drawing.Size(379, 20);
            this.uiFolderPathTextBox.TabIndex = 0;
            // 
            // uiSortedFolderPathTextBox
            // 
            this.uiSortedFolderPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSortedFolderPathTextBox.Location = new System.Drawing.Point(12, 38);
            this.uiSortedFolderPathTextBox.Name = "uiSortedFolderPathTextBox";
            this.uiSortedFolderPathTextBox.Size = new System.Drawing.Size(379, 20);
            this.uiSortedFolderPathTextBox.TabIndex = 1;
            // 
            // uiStartButton
            // 
            this.uiStartButton.Location = new System.Drawing.Point(12, 64);
            this.uiStartButton.Name = "uiStartButton";
            this.uiStartButton.Size = new System.Drawing.Size(100, 23);
            this.uiStartButton.TabIndex = 2;
            this.uiStartButton.Text = "start";
            this.uiStartButton.UseVisualStyleBackColor = true;
            this.uiStartButton.Click += new System.EventHandler(this.uiStartButton_Click);
            // 
            // uiSortProgressBar
            // 
            this.uiSortProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSortProgressBar.Location = new System.Drawing.Point(12, 227);
            this.uiSortProgressBar.Name = "uiSortProgressBar";
            this.uiSortProgressBar.Size = new System.Drawing.Size(379, 23);
            this.uiSortProgressBar.TabIndex = 3;
            // 
            // uiStopButton
            // 
            this.uiStopButton.Location = new System.Drawing.Point(118, 64);
            this.uiStopButton.Name = "uiStopButton";
            this.uiStopButton.Size = new System.Drawing.Size(100, 23);
            this.uiStopButton.TabIndex = 4;
            this.uiStopButton.Text = "stop";
            this.uiStopButton.UseVisualStyleBackColor = true;
            this.uiStopButton.Click += new System.EventHandler(this.uiStopButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 262);
            this.Controls.Add(this.uiStopButton);
            this.Controls.Add(this.uiSortProgressBar);
            this.Controls.Add(this.uiStartButton);
            this.Controls.Add(this.uiSortedFolderPathTextBox);
            this.Controls.Add(this.uiFolderPathTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiFolderPathTextBox;
        private System.Windows.Forms.TextBox uiSortedFolderPathTextBox;
        private System.Windows.Forms.Button uiStartButton;
        private System.Windows.Forms.ProgressBar uiSortProgressBar;
        private System.Windows.Forms.Button uiStopButton;
    }
}

