namespace Noscape
{
    partial class Noscape
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Noscape));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tspBar = new System.Windows.Forms.ToolStripProgressBar();
            this.pageStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.htmlTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.favouritesButton = new System.Windows.Forms.Button();
            this.historyButton = new System.Windows.Forms.Button();
            this.toggleFavouriteButton = new System.Windows.Forms.Button();
            this.loadUrlButton = new System.Windows.Forms.Button();
            this.homepageButton = new System.Windows.Forms.Button();
            this.currentPageLabel = new System.Windows.Forms.Label();
            this.setHomepageButton = new System.Windows.Forms.Button();
            this.urlTextBox = new System.Windows.Forms.ComboBox();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspBar,
            this.pageStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 501);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip.Size = new System.Drawing.Size(722, 25);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tspBar
            // 
            this.tspBar.Name = "tspBar";
            this.tspBar.Size = new System.Drawing.Size(114, 19);
            // 
            // pageStatusLabel
            // 
            this.pageStatusLabel.Name = "pageStatusLabel";
            this.pageStatusLabel.Size = new System.Drawing.Size(103, 20);
            this.pageStatusLabel.Text = "Page Status: None";
            // 
            // htmlTextBox
            // 
            this.htmlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.htmlTextBox.Location = new System.Drawing.Point(0, 87);
            this.htmlTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.htmlTextBox.Multiline = true;
            this.htmlTextBox.Name = "htmlTextBox";
            this.htmlTextBox.ReadOnly = true;
            this.htmlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.htmlTextBox.Size = new System.Drawing.Size(722, 415);
            this.htmlTextBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL:";
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(7, 38);
            this.previousButton.Margin = new System.Windows.Forms.Padding(2);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(83, 26);
            this.previousButton.TabIndex = 4;
            this.previousButton.Text = "← Back";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(92, 38);
            this.nextButton.Margin = new System.Windows.Forms.Padding(2);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(83, 26);
            this.nextButton.TabIndex = 5;
            this.nextButton.Text = "Next →";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // favouritesButton
            // 
            this.favouritesButton.Location = new System.Drawing.Point(179, 38);
            this.favouritesButton.Margin = new System.Windows.Forms.Padding(2);
            this.favouritesButton.Name = "favouritesButton";
            this.favouritesButton.Size = new System.Drawing.Size(83, 26);
            this.favouritesButton.TabIndex = 6;
            this.favouritesButton.Text = "Favourites";
            this.favouritesButton.UseVisualStyleBackColor = true;
            this.favouritesButton.Click += new System.EventHandler(this.favouritesButton_Click);
            // 
            // historyButton
            // 
            this.historyButton.Location = new System.Drawing.Point(266, 38);
            this.historyButton.Margin = new System.Windows.Forms.Padding(2);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(83, 26);
            this.historyButton.TabIndex = 7;
            this.historyButton.Text = "History";
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // toggleFavouriteButton
            // 
            this.toggleFavouriteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleFavouriteButton.Location = new System.Drawing.Point(550, 38);
            this.toggleFavouriteButton.Margin = new System.Windows.Forms.Padding(2);
            this.toggleFavouriteButton.Name = "toggleFavouriteButton";
            this.toggleFavouriteButton.Size = new System.Drawing.Size(161, 26);
            this.toggleFavouriteButton.TabIndex = 9;
            this.toggleFavouriteButton.Text = "Remove from Favourites ☆";
            this.toggleFavouriteButton.UseVisualStyleBackColor = true;
            this.toggleFavouriteButton.Click += new System.EventHandler(this.toggleFavouriteButton_Click);
            // 
            // loadUrlButton
            // 
            this.loadUrlButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadUrlButton.Location = new System.Drawing.Point(599, 6);
            this.loadUrlButton.Margin = new System.Windows.Forms.Padding(2);
            this.loadUrlButton.Name = "loadUrlButton";
            this.loadUrlButton.Size = new System.Drawing.Size(83, 26);
            this.loadUrlButton.TabIndex = 2;
            this.loadUrlButton.Text = "Load URL";
            this.loadUrlButton.UseVisualStyleBackColor = true;
            this.loadUrlButton.Click += new System.EventHandler(this.loadUrlButton_Click);
            // 
            // homepageButton
            // 
            this.homepageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.homepageButton.Location = new System.Drawing.Point(686, 6);
            this.homepageButton.Margin = new System.Windows.Forms.Padding(2);
            this.homepageButton.Name = "homepageButton";
            this.homepageButton.Size = new System.Drawing.Size(25, 26);
            this.homepageButton.TabIndex = 3;
            this.homepageButton.Text = "🏠 ";
            this.homepageButton.UseVisualStyleBackColor = true;
            this.homepageButton.Click += new System.EventHandler(this.homepageButton_Click);
            // 
            // currentPageLabel
            // 
            this.currentPageLabel.AutoSize = true;
            this.currentPageLabel.Location = new System.Drawing.Point(4, 72);
            this.currentPageLabel.Name = "currentPageLabel";
            this.currentPageLabel.Size = new System.Drawing.Size(0, 13);
            this.currentPageLabel.TabIndex = 11;
            // 
            // setHomepageButton
            // 
            this.setHomepageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setHomepageButton.Location = new System.Drawing.Point(437, 38);
            this.setHomepageButton.Margin = new System.Windows.Forms.Padding(2);
            this.setHomepageButton.Name = "setHomepageButton";
            this.setHomepageButton.Size = new System.Drawing.Size(109, 26);
            this.setHomepageButton.TabIndex = 8;
            this.setHomepageButton.Text = "Set Homepage";
            this.setHomepageButton.UseVisualStyleBackColor = true;
            this.setHomepageButton.Click += new System.EventHandler(this.setHomepageButton_Click);
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.urlTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.urlTextBox.FormattingEnabled = true;
            this.urlTextBox.Location = new System.Drawing.Point(50, 10);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(543, 21);
            this.urlTextBox.TabIndex = 1;
            // 
            // Noscape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(722, 526);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.setHomepageButton);
            this.Controls.Add(this.currentPageLabel);
            this.Controls.Add(this.homepageButton);
            this.Controls.Add(this.loadUrlButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toggleFavouriteButton);
            this.Controls.Add(this.historyButton);
            this.Controls.Add(this.favouritesButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.htmlTextBox);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(738, 565);
            this.Name = "Noscape";
            this.Text = "Noscape";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel pageStatusLabel;
        private System.Windows.Forms.TextBox htmlTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button favouritesButton;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.Button toggleFavouriteButton;
        private System.Windows.Forms.Button loadUrlButton;
        private System.Windows.Forms.Button homepageButton;
        private System.Windows.Forms.Label currentPageLabel;
        private System.Windows.Forms.Button setHomepageButton;
        private System.Windows.Forms.ComboBox urlTextBox;
        private System.Windows.Forms.ToolStripProgressBar tspBar;
    }
}

