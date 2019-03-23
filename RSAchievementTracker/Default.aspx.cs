using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using RSAchievementTracker.Domain;
using RSAchievementTracker.DTO;
using System.Data;

namespace RSAchievementTracker
{
    public partial class Default : Page
    {
        private readonly string URLSTATS = "https://secure.runescape.com/m=hiscore/index_lite.ws?player=";
        private readonly string URLQUESTS = "https://apps.runescape.com/runemetrics/quests?user=";
        private readonly string INVALIDQUESTS = @"{""quests"":[],""loggedIn"":""false""}";

        private Helper helper;
        private CheckEligibility ce;
        private DataTable questsDataTable;
        private DataTable statsDataTable;
        private DataTable achievementsTable;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // do something initially
                MultiView.ActiveViewIndex = 0;

                CreateAchievementsTable(GetAchievements.GetAllAchievements());
            }
        }

        protected void trackBtn_Click(object sender, EventArgs e)
        {
            helper = new Helper();
            string username = userNameTB.Text;
            
            // get the user's stats
            try
            {
                // gets the website's contents
                string userStats = Helper.GetUserInfo(URLSTATS + username);

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
                string userQuests = Helper.GetUserInfo(URLQUESTS + username);

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
            // TODO: - DATA SORTABLE
            ce = new CheckEligibility(helper.CurrentUser);
            CreateAchievementsTable(ce.AchievementsList);
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
                string exp = NumberFormat(kvp.Value.ElementAt(2));
                string hiscore = NumberFormat(kvp.Value.ElementAt(0));

                statsDataTable.Rows.Add(skill, level, exp, hiscore);
            }

            ViewState.Add("StatsDataTable", statsDataTable);
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
                string difficulty = quest.DifficultyString();
                string questPoints = quest.QuestPoints.ToString();
                string members = quest.Members.ToString();
                string status = quest.StatusString();
                questsDataTable.Rows.Add(title, difficulty, questPoints, members, status);
            }

            ViewState.Add("QuestsDataTable", questsDataTable);
        }

        protected void CreateAchievementsTable(List<AchievementObject> achievements)
        {
            achievementsTable = new DataTable();

            achievementsTable.Columns.AddRange(new DataColumn[9]
            {
                new DataColumn("Name", typeof(string)),
                new DataColumn("Members", typeof(string)),
                new DataColumn("Description", typeof(string)),
                new DataColumn("Categories", typeof(string)),
                new DataColumn("Subcategories", typeof(string)),
                new DataColumn("Quest Requirements", typeof(string)),
                new DataColumn("Skill Requirements", typeof(string)),
                new DataColumn("Runescore", typeof(int)),
                new DataColumn("Eligible", typeof(bool))
            });

            foreach (var achievement in achievements)
            {
                string name = achievement.AName;
                string description = achievement.ADescription;
                int runescore = achievement.ARunescore;
                string members = achievement.AMembers;
                string categories = string.Join("\n", achievement.ACategories.ToArray());
                string subcategories = string.Join("\n", achievement.ASubcategories.ToArray());
                string questReqs = string.Join("\n", achievement.AQuestReqs.ToArray());
                string skillReqs = "";
                foreach (var skillReq in achievement.ASkillReqs)
                    skillReqs += string.Format("{0} {1}\n", skillReq.Item1, skillReq.Item2);
                string eligible = achievement.AEligible.ToString();

                achievementsTable.Rows.Add(name, members, description, categories,
                    subcategories, questReqs, skillReqs, runescore, eligible);
            }

            ViewState.Add("AchievementsTable", achievementsTable);
        }

        protected void ShowStats_Click(object sender, EventArgs e)
        {
            statsDataTable = (DataTable)ViewState["StatsDataTable"];
            if (statsDataTable != null)
            {
                statsGridView.DataSource = statsDataTable;
                statsGridView.DataBind();
            }
            else
            {
                userStatsLbl.Text = "Please input username.";
            }

            MultiView.ActiveViewIndex = 1;
            
        }

        protected void ShowQuests_Click(object sender, EventArgs e)
        {
            questsDataTable = (DataTable)ViewState["QuestsDataTable"];
            if (questsDataTable != null)
            {
                questsGridView.DataSource = questsDataTable;
                questsGridView.DataBind();
            }
            else
            {
                userQuestsLbl.Text = "Please input username.";
            }

            MultiView.ActiveViewIndex = 2;
        }

        protected void ShowAchievements_Click(object sender, EventArgs e)
        {
            achievementsTable = (DataTable)ViewState["AchievementsTable"];
            achievementsGridView.DataSource = achievementsTable;
            achievementsGridView.DataBind();

            MultiView.ActiveViewIndex = 3;
        }

        /// <summary>
        ///    Formats the given number to include commas between the nth's place
        /// </summary>
        /// <param name="num">the number to format</param>
        /// <returns>the formatted number (x,xxx,xxx)</returns>
        private string NumberFormat(long num)
        {
            return string.Format("{0:#,0}", num);
        }

        protected void MinigamesButton_Click(object sender, EventArgs e)
        {
            CreateAchievementsTable(GetAchievements.GetCategoryAchievements("Minigames"));
            achievementsGridView.DataSource = achievementsTable;
            achievementsGridView.DataBind();

            MultiView.ActiveViewIndex = 3;
        }
    }
}