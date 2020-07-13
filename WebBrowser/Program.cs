using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;


    namespace WebBrowser {
    class Program {

        Dictionary<string, string> favourites = new Dictionary<string, string>();
        Dictionary<DateTime, string> history = new Dictionary<DateTime, string>();
        private static string FavouritesFile = "favourites.txt";
        private static string HistoryFile = "history.txt";

        [STAThread]
        static void Main() {
            new Program();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WebForm());
        }
        public Program() {
            HandleFiles();
            ReloadFavourites();
            ReloadHistory();
            string URL = "http://www.google.com";
            bool validURL = InvalidURL(ref URL);
            Console.WriteLine((validURL) ? "INFO: VALID URL" : "INFO: INVALID URL");
            HTTPRequest(URL);
            FavouritesAdd("google", URL);
            URL = "http://www.webreimagined.co.uk/SafeBox/index.html";
            FavouritesAdd("safebox", URL);
            HTTPRequest(URL);
            PrintHistory();
            PrintFavourites();
            Console.ReadLine();
        }

        /// <summary>
        /// Makes sure that the Favourites/History files are created locally
        /// </summary>
        private void HandleFiles() {
            string[] fileNames = { FavouritesFile, HistoryFile };
            foreach (string file in fileNames) {
                
                if (!System.IO.File.Exists(file)) {
                   File.Create(file).Dispose();
                } else if (System.IO.File.Exists(file)) {
                    Console.WriteLine("File: {0} already exists", file);
                }
            }
            return;
        }

        #region URL Handling
        /// <summary>
        /// Makes sure that the URL input is of correct format - http://www.WEBPAGE.DOMAIN
        /// </summary>
        /// <param name="URL">The url input</param>
        /// <returns>correctly formatted URL string</returns>
        private bool InvalidURL(ref string URL) {
            if (URL.Contains("http://www.") || URL.Contains("https://www.")) {
                return Uri.IsWellFormedUriString(URL, UriKind.Absolute);
            } else if (URL.Contains("www.")) {
                URL = "http://" + URL;
            } else if (URL.Contains("http://") || URL.Contains("https://")) {
                URL = "http://www." + URL; //------------------------------------------------ PROBABLY WRONG. COME BACK TO ME
            } else {
                URL = "http://www." + URL;
            }
            return Uri.IsWellFormedUriString(URL, UriKind.Absolute);
        }

        /// <summary>
        /// Reads each line of the URL
        /// </summary>
        /// <param name="datastream">content of the URL</param>
        /// <returns>HTML code</returns>
        private string DecodeString(Stream datastream) {
            StreamReader sr = new StreamReader(datastream);
            string htmlstring = "";
            while (!sr.EndOfStream) {
                htmlstring += String.Format("{0}\r\n", sr.ReadLine());
            }
            sr.Close();
            return htmlstring;
        }
        #endregion

        #region History

        /// <summary>
        /// Adds every visted webpage to a history list and stored in a file incase application is closed (storage)
        /// </summary>
        /// <param name="URL">The address of the webpage visited</param>
        private void HistoryAdd (string URL) {
            DateTime timestamp = DateTime.Now;
            history.Add(timestamp, URL);
            TextWriter tw = new StreamWriter(HistoryFile, append: true);
            tw.WriteLine("{0}|{1}", timestamp, URL);
            tw.Close();
        }

        /// <summary>
        /// Reloads the content of the history file into the dictionary to "reload" the history
        /// </summary>
        private void ReloadHistory () {
            history.Clear();
            StreamReader sr = new StreamReader(HistoryFile);
            while (!sr.EndOfStream) {
                string[] entry = sr.ReadLine().Split('|');
                DateTime timestamp = DateTime.Parse(entry[0]);
                string URL = entry[1];

                /*This if statement makes sure that the key is always unique incase the user reloads or loads a new page within the same second*/
                if (!history.ContainsKey(timestamp)) {
                    history.Add(timestamp, URL);
                } else {
                    timestamp = timestamp.AddSeconds(1);
                    history.Add(timestamp, URL);
                }
            }
            sr.Close();
        }

        /// <summary>
        /// Displays the content of the History Dictionary --- Mostly used for debugging
        /// </summary>
        public void PrintHistory() {
            Console.WriteLine("Printing History...");
            foreach (KeyValuePair<DateTime, string> entry in history){
                Console.WriteLine("Time: {0}, WebPage: {1}", entry.Key, entry.Value);
            }
        }

        #endregion

        #region Favourites

        /// <summary>
        /// This function adds a new favourites page to the dictionary but also the file responsible for holding all favourites
        /// </summary>
        /// <param name="title">The name of the webpage</param>
        /// <param name="URL">The address of the webpage</param>
        public void FavouritesAdd(string title, string URL) {
            if (favourites.ContainsKey(title)) {
                Console.WriteLine("DUPLICATE ERROR: Favourites already contains: {0}", title);
                return;
            } else if (favourites.ContainsValue(URL)) {
                Console.WriteLine("DUPLICATE ERROR: Favourites already contains: {0}", URL);
                return;
            }
            favourites.Add(title, URL);
            StreamWriter sw = new StreamWriter(FavouritesFile, append: true);
            sw.WriteLine("{0}|{1}", title, URL);
            sw.Close();
        }

        /// <summary>
        /// This founction reloads the favourites dictionary from the stored favourites file upon reloading the program
        /// </summary>
        public void ReloadFavourites() {
            try {
                StreamReader sr = new StreamReader(FavouritesFile);
                while (!sr.EndOfStream) {
                    string[] entry = sr.ReadLine().Split('|');
                    string title = entry[0];
                    string URL = entry[1];
                    if (favourites.ContainsKey(title)) {
                        Console.WriteLine("DUPLICATE ERROR: Favourites already contains: {0}", title);
                        continue;
                    } else if (favourites.ContainsValue(URL)) {
                        Console.WriteLine("DUPLICATE ERROR: Favourites already contains: {0}", URL);
                        continue;
                    }
                    favourites.Add(title, URL);
                }
                sr.Close();
            } catch {

            }
        }

        /// <summary>
        /// Displays the content of the Favourites Dictionary --- Mostly used for debugging
        /// </summary>
        public void PrintFavourites() {
            Console.WriteLine("Printing Favourites...");
            foreach (KeyValuePair<string, string> entry in favourites) {
                Console.WriteLine("Title: {0}, WebPage: {1}", entry.Key, entry.Value);
            }
        }

        #endregion
        /// <summary>
        /// Gets HTML from website and handle http status code errors
        /// </summary>
        /// <param name="URL">Website to request HTML from</param>
        private string HTTPRequest(string URL) {
            string htmlstring = ""; //hold the value of the URL
            try {
                WebRequest request = WebRequest.Create(URL);
                WebResponse response = request.GetResponse();
                HttpWebResponse webResponse = (HttpWebResponse)response;

                switch (webResponse.StatusCode) {
                    case (HttpStatusCode.OK): {
                            Stream dataStream = response.GetResponseStream();
                            htmlstring = DecodeString(dataStream);
                            HistoryAdd(URL);
                            
                            response.Close();
                            return htmlstring;
                        }
                    case (HttpStatusCode.BadRequest): {
                            htmlstring = String.Format("ERROR 400: Bad Request from: {0}", URL);
                            break;
                        }
                    case (HttpStatusCode.NotFound): {
                            htmlstring = String.Format("ERROR 404: URL: {0} Not Found", URL);
                            break;
                        }
                    case (HttpStatusCode.Forbidden): {
                            htmlstring = String.Format("ERROR 403: Forbidden from: {0}", URL);
                            break;
                        }
                    case (HttpStatusCode.BadGateway): {
                            htmlstring = String.Format("ERROR 502: Bad Gateway from: {0}", URL);
                            break;
                        }
                }
                return htmlstring;
            } catch (WebException e) {
                HttpWebResponse eResponse = e.Response as HttpWebResponse;
                if (eResponse == null) {
                    htmlstring = "ERROR: No connection recognised";
                    return htmlstring;
                }
            }
            return htmlstring;
            } 
        }
    }