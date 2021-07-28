using System;

namespace Noscape
{
    /// <summary>
    /// This is a class representation of an entry in the history database.
    /// </summary>
    public class HistoryEntry
    {
        private int historyEntryId;
        private string url;
        private int visited;

        /// <summary>
        /// HistoryEntry constructor.
        /// </summary>
        /// <param name="newId">The unique ID of this entry.</param>
        /// <param name="newURL">The URL of this entry.</param>
        /// <param name="newVisited">The time visited in UNIX format.</param>
        public HistoryEntry(int newId, string newURL, int newVisited)
        {
            historyEntryId = newId;
            url = newURL;
            visited = newVisited;
        }

        /// <summary>
        /// ToString override for pretty printing relevant info.
        /// </summary>
        /// <remarks>
        /// String format: "ID: [x], URL: [x], Last visited: [x]".
        /// </remarks>
        /// <returns>A string containing ID, URL and time last visited in UNIX.</returns>
        public override string ToString()
        {
            return "ID: " + historyEntryId + ", URL: " + url + ", Last visited: " + visited;
        }

        /// <summary>
        /// Get the ID of this entry.
        /// </summary>
        /// <returns>This entry's ID.</returns>
        public int GetID()
        {
            return historyEntryId;
        }

        /// <summary>
        /// Get the URL of this entry.
        /// </summary>
        /// <returns>This entry's URL.</returns>
        public string GetURL()
        {
            return url;
        }

        /// <summary>
        /// Get the last visited time of this entry.
        /// </summary>
        /// <returns>Last visited time in UNIX format.</returns>
        public int GetVisitedAsUnix()
        {
            return visited;
        }

        /// <summary>
        /// Get the last visited time of this entry.
        /// </summary>
        /// <remarks>
        /// Based on https://stackoverflow.com/a/250400
        /// </remarks>
        /// <returns>Last visited time as a DateTime object.</returns>
        public DateTime GetVisited()
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(visited).ToLocalTime();
            return dtDateTime;
        }

        /// <summary>
        /// Set the last visited time of this entry.
        /// </summary>
        /// <param name="unixTime">New last visited time in UNIX format.</param>
        public void SetVisitedWithUnix(int unixTime)
        {
            visited = unixTime;
        }

        /// <summary>
        /// Set the last visited time of this entry.
        /// </summary>
        /// <remarks>
        /// Based on https://stackoverflow.com/a/17632585
        /// </remarks>
        /// <param name="dt">New last visited time as a DateTime object.</param>
        public void SetVisitedWithDateTime(DateTime dt)
        {
            visited = (int)(dt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
