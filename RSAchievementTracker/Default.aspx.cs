using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using AchievementTrackerHelper;
using System.Data;

namespace RSAchievementTracker
{
    public partial class Default : Page
    {
        private Helper helper;
        private readonly string URLSTATS = "https://secure.runescape.com/m=hiscore/index_lite.ws?player=";
        private readonly string URLQUESTS = "https://apps.runescape.com/runemetrics/quests?user=";
        private readonly string INVALIDQUESTS = @"{""quests"":[],""loggedIn"":""false""}";
        private DataTable questsDataTable;
        private DataTable statsDataTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            helper = new Helper();
            if (!IsPostBack)
            {
                // do something initially
                MultiView.ActiveViewIndex = 0;
                
            }
        }

        protected void trackBtn_Click(object sender, EventArgs e)
        {
            //helper = new Helper();
            string username = userNameTB.Text;
            
            // get the user's stats
            try
            {
                // gets the website's contents
                string userStats = helper.GetUserInfo(URLSTATS + username);

                // populates the table's data from the string
                helper.PopulateStatsData(userStats);

                // gets the Dictionary that contains the user's stats then creates the table
                Dictionary<string, long[]> levels = helper.CurrentUser.Levels;
                CreateStatsTable(levels);
                
            }
            catch (WebException we)
            {
                userStatsLbl.Text = string.Format("User \"{0}\" does not exist.", username);
            }

            // get the user's quest progress
            try
            {
                string userQuests = helper.GetUserInfo(URLQUESTS + username);
                //System.Diagnostics.Debug.Write(userQuests);

                if (userQuests != INVALIDQUESTS)
                {
                    helper.PopulateQuestsData(userQuests);
                    List<Quest> quests = helper.CurrentUser.Quests;
                    CreateQuestsTable(quests);
                }
                else
                {
                    userQuestsLbl.Text = string.Format("User \"{0}\" has their Runemetrics profile set to private.", username);
                    questsGridView.Visible = false;
                }
            }
            catch (WebException we)
            {
                questsGridView.Visible = false;
            }
        }

        /*
         * Creates the data table from the user's stats
         */
        protected void CreateStatsTable(Dictionary<string, long[]> data)
        {
            statsDataTable = new DataTable();
            // creates the columns
            statsDataTable.Columns.AddRange(new DataColumn[4] {
                new DataColumn("Skill", typeof(string)),
                new DataColumn("Level", typeof(long)),
                new DataColumn("Experience", typeof(string)),
                new DataColumn("Hiscores Rank", typeof(string))
            });

            // adds a row based on the given dictionary
            foreach (KeyValuePair<string, long[]> kvp in data)
            {
                string skill = kvp.Key;
                long level = kvp.Value.ElementAt(1);
                string exp = helper.NumberFormat(kvp.Value.ElementAt(2));
                string hiscore = helper.NumberFormat(kvp.Value.ElementAt(0));

                statsDataTable.Rows.Add(skill, level, exp, hiscore);
            }

            ViewState.Add("statsDataTable", statsDataTable);
        }

        protected void CreateQuestsTable(List<Quest> quests)
        {
            questsDataTable = new DataTable();

            questsDataTable.Columns.AddRange(new DataColumn[5] 
            {
                new DataColumn("Name", typeof(string)),
                new DataColumn("Difficulty", typeof(string)),
                new DataColumn("Quest Points", typeof(string)),
                new DataColumn("Member", typeof(bool)),
                new DataColumn("Status", typeof(string))
            });

            foreach (var quest in quests)
            {
                string title = quest.Title;
                string difficulty = helper.ConvertDifficulty(quest.Difficulty);
                string questPoints = quest.QuestPoints.ToString();
                string members = quest.Members.ToString();
                string status = helper.ConvertStatus(quest.Status, quest.Eligible);
                questsDataTable.Rows.Add(title, difficulty, questPoints, members, status);
            }

            ViewState.Add("questsDataTable", questsDataTable);
        }

        protected void ShowStats_Click(object sender, EventArgs e)
        {
            statsDataTable = (DataTable)ViewState["statsDataTable"];
            statsGridView.DataSource = statsDataTable;
            statsGridView.DataBind();

            MultiView.ActiveViewIndex = 1;
        }

        protected void ShowQuests_Click(object sender, EventArgs e)
        {
            questsDataTable = (DataTable)ViewState["questsDataTable"];
            questsGridView.DataSource = questsDataTable;
            questsGridView.DataBind();

            MultiView.ActiveViewIndex = 2;
        }

        protected void ShowAchievements_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 3;
        }
    }
}