using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Noscape
{
    /// <summary>
    /// The history browser window.
    /// </summary>
    public partial class HistoryWindow : Form
    {
        DBHandler dbHandler;    // We will use an existing DbHandler, not create another

        /// <summary>
        /// History browser window constructor.
        /// </summary>
        /// <param name="dbh">Reference to an existing DbHandler object</param>
        public HistoryWindow(DBHandler dbh)
        {
            InitializeComponent();
            dbHandler = dbh;
            LoadHistory();
            historyListBox.DoubleClick += new EventHandler(HistoryListBox_DoubleClick);
        }

        /// <summary>
        /// Fetch all history from the database and load it into the UI.
        /// </summary>
        public void LoadHistory()
        {
            historyListBox.Items.Clear();
            List<HistoryEntry> feList = dbHandler.GetAllHistory();

            foreach (HistoryEntry fe in feList)
            {
                historyListBox.Items.Add(fe.GetURL());
            }
        }

        /// <summary>
        /// EventHandler for closing the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistoryCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// EventHandler for doubling clicking the list area.
        /// 
        /// If the user has selected an entry in the list, trigger the main UI to load the selected URL.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistoryListBox_DoubleClick(object sender, EventArgs e)
        {
            if (historyListBox.SelectedItem != null)
            {
                (Application.OpenForms["Noscape"] as Noscape).LoadNewURL(historyListBox.SelectedItem.ToString(), false);
            }
        }

        /// <summary>
        /// EventHandler for selecting the Clear History button, which called the DbHandler to clear the history database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearHistory_Click(object sender, EventArgs e)
        {
            dbHandler.ClearAllHistory();
            LoadHistory();
        }
    }
}
