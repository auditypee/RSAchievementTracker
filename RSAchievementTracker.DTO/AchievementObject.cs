using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAchievementTracker.DTO
{
    [Serializable]
    public class AchievementObject
    {
        public string AName { get; set; }
        public string ADescription { get; set; }
        public int ARunescore { get; set; }
        public string AMembers { get; set; }
        public List<string> ACategories { get; set; }
        public List<string> ASubcategories { get; set; }
        public List<string> AQuestReqs { get; set; }
        public List<Tuple<string, int>> ASkillReqs { get; set; }
        public bool AEligible { get; set; }

        public AchievementObject(string name, string description, int runescore,
            string members, List<string> categories, List<string> subcategories,
            List<string> questReqs, List<Tuple<string, int>> skillReqs)
        {
            AName = name;
            ADescription = description;
            ARunescore = runescore;
            AMembers = members;
            ACategories = categories;
            ASubcategories = subcategories;
            AQuestReqs = questReqs;
            ASkillReqs = skillReqs;
            AEligible = false;
        }
    }
}
