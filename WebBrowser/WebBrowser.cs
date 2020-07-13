using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser {
    public partial class WebFormBrowser : Form {

        WebHandle WebHandle;
        Favourites Fav;
        History Hist;
        Home home;

        public int sessionPageNo;

        /// <summary>
        /// Initialization of classes
        /// </summary>
        public WebFormBrowser() {
            InitializeComponent();
            WebHandle = new WebHandle();
            Fav = new Favourites();
            Hist = new History();
            home = new Home();
            
        }

        /// <summary>
        /// This function takes care of the repetative function calls that redirecting to a new page requires.
        /// </summary>
        private void DisplayPage() {
            string URL = URLtxt.Text;
            WebHandle.InvalidURL(ref URL);
            string htmlstring = WebHandle.HTTPRequest(URL);
            DisplayTxt.Text = htmlstring;
            labelStatus.Text = String.Format("{0} | {1}", WebHandle.GetStatusCode, WebHandle.GetTitle(htmlstring));
            Hist.HistoryAdd(URL);
            URLtxt.Text = URL;
           
        }

        /// <summary>
        /// Upon pressing the Go button the DisplayPage function is called
        /// </summary>
        private void GoBtn_Click(object sender, EventArgs e) {
            LtbItems.Hide();
            DisplayTxt.Show();
            DisplayPage();
        }
        /// <summary>
        /// Closely related to GoBtn_Click but for pressing the Enter key
        /// </summary>
        private void Urltxt_request(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                LtbItems.Hide();
                DisplayTxt.Show();
                DisplayPage();
                e.Handled = true;
                e.SuppressKeyPress = true; //Prevents windows noise on ENTER keydown

            }
        }

        /// <summary>
        /// When the Browser is first loaded this is called. It makes sure that all the files were read to populate the DLL's and the homepage is shown
        /// </summary>
        private void WebForm_Load(object sender, EventArgs e) {
            DisplayTxt.Show();
            WebHandle.HandleFiles();
            Fav.ReloadFavourites();
            Hist.ReloadHistory();
            home.ReloadHome();
            string htmlstring = WebHandle.HTTPRequest(home.GetHome());
            Hist.sessionHistory.Insert(DateTime.Now, home.GetHome());
            DisplayTxt.Text = htmlstring;
            labelStatus.Text = String.Format("{0} | {1}", WebHandle.GetStatusCode, WebHandle.GetTitle(htmlstring));
            
            URLtxt.Text = home.GetHome();
        }

        /// <summary>
        /// Allows the user to add a new favourite
        /// </summary>
        private void AddFavBtn_Click(object sender, EventArgs e) {
            DisplayTxt.Clear();
            DisplayTxt.Show();
            string URL = URLtxt.Text;
            WebHandle.InvalidURL(ref URL);
            string htmlstring = WebHandle.HTTPRequest(URL);
            string title = WebHandle.GetTitle(htmlstring);
            DisplayTxt.Text = Fav.FavouritesAdd(title, URL);
        }

        /// <summary>
        /// Displays the Favourites list in a ListBox if the user has at least 1 favourite URL saved.
        /// </summary>
        private void FavouritesBtn_Click(object sender, EventArgs e) {
            LtbItems.ContextMenuStrip = menuFavourites;
            if (Fav.favourites.Count != 0) {
                LtbItems.Show();
                LtbItems.Items.Clear();
               
                for (int i = 0; i < Fav.favourites.Count; i++) {
                    LtbItems.Items.Add(String.Format("Title  |{0}, WebPage  |{1}", Fav.favourites[i].GetData.Item1, Fav.favourites[i].GetData.Item2));
                }
            } else {
                LtbItems.Hide();
                DisplayTxt.Clear();
                DisplayTxt.Text = "You don't have any favourites yet! Press the 'Favourite!' Button to add the currert URL as a favourite.";
            }
        }

        /// <summary>
        /// Displays the History list in a ListBox if the user has at least 1 history URL on record.
        /// </summary>
        private void HistoryBtn_Click(object sender, EventArgs e) {
            LtbItems.ContextMenuStrip = menuHistory;
            if (Hist.history.Count != 0) {
                LtbItems.Show();
                LtbItems.Items.Clear();
               
                for (int i = 0; i < Hist.history.Count; i++) {
                    LtbItems.Items.Add(String.Format("Time Accessed  |{0}, WebPage  |{1}", Hist.history[i].GetData.Item1 , Hist.history[i].GetData.Item2));
                }
            } else {
                DisplayTxt.Clear();
                DisplayTxt.Text = "You just cleared the history. Try typing something in the textbox above to start making your new history feed!";
            }
        }

        /// <summary>
        /// If the user double clicks a URL in the ListBox, it will display that page
        /// </summary>
        private void LbtItems_Selected(object sender, MouseEventArgs e) {
            string Item = LtbItems.SelectedItem.ToString();
            string[] sub = Item.Split('|');
            string currItem = sub[2];
            currItem.Trim();
            DisplayTxt.Text = WebHandle.HTTPRequest(currItem);
            URLtxt.Clear();
            URLtxt.Text = currItem;
            LtbItems.Items.Clear();
            LtbItems.Hide();
        }

        /// <summary>
        /// Sends another HTTP request to the currently displaying URL
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e) {
            LtbItems.Hide();
            string URL = URLtxt.Text;
            DisplayTxt.Text = WebHandle.HTTPRequest(URL);
        }

        /// <summary>
        /// Takes the user to the homepage
        /// </summary>
        private void btnHome_Click(object sender, EventArgs e) {
            LtbItems.Hide();
            URLtxt.Text = home.GetHome();
            DisplayPage();
        }

        /// <summary>
        /// Takes the user to the previously visited URL
        /// </summary>
        private void BackBtn_Click(object sender, EventArgs e) {
            
        }

        /// <summary>
        /// Takes the user one URL forward if there is one
        /// </summary>
        private void ForwardBtn_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// Clears the entire favourites DLL & File
        /// </summary>
        private void clearFav_Click(object sender, EventArgs e) {
            LtbItems.Items.Clear();
            LtbItems.Hide();
            DisplayTxt.Clear();
            Fav.FavClear();
            DisplayTxt.Text = "Favourites Cleared Successfully";
        }

        /// <summary>
        /// Deletes the selected favourites entry
        /// </summary>
        private void delFav_Click(object sender, EventArgs e) {
            int DelIndex = LtbItems.SelectedIndex;
            if (Fav.favourites.Count > 1) {
                Fav.favourites.Remove(DelIndex);
                LtbItems.Items.Remove(LtbItems.SelectedItem);
            } else {
                LtbItems.Items.Clear();
                Fav.FavClear();
                DisplayTxt.Text = "All Favourites Deleted Successfully";
                LtbItems.Hide();
            }
        }

        /// <summary>
        /// Deletes the selected history entry
        /// </summary>
        private void delHist_Click(object sender, EventArgs e) {
            int DelIndex = LtbItems.SelectedIndex;
            if (Hist.history.Count > 1) {
                Hist.history.Remove(DelIndex);
                LtbItems.Items.Remove(LtbItems.SelectedItem);
            } else {
                LtbItems.Items.Clear();
                Hist.HistoryClear();
                DisplayTxt.Text = "Each History Entry Deleted Successfully";
                LtbItems.Hide();
            }
        }

        /// <summary>
        /// Clears the entire history DLL & File
        /// </summary>
        private void clearHist_Click(object sender, EventArgs e) {
            LtbItems.Items.Clear();
            LtbItems.Hide();
            DisplayTxt.Clear();
            Hist.HistoryClear();
            DisplayTxt.Text = "History Cleared Successfully";
        }

        /// <summary>
        /// Sets the current URL to the homepage
        /// </summary>
        private void menuSetHome_Click(object sender, EventArgs e) {
            home.HomeChange(URLtxt.Text);
            DisplayTxt.Clear();
            string title = WebHandle.GetTitle(WebHandle.HTTPRequest(URLtxt.Text));
            DisplayTxt.Text = String.Format("New Homepage set to: {0}", title);
        }
    }
}
