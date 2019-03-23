using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSAchievementTracker.Persistence;
using RSAchievementTracker.DTO;

namespace RSAchievementTracker.Domain
{
    public class CheckEligibility
    {
        public User CurrentUser { get; set; }
        public List<AchievementObject> AchievementsList { get; set; }

        public CheckEligibility(User user)
        {
            CurrentUser = user;
            
            AchievementsList = GetDatabaseItems.GetAllAchievements();
            Eligibility();
        }
        
        private void Eligibility()
        {
            foreach (var achievement in AchievementsList)
            {
                bool eligible = CompareQuests(achievement) && CompareSkillLevels(achievement);

                achievement.AEligible = eligible;
            }
        }

        private bool CompareQuests(AchievementObject achievement)
        {
            List<string> aQuestReqs = achievement.AQuestReqs;
            List<string> usersQuests = new List<string>();
            foreach (var uq in CurrentUser.Quests)
            {
                // if user completed that quest, add it to completed quest list
                if (uq.Status == "COMPLETED")
                    usersQuests.Add(uq.Title);
            }

            // if users completed quest list doesn't contain a quest requirement, false
            foreach (var aQuestReq in aQuestReqs)
            {
                string replacedString = aQuestReq;
                if (aQuestReq.Contains("(partial)"))
                    replacedString = aQuestReq.Replace(" (partial)", "");
                if (!usersQuests.Contains(replacedString))
                    return false;
            }

            return true;
        }
        
        private bool CompareSkillLevels(AchievementObject achievement)
        {
            List<Tuple<string, int>> aSkillReqs = achievement.ASkillReqs;
            Dictionary<string, long[]> usersSkills = CurrentUser.Levels;

            foreach (var aSkillReq in aSkillReqs)
            {
                if (usersSkills.ContainsKey(aSkillReq.Item1))
                {
                    int i = (int)usersSkills[aSkillReq.Item1].ElementAt(1);
                    if (i < aSkillReq.Item2)
                        return false;
                }
                else
                    return false;
                
            }
            return true;
        }
    }
}
