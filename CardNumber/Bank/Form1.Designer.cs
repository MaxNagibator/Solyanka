namespace Bank
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.uiCardNumberTextBox = new System.Windows.Forms.TextBox();
            this.uiExecuteButton = new System.Windows.Forms.Button();
            this.uiValidateButton = new System.Windows.Forms.Button();
            this.uiLastCharTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uiCardNumberTextBox
            // 
            this.uiCardNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCardNumberTextBox.Location = new System.Drawing.Point(12, 12);
            this.uiCardNumberTextBox.Name = "uiCardNumberTextBox";
            this.uiCardNumberTextBox.Size = new System.Drawing.Size(200, 20);
            this.uiCardNumberTextBox.TabIndex = 0;
            this.uiCardNumberTextBox.Text = "4276 8640 2253 0222";
            // 
            // uiExecuteButton
            // 
            this.uiExecuteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiExecuteButton.Location = new System.Drawing.Point(12, 67);
            this.uiExecuteButton.Name = "uiExecuteButton";
            this.uiExecuteButton.Size = new System.Drawing.Size(227, 23);
            this.uiExecuteButton.TabIndex = 1;
            this.uiExecuteButton.Text = "Get last number";
            this.uiExecuteButton.UseVisualStyleBackColor = true;
            this.uiExecuteButton.Click += new System.EventHandler(this.uiExecuteButton_Click);
            // 
            // uiValidateButton
            // 
            this.uiValidateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiValidateButton.Location = new System.Drawing.Point(12, 38);
            this.uiValidateButton.Name = "uiValidateButton";
            this.uiValidateButton.Size = new System.Drawing.Size(227, 23);
            this.uiValidateButton.TabIndex = 2;
            this.uiValidateButton.Text = "Is valid number?";
            this.uiValidateButton.UseVisualStyleBackColor = true;
            this.uiValidateButton.Click += new System.EventHandler(this.uiValidateButton_Click);
            // 
            // uiLastCharTextBox
            // 
            this.uiLastCharTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLastCharTextBox.Location = new System.Drawing.Point(218, 12);
            this.uiLastCharTextBox.Name = "uiLastCharTextBox";
            this.uiLastCharTextBox.Size = new System.Drawing.Size(21, 20);
            this.uiLastCharTextBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 97);
            this.Controls.Add(this.uiLastCharTextBox);
            this.Controls.Add(this.uiValidateButton);
            this.Controls.Add(this.uiExecuteButton);
            this.Controls.Add(this.uiCardNumberTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Bank card numbers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiCardNumberTextBox;
        private System.Windows.Forms.Button uiExecuteButton;
        private System.Windows.Forms.Button uiValidateButton;
        private System.Windows.Forms.TextBox uiLastCharTextBox;
    }
}

