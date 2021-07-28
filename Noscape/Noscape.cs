using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noscape
{
    /// <summary>
    /// This is the main UI window which allows the user to load and view URLs, navigate through their session history, 
    /// navigate to / set their homepage and open other windows which allow them to view their history and favourites.
    /// </summary>
    public partial class Noscape : Form
    {
        // Our HTTP request, XML database and Session history handlers
        HTTPHandler webHandler;
        DBHandler dbHandler;
        SessionHistoryHandler shHandler;

        /// <summary>
        /// This variable is publically visible so that Handlers may reference it, 
        /// but it can only be changed by this class.
        /// </summary>
        public  string currentURL { get; private set; }
        private string nextURL      = "";
        private string previousURL  = "";

        private string content;
        private string code;

        /// <summary>
        /// Main Noscape UI constructor.
        /// 
        /// Here we instantiate our HTTP, Database and Session history handlers and ensure we get started correctly.
        /// </summary>
        public Noscape()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Noscape starting... ");
            try
            {
                InitializeComponent();
                webHandler  = new HTTPHandler();
                dbHandler   = new DBHandler();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("An error occured when trying to create the database file!");
                Close();
            }
            Console.WriteLine("Loading homepage...");
            shHandler = new SessionHistoryHandler();
            LoadNewURL(dbHandler.GetHomepage(), false);
            Console.WriteLine("Noscape started.");
            Console.WriteLine("=================================");

            urlTextBox.KeyDown += new KeyEventHandler(url_KeyDown);
        }

        /// <summary>
        /// Refresh the favourite toggle button so that it respects whether the current page has been favourited.
        /// </summary>
        public void RefreshFavouriteButton()
        {
            if (dbHandler.IsFavourite(currentURL))
            {
                toggleFavouriteButton.Text = "Remove from Favourites ★";
            }
            else
            {
                toggleFavouriteButton.Text = "Add to Favourites ☆";
            }
        }

        /// <summary>
        /// Refresh the homepage toggle button so that it respects whether the current page has been set as the homepage.
        /// </summary>
        private void RefreshHomepageButton()
        {
            if (dbHandler.IsHomepage(currentURL))
            {
                setHomepageButton.Enabled = false;
            }
            else
            {
                setHomepageButton.Enabled = true;
            }
        }

        /// <summary>
        /// Refresh the Next/Forward button so that it allows the user to traverse their history forwards
        /// only if applicable.
        /// </summary>
        private void RefreshNextButton()
        {
            nextURL = shHandler.GetNext();
            if (nextURL == null)
            {
                nextButton.Enabled = false;
            }
            else
            {
                nextButton.Enabled = true;
            }
        }

        /// <summary>
        /// Refresh the Back/Previous button so that it allows the user to traverse their history backwards
        /// only if applicable.
        /// </summary>
        private void RefreshPreviousButton()
        {
            previousURL = shHandler.GetPrevious();
            if (previousURL == null)
            {
                previousButton.Enabled = false;
            }
            else
            {
                previousButton.Enabled = true;
            }
        }

        /// <summary>
        /// Refresh the URL bar so that the dropdown options respect the up-to-date browsing history.
        /// </summary>
        private void RefreshURLBar()
        {
            urlTextBox.BeginUpdate();
            urlTextBox.Items.Clear();
            List<HistoryEntry> heList = dbHandler.GetAllHistory();
            foreach(HistoryEntry he in heList)
            {
                urlTextBox.Items.Add(he.GetURL());
            }
            urlTextBox.EndUpdate();
        }

        /// <summary>
        /// Refresh the current page's title.
        /// </summary>
        private void RefreshTitle()
        {
            string title = GetPageTitle();
            currentPageLabel.Text = title + " " + code;
            this.Text = "Noscape: " + title;
        }

        /// <summary>
        /// Attempt to get the current page's title via HTML elements if they exist.
        /// </summary>
        /// <returns>A string representing either the accurate title or just the given URL if we couldn't find one.</returns>
        private string GetPageTitle()
        {
            Match title = Regex.Match(content, "<title>(.*?)</title>");
            if (title.Success)
            {
                return title.Value.Substring(7, title.Value.Length - 15);
            }
            else
            {
                return currentURL;
            }
        }

        /// <summary>
        /// This method is responsible for fetching a new resource, handling its 
        /// response and updating the UI accordingly.
        /// </summary>
        /// <remarks>
        /// Method is public to allow other windows to force a refresh or change of URL
        /// (for example, when a user elects to load something from their history or
        /// favourites).
        /// </remarks>
        /// <param name="newURL">The new URL the user wishes to navigate to.</param>
        /// <param name="breadcrumbs">True if the user has navigated to the URL using the back/next buttons, false otherwise.</param>
        public async void LoadNewURL(String newURL, bool breadcrumbs)
        {
            tspBar.Value = 0;

            // If the user has entered an incomplete URL such as google.com, we
            // assume they meant http://google.com (and that a sensibly configured
            // server will redirect to https:// if necessary!)
            if ( ! newURL.StartsWith("http://") && ! newURL.StartsWith("https://") )
            {
                newURL = "http://" + newURL;
            }

            tspBar.Value = 20;

            // Debug info and resetting interface
            currentURL = newURL;
            Console.WriteLine("Navigating to URL: {0}", newURL);
            htmlTextBox.Text = "";
            urlTextBox.Text = newURL;

            // If we navigated to this page via the back/forward buttons we
            // do not want to add another entry to the session history
            if(!breadcrumbs)
            {
                shHandler.AddVisited(newURL);
            }

            pageStatusLabel.Text = "Page Status: Loading...";

            // Refresh various UI elements to respect current page
            RefreshFavouriteButton();
            RefreshHomepageButton();
            RefreshNextButton();
            RefreshPreviousButton();
            RefreshURLBar();

            tspBar.Value = 40;

            try
            {
                // Asynchonous section to fetch the resource
                HttpResponseMessage response = await webHandler.GetHTMLAsync(newURL);

                tspBar.Value = 60;

                content = response.Content.ReadAsStringAsync().Result;
                code = response.StatusCode.ToString();

                RefreshTitle();
                pageStatusLabel.Text = ("Page Status: " + code);

                // Handle various HTTP error codes
                switch (code)
                {
                    case "OK":
                        htmlTextBox.Text += content;
                        break;
                    case "NotFound": 
                        htmlTextBox.Text = "Error 404: Unfortunately this resource or page could not be found.\r\n\r\n";
                        htmlTextBox.Text += content;
                        break;
                    case "Forbidden":
                        htmlTextBox.Text = "Error 403: Access to this resource or page is forbidden.\r\n\r\n";
                        htmlTextBox.Text += content;
                        break;
                    case "BadRequest":
                        htmlTextBox.Text = "Error 400: Unfortunately the server reported a bad request.\r\n\r\n";
                        htmlTextBox.Text += content;
                        break;
                    default:
                        htmlTextBox.Text = "Error: Unfortunately an error was encountered: " + code + "\r\n\r\n";
                        htmlTextBox.Text += content;
                        break;
                }

            }
            catch (HttpRequestException e)
            {
                // Bad connection
                pageStatusLabel.Text = ("Page Status: Exception thrown");
                htmlTextBox.Text = "Failed the load the URL: " + newURL + "\r\n\r\n" +
                    "This could be due to poor internet connectivity, DNS failure, an invalid SSL certificate or server timeout.\r\n\r\n" +
                    e;
            }
            catch (InvalidOperationException e)
            {
                // Bad user input for URL
                pageStatusLabel.Text = ("Page Status: Exception thrown");
                htmlTextBox.Text = "Failed the load the URL: " + newURL + "\r\n\r\n" +
                    "Make sure the given URL is a full URI or BaseAddress.\r\n\r\n" +
                    e;
            }
            catch (TaskCanceledException)
            {
                // We do nothing in this event, as the task was canceled (probably to
                // load a new page) and we don't want the previous page loading after,
                // or an error message to get in the way
            }
            catch (Exception e)
            {
                // An unknown exception occured
                pageStatusLabel.Text = ("Page Status: Exception thrown");
                htmlTextBox.Text = "Failed the load the URL: " + newURL + "\r\n\r\n" +
                    "An unknown exception occured.\r\n\r\n" +
                    e;
            }

            tspBar.Value = 80;

            // Add a new persistent history entry or update the last visited
            // time for this resource
            dbHandler.AddOrModifyHistoryEntry(newURL);
            foreach (Form f in Application.OpenForms)
            {
                // If the history browser is open, make it refresh the list
                // to show the newly visited page
                if (f.Text == "Noscape: History")
                {
                    HistoryWindow hw = (HistoryWindow)f;
                    hw.LoadHistory();
                }
            }

            tspBar.Value = 0;
        }

        /*
         * Event handlers from this point on!
         */

        void url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadNewURL(urlTextBox.Text, false);
            }
        }

        private void loadUrlButton_Click(object sender, EventArgs e)
        {
            LoadNewURL(urlTextBox.Text, false);
        }

        private void homepageButton_Click(object sender, EventArgs e)
        {
            LoadNewURL(dbHandler.GetHomepage(), false);
        }

        private void setHomepageButton_Click(object sender, EventArgs e)
        {
            dbHandler.SetHomepage(currentURL);
            setHomepageButton.Enabled = false;
        }

        private void toggleFavouriteButton_Click(object sender, EventArgs e)
        {
            dbHandler.AddOrRemoveFavouriteEntry(currentURL, GetPageTitle());
            if (toggleFavouriteButton.Text.StartsWith("Add"))
            {
                toggleFavouriteButton.Text = "Remove from Favourites ★";
                bool editing = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == "Noscape: Modify Favourite")
                    {
                        editing = true;
                    }
                }
                if (!editing)
                {
                    ModifyFavouriteWindow mfw = new ModifyFavouriteWindow(dbHandler, currentURL, GetPageTitle());
                    mfw.Show();
                }
            }
            else
            {
                toggleFavouriteButton.Text = "Add to Favourites ☆";
            }

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Noscape: Favourites")
                {
                    FavouritesWindow fw = (FavouritesWindow)f;
                    fw.loadFavourites();
                }
            }
        }

        private void favouritesButton_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Noscape: Favourites") return;
            }

            var fWindow = new FavouritesWindow(dbHandler);
            fWindow.Show();
        }
        private void historyButton_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Noscape: History") return;
            }

            var hWindow = new HistoryWindow(dbHandler);
            hWindow.Show();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            shHandler.GoBack();
            LoadNewURL(previousURL, true);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            shHandler.GoForward();
            LoadNewURL(nextURL, true);
        }

    }
}
