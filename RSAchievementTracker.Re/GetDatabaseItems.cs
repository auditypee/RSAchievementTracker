using System;
using System.Collections.Generic;
using System.Text;
using RSAchievementTracker.Persistence;

namespace RSAchievementTracker.Domain
{
    public class GetDatabaseItems
    {
        public List<AchievementObject> AchievementsList { get; set; }

        public GetDatabaseItems()
        {
            AchievementsList = GetAchievements();
        }

        private List<AchievementObject> GetAchievements()
        {
            AchievementsDatabaseEntities db = new AchievementsDatabaseEntities();

            var achievements = db.Achievements;

            List<AchievementObject> achievementList = new List<AchievementObject>();
            foreach (var achievement in achievements)
            {
                string name = achievement.Name;
                string description = achievement.Description;
                int runescore = achievement.Runescore;
                string members = achievement.Members;

                List<string> categories = new List<string>();
                foreach (var cat in achievement.Categories)
                {
                    categories.Add(cat.Name);
                }
                
                List<string> subcategories = new List<string>();
                foreach (var sub in achievement.Subcategories)
                {
                    subcategories.Add(sub.Name);
                }

                List<string> questReqs = new List<string>();
                foreach (var que in achievement.QuestReqs)
                {
                    questReqs.Add(que.Quest);
                }

                List<Tuple<string, int>> skillReqs = new List<Tuple<string, int>>();
                foreach (var ski in achievement.SkillReqs)
                {
                    Tuple<string, int> skillLevel = new Tuple<string, int>(ski.Skill, ski.Level);
                    skillReqs.Add(skillLevel);
                }

                AchievementObject achievementObject = new AchievementObject(
                    name, description, runescore, members, categories,
                    subcategories, questReqs, skillReqs
                    );

                achievementList.Add(achievementObject);
            }

            return achievementList;
        }
    }
}
