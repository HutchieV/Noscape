namespace Noscape
{
    partial class HistoryWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryWindow));
            this.historyCloseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clearHistory = new System.Windows.Forms.Button();
            this.historyListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // historyCloseButton
            // 
            this.historyCloseButton.Location = new System.Drawing.Point(229, 440);
            this.historyCloseButton.Name = "historyCloseButton";
            this.historyCloseButton.Size = new System.Drawing.Size(92, 28);
            this.historyCloseButton.TabIndex = 7;
            this.historyCloseButton.Text = "Close";
            this.historyCloseButton.UseVisualStyleBackColor = true;
            this.historyCloseButton.Click += new System.EventHandler(this.HistoryCloseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "History";
            // 
            // clearHistory
            // 
            this.clearHistory.Location = new System.Drawing.Point(8, 440);
            this.clearHistory.Name = "clearHistory";
            this.clearHistory.Size = new System.Drawing.Size(144, 28);
            this.clearHistory.TabIndex = 5;
            this.clearHistory.Text = "Clear History";
            this.clearHistory.UseVisualStyleBackColor = true;
            this.clearHistory.Click += new System.EventHandler(this.ClearHistory_Click);
            // 
            // historyListBox
            // 
            this.historyListBox.FormattingEnabled = true;
            this.historyListBox.Location = new System.Drawing.Point(8, 26);
            this.historyListBox.Name = "historyListBox";
            this.historyListBox.Size = new System.Drawing.Size(315, 407);
            this.historyListBox.TabIndex = 4;
            // 
            // HistoryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 478);
            this.Controls.Add(this.historyCloseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearHistory);
            this.Controls.Add(this.historyListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HistoryWindow";
            this.Text = "Noscape: History";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button historyCloseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearHistory;
        private System.Windows.Forms.ListBox historyListBox;
    }
}