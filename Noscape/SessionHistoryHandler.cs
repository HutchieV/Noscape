using System.Collections.Generic;

namespace Noscape
{

    /// <summary>
    /// This class represents a node in a custom DoubleLinkedList which itself represents a URL the user has visited, 
    /// as well as the previous and next nodes where applicable.
    /// </summary>
    /// <remarks>
    /// The DoubleLinkedList implementation allows us to traverse "backwards" and "forwards" along the list while also 
    /// allowing us to "chop of" the tail of the list at any point if the user decides to navigate to a new page,
    /// without having to do any complex list copying or deletion.
    /// </remarks>
    class SessionHistoryNode
    {
        /// <value>Gets the Next node.</value>
        public SessionHistoryNode Next { get; private set; }
        /// <value>Gets the Previous node.</value>
        public SessionHistoryNode Previous { get; private set; }
        /// <value>Gets this node's URL.</value>
        public string URL { get; private set; }

        /// <summary>
        /// SessionHistoryNode constructor.
        /// </summary>
        public SessionHistoryNode()
        {
            Next = null;
            Previous = null;
            URL = null;
        }

        /// <summary>
        /// Set this node's reference to the next node.
        /// </summary>
        /// <param name="newNext">A reference to the next SessionHistoryNode.</param>
        public void SetNext(SessionHistoryNode newNext)
        {
            Next = newNext;
        }

        /// <summary>
        /// Set this node's reference to the previous node.
        /// </summary>
        /// <param name="newPrevious">A reference to the previous SessionHistoryNode.</param>
        public void SetPrevious(SessionHistoryNode newPrevious)
        {
            Previous = newPrevious;
        }

        /// <summary>
        /// Set this node's URL value.
        /// </summary>
        /// <param name="newURL">The new URL value.</param>
        public void SetURL(string newURL)
        {
            URL = newURL;
        }
    }

    /// <summary>
    /// This class handles the in-memory session history which the Back and Next button in the UI refer to.
    /// </summary>
    /// <remarks>
    /// This information is seperate from the persistent database file.
    /// This class allows for future Noscape versions which may implement multiple "tabs" with their own tab history. 
    /// </remarks>
    class SessionHistoryHandler
    {
        private SessionHistoryNode cNode; // A reference to the current node.

        /// <summary>
        /// SessionHistoryHandler constructor.
        /// </summary>
        public SessionHistoryHandler()
        {
            cNode = new SessionHistoryNode();
        }

        /// <summary>
        /// Adds a new node to the list from the current node which represents the given URL.
        /// </summary>
        /// <remarks>
        /// If the user traverses back page(s) and then invokes this method by entering a new URL/selecting from fav/history browsers
        /// then this method will disgard the tail from the current node by setting its next node to a new value, losing the ability
        /// to traverse forwards again.
        /// </remarks>
        /// <param name="url">The new URL the user has visited.</param>
        public void AddVisited(string url)
        {
            // If the current node is the first one
            if (cNode.URL == null)
            {
                cNode.SetURL(url);
            }
            else
            {
                SessionHistoryNode nNode = new SessionHistoryNode();
                nNode.SetURL(url);
                nNode.SetPrevious(cNode);
                cNode.SetNext(nNode);
                cNode = nNode;
            }
        }

        /// <summary>
        /// Tell the Handler the user has selected the Back button and is now visiting
        /// the previous node.
        /// </summary>
        public void GoBack()
        {
            SessionHistoryNode tempNode = cNode.Previous;
            if (tempNode != null)
            {
                cNode = tempNode;
            }
        }

        /// <summary>
        /// Tell the Handler the user has selected the Next button and is now visiting
        /// the next node.
        /// </summary>
        public void GoForward()
        {
            SessionHistoryNode tempNode = cNode.Next;
            if (tempNode != null)
            {
                cNode = tempNode;
            }
        }

        /// <summary>
        /// Get the next node's (page's) URL.
        /// </summary>
        /// <returns>The next page's URL.</returns>
        public string GetNext()
        {
            SessionHistoryNode tempNode = cNode.Next;
            if(tempNode == null)
            {
                return null;
            }
            else
            {
                return tempNode.URL;
            }
        }

        /// <summary>
        /// Get the previous node's (page's) URL.
        /// </summary>
        /// <returns>The previous page's URL.</returns>
        public string GetPrevious()
        {
            SessionHistoryNode tempNode = cNode.Previous;
            if (tempNode == null)
            {
                return null;
            }
            else
            {
                return tempNode.URL;
            }
        }

        /// <summary>
        /// Get a list representation of all node in the session history.
        /// </summary>
        /// <remarks>
        /// Only used for debugging.
        /// </remarks>
        /// <returns>
        /// A list of string triplets which each represent a SessionHistoryNode in the form
        /// (Previous node's URL, This node's URL, Next node's URL)
        /// </returns>
        public List<(string, string, string)> GetAllHistory()
        {
            List<(string, string, string)> urls = new List<(string, string, string)>();
            SessionHistoryNode tempNode = cNode;

            // If there is only one node in the list (first node, before
            // the user has started browsing)
            if (cNode.Previous == null && cNode.Next == null)
            {
                urls.Add(("", cNode.URL, ""));
                return urls;
            }

            // Traverse to the end of the list
            while (tempNode.Next != null)
            {
                tempNode = tempNode.Next;
            }

            // Traverse back to the beginning, adding every URL
            // we have visited to the list we then return
            while (tempNode.Previous != null)
            {
                (string, string, string) tempString = ("", "", "");
                if (tempNode.Previous != null) tempString.Item1 = tempNode.Previous.URL;
                tempString.Item2 = tempNode.URL;
                if (tempNode.Next != null) tempString.Item3 = tempNode.Next.URL;
                urls.Add(tempString);
                tempNode = tempNode.Previous;
            }
            // Make sure we add the first node too
            urls.Add(("", tempNode.URL, tempNode.Next.URL));

            return urls;
        }
    }
}
