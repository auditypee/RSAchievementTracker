using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSAchievementTracker.DTO;

namespace RSAchievementTracker.Persistence
{
    public class GetDatabaseItems
    {

        public static List<AchievementObject> GetAllAchievements()
        {
            List<AchievementObject> achievementList = new List<AchievementObject>();

            using (var db = new AchievementsDatabaseEntities())
            {
                var achievements = db.Achievements;
                
                foreach (var achievement in achievements)
                {
                    var achievementObject = ConvertToAchObj(achievement);
                    achievementList.Add(achievementObject);
                }
            }

            return achievementList;
        }

        public static List<AchievementObject> GetCategoryAchievements(string category)
        {
            List<AchievementObject> categoryAchievements = new List<AchievementObject>();

            using (var db = new AchievementsDatabaseEntities())
            {
                var achievements = from a in db.Achievements
                                   where a.Categories.Any(c => c.Name == category)
                                   select a;

                foreach (var achievement in achievements)
                {
                    var achievementObject = ConvertToAchObj(achievement);

                    categoryAchievements.Add(achievementObject);
                }
            }

            return categoryAchievements;
        }

        public static List<AchievementObject> GetSubCategoryAchievements(string subcategory)
        {
            List<AchievementObject> subcategoryAchievements = new List<AchievementObject>();

            using (var db = new AchievementsDatabaseEntities())
            {
                var achievements = from a in db.Achievements
                                   where a.Subcategories.Any(s => s.Name == subcategory)
                                   select a;

                foreach (var achievement in achievements)
                {
                    var achievementObject = ConvertToAchObj(achievement);

                    subcategoryAchievements.Add(achievementObject);
                }
            }

            return subcategoryAchievements;
        }

        private static AchievementObject ConvertToAchObj(Achievement achievement)
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

            return achievementObject;
        }
    }
}
