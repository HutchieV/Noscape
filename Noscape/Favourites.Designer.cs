namespace Noscape
{
    partial class FavouritesWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavouritesWindow));
            this.favouritesListBox = new System.Windows.Forms.ListBox();
            this.removeFavourite = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.favouritesCloseButton = new System.Windows.Forms.Button();
            this.modifyFavouriteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // favouritesListBox
            // 
            this.favouritesListBox.FormattingEnabled = true;
            this.favouritesListBox.Location = new System.Drawing.Point(8, 26);
            this.favouritesListBox.Name = "favouritesListBox";
            this.favouritesListBox.Size = new System.Drawing.Size(439, 368);
            this.favouritesListBox.TabIndex = 0;
            // 
            // removeFavourite
            // 
            this.removeFavourite.Location = new System.Drawing.Point(8, 440);
            this.removeFavourite.Name = "removeFavourite";
            this.removeFavourite.Size = new System.Drawing.Size(144, 28);
            this.removeFavourite.TabIndex = 1;
            this.removeFavourite.Text = "Remove from Favourites";
            this.removeFavourite.UseVisualStyleBackColor = true;
            this.removeFavourite.Click += new System.EventHandler(this.removeFavourite_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Favourites";
            // 
            // favouritesCloseButton
            // 
            this.favouritesCloseButton.Location = new System.Drawing.Point(353, 440);
            this.favouritesCloseButton.Name = "favouritesCloseButton";
            this.favouritesCloseButton.Size = new System.Drawing.Size(92, 28);
            this.favouritesCloseButton.TabIndex = 3;
            this.favouritesCloseButton.Text = "Close";
            this.favouritesCloseButton.UseVisualStyleBackColor = true;
            this.favouritesCloseButton.Click += new System.EventHandler(this.favouritesCloseButton_Click);
            // 
            // modifyFavouriteButton
            // 
            this.modifyFavouriteButton.Enabled = false;
            this.modifyFavouriteButton.Location = new System.Drawing.Point(8, 405);
            this.modifyFavouriteButton.Name = "modifyFavouriteButton";
            this.modifyFavouriteButton.Size = new System.Drawing.Size(144, 28);
            this.modifyFavouriteButton.TabIndex = 4;
            this.modifyFavouriteButton.Text = "Modify Favourite";
            this.modifyFavouriteButton.UseVisualStyleBackColor = true;
            this.modifyFavouriteButton.Click += new System.EventHandler(this.modifyFavouriteButton_Click);
            // 
            // FavouritesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 479);
            this.Controls.Add(this.modifyFavouriteButton);
            this.Controls.Add(this.favouritesCloseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeFavourite);
            this.Controls.Add(this.favouritesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FavouritesWindow";
            this.Text = "Noscape: Favourites";
            this.Load += new System.EventHandler(this.favouritesWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox favouritesListBox;
        private System.Windows.Forms.Button removeFavourite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button favouritesCloseButton;
        private System.Windows.Forms.Button modifyFavouriteButton;
    }
}