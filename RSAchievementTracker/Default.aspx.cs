using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using AchievementTrackerHelper;
using System.Data;

namespace RSAchievementTracker {
    public partial class Default : Page {
        private string url;
        private Helper helper;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                // do something initially
            }
        }

        protected void trackBtn_Click(object sender, EventArgs e) {
            helper = new Helper();
            url = "https://secure.runescape.com/m=hiscore/index_lite.ws?player=";
            string username = userNameTB.Text;
            url += username;

            string userStats = "";

            // exception handling if the user does not exist or returns a 404
            try {
                // gets the website's contents
                userStats = helper.GetStats(url);

                // populates the table's data from the string
                helper.PopulateTable(userStats);

                // gets the Dictionary that contains the user's stats then creates the table
                Dictionary<string, int[]> levels = helper.Levels;
                CreateTable(levels);
            } catch (WebException we) {
                userStatsLbl.Text = string.Format("User \"{0}\" does not exist.", username);
                statsGridView.Visible = false;
            }
            
        }

        /*
         * Creates the data table from the user's stats
         */
        protected void CreateTable(Dictionary<string, int[]> data) {
            DataTable statsDataTable = new DataTable();
            // creates the columns
            statsDataTable.Columns.AddRange(new DataColumn[4] {
                new DataColumn("Skill", typeof(string)),
                new DataColumn("Level", typeof(int)),
                new DataColumn("Experience", typeof(string)),
                new DataColumn("Hiscores Rank", typeof(string))
            });

            // adds a row based on the given dictionary
            foreach (KeyValuePair<string, int[]> kvp in data) {
                //string text = string.Format("Key: {0}, Value: {1}", kvp.Key, kvp.Value.ElementAt(1));
                //System.Diagnostics.Debug.Write(text + "\n");

                statsDataTable.Rows.Add(kvp.Key, kvp.Value.ElementAt(1), helper.NumberFormat(kvp.Value.ElementAt(2)), helper.NumberFormat(kvp.Value.ElementAt(0)));
            }

            statsGridView.DataSource = statsDataTable;
            statsGridView.DataBind();
            statsGridView.Visible = true;
        }
    }
}