namespace PhotoSorter
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiOutputTextBox = new System.Windows.Forms.TextBox();
            this.uiFolderTextBox = new System.Windows.Forms.TextBox();
            this.uiSortButton = new System.Windows.Forms.Button();
            this.uiFileTypeTextBox = new System.Windows.Forms.TextBox();
            this.uiMainProgressBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.uiIncludeSubdirCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // uiOutputTextBox
            // 
            this.uiOutputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOutputTextBox.Location = new System.Drawing.Point(12, 151);
            this.uiOutputTextBox.Multiline = true;
            this.uiOutputTextBox.Name = "uiOutputTextBox";
            this.uiOutputTextBox.Size = new System.Drawing.Size(629, 158);
            this.uiOutputTextBox.TabIndex = 0;
            // 
            // uiFolderTextBox
            // 
            this.uiFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiFolderTextBox.Location = new System.Drawing.Point(12, 12);
            this.uiFolderTextBox.Name = "uiFolderTextBox";
            this.uiFolderTextBox.Size = new System.Drawing.Size(629, 20);
            this.uiFolderTextBox.TabIndex = 1;
            this.uiFolderTextBox.Text = "D:\\Photos\\202207(2022.12.07)";
            // 
            // uiSortButton
            // 
            this.uiSortButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSortButton.Location = new System.Drawing.Point(12, 64);
            this.uiSortButton.Name = "uiSortButton";
            this.uiSortButton.Size = new System.Drawing.Size(629, 23);
            this.uiSortButton.TabIndex = 2;
            this.uiSortButton.Text = "Вбей в текстбокс путь к папке, а потом нажми сюда, там появится папка сортид куда" +
    " всё переместится";
            this.uiSortButton.UseVisualStyleBackColor = true;
            this.uiSortButton.Click += new System.EventHandler(this.uiSortButton_Click);
            // 
            // uiFileTypeTextBox
            // 
            this.uiFileTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiFileTypeTextBox.Location = new System.Drawing.Point(12, 38);
            this.uiFileTypeTextBox.Name = "uiFileTypeTextBox";
            this.uiFileTypeTextBox.Size = new System.Drawing.Size(442, 20);
            this.uiFileTypeTextBox.TabIndex = 3;
            this.uiFileTypeTextBox.Text = "jpg,jpeg,heic,mov";
            // 
            // uiMainProgressBar
            // 
            this.uiMainProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiMainProgressBar.Location = new System.Drawing.Point(12, 122);
            this.uiMainProgressBar.Name = "uiMainProgressBar";
            this.uiMainProgressBar.Size = new System.Drawing.Size(629, 23);
            this.uiMainProgressBar.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(12, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(629, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "добавить_2 в префикс";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiIncludeSubdirCheckBox
            // 
            this.uiIncludeSubdirCheckBox.AutoSize = true;
            this.uiIncludeSubdirCheckBox.Location = new System.Drawing.Point(520, 40);
            this.uiIncludeSubdirCheckBox.Name = "uiIncludeSubdirCheckBox";
            this.uiIncludeSubdirCheckBox.Size = new System.Drawing.Size(121, 17);
            this.uiIncludeSubdirCheckBox.TabIndex = 6;
            this.uiIncludeSubdirCheckBox.Text = "Включая подпапки";
            this.uiIncludeSubdirCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 321);
            this.Controls.Add(this.uiIncludeSubdirCheckBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uiMainProgressBar);
            this.Controls.Add(this.uiFileTypeTextBox);
            this.Controls.Add(this.uiSortButton);
            this.Controls.Add(this.uiFolderTextBox);
            this.Controls.Add(this.uiOutputTextBox);
            this.Name = "MainForm";
            this.Text = "PhotoSorter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiOutputTextBox;
        private System.Windows.Forms.TextBox uiFolderTextBox;
        private System.Windows.Forms.Button uiSortButton;
        private System.Windows.Forms.TextBox uiFileTypeTextBox;
        private System.Windows.Forms.ProgressBar uiMainProgressBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox uiIncludeSubdirCheckBox;
    }
}

