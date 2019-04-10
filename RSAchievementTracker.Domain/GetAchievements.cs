using RSAchievementTracker.DTO;
using RSAchievementTracker.Persistence;
using System.Collections.Generic;

namespace RSAchievementTracker.Domain
{
    public class GetAchievements
    {
        public static List<AchievementObject> GetAllAchievements()
        {
            return GetDatabaseItems.GetAllAchievements();
        }

        public static List<AchievementObject> GetCategoryAchievements(string category)
        {
            return GetDatabaseItems.GetCategoryAchievements(category);
        }

        public static List<AchievementObject> GetSubcategoryAchievements(string subcategory)
        {
            return GetDatabaseItems.GetSubCategoryAchievements(subcategory);
        }
    }
}