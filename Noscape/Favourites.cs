using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Noscape
{
    /// <summary>
    /// The favourites browser window.
    /// </summary>
    public partial class FavouritesWindow : Form
    {
        DBHandler dbHandler;    // We will use an existing DbHandler, not create another

        /// <summary>
        /// Favourites browser window constructor.
        /// </summary>
        /// <param name="dbh">Reference to an existing DbHandler object.</param>
        public FavouritesWindow(DBHandler dbh)
        {
            InitializeComponent();
            dbHandler = dbh;
            loadFavourites();
            favouritesListBox.DoubleClick += new EventHandler(favouritesListBox_DoubleClick);
            favouritesListBox.Click += new EventHandler(favouritesListBox_Click);
        }

        /// <summary>
        /// Fetch all history from the database and load it into the UI.
        /// </summary>
        public void loadFavourites()
        {
            favouritesListBox.Items.Clear();
            List<FavouriteEntry> feList = dbHandler.GetAllFavourites();

            foreach (FavouriteEntry fe in feList)
            {
                favouritesListBox.Items.Add(fe);
            }
        }

        /// <summary>
        /// EventHandler for closing the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void favouritesCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// EventHandler for single clicking in the list area.
        /// 
        /// If the user has selected an entry in the list, allow the user the option to modify the entry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void favouritesListBox_Click(object sender, EventArgs e)
        {
            if (favouritesListBox.SelectedItem != null)
            {
                modifyFavouriteButton.Enabled = true;
            }
            else
            {
                modifyFavouriteButton.Enabled = false;
            }
        }

        /// <summary>
        /// EventHandler for double clicking the list area.
        /// 
        /// If the user has selected an entry in the list, trigger the main UI to load the selected URL.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void favouritesListBox_DoubleClick(object sender, EventArgs e)
        {
            if (favouritesListBox.SelectedItem != null)
            {
                FavouriteEntry fe = (FavouriteEntry)favouritesListBox.SelectedItem;

                (Application.OpenForms["Noscape"] as Noscape).LoadNewURL(fe.GetURL(), false);
            }
        }

        /// <summary>
        /// EventHandler for the user clicking the remove favourite button.
        /// 
        /// Triggers the DbHandler to remove the selected favourite entry and refreshes the main UI
        /// so that the favourite button respects the selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeFavourite_Click(object sender, EventArgs e)
        {
            if (favouritesListBox.SelectedItem != null)
            {
                FavouriteEntry fe = (FavouriteEntry)favouritesListBox.SelectedItem;

                dbHandler.AddOrRemoveFavouriteEntry(fe.GetURL(), null);
                if((Application.OpenForms["Noscape"] as Noscape).currentURL == fe.GetURL())
                {
                    (Application.OpenForms["Noscape"] as Noscape).RefreshFavouriteButton();
                }
                loadFavourites();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifyFavouriteButton_Click(object sender, EventArgs e)
        {
            if (favouritesListBox.SelectedItem != null)
            {
                foreach (Form f in Application.OpenForms)
                    if (f.Text == "Noscape: Modify Favourite")
                    {
                        return;
                    }

                FavouriteEntry fe = (FavouriteEntry)favouritesListBox.SelectedItem;
                ModifyFavouriteWindow mfw = new ModifyFavouriteWindow(dbHandler, fe.GetURL(), fe.GetName());
                mfw.Show();
            }
        }

        private void favouritesWindow_Load(object sender, EventArgs e)
        {

        }
    }

}
