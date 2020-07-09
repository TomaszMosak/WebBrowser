namespace WebBrowser {
    partial class WebForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.GoBtn = new System.Windows.Forms.Button();
            this.DisplayTxt = new System.Windows.Forms.TextBox();
            this.URLtxt = new System.Windows.Forms.TextBox();
            this.BackBtn = new System.Windows.Forms.Button();
            this.ForwardBtn = new System.Windows.Forms.Button();
            this.HistoryBtn = new System.Windows.Forms.Button();
            this.FavouritesBtn = new System.Windows.Forms.Button();
            this.AddFavBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GoBtn
            // 
            this.GoBtn.Location = new System.Drawing.Point(545, 13);
            this.GoBtn.Name = "GoBtn";
            this.GoBtn.Size = new System.Drawing.Size(57, 23);
            this.GoBtn.TabIndex = 0;
            this.GoBtn.Text = "Go!";
            this.GoBtn.UseVisualStyleBackColor = true;
            this.GoBtn.Click += new System.EventHandler(this.GoBtn_Click);
            // 
            // DisplayTxt
            // 
            this.DisplayTxt.Location = new System.Drawing.Point(90, 41);
            this.DisplayTxt.Multiline = true;
            this.DisplayTxt.Name = "DisplayTxt";
            this.DisplayTxt.Size = new System.Drawing.Size(512, 312);
            this.DisplayTxt.TabIndex = 1;
            // 
            // URLtxt
            // 
            this.URLtxt.Location = new System.Drawing.Point(275, 14);
            this.URLtxt.Name = "URLtxt";
            this.URLtxt.Size = new System.Drawing.Size(264, 20);
            this.URLtxt.TabIndex = 2;
            this.URLtxt.TextChanged += new System.EventHandler(this.URLtxt_TextChanged);
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(90, 13);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(35, 23);
            this.BackBtn.TabIndex = 3;
            this.BackBtn.Text = "<----";
            this.BackBtn.UseVisualStyleBackColor = true;
            // 
            // ForwardBtn
            // 
            this.ForwardBtn.Location = new System.Drawing.Point(131, 13);
            this.ForwardBtn.Name = "ForwardBtn";
            this.ForwardBtn.Size = new System.Drawing.Size(35, 23);
            this.ForwardBtn.TabIndex = 4;
            this.ForwardBtn.Text = "---->";
            this.ForwardBtn.UseVisualStyleBackColor = true;
            // 
            // HistoryBtn
            // 
            this.HistoryBtn.Location = new System.Drawing.Point(12, 41);
            this.HistoryBtn.Name = "HistoryBtn";
            this.HistoryBtn.Size = new System.Drawing.Size(72, 43);
            this.HistoryBtn.TabIndex = 5;
            this.HistoryBtn.Text = "Display History";
            this.HistoryBtn.UseVisualStyleBackColor = true;
            // 
            // FavouritesBtn
            // 
            this.FavouritesBtn.Location = new System.Drawing.Point(12, 90);
            this.FavouritesBtn.Name = "FavouritesBtn";
            this.FavouritesBtn.Size = new System.Drawing.Size(72, 43);
            this.FavouritesBtn.TabIndex = 6;
            this.FavouritesBtn.Text = "View Favourites";
            this.FavouritesBtn.UseVisualStyleBackColor = true;
            // 
            // AddFavBtn
            // 
            this.AddFavBtn.Location = new System.Drawing.Point(172, 13);
            this.AddFavBtn.Name = "AddFavBtn";
            this.AddFavBtn.Size = new System.Drawing.Size(97, 23);
            this.AddFavBtn.TabIndex = 7;
            this.AddFavBtn.Text = "Favourite This";
            this.AddFavBtn.UseVisualStyleBackColor = true;
            // 
            // WebForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 365);
            this.Controls.Add(this.AddFavBtn);
            this.Controls.Add(this.FavouritesBtn);
            this.Controls.Add(this.HistoryBtn);
            this.Controls.Add(this.ForwardBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.URLtxt);
            this.Controls.Add(this.DisplayTxt);
            this.Controls.Add(this.GoBtn);
            this.Name = "WebForm";
            this.Text = "Web Browser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GoBtn;
        private System.Windows.Forms.TextBox DisplayTxt;
        private System.Windows.Forms.TextBox URLtxt;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button ForwardBtn;
        private System.Windows.Forms.Button HistoryBtn;
        private System.Windows.Forms.Button FavouritesBtn;
        private System.Windows.Forms.Button AddFavBtn;
    }
}

