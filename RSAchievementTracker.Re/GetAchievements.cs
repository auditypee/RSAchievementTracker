using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSAchievementTracker.Persistence;
using RSAchievementTracker.DTO;

namespace RSAchievementTracker.Domain
{
    public class GetAchievements
    {
        public List<AchievementObject> AllAchievements { get; set; }
        public List<AchievementObject> SkillsAchievements { get; set; }
        public List<AchievementObject> ExplorationAchievements { get; set; }
        public List<AchievementObject> CombatAchievements { get; set; }
        public List<AchievementObject> CompletionistAchievements { get; set; }
        public List<AchievementObject> MiscellaneousAchievements { get; set; }
        public List<AchievementObject> MinigamesAchievements { get; set; }
        
        public static List<AchievementObject> GetAllAchievements()
        {
            List<AchievementObject> allAchievements = new List<AchievementObject>();

            allAchievements = GetDatabaseItems.GetAllAchievements();

            return allAchievements;
        }
        
        public static List<AchievementObject> GetCategoryAchievements(string category)
        {
            List<AchievementObject> categoryAchievements = new List<AchievementObject>();

            categoryAchievements = GetDatabaseItems.GetCategoryAchievements(category);

            return categoryAchievements;
        }
    }
}
