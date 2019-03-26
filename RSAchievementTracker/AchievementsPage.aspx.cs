using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RSAchievementTracker.Domain;
using RSAchievementTracker.DTO;

using System.Data;

// TODO: - Create buttons programmatically, otherwise it will look like boilerplate code
namespace RSAchievementTracker
{
    public partial class AchievementsPage : System.Web.UI.Page
    {
        private DataTable achievementsTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            
        }

        protected void CreateAchievementsTable(List<AchievementObject> achievements)
        {
            achievementsTable = new DataTable();

            achievementsTable.Columns.AddRange(new DataColumn[7]
            {
                new DataColumn("Name", typeof(string)),
                new DataColumn("Members", typeof(string)),
                new DataColumn("Description", typeof(string)),
                new DataColumn("Quest Requirements", typeof(string)),
                new DataColumn("Skill Requirements", typeof(string)),
                new DataColumn("Runescore", typeof(int)),
                new DataColumn("Eligible", typeof(bool))
            });

            User currentUser = (User)ViewState["User"];
            if (currentUser != null)
            {
                achievements = CheckEligibility.Eligibility(currentUser, achievements);
            }
            if (currentUser == null)
                System.Diagnostics.Debug.WriteLine("currentUser is null");


            foreach (var achievement in achievements)
            {
                string name = achievement.AName;
                string description = achievement.ADescription;
                int runescore = achievement.ARunescore;
                string members = achievement.AMembers;
                string questReqs = string.Join(@"\n", achievement.AQuestReqs.ToArray());
                string skillReqs = "";
                foreach (var skillReq in achievement.ASkillReqs)
                    skillReqs += string.Format("{0} {1}\n", skillReq.Item1, skillReq.Item2);
                string eligible = achievement.AEligible.ToString();

                achievementsTable.Rows.Add(name, members, description, 
                    questReqs, skillReqs, runescore, eligible);
            }

            ViewState.Add("AchievementsTable", achievementsTable);
        }

        protected void CategoriesBtn_Click(object sender, EventArgs e)
        {
            Button categoryBtn = (Button)sender;
            string category = categoryBtn.ID;
            

            CreateAchievementsTable(GetAchievements.GetCategoryAchievements(category));
            achievementsGridView.DataSource = achievementsTable;
            achievementsGridView.DataBind();
        }

        protected void SubcategoriesBtn_Click(object sender, EventArgs e)
        {
            Button subcategoryBtn = (Button)sender;
            string subcategory = subcategoryBtn.Text;
            

            CreateAchievementsTable(GetAchievements.GetSubcategoryAchievements(subcategory));
            achievementsGridView.DataSource = achievementsTable;
            achievementsGridView.DataBind();
        }
        
        protected void PreRenderBtnTrigger(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
             
            ScriptManager1.RegisterAsyncPostBackControl(btn);
            AchievementsUpdatePanel.Update();
        }
    }
}