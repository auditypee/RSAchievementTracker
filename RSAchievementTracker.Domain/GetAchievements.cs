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
