namespace Noscape
{
    partial class ModifyFavouriteWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyFavouriteWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.modifyFURLBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.modifyFNameBox = new System.Windows.Forms.TextBox();
            this.modifyFCancelButton = new System.Windows.Forms.Button();
            this.modifyFOkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL:";
            // 
            // modifyFURLBox
            // 
            this.modifyFURLBox.Enabled = false;
            this.modifyFURLBox.Location = new System.Drawing.Point(12, 29);
            this.modifyFURLBox.Name = "modifyFURLBox";
            this.modifyFURLBox.Size = new System.Drawing.Size(326, 20);
            this.modifyFURLBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Custom Name:";
            // 
            // modifyFNameBox
            // 
            this.modifyFNameBox.Location = new System.Drawing.Point(12, 84);
            this.modifyFNameBox.Name = "modifyFNameBox";
            this.modifyFNameBox.Size = new System.Drawing.Size(326, 20);
            this.modifyFNameBox.TabIndex = 3;
            // 
            // modifyFCancelButton
            // 
            this.modifyFCancelButton.Location = new System.Drawing.Point(263, 133);
            this.modifyFCancelButton.Name = "modifyFCancelButton";
            this.modifyFCancelButton.Size = new System.Drawing.Size(75, 23);
            this.modifyFCancelButton.TabIndex = 4;
            this.modifyFCancelButton.Text = "Cancel";
            this.modifyFCancelButton.UseVisualStyleBackColor = true;
            this.modifyFCancelButton.Click += new System.EventHandler(this.modifyFCancelButton_Click);
            // 
            // modifyFOkButton
            // 
            this.modifyFOkButton.Location = new System.Drawing.Point(182, 133);
            this.modifyFOkButton.Name = "modifyFOkButton";
            this.modifyFOkButton.Size = new System.Drawing.Size(75, 23);
            this.modifyFOkButton.TabIndex = 5;
            this.modifyFOkButton.Text = "Ok";
            this.modifyFOkButton.UseVisualStyleBackColor = true;
            this.modifyFOkButton.Click += new System.EventHandler(this.modifyFOkButton_Click);
            // 
            // ModifyFavouriteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 170);
            this.Controls.Add(this.modifyFOkButton);
            this.Controls.Add(this.modifyFCancelButton);
            this.Controls.Add(this.modifyFNameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modifyFURLBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModifyFavouriteWindow";
            this.Text = "Noscape: Modify Favourite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox modifyFURLBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox modifyFNameBox;
        private System.Windows.Forms.Button modifyFCancelButton;
        private System.Windows.Forms.Button modifyFOkButton;
    }
}