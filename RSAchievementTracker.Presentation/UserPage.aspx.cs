﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using RSAchievementTracker.Domain;
using RSAchievementTracker.DTO;
using System.Data;
using System.Web.UI.HtmlControls;

namespace RSAchievementTracker.Presentation
{
    public partial class UserPage : System.Web.UI.Page
    {
        private DataTable achievementsTable;
        private DataTable statsDataTable;
        private DataTable questsDataTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["User"] != null)
                    GetUserInfo();
                    
                MultiView.ActiveViewIndex = 0;
            }

            if (Request.QueryString["User"] != null)
                Page.Title = Request.QueryString["User"].ToString();
        }

        protected void GetUserInfo()
        {
            
            string username = Request.QueryString["User"].ToString();
            UsernameHeader.Text = username;

            InitializeUser currentUser = new InitializeUser(username);
            
            CreateStatsTable(currentUser.CurrentUser.Levels);
            if (currentUser.CurrentUser.Quests != null)
                CreateQuestsTable(currentUser.CurrentUser.Quests);

            ViewState.Add("User", currentUser.CurrentUser);
        }
        
        protected void CreateStatsTable(Dictionary<string, long[]> data)
        {
            statsDataTable = new DataTable();
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
                bool members = quest.Members;
                string status = quest.StatusString();
                questsDataTable.Rows.Add(title, difficulty, questPoints, members, status);
            }

            ViewState.Add("QuestsDataTable", questsDataTable);
        }

        protected void questsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            
        }
        
        private string NumberFormat(long num)
        {
            return string.Format("{0:#,0}", num);
        }


        /// <summary>
        /// Creates a table containing all the AchievementObject's items
        /// Should be called using DataBind.Eval() function in the .aspx file
        /// Also implements the user's data if given
        /// </summary>
        /// <param name="achievements">List of achievements that will be converted to a table</param>
        protected void CreateAchievementsTable(List<AchievementObject> achievements)
        {
            achievementsTable = new DataTable();
            
            achievementsTable.Columns.AddRange(new DataColumn[7]
            {
                new DataColumn("AchName", typeof(string)),
                new DataColumn("AchMembers", typeof(string)),
                new DataColumn("AchDescription", typeof(string)),
                new DataColumn("AchQuestReq", typeof(List<AQuestReq>)),
                new DataColumn("AchSkillReq", typeof(List<ASkillReq>)),
                new DataColumn("AchRunescore", typeof(int)),
                new DataColumn("AchEligible", typeof(bool))
            });
            
            User currentUser = (User)ViewState["User"];
            if (currentUser != null)
                achievements = CheckEligibility.Eligibility(currentUser, achievements);

            foreach (var achievement in achievements)
            {
                string name = achievement.AName;
                string description = achievement.ADescription;
                int runescore = achievement.ARunescore;
                string members = achievement.AMembers;
                string eligible = achievement.AEligible.ToString();
                var questReqs = achievement.AQuestReqs;
                var skillReqs = achievement.ASkillReqs;

                if (questReqs == null)
                    System.Diagnostics.Debug.Write("questReqs is null");

                achievementsTable.Rows.Add(name, members, description,
                    questReqs, skillReqs, runescore, eligible);
            }

            ViewState.Add("AchievementsTable", achievementsTable);
        }

        protected void AchievementsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater questReqRepeater = (Repeater)e.Item.FindControl("AchQuestReqRepeater");
                List<AQuestReq> aQuestReqs = (List<AQuestReq>)((DataRowView)e.Item.DataItem)["AchQuestReq"];
                questReqRepeater.DataSource = aQuestReqs;
                questReqRepeater.DataBind();

                Repeater skillReqRepeater = (Repeater)e.Item.FindControl("AchSkillReqRepeater");
                List<ASkillReq> aSkillReqs = (List<ASkillReq>)((DataRowView)e.Item.DataItem)["AchSkillReq"];
                skillReqRepeater.DataSource = aSkillReqs;
                skillReqRepeater.DataBind();
            }
        }

        protected void CategoriesBtn_Click(object sender, EventArgs e)
        {
            Button categoryBtn = (Button)sender;
            string category = categoryBtn.ID;

            CurrentSubcategory.Text = category;
            CreateAchievementsTable(GetAchievements.GetCategoryAchievements(category));
            AchievementsRepeater.DataSource = achievementsTable;
            AchievementsRepeater.DataBind();
        }

        protected void SubcategoriesBtn_Click(object sender, EventArgs e)
        {
            Button subcategoryBtn = (Button)sender;
            string subcategory = subcategoryBtn.Text;

            CurrentSubcategory.Text = subcategory;
            CreateAchievementsTable(GetAchievements.GetSubcategoryAchievements(subcategory));
            AchievementsRepeater.DataSource = achievementsTable;
            AchievementsRepeater.DataBind();
        }

        protected void PreRenderBtnTrigger(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            ScriptManager1.RegisterAsyncPostBackControl(btn);
            AchievementsUpdatePanel.Update();
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
                statsGridView.Visible = false;
            }

            ShowStats.CssClass += " active";
            ShowQuests.CssClass = "nav-link";
            ShowAchievements.CssClass = "nav-link";
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
                userQuestsLbl.Text = string.Format("User has their Runemetrics profile set to private.");
                questsGridView.Visible = false;
            }

            ShowStats.CssClass = "nav-link";
            ShowQuests.CssClass += " active";
            ShowAchievements.CssClass = "nav-link";
            MultiView.ActiveViewIndex = 2;
        }

        protected void ShowAchievements_Click(object sender, EventArgs e)
        {
            ShowStats.CssClass = "nav nav-link";
            ShowQuests.CssClass = "nav nav-link";
            ShowAchievements.CssClass += " active";
            MultiView.ActiveViewIndex = 3;
        }

        protected void NewSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}