using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WebBrowser {
    class Home {

        public string HomeURL = null; //stores the URL of the homepage for the session
        private static string HomeFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "home.txt"); //filepath for the homepage URL.

        public Home() {
          
        }

        /// <summary>
        /// Changes the HomeURL to the current URL and writes it to a file (memory)
        /// </summary>
        /// <param name="URL">The address to the webpage</param>
        public void HomeChange(string URL) {
            HomeURL = URL;
            TextWriter tw = new StreamWriter(HomeFile, append: true);
            tw.WriteLine("{0}", HomeURL);
            tw.Close();
        }

        /// <summary>
        /// Reads the content of the file searching for a custom homepage or sets it to google if there isn't one
        /// </summary>
        public void ReloadHome() {
            StreamReader sr = new StreamReader(HomeFile);
            while (!sr.EndOfStream) {
                HomeURL = sr.ReadLine();
            }
            if (HomeURL == null) {
                HomeURL = "http://www.google.com";
            }
            sr.Close();
        }

        /// <summary>
        /// Self Explanatory
        /// </summary>
        /// <returns>The URL string stored in the HomeURL string</returns>
        public string GetHome() {
            return HomeURL;
        }
    }

}
