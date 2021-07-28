using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Noscape
{

    /// <summary>
    /// The main XML database file interface.
    /// Handles all selecting, modifying and deleting of XML history and favourite data.
    /// </summary>
    /// <remarks>
    /// The structure of the XML is as follows:
    /// 
    /// BrowserData
    ///   ┕ Config
    ///       ┕ Homepage
    ///   ┕ History
    ///       ┕ HistoryEntry
    ///       ┕ HistoryEntry
    ///       ┕ ...
    ///   ┕ Favourites
    ///       ┕ FavouritesEntry
    ///       ┕ FavouritesEntry
    ///       ┕ ...
    ///         
    /// </remarks>
    public class DBHandler
    {
        private string DB_FILE = "NoscapeData.xml";                     // Our database filename
        private string DIR = Directory.GetCurrentDirectory() + "\\";    // So we don't have to concat repeatedly
        
        // These represent various parts of the XML database in-memory
        private XElement xml;
        private XElement xmlConfig;
        private XElement xmlHistory;
        private XElement xmlFavourites;

        // This represents the largest IDs currently in
        // use. We track this so we can create new entries with 
        // unique IDs.
        private int HIGHEST_HISTORY_ID;
        private int HIGHEST_FAVOURITE_ID;

        /// <summary>
        /// The database handler's constructor
        /// </summary>
        public DBHandler()
        {
            // Check if the database file already exists
            Console.WriteLine("[DbHandler] Current working directory: " + DIR);
            Console.Write("[DbHandler] Checking if " + DB_FILE + " exists... ");
            if (File.Exists(DIR + DB_FILE))
            {
                Console.WriteLine("yes");
            }
            else
            {
                // If not, generate a new file and populate it
                // with the skeleton of the data structure
                Console.WriteLine("no");
                try
                {
                    //File.Create(DIR + DB_FILE);
                    xml = new XElement("BrowserData");
                    xml.Add(new XElement("Config"));
                    xml.Element("Config").Add(new XElement("Homepage"));
                    xml.Add(new XElement("History"));
                    xml.Add(new XElement("Favourites"));
                    xml.Element("Config").Element("Homepage").SetValue("http://google.com");
                    xml.Save(DIR + DB_FILE);
                    Console.WriteLine("[DbHandler] File created");
                }   
                catch (Exception)
                {
                    Console.WriteLine("[DbHandler] Failed to create file!");
                    throw new System.InvalidOperationException("Could not create database file");
                }
            }

            xml = XElement.Load(DIR + DB_FILE);
            xmlConfig       = xml.Element("Config");
            xmlHistory      = xml.Element("History");
            xmlFavourites   = xml.Element("Favourites");

            // Refresh the HIGHEST_HISTORY_ID and HIGHEST_FAVOURITE_ID
            GetAllHistory();
            Console.WriteLine("[DbHandler] HIGHEST_HISTORY_ID = " + HIGHEST_HISTORY_ID);
            GetAllFavourites();
            Console.WriteLine("[DbHandler] HIGHEST_FAVOURITE_ID = " + HIGHEST_FAVOURITE_ID);
        }

        /* -------------------------------------------------------
         * Homepage Operations
         */

        /// <summary>
        /// Get the configured homepage.
        /// </summary>
        /// <returns>
        /// The homepage URL.
        /// </returns>
        public string GetHomepage()
        {
            return xmlConfig.Element("Homepage").Value;
        }

        /// <summary>
        /// Sets the configured homepage.
        /// </summary>
        /// <param name="url">
        /// The new homepage URL.
        /// </param>
        public void SetHomepage(string url)
        {
            xmlConfig.Element("Homepage").SetValue(url);
            xml.Save(DIR+DB_FILE);
            Console.WriteLine("[DbHandler] Set Homepage to " + url);
        }

        /// <summary>
        /// Checks if the given URL is currently set as the homepage.
        /// </summary>
        /// <param name="url">
        /// The URL to check.
        /// </param>
        /// <returns>
        /// True if the URL matches the homepage URL, false otherwise.
        /// </returns>
        public bool IsHomepage(string url)
        {
            if ((string)xmlConfig.Element("Homepage").Value == url)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* -------------------------------------------------------
         * History Operations
         */

        /// <summary>
        /// Fetch all history entries from the database.
        /// </summary>
        /// <returns>
        /// A list of HistoryEntry which each represent an entry in the history database.
        /// </returns>
        public List<HistoryEntry> GetAllHistory()
        {
            // Create the HistoryEntry list we will return and load the 
            // xml file from the History element
            List<HistoryEntry> heList = new List<HistoryEntry>();

            if (!xmlHistory.HasElements) return heList;

            IEnumerable<XElement> entries =
                from entry in xmlHistory.Elements()
                select entry;
            foreach (XElement entry in entries) {

                // Keep track of the highest ID value we have used, so that
                // we know what the next entry will need to be
                if ((int)entry.Attribute("HistoryEntryId") > HIGHEST_HISTORY_ID) {
                    HIGHEST_HISTORY_ID = (int)entry.Attribute("HistoryEntryId");
                }

                // Add a new HistoryEntry object to the list with the given
                // xml information
                heList.Add(new HistoryEntry(
                    (int)entry.Attribute("HistoryEntryId"),
                    (string)entry.Attribute("URI"),
                    (int)entry.Attribute("Visited")
                    ));
            }

            return heList;
        }

        /// <summary>
        /// Clear/remove all history from the database.
        /// </summary>
        public void ClearAllHistory()
        {
            xmlHistory.RemoveNodes();
            xml.Save(DIR + DB_FILE);
        }

        /// <summary>
        /// Add a new, or modify an existing entry in the history database.
        /// </summary>
        /// <remarks>
        /// If the entry already exists, this method will update the last visited time.
        /// </remarks>
        /// <param name="url">
        /// The URL the user is visiting and we will add/update.
        /// </param>
        public void AddOrModifyHistoryEntry(string url)
        {
            HistoryEntry he = new HistoryEntry(HIGHEST_HISTORY_ID++, url, 0);
            he.SetVisitedWithDateTime(DateTime.UtcNow);

            // See if an entry already exists for that url (the user
            // has already visited the url). If so, set the last
            // visited time to now
            bool exists = false;

            IEnumerable<XElement> entries =
                from entry in xmlHistory.Elements()
                select entry;
            foreach (XElement entry in entries)
            {
                if ( (string)entry.Attribute("URI") == url )
                {
                    exists = true;
                    entry.SetAttributeValue("Visited", he.GetVisitedAsUnix());
                }
            }

            // If the user hasn't already visited this page, then
            // create a new entry in the history for it
            if (!exists)
            {
                XElement xhe = new XElement("HistoryEntry");
                xhe.SetAttributeValue("HistoryEntryId", he.GetID());
                xhe.SetAttributeValue("URI", he.GetURL());
                xhe.SetAttributeValue("Visited", he.GetVisitedAsUnix());

                xmlHistory.Add(xhe);
            }

            xml.Save(DIR + DB_FILE);    // Write the changes to file

            Console.WriteLine("[DbHandler] Added/Amended history entry for: " + url);
        }

        /* -------------------------------------------------------
         * Favourite Operations
         */

        /// <summary>
        /// Fetch all favourite entries in the database.
        /// </summary>
        /// <returns>
        /// A list of FavouriteEntry which each represent an entry in the Favourites database.
        /// </returns>
        public List<FavouriteEntry> GetAllFavourites()
        {
            // Create the HistoryEntry list we will return and load the 
            // xml file from the History element
            List<FavouriteEntry> feList = new List<FavouriteEntry>();

            if (!xmlFavourites.HasElements) return feList;

            IEnumerable<XElement> entries =
                from entry in xmlFavourites.Elements()
                select entry;
            foreach (XElement entry in entries)
            {

                // Keep track of the highest ID value we have used, so that
                // we know what the next entry will need to be
                if ((int)entry.Attribute("FavouriteEntryId") > HIGHEST_FAVOURITE_ID)
                {
                    HIGHEST_FAVOURITE_ID = (int)entry.Attribute("FavouriteEntryId");
                }

                // Add a new HistoryEntry object to the list with the given
                // xml information
                feList.Add(new FavouriteEntry(
                    (int)entry.Attribute("FavouriteEntryId"),
                    (string)entry.Attribute("URI"),
                    (string)entry.Attribute("Name")
                    ));
            }

            return feList;
        }

        /// <summary>
        /// Modify the name of an existing favourite entry in the database.
        /// </summary>
        /// <param name="url">The favourite URL</param>
        /// <param name="name">The favourite's new custom name</param>
        public void ModifyFavouriteEntry(string url, string name)
        {
            IEnumerable<XElement> entries =
            from entry in xmlFavourites.Elements()
            select entry;
                    foreach (XElement entry in entries)
                    {
                        if ((string)entry.Attribute("URI") == url)
                        {
                            entry.SetAttributeValue("Name", name);
                            xml.Save(DIR + DB_FILE);    // Write the changes to file
                            Console.WriteLine("[DbHandler] Modified favourite entry for: " + url);
                            return;
                        }
                    }
        }

        /// <summary>
        /// Add a new or remove an existing favourite entry.
        /// </summary>
        /// <param name="url">The favourite URL to add/remove</param>
        /// <param name="name">The custom name if setting a new favourite</param>
        public void AddOrRemoveFavouriteEntry(string url, string name)
        {
            // See if an entry already exists for that url (the user
            // has already visited the url). If so, remove from file
            IEnumerable<XElement> entries =
                from entry in xmlFavourites.Elements()
                select entry;
            foreach (XElement entry in entries)
            {
                if ((string)entry.Attribute("URI") == url)
                {
                    entry.Remove();
                    xml.Save(DIR + DB_FILE);    // Write the changes to file
                    Console.WriteLine("[DbHandler] Removed favourite entry for: " + url);
                    return;
                }
            }

            // If the user hasn't already visited this page, then
            // create a new entry in the favourites for it
            XElement xfe = new XElement("FavouriteEntry");
            xfe.SetAttributeValue("FavouriteEntryId", HIGHEST_FAVOURITE_ID++);
            xfe.SetAttributeValue("URI", url);
            xfe.SetAttributeValue("Name", name);

            xmlFavourites.Add(xfe);
            xml.Save(DIR + DB_FILE);    // Write the changes to file

            Console.WriteLine("[DbHandler] Added favourite entry for: " + url);
        }

        /// <summary>
        /// Check if a given URL is already a favourite in the database
        /// </summary>
        /// <param name="url">The URL to check</param>
        /// <returns>True if the URL is favourited already, false otherwise.</returns>
        public bool IsFavourite(string url)
        {
            IEnumerable<XElement> entries =
                from entry in xmlFavourites.Elements()
                select entry;
            foreach (XElement entry in entries)
            {
                if((string)entry.Attribute("URI") == url)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
