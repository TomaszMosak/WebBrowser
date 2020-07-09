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
    class History {

        public DoublyLinkedList<DateTime, string> history = new DoublyLinkedList<DateTime, string>();//New instance of a DLL for the history
        public DoublyLinkedList<DateTime, string> sessionHistory = new DoublyLinkedList<DateTime, string>();//New instance of a DLL for the session history. Needed for forward/backward functions
        private static string HistoryFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "history.txt");

        public History() {
        }

        #region History

        /// <summary>
        /// Adds every visted webpage to a history double linked list and stored in a file incase application is closed (storage)
        /// </summary>
        /// <param name="URL">The address of the webpage visited</param>
        public void HistoryAdd(string URL) {
            DateTime timestamp = DateTime.Now;
            history.Insert(timestamp, URL);
            TextWriter tw = new StreamWriter(HistoryFile, append: true);
            tw.WriteLine("{0}|{1}", timestamp, URL);
            tw.Close();
            sessionHistory.Insert(timestamp, URL);
        }

        /// <summary>
        /// Reloads the content of the history file into the DLL to "reload" the history
        /// </summary>
        public void ReloadHistory() {
            history.Clear();
            StreamReader sr = new StreamReader(HistoryFile);
            while (!sr.EndOfStream) {
                string[] entry = sr.ReadLine().Split('|');
                DateTime timestamp = DateTime.Parse(entry[0]);
                string URL = entry[1];

                /*This if statement makes sure that the key is always unique incase the user reloads or loads a new page within the same second*/
                if (!history.ContainsKey(timestamp)) {
                    history.Insert(timestamp, URL);
                } else {
                    timestamp = timestamp.AddSeconds(1);
                    history.Insert(timestamp, URL);
                }
            }
            sr.Close();
        }

        /// <summary>
        /// Clears the history DLL but also makes sure that the history file is reset back to empty
        /// </summary>
        public void HistoryClear() {
            history.Clear();
            
            using (FileStream fs = File.Open(HistoryFile, FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
                lock (fs) {
                    fs.SetLength(0);
                }
            }

            #endregion
        }
    }
 }



    