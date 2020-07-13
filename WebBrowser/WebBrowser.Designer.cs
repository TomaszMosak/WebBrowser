namespace WebBrowser {
    partial class WebFormBrowser {
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
            this.components = new System.ComponentModel.Container();
            this.GoBtn = new System.Windows.Forms.Button();
            this.DisplayTxt = new System.Windows.Forms.TextBox();
            this.BackBtn = new System.Windows.Forms.Button();
            this.ForwardBtn = new System.Windows.Forms.Button();
            this.AddFavBtn = new System.Windows.Forms.Button();
            this.FavouritesBtn = new System.Windows.Forms.Button();
            this.HistoryBtn = new System.Windows.Forms.Button();
            this.URLtxt = new System.Windows.Forms.TextBox();
            this.LtbItems = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.menuHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuClearHist = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelHist = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFavourites = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuClearFav = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelFav = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHome = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSetHome = new System.Windows.Forms.ToolStripMenuItem();
            this.labelStatus = new System.Windows.Forms.Label();
            this.menuHistory.SuspendLayout();
            this.menuFavourites.SuspendLayout();
            this.menuHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // GoBtn
            // 
            this.GoBtn.Location = new System.Drawing.Point(656, 23);
            this.GoBtn.Name = "GoBtn";
            this.GoBtn.Size = new System.Drawing.Size(57, 23);
            this.GoBtn.TabIndex = 0;
            this.GoBtn.Text = "Go!";
            this.GoBtn.UseVisualStyleBackColor = true;
            this.GoBtn.Click += new System.EventHandler(this.GoBtn_Click);
            // 
            // DisplayTxt
            // 
            this.DisplayTxt.Location = new System.Drawing.Point(90, 55);
            this.DisplayTxt.Multiline = true;
            this.DisplayTxt.Name = "DisplayTxt";
            this.DisplayTxt.Size = new System.Drawing.Size(694, 368);
            this.DisplayTxt.TabIndex = 1;
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(90, 24);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(62, 23);
            this.BackBtn.TabIndex = 3;
            this.BackBtn.Text = "<----";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // ForwardBtn
            // 
            this.ForwardBtn.Location = new System.Drawing.Point(158, 23);
            this.ForwardBtn.Name = "ForwardBtn";
            this.ForwardBtn.Size = new System.Drawing.Size(62, 23);
            this.ForwardBtn.TabIndex = 4;
            this.ForwardBtn.Text = "---->";
            this.ForwardBtn.UseVisualStyleBackColor = true;
            this.ForwardBtn.Click += new System.EventHandler(this.ForwardBtn_Click);
            // 
            // AddFavBtn
            // 
            this.AddFavBtn.ContextMenuStrip = this.menuFavourites;
            this.AddFavBtn.Location = new System.Drawing.Point(226, 23);
            this.AddFavBtn.Name = "AddFavBtn";
            this.AddFavBtn.Size = new System.Drawing.Size(64, 23);
            this.AddFavBtn.TabIndex = 7;
            this.AddFavBtn.Text = "Favourite!";
            this.AddFavBtn.UseVisualStyleBackColor = true;
            this.AddFavBtn.Click += new System.EventHandler(this.AddFavBtn_Click);
            // 
            // FavouritesBtn
            // 
            this.FavouritesBtn.ContextMenuStrip = this.menuFavourites;
            this.FavouritesBtn.Location = new System.Drawing.Point(12, 54);
            this.FavouritesBtn.Name = "FavouritesBtn";
            this.FavouritesBtn.Size = new System.Drawing.Size(72, 43);
            this.FavouritesBtn.TabIndex = 6;
            this.FavouritesBtn.Text = "View Favourites";
            this.FavouritesBtn.UseVisualStyleBackColor = true;
            this.FavouritesBtn.Click += new System.EventHandler(this.FavouritesBtn_Click);
            // 
            // HistoryBtn
            // 
            this.HistoryBtn.ContextMenuStrip = this.menuHistory;
            this.HistoryBtn.Location = new System.Drawing.Point(12, 103);
            this.HistoryBtn.Name = "HistoryBtn";
            this.HistoryBtn.Size = new System.Drawing.Size(72, 43);
            this.HistoryBtn.TabIndex = 5;
            this.HistoryBtn.Text = "Display History";
            this.HistoryBtn.UseVisualStyleBackColor = true;
            this.HistoryBtn.Click += new System.EventHandler(this.HistoryBtn_Click);
            // 
            // URLtxt
            // 
            this.URLtxt.Location = new System.Drawing.Point(296, 25);
            this.URLtxt.Name = "URLtxt";
            this.URLtxt.Size = new System.Drawing.Size(354, 20);
            this.URLtxt.TabIndex = 2;
            this.URLtxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Urltxt_request);
            // 
            // LtbItems
            // 
            this.LtbItems.FormattingEnabled = true;
            this.LtbItems.Location = new System.Drawing.Point(90, 55);
            this.LtbItems.MultiColumn = true;
            this.LtbItems.Name = "LtbItems";
            this.LtbItems.Size = new System.Drawing.Size(694, 368);
            this.LtbItems.TabIndex = 8;
            this.LtbItems.Visible = false;
            this.LtbItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LbtItems_Selected);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(72, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnHome
            // 
            this.btnHome.ContextMenuStrip = this.menuHome;
            this.btnHome.Location = new System.Drawing.Point(719, 23);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(65, 22);
            this.btnHome.TabIndex = 14;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // menuHistory
            // 
            this.menuHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClearHist,
            this.menuDelHist});
            this.menuHistory.Name = "menuHistory";
            this.menuHistory.Size = new System.Drawing.Size(143, 48);
            // 
            // menuClearHist
            // 
            this.menuClearHist.Name = "menuClearHist";
            this.menuClearHist.Size = new System.Drawing.Size(142, 22);
            this.menuClearHist.Text = "Clear History";
            this.menuClearHist.Click += new System.EventHandler(this.clearHist_Click);
            // 
            // menuDelHist
            // 
            this.menuDelHist.Name = "menuDelHist";
            this.menuDelHist.Size = new System.Drawing.Size(142, 22);
            this.menuDelHist.Text = "Delete Entry";
            this.menuDelHist.Click += new System.EventHandler(this.delHist_Click);
            // 
            // menuFavourites
            // 
            this.menuFavourites.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClearFav,
            this.menuDelFav});
            this.menuFavourites.Name = "menuFavourites";
            this.menuFavourites.Size = new System.Drawing.Size(160, 48);
            // 
            // menuClearFav
            // 
            this.menuClearFav.Name = "menuClearFav";
            this.menuClearFav.Size = new System.Drawing.Size(159, 22);
            this.menuClearFav.Text = "Clear Favourites";
            this.menuClearFav.Click += new System.EventHandler(this.clearFav_Click);
            // 
            // menuDelFav
            // 
            this.menuDelFav.Name = "menuDelFav";
            this.menuDelFav.Size = new System.Drawing.Size(159, 22);
            this.menuDelFav.Text = "Delete Favourite";
            this.menuDelFav.Click += new System.EventHandler(this.delFav_Click);
            // 
            // menuHome
            // 
            this.menuHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSetHome});
            this.menuHome.Name = "menuHome";
            this.menuHome.Size = new System.Drawing.Size(141, 26);
            // 
            // menuSetHome
            // 
            this.menuSetHome.Name = "menuSetHome";
            this.menuSetHome.Size = new System.Drawing.Size(140, 22);
            this.menuSetHome.Text = "Set as Home";
            this.menuSetHome.Click += new System.EventHandler(this.menuSetHome_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 9);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(65, 13);
            this.labelStatus.TabIndex = 20;
            this.labelStatus.Text = "Status Code";
            // 
            // WebFormBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 433);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.LtbItems);
            this.Controls.Add(this.AddFavBtn);
            this.Controls.Add(this.FavouritesBtn);
            this.Controls.Add(this.HistoryBtn);
            this.Controls.Add(this.ForwardBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.URLtxt);
            this.Controls.Add(this.DisplayTxt);
            this.Controls.Add(this.GoBtn);
            this.Name = "WebFormBrowser";
            this.Text = "Web Browser";
            this.Load += new System.EventHandler(this.WebForm_Load);
            this.menuHistory.ResumeLayout(false);
            this.menuFavourites.ResumeLayout(false);
            this.menuHome.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GoBtn;
        private System.Windows.Forms.TextBox DisplayTxt;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button ForwardBtn;
        private System.Windows.Forms.Button AddFavBtn;
        private System.Windows.Forms.Button FavouritesBtn;
        private System.Windows.Forms.Button HistoryBtn;
        private System.Windows.Forms.TextBox URLtxt;
        private System.Windows.Forms.ListBox LtbItems;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.ContextMenuStrip menuHistory;
        private System.Windows.Forms.ToolStripMenuItem menuClearHist;
        private System.Windows.Forms.ToolStripMenuItem menuDelHist;
        private System.Windows.Forms.ContextMenuStrip menuFavourites;
        private System.Windows.Forms.ToolStripMenuItem menuClearFav;
        private System.Windows.Forms.ToolStripMenuItem menuDelFav;
        private System.Windows.Forms.ContextMenuStrip menuHome;
        private System.Windows.Forms.ToolStripMenuItem menuSetHome;
        private System.Windows.Forms.Label labelStatus;
    }
}

