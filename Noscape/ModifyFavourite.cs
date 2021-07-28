using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noscape
{
    /// <summary>
    /// This window allows the user to modify a favourite's custom name.
    /// </summary>
    public partial class ModifyFavouriteWindow : Form
    {
        DBHandler dbHandler;    // We will use an existing DbHandler, not create another

        /// <summary>
        /// ModifyFavouriteWindow constructor.
        /// </summary>
        /// <param name="dbh">A reference to an existing DbHandler object.</param>
        /// <param name="url">The URL of the favourite being edited (for reference only, this will not change).</param>
        /// <param name="name">The existing custom name of the favourite being edited.</param>
        public ModifyFavouriteWindow(DBHandler dbh, string url, string name)
        {
            InitializeComponent();
            dbHandler = dbh;

            modifyFURLBox.Text = url;
            modifyFNameBox.Text = name;

            modifyFNameBox.KeyDown += new KeyEventHandler(keyDown);
        }

        /// <summary>
        /// EventHandler for the user closing the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifyFCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// EventHandler for the user pressing the OK button and submitting changes.
        /// 
        /// Also triggers the UI list to refresh and respect the new custom name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifyFOkButton_Click(object sender, EventArgs e)
        {
            dbHandler.ModifyFavouriteEntry(modifyFURLBox.Text, modifyFNameBox.Text);
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Noscape: Favourites")
                {
                    FavouritesWindow fw = (FavouritesWindow)f;
                    fw.loadFavourites();
                }
            }
            Close();
        }

        /// <summary>
        /// EventHandler for the user pressing the enter key and submitting changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                modifyFOkButton_Click(sender, e);
            }
        }
    }
}
