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

        public List<AQuestReq> AQuestReqs { get; set; }
        public List<ASkillReq> ASkillReqs { get; set; }
        
        public bool AEligible { get; set; }

        public AchievementObject(string name, string description, int runescore,
            string members, List<string> categories, List<string> subcategories,
            List<string> questReqs, List<string> skillReqs)
        {
            AName = name;
            ADescription = description;
            ARunescore = runescore;
            AMembers = members;
            ACategories = categories;
            ASubcategories = subcategories;

            AQuestReqs = new List<AQuestReq>();
            foreach (var questReq in questReqs)
            {
                AQuestReq qr = new AQuestReq
                {
                    Quest = questReq,
                    CanComplete = false
                };
                AQuestReqs.Add(qr);
            }

            ASkillReqs = new List<ASkillReq>();
            foreach (var skillReq in skillReqs)
            {
                ASkillReq sr = new ASkillReq
                {
                    LevelSkill = skillReq,
                    CanComplete = false
                };
                ASkillReqs.Add(sr);
            }

            AEligible = true;
        }
    }

    [Serializable]
    public class AQuestReq
    {
        public string Quest { get; set; }
        public bool CanComplete { get; set; }
    }

    [Serializable]
    public class ASkillReq
    {
        public string LevelSkill { get; set; }
        public bool CanComplete { get; set; }
    }
}
