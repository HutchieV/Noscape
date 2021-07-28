using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noscape
{
    /// <summary>
    /// This is a class representation of an entry in the favourites database.
    /// </summary>
    public class FavouriteEntry
    {
        private int favouriteEntryId;
        private string uri;
        private string name;

        /// <summary>
        /// FavouriteEntry constructor.
        /// </summary>
        /// <param name="newId">The unique ID of this entry.</param>
        /// <param name="newURL">The URL of this entry.</param>
        /// <param name="newName">The custom name of this entry.</param>
        public FavouriteEntry(int newId, string newURL, string newName)
        {
            favouriteEntryId = newId;
            uri = newURL;
            name = newName;
        }

        /// <summary>
        /// ToString override for pretty printing relevant info.
        /// </summary>
        /// <remarks>
        /// String format: "[custom name] (url)"
        /// </remarks>
        /// <returns>A string containing the custom name and URL.</returns>
        public override string ToString()
        {
            return (name + " (" + uri + ")");
        }

        /// <summary>
        /// Get the ID of this entry.
        /// </summary>
        /// <returns></returns>
        public int GetID()
        {
            return favouriteEntryId;
        }

        /// <summary>
        /// Get the URL of this entry.
        /// </summary>
        /// <returns></returns>
        public string GetURL()
        {
            return uri;
        }

        /// <summary>
        /// Get the custom name of this entry.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return name;
        }
    }
}
