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
    class Favourites {

        public DoublyLinkedList<string, string> favourites = new DoublyLinkedList<string, string>(); //New instance of a DLL for the favourites
        private static string FavouritesFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "favourites.txt"); //file path to the favourites

        public Favourites() {
            
        }

        #region Favourites

        /// <summary>
        /// This function adds a new favourites page to the dictionary but also the file responsible for holding all favourites
        /// Also checks for any duplicates
        /// </summary>
        /// <param name="title">The name of the webpage</param>
        /// <param name="URL">The address of the webpage</param>
        public string FavouritesAdd(string title, string URL) {
            if (favourites.ContainsKey(title)) {
                Console.WriteLine("DUPLICATE ERROR: Favourites already contains: {0}", title);
                string errorString = "ERROR: ";
                title += " Already in the favourites";
                errorString += title;
                return title;
            } else if (favourites.ContainsValue(URL)) {
                Console.WriteLine("DUPLICATE ERROR: Favourites already contains: {0}", URL);
                string errorString = "ERROR: ";
                URL += " Already in the favourites";
                errorString += URL;
                return errorString;
            }
            favourites.Insert(title, URL);
            string success = String.Format("Successfully added {0} to Favourites", title);
            StreamWriter sw = new StreamWriter(FavouritesFile, append: true);
            sw.WriteLine("{0}|{1}", title, URL);
            sw.Close();

            return success;
        }

        /// <summary>
        /// This founction reloads the favourites dictionary from the stored favourites file upon reloading the program
        /// Also checks for any duplicates
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
                    favourites.Insert(title, URL);
                }
                sr.Close();
            } catch {

            }
        }

        /// <summary>
        /// Clears the favourites DLL then goes in the File storing the favourites and deletes them
        /// </summary>
        public void FavClear() {
            favourites.Clear();
            using (FileStream fs = File.Open(FavouritesFile, FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
                lock (fs) {
                    fs.SetLength(0);
                }
            }
        }


#endregion

    }
    }